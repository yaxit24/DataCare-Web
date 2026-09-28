# Implementation Spec — RATE CUT (desktop book 064, VCH_TYPE `RCUT`)

_Session `rate_cut_spec`. Generated 2026-06-30. READ-ONLY research → build spec. Evidence = deep read of
decompiled C# WinForms in `unified/src/csharp_nextdm/DataCareNext/` + live Postgres (`web-postgres-1` /
db `datacare`, tenant `default`). Every formula / table / leg below is cited to a `.cs` line or a real DB
row. **No app code was modified.** Accuracy over completeness — unknowns are called out in §7._

---

## 0. TL;DR + a required correction to the premise

**The task pointed at `TR_FINE_SL_PR.cs` as "the rate-cut form". That is wrong, and the DB proves it.**

- Book **064** is `BOOK_DATA`: `MAIN_BOOK='RATE CUT'`, `BOOK_SNAME='RCUT'`, `BOOK_INOUT='O'`,
  `BOOK_TYPE='F'`, `DATA_TYPE='A'` (live row — see §6.1).
- `TR_FINE_SL_PR.cs` is the **FINE SALE / FINE PURCHASE** form. It writes `CUT_DATA / CUT_DETL /
  CUT_STK_DETL` and posts via `Ac_Ledr.Fine_CUT_Ledr` whose filter is
  `B.MAIN_BOOK IN ('FINE PURC','FINE SALE')` (`Ac_Ledr.cs:2040`+, verbatim `MAIN_BOOK IN ('FINE PURC','FINE SALE')`).
  It is gated to those books and **never** posts a `RATE CUT` book. In this DB `CUT_DATA` has **0 rows**
  (every book), so that form's data set is empty here.
- The **RATE CUT** book stores its data in **`RATE_CUT_DATA` (header) + `RATE_CUT_ISU` (line items) +
  `SL_IDTL` (stone/diamond sub-lines)**. Confirmed by `BOOK_DATA.BOOK_TBL_NAME='RATE_CUT_DATA'`,
  `BOOK_TBL_DETL='RATE_CUT_ISU'` seeded for `MAIN_BOOK IN ('WH SALES','RATE CUT','VP PARCEL','BUL WH SALE','TOUR SALES')`
  (`MS_UPDATE.cs:7278`, `Mfg_Module.cs:1012`).
- The form that owns those tables is **`TR_VP.cs`** (`class TR_VP @ TR_VP.cs:30`; `FormMainBook =
  DC_Main.CurBookMain @ TR_VP.cs:5012`; `BtnSave_Click @ TR_VP.cs:5505-5858` writes
  `RATE_CUT_DATA/RATE_CUT_ISU/SL_IDTL`). Sibling forms `TR_WH_SALE`, `TR_TOUR_SALE`, `TR_BUL_SALE` write
  the **same** `RATE_CUT_DATA` family (grep `RATE_CUT_DATA`). They are the bullion "unfixed sale + rate
  fix" family. **Which of these forms the desktop menu opens for book 064 is not 100 % pinned from
  source — see §7.3.**
- **Business model:** RATE CUT = *fix the price ("cut the rate") on metal previously sold/issued
  unfixed.* It books the fixed metal value (= fine × rate), moves the metal weight on the customer's
  gold position, and settles in cash/cheque/card/kasar. It is **metal-and-money**, exactly the
  "karigar-style metal leg" pattern the web already uses (`IT_TYPE='G'/'S'`, `SIGN='-'/'+'`, `FINE_WT`,
  `FINE_RATE`).

**Reconciliation of the observed example up-front** (book 064, VCH `00004`, party `000286` DEV JEWELLERS):
`14965 = ITM_FINE 2.050 × ITM_RATE 7300` (pure metal value at the cut rate; `AC_DATA.FINE_RATE=7300`
confirms). `15800` is the **cash** leg (`SL_CASH_AMT`), an independently-entered settlement — **not**
derived from 14965 and **not** making/premium (there is **no** labour/making leg in the voucher). `15`
is the **kasar** leg to `KASAR JAVK A/C (00057)`. The 835 gap (15800 − 14965) is the net movement on the
customer's running balance. Full proof in §5.

---

## 1. Inputs (fields the user enters) — `TR_VP.cs`

