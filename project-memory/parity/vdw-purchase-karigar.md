# Video-vs-Web Parity — PURCHASE + KARIGAR (manufacturing)

**Module:** Purchase (Gold/Silver/URD) + Karigar metal Issue/Receipt
**Method:** field-by-field compare of the DESKTOP behaviour (video-research KB `851f2afc…` + mined `*.behavior.json` catalogs) against the WEB implementation (`web/apps/web/app/(app)/txn/*` + `web/apps/api/src/modules/*`). Read-only; no code changed.
**Verdict legend:** Match = behaviour + data footprint equivalent · Partial = present but thinner/renamed/incomplete · Gap = absent in web.

## Sources actually read (evidence base)
- **Desktop behaviour:** `catalogs/form-behavior/TR_PURC.behavior.json` (loc 17256, 87-col grid map + `calc[]` + `inlineSql[]` + `validations[]`), `TR_KR_ISU.behavior.json` (loc 7062, 50-col grid + calc + tender), `TR_MFG_KR_ISU_REC.behavior.json` (loc 11975 — see note below).
- **Desktop KB:** `KB_transaction.md` chunks 13/14 (Purchase §6), `KB_karigar.md` chunks 2/4/7 (Karigar Issue Video 1 `Gd0TSp2OoXA`, Receipt Video 2 `CO9Ro-ZeeE8`).
- **Web:** `txn/purchase/page.tsx`, `apps/api/src/modules/purchase/purchase.ts`, `txn/karigar-issue/page.tsx` + `txn/karigar-receive/page.tsx` (both thin re-exports of `components/KarigarForm.tsx`), `apps/api/src/modules/manufacturing/karigar.ts`, `manufacturing/karigarVoucher.ts`, `routes/txn.ts` L468-479, `components/LookupPicker.tsx`, `apps/api/test/karigar.test.ts`.

> **Form-mapping correction (verified):** `TR_MFG_KR_ISU_REC.behavior.json` is the **MFG production** form (wax/casting weight `cCastingWt`/`cWaxWt`, lot `cMtrlLot`, sales-order link `cOrdAcCode`, sett-issue `MFG STNG ISU`, repair-adj). Its inlineSql targets `MFG_DATA/MFG_DETL/MFG_IDTL/MFG_ISU_REC`. That maps to the web **`mfg-issue`/`mfg-receive`** pages (`manufacturing/mfg.ts` → `issueMfg`, route `/mfg/issue`), **not** to `karigar-issue`/`karigar-receive`. The plain Karigar Issue/Receipt screens from the videos correspond to **`TR_KR_ISU`** (+ `KB_karigar.md`) and the web **`KarigarForm.tsx` → `karigar.ts`**. All Karigar rows below compare against `TR_KR_ISU`/`KB_karigar`.

---

## 1 · PURCHASE — `/txn/purchase` vs desktop `TR_PURC` (Gold Purchase Tax)

### 1.1 Header
| Field / behaviour | Desktop (evidence) | Web (evidence) | Verdict |
|---|---|---|---|
| Vch No + F1 new | `Vch No (+F1)` (KB §6.2); `validations`: *"Please Insert VchNo and try"* | `VoucherChrome vchNo={result?.vchNo}` — assigned server-side by `nextVoucherNoTx`, shown only after save | **Partial** — no editable/pre-shown running Vch No or F1-new |
| Vch Date + time + weekday | `Vch Date (+time+weekday)` (KB §6.2) | `date={vchDate}` `<input type=date>` via VoucherChrome | **Partial** — date only; no time/weekday |
| Ref No / Sl Bil No | `Ref No` · `Sl Bil No` (supplier bill no) | `billNo` → `refNo` (one field, mapped to `BILL_NO`) | **Partial** — single field covers both |
| Party (supplier) + F1 inline-create | `Party … F1 creates inline — ABC Jewellers, AC group 05` (KB §6.2) | `<LookupPicker entity="accounts">`; `LookupPicker.tsx` F1 = **search LOV only** (`if (e.key==='F1'){search(value)}`) — no create | **Partial** — F1 opens search; **no inline party create**, not filtered to supplier group `05` |
| Live `: Amt / : Gold / : Silvr` running balance | Right header labels (KB §6.2) | none | **Gap** |
| `Item Wt` (2 boxes) running weight | `Item Wt (2 boxes)` (KB §6.2) | none | **Gap** |
| Tax %, Discount, Inter-state, URD | Tax auto (3% GST); disc in tender panel | `taxRatePct`, `discountAmount`, `interState` select, `urd` select (header inputs) | **Match** (web is actually more explicit; incl. URD toggle) |

