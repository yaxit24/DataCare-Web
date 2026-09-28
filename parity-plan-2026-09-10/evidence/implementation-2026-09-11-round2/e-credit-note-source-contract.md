# E Credit Note: source contract and unresolved decisions

Captured for round 2 on 2026-09-11 (Asia/Kolkata). This is a static reading of the extracted C# source. It is not an executable desktop capture, an approved tax interpretation, or evidence that the web credit-note writer has been implemented. The new web slice supports scoped read/browse and the separately guarded IRN action. X15 remains open.

Source paths below are relative to `imodule-extracted/`. Exact hashes are recorded in `source-contract-hashes.json`. Line references refer to this frozen source, not a new interpretation of the desktop behaviour.

## Document identity and stored row contract

`unified/src/csharp/DataCareNext/TR_SL_EBILL.cs` drives the configured E Invoice/E Crnt mode. IRN document type becomes `CRN` for `E CRNT` at lines 9353–9360. Reusing the invoice `INV` type is incorrect.

The parent grid-to-`SL_DETL` write at 7654–7685 maps pieces=5, gross=6, less/other weight=7, net=8, touch=9, wastage=10, fine=11, item rate=12, metal amount=13, labour percentage=14, labour basis=15, labour rate=16, labour amount=17, other amount=18, MRP=19, net amount=22, taxable rate=23, tax code=24, tax percentage=25, IGST=26, CGST=27, SGST=28, grand total=29 and ghat weight=34. `NET_AMT` and `TOT_AMT` both store grid column 22; `GRAND_TOTAL` separately stores column 29. A generic writer that treats the detail total as the tax-inclusive grand total would change the persisted contract.

At 7642–7643, parent `SR_NO` stores grid column 0 and `OLD_SRNO` stores column 52. Child `SL_IDTL.SR_NO` stores `DtIdtl[i][20]` at 7750. The apparent nearby computed `num2` is used for tag lookup; it is not the saved child parent key. Consequently a reader must join imported children through the parent's original identity (`OLD_SRNO`), preserve all children and reject ambiguous/orphan mappings. A fallback to the visible `SR_NO` may support earlier web-created rows, but must not override a unique source identity match.

## Calculation passes that a future writer must reproduce

`CommPassTotal` starts at 4714. Grid visibility and the currently committed cell affect its branches. Do not reduce the method to an unordered set of formulas or reuse the Tour Order cached-change algorithm.

1. Precision defaults: line labour rounding uses zero decimal places at 5121. At 5125–5136, registration `DM035NPDM` or `MsAllRofRemove == "Y"` makes metal precision (`num5`) and labour precision two decimals. Otherwise the relevant metal/labour amounts round to whole rupees. `Math.Round` is the desktop midpoint-to-even operation; later formatting has its own precision.
2. At 5155–5240, changed gross weight leads to gross minus less weight, formatted to three decimals. A nonzero ghat percentage derives ghat weight from net weight times percentage / 100, also formatted to three decimals. Fine weight is `(net + ghat) × (touch + wastage) / 100`, formatted to three decimals. When touch plus wastage is zero, the method explicitly substitutes net plus ghat.
3. The metal branch uses pieces for `P`, the selected weight divided by 10 for `1`, weight divided by 1000 for `K`, and direct selected weight otherwise. Grid column 11 visibility selects fine weight versus net weight. Amount rounds with the precision above. Do not assume this visibility from the row's numeric value.
4. Manual metal inversion at 5481–5510 runs only for current column 13, nonzero entered metal amount and a zero current item rate, with an available pieces/net basis. The derived rate rounds to three decimals.
5. Manual labour inversion at 5514–5572 runs for current column 17 when both amount and existing rate are nonzero. `P` divides by pieces; `N` divides by net plus ghat when `MsLbrWithGht == "Y"`, otherwise net; `K` literally divides by `(net + ghat)` and then by 1000; the default divides by gross weight. The literal `K` inverse is unusual and is not the algebraic inverse of the forward formula.
6. At 5576–5583, any nonzero labour percentage and item rate unconditionally derive labour rate as `itemRate × labourPct / 100`, rounded with `MsLbrRof` and formatted to two decimals. This can replace a rate derived by manual labour inversion earlier in the same pass.
7. At 5587–5631, any resulting nonzero labour rate recomputes labour amount: `P` uses pieces, `N` uses the configured net/ghat basis, `K` uses `(net + ghat) / 1000`, and the default uses gross weight. Precision is zero or two as above. Thus an entered manual amount may be overwritten later in the same pass. Tour Order's unchanged-cell cache must not be copied here.
8. Editing row total column 22 invokes 5639–5754. Labour becomes entered net minus other minus metal. A negative result clears labour and its rate, changes metal to entered net minus other, then derives metal rate. The following branches derive labour rate/percentage. Preserve the order of these transitions.
9. Ordinary net is metal + labour + other at 5769. At 5773–5784, nonzero MRP overrides net with MRP and sets taxable rate to net / pieces, formatted to three decimals. Otherwise, zero gross at 5788–5799 sets net to metal + other, omitting labour, and derives taxable rate using pieces. Otherwise nonzero net and net weight derive taxable rate using net weight at 5803–5810.
10. GST handling around 5102, 5403 and 5407 uses the account GST type. Type `I` computes IGST and clears CGST/SGST. The other branch computes CGST and SGST independently at half the tax percentage and clears IGST. Each tax component rounds with `MsTaxRof`. The later tax branch at 5814–5819 is conditional on nonzero net and percentage; independent desktop execution must establish whether a transition to zero tax clears all previously stored tax cells.
11. At 5431, line grand total is always `Math.Round(net + IGST + CGST + SGST, 0)`, including the all-rounding-removed branch. Summing line rounded grand totals is different from rounding an aggregate once.
12. F1 on column 22 at 5885–5944 extracts a tax-exclusive amount with whole-rupee rounding from `entered / (100 + taxPct) × 100`, changes labour or metal and associated inverse rates, then reruns `CommPassTotal`. This slice has a different `K` inverse using gross × 1000. Do not merge those branches based only on similar variable names.

