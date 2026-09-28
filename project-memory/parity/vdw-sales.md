# Desktop ⇄ Web Parity — SALES (Gold/Silver Tax Invoice) · flagship

Read-only verification. **Desktop truth** = video-research KB (`851f2afc…`, `KB_transaction.md §1`) + mined catalog `catalogs/form-behavior/TR_SALE.behavior.json` (gridColumns / calc / validations / keyboard / inlineSql). **Web truth** = `web/apps/web/app/(app)/txn/sales/page.tsx`, `web/apps/api/src/modules/sales/{sales,invoice,salesOrder}.ts`, `web/packages/core/src/calc.ts`, `components/{KeyboardNav,LookupPicker}.tsx`.

Verdicts quote real evidence on both sides. Legend: **Match** = desktop behavior reproduced · **Partial** = present but incomplete/differs · **Gap** = absent.

---

## (a) Header fields — KB §1.2 (kf_004/kf_008)

| Desktop field | Web implementation | Verdict | Evidence |
|---|---|---|---|
| `Vch No` (auto, `F1`→Party) | Auto server-side `nextVoucherNoTx`; shown in `VoucherChrome vchNo={result?.vchNo}` | **Match** | KB "`Vch No` auto (e.g. `00002`)"; `sales.ts` `const vchNo = await nextVoucherNoTx(tx, input.scope)` |
| `Vch Date` (+time+weekday) | `<input>` date only in `VoucherChrome … onDateChange={setVchDate}` | **Partial** | KB "`Vch Date` auto `15/05/2021` + time `10:36:41` + weekday `Saturday`"; page has date only, no time/weekday |
| `Apr No` (+`A`, approval/tour import) | — none | **Gap** | KB "`Apr No` approval/tour reference; `A` button"; behavior `validations` "All Approval Tag In This Voucher Import?" + `inlineSql` `UPDATE APR_DETL … ISU_REC='N'`; no Apr field/import in `page.tsx` |
| `Ref No` (printed serial `T1-00001`) | `refNo` → `billNo` | **Match** | KB "`Ref No` printed bill serial"; page `refNo`, body `billNo: refNo || undefined` |
| `Party` (code+name; default **AC 45 Cash Sales**; `F1` inline-create) | `LookupPicker entity="accounts"` → `acCode`+`acName`; default `'WALKIN'`; picks existing only | **Partial** | KB "Default is **AC 45 = Cash Sales** … **F1** creates a Party inline"; page `useState('WALKIN')`, LookupPicker selects existing (no inline create, different default) |
| `Print` template (`SalesBillA4Gst`+`Set`) | `onPrint`→opens `/api/sales/invoice?…format=html`; no template dropdown/Set | **Partial** | KB "template dropdown `SalesBillA4Gst` + `Set`"; `invoice.ts` renders one fixed A4 GST template |
| party balance top-right (`Dr Amt`) | `<PartyBalance acCode={acCode} />` | **Match** | KB "top-right `15000.00 : Dr Amt`"; page mounts `PartyBalance` |
| live rate ticker | `<RateTicker />` | **Match** | KB status strip "Fine Gold/Silver"; page mounts `RateTicker` |

## (b) Main item grid columns — KB §1.3

Desktop headers: `Sr · TagNo · ItCode · Design · Size · Pcs · GrWt · LsWt · NetWt · ItRate · ItAmt · Lbr% · LbrRate · LbrAmt · OthAmt · TotAmt · Tax% · NetAmt`.
Web `<table class="grid">`: `Item · Tag · Pcs · Gross · Net Wt · Touch% · Rate · Making/g · Design · Size · Ls Wt · Lbr% · Oth Amt · Fine · Amount`.

