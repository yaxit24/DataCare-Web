## DataCareNext — Master Parity-Gap Plan (web → exact desktop replica)

_2026-07-01. Consolidates the four code-grounded gap analyses — `GAP_transaction.md`, `GAP_other.md`,
`GAP_master.md`, `GAP_karigar.md` — into one prioritized, phased plan. Each analysis compared the desktop
knowledge base (`project-memory/video-research/_kb/KB_*.md`, from Sarvam transcripts + keyframes) against
the actual web code (`web/apps/web/app/(app)/**`, `web/apps/api/src/**`) and the decompiled desktop
(`extracted_code/DataCareNext/DataCareNext/*.cs`)._

## 0. Executive summary
**The service/posting layer is already faithful — do not rebuild it.** Verified at parity: balanced
posting (`posting.ts`: `assertBalanced`, `LEDR_KEY`/`DATA_TYPE`/`BOOK_NAME`, `reverseVoucherTx`+`DELETE_DATA`),
period-lock, `fine=net×touch/100`, GST split (`billTotals`/`gstSplit`, **Tier-4 190/190 exact**), and the
core services for Sales, Purchase, Contra, Cash/Bank rec+pay, Sales-Order, Sales/Purchase-Return, Tour,
Bill-to-Bill, Stock Adjust/Tag Transfer/Counter Transfer, Daily Rate derivation, Opening Balance, Bank
Recon clearing, Reminder Entry, and karigar fine-math.

**Gaps are almost entirely (a) UI fidelity** — the desktop's dense multi-column grids, sub-grids, tender
panels, header chrome — **and (b) a few missing behaviours** (dual-GST labour invoice, purchase/expense
settlement, order advance consumption + refund, sales-return import, auto barcode numbering, karigar rich
grids). Five cross-cutting **foundations** unblock most UI gaps at once.

**Effort:** Foundations ≈5–7d · P0 ≈15–20d · P1 ≈20–25d · P2 ≈10–15d. Order: Foundations → P0 → P1 → P2,
verifying each item (inject on `e2e` + suite + video cross-check) before the next.

## 1. Phase 0 — Foundations (high-leverage roots; build first)
| F | Foundation | Unblocks | Files | Effort |
|---|---|---|---|---|
| F1 | **`FormField` `select`+`lookup` types** — add `type:'select'|'lookup'`(+options/entity/side-effect); render `<select>`/`LookupPicker` in the generic master form. | Company State/Work/Metal type; Party `AC_GR`(→auto `AC_MAIN_GR`)/GST-type; Item/Group Product/Group/Sale-A-c/Purchase-A-c; Counter/Karigar pickers — code-field gaps across Company/Party/Item/Group at once. | `api/.../masters/master.service.ts`, `web/app/(app)/masters/[name]/page.tsx` | M |
| F2 | **Shared settlement/tender panel** — reusable `<TenderPanel>` (Cash/Cheque/Card/UPI/Kasar/Bank + Os) + backend `applyTender()` posting Cr/Dr cash-bank legs + `BILL_OS_DATA` REC_AMT (mirror `createSale`). | Purchase/Other-Exp/Purchase-Return (full-payable today); reused by Order Cancel, Karigar receive, Sales-Return refund. | `web/components/TenderPanel.tsx`(new); `purchase.ts`,`purchaseReturn.ts` | M |
| F3 | **Auto tag numbering** — `nextTagNoTx(tx,scope)` reads+increments `SRNO_MAST.TAG_SRNO` (6-digit, mirror `nextVoucherNoTx`) → `CHG00001`. | Barcoding unusable without it (Tag Opening, Only-Tag-Entry, Karigar-receive tagging, Purchase inline tag). | `api/.../vouchers/numbering.ts`, `stock/stock.ts` | S–M |
| F4 | **`SL_ORD_ADJ` helpers** — write/read `SL_ORD_ADJ` (`ORD_NO/ORD_AMT/ADJ_AMT/KASAR_AMT/PAID_AMT/PAID_AC`); `adjustOrderIntoSale()` + `cancelSalesOrderAdjust()`. | Sales-Order→Sales fulfilment + Order-Cancel refund-through-account (both impossible today). | `api/.../sales/salesOrder.ts`, `sales.ts` | M |
| F5 | **Shared voucher chrome** — `<VoucherHeader>` (Vch No pre-save, Date+time+weekday, Ref No, Print-template+Set) + action bar (◀▶ Print Save Cancel Delete Exit) + **list→edit/delete** wiring (every module already exports `delete*` + `DELETE /…/:vchNo`; no page exposes it). | Recurs on every txn screen; enables edit/delete/navigate. | `web/components/VoucherHeader.tsx`,`VoucherActions.tsx`(new); each `txn/*/page.tsx` | M |