### 1.2 Main line grid
Desktop main grid (KB §6.2): `Sr·ItCode·ItName·Pcs·GrWt·OthWt·NetWt·Touch·West%·Fine·Rate·ItAmt·Ltype·LRate·LAmt·OthAmt·TotAmt`.
Web grid (`page.tsx` `<thead>`): `Item·Tag·Pcs·Gross·Net Wt·Touch%·Rate·Making/g·Fine·Amount`.

| Column | Desktop | Web | Verdict |
|---|---|---|---|
| ItCode / ItName | `ItCode`,`ItName` (F1 picker `ItemName·ItCode·Group`) | `LookupPicker entity="items"` (single code col) | **Partial** — no item-name column shown |
| Pcs / GrWt / NetWt / Touch | present | `pcs`,`grossWt`,`netWt`,`touch` | **Match** |
| **OthWt** (stone/other wt) | `OthWt`; `GrWt` opens stone/diamond detail box → NetWt (KB §6.2/6.3) | none (net entered directly) | **Gap** — no stone/diamond weight-detail box |
| **West%** (wastage) | `West%`; feeds Fine (calc below) | none | **Gap** — wastage not on purchase line |
| Fine (computed) | `Fine` col 24 | `{c.fine}` read-only cell | **Match** (value; see calc gap 1.4) |
| Rate / ItAmt | `Rate`,`ItAmt` | `rate` input, `Amount` = metal+making cell | **Partial** — ItAmt(metal) not shown separately from making |
| Ltype / LRate / LAmt | labour type + rate + amt cols; `MS_LBR_TYPE` driven | page sends only `making/g` → `{labourType:'per_gram',labourRate}` | **Partial** — only per-gram making; no Ltype picker / LRate / LAmt cols (though `purchase.ts labourCharge` supports per_pc/pct/fixed) |
| OthAmt | `OthAmt` col | none on page (API `otherAmount` exists) | **Gap** on UI |
| TotAmt | `TotAmt` col 40 = ItAmt+LbrAmt+OthAmt | not shown per-line | **Partial** |

### 1.3 Tender / right panel
Desktop (KB §6.2): `Net·Disc·Tax(3% auto)·Tcs·Rof·Total·Cheque·Card·Cash·Kasar·Os` + running balance, bank picker (HDFC).
Web: `<TenderPanel>` = cash/cheque/card/upi/kasar + `cashAc/bankAc/kasarAc`; header taxable/tax/total preview; `purchase.ts` computes `ROF_AMT`, `BILL_OS`.

| Item | Verdict |
|---|---|
| Net/Disc/Tax(auto 3%)/Total | **Match** — `billTotals`, `taxRatePct` default `'3'` |
| Rof (round-off) | **Match** (server `totals.roundOff` → `ROF_AMT`; not a live cell) |
| Cheque/Card/Cash/Kasar + bank picker | **Match** — TenderPanel + `payoutLegs` Dr supplier/Cr cash|bank+kasar |
| **Tcs Amt** | **Gap** — no TCS field/leg |
| Os (outstanding live) | **Partial** — `BILL_OS` computed & stored; not shown live on panel |

