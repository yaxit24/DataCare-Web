# SPEC — DHRN / Pledge-Loan subsystem (ISSUE · REPAYMENT · INTEREST-ONLY · OS report)

Implementation spec for a web `dhrn.ts` module + Fastify routes + forms, derived by deep read of the
decompiled desktop WinForms in `extracted_code/DataCareNext/DataCareNext/` and verified against the live
Postgres schema (`docker exec web-postgres-1 psql -U datacare -d datacare`).

Source of truth (cite when implementing):
- `TR_DHRN_ISU.cs`  — pledge/loan **ISSUE** (form "DHIRAN ISSUE" + "LOAN REC"); `BtnSave_Click@5083`, `BILL_TOTAL@6089`, `cboIntMonth_KeyDown@6398`, `mToDate_KeyDown@6685`, `DhirnImgPrint@5404`, `BtnDelete_Click@5493`, `MSG_CLEAR@3802`.
- `TR_DHRN_REC.cs`  — **REPAYMENT** (form "DHIRAN RECEIVED" + "LOAN ISSUE"); `BtnSave_Click@6049`, interest calc block `@6915-7035`.
- `TR_DHRN_INTREC.cs`— **INTEREST-ONLY** receipt (form "INTREST RECIVED" + "LOAN INT ENTRY" + "OS LETTER"); `BtnSave_Click@4634`.
- `Ac_Tax.cs`  — DHRN_DATA movement builders: `DhrrnIsu_Data@33`, `DhrnRec_Data@39`, `DhrnIntRec_Data@45`, `Loan_Rec_Data@51`, `Loan_Isu_Data@63`, `Loan_IntIsu_Data`.
- `Ac_Ledr.cs` — AC_DATA double-entry builders: `DhrnIsu_Ledr@1064`, `DhrnRec_Ledr@1105`, `DhrnIntRec_Ledr@1150`, `Loan_Rec_Ledr@1397`, `Loan_IntRec_Ledr`, `Loan_Isu_Ledr@1489`.
- `Ac_Rojmel.cs` — ROJ_MEL_DATA day-book builders: `DhrnIsu_RojMel@480`, `DhrnRec_RojMel@492`, `DhrnIntRec_RojMel@512`, `Loan_Rec_RojMel@617`, `Loan_Isu_RojMel@643`, `Loan_IntRec_RojMel`.
- `Ac_Stock.cs` — MAIN_STOCK custody: `Dhrn_Isu_Stk@265`, `Dhrn_Int_Stk@275`, `Dhrn_Rec_Stk@285`, `Loan_Rec_Stk@295`, `Loan_Isu_Stk@315`, `Loan_Int_Stk`.
- `RP_DHRN_OS.cs` — Outstanding + accrued-interest + aging report; main query `@1910`, accrual/aging `@1990-2090`, second variant `@2364`.

---

## 0. CORE MODEL & VOCABULARY (read first)

### 0.1 The "books" (a `CO_BOOK` row in `BOOK_DATA`, keyed by `MAIN_BOOK`)
One desktop form is reused across several MAIN_BOOK values via `FormMainBook`:

| Form | MAIN_BOOK values | INOUT | ENTRY_TYPE | meaning |
|---|---|---|---|---|
| TR_DHRN_ISU | `DHIRAN ISSUE` | O (out) | `D` | pledge loan paid out, ornaments held |
| TR_DHRN_ISU | `LOAN REC` | I (in) | `L` | loan **receivable** booked (we lent earlier) |
| TR_DHRN_REC | `DHIRAN RECEIVED` | I (in) | `D` | repayment of a dhiran |
| TR_DHRN_REC | `LOAN ISSUE` | O (out) | `L` | loan principal disbursed (loan side) |
| TR_DHRN_INTREC | `INTREST RECIVED` | I (in) | `D` | interest-only collection on a dhiran |
| TR_DHRN_INTREC | `LOAN INT ENTRY` | I (in) | `L` | interest-only on a loan |
| TR_DHRN_INTREC | `OS LETTER` | — | — | print outstanding letter only (no posting) |

Web should model `bookKind ∈ {dhiran, loan}` × `op ∈ {issue, repay, interest, osLetter}`. The desktop
**DHIRAN side and LOAN side are mirror images** (issue ⇄ rec swapped): the *issue* form writes the loan-out
for dhiran but the loan-receivable for "LOAN REC"; the *rec* form writes repayment for dhiran but disbursement
for "LOAN ISSUE". For a first web cut implement the **DHIRAN** side fully and stub the LOAN mirror.

### 0.2 `LOAN_TYPE` (single char, from `cboLoanType`, stored `Mid(cboLoanType.Text,1,1)`)
- `A` = **Amount/cash** loan — `DHRN_AMT` is **money**; posts money legs; **no MAIN_STOCK** row.
- `G` = **Gold** metal loan — `DHRN_AMT` is **fine weight (gms)**; posts fine-weight (metal) legs + MAIN_STOCK.
- `S` = **Silver** metal loan — same as G but silver.
- `cboLoanType.SelectedIndex == 0` ⇒ the cash/default type → amounts rounded to **2 dp** (`"0.00"`).
  `SelectedIndex != 0` (G/S/other) ⇒ amounts rounded to **3 dp** (`"0.000"`) (fine weight precision).

### 0.3 Company-global config flags (read from `DC_Main`, set in company/settings master)
- `MsIntYearDays` — **day-count denominator** for interest (e.g. 360 or 365). Drives the formula. **Configurable.**
- `MsDhrnIntType` — `'M'` = interest charged by whole **months** (days = months×30); else **actual day-count** (`toDate − vchDate`).
- `MsDhrnImgPrint` — `'Y'` ⇒ capture & store per-packet photo + party photo on save.
- `MsTradFine` — `'Y'` ⇒ also emit the trade-fine mirror ledger leg for metal loans.
- `MsOpDhiran` / `MsOpLoan` — `'Y'` ⇒ also post **opening** (pre-open-date) dhiran/loan legs (`VCH_DATE < MOp_dt`).
- `MsLockDt` — period lock date; `MsLockDt >= vchDate` blocks save & delete.
- `MCo_OpDate`/`MCo_ClDate`, `MOp_dt` — company open/close + opening date (posting cut-off).
- `SSRegSrNo` — licensee id; `=='AK030NPAK'` appends 3 custom expiry/interest WhatsApp clauses.
- Composite PK on **every** table: `(CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO)` (+ `SR_NO` for detail/stock).
  `tenant_id` present on the web-migrated tables; carry it on all writes.

