# X13 incoming Return calculation: primary source contract for the next slice

Status: source investigation and independent arithmetic vectors only. No production code, test, database, or browser change is made by this document. This does not complete X13 or authorize a numeric saved-return writer. Round6's saved metadata service must remain separate until the numeric write set, original-source admission, companions, reversal, and accounting have their own complete contract.

Primary source: `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs`, `MSG_PR_LeaveCell`4592–4664 and complete `CommPassTotal_Pr`4866–5160. The companion `independentexpectedvectors.json` contains manually derived row-level expectations, independent of a new implementation. It is not an executable-desktop capture. Expected cells are observed immediately before the aggregate callbacks at5157–5158; it does not predict the full `BILL_TOTAL` or persisted voucher outcome.

## Execution boundary and event contract

`CommPassTotal_Pr(int CRow)` never reads `CRow`. It uses the live `MSG_PR.Row` for every row operation, and the live `MSG_PR.Col` plus `TEXT_PR.Text` for the manual-total branch. A web event must therefore retain the selected row identity, committed column, original text, prior visible values and prior cache values. A pure function of the final database row cannot reproduce the source order.

`MSG_PR_LeaveCell` returns without mutation if `MsgPrClear`, row0, single-index `MSG_PR[MSG_PR.Col] == 0`, or the text editor is invisible (4594). The single-index member is a COM control property, not the current cell value; its exact imported member identity is unresolved here. All supplied ordinary-commit vectors explicitly assume the event passes these guards. Do not treat an empty/zero numeric cell as the visibility guard.

| Leave column(s) | Before calculation | Calculation called? |
| --- | --- | --- |
| 0,2,3,4,5,6,7,8,13,22,29,39 | Copy text without trimming (4616–4628) | No |
| 1 | May call `NewTagNo` for a nonempty item with empty tag on the final A row (4600–4605) | No direct call here; tag identity workflow is separate |
| 9 | `Format(Val(text), "0")` (4630–4633) | Yes |
| 21,23,24,25,26,28 | `Format(Val(text), "0.00")` (4607–4615) | Yes |
| 14,16,17,19,20,27,30,31,32,33,34,35,36,37,38,41 | Two-decimal format (4634–4652) | Yes |
| 10,11,12,15,18,42 | Three-decimal format (4653–4661) | Yes |
| Other hidden columns | No switch case in this handler | No |

Consequences: a direct labour-type text commit does not recalculate; neither does HUID/description. A numeric blur calls the function even if the entered numeric value is unchanged. Direct ItAmt/LAmt/discount/net edits can be overwritten by later branches during the same call. `TEXT_PR_TextChanged`3805–3807 is empty; typing itself is not a calculation event. Enter on gross has its own call at4389–4390, rejects zero gross when rate type is not P, hides the parent editor and moves to the child grid (4383–4397). Do not produce a second invented blur trigger after that hidden-editor transition.

Original-sale F1 at3880–4026 is a different event. It requires blank item-editor text, a selected original voucher and book, loads the source parent/children, and **calls this calculation at4023**. It is not Sales Order's no-calculation Design F1. Source parent copy initializes caches45–49 and58, and67 from tax (3924–3955), but does not initialize cache66 alongside copied labour%21 (3936); an existing/blank66 therefore affects the first calculation. Saved hydration does initialize66 from persisted LBR_PRC (10390–10391), initializes the other caches from persisted values (10377–10416), then calls aggregate fill at10447 without calling `CommPassTotal_Pr` for every row.

F1 sets OLD_SRNO cell51 to the incoming visual row (3913), never copies the original sold instance into admitted cell40, and copies original children from `SL_IDTL` into `RtnIdtl` (3988–4018). `CommPassAdd_Pr`3782–3802 already generates an initial cell40 identity; save only generates another when cell40 is zero (14482–14497). Preserve original sale identity, incoming OLD_SRNO, and admitted VCH_SRNO separately. New rows use one piece, configured `MsLbrType`, A mode, N approval/employee/image defaults (3785–3792); they do not initialize every calculation cache to its visible value.

