# GAP — KARIGAR / MANUFACTURING module (web ⟶ desktop parity)

> **Goal:** make the web Karigar screens behave EXACTLY like the DataCareNext desktop.
> **Method:** every claim below is grounded in a file I read — KB `project-memory/video-research/_kb/KB_karigar.md`, the web pages/modules/routes, and the decompiled desktop `extracted_code/DataCareNext/DataCareNext/*.cs`. No application code was modified.
> **Owns:** 2 screens — **Karigar Metal Issue** (`Gd0TSp2OoXA`) and **Karigar Ornament Received** (`CO9Ro-ZeeE8`).

## Files read (evidence base)
| Layer | File | What it is |
|---|---|---|
| KB (desktop spec) | `project-memory/video-research/_kb/KB_karigar.md` | golden-master field/grid/effect spec (frame-cited) |
| Web page | `web/apps/web/app/(app)/txn/karigar-issue/page.tsx` | 4-line wrapper → `<KarigarForm mode="issue"/>` |
| Web page | `web/apps/web/app/(app)/txn/karigar-receive/page.tsx` | 4-line wrapper → `<KarigarForm mode="receive"/>` |
| Web form | `web/apps/web/components/KarigarForm.tsx` | the ONLY karigar UI — 3-col (issue) / 4-col (receive) grid |
| Web API | `web/apps/api/src/modules/manufacturing/karigar.ts` | `issueKarigar` / `receiveKarigar` / `karigarMetalBalance` / `deleteKarigar` |
| Web API | `web/apps/api/src/modules/manufacturing/mfg.ts` | richer `issueMfg` / `receiveMfg` (MFG_ISU_REC) — **not wired to the karigar pages** |
| Web routes | `web/apps/api/src/routes/txn.ts` L278-303, 587, 604 | `/karigar/*`, `/mfg/*`, `/reports/karigar-*` |
| Web reports | `reports.ts` L150 `karigarBalances`; `reports4.ts` L69 `karigarStatement` | balance/statement aggregations (KR_DETL) |
| Web test | `web/apps/api/test/karigar.test.ts` | pure fine-math only (no posting/report test) |
| Web richer pages | `txn/mfg-issue`, `txn/mfg-receive`, `txn/mfg-order-issue/page.tsx` | separate surface posting to `/mfg/*` |
| Desktop | `Ac_Stock.cs` L15+ | `INSERT INTO MAIN_STOCK(… KR_NWT,KR_TOUCH,KR_WEST,KR_FINE,KR_LBR_AMT,KR_OTH_AMT,KR_COST …)` |
| Desktop | `Ac_Tax.cs` L333+ | `INSERT INTO MFG_ISU_REC(… KDM_WT,ADD_WT,LESS_WT,RTN_CHOL,RTN_KDM,RTN_GHIS,ITM_GHAT,MINO_WT,ITM_LOSS,RTN_MTRL,LBR_… )` |
| Desktop | `MS_UPDATE.cs` L2691 | fine = `ITM_NWT × (ITM_TOUCH + ITM_WEST_PRC) / 100.0` |
| Desktop | `TR_MFG_KR_ISU_REC.cs` L367/3596 (`GhtWt` col 23), L9660 (`LBR_TYPE` col 30), L11193 (`TAX_MAST`), L11688 (`INSERT INTO TAG_PRINT_DATA(…)`) | the Kr Issue/Received form + barcode/tax posting |

---

## SCREEN 1 — KARIGAR METAL ISSUE (`/txn/karigar-issue`)

**Desktop spec (KB §Video 1).** Form `Kr Issue 1`, menu Karigar→Kr Issue. Header: `Vch No`+F1 · `Vch Date`+time+weekday · `Ref No` · `Party` (group-10 lookup, F1 create) + live `: Amt/: Gold/: Silvr`. **16-col grid:** `Sr · TagNo · ItCode · ItName · Counter · Pcs · GrWt · OthWt · NetWt · Touch · West% · Fine · ConIt · Con% · ConWt · TotWt`. Totals panel (`Net/Disc/Tax/Rof/Total/Cheque/Card/Cash/Kasar/Os Amt`) + live red `100.000 : Dr Gold` + `Print/Save/Cancel/Delete/Exit`. **Effects:** `fine = NetWt×Touch/100 = 100`; MAIN_STOCK metal-OUT (`TR_TYPE 'O'`, `ITM_SIGN '−'`, fine 100, +`KR_*` cost cols); karigar `Dr Gold 100.000` (desktop `FINE_DATA`); header `MFG_ISU_REC`+`MFG_DETL`; money = 0; prints an ORIGINAL receipt.