### 1.1 Header (→ `RATE_CUT_DATA`, written `TR_VP.cs:5505-5858`)
| Field (control) | → column | Notes |
|---|---|---|
| Voucher No `tVchNo` | `VCH_NO` | auto = `MAX(VCH_NO)+1` per `CO_CODE/LC_CODE/CO_YEAR/CO_BOOK` (`TR_VP.cs:5570`) |
| Voucher Date `mVchDate` | `VCH_DATE` | must be inside open year & after lock date (`TR_VP.cs:5533-5543`) |
| Party A/C `tAcCode` (+`tAcName`) | `AC_CODE`,`AC_NAME` | mandatory (`TR_VP.cs:5550`) — the customer |
| Bill/Ref No `tBillNo` | `BILL_NO` | |
| Hd Vch No `tHdVchNo` | `HD_VCH_NO` | links `TEMP_BOOK_DATA` reservation |
| Item type `cboItemTyp` | `IT_TYPE` | `Mid(...,1,1)` → `G`(gold)/`S`(silver) |
| VP charge type `cboVpChargType` | `VP_AMT_TYPE` | parcel/VP variants only |
| `nVpInsAmt`,`nVpCharge`,`tAngdiyaAc` | `VP_INS_AMT`,`VP_CHARG_AMT`,`AC_ANGDIYA` | VP PARCEL only |
| Employee `tEmpCode` | `EMP_CODE` | |
| Desc `tVchDesc` | `VCH_DESC` | |
| Time | `VCH_TIME` (`mVchDate + ' ' + mTime`) | |

### 1.2 Line grid `MSG` (→ `RATE_CUT_ISU`, one row per piece/lot) — col map from `BtnSave_Click`
`0`=SR_NO, `1`=TAG_NO (blank ⇒ `'N'`), `2`=IT_CODE, `3`=TBL_CODE, `4`=DESIGN_NO, `5`=ITM_SIZE,
`6`=BAG_WT, `7`=ITM_PCS, `8`=ITM_GWT, `9`=ITM_OTH_WT, `10`=ITM_NWT, `12`=ITM_GHT_WT, `13`=ITM_TOUCH,
`14`=ITM_WEST_PRC, `15`=ITM_FINE, `16`=ITM_RATE, `17`=ITM_AMT, `18`=LBR_PRC, `19`=LBR_TYPE,
`20`=LBR_RATE, `21`=LBR_AMT, `22`=OTH_AMT, `23`=ITM_MRP, `24`=TOT_AMT, `25`=TAX_PRC, `26`=NET_AMT,
`29`=KR_NET_WT, `32`=KR_TOUCH, `33`=KR_WEST_PRC, `34`=KR_FINE, `27`=KR_NAME, `39`=VCH_SRNO,
`44`=OLD_SRNO, `45`=RATE_TYPE, `46`=IT_TYPE, `48`=PR_CODE, `62`=ITM_REMARK, `66`=DESIGN_IMG_ID.
(Source: `TR_VP.cs:5505-5858`, the `RsDetl.NewRow()` block.)

### 1.3 Sub-detail grid (`DtIdtl` → `SL_IDTL`, stones/diamonds under a line)
`ISR_NO`, `IT_CODE`, `DM_CODE/DM_NAME/DM_SIZE/DM_SFNO`, `IT_PCS`, `IT_GWT`, `KR_WT`, `IT_CON_PRC`,
`IT_RATE_TYPE`, `IT_RATE`, `IT_AMT`, `IT_LBR_RATE`, `IT_LBR_AMT`, `IT_NET_AMT`, `IT_CON_WT`, `IT_TYPE`,
parent `SR_NO`/`TAG_NO`/`VCH_SRNO` (`TR_VP.cs:5505-5858`, the `RsIdtl.NewRow()` block; `DtIdtl` column
ordinals 0..20).

### 1.4 Bill totals grid `MSG2_TOTAL` (payment strip) — row map from header save
`row0`=NET (`SL_NET_AMT`), `row1`=TAX (`TAX_PRC`/`SL_TAX_AMT`/`TAX_CODE` in cols 2/3/4), `row3`=CASH
(`SL_CASH_AMT`), `row4`=CHQ (`SL_CHQ_AMT`; `BANK_AC` col4, `CHQ_NO` col2), `row5`=CARD (`SL_CARD_AMT`;
`CARD_AC` col4), `row6`=KASAR (`SL_KASAR_AMT`), `row7`=BILL_OS / `VP_AMT` (`SL_BILL_OS`,`VP_AMT`).
(Source: `TR_VP.cs:5505-5858` `dataRow2[...]` assignments.)

---

## 2. Computation (exact formulas, cited)

All per-row math is in **`TR_VP.CommPassTotal @ TR_VP.cs:3992-4242`** (grid `MSG`). Weights round to 3
dp, amounts to 0 dp (nearest rupee) via `Math.Round(...,0)` / `"0.00"` formatting.

