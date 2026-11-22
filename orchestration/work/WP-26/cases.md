# WP-26 frozen case list: Sales Invoice residuals (TR_SALE)

Source: `orchestration/work/WP-26/study.md`, the desktop form `unified/src/csharp/DataCareNext/TR_SALE.cs` (authority), the
role contract `orchestration/roles/cases.md`, playbook kinds T01 to T18 (`docs/master-parity-plan-2026-09-29/04-verification-playbook.md`).
Module id prefix: `sales-invoice.`. Existing ids in `web/apps/web/test/features/modules/salesInvoice.mjs` are reused unchanged and
marked **reused**; their status stays as in that file. Every other case is new and **fails today** because of the gap named in it
(study gap numbers G1 to G13 below are the study's `Gaps` numbers, not the master-plan G82/G83 ids; those are named in full).

All arithmetic uses these fixed inputs:

- Line A (existing fixture `LINE_A`): gold, net 10.000, touch 91.6, rate 6123.45, making 237.5 per gram. Metal 10.000 x 6123.45 = 61,234.50;
  labour 10.000 x 237.5 = 2,375.00; net 63,609.50; tax 3% = 1,908.285 -> 1,908.29; total 65,517.79 (existing constant `ONE_LINE`).
- Rate master today: `FINE_GL_RATE` 60,000.00 per 10 g, `FINE_SL_RATE` 80,000.00 per kg. The desktop turns them into per gram rates:
  TR_SALE.cs:20833 {{Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 10.0}} so
  `ToDayGlRate` = 60,000.00 / 10 = 6,000.00; TR_SALE.cs:20854 {{Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 1000.0}}
  so `ToDaySlRate` = 80,000.00 / 1000 = 80.00.

## Decisions (architect, 2026-11-22, owner may override)

Standing rule: the desktop first; the web adds only what a hosted multi-user service needs to be safe and correct. Never ported: string-built
SQL, plaintext secrets, unscoped deletes, partial writes, per-installation `SSRegSrNo` branches.

| # | Study open question | Decision (architect, 2026-11-22, owner may override) | Grounds |
|---|---|---|---|
| D1 | Do UPI rows have to sum to `UPI_AMT`? | `UPI_AMT` is derived from the rows, never typed; a request whose `upiAmount` differs from the row sum by more than 0.005 is refused with 400 and nothing is written. | TR_SALE.cs:6867 {{MSG2_TOTAL[12, 1] = Strings.Format((object)num2, "0.00");}} (the desktop total is the sum, TR_SALE.cs:6862 {{(Operators.CompareString(MSG_UPI[i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[i, 5]) != 0.0)}}); the refusal is the hosted-service safety add (never trust a second figure). |
| D2 | `ORD_SIGN` `'-'` (TR_SALE) versus `'C'` (web order code) | The sale writes the desktop shape: `ORD_SIGN '-'`, `ORD_AMT`, `PAID_AMT 0`, `ENTRY_TYPE 'S'`, many rows. The reader accepts both `'-'` and `'C'` rows. The order-cancel screen keeps its own value unchanged (no rewrite of its rows). | TR_SALE.cs:15715 {{dataRow8["ORD_SIGN"] = "-";}}, TR_SALE.cs:15716 {{dataRow8["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);}}, TR_SALE.cs:15718 {{dataRow8["PAID_AMT"] = 0;}} |
| D3 | Blocked case 1, `refusal.negative-weight` | **Accept.** No desktop message exists for a negative weight, so the web must not invent one. The case becomes executable and asserts "saved". | TR_SALE.cs:14870 {{private void TR_SALE_KeyPress(object sender, KeyPressEventArgs e)}} drops only NUL and apostrophe: TR_SALE.cs:14879 {{num == 39}}; the message list in the study has no weight text. |
| D4 | Blocked case 2, `config.setting-change` | Executable. The fixture pack (company with `CO_SET.SL_AMT_TYPE = 'F'`) is part of this work package's test data, not an outside dependency. | TR_SALE.cs:9161 {{mSG[mSG.Row, 21] = DC_Main.MsSlAmtType;}} (new line takes the setting), reopen reads the stored value, TR_SALE.cs:14570 {{mSG[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);}} (reopen shows the stored value). |
| D5 | Blocked case 3 (study could not find it) | Identified as the master plan's "Sales Apr No import" (WP-01 row, `docs/parity/LITE-MASTER-PLAN.md` line 309: "3 cases blocked on WP-04 follow-up and a Sales Apr No import"). Case `sales-invoice.source.approval-no-import` is `blocked`, with the exact question in its body. The two other blocked ids stay `refusal.negative-weight` and `config.setting-change`, both unblocked by D3 and D4. | master plan line 309 |
| D6 | Crystal print variants | Web prints are HTML/PDF, not Crystal. The web offers the `PRINT_MAST` file names for the company, and each name maps to a named web template; the choice order is the desktop's (HUID box, then book 099, then the chosen file). A file name with no web template falls back to the default template and is shown as such. The `VK050NEVK` and `HM249NEHP` branches are per-installation and are not ported. Pixel layout is out of scope (Not covered). | TR_SALE.cs:16484 {{RtlHuidPrint.RPT}}, TR_SALE.cs:16489 {{SalesQuotation.RPT}}, TR_SALE.cs:16494 {{cboPrintfile.Text}} |
| D7 | Tab order and defaults of the old-metal, UPI, credit-note grids | Not decided from the layout file; no case asserts tab order. Cases assert values only. | study Open questions |
| D8 | Desktop sets `DATA_TRFR='N'` and `USER_UPDATE='N'` on every save | A changed save writes `N` for both (the desktop rule). An **unchanged** save keeps the stored values (the lossless rule; the web must not mark an untouched voucher for re-transfer). | TR_SALE.cs:15332 {{dataRow3["DATA_TRFR"] = "N";}}, TR_SALE.cs:15342 {{dataRow3["USER_UPDATE"] = "N";}} |
| D9 | Derived `CASH_AMT` branch | The branch is keyed on the literal party code `"00045"`, which is per-company data, not a rule. Not ported (case N/A). | TR_SALE.cs:15240 {{if (Conversion.Val(MSG2_TOTAL[9, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]) < Conversion.Val(MSG2_TOTAL[12, 3]))}} |
| D10 | Approval-tag reset on grid-row delete runs outside the save | Not ported. In the web a deleted row releases its approval tag only when the voucher is saved (one transaction). | TR_SALE.cs:11969 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} |

Corrections to the study found while writing the cases (each backed by a quoted line below):

- Header `OLD_GL` / `OLD_SL` are the sums of the **net weight** (column 6), not of the fine weight:
  TR_SALE.cs:19345 {{mSG2_TOTAL[9, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");}}.
  The header total runs only for a metal book: TR_SALE.cs:19333 {{if (Operators.CompareString(DC_Main.MCo_BookType, "M", false) == 0)}}.
- F1 in the UPI grid is the **UPI type add** at column 3, not an account help: TR_SALE.cs:6901 {{if (mSG_UPI.Col == 3)}} then TR_SALE.cs:6903 {{UpiTypeAdd = true;}}.
- "Please Save This Voucher Then Effect...." is shown after **deleting a UPI row (Ctrl+D)**; the row is cleared on the grid and the total recomputed, and the
  database changes only at Save: TR_SALE.cs:6921 {{Please Save This Voucher Then Effect....}}.
- The old-metal touch back-calculation (OG/OS) overwrites a touch typed on the row whenever the amount cell is non-zero (so a plain old-gold item must not use code `OG` or `OS`).

## Cases

### sales-invoice.entry.defaults   (T01 Entry/defaults)   **reused**
Layer: browser
Steps: as in `salesInvoice.mjs` (open `/txn/sales`, provisioned SALES book selected).
Expected: unchanged from the module.
Status: executable

### sales-invoice.entry.print-file-list-and-default   (T01 Entry/defaults)
Layer: browser
Steps: 1. Seed `PRINT_MAST` for the test company with `PRINT_TYPE` = the SALES main book, `BOOK_TYPE` = the book's type, files `SalesBillA4` (`PRINT_SET_A='N'`), `SalesBillGst` (`PRINT_SET_A='Y'`), plus a row for another company and another book type. 2. Open `/txn/sales`. 3. Read the print-file list and its selected value.
Expected: the list is ordered by file name and holds exactly `` (blank), `SalesBillA4`, `SalesBillGst` (the other company's and other book type's rows are absent; G10). `SalesBillGst` is selected because its `PRINT_SET_A` is `Y`. Rule: TR_SALE.cs:13933 {{SELECT * FROM PRINT_MAST WHERE CO_CODE = '}} filtered by `PRINT_TYPE = FormMainBook` and `BOOK_TYPE = FormBookType` and ordered `PRINT_FILE`. Arithmetic: 3 rows seeded for the company and book, 2 listed besides the blank entry the desktop adds first.
Status: executable

### sales-invoice.entry.print-file-company-fallback   (T01 Entry/defaults)
Layer: database
Steps: 1. Test company with **no** `PRINT_MAST` rows for the book; company "01" holds `SalesBillA4`. 2. `GET` the print-file list for the sales screen.
Expected: the list is company "01"'s: `SalesBillA4` (G10). Rule: the study records "falling back to company "01"" for the list read at TR_SALE.cs:13933 {{SELECT * FROM PRINT_MAST WHERE CO_CODE = '}}. The fallback read is scoped to company "01" rows of the same tenant only (decision D6: no cross-tenant read).
Status: executable

### sales-invoice.entry.quotation-book-099-offers-sales-quotation   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the sales screen on a book whose code is `099`. 2. Open the print choice.
Expected: the template offered and used is `SalesQuotation` regardless of the file list: TR_SALE.cs:16489 {{SalesQuotation.RPT}} (G10). The file list choice is ignored for book `099`.
Status: executable

### sales-invoice.lookup.code-enter-at-once   (T04 Lookup)   **reused**
Layer: browser
Steps/Expected/Status: unchanged from the module. Also reused for T04: `lookup.lower-case-code`, `lookup.pick-over-typed-code`, `refusal.unknown-item` (listed under their kinds).
Status: executable

### sales-invoice.lookup.quotation-import-picks-account-quotations   (T04 Lookup)
Layer: browser
Steps: 1. Seed two sales quotations for party P1 (book `099`: Q1 with 1 line, Q2 with 2 lines) and one for P2. 2. New sale for P1, press the quotation button ("Q"). 3. Cancel the first prompt, press "Q" again, accept, choose Q2.
Expected: prompt text for the account import: TR_SALE.cs:21029 {{All Quatation Import From  }} (spelling kept) followed by the account code; the pick list holds only P1's quotations (Q1, Q2); choosing Q2 fills 2 lines (G7). Cancel leaves the grid empty (0 lines).
Status: executable

### sales-invoice.formula.single-line   (T03 Formula sequence)   **reused**
Layer: browser. Unchanged from the module (net 63,609.5, fine 9.16). Status: executable

### sales-invoice.oldmetal.fine-from-touch   (T03 Formula sequence)
Layer: unit
Steps: kernel vector in `packages/core/src/oldGold.ts`: net 10.000, touch 91.6, no rate.
Expected: fine 9.160. Rule: TR_SALE.cs:7905 {{Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0}}; arithmetic 10.000 x 91.6 / 100 = 9.160, shown with three decimals (`"0.000"`). With touch blank the fine is the net: TR_SALE.cs:7909 {{mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");}} so net 10.000 gives fine 10.000. (G8)
Status: executable

### sales-invoice.oldmetal.amount-net-wise   (T03 Formula sequence)
Layer: browser
Steps: old-metal row, item code `OLDG` (type G, not `OG`), net 12.500, touch 91.6, rate 6,000, rate type `N`.
Expected: fine = 12.500 x 91.6 / 100 = 11.450; amount (rate type N uses the net, col 6) = Round(12.500 x 6,000, 0) = 75,000.00. Rule: TR_SALE.cs:7959 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0)}}. Header OLD_GL_AMT after the row = 75,000.00. (G8)
Status: executable

### sales-invoice.oldmetal.amount-fine-wise   (T03 Formula sequence)
Layer: browser
Steps: same row, rate type `F`.
Expected: amount (rate type F uses the fine, col 8) = Round(11.450 x 6,000, 0) = Round(68,700.000, 0) = 68,700.00. Rule: TR_SALE.cs:7963 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0)}}. (G8)
Status: executable

### sales-invoice.oldmetal.amount-half-to-even   (T03 Formula sequence)
Layer: unit
Steps: net 5.000, no touch, rate 100.5, rate type `N`.
Expected: 5.000 x 100.5 = 502.5 exactly, `Math.Round` is half to even so the amount is 502.00 (not 503.00). Rule: TR_SALE.cs:7959 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0)}}. (G8)
Status: executable

