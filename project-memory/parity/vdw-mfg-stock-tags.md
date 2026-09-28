# Video-vs-Web Parity — MANUFACTURING + STOCK/TAGS

**Modules:** (1) Manufacturing — `TR_MFG_ISU_REC` (metal issue/receive), `TR_MFG_ORD_ISU`/`TR_MFG_ORD_REC` (design issue/receive vs order), `TR_MFG_KR_ISU_REC` (job-work production), `TR_MLT_PRO` (melting/refining). (2) Stock + Tags — `TR_TAG_OPBL` (tag opening), `UT_TAG_PRINT`/`RP_TAG` (tag print), `TR_TAG_SPLIT` (split), tag transfer (`TR_INOUT` book `TAG TRFR`), `TR_TAG_CAN` (cancel), `TR_TAG_WT_DIFF` (weight change), `TR_PHYSTK` (physical stock), stock adjust (`TR_INOUT`/`TR_TAG_CAN` book `STOCK ADJUST`), stock view (`RP_STOCK`).
**Method:** field-/calc-/leg-by-leg compare of DESKTOP behaviour (video-research KB `851f2afc…` + mined `catalogs/form-behavior/*.behavior.json`: `gridColumns`+`calc`+`inlineSql`+`validations`) against the WEB implementation (`web/apps/web/app/(app)/txn/*` + `web/apps/api/src/modules/{manufacturing,stock}/*` + wired routes in `routes/txn.ts`). Read-only; **no code changed**.
**Verdict legend:** Match = behaviour + data footprint equivalent · Partial = present but thinner/renamed/incomplete · Gap = absent in web.

## Sources actually read (evidence base)
- **Desktop catalogs:** `TR_MFG_ISU_REC.behavior.json` (loc 8001; 55-col grid, `calc[]` incl. fine `(net+ght)×(touch+west)/100`, `inlineSql[]` MFG_DATA/DETL/IDTL/ISU_REC + TAG_PRINT_DATA + delete), `TR_MLT_PRO.behavior.json` (loc 5244; melt grid + avg-touch + loss legs, MLT_DATA/DETL + MFG_DETL/ISU_REC + MAIN_STOCK), `TR_TAG_OPBL.behavior.json` (loc 14665; **112-col** grid, TAG_PRINT_DATA/TAG_SET/BAR_*), `TR_TAG_SPLIT.behavior.json` (loc 12941; parent+child grids, LBR_* labour tables, auto child-tag), `Mfg_Module.behavior.json` (book/stage registry MFG_MAST/BOOK_*).
- **Desktop KB:** `KB_karigar.md` (mfg issue/receive fine loop), `KB_other.md` chunks 2–8/11 (Tag Cancel+Print §2, Stock Adjust §3, Physical Stock §4, Tag Transfer §6, Tag Wt Change §7), `KB_master.md` chunks 9/10/12 (Tag/Item Opening §5), `KB_transaction.md` chunk 19 (Labour Work — melting context). No dedicated *melting* tutorial exists ⇒ melting ground-truth = `TR_MLT_PRO` catalog.
- **Web:** pages `txn/{mfg-issue,mfg-receive,mfg-order-issue,jobwork-issue,jobwork-receive,melting,tag-opening,tag-print,tag-split,tag-transfer,tag-cancel,physical-stock,stock,stock-adjust}/page.tsx`; API `manufacturing/{mfg.ts,melting.ts}`, `stock/{stock.ts,tagOps.ts,tagSplit.ts,tagPrint.ts}`; routes `routes/txn.ts` L480-L1050 (all endpoints confirmed wired).

## Form-mapping corrections (verified this session)
1. **`mfg-issue`/`mfg-receive` pages are wired to the REAL `/mfg/*` engine** (`manufacturing/mfg.ts` → `issueMfg`/`receiveMfg`, routes `txn.ts` L480/L485), which is a faithful `TR_MFG_ISU_REC` port (lot/design/ghat/west/labour-types/components/chol-ghis/ORD link, `MFG_DATA/DETL/IDTL/ISU_REC`+`MAIN_STOCK`, delete-reversal). **But the pages send only a 5-field subset** — the engine's richness is unused by the UI.
2. **`jobwork-issue`/`jobwork-receive` are 3-line re-exports of `KarigarForm`** (`return <KarigarForm mode=… label="Job-work" />`) → the simplified `karigar.ts` (`KR_DATA/KR_DETL`), **not** the rich desktop `TR_MFG_KR_ISU_REC` (wax/casting/lot/sales-order/sett-issue/repair). Job-work therefore inherits every karigar-form gap already logged in `vdw-purchase-karigar.md`.
3. **No `/mfg/order-receive`** route or page exists (grep of `routes/txn.ts`: only `/mfg/order-issue` + its delete). Desktop `TR_MFG_ORD_REC.behavior.json` (26 KB) has no web counterpart.
4. **Tag Print now HAS a web implementation** (`stock/tagPrint.ts` + routes `/stock/tag-print` & `/stock/tag-print/label`) — this **supersedes** the older KB note ("Tag Print has no web equivalent").

---

# MODULE 1 — MANUFACTURING

## 1 · MFG ISSUE — `/txn/mfg-issue` → `POST /mfg/issue` (`issueMfg`) vs `TR_MFG_ISU_REC`