## Header total, TCS and TDS

`BILL_TOTAL`, 9062–9145, sums parent net column 22 and tax columns 26/27/28. Header total is the sum of **each line's already rounded grand total (29)** plus TCS. Round off is header total minus `(net + all GST + TCS)`.

TDS is rounded to zero decimals from `net × TDS percentage / 100` only when the cached TDS percentage changes and net is nonzero; a zero percentage clears it. Outstanding is total minus TDS minus cash, cheque, card and kasar. A save-only aggregate function cannot silently discard the source's cached-edit behaviour.

The add-mode TCS threshold is literally `AcTcsAmt + net + IGST - CGST - SGST > 5,000,000`, while the computed tax base adds all three taxes. Above the threshold the branch selects an excess/full base, uses `TAX_MAST` type 20 and treats code `00` as disabled. Edit mode recalculates when TCS percentage changes, using whole-rupee rounding on `(net + all GST) × percentage / 100`; a changed header net invalidates the TCS cache. The minus signs in the threshold are a source anomaly to confirm, not silently normalize.

Header persistence at 7526–7562 stores TCS, TDS, round off and each tender separately. Discount and header tax percentage are written as zero. Future acceptance needs before/after state fixtures for the cached TDS/TCS transitions, thresholds, both GST account types, MRP, zero gross, mixed line rounding, tax-inclusive F1 and imported manually overridden values.

## Credit-note postings and source anomalies

`unified/src/csharp/DataCareNext/Ac_Ledr.cs`, `EInvoice_Ledr`, is bounded to 1837–1873. Follow these actual credit-note directions rather than reversing every invoice amount mechanically:

| Source reference | Literal source result |
| --- | --- |
| 1839 | `E CRNT` party credit is `TOT_AMT + DISC_AMT`; ordinary invoice is debit. |
| 1841, 1843 | Credit-note item net is debit to the header ledger account or the group sale account, with the source item-type condition. |
| 1845 | Credit-note tax is debit to the tax ledger for tax type 10 / source row 0. |
| 1847 | TCS ledger debit is gated to `BOOK_INOUT = 'O'`. A credit note using `I` gets no such ledger leg although its header total can include TCS. |
| 1849, 1851 | TDS party debit / tax credit are also `O`-only. An `I` credit note gets neither leg although outstanding subtracts TDS. |
| 1869 | Ordinary invoice round-off account uses source slot 5. |
| 1871 | Credit-note round-off account uses source slot 4. Negative round off is inserted literally as negative `CR_AMT`; positive round off is positive `DR_AMT`. |

For a source-level example with net 100.40, tax 0 and line grand total 100, round off is -0.40. The credit note produces party credit 100, revenue debit 100.40 and **credit -0.40** on the round-off leg. Arithmetic debit minus credit is then 0.80. This is an analysis of the SQL expressions, not an executed desktop observation. Do not add a balancing line, apply `abs`, or change direction and call that exact parity. Resolve whether the deployed desktop differs from this extracted source, or record an explicitly approved business/migration correction with separate expected outputs.

`unified/src/csharp/DataCareNext/Ac_Tax.cs`, `EInvoice_GST`, 267–275, writes `TAX_SIGN = '-'` for credit notes while retaining positive parent tax amounts. SGST maps tax-master source row 1, CGST row 2, IGST row 3 with the account-type conditions. Ledger and statutory-tax signs are separate contracts.

## Lifecycle obligations before X15 write acceptance

Save guards at `TR_SL_EBILL.cs:7382–7485` include licensing, cash limit, required employee, bank/card accounts, company mode, save time, financial-year range, lock date, edit permission, party, voucher and auto-number collision handling. At 7785–7800 save calls the EInvoice ledger, Rojmel, stock, GST and diamond-child posting helpers. Audit/narration handling around commit must also be captured. Delete at 7850 onwards checks lock, an IRN length greater than ten and rights, then removes the source write set.

Before enabling create/update/delete, capture independent desktop output for the calculation cases above and all touched header/detail/subdetail, ledger, tax, stock and Rojmel tables. Establish the deployed interpretation of negative credit-note round off, O-only TCS/TDS, the TCS threshold signs, K manual inversion and visibility-dependent formulas. Then implement explicit validation and transaction boundaries, rollback tests, stale edit protection, imported-history preservation, protected book/company/branch/year identity, provider failure/retry behaviour and actual browser journeys. Do not infer desktop approval from internally consistent web tests.

## Review of the bounded web read slice

The current `web/apps/api/src/modules/einvoice/creditNote.ts` selects a unique active configured `E CRNT` book with input direction and uses tenant/company/branch/year/book/voucher scope throughout a repeatable-read snapshot. It preserves full persisted parent/component data, prefers `OLD_SRNO` for imported child attachment and rejects duplicate/orphan children. `E_DATA` has the same complete compound primary key, so the registration query's single-row assumption is backed by the schema.

The browser gets company/branch/year from the authenticated business-scope provider; its generation counter discards obsolete async results after scope/book changes. The new surface remains a read/browse slice. At review time, its field-label whitelist omitted actual `BAG_WT`, `ITM_GHT_WT` and several karigar/stone fields returned by the API. This finite visibility finding was sent to the root implementer; the read-only review did not modify product code. Current implementation and test evidence must establish its final disposition separately.
