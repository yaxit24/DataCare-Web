# X13 incoming calculation contract: independent source and IL review

Reviewed by the saved-return UI owner, independently of the original contract/vector author and the upcoming core implementer. This review did not change the existing contract, original35 vectors, product code or tests, and did not run a database/browser. Root subsequently authorized additive width vectors and an independent review of the upcoming pure kernel; no numeric UI save or writer is authorized by this artifact.

## Review result

No incorrect bounded numeric expectation was found in the35 original vectors by direct comparison with the complete primary `MSG_PR_LeaveCell` and `CommPassTotal_Pr`. Their non-obvious zero retention, whole-unit half-even rounding, K inversion differences, manual negative-labour blank and MRP/tax outcomes match the source expressions at the declared pre-aggregate observation point. This is a source/arithmetic review, not executable desktop confirmation and not an exhaustive proof of the entire function.

A material ambiguity **can now be resolved from the original assembly**: both single-index guards are `ColWidth`. The reducer must also preserve exact decimal text and original event boundaries. The following corrections and additional cases should be applied to the implementation contract; the frozen original artifacts remain unchanged so the evidence history is clear.

## 1. Resolved blocking ambiguity: the single-index member is column width

Original assembly `DataCareNext.exe` was read with the already installed ILSpy10.1.0.8386 under .NET10.0.8. This does not execute the Windows business application. The extraction command completed with exit0:

    DOTNET_ROOT=/opt/homebrew/opt/dotnet/libexec /Users/yakshitsavaliya/.dotnet/tools/ilspycmd --disable-updatecheck -il -t DataCareNext.TR_SALE_RTN ../DataCareNext.exe

The tool emitted whole-assembly IL; the complete three relevant methods were extracted into `x13-calculation-il-review-excerpts.txt` and hashed below. No unresolved decompiler indexer name is used as the evidence.

| Source location | Exact assembly evidence | Consequence |
| --- | --- | --- |
| `MSG_PR_LeaveCell`4594 | Method RVA0x7c2150; IL_0033 gets active Col, IL_0038 calls `AxMSFlexGrid.get_ColWidth(int32)` | A zero-width active column skips the entire leave operation before text assignment/calculation. It is not a zero-valued numeric cell guard. |
| `CommPassTotal_Pr`4919 | Method RVA0x7c30d0; IL_065f loads18, IL_0661 calls `get_ColWidth(int32)`, IL_0667 compares unequal tozero | Global F uses the Fine branch when Fine width is nonzero, independently of the displayed Fine value. |
| `MSG_PR_CLEAR`3635–3637 | Method RVA0x7bd864; IL_0441 calls `set_ColWidth(18, round(1000*ColCon))`; IL_044b separately calls `set_ColAlignment(18,7)` | The apparently overwritten width in the decompiled C# is actually a different alignment setter. The default width is not7. |
| `MSG_PR_CLEAR`3746–3753 | IL_0af2 reads YES_NO, IL_0b02 compares N, IL_0b14 calls `set_ColWidth(activeColumn,0)` | The SALES RETURNE column configuration can suppress the Fine basis. Relabeling the heading does not itself select the calculation basis. |

The current contract's “unidentified COM property” and unresolved-probe entries should be superseded by this evidence. Keep the remaining deployment question explicit: the server must resolve/version the source-derived effective width or visibility from the scoped `DC_Main.RsClDetl`/COL_DETL configuration and default setup. Browser viewport width, CSS scrolling, a hidden mobile layout, or the value of Fine is not source authority. Duplicate configuration resolution and actual runtime overrides still require a deterministic policy.

`x13-calculation-width-independentvectors.json` adds8 manually derived vectors without changing the original35. They use global F and explicit active/Fine widths. In the main pair, net10, ghat1, touch90 and stale displayed Fine7.777 produce Fine9.900/metal990 when Fine width is nonzero; width0 retains Fine7.777 and prices net10 for metal1000. A zero displayed Fine does not disable the visible branch, and a nonzero Fine does not enable a hidden branch. Other cases cover zero touch falling back to net despite displayed Fine=net+ghat, active-column width0 skipping the whole leave, and ghat-only events refreshing Fine only in the visible F branch. Expectations are before aggregate callbacks, not persisted totals.

