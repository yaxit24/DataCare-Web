# X15 — E CRNT (E Credit Note) lifecycle contract

Written before the writer was implemented. Source: `unified/src/csharp/DataCareNext/` (decompiled, authoritative). Line numbers are 1-based.

## Entry and book

- Menu `E CrntNote` → `CurBookHelp("E CRNT")` (MDI_FORM.cs ~7955; DC_Main.cs 1489-1549) → `TR_SL_EBILL`. The form is shared with E INVOICE; E CRNT differs only through `MAIN_BOOK` in the posting SQL and `DocDtls.Typ="CRN"` in the IRN payload.
- The web requires exactly one active `BOOK_DATA` row with `MAIN_BOOK='E CRNT'`, `BOOK_INOUT='I'`, table blank or `SL_DATA`. Book codes are never hard-coded; 146 is only a UI preference.

## Save (BtnSave_Click 7366-7830)

Validation order (web message in brackets where it differs):

1. Licence expired — no web equivalent (not applicable).
2. `CASH_LIMIT > 0` and party ≠ `00020`: prior party cash (`LedrCash`) + cash > limit → desktop message. The web reuses `partyCashReceivedTx` (party / BOOK_DETL slot 2 cash account). **Open:** the full cross-year LedrCash aggregate defined in the Round 14 cash-guard review.
3. `EMP_CODE_MANDATORY='Y'` and no employee → "Please Select Employee Code and Try......".
4. Cheque amount without bank → "Please Select Bank Account And Try Because Chq Rec Amt <> 0......".
5. Card amount without card account → "Please Select Card Bank Account And Try Because Card Amt <> 0......".
6. New voucher and `CO_MAST.CO_TYPE='B'` → "You Cant Save This Voucher Becouse This Company Type is B......".
7. Date outside the fiscal year → fiscal-year error; lock date → existing period-lock error (web also checks the persisted date on edit).
8. Edit without rights → route policy / form rights (403).
9. Blank party → "Please Insert Party and try".
10. Header saved only when MRP total ≠ 0 or pcs+gross+line-net+kasar ≠ 0 (7496) [web refuses instead of writing lines without a header].

Numbering: `MAX(VCH_NO)+1` per CO/LC/YEAR/BOOK, `HD_VCH_NO` per CO/LC/BOOK (no year). The web allocates both under advisory locks, so the desktop "voucher number changed" retry is structural.

Write set (one transaction; delete then insert on create and edit):

| Table | Rows | Source |
| --- | --- | --- |
| SL_DATA | header; DISC/TAX_PRC/ADV/CRNT_ADJ/OLD/SCHM/HM/RTN = 0, TAX_CODE='', USER_UPDATE/DELETE='N', MOB_ENTRY_SAVE='Y', RATE_UNFIX='N', IRN_NO='N' (book 025 keeps IRN), ACK_DATE=VCH_DATE | 7515-7614 |
| SL_DETL | one per saved grid row (predicate 7614); SR_NO = grid row, OLD_SRNO stable row identity, TAG_NO 'N' when blank, TOT_AMT = NET_AMT = taxable, DISC = 0, ENTRY_TYPE 'O', BOOK_NAME 'E CRNT', VCH_TYPE = BOOK_SNAME, INOUT_TYPE = BOOK_INOUT | 7626-7707 |
| SL_IDTL | children re-inserted by parent OLD_SRNO | 7715-7776 |
| TEMP_BOOK_DATA | CO/LC/BOOK/HD_VCH_NO/BOOK_NAME | 7497-7510 |
| AC_DATA | `EInvoice_Ledr` E CRNT branch (below) | Ac_Ledr.cs 1837-1874 |
| ROJ_MEL_DATA | `EInvoice_Rojmel` E CRNT branch (below) | Ac_Rojmel.cs 863-888 |
| MAIN_STOCK | one per line: SR_NO 1, ISR_NO = line, TR_TYPE 'I', ITM_SIGN '+', ITM_QTY 1, ITM_WEST 0, KR_LBR/OTH/COST 0, ITM_DESC '', ITM_LOT '', ITM_DISC 0 | Ac_Stock.cs 383-392 |
| TAX_DATA | per line: SGST SR_NO=line, CGST 111+line (not IGST party), IGST SR_NO=line (IGST party); TRAN_TYPE 'S', TAX_SIGN '-', TAX_TYPE/TAX_PRC from the component row, PARTY_NAME from AC_MAST, R_CHARG 'N' | Ac_Tax.cs 267-276 |
| DM_DATA | none — `Dm_Sale_eInv_Detl` filters `MAIN_BOOK IN ('E INVOICE')` | Ac_Stock.cs 818 |

AC_DATA, base key `CO+LC+YEAR+BOOK+VCH`; BOOK_NAME/VCH_TYPE/DATA_TYPE from BOOK_DETL (SR_NO 1 unless stated):