### 1.1 Header / voucher chrome
| Field | Desktop (evidence) | Web (evidence) | Verdict |
|---|---|---|---|
| Vch No + F1, Vch Date+time+weekday, Ref/Bill No | `TR_MFG_ISU_REC.validations`: *"Please Insert VchNo and try"*; header `MFG_DATA` writes `BILL_NO/BILL_DATE/VCH_TIME` | page has `Book/Year/Location/Karigar/Party` inputs only; `vchNo` server-assigned, shown post-save | **Gap** — no editable Vch No/F1, no date/time/weekday, no Ref/Bill No |
| Party + Karigar (`AC_GR in '02,22,03,23'`) with F1 create | `inlineSql` party picker filters `AC_GR in('02','22','03','23')` | two `LookupPicker entity="accounts"` (Karigar + Party), search-only, not group-filtered | **Partial** — both parties present; no group filter / F1 create |
| Employee / Vch Desc / live `:Gold/:Amt` balance | `MFG_DATA.EMP_CODE`, `VCH_DESC`; live balance | none | **Gap** |

### 1.2 Line grid + calc (the crux)
Desktop main grid (`TR_MFG_ISU_REC.gridColumns`, 55 cols): `LotNo·ItCode·Design·Size·IsPcs·IsGrWt·IsOthWt·IsNetWt·Pcs·GrWt·OthWt·NetWt·GhtPrc·GhtWt·RtnChol·Ghis·MtrlIt·MtrlWt·LbrType·LbrRate·LbrAmt·OthAmt·NetAmt·…·Touch·WestPrc·Fine·…·ItRate·ItAmt·…·DmPcs·DmWt`.
Web grid (`mfg-issue/page.tsx <thead>`): `Item · Pcs · Gross · Net Wt · Touch% · Fine`.

| Behaviour | Desktop | Web | Verdict |
|---|---|---|---|
| **Line fine** | `calc`: `val[29] = (val[16]+val[26])·(val[27]+val[28])/100` ⇒ **Fine = (NetWt+GhtWt)×(Touch+West%)/100**; `val[26]=NetWt×GhtPrc/100` | engine `fineWithGhat = round3(((nwt+ghtWt)*(touch+westPct))/100)` (`mfg.ts`); issue page sends no ghat/west ⇒ `fine=net×touch/100` | **Match (engine)** / **Partial (UI)** — formula exact server-side; issue UI never captures Ght/West so only the degenerate case is reachable |
| NetWt = GrWt − OthWt | `MSG[16]=MSG[14]−MSG[15]` (also `[12]=[10]−[11]`) | net entered directly (page has no OthWt) | **Partial** |
| Lot / Design / Size / Counter | `cLotNo/cDesign/cSize` + lot-balance SQL (`Σissued IR_WT − Σrecv`) | `MfgLine.lotNo/designNo/size` exist in engine; **page sends none** | **Gap (UI)** — engine supports lot/design; `mfgLotBalance()` exists; UI omits |
| Ghat% / GhtWt / RtnChol / RtnGhis / Material | `cGhtPrc/cGhtWt/cRtnChol/cGhis/cMtrlIt/cMtrlWt` | engine fields exist; issue page omits all | **Gap (UI)** |
| Labour type/rate/amt (5 types) | `calc` labour variants: per-gross `val[10]×rate`, per-(net+ght) `(val[16])×rate`, per-kg `/1000`, per-10gm `/10`, %/pcs | engine `labourAmount` handles `P`(pc)/`N`(net+ght gram)/`K`(/1000)/default(gross) | **Partial** — 4 of the desktop's 5 modes; **missing per-10gm (`/10`) and the %-of-rate mode**; page has no labour column at all on issue |
| Diamonds / stone sub-components | `cDmPcs/cDmWt` + `MFG_IDTL` (`inlineSql` writes `IT_CON_PRC/IT_CON_WT/…`) | engine `MfgComponent[]`→`MFG_IDTL` exists; page sends none | **Gap (UI)** |
| **Barcode finished pieces (TAG_PRINT_DATA)** | `inlineSql`: `INSERT INTO TAG_PRINT_DATA(… ITM_FINE,LBR_*,ITM_MRP,DESIGN_NO,HM_ID,…) SELECT … FROM MFG_DETL` — the receive/issue barcodes the made pieces | `mfg.ts` writes **no** `TAG_PRINT_DATA`/`BAR_DETL` | **Gap** — web MFG cannot barcode manufactured pieces |

### 1.3 Effects — tables & legs
| Effect | Desktop | Web (`issueMfg`) | Verdict |
|---|---|---|---|
| Header `MFG_DATA` (GR_WT/NET_WT/FINE_WT/LBR_AMT/…) | yes | `header()` writes all those cols incl. `INOUT_TYPE 'O'`, `ENTRY_TYPE=irType`, `BOOK_NAME` | **Match** |
| Lines `MFG_DETL` + sub `MFG_IDTL` | yes | `detlRows()` (+`idtlRows()` when components) | **Match** |
| Metal-flow `MFG_ISU_REC` `ITM_SIGN '-'` (scrap cols 0) | yes (`isuRecRows`) | `isuRecRows()` `SIGN_ISSUE '-'`, `IR_WT=ITM_NWT` | **Match** |
| `MAIN_STOCK` out (`TR_TYPE 'O'/sign '-'`) when stage bears stock | `MFG_MAST.STK_ISU` | `doStock = stage.stkIsu==='Y' \|\| postStock!==false` → `stockRows(TR_ISSUE,SIGN_ISSUE)` | **Match** |
| Order (design-issue) link → mark `SL_ORD_DETL.DESIGN_ISU='Y'` | `TR_MFG_ORD_ISU` | `issueMfg` runs `UPDATE SL_ORD_DETL SET DESIGN_ISU='Y'` per `ordNo/ordSrno` | **Match** |
| Empty money ledger (pure metal) | yes | `ledger:{lines:[]}` | **Match** |
| Delete reverses all + DELETE_DATA + re-open order | `inlineSql` DELETE MFG_DATA/DETL/IDTL/ISU_REC/MAIN_STOCK + DELETE_DATA; `UPDATE MFG_DETL REP_ADJ` | `deleteMfg` reverses same 6 tables + DELETE_DATA + `DESIGN_ISU='N'` | **Match** |

