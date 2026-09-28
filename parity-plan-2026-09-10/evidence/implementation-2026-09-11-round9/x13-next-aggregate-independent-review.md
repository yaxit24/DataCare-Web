# X13 prospective aggregate and bill-total review

Status: independent static source review for the next bounded implementation. This note changes no product, test, schema, frozen core, or prior evidence file. No desktop execution, database test, browser run, numeric write, financial parity, or acceptance result is credited here. The scenarios below are hand-derived expectations at named source boundaries, not outputs obtained from the web reducer.

The smallest safe next integration keeps the existing incoming-only, saved, nonpersisting profile. Add a source-specific running aggregate and an explicitly phased bill-state calculation. Continue to reject outgoing documents in the initial API profile: saved desktop opening can recalculate the first outgoing row and its child-derived amounts before its final bill calculation. A generic sum followed by one final settlement calculation would miss observable source behavior even for an incoming-only journal.

## Source identities and scope

All primary line references below are to `extracted_code/DataCareNext/DataCareNext/TR_SALE_RTN.cs`, unless another file is named. The source is a decompilation; ordinary call order and named fields are readable, but this review does not claim executable VB `Double`, `Format`, culture, COM event ordering, or historical FLOAT round trips have been measured. The existing exact-decimal mathematical profile can support a bounded implementation only when that distinction remains explicit.

- `MSG_PR_TOT_FILL`: 5162–5202; its caller performs the aggregate and then `BILL_TOTAL` at 5157–5158.
- Outgoing `MSG_TOT_FILL`: 6051–6096; outgoing calculator calls it at 6660 and then `BILL_TOTAL` at 7196.
- Clear/default state: 9979–9987, 10007–10031. Saved header/payment projection: 10101–10169. Saved outgoing/incoming aggregation: 10309 and 10447. Saved final callbacks and bill calculation: 10491–10507.
- `MSG_RowColChange`: 15328–15405, including nonzero child-sum assignments and an unconditional call to the outgoing calculator after the row guard. `MSG_PR_RowColChange`: 16746–16853, which loads children/images and does not call the incoming calculator.
- Payment-grid labels and editing: 15917–15929, 15954–16043, 16047–16078. `BILL_TOTAL`: 16381–16458.
- Header write ownership: 12623, 12683–12719, 12789–12821. These references describe the source write set; this prospective slice must not implement it.
- Opening/closing balance query: `DC_Main.cs` 1463–1492. Saved clock projection and call: 10106 and 10197; opening state assignment: 10226–10227.
- Tax-round policy: `MS_OPNCOMP.cs` 657–671, 741–743, 1297–1303; `DC_Main.Fnv` at `DC_Main.cs` 2088–2104; live tax setting at `UT_SETTING.cs` 4930–4936; all-rounding setting at `UT_SETTING_MAIN.cs` 8821–8834.
- Original `DataCareNext_Source/Database/01_Schema.sql` 2867–2868 adds the seven `RTN_*` payment amounts as FLOAT. Current `web/packages/db/prisma/schema.prisma` 5702–5708 also declares them as nullable Float. Neither raw text serialization nor an exact-decimal preview restores an already lost historical binary value.

## Findings that the next contract must preserve

### 1. Aggregate the visible grid in source order, with formatting after every addition

`MSG_PR_TOT_FILL` is entirely guarded by `!UpDown`. On the active path it resets `TotCrFine` and `PrOthAmtLess`, clears aggregate columns 1 through the final column, leaves column 0 untouched, and writes `Total :` to column 5. It then visits every grid row from 1 through `Rows - 1`. There is no item-code, tag, width, eligibility, or nonblank-row filter inside the fold.

Each assignment reads the **previous formatted running total**, adds the next visible cell using `Val`, and formats immediately. Preserve the loop order; do not replace it with SQL SUM, a generic final-rounded reduce, or a regrouped parallel reduction.

| Incoming source columns | Format after each addition |
| --- | --- |
| 9 (pieces) | `0` |
| 10, 11, 12, 15, 18 | `0.000` |
| 20, 24, 27 | `0.00` |
| 42 (hidden source cell) | `0.000` |
| 28, 36, 38, 35 | `0.00` |

These are exactly 14 aggregate columns. Discount amount 26, discount percentage 25 and line tax percentage 37 are not summed. Column 42 is included despite being hidden; its ownership is not established merely by aggregation. Frozen saved incoming projection leaves it blank, and this review does not authorize a client event that changes it.