```
NetWt      col10 = col8(GrWt) − col9(OthWt)
GhtWt      col12 = col10 × col11(Ght%) / 100
Fine       if (col13(touch) + col14(west) ≠ 0  AND col10 ≠ 0):
               col15 = (col10 + col12) × (col13 + col14) / 100        # (NWT+GhtWt)×(touch+west)/100
           else if (touch+west == 0):
               col15 = col10 + col12                                  # fine = net + ght
           else:
               col15 = col10
KR Fine    col34 = (col29 + col31) × (col32 + col33) / 100            # karigar/return-side fine
```
`col29 (KR_NET_WT) = col8 − col28`.

**Item amount by rate type `col45` (`RATE_TYPE`)** — this answers the rate question:
```
'P'      col17 = round(col7(pcs) × col16(rate), 0)        # per piece
'1'      col17 = round(col15(fine) × col16 / 10,   0)     # rate per 10 g
'K'      col17 = round(col15(fine) × col16 / 1000, 0)     # rate per kg
default  col17 = round(col15(fine) × col16, 0)            # per gram  →  ITM_AMT = FINE × RATE
```
The observed voucher uses the **default (per-gram)** branch: `14965 = round(2.050 × 7300)`.

**Labour amount `col21` by `LBR_TYPE col19`** (`P`=per-pc, `N`=per-net-gram[±ght via `MsLbrWithGht`],
`K`=per-fine/1000, default=per-gross-gram); `LBR%` path: `col20 = round(col16 × col18/100, MsLbrRof)`.

**Totals**
```
TOT_AMT  col24 = (col23(MRP) ≠ 0) ? col23                       # MRP overrides; clears lbr/itm/oth
                                  : col21(lbr) + col22(oth) + col17(itmAmt)
NET_AMT  col26 = (col25(tax%) == 0) ? col24
                                    : round(col24 / (col25 + 100) × 100, 0)   # tax-inclusive back-out
```
Bill rollups: `MSG_TOT_FILL @ TR_VP.cs:3674-3730` (Σ into `MSG_TOT`), `BILL_TOTAL @ TR_VP.cs:6935-6972`
(fills `MSG2_TOTAL`). Header derives `SL_ITM_AMT=Σcol17`, `SL_LBR_AMT=Σcol21`, `SL_OTH_AMT=Σcol22`,
`SL_FINE=TotDrFine`, `SL_NET_AMT=MSG2_TOTAL[0,3]` (`TR_VP.cs:5505-5858`).

---

## 3. DB footprint — every table written on Save

Save order in `TR_VP.BtnSave_Click @ TR_VP.cs:5505-5858` (each table is **DELETE-by-key then re-insert**
= re-save replaces):

| # | Table | How | Key columns / notes |
|---|---|---|---|
| 1 | `RATE_CUT_DATA` | header, 1 row | full money/fine column set (§3.1) |
| 2 | `RATE_CUT_ISU` | line items | one row per `MSG` line where `(IT_CODE&TAG set & MRP≠0)` **OR** `(GrWt+LbrAmt+OthAmt+NetAmt ≠ 0)` |
| 3 | `SL_IDTL` | stone/diamond sub-lines | from `DtIdtl` where `pcs+gwt+netAmt ≠ 0` |
| 4 | `TEMP_BOOK_DATA` | vch-no reservation | only when totals nonzero; `(CO_CODE,LC_CODE,CO_BOOK,VCH_NO=tHdVchNo,BOOK_NAME)` |
| 5 | `AC_DATA` | `DELETE` then `Ac_Ledr.VP_Ledr(book,vch)` | `TR_VP.cs:5814-5815` — **see §4 + §7.3 caveat** |
| 6 | `ROJ_MEL_DATA` | `DELETE` then `Ac_Rojmel.VP_Rojmel(book,vch)` | day-book projection (`TR_VP.cs:5817-5818`) |
| 7 | `MAIN_STOCK` | `DELETE` then `Ac_Stock.Wh_Sale_Stk(book,vch)` | tag/stock movement (`TR_VP.cs:5820-5821`) |
| 8 | `DM_DATA` | `DELETE` then `Ac_Stock.Dm_Vp_Sale_Sale_Detl(book,vch)` | diamond stock (`TR_VP.cs:5823-5824`) |