### 0.4 Idempotent save pattern (MANDATORY for parity)
Every save is **DELETE-then-INSERT per voucher across ALL derived tables**, so re-saving an edited voucher
is correct. On Add, re-check `MAX(VCH_NO)` collision and bump. Posting helpers themselves begin by being
called *after* a `DELETE … WHERE VCH_NO=…` of the target table. Web `dhrn.ts` must wrap a save in one DB
transaction that: deletes the voucher rows from `{source header, source detail, AC_DATA, ROJ_MEL_DATA,
DHRN_DATA, MAIN_STOCK, REMARK_DATA}`, then re-inserts header+detail, then re-derives the 4 posting tables.

### 0.5 Sub-account resolution (`BOOK_DETL.SR_NO`)
Interest-income / charges / kasar accounts are **not hard-coded**; they come from `BOOK_DETL` rows for the
book: `SR_NO=1` (principal/loan control `LD_CODE`), `SR_NO=2` (interest income a/c), `SR_NO=3` (other-charge /
kasar a/c). Metal rate-cut uses fixed AC codes: gold `00003`/`00008`, silver `00004`/`00009`; kasar `00057`
(dhiran int) / `00042` (loan int) / `00098` (loan rcut kasar). Replicate via a `book_detl` lookup, not literals.

---

## 1. ISSUE — `TR_DHRN_ISU.cs` ("DHIRAN ISSUE")

### 1.1 (1) Operator input fields (header)
| UI field | var | stored column | notes |
|---|---|---|---|
| Voucher No | `tVchNo` | `VCH_NO` | auto-seq; collision re-check & bump on Add |
| Header voucher link | `tHdVchNo` | `HD_VCH_NO` | links header→detail; own seq in `TEMP_BOOK_DATA` |
| Voucher Date | `mVchDate` | `VCH_DATE` / `VCH_TIME`(=`date+ " " +mTime`) | must be within open/close; not ≤ lock date |
| Bill No | `tBillNo` | `DHRN_BILL` | printed pledge-ticket no |
| Party (borrower) | `tAcCode`/`tAcName` | `AC_CODE`,`AC_NAME` | mandatory |
| Received/paid-from a/c | `tRecAc` | `LEDR_ACCD` | cash/bank account money paid out from |
| Loan Type | `cboLoanType` | `LOAN_TYPE` (A/G/S) | drives money-vs-fine + dp |
| Packet No | `tPacketNo` | `PACKET_NO` | physical packet/locker id |
| Due Date | `mDueDate` | `DHRN_DUE_DATE` | nullable (only if valid date) |
| Maturity / To Date | `mToDate` | `TO_DATE` | auto-derived from months (see 1.2) |
| Principal | `nDhrnAmt` | `DHRN_AMT` | money (A) or fine-wt (G/S) |
| Dhiran months | `cboIntMonth` | `INT_MONTH` | interest period in months |
| Loan months | `nDhrnMonth` | `DHRN_MONTH` | tenure (separate from int months) |
| Annual int % | `nIntPrc` | `INT_PRC` | `= nMonthlyInt × 12` |
| Monthly int % | `nMonthlyInt` | (not stored; derives INT_PRC) | `= nIntPrc / 12` |
| Per-month int amount | `nMonthIntAmt` | `MONTH_INT_AMT` | optional flat monthly interest |
| Interest days | `nIntDays` | `INT_DAYS` | derived (see 1.2) |
| Interest amount | `nIntAmt` | `INT_AMT` | derived (see 1.2) |
| Interest received now | `nRecAmt` | `INT_REC_AMT` | `= nIntAmt + nOtherCharges` |
| Other charges | `nOtherCharges` | `OTH_AMT` | processing/doc charges |
| Employee | `tEmpCode` | `EMP_CODE` | mandatory iff `MsEmpCodeMendetry='Y'` |
| Narration | `tVchDesc` | `VCH_DESC` | "Text Hear" placeholder → "" |
| Renewal source | `tIsuNo`/`tIsuYrCd`/`tIsuDbCd` | `OLD_ISU_NO`/`OLD_ISU_YRCD`/`OLD_ISU_DBCD` | rollover linkage (blank ⇒ self) |
| (auto) item-adjust flag | — | `OLD_ITEM_ADJ` | `'Y'` if renewing an old issue else `'N'` |
| (auto) lifecycle | `IsuRec` | `ISU_REC` | `'N'` open; set `'Y'` when repaid |
| (auto) gold summary | composed | `GOLD_DESC`(≤255), `GOLD_AMT`(Σ NetAmt), `GOLD_WT`(Σ GrWt), `GOLD_NWT`,`SILVER_NWT` | from grid |

`GOLD_DESC` auto-composed per grid line: `"{IT_DESC}, N {NetWt} / T {Touch} / F {Fine}"` joined by `, `.

### 1.2 (2) EXACT interest formula at ISSUE
Two derivations run together (`BILL_TOTAL@6089`, `mToDate_KeyDown@6685`, `cboIntMonth_KeyDown@6398`):

**a) Interest DAYS (`nIntDays`):**
```
if MsDhrnIntType == 'M':   nIntDays = cboIntMonth × 30
else:                      nIntDays = toDate − vchDate        // actual calendar days
```

**b) Maturity TO_DATE from months (`cboIntMonth_KeyDown`)** — calendar-accurate month stepping, starting at vchDate:
```
toDate = vchDate
repeat cboIntMonth times:
    m = month(toDate)
    toDate += (m in {1,3,5,7,8,10,12} ? 31 : m==2 ? 28 : 30) days
```

**c) Interest AMOUNT (`nIntAmt`):** let `dp = (cboLoanType.SelectedIndex==0 ? 0 : 3)` (display 0.00 vs 0.000):
```
if nMonthIntAmt != 0:   nIntAmt = Round( nMonthIntAmt × cboIntMonth , dp )
else:                   nIntAmt = Round( DHRN_AMT × (INT_PRC/100) × (30 × cboIntMonth) / MsIntYearDays , dp )
```
i.e. **Interest = Principal × annual-rate% × (months×30 days) ÷ MsIntYearDays.**

**d) Money to collect now:** `nRecAmt (INT_REC_AMT) = nIntAmt + nOtherCharges`.
**e) Rate conversions:** `INT_PRC = nMonthlyInt × 12`; `nMonthlyInt = INT_PRC / 12`.

### 1.3 (1) Collateral item grid — `DHRN_ISU_DETL` (one row per pledged packet)
MSFlexGrid `MSG`, 27 columns (`MSG_CLEAR@3802`). Column index → header → DETL column:

