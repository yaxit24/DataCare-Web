# X13 next aggregate requirements — prospective primary Return contract

**Next bounded prerequisite:** an independently tested incoming-grid aggregate plus a stateful bill-total simulation, with trusted saved-open/header/settings observations. Keep it nonpersisting until the complete financial/stock writer is proved. The current twelve-field replay is a row-only calculation; its `aggregateRequired` flag grants no header, tender, refund or ledger authority.

This is source analysis and future verification requirements, not executed desktop acceptance, a new implementation or permission to modify the frozen row kernel. It supplements `x13-next-server-replay-contract.md`. Root's `30-implementation-progress-round9.md` still leaves header totals, outgoing exchange, tender/refund, ledger/report effects and reversal open. Original plan `02-implementation-plan.md:326–332` requires complete/partial returns, refund/credit allocation, stock availability and permitted reversal; this next prerequisite alone cannot close that acceptance.

Unless explicitly named otherwise, source references are to **primary** `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs`. Alternate/UAE/wholesale forms are separate contracts. The independent challenge is recorded in `x13-next-aggregate-independent-review.md` by the review owner; the findings below include independently checked source phase hazards, not an invented general invoice formula.

## 1. Dependency graph and exact callback order

1. A genuine incoming numeric LeaveCell formats the editor then calls `CommPassTotal_Pr` (4592–4664). The current row reducer models its row calculations through5156.
2. `CommPassTotal_Pr` calls `MSG_PR_TOT_FILL()` at5157 and **then** `BILL_TOTAL()` at5158, after every successful numeric calculation. A multi-event replay must interleave these callbacks after **each** applied event. Applying all row events then running the bill callback once is incorrect because bill caches/manual tax and inactive-side clearing are stateful.
3. `MSG_PR_TOT_FILL` (5162–5202) reads every incoming grid row, not just the selected row, rebuilding fourteen totals. It does not call the row calculator or bill callback itself. `UpDown=true` skips its entire body, including clearing/resetting, so subsequent bill calculation can observe retained totals.
4. `BILL_TOTAL` (16381–16458) reads outgoing `MSG_TOT[0,24]`, incoming `MSG_PR_TOT[0,38]`, mutable two-sided `MSG2_TOTAL`, two tax caches, phase `EditOPen`, tax rounding setting and customer opening balance. It does not rebuild either row grid.
5. Outgoing `MSG_TOT_FILL` (6051–6095) separately supplies its own totals and has the same `!UpDown` guard. Its column24 is the outgoing net amount consumed by the bill callback; it is not incoming c24 labour amount. Do not reuse incoming source-column IDs for outgoing cells.

There is no single interchangeable `total = sum(row.net)` operation. An aggregate DTO must name the source grid/column, phase and exact saved identities independently. Rows must follow source grid order; loaded incoming SQL orders by saved `A.SR_NO` at10353. Display ordinals and immutable saved SR/OLD/instance remain distinct. A malformed or duplicate order/identity must be contained instead of silently sorting by rendered row position or merging tags.

## 2. Incoming running totals

When `UpDown=false`, the source resets `TotCrFine` and `PrOthAmtLess` to0 (5168–5169), clears total cells1 through `MSG_PR.Cols-1`, and puts `Total :` in total c5 (5172–5179). It loops rows1 through `MSG_PR.Rows-1` without filtering on item code, tag, pieces or numeric sign (5180–5198). A blank trailing row normally contributes Val(blank)=0; a nonblank numeric cell cannot be dropped merely because its row is not yet admissible for saving.

Each listed assignment is **running formatted accumulation**: `total[c] = Format(Val(total[c]) + Val(row[c]), format)`, in the order below. The next row consumes the formatted previous total, not an unrounded accumulator.