### 1.4 Line calculation (the crux)
| Formula | Desktop (`TR_PURC.calc[]` + grid map) | Web | Verdict |
|---|---|---|---|
| **Fine** | `mSG_PR[Row,24] = mSG_PR[Row,18] * (mSG_PR[Row,21] + mSG_PR[Row,22]) / 100` → `cPrNetWt=18, cPrTouch=21, cPrWestPrc=22, cPrFine=24` ⇒ **Fine = NetWt×(Touch+West%)/100** | `page.tsx`: `fine = r2((netWt*touch)/100)`; `purchase.ts lineFine`: `round3((netWt*touch)/100)` — **West% omitted** | **Partial/Gap** — web fine = NetWt×Touch/100; **drops the +West% wastage term** the desktop applies |
| NetWt from deductions | `mSG_PR[Row,18] = GrWt − (13+10+14+15)` (stone/kundan/less) | net entered directly; gross not deducted | **Partial** |
| Metal amt | `ItAmt = fine × rate` (rate-type N/F, `mSG_PR[Row,31]`) | `metal = r2(fine*rate)` | **Match** (net-wise); **Gap**: no Fine-wise `RateType F` (validation *"Select Rate type N or F"*) |
| Making | weight-slab `ITM_WT_MAST`, `LbrType` variants | `mk = netWt*making` (per-gram only) | **Partial** |
| Line total | `TotAmt = ItAmt+LbrAmt+OthAmt` | `net = metal+mk` | **Partial** (no OthAmt) |
| Per-party touch memory | `TOUCH_MAST` select + insert/update per AC+item (`inlineSql`) | none | **Gap** — no per-supplier touch/west/lbr recall |
| Rate by date | `RATE_MAST … VCH_DATE` auto-fill | manual `rate` | **Gap** |

### 1.5 Inline tagging ("Only Tag Entry" / barcoding)
| Behaviour | Desktop | Web | Verdict |
|---|---|---|---|
| Convert loose lot → many barcoded tags | Second grid (KB §6.2): `Sr·ItCode·TagNo·Counter·Design·Size·Pcs·GrWt·LsWt·NetWt·Lbr%·LbrRate·LbrAmt·OthAmt·PrCost·Mrp·Image·KrCode`; TAG_SRNO gen (`TR_PURC.inlineSql`); QR-916 label `QrPrint10` | `page.tsx` line has a single `Tag` LookupPicker; `purchase.ts createTagTx` creates **one tag per line** if `tagNo` given (`STK_TYPE 'R'`) | **Gap** — no loose→multi-tag conversion screen, no Counter/Design/Size/Mrp/PrCost tag grid, no QR label print of the new tags |

### 1.6 Effects — tables & ledger
| Effect | Desktop (KB §6.4, verified `purchase/purchase.ts`) | Web (`createPurchase`) | Verdict |
|---|---|---|---|
| Header `PR_DATA` (NET/DISC/TAX/CGST/SGST/IGST/ROF/TOT/HM_*) | yes | `header{…NET_AMT,DISC_AMT,TAX_PRC,TAX_AMT,CGST_TAX,SGST_TAX,IGST_TAX,ROF_AMT,TOT_AMT,HM_AMT…}` | **Match** |
| Lines `PR_DETL` `INOUT_TYPE 'I'`, `ENTRY_TYPE 'P'` | yes | `detl{…INOUT_TYPE:'I',ENTRY_TYPE:'P',BOOK_NAME:'PURCHASE'…}` | **Match** |
| `MAIN_STOCK` tag-IN `VCH_TYPE 'TGPR'`,`TR_TYPE 'P'`,`ITM_SIGN '+'` | yes | `mainStock{VCH_TYPE:'TGPR',TR_TYPE:'P',ITM_SIGN:'+'}` | **Match** |
| `TAX_DATA` input register `TAX_SIGN '-'` | yes | `taxBase{TRAN_TYPE:'P',BOOK_NAME:'PURCHASE',TAX_SIGN:'-'}` CGST/SGST or IGST rows | **Match** |
| `BILL_OS_DATA` payable | yes | `osRow{…BILL_AMT,REC_AMT,KASAR_AMT}` | **Match** |
| **Ledger `AC_DATA` VCH_TYPE `PURC`** | Cr supplier(total) · Dr `PURCHASE` (taxable, **per-group `GROUP_MAST.PURC_AC` split**) · Dr `GSTINPUT` · Dr `ROUNDOFF` | `buildPurchaseLedger` + `buildExpenseLegs` with live `ITEM_MAST⋈GROUP_MAST.PURC_AC` lookup; Cr supplier / Dr expense-legs / Dr `GSTINPUT` / Dr `ROUNDOFF` | **Match** — faithful incl. per-group split |
| Metal fine sub-ledger leg (`IT_TYPE 'G'/'S', SIGN '+', FINE_WT=Σfine, DR=CR=0`) | yes | `ledger.push({IT_TYPE:metalType,SIGN:'+',FINE_WT,DR_AMT:0,CR_AMT:0})` per metal type | **Match** |
| Hallmark purchase (Dr `HMCHRG` + input GST / Cr supplier) | `TR_PURC_HM` | `if(hmAmt>0)` HM legs + `HM_*` tax rows | **Match** |
| Delete reverses all + removes tags (rejects if tag sold) | `deletePurchase` | `deletePurchase` reverses `PR_DATA/PR_DETL/AC_DATA/TAX_DATA/BILL_OS_DATA/MAIN_STOCK` + `issueTagTx` | **Match** |
| URD / reverse-charge & the 4 books | URD = no input GST; books Gold/Gold-URD/Silver/Silver-URD | `if(input.urd) taxRatePct=0`; one page + `urd` toggle + per-line `metal` G/S | **Partial** — URD zeroes GST but **no reverse-charge output leg**; books not separated |
| Print copies / `< >` nav | Original/Dup/Trip; nav | `VoucherList` (delete/print list) + "View Purchase Bill"; no per-copy, no `<>` nav | **Partial** |