| col | header (DHIRAN) | header (LOAN REC) | DETL column | type |
|---|---|---|---|---|
| 0 | Sr | Sr | `SR_NO`,`OLD_SRNO` | int |
| 1 | (hidden) | PacketNo | `PACKET_NO` | text |
| 2 | (hidden) | CustName | `CUST_NAME` | text |
| 3 | ItCode | ItCode | `IT_CODE` | item code (req) |
| 4 | ItName | ItName | `IT_NAME` | text |
| 5 | Pcs | Pcs | `ITM_PCS` | num |
| 6 | GrWt | GrWt | `ITM_GWT` | gross weight |
| 7 | OthWt | (hidden) | `ITM_OTH_WT` | stone/other wt |
| 8 | NetWt | NetWt | `ITM_NWT` | net weight |
| 9 | Touch | Touch | `ITM_TOUCH` | touch % |
| 10 | West% | (hidden) | `ITM_WEST_PRC` | wastage % |
| 11 | Fine | Fine | `ITM_FINE` | fine weight |
| 12 | Rate | Rate | `ITM_RATE` | rate |
| 13 | ItAmt | ItAmt | `ITM_AMT` | item amount |
| 14 | NetAmt | NetAmt | `NET_AMT` | net amount |
| 15 | (hidden) | | `IT_TYPE` | G/S |
| 16 | (hidden) | | `RATE_TYPE` | |
| 17 | (hidden) | | `IT_DESC` (≤100) | description (feeds GOLD_DESC) |
| 23/24/25 | (hidden) | | `DHRN_NO`/`DHRN_YRCD`/`DHRN_DBCD` | source issue (renewal) |
| 26 | (hidden) | | `PACKET_REC` | packet-returned flag |

Column visibility & labels are **re-skinnable** from `RsClDetl` (rows `BOOK_NAME='DHRN_ISU'`,
`COL_NAME`,`COL_NEW_NAME`,`YES_NO`). A line is persisted only if `(ITM_NWT + NET_AMT) != 0 AND IT_CODE != ''`.
DETL also carries header echo cols: `CO_*`,`VCH_NO`,`VCH_DATE`,`HD_VCH_NO`,`AC_CODE`,`VCH_TYPE`,`INOUT_TYPE`,
`ENTRY_TYPE`,`BOOK_NAME`,`VCH_TIME`,`MAIN_USER`.

### 1.4 Per-packet PHOTO capture (`DhirnImgPrint@5404`, only if `MsDhrnImgPrint='Y'`)
- **`IMAGE_DATA`** per grid line: `CO_CODE,LC_CODE,SCHM_CODE(=CO_BOOK),MEMB_CODE='',TAG_NO(=VCH_NO),SR_NO,
  DESIGN(=AC_CODE),VCH_SRNO=0,TAG_IMAGE(=JPEG bytes)`. Source file `{ImgPath}/DhranImage/{co}{lc}{yr}{vch}{ac}{sr}.jpg`.
- **`AC_IMAGE`** (party portrait): `CO_CODE,LC_CODE,AC_CODE,AC_IMAGE(bytes)`. File `{ImgPath}/AcImage/{co}{lc}{ac}.jpg`.
- Web: accept multipart uploads → store as `BYTEA`/object storage with the same keying.

### 1.5 (3) Tables written on ISSUE save (`BtnSave_Click@5083`) — DELETE-then-INSERT, in order
1. **`TEMP_BOOK_DATA`** header-book row: `CO_CODE,LC_CODE,CO_BOOK,VCH_NO(=HD_VCH_NO),BOOK_NAME(=FormName)`.
   Written only when `DHRN_AMT != 0 AND tRecAc != ''`.
2. **`DHRN_ISU_DATA`** (header) — key columns:
   `VCH_DATE,DHRN_BILL,HD_VCH_NO,DHRN_DUE_DATE,AC_CODE,AC_NAME,LEDR_ACCD,TO_DATE,VCH_TYPE,INOUT_TYPE,
   ENTRY_TYPE(D/L),LOAN_TYPE,BOOK_NAME,PACKET_NO,DHRN_AMT,DHRN_REC_AMT(=DhrnAdjAmt),DHRN_MONTH,INT_MONTH,
   INT_DAYS,INT_PRC,INT_AMT,INT_REC_AMT,OTH_AMT,MONTH_INT_AMT,GOLD_DESC,GOLD_AMT,GOLD_WT,GOLD_NWT,SILVER_NWT,
   VCH_DESC,OLD_ISU_NO,OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ITEM_ADJ,ISU_REC,EMP_CODE,MAIN_USER,VCH_TIME,
   DATA_TRFR='N',USER_UPDATE='N',USER_DELETE='N'`.
3. **`DHRN_ISU_DETL`** (collateral lines) — see 1.3.
4. **`AC_DATA`** via `Ac_Ledr.DhrnIsu_Ledr` (LOAN REC ⇒ `Loan_Rec_Ledr`). Legs (see 1.6).
5. **`ROJ_MEL_DATA`** via `Ac_Rojmel.DhrnIsu_RojMel` (LOAN REC ⇒ `Loan_Rec_RojMel`).
6. **`DHRN_DATA`** (movement) via `Ac_Tax.DhrrnIsu_Data` (LOAN REC ⇒ `Loan_Rec_Data`).
7. **`MAIN_STOCK`** via `Ac_Stock.Dhrn_Isu_Stk` (LOAN REC ⇒ `Loan_Rec_Stk`) — **only LOAN_TYPE≠'A'** (see 1.7).
8. **`IMAGE_DATA`/`AC_IMAGE`** via `DhirnImgPrint` (if enabled).
9. **`REMARK_DATA`** via `Ac_Tax.Vch_Remark(book,vch,0)` — narration rows.
10. (LOAN REC only) `UPDATE DHRN_ISU_DATA SET ISU_REC='Y'` joining `DHRN_ISU_DETL.DHRN_NO/YRCD/DBCD` (closes the rolled-over source issue).
Then `DC_Main.MsAcBal(party,…)` recomputes opening/closing party balances and prints.

### 1.6 (3) AC_DATA legs — `DhrnIsu_Ledr@1064` (the exact double-entry)
`AC_DATA` columns: `CO_*,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY(=CO+LC+YR+BK+VCH+nn),BOOK_NAME,BILL_NO,BILL_DATE,
CHQ_NO,AC_CODE,LD_CODE,CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,
DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE,LDR_NAME`. Filter `MAIN_BOOK='DHIRAN ISSUE' AND BOOK_INOUT='O'`.

