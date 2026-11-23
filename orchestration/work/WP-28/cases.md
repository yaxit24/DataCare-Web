# WP-28 frozen case list: Purchase residuals (hallmark receive branch, lossless reopen, family-filtered books)

Source: `orchestration/work/WP-28/study.md`, desktop forms `TR_PURC_HM.cs` (hallmark purchase, 95-column receive grid) and `TR_PURC.cs`
(plain purchase), `MDI_FORM.cs`, `DC_Main.cs` under `unified/src/csharp/DataCareNext/` (authority), role contract `orchestration/roles/cases.md`,
playbook kinds T01 to T18. Module id prefix `purchase-invoice.`. Existing ids in `web/apps/web/test/features/modules/purchaseInvoice.mjs` are reused
unchanged and marked **reused**. Every other case is new and fails today for the gap named in it. "G1" to "G10" are the study's `Gaps` numbers
(G91, N32, G46, G101 keep their own names).

Fixed inputs, from the module's constants:

- Line G: gold, net 20.000, touch 91.6, rate 6,050, making 150 per gram. Fine 20.000 x 91.6 / 100 = 18.320; metal 18.320 x 6,050 = 110,836.00; labour 20.000 x 150 = 3,000.00; net 113,836.00.
- Line S: silver, net 100.000, touch 92.5, rate 80. Fine 92.500; metal 92.500 x 80 = 7,400.00; net 7,400.00.
- Lines G + S: net 113,836.00 + 7,400.00 = 121,236.00; tax 3% = 3,637.08 (121,236.00 x 3 / 100 = 3,637.08).
- Settings of the fixture company unless stated: `TAX_ROF` 2, `TOT_AMT_ROF` 0, amount type `F` (the module's `WHOLE_RUPEE_SETTINGS`).

## Decisions (architect, 2026-11-22, owner may override)

Standing rule: the desktop first; the web adds only what a hosted multi-user service needs to be safe and correct. Never ported: string-built SQL,
plaintext secrets, unscoped deletes, partial writes.

| # | Study open question | Decision (architect, 2026-11-22, owner may override) | Grounds |
|---|---|---|---|
| D1 | Which form opens: one menu entry by setting (G5) | One `Purchase` entry. It opens the 95-column hallmark layout when the company setting `PURC_WITH_HMTAX` is `Y`, else the plain layout. `Tag Wise Purc` opens the hallmark layout on the `TAG PURCHASE` books. The old `/txn/purchase-hm` route stays as a redirect to `/txn/purchase` so bookmarks work. | MDI_FORM.cs:7866 {{if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)}}, MDI_FORM.cs:7871 {{TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();}}, MDI_FORM.cs:7884 {{TR_PURC tR_PURC2 = new TR_PURC();}} |
| D2 | Setting default | A blank `PURC_WITH_HMTAX` is `N`. The setting is per company (read once from the company row when the company is opened). | MS_OPNCOMP.cs:1114 {{DC_Main.MsPurcWithHmTax = "N";}} |
| D3 | Lite or Enterprise (study open question 3) | `Purchase` is a Lite menu; `Tag Wise Purc` is an Enterprise menu (`docs/handbook/menu-editions.json`, entry `Tag Wise Purc`, edition `E`; entry `Purchase`, edition `L`). The Lite menu does not show `Tag Wise Purc`. The `TAG PURCHASE` book and its tag band stay supported by the writer and the screen (data written by an Enterprise desktop must not be lost), tested on a fixture `TAG PURCHASE` book through the direct route. | MDI_FORM.cs:8540 {{case "Tag Wise Purc":}}, MDI_FORM.cs:8541 {{DC_Main.CurBookHelp("TAG PURCHASE");}} |
| D4 | What the hallmark weight rule applies to (study open question 1) | The refusal text lives only in the **plain** form's tag-line boxes (`nHmWt2` to `nHmWt4`). `TR_PURC_HM` contains no such message (checked: its message list has no "HmId"). So the web hallmark grid **accepts** an id with a zero weight and stores it; the plain screen has one HUID cell and no weight boxes, so the rule has nothing to attach to there. | TR_PURC.cs:16315 {{Please Insert HmId2 Weight and try...}}; TR_PURC_HM.cs holds no `HmId` message |
| D5 | Hallmark ids 2 to 4, their weights and the tag band are written only for `TAG PURCHASE` | Written (and read back) only when the book's `MAIN_BOOK` is `TAG PURCHASE`. For a `PURCHASE` book the desktop writes the tag columns as zeros and blanks and leaves `HM_ID*` unset. The web writes the same. | TR_PURC_HM.cs:8053 {{dataRow3["HM_ID"] = mSG_PR[DC_Main.i, 55];}} sits inside the branch opened at TR_PURC_HM.cs:8023 {{if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)}}; the `PURCHASE` branch writes zeros: TR_PURC_HM.cs:8087 {{dataRow3["TAG_TOT_COST"] = 0;}} |
| D6 | Lossless edit (G1, G2, G10) | The desktop hallmark form rewrites only the lines whose snapshot changed (a weight/amount checksum and a text key per line, kept in hidden columns 87 and 88). The web does the same effect: an unchanged save leaves **every stored column of every untouched line, header and stone row identical**, and writes no value derived from a re-read of the item master. Stricter than the desktop, which rounds through grid text (study "Desktop weaknesses"). | TR_PURC_HM.cs:7585 {{mSG_PR[DC_Main.i + 1, 87] = Strings.Format((object)num3, "0.000");}}, TR_PURC_HM.cs:7586 {{mSG_PR[DC_Main.i + 1, 88] = text;}}, TR_PURC_HM.cs:7944 {{if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG_PR[DC_Main.i, 87]), "0.000"), Strings.Format((object)num2, "0.000"), false) != 0)}} |
| D7 | Server-side family check (G6) | `createPurchase` and `editPurchase` refuse (400) a book whose `MAIN_BOOK` is not `PURCHASE` or `TAG PURCHASE`, and a book with `CUR_USE` not `Y`. `/context/books` takes a `family` parameter and filters on the server. | DC_Main.cs:1503 {{CUR_USE = 'Y' AND MAIN_BOOK = '}} |
| D8 | Book lists per screen (G7) | `Purchase` entry offers `PURCHASE` books only; `Tag Wise Purc` offers `TAG PURCHASE` books only; neither offers Sales, Contra, Journal or any other family. | MDI_FORM.cs:7868 {{DC_Main.CurBookHelp("PURCHASE");}}, MDI_FORM.cs:8541 {{DC_Main.CurBookHelp("TAG PURCHASE");}} |
| D9 | Employee-code book shortcut (G8) | Ported as the desktop does: when the signed-in user has an employee code and a book carries that code in `USER_EMP_CODE`, that book is selected at once; when no book exists the screen shows "Please Creat Book From PURCHASE....". | DC_Main.cs:1514 {{dataView.RowFilter = "USER_EMP_CODE =  '}}, DC_Main.cs:1508 {{Please Creat Book From}} |
| D10 | `/context/books` and `DATA_TYPE` (study open question 4) | `CUR_USE = 'Y'` is honoured. The desktop narrows the list by `DATA_TYPE` equal to `A` or `B` when the company data type is `A` or `B`; whether a web-provisioned company has a data type is not decided anywhere. The case is `blocked` with the exact question. | the `A`/`B` branches of the book query; see `lookup.books-data-type-filter` |
| D11 | Voucher number race on a new entry | The web allocates the number on the server inside the save (never a number shown earlier). Two simultaneous new saves both succeed with consecutive numbers (`MAX + 1`, five digits). The desktop's silent "number has been changed" notice is replaced by the saved message that names the assigned number. | TR_PURC_HM.cs:7785 {{Current Voucher No has been changd New Voucher No is}}, TR_PURC_HM.cs:7787 {{tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");}} |
| D12 | Item master changed after the voucher was saved | Reopen shows the stored `RATE_TYPE` and `IT_TYPE` of the line, not the master's current ones (the desktop reads them from the master join and would silently rewrite them: weakness, not ported). | TR_PURC_HM.cs:7462 {{SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM}} |
| D13 | Licence-expired and company-type-B save refusals | Not ported (desktop licensing, not a hosted-service rule). Cases N/A. | TR_PURC_HM.cs:7728 {{You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....}} |

Corrections to the study found while writing:

- The 95-column grid holds **hallmark amount per line** at column 39, and the header `HM_AMT` is the rounded column total:
  TR_PURC_HM.cs:9995 {{mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 39]), 0), "0.00");}} (non-UAE). The hallmark tax is
  TR_PURC_HM.cs:9998 {{Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) * Conversion.Val(mSG2_TOTAL[6, 2]) / 100.0, DC_Main.MsTaxRof)}}.