`UpDown=true` preserves the prior totals, label, counters and other cells; it is not an instruction to return fresh zeros. The caller at 5158 still invokes `BILL_TOTAL` after the skipped aggregate. Initial server preview may fix `UpDown=false` as a documented profile condition; it must not pretend it implemented the skipped state.

### 2. Bill calculation is stateful and follows each actual row calculation

At the `BILL_TOTAL` entry boundary, use the following phase order:

1. Independently whole-unit-round outgoing aggregate column 24 and incoming aggregate column 38, then format each to two decimals into `nAcDrAmt` and `nAcCrAmt` (16385–16386).
2. Subtract those two already rounded values. A negative difference occupies Received column 4; zero or a positive difference occupies Payment column 3. Blank the other net cell (16387–16397).
3. Compare the **Payment net cell** and bill tax percentage to `OldNetAmt` and `OldTaxPrc`. A changed comparison value updates the two caches and recomputes Payment tax with `Math.Round(..., MsTaxRof)` followed by two-decimal `Format`. If both comparisons match, preserve the current tax amount, including a manually entered amount (16398–16403). Tax code is not part of this predicate.
4. Derive Received total from Received net. Derive Payment total by independently whole-unit-rounding Payment net plus Payment tax (16404–16405).
5. Derive each side's outstanding amount in source subtraction order: total minus Cash (row 6), Cheque (row 4), Card (row 5), then Kasar (row 7); format only the final subtraction result (16406–16407).
6. Only when `EditOPen=false`, clear rows 2 through 8 on the inactive side. This happens **after** both outstanding calculations. It does not clear bill tax percentage, account-code columns, or the two comparison caches (16408–16429).
7. Derive closing amount from opening amount and the **post-clearing** outstanding cells. Keep source expression grouping if reproducing binary arithmetic later. Choose Cr/Dr/zero label from the result. The zero path sets the text `: Amt` but does not reset the prior label color (16431–16455).

No unconditional tax calculation, discount reapplication, payment normalization, or debit/credit renaming is justified by this method. Incoming net column 38 is the already projected or calculated row net; the primary row tax branch can perform an inverse calculation (5119–5155), so do not describe it as uniformly additive tax. Bill tax is a separate calculation. The next interface must name both layers clearly.

The event sequence is part of the state. `CommPassTotal_Pr` calls the running aggregate and `BILL_TOTAL` after every actual row calculation. Calculating all row events first and settling only the final aggregate loses bill-cache transitions. Preserve this phase boundary for every committed event whose source path calls the calculator, including same-visible-value events that actually reach it. A skipped or rejected event must not be given a synthetic bill phase.

### 3. Saved-open and ordinary-event baselines are different

New form clear sets `OldNetAmt=0`, `OldTaxPrc=0`, and `EditOPen=false` (9985–9987). The taxable-book default loads tax master code 10 only in the source's `FormBookType == "T"` branch (10017–10031); it is not a universal bill default.

Saved opening sets `EditOPen=true`, loads Payment/Received tender fields, loads tax amount and percentage, and seeds `OldNetAmt` from the **full saved `RTN_NET_AMT`**, not the signed difference or Payment net cell (10101, 10112–10148). This alone can cause the final open to replace a saved manual tax amount when the rounded current difference is different.

The incoming rows are projected and aggregated without `CommPassTotal_Pr` (10353–10447). Their first-row callback loads children/images only. However, when an outgoing row exists, the saved-open callback at 10501 invokes `MSG_RowColChange`: it sums matched child amounts/weights; conditionally overwrites loss/net/K-weight/other fields when those sums are nonzero; and calls `CommPassTotal` (15389–15405). That outgoing calculator aggregates and calls `BILL_TOTAL` while `EditOPen` is still true. Then 10503 sets `EditOPen=false` and 10504 calls `BILL_TOTAL` again.

Therefore an outgoing document cannot be modeled as a static saved outgoing total plus a single final calculation without proving that omitted path. Keeping outgoing denied in the first incoming-only profile is a rollout restriction, not a claim the desktop refuses such documents. Automatic COM events during grid population remain unmeasured; the explicit calls above are the minimum established sequence.

Expose raw saved header values separately from the post-open calculation state. A preview must not silently relabel transformed bill values as exact saved data, and metadata/no-event raw reads must retain their existing behavior.

### 4. `RTN_*` names describe Payment-side amounts, not a second incoming row aggregate