For **cash dhiran (`LOAN_TYPE='A'`)**, legs `01..08` (LEDR_KEY suffix), `IT_TYPE='A'`, `FINE_WT=0`:
| key | Dr (LD_CODE on AC_CODE row) | Cr | amount | condition |
|---|---|---|---|---|
| 01 | party `AC_CODE` (contra `LEDR_ACCD`) | — | DR=`DHRN_AMT` | DHRN_AMT≠0 — loan receivable up |
| 02 | — | `LEDR_ACCD` cash (contra party) | CR=`DHRN_AMT` | money paid out |
| 03/04 | party | interest-income (`BOOK_DETL SR_NO=2`) | `INT_AMT` | INT_AMT≠0 |
| 05/06 | party | `BOOK_DETL` int a/c | `INT_REC_AMT` | INT_REC_AMT≠0 (interest collected now) |
| 07/08 | party | other-charge a/c (`SR_NO=3`) | `OTH_AMT` | OTH_AMT≠0 |

For **metal loan (`LOAN_TYPE≠'A'`)**: leg `09/10` instead — `IT_TYPE=LOAN_TYPE`, `SIGN='-'/'+'`,
`FINE_WT=DHRN_AMT`, `DR_AMT=CR_AMT=0` (a **fine-weight** journal, not money). If `MsTradFine='Y'` an
opposite `'+'` mirror is emitted. If `MsOpDhiran='Y'`, legs `11..16` repeat for opening (pre-`MOp_dt`) vouchers.

> Web takeaway: AC_DATA rows must carry **`IT_TYPE,SIGN,FINE_WT,FINE_RATE`** so metal balances flow into ledger/trial-balance/day-book; money-only rows break parity.

### 1.7 (3) MAIN_STOCK custody — `Dhrn_Isu_Stk@265` (metal loans only)
Runs **only when `LOAN_TYPE≠'A'`** (cash loans put **no** row in MAIN_STOCK; the pledged ornaments live in
`DHRN_ISU_DETL` only). Inserts one row: `IT_CODE = (LOAN_TYPE='G' ? '999' : 'FSL')`, `TR_TYPE='O'`,
`ITM_SIGN='-'`, `ITM_GWT=ITM_NWT=ITM_FINE=NET_AMT=KR_NWT=KR_FINE=DHRN_AMT`, `ITM_TOUCH=KR_TOUCH=100`,
plus full `MAIN_STOCK` column list (`SR_NO=1,ISR_NO=1,VCH_*,BOOK_NAME,AC_CODE,VCH_SRNO=0,TBL_CODE='',…`).
So lent metal **leaves** custody at issue; it returns (`ITM_SIGN='+'`) on repayment/interest receipt.

### 1.8 (3) DHRN_DATA movement — `DhrrnIsu_Data@33`
`INSERT INTO DHRN_DATA(…)` SELECT from `DHRN_ISU_DATA` where `MAIN_BOOK='DHIRAN ISSUE'`. Key mapped values:
`SR_NO=1, FROM_DATE=VCH_DATE, TO_DATE, BOOK_NAME=MAIN_BOOK, AC_CODE, DHRN_AMT, DHRN_REC_AMT=0, INT_PRC,
INT_AMT, INT_REC_AMT = (INT_REC_AMT − OTH_AMT), ISU_LC/YRCD/DBCD/NO = self (CO_YEAR,CO_BOOK,VCH_NO),
GOLD_AMT, REMARKS=GOLD_DESC, INT_DAYS, ADJ_DHRN=0, ENTRY_TYPE='D', LOAN_TYPE, UNCHAK_DHRN_REC=0, REC_DATE=NULL`.
**This is the row the OS report sums.**

### 1.9 Delete (`BtnDelete_Click@5493`)
Block if `MsLockDt>=vchDate` or no rights. Writes a rich `DELETE_DATA` row
(`…VCH_VAL_DR=DHRN_AMT, VCH_VAL_CR=0, FINE_TYPE='A', VCH_FINE_DR/CR=0, HD_VCH_NO, DELETE_USER, VCH_DESC=SUBSTRING(GOLD_DESC,1,149)`),
resets `ISU_REC='N'` on the rolled-over source (LOAN REC), then deletes from
`REMARK_DATA, TEMP_BOOK_DATA, DHRN_DATA, AC_DATA, ROJ_MEL_DATA, MAIN_STOCK, DHRN_ISU_DATA, DHRN_ISU_DETL`.

---

## 2. REPAYMENT — `TR_DHRN_REC.cs` ("DHIRAN RECEIVED")

### 2.1 (1) Operator input fields
Header echoes ISSUE (`tVchNo,tHdVchNo,mVchDate,tBillNo,tAcCode,tRecAc,cboLoanType,tPacketNo,tEmpCode,tVchDesc`)
plus repayment-specific:
| UI field | var | column | meaning |
|---|---|---|---|
| Source issue | `tIsuNo`/`tIsuYrCd`/`tIsuDbCd` | `ISU_NO`,`ISU_YRCD`,`ISU_DBCD`,`ISU_LC` | which dhiran is being repaid |
| Issue date | `mIsuDate` | `DHRN_DATE` | original issue date |
| From / To date | `mFromDate`/`mToDate` | `FROM_DATE`/`TO_DATE` | interest period being settled |
| Original principal | `nDhrnAmt` | `DHRN_AMT` | of the source issue |
| Outstanding principal | `nPandingDhrn` | (drives calc; `DHRN_OS_AMT`) | principal still due before this receipt |
| Principal received | `nDhrnReceived` | `DHRN_REC_AMT` | principal repaid now |
| Advance / unchecked | `nAdvanceDhiran` | `UNCHAK_DHRN_REC` | advance dhiran receipt |
| Dhiran adjust | `nDhrnAdjAmt` | `DHRN_ADJ_AMT` | adjustment to principal |
| Months / Int days | `nIntMonth`/`nIntDays` | `INT_MONTH`/`INT_DAY` | derived (2.2) |
| Annual int % | `nIntPrc` | `INT_PRC` | from source issue |
| Interest due | `nIntAmt` | `INT_AMT` | **auto-computed** (2.2) |
| Interest received | `nIntRecAmt` | `INT_REC_AMT` | defaults to `nIntAmt` |
| Interest kasar | `nIntKasr` | `KASAR_AMT` | rounding write-off |
| Pending-int adjust | `nPanIntAmt` | `PAN_ADJ_AMT` | adj of accrued interest |
| Adj interest / dhiran | `nAdjInt`/`nAdjDhiran` | `ADJ_INT`/`ADJ_DHRN` | |
| `chkInt` checkbox | — | (controls compounding) | enable yearly compounding when >1yr |
| Rate-cut (metal) | `nFineRate`,`nRcutAmt`,`nPayAmt`,`nOsAmt` | `RCUT_RATE`,`RCUT_AMT`,`RCUT_PAY_AMT`,`RCUT_OS_AMT` | settle metal loan by fine-rate cut |
| Gold summary | grid totals | `GOLD_AMT`(Σ NetAmt),`GOLD_WT`(Σ GrWt) | released items grid (`DHRN_REC_DETL`) |