**MFG-issue summary:** **service/posting layer = strong Match** (fine-with-ghat/wastage, `recWt`, lot balance, MFG_DATA/DETL/IDTL/ISU_REC + MAIN_STOCK, ORD link, faithful delete — the engine is a proper `TR_MFG_ISU_REC` port). **UI = thin** (6-col grid vs 55): no lot/design/size/counter/othWt/ghat/west/material/diamond/labour columns, no voucher chrome, and — engine-wide — **no barcoding of finished pieces** (`TAG_PRINT_DATA` never written).

---

## 2 · MFG RECEIVE — `/txn/mfg-receive` → `POST /mfg/receive` (`receiveMfg`) vs `TR_MFG_ISU_REC`

### 2.1 Grid + reconciliation
Web receive grid (`mfg-receive/page.tsx`): `Item·Pcs·Gross·Net Wt·Touch%·Ght Wt·Loss Wt·Fine·RecWt` + one header `Labour Amount ₹`.
| Behaviour | Desktop | Web | Verdict |
|---|---|---|---|
| **Accountable RecWt** | `MFG_ISU_REC` sum `IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS` (KB `TR_MFG_ISU_REC.cs`) | engine `recWt = irWt+rtnChol+rtnGhis+itmGhat+itmLoss`; page `recOf=net+ght+loss` | **Match (engine)** — chol/ghis exposed in engine; page comment "RTN_CHOL/RTN_GHIS not entered here" ⇒ **Partial (UI)** |
| **Line fine** | `(NetWt+GhtWt)×(Touch+West%)/100` | engine `lineFine`=`fineWithGhat(net,ght,touch,west)`; **page live-preview shows `fine=net×touch/100`** (ignores ght) | **Partial** — engine posts `(net+ght)×touch/100`; page preview under-reports fine when Ght>0 (display/calc mismatch) |
| Ghat / Loss inputs | `cGhtWt/ITM_LOSS` per line | `ghtWt`, `lossWt`(→`itmLoss`) inputs present | **Match** |
| Per-line labour type/rate + stone sub-grid | grid `LbrType/LbrRate/LbrAmt`, `MFG_IDTL` | page has **one header** `labourAmt` only; no per-line labour, no components | **Gap (UI)** |
| Tender panel (`Net·Tax·Rof·Cash·Kasar·Os`) | `mSG2_TOTAL` rows + `calc` `[6,3]=Total−Cash−Chq−…`; validation *"Please Select Bank Account … Chq Rec Amt<>0"* | `cashAmt/kasarAmt/billOs` accepted by engine but page exposes none | **Gap (UI)** |
| Barcode received pieces | `TAG_PRINT_DATA` insert from `MFG_DETL` | none | **Gap** |

### 2.2 Effects / legs
| Effect | Desktop | Web (`receiveMfg`) | Verdict |
|---|---|---|---|
| `MFG_ISU_REC` `ITM_SIGN '+'` filling `RTN_CHOL/RTN_GHIS/ITM_GHAT(=ght)/RTN_MTRL/ITM_LOSS` | yes | `isuRecRows` fills those on receipt | **Match** |
| `MAIN_STOCK` in (`TR_TYPE 'I'/sign '+'`) when `STK_REC='Y'` | yes | `doStock=stage.stkRec==='Y'` → `stockRows(TR_RECEIPT,SIGN_RECEIPT)` | **Match** |
| Labour settlement Dr LABOUR / Cr party | book `MFG * REC` seeds `LABOUR EXP A/C` (`Mfg_Module.inlineSql`) | `labourAmt>0` ⇒ balanced `Dr labourAc / Cr karigar\|party` | **Match** (but **no GST-on-labour** row, unlike karigar-receive which books 5% GST) |
| Karigar-cost stamp on stock (`KR_NWT/KR_TOUCH/KR_FINE/KR_LBR_AMT/KR_COST`) | desktop `Ac_Stock.cs` stamps them | `stockRows` writes `ITM_*` only | **Gap** — made-piece making-cost not carried into stock valuation |

---

## 3 · MFG DESIGN/ORDER ISSUE — `/txn/mfg-order-issue` → `POST /mfg/order-issue` vs `TR_MFG_ORD_ISU` (+ the ORD-RECEIVE gap)

| Behaviour | Desktop | Web (`mfg-order-issue/page.tsx` + `issueMfg`) | Verdict |
|---|---|---|---|
| Issue design vs an open sales order; grid `Item·Design·Pcs·Gross·Net·Touch·Order#·OrdLine·OrdCust` | `TR_MFG_ORD_ISU`; `MFG_DETL.ORD_NO/ORD_YRCD/ORD_DBCD/ORD_AC_CODE/ORD_DESIGN/ORD_SRNO` | page sends `ordNo/ordSrno/ordAcCode/ordDesign`; engine writes those ORD_* cols | **Match** (core linkage) |
| Mark consumed order line `DESIGN_ISU='Y'`; reverse re-opens | desktop guards order-cancel on `DESIGN_ISU='Y'` | `issueMfg` `UPDATE SL_ORD_DETL … DESIGN_ISU='Y'`; `deleteMfg` sets `'N'` | **Match** |
| Open-order **picker** (auto-pull pending `SL_ORD_DETL`) + design image | `TR_TAG_OPBL.inlineSql` pulls `SL_ORD_DETL WHERE DESIGN_ISU='N'` + `APR_DETL 'KARIGAR ORDER'` | user **types** Order#/OrdLine manually; no pending-order LOV | **Partial** |
| Karigar-order (`APR_DETL 'KARIGAR ORDER'`) path | present | none | **Gap** |
| BOM / components / lot / size / tender | grid + `MFG_IDTL` | none on this page | **Gap (UI)** |
| **Order RECEIVE** (receive finished ornament vs order, then tag) | **`TR_MFG_ORD_REC`** (dedicated 26 KB form) | **no `/mfg/order-receive` route or page** (grep confirms only `/mfg/order-issue`) | **Gap** — order-receive not implemented; generic `/mfg/receive` carries no ORD reconciliation |