**Web now.**
- Page (`karigar-issue/page.tsx`) renders `<KarigarForm mode="issue"/>`. The whole UI is `KarigarForm.tsx`: header = `Karigar (AC_CODE)` raw `<input>` + `Karigar Name` raw `<input>` + a `Check balance` button; grid = **3 columns** `Item · Net Wt · Touch %` with `+ Add line` / `×`; a `Save` button; result line `Saved — Voucher #N · fine {fineIssued}`.
- Submits `{ karigarAc, karigarName, lines:[{itCode, netWt, touch}] }` to `POST /karigar/issue` (`txn.ts` L278 → `issueKarigar`).
- `issueKarigar` (`karigar.ts`) posts, in one tenant txn: `KR_DATA` header (`PARTY_FINE`, `LBR_AMT/NET_AMT/TOT_AMT = 0`), `KR_DETL` (`INOUT_TYPE='O'`; cols `ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,NET_AMT=0`), `MAIN_STOCK` (`TR_TYPE 'O'`/`ITM_SIGN '-'`; cols `ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE`), and an `AC_DATA` metal leg (`IT_TYPE 'G'`/`SIGN '-'`/`FINE_WT=fineIssued`, `DR_AMT/CR_AMT=0`). `fine = NetWt×Touch/100` (`fineWeight`, matches desktop; `karigar.test.ts` asserts `fineWeight(100,92)=92`).

**GAPS.**
- **Grid: 3 cols vs 16.** Missing `TagNo · ItCode(as lookup) · ItName · Counter · Pcs · GrWt · OthWt · West%(issue) · Fine(shown, computed) · ConIt · Con% · ConWt · TotWt`. Web only has `Item(raw) · Net Wt · Touch`. Even `Pcs`/`GrWt` exist in the API `KarigarLine` but the form never sends them ⇒ stock row is always `ITM_PCS=0, ITM_GWT=0`.
- **Party field is a raw textbox**, not a **group-10 (KARIGAR SUNDRY CR) LookupPicker** with **F1 = create party inline**. (`LookupPicker` exists in the repo and is already used by `mfg-issue/page.tsx`, but not here.)
- **No header fields:** `Vch No`, `Vch Date`+time+weekday, `Ref No`, `Bank`, `Vch Desc`, `Employe`, image-attach. Consequently the operator cannot back-date the voucher — and the route does not even forward `vchDate` (`issueKarigar` accepts `vchDate` but `txn.ts` L280 omits it).
- **No live `: Dr Gold / : Amt / : Silvr` balance** on selecting the party — only a manual `Check balance` button hitting `GET /karigar/:ac/balance`.
- **No totals/payment panel** (`Net/Disc/Tax/Rof/Total/Cheque/Card/Cash/Kasar/Os Amt`). Cannot pay a labour advance / cash on issue.
- **MAIN_STOCK missing columns** vs desktop (`Ac_Stock.cs`): web omits `TAG_NO, VCH_SRNO, TBL_CODE, ITM_RATE, ITM_AMT, LBR_RATE, LBR_AMT, OTH_AMT, ITM_MRP, NET_AMT` and the karigar-cost block `KR_NWT, KR_TOUCH, KR_WEST, KR_FINE, KR_LBR_AMT, KR_OTH_AMT, KR_COST, EMP_CODE`.
- **Header ledger table differs:** desktop persists the voucher in `MFG_ISU_REC`(+`MFG_DETL`) and the metal sub-ledger in `FINE_DATA`; web uses simplified `KR_DATA`/`KR_DETL` + an `AC_DATA` metal leg. `FINE_DATA` is **not written anywhere in the web** (grep: 0 hits) ⇒ the desktop MFG/Karigar Ledger report has no backing table.
- **No metal-conversion leg** (`ConIt/Con%/ConWt`) — used when the issued metal is converted to another purity.
- **No Print (Original receipt), no Delete, no `< >` nav.** `deleteKarigar` exists in `karigar.ts` but is **not wired to any route** (only `/mfg/:vchNo` delete exists).