A grid of **returned packets** writes `DHRN_REC_DETL` (mirror of `DHRN_ISU_DETL` + `REC_QTY,REC_NWT,ISU_SRNO,ISU_NO/LC/YRCD`).

### 2.2 (2) EXACT interest auto-computation (THE authoritative formula, `@6915-7035`)
This is **server-side**, not operator-typed. Inputs: outstanding principal `P=nPandingDhrn`, `INT_PRC`,
`MsIntYearDays`, the period, `chkInt`, `MsDhrnIntType`, `dp` (0 for cash / 3 for metal).

**Step A — days → whole months → days (monthly mode `MsDhrnIntType='M'`):**
```
rawDays  = |DateDiff(day, toDate, fromDate)|
months   = Round( rawDays / 365 × 360 / 30 )          // nIntMonth
nIntDays = months × 30
nIntDays = nIntDays − | nIntDays − Round(nIntDays/30)×30 |   // snap to whole 30-day months
nIntYear = nIntDays / 365
```
(For actual-day mode, `nIntDays = |DateDiff(day, toDate, fromDate)|` directly.)

**Step B — interest amount:**
```
// simple interest (nIntYear ≤ 1, or chkInt unchecked):
nIntAmt = Round( P × (INT_PRC/100) / MsIntYearDays × nIntDays , dp )

// annual COMPOUNDING (chkInt checked AND nIntYear > 1):
acc = 0; principal = P; consumed = 0
for y = 1 .. floor(nIntYear):
    yrInt     = Round( principal × (INT_PRC/100) / MsIntYearDays × 360 , 2 )
    acc      += yrInt
    principal += yrInt          // interest capitalised each 360-day year
    consumed += 360
nIntAmt = Round( principal × (INT_PRC/100) / MsIntYearDays × (nIntDays − consumed) + acc , dp )
```
> Net: **simple interest = OutstandingPrincipal × INT_PRC% × days ÷ MsIntYearDays**, with days bucketed to
> whole months×30 in monthly mode; optional **annual compounding** (360-day years) when `chkInt` and tenure > 1 yr.

**Step C — defaults:** `INT_REC_AMT = INT_AMT`; `DHRN_REC_AMT(received) = nPandingDhrn` (non-edit mode).
`DHRN_OS_AMT = nPandingDhrn − (UNCHAK_DHRN_REC + DHRN_ADJ_AMT)`.

### 2.3 (3) Tables written on REPAYMENT (`BtnSave_Click@6049`)
Header row in **`DHRN_REC_DATA`** is written only if `INT_AMT+INT_REC_AMT+DHRN_REC_AMT+KASAR_AMT != 0`.
Columns (verified): `VCH_DATE,DHRN_BILL,HD_VCH_NO,AC_CODE,AC_NAME,FROM_DATE,TO_DATE,VCH_TYPE,INOUT_TYPE,
ENTRY_TYPE(D/L),BOOK_NAME,DHRN_LIC_NO,PACKET_NO,DHRN_DATE,LOAN_TYPE,DHRN_AMT,DHRN_ADJ_AMT,UNCHAK_DHRN_REC,
DHRN_OS_AMT,DHRN_REC_AMT,DHRN_MONTH,KASAR_AMT,INT_DAY,INT_PRC,INT_AMT,INT_REC_AMT,INT_MONTH,LEDR_ACCD,
EMP_CODE,GOLD_AMT,GOLD_WT,ISU_NO,ISU_LC,ISU_YRCD,ISU_DBCD,VCH_DESC,PAN_ADJ_AMT,ADJ_INT,ADJ_DHRN,
RCUT_RATE,RCUT_AMT,RCUT_PAY_AMT,RCUT_OS_AMT,MAIN_USER,VCH_TIME,DATA_TRFR='N',USER_UPDATE='N',USER_DELETE='N'`.
Then in order (DELETE-then-INSERT per voucher):
1. `TEMP_BOOK_DATA`, `DHRN_REC_DATA` (header), `DHRN_REC_DETL` (returned-items grid).
2. `AC_DATA` via `Ac_Ledr.DhrnRec_Ledr` (LOAN ISSUE ⇒ `Loan_Isu_Ledr`).
3. `ROJ_MEL_DATA` via `Ac_Rojmel.DhrnRec_RojMel` (⇒ `Loan_Isu_RojMel`).
4. `DHRN_DATA` via `Ac_Tax.DhrnRec_Data` (⇒ `Loan_Isu_Data`).
5. `MAIN_STOCK` via `Ac_Stock.Dhrn_Rec_Stk` (⇒ `Loan_Isu_Stk`) — metal loans only; `ITM_SIGN='+'`, qty=`DHRN_REC_AMT+INT_REC_AMT`, where `RCUT_AMT=0`.
6. `UPDATE DHRN_ISU_DATA SET ISU_REC='Y'` when the source issue is fully repaid (joined via `ISU_NO`).
7. `Ac_Tax.Vch_Remark(book,vch,0)`.

**AC_DATA legs (`DhrnRec_Ledr@1105`)** — 17 legs; salient ones (cash `LOAN_TYPE='A'`):
- principal repaid `DHRN_REC_AMT − KASAR_AMT`: **Dr cash `LEDR_ACCD` / Cr party** (legs 01/02 when INT_REC=0; 03/04 full when INT_REC≠0).
- accrued interest `INT_AMT`: **Dr party / Cr interest-income** (`BOOK_DETL SR_NO=2`) legs 05/06.
- interest received `INT_REC_AMT − KASAR_AMT`: **Dr cash / Cr party** legs 07/08.
- `KASAR_AMT` rounding write-off legs 09/10 (`SR_NO=3`).
- metal rate-cut: `RCUT_AMT` via gold `00003` / silver `00004`; `RCUT_PAY_AMT` legs; metal loans use SIGN/FINE_WT legs (`LOAN_TYPE≠'A'`).
- `MsOpDhiran='Y'` adds opening legs 18/19.