### 3.1 `RATE_CUT_DATA` columns (live schema, tenant-scoped — `information_schema`)
`tenant_id,row_id,CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,IT_TYPE,
AC_CODE,AC_NAME,DR_AMT,CR_FINE,CR_AMT,DR_FINE,RATE_PAR,FINE_RATE,SL_FINE,PR_FINE,TOT_FINE_DR,
TOT_FINE_CR,KSR_FINE_CR,KSR_FINE_DR,SL_NET_AMT,SL_ITM_AMT,SL_LBR_AMT,SL_OTH_AMT,SL_ADV_AMT,SL_CASH_AMT,
SL_CARD_AMT,SL_CHQ_AMT,SL_KASAR_AMT,SL_BILL_OS,PR_NET_AMT,PR_ITM_AMT,PR_LBR_AMT,PR_OTH_AMT,PR_ADV_AMT,
PR_CASH_AMT,PR_CARD_AMT,PR_CHQ_AMT,PR_KASAR_AMT,PR_BILL_OS,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,
EMP_CODE,VCH_DESC,ENTRY_TIME,ADD1,ADD2,ADD3,CITY,MOBILE,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,
CONV_RATE,CONV_PRC,SILVER_FINE_DR,SILVER_FINE_CR,MOB_ENTRY_SAVE,VP_ADJ_AMT,PR_TAX_AMT,PR_TOT_AMT,
SL_TAX_AMT,SL_TOT_AMT,INT_DAYS,INT_OS_FINE,INT_PRC_FINE,INT_FINE,VP_AMT,VP_INS_AMT,VP_CHARG_AMT,
VP_AMT_TYPE,AC_ANGDIYA,TAX_CODE,TAX_PRC,SLV_FINE_CR,SLV_FINE_DR,SLV_AMT_CR,SLV_AMT_DR,SLV_FINE_RATE,
USER_UPDATE,USER_DELETE,TDS_CODE,TDS_PRC,SL_TDS_AMT,PR_TDS_AMT`
(`SL_*` = sale/rate-cut side, `PR_*` = purchase side, both 0 for a pure rate-cut.)

### 3.2 `RATE_CUT_ISU` columns
`tenant_id,row_id,VCH_SRNO,TAG_NO,CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,
VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,
ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,
LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,KR_NET_WT,
KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,…,LESS_TOUCH,
ITM_OTH_RATE,ITM_OTH_FINE,CONV_RATE,CONV_PRC,SILVER_FINE,ISU_NO,ISU_LC_CODE,ISU_YRCD,ISU_DBCD,ISU_SRNO,
LESS_WT,TAG_GWT,TAG_NWT,MCX_RATE,HM_FINE,DESIGN_IMG_ID,ADJ_WT,ITM_LOT,FINE_CUT_FINE,FINE_CUT_NWT,
FINE_CUT_GWT,FINE_CUT_PCS,EMP_CODE,PRM_AMT,HM_ID*,ITM_COLOR,ITM_STYLE`
(`ISU_*` + `FINE_CUT_*` link a rate-cut line back to the original unfixed-sale lot it fixes.)

### 3.3 `SL_IDTL` columns (stone/diamond sub-lines)
`tenant_id,row_id,VCH_NO,CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,
ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,
IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,
IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,
MAIN_USER,…,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT`.

### 3.4 AC_DATA leg list (signs + IT_TYPE) — canonical source `Ac_Ledr.Wh_Sales_Ledr @ Ac_Ledr.cs:613-780`
Filter on every leg: `B.MAIN_BOOK IN ('WH SALES','RATE CUT','BUL WH SALE','TOUR SALES') AND
B.BOOK_INOUT='O'`. Each economic leg is double-posted (party row + contra row, swapped `AC_CODE`/
`LD_CODE`). `SR_NO` = the `BOOK_DETL` config row that supplies the contra `AC_CODE`. `IT_TYPE`: `A`=money,
`G`=gold metal, `S`=silver metal; metal legs carry `SIGN` + `FINE_WT` (+`FINE_RATE`).