**Fill plan.**
- *Frontend* — replace `KarigarForm.tsx` (or fork a `KarigarIssueForm`) with a full-fidelity form: LookupPicker(entity=`accounts`, filter group `10`) + F1 create-party modal (reuse the party-master create flow); a real header (auto `Vch No`, editable `Vch Date`/`Ref No`/`Bank`/`Vch Desc`/`Employe`); a grid with `TagNo, Item(lookup→ItName), Counter, Pcs, GrWt, OthWt, NetWt, Touch, West%, Fine(read-only=net×touch/100), ConIt, Con%, ConWt, TotWt`; a totals/payment panel; a live balance chip fed from `/karigar/:ac/balance` on party pick; `Print/Save/Delete` buttons.
- *Backend* — extend `KarigarLine` with `tagNo, counter, othWt, itName, conItCode, conPct, conWt`; extend `stockRows` (`karigar.ts`) to emit the full `MAIN_STOCK` column set incl. `KR_NWT/KR_TOUCH/KR_WEST/KR_FINE/KR_LBR_AMT/KR_OTH_AMT/KR_COST, TAG_NO, ITM_RATE, ITM_AMT, LBR_RATE, LBR_AMT, OTH_AMT, ITM_MRP, NET_AMT, EMP_CODE`. Have `txn.ts` L280 forward `b.vchDate`, `b.empCode`, `b.refNo`, totals. **Preferred (see cross-cutting §):** route the page through `issueMfg` (writes `MFG_ISU_REC` like the desktop) instead of `issueKarigar`, and make the balance read the same ledger. Add `DELETE /karigar/:vchNo → deleteKarigar` and a print endpoint (`KrIsuBillGst.rpt` equivalent).

**Priority: P0** (grid + party lookup + Dr-Gold balance are the core of desktop-equivalent use). **Effort: L.**

---

## SCREEN 2 — KARIGAR ORNAMENT RECEIVED (`/txn/karigar-receive`)

**Desktop spec (KB §Video 2).** Form `Kr Received 1`, menu Karigar→Kr Received. Header adds **`Item Wt`** (running weight) + live `100.000 : Dr Gold`. **THREE grids:** **Grid A (main, 17 cols)** `Sr · ItCode · ItName · Pcs · GrWt · OthWt · NetWt · GhtWt · Touch · West% · Fine · Ltype · LRate · LAmt · TotAmt · TaxPrc · NetAmt`; **Grid B (barcoding, 19 cols)** `Sr · ItCode · TagNo · Counter · Design · Size · HmId · Pcs · GrWt · LsWt · NetWt · Lbr% · LbrRate · LbrAmt · OthAmt · PrCost · Mrp · Image · KrCod` → `TAG_PRINT_DATA`/`BAR_DETL`; **Grid C (stone/diamond, 11 cols)** `Sr · ItCode · ItName · Pcs · KrWt · Weight · Con% · P/W · Rate · ItAmt · NetAmt` → `MFG_IDTL`. Totals add `Tcs Amt`; live `6500.00 : Cr Amt` + `100.000 : Dr Gold`. **Effects:** `fine = NetWt×(Touch+West%)/100 = 59.800` (`MS_UPDATE.cs` L2691, confirmed); MAIN_STOCK metal-IN (`TR_TYPE 'I'`/`ITM_SIGN '+'`, `ITM_PCS 5`, `ITM_NWT/GWT 65`, `ITM_TOUCH 92`, `ITM_FINE 59.800`) + `KR_NWT/KR_TOUCH/KR_WEST/KR_FINE/KR_LBR_AMT/KR_OTH_AMT/KR_COST`; karigar `Cr Gold 59.800` ⇒ balance `40.200 Dr Gold`; **labour money `Cr Amt 6,825` = LAmt 6500 + 5% GST 325** (`Dr LABOUR / Cr karigar`); prints Original/Duplicate/Triplicate.

