# 03 — UNCERTAIN-SEMANTICS Verification (FINANCE / DHRN / SCHEME / MEMBERSHIP / BULLION / TOUR / VP)

**Date:** 2026-07-27 · **Session:** uncertain-semantics · **Mode:** read-only, evidence-based.
**Method:** desktop truth = decompiled C# `unified/src/csharp/DataCareNext/*.cs` (read in full for the
uncertain forms) + VB `DataCareNext_Source/Forms/*.vb`; web truth = `web/apps/api/src/modules/*` +
`routes/txn.ts` + `app/(app)/txn/*`, **read from CURRENT source** (not trusted from prior docs).
Prior doc `parity/vdw-dhrn-scheme-loyalty.md` was used only as a hypothesis and re-verified.

Legend: **MATCH** = web reproduces desktop double-entry + metal legs · **DIVERGE** = present but
differs · **PARTIAL** = core present, sub-flows missing · **MISSING** = no web implementation ·
**UNVERIFIABLE** = needs live DB/UI.

---

## PER-FORM STATUS TABLE

| # | Desktop form | Desktop table(s) / ledger | Web impl | Status | Dr=Cr / metal legs |
|---|---|---|---|---|---|
| 1 | TR_CASH | CASH_DATA/PAY_DATA/PAY_DETL; AC_DATA | finance.ts `postReceipt`/`postReceiptLines`/`postPayment`/`postPaymentLines` | **MATCH** (generic) | Dr cash/Cr party (+kasar) balanced ✓ money-only |
| 2 | TR_CONTRA | CONTRA_DATA; AC_DATA | finance.ts `postContra` | **MATCH** | Dr toAc/Cr fromAc `JV` balanced ✓ |
| 3 | TR_CARD_REC | CARD_DATA; AC_DATA | finance.ts `postReceipt` mode=`card` → CARD_DATA (commission, net→bank) | **MATCH** (generic mode) | Dr bank/Cr party balanced ✓ |
| 4 | TR_UPI_REC | UPI_DATA; AC_DATA | finance.ts `postReceipt` mode=`upi` → UPI_DATA | **MATCH** (generic mode) | Dr bank/Cr party balanced ✓ |
| 5 | TR_LOCT_AMT | LOCT_* ; `Ac_Ledr.Loct_Amt_Ledr` (inter-branch amount transfer) | — none | **MISSING** | n/a |
| 6 | TR_DHRN_ISU | DHRN_ISU_DATA/DETL/DHRN_DATA; AC_DATA | dhrn.ts `issueDhrn` | **MATCH** (core) | Dr loan/Cr cash balanced ✓; MAIN_STOCK pledge & renewal GAP |
| 7 | TR_DHRN_REC | DHRN_REC_DATA/DHRN_DATA; AC_DATA | dhrn.ts `receiveDhrn` | **PARTIAL** | Dr cash/Cr loan(+int-inc) ✓; kasar/rate-cut/unchak/packet-release MISSING |
| 8 | TR_DHRN_INTREC | DHRN_REC_DATA/DHRN_DATA; AC_DATA(`DhrnIntRec_Ledr`) | dhrn.ts `receiveDhrnInterest` | **PARTIAL** | Dr cash/Cr INTINC ✓ (simple); **COMPOUND + rate-cut + kasar MISSING** |
| 9 | TR_MEMB_ENT | AD_DATA/AD_OS; AC_DATA (bk 074/075) | membership/scheme.ts `postMemberEntry` | **PARTIAL** | Dr cash/Cr SCHM_AC ✓; gold-gram conv, multi-member grid, UPI_DATA MISSING |
| 10 | TR_MEMB_ADJ | AD_ADJ/AD_OS; AC_DATA (bk 076) | scheme.ts `schemeMaturity` | **MATCH** (cash) | Dr SCHM_AC/Cr cash ✓; payout=amt+bonus−less ✓; GoldAmt + SBILL-redeem + EXP_DATE MISSING |
| 11 | TR_BUL_SALE | BUL_DATA (draw `ADJ_WT`) + RATE_CUT_ISU/REC; AC_DATA | — none (booking has no draw-down consumer) | **MISSING** | n/a — booking cannot be sold/settled |
| 12 | TR_BUL_BOOKING | BUL_DATA; AC_DATA | bullion.ts `bullionBooking` | **MATCH** (booking only) | Dr party/Cr BULLION-payable (+adv Dr cash/Cr party) balanced ✓; no stock leg (metal at sale) |
| 13 | TR_TOUR_SALE | (sale of on-approval goods) | tour.ts `markApprovalBilled` bridge (Apr-No→Sale) | **PARTIAL** | no dedicated form; billed via normal sale + flag ISU_REC/EMP_SALE |
| 14 | TR_TOUR | APR_DATA/DETL; MAIN_STOCK (no money) | tour.ts `tourIssue`/`tourReturn` | **MATCH** | 0=0 ledger ✓; MAIN_STOCK out(-)/in(+) metal legs ✓ |
| 15 | TR_TOUR_ORD | tour ORDER booking | — none | **MISSING** | n/a |
| 16 | TR_VP | RATE_CUT_DATA/RATE_CUT_ISU/SL_IDTL; `VP_Ledr`+`Wh_Sale_Stk` | — none | **MISSING** | n/a |
| 17 | TR_VP_ADJ | VP_ADJ_DATA (+UPDATE RATE_CUT_DATA.VP_ADJ_AMT); `VpAdj_Ledr` | — none | **MISSING** | n/a |
| 18 | TR_GOLD_BOOK | DG_GOLD_DATA; `Dg_Gold_Booking` | — none | **MISSING** | n/a |
| 19 | TR_FINE_SL_PR | CUT_DATA/CUT_DETL/CUT_STK_DETL/TAX_DATA/MAIN_STOCK; AC_DATA | bullion/fineSalePurchase.ts `createFineSalePurchase` | **MATCH** | Dr party-net/Cr metal+GST balanced ✓; FINE_WT leg +/- ✓; rate-cut drawdown ✓ |
| 20 | TR_FN_INOUT | INOUT_DATA/INOUT_DETL/MAIN_STOCK (no money) | inout/fineInout.ts `fineInout` | **MATCH** | 0=0 ledger ✓; MAIN_STOCK ITM_FINE +/- ✓ |
| 21 | TR_INOUT | INOUT_DATA/INOUT_DETL/**INOUT_IDTL**/MAIN_STOCK | fineInout.ts (fine-only) + counter/tag-transfer pages | **PARTIAL** | tagged-item branch in/out (INOUT_IDTL) not implemented; fine flavour ✓ |
| 22 | TR_OTH_COMM | OTH_COMM(_DATA); AC_DATA | — none | **MISSING** | n/a |