| Order / column | Primary meaning | Format | Source |
| --- | --- | --- | --- |
| 1 / c09 | Pieces | `0` | 5183 |
| 2 / c10 | Gross weight | `0.000` | 5184 |
| 3 / c11 | Other weight | `0.000` | 5185 |
| 4 / c12 | Net weight | `0.000` | 5186 |
| 5 / c15 | Ghat weight | `0.000` | 5187 |
| 6 / c18 | Fine | `0.000` | 5188 |
| 7 / c20 | Item amount | `0.00` | 5189 |
| 8 / c24 | Labour amount | `0.00` | 5190 |
| 9 / c27 | Other amount | `0.00` | 5191 |
| 10 / c42 | Hidden three-decimal total; business meaning not proved | `0.000` | 5192 |
| 11 / c28 | Return MRP | `0.00` | 5193 |
| 12 / c36 | Total amount | `0.00` | 5194 |
| 13 / c38 | Net amount | `0.00` | 5195 |
| 14 / c35 | Tag MRP | `0.00` | 5196 |

Incoming c38 is the already saved or calculated row net amount. Do not reconstruct it as c36 plus a presumed additive row tax: the row tax branch5119–5155 can use inverse tax and clear/rederive labour. The bill callback independently taxes its rounded payment difference.

Do not invent aggregate discount percentage/amount, tax percentage, labour percentage or rate cells: they are not accumulated here. c42 is not an extra proved editor and is not a labour comparison cache. The saved projection leaves it cleared; a future branch that populates it needs its own source proof. TotCrFine/PrOthAmtLess are reset but not incremented in this callback, so do not substitute the named variable for c18 or c27 just because its name sounds appropriate.

Formats and `Conversion.Val` operate on desktop Double/string values. A web exact-decimal mathematical profile may be separately declared, using sufficient local precision and the same explicit formatting boundaries, but it must not claim measured binary/locale/midpoint parity. Do not reuse the row kernel's rounding helper indiscriminately: later explicit `Math.Round` calls have their own midpoint rule, distinct from unmeasured `Strings.Format` runtime behavior.

## 3. Bill matrix and sequential algorithm

`MSG2_CLEAR` (15820–15932) creates nine rows and six columns. Captions at15917–15926 establish:

| Row | Meaning | Relevant columns |
| --- | --- | --- |
| 0 | Headings | c3 **Payment**, c4 **Received** |
| 1 | Net amount / exchange difference | c3 or c4 |
| 2 | Sale tax | c1 name, c2 percent, c3 tax amount, c5 hidden code |
| 3 | Total amount | c3 payment / c4 received |
| 4 | Cheque | c1 account name, c2 cheque number, c3/c4 amount, c5 account code |
| 5 | Card | c1 account name, c2 reference text, c3/c4 amount, c5 account code |
| 6 | Cash | c3/c4 amount |
| 7 | Kasar | c3/c4 amount |
| 8 | Outstanding | c3/c4 amount |

For an established valid phase, preserve this exact update order in `BILL_TOTAL`:

1. `nAcDrAmt = Format(Math.Round(Val(outgoingTotal24),0),'0.00')`; `nAcCrAmt` applies the same operation to incomingTotal38 (16385–16386). Then `difference = Val(nAcCrAmt) - Val(nAcDrAmt)` (16387). Rounding each leg first is not rounding their difference once. The whole-unit rounding here is literal0, even when `ALL_ROF_REMOVE=Y`; that setting can affect the separate tax-rounding step below.
2. If difference<0, set received net `[1,4]=Format(abs(difference),2)` and payment net `[1,3]=''`; otherwise set payment net `[1,3]=Format(difference,2)` and received net `[1,4]=''` (16388–16397). A zero difference uses the nonnegative/payment branch.
3. Compare `Val([1,3])` with `OldNetAmt`, and `Val([2,2])` with `OldTaxPrc` using OR. Only when either differs, update **both** caches from two-decimal formatted values and set `[2,3]=Format(Math.Round(paymentNet*taxPct/100,MsTaxRof),2)` (16398–16403). This tax base is the positive payment difference, not full incoming value. If both comparisons match, preserve the existing manual/stored tax amount, even if it disagrees with percentage arithmetic.
4. Received total `[3,4]=Format(Val([1,4]),2)`. Payment total `[3,3]=Format(Math.Round(Val([1,3])+Val([2,3]),0),2)` (16404–16405). Payment total is again rounded to whole units.
5. Compute each outstanding side from its total minus cash row6, cheque row4, card row5 and kasar row7, with final two-decimal Format (16406–16407). No clamp rejects negative outstanding in this callback.
6. Only **after** those calculations, if `EditOPen=false`, clear inactive-side rows2 through8: when difference<0, clear payment c3; otherwise clear received c4 (16408–16430). Preserve empty strings rather than normalizing everything to numeric zero. `EditOPen=true` skips this clearing and can retain both sides during a hydration/intermediate phase.
7. Compute customer closing amount using opening balance and final payment/received outstanding (16431–16442). The three branches are mathematically `opening + Val(paymentOutstanding) - Val(receivedOutstanding)`, but source operation order/absolute-value branches are explicit and should remain testable. Positive closing labels `Cr Amt` in blue, negative labels `abs(...) : Dr Amt` in red, and zero labels `: Amt` (16443–16455).