**Web now.**
- Page renders `<KarigarForm mode="receive"/>` — same form, gaining exactly **one** header field `Labour Amount` and **one** grid column `Wastage %` (4 cols total: `Item · Net Wt · Touch % · Wastage %`).
- Submits `{ karigarAc, karigarName, labourAmt, lines:[{itCode, netWt, touch, westPct}] }` to `POST /karigar/receive` (`txn.ts` L283 → `receiveKarigar`). *(Route omits `karigarName`, `vchDate`, `labourAc`.)*
- `receiveKarigar` (`karigar.ts`) posts: `KR_DATA` (`PARTY_FINE`, `LBR_AMT/NET_AMT/TOT_AMT = labourAmt`), `KR_DETL` (`INOUT_TYPE='I'`), `MAIN_STOCK` (`TR_TYPE 'I'`/`'+'`), and `AC_DATA` legs: **if `labourAmt>0`** → `Dr LABOUR / Cr karigar` (face value) **plus** a metal leg `IT_TYPE 'G'`/`SIGN '+'`/`FINE_WT=fineReceived`. `fine = NetWt×(Touch+West%)/100` (`fineWithWastage`; `karigar.test.ts` asserts `fineWithWastage(100,90,2)=92`). Returns `{ vchNo, fineReceived }`.

**GAPS.**
- **Grid A: 4 cols vs 17.** Missing `ItName · Pcs · GrWt · OthWt · GhtWt · per-line Ltype · LRate · LAmt · TotAmt · TaxPrc · NetAmt`. No pieces, no gross, no ghat/loss weight, **no per-line labour model** (only a single header `Labour Amount`), no labour-type (`Ltype` = N/per-gm/per-pc/%/fixed → `LBR_TYPE` col 30 in the desktop form). `KarigarLine` has no `othWt`/`ghtWt` fields at all.
- **No Grid B (barcoding/tagging).** The web **cannot tag received pieces into barcode stock** — no `TAG_PRINT_DATA`/`BAR_DETL` write (desktop does this at `TR_MFG_KR_ISU_REC.cs` L11688 with `TAG_NO, DESIGN_NO, ITM_SIZE, HM_ID, HM_ID2, ITM_MRP, TAG_COST, LBR_*` …). Pairs with the barcoding gap in the stock/tag module.
- **No Grid C (stone/diamond).** No `MFG_IDTL` write from the karigar path; can't describe the less-weight (`KrWt/Weight/Con%/P/W/Rate/ItAmt`).
- **No GST/TCS.** `receiveKarigar` posts labour at **face value** — passing `labourAmt=6500` books `Cr Amt 6500`, not the desktop `6,825` (6500 + 5% GST 325). No `Tax Amt`/`Tcs Amt` fields, no `TAX_MAST` lookup (desktop uses it at `TR_MFG_KR_ISU_REC.cs` L11193), and no split of GST to a tax account.
- **No totals/payment panel** (`Net/Disc/Tax/Tcs/Rof/Total/Cheque/Card/Cash/Kasar/Os`) ⇒ **cannot pay the karigar now** (Cheque/Card/Cash) nor explicitly leave it as `Os`.
- **MAIN_STOCK missing the `KR_*` making-cost block** (`KR_NWT/KR_TOUCH/KR_WEST/KR_FINE/KR_LBR_AMT/KR_OTH_AMT/KR_COST`, `Ac_Stock.cs`) ⇒ the received piece does **not** carry its making cost into stock (breaks tag-cost / valuation parity).
- **No `Item Wt` header, no live `Dr Gold`/`Cr Amt`, no `Employe/Bank/Vch Desc`, no image**.
- **No Original/Duplicate/Triplicate print**, no Delete, no `< >` nav.
- **Result under-reports effects:** API returns only `fineReceived`; the labour `Cr Amt`, cleared `Dr Gold` and stock-in are posted but never surfaced in the UI result (`res.fineReceived` only).
- **Header table differs** (`KR_DATA/KR_DETL` vs desktop `MFG_ISU_REC`/`MFG_DETL`) — same `FINE_DATA`-absent issue as Screen 1.