**Purchase summary:** service/ledger layer is a **strong Match** (per-group PURC_AC split, metal fine leg, hallmark, TGPR stock-IN, all satellite tables, faithful delete). The **UI + line math are the weak side**: no West%/OthWt/stone-box, per-gram-only making, no Tcs, and critically the **fine formula omits wastage**. The **Only Tag Entry barcoding workflow is absent**.

---

## 2 · KARIGAR ISSUE — `/txn/karigar-issue` vs desktop `TR_KR_ISU` (Kr Issue)

`karigar-issue/page.tsx` → `<KarigarForm mode="issue"/>` → `POST /karigar/issue` (`routes/txn.ts` L468) → `issueKarigar()` (`karigar.ts`).

### 2.1 Header
| Field | Desktop (`KB_karigar` V1 §2; `TR_KR_ISU`) | Web (`KarigarForm.tsx`) | Verdict |
|---|---|---|---|
| Vch No + F1 | `Vch No [00001] + F1` | none (server-assigned, shown post-save as `res.vchNo`) | **Gap** |
| Vch Date + time + weekday | `Vch Date [07/07/2021]+time[21:10:25]+weekday[Wednesday]` | none (defaults to `new Date()` server-side; **route ignores `vchDate`**) | **Gap** |
| Ref No | present | none | **Gap** |
| Party (group-10 karigar) + F1 create | `Party [000209 MANOJ KARIGAR]`, F1 create (kf_023); `inlineSql` picker `AC_GR in ('02','22','03','23')` | `<LookupPicker entity="accounts">` search-only, not group-filtered, no create | **Partial** |
| Live `: Dr Gold` (red) + `:Amt/:Gold/:Silvr` | `100.000 : Dr Gold` live label | manual **"Check balance"** button → `GET /karigar/:ac/balance`; shows `N fine (karigar owes us)` | **Partial** — balance exists but not a live per-line header label |
| Footer image / Employe / Bank / Vch Desc / nav `< >` | all present | none | **Gap** |

### 2.2 Grid
Desktop `TR_KR_ISU` grid (16 visible, KB §2): `Sr·TagNo·ItCode·ItName·Counter·Pcs·GrWt·OthWt·NetWt·Touch·West%·Fine·ConIt·Con%·ConWt·TotWt` (catalog cols: `cTagNo=1,cItCode=2,cItName=3,cCounter=4,cDesign=5,cPcs=6,cGrWt=7,cOthWt=8,cNetWt=9,cGhtWt=10,cTouch=11,cWestPrc=12,cLesTch=13,cLesWt=14,cFine=15,…cConItm=17,cConPrc=18,cConWt=19,cTotWt=20,cAvgRate=21,cAvgAmt=22,cItRate=24,cItAmt=25,cLbrType=26,cLbrRate=27,cLbrAmt=28,cNetAmt=29`).
Web issue grid: `Item·Design·Ctr·Size·Pcs·Gross·Oth Wt·Net Wt·Ght Wt·Touch%·Fine`.