- Reopen takes the header tax names by the parent row: TR_PURC_HM.cs:7255 {{SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='}} with `SR_NO = 0`.
- The study read `HM_ID` and `HM_ID2` as written for every book; they are written for `TAG PURCHASE` only (D5).

## Cases

### purchase-invoice.rights.voucher-list-follows-book-rights   (T11 Scope/rights)   **reused**
Unchanged. Status: executable

### purchase-invoice.entry.defaults   (T01 Entry/defaults)   **reused**
Layer: browser. Plain layout, setting `N`: books offered `['PR — Purchase']`, tax 3. Unchanged (it asserts the plain screen only; the new book cases below add the hallmark screen). Status: executable

### purchase-invoice.entry.setting-n-opens-plain-layout   (T01 Entry/defaults)
Layer: browser
Steps: company with `PURC_WITH_HMTAX` = `N`; open the `Purchase` menu entry.
Expected: the plain layout opens (receive grid with the plain column set; no `HmAmt` column; 70-column family: TR_PURC.cs:6219 {{mSG_PR.Cols = 70;}}); the menu has a single `Purchase` entry (no second "Hallmark Purchase" entry); the book list holds `PURCHASE` books only. Rule: MDI_FORM.cs:7884 {{TR_PURC tR_PURC2 = new TR_PURC();}} after the failed test at MDI_FORM.cs:7866 {{if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)}}. (G5, D1)
Status: executable

### purchase-invoice.entry.setting-y-opens-hallmark-grid   (T01 Entry/defaults)
Layer: browser
Steps: company with `PURC_WITH_HMTAX` = `Y`; open the `Purchase` menu entry; read the grid columns.
Expected: the hallmark layout opens with the 95-column receive grid: TR_PURC_HM.cs:4546 {{mSG_PR.Cols = 95;}}; the visible columns include `HmAmt` (index 39: TR_PURC_HM.cs:4647 {{mSG_PR[0, 39] = "HmAmt";}}), `HmFine` (index 76: TR_PURC_HM.cs:4629 {{mSG_PR[0, 76] = "HmFine";}}) and `Color` (index 7: TR_PURC_HM.cs:4778 {{mSG_PR[0, 7] = "Color";}}); the tag band columns (`TOthWt`, `TgNwt`, `TagRate`, ...) are not shown because the book is `PURCHASE`; the stone sub-grid has 23 columns: TR_PURC_HM.cs:3807 {{mSG_PR_IDTL.Cols = 23;}}; the totals grid has 5 columns: TR_PURC_HM.cs:9297 {{mSG2_TOTAL.Cols = 5;}}. Today the page shows the plain layout (G5).
Status: executable

### purchase-invoice.entry.setting-blank-is-n   (T01 Entry/defaults)
Layer: database
Steps: company row with `PURC_WITH_HMTAX` blank/NULL; open the `Purchase` entry.
Expected: plain layout (blank becomes `N`): MS_OPNCOMP.cs:1114 {{DC_Main.MsPurcWithHmTax = "N";}}. (G5, D2)
Status: executable

### purchase-invoice.entry.tag-wise-purc-opens-tag-books   (T01 Entry/defaults)
Layer: browser
Steps: fixture company with a `TAG PURCHASE` book `TP` and a `PURCHASE` book `PR`; open `Tag Wise Purc` (direct route in Lite, D3).
Expected: hallmark layout whatever the setting; book list = `TP` only; the tag band columns are shown (`TOthWt`, `TgNwt`, `TgTch`, `TagRate`, `TagItAmt`, ...: TR_PURC_HM.cs:4699 {{"TAG PURCHASE"}}); `Party Fine` is visible (TR_PURC_HM.cs:6938 {{((Control)nPartyFine).Visible = true;}}) and `Sl Bil No` is hidden (TR_PURC_HM.cs:6940 {{((Control)tSlBill).Visible = false;}}). (G5, G7, D8)
Status: executable

### purchase-invoice.entry.tag-wise-purc-menu-edition   (T01 Entry/defaults)
Layer: unit
Steps: build the Lite and Enterprise menus from `docs/handbook/menu-editions.json`.
Expected: `Purchase` (edition L) is in both; `Tag Wise Purc` (edition E, smCode 23) is in the Enterprise menu only (D3). 2 entries compared, 1 differs.
Status: executable

### purchase-invoice.entry.books-user-employee-shortcut   (T01 Entry/defaults)
Layer: browser
Steps: two `PURCHASE` books, `PR1` (`USER_EMP_CODE` blank) and `PR2` (`USER_EMP_CODE` = E7); sign in as a user whose employee code is E7; open `Purchase`.
Expected: `PR2` is selected at once (the list is not shown); with a user whose code is E8 (no book carries it) the normal book list (PR1, PR2) shows. Rule: DC_Main.cs:1514 {{dataView.RowFilter = "USER_EMP_CODE =  '}} then DC_Main.cs:1517 {{dataView[0]["BookCodeT"]}}. Today the list never selects by employee code (G8).
Status: executable

### purchase-invoice.entry.books-none-message   (T01 Entry/defaults)
Layer: browser
Steps: company with no active `PURCHASE` book (all `CUR_USE` = N); open `Purchase`.
Expected: the message "Please Creat Book From PURCHASE...." (spelling kept) and no empty form: DC_Main.cs:1508 {{Please Creat Book From}} + main book name + "....". Today the list shows "No active books" (BookSelect.tsx:94). (G8)
Status: executable

### purchase-invoice.lookup.code-enter-at-once   (T04 Lookup)   **reused**
Unchanged. Also reused: `lookup.lower-case-code`, `lookup.pick-over-typed-code`, `refusal.unknown-item` (under T06). Status: executable

### purchase-invoice.lookup.books-family-list-server-side   (T04 Lookup)
Layer: database
Steps: company with books: `PR` (PURCHASE), `TP` (TAG PURCHASE), `SL` (SALES), `CN` (CONTRA), `JV` (JOURNAL), `PX` (PURCHASE with `CUR_USE` = N). `GET /context/books?family=purchase`, then `?family=tag-purchase`, then `?family=sales`.
Expected: `purchase` returns exactly [`PR`] (1 book; `PX` excluded because `CUR_USE` is N; `TP`, `SL`, `CN`, `JV` excluded); `tag-purchase` returns [`TP`]; no request returns a book of another family for the purchase writer. Rule: DC_Main.cs:1503 {{CUR_USE = 'Y' AND MAIN_BOOK = '}} ordered by book name. Today the filter exists in the browser only (BookSelect.tsx:61). (G6, G7, D7, D8)
Status: executable

### purchase-invoice.lookup.hm-tax-code-help   (T04 Lookup)
Layer: browser
Steps: hallmark layout, totals grid row 6: open the tax help, cancel; open again and pick the 18% code `HMT18`; then pick a second code `HMT05` (5%).
Expected: cancel leaves the row empty (code, rate and amount blank: TR_PURC_HM.cs:9875 {{mSG2_TOTAL[6, 2] = "";}}); picking `HMT18` shows 18.00 and keeps the code `HMT18` (TR_PURC_HM.cs:9867 {{mSG2_TOTAL[6, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");}}, TR_PURC_HM.cs:9868 {{mSG2_TOTAL[6, 4] = DC_Main.ColValue[2];}}); picking `HMT05` replaces both (5.00, `HMT05`). (G4, G91)
Status: executable

### purchase-invoice.lookup.books-data-type-filter   (T04 Lookup)
Layer: database
Steps: company data type `A` with books whose `DATA_TYPE` is `A` and `B`.
Expected: the desktop lists only books of the company's data type: DC_Main.cs:1495 {{AND DATA_TYPE = 'A' AND MAIN_BOOK = '}} (and the `B` branch next to it).
Status: blocked: the web has no company data type; where `MsDataType` (set from `CON_CODE`, MDI_FORM.cs:12753 {{DC_Main.MsDataType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CON_CODE"], (object)""));}}) lives for a web-provisioned company is a decision outside this menu. Exact question for the owner: "Does a web company have a data type A/B/C, and if so which table column carries it?" Unblocks when answered; until then the list ignores `DATA_TYPE` (the default branch, which has no `DATA_TYPE` term).

### purchase-invoice.formula.preview   (T03 Formula sequence)   **reused**
Unchanged. Also reused: `formula.whole-rupees`, `formula.non-f-rate-types-round-trip`. Status: executable

### purchase-invoice.formula.hm-amount-header-half-to-even   (T03 Formula sequence)
Layer: unit
Steps: hallmark layout; lines G and S with `HmAmt` 36.50 and 40.00; hallmark tax code 18%; tax rounding 2.
Expected: column total 36.50 + 40.00 = 76.50; header `HM_AMT` = Math.Round(76.50, 0) = 76 (half to even; not 77) -> 76.00: TR_PURC_HM.cs:9995 {{mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 39]), 0), "0.00");}}. Hallmark tax = Round(76.00 x 18 / 100, 2) = Round(13.68, 2) = 13.68: TR_PURC_HM.cs:9998 {{Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) * Conversion.Val(mSG2_TOTAL[6, 2]) / 100.0, DC_Main.MsTaxRof)}}. (G3, G4)
Status: executable

### purchase-invoice.formula.hm-total-with-hallmark   (T03 Formula sequence)
Layer: browser
Steps: the inputs above, no discount, no TCS/TDS, round-off cell 0.00.
Expected: net 121,236.00; tax 3% = Round(121,236.00 x 3 / 100, 2) = 3,637.08; total = Round(121,236.00 - 0 + 0 + 76.00 + 13.68 + 3,637.08 + 0, 0) = Round(124,962.76, 0) = 124,963.00: TR_PURC_HM.cs:10029 {{mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[6, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]), 0), "0.00");}}. Header `TOT_AMT` saved = 124,963.00 (TR_PURC_HM.cs:7858 {{dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]) + Conversion.Val(MSG2_TOTAL[4, 3]);}}). (G3, G4)
Status: executable