| Persisted header field | Source control ownership |
| --- | --- |
| `NET_AMT` | Rounded outgoing `nAcDrAmt` |
| `RTN_NET_AMT` | Rounded incoming `nAcCrAmt` |
| `TOT_AMT`, `CHQ_AMT`, `CARD_AMT`, `CASH_AMT`, `KASAR_AMT`, `BILL_OS` | Received column 4, rows 3 through 8 |
| `TAX_PRC`, `TAX_AMT` | Bill percentage at [2,2] and Payment tax at [2,3] |
| `RTN_TOT_AMT`, `RTN_CHQ_AMT`, `RTN_CARD_AMT`, `RTN_CASH_AMT`, `RTN_KASAR_AMT`, `RTN_BILL_OS` | Payment column 3, rows 3 through 8 |

Payment and Received are the source's grid headings (15917–15918). In particular, `RTN_TOT_AMT` is the Payment difference plus bill tax, whole-unit-rounded; it is not the incoming rows' total or net sum. Shared bank/card/cheque identity cells are separate (12813–12821). Do not create tender edit controls or route writes from this table alone. Bill tax percentage is read-only in the ordinary editor at 15994–15997; the fact that `BILL_TOTAL` consumes it does not authorize arbitrary client changes. Manual bill tax amount follows different edit rules.

### 5. Tax rounding and opening balance require additional authoritative inputs

The three whole-unit `Math.Round(..., 0)` calls inside `BILL_TOTAL` ignore `ALL_ROF_REMOVE` directly. The **tax step does not**: it uses `MsTaxRof`, which company opening loads from `CO_SET.TAX_ROF` through Fnv, Math.Round and Int32 conversion, changes to 2 when greater than 5, and finally forces to 2 when `ALL_ROF_REMOVE=Y`. Negative/unrepresentable values are not made valid by an invented clamp. A future exact implementation must preserve the original operation order and explicitly contain unsupported configuration.

`Fnv` maps DBNull, null and empty text to zero before that conversion; unsupported numeric-prefix/culture cases must not be guessed. Test the intermediate integer conversion before either fallback or the final flag override. Do not let `ALL_ROF_REMOVE=Y` conceal a value that could not pass the original preceding conversion.

The existing incoming configuration service does not yet resolve `TAX_ROF`. Add a same-snapshot, versioned effective tax policy before advertising bill preview. The live desktop tax setting can update `MsTaxRof` separately (`UT_SETTING` 4930–4936); company-open policy and mutable live process state are not automatically identical. Name the server profile rather than claiming every live-setting history is represented.

`CustOpAmt` is loaded using `DC_Main.MsAcBal` over the same company, location, year and account, across **all books**. Opening uses strict `ENTRY_TIME < cutoff`; the helper's separate closing query uses `<=`. `DATA_TYPE='C'` at the application mode level means no data-type predicate, while other modes add an exact predicate. Saved opening formats `VCH_TIME` to `HH:mm:ss` before this call and the helper also formats its SQL cutoff to seconds. Do not silently substitute a microsecond cutoff, voucher exclusion, selected-book-only balance, or all-years balance.

A future closing-balance preview needs authoritative mode, account identity, source clock policy and relevant scoped ledger observations in its composite token. If these are unavailable, report closing balance as unsupported; do not assume zero. SQL aggregate NULL behavior, historical timestamp loss and FLOAT precision remain explicit import/runtime limitations. Keep actual write effects, tax-ledger splits, outstanding rows and payment posting out of this slice.

## Discriminating prospective scenarios

Conventions: all unspecified numeric control cells start blank and are interpreted as zero at the named calculation boundary; default `UpDown=false`, `EditOPen=false`, `OldNetAmt=0`, `OldTaxPrc=0`, `MsTaxRof=2`, and `CustOpAmt=0`. Formatting expectations use the declared mathematical profile, with explicit `Math.Round` half-even where applicable. These are proposed golden cases, not tests executed in this review. Whole bill-entry cases supply already computed aggregate cells and must not be represented as coverage of unsupported outgoing admission.