LCode and TgLCode Enter actions also call the calculator (4319/4380), despite their plain text Leave cases not calling it. LCode category mapping4294–4317:01→rate23;02→percentage21;03→amount24;04→west17;05→ghat%14;06→type K plus rate23;07→MRP28. Changing LCode clears23/24/21/14/17/28 first (4279–4286), retaining caches and other cells. TgLCode clears31/32/30/35, then maps01/06→tag rate31,02→tag%30,03→tag amount32,07→tag MRP35 (4353–4377); category06 does not assign labour type. A later slice must journal these resolved master actions independently of simple text commits.

## Complete incoming grid map

The grid has71 columns (3568). Labels come from3582–3703; hidden slots are3704–3734. `COL_DETL` configuration can hide/relabel named columns (3746–3753). Width and alignment setters are collapsed to the same single-index syntax by this decompilation; the table below identifies values, not a proven final COM visibility state.

| Col | Label/value | Persisted/source role |
| --- | --- | --- |
| 0 | Sr | Visual incoming row; saved reader renumbers display at10359; do not use as persisted key |
| 1 | RecCode | IT_CODE |
| 2 | TagNo | TAG_NO |
| 3 | Receive Item | ITM_REMARK; saved display falls back to item name10362–10368 |
| 4 | Counter | TBL_CODE |
| 5 | Design | DESIGN_NO |
| 6 | Style | ITM_STYLE; initial visible label only for MsSoftType A/E3595–3604 |
| 7 | Size | ITM_SIZE |
| 8 | HmId | HM_ID |
| 9 | Pcs | ITM_PCS; cell commits whole pieces |
| 10 | GrWt | ITM_GWT |
| 11 | OthWt | ITM_OTH_WT |
| 12 | NetWt | ITM_NWT |
| 13 | LCode | LBR_CODE |
| 14 | Ght% | ITM_GHT_PRC |
| 15 | GhtWt | ITM_GHT_WT |
| 16 | Touch | ITM_TOUCH |
| 17 | West% | ITM_WEST_PRC |
| 18 | Fine | ITM_FINE |
| 19 | Rate | ITM_RATE |
| 20 | ItAmt | ITM_AMT |
| 21 | Lbr% | LBR_PRC |
| 22 | Ltype | LBR_TYPE |
| 23 | LRate | LBR_RATE |
| 24 | LAmt | LBR_AMT |
| 25 | LDisc% | DISC_PRC |
| 26 | LDiscAmt | DISC_AMT |
| 27 | OthAmt | OTH_AMT |
| 28 | RtnMrp | ITM_MRP |
| 29 | TgLCode | TAG_LBR_CODE; saved blank falls back to LBR_CODE10400–10404 |
| 30 | Tag% | TAG_LBR_PRC |
| 31 | TagLRate | TAG_LBR_RATE |
| 32 | TagLAmt | TAG_LBR_AMT |
| 33 | TagOtAmt | TAG_OTH_AMT |
| 34 | TagCost | TAG_COST |
| 35 | TagMrp | TAG_MRP |
| 36 | TotAmt | TOT_AMT; manual total logic uses active editor text |
| 37 | TaxPrc | TAX_PRC |
| 38 | NetAmt | NET_AMT; overwritten by final tax-cache branch |
| 39 | KrCode | KR_NAME |
| 40 | Hidden admitted instance | VCH_SRNO; not original sold instance |
| 41 | Hidden unidentified numeric slot | Two-decimal Leave case; no row read/write meaning established by inspected source |
| 42 | Hidden unidentified numeric slot | Three-decimal Leave case, aggregated at5192; no business meaning established |
| 43 | Hidden item type | IT_TYPE |
| 44 | Hidden item rate basis | RATE_TYPE; P,1,K,default branches |
| 45 | Hidden prior gross | Cached10, initialized three decimals |
| 46 | Hidden prior net | Cached12, initialized three decimals |
| 47 | Hidden prior touch | Cached16, initialized two decimals |
| 48 | Hidden prior west | Cached17, initialized two decimals |
| 49 | Hidden prior item rate | Cached19, initialized two decimals |
| 50 | Hidden approval issue | APR_ISU |
| 51 | Hidden saved old row | OLD_SRNO; not proof of original sale SR_NO |
| 52 | Hidden product | PR_CODE |
| 53 | Hidden prior product copy | PR_CODE copy; retained for tag workflow |
| 54 | Hidden tag type | TAG_TYPE on saved load; original F1 initially copies source IT_TYPE3959 |
| 55 | Hidden prior tag-type copy | Saved TAG_TYPE copy; original F1 copies IT_TYPE3960 |
| 56 | Hidden tag serial | TAG_SRNO |
| 57 | Hidden row mode | A for new3788; E for loaded10436 |
| 58 | Hidden prior labour rate | Cached23; **no separate amount24 cache** in this function |
| 59,60,61 | Hidden additional hallmark IDs | HM_ID2,HM_ID3,HM_ID4 |
| 62,63,64,65 | Hidden hallmark weights | HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT |
| 66 | Hidden prior labour% | Cached21; reset by changed item rate |
| 67 | Hidden prior tax% | Cached37; reset by changed item rate, labour% or labour rate |
| 68 | Hidden employee issue | EMP_ISU |
| 69 | Hidden image identity | DESIGN_IMG_ID |
| 70 | Hidden data type | DATA_TYPE; defaulting on save is a separate contract |