## 2. Phase 1 — P0 (blocks desktop-equivalent core use)
| # | Screen | Missing behaviour | Fill plan | Dep | Eff |
|---|---|---|---|---|---|
| P0-1 | **Labour Invoice** `/txn/labour-sale` | posts to `/sales` as plain sale; no **dual GST (3% metal + 5% labour)**, no **order-gold credit** (chargeable = made−order-gold), no `LBR_*` tables. | new `sales/labourInvoice.ts createLabourInvoice()`: pull order-gold by `ordNo`(F4), charge surplus metal×rate+making, **two `TAX_DATA` rows**, post Dr customer/Cr labour+metal+GST3+GST5+order-gold Cr-Gold; write `LBR_DATA/LBR_ISU_DETL/LBR_ISU_IDTL/LBR_REC_DETL`; `POST /labour-invoice`; frontend order-gold panel + Ord-No picker + split tax totals + tender. | F2,F4 | L |
| P0-2 | **Purchase/Other-Exp/Purchase-Return settlement** | services accept **no tender** → always full payable/no refund. | add `cashAmt/chequeAmt/cardAmt/kasar/bankAc` to the 3 services → Cr/Dr cash-bank + `BILL_OS` REC_AMT (F2); wire `<TenderPanel>` on all 3 pages. | F2 | M–L |
| P0-3 | **Sales-Order → Sales fulfilment** `/txn/sales`,`/txn/sales-order` | order advance **never consumed**; `createSale` has no Ord-No; `SL_ORD_ADJ` never touched. | `createSale` accept `orderRef{ordNo,adjustAmt}`→`adjustOrderIntoSale`(F4); order: advance-by-mode + old-gold sub-grid + `DEL_DATE`; frontend Order-Amt tender row. | F4 | M |
| P0-4 | **Sales Return import-from-bill** `/txn/sale-return` | no Sale-Bill picker importing lines; no **receive-item re-stock grid** (editable `TagLRate`/MRP); no **refund-vs-credit** tender. | `salesReturn.ts`: `importFromBill()`; `receiveItems[]`→`createTagTx`; optional refund tender (Dr customer/Cr cash-bank, F2)+`BILL_OS` adjust; frontend picker+grid+refund panel. | F2,F3 | L |
| P0-5 | **Order Cancel refund** `/txn/order-cancel` | web only key-reverses advance; desktop books **refund through chosen `PaiidAc`** + `AdjAmt/KsarAmt/PaidAmt` in **`SL_ORD_ADJ`** (`TR_SL_ORD_ADJ.cs`). | `cancelSalesOrderAdjust()`(F4): insert `SL_ORD_ADJ` + balanced refund (Dr customer / Cr PaiidAc + Kasar); `POST /order-cancel`; frontend PaiidAc picker (default CASH). | F4 | M |
| P0-6 | **Tag Opening auto-barcode + rich fields** `/txn/tag-opening` | `TAG_NO` hand-typed (desktop auto `CHG00001`); `BAR_DETL` omits Counter/Design/Size/LessWt/Lbr%/LType/LbrRate/LbrAmt/OthAmt/PrCost/Karigar/Image. | F3 auto-number; extend `TagOpeningLine`+`tagOpening` to persist rich cols; frontend full grid + Counter/Karigar lookup(F1) + LType select + item sub-grid. | F1,F3 | M–L |
| P0-7 | **Karigar Issue + Receive rich grids** `/txn/karigar-issue`,`/karigar-receive` | 3/4-col toy vs 16/17-col + stone + barcoding sub-grids; party raw text; receive lacks per-line labour/GST(5%)/TCS/tender; `MAIN_STOCK` omits `KR_*` cost block; wired to thin `karigar.ts` not `mfg.ts`. | **converge on `mfg.ts`** (`MFG_ISU_REC`): point pages at `/mfg/issue`+`/mfg/receive`; extend `receiveMfg` for GST split + `KR_*` cols + stone(`MFG_IDTL`) + tagging(`BAR_DETL`/`TAG_PRINT_DATA`,F3) + tender; party LookupPicker(group10)+F1; live Dr-Gold; balance/reports read `MFG_ISU_REC`. | F1,F2,F3 | L |
| P0-8 | **Karigar report inversion (BUG)** | `karigarBalances`/`karigarStatement` treat `INOUT_TYPE='I'` as *issued* while posting uses issue=`'O'` → balance is negated, columns swapped. | flip the two `CASE WHEN` in `reports.ts`+`reports4.ts` (issued⇢`'O'`, received⇢`'I'`) + regression test. | — | S |

