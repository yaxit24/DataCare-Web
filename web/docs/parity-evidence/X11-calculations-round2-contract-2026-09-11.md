# X11 Design Book — round 2 calculation contract

Date: 2026-09-11. This is an additional bounded implementation checkpoint, not an amendment to the frozen first-round evidence and not a declaration of complete X11 parity.

## Evidence and interpretation

Primary source: `unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs`, SHA-256 `abde981d2825b4fc621a21c92305d36aea99aa3248d8f02f6d5e8644486cf9e3`.

The alternate `unified/src/csharp_nextdm/DataCareNext/MS_DESIGN_BOOK.cs`, SHA-256 `bbc05e84afec56728d43cc84d1638e2e2653e63943d6ec82b0f1b491b51bf288`, was checked for the relevant calculation helpers. The source executable is `DataCareNext.exe`, SHA-256 `c85f93fd336853a2a639c6452b47748290a1dddb214e2fdf3fc78f47bc0ca6c8`.

The unusual component P-rate condition was resolved using ILSpy 10.1.0.8386 on that executable, rather than simplifying the decompiled expression. `CommPassTotal_Idtl`, IL_04ca–IL_0599, compares the basis to P, negates its boolean value, converts to Int64, rounds the rate through `System.Math.Round(float64)`, checked-converts that result to Int64, then bitwise-ANDs and branches. Its effective condition for database-representable rates is `basis == P && roundHalfEven(rate, 0) != 0`. This is why a rate of ±0.50 uses customer weight while ±0.51 uses pieces. The relevant extracted IL is preserved in the adjacent `X11-component-rate-round2.il.txt` artifact.

All numerical vectors in the automated tests are synthetic values derived from source/IL. They are **not observed desktop UI executions**. Rounding uses the repository's established `Strings.Format` half-up and `.NET Math.Round` half-even policies, and Decimal arithmetic retains each source rounding boundary. Comparing exact binary-double/format-string edge cases against the operational desktop remains a separate evidence requirement.

## Trigger contract

| Action | Desktop source | Implemented behavior |
|---|---|---|
| Parent numeric leave | `MSG_LeaveCell`, 3154–3210 | Round the entered cell at its source precision, then run the parent helper for the source-listed fields. Parent pieces are formatted to an integer without running the helper. |
| Parent other-weight leave | Same method, case 9 | Calculate the first component, aggregate children, then calculate the parent. The component aggregate can overwrite the manually entered other weight when its sum is nonzero. |
| Parent labour/rate basis leave | Same method and hidden basis column | Store the basis without recalculation; the next qualifying numeric commit consumes it. |
| Component numeric leave | `MSG_IDTL_LeaveCell`, 2540–2588 | Format pieces at 0dp; weights/conversion at 3dp; percentages/rates/amounts at 2dp. Run the component helper and its aggregate, without calling the parent helper. |
| Component basis/type changes | Same method | Store the cell without recalculation. |
| Component removal | `TEXT_IDTL_KeyDown`, 2190–2214 | Remove the identified component, recalculate the first remaining component, and retain the source's nonzero aggregate guards. Removing the final child does not forcibly zero a manual parent value. |
| Item selection | `TEXT_IDTL_KeyDown`, 2250–2328 | Resolve the item in the current company. Copy item type; fill conversion only if current conversion is zero. In new-book mode only, default rate/basis or fixed net amount according to `OTH_RATE_TYPE`, preserving existing nonzero amounts. Selection alone does not calculate amounts. |
| Parent refresh | `MSG_RowColChange`, 4910–5000 | The browser provides an explicit **Recalculate design totals** action that aggregates persisted/current children and runs the parent helper. The lossy desktop row-rebuild operations described below are deliberately excluded. |
| Unchanged load/save | Desktop display has lossy side effects; parity plan requires preservation | Loading or selecting a web design does not mutate its saved numeric cells or create calculation events. An unchanged save follows the existing exact-snapshot lifecycle. |