Parent saved hydration is10353–10438; incoming column-to-database writing is14319–14584. Cell41/42 remain explicitly unidentified, rather than being assigned speculative bag/less/stock semantics.

## Settings and rounding

| Runtime value | Source setting/default | Effect inside this function |
| --- | --- | --- |
| MsSlAmtType | CO_SET.SL_AMT_TYPE; load MS_OPNCOMP686; blank→N881–883 | G chooses gross; F uses the unresolved column-property branch; all other values choose net+ghat |
| MsLbrRof | CO_SET.LBR_ROF; load691; values>3→0817–819; UI choices0–3 UT_SETTING4280–4283 | Precision of derived rates, tag labour and discounts, **not** normal incoming metal/forward labour amount |
| MsLbrWithGht | CO_SET_NEW.LBR_WITH_GHT; load948/1006; blank→Y1224–1226 | N labour excludes ghat only when exact setting N; K normally always adds ghat |
| MsLbrGen | CO_SET.LBR_RATE_GEN; load675; blank→N757–759 | Enables amount→rate derivation only when visible labour rate equals cached58 and amount is nonzero |
| MsAllRofRemove | CO_SET.ALL_ROF_REMOVE | Y overrides MsLbrRof to2 at MS_OPNCOMP1297–1303; hardcoded Math.Round(...,0) sites remain whole-rupee |

The setting UI also offers `Pcs Wise` for global SlAmtType (UT_SETTING_MAIN8489), but this primary incoming function does **not** implement a separate global P branch: P follows net+ghat unless row RATE_TYPE44 is P. Do not infer a pieces branch from the setting label alone.

Use separate primitives as the existing core `money.ts` does: explicit `.NET Math.Round(x,n)` defaults to midpoint-to-even; ordinary `Strings.Format` is a separate decimal cell-format step. `orderLabour.ts` and `designCalc.ts` already distinguish `roundHalfEven` from `round`. Reuse these primitives after checking supported runtime precision, but **do not call the Order labour state machine**: its amount→percentage→rate cache sequence differs from this source. Returned money is often formatted to two decimals after rounding at configured precision; a three-decimal rate intermediate may therefore be formatted again to two decimals. A negative configured precision has no normalization guard in the inspected loader and needs an explicit validation decision.

The independent vectors avoid uncertain binary-double formatting midpoints except deliberate exact binary half ties at explicit Math.Round sites. Decimal.js mathematical parity is not automatically bit-for-bit parity with all legacy Double/Val/Strings.Format behavior. Exact halfway formatting, malformed Val inputs, culture, NaN/infinity, and the actual desktop framework remain independent runtime-confirmation cases.

## Ordered calculation, with writes and skipped-write behavior

Use V[c] for numeric `Conversion.Val` of cell c, F2/F3 for cell formatting, E0 for whole-rupee midpoint-to-even rounding, and Ep for `Math.Round(..., MsLbrRof)` followed by F2. Skipped conditions retain the previous cell; they do not implicitly clear it.