| Column | Desktop | Web | Verdict |
|---|---|---|---|
| ItCode/Design/Counter/Size/Pcs/GrWt/OthWt/NetWt/GhtWt/Touch | present | `itCode,designNo,tblCode,itmSize,pcs,grossWt,othWt,netWt,ghtWt,touch` | **Match** (10 of the working cols) |
| **TagNo** (issue tagged tags out) | `cTagNo=1` + tag-resolve `inlineSql` (MAIN_STOCK⋈BAR_DETL) | none in issue mode | **Gap** |
| ItName | shown | code only | **Partial** |
| West% (issue) | `cWestPrc=12` present | issue mode hides West% | **Partial** (desktop issue West%=0 in videos; still a field) |
| Conversion leg `ConIt/Con%/ConWt/TotWt` | `cConItm/cConPrc/cConWt/cTotWt` | none | **Gap** — no metal-conversion leg |
| `LesTch/LesWt` | `cLesTch=13/cLesWt=14` (loss) | none | **Gap** |
| Fine (computed) | `cFine=15` | `{fine(l)}` cell | **Match** |

### 2.3 Calc + effects (issue)
| Item | Desktop | Web | Verdict |
|---|---|---|---|
| **Fine (issue)** | `mSG[Row,15]=mSG[Row,9]*(mSG[Row,11]+mSG[Row,12])/100` (NetWt×(Touch+West)/100); issue West=0 ⇒ NetWt×Touch/100 | `fine=r3(netWt*(touch+0)/100)` (issue); `karigar.ts fineWeight = round3(nwt*touch/100)` | **Match** (`karigar.test.ts`: `fineWeight(100,92)=92`) |
| NetWt = GrWt−OthWt | `mSG[Row,9]=mSG[Row,7]−mSG[Row,8]` | net entered directly (not derived) | **Partial** |
| Header tables | `MFG_ISU_REC (+MFG_DETL)` w/ `INOUT_TYPE` | `KR_DATA` + `KR_DETL(INOUT_TYPE 'O')` | **Partial** — simplified; **`MFG_ISU_REC` not written** by `karigar.ts` |
| Stock OUT | `MAIN_STOCK` metal out, sign '−', `BOOK 'KARIGAR'` | `stockRows(TR_TYPE 'O', sign '-', BOOK_NAME 'KARIGAR')` | **Match** |
| **Metal ledger — Dr Gold** | issue posts `Dr Gold 100` (karigar owes); desktop `FINE_DATA`; KB maps web→`AC_DATA` `IT_TYPE 'G'/SIGN '−'/FINE_WT` | `AC_DATA{VCH_TYPE 'KISU',IT_TYPE 'G',SIGN '-',FINE_WT=fineIssued,DR=CR=0}` | **Match** (semantics; `balance=issued−received>0` ⇒ "karigar owes us") |
| Money ledger | none (pure metal issue) | none | **Match** |
| INOUT alphabet | issue `'O'` (book 050) | `INOUT_ISSUE='O'` (test asserts) | **Match** |
| Print (issue voucher) | Original/Dup/Trip | "View Issue Voucher" HTML (`karigarVoucher.ts karigarIssueHtml`) | **Partial** — single HTML, no copy selector |

---

## 3 · KARIGAR RECEIPT — `/txn/karigar-receive` vs desktop `TR_KR_ISU`/Kr Received

`karigar-receive/page.tsx` → `<KarigarForm mode="receive"/>` → `POST /karigar/receive` (L473) → `receiveKarigar()`.

### 3.1 Grid (receive adds labour columns)
Web receive grid adds: `West%·LType·LRate·Lbr Amt·Oth Amt·Tag` to the §2.2 set.
| Column | Desktop (`TR_KR_ISU` / KB V2) | Web | Verdict |
|---|---|---|---|
| West% | `cWestPrc=12` | `westPct` input (receive only) | **Match** |
| LbrType/LbrRate/LbrAmt | `cLbrType=26/cLbrRate=27/cLbrAmt=28` | `lbrType` select (/g,/pc,Fix,%), `lbrRate`, `lbrAmt` | **Partial** — `lbrAmt` is **hand-typed**; no auto `LbrAmt=rate×wt` calc (desktop `calc[]` derives it) |
| ItRate/ItAmt (metal valuation) | `cItRate=24/cItAmt=25` + `AvgRate/AvgAmt` | none | **Gap** — no metal rate/amount valuation of received ornament |
| OthAmt (stone) | `cOthAmt=16` | `othAmt` | **Match** |
| Tag (barcode the piece) | Grid-B barcoding → `BAR_DETL/TAG_PRINT_DATA` | `tag` checkbox → auto `nextTagNoTx` → `BAR_DETL` | **Match** (F3 tagging) |

