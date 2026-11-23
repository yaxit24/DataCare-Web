# WP-29 cases — Purchase Rtn residuals (G95, G96, open cases)

Authority: `unified/src/csharp/DataCareNext/TR_KR_ISU.cs`, `PURC RETURN` mode. Study: `study.md`. Existing browser module:
`web/apps/web/test/features/modules/purchaseReturn.mjs` (22 cases; ids below keep their `purchase-return.` prefix).
Cases marked NEW are added by this package; "kept" cases already exist and are not re-written.

## Decisions (architect, 2026-11-23, owner may override)
Rule applied: the desktop first; the web adds only what a hosted multi-user service needs to be safe and correct.
- D1 Print right. The desktop gates print on `FRM_PRINT` (TR_KR_ISU.cs:5434 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}).
  Decision: the Purchase Return print route guards `'print'` not `'view'`. Only this route changes; the sales print (txn.ts:1410) is
  left for a cross-family decision (study open question 3).
- D2 Per-line tax. The desktop writes 0 on every return line (TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}) and the report reads only the
  header. Decision: the web writes 0 on `PR_DETL.TAX_PRC`; the header keeps rate and amounts. Nothing in the web reads the line column
  (reopen reads PR_DATA.TAX_PRC). No data migration: old rows keep the header rate on the line, which no reader uses. (If the owner wants
  the old rows zeroed, it must use the repo pattern of 20261109090000.)
- D3 Fine / Amount editable stops: not ported. They are the compact layout's computed cells (layout residual N77); the Enter walk asserts
  the web's own editable order and that the walk never stops on a read-only cell, as the desktop skip loop does
  (TR_KR_ISU.cs:3743 {{while (mSG[mSG.Col] == 0)}}).
- D4 Settings variant (T15 `config.setting-variant`): stays blocked. The fixture company is N166's, outside this menu; the expectation is
  not loosened.
- D5 Version token. A hosted service has concurrent editors; the desktop has none. Edit (PUT) and delete require the `expectedVersion`
  returned by the read, as purchaseVoucher.ts:45 does (N51/D17). A missing token is 400, a stale token 409 `voucher-version-conflict`,
  with no write. The token covers PURCHASE_RETURN_WRITE_TABLES. Lossless reopen/edit (stored date, typed amounts, fine, bill no, hidden
  number, creator, clock) is kept: the desktop re-writes the same identity (TR_KR_ISU.cs:4624 {{mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");}}).
- D6 Delete audit and Esc/Ctrl+D keys of the desktop editor are out of scope (kept as in the module / not ported).

## Cases

### purchase-return.print.hsn-tax-intra   (T16 Report/output)
Layer: browser (and database: `purchaseReturnWp29.db.test.ts` print-hsn-intra)
Steps: 1. Save LINE_W (net 5, touch 80, rate 1500, making 40/g, tax 3%, intra-state) for supplier PARTIES.local. 2. Open the print from Recent vouchers. 3. Slice the table with class `hsn`.
Expected: the HSN row shows taxable 6,200.00, CGST 93.00, SGST 93.00, tax 186.00 and no tax cell is `0.00`. Arithmetic: 6,200 x 3% = 186.00; the desktop splits the header tax in two halves, 186.00 / 2 = 93.00 (TR_KR_ISU.cs:5102 {{dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;}}); the template is chosen for a tax book (TR_KR_ISU.cs:5519 {{PrRtnBillGst.RPT}}). Gap G95.
Status: executable

### purchase-return.print.hsn-tax-inter   (T16 Report/output)
Layer: browser (and database: print-hsn-inter)
Steps: 1. Save LINE_W for the inter-state supplier PARTIES.interState. 2. Print. 3. Slice the `hsn` table.
Expected: IGST 186.00, CGST and SGST cells absent or not printed as amounts; whole tax in IGST (TR_KR_ISU.cs:5095 {{dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);}}). Gap G95.
Status: executable

### purchase-return.print.hsn-tax-zero   (T16 Report/output)
Layer: database
Steps: 1. Save a return at tax 0%. 2. Print.
Expected: header IGST/CGST/SGST/TAX_AMT all 0 (zero tax writes three zeros, TR_KR_ISU.cs:5108-5110 {{dataRow2["IGST_TAX"] = 0;}}); the print still lists the HSN row with taxable 6,200.00. The desktop report suppresses each zero tax section; the web HSN table shows 0.00 cells (layout, not ported).
Status: executable

### purchase-return.print.debit-note   (T16 Report/output) kept
Layer: browser
Steps: as in the module. Expected: `Purchase Return` and `6,386` (net 6,200 + tax 186, TR_KR_ISU.cs:6528 {{Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]), 0)}}).
Status: executable