**DHRN_DATA movement (`DhrnRec_Data@39`):** `DHRN_REC_AMT = DHRN_REC_AMT + ADJ_DHRN`, `INT_REC_AMT` as-is,
`UNCHAK_DHRN_REC=0`, `ADJ_DHRN`, `ISU_*` = the source issue keys (so OS nets against the right issue).
**ROJ_MEL_DATA (`DhrnRec_RojMel@492`):** rows for `DHRN_REC_AMT`, `INT_REC_AMT+ADJ_INT`, `KASAR_AMT`,
`ADJ_INT` (advance int), net cash `DHRN_REC_AMT+INT_REC_AMT`, and rate-cut rows.

### 2.4 Delete (`@6365`) — DELETE_DATA + reset `ISU_REC='N'`; purge DHRN_DATA/AC_DATA/ROJ_MEL_DATA/MAIN_STOCK/REC_DATA/REC_DETL.

---

## 3. INTEREST-ONLY — `TR_DHRN_INTREC.cs` ("INTREST RECIVED")

Dedicated monthly interest-collection flow. **Writes the same `DHRN_REC_DATA`/`DHRN_REC_DETL` tables** as REC
(distinguished by `BOOK_NAME='INTREST RECIVED'`/`'LOAN INT ENTRY'`). No new `DHRN_INTREC_*` table exists.

### 3.1 (1) Operator inputs
Same header as REC, plus `nUnchakDhrnRec` (advance), `nMonthIntAmt` (flat monthly interest), `cboIntMonth`
(`INT_MONTH`), `nIntrestKasar`(`KASAR_AMT`), `nFineRate/nRcutAmt/nPayAmt/nOsAmt` (rate-cut). No collateral
release grid amounts (`GOLD_AMT=GOLD_WT=0`); `PAN_ADJ_AMT=ADJ_INT=ADJ_DHRN=0`, `PACKET_NO=''`.

### 3.2 (2) Interest formula
Identical day-count engine as §2.2 (same `MsIntYearDays`, whole-month bucketing, optional `chkInt`
compounding). When a flat `nMonthIntAmt` is set, interest = `nMonthIntAmt × months`. `INT_REC_AMT` is the
interest actually collected; `DHRN_REC_AMT`/`UNCHAK_DHRN_REC` capture any principal/advance collected alongside.

### 3.3 (3) Tables written (`BtnSave_Click@4634`)
`DHRN_REC_DATA` columns as §2.3 **plus** `MONTH_INT_AMT` (=`nMonthIntAmt`); `GOLD_AMT/GOLD_WT=0`. Then:
- `INTREST RECIVED` (dhiran): `Ac_Ledr.DhrnIntRec_Ledr` → `Ac_Rojmel.DhrnIntRec_RojMel` → `Ac_Tax.DhrnIntRec_Data` → `Ac_Stock.Dhrn_Int_Stk` (metal, `ITM_SIGN='+'`, `MONTH_INT_AMT=0 AND RCUT_AMT=0`).
- `LOAN INT ENTRY` (loan): `Loan_IntRec_Ledr` → `Loan_IntRec_RojMel` → `Loan_IntIsu_Data` → `Loan_Int_Stk`.
- `OS LETTER`: **no posting** — only prints `DhrnOsLetter.RPT`.
- `Ac_Tax.Vch_Remark(book,vch,0)`.
Does **not** set `ISU_REC` (interest receipt never closes the loan).

**DHRN_DATA movement (`DhrnIntRec_Data@45`):** `INT_REC_AMT = INT_REC_AMT + KASAR_AMT`, `DHRN_REC_AMT` as-is,
`UNCHAK_DHRN_REC` carried (advance), `BOOK_NAME='INTREST RECIVED'`. **AC_DATA legs (`DhrnIntRec_Ledr@1150`):**
leg 01/02 `DHRN_REC_AMT+UNCHAK_DHRN_REC` Dr cash/Cr party; 03/04 `INT_AMT` Dr party/Cr int-income; 05/06
`INT_REC_AMT`; 07/08 `KASAR_AMT` via `00057`; metal-loan SIGN/FINE legs `09..` when `LOAN_TYPE≠'A'`.

### 3.4 Delete (`@4860`) — DELETE_DATA (`VCH_VAL_CR=INT_REC_AMT`) + purge same tables as REC.

---

## 4. OS / OUTSTANDING report — `RP_DHRN_OS.cs`

### 4.1 Source & recovered-to-date (`@1910` main, `@1961` per-issue sub-query)
Join `DHRN_ISU_DATA A` (open issues) with movement `DHRN_DATA B` grouped by issue
(`ISU_YRCD,ISU_DBCD,ISU_NO,AC_CODE`):
```
SELECT SUM(B.INT_AMT) IntAmt, SUM(B.INT_REC_AMT) IntRec,
       SUM(B.DHRN_REC_AMT) DhrnRec, SUM(B.UNCHAK_DHRN_REC) UnchakRec
FROM DHRN_DATA B GROUP BY ISU…
```
- **Principal recovered = `DhrnRec + UnchakRec`** (advance is netted — web currently ignores UnchakRec).
- **Outstanding principal = `DHRN_AMT − (DhrnRec + UnchakRec)`** (display col 15). Header pulls
  `AC_CODE,AC_NAME,AC_MOBILE,VCH_NO,PACKET_NO,DHRN_BILL,CO_YEAR,CO_BOOK,VCH_DATE,DHRN_AMT,INT_PRC,GOLD_WT,GOLD_DESC`.

### 4.2 (4) Accrued interest to report date + AGING (`@1990-2090`)
1. **As-of date** per issue: latest `TO_DATE` from `DHRN_DATA` for that issue (`ORDER BY TO_DATE DESC`); if none, the issue `VCH_DATE`. (= last date interest was paid up to.)
2. **Aging days `num`:** `DateDiff(day, asOfDate, reportDate mToDt)` (absolute). In **monthly mode**
   (`CurIntTypeCalc='M'`) `num` is first converted to whole months `Round(num/365×360/30)` then `×30` and
   snapped to a 30-multiple (same as §2.2). Calendar month-end edge handling mirrors the REC form.
3. **Accrued interest** (simple branch, the authoritative line `@2053`):
```
accrued = Round( (DHRN_AMT − DHRN_REC_AMT) × (INT_PRC/100) × num ÷ MsIntYearDays , dp )
```
   with the same **annual-compounding** branch (`@2040/2046`, 360-day years) when `chkInt` and `nIntYear>1`.