### 3.2 Fine formula + metal ledger
| Item | Desktop | Web | Verdict |
|---|---|---|---|
| **Fine = NetWt×(Touch+West%)/100** | `MS_UPDATE.cs` L2691 `num = ITM_NWT×(ITM_TOUCH+ITM_WEST_PRC)/100`; example `65×(92+0)/100=59.800` | `fineWithWastage = round3((nwt*(touch+westPct))/100)` | **Match** — `karigar.test.ts`: `fineWithWastage(100,90,2)=92` |
| **Cr Gold** (reduces Dr Gold) | receipt posts `Cr Gold 59.800`; balance `100−59.8=40.2 Dr` (kf_035); desktop `FINE_DATA`; web→`AC_DATA` `SIGN '+'` | `AC_DATA{VCH_TYPE 'KREC',IT_TYPE 'G',SIGN '+',FINE_WT=fineReceived,DR=CR=0}` | **Match** |
| Metal balance = Σissued−Σreceived | KB loop; wastage nets to 0 | `karigarBalance=round3(issued−received)`; `balanceTx` sums `KR_DETL` by `INOUT_TYPE` | **Match** — `karigar.test.ts`: `balance(fineWeight(100,92),fineWithWastage(100,90,2))=0` |
| INOUT alphabet | receipt `'I'` (book 052) | `INOUT_RECEIPT='I'` (test asserts) | **Match** |

### 3.3 Labour-payable ledger + settlement
| Item | Desktop (KB V2 §4, kf_035) | Web (`receiveKarigar`) | Verdict |
|---|---|---|---|
| **Labour payable Dr LABOUR / Cr karigar** | `Dr LABOUR / Cr MANOJ KARIGAR`; `Cr Amt 6,825 = LAmt 6500 + 5% GST 325` | `ledger`: Dr `labourAc`(labourAmt) + Dr `gstAc`(labourGst) / **Cr karigar** `creditToKarigar=labourAmt+labourGst` | **Match** |
| Labour GST (manual 3%/5%) | narration: "manually 3% or 5%… e.g. 5% on making = 325" | `labourGstPct` (default `'5'`), IGST or CGST/SGST split into `KR_DATA` | **Match** |
| **Pay karigar now (Cheque/Card/Cash) or leave Os** | step 10: pay via cheque/card/cash OR credit to his account (`Os`) | **only credits karigar A/c**; `receiveKarigar` books no cash/bank leg, no `RojMel` | **Gap** — cannot settle labour with cash/cheque/card on receipt; no Kasar/Os/Rof panel |
| Tender panel (`Net·Disc·Tax·Rof·Total·Chq·Card·Cash·Kasar·Os`) | `TR_KR_ISU` mSG2_TOTAL rows 0-9 | none (only labour+GST summary line) | **Gap** |

### 3.4 Stock-IN with karigar-cost columns
| Item | Desktop (KB V2 §4) | Web | Verdict |
|---|---|---|---|
| `MAIN_STOCK` metal-IN `TR_TYPE 'I'/sign '+'`, `BOOK 'KARIGAR'`, ITM_PCS/GWT/NWT/TOUCH/FINE | verified KREC kf_037/039 (`Pcs 5·GrWt 65·Fine 59.8·Sign +`) | `stockRows(TR_TYPE 'I', sign '+', BOOK_NAME 'KARIGAR', ITM_FINE=nwt×(touch+west)/100)` | **Match** |
| **Karigar-cost columns** `KR_NWT·KR_TOUCH·KR_WEST·KR_FINE·KR_LBR_AMT·KR_OTH_AMT·KR_COST` | desktop `Ac_Stock.cs` stamps them so the piece carries its making cost into stock | web `stockRows` writes ITM_* only — **no KR_* making-cost columns** | **Gap** |
| Categorize→barcode moves bulk→tag | narration; Grid-B / Only Tag Entry | `tag` flag writes `BAR_DETL` but no bulk-decrement/categorize reconciliation | **Partial** |