| Desktop col | Web col | Verdict | Evidence |
|---|---|---|---|
| `Sr` | row index (implicit) | **Match** | rows `lines.map((l,i)=>…)` |
| `TagNo` | `Tag` (LookupPicker `entity="tags"`, auto-fills wt/touch/rate on pick) | **Match** | KB "scan a barcode… auto-fills GrWt/NetWt"; page `onPick={(r)=>…ITM_NWT…ITM_TOUCH…ITM_RATE}` |
| `ItCode` | `Item` (LookupPicker `entity="items"`) | **Match** | KB "`ItCode` Enter lists all items"; page `LookupPicker entity="items"` |
| `Design` / `Size` | `Design` / `Size` | **Match** | page `l.designNo` / `l.itmSize` → `designNo`/`itmSize` |
| `Pcs · GrWt · LsWt · NetWt` | `Pcs · Gross · Ls Wt · Net Wt` | **Match** | page inputs `pcs/grossWt/lessWt/netWt`; `SL_DETL` `ITM_PCS/ITM_GWT/ITM_OTH_WT/ITM_NWT` |
| `ItRate` | `Rate` | **Match** | page `l.rate` → `ITM_RATE` |
| `ItAmt` (metal only) | — folded into `Amount`(=net); `Fine` shown | **Partial** | desktop shows `ItAmt` (metal) as its own col; web shows `Fine`+`Amount`(net=metal+making), no standalone metal col. `sales.ts` stores `ITM_AMT: c.calc.metal` server-side |
| `Lbr%` | `Lbr%` (`lbrPct`) | **Partial** | column present, but page only wires **making/g**; `labourPct` sent yet `computeLine` ignores it unless `labourType` set (see (f)) |
| `LbrRate` | `Making/g` (per-gram) | **Partial** | KB `LbrRate`/`Ltype` (per-gram/piece/%/fixed); page fixes `labourType:'per_gram'` only |
| `LbrAmt` | — computed, not shown | **Partial** | server `LBR_AMT: c.calc.labour`; no grid column |
| `OthAmt` | `Oth Amt` | **Match** | page `l.othAmt`→`otherAmount`→`OTH_AMT` |
| `TotAmt` | — (only `Amount`=NetAmt shown) | **Partial** | server `TOT_AMT` computed; not a distinct visible col |
| `Tax%` (per line) | header-level `Tax %` only | **Partial** | desktop per-line `Tax%`; page single `taxRatePct`; server writes per-line `TAX_PRC` uniformly |
| `NetAmt` | `Amount` | **Match** | page `c.net`; `NET_AMT: c.calc.net` |
| `Touch%` (behind grid → fine) | `Touch%` **surfaced** | **Match**+ | behavior `gridColumns.cTouch=18/cFine=20`; web exposes Touch/Fine explicitly |
| Totals row `P= G= N=` | per-line totals; footer shows Taxable/Tax/Total only | **Partial** | KB "running totals `P=4 G=54.55 N=54.55`"; web has no Pcs/Gross/Net grand-total row |

## (c) Old-Gold / Old-Silver exchange grid (sub-grid B / `MSG_OLD`) — KB §1.4-B

Desktop cols: `Sr · ItCode · ItName · Pcs · GrWt · LsWt · NetWt · Touch · Fine · Rate · NetAmt`; supports **N (net-wise) / F (fine-wise)** rate types + melting/west% + touch back-calc from today's rate.

| Item | Web | Verdict | Evidence |
|---|---|---|---|
| Grid exists (metal in against bill) | `ogRows` grid: `Metal·Item·Pcs·Gross·Net·Touch%·Rate·Amount` + "Add exchange" | **Match** | KB §1.4-B; page `<h2>Old Gold / Silver Exchange</h2>` table |
| Metal G/S selector | `<select metal G/S>` | **Match** | page `setOg(i,'metal',…)`; `oldGoldDetl … IT_TYPE:'G'` |
| Fine = NetWt × Touch ÷ 100 | `((netWt*touch)/100)` | **Match** | KB "Fine = NetWt × Touch ÷ 100"; behavior calc `mSG_OLD[Row,8]=col6*col7/100`; page `ogAmt` uses `(o.netWt*o.touch)/100` |
| Amount = Fine × Rate | `…*rate` | **Match** | behavior `mSG_OLD[Row,13]=col8*col11`; page `ogAmt=(fine)*n(o.rate)` |
| **N vs F rate-type** toggle | — only fine-wise | **Gap** | behavior validation "Please Select Rate type = N - Net Wise Or F - Fine Wise" + calc `col13=col6*col11`(net) vs `col8*col11`(fine); web always fine-wise |
| `LsWt` col → NetWt = Gross−Less | Gross & Net are independent inputs | **Partial** | behavior `mSG_OLD[CRow,6]=col4-col5`; page has no less→net compute |
| melting/west% adj + touch-from-today-rate | — none | **Gap** | behavior `col10=col8*col9/100`, `col7=col13/ToDayGlRate/col6*100`; absent in page |
| posts SL_PR_DETL + MAIN_STOCK(+) | `oldGoldDetl`(SL_PR_DETL, SLOG) + `oldGoldStock`(MAIN_STOCK, MIXSL '+') | **Match** | KB §1.7 "old-gold in `VCH_TYPE=MIXSL … ITM_SIGN='+'`"; `sales.ts` both arrays |