**Fill plan.**
- *Frontend* — full receive form: party LookupPicker + live `Dr Gold`; **Grid A** with `Item, ItName, Pcs, GrWt, OthWt, NetWt, GhtWt, Touch, West%, Fine(read-only), Ltype, LRate, LAmt, TotAmt, TaxPrc, NetAmt`; a **Grid C** stone sub-editor; a **Grid B** tagging sub-editor (or a “defer → Only Tag Entry” toggle); a totals/payment panel with `Tax/Tcs/Cheque/Card/Cash/Kasar/Os` and a `Cr Amt` labour-payable readout; Original/Dup/Trip print.
- *Backend* — extend `KarigarLine` with `othWt, ghtWt, lbrType, lbrRate, lbrAmt, tagNo, designNo, size, hmId, mrp, stones[]`. In `receiveKarigar`: compute per-line labour via a `labourAmount(type,…)` helper (reuse `mfg.ts`’s), compute GST from a tax master and post the tax split so `Cr Amt = LAmt + GST` matches desktop; write the `KR_*` cost columns into `MAIN_STOCK`; add optional `MFG_IDTL` (stones) and `TAG_PRINT_DATA`/`BAR_DETL` (tagging) writes; accept cash/cheque/card/os and post the money legs; return `{ vchNo, fineReceived, labourCr, drGoldAfter }`. **Preferred:** converge onto `receiveMfg` (already writes `MFG_ISU_REC` + richer header) — it already models `ghtWt/rtnChol/rtnGhis/itmLoss/lbrType/components`; extend it for GST + `KR_*` cost cols + tagging, and point the page at it.

**Priority: P0** (this is the biggest single mfg gap — no pieces/gross/ghat/per-line labour/GST/tagging/stone). **Effort: L.**

---

## CROSS-CUTTING GAPS (whole module)

### X1 — The wired page uses the *thin* `karigar.ts`, not the *rich* `mfg.ts` (P0, M)
A far more complete pipeline already exists: `POST /mfg/issue`→`issueMfg` and `POST /mfg/receive`→`receiveMfg` (`mfg.ts`) write the desktop-shaped `MFG_DATA`+`MFG_DETL`+`MFG_ISU_REC`(+`MFG_IDTL`)+`MAIN_STOCK`, with a `MfgLine` carrying `pcs, grossWt, othWt, ghtWt, rtnChol, rtnGhis, itmGhat, itmLoss, lbrType, components[]` and a header with `TAX_*, GR_WT, NET_WT, FINE_WT, CASH/CHQ/CARD/KASAR/BILL_OS`. There are even ready-made richer pages `txn/mfg-issue`, `txn/mfg-receive` (LookupPicker + `Pcs/Gross/GhtWt/Loss/Fine/RecWt`). **But the `karigar-issue`/`karigar-receive` pages are hard-wired to the simplified `karigar.ts` (`KR_DATA`/`KR_DETL`).** Worse, the two ledgers are **disconnected**: `karigarMetalBalance`, `karigarBalances`, `karigarStatement` all read **`KR_DETL`**, while `mfg.ts` writes **`MFG_DETL/MFG_ISU_REC`** — so vouchers entered on the richer mfg pages are invisible to the karigar balance/reports. Desktop uses a single `MFG_ISU_REC` metal-flow ledger for both. **Fill:** converge — make karigar issue/receive post through `mfg.ts` (book `KIS`/`KRC`, `IR_TYPE` karigar) and make the balance/reports read `MFG_ISU_REC`; or, if `KR_DETL` is kept, mirror every desktop column into it.

### X2 — Karigar balance/statement reports are INVERTED (P1, S) — real bug
`karigar.ts` posts **issue = `INOUT_TYPE 'O'`**, **receipt = `'I'`** (`INOUT_ISSUE='O'`, `INOUT_RECEIPT='I'`; asserted in `karigar.test.ts`), and `karigarMetalBalance`/`balanceTx` read it correctly (`issued='O' − received='I'`). **But** `reports.ts` L150 `karigarBalances` and `reports4.ts` L69 `karigarStatement` compute `issued = Σ(INOUT_TYPE='I')` and `received = Σ(INOUT_TYPE='O')` — the **opposite** convention. Result: the `issued`/`received` columns are swapped and `balance = issued − received` is the **negative** of the true balance. For the tutorial (issue 100, receive 59.8) the desktop shows `DrGold 40.200`; these reports would show `issued 59.8 / received 100 / balance −40.200`. **Fill:** flip the two `CASE WHEN` branches in both functions to `issued⇢'O'`, `received⇢'I'`; add a report-level regression test.

### X3 — No print / no desktop ledger reports (P2, M)
Desktop prints `Kr Issue` (`KrIsuBillGst.rpt`, ORIGINAL) and receive Original/Duplicate/Triplicate, and has the **Karigar/MFG Ledger** (`MfgLedger.rpt` / `RP_MFG_LEDR.cs`, sourced from `FINE_DATA`). Web has only JSON data endpoints `/reports/karigar-balances` and `/reports/karigar-statement` (no PDF, no per-voucher receipt, no MFG-ledger). `FINE_DATA` is not written at all. **Fill:** add print endpoints + a MFG/Karigar ledger report; decide the metal sub-ledger table (`FINE_DATA` vs `AC_DATA` metal legs) and back the ledger report with it.

