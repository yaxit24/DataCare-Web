# AUDIT_D — Finance / Cash-Bank + Bullion / Tour / Membership / Schemes

Independent parity audit. Desktop = `unified/src/csharp_nextdm/DataCareNext/*.cs` (decompiled VB→C#).
Web backend = `web/apps/api/src/modules/*`, web frontend = `web/apps/web/app/(app)/txn/*`.
DB = `web-postgres-1` / `datacare`. Method: every claim cites `file:line` on BOTH sides; anything
not confirmable is marked CANNOT-VERIFY.

> **Data caveat (important):** the migrated Postgres is almost entirely EMPTY of transactions —
> `CASH_DATA=0, PAY_DATA=0, CONTRA_DATA=0, CARD_DATA=0, BUL_DATA=0, APR_DATA=0, AD_DATA=0, AD_OS=0,
> OP_DATA=0, EMP_DATA=0, LDR_ADJ_DATA=0` rows. Only `AD_ADJ=26, BILL_OS_DATA=366, POINT_DATA=2,
> POINT_MEMB=1, UPI_DATA=1` carry rows. Therefore **row-level runtime parity cannot be verified**;
> verdicts are based on (a) desktop save-code footprint, (b) web write-code footprint, (c) live
> table SCHEMA (columns). Schema is verified; produced-row equivalence is not.

---

## Verdict table

| # | Area | Desktop ref | Web ref | Verdict |
|---|------|-------------|---------|---------|
| 1 | Receipt/Payment ledger + cash-vs-bank + PAN-over-limit | TR_CASH.cs | finance.ts | **PARTIAL** |
| 2 | Contra two-account transfer | TR_CONTRA.cs | finance.ts `postContra` | **PARTIAL** |
| 3 | Card / UPI receipts footprint | TR_CARD_REC.cs / TR_UPI_REC.cs | *(none)* | **GAP** |
| 4 | Account opening balance / "ACOP" | TR_AC_OPBL.cs | acOpening.ts | **PARTIAL** |
| 5 | Ledger adjustment + bill-to-bill settlement | TR_LEDR_ADJ.cs / TR_BILL_TO.cs | journal.ts | **GAP** |
| 6 | Employee JV (payroll) | TR_EMP_JV.cs | journal.ts | **GAP** |
| 7 | Multi-party batch receipt | TR_CASH.cs (grid) | batchReceipt.ts | **PARTIAL** |
| 8 | Bullion booking/sale fine/rate/adjust-wt | TR_BUL_BOOKING/_SALE.cs | bullion.ts | **GAP** |
| 9 | Tour APR footprint + EMP_CODE | TR_TOUR/_SALE.cs | tour.ts | **PARTIAL** |
| 10 | Membership points | TR_MEMB_ENT.cs | membership.ts | **CANNOT-VERIFY** |
| 11 | Saving scheme enroll/installment/maturity | Module_Schm.cs (+TR_MEMB_ENT) | scheme.ts | **PARTIAL** |
| 12 | DB footprint desktop-vs-web column diff | (schema) | (write code) | **PARTIAL** |
| 13 | Frontend fields per form | (WinForms) | txn/*/page.tsx | **PARTIAL** |

---

## 1 — Receipt / Payment + cash-vs-bank + PAN-over-limit  →  PARTIAL

**Desktop (TR_CASH.cs):** one form drives BOTH receipt and payment, distinguished by `BOOK_NAME`
(`"CASH REC"/"CASH PAY"/"BANK REC"/"BANK PAY"`). It is **multi-party** — a grid loop writes one
`CASH_DATA` row per party (`TR_CASH.cs:3017-3066`): sets `REC_AMT, BANK_CHARGES, KASAR_AMT,
CHQ_NO, CHQ_PRINT_NAME, BANK_NAME, IT_DESC, VCH_TIME, EMP_CODE, HD_VCH_NO, ENTRY_TYPE='C',
INOUT_TYPE, BOOK_NAME, SR_NO, CLR_DATE, MAIN_USER, USER_UPDATE/DELETE`. The ledger (AC_DATA) is
posted by `Ac_Ledr.Cash_Ledr` / `Ac_Ledr.Bank_Ledr` (`TR_CASH.cs:3075-3079`) plus a rojmel/day-book
row via `Ac_Rojmel.Cash_Rojmel`/`Bank_Rojmel` (`TR_CASH.cs:3084-3092`).

**Cash limit / PAN rule (desktop):** `TR_CASH.cs:2913-2922` — *only* when `BOOK_NAME=="CASH REC"`
and `DC_Main.MsCashLimit > 0`, it loops parties, calls `DC_Main.LedrCash(...)` to read the party's
existing cash-ledger balance (`AcCash`), and if `newAmount + AcCash > MsCashLimit` it **hard-blocks
the save** with a MsgBox. It is a **cumulative-per-party cash ceiling**, the limit is **configurable**
(`MsCashLimit`), and **there is no PAN capture at all**.

**Web (finance.ts):** `postReceipt` writes a single-party `CASH_DATA` row (`finance.ts:78-100`):
`REC_AMT, AC_CODE, AC_NAME, REC_AC_CODE, CHQ_NO, VCH_DATE, VCH_TYPE='RCT'` + a 2-line balanced
AC_DATA ledger (Dr cash/bank, Cr party). `postPayment` writes **PAY_DATA** (`finance.ts:128-150`):
`NET_AMT, TOT_AMT, CASH_AMT, CHQ_AMT, CARD_AMT, BANK_AC`.

PAN rule (web): `assertCashLimit` (`finance.ts:24-28`) requires a PAN when `mode==='cash' && amount >
DEFAULT_CASH_LIMIT` (`=200000`, hard-coded, `finance.ts:13`); it does **not** block, is **per-single-
transaction** (not cumulative), and exempts non-cash.

**Divergences:**
- Rule semantics are **fundamentally different**: desktop = cumulative-ledger hard block, no PAN;
  web = single-txn PAN-required, no block, fixed ₹2,00,000.
- **UI bypass defect:** `PaymentForm.tsx:11,48-52` sends `mode` UPPERCASE (`'CASH'`), but
  `assertCashLimit`/`settlementAc` compare `=== 'cash'` (`finance.ts:25,41`). So via the bundled UI a
  cash receipt/payment (a) never triggers the PAN check and (b) `settlementAc('CASH')` returns
  `bankAc ?? 'BANK'` → cash is booked to the **BANK** ledger. (`batchReceipt.ts:113` lower-cases mode;
  `finance.ts` does not.)
- **Payment table mismatch:** desktop cash-payment → `CASH_DATA` (`BOOK_NAME 'CASH PAY'`); web payment
  → `PAY_DATA` (a different, richer schema). The desktop writer of `PAY_DATA` is out of audit scope →
  that table choice is CANNOT-VERIFY against TR_CASH.
- `CASH_DATA` footprint subset: web omits `SR_NO, INOUT_TYPE, ENTRY_TYPE, BOOK_NAME, VCH_TIME,
  KASAR_AMT, BANK_CHARGES, BANK_NAME, CHQ_PRINT_NAME, CLR_DATE, IT_DESC, EMP_CODE, HD_VCH_NO,
  MAIN_USER, USER_UPDATE/DELETE` (all real columns) on the single-receipt path. No `ROJ_MEL_DATA`.

Ledger double-entry direction (Dr cash/bank, Cr party for receipt; reverse for payment) is correct →
hence PARTIAL not GAP.

## 2 — Contra two-account transfer  →  PARTIAL

**Desktop (TR_CONTRA.cs):** for each grid line writes a **mirror pair** of `CONTRA_DATA` rows
(`TR_CONTRA.cs:2759-2840`): row A `CRDR_TYPE=grid, AC_CODE=line, LD_CODE=primary, LDR_TYPE='0'`;
row B `AC_CODE=primary, LD_CODE=line, LDR_TYPE='1'`. Sets `ENTRY_TYPE='J', INOUT_TYPE, BOOK_NAME,
AC_NAME, IT_DESC, VCH_TIME, EMP_CODE, MAIN_USER` and supports **metal contra** ("FINE JV":
`IT_TYPE`, `CR_FINE`/`DR_FINE`, `TR_CONTRA.cs:2786-2790`). Ledger via a posting routine + ROJ_MEL.

**Web (finance.ts `postContra`):** ONE `CONTRA_DATA` row with `SR_NO=1, AC_CODE=toAc, LD_CODE=fromAc,
DR_AMT=amount, CR_AMT=amount` (`finance.ts:160-200`) + a balanced AC_DATA pair (Dr toAc, Cr fromAc).

**Divergence:** the net ledger effect matches, but the `CONTRA_DATA` footprint diverges — single row
(both DR_AMT & CR_AMT populated) vs desktop's `CRDR_TYPE`/`LDR_TYPE` mirror pair; web omits
`CRDR_TYPE, LDR_TYPE, AC_NAME, INOUT_TYPE, ENTRY_TYPE, BOOK_NAME, VCH_TIME, IT_DESC, EMP_CODE,
IT_TYPE, CR_FINE, DR_FINE` (all real cols) and has **no metal/fine contra**.

## 3 — Card / UPI receipts footprint  →  GAP

**Desktop:** TR_CARD_REC writes a full `CARD_DATA` row (`TR_CARD_REC.cs:3291-3340`) with card-
commission math — `CARD_AMT, CARD_COM_PRC, CARD_COM_AMT, CARD_REC_AMT, CASH_PAID, BANK_COM_PRC,
BANK_SCH_PRC, BANK_COMM_1/2, BANK_COM_AMT, BANK_NET_AMT`, plus bill linkage (`BILL_NO, BILL_ADJ_AMT,
BILL_OS_AMT`); ledger via `Ac_Ledr.Card_Adj_Ledr` (`TR_CARD_REC.cs:3349`). TR_UPI_REC writes
`UPI_DATA` (`TR_UPI_REC.cs:1319-1360`): `UPI_AC_CODE, UPI_AC_NAME, UPI_TYPE, UPI_ID, UPI_AMT` per row.

**Web:** there is **no card or UPI module**. "card"/"upi" exist only as a `PayMode` string that
`settlementAc` routes to a bank ledger (`finance.ts:34,41`). Confirmed: no web source writes
`CARD_DATA` or `UPI_DATA` (grep across `web/apps`, only matches are unrelated). `CARD_DATA`(42 cols)
and `UPI_DATA`(19 cols) exist in the DB but are never populated by web.
→ **GAP**: entire CARD_DATA commission footprint and UPI_DATA split footprint are unimplemented.

## 4 — Account opening balance / "ACOP table"  →  PARTIAL

**Desktop (TR_AC_OPBL.cs):** there is **no ACOP table**. Opening writes per-account master rows to
`OP_DATA` (`TR_AC_OPBL.cs:2691-2713`): `OP_AMT, OP_SIGN, FINE_BAL, FINE_SIGN, SL_FINE_BAL,
SL_FINE_SIGN, DATA_TYPE` (separate **gold & silver** opening fine with +/− signs), `CO_BOOK='000',
VCH_NO='00000'`; plus **bill-wise** opening detail to `OP_DETL` (`TR_AC_OPBL.cs:2717-2760`:
`BILL_NO, ITM_GWT, ITM_NWT, ITM_TOUCH, ITM_GL_FINE, ITM_SL_FINE, DM_*`). It then derives the
`AC_DATA` ledger via `Ac_Ledr.AcOp_Ledr(acCode, dataType)` (`TR_AC_OPBL.cs:~2773`); delete stamps
`VCH_TYPE='OPBAL'` (`TR_AC_OPBL.cs:2830`).

**Web (acOpening.ts):** writes **only** a balanced double-entry into `AC_DATA` with
`VCH_TYPE='ACOP'` (`acOpening.ts:16,89`), per-line `DR_AMT/CR_AMT/FINE_WT/IT_TYPE`, `CO_BOOK='ACO'`.

**Divergences:** web seeds the AC_DATA ledger (functional opening) but **does not write `OP_DATA`/
`OP_DETL`** masters that desktop opening reports rely on; has a single `FINE_WT` (no separate
gold/silver fine + sign), no bill-wise opening, `VCH_TYPE 'ACOP'` vs desktop `'OPBAL'`, book `'ACO'`
vs `'000'`. `OP_DATA` exists in DB (0 rows); `OP_DETL` is absent from the web DB entirely.

## 5 — Ledger adjustment + bill-to-bill settlement  →  GAP

**Ledger adjustment (TR_LEDR_ADJ.cs):** writes `LDR_ADJ_DATA` (`TR_LEDR_ADJ.cs:2951-3000`) with
`CR_AMT, DR_AMT, DIFF_AMT, CR_FINE, DR_FINE, DIFF_FINE, IT_TYPE, IT_REMARK, ONLY_REMARK`,
`ENTRY_TYPE='L'`; ledger via `Ac_Ledr.Ledr_Adjust_Ledr` (`TR_LEDR_ADJ.cs:~3008`). It models reconciled
amount **and** fine differences.

**Bill-to-bill (TR_BILL_TO.cs):** receives money against SPECIFIC outstanding bills — writes
`CASH_DATA` receipt rows (`TR_BILL_TO.cs:4767-4820`) AND `BILL_OS_DATA` settlement rows
(`TR_BILL_TO.cs:4813-4860`): `BILL_AMT, OLD_ADJ_AMT, REC_AMT, KASAR_AMT, BILL_GOLD/REC_GOLD/
KASAR_GOLD/BILL_SILVER/…, BILL_NO, BILL_LC, BILL_YRCD, BILL_DBCD, BILL_HD_VCH_NO` + old-gold to
`SL_PR_DETL` (`TR_BILL_TO.cs:4865+`).

**Web (journal.ts):** the doc-comment claims "Phase 6: LEDR_ADJ / EMP_JV / general JV"
(`journal.ts:48`) but `postJournal` writes **only `AC_DATA`** as a free-form balanced JV
(`journal.ts:88-110`). There is **no `LDR_ADJ_DATA` write, no DIFF_AMT/DIFF_FINE, no fine
adjustment**, and **no bill-to-bill settlement** — nothing in web writes `BILL_OS_DATA` as a
settlement (sales.ts/purchase.ts only CREATE outstanding; `billOutstanding` is read-only report).
`BILL_OS_DATA` has 366 desktop-migrated rows the web can neither settle nor reduce.
→ **GAP** for both LDR_ADJ_DATA and bill-to-bill settlement; generic balanced JV is a partial
substitute for the *amount-only* ledger effect at best.

## 6 — Employee JV (payroll)  →  GAP

**Desktop (TR_EMP_JV.cs):** writes `EMP_DATA` (`TR_EMP_JV.cs:2907-2950`) — a **payroll** voucher:
`SALARY_AMT, PAID_AMT, TDS_PRC, TDS_AMT, PF_PRC, PF_AMT, MONTHLY_SALARY, EMP_DAY, DAY_HOURS,
TOT_HOURS, PAID_AC_CODE, CHQ_NO, BANK_NAME`; ledger via `Ac_Ledr.Emp_Jv_Ledr`
(`TR_EMP_JV.cs:~2960`).

**Web:** no `EMP_DATA` writer exists (grep confirms). Folded conceptually into generic `postJournal`
(`journal.ts:48`), which has **none** of the salary/TDS/PF/days/hours fields. `EMP_DATA` exists in DB
(0 rows), never written by web. → **GAP**.

## 7 — Multi-party batch receipt  →  PARTIAL

**Web (batchReceipt.ts):** `postBatchReceipt` is the genuine multi-party analogue of the TR_CASH grid
— one `CASH_DATA` row per party (`batchReceipt.ts:138` writes `cashRows`) with `SR_NO, BOOK_NAME,
REC_AMT, KASAR_AMT, REC_AC_CODE, CHQ_NO`, a per-party `KASAR` write-off, and one balanced AC_DATA
ledger across all lines (Dr cash/bank + Dr KASAR; Cr party for amount+kasar). Mode is lower-cased
(`batchReceipt.ts:113`) so cash routing is correct here (unlike #1).

**vs Desktop TR_CASH grid:** matches multi-row + KASAR + per-party settlement, but still **omits**
`INOUT_TYPE, ENTRY_TYPE, VCH_TIME, BANK_CHARGES, BANK_NAME, CHQ_PRINT_NAME, CLR_DATE, IT_DESC,
EMP_CODE, HD_VCH_NO, MAIN_USER, USER_*` and writes **no `ROJ_MEL_DATA`**, and has **no cumulative
cash-limit block**. → PARTIAL.

## 8 — Bullion booking / sale (fine / rate / adjust-wt)  →  GAP

**Desktop booking (TR_BUL_BOOKING.cs):** writes `BUL_DATA` rows (`TR_BUL_BOOKING.cs:2444-2461`):
`ITM_GWT=ITM_NWT=grid`, `ADJ_WT (grid col14)`, `MCX_RATE (market)`, `ITM_RATE (booking rate)`,
`ITM_AMT`, `PRM_AMT (premium)`, `TAX_PRC`, `TOT_AMT`, `ENTRY_TYPE='S'`. The booking save persists
grid-computed amounts and **posts no AC_DATA ledger** (booking is an order record).

**Desktop sale (TR_BUL_SALE.cs):** draws the booking down — available weight =
`ITM_GWT − ADJ_WT` / `ITM_NWT − ADJ_WT` (`TR_BUL_SALE.cs:4546-4549, 7449-7454`), carries
`MCX_RATE/ITM_RATE/ITM_AMT/PRM_AMT/TOT_AMT` (`TR_BUL_SALE.cs:4550-4554`), writes BUL_DATA + detail +
RsPrDetl (`TR_BUL_SALE.cs:8788-8986`) and posts the financial settlement.

**Web (bullion.ts):** `bullionBooking` ONLY. `amount = fineWt × rate` (`bullion.ts:90`); BUL_DATA
with `ITM_GWT=ITM_NWT=fineWt, ADJ_WT:0 (bullion.ts:123), PRM_AMT:0 (127), TAX_PRC:0, MCX_RATE=ITM_RATE=
rate`; **adds** an AC_DATA double-entry Dr party/Cr `BULLION` (+advance) (`bullion.ts:60-75`).

**Divergences:** (a) **bullion SALE is entirely missing** — no `/bullion/sale` route, no adjust-wt
drawdown, no fine×rate settlement, no premium/tax → GAP; (b) booking hard-codes `PRM_AMT/TAX_PRC/
ADJ_WT=0` and collapses MCX vs booking rate; (c) web booking posts a Dr-party/Cr-BULLION ledger that
desktop booking does **not** create (web makes the party owe immediately). Adjust-wt math — the core
of this item — is absent. → overall GAP.

## 9 — Tour APR footprint + EMP_CODE  →  PARTIAL

**Desktop (TR_TOUR.cs):** writes `APR_DATA` header (`TR_TOUR.cs:5110-5128`) with `AC_CODE=tEmpCode`
(**account code == employee code**), `EMP_CODE=tEmpCode`, `ISU_NO, ISU_LC_CODE, ISU_YRCD, ISU_DBCD,
HD_VCH_NO, VCH_DESC`; and a rich `APR_DETL` (`TR_TOUR.cs:5136-5230`): `OLD_SRNO, ISU_NO, ISU_AC_NAME,
ISU_AC_CODE, MTL_COLOR, TBL_CODE, DESIGN_NO, ITM_SIZE, HM_ID, BAG_WT, ITM_PCS/GWT/OTH_WT/NWT/GHT_WT/
TOUCH/WEST_PRC/FINE, LBR_PRC/TYPE/RATE/AMT, ITM_RATE, ITM_AMT, …`, `ENTRY_TYPE='A'`. No AC_DATA
(pure inventory). TR_TOUR_SALE.cs is the sale/recovery side (APR_IDTL + `RATE_CUT_ISU_REC`
`TR_TOUR_SALE.cs:11495`, `USER_DATA` `:11286`, financial settlement).

**Web (tour.ts):** `tourIssue` writes `APR_DATA + APR_DETL + MAIN_STOCK` with empty AC_DATA
(`tour.ts:155-160`) — table set & "no money on issue" match desktop. `EMP_CODE` correctly truncated
to varchar(3) (`tour.ts:75`); `AC_CODE = salesmanAc ?? empCode` (allows a distinct salesman acct vs
desktop's AC_CODE=EMP_CODE). Fine = `netWt × touch / 100` (`tour.ts: tourLineFine`).

**Divergences:** APR_DETL is heavily simplified — web omits `OLD_SRNO, ISU_NO/AC_NAME/AC_CODE,
MTL_COLOR, TBL_CODE, DESIGN_NO, ITM_SIZE, HM_ID, BAG_WT, ITM_OTH_WT, ITM_GHT_WT, ITM_WEST_PRC,
LBR_*, OTH_AMT, ITM_RATE, ITM_AMT, VCH_SRNO`; and **tour SALE (TR_TOUR_SALE) is entirely missing**
(no `/tour/sale`). Issue side = reasonable PARTIAL; sale side = GAP.

## 10 — Membership "points"  →  CANNOT-VERIFY (premise mismatch)

**Finding:** `TR_MEMB_ENT.cs` is **not** a loyalty-points form. It is a **gold-saving-scheme
membership entry**: writes `AD_DATA` (`TR_MEMB_ENT.cs:4542-4600`: `SCHM_CODE, MEMB_CODE, SCHM_DATE,
ITM_RATE, ITM_GWT, MEMB_AMT, ENT_TYPE 'O'/'E', REC_AC, WITH_UPI, UPI_NAME, BANK_NAME, CHQ_NO`) and a
`UPI_DATA` split (`TR_MEMB_ENT.cs:4612-4640`); its outstanding balance is `AD_OS` with
`SUM(CASE WHEN SIGN='+' THEN ADJ_AMT ELSE -ADJ_AMT END)` (`TR_MEMB_ENT.cs:3683`); ledger via
`Ac_Ledr.Schm_Ledr` (`TR_MEMB_ENT.cs:4655`). It contains **no `POINT_DATA`/`POINT_MEMB`/`TOT_POINT`/
`MEMB_POINT`** logic (grep confirms).

**Web (membership.ts):** a genuine loyalty-points module — `POINT_MEMB` enrol + `POINT_DATA` earn
(`INOUT 'I'`)/redeem (`'O'`) with derived balance (`membership.ts:24,55-80,67`). This corresponds to
some other desktop point/loyalty form **not in the audited set**, not to TR_MEMB_ENT.

→ The specified comparison ("TR_MEMB_ENT points") **cannot be made** — there are no points in
TR_MEMB_ENT. Separately, TR_MEMB_ENT's actual behaviour (scheme membership AD_DATA/AD_OS/UPI split)
overlaps web **scheme.ts** (#11), not membership.ts. `POINT_DATA`=2 rows exist (web-created); desktop
reference for points = none. **CANNOT-VERIFY.**

## 11 — Saving scheme enroll / installment / maturity  →  PARTIAL

**Finding on Module_Schm.cs:** it is a **background sync / company-reset utility**, not the
interactive entry form — `bgWorker_DoWork` (`Module_Schm.cs:408`) bulk-copies `AD_MEMB`
(`:480`, 37 cols incl `MEMB_AMT, ITM_GWT, EMP_CODE, MEMB_BONUS, SCHM_SHORT` + KYC) and `AD_DATA`
(`:563`, incl `ITM_GWT, ITM_RATE, MONTH_CODE, WITH_UPI, UPI_NAME, BANK_NAME`) between databases;
`CompnyRest` (`:865`) and the reset paths just `DELETE AD_ADJ / AD_OS` (`:87,:91,:905,:909`). The
real installment math lives in TR_MEMB_ENT (AD_DATA/AD_OS) and **maturity/redemption uses `AD_ADJ`**
(cols `MEMB_BONUS, MEMB_LESS, ADJ_AMT, GOLD_WT, GOLD_RATE, GOLD_AMT`; `AD_ADJ`=26 rows live).

**Web (scheme.ts):**
- Enroll → `AD_MEMB` with `MEMB_AMT, JOIN_DATE, DATA_TRFR, MAIN_USER` only (`scheme.ts enrollScheme`)
  — omits `ITM_GWT, EMP_CODE, MEMB_BONUS, SCHM_SHORT` and all KYC → **PARTIAL**.
- Installment → `AD_DATA + AD_OS + AC_DATA` (`scheme.ts:154,180`), `AD_OS` with `SIGN='+', OS_TYPE='A',
  ADJ_AMT` (`scheme.ts:196`) — the +/− accrual model matches `AD_OS` balance. But AD_DATA is
  amount-only: omits `ITM_GWT, ITM_RATE` (per-installment **gold weight/rate accrual** — material for
  a gold scheme), `MONTH_CODE, WITH_UPI, UPI_NAME, BANK_NAME` → **PARTIAL**.
- Maturity/redemption → **GAP**: no `/scheme/maturity`, no `AD_ADJ` write, no `AD_OS` `SIGN='-'`
  redemption (`scheme.ts` comment at `:196` even notes "redemption later books 'D'(-)" but it is
  unimplemented).

Overall PARTIAL (enroll + installment partial; maturity absent).

## 12 — DB footprint: desktop-vs-web column diff  →  PARTIAL

Live-schema column counts confirmed (desktop migrated full tables); web writes a strict SUBSET, and
several desktop tables are **never written by web**:

| Table | Cols (DB) | Desktop writes | Web writes | Web never-written cols (examples) |
|-------|-----------|----------------|------------|-----------------------------------|
| CASH_DATA | 35 | TR_CASH (multi-row) | postReceipt(1)/batchReceipt(n) | INOUT_TYPE, ENTRY_TYPE, VCH_TIME, BANK_CHARGES, BANK_NAME, CHQ_PRINT_NAME, CLR_DATE, EMP_CODE, HD_VCH_NO, MAIN_USER |
| PAY_DATA | 45 | *(out-of-scope desktop form; TR_CASH uses CASH_DATA)* | postPayment | IGST/CGST/SGST_TAX, TDS_*, DISC_*, BILL_*, LEDR_CODE, CARD_AC |
| CONTRA_DATA | 33 | TR_CONTRA (mirror pair) | postContra(1 row) | CRDR_TYPE, LDR_TYPE, AC_NAME, IT_TYPE, CR_FINE, DR_FINE, INOUT_TYPE, ENTRY_TYPE, BOOK_NAME |
| CARD_DATA | 42 | TR_CARD_REC | **none** | ALL (whole table unused) |
| UPI_DATA | 19 | TR_UPI_REC / TR_MEMB_ENT | **none** | ALL (whole table unused) |
| EMP_DATA | (exists) | TR_EMP_JV | **none** | ALL (payroll) |
| LDR_ADJ_DATA | (exists) | TR_LEDR_ADJ | **none** | ALL (DIFF_AMT/DIFF_FINE) |
| OP_DATA | (exists) | TR_AC_OPBL | **none** | ALL (OP_SIGN, FINE/SL_FINE) |
| AD_ADJ | 38 | scheme maturity | **none** (read-only report) | ALL (MEMB_BONUS, GOLD_WT/RATE/AMT) |
| BUL_DATA | 40 | TR_BUL_BOOKING/_SALE | booking only | ADJ_WT(≠0), PRM_AMT, TAX_PRC, TO_LC_CODE/TO_CO_BOOK/TO_VCH_NO |
| APR_DETL | ~84 | TR_TOUR/_SALE | tourIssue subset | LBR_*, ITM_RATE/AMT, HM_ID*, DESIGN_NO, TBL_CODE, ISU_AC_* |
| AD_DATA | 34 | TR_MEMB_ENT/Module_Schm | schemeInstallment subset | ITM_GWT, ITM_RATE, MONTH_CODE, WITH_UPI, UPI_NAME, BANK_NAME |
| BILL_OS_DATA | 41 | TR_BILL_TO (settle) | sales/purchase CREATE only | settlement REC_AMT/KASAR via receipt |

Where web does write a table, it stays within real columns (no phantom columns) — but coverage is a
subset and 6+ desktop tables (CARD_DATA, UPI_DATA, EMP_DATA, LDR_ADJ_DATA, OP_DATA, AD_ADJ) are never
populated. → PARTIAL.

## 13 — Frontend fields per form  →  PARTIAL

Implemented web UIs and their fields:
- **receipt / payment** → shared `PaymentForm.tsx`: partyAc, partyName, amount, mode(CASH/BANK/CARD/
  UPI/CHEQUE), bankAc (non-cash), chqNo (cheque), pan. **Defect:** mode is UPPERCASE → see #1
  (PAN check + cash routing bypassed). No grid (single party), no kasar/bank-charges/emp.
- **contra** (`contra/page.tsx`): fromAc, toAc, amount (3 fields). No metal/fine, no description.
- **journal** (`journal/page.tsx`): coBook/coYear/lcCode/date/narration + line grid (acCode, desc,
  debit, credit) with live balance gate. Maps to generic JV (not LDR_ADJ/EMP_JV specifics).
- **ac-opbl** (`ac-opbl/page.tsx`): coBook(ACO)/year/lc/date + lines (acCode, debit, credit, fineWt,
  itType A/G/S). No separate gold+silver, no bill-wise.
- **batch-receipt** (`batch-receipt/page.tsx`): lines(partyAc, partyName, amount, mode, bankAc, chqNo,
  kasar) — closest to TR_CASH grid.
- **bullion** (`bullion/page.tsx`): partyAc, fineWt, rate, advance → amount=fine×rate. No premium/tax/
  adjust-wt; booking only (no sale UI).
- **tour** (`tour/page.tsx`): salesmanAc, lines(itCode, tagNo, pcs, grossWt, netWt, touch→fine). Issue
  only (no sale UI). No EMP_CODE field distinct from salesman.
- **membership** (`membership/page.tsx`): enrol(membCode, membName, mobile, pointCode, cardNo) +
  points(earn/redeem, points, amount) — loyalty, unrelated to TR_MEMB_ENT (#10).
- **scheme** (`scheme/page.tsx`): enrol(schmCode, membCode, membName, monthlyAmt, months) +
  installment(schmCode, membCode, amount, mode, chqNo). No maturity UI, no gold-weight field.

**No UI exists** for: card receipt, UPI receipt, employee/payroll JV, ledger adjustment, bill-to-bill
settlement, bullion sale, tour sale, scheme maturity. Implemented forms expose the core fields of
their (subset) backend → PARTIAL.

---

## GAPS FOUND (actionable)

1. **PAN/cash-limit rule wrong + bypassed (#1).** Web implements PAN-required-over-₹2L (single-txn),
   desktop is a configurable cumulative-per-party cash *hard block* with no PAN. And `PaymentForm.tsx`
   sends UPPERCASE `mode` so `assertCashLimit`/`settlementAc` (`finance.ts:25,41`) never fire for cash
   → cash silently booked to BANK and PAN never demanded. **Fix:** lower-case mode at the route/form
   and reconcile the rule semantics.
2. **Payment table divergence (#1).** Web payment → `PAY_DATA`; desktop cash-payment → `CASH_DATA`
   (`BOOK_NAME 'CASH PAY'`). Reconcile or document.
3. **Card receipts (#3) — GAP.** No `CARD_DATA`, no commission math (CARD_COM/BANK_COM/NET_AMT), no
   card↔bill adjustment.
4. **UPI receipts (#3) — GAP.** No `UPI_DATA` split footprint.
5. **Ledger adjustment (#5) — GAP.** No `LDR_ADJ_DATA`, no amount+fine DIFF reconciliation.
6. **Bill-to-bill settlement (#5) — GAP.** No `BILL_OS_DATA` settlement write; 366 outstanding rows
   cannot be cleared by the web.
7. **Employee/payroll JV (#6) — GAP.** No `EMP_DATA` (salary/TDS/PF/days/hours).
8. **Account-opening masters (#4).** No `OP_DATA`/`OP_DETL`; no gold+silver opening fine with signs;
   no bill-wise opening; `VCH_TYPE 'ACOP'` vs desktop `'OPBAL'`.
9. **Bullion sale (#8) — GAP.** No sale/drawdown (`ITM_GWT−ADJ_WT`), no fine×rate settlement, no
   premium/tax. Booking hard-codes PRM_AMT/TAX_PRC/ADJ_WT=0 and posts a ledger desktop omits.
10. **Tour sale (#9) — GAP.** TR_TOUR_SALE (APR_IDTL + RATE_CUT_ISU_REC + financial recovery)
    unimplemented; tour-issue APR_DETL is a thin subset.
11. **Scheme maturity (#11) — GAP.** No `AD_ADJ` redemption, no `AD_OS` `SIGN='-'`; installment omits
    gold weight/rate (ITM_GWT/ITM_RATE) for a gold scheme.
12. **Loyalty-points reference (#10).** Web `POINT_DATA` module has no desktop counterpart in scope;
    TR_MEMB_ENT is actually a scheme form → re-map or supply the correct desktop reference.
13. **Footprint subset everywhere (#12).** Even implemented finance writes drop many real audit/trace
    columns (INOUT_TYPE, ENTRY_TYPE, VCH_TIME, EMP_CODE, MAIN_USER, USER_*); no `ROJ_MEL_DATA`
    day-book rows from any finance write.
14. **Data caveat.** Transaction tables are empty → no web write was verified against desktop-produced
    rows; verification is code/schema-level only.

---

## AUDIT_D VERDICT: parity=0 partial=8 gap=4 cannot-verify=1

- **PARTIAL (8):** #1 receipt/payment, #2 contra, #4 account-opening, #7 batch-receipt, #9 tour,
  #11 scheme, #12 footprint-diff, #13 frontend.
- **GAP (4):** #3 card/UPI, #5 ledger-adj + bill-to-bill, #6 employee JV, #8 bullion booking/sale.
- **CANNOT-VERIFY (1):** #10 membership points (TR_MEMB_ENT contains no points logic — premise
  mismatch; web POINT_DATA module has no in-scope desktop reference).
- **PARITY (0):** no audited area reaches full footprint+rule parity; closest are the AC_DATA
  double-entry directions (receipt/payment/contra/journal/opening), which are correct in isolation but
  each carry footprint and/or rule divergences that hold them at PARTIAL.

(Row-level runtime parity is CANNOT-VERIFY system-wide due to the empty transaction tables; all
verdicts above are established from desktop save-code, web write-code, and live schema.)