Do not call payment c3 a generic receivable or swap its signs based on ordinary Sales conventions. The primary Return UI labels and writer mapping below establish its direction.

## 4. Saved-open phases and noncommuting event history

The source clear path resets `OldNetAmt=0`, `OldTaxPrc=0` and `EditOPen=false` (9985–9987). Saved open sets `EditOPen=true` at10101. It hydrates outgoing nAcDrAmt and received matrix from `NET_AMT`, `TOT_AMT`, `CHQ_AMT`, `CARD_AMT`, `CASH_AMT`, `KASAR_AMT`, `BILL_OS` (10112–10127). It hydrates incoming nAcCrAmt, payment tax/tender/outstanding from the corresponding RTN fields (10128–10148).

**Crucially, OldNetAmt is seeded from full saved `RTN_NET_AMT` at10129, not from the eventual exchange difference.** OldTaxPrc is seeded from saved TAX_PRC at10132. Saved manual TAX_AMT is copied at10133. Thus unchanged incoming-only data can preserve manual tax when its rounded aggregate equals that saved cache, while nonzero outgoing value or changed aggregate rounding can cause tax replacement during opening.

Incoming saved rows are formatted/seeded at10353–10438, followed by `MSG_PR_TOT_FILL` at10447; no per-incoming-row CommPassTotal_Pr runs merely because they loaded. **This does not hold for the outgoing leg.** Before clearing EditOPen, saved load invokes the first outgoing `MSG_RowColChange` at10497–10501. That callback15328–15405 sums matching child buffers, conditionally overwrites parent loss/net, karigar weights and other amount, then unconditionally calls outgoing `CommPassTotal`; that calculator can call BILL_TOTAL at7196. Incoming RowColChange16746 onward hydrates children/images without the same incoming recalculation. Therefore the full saved-open pipeline can contain an `EditOPen=true` bill call and changed first outgoing values before its final `EditOPen=false; BILL_TOTAL()` at10503–10504.

The smallest next aggregate profile should continue to deny outgoing rows/components. Extending it to two-sided exchange requires the outgoing projection, child binding and saved-open callbacks, rather than treating stored outgoing NET_AMT as an immutable substitute for source grid state.

Maintain distinct phases: exact raw saved observation; projected incoming rows/loaded header controls and caches; optional desktop-open aggregate result; and subsequent ordered row/header commits. The existing row-preview GET does not calculate headers. Do not silently change that v1 behavior or overwrite raw saved header values with a simulated desktop-open result. Use an explicitly versioned aggregate contract and show its phase.

A multi-row/event aggregate replay must carry every row state, each row's comparison caches, incoming/outgoing total grids, bill matrix, OldNetAmt/OldTaxPrc and opening-balance phase. For each genuine event, run row calculation → incoming aggregate → bill calculation before the next event. Final-value diffs or one final callback lose the source history.

## 5. Header mapping is two-sided and partly floating storage

The primary Save mapping writes these control values; this is dependency evidence, not a safe partial writer:

| SL_DATA field | Source control/value | Lines |
| --- | --- | --- |
| NET_AMT | nAcDrAmt, rounded full outgoing amount | 12623 |
| RTN_NET_AMT | nAcCrAmt, rounded full incoming amount | 12707 |
| TOT_AMT | received `[3,4]`, positive magnitude of a negative exchange difference | 12679 |
| RTN_TOT_AMT | payment `[3,3]`, positive difference plus bill tax | 12789 |
| CHQ_AMT / CARD_AMT / CASH_AMT / KASAR_AMT / BILL_OS | rows4/5/6/7/8 c4 | 12683–12703 |
| RTN_CHQ_AMT / RTN_CARD_AMT / RTN_CASH_AMT / RTN_KASAR_AMT / RTN_BILL_OS | rows4/5/6/7/8 c3 | 12793–12809 |
| TAX_CODE / TAX_PRC / TAX_AMT | row2 c5/c2/c3 | 12711–12719 |
| IGST_TAX or SGST_TAX+CGST_TAX | nonzero tax; AcGstType I versus other, half division without explicit local rounding | 12723–12773 |
| LBR_AMT / OTH_AMT | **outgoing** totals21/22 | 12671–12675 |
| BANK_AC / CARD_AC / CHQ_NO | row4c5 / row5c5 / row4c2 | 12813–12821 |

DISC_PRC, DISC_AMT, ROF_AMT and multiple legacy adjustment fields are explicitly set0 at12627–12663. This does not authorize zeroing imported saved data in a future unchanged edit. The existing web loss-preservation policy and complete write-set still need source/business acceptance. TAX_CODE is passed through `Conversion.Val` at12711 despite a string schema; preserving leading-zero code identity versus reproducing that conversion is an explicit unresolved writer detail.

Original `unified/database/schema/01_Schema.sql:2867–2868` adds all seven RTN amount fields as FLOAT. Current Prisma `SL_DATA`5702–5708 retains Float?, while ordinary NET_AMT/TAX_AMT/TOT_AMT are Decimal(18,2) at5650 onward. Raw incoming header1100 can therefore be text `1100`, not `1100.00`; display formatting and exact storage preservation remain separate. Do not silently migrate RTN fields to Decimal or force a fixed-scale raw DTO in this task. Future persistence must explicitly account for target storage conversion, range, floating precision and nullable imported fields.

Current legacy web `salesReturn.ts:398–423` writes generic `totals.net/discount/tax/total` to ordinary header fields and does not supply this primary two-sided matrix. It cannot be reused as an aggregate implementation simply by wiring twelve preview fields into it.

## 6. Additional authoritative observations required

- **Tax rounding:** CO_SET.TAX_ROF → DC_Main.Fnv(NULL/empty→0; DC_Main2088–2102) → Math.Round → integer at MS_OPNCOMP663–671; values>5 become2 at741–743. ALL_ROF_REMOVE blank→N at931 and Y forces MsTaxRof=2 at1297–1303. Negative/invalid/fractional historical values and checked conversion require a documented supported profile. Do not replace the source precedence with a generic clamp. UT_SETTING4932–4935 writes TAX_ROF and updates the live variable directly; settings changed while a desktop form stays open need explicit phase/runtime acceptance. Existing round8 incoming configuration does not yet expose this tax-rounding contract.
- **Tax identity/percent:** saved open retains TAX_CODE/TAX_PRC/TAX_AMT, looking up display TAX_NAME by company/code/SR_NO0 at10149. New FormBookType T defaults TAX_CODE10 at10017–10032 without an SR_NO filter; tax selection at16196–16250 uses TAX_MAST company, SR_NO0 and tax name/code, with TAX FREE behavior. Ambiguous/missing rows cannot silently use Rows[0]. Book type comes from configured BOOK_DATA through CurBook at9912–9919. `DC_Main.MCo_BookType` versus local FormBookType appears in the blank-tax branch; their equality must be proved for a server-owned profile.
- **Tender permissions and references:** MSG2_TOTAL EnterCell15954–16043 makes bill tax percentage row2/c2 read-only; tax amount row2/c3 can be edited through the separate handler. Do not expose arbitrary header percentage input just because BILL_TOTAL consumes it. CO_SET_NEW.ESTMATE_BANK_LOCK, loaded MS_OPNCOMP948–953/defaultN1030, and FormBookType affect bank/card editability. Card/cheque account identities, cheque/reference strings, bank selection, keyboard routing and own rights require separate exact lookup events. No UPI row appears in this primary nine-row matrix; existing generic UPI support is not proof of this form's mapping.
- **Customer balance:** source calls DC_Main.MsAcBal using account plus combined voucher date/time at10198 and15713; it seeds CustOpAmt at10226/15730. DC_Main1463–1489 sums AC_DATA across all books in exact company/location/year/account, with ENTRY_TIME **strictly before** the second-precision formatted voucher timestamp for opening and <= for closing. DATA_TYPE is unrestricted only when MsDataType=C, otherwise filtered. This scope is broader than the current voucher. A coherent aggregate observation must include the relevant account/ledger/time/DATA_TYPE inputs and dependencies, not use only current-document rows or an unversioned cached customer balance. Microsecond/equal-second boundary and current-voucher exclusion/reversal effects need proof; raw clocks remain exact.
- **Grid state and edition:** UpDown, EditOPen, active saved/new phase, retained header tax caches, complete row order, unsupported hidden42, edition-specific source admission and form variants must be server-owned/derived. Neither CSS width, array index, browser booleans nor client old caches can be authority.