| Suffix | AC_CODE | LD_CODE | CR | DR | Condition |
| --- | --- | --- | --- | --- | --- |
| 01 | party | slot 1 | TOT_AMT | 0 | TOT ≠ 0; PARTY_AC_CODE=party, LDR_NAME=party name |
| STR(SR)+02 | LDR_CODE or item GROUP_MAST.SALE_AC | party | 0 | line NET | BOOK_DATA.ITM_TYPE='A', NET ≠ 0 |
| 03 | TAX_MAST code '10' SR 0 TAX_AC | party | 0 | TAX_AMT | TAX ≠ 0 |
| 04/05/06 | TCS/TDS | | | | only when BOOK_INOUT='O' — never for an E CRNT book |
| 07/08 | party / BANK_AC | | 0 / CHQ | CHQ / 0 | CHQ ≠ 0 |
| 09/10 | party / CARD_AC | | 0 / CARD | CARD / 0 | CARD ≠ 0 |
| 11/12 | party / slot 2 | | 0 / CASH | CASH / 0 | CASH ≠ 0; 12 LDR_NAME=party name |
| 13/14 | party / slot 3 | | 0 / KASAR | KASAR / 0 | KASAR ≠ 0 |
| 16 | slot 4 | party | ROF<0 | ROF>0 | ROF ≠ 0 |

STR(n) is SQL Server's default width-10 right-aligned text. `07/09/11/13` carry PARTY_AC_CODE=party.

ROJ_MEL_DATA: `01`+STR(SR) DR line NET (sale/ledger account, item name, pcs/weights/rate/amounts; touch/west/fine 0); `02` party CR BILL_OS when > 0; `03` tax account DR TAX; `05` TDS CR (not reached, TDS never posts on an I book in the ledger but the rojmel row has no BOOK_INOUT filter — see below); `06` bank CR CHQ; `07` card CR CARD; `08` kasar CR KASAR with AC_NAME `KSR - <party>`. There is **no cash row and no round-off row** for E CRNT.

## Delete (BtnDelete_Click 7857-7898)

Lock date, IRN (`Len(IRN) > 10`), rights and confirmation, then DELETE_DATA audit (SR_NO 0, VCH_VAL 0, FINE_TYPE 'A') and removal of REMARK_DATA, TEMP_BOOK_DATA, MAIN_STOCK, AC_DATA, ROJ_MEL_DATA, SL_ORD_ADJ, TAX_DATA, DM_DATA, SL_DATA, SL_DETL, SL_IDTL, SL_PR_DETL. E_DATA is not deleted.

## Web adaptations (need business acceptance)

1. **Negative round-off.** Desktop row 16 writes `CR_AMT = ROF` (a negative number) when ROF < 0, leaving the voucher unbalanced by 2×|ROF|. The web writes `CR_AMT = |ROF|` so the ledger balances. Positive ROF is identical.
2. **IRN lock.** The desktop delete guard reads a textbox that is normally empty after reopen, and save has no IRN guard. The web blocks both edit and delete when `E_DATA` has a row or `SL_DATA.IRN_NO` is longer than 10 characters; cancel the IRN first.
3. **TCS/TDS.** TCS is refused (desktop ledger would be unbalanced on an I book). TDS is refused for an I book because the desktop posts its rojmel row but not its ledger pair; accepting it would change BILL_OS without a ledger effect.
4. **Tagged lines.** A line with a tag number is refused in this slice; tag stock return needs the tag-identity work in X18/X19.
5. **Empty header.** Refused instead of writing SL_DETL/postings without a SL_DATA header.
6. **Tax master '10'.** When TAX_AMT ≠ 0 the web requires `TAX_MAST` code 10 / SR_NO 0 with an account; the desktop would silently omit the tax ledger row and unbalance the voucher.

## Calculation

Implemented in `web/packages/core/src/eBillCalc.ts` with independent hand-derived vectors in `web/packages/core/test/fixtures/eBillCalc.vectors.json`. Not yet compared to a captured desktop run.

---

# E INVOICE mode of the same form (continuation, 29 September 2026)

Menu `E Invoice` (MDI_FORM.cs 7942-7953) opens the same `TR_SL_EBILL` through `CurBookHelp("E INVOICE")`. The form has no E INVOICE-specific code apart from `JsonGen` (`Typ="INV"`); every difference is in the posting SQL. The book must be `MAIN_BOOK='E INVOICE'`, and the TCS/TDS ledger rows exist only for `BOOK_INOUT='O'`, so the web requires an outward book.

## Posting differences (E INVOICE orientation)