| LEDR_KEY suffix | BOOK_DETL SR_NO | IT_TYPE | Amount (CR/DR) | Metal | Meaning |
|---|---|---|---|---|---|
| 01 / 02 | 1 | G | DR = `DR_AMT+SL_ITM_AMT+SL_TAX_AMT` | `SIGN '+'`, `FINE_WT=CR_FINE`, `FINE_RATE` | gold **value** of fixed metal (sale side) |
| 04 / 05 | 8 | S | same, silver | — | silver value |
| 08 / 09 | 2 | G | CR = `CR_AMT+PR_ITM_AMT+PR_TAX_AMT` | `SIGN '-'`, `FINE_WT=DR_FINE` | purchase/return side value |
| 15 / 16 | 6 | A | `SL_LBR_AMT` | — | **labour / making** (only if entered) |
| 17 / 18 | 11 | A | `SL_OTH_AMT` | — | other charges |
| 23 / 24 | 1 | G | 0 | `SIGN '-'`, `FINE_WT=SL_FINE` | **metal-only**: customer fine OUT (the fixed fine) |
| 25 / 26 | 8 | S | 0 | `SIGN '-'`, `FINE_WT=SL_FINE` | silver metal-only |
| 27 / 28 | 12 | (G/S) | 0 | `SIGN '+'`, `FINE_WT=KSR_FINE_CR` | fine-kasar credit |
| 33 / 34 | 12 | (G/S) | 0 | `SIGN '-'`, `FINE_WT=KSR_FINE_DR` | fine-kasar debit |
| 35 / 36 | 1 | A | `SL_CHQ_AMT` | — | cheque → `BANK_AC` |
| 39 / 40 | 1 | A | `SL_CARD_AMT` | — | card → `CARD_AC` |
| 43 / 44 | 3 | A | `SL_CASH_AMT` | — | **cash** → SR3 cash account |
| 47 / 48 | 4 | A | `SL_KASAR_AMT` (>0) | — | **kasar** → SR4 kasar account |
| 49 / 50 | 4 | A | `ABS(SL_KASAR_AMT)` (<0) | — | negative kasar |
| 53 / 54 | — | (G/S) | 0 | `SIGN '-'`, `FINE_WT=INT_FINE`, LD=`00061` | interest fine |
| 55 / 56 | — | A | `SL_TAX_AMT` / `PR_TAX_AMT` → `TAX_AC` | — | GST (BUL WH SALE only) |
| 57–60 | 8 / 9 | S/A | `SLV_*` | `SIGN '+'/'-'`, `SLV_FINE_*` | silver value/metal |
| 61–64 | — | A | `SL_TDS_AMT`/`PR_TDS_AMT` → `TAX_AC` | — | TDS |
| 65–68 | 1 | A | `SL_ITM_AMT` (LD=`00007`) | — | `IT_TYPE='A'` item-amount variant (reg-gated) |

> The labour/making path is legs **15/16** (`SL_LBR_AMT`) and other-charges **17/18** (`SL_OTH_AMT`).
> **If those header fields are 0, no making leg is posted** — which is the case for the example voucher
> (see §5). PR_* legs only fire for the purchase counter-side of a parcel.

`Ac_Ledr.VP_Ledr @ Ac_Ledr.cs:1723` is the **VP PARCEL** variant (legs use `VP_AMT`, `SL_ITM_AMT`,
`SL_FINE`, `KSR_FINE_CR`, charges; filter `B.MAIN_BOOK='VP PARCEL'`). It does **not** match book 064's
`RATE CUT` filter — see §7.3.

---

## 4. Cross-check against REAL data (authoritative ledger)

### 4.1 Book 064 — `AC_DATA` legs (live; `docker exec web-postgres-1 psql … CO_BOOK='064'`)
Customer `000286` voucher (`VCH_NO='00004'`, all rows `VCH_TYPE='RCUT'`, `BOOK_NAME='RATE CUT'`):

| LD_CODE | AC_CODE | IT_TYPE | SIGN | DR_AMT | CR_AMT | FINE_WT | FINE_RATE |
|---|---|---|---|---:|---:|---:|---:|
| `00008` PURCHASE GOLD A/C | `000286` | G | `-` | 0.00 | **14965.00** | **2.050** | **7300** |
| `000286` | `00008` | A | | **14965.00** | 0.00 | 0 | 0 |
| `00001` CASH ON HAND | `000286` | A | | **15800.00** | 0.00 | 0 | 0 |
| `000286` | `00001` | A | | 0.00 | **15800.00** | 0 | 0 |
| `00057` KASAR JAVK A/C | `000286` | A | | **15.00** | 0.00 | 0 | 0 |
| `000286` | `00057` | A | | 0.00 | **15.00** | 0 | 0 |

Account names from `AC_MAST`: `00001`=CASH ON HAND, `00008`=PURCHASE GOLD A/C, `00057`=KASAR JAVK A/C,
`000286`=DEV JEWELLERS. Voucher balances: **ΣDR = ΣCR = 30 780** (14965+15800+15).

Other 064 vouchers in the first 30 legs follow the same shape (e.g. `000939`: G `-` 36.200 valued
274324 ≈ 36.200×7577; `000211`: G `-` 7.914 valued 58250; `000208`: G `-` 33.620 valued 249965).

### 4.2 The 15800-vs-14965 explanation (cited)
- **14965 = gold value = `ITM_FINE 2.050 × ITM_RATE 7300`** — the default per-gram branch of
  `CommPassTotal` (`col17 = round(col15 × col16, 0)`, §2) and `Wh_Sales_Ledr` leg 01
  `DR = …+SL_ITM_AMT…` with `FINE_RATE=A.FINE_RATE`. The live `AC_DATA.FINE_RATE=7300` and
  `FINE_WT=2.050` make this exact. It is the **pure metal value at the cut rate** (`SL_ITM_AMT`).