## 2. Decimal-string implementation must avoid the existing Number-returning round helpers

The inspected pre-round7 `money.ts` hash is `7e176f0adeea92f7cabf981b0cd281bd493e1168e7672278c9f631a3d87168dc`. Its `round` and `roundHalfEven` return JavaScript Number via toNumber. Copying those helpers directly into a string-state reducer can discard large exact decimal values even if the input and final DTO are strings.

The contract's “reuse named rounding primitives” needs an explicit qualification: reuse rounding **modes/semantics**, with Decimal/string output after each source formatting point, or reject an unsupported numerical roundtrip. Do not silently route a full-width imported value through Number. Use separate F2/F3/whole-format and Math.Round-to-even primitives; do not collapse two-step configured rounding plus F2 into one rounding operation. Numeric-state comparison must compare parsed numeric values, while untouched cell strings and source-written cache strings retain their separate formatting.

The existing binary64 K probe is correctly unresolved: source4949/4952 evaluates basis*(rate/divisor), rather than algebraically regrouping all expressions. A mathematical Decimal kernel can be bounded and tested, but must not claim bit-for-bit legacy Double/Val/Strings.Format behavior at all binary/culture boundaries. Strict malformed/NaN/infinite/divide-by-zero containment remains a deliberate web decision with recoverable unchanged state, not an observed desktop error result.

## 3. Manual-total mismatch guard does not enclose the whole manual-total block

Source5077–5110 limits the residual labour/inverse-rate rewrite to editor text unequal to the computed total. However,5111–5115 are outside that inequality: active column36 with zero MRP and zero tax still writes total/net from editor text and can recompute labour percentage even when the total was numerically unchanged. The existing prose has the correct operations, but the indentation/scope must be explicit for a lower model implementing the reducer.

A recommended independent case, over the original base cells: item rate19/cache49=10.00; labour%21/cache66=10.00; labour rate23/cache58=2.00; labour amount24=20.00; other27=10.00; leave36 with original text130. Expected metal20=100.00, total36/net38=130.00, percentage21=20.000, while cache66 remains10.00. No residual labour inversion was needed. A reducer that returns early when editor equals computed total misses that percentage write.

Also retain original pre-format editor text: with the same rate/amount/other but zero labour%, leave36 text130.004 formats the visible total to130.00, yet the source compares original130.004 to computed130.00, runs the residual branch and rewrites cache58 through `Conversions.ToString(Val(rate))` to2 rather than retaining2.00 (5077/5108). Comparing only the formatted cell loses the event distinction. Exact formatting edge behavior remains separately qualified.

## 4. F1 and hydration vectors are bounded event inputs, not full source-transfer proof

The original `f1-calls-calculation-and-leaves-pct-cache` vector correctly shows the incoming cache66 effect, but it is not a complete source-copied row. Source3938–3944 copies source LBR_RATE into both23 and31 and source LBR_AMT into both24 and32. Its initial23=3.00/24=37.37 with base31=0.00/32=0.00 is therefore not the complete post-F1 copy state from the source it describes. The bounded incoming expected subset is valid; do not call passing it proof of F1 copy/admission.

Recommended additive correction when a full source-copy wrapper exists: initial31=3.00,32=37.37 alongside the current copied values; source tag rate remains3.00 and its amount becomes30.00 for net10 after calculation, while incoming rate becomes2.00 and incoming amount20.00. Preserve prior30/66 exactly because the inspected F1 block does not assign those cells. Original children/source identity/admitted identity remain a separate server-resolved contract.

Similarly, `savedHydration` is valid as a formatted-cell cache-seeding test, not proof that the entire raw imported DTO can be normalized and resaved. Source10377–10417 formats visible values/caches. Round6 intentionally retains immutable exact raw values separately. Define the raw-to-visible projection and cache seeding explicitly, with no row calculation during load, and only use a journal to justify later writes.

## 5. Resolved labour-code event includes a tag-code fallback