### purchase-return.print.rights-denied   (T11 Scope/rights)
Layer: database
Steps: 1. A user with FRM_VIEW=Y, FRM_PRINT=N for Purchase Return requests GET /purchase-returns/:no/print. 2. A user with both gets it.
Expected: 403 and no document for the first; 200 `text/html` for the second. Desktop: {{You Have No Print Rights.....}} (TR_KR_ISU.cs:5436 {{You Have No Print Rights.....}}). Gap G95 (rights). D1.
Status: executable

### purchase-return.rights.clerk-no-return   (T11) kept
Layer: browser. Status: executable

### purchase-return.line.tax-prc-zero   (T07 Create)
Layer: database
Steps: 1. Save LINE_W at tax 3%. 2. Read PR_DETL.TAX_PRC and PR_DATA.TAX_PRC.
Expected: every PR_DETL.TAX_PRC = 0, PR_DATA.TAX_PRC = 3, TAX_AMT 186. Desktop: TR_KR_ISU.cs:5206 {{dataRow3["TAX_PRC"] = 0;}}. Gap 6 / D2.
Status: executable

### purchase-return.keyboard.enter-walk   (T17 Keyboard)
Layer: browser
Steps: 1. Focus Item on row 1. 2. Press Enter through Tag, Pcs, Gross, Net Wt, Touch%, Rate, Making/g asserting the focused cell after each. 3. Press Enter on Making/g. 4. Type a second line and the web has no Ctrl+D; the row x button is not a stop.
Expected: after Making/g the focus is row 2 Item (a row was appended), never the read-only Fine or Amount cells or the x button; the grid has 2 rows. Desktop: Enter advances one column (TR_KR_ISU.cs:3699 {{mSG.Col += 1;}}), read-only columns are walked past (TR_KR_ISU.cs:3743 {{while (mSG[mSG.Col] == 0)}}), and Enter on the last row's last cell adds a row and restarts at column 1 (TR_KR_ISU.cs:3680 {{mSG.Rows += 1;}}, TR_KR_ISU.cs:3683 {{mSG.Col = 1;}}). Gap G96. D3.
Status: executable

### purchase-return.keyboard.enter-middle-row   (T17 Keyboard)
Layer: browser
Steps: 1. With two rows, focus row 1 Making/g. 2. Press Enter.
Expected: focus moves to row 2 Item and no third row is appended. Desktop: on any other row it goes to the next row, column 1 (TR_KR_ISU.cs:3690 {{mSG.Row += 1;}}). Gap G96.
Status: executable

### purchase-return.keyboard.enter-walk-unit   (T17 Keyboard)
Layer: unit
Steps: 1. `walkEnter` over a DOM-less cell model: cells [item, tag, readonly fine, button, last].
Expected: Enter on the cell before a read-only cell lands on the next editable one; Enter on the last editable cell of the last row appends. (Decision-table covered in gridKeyboard.test.ts; the skip is the new assertion.) Gap G96.
Status: executable

### purchase-return.keyboard.alt-s-saves   (T17) kept
Layer: browser. Status: executable

### purchase-return.edit.version-required   (T06 Required/invalid)
Layer: database
Steps: 1. PUT /purchase-returns/:no with a full payload and no expectedVersion. 2. DELETE with no expectedVersion.
Expected: 400 `expectedVersion (the version returned when the voucher was opened) is required`; snapshot of the tenant unchanged. D5.
Status: executable

### purchase-return.edit.stale-version   (T12 Concurrency)
Layer: database
Steps: 1. Read the voucher (version V1). 2. Save an edit with V1 (version V2 returned). 3. A second session PUTs with V1 and DELETEs with V1.
Expected: 409 `voucher-version-conflict` for both; rows unchanged after step 2. D5.
Status: executable

### purchase-return.edit.version-roundtrip   (T08 Reopen/no-op)
Layer: database
Steps: 1. Create, read (V1). 2. PUT the read payload unchanged with V1. 3. Read again.
Expected: save returns a version, tenant rows unchanged except surrogate keys; date, bill no, tender, per-line fine and the clock are identical; the returned version equals the next read's version (the token changes because the write set is re-inserted). Desktop re-writes the same identity (TR_KR_ISU.cs:4625 {{tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));}}).
Status: executable

### purchase-return.delete.version-ok   (T10 Delete)
Layer: database
Steps: 1. Read (V1). 2. DELETE with V1.
Expected: 200; PR_DATA, PR_DETL, ledger, stock rows gone; one DELETE_DATA audit row (TR_KR_ISU.cs:5373 {{INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE}}). The browser delete (loaded form and recent list) sends the token.
Status: executable

### purchase-return.reopen.load / edit.unchanged-and-reprice / delete.reverses   (T08/T09/T10) kept
Layer: browser; the browser page now carries the token. Status: executable