---

## RESOLVED UNCERTAIN SEMANTICS (desktop source read → web comparison)

### (1) DHRN INTEREST ACCRUAL — `TR_DHRN_INTREC.cs` `BILL_TOTAL()`  → **web PARTIAL**
`CurIntTypeCalc = DC_Main.MsDhrnIntType` (`'M'` month-mode else day-count); compound gated by
`chkInt` whose default = `DC_Main.MsDhrnCompound` (company config). Three code paths, all confirmed:
- **Simple day-count:** `nIntAmt = nPandingDhrn × INT_PRC/100 × nIntDays / MsIntYearDays`.
- **Simple month:** `nIntAmt = nMonthIntAmt × cboIntMonth`  *or*  `nPandingDhrn × INT_PRC/100 × (30×months)/MsIntYearDays`.
- **COMPOUND** (`chkInt`, `nIntYear>1`): year-loop `num5 += round(num5×INT_PRC/100/MsIntYearDays×360)` then
  day-count remainder; the sub-year branch uses `nPandingDhrn×(1+INT_PRC/100)^nIntYear − nPandingDhrn` prorated `/(nIntYear×12)×months`.
- **RATE-CUT (gold-loan settle, gated `SSRegSrNo=='VK236NEVK'` / `LOAN INT ENTRY` & loanType≠A):**
  `nRcutAmt = round(nIntAmt × nFineRate)`, `nOsAmt = nRcutAmt − nPayAmt` (→ RCUT_RATE/AMT/PAY/OS).