---

## 4 · JOB-WORK ISSUE/RECEIVE — `/txn/jobwork-issue|receive` vs `TR_MFG_KR_ISU_REC`

| Behaviour | Desktop (`TR_MFG_KR_ISU_REC`) | Web | Verdict |
|---|---|---|---|
| Screen | rich MFG production form: wax/casting weight (`cCastingWt/cWaxWt`), lot (`cMtrlLot`), sales-order link (`cOrdAcCode`), sett-issue (`MFG STNG ISU`), repair-adj; targets `MFG_DATA/DETL/IDTL/ISU_REC` | `jobwork-*/page.tsx` = `return <KarigarForm mode=… label="Job-work" />` → `karigar.ts` (`KR_DATA/KR_DETL`) | **Gap** — job-work is a relabelled 4-col karigar toy; no lot/wax/cast/design/stone/barcoding/repair; uses `karigar.ts`, **not** the richer `/mfg/*` engine that already exists |

---

## 5 · MELTING / REFINING — `/txn/melting` → `POST /melting` (`meltProcess`) vs `TR_MLT_PRO`

Desktop melt grid (`TR_MLT_PRO.gridColumns`): main `ItCode·ItName·Pcs·GrWt·OthWt·NetWt·Touch·Fine`; second grid `…·Touch·Fine·ConPrc·ConWt·ConItCode·FinePrc·AddFine·MltWt·RtnWt·RtnIt·RecWt·LossWt`.
| Behaviour | Desktop (`TR_MLT_PRO.calc`) | Web (`melting.ts meltLine` + page) | Verdict |
|---|---|---|---|
| Input (party) fine = NetWt×Touch/100 | `val[8]=val[6]·val[7]/100`; `val[6]=GrWt−OthWt` | `partyFine = round3(netWt·touch/100)` | **Match** |
| **Average touch** of the melt = ΣFine/ΣGross×100 | `nAvgTouch = mSG_TOT[0,8]/mSG_TOT[0,6]·100` | **none** | **Gap** — no assay/avg-touch computation |
| **Loss model** | `MltWt=Fine+addFine`; `RecWt=MltWt−RtnWt`; **`LossWt = MltWt−(RtnWt+RecWt)`**; conversion add-fine via `ConItCode`/`FinePrc` | `netFine = recoveredFine ?? partyFine·(1−loss%/100)`; `lossWt = partyFine − netFine` | **Partial** — web is a flat "loss% or explicit assay"; no return-weight/received-weight legs, no conversion-item add-fine |
| **Stock movement** | writes `MAIN_STOCK` (scrap OUT / pure IN) + `MFG_DETL` + `MFG_ISU_REC` (all DELETEd on reverse) | `postVoucherTx(… writes:[MLT_DATA, MLT_DETL])` — **no MAIN_STOCK, no MFG_***; empty `AC_DATA` | **Gap** — a web melt records fine numbers but **does not move inventory** (scrap stays in stock, refined metal never enters) |
| Lot number generation | `SELECT LOT_NO … SUBSTRING(LOT_NO,2,2)`, `CurTagNo=+1` | none (no `LOT_NO`) | **Gap** |
| Sales-order design-issue (`ORNA_ISU='Y'`) + Employee/Emp-Transfer mandatory | `UPDATE SL_DATA SET ORNA_ISU='Y'`; validations *"Please Select Employee Code"*, *"…Emp Trfr Code"* | optional `acCode` only; no employee/emp-transfer, no order link | **Gap** |
| Delete / reverse | full delete (`inlineSql` DELETE MLT_DATA/DETL + MFG_DETL + MAIN_STOCK + MFG_ISU_REC + DELETE_DATA) | **no `deleteMelt`** in `melting.ts` | **Gap** — melt vouchers are not reversible in web |

**Melting summary:** web captures only the headline fine math (`partyFine/netFine/lossWt`) into `MLT_DATA/MLT_DETL`; it **omits the entire stock/MFG side, avg-touch, return/received/add-fine legs, lot, order link, employee, and reversal**. Highest-impact data gap in this audit.

---

# MODULE 2 — STOCK + TAGS

## 6 · TAG OPENING — `/txn/tag-opening` → `POST /stock/tag-opening` (`tagOpening`) vs `TR_TAG_OPBL`

Desktop `TR_TAG_OPBL` = **112-col** grid (`gridColumns`): incl. `HmId`(+`HmId2/3/4`+weights), `Style`, `Color`, `BagWt`, full **Karigar-cost** side (`KrOthWt/KrNetWt/KrGhatPrc/KrGhatWt/KrTouch/KrWestPrc/KrFine/KrLRate/KrLAmt/KrOthAmt`), `GhtPrc/GhtWt`, `Kundan/KndTch/KndNwt`, `Wax/KrWax`, `PrCost/TagCost/Margin/MainMrp/Mrp`, `ImageTake`, a **diamond sub-grid** (`c1Dm*`), and order/mfg pull columns (`OrdNo/OrdAc/MfgNo…`). Web line (`tag-opening/page.tsx`): `Tag No(auto)·Item·Ctr·Design·Size·Pcs·Gross·LsWt·Net·Touch%·Fine·Lbr%·LbrRate·OthAmt·MRP`.