The LCode description omits source4289–4292: after selecting the saved LBR_CODE into13, a blank TgLCode29 is filled with the same code. This happens in addition to category value assignment and before calculation4319; it does not copy all incoming labour amounts into tag amounts. A resolved master-action wrapper should preserve this exact text effect. Plain LeaveCell13 remains text-only; it is not the same event as Enter with resolved master data. This does not block a kernel limited to direct calculator/leave events, but it blocks claiming complete LCode action parity.

## Additional high-value branch tests

These are coverage requirements rather than arithmetic corrections to the original35:

- **Zero incoming labour rate differs from zero item rate.** Source4969–4995 writes amount0 when a previously nonzero cached rate is cleared, whereas4941 skips the metal amount write when item rate iszero. Do not use a shared blanket “zero retains amount” rule.
- **Unusual metal sum guard.** Source4941 requires basis+pieces!=0. With net basis−2, pieces2 and a nonzero new item rate, the old metal amount is retained even though either operand alone is nonzero.
- **K tax inverse uses gross.** With gross20/net10, old metal100, labour50, rate/cache2, typeK, zero item rate and a new tax20, total150 extracts net125 and residual labour25; source5144 derives rate1250.00 from gross20. It must not produce2500.00 from net10.
- **Unknown labour type branches are different by stage.** Forward/generation/manual-total use a gross default (4992/5017/5105), but the final tax inversion has only explicit P/N/K/G checks and otherwise retains the visible rate before writing cache58 (5127–5150). The existing gross vector's purpose mentions unknown types but its input only tests G.
- **Cache/reset and zero conditions.** Include percentage cleared tozero with nonzero item rate, tax cleared after a saved nonzero tax cache, tag% cleared while tag rate remains nonzero, a manual Fine commit under zero versus nonzero touch, and MsLbrRof0/1/3 at separate forward/tag/inverse sites. Preserve source formatting and skipped writes, not just final arithmetic totals.
- **No unintended row mutation.** Each rejected/guard-skipped event must retain immutable raw data, row identity, all unrelated/unknown slots41/42, other rows and the journal. Do not let rejected math partially update a cache or consume a source selection.

## Reducer readiness and remaining blockers

A Return-specific pure kernel is implementable now with exact string state, source-mapped caches, ordered events, explicit effective column width, source-literal branch ordering and recoverable unsupported outcomes. No remaining unidentified property prevents the nonzero/zero Fine width branches. This review does not authorize a numeric saved-return writer or UI control: versioned original-source selection, complete tag admission/consumption, children, stock/ledger/tax/outstanding/reversal and header aggregate behavior remain separate blockers.

The upcoming independent implementation review should run the original35 plus the additive8 width vectors, inspect cache/whole-state preservation and add adversarial branch cases above. Expected values must not be generated by the implementation under review. Match formulas to their exact source sites rather than importing Order's different cache state machine.

## Capture and validation

Captured UTC: 2026-09-11T08:43:23.137250+00:00

The new8-vector artifact was parsed; IDs are unique, cell keys are within0–70, expected/input cells are strings, and the pinned original35-vector hash remained unchanged. This is structural validation plus independent source arithmetic, not an executed reducer. IL extraction exited0. The initial ILSpy invocation lacked DOTNET_ROOT and failed before reading the assembly; supplying the already installed Homebrew runtime resolved the environment issue without installing anything or running the desktop application.

| Path relative to Desktop/imodule-extracted | SHA-256 |
| --- | --- |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-incoming-calculation-contract.md` | `3a60edd05ab8837cfffe24283c45e2a91a1421d1ba9cc771b22d9aba756fb5c0` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/independentexpectedvectors.json` | `ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-calculation-width-independentvectors.json` | `3c0bef2a5aa86fca83d8c0e98b56e36c553595f2b941a06642409ce7e631d309` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-calculation-il-review-excerpts.txt` | `8c60e56122820e7fc18cb35aed07188f5016f185ed1d219f7661566facf09144` |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `DataCareNext.exe` | `c85f93fd336853a2a639c6452b47748290a1dddb214e2fdf3fc78f47bc0ca6c8` |