### purchase-invoice.formula.hm-zero-charge-no-tax   (T03 Formula sequence)
Layer: unit
Steps: no `HmAmt` on any line, hallmark tax code 18% chosen.
Expected: `HM_AMT` 0.00 and `HM_TAX_AMT` 0.00 (the tax is computed from `HM_AMT`: 0.00 x 18 / 100 = 0.00); the code `HMT18` and 18.00 are **still stored** (TR_PURC_HM.cs:7854 {{dataRow2["HM_TAX_CODE"] = MSG2_TOTAL[6, 4];}}, TR_PURC_HM.cs:7855 {{dataRow2["HM_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[6, 2]);}}); total = Round(121,236.00 + 3,637.08, 0) = 124,873.00 (124,873.08 rounds to 124,873). Today the web writes the three hallmark columns only when the charge is positive. (G4)
Status: executable

### purchase-invoice.formula.bar-detl-net-weight-rule   (T03 Formula sequence)
Layer: unit
Steps: `TAG PURCHASE` line with `Net` (col 15) 10.000; case 1 `TgNwt` (col 41) 9.800; case 2 `TgNwt` 0.
Expected: `BAR_DETL.ITM_NWT` = 9.800 in case 1 (TR_PURC_HM.cs:8243 {{dataRow6["ITM_NWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 41]);}}) and 10.000 in case 2 (TR_PURC_HM.cs:8239 {{dataRow6["ITM_NWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 15]);}}, guard TR_PURC_HM.cs:8237 {{if (Conversion.Val(mSG_PR2[DC_Main.i, 41]) == 0.0)}}); `KR_NET_WT` = 10.000 in both (TR_PURC_HM.cs:8246 {{dataRow6["KR_NET_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 15]);}}). (G9)
Status: executable

### purchase-invoice.formula.bar-detl-rate-amount-rule   (T03 Formula sequence)
Layer: unit
Steps: `TAG PURCHASE` line with `TagItAmt` (col 47) 61,000.00 and `TagRate` (col 46) 6,100; case 2 `TagItAmt` 0, line `Rate` (col 25) 6,050 and `ItAmt` (col 26) 60,500.00.
Expected: case 1 `ITM_RATE` 6,100 and `ITM_AMT` 61,000.00, `TAG_COST` = col 52, `ITM_MARGIN` = col 53 (TR_PURC_HM.cs:8304 {{if (Conversion.Val(mSG_PR2[DC_Main.i, 47]) != 0.0)}}, TR_PURC_HM.cs:8306 {{dataRow6["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 46]);}}, TR_PURC_HM.cs:8307 {{dataRow6["ITM_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 47]);}}, TR_PURC_HM.cs:8308 {{dataRow6["TAG_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 52]);}}); case 2 `ITM_RATE` 6,050, `ITM_AMT` 60,500.00, `TAG_COST` = col 34, `ITM_MARGIN` 0 (TR_PURC_HM.cs:8313 {{dataRow6["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 25]);}}, TR_PURC_HM.cs:8315 {{dataRow6["TAG_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 34]);}}, TR_PURC_HM.cs:8316 {{dataRow6["ITM_MARGIN"] = 0;}}). (G9)
Status: executable

### purchase-invoice.field.line-lot-and-stock-route   (T02 Field route)
Layer: browser
Steps: plain and hallmark layouts: set `Lot No` = L7 on line 1, leave `WITH_STOCK` as the screen default; save; reopen; read `PR_DETL`, `LOT_DETL` and the stock report.
Expected: `PR_DETL.LOT_NO` = L7 and `ITM_LOT` as saved, `WITH_STOCK` = `Y` (blank becomes Y: TR_PURC_HM.cs:8012 {{WITH_STOCK}} after TR_PURC_HM.cs:8010 {{mSG_PR[DC_Main.i, 94] = "Y";}}); reopen shows L7 (TR_PURC.cs:12384 {{LOT_NO}}, TR_PURC.cs:12385 {{ITM_LOT}}, TR_PURC.cs:12386 {{WITH_STOCK}}); with `WITH_STOCK` = `N` the stock report shows 0 for that line. Today these three columns are written and never read back (G1).
Status: executable

### purchase-invoice.field.line-loss-ghat-less-touch-route   (T02 Field route)
Layer: database
Steps: line 1: loss weight 0.200, ghat % 2.00, less touch 0.50; save; reopen; save unchanged; compare.
Expected: `ITM_LOSS_WT` 0.200, `ITM_GHT_PRC` 2.00, `ITM_LESS_TCH` 0.50 after the save, after reopen and after the unchanged save (TR_PURC.cs:12394 {{ITM_LOSS_WT}}, TR_PURC.cs:12400 {{ITM_GHT_PRC}}, TR_PURC.cs:12417 {{ITM_LESS_TCH}}); hallmark layout writes them from columns 14, 16, 20 (TR_PURC_HM.cs:7979 {{dataRow3["ITM_LOSS_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);}}). Today they return as 0 after any edit (G1).
Status: executable

### purchase-invoice.field.line-conversion-commission-route   (T02 Field route)
Layer: database
Steps: line 1: conversion rate 6,000, conversion % 98, commission amount 120.00; save; reopen; unchanged save.
Expected: `CONV_RATE` 6,000, `CONV_PRC` 98.00, `COMM_AMT` 120.00 identical at all three stages (TR_PURC.cs:12438 {{CONV_RATE}}, TR_PURC.cs:12439 {{CONV_PRC}}, TR_PURC.cs:12447 {{COMM_AMT}}); hallmark layout: TR_PURC_HM.cs:8003 {{HM_ID_AMT}} is unrelated and stays as set. (G1)
Status: executable

### purchase-invoice.field.line-fine-cut-route   (T02 Field route)
Layer: database
Steps: line 1: fine-cut pieces 2, gross 4.000, net 3.500, fine 3.200; save; reopen; unchanged save.
Expected: `FINE_CUT_PCS` 2, `FINE_CUT_GWT` 4.000, `FINE_CUT_NWT` 3.500, `FINE_CUT_FINE` 3.200 at all stages (TR_PURC.cs:12455 {{FINE_CUT_PCS}}, TR_PURC.cs:12456 {{FINE_CUT_GWT}}, TR_PURC.cs:12457 {{FINE_CUT_NWT}}, TR_PURC.cs:12458 {{FINE_CUT_FINE}}; hallmark: TR_PURC_HM.cs:8019 {{FINE_CUT_PCS}} from col 90, reopen TR_PURC_HM.cs:7531 {{FINE_CUT_PCS}} to col 90). (G1)
Status: executable

### purchase-invoice.field.line-process-code-route   (T02 Field route)
Layer: database
Steps: line 1 process code `PC1`; save; reopen; unchanged save.
Expected: `PR_CODE` = `PC1` at all stages (TR_PURC.cs:12454 {{PR_CODE}}; hallmark: the non-tag branch writes TR_PURC_HM.cs:8067 {{dataRow3["PR_CODE"] = mSG_PR[DC_Main.i, 82];}}). (G1)
Status: executable

### purchase-invoice.field.header-discount-tcs-tds-route   (T02 Field route)
Layer: browser
Steps: header discount 2.00 %, TCS code `TC1`, TDS code `TD1` (both with 1.00 %), save, reopen.
Expected: `DISC_PRC` 2.00, `TCS_CODE` TC1, `TDS_CODE` TD1 stored (TR_PURC_HM.cs:7842 {{dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);}}, TR_PURC_HM.cs:7847 {{dataRow2["TCS_CODE"] = MSG2_TOTAL[3, 4];}}, TR_PURC_HM.cs:7850 {{dataRow2["TDS_CODE"] = MSG2_TOTAL[4, 4];}}); reopen shows 2.00, TC1, TD1 (TR_PURC_HM.cs:7244 {{MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");}}, TR_PURC_HM.cs:7249 {{RsData.Rows[0]["TCS_CODE"]}}, TR_PURC_HM.cs:7252 {{RsData.Rows[0]["TDS_CODE"]}}); the TDS name is read by parent row (TR_PURC_HM.cs:7255 {{SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='}}). (G2)
Status: executable

### purchase-invoice.field.header-bank-card-cheque-route   (T02 Field route)
Layer: browser
Steps: cheque amount with bank account `BK1`, cheque no `000123`, card amount with card account `CD1`; save; reopen.
Expected: `BANK_AC` BK1, `CHQ_NO` 000123, `CARD_AC` CD1 stored (TR_PURC_HM.cs:7866 {{dataRow2["CARD_AC"] = MSG2_TOTAL[10, 4];}}, TR_PURC_HM.cs:7867 {{dataRow2["BANK_AC"] = MSG2_TOTAL[9, 4];}}, TR_PURC_HM.cs:7868 {{dataRow2["CHQ_NO"] = MSG2_TOTAL[9, 2];}}); reopen shows the three (TR_PURC_HM.cs:7288 {{MSG2_TOTAL[9, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));}}, TR_PURC_HM.cs:7289 {{RsData.Rows[0]["CHQ_NO"]}}, TR_PURC_HM.cs:7296 {{RsData.Rows[0]["CARD_AC"]}}). (G2)
Status: executable

### purchase-invoice.field.header-employee-credit-days-address-route   (T02 Field route)
Layer: browser
Steps: employee `E7`, credit days 30, address line 1 "12 Gold St", city "Surat", mobile "9876543210"; save; reopen.
Expected: `EMP_CODE` = E7 (today the writer stores the constant '': purchase.ts:1505), `CR_DAYS` 30, `ADD1`, `CITY`, `MOBILE` stored (TR_PURC_HM.cs:7897 {{dataRow2["EMP_CODE"] = tEmpCode.Text;}}, TR_PURC_HM.cs:7899 {{dataRow2["CR_DAYS"] = Conversion.Val(nCrDays.Text);}}, TR_PURC_HM.cs:7870 {{dataRow2["ADD1"] = tAdd1.Text;}}, TR_PURC_HM.cs:7873 {{dataRow2["CITY"] = tCity.Text;}}, TR_PURC_HM.cs:7874 {{dataRow2["MOBILE"] = tMobile.Text;}}); reopen shows all five (TR_PURC_HM.cs:7321 {{tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));}}, TR_PURC_HM.cs:7340 {{nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));}}, TR_PURC_HM.cs:7330 {{tAdd1.Text}}, TR_PURC_HM.cs:7333 {{tCity.Text}}, TR_PURC_HM.cs:7334 {{tMobile.Text}}). (G2)
Status: executable

### purchase-invoice.field.hm-amount-line-route   (T02 Field route)
Layer: browser
Steps: hallmark layout, line 1 `HmAmt` 36.50; save; reopen; run the purchase register.
Expected: `PR_DETL.HM_ID_AMT` 36.50 (TR_PURC_HM.cs:8003 {{dataRow3["HM_ID_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 39]);}}); reopen shows 36.50 in column 39 (TR_PURC_HM.cs:7519 {{HM_ID_AMT}} to col 39); header `HM_AMT` = Round(36.50, 0) = 36.00 (half to even; 36 is even); no dead field. (G3)
Status: executable

### purchase-invoice.field.hm-tax-code-route   (T02 Field route)
Layer: database
Steps: header hallmark tax code `HMT18` (18%), hallmark amount 76.00; save; reopen; change nothing; save.
Expected: `PR_DATA.HM_TAX_CODE` = HMT18, `HM_TAX_PRC` 18.00, `HM_TAX_AMT` 13.68 (76.00 x 18 / 100) at create, reopen and after the unchanged save; the reopen cell shows HMT18 (TR_PURC_HM.cs:7262 {{MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HM_TAX_CODE"], (object)""));}}). Today `HM_TAX_CODE` is never stored (G91 / G4).
Status: executable

### purchase-invoice.children.two-vouchers-dissimilar-line-columns   (T05 Children)
Layer: database
Steps: voucher V1: two lines, line 1 with lot L7, loss 0.200, fine-cut pcs 2, `HmAmt` 36.50; line 2 with lot L8, conversion 98, process code PC1. Voucher V2: one line with lot L9 and `HmAmt` 10.00. Edit V1 changing only line 2's rate; save.
Expected: V1 line 1 keeps all 14 columns and `HM_ID_AMT` 36.50 byte for byte; line 2 changes only rate-derived columns (rate, amount, tax, net); V2 unchanged (1 line, L9, 10.00): 2 + 1 = 3 detail rows before and after, no value moved between vouchers. Rule: the desktop rewrites only lines whose snapshot changed: TR_PURC_HM.cs:7944 {{if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG_PR[DC_Main.i, 87]), "0.000"), Strings.Format((object)num2, "0.000"), false) != 0)}}. (G1, D6)
Status: executable

### purchase-invoice.children.stone-rows-kept   (T05 Children)
Layer: database
Steps: voucher V1 with 2 stone rows (`PR_IDTL`) on line 1 and 1 on line 2; voucher V2 with 1 stone row; reopen V1, change line 2's rate only, save.
Expected: V1 still 2 + 1 stone rows with identical columns (TR_PURC_HM.cs:7607 {{SELECT A.*,B.IT_NAME FROM}} reads them; the stone write is TR_PURC_HM.cs:8109 {{DELETE FROM}} then insert); V2 still 1 row. (G1, G10)
Status: executable

### purchase-invoice.children.hm-ids-four-with-weights   (T05 Children)
Layer: database
Steps: `TAG PURCHASE` voucher, line 1 with ids H1, H2, H3, H4 and weights 0.100, 0.200, 0.300, 0.400; line 2 with H5 only (0.050); save; reopen; delete line 2; save.
Expected: line 1 `HM_ID` H1 / `HM_ID2` H2 / `HM_ID3` H3 / `HM_ID4` H4 and `HM_ID_WT` 0.100 / `HM_ID2_WT` 0.200 / `HM_ID3_WT` 0.300 / `HM_ID4_WT` 0.400 (TR_PURC_HM.cs:8053 {{dataRow3["HM_ID"] = mSG_PR[DC_Main.i, 55];}}, TR_PURC_HM.cs:8054 {{dataRow3["HM_ID2"] = mSG_PR[DC_Main.i, 58];}}, TR_PURC_HM.cs:8057 {{dataRow3["HM_ID_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 57]);}}, TR_PURC_HM.cs:8058 {{dataRow3["HM_ID2_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 59]);}}); weights read back with three decimals (TR_PURC_HM.cs:7568 {{mSG_PR[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");}}); after the delete only line 1 remains (1 row), its ids and weights intact; the weight sum 0.100 + 0.200 + 0.300 + 0.400 = 1.000 enters the line's snapshot (TR_PURC_HM.cs:7578 {{num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 57])}}). (G3, D5)
Status: executable

### purchase-invoice.children.tag-band-two-lines   (T05 Children)
Layer: database
Steps: `TAG PURCHASE` voucher with two lines of dissimilar tag values (line 1: tag no T-001, `TOthWt` 0.500, `TgNwt` 9.800, `TgTch` 91.60, `TagCost` 61,500.00, margin 5.00; line 2: tag no T-002, `TOthWt` 0.000, `TgNwt` 4.000, `TgTch` 75.00, `TagCost` 20,000.00, margin 8.00).
Expected: `PR_DETL` rows hold per line `TAG_NO`, `TAG_OTH_WT`, `TAG_MARGIN_PRC` (TR_PURC_HM.cs:8029 {{dataRow3["TAG_NO"] = mSG_PR[DC_Main.i, 3];}}, TR_PURC_HM.cs:8030 {{dataRow3["TAG_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 40]);}}, TR_PURC_HM.cs:8062 {{dataRow3["TAG_MARGIN_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 53]);}}) and `WITH_STOCK` = `N` (TR_PURC_HM.cs:8025 {{dataRow3["WITH_STOCK"] = "N";}}); `BAR_DETL` has 2 rows, one per tag, with `ENTRY_TYPE` `I` (TR_PURC_HM.cs:8215 {{dataRow6["ENTRY_TYPE"] = "I";}}), `TAG_NO` as typed, `DATA_TYPE` `A` when blank (TR_PURC_HM.cs:8290 {{dataRow6["DATA_TYPE"] = "A";}}), `APR_ISU` `N` when blank (TR_PURC_HM.cs:8280 {{dataRow6["APR_ISU"] = "N";}}); line 2 values never appear on line 1. (G3, G9)
Status: executable

### purchase-invoice.refusal.no-lines   (T06 Required/invalid)   **reused**
Unchanged. Also reused: `refusal.unknown-item`. Status: executable

### purchase-invoice.refusal.no-party   (T06 Required/invalid)
Layer: browser
Steps: hallmark layout, a line entered, party blank, Save.
Expected: message "Please Insert Party and try", focus returns to the party box, no `PR_DATA` row: TR_PURC_HM.cs:7758 {{Please Insert Party and try}}, TR_PURC_HM.cs:7760 {{((Control)tAcCode).Focus();}}; server returns 400 for the same body.
Status: executable

### purchase-invoice.refusal.date-outside-year   (T06 Required/invalid)
Layer: browser
Steps: voucher date one day before the open year's first day (open year 2026-04-01 to 2027-03-31; date 2026-03-31); Save.
Expected: message "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date..." and no write: TR_PURC_HM.cs:7740 {{You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...}}. Dates 2026-04-01 and 2027-03-31 are accepted (boundary).
Status: executable

### purchase-invoice.refusal.lock-date   (T06 Required/invalid)
Layer: browser
Steps: company lock date 2026-10-31; save a new voucher dated 2026-10-31, then 2026-11-01; also try to edit and to delete a voucher dated 2026-10-31.
Expected: the 2026-10-31 save, edit and delete are refused with "You Cant Save and Delete This Voucher Becouse Lock Date is = " followed by the lock date: TR_PURC_HM.cs:7746 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}, delete: TR_PURC_HM.cs:8589 {{You Cant Save and Delete This Voucher Becouse Lock Date is = }}; the 2026-11-01 save succeeds.
Status: executable

### purchase-invoice.refusal.edit-without-right   (T06 Required/invalid)
Layer: browser
Steps: clerk without the edit right (`FRM_EDIT` not Y) and a voucher whose own `USER_UPDATE` is not Y; reopen and Save.
Expected: message "You Have No Rights....." and no write: TR_PURC_HM.cs:7750 {{UserEdit}}, TR_PURC_HM.cs:7752 {{You Have No Rights.....}}; the voucher's own grant allows the save: TR_PURC_HM.cs:7336 {{UsUPdate = Conversions.ToString}}; server returns 403 on a direct call.
Status: executable

### purchase-invoice.refusal.book-not-purchase-family-create   (T06 Required/invalid)
Layer: database
Steps: `POST /purchases` with each of: book `SL` (SALES), `CN` (CONTRA), `JV` (JOURNAL), `PX` (PURCHASE but `CUR_USE` = N), an unknown book code `ZZ`, and book `TP` (TAG PURCHASE, accepted); valid lines otherwise.
Expected: the first five return 400 with a message naming the book and the family; 0 rows in `PR_DATA`, `PR_DETL`, `AC_DATA`, `MAIN_STOCK` for each; the `TP` request returns 200 (1 voucher). Rule: only `MAIN_BOOK` `PURCHASE` or `TAG PURCHASE` with `CUR_USE` Y is a purchase book: DC_Main.cs:1503 {{CUR_USE = 'Y' AND MAIN_BOOK = '}}, the form's family: TR_PURC_HM.cs:6916 {{FormMainBook = DC_Main.CurBookMain;}}. Today the writer checks only that the book exists and is in use (G6).
Status: executable

### purchase-invoice.refusal.book-not-purchase-family-edit   (T06 Required/invalid)
Layer: database
Steps: voucher V in book `PR`; `PUT` it with the body's book changed to `SL`.
Expected: 400, V unchanged (header, lines, ledger identical, 0 differences). (G6)
Status: executable

### purchase-invoice.refusal.book-family-screen-mismatch   (T06 Required/invalid)
Layer: database
Steps: `POST` with a `TAG PURCHASE` book from the plain layout request and a `PURCHASE` book with `layout=tag` (tag band lines).
Expected: a `PURCHASE` book never stores tag-band columns (stored as zeros and blanks, TR_PURC_HM.cs:8087 {{dataRow3["TAG_TOT_COST"] = 0;}}); a `TAG PURCHASE` book always stores `WITH_STOCK` `N`. Both requests succeed and the stored values are those, never the request's (2 requests, 2 checks). (G3, D5)
Status: executable

### purchase-invoice.refusal.hm-id-without-weight-accepted   (T06 Required/invalid)
Layer: browser
Steps: `TAG PURCHASE` line with id H2 and weight 0.000; save.
Expected: **no refusal**; the save returns 200 and `HM_ID2` = H2, `HM_ID2_WT` = 0.000 are stored. `TR_PURC_HM.cs` has no hallmark weight message; the message exists only in the plain form: TR_PURC.cs:16315 {{Please Insert HmId2 Weight and try...}} (D4, architect, 2026-11-22, owner may override). (G3)
Status: executable

### purchase-invoice.refusal.hm-id-weight-plain-form   (T06 Required/invalid)
Layer: browser
Steps: plain layout, hallmark id 2 without weight.
Expected: N/A (see status).
Status: N/A: the plain web layout has one HUID cell and no `HmId2` to `HmId4` boxes, so the desktop refusal at TR_PURC.cs:16315 {{Please Insert HmId2 Weight and try...}} has no control to attach to; D4.

### purchase-invoice.refusal.licence-and-company-type   (T06 Required/invalid)
Layer: browser
Steps: n/a.
Expected: N/A.
Status: N/A: licence expiry and company type `B` refusals (TR_PURC_HM.cs:7728 {{You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....}}, TR_PURC_HM.cs:7733 {{You Cant Save This Voucher Becouse This Company Type is B......}}) are desktop licensing, not ported (D13).

### purchase-invoice.refusal.old-item-sales-party-fine   (T06 Required/invalid)
Layer: browser
Steps: n/a.
Expected: N/A.
Status: N/A: the "Please Insert Party fine Value or item Amount Valeu and try...." check (the message "Please Insert Party fine Value or item Amount Valeu and try...." in the save checks) applies to the `OLD ITEM SALES` book only, which is out of this study's scope (study Scope).

### purchase-invoice.create.single-line   (T07 Create)   **reused**
Unchanged. Also reused: `create.two-groups`, `create.interstate-supplier`, `create.urd-no-gst`, `create.discount`. Status: executable

### purchase-invoice.create.hm-purchase-full-footprint   (T07 Create)
Layer: database
Steps: hallmark layout, book `PR`, lines G and S with `HmAmt` 36.50 and 40.00, hallmark tax `HMT18`, one stone row on line 1, party P1 (local), cash 0 (credit purchase); save once.
Expected: `PR_DATA`: `NET_AMT` 121,236.00, `HM_AMT` 76.00, `HM_TAX_CODE` HMT18, `HM_TAX_PRC` 18.00, `HM_TAX_AMT` 13.68, tax 3,637.08, `TOT_AMT` 124,963.00 (arithmetic in `formula.hm-total-with-hallmark`); `PR_DETL` 2 rows, `ENTRY_TYPE` `P`, `TAG_NO` `N` (TR_PURC_HM.cs:7968 {{dataRow3["TAG_NO"] = "N";}}), `URD_RATE_TYPE` `F` (TR_PURC_HM.cs:8016 {{dataRow3["URD_RATE_TYPE"] = "F";}}), tag columns zero and blank for a `PURCHASE` book (TR_PURC_HM.cs:8087 {{dataRow3["TAG_TOT_COST"] = 0;}}), `HM_ID_AMT` 36.50 and 40.00; `PR_IDTL` 1 row; ledger: supplier credited 124,963.00 and purchase/tax accounts debited, balanced to 0.00; stock +20.000 gold, +100.000 silver; `BAR_*` tables 0 rows for a `PURCHASE` book. Posting set: TR_PURC_HM.cs:8426 {{Ac_Ledr.Purc_Ledr(DC_Main.MCo_Book, tVchNo.Text);}}, TR_PURC_HM.cs:8432 {{Ac_Tax.Purc_GST(DC_Main.MCo_Book, tVchNo.Text);}}, TR_PURC_HM.cs:8435 {{Ac_Stock.Purc_Stk(DC_Main.MCo_Book, tVchNo.Text);}}. (G3, G4)
Status: executable

### purchase-invoice.create.tag-purchase-bar-footprint   (T07 Create)
Layer: database
Steps: `TAG PURCHASE` book `TP`, two tag lines of `children.tag-band-two-lines`, one stone row, save once.
Expected: `PR_DATA` 1, `PR_DETL` 2, `PR_IDTL` 1, `BAR_DATA` rows for the voucher (TR_PURC_HM.cs:8157 {{DELETE FROM BAR_DATA}} then insert), `BAR_DETL` 2 (columns per the mapping rules in `formula.bar-detl-*`; the fixed zero columns `JDT_JDT_WT`, `JDT_GHT_WT`, `JDT_KUN_WT`, `JDT_KUN_TOUCH`, `JDT_KUN_NET`, `JDT_WAX_WT`, `KR_WAX_WT` = 0: TR_PURC_HM.cs:8319 {{dataRow6["JDT_JDT_WT"] = 0;}}, `SF_NO` blank: TR_PURC_HM.cs:8318 {{dataRow6["SF_NO"] = "";}}), `SRNO_MAST` rows for the tags (TR_PURC_HM.cs:8333 {{DELETE FROM SRNO_MAST}}), `BAR_IDTL` for the stone (TR_PURC_HM.cs:8355 {{DELETE FROM BAR_IDTL}}), and the tag-set rows (TR_PURC_HM.cs:8514 {{DELETE FROM TAG_SET}}). Counts: 1 + 2 + 1 + 2 = 6 rows in the four direct tables, all written in one transaction. (G3, G9)
Status: executable

### purchase-invoice.create.number-assignment-two-sessions   (T07 Create)
Layer: database
Steps: last purchase number in the book is 00005; two sessions each open a new purchase (both are shown 00006), save one after the other.
Expected: first save 00006, second save 00007 (MAX 6 + 1 = 7, five digits), both vouchers exist (2 `PR_DATA` rows), no overwrite; the second user is told the assigned number in the saved message. Rule: TR_PURC_HM.cs:7787 {{tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");}} (D11).
Status: executable

### purchase-invoice.reopen.round-trip   (T08 Reopen/no-op)   **reused**
Unchanged. Status: executable

### purchase-invoice.edit.unchanged-no-op   (T08 Reopen/no-op)   **reused**
Unchanged (compares the supplied fields; the cases below compare every stored column). Status: executable

### purchase-invoice.reopen.all-detail-columns-unchanged-save   (T08 Reopen/no-op)
Layer: database
Steps: seed or save a voucher (plain and hallmark layouts) with all 14 study columns non-default on line 1 (`LOT_NO` L7, `ITM_LOT` 7, `WITH_STOCK` N, `ITM_LOSS_WT` 0.200, `ITM_GHT_PRC` 2.00, `ITM_LESS_TCH` 0.50, `CONV_RATE` 6,000, `CONV_PRC` 98.00, `COMM_AMT` 120.00, `FINE_CUT_PCS` 2, `FINE_CUT_GWT` 4.000, `FINE_CUT_NWT` 3.500, `FINE_CUT_FINE` 3.200, `PR_CODE` PC1). `GET`, then `PUT` the same body, dump `PR_DETL` by column name before and after.
Expected: 0 differing columns on every line (14 of 14 equal). Rule: the desktop reads every column and keeps it in a grid cell: TR_PURC.cs:12364 {{SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM}}, TR_PURC_HM.cs:7462 {{SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM}}. Today all 14 reset to 0/blank. (G1, G10)
Status: executable

### purchase-invoice.reopen.all-header-columns-unchanged-save   (T08 Reopen/no-op)
Layer: database
Steps: voucher with header values non-default: `DISC_PRC` 2.00, `TCS_CODE` TC1, `TDS_CODE` TD1, `CHQ_NO` 000123, `BANK_AC` BK1, `CARD_AC` CD1, `CR_DAYS` 30, `EMP_CODE` E7, `ADD1`/`CITY`/`MOBILE`, `HM_AMT` 76.00, `HM_TAX_CODE` HMT18, `PARTY_FINE` 1.250. `GET` then `PUT` unchanged; dump `PR_DATA` by column.
Expected: 0 differing columns apart from the audited clock columns (`VCH_TIME` and the user-edit audit row, TR_PURC.cs:13753 {{INSERT INTO USER_DATA}}); `EMP_CODE` stays E7 (today it becomes ''), `PARTY_FINE` stays 1.250 (TR_PURC_HM.cs:7232 {{nPartyFine.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["PARTY_FINE"], (object)"")), "0.000");}}). (G2, G10)
Status: executable

### purchase-invoice.reopen.desktop-shaped-voucher   (T08 Reopen/no-op)
Layer: database
Steps: seed a voucher shaped like the desktop's own save (hallmark layout, `PURCHASE` book): `PR_DETL.HM_ID_AMT` 36.50, `ITM_COLOR` RED, `DESIGN_IMG_ID` D5, `TAG_TYPE`, `TAG_SRNO` 3, `PR_CODE` PC1, `WITH_STOCK` Y, `FINE_CUT_*`, plus the tag columns as zeros; reopen through the browser and save unchanged.
Expected: 0 differing columns in `PR_DATA`, `PR_DETL`, `PR_IDTL` (including `ITM_COLOR`, `DESIGN_IMG_ID`, `TAG_SRNO`, which the web writer does not write today: TR_PURC_HM.cs:7973 {{ITM_COLOR}}, TR_PURC_HM.cs:8006 {{DESIGN_IMG_ID}}, TR_PURC_HM.cs:7522 {{TAG_SRNO}}); reopen shows RED, D5 and 3 (TR_PURC_HM.cs:7573 {{ITM_COLOR}} to col 7, TR_PURC_HM.cs:7572 {{DESIGN_IMG_ID}} to col 86). (G1, G3)
Status: executable

### purchase-invoice.reopen.tag-band-from-pr-detl   (T08 Reopen/no-op)
Layer: database
Steps: `TAG PURCHASE` voucher saved with the tag band (two tags); reopen; save unchanged; dump `PR_DETL` and `BAR_DETL` by column.
Expected: 0 differing columns in both tables (the `BAR_DETL` row keeps all its columns, not only the 16 the web reads today); the tag band returns from `PR_DETL` (TR_PURC_HM.cs:7538 {{mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(}}, TR_PURC_HM.cs:7539 {{TAG_OTH_WT}}, TR_PURC_HM.cs:7552 {{TAG_COST}}, TR_PURC_HM.cs:7559 {{TAG_MARGIN_PRC}}). (G9, G10)
Status: executable

### purchase-invoice.reopen.item-master-changed-keeps-stored   (T08 Reopen/no-op)
Layer: database
Steps: save a gold line (item rate type `F`, item type `G`); change the item master to rate type `N` and type `S`; reopen and save unchanged.
Expected: stored `RATE_TYPE` stays `F` and `IT_TYPE` stays `G` (0 changes); item name shows the current master name. D12 (architect, 2026-11-22, owner may override): the desktop would show the master's values (TR_PURC_HM.cs:7462 {{SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM}}); the web keeps stored values. (G10)
Status: executable

### purchase-invoice.edit.change-rate   (T09 Edit)   **reused**
Unchanged. Status: executable

### purchase-invoice.edit.hm-amount-changes-header-total   (T09 Edit)
Layer: database
Steps: voucher of `create.hm-purchase-full-footprint`; change line 1 `HmAmt` from 36.50 to 46.50; save.
Expected: column total 46.50 + 40.00 = 86.50 -> Round(86.50, 0) = 86 (half to even) -> `HM_AMT` 86.00; `HM_TAX_AMT` = Round(86.00 x 18 / 100, 2) = 15.48; `TOT_AMT` = Round(121,236.00 + 86.00 + 15.48 + 3,637.08, 0) = Round(124,974.56, 0) = 124,975.00; line 2 untouched; ledger re-posted to 124,975.00 (balanced). TR_PURC_HM.cs:9995 {{mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 39]), 0), "0.00");}}. (G3, G4)
Status: executable

### purchase-invoice.edit.one-column-only   (T09 Edit)
Layer: database
Steps: voucher with all 14 columns and header columns set; change only line 1's lot number to L9; save.
Expected: exactly 1 differing column in `PR_DETL` line 1 (`LOT_NO`) and `LOT_DETL` follows; every other column of every line and of `PR_DATA` identical (apart from audited clocks). (G1, G10)
Status: executable

### purchase-invoice.delete.reverses   (T10 Delete/cancel/reverse)   **reused**
Unchanged. Status: executable

### purchase-invoice.delete.hm-write-set-removed   (T10 Delete/cancel/reverse)
Layer: database
Steps: delete a `TAG PURCHASE` voucher (with stones, tags) while a second voucher of the same kinds exists.
Expected: 0 rows for the deleted voucher in `AC_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`, `DM_DATA`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL` and one `DELETE_DATA` audit row; the second voucher's rows all intact; confirmation "Are You Sure To Delete This Voucher now?" and result "Delete Success.": TR_PURC_HM.cs:8605 {{DELETE FROM AC_DATA}}, TR_PURC_HM.cs:8606 {{DELETE FROM ROJ_MEL_DATA}}, TR_PURC_HM.cs:8607 {{DELETE FROM TAX_DATA}}, TR_PURC_HM.cs:8608 {{DELETE FROM DM_DATA}}, TR_PURC_HM.cs:8615 {{DELETE FROM BAR_DATA}}, TR_PURC_HM.cs:8616 {{DELETE FROM BAR_DETL}}, TR_PURC_HM.cs:8617 {{DELETE FROM BAR_IDTL}}, TR_PURC_HM.cs:8597 {{INSERT INTO DELETE_DATA}}, TR_PURC_HM.cs:8595 {{Are You Sure To Delete This Voucher now?}}, TR_PURC_HM.cs:8619 {{Delete Success.}}. Every delete scoped by company, location, year, book and voucher number. (G3)
Status: executable

### purchase-invoice.delete.refused-when-tag-sold   (T10 Delete/cancel/reverse)
Layer: database
Steps: purchase with a tag line; sell that tag on a Sales Invoice; delete the purchase.
Expected: refused with "You Cant Delete This Voucher Because  Tag Use in Sales Transection...." (two spaces before "Tag"): TR_PURC.cs:13849 {{You Cant Delete This Voucher Because  Tag Use in Sales Transection....}}; purchase and tag rows unchanged (counts equal before and after); after the sale is deleted the purchase deletes.
Status: executable

### purchase-invoice.delete.refused-without-right   (T10 Delete/cancel/reverse)
Layer: browser
Steps: clerk without the delete right presses Delete on a saved voucher.
Expected: message "You Have No Rights....." and the voucher untouched: TR_PURC_HM.cs:8593 {{You Have No Rights.....}}; API 403.
Status: executable

### purchase-invoice.edit.item-code-frozen-after-tag   (T09 Edit)
Layer: browser
Steps: purchase line that created a tag; reopen; change the item code.
Expected: message "You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag..." and the code is unchanged: TR_PURC.cs:10485 {{You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag...}}.
Status: executable

### purchase-invoice.rights.clerk-no-purchase   (T11 Scope/rights)   **reused**
Unchanged. Status: executable

### purchase-invoice.rights.book-family-direct-api   (T11 Scope/rights)
Layer: database
Steps: a user with the purchase right calls `POST /purchases` with a Sales book code, then calls with a book code that belongs to another company, and with a voucher number that belongs to another tenant.
Expected: 400 / 404 / 404; 0 rows written and the other tenant's rows unchanged (count equal before and after); no leak of the other tenant's book name in the message. Hosted-service safety (the desktop is single company). (G6)
Status: executable

### purchase-invoice.rights.tenant-scope-reopen   (T11 Scope/rights)
Layer: database
Steps: tenant A `GET`/`PUT`/`DELETE` a voucher number that exists only in tenant B.
Expected: 404 each; B's header, lines, stones, tags unchanged (row counts equal). Hosted-service rule. (G1, G2)
Status: executable

### purchase-invoice.concurrency.stale-second-save   (T12 Concurrency)   **reused**
Unchanged. Status: executable

### purchase-invoice.concurrency.edit-vs-delete   (T12 Concurrency)
Layer: database
Steps: sessions A and B load voucher V; A deletes it; B saves an edit.
Expected: B receives a defined not-found/conflict (404 or 409) and V is not resurrected (0 `PR_DATA` rows for V afterwards, 0 orphan `PR_DETL` rows); ledger and stock stay reversed. Hosted rule. (G1)
Status: executable

### purchase-invoice.retry.double-click   (T13 Retry/unknown)   **reused**
Unchanged. Status: executable

### purchase-invoice.retry.lost-acknowledgement-hm   (T13 Retry/unknown)
Layer: database
Steps: save a hallmark voucher; drop the response after commit; resend the same request key.
Expected: the same voucher number is returned; counts: 1 `PR_DATA`, 2 `PR_DETL`, 1 `PR_IDTL`, one ledger set (no duplicates). Hosted rule. (G3)
Status: executable

### purchase-invoice.rollback.stock-write-fault   (T14 Rollback)   **reused**
Unchanged. Status: executable

### purchase-invoice.rollback.hm-write-faults   (T14 Rollback)
Layer: database
Steps: fault injection after `PR_DATA`, after `PR_DETL`, after `PR_IDTL`, after `BAR_DATA`, after `BAR_DETL`, after `BAR_IDTL`, after `SRNO_MAST`, after the ledger posting, on a new `TAG PURCHASE` voucher and on an edit of an existing one; a sentinel voucher present.
Expected: 8 faults x 2 operations: 0 rows of the new voucher anywhere; for the edit the original voucher is byte-identical; sentinel untouched. The desktop hallmark form writes statement by statement (TR_PURC_HM.cs:7801 {{DC_Main.ExeQuteDc(}}) and can leave a partial voucher; the web keeps one transaction (not ported weakness). (G3)
Status: executable

### purchase-invoice.config.amount-type-gross   (T15 Config/history)   **reused**
Unchanged. Also reused: `settings.labour-to-slot-4`. Status: executable

### purchase-invoice.config.purc-with-hmtax-flips-between-open-and-save   (T15 Config/history)
Layer: browser
Steps: setting `N`; open `Purchase` (plain layout), enter Line G; in another session set `PURC_WITH_HMTAX` to `Y`; save; reopen the voucher; open `Purchase` again.
Expected: the save succeeds with the plain-layout values (net 113,836.00; `HM_AMT` 0.00); the reopened voucher shows with the layout current at reopen (hallmark) and every stored value unchanged (0 differences); the new open shows the hallmark layout. The setting is read when the company is opened (MS_OPNCOMP.cs:974 {{PURC_WITH_HMTAX}}), not per request; the web re-reads it per screen open. (G5)
Status: executable

### purchase-invoice.config.history-reopen-after-rate-and-tax-change   (T15 Config/history)
Layer: database
Steps: save line G at 3% tax; change the tax master to 5%; reopen and save unchanged.
Expected: stored `TAX_PRC` 3.00 and tax 3,415.08 (113,836.00 x 3% = 3,415.08) stay; no recomputation at 5% (would be 5,691.80). (G10)
Status: executable

### purchase-invoice.print.after-access-expiry   (T16 Report/output)   **reused**
Unchanged. Also reused: `print.date-with-year`. Status: executable

### purchase-invoice.print.template-tax-book-a4   (T16 Report/output)
Layer: browser
Steps: print a voucher of a tax book (`FormBookType` T), half-page box unticked.
Expected: template `PurcBillA4Gst`: TR_PURC_HM.cs:8768 {{PurcBillA4Gst.RPT}}; the opening and closing gold parameters are **not** passed for a tax book: TR_PURC_HM.cs:8740 {{Cr[(short)2] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";}} runs only when the book type is not `T`.
Status: executable

### purchase-invoice.print.template-tax-book-half   (T16 Report/output)
Layer: browser
Steps: same, half-page box ticked.
Expected: template `PurcBillHalfGst`: TR_PURC_HM.cs:8764 {{PurcBillHalfGst.RPT}} (guard TR_PURC_HM.cs:8762 {{if (PrHalfPrint)}}).
Status: executable

### purchase-invoice.print.template-non-tax-book-gold-parameters   (T16 Report/output)
Layer: database
Steps: print a voucher of a non-tax book; supplier gold opening balance 100.000 and the voucher adds fine 18.320 (line G fine).
Expected: template `PurcBillA4`: TR_PURC_HM.cs:8773 {{PurcBillA4.RPT}}; parameters `OpGold = 100.000` and `ClGold = 118.320` (100.000 + 18.320; three decimals): TR_PURC_HM.cs:8740 {{Cr[(short)2] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";}}, TR_PURC_HM.cs:8741 {{Cr[(short)3] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";}}, closing from the party-fine rule TR_PURC_HM.cs:10111 {{CustClGold = CustOpGold + PurcAcFine;}}.
Status: executable

### purchase-invoice.print.refused-without-right   (T16 Report/output)
Layer: browser
Steps: user without the print right presses Print.
Expected: message "You Have No Print Rights....." and no document: TR_PURC_HM.cs:8662 {{You Have No Print Rights.....}}; print endpoint 403.
Status: executable

### purchase-invoice.output.register-hm-total   (T16 Report/output)
Layer: browser
Steps: after `create.hm-purchase-full-footprint` run the purchase register for the date.
Expected: the row shows net 121,236.00, tax 3,637.08, total 124,963.00; after `edit.hm-amount-changes-header-total` the same row shows 124,975.00 (one row, not two); after delete the row is gone (0 rows). Header `TOT_AMT` is the figure written at TR_PURC_HM.cs:7858 {{dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]) + Conversion.Val(MSG2_TOTAL[4, 3]);}}. (G3, G4)
Status: executable

### purchase-invoice.keyboard.voucher-number-keys   (T17 Keyboard/usability)   **reused**
Unchanged. Also reused: `keyboard.alt-s-saves`. In the hallmark layout the same keys apply: F1 help, Up last, Down first, Enter loads: TR_PURC_HM.cs:8930 {{if ((int)e.KeyCode == 112)}}, TR_PURC_HM.cs:8934 {{if ((int)e.KeyCode == 38)}}, TR_PURC_HM.cs:8938 {{if ((int)e.KeyCode == 40)}}; "Last Record..." at the end: TR_PURC_HM.cs:9023 {{Last Record...}}. Status: executable

### purchase-invoice.keyboard.hm-grid-escape-and-delete-row   (T17 Keyboard/usability)
Layer: browser
Steps: hallmark grid, edit a cell, press Esc; then Ctrl+D on a row, answer No, then Yes.
Expected: Esc closes the cell editor and jumps to the totals grid: TR_PURC_HM.cs:8628 {{if ((int)e.KeyCode == 27)}}; the delete prompt "This Row Record will Removed permantley ?" shows each time (TR_PURC_HM.cs:3946 {{This Row Record will Removed permantley ?}}), No keeps the row, Yes removes it and shows "Record is Deleted....Please Save Voucher....." (TR_PURC_HM.cs:3986 {{Record is Deleted....Please Save Voucher.....}}); the database still holds the row until Save (row count before Save = N, after Save = N - 1).
Status: executable

### purchase-invoice.keyboard.hm-grid-enter-walk   (T17 Keyboard/usability)
Layer: browser
Steps: hallmark grid, press Enter through a whole line from the item code to the last column.
Expected: the cell order and defaults of `TEXT_PR_KeyDown` (lines 4977 to 5718 of the hallmark form).
Status: blocked: the study did not transcribe the key-by-key Enter walk of `TEXT_PR_KeyDown` (lines 4977-5718; study Open question 1), so no cell order can be asserted. Exact request for the supervisor: "Add a study addendum transcribing the Enter/Tab order, skipped cells and default values of TEXT_PR_KeyDown for the PURCHASE and TAG PURCHASE books." Unblocks when the addendum exists; then add one case per column group.

### purchase-invoice.journey.stock-and-register   (T18 Full journey)   **reused**
Unchanged. Status: executable

### purchase-invoice.journey.hm-purchase-to-ledger-stock-register   (T18 Full journey)
Layer: browser
Steps: create the hallmark purchase of `create.hm-purchase-full-footprint`; open the supplier ledger, the stock report, the purchase register and the GST report; edit `HmAmt` as in `edit.hm-amount-changes-header-total`; delete.
Expected: supplier ledger Cr 124,963.00 (then 124,975.00 after the edit, then 0.00 after delete); stock +20.000 gold and +100.000 silver (and back to 0 after delete); register 1 row 124,963.00 then 124,975.00 then 0 rows; the GST report shows tax 3,637.08 and the hallmark tax 13.68 (then 15.48) on the hallmark-tax code, and nothing after delete. (G3, G4)
Status: executable

### purchase-invoice.journey.tag-purchase-to-tag-stock-and-sale   (T18 Full journey)
Layer: browser
Steps: `TAG PURCHASE` voucher with two tags; open tag stock; sell tag T-001 on a Sales Invoice; try to delete the purchase; delete the sale; delete the purchase.
Expected: tag stock shows 2 tags after the purchase, 1 after the sale, the purchase delete is refused while the tag is sold (TR_PURC.cs:13849 {{You Cant Delete This Voucher Because  Tag Use in Sales Transection....}}), 2 after the sale is deleted, 0 after the purchase is deleted.
Status: executable

## Coverage table

| Kind | Cases | Blocked | N/A |
|---|---|---|---|
| T01 Entry/defaults | 8 | 0 | 0 |
| T02 Field route | 10 | 0 | 0 |
| T03 Formula sequence | 6 | 0 | 0 |
| T04 Lookup | 4 | 1 | 0 |
| T05 Children | 4 | 0 | 0 |
| T06 Required/invalid | 12 | 0 | 3 |
| T07 Create | 4 | 0 | 0 |
| T08 Reopen/no-op | 7 | 0 | 0 |
| T09 Edit | 4 | 0 | 0 |
| T10 Delete/cancel/reverse | 4 | 0 | 0 |
| T11 Scope/rights | 4 | 0 | 0 |
| T12 Concurrency | 2 | 0 | 0 |
| T13 Retry/unknown | 2 | 0 | 0 |
| T14 Rollback | 2 | 0 | 0 |
| T15 Config/history | 3 | 0 | 0 |
| T16 Report/output | 6 | 0 | 0 |
| T17 Keyboard/usability | 3 | 1 | 0 |
| T18 Full journey | 3 | 0 | 0 |

Total 88 case entries: 83 executable (19 of them reuse an existing id unchanged, some entries name several), 3 N/A, 2 blocked.

## Test data

- Company A (web-provisioned), settings `TAX_ROF` 2, `TOT_AMT_ROF` 0, amount type `F`; `PURC_WITH_HMTAX` = `N` for the plain cases and `Y` for the hallmark cases (a second company B for the other value).
- Books: `PR` (PURCHASE, active), `PR2` (PURCHASE, `USER_EMP_CODE` E7), `PX` (PURCHASE, `CUR_USE` N), `TP` (TAG PURCHASE), `SL` (SALES), `CN` (CONTRA), `JV` (JOURNAL); a book of another company; a tax book (type T) and a non-tax book.
- Items: gold item (existing fixture, rate type F, type G), silver item; a tag item. Item master can be changed during the case.
- Parties: P1 (local supplier, gold opening balance 100.000), P2 (interstate); employee E7; bank BK1, card CD1; TCS TC1, TDS TD1 (1.00 % each); tax codes `HMT18` (18 %), `HMT05` (5 %), 3 % purchase tax.
- Vouchers: V1/V2 (children cases), a desktop-shaped voucher (D-1) with the 14 columns, header columns and hidden snapshot values, a `TAG PURCHASE` voucher (T-1) with two tags, stones and `BAR_*` rows, a sale of tag T-001 (for the delete refusal).
- Users: admin, clerk (no edit, delete, print right), a user with employee code E7, a user with employee code E8, a second tenant with the same book codes and voucher numbers.
- Company lock date 2026-10-31; open year 2026-04-01 to 2027-03-31.

## Not covered

- Cell-by-cell Enter order and defaults of the 95 columns (blocked case `keyboard.hm-grid-enter-walk`; study Open question 1).
- `DATA_TYPE` narrowing of the book list (blocked case `lookup.books-data-type-filter`; D10).
- Pixel layout of `PurcBillA4`, `PurcBillA4Gst`, `PurcBillHalfGst`: cases prove template choice and parameter values only.
- Karigar receipt, old item sales, purchase quotation, purchase return, consignment and other-expense books (study Scope: out of scope); the `OLD ITEM SALES` party-fine refusal and the UAE-only controls (`chkRateUnFix`, `chkHalfPrint` visible for company short name UAE: TR_PURC_HM.cs:6947 {{((Control)chkRateUnFix).Visible = true;}}) are not covered.
- Bill-image and WhatsApp/e-mail options (`chkBillImage`, `chkWapp`), `Mobile_image_Save` and the quotation button paths (study Open question 6).
- `HmFine` (column 76) and the shadow-copy helper columns (70-75, 77-81, 84-89) beyond what the unchanged-save cases compare: they are not stored columns of their own (they feed the stored fine and weights), so the full-column comparison covers them indirectly.
- Print of old gold / old silver prompts ("Old Silver Purchase Print... ?", "Old Gold Purchase Print... ?"): desktop print dialog prompts, not a stored value.