- Also `KASAR_AMT` (interest write-off) and `UNCHAK_DHRN_REC` (advance). `nMonthlyInt = INT_PRC/12`.
- Writes DHRN_REC_DATA + AC_DATA + ROJ_MEL_DATA + DHRN_DATA + MAIN_STOCK.
**Web `dhrn.ts`:** `accruedInterest` (day-count, `DEFAULT_YEAR_DAYS=360`) + `monthlyTermInterest`
reproduce the two SIMPLE modes with correct Dr cash / Cr INTINC balancing (`receiveDhrnInterest`,
outstanding unchanged, `DHRN_REC_AMT:0`). **MISSING:** compound path, rate-cut-to-fine, kasar,
unchak advance, and the ROJ_MEL/MAIN_STOCK legs. → **DIVERGE on interest math (no compound), MATCH on simple.**

### (2) VP (Value-Payable parcel) LIFECYCLE — `TR_VP.cs` / `TR_VP_ADJ.cs`  → **web MISSING**
VP is **not a dedicated table** — `TR_VP.BtnSave_Click` writes the **RATE_CUT_DATA / RATE_CUT_ISU / SL_IDTL**
tables with VP-specific columns `VP_AMT_TYPE('T'ToPay/'P'Pay)`, `VP_AMT`, `VP_INS_AMT` (insurance),
`VP_CHARG_AMT` (parcel charge), `AC_ANGDIYA` (courier/angadia account), `VP_ADJ_AMT`. Line items
(`RATE_CUT_ISU`) are tagged ornaments ISSUED out of stock (`Ac_Stock.Wh_Sale_Stk` — same as a
wholesale sale) with the 4 rate-type modes (P/1/K/default). Ledger `Ac_Ledr.VP_Ledr`; report
`VpParcelBill.RPT`. **Lifecycle:** ship gold parcel to a party via angadia as value-payable (COD);
metal leaves stock, party billed, `VP_AMT` outstanding. `TR_VP_ADJ` settles it — picks open parcels
(`RATE_CUT_DATA` where `BOOK_DATA.MAIN_BOOK='VP PARCEL' AND VP_AMT − VP_ADJ_AMT > 0`), writes
`VP_ADJ_DATA(REC_AMT,KASAR_AMT,VP_NO…)`, and does `UPDATE RATE_CUT_DATA SET VP_ADJ_AMT = VP_ADJ_AMT +
(REC_AMT+KASAR_AMT)` (reversed on edit/delete) until fully settled (`Ac_Ledr.VpAdj_Ledr`, no metal
leg). **Web:** zero references to VP_AMT/AC_ANGDIYA/VP_ADJ_DATA in `apps/api/src` → both forms **MISSING**.

### (3) GOLD_BOOK customer gold-accumulation — `TR_GOLD_BOOK.cs`  → **web MISSING**
Table `DG_GOLD_DATA` (ENTRY_TYPE `'S'`, DATA_TYPE `'A'`). Grid per customer:
Amount/Rate/Fine/RecAc/Tax. `CommPassTotal`: `Amount = round(Fine × Rate)`; `Fine = Amount / Rate`;
`TaxAmt = round(Amount × Tax%/100)`; `TotAmt = round(Amount + TaxAmt)`. Defaults RecAc `00001`(cash),
TaxCode `10`, Tax% `3.00` (jewellery GST); Mobile mandatory. Customer **pays money and accumulates
FINE GOLD (grams) at a locked rate** — a per-customer gold-savings/digital-gold plan. Ledger
`Ac_Ledr.Dg_Gold_Booking`; report `BullBookBill.RPT`. **Web:** no `DG_GOLD_DATA`/goldBook reference → **MISSING**.