### X4 — Missing routes/wiring (P1, S)
- **No `DELETE /karigar/:vchNo`** though `deleteKarigar` is implemented in `karigar.ts` (only `/mfg/:vchNo` delete exists) ⇒ no Delete button possible.
- **KB inaccuracy to note:** KB §6 says a `POST /karigar/design-issue` (book `DIS`) exists; in code the design-issue route is **`POST /mfg/order-issue`** (`txn.ts`), backed by `issueMfg` (book `DIS`, `IR_TYPE 'D'`) and surfaced by `txn/mfg-order-issue/page.tsx`. Menu items `Kr Design Isu · Cust Repar · Kr Repar Isu · Kr Repar Rec · Cust Repar Isu` have **no** web screens.
- `/karigar/issue` and `/karigar/receive` **don’t forward `vchDate`** (nor `empCode/refNo/labourAc`) even though the module functions accept them.

### X5 — Validation gaps (P1, S)
Web validates only `karigarAc` present + ≥1 line (`KarigarValidationError`). Missing vs desktop: item must exist / be a metal item, `Touch` range, `NetWt>0`, party must be group-10, wastage within agreed %, and the receive-side reconciliation that lets a lower-touch return net to a zero balance within wastage (the KB’s “wastage closes the loop”). No duplicate-voucher / re-open-order guard on the karigar path.

---

## MODULE SUMMARY — TOP 5 GAPS BY PRIORITY

1. **[P0] Receive form is a 4-col toy vs the desktop’s 3 rich grids** — no `Pcs/GrWt/OthWt/GhtWt`, no per-line labour (`Ltype/LRate/LAmt`), no GST/TCS, no stone (Grid C) or barcoding (Grid B → `TAG_PRINT_DATA`/`BAR_DETL`), no totals/payment. *(Screen 2; effort L.)*
2. **[P0] Issue form is a 3-col grid vs 16 cols + no party lookup + no live `Dr Gold`** — raw-text `karigarAc` instead of a group-10 LookupPicker with F1 create-party; missing `TagNo/Counter/Pcs/GrWt/OthWt/West%/Fine/ConIt/Con%/ConWt/TotWt`, header and totals. *(Screen 1; effort L.)*
3. **[P0] Wired to thin `karigar.ts` (KR_DETL), not the desktop-shaped `mfg.ts` (MFG_ISU_REC)** — the rich pipeline + pages already exist but are disconnected from the karigar balance/reports; MAIN_STOCK omits the `KR_NWT/KR_TOUCH/KR_WEST/KR_FINE/KR_LBR_AMT/KR_OTH_AMT/KR_COST` making-cost block. *(X1; effort M.)*
4. **[P1] Karigar balance & statement reports are inverted** — `karigarBalances`/`karigarStatement` treat `INOUT_TYPE='I'` as *issued* while posting uses issue=`'O'`; the reported balance is the negative of the true `Dr Gold`. *(X2; effort S — flip two `CASE WHEN`s + test.)*
5. **[P1] Missing wiring: no karigar Delete route, no `vchDate` pass-through, GST not added to labour `Cr Amt`, no print/MFG-ledger, thin validation.** *(X3/X4/X5; effort S–M.)*

**Verified facts underpinning the above:** fine formulas match desktop (`fineWeight`, `fineWithWastage` = `MS_UPDATE.cs` L2691); MAIN_STOCK `KR_*` columns confirmed in `Ac_Stock.cs`; `MFG_ISU_REC` scrap columns (`KDM_WT/ADD_WT/LESS_WT/RTN_KDM/MINO_WT`) confirmed in `Ac_Tax.cs`; desktop grid `GhtWt`(col 23)/`LBR_TYPE`(col 30)/`TAG_PRINT_DATA`/`TAX_MAST` confirmed in `TR_MFG_KR_ISU_REC.cs`; `FINE_DATA` absent from the web (grep 0 hits); `deleteKarigar` present but unrouted; report inversion read directly from `reports.ts`/`reports4.ts`.