| Case and complete deviation from defaults | Required discriminating result |
| --- | --- |
| A1: aggregate two saved rows with pieces `0.6`, `0.6`; all other row cells blank | Running pieces are `1`, then `2`. Sum-then-format would return `1` and is wrong. This input is reachable because saved pieces use direct source text, not integer formatting. |
| A2: rows have hidden c42 `0.006`, `0.004`; c26 `99`, `99`; c37 `10`, `20`; all else blank, width42=0 | c42 aggregate is `0.010`; c26 and c37 remain blank after clearing. Width does not filter this fold. This is a pure aggregate vector, not permission to supply hidden c42 through the current API. |
| A3: `UpDown=true`, previous incoming c38=`80.00`, previous label/counters nonzero sentinels, current rows would total120; outgoing aggregate30 | Aggregate returns previous state unchanged. A separately invoked bill step uses80 and30, yielding Payment net50, not90. |
| A4: one trailing blank grid row versus no data rows at all | A visited blank row causes all14 aggregate numeric cells to be formatted zeros. With no rows visited, those cells remain blank after clear; label and column0 behavior still apply. Do not infer these two grid shapes are identical. |
| B1: incoming aggregate100.49, outgoing99.51; run with either ALL_ROF_REMOVE flag under resolved tax policy | Rounded sides100 and100; difference0.00. Rounding raw difference0.98 would wrongly yield1.00. Whole-side rounding does not change with the flag. |
| B2: incoming100.50, then a separate case101.50; outgoing0 | Half-even whole-unit results100.00 and102.00. These `.5` values are exact midpoint examples; this does not establish all VB Format or binary cases. |
| B3: incoming200, outgoing80, percentage10, OldNetAmt200, OldTaxPrc10, saved manual tax7 | Difference120; cache changes to120; tax12.00; Payment total132.00. This is the bill-entry consequence of the saved full-incoming cache. |
| B4: incoming200, outgoing0, percentage10, OldNetAmt200, OldTaxPrc10, manual tax7 | Cache predicate is false; tax remains7.00 and Payment total207.00. Tax code-only change cannot force recomputation through this predicate. |
| B5: incoming200.60, outgoing0, percentage10, OldNetAmt200.60, OldTaxPrc10, manual tax7 | Whole incoming201; cache changes; tax20.10; Payment total221.00. An unchanged incoming saved row can still produce this bill-open transformation. |
| B6: incoming80, outgoing200, percentage10, OldNetAmt120, OldTaxPrc10; Payment cash10, Received cash20, CustOpAmt5; first call EditOPen=true, second false | First: Payment net blank/tax0/total0/OS−10; Received net120/total120/OS100; closing−105. Second: inactive Payment rows2..8 clear after OS calculation, Received OS100 stays, caches stay0 and10; closing−95. A global EditOPen skip or closing-before-clear is wrong. |
| B7: both aggregate sides0, percentage10, OldNetAmt0, OldTaxPrc10, manual Payment tax7, Payment cash9 | Zero takes the nonnegative Payment branch; manual tax stays7, total7, Payment OS−2, Received rows2..8 clear, closing−2. Do not introduce a blanket zero-difference cleanup. |
| B8: saved row observations retain c36=100 and c38=110; bill percentage10, no cached match | Aggregate/bill consumes c38=110, computes separate bill tax11, settles121. It must not substitute c36=100, deduct line discount again, or invent a recalculation of the saved relationship. This is a saved-observation vector, not a claim that primary row tax transforms100 into110. |
| B9: incoming101, outgoing0, percentage1.4; resolved TAX_ROF0 then an independent run with ALL_ROF_REMOVE=Y forcing2 | Tax values1.00 versus1.41; whole Payment total102.00 in both. Testing only final settlement would miss the tax-round policy defect. |

**J1: prefix-sensitive row journal.** Use the complete saved `rate-then-manual-labour` baseline, master, policy and context from `x13-replay-independent-journal-vectors.json` (SHA256 `68c3744d2e2cdbf741723effeef853dc05c97222f47bd740ecdd126127f7d83d`), replacing only its events with the two below. This fixes all visible cells and eight caches: rate and labour types N; net/gross10; zero loss/ghat/wastage; touch100 and fine10; item rate10 and metal amount100; labour percentage10, rate1, amount10; other/discount/row-tax0; total/net110. Bill state has tax percentage10, `OldNetAmt=110`, `OldTaxPrc=10`, manual tax7, no tenders, opening0. Commit source Other Amount c27 text `1`, then text `0`, with the row calculator and aggregate/bill phase after **each** event. First prefix: incoming111, bill tax11.10, cache111, Payment total122.00. Final: incoming110, bill tax11.00, cache110, Payment total121.00. Settling once after both row events would incorrectly preserve manual7 and yield117.00. Preserve exact intermediate tax/cache observations in expected fixtures, not only the final row cells.