| Behaviour | Desktop | Web (`stock.ts tagOpening` + page) | Verdict |
|---|---|---|---|
| Posting footprint `BAR_DATA + BAR_DETL + BAR_IDTL + MAIN_STOCK('TAGOP'/'P'/'+')`, no ledger | `inlineSql` BAR_DATA/DETL/IDTL, `TAG GEN` MAIN_STOCK IN | writes exactly `BAR_DATA`+`BAR_DETL`+`BAR_IDTL`+`MAIN_STOCK{VCH_TYPE:'TAGOP',TR_TYPE:'P',ITM_SIGN:'+'}` | **Match** |
| **Auto tag-number** (`SRNO_MAST.TAG_SRNO`, prefix) | `Select Max(TAG_SRNO)…LEN=6`; `mSG[67]=Co+Lc+date+VchSrno` | `nextTagNoTx(tx,scope,{prefix:itCode.slice(0,3)})` when blank; returns `tagNos[]` | **Match** — closes the KB "web tag no user-entered" gap |
| Counter/Design/Size/LsWt/Lbr%/LbrRate/OthAmt | rich cols | all present on page + persisted | **Match** |
| **Line fine** | `val[29]=(NetWt+GhtWt)×(Touch+West%)/100` | `fineOf = net×touch/100` (no ghat, no west) | **Partial** — opening fine omits Ghat & Wastage terms |
| HUID `HmId`(1-4)+weights | `cHmId/cHmId2..4` + `HmId*Wt`; validations *"Please Insert HmId2 Weight…"* | none | **Gap** |
| Style / Color / BagWt / Ghat%/GhtWt | present | none | **Gap** |
| Karigar-cost side (`Kr*`) + Kundan + Wax | full karigar costing sub-columns | none | **Gap** |
| Diamond/stone sub-grid | `c1Dm*` grid + `calc` con-wt/amt | none (`BAR_IDTL` written with pcs/gwt only) | **Gap** |
| PrCost / TagCost / Margin→MRP | `cPrCost/cTagCost/cMargin`; `val[45]=amt×(1+margin/100)` | `tagCost` in `TagOpeningLine` but **page has no PrCost/Margin column**; no margin→MRP calc | **Partial** |
| Counter **mandatory** | validation *"Please Insert Counter Code … Mandatory"* | page defaults `tblCode='001'`, not enforced | **Partial** |
| Pull open Sales-Order / Karigar-Order / MFG designs into tagging | `inlineSql` unions `SL_ORD_DETL`(`DESIGN_ISU='N'`)+`APR_DETL`(`KARIGAR ORDER`)+`MFG_DETL` | none | **Gap** |
| Image capture, barcode-scanner (COM), QR/TAG print picker (`PRINT_MAST`) | `TAG_IMAGE_DATA`, `Win32_PnPEntity`, `PRINT_MAST QR/TAG` | none (print via §7) | **Gap** |

**Tag-opening summary:** posting + **auto barcode number** = Match (a real improvement over prior audits); the UI captures the common tag fields but **omits HUID, Style/Color/BagWt, Ghat/Wastage-in-fine, the whole Karigar-cost side, Kundan/Wax, the diamond sub-grid, margin→MRP, image, and the open-order/mfg pull**.

## 7 · TAG PRINT — `/txn/tag-print` → `/stock/tag-print(+/label)` vs `UT_TAG_PRINT`/`RP_TAG`
| Behaviour | Desktop | Web (`tagPrint.ts` + page) | Verdict |
|---|---|---|---|
| List in-stock tags with filters, render label sheet | `RP_TAG`/`QrPrint10`; read-only, no data mutation (KB §2.4) | `listPrintableTags` (BAR_DETL not-sold; filters `tblCode/itCode/tagFrom/tagTo`) + `renderTagLabels` HTML; page selects & opens `/stock/tag-print/label` | **Match** — present & read-only |
| **Real scannable barcode** | Code39/QR selectable | `code39Svg()` renders genuine **Code39** SVG; label shows Tag#/Item/Design/Net/Gross/MRP/**HUID** | **Match (barcode)** — HUID rendered |
| **QR** option | `PRINT_MAST PRINT_TYPE 'QR'` (QrPrint10) | Code39 only | **Partial** — no QR variant |
| Rich label (firm name, product, group, `LC%`/`LP`, HM/RD charges) + print-template picker | KB §2.3/§5.2 label preview; `PRINT_MAST` picker | label lacks firm/group/LC-LP/HM-RD lines; no template picker | **Partial** |

## 8 · TAG SPLIT — `/txn/tag-split` → `/stock/tag-split` (`splitTag`) vs `TR_TAG_SPLIT`
| Behaviour | Desktop | Web | Verdict |
|---|---|---|---|
| Parent OUT (full) + each child IN; metal conserved | `TR_TAG_SPLIT`; validation *"Please Insert diff Wt … CrWt != DrWt"* | parent row `TR_TYPE 'O'/sign '-'` + child rows `'I'/'+'`; guard `|Σchildren.net − parent.net| ≤ 0.01` | **Match** |
| VCH_TYPE/book, no money ledger, reversible | `TGSPL`/`TAG SPLIT` | `VCH_TYPE 'TGSPL', BOOK 'TAG SPLIT'`, `ledger:[]`, `deleteTagSplit` | **Match** |
| Parent autofill from `BAR_DETL` on pick | F-key lookup | `LookupPicker entity="tags"` `onPick` fills item/net/gross/touch/fine | **Match** |
| Child fine | `mSG_PR[26]=(NetWt+GhtWt)×(Touch+West)/100` | `childFine=net×touch/100` | **Partial** — omits Ghat/West |
| **Auto child tag numbering** | `CurTagNo=+1`, `mSG_PR[2]=prefix+Lc+CurTagNo` | user must **type** each child `tagNo` | **Gap** |
| Per-child Design/Counter/Size/HUID/Labour | full parent(`cP*`)+child grids + `LBR_DATA/LBR_ISU_*` (labour re-book) + diamond sub-grid | children grid = `Tag·Item·Pcs·Net·Touch·Fine` only | **Gap** — no labour/diamond/design/counter on children |