4. Report columns: party, mobile, `PACKET_NO`, `DHRN_BILL`, `VCH_DATE`, `DHRN_AMT`, recovered, **outstanding**,
   `INT_PRC`, aging days/months, **accrued interest**, `GOLD_WT`, `GOLD_DESC`. Aging buckets are by `num` days.

---

## 5. DB TABLES (verified columns — `information_schema`)

- **`DHRN_ISU_DATA`** (issue header): `CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,
  BOOK_NAME,VCH_DATE,VCH_TIME,DHRN_BILL,HD_VCH_NO,AC_CODE,AC_NAME,LEDR_ACCD,LOAN_TYPE,PACKET_NO,DHRN_AMT,
  DHRN_REC_AMT,DHRN_MONTH,INT_MONTH,INT_DAYS,INT_PRC,INT_AMT,INT_REC_AMT,OTH_AMT,MONTH_INT_AMT,GOLD_AMT,
  GOLD_NWT,GOLD_WT,SILVER_NWT,GOLD_DESC,VCH_DESC,TO_DATE,DHRN_DUE_DATE,DHRN_LIC_NO,EMP_CODE,
  OLD_ISU_NO,OLD_ISU_LC,OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ITEM_ADJ,ISU_REC,UNCHAK_DHRN_REC,MAIN_USER,
  DATA_TRFR,USER_UPDATE,USER_DELETE,tenant_id`.
- **`DHRN_ISU_DETL`** (collateral lines): `CO_*,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,PACKET_NO,PACKET_REC,
  CUST_NAME,IT_CODE,IT_NAME,IT_DESC,IT_TYPE,RATE_TYPE,ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,REC_NWT,ITM_TOUCH,
  ITM_WEST_PRC,ITM_FINE,ITM_RATE,ITM_AMT,NET_AMT,HD_VCH_NO,AC_CODE,HM_ID,DHRN_NO,DHRN_YRCD,DHRN_DBCD,
  BOOK_NAME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,MAIN_USER,DATA_TRFR,tenant_id`.
- **`DHRN_REC_DATA`** (repayment & interest header): `CO_*,VCH_NO,HD_VCH_NO,VCH_DATE,VCH_TIME,DHRN_DATE,
  DHRN_MONTH,FROM_DATE,TO_DATE,DHRN_AMT,DHRN_ADJ_AMT,DHRN_OS_AMT,DHRN_REC_AMT,UNCHAK_DHRN_REC,DHRN_DAY,
  INT_MONTH,INT_DAY,INT_PRC,INT_AMT,INT_REC_AMT,MONTH_INT_AMT,KASAR_AMT,ADJ_INT,ADJ_DHRN,PAN_ADJ_AMT,
  GOLD_AMT,GOLD_WT,ORNA_AMT,RCUT_RATE,RCUT_AMT,RCUT_PAY_AMT,RCUT_OS_AMT,AC_CODE,AC_NAME,LEDR_ACCD,DHRN_BILL,
  ISU_LC,ISU_NO,ISU_DBCD,ISU_YRCD,LOAN_TYPE,PACKET_NO,EMP_CODE,VCH_DESC,BOOK_NAME,VCH_TYPE,INOUT_TYPE,
  ENTRY_TYPE,DHRN_LIC_NO,MAIN_USER,DATA_TRFR,USER_UPDATE,USER_DELETE,tenant_id`.
- **`DHRN_REC_DETL`** (returned items): `…SR_NO,OLD_SRNO,ISU_SRNO,IT_CODE,IT_NAME,IT_DESC,IT_TYPE,RATE_TYPE,
  ITM_PCS,REC_QTY,ITM_GWT,ITM_OTH_WT,ITM_NWT,REC_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_RATE,ITM_AMT,NET_AMT,
  PACKET_NO,CUST_NAME,ISU_NO,ISU_LC,ISU_YRCD,ISU_DBCD,HD_VCH_NO,…,tenant_id`.
- **`DHRN_DATA`** (movement / OS source): `CO_*,VCH_NO,SR_NO,VCH_DATE,FROM_DATE,TO_DATE,VCH_TIME,DHRN_AMT,
  DHRN_REC_AMT,INT_PRC,INT_AMT,INT_REC_AMT,GOLD_AMT,INT_DAYS,ADJ_DHRN,UNCHAK_DHRN_REC,REC_DATE,AC_CODE,REMARKS,
  LOAN_TYPE,ISU_LC,ISU_YRCD,ISU_DBCD,ISU_NO,HD_VCH_NO,DHRN_LIC_NO,BOOK_NAME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,
  MAIN_USER,DATA_TRFR,tenant_id`.
- **`AC_DATA`** (ledger): keyed by `LEDR_KEY`; money `DR_AMT/CR_AMT` **+ metal `IT_TYPE,SIGN,FINE_WT,FINE_RATE`**;
  `AC_CODE,LD_CODE,PARTY_AC_CODE,BOOK_NAME,VCH_*,HD_VCH_NO,DATA_TYPE`.
- **`ROJ_MEL_DATA`** (day-book): `LEDR_KEY,AC_CODE,LD_CODE,CR_AMT,DR_AMT,AC_NAME,IT_TYPE,SIGN,ITM_PCS,ITM_GWT,
  ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,ITM_RATE,ITM_AMT,LBR_RATE,LBR_AMT,OTH_AMT,NET_AMT,IT_DESC,IT_CODE,
  MEMB_CODE,SCHM_CODE,REF_NO,DATA_TYPE`.
- **`MAIN_STOCK`** (custody, metal loans): `…SR_NO,ISR_NO,VCH_DATE,STK_DATE,BOOK_NAME,AC_CODE,IT_CODE('999'|'FSL'),
  TAG_NO='N',VCH_SRNO=0,TBL_CODE='',TR_TYPE('O'|'I'),ITM_SIGN('-'|'+'),ITM_QTY=1,ITM_GWT,ITM_NWT,ITM_TOUCH=100,
  ITM_FINE,NET_AMT,KR_NWT,KR_FINE,…` (qty fields all = `DHRN_AMT` at issue, `DHRN_REC_AMT+INT_REC_AMT` at receipt).
- **`TEMP_BOOK_DATA`** (header-book link): `CO_CODE,LC_CODE,CO_BOOK,VCH_NO(=HD_VCH_NO),BOOK_NAME`.
- **`IMAGE_DATA`** / **`AC_IMAGE`** (photos): see §1.4. **`REMARK_DATA`** (narration via `Vch_Remark`).
  **`DELETE_DATA`** (audit on delete). **`TAX_DATA`** is **not** used by DHRN (no GST on pledge interest).