**L1: opening cutoff and scope.** For a saved clock `12:00:00.900000`, source saved-open cutoff is `12:00:00`. Same company/location/year/account entries at `11:59:59.900` credit10 and in another book before the cutoff credit7 contribute17 to opening. An entry exactly at12:00:00 credit20 does not contribute to opening but contributes to the helper's separate closing query; a12:00:00.100 entry contributes to neither. Other company/location/year/account entries never contribute. With data mode C, A/B rows are both eligible; with mode A, only exact A rows are. Keep the raw clock separate from the explicitly second-precision source policy. Do not count this hand scenario as a database result.

## Implementation and verification boundary

Before implementation, freeze independent expected fixtures with full row order, all visible cells, previous aggregate, bill controls, caches, source flags and the phase at which each expectation applies. Include absent versus blank cells and exact strings. Test no mutation of input raw/header/rows, exact prefix cache effects, whole-row rejection recovery, and preserved previous aggregate under UpDown. Do not derive golden expectations by running the function under test.

The API should construct document-wide rows and initial bill state in one authoritative snapshot, including tax policy and any represented opening balance; validate one composite token before replay. Rebuild the running aggregate and bill state after every relevant row event. Keep all existing scope, master, configuration, period and unsupported-state containment. A preview may return source-derived payment observations, but `canSaveNumeric` remains false. Do not bind a save/apply control, reuse destructive `editSaleReturn`, allocate vouchers, mutate tags, update financial rows, or broaden outgoing admission in this batch.

This review identifies no reason to alter current round9 row-only behavior: its `aggregateRequired` flag correctly signals work that remains unimplemented. Aggregate/header parity must be a separately named acceptance slice, with a reviewed source contract and new evidence.

## Comparison with the prospective requirements draft

Reviewed `x13-next-aggregate-requirements.md`, SHA256 `ae2b95e059748d34facb152c7ea1268058eb0bf9058ec7f9b91dd30051889ddc`. The author’s `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` and this review’s extracted-code path have identical bytes, as do the two referenced schema copies. The findings were first traced independently and then exchanged with the author; this was an independent source challenge, not a blinded review.

The corrected draft agrees with the14-column running fold, skipped UpDown state, individually rounded legs, payment-only tax predicate, after-OS clearing, incoming saved projection, first outgoing callback, exact header ownership and nonpersisting scope. Its nine hand-derived example rows were checked by arithmetic and source branch inspection; no arithmetic or phase mismatch remains in that bounded set. During review the author corrected citation offsets, clarified that received TOT_AMT is a positive magnitude, separated raw microseconds from the second-precision cutoff, and removed any implication of a universal additive line-tax formula. These were prospective documentation corrections, not product changes or completed acceptance tests.

This note adds explicit blank-grid shape, zero-difference/manual-tax, tax-code-only predicate, effective tax-rounding, ledger scope and complete prefix-baseline examples. The draft’s additional tax-picker, tender permission, registration-specific save and stock-companion dependencies remain implementation prerequisites; this review does not establish their full writer contract. The recommendation remains: implement the pure aggregate and explicit bill phases first, then bind a separately versioned incoming-only read preview after authoritative tax/ledger observations are available. Keep outgoing and financial writes open.

## Pinned read inputs

Paths are relative to the extracted desktop folder, except the explicitly prefixed web paths. These hashes record the inspected files; they are not a before/after execution snapshot or a claim that any tests ran.

| Input | SHA256 |
| --- | --- |
| `extracted_code/DataCareNext/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `extracted_code/DataCareNext/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `extracted_code/DataCareNext/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `extracted_code/DataCareNext/DataCareNext/UT_SETTING.cs` | `a47be9b0e2b7754511e8d0aeab135c8352c58f9f417101e550b23ccbc78c30ad` |
| `extracted_code/DataCareNext/DataCareNext/UT_SETTING_MAIN.cs` | `76116b14149afc1c6a5b93562c9aa9877979c43bdf6372e1d8fe1e6296aec4c5` |
| `DataCareNext_Source/Database/01_Schema.sql` | `1eb684c7e2bec72a330a9038a2da72ffea669b3ae7ef50b85b34e0e3126efa0d` |
| `web/packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
| `web/apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts` | `2352433c0fb065d5ef17c227a594ba887875c7d024817848da3056c852466505` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-next-aggregate-requirements.md` | `ae2b95e059748d34facb152c7ea1268058eb0bf9058ec7f9b91dd30051889ddc` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-replay-independent-journal-vectors.json` | `68c3744d2e2cdbf741723effeef853dc05c97222f47bd740ecdd126127f7d83d` |