## 3. Phase 2 — P1 (important fields / behaviours / missing screens)
| # | Screen | Gap | Fill | Eff |
|---|---|---|---|---|
| P1-1 | Sales Invoice fidelity `/txn/sales` | Apr-No/Ref-No/print header; **charges sub-grid HM/RD→OthAmt**; item cols Design/Size/LsWt/Lbr%/LbrRate/OthAmt; tender rows Old-Silver/Scheme/Cash-Paid/Order-Amt/Bank/CR-Days/Employe. | `SaleInput`: `charges[]/oldSilver[]/schemeAmt/crDays/empCode/aprNo/per-tender bankAc`; frontend full 18-col grid + charges sub-grid + tender + header(F5). | L |
| P1-2 | Company detail form `/masters/companies` | only code+name; missing State(+picker)/WorkType/MetalType/GST/CST/PAN/address/bank/jurisdiction. **State/GST → tax split (P0-flavoured).** | full `formFields` on `CO_MAST_CONFIG` (+State lookup, Work/Metal select via F1). | M |
| P1-3 | User rights matrix UI `/admin/users` | `USER_SET`+`/me.allowedForms` exist server-side; only 3 global flags in UI; ~54-row Main/Sub×View/Edit/Delete/Print grid not configurable. | `rbac/formCatalog.ts` + `GET /admin/form-catalog`; per-user Rights grid; verify shell enforces `allowedForms`. | M |
| P1-4 | Auto Item `/masters/auto-item` (missing) | no `MS_AUTO_ITEM`; items one-at-a-time; code/name not auto-derived. | `masters/autoItem.ts` bulk-insert + `POST /masters/auto-item` + page (group→product Y/N). | M |
| P1-5 | Party fields + AC_GR lookup `/masters/customers` | `AC_GR` free-text (→auto `AC_MAIN_GR`); missing `AC_MOBILE2`/RefBy/**BIRTH_DATE**/**ANV_DATE**/`KHATA_NO`; GST-type not select. | append `formFields` + AC_GR lookup / GST-type select (F1). Birth/Anniv feed P1-9. | M |
| P1-6 | Physical Stock `/txn/physical-stock` | reconciles vs `TAG_STOCK` not **`BAR_DETL`**; no weights/`DiffWt`, no Out/Apr, no save/**Reset**, no filters. | rebase on `BAR_DETL`; per-tag detail+DiffWt+Out/Apr; `savePhysicalCount`/`resetPhysicalCount`; frontend scan grid+filters+report. | L |
| P1-7 | Tag Print `/txn/tag-print` (missing) | whole label-reprint screen absent. | `stock/tagPrint.ts` (`listPrintableTags`+`renderTagLabels`); `GET /stock/tag-print`+`/label`; page+nav. | M–L |
| P1-8 | Tag Weight Change `/txn/tag-weight-diff` | credits generic WTDIFF/STKADJ not the **karigar party** (`KR_TOUCH/KR_FINE`); no Party field, no OLD-GOLD absorption, no payment. | `tagWeightDiff`: `partyAc`+`absorbItCode/sign`+`payAc`; frontend Party+absorption+payment. | M–L |
| P1-9 | Reminder dashboard `/txn/reminders` | only Sales+Order; **Birthday** built but unwired; missing WhSales/Dhiran/Scheme/ItemInOut; ages by party not **per-bill CrDay**. | dataset tabs; wire `/reminders/birthdays`; add 4 datasets + per-bill Sales-Rem aging. | M–L |
| P1-10 | Multi-line receipt/payment `/txn/receipt`,`/payment` | single-line; desktop multi-line grid (AcCode/Amount/Kasar/ItDesc) + Employe. | `postReceiptLines`/`postPaymentLines` (`lines[]`→one voucher + `PAY_DETL`); frontend line grid. | M |
| P1-11 | Per-bank Book + Chq No (bank rec/pay) | no Book concept (per-bank REC/PAY + default KASAR/BANK-CHARGES legs); no Chq-No col; no cheque print. | `BOOK_DATA` book master + chooser driving bankAc+default legs; Chq-No column. | M–L |
| P1-12 | Bill-to-Bill mixed tender `/txn/bill-to-bill` | single `mode`; can't mix cash+bank; no top tender grid/Chq-No. | `settleBills` accept `tenders[]`→Dr per leg; frontend top tender grid + Σ reconcile. | M |
| P1-13 | Other-Exp TaxType F/R + HSN `/txn/other-purchase` | forward-GST only; no **R (inclusive back-calc)**, no per-line HSN/CGST/SGST/IGST, no HSN master, no tender. | `createOtherPurchase` per-line `{hsnCode,taxPct,taxType}` (R→taxable=amt×100/(100+rate)); HSN master; tender(F2); frontend HSN grid. | M–L |
| P1-14 | Tour Isu-No picker + Apr-No→Sales `/txn/tour-return`,`/txn/sales` | no `Isu No` F1 picker loading issue lines; kept item can't bill via `Apr No`. | `GET /tour/:vchNo/lines`; `Apr No`→`createSale` bridge (`EMP_SALE='Y'`); persist APR_DETL desc cols. | M |
| P1-15 | Daily Rate grid `/txn/daily-rate` | 3 inputs only; no per-group grid/`Tax%`/Employee/**F1 history** (no GET). | `getDailyRate(coCode,date)`; `postDailyRate` overrides+tax; `GET /daily-rate`; editable grid+history. | M |
| P1-16 | Stock Adjust fields `/txn/stock-adjust` | missing Counter/Design/Size/LsWt/West%/Mrp/KrCode + karigar sub-grid; `+` defaulted; no tag autofill. | `StockAdjustLine` add fields; frontend Counter picker+cols+tag onPick autofill+Sign validation. | M |
| P1-17 | Tag Transfer autofill/OUT code `/txn/tag-transfer` | tag pick no autofill; blank `fromItCode`→OUT on wrong item; missing Counter/Design/Size/LsWt/West%. | frontend tags `onPick` autofill; `tagTransfer` require resolved `fromItCode`; add cols. | S–M |
| P1-18 | Tag Cancel register/guard `/txn/tag-cancel` | writes only `MAIN_STOCK`; no `BAR_CAN_DATA/DETL` register; no in-stock guard; ignores body scope. | `tagCancel` write `BAR_CAN_*` + in-stock pre-check; route read body scope. | S–M |
| P1-19 | Backup completeness `/backup` | JSON omits BAR_*/MAIN_STOCK/ITM_OPBL/OP_DATA/LOGIN_MAST/USER_SET/CO_SET/SRNO_MAST/YEAR_MAST/AC_GROUP/TABLE_MAST; no restore. | expand `ops/backup.ts` TABLES; add admin `POST /backup/restore` (re-insert within `withTenant`). | S–M |