## 7. Independent synthetic expected examples

These are hand-derived **source arithmetic profile** expectations, not executable-desktop observations or tests run in this task. Unless stated otherwise, use finite plain values, MsTaxRof2, EditOPen=false, UpDown=false, blank/zero unlisted bill cells, and no unsupported outgoing-row admission. Outgoing aggregate examples below test the pure callback boundary only; they do not certify an outgoing workflow.

| Case | Inputs and prior state | Expected consequence |
| --- | --- | --- |
| Running pieces, not final-only rounding | incoming visible pieces `[0.4,0.4]` | Running Format0 yields0 then0, total `0`. Rounding raw sum0.8 once would incorrectly yield1. Fractional pieces can be loaded unchanged at10376. |
| Positive difference/tender | incoming net rows100.24+50.31, outgoing20.21; tax10%, caches0; payment cheque10/card20/cash30/kasar4; opening50 | incoming sum150.55→nAcCr151.00; nAcDr20.00; payment net131.00; tax13.10; payment total144.00; payment OS80.00; inactive received rows2–8 blank; closing130.00 Cr. RTN_NET and RTN_TOT are151 versus144. |
| Negative difference | incoming100.24, outgoing250.49; received cheque10/cash100/kasar5; opening50 | nAcCr100.00,nAcDr250.00; received net/total150.00; received OS35.00; inactive payment rows2–8 blank; closing15.00 Cr. |
| Saved total/net remain distinct | trusted incoming visible c36=100.00, c38=110.00; outgoing0, bill pct0 | The aggregate keeps c36=100.00 and c38=110.00; bill nAcCr=110.00. This tests trusted saved values, not a derived additive line-tax formula. |
| Manual tax retained | incoming200,outgoing0; oldNet200,oldTax10,currentTaxPct10,manualTax7; no tenders | Comparisons match, tax stays7.00 and payment total/OS207.00; do not force computed20.00. |
| Saved-open rounding changes cache | saved RTN_NET_AMT200.60 seeds oldNet200.60; projected incoming sum200.60; oldTax10,pct10,manualTax7 | nAcCr rounds201.00, differs from cache; tax becomes20.10; payment total/OS221.00 without recalculating an incoming row. |
| Equal final row, unequal history | initial incoming110,oldNet110,pct/cache10,manualTax7. A genuine OtherAmt journal0→1→0 moves incoming110→111→110 | After each callback tax11.10 then11.00, final settlement121.00. A single final callback would wrongly retain manual7 and settlement117.00. |
| Explicit Math.Round midpoint | incoming sum100.50 or101.50, outgoing0,tax0,caches chosen to trigger | Default Math.Round(Double,0) ties-to-even gives nAcCr100.00 or102.00. These exact half values do not settle separate Strings.Format or arbitrary binary decimal edge behavior. |
| Phase clearing difference | incoming100,outgoing250; oldNet0,oldTax10,pct10,manual payment tax9.99,payment cash3,received cash100,opening0 | With EditOPen=true, unchanged tax cache retains9.99, payment total10.00/OS7.00, received total150.00/OS50.00, closing−43.00. With EditOPen=false, payment rows2–8 clear, closing−50.00. Treat this as a phase probe, not an accepted user settlement. |