The browser records ordered explicit commits and sends a per-line `calculationEvents` journal plus `calculationVersion`. The API reconstructs the initial state from the database snapshot inside the locked replacement transaction, resolves current company policy and item defaults itself, replays the journal, and writes the replay result. Caller-supplied derived cells cannot replace values written by replay; supplied item-default objects are disregarded. Unknown events, missing/duplicate child identities, incomplete add/remove histories, invalid numbers, and stale policy versions are rejected before replacement. Existing callers that omit the journal retain the previous import/manual API contract.

## Parent arithmetic, in source order

`CommPassTotal`, 3213–3710:

1. A changed gross weight updates the old-gross tracker and sets net to gross minus other weight, at 3dp. A nonzero gross and nonzero other weight also assign this net value.
2. A changed net weight updates its tracker. If net and touch-plus-west are nonzero, fine becomes `(net + current ghat) × (touch + west) / 100`, at 3dp; otherwise fine becomes net.
3. Nonzero ghat percentage and nonzero net assign `ghat = net × ghatPercentage / 100`, at 3dp. This happens **after** the preceding fine calculation; it is not algebraically reordered.
4. Changes to touch or west update their old trackers, then calculate fine under the source nonzero guards. Zero touch-plus-west assigns fine as net plus ghat. A zero fine with nonzero touch-plus-west triggers the fine expression again.
5. A nonzero rate and nonzero fine calculate the parent amount. P uses pieces × rate; `1` uses fine × rate / 10; K uses fine × rate / 1000; every other basis uses fine × rate. Each result uses whole-amount half-even rounding. The nonzero-fine guard also applies to P.
6. A nonzero labour rate calculates labour. P uses pieces; N uses net plus ghat; K uses `(net + ghat) / 1000`; other bases, including G, use gross. Each uses whole-amount half-even rounding. The editable labour percentage is not consumed by this helper.
7. Only the desktop special-registration cost mode assigns tag cost and transient purchase cost from amount + labour + other amount, at **1dp**. Generic businesses preserve manual costs.
8. A nonzero tag cost and changed margin assign MRP from `tagCost × (1 + margin / 100)`, using whole-amount half-even rounding, and update the old-margin tracker. If TagCost is hidden, nonzero transient purchase cost is used only if the margin change has not already been consumed by the tag-cost branch. Changing only the base cost or re-entering the same margin preserves a manual MRP.

No general parent NET_AMT formula is inferred. Purchase cost and margin are transient screen inputs because the source design table has no persisted purchase-cost/margin fields. MRP remains a normal persisted parent value. The original child/parent IDs, images, dates, styles, and other fields retain the first-round persistence contract.

## Component arithmetic, in source order

`CommPassTotal_Idtl`, 2590–2695:

1. Nonzero pieces and nonzero piece weight assign karigar weight as their product at 3dp.
2. Nonzero karigar-less percentage assigns customer weight as `karigarWeight × percentage / 100`, at 3dp, and updates the old-customer tracker. This is the percentage itself, **not** a 100-minus-percentage formula.
3. Changed karigar weight fills customer weight only when customer weight is zero. Changed customer weight fills karigar weight only when karigar weight is zero. Their old trackers are maintained separately.
4. Customer converted weight is customer weight × conversion; karigar converted weight is karigar weight × conversion, each at 3dp. Either becomes zero if either of its two operands is zero. Conversion is multiplication by the stored factor; it is not a percentage division.
5. Blank rate basis uses pieces when customer weight is zero and both rate/pieces are nonzero; otherwise it uses customer weight when customer weight/rate are nonzero. The explicit P branch follows the IL condition above. Every other explicit basis uses customer weight when rate is nonzero. Amounts are 2dp half-up. Zero rate retains a manual amount.
6. Nonzero labour rate assigns labour amount as labour rate × pieces, at 2dp. Zero labour rate retains manual labour.
7. Nonzero amount-plus-labour assigns net amount at 2dp. A zero sum retains the prior net amount, including a manually entered fixed amount.
8. Sum all current child converted weights and net amounts. A nonzero weight sum assigns parent other weight and net; a nonzero amount sum assigns parent other amount. Zero sums retain the prior parent cells. This helper does **not** calculate the parent's fine, material amount, labour, or MRP.