## 4. Phase 3 — P2 (polish / print / display)
| # | Item | Fill | Eff |
|---|---|---|---|
| P2-1 | Print templates Orig/Dup/Trip + Gold-Tax-Invoice/receipt/cheque | template registry + `reports/render.ts`; per-screen dialog (F5) | M |
| P2-2 | Contra two-line Cr/Dr grid + ItDesc + equal-amount check + receipt | `contra/page.tsx` layout | S |
| P2-3 | Bank-Recon per-row `AmtBal` + `Ac Name` + Op-Balance row; From/To=current month | `bankReconList` cumulative+name join | S–M |
| P2-4 | Labour Update multi-slab keying (verify schema; key by SR_NO/slab) | `labourUpdate.ts` slab key | S |
| P2-5 | Reminder Entry EntDate/RemDate/Mobile columns | store `ENT_DATE` + join mobile | S |
| P2-6 | Year Create opening/close/year-month + auto-seed-on-create + reopen copy | `YEAR_MAST_CONFIG` + combined flow | M |
| P2-7 | Party photo + Family tab + inline opening-at-create | image upload + tabbed form | L |
| P2-8 | Karigar print + MFG/Karigar ledger (decide `FINE_DATA` vs AC_DATA metal legs) | print endpoints + ledger report | M |
| P2-9 | Voucher edit/delete/navigate from list on every txn screen | via F5 + per-screen list | M |
| P2-10 | Purchase URD books + Only-Tag-Entry (loose→barcoded tags + QR) | book variants + `onlyTagEntry`(F3) | M |
| P2-11 | Tag-Stock Report tabs (In/Out/Stock/Mrp/Apr-Pending/All) + filters + Excel | report module + page | M |