- **15800 = `SL_CASH_AMT`** (`MSG2_TOTAL[3,3]` → leg 43/44 → CASH ON HAND). A free-entered cash
  settlement; nothing in the voucher derives it from 14965.
- **15 = `SL_KASAR_AMT`** (`MSG2_TOTAL[6,3]` → leg 47/48 → KASAR JAVK `00057`).
- **The 835 gap is NOT making/premium/a different rate.** Making would appear as a labour leg
  (`SL_LBR_AMT`, legs 15/16) and other-charges as legs 17/18 — **neither exists** in this voucher, so
  `SL_LBR_AMT=SL_OTH_AMT=0` and `NET_AMT=ITM_AMT=14965`. The 835 is the **net change to the customer's
  running balance**: customer net for the voucher = `DR 14965 − CR 15800 − CR 15 = CR 850`. Economically
  the customer paid 15800 cash + 15 kasar against a 14965 fixing, leaving an 850 credit (settling a
  prior balance / advance). This is consistent with the rate-cut model (fix metal owed → money, then
  settle), where cash need not equal a single fixing's value.

---

## 5. Web implementation plan

### 5.1 Module signature (mirror `karigar.ts` + `posting.ts`)
New module `web/apps/api/src/modules/finance/rateCut.ts` (or `sales/rateCut.ts`):
```ts
export interface RateCutLine {
  itCode?: string; tagNo?: string; designNo?: string; pcs?: number;
  grossWt?: number; othWt?: number; netWt?: number; ghtPct?: number;
  touch?: number; westPct?: number;            // → fine
  rate?: number; rateType?: 'P'|'1'|'K'|'G';    // → itmAmt
  lbrType?: 'P'|'N'|'K'|'G'; lbrRate?: number; lbrAmt?: number; othAmt?: number;
  mrp?: number; taxPct?: number; itType?: 'G'|'S';
  isuRef?: { yrcd: string; dbcd: string; no: string; srno: number }; // original unfixed lot (RATE_CUT_ISU.ISU_*)
}
export interface RateCutInput {
  scope: VoucherScope; vchDate?: string; acCode: string; acName?: string; itType?: 'G'|'S';
  lines: RateCutLine[]; components?: SlIdtlLine[];
  pay?: { cash?: number; chq?: number; chqNo?: string; bankAc?: string;
          card?: number; cardAc?: string; kasar?: number; billOs?: number; taxPct?: number; taxCode?: string };
}
export async function rateCut(prisma, input: RateCutInput): Promise<{ vchNo: number; fine: number; netAmt: number }>;
```

### 5.2 Pure functions (unit-test first against §2 golden values)
- `netWt = round3(grossWt − othWt)`; `ghtWt = round3(netWt × ghtPct/100)`.
- `fine(netWt, ghtWt, touch, westPct)` = `round3((netWt+ghtWt) × (touch+westPct)/100)` (touch+west=0 ⇒ `netWt+ghtWt`).
- `itmAmt(fine, rate, rateType, pcs)`: `P`→`round0(pcs×rate)`, `'1'`→`round0(fine×rate/10)`,
  `K`→`round0(fine×rate/1000)`, default→`round0(fine×rate)`. **Golden: fine 2.050, rate 7300 ⇒ 14965.**
- `lbrAmt(...)` per type (§2). `totAmt = mrp>0 ? mrp : lbrAmt+othAmt+itmAmt`.
  `netAmt = taxPct==0 ? totAmt : round0(totAmt/(taxPct+100)×100)`.

### 5.3 Posting (compose into the existing engine — `posting.ts`)
Use `withTenant` → `nextVoucherNoTx(tx, scope)` (`numbering.ts:24`) → `postVoucherTx(tx, tenantId,
{ ledger, writes, bookName:'RATE CUT' })` (`posting.ts:137`). `postVoucherTx` already runs
`assertBalanced` (Σ CR = Σ DR), `assertPeriodOpen` (period-lock), and stamps `LEDR_KEY/IT_TYPE/LD_CODE/
BOOK_NAME` (`enrichLedgerLine`). Build the AC_DATA `lines` as the §3.4 legs; build `writes` for
`RATE_CUT_DATA` (header), `RATE_CUT_ISU` (lines), `SL_IDTL` (components), and the `TEMP_BOOK_DATA`
reservation. (Defer `ROJ_MEL_DATA`/`MAIN_STOCK`/`DM_DATA` projections to phase 2 unless rojmel/stock
parity is required immediately.)