## (d) Order-adjust (advance consumed into bill) — KB §1.5 Order sub-grid + `SL_ORD_ADJ`

| Item | Web | Verdict | Evidence |
|---|---|---|---|
| `Order Amt` tender + `Ord No` | `ordNo`+`ordAmt` inputs → `orderRef` | **Match** | KB "`Order Amt (0.00)` … Order sub-grid `Sr·Ord No·Ord Amt`"; page `orderRef:{ordNo,adjustAmt}` |
| clamp to available advance | `orderAdvanceAvailableTx` = `ADV_AMT − Σ PAID_AMT`, then `Math.min(want,available,balance)` | **Match** | `salesOrder.ts` `available: round2(adv - used.u)`; `sales.ts` `Math.max(0,Math.min(want,av.available,…))` |
| writes SL_ORD_ADJ, reduces BILL_OS | `adjustOrderIntoSaleTx` (SADJ, book ORA); `billOS = … − orderAdjust` | **Match** | `sales.ts` `if(orderAdjust>0) await adjustOrderIntoSaleTx(...)`; `BILL_OS` net of orderAdjust |
| multiple order rows | single `Ord No` only | **Partial** | KB Order sub-grid implies multi-row `Sr·Ord No·Ord Amt`; page one `ordNo` |
| **import ordered item lines/tags** by Ord No | — only money applied | **Gap** | desktop `inlineSql` pulls order pieces (`… FROM BAR_DETL … B.TAG_SALE='N' AND A.ORD_AC=?`, `SELECT * FROM SL_ORD_DETL …`); web applies only the advance amount, does not load the order's lines |

## (e) Right tender / totals panel — KB §1.5 (16 labels)

Desktop labels: `Net Amt · Disc Amt · Tax Amt(GST%) · Tcs Amt · Rof Amt · Total Amt · Cheque Amt · Card Amt · Order Amt · Old Gold Amt · Old Silver Amt · Scheme Amt · Cash Amt · Cash Paid Amt · Kasar Amt · Os Amt` (+ Employe/Bank/Vch Desc/CrDay).

| Desktop label | Web | Verdict | Evidence |
|---|---|---|---|
| `Net Amt` | `Net` tile | **Match** | page tiles `['Net', lineNet]`; `NET_AMT: totals.net` |
| `Disc Amt` | `Discount` input+tile | **Match** | page `discountAmount`→`DISC_AMT` |
| `Tax Amt` (`GST 3%`) | `Tax {%}` tile (+Taxable) | **Match** | page `taxPrev`; `TAX_AMT: totals.tax` |
| `Tcs Amt` | `TCS %` input + `TCS` tile | **Match** | page `tcsPct`; `sales.ts` `TCS_AMT: tcs, TCS_PRC: tcsPct` |
| `Rof Amt` (round-off) | computed & posted, **no tile** | **Partial** | `calc.ts billTotals` `roundOff`; `ROF_AMT: totals.roundOff` written; not shown as a tender field |
| `Total Amt` | `Total` tile | **Match** | page `totalPrev`; `TOT_AMT: grandWithTcs` |
| `Cheque Amt` (+deposit bank) | `Cheque ₹` (routes to `BANK`; no per-tender bank pick) | **Partial** | KB "pick **deposit bank** from list"; page `chequeAmt`→`bankAmt` all to `bankAc:'BANK'` |
| `Card Amt` | `Card ₹` | **Match** | page `cardAmt`→`CARD_AMT` |
| `Order Amt` | `Order Amt` | **Match** | see (d) |
| `Old Gold Amt` | `Old Gold/Silver` (combined) | **Partial** | page one `oldGoldVal` tile; captured via OG grid but not a separate Gold field |
| `Old Silver Amt` | folded into OG grid `metal='S'` | **Partial** | no distinct Old-Silver tender field/tile |
| `Scheme Amt` | — none | **Gap** | no `schemeAmt` in `SaleInput`/page; no ledger leg |
| `Cash Amt` | `Cash ₹` | **Match** | page `cashAmt`→`CASH_AMT` |
| `Cash Paid Amt` | — none | **Gap** | desktop distinguishes Cash vs Cash-Paid; web only `Cash` |
| `Kasar Amt` | `Kasar ₹` | **Match** | page `kasar`→`KASAR_AMT` |
| `Os Amt` (outstanding) | `Balance Due` tile (=BILL_OS) | **Match** | page `balanceDue`; `sales.ts BILL_OS: billOS` |
| `Employe` | `Employee` LookupPicker | **Match** | page `empCode`→`EMP_CODE` |
| `Bank` (deposit dropdown) | — implicit `BANK` | **Partial** | KB "`Bank` deposit-bank dropdown"; web fixed |
| `CrDay` | `CR Days` | **Match** | page `crDays`→`CR_DAYS` |
| `Vch Desc` | — none | **Gap** | KB footer "`Vch Desc`"; no narration field on sale |
| `UPI Amt` | `UPI ₹` | **Match**+ | page `upiAmt`→`UPI_AMT` (matches `SL_DATA.UPI_AMT`) |