## 5. Sequencing, dependencies & verification
**Deps:** F1→(P1-2,P1-4,P1-5,P0-6) · F2→(P0-1,P0-2,P0-4,P0-5,P1-13) · F3→(P0-6,P0-7,P2-10) ·
F4→(P0-1,P0-3,P0-5) · F5→(P1-1,P2-1,P2-9). Build **F1–F5 first**; P0-8 (1-line bug) can land immediately.

**Per-item verification (same discipline as the build so far):**
1. Re-read the `_kb/KB_*.md` section (+ keyframes) to confirm exact fields/columns/effects.
2. Backend **inject on `e2e`** (`.inject()` + `withTenant`): assert new tables/columns/legs balance, signed stock, reversibility; wipe after.
3. `api` build + `web` typecheck clean; **full suite green** (151/151 today — add a test per new behaviour: dual-GST labour, order-adjust, refund, auto-tag, karigar-report fix).
4. **Tier-4** calc-parity 190/190 unaffected for anything touching totals/tax.
5. Demo intact (`default` SL/AC unchanged); restart `:4000`.
6. Update `SPEC-RECONCILIATION.md` on completion.

**Guardrails:** keep posting/period-lock/fine-math untouched (Tier-4-verified); additive schema use only
(no destructive migrations on shared DB); secrets in env; every new voucher balances + reverses.

## 6. Top-10 highest-value (if time-boxed)
1. F1 Lookup infra · 2. F2 Tender + P0-2 (purchase/expense settlement) · 3. P0-1 Labour Invoice (dual GST) ·
4. F4+P0-3 (order advance→sale) · 5. P0-5 Order Cancel refund · 6. F3+P0-6 (auto barcode + rich Tag Opening) ·
7. P0-7 Karigar rich grids (converge on mfg.ts) · 8. P0-4 Sales-Return import · 9. P0-8 karigar report bug (1-liner) ·
10. P1-2 Company detail form (State/GST tax-correctness).