Add separate vectors for zero difference with retained manual tax, sign reversal clearing already-entered tenders, negative/overpaid outstanding, both positive/negative opening balances, blank versus0 strings, nonfinite/NULL imports, and very large/small numerical values. Do not invent desktop outputs for unresolved format/overflow/variant paths; return explicit diagnostics or obtain runtime/IL evidence first.

## 8. Executable future implementation and verification sequence

1. Freeze a complete source catalog for the fourteen incoming totals, six-by-nine bill matrix, header mappings, two caches and phase transitions. Independently verify the saved-open outgoing callback and settings order; keep incoming-only profile until that dependency is ported.
2. Add a pure aggregate state/reducer with immutable raw values, ordered rows/caches, explicit applied/skipped/rejected events and separate aggregate versus saved output. Interleave callbacks after every row event. Rejections preserve all prior rows, aggregate/header caches, tenders, journal and attempted text.
3. Author independent fixture expectations for the examples above before implementation, including cache/history discrimination and per-step rounding. Add source-negative tests preventing sum-final-only, final-event-only, payment/received inversion, client phase/cache injection, hidden42 invention and numeric coercion of exact raw header floats.
4. Build trusted transaction-local saved header/row/settings/tax/account/ledger observations with one coherent snapshot and a new version binding every relevant dependency, raw rows/counts and physical revisions. Re-resolve on preview; stale input returns409 with retained client draft and explicit reload. The existing present-row xmin/ctid token does not record absent→insert→delete history; do not call it universal ABA prevention. No-write preview still grants no reservation.
5. Extend only a new explicitly versioned preview surface. Show original saved amounts, row aggregate and source-phase settlement separately. Retain current row-only API behavior and false numeric-save capability. Test full identity, duplicate books/vouchers, same-value update, changed tax setting/master/account/ledger cutoff, scope A→B→A and permission revocation with real DB snapshots proving no business/counter/stock writes.
6. Before any write, independently map all SL_DATA/SL_DETL_RTN/BAR_DATA/BAR_DETL/BAR_IDTL/DM/MAIN_STOCK, tax/ledger/outstanding/tender/report effects. Save's incoming aggregate also gates BAR header creation at13073 and a registration-specific fine/value validation at12387–12402; aggregate-only SQL is not a complete admission contract. Preserve exact raw timestamp/microsecond storage independently of the source saved-open second-precision ledger cutoff; preserve imported raw/hidden values and full companion identity; test failure rollback, concurrent edits, source over-return, reversal and report reconciliation under the same locked write transaction.

The next preview may demonstrate aggregate mathematics for its supported phase. Complete Return transfer remains blocked on source admission, outgoing/component calculations, settlement permissions, exact financial posting, stock ownership, tax/report/print behavior, delete/reversal, runtime uncertainty and real business acceptance. No percentage or full-card acceptance changes follow from this document.

## 9. Source provenance and verification boundary

The following SHA-256 values pin the bytes inspected on 2026-09-11. Paths are relative to `Desktop/imodule-extracted`; the first source governs the primary-form line citations above. Schema and current web writer are comparison dependencies, not proof of desktop execution. No product/test source, database, browser or build was changed or run for this prospective document. Examples above are independent arithmetic derivations and must become executable fixtures in the next authorized implementation.

| Inspected source | SHA-256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `unified/src/csharp/DataCareNext/UT_SETTING.cs` | `a47be9b0e2b7754511e8d0aeab135c8352c58f9f417101e550b23ccbc78c30ad` |
| `unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs` | `76116b14149afc1c6a5b93562c9aa9877979c43bdf6372e1d8fe1e6296aec4c5` |
| `unified/database/schema/01_Schema.sql` | `1eb684c7e2bec72a330a9038a2da72ffea669b3ae7ef50b85b34e0e3126efa0d` |
| `web/packages/db/prisma/schema.prisma` | `158aa2c66db0ff7b5b07931d853d73cb2aad0973880a0d7385eee6695c973754` |
| `web/apps/api/src/modules/sales/salesReturn.ts` | `612ddcd8f3b0cb8f0368435495125c8b50ed2f8cd03adad11f1cef12cf1d2a70` |