- NOTE: tables `DHRN_INTREC_DATA` and `DHRN_INT_DATA` **do not exist** — interest-only writes `DHRN_REC_DATA`.

---

## 6. WEB MODULE SHAPE (`dhrn.ts` + routes + forms)

```
web/apps/api/src/modules/dhrn/
  dhrn.ts            // service: interest engine + posting engine + CRUD (txn-wrapped)
  dhrn.posting.ts    // builders mirroring DhrnIsu_/DhrnRec_/DhrnIntRec_ {Ledr,RojMel,Data,Stk}
  dhrn.routes.ts     // Fastify routes (AUTH REQUIRED — see note)
  dhrn.schema.ts     // zod DTOs for header + line grid + photos
web/apps/web/app/(app)/txn/
  dhrn-issue/page.tsx     // header + collateral grid + per-packet photo + party photo
  dhrn-receipt/page.tsx   // pick issue → auto interest → principal/int received/kasar/advance
  dhrn-interest/page.tsx  // pick issue → auto interest → interest received (+OS letter print)
  reports/dhrn-os/page.tsx// outstanding + accrued interest + aging
```
Suggested interest helper (single source of truth, used by issue/rec/intrec/OS):
```ts
function dhrnInterest(p: { principal:number; annualPrct:number; fromDate:Date; toDate:Date;
  yearDays:number; monthlyMode:boolean; compound:boolean; dp:0|3 }): { days:number; months:number; amount:number }
```
implementing §2.2 exactly (whole-month bucketing in monthly mode; annual 360-day compounding when `compound && years>1`).

> SECURITY: these routes mutate financial ledgers and store customer PII + collateral photos. They MUST be
> behind authentication + per-tenant authorization and CSRF protection. Do not expose unauthenticated.

---

## 7. STEP-BY-STEP BUILD CHECKLIST

1. **Schema/migrations** — ensure `DHRN_ISU_DATA, DHRN_ISU_DETL, DHRN_REC_DATA, DHRN_REC_DETL, DHRN_DATA,
   TEMP_BOOK_DATA, IMAGE_DATA, AC_IMAGE, REMARK_DATA, DELETE_DATA` exist with the columns in §5; ensure
   `AC_DATA` has `IT_TYPE,SIGN,FINE_WT,FINE_RATE,LEDR_KEY` and `ROJ_MEL_DATA` has the full item-metric columns;
   ensure `MAIN_STOCK` present. Add `tenant_id` everywhere.
2. **Config** — surface `MsIntYearDays, MsDhrnIntType, MsDhrnImgPrint, MsTradFine, MsOpDhiran, MsOpLoan,
   MsLockDt, MCo_OpDate/ClDate, MOp_dt, SSRegSrNo` from company settings; default `yearDays` configurable
   (NOT hard-coded 360). Load `BOOK_DATA`/`BOOK_DETL` sub-accounts (SR_NO 1/2/3) per book.
3. **Interest engine** (`dhrnInterest`) — implement §2.2 (days→months→days, simple + annual compounding,
   dp by loan type). Unit-test against desktop: e.g. P=100000, INT_PRC=24, 3 months monthly mode, yearDays=360
   ⇒ days=90, amount = 100000×0.24×90/360 = 6000.00; verify >1yr compounding path.
4. **Posting engine** (`dhrn.posting.ts`) — port `DhrnIsu_Ledr / DhrnRec_Ledr / DhrnIntRec_Ledr` (AC_DATA legs
   incl. metal SIGN/FINE_WT), `*_RojMel` (ROJ_MEL_DATA), `Dhrrn*_Data` (DHRN_DATA), `Dhrn_*_Stk` (MAIN_STOCK,
   metal-only). Resolve interest/charge/kasar accounts from `BOOK_DETL`.
5. **ISSUE** (`issueDhrn`) — validations (licence/lock-date/open-close/rights/party/vchno + MAX collision);
   DELETE-then-INSERT `TEMP_BOOK_DATA → DHRN_ISU_DATA → DHRN_ISU_DETL`; compose `GOLD_DESC/GOLD_AMT/GOLD_WT`;
   call posting builders; photos; `Vch_Remark`; LOAN_REC `ISU_REC='Y'` rollover; all in one txn.
6. **REPAYMENT** (`receiveDhrn`) — look up source issue + its `DHRN_DATA` to get outstanding & last TO_DATE;
   auto-compute interest (server-side, §2.2); write `DHRN_REC_DATA(+DETL)`; post legs incl KASAR, advance
   (UNCHAK), PAN_ADJ, rate-cut; release MAIN_STOCK (metal); set `ISU_REC='Y'` on full repay.
7. **INTEREST-ONLY** (`interestDhrn`) — like repayment but `BOOK_NAME='INTREST RECIVED'`, `MONTH_INT_AMT`
   support, no `ISU_REC` change; `OS LETTER` mode = print only (no posting). Writes `DHRN_REC_DATA`.
8. **DELETE** (`deleteDhrn`) — write rich `DELETE_DATA`; reset `ISU_REC='N'`; purge
   `REMARK_DATA,TEMP_BOOK_DATA,DHRN_DATA,AC_DATA,ROJ_MEL_DATA,MAIN_STOCK,<header>,<detail>`. Block on lock date.
9. **OS report** (`dhrnOutstanding`) — join `DHRN_ISU_DATA` + `SUM(DHRN_DATA)`; outstanding = `DHRN_AMT −
   (DhrnRec+UnchakRec)`; accrued interest = §4.2 from last TO_DATE to report date; aging buckets; expose
   party/mobile/packet/bill/GOLD_DESC. Reconcile a sample against desktop `RP_DHRN_OS`.
10. **Forms** — issue form with collateral grid (item/pcs/grwt/othwt/netwt/touch/west%/fine/rate/amount/netamt
    + IT_TYPE, desc) and per-packet + party photo upload; receipt/interest forms that pick an issue and show
    server-computed interest read-only (operator may override received/kasar/advance). Hide LOAN-side until needed.
11. **Auth & tests** — protect routes (auth + tenant scope); add tests: interest engine vs desktop, idempotent
    re-save (no double-posting), full-repay closes `ISU_REC`, metal-loan MAIN_STOCK out/in, OS accrual+aging.
12. **Verify build** — run the API/web build + the new unit/integration tests; reconcile one real dhiran
    voucher end-to-end (issue → interest → repay) against the desktop tables row-for-row before sign-off.
```