### (4) SCHEME MATURITY / BONUS payout (AD_ADJ) — `TR_MEMB_ADJ`  → **web MATCH (cash), GAP gold+bill**
Desktop `MembAdjAmt = MembTot + Bonus − LessAmt`; `GoldAmt = GoldWt × GoldRate`; may redeem into a
SALES bill (`SBILL_NO`) and updates `AD_MEMB.EXP_DATE`. Web `scheme.ts schemeMaturity` writes
`AD_ADJ(MEMB_AMT,MEMB_BONUS,MEMB_LESS,ADJ_AMT)` + `AD_OS(OS_TYPE 'D',SIGN '-')` with
`payout = amount + bonus − less` and Dr SCHM_AC / Cr cash (`buildTransferLedger`) — **balanced, MATCH**.
**GAP:** gold valuation (`GOLD_WT/RATE/AMT` written 0), SBILL-in-bill redemption, and EXP_DATE update.

### (5) LOYALTY POINTS earn/redeem (POINT_DATA) — `MS_POINT`  → **web MATCH (manual), GAP accrual**
Web `membership.ts` derives balance from `POINT_DATA` (Σ `INOUT 'I'` earn − Σ `'O'` redeem;
`MEMB_POINT` is a flag), `postPoints` writes `POINT_DATA(VCH_TYPE 'PERN'/'PRED')` with an overdraw
guard, **no money ledger** — matches desktop. **GAP (still open):** the `POINT_MAST` rule columns
(`SL_AMT→SL_POINT`, `GRM_POINT`/gm, `FIX_POINT`) drive **no** auto-accrual, and `sales/sales.ts` does
**not** award points — `POINT_DATA`/`AD_ADJ` appear in `sales.ts` **only in the reversal-table array
(lines 1024, 1032)**, i.e. cleanup on delete, with no write path. So points remain a manual screen.

### (6) AVERAGE TOUCH rebuild  → **web UNIMPLEMENTED**
`AVG_TOUCH` exists in the web **only as a stored master/config field** (`generated-formfields.ts:323,369`,
`configs.ts:301`, `master.service.ts:37`). No engine recomputes a running average touch on stock
in/out movements. Desktop maintains item/stock average-touch (and `MS_UPDATE.cs` rebuilds
`BUL_DATA.ADJ_WT` from RATE_CUT_ISU). → **no recompute-on-movement in web (unresolved gap).**

### (7) MELTING / RATE-CUT drawdown  → **web PARTIAL**
- **Melting:** `manufacturing/melting.ts meltProcess` (TR_MLT_PRO) implements input-fine / recovered-fine
  / loss — **IMPLEMENTED** (route `POST /melting`).
- **Rate-cut drawdown:** `fineSalePurchase.ts` fixes open fine on a source `PR_DETL` line — writes a
  `CUT_STK_DETL` link and increments `PR_DETL.FINE_CUT_*` under an open-balance guard, with delete
  restoring it — **IMPLEMENTED** for fine purchase lines.
- **BUT** the **bullion-booking drawdown** is MISSING: desktop `TR_BUL_SALE.cs:8816/9101`
  `UPDATE BUL_DATA SET ADJ_WT = ADJ_WT ± (ITM_GWT+ADJ_WT)` (draw a booking down as it is sold) has no
  web consumer — `bullionBooking` records `ADJ_WT:0` and nothing ever settles it. → **PARTIAL.**

---

## DOUBLE-ENTRY / METAL-LEG VERIFICATION (implemented forms)
- **finance.ts** — every ledger runs `assertBalanced`; receipt Dr cash+kasar / Cr party; payment mirror;
  contra Dr toAc/Cr fromAc. Money-only (no metal). Cash-receipt ceiling matches TR_CASH.cs
  (`assertCashReceiptCeiling`, no-PAN escape). **Balanced ✓.**
