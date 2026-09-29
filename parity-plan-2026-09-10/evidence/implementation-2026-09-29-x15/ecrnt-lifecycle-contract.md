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

Implemented in `web/packages/core/src/eCreditNoteCalc.ts` with independent hand-derived vectors in `web/packages/core/test/fixtures/eCreditNoteCalc.vectors.json`. Not yet compared to a captured desktop run.