Book totals follow `MSG_TOT_FILL`, 2947–2984: format after each addition; pieces 0dp, weights/fine 3dp, amounts/costs 2dp, and MRP total 3dp.

## Configuration and authorization

- `MS_OPNCOMP` reads company `CO_SET.LBR_TYPE` and defaults blank/missing to G. A new parent starts with one piece and that labour type; saved blank/null cells are not defaulted on load.
- `MS_OPNCOMP` derives the special automatic-cost mode from tenant installation `HDD_MAST.REF_NO`. The API returns only the boolean mode, never the underlying registration reference. Conflicting rows whose values would choose different calculation branches are refused for reconciliation.
- The source's `COL_MAST` entries are company-specific. `DESIGN DETL` and `TAG_IDTL` exact desktop column names determine configured labels/visibility; hidden values remain in the save DTO. TagCost is visible by default and hidden only by its configured N flag.
- The configuration version hashes all effective policy and returned column metadata. Replaying a draft against changed policy requires reloading the book.
- The new `/masters/design-book/calculation-config` and `/masters/design-book/component-defaults` routes use the screen's existing Design Book view authority, not Sales or Tag Print authority. Root integrated those shared routes/RBAC entries. Existing POST/PUT/DELETE and image rights remain intact.

## Verification completed for this bounded change

| Layer | Tests/check | Result |
|---|---|---|
| Core | `packages/core/test/designCalc.test.ts` | 36 passing source/IL vectors |
| Frontend DTO/calculation editor | `designBookCalculation.test.ts` + existing `designBookPage.test.ts` | 10 passing tests |
| PostgreSQL runtime role / forced RLS | `designCalculations.db.test.ts` + existing `designComponents.db.test.ts` + `designBook.routes.db.test.ts` | 21 passing tests; 7 new calculation cases |
| Build/typecheck | Core build, API typecheck, web typecheck, focused page lint | Passed, including the final Design Book layout correction |
| Actual browser | `apps/web/test/design-calculation.journey.mjs` | 14 Design calculation checks passed against the real stack, including invalid draft retention and grid containment. The complete combined browser run passed with zero mocked requests. |
| Full API | Root `api-full-verified.txt` | 210 files / 1,630 tests passed |
| Full frontend tests | Root `web-tests-tested.txt` | 18 files / 83 tests passed |
| Strict test typecheck | Root `test-types-verified.txt` | Passed; the earlier duplicate subagent compiler was terminated, so only the root run supplies the integration verdict |
| Production build | Root `build-tested.txt` | 7 tasks passed against the final integrated product. Final log hashes are recorded in the adjacent run manifest. |

The focused database log is `/tmp/datacare-design-round2-db.log`. Tests used the disposable `localhost:55433` database through `scripts/parity-test-env.mjs`; the regular application database was not used.

The separate browser journey creates `CALC WEB` under company01/product01 with configured item `CALCS`, checks invalid numeric text plus refresh without losing the draft or raising an unhandled page error, actual source-trigger order, customer/karigar conversion, labour, explicit refresh, saved MRP, exact unchanged save, zero-rate manual-value retention, P-rate 0.50/0.51, and deletion. The prior real-stack lifecycle remains separately exercised. Editor calculation failures, including a defaults response arriving during invalid numeric entry, update feedback atomically while retaining the previous draft.

Visual review found that the native fieldset's default minimum width let the entire content area scroll horizontally, hiding the heading and book controls beneath the sidebar. A page-local `minWidth: 0` correction confines horizontal scrolling to the two grid panels. The journey now asserts the content container stays at horizontal offset zero without excess width; the resulting screenshot shows the heading and all book controls fully visible. Earlier combined browser attempts that passed Design Book but failed a later screen are retained as failed attempts, not relabeled as whole-run successes.