---

## Top 5 gaps (priority)

1. **Purchase line Fine drops wastage (West%).** Desktop `TR_PURC.calc`: `Fine = NetWt×(Touch+West%)/100` (cols 18/21/22→24); web `page.tsx` & `purchase.ts lineFine` compute `NetWt×Touch/100` with **no West%** — and no West%/OthWt columns or stone-detail box. Any wastage-bearing metal purchase mis-states fine (and thus metal-amount & stock fine). *(Contrast: the Karigar side gets this right via `fineWithWastage`.)*

2. **"Only Tag Entry" barcoding workflow absent on Purchase.** Desktop converts a loose purchased lot into many barcoded tags (18-col tag grid `TagNo·Counter·Design·Size·…·PrCost·Mrp·Image·KrCode` + QR-916 `QrPrint10`). Web `createPurchase` only creates **one tag per line** when a `tagNo` is typed; there is no lot→multi-tag screen and no new-tag QR label print.

3. **Karigar Receipt cannot pay the karigar (no tender/settlement).** Desktop step 10 pays labour via Cheque/Card/Cash or leaves `Os`, with a full `Net·Disc·Tax·Rof·Total·Chq·Card·Cash·Kasar·Os` panel (`TR_KR_ISU` mSG2_TOTAL). `receiveKarigar` only posts Dr LABOUR+GST / Cr karigar — the labour always sits as a payable; no cash/bank/kasar leg, no RojMel.

4. **Karigar stock-IN omits the KR_* making-cost columns.** Desktop `Ac_Stock.cs` stamps `KR_NWT·KR_TOUCH·KR_WEST·KR_FINE·KR_LBR_AMT·KR_OTH_AMT·KR_COST` onto the `MAIN_STOCK` IN row so each received piece carries its making cost into inventory valuation. Web `stockRows` writes ITM_* weights/fine only — downstream cost/valuation of karigar-made stock is lost.

5. **Karigar form has no voucher chrome / thin grid.** No Vch No/Date/time/weekday, Ref No, Bank, Vch Desc, Employe, image, `< >` nav, or Print(Orig/Dup/Trip); the route even ignores `vchDate`. Grid drops `TagNo`(issue), `ConIt/Con%/ConWt/TotWt` (metal-conversion leg), `LesTch/LesWt`, and `ItRate/ItAmt` metal valuation. Party picker is search-only (`LookupPicker`), not a group-10 karigar picker with F1 inline-create.

---

## Cross-cutting notes
- **Ledger/data faithfulness is the web's strength** on Purchase (per-group PURC_AC split, metal-fine leg, hallmark, TGPR stock-IN, TAX_DATA input register, BILL_OS, faithful delete) and on Karigar metal accounting (Dr/Cr Gold via `AC_DATA` metal legs, balance=issued−received, INOUT `O`/`I`, fine-with-wastage). These are verified in `karigar.test.ts`.
- **UI/workflow fidelity is the web's weakness**: missing header chrome, running balances, per-party touch memory (`TOUCH_MAST`), rate-by-date (`RATE_MAST`), Fine-wise `RateType F`, TCS, and the barcoding/print workflows.
- **`MFG_ISU_REC` divergence:** desktop plain Karigar writes `MFG_ISU_REC`; web `karigar.ts` writes only `KR_DATA/KR_DETL`. A richer `/mfg/issue`→`issueMfg` (writes `MFG_DETL` with `KR_CODE/IR_TYPE`, closer to desktop) exists but the `karigar-*` pages are **not** wired to it — they use the simplified `karigar.ts`.
- **Verification performed:** read all cited files end-to-end; confirmed the fine-formula/ledger parity against `apps/api/test/karigar.test.ts` (asserts `fineWeight(100,92)=92`, `fineWithWastage(100,90,2)=92`, `balance(…)=0`, `INOUT_ISSUE='O'`, `INOUT_RECEIPT='I'`). No code was modified.

**Report path:** `/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/parity/vdw-purchase-karigar.md`