- **bullion.ts** — `buildBookingLedger`: Dr party(amount)/Cr BULLION(amount); advance adds Dr cash/Cr
  party. `assertBalanced`. No MAIN_STOCK leg (metal delivered at the — unimplemented — sale). **Balanced ✓.**
- **fineSalePurchase.ts** — sale: Dr party-net / Cr FINESALE(metal) + Cr GST(tax); purchase mirror with
  input-GST; plus a zero-value `FINE_WT` custody leg (SIGN `-`/`+`) + `MAIN_STOCK ITM_FINE`. CGST/SGST vs
  IGST split. **Balanced ✓, metal legs correct ✓.**
- **tour.ts / fineInout.ts** — empty AC_DATA (0=0 validated) + signed `MAIN_STOCK` metal movements
  (out `-` / in `+`, `ITM_FINE` carried). **Correct pure-inventory legs ✓.**
- **scheme.ts** — installment Dr cash/Cr SCHM_AC, maturity mirror, via `buildTransferLedger`. **Balanced ✓.**

---

## SEVERITY-RANKED FINDINGS
- **BLOCKER — TR_VP / TR_VP_ADJ MISSING.** Value-payable angadia parcel issue + settlement (RATE_CUT_DATA
  `VP_AMT`/`AC_ANGDIYA` + VP_ADJ_DATA drawdown) is entirely absent; a whole shipping/COD workflow with
  metal-out-of-stock and party billing cannot be reproduced. (`TR_VP.cs`, `TR_VP_ADJ.cs` ↔ no web).
- **BLOCKER — TR_BUL_SALE MISSING / bullion booking has no drawdown.** `bullion.ts:bullionBooking` books
  the payable but nothing consumes `BUL_DATA.ADJ_WT` (`TR_BUL_SALE.cs:8816`), so booked metal can never be
  sold/settled — the booking side is a dead-end.
- **HIGH — TR_GOLD_BOOK MISSING.** Customer gold-accumulation plan (`DG_GOLD_DATA`, Fine=Amount/Rate +3% GST)
  unavailable (`TR_GOLD_BOOK.cs` ↔ no web).
- **HIGH — DHRN interest COMPOUND + rate-cut + kasar MISSING.** `receiveDhrnInterest`/`receiveDhrn` do only
  simple day/month interest; the compound and gold-loan rate-cut settlement paths (`TR_DHRN_INTREC.cs
  BILL_TOTAL()`) are not implemented — NBFC-style gold loans not reproducible.
- **HIGH — Scheme gold-gram conversion & SBILL redemption; loyalty rule-driven accrual MISSING.** Gold
  savings schemes lose their gram accrual; matured scheme cannot be applied to a purchase bill; sales
  awards no points (`sales.ts` references POINT_DATA/AD_ADJ only in the reversal list).
- **MEDIUM — TR_LOCT_AMT, TR_OTH_COMM, TR_TOUR_ORD MISSING; TR_TOUR_SALE PARTIAL (sale-bridge only);
  TR_INOUT tagged-item branch transfer PARTIAL (fine-only).**
- **LOW — AVERAGE-TOUCH rebuild engine absent** (stored field only, no recompute-on-movement).

## VERIFIED-MATCH (solid parity)
TR_CASH, TR_CONTRA, TR_CARD_REC, TR_UPI_REC (finance module, balanced, mode-detail tables written);
TR_FINE_SL_PR (full CUT_* + TAX + MAIN_STOCK + rate-cut drawdown, balanced); TR_FN_INOUT; TR_TOUR
issue+return (APR_* + MAIN_STOCK); TR_BUL_BOOKING (booking ledger); TR_MEMB_ADJ cash payout;
loyalty manual earn/redeem balance model.

_Read-only. Desktop = decompiled C# (quoted); web = current source (quoted). Items needing a live DB
run to confirm posted rows are noted UNVERIFIABLE; none blocked this static verification._
