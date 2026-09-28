# FUNCTIONAL PARITY — FINANCE + DHRN + BULLION + TOUR + INOUT (+VP)

Session `finance_dhrn` · 2026-06-30 · FIELD / BUTTON / FLOW depth audit (not surface coverage).
Desktop = `extracted_code/DataCareNext/DataCareNext/*.cs` (decompiled VB→C#, READ-ONLY).
Web = `web/apps/api/src/modules/*` + `routes/txn.ts` + `web/apps/web/app/(app)/txn/*/page.tsx`.
Refreshes BASELINE `audit-D-finance-bullion.md` + `audit-C-mfg-dhrn.md` (dhrn) to CURRENT code.
Classification: **OK** = full field+flow+column parity · **DEPTH** = form exists, missing
fields/calc/validation/columns · **BREADTH** = flow absent in web.

## Data reality (live DB, tenant 'default', this session)
`AC_DATA=5150, BILL_OS_DATA=366, UPI_DATA=1` carry rows. **All other scope tables = 0**:
`CASH_DATA, PAY_DATA, CONTRA_DATA, CARD_DATA, EMP_DATA, LDR_ADJ_DATA, OP_DATA, BUL_DATA,
DHRN_ISU_DATA, DHRN_ISU_DETL, DHRN_REC_DATA, DHRN_DATA, APR_DATA, APR_DETL, REP_DATA,
INOUT_DATA, INOUT_DETL` = 0. ⇒ Even the NEW write-paths (CARD_DATA, LDR_ADJ_DATA, EMP_DATA,
DHRN_ISU_DETL) have produced **zero runtime rows** → every verdict is **code/schema-level;
runtime row-equivalence is CANNOT-VERIFY** system-wide.

## REFRESH vs baseline — what changed since the prior same-day audit
Baseline marked Card/UPI, ledger-adjust, employee-JV, bill-to-bill as **GAP (no module)**.
Current tree adds real modules; verified this session:
- **CARD_DATA / UPI_DATA** — NOW written by `finance.ts postReceipt` (card/upi branch). PARTIAL (depth).
- **LDR_ADJ_DATA** — NEW `finance/ledgerAdjust.ts` + `/ledger-adjust`. PARTIAL (amount only; fine=0).
- **EMP_DATA** — NEW `finance/employeeJv.ts` + `/employee-jv`. PARTIAL (no %-rate/days/hours).
- **bill-to-bill** — NEW `finance/billToBill.ts` (`/bill-to-bill/open|settle`) updates BILL_OS_DATA. PARTIAL.
- **fine-jv** — NEW `finance/fineJv.ts` + `/fine-jv` (2-leg metal contra). Covers TR_CONTRA "FINE JV".
- **dhrn borrower-ledger debit** — FIXED: `dhrn.ts:~172 loanAc = (input.loanAc||'').trim() || borrowerAc`
  ⇒ borrower's own ledger now Dr on issue / Cr on repay (was hard 'DHRN'/'CASH').
- **dhrn collateral grid** — FIXED: `issueDhrn` now writes `DHRN_ISU_DETL` + `DHRN_DATA` movement.
- **dhrn whole-month interest** — `monthsBetween`/`termInterestBetween`/`dhrnInterest` EXIST (`dhrn.ts:58,66,48`)
  with whole-month round-UP bucketing, **but are UNUSED by any endpoint** — only referenced by
  `test/dhrn.test.ts` + `parity/golden.ts`. Issue uses `accruedInterest(intMonths×30,360)`; receipt/interest
  take a client-typed `interest` field (`txn.ts:218,234`). ⇒ interest is still operator-entered at runtime.
- **PaymentForm mode-case bypass** — FIXED: `PaymentForm.tsx` mode values are lowercase (`cash/bank/…`),
  `postReceipt/postPayment` lower-case again (`finance.ts:78,175`) ⇒ PAN-check + cash routing now fire.
- Still ABSENT (BREADTH): OP_DATA/OP_DETL, bullion SALE, tour SALE, tour ORDER, TR_REP_REC, VP, VP_ADJ,
  FAN_DATA (TR_FN_INOUT's real table). And NO frontend page for `/ledger-adjust` or `/employee-jv`.

---

## VERDICT TABLE

| # | Desktop form | Web | Verdict |
|---|---|---|---|
|1|TR_CASH (receipt/payment + cash-limit/PAN)|finance.ts / PaymentForm|DEPTH|
|2|TR_CARD_REC (card commission)|finance.ts CARD_DATA branch|DEPTH|
|3|TR_UPI_REC (UPI split)|finance.ts UPI_DATA branch|DEPTH|
|4|TR_CONTRA (mirror pair + metal)|finance.ts postContra + fineJv.ts|DEPTH|
|5|TR_AC_OPBL (OP_DATA/OP_DETL)|acOpening.ts|DEPTH|
|6|TR_LEDR_ADJ (amount+fine diff)|ledgerAdjust.ts|DEPTH|
|7|TR_EMP_JV (payroll TDS/PF/days/hrs)|employeeJv.ts|DEPTH|
|8|TR_BILL_TO (settle + receipt + old-gold)|billToBill.ts|DEPTH|
|—|TR_CASH grid (multi-party)|batchReceipt.ts|DEPTH (closest)|
|9|TR_DHRN_ISU (principal/collateral/interest/legs)|dhrn.ts issueDhrn|DEPTH|
|10|TR_DHRN_REC (repay + DHRN_DATA + ISU_REC + stock)|dhrn.ts receiveDhrn|DEPTH|
|11|TR_DHRN_INTREC (monthly/day + compounding)|dhrn.ts receiveDhrnInterest|DEPTH|
|12|TR_REP_REC (REP_DATA/REP_DETL)|*(none)*|**BREADTH**|
|13|TR_BUL_BOOKING (premium/tax/adj-wt)|bullion.ts|DEPTH|
|14|TR_BUL_SALE (adj-wt drawdown settlement)|*(none)*|**BREADTH**|
|15|TR_TOUR (APR issue)|tour.ts tourIssue|DEPTH|
|16|TR_TOUR_ORD (SL_ORD_DATA order)|*(none; sales-order out of scope)*|**BREADTH**|
|17|TR_TOUR_SALE (APR_IDTL + RATE_CUT_ISU_REC)|*(none)*|**BREADTH**|
|18|TR_FN_INOUT (FAN_DATA + GST + ledger)|*(none; web writes INOUT_DATA)*|**BREADTH**|
|19|TR_INOUT (INOUT_DATA/DETL/IDTL + transfer)|inout/fineInout.ts|DEPTH|
|20|TR_VP (RATE_CUT_DATA + wholesale stock)|*(none)*|**BREADTH**|
|21|TR_VP_ADJ (VP settlement)|*(none)*|**BREADTH**|

---

## FINANCE

### 1 — TR_CASH receipt/payment + cash-limit/PAN → DEPTH
**Desktop:** one form, BOOK_NAME drives REC/PAY × CASH/BANK; multi-party grid writes one CASH_DATA
row/party (`TR_CASH.cs:3017-3066`: REC_AMT, BANK_CHARGES, KASAR_AMT, CHQ_NO, CHQ_PRINT_NAME, BANK_NAME,
IT_DESC, VCH_TIME, EMP_CODE, HD_VCH_NO, ENTRY_TYPE 'C', INOUT_TYPE, BOOK_NAME, SR_NO, CLR_DATE,
MAIN_USER, USER_*), AC_DATA via `Ac_Ledr.Cash_Ledr/Bank_Ledr` (`:3075-3079`) + `Ac_Rojmel.Cash/Bank_Rojmel`
day-book (`:3084-3092`). **Cash-limit = cumulative-per-party HARD BLOCK** (VERIFIED `TR_CASH.cs:2913-2922`):
when `FormMainBook=="CASH REC" && MsCashLimit>0`, loops parties, `DC_Main.LedrCash()` reads prior balance
`AcCash`, and `MSG[i,5]+AcCash > MsCashLimit` ⇒ MsgBox + `goto end` (no save). **No PAN anywhere.** Also
**EMP_CODE mandatory** when `MsEmpCodeMendetry='Y'` (`:2908`).
**Web:** `postReceipt`→CASH_DATA single row (REC_AMT, AC_CODE, AC_NAME, REC_AC_CODE, CHQ_NO, VCH_DATE,
VCH_TYPE CREC/BREC; `finance.ts:88-101`); `postPayment`→**PAY_DATA** (NET/TOT/CASH/CHQ/CARD_AMT, BANK_AC;
`finance.ts:188-205`). Cash rule = `assertCashLimit` (`finance.ts:24-28`) PAN-required-over-`DEFAULT_CASH_LIMIT
=200000` (`finance.ts:13`), **does not block, per-single-txn, no cumulative ledger read**. `cashLimit` now a
param. PaymentForm fields: partyAc, partyName, amount, mode(cash/bank/card/upi/cheque lowercase — FIXED),
bankAc(non-cash), chqNo(cheque), pan. No grid/kasar/bank-charges/EMP_CODE/mandatory-emp.
**DEPTH:** rule semantics inverted (cumulative-block-no-PAN vs single-PAN-no-block), CASH_DATA omits ~12
audit cols, no ROJ_MEL_DATA, payment→PAY_DATA (desktop cash-pay→CASH_DATA), no EMP_CODE gate.

### 2 — TR_CARD_REC card commission → DEPTH (was GAP)
**Desktop** writes CARD_DATA (`TR_CARD_REC.cs:3291-3340`) with full two-tier commission: CARD_AMT,
CARD_COM_PRC, **CARD_COM_AMT**(`:3314`), CARD_REC_AMT, **CASH_PAID**(`:3316`), **BANK_COM_PRC**(`:3319`),
BANK_SCH_PRC, BANK_COMM_1/2, **BANK_COM_AMT**(`:3323`), **BANK_NET_AMT**(`:3324`), + bill linkage
**BILL_NO/BILL_ADJ_AMT(`:3310`)/BILL_OS_AMT**; ledger via `Ac_Ledr.Card_Adj_Ledr` (`:3349`).
**Web** (`finance.ts:108-135`, card branch) writes CARD_DATA: CARD_AMT, CARD_COM_PRC, CARD_COM_AMT,
CARD_REC_AMT, BANK_ACCD, BANK_NAME, BANK_NET_AMT(=card net), IT_DESC, HD_VCH_NO, INOUT_TYPE 'I',
ENTRY_TYPE 'C', BOOK_NAME 'BANK REC'. Ledger = generic Dr bank/Cr party (no Card_Adj_Ledr).
**DEPTH:** has card-commission math; **omits the entire BANK-side commission tier** (BANK_COM_PRC/AMT,
BANK_SCH_PRC, BANK_COMM_1/2), CASH_PAID, and card↔bill adjustment (BILL_NO/BILL_ADJ_AMT/BILL_OS_AMT).
No UI exposes `cardCommissionPct`/`bankName` (PaymentForm never sends them).

### 3 — TR_UPI_REC UPI split → DEPTH (was GAP)
**Desktop** writes UPI_DATA per row (`TR_UPI_REC.cs:1319-1360`): UPI_AC_CODE, UPI_AC_NAME, UPI_TYPE,
UPI_ID, UPI_AMT. **Web** (`finance.ts:140-160`, upi branch) writes UPI_DATA: SR_NO, UPI_AC_CODE,
UPI_AC_NAME, UPI_AMT, UPI_ID, UPI_TYPE 'R', HD_VCH_NO. Close on the row footprint. **DEPTH:** single-row
(no multi-split grid), `UPI_TYPE='R'` hard-coded, no UI field for `upiId` (PaymentForm omits it).
(Live UPI_DATA=1 — the only populated detail table; origin not re-verified this session.)

### 4 — TR_CONTRA two-account transfer (+metal FINE JV) → DEPTH
**Desktop** writes a **mirror pair** of CONTRA_DATA rows/line (`TR_CONTRA.cs:2759-2840`): row A
`CRDR_TYPE, AC_CODE=line, LD_CODE=primary, LDR_TYPE '0'`; row B `AC_CODE=primary, LD_CODE=line, LDR_TYPE '1'`;
+ ENTRY_TYPE 'J', INOUT_TYPE, BOOK_NAME, AC_NAME, IT_DESC, VCH_TIME, EMP_CODE; **metal contra** ("FINE JV":
IT_TYPE, CR_FINE/DR_FINE, `:2786-2790`).
**Web** `postContra` (`finance.ts:225-245`): ONE CONTRA_DATA row (SR_NO 1, AC_CODE=toAc, LD_CODE=fromAc,
DR_AMT=CR_AMT=amount) + balanced AC_DATA (Dr toAc/Cr fromAc). Metal contra now in **separate** `fineJv.ts`
(`postFineJv`, `/fine-jv`): two DR=CR=0 AC_DATA legs, toAc SIGN '+' / fromAc SIGN '−', IT_TYPE G/S, FINE_WT
(`fineJv.ts:78-90`). UI: contra=fromAc/toAc/amount (3 fields); fine-jv=fromAc/toAc/metal/fineWt.
**DEPTH:** net amount-ledger matches; CONTRA_DATA single row (no CRDR_TYPE/LDR_TYPE mirror pair), omits
AC_NAME/INOUT_TYPE/ENTRY_TYPE/BOOK_NAME/VCH_TIME/EMP_CODE; metal moved to fine-jv (AC_DATA legs only, not
CONTRA_DATA IT_TYPE/CR_FINE/DR_FINE).

### 5 — TR_AC_OPBL account opening → DEPTH
**Desktop:** NO ACOP table — writes per-account OP_DATA (`TR_AC_OPBL.cs:2691-2713`): OP_AMT, OP_SIGN,
FINE_BAL, FINE_SIGN, SL_FINE_BAL, SL_FINE_SIGN, DATA_TYPE (separate gold & silver opening fine w/ ± signs),
CO_BOOK '000', VCH_NO '00000'; + bill-wise OP_DETL (`:2717-2760`: BILL_NO, ITM_GWT/NWT/TOUCH/GL_FINE/SL_FINE,
DM_*); ledger via `Ac_Ledr.AcOp_Ledr`; delete stamps VCH_TYPE 'OPBAL' (`:2830`).
**Web** `acOpening.ts` writes **only** balanced AC_DATA, VCH_TYPE 'ACOP', book 'ACO'; per-line money 'A' leg
+ NOW separate metal legs via `goldFine`/`silverFine` (IT_TYPE G/S, SIGN ±, FINE_WT, DR=CR=0;
`acOpening.ts:40-60,150-168`). UI (`ac-opbl/page.tsx`): lines(acCode, debit, credit, fineWt, itType A/G/S),
Dr=Cr balance gate — but sends single `fineWt`+`itType`, NOT goldFine/silverFine, so the separate-leg path
is unused by the UI.
**DEPTH:** improved gold/silver metal legs in backend, but **still no OP_DATA / OP_DETL** (the masters
opening reports read), no OP_SIGN/FINE_SIGN/SL_FINE_SIGN, no bill-wise opening, VCH_TYPE 'ACOP' vs 'OPBAL',
book 'ACO' vs '000'. OP_DATA=0 in DB; OP_DETL absent from web schema.

### 6 — TR_LEDR_ADJ ledger adjustment → DEPTH (was GAP)
**Desktop** (VERIFIED `TR_LEDR_ADJ.cs:2951-3000`): multi-line grid → LDR_ADJ_DATA per line with
**CR_AMT, DR_AMT, DIFF_AMT** (col3) AND **CR_FINE(col5), DR_FINE(col6), DIFF_FINE(col7)**, IT_TYPE,
IT_REMARK, ONLY_REMARK (remark-only lines via `chkRemark`), VCH_TIME, HD_VCH_NO, EMP_CODE, ENTRY_TYPE 'L';
then `Ac_Ledr.Ledr_Adjust_Ledr` + **`Ac_Rojmel.Cash_Rojmel`** (ROJ_MEL day-book) (`:3005-3010`).
**Web** `postLedgerAdjust` (`ledgerAdjust.ts:60-115`): single acCode + adjAc (default 'KASAR') + amount +
direction → ONE LDR_ADJ_DATA row: DIFF_AMT=amount, INOUT_TYPE I/O, ENTRY_TYPE 'A', IT_TYPE 'A',
**CR_FINE:0, DR_FINE:0, DIFF_FINE:0 (hard-zero)**, IT_REMARK; + balanced Dr/Cr AC_DATA.
**DEPTH:** amount reconciliation now persisted, but **no metal/fine difference** (the core DIFF_FINE
reconciliation is hard-zeroed), single-line not grid, no remark-only lines, ENTRY_TYPE 'A' vs 'L', no
ROJ_MEL_DATA. **No frontend page** (`/ledger-adjust` is headless).

### 7 — TR_EMP_JV payroll → DEPTH (was GAP)
**Desktop** writes EMP_DATA (VERIFIED `TR_EMP_JV.cs:2930-2937`): **TDS_PRC, PF_PRC** (percentage-driven),
MONTHLY_SALARY, **EMP_DAY** (days worked), **DAY_HOURS, TOT_HOURS** (attendance) + SALARY_AMT/PAID_AMT/
TDS_AMT/PF_AMT/PAID_AC_CODE/CHQ_NO/BANK_NAME; ledger via `Ac_Ledr.Emp_Jv_Ledr`.
**Web** `postEmployeeJv` (`employeeJv.ts:95-130`): EMP_DATA with MONTHLY_SALARY, SALARY_AMT, PAID_AMT(net),
TDS_AMT, PF_AMT, PAID_AC_CODE, CHQ_NO, EMP_CODE; ledger Dr emp salary / Cr net cash / Cr TDS / Cr PF
(balanced, net=salary−tds−pf).
**DEPTH:** salary/TDS/PF **amounts** + net-pay ledger present, but **omits TDS_PRC, PF_PRC** (%-rate
inputs), **EMP_DAY, DAY_HOURS, TOT_HOURS** (attendance) and BANK_NAME. **No frontend page** (`/employee-jv`
headless).

### 8 — TR_BILL_TO bill-to-bill → DEPTH (was GAP)
**Desktop** receives money against SPECIFIC bills: writes CASH_DATA receipt rows (`TR_BILL_TO.cs:4767-4820`)
AND BILL_OS_DATA settlement (`:4813-4860`: BILL_AMT, OLD_ADJ_AMT, REC_AMT, KASAR_AMT, BILL_GOLD/REC_GOLD/
KASAR_GOLD/BILL_SILVER…, BILL_NO/LC/YRCD/DBCD/HD_VCH_NO) + old-gold to SL_PR_DETL (`:4865+`); ledger via
`Ac_Ledr.Bill_to_Bill_Ledr`.
**Web** `billToBill.ts`: `listOpenBills` (open = BILL_AMT−REC_AMT−KASAR_AMT) + `settleBills` increments
BILL_OS_DATA REC_AMT/KASAR_AMT in place with **overpay guard** (`:160-205`). UI (`bill-to-bill/page.tsx`):
party→list bills→per-bill Receive+Kasar→Settle, live new-open + overpay block.
**DEPTH (real, against 366 live BILL_OS_DATA rows):** outstanding can now be reduced — but module is
**explicitly scoped to the BILL_OS_DATA update only** (`billToBill.ts:30-40` SCOPE NOTE): **no AC_DATA
receipt leg, no CASH_DATA row, no OLD_VCH_NO/NEW_VCH_NO linkage, no metal columns** (BILL_GOLD/REC_GOLD/
KASAR_GOLD), no SL_PR_DETL old-gold. So a settlement clears the bill but books no money receipt.

### (batch) TR_CASH grid → batchReceipt.ts → DEPTH (closest analogue)
`postBatchReceipt` (`batchReceipt.ts:110-160`): one CASH_DATA row/party (SR_NO, BOOK_NAME, REC_AMT,
KASAR_AMT, REC_AC_CODE, CHQ_NO) + per-party KASAR write-off + one balanced AC_DATA (Dr cash/bank + Dr KASAR;
Cr party amount+kasar); mode lower-cased (`:113`). UI `batch-receipt/page.tsx`: grid(partyAc, partyName,
amount, mode, bankAc, chqNo, kasar). **DEPTH:** still omits INOUT_TYPE/ENTRY_TYPE/VCH_TIME/BANK_CHARGES/
BANK_NAME/CHQ_PRINT_NAME/CLR_DATE/EMP_CODE/HD_VCH_NO/MAIN_USER, no ROJ_MEL_DATA, no cumulative cash-limit.

---

## DHRN (pledge loans)

### 9 — TR_DHRN_ISU issue → DEPTH (borrower-ledger + collateral FIXED)
**Desktop:** principal/collateral/interest → DHRN_ISU_DATA + DHRN_ISU_DETL + TEMP_BOOK_DATA + AC_DATA +
ROJ_MEL_DATA + DHRN_DATA + MAIN_STOCK (metal custody, `Ac_Stock.Dhrn_Isu_Stk`) + IMAGE_DATA/AC_IMAGE +
REMARK_DATA (`TR_DHRN_ISU.cs:5155-5363`); interest round by type (cash `Round(,0)` `:6118`, metal
`Round(,3)` `:6109`); ledger `Ac_Ledr.DhrnIsu_Ledr` legs 01-16 (borrower Dr, cash Cr, interest-income,
charges, metal weight G/S, MsOpDhiran opening) (`Ac_Ledr.cs:1064-1162`).
**Web** `issueDhrn` (`dhrn.ts:160-235`): **loanAc defaults to borrowerAc** (`:172`) ⇒ borrower's ledger now
carries the loan (FIX confirmed). Writes DHRN_ISU_DATA (header: LOAN_TYPE, DHRN_AMT, INT_PRC, INT_MONTH,
MONTH_INT_AMT, INT_AMT, OTH_AMT, PACKET_NO, GOLD_AMT/WT/NWT/DESC) + **DHRN_ISU_DETL** collateral grid +
**DHRN_DATA** movement + AC_DATA (Dr borrower / Cr cash). UI `dhrn-issue/page.tsx`: borrowerAc, loanType
A/G/S, principal, intPrc, intMonths, packetNo, otherCharges, toDate + collateral grid(item, desc, pcs,
gross, net, touch→fine, rate→amount), live interest preview.
**DEPTH:** big improvement (borrower ledger + collateral + movement). Still **missing ROJ_MEL_DATA,
MAIN_STOCK custody (G/S loans), TEMP_BOOK_DATA, IMAGE_DATA/AC_IMAGE, REMARK_DATA**; ledger is 2-leg only
(no interest/charge/metal legs); `round2` everywhere (not 0dp-cash / 3dp-metal); INT_AMT uses
`accruedInterest(intMonths×30,360)` with hard `DEFAULT_YEAR_DAYS=360` (`dhrn.ts:22`), no MsIntYearDays/
MsDhrnIntType config.

### 10 — TR_DHRN_REC repayment → DEPTH (still skips DHRN_DATA + ISU_REC + stock)
**Desktop** (`TR_DHRN_REC.cs:6122-6386`): server-computes interest (`:6896-7070`: day-count vs monthly,
whole-month snap, 360-day compounding), writes DHRN_REC_DATA + DHRN_REC_DETL (returned items) + DHRN_DATA
via `Ac_Tax.DhrnRec_Data`, `UPDATE DHRN_ISU_DATA SET ISU_REC='Y'` on full repay, releases MAIN_STOCK;
17-leg ledger `Ac_Ledr.DhrnRec_Ledr` (KASAR SR_NO 3, rate-cut gold 00003/silver 00004, metal SIGN/FINE).
**Web** `receiveDhrn` (`dhrn.ts:250-300`): writes **only DHRN_REC_DATA + AC_DATA** (Dr cash / Cr loan /
Cr INTINC); takes client `interest` (`txn.ts:218`); outstanding guard before save. **Never writes
DHRN_DATA, never DHRN_REC_DETL, never releases MAIN_STOCK, never flips ISU_REC.** UI `dhrn-receipt/page.tsx`:
isuNo, borrowerAc, principalRepaid, free-text interest, Check-Outstanding button.
**DEPTH:** principal reduction + 3-leg ledger work, but movement/close/stock-release/returned-items absent;
interest operator-typed (server engine `monthsBetween` unused); rounding/compounding/config divergent.
(Internally inconsistent: `receiveDhrnInterest` DOES write DHRN_DATA; `receiveDhrn` does not.)

### 11 — TR_DHRN_INTREC interest-only → DEPTH
**Desktop** (`TR_DHRN_INTREC.cs:5343-5562`): monthly (`:5377,5524`) vs day-count (`:5553`), whole-month
snap (`:5387`), annual 360-day compounding (`:5412-5426`), denom MsIntYearDays; KASAR via 00057; round
3dp/0dp by type.
**Web** `receiveDhrnInterest` (`dhrn.ts:310-360`): Dr cash / Cr INTINC + DHRN_DATA (INOUT 'I') + DHRN_REC_DATA
(DHRN_REC_AMT 0); interest is client-typed (`txn.ts:234`); principal untouched. UI `dhrn-interest/page.tsx`:
isuNo, borrowerAc, free-text interest.
**DEPTH:** correct "interest without principal" effect + movement row, but **computes no interest**
(no monthly/day toggle, no bucketing, no compounding, no per-type rounding, no config).
Outstanding (`dhrn.ts outstandingTx:330` + `reports.ts dhrnOutstandingList`) sums `DHRN_REC_DATA.DHRN_REC_AMT`,
not `DHRN_DATA`, and ignores `UNCHAK_DHRN_REC` advance (desktop RP_DHRN_OS).

### 12 — TR_REP_REC repair receipt → BREADTH
**Desktop** writes REP_DATA + REP_DETL (`TR_REP_REC.cs:4233/4267/3145`) + ledger `Ac_Ledr.Rep_CustRec_KrIsu_Ledr`
/ `Rep_KrRec_CustIsu_Ledr` + `Ac_Rojmel.*` + `Ac_Tax.Vch_Remark` (`:4863-4903`) — a repairing/job receipt
(customer↔karigar). **Web:** none (`grep REP_DATA|REP_DETL` over apps/api/src → 0). REP_DATA=0 in DB.
**BREADTH:** entire repair-receipt flow absent.

---

## BULLION

### 13 — TR_BUL_BOOKING → DEPTH
**Desktop** (`TR_BUL_BOOKING.cs:2444-2461`): BUL_DATA rows ITM_GWT=ITM_NWT=grid, **ADJ_WT**(col14),
**MCX_RATE**(market) vs **ITM_RATE**(booking), ITM_AMT, **PRM_AMT**(premium), **TAX_PRC**, TOT_AMT,
ENTRY_TYPE 'S'; booking posts **no AC_DATA** (order record).
**Web** `bullionBooking` (`bullion.ts:110-180`): BUL_DATA ITM_GWT=ITM_NWT=fineWt, **ADJ_WT:0, PRM_AMT:0,
TAX_PRC:0**, MCX_RATE=ITM_RATE=rate, ITM_AMT=TOT_AMT=fineWt×rate; **adds AC_DATA Dr party / Cr BULLION
(+advance)** (`:60-85`). UI `bullion/page.tsx`: partyAc, fineWt, rate, advanceAmt only.
**DEPTH:** hard-codes premium/tax/adjust-wt=0, collapses MCX vs booking rate, and posts a party-owes ledger
the desktop booking does NOT create (web makes party owe immediately).

### 14 — TR_BUL_SALE drawdown settlement → BREADTH
**Desktop** (VERIFIED `TR_BUL_SALE.cs:4581-4588, 7484-7491`): available = **ITM_GWT−ADJ_WT** / **ITM_NWT−ADJ_WT**,
carries MCX_RATE/ITM_RATE/ITM_AMT/**PRM_AMT**/TOT_AMT, writes BUL_DATA + detail + RsPrDetl + financial
settlement (`:8788-8986`). **Web:** no `/bullion/sale`, no drawdown, no fine×rate settlement, no premium/tax
(`grep BUL_SALE|bullion/sale` → comment only). **BREADTH:** the adjust-wt drawdown — the heart of bullion —
is entirely absent.

---

## TOUR / APPROVAL

### 15 — TR_TOUR issue → DEPTH
**Desktop** (`TR_TOUR.cs:5110-5230`): APR_DATA header (AC_CODE=tEmpCode, EMP_CODE, ISU_NO/LC/YRCD/DBCD,
HD_VCH_NO, VCH_DESC) + rich APR_DETL (OLD_SRNO, MTL_COLOR, TBL_CODE, DESIGN_NO, ITM_SIZE, HM_ID, BAG_WT,
ITM_PCS/GWT/OTH_WT/NWT/GHT_WT/TOUCH/WEST_PRC/FINE, LBR_*, ITM_RATE/AMT…), ENTRY_TYPE 'A'; no AC_DATA.
**Web** `tourIssue` (`tour.ts:120-185`): APR_DATA + APR_DETL + MAIN_STOCK (TR_TYPE 'O', sign '−'), empty
AC_DATA. fine = netWt×touch/100 (`tour.ts:55`). EMP_CODE truncated varchar(3) (`:130`) — but route
`/tour/issue` **does not pass empCode** (`txn.ts:470`), only salesmanAc. UI `tour/page.tsx`: salesmanAc,
salesmanName, vchDesc, grid(item, tag, pcs, gross, net, touch→fine). **No EMP_CODE field.**
**DEPTH:** table set + "no money on issue" + stock-out match; APR_DETL heavily simplified (omits LBR_*,
ITM_RATE/AMT, HM_ID, DESIGN_NO, TBL_CODE, MTL_COLOR, BAG_WT, GHT_WT, WEST_PRC, OLD_SRNO, ISU_AC_*); no
APR_IDTL/IMAGE/DM/BAR/TEMP/REMARK; EMP_CODE unreachable via UI/route.

### 16 — TR_TOUR_ORD order → BREADTH
**Desktop** writes **SL_ORD_DATA** (`TR_TOUR_ORD.cs:6758/6789/7258`) + `Ac_Ledr.Order_Ledr` +
`Ac_Rojmel.Order_Rojmel` + `Ac_Stock.Order_Stk` (`:7611-7617`) + DELETE_DATA audit — an approval/tour
order with advance. **Web:** no `/tour/order`. (SL_ORD_DATA IS written by the out-of-scope sales-order
module `createSalesOrder` via `/sales-orders`, a different book/flow.) **BREADTH:** no tour-order voucher.

### 17 — TR_TOUR_SALE sale/recovery → BREADTH
**Desktop** (`TR_TOUR_SALE.cs`): the sale/recovery side — APR_IDTL + `RATE_CUT_ISU_REC` (`:11495`),
`USER_DATA` (`:11286`) + financial settlement. **Web:** no `/tour/sale`. **BREADTH:** tour sale absent
(only issue exists). `deleteTour` reverses APR_IDTL but it is never written on issue.

---

## INOUT

### 18 — TR_FN_INOUT (fine purchase/sale) → BREADTH (table mismatch)
**Desktop** writes **FAN_DATA** header (VERIFIED `TR_FN_INOUT.cs:5033,5055`) + TEMP_BOOK_DATA, and posts
`Ac_Ledr.Fan_Purc_Ledr`/`Fan_Sale_Ledr` + `Ac_Rojmel.Fan_*_Rojmel` + `Ac_Stock.Fan_InWord_Stk`/
`Fan_OutWord_Stk` + **`Ac_Tax.Fan_Purc_GST`/`Fan_Sale_GST`** (`:6943-6953`) — a fine-metal PURCHASE/SALE
with money ledger, day-book and **GST**. **Web** writes **INOUT_DATA** (not FAN_DATA) and posts **no money
ledger, no GST** (`grep FAN_DATA|Fan_ over apps/api/src` → only FAN_AC_MAST master config). **BREADTH:**
the TR_FN_INOUT flow (FAN_DATA + GST + ledger) has no web counterpart — the web "fine in/out" is a
different (pure-metal INOUT_DATA) thing.

### 19 — TR_INOUT (branch stock in/out) → DEPTH
**Desktop** writes INOUT_DATA + INOUT_DETL + **INOUT_IDTL** (tag sub-detail) (`TR_INOUT.cs:5410/5469/5579`),
supports **inter-branch transfer** (STK_TRFR='Y', TO_LC/TO_BOOK/TO_VCH `:5626,7585`), `Ac_Stock.InWord_Stk`/
`OutWord_Stk` + **`Ac_Ledr.Stk_InOut_Ledr`** + `Ac_Rojmel.Stk_InOut_Rojmel` + `Ac_Stock.Dm_Out_Detl` (stones)
+ `Ac_Tax.Vch_Remark` (`:9970-10005, 8003`).
**Web** `fineInout` (`inout/fineInout.ts:100-180`): INOUT_DATA + INOUT_DETL + MAIN_STOCK (signed, FNIN/FNOUT),
**empty AC_DATA** (pure metal); header TOT_GWT/NWT/FINE only. UI `fine-inout/page.tsx`: direction IN/OUT,
partyAc, grid(item, pcs, gross, net, touch→fine).
**DEPTH:** pure-metal in/out + stock movement work; **omits INOUT_IDTL (tags), DM stones, inter-branch
STK_TRFR transfer, Stk_InOut_Ledr money ledger, ROJ_MEL_DATA, REMARK**. Maps to a thin slice of TR_INOUT.

---

## VP (wholesale)

### 20 — TR_VP → BREADTH
**Desktop** writes **RATE_CUT_DATA** header (VERIFIED `TR_VP.cs:5127,5157`) + TEMP_BOOK_DATA + `Ac_Ledr.VP_Ledr`
+ `Ac_Rojmel.VP_Rojmel` + **`Ac_Stock.Wh_Sale_Stk`** (wholesale sale stock) + `Ac_Stock.Dm_Vp_Sale_Sale_Detl`
(stones) (`:5815-5824`) — a wholesale ("Vyapari") sale. **Web:** no `/vp` route/module. (RATE_CUT_DATA is
written by the out-of-scope `rateCut.ts`/`/rate-cut`, a different ledger `Wh_Sales_Ledr`/flow.) **BREADTH:**
the VP wholesale-sale voucher (VP_Ledr + Wh_Sale_Stk) is absent.

### 21 — TR_VP_ADJ → BREADTH
**Desktop** posts `Ac_Ledr.VpAdj_Ledr` + `Ac_Rojmel.VpAdj_Rojmel` and re-posts `VP_Ledr` per grid row
(`TR_VP_ADJ.cs:2709-2772`) — VP settlement/adjustment. **Web:** none. **BREADTH.**

---

## DB FOOTPRINT (web write vs desktop, live columns)
| Table | Live rows | Desktop writer | Web writer | Still-missing cols / note |
|---|--:|---|---|---|
| CASH_DATA | 0 | TR_CASH (n) | postReceipt(1)/batchReceipt(n) | INOUT_TYPE, ENTRY_TYPE, VCH_TIME, BANK_CHARGES, BANK_NAME, CHQ_PRINT_NAME, CLR_DATE, EMP_CODE, HD_VCH_NO, MAIN_USER |
| CARD_DATA | 0 | TR_CARD_REC | postReceipt(card) | **NOW written**; missing BANK_COM_PRC/AMT, BANK_SCH_PRC, BANK_COMM_1/2, CASH_PAID, BILL_NO/BILL_ADJ_AMT/BILL_OS_AMT |
| UPI_DATA | 1 | TR_UPI_REC | postReceipt(upi) | **NOW written**; single-row, UPI_TYPE hard 'R' |
| CONTRA_DATA | 0 | TR_CONTRA (pair) | postContra(1) | CRDR_TYPE, LDR_TYPE, AC_NAME, IT_TYPE, CR_FINE, DR_FINE |
| LDR_ADJ_DATA | 0 | TR_LEDR_ADJ | ledgerAdjust(1) | **NOW written (amount)**; CR_FINE/DR_FINE/DIFF_FINE hard-0, ONLY_REMARK, multi-line |
| EMP_DATA | 0 | TR_EMP_JV | employeeJv(1) | **NOW written**; TDS_PRC, PF_PRC, EMP_DAY, DAY_HOURS, TOT_HOURS, BANK_NAME |
| OP_DATA / OP_DETL | 0 / — | TR_AC_OPBL | **none** | whole tables (OP_SIGN, FINE/SL_FINE ±, bill-wise) — AC_DATA seeded instead |
| BILL_OS_DATA | 366 | TR_BILL_TO (settle) | settleBills (REC/KASAR only) | metal BILL_GOLD/REC_GOLD/KASAR_GOLD, OLD/NEW_VCH_NO; no AC_DATA/CASH receipt |
| BUL_DATA | 0 | TR_BUL_BOOKING/_SALE | booking only | ADJ_WT(≠0), PRM_AMT, TAX_PRC, MCX≠ITM rate; **no SALE** |
| DHRN_ISU_DATA/DETL/DATA | 0 | TR_DHRN_ISU | issueDhrn | **DETL+DATA now written**; no MAIN_STOCK/ROJ_MEL/IMAGE/REMARK |
| DHRN_REC_DATA | 0 | TR_DHRN_REC | receiveDhrn | no DHRN_DATA, no DHRN_REC_DETL, no ISU_REC close, no stock release |
| APR_DATA/DETL | 0 | TR_TOUR/_SALE | tourIssue (subset) | APR_IDTL, LBR_*, ITM_RATE/AMT, HM_ID, DESIGN_NO; **no SALE/ORDER** |
| REP_DATA/DETL | 0 | TR_REP_REC | **none** | whole flow |
| INOUT_DATA/DETL | 0 | TR_INOUT | fineInout (subset) | INOUT_IDTL, DM, STK_TRFR, Stk_InOut_Ledr, ROJ_MEL |
| FAN_DATA | (n/a) | TR_FN_INOUT | **none** | whole flow (+GST) — web writes INOUT_DATA instead |
| RATE_CUT_DATA | — | TR_VP / rate-cut | rateCut (diff flow) | **no VP** (VP_Ledr/Wh_Sale_Stk) |

No phantom columns anywhere web writes (every written col exists). No `ROJ_MEL_DATA` from ANY finance/dhrn
write. Config (MsCashLimit, MsIntYearDays, MsDhrnIntType, MsOpDhiran, BOOK_DETL SR_NO 1/2/3) not honoured.

## Frontend breadth
Pages present (scope): receipt, payment, contra, ac-opbl, bill-to-bill, batch-receipt, fine-jv, bullion,
tour, fine-inout, dhrn-issue, dhrn-receipt, dhrn-interest. **No page** for: ledger-adjust, employee-jv
(both have live backends/routes — headless), card-receipt detail, UPI detail, bullion-sale, tour-sale,
tour-order, dhrn repay returned-items, REP, VP/VP_ADJ. Card commission + UPI-id fields not surfaced in
PaymentForm even though postReceipt accepts them.

## VERDICT: OK=0 · DEPTH=12 · BREADTH=9 (runtime CANNOT-VERIFY: all scope tables ~0 rows)
- **DEPTH (12):** receipt/payment, card, upi, contra, ac-opbl, ledger-adjust, employee-jv, bill-to-bill,
  dhrn-issue, dhrn-receipt, dhrn-interest, bullion-booking, tr_inout (+batch-receipt).
- **BREADTH (9):** TR_REP_REC, TR_BUL_SALE, TR_TOUR_ORD, TR_TOUR_SALE, TR_FN_INOUT(FAN_DATA), TR_VP, TR_VP_ADJ
  (and headless: ledger-adjust UI, employee-jv UI).
- **Fixed since baseline:** CARD/UPI detail, LDR_ADJ_DATA, EMP_DATA, bill-to-bill, fine-jv, dhrn borrower-
  ledger + collateral + movement, mode-case PAN/cash bypass.
- **Still GAP:** OP_DATA/OP_DETL, bullion SALE, tour SALE/ORDER, TR_REP_REC, VP/VP_ADJ, FAN_DATA flow,
  dhrn DHRN_DATA-on-repay + ISU_REC close + MAIN_STOCK, server-computed/whole-month/compounded interest
  (engine exists but unused), per-type interest rounding, LDR_ADJ fine-diff, EMP %-rate/attendance,
  card bank-commission tier, ROJ_MEL_DATA from any finance write.