## 9 · TAG TRANSFER — `/txn/tag-transfer` → `/stock/tag-transfer` (`tagTransfer`) vs `TR_INOUT` (book `TAG TRFR`)
| Behaviour | Desktop (KB §6) | Web | Verdict |
|---|---|---|---|
| Tag OUT + bulk-target IN, metal conserved, no ledger | 2 `MAIN_STOCK` legs `TAGTR`/`TAG TRFR` (OUT tag `-`, IN bulk `+`, same net/fine) | `tagTransfer` emits OUT `IT_CODE=fromCode,sign '-'` + IN `IT_CODE=toItCode,'N',sign '+'`; `VCH_TYPE 'TAGTR', BOOK 'TAG TRFR'`, book `TTR`, empty ledger | **Match** |
| Resolve source item from `BAR_DETL` on scan | auto-fill on tag select | resolves `fromItCode` from `BAR_DETL` when blank (never falls back to target) | **Match** |
| Fine incl. wastage | KB net/fine equal both legs | `fine = net×(touch+west)/100` | **Match** |
| Reversible | `deleteTagTransfer`+DELETE_DATA | `deleteTagTransfer` | **Match** |

## 10 · TAG CANCEL — `/txn/tag-cancel` → `/stock/tag-cancel` (`tagCancel`) vs `TR_TAG_CAN`
| Behaviour | Desktop (KB §2.4) | Web | Verdict |
|---|---|---|---|
| One `MAIN_STOCK` OUT per tag, no ledger | `Ac_Stock.Tag_Can_Stk` `BOOK 'TAG CANCEL'`,`TR_TYPE 'O'`,`sign '-'`; header/detail `BAR_CAN_DATA/BAR_CAN_DETL` | `tagCancel` MAIN_STOCK `TGCAN/'O'/'-'` + `BAR_CAN_DATA`+`BAR_CAN_DETL`; empty `AC_DATA` | **Match** |
| In-stock guard (exists in BAR_DETL, not already sold) | desktop only cancels stock tags | explicit guards: reject if not in `BAR_DETL` or has `MAIN_STOCK '-'` | **Match** (stronger) |
| Autofill on tag pick + reversible | F-key + delete | `LookupPicker` `onPick`; `deleteTagCancel` | **Match** |

## 11 · TAG WEIGHT CHANGE — `/txn/tag-weight-diff` → `/stock/tag-weight-diff` (`tagWeightDiff`) vs `TR_TAG_WT_DIFF`
| Behaviour | Desktop (KB §7) | Web | Verdict |
|---|---|---|---|
| Book the net weight difference into stock + a karigar/valuation leg | `Ac_Stock.Tag_Wt_Diff_Stk` (full OUT+IN replace) + `Ac_Ledr`/`Ac_Rojmel` | net-of-diff: one `MAIN_STOCK` of `|Δ|` (`TGWD`/`TAG WT CHANGE`, sign per direction) + party gold leg (`IT_TYPE 'G'`) + optional old-gold absorption + optional cash pay (Dr LABOUR/Cr cash) | **Partial** — metal delta, party gold sub-ledger, absorption & cash-pay are modelled (richer than prior KB read), but as a simplified net-diff, **not** the desktop full OUT+IN replacement |
| Old-vs-new grid (`OPcs/OGrWt/ONetWt/NwPcs/NwGwt/NwNet/DiffGWt/DiffNWt` + `Lbr%/LType/LbrRate`) | full grid | page collects `oldNetWt/newNetWt/touch/rate` per line only | **Partial/Gap** — no gross/pcs/other-wt old-vs-new, no per-line labour type |
| Party/valuation panel (`Cr/Dr Touch/Fine/1gm Rate/Amount/Cr Lbr Amt`) + tender (`Chq/Card/Order/Kasar/Os`) | present | none | **Gap** |
| "Split a set" (necklace → tags) second use | supported | not modelled (use Tag Split instead) | **Gap** |

## 12 · PHYSICAL STOCK — `/txn/physical-stock` → `/stock/physical-list`+`/physical-reconcile` vs `TR_PHYSTK`(+`RP_PHY_STOCK`)
| Behaviour | Desktop (KB §4) | Web (`physicalReconcile`/`physicalStockList` + page) | Verdict |
|---|---|---|---|
| Load in-stock tags (scan grid) + count | entry grid `TagNo/ItCode/Design/Size/Cntr/Pcs/GrWt/…` | `physicalStockList` (BAR_DETL not-sold; counter/item filters); page scan-to-count + checkbox + counted-wt | **Match** (count UX) |
| Variance = matched / shortage / surplus + weight diff | report `Stk vs Phy`, `Diff/DiffWt` | `physicalReconcile` → `matched/missing/extra` + per-tag `bookWt/countedWt/diffWt` + counts | **Match** (variance) |
| **Persisted count voucher** | writes `PHY STOCK` book → `BAR_CAN_DATA/BAR_CAN_DETL` | **read-only** — reconcile returns JSON, writes nothing | **Gap** — no saved count |
| **Out / Approval (Apr)** classification | report splits In/Out/Physical/Apr-Pending/Different | only in-stock vs counted (no Out/Apr split) | **Partial** |
| **Reset Stock** (permanent) | *"Physical Stock will Reset permanently?"* | client-side `reset()` only | **Gap** |