### purchase-return.entry.defaults   (T01) kept
Layer: browser. Expected: tax 3, empty first line (TR_KR_ISU.cs:4563-4577 {{TAX_CODE = '10'}}). Status: executable

### purchase-return.formula.whole-rupees   (T03) kept
Layer: browser. LINE_P: fine 9.160, item round(56,090.802) = 56,091 (TR_KR_ISU.cs:4015 {{Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * Conversion.Val(mSG[mSG.Row, 24]), 0)}}). Status: executable

### purchase-return.create.amounts / create.effects / create.without-original / create.against-purchase / create.two-groups / create.interstate-igst   (T02/T05/T07) kept
Layer: browser. Status: executable

### purchase-return.refusal.no-lines / refusal.no-upi   (T06) kept
Layer: browser. Status: executable

### purchase-return.concurrency.double-delete / retry.double-click   (T12/T13) kept
Layer: browser. Status: executable

### purchase-return.rollback.mid-write   (T14) kept
Layer: browser (fault matrix over 7 tables). Status: executable (study gap 7: no longer blocked)

### purchase-return.journey.purchase-then-return / report.register-lists-return   (T18/T16) kept
Layer: browser. Status: executable

### purchase-return.config.setting-variant   (T15 Config/history)
Layer: browser
Steps: save LINE_P under a company with TAX_ROF 0 and 3.
Expected: TAX_ROF 0 -> tax round(1,753.98, 0) = 1,754, total 60,220; TAX_ROF 3 -> 1,753.980 (TR_KR_ISU.cs:6527 {{DC_Main.MsTaxRof}}). Gap 5.
Status: blocked: no settings-variant company in the catalogue (N166 / G174 owns the fixture); unblocks when N166 lands.

## Coverage table
| Kind | Cases | Blocked | Notes |
|---|---|---|---|
| T01 Entry/defaults | 1 | 0 | entry.defaults (kept) |
| T02 Field route | 2 | 0 | create.amounts, create.interstate-igst (kept) |
| T03 Formula sequence | 1 | 0 | formula.whole-rupees (kept) |
| T04 Lookup | 0 | 0 | N/A: supplier/item lookups are shared widgets, covered by their own modules; this package does not change them |
| T05 Children | 1 | 0 | create.two-groups (kept) |
| T06 Required/invalid | 3 | 0 | refusal.no-lines, refusal.no-upi (kept), edit.version-required (NEW) |
| T07 Create | 3 | 0 | create.effects (kept), line.tax-prc-zero (NEW), create.against-purchase (kept) |
| T08 Reopen/no-op | 2 | 0 | reopen.load (kept), edit.version-roundtrip (NEW) |
| T09 Edit | 1 | 0 | edit.unchanged-and-reprice (kept) |
| T10 Delete/cancel | 2 | 0 | delete.reverses (kept), delete.version-ok (NEW) |
| T11 Scope/rights | 2 | 0 | rights.clerk-no-return (kept), print.rights-denied (NEW) |
| T12 Concurrency | 2 | 0 | double-delete (kept), edit.stale-version (NEW) |
| T13 Retry/unknown | 1 | 0 | retry.double-click (kept) |
| T14 Rollback | 1 | 0 | rollback.mid-write (kept) |
| T15 Config/history | 1 | 1 | config.setting-variant, blocked on N166 |
| T16 Report/output | 6 | 0 | print.debit-note (kept), hsn-tax-intra, hsn-tax-inter, hsn-tax-zero (NEW), report.register-lists-return (kept) |
| T17 Keyboard | 4 | 0 | alt-s-saves (kept), enter-walk, enter-middle-row, enter-walk-unit (NEW) |
| T18 Full journey | 1 | 0 | journey.purchase-then-return (kept) |

New cases: 11 (4 browser + 7 database/unit; browser-layer new: hsn-tax-intra, hsn-tax-inter, enter-walk, enter-middle-row). Total listed: 33 (22 kept + 11 new); 1 blocked.

## Test data
- The module's fixture company: gold item with HSN from group/item, local supplier PARTIES.local, inter-state supplier PARTIES.interState, return book PRT/348, LINE_W (net 5, touch 80, rate 1500, making 40/g) and LINE_P.
- DB tests: a seeded tenant with book 348, supplier SUPP01, item GOLD, group G01 with an HSN code, three users (full rights; view-only with FRM_PRINT=N; editor).

## Not covered
- UAE variant, karigar/metal modes, stone rows (`PR_IDTL`): out of scope per the study.
- Editable Fine/Amount cells and rate back-solving (study gap 4): layout residual N77, D3.
- Sales print route right (`txn.ts:1410`): cross-family decision, D1.
- Esc and Ctrl+D editor keys: web has a row x button instead; not part of G96.
- Registration-keyed branches (VK252NUST, HM437NEHP): not ported, study weaknesses.