Final browser artifacts are under `web/test-results/parity-real-stack-round2-tested/`; `result.json` records a passed run from `2026-09-10T23:39:01.888Z` to `2026-09-10T23:39:10.249Z`. The calculation screenshot was visually inspected after this final run. Root integration logs are under `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round2/`, including `browser-real-stack-tested.txt`, `build-tested.txt`, `web-tests-tested.txt`, `api-full-verified.txt`, and `test-types-verified.txt`. The adjacent manifest pins their hashes and all owned implementation files. This freezes the bounded round-two evidence; the open parity requirements below remain open.

## Explicit discrepancies and remaining closure gates

1. **Preserve imported data rather than reproduce destructive display behavior.** Desktop `MSG_RowColChange:4959` replaces loaded piece weight with zero while rebuilding its child grid. Its row display also renumbers component display rows. The web preserves the saved piece weight and stable child identity. Desktop display/save omits or clears several historical ghat/tag-cost/net-amount cells; the existing web lifecycle preserves them. Loaded higher-precision fields are also retained: for example, persisted touch can contain 3dp where desktop display formats 2dp, and persisted conversion can contain 4dp where desktop display formats 3dp. The current engine consumes the retained value until that field is explicitly committed, which can differ from arithmetic on the desktop's already-formatted grid. These deliberate preservation differences are **pending desktop comparison and business acceptance**, not already accepted and not evidence of bit-for-bit desktop behavior.
2. **Row selection and unchanged cell blur are nonmutating.** The source can recalculate during row selection or numeric leave even when the user has not changed that cell; the web keeps imported loads/selection and unchanged cell blur intact and exposes an explicit refresh. Changed numeric edit triggers follow the documented source order. An observed desktop execution plus acceptance of this preservation behavior is still required.
3. **Repeat-previous-row defaults remain open.** `CommPassAdd:3015` and the component default-copy helper consult `COL_RPT` using configured display names. The API now supplies that metadata, but automatic copying of previous-row cells is not implemented in this round. It needs a source-backed copy event that does not masquerade as a series of numeric leave events.
4. **Keyboard-specific preconditions remain open.** The item/customer-weight Enter handler has additional fixed-amount/reset conditions, and diamond selection has separate display/default rules. The normal item selection and numeric leave paths are implemented; keyboard-only preprocessing and the full diamond-picker path still require independent source vectors and observed workflow verification. Do not infer those branches from the generic calculation engine.
5. **Transient/default display completeness remains open.** Karigar converted weight is computed in the shared state but is not a persisted database column or a separately editable web column. Purchase cost and margin are exposed as transient inputs and naturally reset after reload, as the source reader does not populate them. Configured N flags and labels are honored, but source default hidden-column geometry and software-type-dependent style visibility are not a full replica of the ActiveX grid. Business review must confirm the expected screen presentation.
6. **Actual desktop comparison remains open.** Capture paired desktop/web artifacts for the vectors above, including rounding boundaries, configured automatic costs, edit-order changes, zero/manual cases, loaded records, item defaults in new/existing books, and parent refresh. Any runtime discrepancy must be triaged against the pinned executable/source and documented, not hidden by changing golden expected values.
7. **X11 downstream closure is separate.** Exact design selection into order/manufacturing, parent/component/image identity transfer, migrated legacy image reconciliation, production migration totals, user acceptance, and all plan-wide release gates remain open. This round does not mark X11 verified or increase the independently verified desktop-parity percentage by assertion.

Implementation: `packages/core/src/designCalc.ts`, `apps/api/src/modules/masters/designBook.ts`, `apps/web/lib/designBookDraft.ts`, and `apps/web/app/(app)/masters/design-book/page.tsx`. No schema changes were needed for this round.