### 5.4 Karigar-style metal legs (the core)
Mirror `karigar.ts:140/175` (`IT_TYPE:'G', SIGN:'-'/'+', FINE_WT, FINE_RATE, DR_AMT:0, CR_AMT:0`). Per
voucher, for `itType='G'` (silver = `'S'` + the SR8/9 accounts):
```
// value side (money) — customer owes the fixed metal value
{ ...key, AC_CODE: customer, LD_CODE: SALES_GOLD_AC, IT_TYPE:'A', DR_AMT: 0,        CR_AMT: itmAmt }  // gold A/C CR
{ ...key, AC_CODE: SALES_GOLD_AC, LD_CODE: customer,  IT_TYPE:'A', DR_AMT: itmAmt,  CR_AMT: 0 }       // customer DR
// metal side — fixed fine leaves the customer's unfixed-gold position
{ ...key, AC_CODE: customer, LD_CODE: SALES_GOLD_AC, IT_TYPE:'G', SIGN:'-', FINE_WT: fine, FINE_RATE: rate, DR_AMT:0, CR_AMT:0 }
// cash / chq / card / kasar pairs (money, IT_TYPE 'A') from input.pay
{ ...key, AC_CODE: CASH_AC,  LD_CODE: customer, DR_AMT: cash, CR_AMT: 0 } ; mirror CR on customer
{ ...key, AC_CODE: customer, LD_CODE: KASAR_AC, DR_AMT: 0,    CR_AMT: kasar } ; mirror DR on kasar
// labour (only if lbrAmt>0): SR6 account ; other charges: SR11 account
```
**Contra accounts** come from the book's `BOOK_DETL` SR_NO config (SR1 gold, SR2 purchase-gold, SR3
cash, SR4 kasar, SR6 labour, SR11 other) — see §7.2. The observed data used `00008`/`00001`/`00057`;
seed config maps RATE CUT SR1→`SALES GOLD A/C (00003)` (`MS_UPDATE.cs:23882`). **Resolve the contra
accounts from `BOOK_DETL` at runtime; do not hard-code.** Balance is guaranteed by `assertBalanced`.

### 5.5 Routes / delete
`POST /txn/rate-cut`, `GET /txn/rate-cut/:vchNo`, `DELETE /txn/rate-cut/:vchNo` (use `reverseVoucherTx`
`posting.ts:170` with `tables:['RATE_CUT_DATA','RATE_CUT_ISU','SL_IDTL','AC_DATA','ROJ_MEL_DATA',
'MAIN_STOCK','DM_DATA','TEMP_BOOK_DATA']` + a `DELETE_DATA` audit row). Guard with the existing
`auth`/`guard(req,reply,'create'|'update')` RBAC. **Security note:** these endpoints are
authenticated/RBAC-guarded — keep that guard; do not expose unauthenticated.

### 5.6 Verification
Unit tests for §2 (golden: fine 2.050 × 7300 = 14965; tax back-out; lbr types). Integration: post the
§4.1 voucher shape and assert the 6 AC_DATA legs + `Σ DR = Σ CR = 30780`; assert re-save replaces and
delete reverses.

---

## 6. Evidence index (file → what it proves)

- **Live DB** (`docker exec web-postgres-1 psql -U datacare -d datacare …`):
  - `BOOK_DATA` 064 = `RATE CUT / RCUT / O / F / A`.
  - `AC_DATA` 064 VCH 00004 — the 6 legs in §4.1 (authoritative).
  - `AC_MAST` — account names (00001/00008/00057/000286/000939).
  - `information_schema.columns` — `RATE_CUT_DATA` (94 cols), `RATE_CUT_ISU` (98 cols), `SL_IDTL`
    (54 cols) — §3.1-3.3.
  - **0 rows**: `CUT_DATA`/`CUT_DETL`/`CUT_STK_DETL` (all books), `RATE_CUT_DATA`/`RATE_CUT_ISU`/
    `SL_IDTL` (book 064), `BOOK_DETL` (book 064 and any `MAIN_BOOK='RATE CUT'`).
- `TR_VP.cs` — RATE CUT/VP form: `class @30`, `CommPassTotal @3992-4242` (§2), `BtnSave_Click
  @5505-5858` (§1/§3 table writes + ledger/rojmel/stock dispatch), `MSG_TOT_FILL @3674-3730`,
  `BILL_TOTAL @6935-6972`, `FormMainBook=CurBookMain @5012`, `Ac_Ledr.VP_Ledr @5815`.