| Table | E INVOICE | Source |
| --- | --- | --- |
| AC_DATA | every CR/DR mirrored: 01 party DR TOT; 02 sale/ledger CR line NET; 03 tax '10' CR; 04 TCS account CR TCS; 05 party CR TDS (LD TDS account, no PARTY_AC_CODE); 06 TDS account DR TDS; 07/09/11/13 party CR, 08/10/12/14 account DR; **15** slot 5 round-off CR ROF>0 / DR ROF<0 (row 16 is E CRNT only) | Ac_Ledr.cs 1839-1869 |
| ROJ_MEL_DATA | 01 CR line NET; 02 party DR BILL_OS; 03 tax CR; 04 TCS CR (AC_NAME = tax account name, no book-direction filter); 05 TDS DR, AC_NAME `TDS - <party>`; 06 bank DR; 07 card DR; 08 kasar DR; **09** slot 5 and **10** slot 4 round-off rows on the party (`ROF - <party>`), each written when its slot exists | Ac_Rojmel.cs 863-886 |
| MAIN_STOCK | TR_TYPE 'S', ITM_SIGN '-' (no availability check anywhere in the form) | Ac_Stock.cs 383-391 |
| TAX_DATA | TAX_SIGN '+' | Ac_Tax.cs 269-273 |
| DM_DATA | one row per SL_IDTL component whose component item has `OTH_DETL_POSTING='Y'`: MAIN_SRNO 1, SR_NO = parent OLD_SRNO, ENTRY_TYPE 'S', BOOK_NAME = BOOK_SNAME, DM_LOT_NO '', DM_SIGN '-', DM_RATE/AMT = IT_RATE/AMT, EMP_CODE '', TAG_NO 'N' when blank, MAIN_IT_CODE/TBL_CODE from the parent line, INOUT_TYPE 'S' | Ac_Stock.cs 818-822 |

## TCS and TDS (BILL_TOTAL 9062-9178, tAcCode_KeyDown 8349-8453, TEXT_ENTRY_2 8818-8949)

- `AcTcsAmt` = Σ AC_DATA.DR_AMT for the party, company, `DATA_TYPE='A'`, `VCH_DATE >= year opening` (no branch/book/year filter), read when the party is chosen; party `00045` keeps the previous value.
- **New voucher.** If `AcTcsAmt + NET + IGST − CGST − SGST > 5,000,000` (the source subtracts CGST/SGST; kept literally) and the operator has not chosen code `00`, TCS takes `TAX_MAST` code `20` and `Math.Round((NET+IGST+CGST+SGST − (5,000,000 − AcTcsAmt)) × % / 100, 0)` while headroom remains, otherwise the full base. Below the threshold an operator-chosen code keeps the operator-typed amount.
- **Saved voucher.** TCS is recomputed on the full base, `Math.Round((NET+taxes) × % / 100, 0)`; the desktop resets its comparison percent on load, so reopening a threshold-excess voucher recalculates it this way.
- TDS = `Math.Round(NET × % / 100, 0)` from a `TAX_MAST` SR_NO 0 code (lookup offers `25` and `00`). Total = Σ line net + TCS; round-off excludes TCS; Bill OS = Total − TDS − cash − cheque − card − kasar.

## REMARK_DATA (Ac_Tax.Vch_Remark, mode 0)

After save: delete REMARK_DATA for the voucher, then insert SR_NO 0 with AC_NAME from AC_MAST, MAIN_BOOK = BOOK_DATA.MAIN_BOOK and VCH_REMARK = VCH_DESC, only when VCH_DESC is not blank and BOOK_DATA.BOOK_TBL_NAME is set. Applies to both modes. The web writes it inside the save transaction (the desktop runs it after commit) and does not reproduce its global `UPDATE BAR_DATA SET AC_CODE=''` side effect.

## Additional web adaptations

7. **Negative round-off (E INVOICE).** Row 15 debits `|ROF|` instead of a negative debit; rojmel rows 09/10 keep the desktop's signed values.
8. **TCS/TDS** are accepted only on outward E INVOICE books; E CRNT keeps adaptation 3.

## Hand-derived E INVOICE vectors

| Case | Inputs | Expected |
| --- | --- | --- |
| EI-1 | L01 + L02 (above), TDS 1%, cash 10,000, no prior debits | NET 65,954; GST 1,978.62; total 67,933; ROF 0.38; TDS round(659.54)=660; Bill OS 57,273; ledger DR 78,593 = CR 78,593 |
| EI-2 | prior party debits 4,990,000; one MRP 50,000 line, GST 3%, TCS code 20 at 0.1% | threshold 5,038,500; TCS round((51,500 − 10,000) × 0.001) = round(41.5) = 42; total 51,542; ROF 0 |
| EI-2 edit | same voucher reopened and saved | TCS round(51,500 × 0.001) = round(51.5) = 52; total 51,552 |
| EI-3 | MRP 1,010 line | ROF −0.30: ledger row 15 DR 0.30; rojmel 09 DR −0.30, rojmel 10 CR −0.30 |