## (f) Calc formulas — behavior `calc[]` (`MSG`/`val`/`MSG_OLD`) vs `calc.ts`+`sales.ts`

| Formula | Desktop | Web | Verdict | Evidence |
|---|---|---|---|---|
| line NetWt | `val[14]=val[12]−val[13]` (Gross−Oth) | Net entered / tag-filled | **Partial** | behavior `calc`; page has no gross−less→net auto-compute |
| **fine** | `Fine=(Net+GhtWt)×(Touch+West%)/100` | `fine = net×touch/100` | **Partial** | behavior `val[20]=(val[14]+val[17])*(val[18]+val[19])/100`; `sales.ts lineFine` omits GhtWt & West% (identical only when Ght=West=0) |
| **metal = fine×rate** | `val[23]=Round(num5×val[22],0)` | `metalAmount(fine,rate)=fine×rate` | **Match** | behavior calc; `calc.ts` `metalAmount = round(D(fineWt).times(rate))` |
| making (per gram) | `LbrAmt` per `Ltype` | `labourCharge('per_gram')=netWt×rate` | **Match** (service) | KB `Lbr%/LbrRate/LbrAmt`; `calc.ts labourCharge` per_gram |
| making per piece/%/fixed | `Ltype` P/%/N | supported in core, **not wired in page** | **Partial** | `calc.ts` has all 4; page sends only `{labourType:'per_gram'}` when `making` set → `Lbr%` override (KB "12%→10%") not sent |
| line net = metal+labour+other | — | `lineNet=metal+labour+other` | **Match** | `calc.ts lineNet` |
| GST split CGST=SGST=tax/2 (intra) / IGST (inter) | KB §1.7 | `gstSplit` (SGST=tax−CGST for exact parity) | **Match** | `calc.ts gstSplit`; `sales.ts` per-line `ITM_CGST_AMT/SGST_AMT/IGST_AMT` |
| taxable→tax→round-off→total | KB tender `Net→Disc→Tax→Rof→Total` | `billTotals` (`total=ROUND_HALF_UP(taxable+tax)`, `roundOff=total−preRound`) | **Match** | `calc.ts billTotals` |
| TCS = total×tcs% | `Tcs Amt` | `round2s((total*tcsPct)/100)` | **Match** | `sales.ts` `tcs = … (totals.total*tcsPct)/100` |
| Hallmark + its own GST | `HM_AMT`+`HM_TAX_AMT` | `hmAmt`,`hmTax=hmAmt×hmTaxPct/100` (+CGST/SGST/IGST split) | **Match** | KB §1.7 HM; `sales.ts hmAmt/hmTax/hmCgst/hmSgst/hmIgst` |
| old-gold fine/amount | `MSG_OLD` N/F | fine-wise only | **Partial** | see (c) |