- `Ac_Ledr.cs` — `Wh_Sales_Ledr @613-780` (the `'RATE CUT'` legs, §3.4), `VP_Ledr @1723` (VP PARCEL),
  `Fine_CUT_Ledr @2040` (FINE SALE/PURC — for `TR_FINE_SL_PR`, not 064).
- `TR_FINE_SL_PR.cs` — FINE SALE/PURC form (`BtnSave_Click @4278-4650` writes `CUT_DATA/CUT_DETL/
  CUT_STK_DETL`; not book 064).
- `MS_UPDATE.cs:7278/23882`, `Mfg_Module.cs:1012` — book-config seeds (`BOOK_TBL_NAME='RATE_CUT_DATA'`;
  RATE CUT SR1=`SALES GOLD A/C 00003`).
- `web/apps/api/src/modules/posting/posting.ts` (`postVoucherTx@137`, `reverseVoucherTx@170`,
  `assertBalanced`, `enrichLedgerLine`), `…/vouchers/numbering.ts` (`nextVoucherNoTx@24`),
  `…/manufacturing/karigar.ts` (metal-leg shape @140/175) — the web engine the plan composes onto.

---

## 7. Unknowns / cannot-verify (read this before building)

1. **Source rows are NOT in this DB.** `RATE_CUT_DATA`/`RATE_CUT_ISU`/`SL_IDTL` have **0 rows** for book
   064 (and `CUT_*` 0 rows everywhere). Only the **`AC_DATA` ledger** (and presumably `ROJ_MEL_DATA`)
   was migrated. Therefore the 14965/15800/15 split is read from **`AC_DATA` (authoritative for the
   ledger)** and cross-checked to the `.cs` math — but I **cannot** read the source header's
   `SL_ITM_AMT/SL_CASH_AMT/SL_NET_AMT/SL_LBR_AMT` for VCH 00004 to prove the decomposition from the
   originating row. The "no making" conclusion is inferred from the **absence** of any labour/other leg
   in `AC_DATA`, which is strong but not a direct read of `SL_LBR_AMT`.
2. **`BOOK_DETL` for book 064 is empty**, so the SR_NO→contra-account map that `Wh_Sales_Ledr` joins on
   cannot be reproduced from this DB. Observed legs used `00008`(gold)/`00001`(cash)/`00057`(kasar); the
   decompiled seed maps RATE CUT **SR1→`SALES GOLD A/C 00003`** (`MS_UPDATE.cs:23882`) — i.e. the live
   production config differs from the seed. The web build must read `BOOK_DETL` at runtime and must have
   it seeded for book 064 (currently it is not).
3. **Form/ledger-routine mismatch (important).** `TR_VP.BtnSave` calls `Ac_Ledr.VP_Ledr`, but `VP_Ledr`
   filters `MAIN_BOOK='VP PARCEL'` only — it would post **nothing** for a `RATE CUT` book. The `RATE
   CUT` legs are emitted by `Wh_Sales_Ledr` (called by `TR_WH_SALE`/`TR_TOUR_SALE`/`TR_BUL_SALE`). The
   observed 6-leg shape (money **and** metal combined on the gold-account row; customer money DR; cash;
   kasar) matches **neither** the current `Wh_Sales_Ledr` row-split (which emits a separate fine-only
   leg 23 and a value leg 01) **nor** `VP_Ledr` exactly. ⇒ The migrated rows were produced by a
   different/older ledger build (or a registration-gated branch — note the `SSRegSrNo`/`MsTradFine`
   conditionals throughout `Wh_Sales_Ledr`). **Which desktop form actually opens book 064, and exactly
   which ledger routine produced its rows, is not uniquely pinned from this source tree.** I did not
   trace the menu/`MS_OPNCOMP` form-dispatch. The §3.4 leg table is the **canonical reference** for
   `RATE CUT`; treat the observed §4.1 shape as the **migration target** and reconcile against a freshly
   re-saved desktop voucher before locking the web leg layout.
4. **Rate-par / per-gram assumption.** `RATE_CUT_DATA.RATE_PAR` is saved as `'G'` (`TR_VP.cs:5505-5858`),
   consistent with the per-gram (`14965=2.050×7300`) default branch. The `'1'` (per-10g) and `'K'`
   (per-kg) branches exist (§2) but are not exercised by the observed voucher, so their parity is
   asserted from code only.
5. **Direction/business semantics of the 850 net.** The voucher balances and the legs are certain; the
   *interpretation* (customer settling a prior balance vs. taking an advance) is inferred from the
   account roles (PURCHASE GOLD A/C, KASAR JAVK) and the rate-cut model, not from a traced running
   balance.