### sales-invoice.oldmetal.conversion-weight-above-100   (T03 Formula sequence)
Layer: unit
Steps: net 10.000, touch 91.6, Con% 120, rate 6,000, rate type `N`.
Expected: fine 9.160; conversion weight = Round(9.160 x 120 / 100, 3) = Round(10.992, 3) = 10.992; amount = Round(10.992 x 6,000, 0) = Round(65,952.000, 0) = 65,952.00. Rules: TR_SALE.cs:7917 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) / 100.0, 3)}}, TR_SALE.cs:7921 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0)}}. The `KJ001NEKJ` branch is not ported. (G8)
Status: executable

### sales-invoice.oldmetal.touch-from-amount-gold   (T03 Formula sequence)
Layer: browser
Steps: old-metal row, item code `OG`, rate type `N`, net 10.000, rate left blank, amount typed 54,000.00; rate master as above (ToDayGlRate 6,000.00).
Expected: rate shown = 54,000.00 / 10.000 = 5,400.00 (TR_SALE.cs:7970 {{Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[CRow, 6])}}); touch = 54,000.00 / 6,000.00 / 10.000 x 100 = 90.00 (TR_SALE.cs:7983 {{Conversion.Val(mSG_OLD[CRow, 13]) / ToDayGlRate / Conversion.Val(mSG_OLD[CRow, 6]) * 100.0}}, guard TR_SALE.cs:7981 {{(Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OG", false) == 0) & (ToDayGlRate != 0.0)}}); fine = 10.000 x 90.00 / 100 = 9.000 (TR_SALE.cs:7991 {{Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0}}). Today the web leaves touch as typed (blank) and fine 10.000 (G8b).
Status: executable

### sales-invoice.oldmetal.touch-from-amount-silver   (T03 Formula sequence)
Layer: browser
Steps: item code `OS`, rate type `N`, net 100.000, amount typed 7,200.00; ToDaySlRate 80.00.
Expected: rate = 7,200.00 / 100.000 = 72.00; touch = 7,200.00 / 80.00 / 100.000 x 100 = 90.00 (TR_SALE.cs:7987 {{Conversion.Val(mSG_OLD[CRow, 13]) / ToDaySlRate / Conversion.Val(mSG_OLD[CRow, 6]) * 100.0}}); fine = 100.000 x 90.00 / 100 = 90.000. (G8b)
Status: executable

### sales-invoice.oldmetal.touch-from-amount-needs-today-rate   (T03 Formula sequence)
Layer: unit
Steps: same as the gold case with no `RATE_MAST` row on or before the voucher date (`ToDayGlRate` = 0).
Expected: touch is not changed (stays as typed, blank); fine = net = 10.000; the guard is `ToDayGlRate != 0.0` at TR_SALE.cs:7981 {{(Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OG", false) == 0) & (ToDayGlRate != 0.0)}}. (G8b)
Status: executable

### sales-invoice.oldmetal.header-gold-silver-split   (T03 Formula sequence)
Layer: browser
Steps: book type `M`. Three old-metal rows: R1 item type G, net 10.000, amount 54,000.00; R2 item type S, net 100.000, amount 7,200.00; R3 item type P (neither G nor S), net 5.000, rate 200, type N (amount 5.000 x 200 = 1,000.00). Save and read `SL_DATA`.
Expected: gold = rows with type `G`: OLD_GL = 10.000, OLD_GL_AMT = 54,000.00. Silver = every row whose type is **not** G: OLD_SL = 100.000 + 5.000 = 105.000, OLD_SL_AMT = 7,200.00 + 1,000.00 = 8,200.00. Rules: TR_SALE.cs:19343 {{if (Operators.CompareString(MSG_OLD[DC_Main.M, 14], "G", false) == 0)}}, TR_SALE.cs:19346 {{mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 13])), "0.00");}}, TR_SALE.cs:19348 {{if (Operators.CompareString(MSG_OLD[DC_Main.M, 14], "G", false) != 0)}}, TR_SALE.cs:19350 {{mSG2_TOTAL[10, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[10, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");}}, TR_SALE.cs:19351 {{mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[10, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 13])), "0.00");}}. Today R3 is dropped or counted as gold (G8d).
Status: executable

### sales-invoice.oldmetal.header-totals-only-for-metal-book   (T03 Formula sequence)
Layer: database
Steps: save the same three rows on a book whose type is not `M`.
Expected: the header old-metal totals are left blank (0.000 / 0.00): TR_SALE.cs:19333 {{if (Operators.CompareString(DC_Main.MCo_BookType, "M", false) == 0)}}; `SL_PR_DETL` rows are still written (3 rows). (G83, G8)
Status: executable

### sales-invoice.oldmetal.one-figure-detail-header-ledger   (T03 Formula sequence)
Layer: database
Steps: Line A with one old-gold row, item `OLDG`, net 10.000, rate 5,400 type `N` (amount Round(10.000 x 5,400, 0) = 54,000.00); cash 11,517.79.
Expected: `SL_PR_DETL.NET_AMT` = 54,000.00 (TR_SALE.cs:15664 {{dataRow7["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 13]);}}), `SL_DATA.OLD_GL_AMT` = 54,000.00 (TR_SALE.cs:15231 {{dataRow3["OLD_GL_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);}}), the old-gold ledger line = 54,000.00, bill total 65,517.79, `BILL_OS` = 65,517.79 - 54,000.00 - 11,517.79 = 0.00 (TR_SALE.cs:15256 {{dataRow3["BILL_OS"] = Conversion.Val(MSG2_TOTAL[15, 3]);}}). All three figures equal. (G83, existing one-figure rule must stay green)
Status: executable

### sales-invoice.oldmetal.rate-type-refusal-text   (T03 Formula sequence)
Layer: unit
Steps: see `sales-invoice.refusal.oldmetal-rate-type` (T06); the kernel rejects any rate type other than N or F.
Expected: the kernel returns the error text below. See the T06 case for the quoted rule.
Status: executable

### sales-invoice.tender.cash-derived-cash-party-branch   (T03 Formula sequence)
Layer: unit
Steps: party code `00045`, old gold 54,000.00, cash cell 70,000.00.
Expected: N/A. The derived `CASH_AMT` formulas are inside a branch for the literal account code `00045`: TR_SALE.cs:15240 {{if (Conversion.Val(MSG2_TOTAL[9, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]) < Conversion.Val(MSG2_TOTAL[12, 3]))}}. A literal account code is company data, not a rule (decision D9, architect, 2026-11-22, owner may override). For every other party the desktop writes the cash cell: TR_SALE.cs:15251 {{dataRow3["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[12, 3]);}}; that is covered by `create.single-line-cash`.
Status: N/A: the branch is keyed on a literal party code `00045` (per-company data), not ported.

### sales-invoice.tender.upi-total-is-sum-of-rows   (T03 Formula sequence)
Layer: browser
Steps: UPI rows: row 1 account U1 amount 1,000.00, row 2 account U2 amount 2,500.50, row 3 empty account with amount 99.00.
Expected: UPI total = 1,000.00 + 2,500.50 = 3,500.50; row 3 is ignored because its account is blank. Rule: TR_SALE.cs:6862 {{(Operators.CompareString(MSG_UPI[i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[i, 5]) != 0.0)}} and TR_SALE.cs:6867 {{MSG2_TOTAL[12, 1] = Strings.Format((object)num2, "0.00");}}. The bill recomputes at once (`BILL_TOTAL()` follows). (G4, D1)
Status: executable

### sales-invoice.field.upi-row-route   (T02 Field route)
Layer: browser
Steps: change one UPI row amount from 1,000.00 to 1,200.00 (row 1 of the two-row bill), save, reopen, run the sales register.
Expected: `UPI_DATA.UPI_AMT` of row 1 = 1,200.00 (TR_SALE.cs:15869 {{dataRow12["UPI_AMT"] = Conversion.Val(MSG_UPI[DC_Main.i, 5]);}}); `SL_DATA.UPI_AMT` = 1,200.00 + 2,500.50 = 3,700.50 (TR_SALE.cs:15253 {{dataRow3["UPI_AMT"] = Conversion.Val(MSG2_TOTAL[12, 1]);}}); reopen shows 1,200.00 and 3,700.50 (TR_SALE.cs:14291 {{RsData.Rows[0]["UPI_AMT"]}}); register UPI column 3,700.50. No dead field. (G4)
Status: executable

### sales-invoice.field.credit-note-route   (T02 Field route)
Layer: browser
Steps: credit-note grid row: note no CN1, amount 4,000.00; save; reopen.
Expected: `SL_DATA.CRNT_ADJ_AMT` = 4,000.00 (TR_SALE.cs:15230 {{dataRow3["CRNT_ADJ_AMT"] = Conversion.Val(MSG2_TOTAL[8, 1]);}}); one `CRNT_DATA` row, `CRNT_AMT` = 4,000.00 (TR_SALE.cs:15911 {{dataRow13["CRNT_AMT"] = Conversion.Val(mSG_CRNT[DC_Main.i, 2]);}}) with `CRNT_NO` CN1 (TR_SALE.cs:15906 {{dataRow13["CRNT_NO"] = mSG_CRNT[DC_Main.i, 1];}}); reopen shows the row; bill outstanding on screen includes the 4,000.00 (G5).
Status: executable

### sales-invoice.field.old-metal-pr-cost-route   (T02 Field route)
Layer: database
Steps: save an old-metal row whose `PR_COST` is 52,000.00 (sent by the desktop-shaped request), reopen, save unchanged.
Expected: `SL_PR_DETL.PR_COST` = 52,000.00 after reopen and after the unchanged save (TR_SALE.cs:15665 {{dataRow7["PR_COST"] = Conversion.Val(mSG_OLD[DC_Main.i, 17]);}}, read at TR_SALE.cs:14724 {{RsOldDetl.Rows[DC_Main.i]["PR_COST"]}}). `PR_COST` is **not recomputed** by the web (the desktop computes it only under `KJ001NEKJ`, TR_SALE.cs:7996 {{mSG_OLD[mSG_OLD.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");}}, not ported). (G3)
Status: executable

### sales-invoice.field.header-account-overrides-route   (T02 Field route)
Layer: browser
Steps: set the member-commission account to M1, tick "without commission bill" and "rate unfixed", pick tax code T3; save; reopen.
Expected: `MEMB_COM_AC_CODE` = M1 (TR_SALE.cs:15264 {{dataRow3["MEMB_COM_AC_CODE"] = tAcMembCode.Text;}}), `WHOUT_COMM_BILL` = Y (TR_SALE.cs:15267 {{dataRow3["WHOUT_COMM_BILL"]}}), `RATE_UNFIX` = `Y` (TR_SALE.cs:15347 {{dataRow3["RATE_UNFIX"] = "Y";}}), `TAX_CODE` = T3 (TR_SALE.cs:15203 {{dataRow3["TAX_CODE"] = MSG2_TOTAL[2, 4];}}); on reopen all four controls show M1, ticked, ticked, T3 (TR_SALE.cs:14365 {{RsData.Rows[0]["MEMB_COM_AC_CODE"]}}, TR_SALE.cs:14398 {{chkRateUnFix.Checked = true}}, TR_SALE.cs:14404 {{RsData.Rows[0]["WHOUT_COMM_BILL"]}}). (G1)
Status: executable

### sales-invoice.field.order-advance-route   (T02 Field route)
Layer: browser
Steps: one order row: order no ORD7, amount 5,000.00; save; reopen; run the order balance.
Expected: `SL_ORD_ADJ` one row, `ORD_AMT` 5,000.00, `ORD_SIGN` `-`, `PAID_AMT` 0, `ENTRY_TYPE` `S`; `SL_DATA.ADV_AMT` = 5,000.00 (TR_SALE.cs:15229 {{dataRow3["ADV_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);}}); reopen shows the order row and 5,000.00 (TR_SALE.cs:14283 {{MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADV_AMT"]), "0.00");}}). (G6, D2)
Status: executable

### sales-invoice.children.upi-two-rows-dissimilar   (T05 Children)
Layer: browser
Steps: invoice X with UPI rows (U1 PhonePe id a@b 1,000.00; U2 Gpay id c@d 2,500.50); invoice Y with one row (U3 Paytm id e@f 700.00). Delete row 1 of X (Ctrl+D, confirm), save X. Reorder is not offered, so only delete is exercised.
Expected: X after save has one `UPI_DATA` row (U2, `SR_NO` 1, `UPI_AMT` 2,500.50) and `SL_DATA.UPI_AMT` = 2,500.50; Y still has U3 only with 700.00 (no movement across vouchers). Rules: TR_SALE.cs:15844 {{DELETE FROM UPI_DATA WHERE}} then rows renumbered `SR_NO` = grid index: TR_SALE.cs:15865 {{dataRow12["UPI_AC_CODE"] = MSG_UPI[DC_Main.i, 1];}}, TR_SALE.cs:15866 {{dataRow12["UPI_AC_NAME"] = MSG_UPI[DC_Main.i, 2];}}, TR_SALE.cs:15867 {{dataRow12["UPI_TYPE"] = MSG_UPI[DC_Main.i, 3];}}, TR_SALE.cs:15868 {{dataRow12["UPI_ID"] = MSG_UPI[DC_Main.i, 4];}}. The delete is scoped to the one voucher (company, location, year, book, voucher number; never an unscoped delete). (G4)
Status: executable

### sales-invoice.children.upi-row-delete-takes-effect-on-save   (T05 Children)
Layer: browser
Steps: reopen X (two rows), Ctrl+D on row 2, confirm, **do not save**, read `UPI_DATA` from the database, then save.
Expected: after the confirm the screen shows the row cleared and the total 1,000.00 (2,500.50 removed), the message "Please Save This Voucher Then Effect....", and the database still holds 2 rows and `UPI_AMT` 3,500.50; after Save 1 row and 1,000.00. Rule: TR_SALE.cs:6921 {{Please Save This Voucher Then Effect....}} and TR_SALE.cs:6907 {{(int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0)))}}. (G4)
Status: executable

### sales-invoice.children.order-advance-two-orders   (T05 Children)
Layer: database
Steps: invoice with two order rows O1 5,000.00 and O2 3,000.00; invoice Z with one order row O3 2,000.00; edit X removing O2.
Expected: X has `SL_ORD_ADJ` rows `SR_NO` 1 (O1, 5,000.00); `ADV_AMT` 5,000.00 (before the edit 5,000.00 + 3,000.00 = 8,000.00); Z unchanged (2,000.00). Rows are written one per grid row with a non-zero amount: TR_SALE.cs:15686 {{if (Conversion.Val(MSG2_TOTAL[8, 3]) != 0.0)}}, TR_SALE.cs:15709 {{dataRow8["ORD_HD_VCH_NO"] = mSG_ORD[DC_Main.i, 7];}}, TR_SALE.cs:15714 {{dataRow8["ORD_AC_CODE"] = mSG_ORD[DC_Main.i, 6];}}. (G6)
Status: executable

### sales-invoice.children.credit-note-two-rows   (T05 Children)
Layer: database
Steps: two credit-note rows CN1 4,000.00 and CN2 1,500.00; second invoice with CN3 800.00; edit the first removing CN2.
Expected: first invoice: `CRNT_ADJ_AMT` 5,500.00 before (4,000.00 + 1,500.00) and 4,000.00 after; one `CRNT_DATA` row; second invoice keeps CN3 800.00. Rows only when the cell is non-zero: TR_SALE.cs:15878 {{if (Conversion.Val(MSG2_TOTAL[8, 1]) != 0.0)}}; the old rows are deleted first: TR_SALE.cs:15876 {{Delete FROM CRNT_DATA WHERE}}. (G5)
Status: executable

### sales-invoice.children.stone-detail-kept   (T05 Children)
Layer: database
Steps: voucher V1 with 2 stone rows on line 1 (`SL_IDTL`), voucher V2 with 1 stone row on line 1; reopen V1, save unchanged.
Expected: V1 still has 2 `SL_IDTL` rows with identical columns; V2 has 1. The desktop reloads them: TR_SALE.cs:14670 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST}} and rewrites from the grid: TR_SALE.cs:15546 {{SELECT * FROM SL_IDTL WHERE CO_CODE = '}}. Today the edit deletes `SL_IDTL` (TR_SALE.cs:15169 {{DELETE FROM SL_IDTL WHERE CO_CODE = '}}) and the web writes none back. (G2)
Status: executable

### sales-invoice.refusal.oldmetal-rate-type   (T06 Required/invalid)
Layer: browser
Steps: old-metal row, rate type cell: type `X`, press Enter; then type `n` and `F`.
Expected: for `X` the message "Please Slelect Rate type = N - Net Wise Or F - Fine Wise" (spelling kept) is shown and the cell editor stays on the same cell; nothing is committed. Rule: TR_SALE.cs:7667 {{if ((Operators.CompareString(TEXT_OLD.Text, "N", false) != 0) & (Operators.CompareString(TEXT_OLD.Text, "F", false) != 0))}}, message TR_SALE.cs:7669 {{Please Slelect Rate type = N - Net Wise Or F - Fine Wise}}. The compare is case-sensitive as written (`CompareString(..., false)` is a binary compare), so lower-case `n` is refused as well. Server side: a request with a row rate type other than N or F returns 400 with the same text and writes nothing. (G8a)
Status: executable

### sales-invoice.refusal.duplicate-order   (T06 Required/invalid)
Layer: browser
Steps: order grid: row 1 holds order ORD7 (book B1); on row 2 pick order ORD7 of the same book again.
Expected: message "Duplicate Order No", the cell is cleared, focus stays on the cell; the identity compared is book plus order number, so ORD7 of a different book is accepted. Rule: TR_SALE.cs:7326 {{Duplicate Order No}} guarded by TR_SALE.cs:7324 {{if ((Operators.CompareString(mSG_ORD[DC_Main.X, 5] + mSG_ORD[DC_Main.X, 1], DC_Main.ColValue[7] + TEXT_ORD.Text, false) == 0) & (mSG_ORD.Row != DC_Main.X))}}. Server: a request with the same book+order twice returns 400 and writes nothing. (G6)
Status: executable

### sales-invoice.refusal.upi-amount-mismatch   (T06 Required/invalid)
Layer: database
Steps: `POST` a sale with UPI rows summing 3,500.50 and `upiAmount` 3,000.00.
Expected: HTTP 400 naming `upiAmount`, no `SL_DATA`, `UPI_DATA`, stock or ledger row written (0 rows in each). The desktop has no second figure (TR_SALE.cs:6867 {{MSG2_TOTAL[12, 1] = Strings.Format((object)num2, "0.00");}}); decision D1 (architect, 2026-11-22, owner may override). (G4)
Status: executable

### sales-invoice.refusal.negative-weight   (T06 Required/invalid)
Layer: browser
Steps: Line A with net weight -10.000 (decision D3: accept), save.
Expected: **no refusal message**; the save returns 200 and `SL_DETL` stores net weight -10.000. The grid key handler only upper-cases and drops NUL and apostrophe: TR_SALE.cs:14879 {{if (num == 0 || num == 39)}}; no desktop text refuses a negative weight (study Gap 11). The stored net weight equals what the screen showed (-10.000), and header net equals the sum of lines. Decision (architect, 2026-11-22, owner may override). Previously `blocked`; now executable.
Status: executable

### sales-invoice.refusal.edit-without-right   (T06 Required/invalid)
Layer: browser
Steps: user whose `USER_SET` edit right is not Y, voucher with `USER_UPDATE` not Y; reopen and Save.
Expected: message "You Have No Rights....." and no write. Rule: TR_SALE.cs:15070 {{if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0)}} then TR_SALE.cs:15072 {{You Have No Rights.....}}. Server returns 403 for a direct call. With the voucher's own `USER_UPDATE = 'Y'` the save is allowed (TR_SALE.cs:14417 {{UsUPdate = Conversions}}).
Status: executable

### sales-invoice.refusal.quotation-import-edit-mode   (T06 Required/invalid)
Layer: browser
Steps: reopen a saved invoice (edit mode), press "Q".
Expected: nothing happens (no prompt, no lines added): TR_SALE.cs:21021 {{if (Operators.CompareString(EntryMode, "A", false) != 0)}} returns. (G7)
Status: executable

### sales-invoice.refusal.olocar-before-save   (T06 Required/invalid)
Layer: browser
Steps: new unsaved invoice, press "O Locar".
Expected: message "Please First Save Voucher and Reopen Voucher and try..." and no remote call: TR_SALE.cs:21571 {{Please First Save Voucher and Reopen Voucher and try...}}.
Status: N/A: the "O Locar" service (`OlockerService`) is an external locker integration outside the Lite web scope and not in this work package's gaps; no study gap names it.

### sales-invoice.refusal.no-lines   (T06 Required/invalid)   **reused**
Layer: browser. Unchanged. Also reused: `refusal.approval-tag-mismatch`, `refusal.cheque-without-bank`, `refusal.unknown-item`. Status: executable

### sales-invoice.create.upi-rows   (T07 Create)
Layer: database
Steps: Line A, UPI rows U1 1,000.00 and U2 2,500.50, cash 62,017.29, save once.
Expected: `SL_DATA.UPI_AMT` 3,500.50; 2 `UPI_DATA` rows (`SR_NO` 1, 2) with account, name, type, id, amount; bill total 65,517.79 = UPI 3,500.50 + cash 62,017.29 (65,517.79 - 3,500.50 = 62,017.29), `BILL_OS` 0.00; ledger balanced; `UPI_DATA` columns per TR_SALE.cs:15865 {{dataRow12["UPI_AC_CODE"] = MSG_UPI[DC_Main.i, 1];}} to TR_SALE.cs:15869 {{dataRow12["UPI_AMT"] = Conversion.Val(MSG_UPI[DC_Main.i, 5]);}}. All rows written in the single voucher transaction. (G4)
Status: executable

### sales-invoice.create.credit-note   (T07 Create)
Layer: database
Steps: Line A, credit note CN1 4,000.00, cash 61,517.79, save.
Expected: `CRNT_ADJ_AMT` 4,000.00; 1 `CRNT_DATA` row (4,000.00); `BILL_OS` = 65,517.79 - 4,000.00 - 61,517.79 = 0.00 (the amount joins the bill outstanding). Rule: TR_SALE.cs:15230 {{dataRow3["CRNT_ADJ_AMT"] = Conversion.Val(MSG2_TOTAL[8, 1]);}}, TR_SALE.cs:15878 {{if (Conversion.Val(MSG2_TOTAL[8, 1]) != 0.0)}}. (G5)
Status: executable

### sales-invoice.create.order-advance-two-orders   (T07 Create)
Layer: database
Steps: Line A, two order rows O1 5,000.00 and O2 3,000.00, cash 57,517.79, save.
Expected: `ADV_AMT` 8,000.00; 2 `SL_ORD_ADJ` rows (`SR_NO` 1 and 2, `ORD_SIGN` `-`, `ORD_AMT` 5,000.00 and 3,000.00, `PAID_AMT` 0, `ENTRY_TYPE` `S`, `ORD_HD_VCH_NO` / `ORD_LC` / `ORD_YRCD` / `ORD_DBCD` / `ORD_AC_CODE` from the picked orders); `BILL_OS` = 65,517.79 - 8,000.00 - 57,517.79 = 0.00. Rule: TR_SALE.cs:15715 {{dataRow8["ORD_SIGN"] = "-";}}, TR_SALE.cs:15716 {{dataRow8["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);}}, TR_SALE.cs:15229 {{dataRow3["ADV_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);}}. (G6, D2)
Status: executable

### sales-invoice.create.old-metal-gold-silver   (T07 Create)
Layer: database
Steps: Line A plus the three old-metal rows of `oldmetal.header-gold-silver-split`, cash 3,317.79 (65,517.79 - 54,000.00 - 8,200.00 = 3,317.79), save.
Expected: 3 `SL_PR_DETL` rows (one per row with a code and a non-zero net plus amount: TR_SALE.cs:15636 {{if ((Conversion.Val(MSG_OLD[DC_Main.i, 6]) + Conversion.Val(MSG_OLD[DC_Main.i, 13]) != 0.0)}}), header OLD_GL 10.000 / OLD_GL_AMT 54,000.00 / OLD_SL 105.000 / OLD_SL_AMT 8,200.00; `BILL_OS` = 65,517.79 - 54,000.00 - 8,200.00 - 3,317.79 = 0.00; stock: old gold +10.000, old silver +105.000 received. A row with blank code or zero net and zero amount is not written (0 extra rows). (G83, G8d)
Status: executable

### sales-invoice.create.header-columns   (T07 Create)
Layer: database
Steps: save with member-commission account M1, "without commission bill" ticked, rate unfixed ticked, tax code T3.
Expected: `MEMB_COM_AC_CODE` M1, `WHOUT_COMM_BILL` Y, `RATE_UNFIX` Y, `TAX_CODE` T3, `DATA_TRFR` N (TR_SALE.cs:15332 {{dataRow3["DATA_TRFR"] = "N";}}), `USER_UPDATE` N (TR_SALE.cs:15342 {{dataRow3["USER_UPDATE"] = "N";}}); with the box unticked `RATE_UNFIX` = N (TR_SALE.cs:15351 {{dataRow3["RATE_UNFIX"] = "N";}}). (G1)
Status: executable

### sales-invoice.create.existing-cases   (T07 Create)   **reused**
Reused ids: `create.single-line-cash`, `create.two-lines-dissimilar`, `create.interstate-igst`, `create.discount`, all unchanged. Status: executable

### sales-invoice.reopen.round-trip   (T08 Reopen/no-op)   **reused**
Unchanged (item, net, touch, rate, making, party). Status: executable

### sales-invoice.edit.unchanged-save-no-op   (T08 Reopen/no-op)   **reused**
Unchanged. The new lossless cases below extend it to desktop-shaped vouchers. Status: executable

### sales-invoice.reopen.desktop-saved-header-columns   (T08 Reopen/no-op)
Layer: database
Steps: seed a voucher shaped like the desktop's save: `OLD_GL` 10.000, `OLD_SL` 105.000, `OLD_GL_AMT` 54,000.00, `OLD_SL_AMT` 8,200.00, `MEMB_COM_AC_CODE` M1, `WHOUT_COMM_BILL` Y, `RATE_UNFIX` Y, `TAX_CODE` T3, `ADV_AMT` 5,000.00, `CARD_ADJ` 12.00, `DATA_TRFR` Y, `USER_UPDATE` Y, `USER_DELETE` Y. Reopen through the browser, save unchanged, compare the whole `SL_DATA` row.
Expected: every column identical except `VCH_TIME`; in particular `RATE_UNFIX` stays Y (today it becomes N because `headerExtra` is not filled on reopen), `MEMB_COM_AC_CODE` stays M1 (not blanked), `OLD_GL` stays 10.000 (net, TR_SALE.cs:19345 {{mSG2_TOTAL[9, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");}}). Per decision D8 `DATA_TRFR` stays Y and `USER_UPDATE` stays Y on an unchanged save. The screen shows the stored values: TR_SALE.cs:14305 {{(dataRow = RsData.Rows[0])["OLD_GL"]}}, TR_SALE.cs:14309 {{RsData.Rows[0]["OLD_SL"]}}, TR_SALE.cs:14415 {{DataTrfr = "Y"}}, TR_SALE.cs:14417 {{UsUPdate = Conversions}}. (G1)
Status: executable

### sales-invoice.reopen.desktop-saved-stones-and-source-tables   (T08 Reopen/no-op)
Layer: database
Steps: seed a voucher holding rows in `SL_IDTL` (2), `UPI_DATA` (2), `CRNT_DATA` (1), `SL_ORD_ADJ` (2, desktop shape), `POINT_DATA` (1, Enterprise) and `CARD_DATA` (1). Reopen and save unchanged. Dump the six tables before and after.
Expected: every table identical row for row (Lite: `POINT_DATA` is out of scope, so its row must simply survive: edit deletes only tables the web rewrites). Rules: the desktop reloads each one: TR_SALE.cs:14670 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST}}, TR_SALE.cs:14735 {{Select * From SL_ORD_ADJ WHERE}}, TR_SALE.cs:14757 {{FROM UPI_DATA WHERE CO_CODE}}, TR_SALE.cs:14812 {{Select * From CRNT_DATA WHERE}}. Counts: 2 + 2 + 1 + 2 + 1 + 1 = 9 rows before and 9 after. (G2)
Status: executable

### sales-invoice.reopen.desktop-order-advance   (T08 Reopen/no-op)
Layer: browser
Steps: seed a desktop-saved bill with `ADV_AMT` 8,000.00 and two `SL_ORD_ADJ` rows (`ORD_SIGN` `-`, 5,000.00 and 3,000.00); reopen, save unchanged.
Expected: the order grid shows 2 rows (5,000.00, 3,000.00), advance cell 8,000.00; after the save `ADV_AMT` still 8,000.00, 2 rows still present, `BILL_OS` unchanged. Today `orderRef` is null and the save drops the rows and writes `ADV_AMT` 0. Rule: TR_SALE.cs:14735 {{Select * From SL_ORD_ADJ WHERE}} and TR_SALE.cs:14283 {{MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADV_AMT"]), "0.00");}}. (G6)
Status: executable

### sales-invoice.reopen.old-metal-rows-pr-cost-it-type   (T08 Reopen/no-op)
Layer: database
Steps: desktop-shaped voucher with 3 old-metal rows (types G, S, P) each with `PR_COST` (52,000.00, 6,000.00, 900.00) and stored fine weights; reopen, save unchanged.
Expected: `SL_PR_DETL` identical (3 rows, `PR_COST` 52,000.00 / 6,000.00 / 900.00, `IT_TYPE` G/S/P, fine weights as stored); `OLD_GL` 10.000 and `OLD_SL` 105.000 unchanged. Rule: TR_SALE.cs:14703 {{SELECT A.* FROM SL_PR_DETL AS A}}, TR_SALE.cs:14724 {{RsOldDetl.Rows[DC_Main.i]["PR_COST"]}}. (G3)
Status: executable

### sales-invoice.reopen.tax-code-two-codes-one-rate   (T08 Reopen/no-op)
Layer: database
Steps: web-provisioned company with two tax parents `T3A` and `T3B`, both 3% (G82 shape: parent `SR_NO` 0 plus components 1/2/3). Save a sale with code `T3B`; reopen; save unchanged.
Expected: the tax name on reopen is the parent row's name: TR_SALE.cs:14337 {{SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='}} with `SR_NO = 0`; the unchanged save sends `taxCode` = `T3B` back and succeeds (200), `SL_DATA.TAX_CODE` still `T3B`; the by-percentage lookup is not used (no "ambiguous" refusal). Today the save asks by percentage and is refused as ambiguous. (G82, study G9b)
Status: executable

### sales-invoice.reopen.rate-with-keeps-stored-value   (T08 Reopen/no-op)
Layer: browser
Steps: see `config.setting-change` (T15): reopen a voucher saved while `SL_AMT_TYPE` = N after the company setting changed to F.
Expected: see T15. Listed here so T08 carries the reopen-of-history rule: the screen shows the stored `RATE_WITH`: TR_SALE.cs:14570 {{mSG[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);}}.
Status: executable

### sales-invoice.edit.change-rate   (T09 Edit)   **reused**
Unchanged. Status: executable

### sales-invoice.edit.changed-save-marks-transfer   (T09 Edit)
Layer: database
Steps: voucher with `DATA_TRFR` Y and `USER_UPDATE` Y (seed); reopen, change the cash tender by 1.00 (cash 65,517.79 -> 65,516.79 with a 1.00 kasar so the bill stays balanced), save.
Expected: only the changed fields move; `DATA_TRFR` becomes N (TR_SALE.cs:15332 {{dataRow3["DATA_TRFR"] = "N";}}) and `USER_UPDATE` becomes N (TR_SALE.cs:15342 {{dataRow3["USER_UPDATE"] = "N";}}); all other columns equal. Decision D8 (architect, 2026-11-22, owner may override). (G1)
Status: executable

### sales-invoice.edit.upi-row-amount   (T09 Edit)
Layer: database
Steps: voucher with UPI rows 1,000.00 and 2,500.50 (cash 62,017.29); change row 1 to 1,200.00 and cash to 61,817.29 (65,517.79 - 3,700.50 = 61,817.29); save.
Expected: `UPI_DATA` rows 1,200.00 and 2,500.50; `UPI_AMT` 3,700.50; `BILL_OS` 0.00; rows for other vouchers unchanged; no extra rows. Rule: TR_SALE.cs:15844 {{DELETE FROM UPI_DATA WHERE}} then rewrite. (G4)
Status: executable

### sales-invoice.edit.old-metal-weight   (T09 Edit)
Layer: database
Steps: voucher with one gold old-metal row net 10.000 rate 5,400 (54,000.00); change net to 11.000.
Expected: amount = Round(11.000 x 5,400, 0) = 59,400.00; `NET_AMT` 59,400.00 = `OLD_GL_AMT` 59,400.00 = ledger old-gold line; `OLD_GL` 11.000; `PR_COST` unchanged (not recomputed). TR_SALE.cs:7959 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0)}}; `BILL_TOTAL()` reprices the bill (study Calculations 6). (G83)
Status: executable

### sales-invoice.delete.reverses   (T10 Delete/cancel/reverse)   **reused**
Unchanged. Status: executable

### sales-invoice.delete.removes-tender-and-source-rows   (T10 Delete/cancel/reverse)
Layer: database
Steps: delete a voucher holding rows in `UPI_DATA` (2), `CRNT_DATA` (1), `SL_ORD_ADJ` (2), `SL_PR_DETL` (3), `SL_IDTL` (2); a second voucher holds the same kinds of rows.
Expected: 0 rows of every table for the deleted voucher; the second voucher's rows are all intact (10 rows); a `DELETE_DATA` audit row exists. Rule: TR_SALE.cs:16385 {{DELETE FROM SL_IDTL WHERE CO_CODE = '}}; confirmation TR_SALE.cs:16316 {{Are You Sure To Delete This Voucher now?}}. Each delete is scoped by company, location, year, book and voucher number. (G2)
Status: executable

### sales-invoice.delete.refused-without-right   (T10 Delete/cancel/reverse)
Layer: browser
Steps: user without the delete right presses Delete on a saved voucher.
Expected: message "You Have No Rights....." and the voucher is untouched. Rule: TR_SALE.cs:16312 {{You Have No Rights.....}}. Also reused: `rights.clerk-cannot-delete` (API 403).
Status: executable

### sales-invoice.rights.voucher-list-follows-book-rights   (T11 Scope/rights)   **reused**
Unchanged. Also reused: `rights.clerk-cannot-delete`. Status: executable

### sales-invoice.rights.tender-rows-other-tenant   (T11 Scope/rights)
Layer: database
Steps: tenant A user calls the sale `GET` and `PUT` with a voucher number that belongs to tenant B (same book code and number), UPI/credit-note/order rows present on B's voucher.
Expected: 404 (not found) for A; B's `UPI_DATA`, `CRNT_DATA`, `SL_ORD_ADJ` rows unchanged (counts equal before and after); no rows of B appear in A's response. Web safety add (hosted multi-user), the desktop is single company: scoping every read and delete by tenant, company, location, year, book and number. (G2, G4, G5, G6)
Status: executable

### sales-invoice.concurrency.stale-second-save   (T12 Concurrency)   **reused**
Unchanged. Status: executable

### sales-invoice.concurrency.order-advance-double-use   (T12 Concurrency)
Layer: database
Steps: order ORD7 has a balance of 5,000.00. Two sessions each save a new invoice adjusting 4,000.00 of it, at the same time.
Expected: exactly one save succeeds (adjusted 4,000.00, balance 1,000.00); the other gets a defined conflict (409) and writes no voucher (0 `SL_DATA` rows for it, order balance still 1,000.00). Arithmetic: 5,000.00 - 4,000.00 = 1,000.00; a second 4,000.00 would give -3,000.00 and must not happen. The desktop has no lock (single user); the refusal is the hosted-service safety add (decision, architect, 2026-11-22, owner may override). (G6)
Status: executable

### sales-invoice.retry.double-click-single-voucher   (T13 Retry/unknown)   **reused**
Unchanged. Status: executable

### sales-invoice.retry.lost-acknowledgement-upi   (T13 Retry/unknown)
Layer: database
Steps: save a sale with UPI rows and credit note; drop the response after commit; resend the same request key.
Expected: the second call returns the first result (same voucher number) and the table counts are 1 `SL_DATA`, 2 `UPI_DATA`, 1 `CRNT_DATA`, 1 ledger set (no duplicates). Hosted-service rule; the desktop has no retry. (G4, G5)
Status: executable

### sales-invoice.rollback.mid-write   (T14 Rollback)   **reused**
Unchanged. Status: executable

### sales-invoice.rollback.tender-write-fault   (T14 Rollback)
Layer: database
Steps: fault injection after the `UPI_DATA` insert, then after `CRNT_DATA`, then after `SL_ORD_ADJ`, then after `SL_PR_DETL` on a new sale, and on an edit of an existing sale; sentinel voucher present.
Expected: for each fault 0 rows of the new voucher in all tables and, for the edit, the original voucher byte-identical (UPI 2, credit-note 1, order 2, old-metal 3 rows kept); sentinel untouched. Rule: the desktop writes everything in one transaction: TR_SALE.cs:15844 {{DELETE FROM UPI_DATA WHERE}} inside `Module_Save.SlTran`; the web must not leave a partial write (compare TR_SALE.cs:11969 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}, D10). (G2, G4, G5, G6)
Status: executable

### sales-invoice.config.setting-change   (T15 Config/history)
Layer: browser
Steps: 1. Company A has `CO_SET.SL_AMT_TYPE` = `N`. Open a new sale, enter Line A (preview). 2. Change the setting to `F` in another session. 3. Save the sale. 4. Reopen it. 5. Add a second new line to the reopened voucher.
Expected: the saved line carries `RATE_WITH` as it was when the line was entered (`N`; saved by TR_SALE.cs:15432 {{dataRow4["RATE_WITH"] = mSG[DC_Main.i, 21];}}), the reopened line shows `N` (TR_SALE.cs:14570 {{mSG[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);}}), the new second line takes the current setting `F` (TR_SALE.cs:9161 {{mSG[mSG.Row, 21] = DC_Main.MsSlAmtType;}}). Amounts of line 1 equal the preview (net 63,609.50). Previously `blocked`; decision D4 makes it executable with the fixture company in Test data. A missing `SL_AMT_TYPE` defaults to `N`: MS_OPNCOMP.cs:883 {{DC_Main.MsSlAmtType = "N";}}.
Status: executable

### sales-invoice.config.history-reopen-after-master-change   (T15 Config/history)
Layer: database
Steps: save a voucher with old-metal row (rate 5,400); change the rate master and the old-gold item name afterwards; reopen.
Expected: the voucher shows the stored rate 5,400.00, stored amount 54,000.00, stored item name (no recompute from the changed masters); the unchanged save keeps `NET_AMT` 54,000.00. Rule: reopen reads stored columns, TR_SALE.cs:14703 {{SELECT A.* FROM SL_PR_DETL AS A}}. (G83)
Status: executable

### sales-invoice.print.pdf   (T16 Report/output)   **reused**
Unchanged. Also reused: `print.hsn-agrees-with-summary`, `print.after-access-expiry`, `print.date-with-year`, `output.register-csv`. Status: executable

### sales-invoice.print.template-chosen-file   (T16 Report/output)
Layer: browser
Steps: print with the file `SalesBillA4` chosen; then with `SalesBillGst` chosen.
Expected: the print job names the chosen file: TR_SALE.cs:16494 {{cboPrintfile.Text}} gives `SalesBillA4` then `SalesBillGst` (G10). A name with no web template prints with the default template and the job says "default". Decision D6.
Status: executable

### sales-invoice.print.template-huid   (T16 Report/output)
Layer: browser
Steps: tick the HUID print box and print any file choice.
Expected: template `RtlHuidPrint` regardless of the file chosen: TR_SALE.cs:16484 {{RtlHuidPrint.RPT}}; opening and closing balance parameters are **not** passed: TR_SALE.cs:16505 {{Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";}} runs only when the HUID box is not ticked. (G10)
Status: executable

### sales-invoice.print.template-quotation-book-099   (T16 Report/output)
Layer: browser
Steps: print on book `099` with file `SalesBillA4` selected.
Expected: template `SalesQuotation`: TR_SALE.cs:16489 {{SalesQuotation.RPT}} (not the chosen file). (G10)
Status: executable

### sales-invoice.print.opening-closing-parameters   (T16 Report/output)
Layer: database
Steps: party opening balance 10,000.00 Dr; save a credit sale with no tender (total 65,517.79); print.
Expected: parameters `OpAmt = 10000.00` and `ClAmt = 75517.79` (10,000.00 + 65,517.79 = 75,517.79), two decimals: TR_SALE.cs:16505 {{Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";}}, TR_SALE.cs:16506 {{Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";}}; the figures are the account balances from TR_SALE.cs:16260 {{CustOpAmt = DC_Main.MsAcAmtOpBal;}} and TR_SALE.cs:16261 {{CustClAmt = DC_Main.MsAcAmtClBal;}}. (G10)
Status: executable

### sales-invoice.print.set-default-file   (T16 Report/output)
Layer: database
Steps: choose `SalesBillA4`, press "Set".
Expected: for the company, book main type and book type: `SalesBillA4` has `PRINT_SET_A` = Y, every other row of the same company, `PRINT_TYPE` and `BOOK_TYPE` has N, rows of other companies and other book types unchanged. Rules: TR_SALE.cs:20620 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '}}, TR_SALE.cs:20622 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '}}. Both updates in one transaction (the desktop runs them as two separate statements; not ported). (G10)
Status: executable

### sales-invoice.print.refused-without-right   (T16 Report/output)
Layer: browser
Steps: user whose print right is not Y presses Print.
Expected: message "You Have No Print Rights....." and no document: TR_SALE.cs:16439 {{You Have No Print Rights.....}}; server `403` on the print endpoint. (G10)
Status: executable

### sales-invoice.print.duplicate-copies   (T16 Report/output)
Layer: browser
Steps: print with duplicate and original copies selected.
Expected: copy label texts `CUSTOMER COPY` then `ACCOUNT COPY`: TR_SALE.cs:16537 {{DC_Main.MsPrintType = "InVoiceType";}}; the two copies carry identical figures (total 65,517.79 on both).
Status: N/A: the copy label text is set in the print-spool path of the desktop (`PrintReportDirect`), which is outside this work package's gaps; the web already prints one document per request and copy handling is not a study gap.

### sales-invoice.keyboard.voucher-number-keys   (T17 Keyboard/usability)   **reused**
Unchanged. Also reused: `keyboard.alt-s-saves`, `entry.no-request-storm`. Status: executable

### sales-invoice.keyboard.esc-steps-back   (T17 Keyboard/usability)
Layer: browser
Steps: focus the totals editor, press Esc; focus a stone editor, press Esc; focus an item cell editor, press Esc; with unchanged totals press Esc on the form.
Expected: each Esc moves back one level (item cell editor, then stone editor, then totals editor with focus to the employee code box) and the form closes only when the old and new totals are equal: TR_SALE.cs:16397 {{if ((int)e.KeyCode == 27)}}. With a changed total the form stays open (0 closes).
Status: executable

### sales-invoice.keyboard.upi-f1-adds-type   (T17 Keyboard/usability)
Layer: browser
Steps: UPI grid, cell on column 3 (type), press F1; then F1 on column 1.
Expected: on column 3 the "add type" mode starts (`UpiTypeAdd` true): TR_SALE.cs:6901 {{if (mSG_UPI.Col == 3)}}, TR_SALE.cs:6903 {{UpiTypeAdd = true;}}; on column 1 nothing happens. Correction to the study (it called this an account help). (G4)
Status: executable

### sales-invoice.keyboard.row-delete-confirm   (T17 Keyboard/usability)
Layer: browser
Steps: old-metal grid, Ctrl+D on row 1, answer No, then Yes.
Expected: the text "This Row Record will Removed permantley ?" (spelling kept) appears each time; No keeps the row, Yes clears it and the totals recompute. Rule: TR_SALE.cs:7539 {{This Row Record will Removed permantley ?}}. (G8)
Status: executable

### sales-invoice.journey.sale-to-register-and-ledger   (T18 Full journey)   **reused**
Unchanged. Status: executable

### sales-invoice.journey.old-metal-sale-to-stock-and-ledger   (T18 Full journey)
Layer: browser
Steps: create the bill of `create.old-metal-gold-silver`; run the sales register, the party ledger, the stock report (old gold, old silver), the cash book; reopen and delete.
Expected: register net 63,609.50 and total 65,517.79; party ledger Dr 65,517.79 then Cr 54,000.00 (old gold) and Cr 8,200.00 (old metal other) and Cr 3,317.79 (cash) = 65,517.79, closing 0.00; stock +10.000 gold and +105.000 silver received; after delete all four reports return to the opening figures. All figures use the single old-metal valuation (TR_SALE.cs:15231 {{dataRow3["OLD_GL_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);}}, TR_SALE.cs:15664 {{dataRow7["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 13]);}}). (G83)
Status: executable

### sales-invoice.journey.order-advance-to-order-balance   (T18 Full journey)
Layer: browser
Steps: order ORD7 value 20,000.00 with advance 8,000.00 taken on the order screen; sale adjusts 5,000.00 and 3,000.00 (two rows); open the order balance; delete the sale.
Expected: balance after the sale = 20,000.00 - 8,000.00 = 12,000.00 outstanding on the order, advance fully adjusted; after the delete the order shows 8,000.00 advance available again (5,000.00 + 3,000.00 released). Rule: TR_SALE.cs:15716 {{dataRow8["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);}}. (G6)
Status: executable

### sales-invoice.source.approval-no-import   (T04 Lookup)
Layer: browser
Steps: new sale, press "A" (approval number import), enter an approval voucher number holding 2 tags, accept the prompt "All Approval Tag In This Voucher Import?".
Expected: the two tags would fill 2 lines and the approval is marked consumed (`APR_DETL.ISU_REC`), per TR_SALE.cs:20050 {{All Approval Tag In This Voucher Import?}}.
Status: blocked: the master plan names this as the third blocked Sales case ("Sales Apr No import", `docs/parity/LITE-MASTER-PLAN.md` line 309, WP-01 follow-up); the import reads the approval-issue screens built by WP-01 and WP-04. Exact question for the supervisor: "Has the WP-01 follow-up (Approval Isu import service) landed on main so that a sale can read an approval voucher by number, and which approval numbers belong in the Test data?" Unblocks when that service exists; then turn it into a T04/T07 pair and assert the 2 lines and the 2 `ISU_REC` updates.

### sales-invoice.source.approval-release-on-save-only   (T10 Delete/cancel/reverse)
Layer: database
Steps: sale with an approval tag line; delete the line on the grid (no save), read `APR_DETL`; then save.
Expected: before save `ISU_REC` unchanged (tag still issued); after save the tag is released. The desktop releases at the row delete itself (TR_SALE.cs:11969 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}), a partial write that is not ported (decision D10, architect, 2026-11-22, owner may override).
Status: executable

## Coverage table

| Kind | Cases | Blocked | N/A |
|---|---|---|---|
| T01 Entry/defaults | 4 | 0 | 0 |
| T02 Field route | 5 | 0 | 0 |
| T03 Formula sequence | 15 | 0 | 1 |
| T04 Lookup | 3 | 1 | 0 |
| T05 Children | 5 | 0 | 0 |
| T06 Required/invalid | 8 | 0 | 1 |
| T07 Create | 6 | 0 | 0 |
| T08 Reopen/no-op | 8 | 0 | 0 |
| T09 Edit | 4 | 0 | 0 |
| T10 Delete/cancel/reverse | 4 | 0 | 0 |
| T11 Scope/rights | 2 | 0 | 0 |
| T12 Concurrency | 2 | 0 | 0 |
| T13 Retry/unknown | 2 | 0 | 0 |
| T14 Rollback | 2 | 0 | 0 |
| T15 Config/history | 2 | 0 | 0 |
| T16 Report/output | 8 | 0 | 1 |
| T17 Keyboard/usability | 4 | 0 | 0 |
| T18 Full journey | 3 | 0 | 0 |

Total 87 case entries: 83 executable (of which 17 reuse an existing id, unchanged), 3 N/A, 1 blocked. Entries marked reused sometimes name several existing ids on one line.

## Test data

- Company A (web-provisioned, so G82 applies): SALES book of type `M`, plus book `099` for quotations; `CO_SET.SL_AMT_TYPE` = `N`; a second fixture company B with `SL_AMT_TYPE` = `F` (D4).
- Tax masters: two parents `T3A` and `T3B`, both 3%, each with components 1/2/3; `T3` for the header case.
- Parties: P1 (local, opening 10,000.00 Dr), P2, member-commission account M1, UPI accounts U1 (PhonePe, a@b), U2 (Gpay, c@d), U3 (Paytm, e@f).
- Items: gold item (existing `LINE_A` item), silver item; old-metal items `OG` (type G), `OS` (type S), `OLDG` (type G, not OG), `OLDP` (type P, platinum).
- `RATE_MAST`: one row on or before the voucher date, `FINE_GL_RATE` 60,000.00, `FINE_SL_RATE` 80,000.00; a second company/date with no row for the "no rate" case.
- `PRINT_MAST`: rows described in `entry.print-file-list-and-default`; company "01" fallback row.
- Orders: ORD7 value 20,000.00 with advance 8,000.00 and balance 5,000.00 for the concurrency case; O1, O2, O3.
- Credit notes: CN1 4,000.00, CN2 1,500.00, CN3 800.00.
- Desktop-shaped vouchers (seeded straight into the tables, as the desktop would save them): H1 (header columns), S1 (stones, UPI, credit note, orders, points, card), R1 (three old-metal rows with `PR_COST`), O-1 (two order rows).
- Users: admin, a clerk without edit/delete/print right, a second tenant with the same book code and voucher number.
- Two sales quotations for P1 and one for P2 on book `099`.

## Not covered

- Pixel and page layout of every Crystal template (`SalesBillA4`, `SalesBillGst`, `RtlHuidPrint`, `SalesQuotation`): the cases prove template choice and data values only; layout needs an owner-accepted visual review. (Study Open question: which `.rpt` files exist was not enumerated.)
- `VK050NEVK` and `HM249NEHP` print branches, `KJ001NEKJ`, `VS287NEBU`, `VK050NEVK`, `HM249NEHP` per-installation code: not business rules (decision, standing rule).
- `00045` cash-party `CASH_AMT` branch (D9) and the "O Locar" locker integration: N/A as listed.
- Points (`POINT_DATA`) panel and the old-data snapshot: Enterprise only (TR_SALE.cs:14229 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}); only survival of the rows on an unchanged save is covered.
- Tab order, defaults and enabled/visible rules of the old-metal, UPI and credit-note controls (D7).
- TCS and TDS name display on reopen (study G9c) and `TAX_AC` (G86): deliberately open, no gap case.
- Percentage labour and line precision (PR #241): out of scope in the study.
- Book types other than `M` beyond `oldmetal.header-totals-only-for-metal-book`.
- Keyboard walk of the old-metal and tender grids cell by cell (study: listed, not walked); only Esc, F1, Ctrl+D and voucher number keys are covered.