## (g) Validations — behavior `validations[]` vs `sales.ts`

| Desktop guard | Web | Verdict | Evidence |
|---|---|---|---|
| "Please Insert Party and try" | `if(!input.acCode) throw SaleValidationError` | **Match** | `sales.ts` line 1 of `createSale` |
| "Item … Net Amount = 0" | `if(!lines||length===0) throw`; page filters empty lines | **Partial** | checks presence not net>0 (`MSG2_TOTAL[0,3]==0` in desktop) |
| balanced double entry | `assertBalanced(ledger)` | **Match**+ | `sales.ts assertBalanced(ledger)` before post |
| "Select Bank Account … Chq Amt<>0" | none (defaults `BANK`) | **Gap** | behavior validation present; no web check |
| "Select Card Bank Account … Card Amt<>0" | none | **Gap** | behavior validation present |
| "Select Employee Code" (if mandatory flag) | `empCode` optional | **Gap** | behavior `MsEmpCodeMendetry`; no gate |
| "Party in Defaulter List" | none | **Gap** | behavior `MsDefaulterAc`; no web check |
| "Voucher Date Not In Current Year" | none | **Gap** | behavior date-range guard; no web check |
| cash>CASH_LIMIT ⇒ **PAN** required | none in `createSale` | **Gap** | KB §1.7 "PAN gate: cash over `CO_SET.CASH_LIMIT` (₹2,00,000)"; absent (note: receipts enforce it in `finance.ts`, sales does not) |
| "Duplicate Tag No" (in-grid) | `issueTagTx` double-issue guard (stock level) | **Partial** | prevents re-selling issued tag, not in-grid dup detection |
| "Insert Cr Days" / licence / company-type B / token | reg/licensing | **n/a** | licensing guards, out of web scope |

## (h) Keyboard — behavior `keyboard{}` (F1×7, Enter×19, Ctrl+Enter×1, arrows) vs web

| Desktop | Web | Verdict | Evidence |
|---|---|---|---|
| `F1` = LOV (party/item/tag/order/emp/counter) | `LookupPicker` `if(e.key==='F1'){search(...)}` on accounts/items/tags/employees | **Match** (core pickers) | `LookupPicker.tsx:61` `if (e.key === 'F1'){ e.preventDefault(); search(value ?? ''); }` |
| Enter-chaining through fields | `KeyboardNav` Enter→focus next input, app-wide | **Match** | `KeyboardNav.tsx` "Enter … advance focus"; mounted `(app)/layout.tsx:29 <KeyboardNav/>` |
| `Ctrl+Enter` = Save | `KeyboardNav` Ctrl/Cmd+Enter→`form.requestSubmit()` | **Match** | `KeyboardNav.tsx:25` `if(e.ctrlKey||e.metaKey){ requestSubmit() }` |
| Arrow Up/Down in LOV list | `LookupPicker` ArrowUp/Down move highlight | **Match** | `LookupPicker.tsx:63-64` |
| F1 on **every** grid cell (order/counter/apr) | only on LookupPicker-bound fields | **Partial** | desktop F1 has 7 contexts; web F1 limited to party/item/tag/employee pickers (no order/counter/apr LOV) |

## (i) Ledger posting legs — KB §1.7 + Appendix vs `buildSaleLedger`/`createSale`

Desktop (`AC_DATA`, VCH_TYPE `SALE`, book `SAL`): **Dr** Cash · Bank · Old-gold · Customer(BILL_OS) ; **Cr** Sales(taxable, per-group `GROUP_MAST.SALE_AC`) · GST · Round-off ; +HM (Cr HMCHRG+GST, Dr cust) ; +TCS (Cr TCS, Dr cust) ; Kasar (Dr KASAR, Cr cust).