1. **Ghat before net** (4869–4881). If ghat%14 and the *old currently visible* net12 are both nonzero, write15=F3(net12×ghat%14/100). Then, if gross10 differs from cache45, write45=F3(gross),12=F3(gross−other11). Independently, nonzero other11 and gross10 also force net=gross−other. Therefore a gross edit can calculate ghat from the previous net. Clearing ghat% to0 retains old ghat; entering ghat manually while nonzero ghat%/net exist is overwritten immediately. Clearing other11 to0 does not restore net from gross unless gross changed or another condition does so.
2. **Fine cache blocks** (4882–4913). Changed net writes46. With nonzero net and nonzero touch16+west17, write18=F3((net+ghat)×(touch+west)/100); otherwise that net block writes18=F3(net). Changed touch writes47 and recalculates fine only under the same nonzero condition. Changed west similarly writes48. Finally touch+west==0 always writes18=F3(net+ghat). A ghat-only change with nonzero unchanged touch/west and unchanged net does not itself update fine in these blocks.
3. **Metal basis** (4915–4934). G→gross10; non-F/non-G→net12+ghat15. F with the single-index control-property18 nonzero recalculates a three-decimal fine basis only when net and touch+west are nonzero; otherwise basis is net alone. F with that property zero also uses net alone. This conditional is **not** `FineCell != 0`. An F vector must provide externally proven property state or remain conditional.
4. **Changed item rate invalidates percentage/tax caches** (4935–4940). When19 differs from49, set49=F2(rate),66="0",67="0". This occurs even for a rate cleared tozero.
5. **Metal amount** (4941–4958). Only when rate19!=0 and `(basis + pieces9)!=0`, write20=F2(E0(pieces×rate)) for type44 P; E0(basis×rate/10) for1; E0(basis×rate/1000) forK; E0(basis×rate) otherwise. The unusual sum guard can skip valid-looking nonzero operands that cancel. A zero rate retains an existing metal amount.
6. **Percentage rates** (4959–4968). Changed21 versus66 with nonzero item rate writes66=F2(21),67="0",23=Ep(rate19×21/100). Tag%30 is not cached: nonzero30 and19 always write31=Ep(rate19×30/100). Zero tag% retains the previous tag rate.
7. **Incoming labour rate cache versus manual amount** (4969–5021). If23 differs from58, set58=F2(23),67="0", and write24 using **E0**, not configured precision: P→pieces×rate; N→net×rate when setting N, otherwise(net+ghat)×rate; K→(net+ghat)×rate/1000; every other type→gross×rate. If rate23 equals58 instead, nonzero amount24 and MsLbrGen Y derive rate with Ep: P amount/pieces; N amount/net or amount/(net+ghat); K amount/(net+ghat)×1000; default amount/gross. That inverse writes58 too, preserves amount24, and does not reset67. There is no amount-change comparison. It can therefore run on any numeric event with a nonzero imported/manual amount.
8. **Discount and tag labour** (5022–5050). If25 and24 are nonzero,26=Ep(amount24×discount%25/100). A cleared discount percentage leaves an existing discount amount. If tag rate31!=0, tag amount32 is recalculated using the same forward basis family as step7, but with **Ep**, not E0. Tag other amount33, tag cost34 and tag MRP35 do not enter this function's return total equation.
9. **MRP branch** (5051–5068). Nonzero MRP28 with nonzero discount% writes26=Ep(MRP×discount%/100), then a temporary36=F2(rate23−discount26). Nonzero tax37 writes38=F2(E0((MRP−discount)/(tax+100)×100)), then36=F2(38−discount). With zero tax,36=F2(MRP),38=36, ignoring discount in the resulting total. The final step11 always overwrites38=36 for every MRP row, so the intermediate tax-exclusive38 is lost. These literal expressions require explicit desktop/business acceptance; do not silently repair or reinterpret them.
10. **Non-MRP and manual total** (5069–5119). First36=F2(labour24+other27+metal20−discount26). Tax==0 first sets38=36. If active column36, compare original editor text with this computed36. When different, set labour24=F2(editor−other−metal+discount); if negative, set24 to the **empty string**. Only nonzero resulting amount and nonzero current labour rate derive a new rate: P amount/pieces; N amount/net or amount/(net+ghat); default amount/gross; **K amount/(net+ghat)/1000**, the opposite scaling from step7. Derivation uses Ep and updates58 using `Conversions.ToString(Val(rate))`, so cache textual formatting may differ. Set36=F2(editor),38=36 even after a negative derived labour was blanked. If labour%21 and item rate19 are nonzero, update21=F3(rate23×100/itemRate19), without updating66 at this site. Manual total does not run when MRP or tax is nonzero.
11. **Final tax cache** (5120–5156). If tax37 differs from cache67 and MRP28==0, set67=F2(tax);38=F2(E0(total36/(tax+100)×100));24=F2(E0(net38−metal20−other27)). This omits discount26 and can create negative labour, without the blanking used by step10. If24!=0, derive rate using plain F2: P amount/pieces if pieces!=0; N amount/net or amount/(net+ghat) if net!=0; K amount/**gross**×1000 if gross!=0; G amount/gross if gross!=0. Unknown types do not derive a new rate but still copy58=F2(current rate). If amount becomes0, rate/cache58 remain as before. In every other case—including an unchanged nonzero tax, and all MRP rows—set38=F2(total36). Repeated unchanged numeric triggers can therefore change totals after a previous tax adjustment. This function is not generally idempotent.
12. Call `MSG_PR_TOT_FILL()` then `BILL_TOTAL()` (5157–5158). The fill skips work when UpDown is true and accumulates pieces9; weights10/11/12/15/18/42; amounts20/24/27/28/35/36/38 (5166–5197), with formatting after each addition. A fresh single sum rounded only once is not the same operation in every input case. Full header/tax/settlement accounting is outside these row-vector expectations.

## Ambiguities and source anomalies requiring decisions

- **COM property18**:4919 is single-index `mSG_PR[18]`, unlike all fine value reads `[Row,18]`. Setup3635–3637 assigns both width-like and alignment-like values through the same decompiled syntax, and Enter/Leave guards use it. Obtain the actual interop getter/IL/desktop configuration before enabling a fine-visibility branch. Do not replace this with a cell-value test or default it true from the label.
- **Other unknown slots**41/42 retain unknown business meaning. A numeric event signature can identify their source positions for evidence, but must not expose or persist speculative fields.
- **Settings labels versus formulas**:global PcsWise does not mean row RATE_TYPE P; forward amount rounding ignores MsLbrRof at its explicit0 sites; ALL_ROF_REMOVE does not remove those hardcoded rounds.
- **Zero division**:the MsLbrGen branch lacks denominator guards for pieces0/net0/gross0/net+ghat0. Manual-total inversion checks amount and old rate, not denominator. Tax extraction fails at tax=-100. Tax inverse N checks net!=0 but can still divide byzero when net+ghat==0. Native Double infinity/NaN propagation, formatting, Val parsing or exceptions are unmeasured; the vector file intentionally supplies no invented resulting numeric values. Web rejection with recoverable draft is a proposed containment choice requiring explicit acceptance, not proof the desktop rejected it.
- **K inverse inconsistency**:generation uses(net+ghat) and×1000; manual-total uses(net+ghat) and÷1000; tax usesgross and×1000. These are literal distinct expressions, not a single reciprocal conversion helper.
- **MRP/tax overwritten intermediates**, negative tax-derived labour, stale fine after ghat, retained amounts when inputs clear, and repeated-trigger changes are source-known control flow. Their intended business meaning and desired migration behavior are not proven. Keep vectors marked source-literal and require business/desktop comparison before allowing them in production.
- **F1 source query/child selection**:source parent and children are selected by tag under original scope, without a fully explicit source-instance predicate; the selected help row carries a VCH_SRNO but it is not copied into incoming40. The original helper's `DtIdtl` loop bound indexing `RtnIdtl`3975–3982 is also not a proven lossless child-removal algorithm. Never use these omissions to justify ambiguous source writes.
- **Input/output precision**:source cells truncate display inputs to two/three decimals despite wider saved numeric columns, and saved UI normalizes nulls to zero/blank. Round6's exact raw preservation is an intentional loss-prevention contract. A numeric update needs dirty-field/committed-event provenance so unrelated imported precision and nulls survive.

## Bounded implementation and verification instructions

Start with a new Return-specific pure reducer whose state separates immutable raw saved values, visible committed cells, caches45/46/47/48/49/58/66/67, and an ordered event journal. Keep original typed text for column36. A source-selection event must be resolved server-side from a complete source identity, apply all supported source values/children, seed exactly the source-proven caches, then run the calculator. A normal saved-load event seeds the saved-cache contract and does not reprice. Never pass client-created cached prior values as authority.

Reuse Decimal and the existing named rounding primitives; keep Return basis/forward/inverse functions separate from Order because even K and default-type branches differ. Resolve company settings and any proven grid-property setting before enabling numeric editing; version those prerequisites alongside the complete saved write set. Return a clear unsupported capability for unproven modes and denominators. Do not expand the round6 metadata PUT map to accept financial fields.

First verification stage: independent vectors below for event-only versus calculation, changed/unchanged caches, ghat ordering, zero retains, P/G/N/K/1 metal bases, half-even ties, different return/tag labour precision, MsLbrGen Y/N, manual amount/total, and literal MRP/tax anomalies. Add separate executable desktop probes for F property's true/false states, formatting ties, generated-id/source/F1 behavior, and zero denominators. A single reducer run must not be the expected-value generator for its own tests.

Second stage: define the complete numeric transaction writer and atomic companions before adding UI saves. Compare all parent/child/stock/tag/ledger/tax/outstanding/rojmel/hidden-id/timestamp records, exercise stale edits and two configured books, and retain unchanged exact imported values. Add actual browser event-order journeys, including source F1 followed by each numeric trigger, then production build/full regressions. Calculation vectors alone do not close original-sale eligibility, incoming tag admission, child propagation, outgoing exchange, UAE variants, settlement/reversal, full desktop parity, or business acceptance.


## Evidence capture and validation

This read-only investigation inspected the complete primary function and caller/cache slices referenced above. The JSON contains **35 manually specified source-derived vectors** and **6 unresolved probes with no invented expected values**. JSON parsing, unique vector IDs, input/output cell-number ranges0–70, string scalar shape, unresolved-null expectation markers, and the primary source hash were checked locally. This structural check is not a reducer test or desktop execution.

A local binary64 arithmetic check found that `1500 * (1001 / 1000)` can produce `1501.4999999999998` while exact decimal arithmetic is1501.5. That case is therefore an unresolved runtime probe, not a high-confidence half-even expectation. The unconditional K tie vector instead uses exactly representable12.5×(1000/1000). This distinction must survive any later migration to Decimal arithmetic.

Paths below are relative to `Desktop/imodule-extracted`. These are the inspected source checkpoints, not claims about a future implementation.

| Source | SHA-256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `unified/src/csharp/DataCareNext/UT_SETTING.cs` | `a47be9b0e2b7754511e8d0aeab135c8352c58f9f417101e550b23ccbc78c30ad` |
| `unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs` | `76116b14149afc1c6a5b93562c9aa9877979c43bdf6372e1d8fe1e6296aec4c5` |
| `web/packages/core/src/money.ts` | `7e176f0adeea92f7cabf981b0cd281bd493e1168e7672278c9f631a3d87168dc` |
| `web/packages/core/src/orderLabour.ts` | `5981b6198035c845b447caf0d92fe84e3c25d1412e6b61b0eee0483f0224230d` |
| `web/packages/core/src/orderLabourWithCache.ts` | `dd9f429992b33918e97b382d5ead1852219aece381ec7c9bb6a1cc21719f3e4f` |
| `web/packages/core/src/designCalc.ts` | `78f207dd2b8796f7f4ea9445c8baa971721f0d78ab82b50168bd67772a391116` |

Independent vector artifact SHA-256: `ad1184e6bb7f7256e42e85b5469ea3152404fba25566465389bc6a7ba4367527`.