## 13 · STOCK ADJUST — `/txn/stock-adjust` → `/stock/adjust` (`stockAdjust`) vs `TR_INOUT`/`TR_TAG_CAN` (book `STOCK ADJUST`)
| Behaviour | Desktop (KB §3) | Web | Verdict |
|---|---|---|---|
| Signed `MAIN_STOCK` ± correction, no ledger, reversible | `STADJ`/`STOCK ADJ`,`TR_TYPE 'A'`,`ITM_SIGN ±`; `TR_INOUT` forces `+`/`-` | `stockAdjust` `VCH_TYPE 'STADJ', BOOK 'STOCK ADJ', TR_TYPE 'A', ITM_SIGN`± ; book `SAJ`; empty ledger; `deleteStockAdjust` | **Match** |
| `Sign` mandatory | *"choose + or −"* warning | page rejects lines missing `+`/`−` | **Match** |
| Fine incl. wastage | KB fine=net×(touch)/100 (west via group) | `fineOf = net×(touch+west)/100` | **Match** |
| Rich cols Counter/Design/Size/LsWt/West%/MRP/**Karigar** | grid + Counter picker | page has Ctr/Design/Size/LsWt/West%/MRP/`krCode`(Karigar) | **Match** |
| Lower karigar/ledger sub-grid (`ItCode/ItName/Pcs/KrWt/Con%/P/W/Rate/ItAmt/NetAmt`) | present | only `krCode` on the main line; no sub-grid | **Partial** |

## 14 · STOCK VIEW — `/txn/stock` (`/stock/on-hand`,`/stock/tags`,`/stock/tags` add) vs `RP_STOCK`/Tag-wise report
| Behaviour | Desktop (KB §5/§1 stock report) | Web (`stock/page.tsx` + `stock.ts onHand/onHandNet/listTags`) | Verdict |
|---|---|---|---|
| On-hand truth from signed `MAIN_STOCK` | `Ac_Stock` ItemSumm (signed net incl. non-tag) | `onHandNet` Σ(+in)−Σ(−out) of pcs/gwt/nwt/**fine** over ALL `MAIN_STOCK`; `onHand`/`listTags` from `BAR_DETL` not-sold | **Match** (engine has the correct signed-net stock truth incl. fine) |
| Item-wise report tabs `Group/Product/Item/Design/Safe/Table/Trading` + `Op/Pr/In/Ou/Sl/Cl` (Pcs+Wt) + date range + gross-wise toggle | full `RP_STOCK` | page shows flat tiles (`pcs/gwt/nwt`) + a single in-stock tag list | **Gap** — no Op/Pr/In/Out/Sl/Cl movement columns, no group/product/design/counter tabs, no date range, no fine tile |
| Tag-wise report tabs `In/Out/Stock/Mrp/Apr-Pending/All` | `RP_TAG` | not reproduced | **Gap** |
| Quick "Stock-in (Tag Opening)" on this page | proper Tag Opening (§6) | writes only to `TAG_STOCK` (tagNo/grCode/prCode/pcs/gwt/nwt/mrp) — a presence-model toy, **no** BAR_DETL/MAIN_STOCK | **Partial** — separate simplified add; real opening is `/txn/tag-opening` |

---

## Ledger / stock-leg conformance summary
| Voucher | Desktop legs | Web legs | Verdict |
|---|---|---|---|
| MFG issue | `MFG_DATA/DETL/IDTL/ISU_REC(-)` + `MAIN_STOCK(-)`, no money | same | **Match** |
| MFG receive | `…ISU_REC(+)` + `MAIN_STOCK(+)` + (labour) Dr LABOUR/Cr party | same (no labour-GST row) | **Match/Partial** |
| Melting | `MLT_DATA/DETL` + `MAIN_STOCK(scrap−/pure+)` + `MFG_DETL/ISU_REC` | `MLT_DATA/DETL` only — **no MAIN_STOCK/MFG** | **Gap** |
| Tag opening | `BAR_DATA/DETL/IDTL` + `MAIN_STOCK('TAGOP'+)` | same | **Match** |
| Tag split | `MAIN_STOCK(parent− / children+)` (+LBR_* when labour) | `MAIN_STOCK` parent−/children+ (no LBR_*) | **Match/Partial** |
| Tag transfer | `MAIN_STOCK(tag− / bulk+)` `TAGTR` | same | **Match** |
| Tag cancel | `MAIN_STOCK(−)` `TGCAN` + `BAR_CAN_DATA/DETL` | same | **Match** |
| Tag wt change | full OUT+IN replace + `AC_DATA`/`ROJ_MEL` | net-diff `MAIN_STOCK(±)` + `AC_DATA` party/absorb/cash | **Partial** |
| Stock adjust | `MAIN_STOCK(±)` `STADJ`, no ledger | same | **Match** |
| Physical stock | `BAR_CAN_DATA/DETL` (`PHY STOCK`) count voucher | read-only JSON (no write) | **Gap** |

---

## TOP 5 GAPS (priority)

1. **Melting moves no inventory and cannot be reversed.** Desktop `TR_MLT_PRO` writes `MAIN_STOCK` (scrap OUT / refined-metal IN) + `MFG_DETL` + `MFG_ISU_REC`, computes an **average touch** (`nAvgTouch=ΣFine/ΣGross×100`) and a **loss leg** (`LossWt=MltWt−(RtnWt+RecWt)`) with conversion add-fine, generates a `LOT_NO`, marks order design-issue (`ORNA_ISU='Y'`), requires employee, and is fully deletable. Web `melting.ts` writes only `MLT_DATA/MLT_DETL` with `partyFine/netFine/lossWt` and an **empty ledger + no stock rows + no `deleteMelt`** — so a melt records numbers but the scrap never leaves stock, the pure metal never enters, there's no avg-touch/return/received legs, no lot, and no reversal.

2. **MFG issue/receive UI wastes a faithful engine.** `mfg.ts` correctly ports `TR_MFG_ISU_REC` (fine `(net+ght)×(touch+west)/100`, `recWt=IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS`, lot balance, `MFG_DATA/DETL/IDTL/ISU_REC`+`MAIN_STOCK`, ORD link, faithful delete). But the pages send only `{item,pcs,gross,net,touch}` (+ght/loss/one labourAmt on receive): **no lot/design/size/counter/othWt/ghat%/west/material/diamond/per-line-labour, no voucher chrome/tender/print, and no barcoding of finished pieces** (the engine never writes `TAG_PRINT_DATA`, which the desktop does). The receive page even previews `fine=net×touch/100` while the engine posts `(net+ght)×touch/100` — a visible calc mismatch when Ght>0.

3. **No Manufacturing Order-Receive; design-issue is thin.** `/mfg/order-issue` exists and correctly marks `SL_ORD_DETL.DESIGN_ISU='Y'` (reverse re-opens), but there is **no `/mfg/order-receive` route or page** for the desktop `TR_MFG_ORD_REC` flow (receive finished ornament against the order and tag it). Order-issue also lacks the pending-order LOV/auto-pull, the karigar-order (`APR_DETL 'KARIGAR ORDER'`) path, BOM/components, lot and tender.

4. **Job-work is a relabelled Karigar toy.** `jobwork-issue/receive` are one-line re-exports of `KarigarForm` → `karigar.ts` (`KR_DATA/KR_DETL`, 4 columns), not the rich desktop `TR_MFG_KR_ISU_REC` (wax/casting weights, lot, sales-order link, sett-issue, repair-adjust). The fuller `/mfg/*` engine already exists but the job-work pages are **not** wired to it.

5. **Tag Opening / Split omit the deep jewellery attributes of the 112-col desktop.** Web tag-opening posting + **auto barcode number** are faithful, but the form drops **HUID (`HmId1-4`+weights), Style/Color/BagWt, the whole Karigar-cost side (`KrNetWt/KrTouch/KrFine/KrLbr…`), Kundan/Wax, the diamond sub-grid, Margin→MRP, image, and the open-order/MFG pull into tagging**, and its fine omits the Ghat+Wastage terms (`net×touch/100` vs `(net+ght)×(touch+west)/100`). Tag Split has **no auto child-tag numbering**, no per-child design/counter/HUID/labour and no `LBR_*` labour re-book / diamond sub-grid.

---

## Cross-cutting notes
- **Web strength = posting fidelity for the pure stock/tag moves.** Tag transfer, tag cancel, stock adjust, tag opening (incl. auto tag#), tag split (weight-conservation), and the signed-net `MAIN_STOCK` stock truth (`onHandNet`, incl. fine) are faithful `Match`es with correct `VCH_TYPE`/book/`ITM_SIGN` and reversibility. **Tag Print now exists** with a genuine scannable Code39 barcode + HUID (supersedes the earlier "no web equivalent" note).
- **Web weakness = UI depth + two structural holes.** Structural: melting doesn't touch stock/MFG or reverse; MFG order-receive is absent; job-work isn't wired to the MFG engine. Depth: no HUID / QR / diamond sub-grids / Karigar-cost columns / Style-Color-Wax / margin→MRP / stock-report movement tabs / physical-count persistence / tender & print chrome.
- **Recurring calc gap:** several web stock/tag fines use `net×touch/100` where the desktop uses `(NetWt+GhtWt)×(Touch+West%)/100` (tag-opening, tag-split, mfg-issue/receive UI-preview). Tag-transfer and stock-adjust correctly include `+West%`. The MFG **engine** (`fineWithGhat`) is the only path that folds in Ghat.
- **Verification performed:** read every cited web file end-to-end (`mfg.ts`, `melting.ts`, `stock.ts`, `tagOps.ts`, `tagSplit.ts`, `tagPrint.ts`, all 14 pages) and every cited catalog (`TR_MFG_ISU_REC`, `TR_MLT_PRO`, `TR_TAG_OPBL`, `TR_TAG_SPLIT`, `Mfg_Module`); confirmed the desktop calc formulas from `calc[]` (e.g. `TR_MFG_ISU_REC` `val[29]=(val[16]+val[26])×(val[27]+val[28])/100`; `TR_MLT_PRO` `nAvgTouch=ΣFine/ΣGross×100`, `LossWt=MltWt−(RtnWt+RecWt)`); confirmed all routes wired via `grep` of `routes/txn.ts` (`/mfg/issue|receive|order-issue`, `/melting`, `/stock/{tag-opening,adjust,tag-transfer,tag-cancel,tag-weight-diff,physical-reconcile,physical-list,tag-print,tag-print/label,tag-split}`) and the **absence** of `/mfg/order-receive`. No code was modified.

**Report path:** `/Users/yakshitsavaliya/Desktop/imodule-extracted/project-memory/parity/vdw-mfg-stock-tags.md`