| Leg | Web | Verdict | Evidence |
|---|---|---|---|
| Dr CASH (cash tendered) | `if(cashAmt>0) push CASH DR` | **Match** | `buildSaleLedger` |
| Dr BANK (card+upi+cheque) | `bankAmt=card+upi+cheque → BANK DR` | **Match**/Partial | `sales.ts` `bankAmt: round2s(card+upi+cheque)`; **single BANK** (no per-tender deposit bank) |
| Dr OLDGOLD (metal in) | `if(oldGoldAmt>0) push OLDGOLD DR` | **Match** | `buildSaleLedger`; `oldGoldAmt = Σ oldGold.amount` |
| Dr Customer = BILL_OS | `if(balance!==0) push acCode DR` | **Match** | `balance = total − cash − bank − oldGold` |
| Cr SALES per-group split (Σ=taxable) | `buildIncomeLegs` over `GROUP_MAST.SALE_AC` | **Match** | KB "split per group via `GROUP_MAST.SALE_AC`"; `sales.ts` queries `g."SALE_AC"`, `buildIncomeLegs` |
| Cr GST (CGST+SGST/IGST) | `if(tax) push taxAc CR` + TAX_DATA rows | **Match** | `buildSaleLedger`; `taxRows` CGST+SGST intra / IGST inter |
| Cr ROUNDOFF | `if(roundOff) push roundAc CR` | **Match** | `buildSaleLedger` |
| HM: Cr HMCHRG + Cr GST + Dr cust | `if(hmAmt>0){ HMCHRG CR; taxAc CR; acCode DR }` | **Match** | `sales.ts` hallmark block |
| TCS: Cr TCS + Dr cust | `if(tcs>0){ TCS CR; acCode DR }` | **Match** | `sales.ts` TCS block |
| Kasar: Dr KASAR + Cr cust | `if(kasar>0){ KASAR DR; acCode CR }` | **Match** | `sales.ts` kasar block |
| Satellite tables | SL_DATA, SL_DETL, SL_IDTL, SL_PR_DETL, MAIN_STOCK(TGSL −/MIXSL +), TAX_DATA, BILL_OS_DATA | **Match** | KB Appendix row "Sales"; `postVoucherTx … writes:[…]` list matches exactly |
| Scheme Amt leg | — none | **Gap** | see (e) Scheme |

---

## Summary verdict

The **service/posting layer (`sales.ts` + `calc.ts`) is at true parity** with the desktop: metal=fine×rate, GST split, round-off, per-group income split, hallmark, TCS, kasar, order-advance adjust, old-gold-in, full satellite tables and balanced `AC_DATA` all match KB §1.7 and the Appendix. Keyboard (F1-LOV, Enter-chain, Ctrl+Enter save) also matches. The remaining gaps are **UI depth + a few edge formulas/validations**, not the money math.

## Top 5 concrete gaps (prioritized)

1. **Fine formula drops GhtWt + West%** — desktop `Fine=(Net+GhtWt)×(Touch+West%)/100` (behavior `val[20]`), web `lineFine = net×touch/100`. Correct for plain sales, but wastage/ghat-inclusive lines misprice. *(sales.ts `lineFine`)*
2. **Old-gold grid missing N/F rate-type + melting/touch-back-calc** — desktop toggles Net-wise vs Fine-wise (validation "Rate type = N … Or F") with melting% and touch-from-today-rate; web is fine-wise only. *(page.tsx `ogAmt`)*
3. **Approval (`Apr No`) import + `Scheme Amt` + `Cash Paid Amt` tender fields absent** — three desktop tender/header inputs (KB §1.2/§1.5) have no web field or ledger leg.
4. **Per-tender deposit-bank selection missing** — desktop picks the deposit bank for cheque/card; web routes all to a single `BANK` account. *(sales.ts `bankAc:'BANK'`)*
5. **Settlement validations + PAN/cash-limit gate not enforced on sale** — desktop blocks on missing cheque/card bank, employee-mandatory, defaulter party, out-of-year date, and PAN when cash > ₹2,00,000 (KB §1.7); `createSale` enforces none of these (only party + non-empty lines + balanced ledger).

**Also Partial (UI):** no per-line `ItAmt`/`LbrAmt`/`TotAmt`/`Tax%` columns or Pcs/Gross/Net totals row; per-bill `Lbr%` making-% override not wired to the page (core supports it); order-adjust applies advance money only (doesn't import the order's item lines/tags); no `Vch Desc`; date lacks time/weekday; print template picker absent; party default is `WALKIN` (not AC 45 Cash Sales) with no F1 inline-create.

---
*Report file: `/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/parity/vdw-sales.md`*
