# WP-15 Report → Tag Stock: frozen case list (T01–T18)

Source: `orchestration/work/WP-15/study.md` (14 gaps), the supervisor decisions in the work packet, and
`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` §3. Case ids are `tag-stock.<group>.<name>`.
The existing helpers in `web/apps/web/test/features/modules/tagCancel.mjs` (API and grid helpers for `/api/reports/tag-stock`)
and `tagOpening.mjs` (Tag Opening setup) are reused for seeding; no `tagStock.mjs` exists yet (study: MISSING).

## Conventions

- **Scope (decision 1):** Lite menu Report → Tag Stock: six Tag Wise modes (Stock Tag, In Tag, Out Tag, Mrp Tag, Apr Pending,
  All Tag), Tag Summ and Product Stk. MDI_FORM.cs:8893 {{RP_TAG rP_TAG = new RP_TAG();}}
- **Lite settings (decision 6):** no wholesale columns, no company merge, edition not E. Test clock: system date = 31/05/2026,
  financial year 01/04/2026–31/03/2027, current location L1, data type "all".
- **Stock rule (decision 2):** a tag instance (company, location, tag no, tag id, item) is in stock when
  `sum(+id for '+', -id for '-') > 0`, where id is VCH_SRNO. RP_TAG.cs:4187 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0";}}
- **Totals (decision 3):** footer and CSV cover every selected row, no cap (gap 7).
- A case marked `executable` runs on the isolated database only. "Seed B" and "Seed X" are defined under `## Test data`.
- Deliberate differences from the desktop are labelled **DELIBERATE** (supervisor decisions 4).
- Voucher type codes (VCH_TYPE) and voucher numbers come from the vouchers the seed creates through the screens; the test reads
  them back and sorts them itself (MISSING: fixed VCH_TYPE codes for the sale, cancel and approval books are not in the study).
  Seed vouchers of one type use equal-length numbers (0001, 0002) so text and numeric order agree.

---

## T01 Entry and defaults

### tag-stock.entry.navigation   (T01 Entry/defaults)
Layer: browser
Steps: 1. Sign in as a user with List and Print rights. 2. Click the Report tab, then the menu caption "Tag Stock".
Expected: the Tag Stock screen opens from the Report menu with no query run (grid empty, footer zero). Desktop constructs the form without arguments and load does not query: RP_TAG.cs:3714 {{CurActCtrl = (Control)(object)mFromDt;}} Menu is Lite (`menu-editions.json:1501-1508`). Fails today: gap 8 (page auto-loads stock on open).
Status: executable

### tag-stock.entry.defaults-dates-focus   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open Tag Stock with test clock 31/05/2026. 2. Read From, To and the focused control.
Expected: From = 31/05/2026, To = 31/05/2026, focus in From. RP_TAG.cs:3711 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}} RP_TAG.cs:3713 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}} RP_TAG.cs:3714 {{CurActCtrl = (Control)(object)mFromDt;}} Fails today: gap 8 (no date fields).
Status: executable

### tag-stock.entry.defaults-selectors   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the screen. 2. Read RptType, It Type, Size, Location, Book, TagNo and the six action button captions.
Expected: RptType = "Tag Wise" (index 0); It Type list in order blank, Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum with Gold selected when the metal setting is G; Size blank; Location = current location L1 (shown only if the location box setting is on); buttons "Stock Tag", "In Tag", "Out Tag", "Mrp Tag", "Apr Pending", "All Tag" (plus Print, Summ, Excel, Cancel, Counter, Exit). RP_TAG.cs:3642 {{cboRptType.Items.Add((object)"Tag Wise");}} RP_TAG.cs:3627 {{cboItemTyp.Items.Add((object)"Gold");}} RP_TAG.cs:3700 {{tLcCode.Text = DC_Main.MLc_code;}} Fails today: gap 8.
Status: executable

### tag-stock.entry.size-list   (T01 Entry/defaults)
Layer: browser
Steps: 1. With Seed B (sizes "7", "8", "18" on tags) open the Size list.
Expected: blank, 18, 7, 8 (distinct non-empty BAR_DETL sizes of the company/location, sorted as text: "18" < "7" < "8"). RP_TAG.cs:3645 {{GROUP BY ITM_SIZE  ORDER BY ITM_SIZE}} Fails today: gap 8.
Status: executable

### tag-stock.entry.summ-relabel   (T01 Entry/defaults)
Layer: browser
Steps: 1. Set RptType to "Tag Summ". 2. Read the caption of the sixth action button.
Expected: "Product Stk" replaces "All Tag". RP_TAG.cs:9744 {{BtnAll.Text = "Product Stk";}} Fails today: gap 8.
Status: executable

### tag-stock.entry.no-photo-no-component-grid   (T01 Entry/defaults; gap 13)
Layer: browser
Steps: 1. Run Stock Tag (Seed B). 2. Click row A001. 3. Look for a photograph panel and a component grid.
Expected: neither is present, and no request to the tag image endpoint is made. RP_TAG.cs:3484 {{((Control)PicImage).Visible = false;}} Fails today: gap 13 (web always mounts the image panel with instance 0).
Status: executable

### tag-stock.entry.diagnostics-and-repair-absent   (T01 Entry/defaults; decision 4)
Layer: browser
Steps: 1. Double-click the bottom panel. 2. Focus TagNo and press F1. 3. Inspect the page for "Zero Tag Id", "Adjust" and the diagnostics grid. 4. Call the API for a repair/adjust route.
Expected: nothing opens, no confirm "Re Adjust This Tag..." appears, and no API route that updates MAIN_STOCK or BOOK_TBL_DETL exists (404/405). The desktop would show the panel and run the repair: RP_TAG.cs:9658 {{((Control)pnlDiff).Visible = true;}} RP_TAG.cs:10727 {{"Re Adjust This Tag..."}} **DELIBERATE** (decision 4; not ported).
Status: executable

### tag-stock.entry.hidden-columns-default   (T01 Entry/defaults; gap 9)
Layer: browser
Steps: 1. Run Stock Tag (Seed B). 2. List the visible column headers.
Expected: CoCode, Book, BookName, AcCode, Remark are not visible; Day and VchDate are visible (no registration override). RP_TAG.cs:4825 {{((ColumnView)GridView1).Columns["CoCode"].Visible = false;}} RP_TAG.cs:4836 {{((ColumnView)GridView1).Columns["Book"].Visible = false;}} Visible order for Stock and MRP: LcCode, VchTyp, VchNo, VchDate, Day, TagNo, ItCode, Counter, Design, Style, Size, Qty, Pcs, Grwt, NetWt, LbrRate, Lbrprc, LbrAmt, OthAmt, PrCost, Mrp, KrName, TagId, SafeName (study "Screen" table, RP_TAG.cs:4124 {{SELECT C.CO_CODE As CoCode}}). Fails today: gap 9.
Status: executable

### tag-stock.entry.column-order-per-mode   (T01 Entry/defaults; gap 9)
Layer: browser
Steps: 1. Run each of In, Out, Apr, All on Seed B. 2. Read visible headers in order.
Expected: In and Out start VchTyp, VchNo, VchDate, Day, TagNo, ItCode, Counter, Design, Style, Size, Qty, Pcs, Grwt, NetWt (Out then LbrRate, Lbrprc; In then Lbrprc, LbrRate), Apr is VchTyp, VchNo, VchDate, TagNo, ItCode, PartyName, Design, Style, Counter, Size, Qty..., All is VchTyp, VchNo, VchDate, TagNo, ItCode, Counter, Design, Size, Qty, Pcs, Grwt, NetWt, LbrRate, Lbrprc, LbrAmt, OthAmt, Mrp, KrName, TagId, Sign, EmpIsu, SafeName. Sources: RP_TAG.cs:4009 {{SELECT C.CO_CODE As CoCode}} RP_TAG.cs:4070 {{SELECT A.CO_CODE As CoCode}} RP_TAG.cs:4216 {{SELECT A.CO_CODE As CoCode}} RP_TAG.cs:4278 {{SELECT A.CO_CODE As CoCode}} Fails today: gap 9.
Status: executable

---

## T02 Field route (each filter, exact row ids)

All filter cases use Seed B at To = 31/05/2026 and compare the exact set of (TagNo, TagId) instances.

### tag-stock.filter.date-range-in   (T02; gaps 3, 8)
Layer: browser
Steps: 1. Mode In Tag. 2. From 01/04/2026, To 07/04/2026, Apply. 3. Change From to 08/04/2026, To 30/04/2026, Apply.
Expected: first run rows A001, A003, A004, A005, A006, A007 (BAR_DETL VCH_DATE inclusive in range; A002 created 10/04 excluded); second run only A002. Inclusive bounds, BAR_DETL creation date, not availability. RP_TAG.cs:4009 {{C.TAG_NO <> 'N' AND C.VCH_DATE >= '}} Fails today: gaps 1, 3, 8 (web has no date and reads every positive movement).
Status: executable

### tag-stock.filter.date-range-out   (T02; gaps 3, 8)
Layer: browser
Steps: 1. Mode Out Tag. 2. From 01/04/2026, To 30/04/2026, Apply. 3. From 01/05/2026, To 31/05/2026, Apply.
Expected: first run: movements A003 sale (20/04), A005 sale (20/04), A004 cancel (25/04) = 3 rows; second run: A006 approval issue (15/05) = 1 row. Out reads negative movements by movement date. RP_TAG.cs:4070 {{AND A.ITM_SIGN = '-'}} Fails today: gap 3.
Status: executable

### tag-stock.filter.stock-ignores-from   (T02; gaps 3, 8)
Layer: browser
Steps: 1. Mode Stock Tag. 2. From 01/05/2026, To 31/05/2026, Apply. 3. Change From to 01/01/2020, Apply.
Expected: identical rows both times (A001, A002, A005, A007); From is ignored, only movement date <= To counts. RP_TAG.cs:4124 {{A.TAG_NO <> 'N' AND A.VCH_DATE <= '}} Fails today: gap 3.
Status: executable

### tag-stock.filter.stock-as-of-date   (T02; T03; gap 3)
Layer: browser
Steps: 1. Mode Stock Tag, To = 15/04/2026. 2. Apply. 3. Change To to 30/04/2026, Apply. 4. To 31/05/2026, Apply.
Expected: Movements are counted up to To only. To 15/04: A001, A002, A003, A004, A005, A006, A007 (each has only the opening plus: 7 rows); To 30/04: sale and cancel are in, so A001, A002, A006, A007 (A005 = +105 -105 = 0 out; A003 and A004 out); To 31/05: A001, A002, A005 (+105 -105 +105 = 105), A007 (A006 approved 15/05: +106 -106 = 0 out). Arithmetic per instance is in `tag-stock.stock.*`. Fails today: gap 3 (no as-of date, web balances every date).
Status: executable

### tag-stock.filter.item   (T02)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Item = GR (Gold Ring), Apply. 3. Item = SC, Apply.
Expected: GR → A001, A002, A005; SC → A007. RP_TAG.cs:4136 {{AND B.IT_CODE =}}
Status: executable

### tag-stock.filter.product   (T02; gap 8)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Product = P1 (Rings), Apply; then P2 (Chains).
Expected: P1 → A001, A002, A005; P2 → A007. RP_TAG.cs:4140 {{AND B.PR_CODE =}} Fails today: gap 8.
Status: executable

### tag-stock.filter.group   (T02; gap 8)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Group = G1, Apply; then G2.
Expected: G1 → A001, A002, A005; G2 → A007. RP_TAG.cs:4144 {{AND B.GR_CODE =}} Fails today: gap 8.
Status: executable

### tag-stock.filter.item-type   (T02; gap 8)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. It Type = "Gold", Apply; then "Silver", then blank.
Expected: Gold (IT_TYPE G) → A001, A002, A005; Silver (S) → A007; blank → all four. The first character of the shown type is used. RP_TAG.cs:4148 {{Strings.Mid(cboItemTyp.Text, 1, 1)}} Fails today: gap 8.
Status: executable

### tag-stock.filter.tagno   (T02; gap 8)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. TagNo = A002, Apply.
Expected: exactly A002 (1 row). RP_TAG.cs:4156 {{AND C.TAG_NO =}} Fails today: gap 8.
Status: executable

### tag-stock.filter.size   (T02; gap 8)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Size = 8, Apply; then 18.
Expected: size 8 → A002 only; 18 → A007 only (tag size C.ITM_SIZE). RP_TAG.cs:4132 {{AND C.ITM_SIZE =}} Fails today: gap 8.
Status: executable

### tag-stock.filter.size-all-mode   (T02; gap 8)
Layer: browser
Steps: 1. All Tag, From 01/04, To 31/05. 2. Size = 8, Apply.
Expected: movement-size filter: the single movement of A002 (1 row). RP_TAG.cs:4290 {{AND A.ITM_SIZE =}} Fails today: gap 8.
Status: executable

### tag-stock.filter.book-in-mode   (T02; gap 8; decision 4)
Layer: browser
Steps: 1. In Tag, From 01/04, To 07/04. 2. Book = the Tag Opening book of A001 (OPSTK book TOP), Apply. 3. Book = a book holding no tag, Apply.
Expected: with TOP: all six tags of that date range whose BAR_DETL book is TOP; with the empty book: zero rows, no error. The desktop SQL names an alias that does not exist in In mode: RP_TAG.cs:4013 {{AND A.CO_BOOK =}} **DELIBERATE**: the web applies the evidently intended book filter instead of failing. Fails today: gap 8.
Status: executable

### tag-stock.filter.book-other-modes   (T02; gap 8)
Layer: browser
Steps: 1. Out Tag, From 01/04, To 31/05, Book = the sale book of A003 and A005. 2. Apply.
Expected: only the two sale movements A003 and A005 (the cancel and approval movements use other books). RP_TAG.cs:4013 {{AND A.CO_BOOK =}} Fails today: gap 8.
Status: executable

### tag-stock.filter.search-box   (T02; gap 8)
Layer: browser
Steps: 1. Stock Tag, To 31/05, Apply. 2. Type "A00" into Search; then "A002"; then "ZZ".
Expected: after the query the grid is filtered by TagNo containing the text: "A00" keeps A001, A002, A005, A007; "A002" keeps A002; "ZZ" shows zero rows. Footer follows the visible filtered rows. RP_TAG.cs:3819 {{TagNo Like}} Fails today: gap 8.
Status: executable

### tag-stock.filter.emp-isu-less   (T02; gap 8)
Layer: database
Steps: 1. Seed X tag A013 (EMP_ISU = 'Y', positive balance) and A014 (EMP_ISU NULL, positive balance). 2. Stock API with and without Emp Isu Less.
Expected: with the option off both appear; with it on A013 is removed, and A014 (NULL) is also removed because SQL NULL does not satisfy `<>`; the option is for edition E only, so in Lite the box is not shown and the default request leaves both. RP_TAG.cs:4124 {{AND C.EMP_ISU <> 'Y'}} Fails today: gap 8.
Status: blocked: the option is shown only in edition E (RP_TAG.cs:3695 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}); needs the supervisor to confirm edition E is out of scope for the Lite certification. The "box not shown in Lite" half is executable as `tag-stock.entry.defaults-selectors`.

### tag-stock.filter.location   (T02; gap 8)
Layer: database
Steps: 1. Seed X: tag AL1 in location L2 (same company). 2. API Stock To 31/05 with location L1, then L2, then blank.
Expected: L1: base four stock rows only; L2: only AL1; blank: base four plus AL1. RP_TAG.cs:4124 {{AND A.LC_CODE = '}} Fails today: gap 8.
Status: executable

### tag-stock.filter.mrp-nonzero   (T02; gap 5)
Layer: database
Steps: 1. Seed B plus Seed X tag A008 (positive balance, ITM_MRP = -100). 2. API Mrp Tag To 31/05.
Expected: rows A001 (30000), A002 (20000), A005 (12000) and A008 (-100); A007 (MRP 0) excluded. Totals Qty 4, Mrp = 30000 + 20000 + 12000 - 100 = 61900. RP_TAG.cs:4152 {{DC_Main.RsQry += "AND C.ITM_MRP <> 0";}} Fails today: gap 5 (web uses > 0 and drops A008).
Status: executable

### tag-stock.filter.sentinel-n   (T02; gap 4)
Layer: database
Steps: 1. Seed X: a BAR_DETL/MAIN_STOCK row with TAG_NO 'N' (the item-level movement Tag Opening writes), balance positive. 2. API each of In, Out, Stock, Mrp, Apr, All.
Expected: no row has TagNo = 'N' in any mode. RP_TAG.cs:4278 {{A.TAG_NO <> 'N'}} Fails today: gap 4.
Status: executable

### tag-stock.filter.year-and-datatype   (T02; gap 3)
Layer: database
Steps: 1. Seed X: tag AY1 with movements in financial year 2025-26 (CO_YEAR other) and tag AD1 with DATA_TYPE different from the session data type. 2. API Stock, Out, All with the session year and data type.
Expected: neither AY1 nor AD1 appears in Stock, Out or All (In uses the data-type rule too except combined type C). RP_TAG.cs:4124 {{A.TAG_NO <> 'N' AND A.VCH_DATE <= '}} Fails today: gap 3.
Status: executable

### tag-stock.filter.all-specific-tag-bypasses-dates   (T02; T03; gap 2)
Layer: browser
Steps: 1. All Tag, From 01/05/2026, To 31/05/2026, TagNo empty, Apply. 2. Same dates, TagNo = A005, Apply.
Expected: first run: movements dated in May only: A005 return (10/05) and A006 approval issue (15/05) = 2 rows. Second run: the three A005 movements regardless of dates: +05/04, -20/04, +10/05 = 3 rows. RP_TAG.cs:4286 {{And A.VCH_DATE >=}} Fails today: gap 2.
Status: executable

---

## T03 Formula sequence (stock state, totals, display)

### tag-stock.stock.cancelled-tag   (T03; decision 2)
Layer: database
Steps: 1. Seed B A004 (id 104): opening +104 on 05/04; Tag Cancel voucher on 25/04 posts -104. 2. API Stock To 31/05; then Stock To 20/04.
Expected: To 31/05: sum = +104 - 104 = 0, not > 0 → A004 absent. To 20/04: sum = +104 → present. Tag Cancel writes a minus: TR_TAG_CAN.cs:5144 {{dataRow3["ITM_SIGN"] = "-";}} and the sign is copied into MAIN_STOCK. Ac_Stock.cs:54 {{CASE WHEN A.ITM_SIGN = '+' THEN 'I' ELSE 'O' END,A.ITM_SIGN}} RP_TAG.cs:4187 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0";}}
Status: executable

### tag-stock.stock.sold-tag   (T03; decision 2)
Layer: database
Steps: 1. A003 (id 103): opening +103 on 05/04; sale voucher 20/04 posts -103. 2. API Stock To 31/05; Stock To 19/04.
Expected: To 31/05: +103 - 103 = 0 → absent; To 19/04: +103 = 103 → present. Ac_Stock.cs:114 {{A.IT_CODE,A.TAG_NO,A.VCH_SRNO,A.TBL_CODE,'S','-'}}
Status: executable

### tag-stock.stock.returned-sale-tag   (T03; decision 2)
Layer: database
Steps: 1. A005 (id 105): opening +105 (05/04), sale -105 (20/04), sale return +105 (10/05). 2. API Stock To 30/04 and To 31/05.
Expected: To 30/04: +105 - 105 = 0 → absent. To 31/05: +105 - 105 + 105 = 105 > 0 → present, one row (not three), Qty 1. Ac_Stock.cs:247 {{A.IT_CODE,A.TAG_NO,A.VCH_SRNO,A.TBL_CODE,'I','+'}} Ac_Stock.cs:247 {{FROM  SL_DETL_RTN AS A}} Replacement outward lines of a sale return are minus rows: Ac_Stock.cs:245 {{A.IT_CODE,A.TAG_NO,A.VCH_SRNO,A.TBL_CODE,'O','-'}} (not asserted here: the seed returns only the tag).
Status: executable

### tag-stock.stock.approval-pending-tag   (T03; decision 2; gap 6)
Layer: database
Steps: 1. A006 (id 106): opening +106 (05/04), approval issue (APR ISU, book out) -106 (15/05), no return. 2. API Stock To 14/05 and To 31/05. 3. Then record an approval return (+106 on 25/05) and run Stock To 31/05.
Expected: To 14/05: +106 → present. To 31/05 (pending): +106 - 106 = 0 → absent. After return: +106 - 106 + 106 = 106 → present. Ac_Stock.cs:68 {{A.IT_CODE,A.TAG_NO,A.VCH_SRNO,A.TBL_CODE,'O','-'}} Ac_Stock.cs:81 {{A.TBL_CODE,'I','+'}} The report tests the movement balance, not BAR_DETL.APR_ISU.
Status: executable

### tag-stock.stock.sale-against-approval-compensates   (T03)
Layer: database
Steps: 1. Seed X tag AA1 (id 201): +201 opening, approval issue -201, then a sale against that approval (ISU_NO non-empty) posting sale -201 and compensating +201. 2. API Stock To 31/05.
Expected: sum = +201 - 201 - 201 + 201 = 0 → absent (the sale leaves it out once, not twice). Ac_Stock.cs:120 {{AND A.ISU_NO <> ''}} RP_TAG.cs:4187 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0";}}
Status: executable

### tag-stock.stock.zero-id-and-missing-bardetl   (T03)
Layer: database
Steps: 1. Seed X: tag AZ0 with VCH_SRNO 0 and one plus movement; tag AM1 with a MAIN_STOCK plus movement but no BAR_DETL row; tag AI1 whose MAIN_STOCK item differs from BAR_DETL item. 2. API Stock.
Expected: none appears (zero id: +0 = 0 is not > 0; no BAR_DETL or item mismatch fails the inner join). RP_TAG.cs:4124 {{And A.IT_CODE = C.IT_CODE}}
Status: executable

### tag-stock.stock.instance-key-two-ids   (T03)
Layer: database
Steps: 1. Seed X: tag "A100" with two BAR_DETL instances id 301 and id 302 (same TagNo); instance 301 sold (+301 -301), instance 302 only +302.
Expected: exactly one row (A100, id 302); asserted by key (TagNo, TagId), not tag text. Sums: 301: 0 (absent); 302: +302 > 0 (present). RP_TAG.cs:4187 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0";}}
Status: executable

### tag-stock.total.stock-mode   (T03; decision 3)
Layer: browser
Steps: 1. Seed B. Stock Tag, To 31/05, Apply. 2. Read the footer.
Expected: rows A001, A002, A005, A007. Qty = 1+1+1+1 = 4; Pcs = 1+2+1+1 = 5; Grwt = 5.000+3.000+2.000+10.000 = 20.000; NetWt = 4.800+2.900+1.900+10.000 = 19.600; Mrp = 30000+20000+12000+0 = 62000; PrCost = 25000+16000+9000+4000 = 54000; LbrAmt = 500+300+200+100 = 1100; OthAmt = 100+50+20+0 = 170. Footer sums: RP_TAG.cs:4916 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");}} RP_TAG.cs:4976 {{((ColumnView)GridView1).Columns["Mrp"].Summary.Add((SummaryItemType)0, "Mrp", "{0}");}} Qty is constant 1 and weights are the BAR_DETL weights: RP_TAG.cs:4124 {{1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt}} Fails today: gap 9 (no Gross, Pcs, PrCost, Lbr, Oth totals).
Status: executable

### tag-stock.total.mrp-mode   (T03)
Layer: browser
Steps: 1. Mrp Tag, To 31/05. 2. Read rows and footer.
Expected: A001, A002, A005 (A007 has MRP 0): Qty 3; Pcs 1+2+1 = 4; Grwt 5+3+2 = 10.000; NetWt 4.8+2.9+1.9 = 9.600; Mrp 62000; PrCost 25000+16000+9000 = 50000; LbrAmt 1000; OthAmt 170. RP_TAG.cs:4152 {{DC_Main.RsQry += "AND C.ITM_MRP <> 0";}}
Status: executable

### tag-stock.total.in-mode   (T03)
Layer: browser
Steps: 1. In Tag, From 01/04, To 07/04.
Expected: rows A001, A003, A004, A005, A006, A007: Qty 6; Pcs 6; Grwt 5+4+1+2+6+10 = 28.000; NetWt 4.8+3.8+0.95+1.9+5.8+10 = 27.250; Mrp 30000+25000+8000+12000+40000+0 = 115000; PrCost 25000+20000+6000+9000+33000+4000 = 97000; LbrAmt 500+400+100+200+600+100 = 1900; OthAmt 100+80+10+20+120+0 = 330. RP_TAG.cs:4009 {{C.TAG_NO <> 'N' AND C.VCH_DATE >= '}} Fails today: gap 1 (web returns only tags with a positive movement and every positive movement).
Status: executable

### tag-stock.total.out-mode   (T03)
Layer: browser
Steps: 1. Out Tag, From 01/04, To 31/05.
Expected: four minus movements: A003 sale, A005 sale, A004 cancel, A006 approval. Qty 4; Pcs 4; Grwt 4+2+1+6 = 13.000; NetWt 3.8+1.9+0.95+5.8 = 12.450; Mrp (movement MRP, A.ITM_MRP, equal to the tag MRP in the seed) 25000+12000+8000+40000 = 85000; LbrAmt 400+200+100+600 = 1300; OthAmt 80+20+10+120 = 230. RP_TAG.cs:4070 {{AND A.ITM_SIGN = '-'}} Out weights are the movement weights: RP_TAG.cs:4070 {{FORMAT(A.ITM_GWT,'0.000') As Grwt,FORMAT(A.ITM_NWT,'0.000') AS NetWt}}
Status: executable

### tag-stock.total.apr-mode   (T03; gap 6)
Layer: browser
Steps: 1. Apr Pending, To 31/05 (answer "No" to "Tour Outword Stock Show....?" and "No" to "Report With Other Detail Item Name...").
Expected: one row A006 with BAR_DETL values: Pcs 1, Grwt 6.000, NetWt 5.800, Mrp 40000, PrCost 33000, LbrAmt 600, OthAmt 120; footer Qty 1. Web today returns APR_DETL weights and MRP 0. RP_TAG.cs:4227 {{AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N'}} Fails today: gap 6.
Status: executable

### tag-stock.total.all-mode   (T03; gap 2)
Layer: browser
Steps: 1. All Tag, From 01/04, To 31/05, TagNo empty.
Expected: 12 movement rows (8 plus, 4 minus): A001 1, A002 1, A003 2, A004 2, A005 3, A006 2, A007 1. Qty = 12; Pcs = 1+2+1×2+1×2+1×3+1×2+1 = 13; Grwt = 5+3+4×2+1×2+2×3+6×2+10 = 46.000; NetWt = 4.8+2.9+3.8×2+0.95×2+1.9×3+5.8×2+10 = 44.500; Mrp = 30000+20000+25000×2+8000×2+12000×3+40000×2+0 = 232000; LbrAmt = 500+300+400×2+100×2+200×3+600×2+100 = 3700; OthAmt = 100+50+80×2+10×2+20×3+120×2+0 = 630. RP_TAG.cs:4278 {{A.ITM_SIGN As Sign}} Fails today: gap 2 (web returns 7 rows, one per tag).
Status: executable

### tag-stock.total.all-mode-sign-column   (T03; gap 2)
Layer: browser
Steps: 1. All Tag as above. 2. Read the Sign column for A005.
Expected: three rows in date order with Sign "+", "-", "+" (05/04, 20/04, 10/05). RP_TAG.cs:4278 {{A.ITM_SIGN As Sign}}
Status: executable

### tag-stock.total.day-column   (T03)
Layer: browser
Steps: 1. Stock Tag, To 31/05 with test clock 31/05/2026. 2. Read Day for A001 (stock date 05/04) and A002 (stock date 10/04). 3. Out Tag, read Day for A003 (sale 20/04) and A004 (cancel 25/04).
Expected: Stock/In: Day = system date − stock date: A001 = 25 (05/04→30/04) + 31 = 56; A002 = 20 + 31 = 51. Out: movement date − stock date: A003 = 20/04 − 05/04 = 15; A004 = 25/04 − 05/04 = 20. RP_TAG.cs:4070 {{DATEDIFF(day,format(C.STK_DATE,'yyyy-MM-dd'),format(A.VCH_DATE,'yyyy-MM-dd')) As Day}} Fails today: gap 9 (no Day column).
Status: executable

### tag-stock.display.number-formats   (T03; gap 9)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Read Grwt of A001, NetWt of A002, LbrAmt of A001 as displayed.
Expected: Grwt "5.000", NetWt "2.900", LbrAmt "500" (n3 for weights, n0 for amounts), footer Grwt "20.000". The stored value is not rounded. RP_TAG.cs:4942 {{((ColumnView)GridView1).Columns["Grwt"].DisplayFormat.FormatString = "{0:n3}";}} RP_TAG.cs:5257 {{((ColumnView)GridView1).Columns["LbrAmt"].DisplayFormat.FormatString = "{0:n0}";}} Fails today: gap 9.
Status: executable

### tag-stock.total.no-row-cap   (T03; T16; decision 3; gap 7)
Layer: database
Steps: 1. Seed X bulk: 5,200 additional tags (more than the current 5,000 cap and more than one page), each with one plus movement, pcs 1, gross 1.000, net 0.900, MRP 100, cost 80, labour 5, other 1. 2. API Stock To 31/05 (JSON and CSV) and the browser footer.
Expected: totals cover every row: Qty = 4 + 5200 = 5204; Pcs = 5 + 5200 = 5205; Grwt = 20.000 + 5200 × 1.000 = 5220.000; NetWt = 19.600 + 5200 × 0.900 = 4699.600; Mrp = 62000 + 520000 = 582000; PrCost = 54000 + 416000 = 470000; LbrAmt = 1100 + 26000 = 27100; OthAmt = 170 + 5200 = 5370. The CSV has 5204 data rows plus one TOTAL row with the same figures. RP_TAG.cs:4322 {{DGV_FILL();}} Fails today: gap 7 (web caps at 5000 rows and totals the capped set).
Status: executable

### tag-stock.total.footer-filtered-by-search   (T03)
Layer: browser
Steps: 1. Stock Tag, To 31/05; Search "A00" then "A002". 2. Read footer.
Expected: "A002": Qty 1, Pcs 2, Grwt 3.000, NetWt 2.900, Mrp 20000, PrCost 16000, LbrAmt 300, OthAmt 50. Footer sums only bound rows: RP_TAG.cs:4946 {{((ColumnView)GridView1).Columns["Grwt"].Summary.Add((SummaryItemType)0, "Grwt", "{0}");}}
Status: executable

### tag-stock.summ.in-by-item   (T03; gap 8)
Layer: browser
Steps: 1. RptType Tag Summ, mode In, From 01/04, To 07/04.
Expected: grouped by item, ordered by item name: "Gold Ring": Qty 5, Pcs 5, Grwt 5+4+1+2+6 = 18.000, NetWt 4.8+3.8+0.95+1.9+5.8 = 17.250; "Silver Chain": Qty 1, Pcs 1, Grwt 10.000, NetWt 10.000. Footer: Qty 6, Pcs 6, Grwt 28.000, NetWt 27.250. IT_TYPE column hidden. RP_TAG.cs:7866 {{DC_Main.RsQry += "GROUP BY C.IT_CODE,B.IT_NAME,B.IT_TYPE ";}} RP_TAG.cs:8396 {{((ColumnView)GridView1).Columns["IT_TYPE"].Visible = false;}} Fails today: gap 8.
Status: executable

### tag-stock.summ.out-by-item   (T03; gap 8)
Layer: browser
Steps: 1. Tag Summ, Out, From 01/04, To 31/05, size filter blank.
Expected: Out aggregates the negative MAIN_STOCK rows directly: "Gold Ring": Qty 4 (A003, A005, A004, A006), Pcs 4, Grwt 4+2+1+6 = 13.000, NetWt 3.8+1.9+0.95+5.8 = 12.450. No Silver row. RP_TAG.cs:7892 {{from MAIN_STOCK AS A}} Fails today: gap 8.
Status: executable

### tag-stock.summ.stock-by-item   (T03; gap 8)
Layer: browser
Steps: 1. Tag Summ, Stock Tag, To 31/05, Location L1.
Expected: "Gold Ring": Qty 3 (A001, A002, A005), Pcs 1+2+1 = 4, Grwt 10.000, NetWt 9.600; "Silver Chain": Qty 1, Pcs 1, Grwt 10.000, NetWt 10.000; footer Qty 4, Pcs 5, Grwt 20.000, NetWt 19.600. RP_TAG.cs:8518 {{DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA");}} (the desktop stages through a global table; the web must compute the same figures without any shared staging table). Fails today: gap 8.
Status: executable

### tag-stock.summ.apr-by-item   (T03; gap 8)
Layer: browser
Steps: 1. Tag Summ, Apr Pending, To 31/05.
Expected: "Gold Ring": Qty 1, Pcs 1, Grwt 6.000, NetWt 5.800 (A006). No tour prompt. RP_TAG.cs:8111 {{AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N'}} Fails today: gap 8.
Status: executable

### tag-stock.summ.product-stk   (T03; gap 8)
Layer: browser
Steps: 1. Tag Summ, then "Product Stk", To 31/05.
Expected: grouped by product, ordered by product name: "Chains" (P2): Qty 1, Pcs 1, Grwt 10.000, NetWt 10.000; "Rings" (P1): Qty 3, Pcs 4, Grwt 10.000, NetWt 9.600 (product names chosen so "Chains" < "Rings"). RP_TAG.cs:8322 {{DC_Main.RsQry += " GROUP BY B.PR_CODE,C.PR_NAME,B.IT_TYPE ";}} RP_TAG.cs:8326 {{DC_Main.RsQry += " ORDER BY C.PR_NAME";}} Fails today: gap 8.
Status: executable

### tag-stock.summ.mrp-and-size-from-staging   (T03; decision 4)
Layer: database
Steps: 1. Tag Summ, Mrp Tag with Size = 8; and Product Stk with Size = 8.
Expected: the desktop reads staging columns it never fills, so its result is empty or meaningless: RP_TAG.cs:8077 {{DC_Main.RsQry += "AND A.ITM_MRP <> 0";}} RP_TAG.cs:8252 {{DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_SIZE = '" + cboSize.Text + "'";}} No desktop-derived expected value exists.
Status: blocked: decision 4 says summary MRP and size depend on staging columns the desktop never fills; unblocks when the supervisor decides the intended summary behaviour for Mrp and Size filters.

### tag-stock.summ.stock-alt-location   (T03; decision 4)
Layer: database
Steps: 1. Seed X: tag AL1 in L2. 2. Tag Summ Stock with Location blank, then L2.
Expected: the desktop stages with the current location even when the selector differs: RP_TAG.cs:8519 {{AND A.LC_CODE = '}} so its figures for L2 are not a business rule worth copying.
Status: blocked: not decided in the packet (decision 4 lists MRP and size only); needs the supervisor to say whether summary Stock uses the selected location (recommended) or the current one.

---

## T04 Lookup

### tag-stock.lookup.product-group-item-help   (T04)
Layer: browser
Steps: 1. In Product, type a missing code and Enter. 2. In the help dialog choose P2. 3. Repeat for Group and Item. 4. Press Escape in the help, then retype a valid code.
Expected: a missing code opens the help list; selecting fills code and name and selects the code text; a valid code fills the name directly; Escape leaves the field unchanged. Focus is not advanced to the next field. RP_TAG.cs:9565 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}} RP_TAG.cs:9601 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}} RP_TAG.cs:9609 {{((TextBoxBase)tPrCode).SelectAll();}} Fails today: gap 8.
Status: executable

### tag-stock.lookup.item-keeps-focus   (T04)
Layer: browser
Steps: 1. Type a non-existent item code, Enter, close help without choosing.
Expected: focus returns to the Item box; a valid item fills its name. RP_TAG.cs:9731 {{((Control)tItCode).Focus();}} Fails today: gap 8.
Status: executable

### tag-stock.lookup.location   (T04)
Layer: browser
Steps: 1. Enter a valid location L2 in Location and press Enter. 2. Enter a non-existent one.
Expected: a valid or blank location clears the grid (previous results are not shown against the new location); an invalid one opens location help. RP_TAG.cs:9695 {{DGV_CLEAR();}} Fails today: gap 8.
Status: executable

### tag-stock.lookup.book-keeps-valid-value   (T04; decision 4)
Layer: browser
Steps: 1. In Book enter the existing book code TOP and press Enter. 2. Read the box. 3. Enter a non-existent book code and Enter.
Expected: the box keeps "TOP". For a missing code the book help opens and focus stays in Book. The desktop clears a valid book: RP_TAG.cs:9783 {{tBookCode.Text = "";}} **DELIBERATE** (decision 4: a valid Book lookup keeps the chosen value). Fails today: gap 8.
Status: executable

### tag-stock.lookup.tagno-existing-runs-all   (T04)
Layer: browser
Steps: 1. In TagNo type A005 and Enter. 2. Repeat with RptType Tag Summ. 3. Type a missing tag and Enter.
Expected: an existing tag runs the All Tag report for that tag (3 movements, dates bypassed); with Tag Summ it runs Product Stk; a missing tag opens the tag/design help. RP_TAG.cs:10789 {{BtnAll_Click(BtnAll, new EventArgs());}} Fails today: gap 8, gap 12.
Status: executable

### tag-stock.lookup.stale-response   (T04)
Layer: browser
Steps: 1. Delay the response to "Stock Tag" by 3 s. 2. Before it arrives press "Out Tag" (fast response). 3. Let the slow response arrive.
Expected: the grid and footer show the Out result (4 rows, Out footer from `total.out-mode`); the stale Stock response is discarded.
Status: executable

---

## T05 Children and drill-down

### tag-stock.drill.voucher-zoom-allowed   (T05; gap 10)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Double-click the row A001. 3. Repeat on an Out row for the sale of A003 and on All rows for the return of A005 and the approval issue of A006, with a user holding Read on each target menu.
Expected: the Tag Opening voucher (TR_TAG_OPBL) opens at A001's VchNo; the Out sale row opens the Sale voucher (TR_SALE); the return row opens the Sale Return voucher (TR_SALE_RTN); the approval row opens the Approval Issue voucher (TR_APR_ISU); the voucher number equals the row's VchNo. RP_TAG.cs:8946 {{DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("VchNo").ToString() ?? "";}} RP_TAG.cs:8955 {{((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;}} RP_TAG.cs:9013 {{TR_SALE tR_SALE = new TR_SALE();}} RP_TAG.cs:9120 {{TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();}} RP_TAG.cs:8990 {{TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();}} Fails today: gap 10.
Status: executable

### tag-stock.drill.voucher-zoom-no-right   (T05; T11; gap 10; decision 4)
Layer: browser
Steps: 1. Sign in as a user with the Tag Stock rights but without Read on the Sale menu. 2. Double-click the A003 sale row in Out. 3. Repeat with a user whose rights row for the Sale menu is absent.
Expected: refused with the text "You Have No Rights..." and no voucher opens, for both the explicit-denied and the missing-right user. Desktop refuses only explicit N: RP_TAG.cs:8943 {{"You Have No Rights..."}} **DELIBERATE**: the web also refuses when the right is missing (decision 4: fail-closed). Also asserted at the API: the voucher read endpoint returns 403 for that user.
Status: executable

### tag-stock.drill.zoom-refusals   (T05; gap 10)
Layer: browser
Steps: 1. In Tag Summ mode double-click a summary row. 2. Set Location to L2 (different from current) and double-click a row.
Expected: no voucher opens in either case. RP_TAG.cs:8920 {{if (cboRptType.SelectedIndex == 1}}
Status: executable

### tag-stock.drill.approval-other-items   (T05; gap 13)
Layer: browser
Steps: 1. Seed X: A006 has BAR_IDTL rows ISR_NO 1 (item ST1, pcs 2, weight 0.500) and ISR_NO 2 (item ST2, pcs 1, weight 0.250). 2. Apr Pending, answer "Yes" to "Report With Other Detail Item Name...".
Expected: A006 row also shows It1 = ST1, It1P = 2, It1Wt = 0.500, It2 = ST2, It2P = 1, It2Wt = 0.250, and It3–It5 blank/zero, plus HM_ID and GR_CODE columns; values are summed per tag instance without rounding. RP_TAG.cs:4221 {{"Report With Other Detail Item Name..."}} RP_TAG.cs:3892 {{L.ISR_NO = 1 GROUP BY L.IT_CODE ) As It1}} RP_TAG.cs:3892 {{K.ISR_NO = 5) As It5Wt}} Fails today: gap 13. (The detail-only lower grid stays out of scope, see Not covered.)
Status: executable

### tag-stock.drill.tour-prompt   (T05; gap 6)
Layer: browser
Steps: 1. Seed X: tag AE1 issued with an EMP ISU voucher (ISU_REC N). 2. Apr Pending: when asked "Tour Outword Stock Show....?" answer Yes; then answer No.
Expected: Yes → only AE1 with EmpName from EMP_MAST (book EMP ISU, ISU_REC N); No → only A006 (APR ISU, ISU_REC N); an APR ISU row with ISU_REC 'Y' (returned) and one with ISU_REC NULL appear in neither. RP_TAG.cs:4204 {{"Tour Outword Stock Show....?"}} RP_TAG.cs:4206 {{AND A.BOOK_NAME = 'EMP ISU'  AND A.ISU_REC = 'N'}} RP_TAG.cs:4227 {{AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N'}} Fails today: gap 6 (web uses coalesce(ISU_REC,'N') <> 'Y' and every book).
Status: executable

---

## T06 Required, invalid and empty

### tag-stock.invalid.date-day-month   (T06)
Layer: browser
Steps: 1. In From type 32/05/2026 and press Enter. 2. In To type 15/13/2026 and press Enter.
Expected: "Date Not Valid..." for day 32 and "Month Not Valid..." for month 13; the text is reset and selected; focus stays in the date box and no query runs. DC_Main.cs:1672 {{"Date Not Valid..."}} DC_Main.cs:1664 {{"Month Not Valid..."}} Fails today: gap 8, gap 12. Impossible calendar dates (30/02/2026, 31/04/2026) are also refused with "Date Not Valid..." — the desktop's one-character substring check is a defect that is not ported (study weakness 8).
Status: executable

### tag-stock.invalid.from-after-to   (T06)
Layer: browser
Steps: 1. Stock Tag with From 01/06/2026 and To 31/05/2026 (Stock ignores From). 2. In Tag Wise In mode with the same dates.
Expected: no validation message. Stock returns its normal four rows (From ignored); In returns zero rows with an empty grid and no message box. Both bounds go to SQL unvalidated. RP_TAG.cs:4777 {{if (dataView.Count <= 0)}}
Status: executable

### tag-stock.invalid.empty-result   (T06)
Layer: browser
Steps: 1. Stock Tag with TagNo = ZZZ (no such tag).
Expected: grid empty, footer all zero, no popup, no error toast. RP_TAG.cs:4777 {{if (dataView.Count <= 0)}}
Status: executable

### tag-stock.invalid.quote-and-sql-text   (T06; weakness 1)
Layer: database
Steps: 1. Send TagNo = `A'00`, ItCode = `X' OR '1'='1`, Search = `%'` to the API in each mode.
Expected: HTTP 200 with zero rows (the text is a value, never SQL); no other tag is returned; the desktop concatenates the text into SQL: RP_TAG.cs:4136 {{DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";}} (not ported). The UI uppercases typed characters and drops NUL and apostrophe: RP_TAG.cs:3851 {{if (num == 0 || num == 39)}}
Status: executable

### tag-stock.invalid.unknown-mode   (T06)
Layer: database
Steps: 1. Call the API with tab = `bogus` and tab = `STOCK ; DROP`.
Expected: 400 with a validation error; it does not default silently to stock. Fails today: study "Web today" (casts arbitrary tab strings).
Status: executable

---

## T07, T08, T09 (not applicable)

### tag-stock.na.create   (T07 Create)
Layer: unit
Steps: none.
Expected: N/A: the report writes nothing the web must reproduce. The desktop's print staging writes (TAG_STOCK_PRINT, TAG_SUM_DATA) are a Crystal feed, not a business effect; the web does not stage in shared tables (see `tag-stock.concurrent.no-shared-staging`).
Status: N/A: read-only report

### tag-stock.na.reopen   (T08 Reopen/no-op)
Layer: unit
Steps: none.
Expected: N/A: nothing is saved, so there is no reopen or unchanged save. Reopening the screen re-runs on demand (`tag-stock.entry.navigation`).
Status: N/A: read-only report

### tag-stock.na.edit   (T09 Edit)
Layer: unit
Steps: none.
Expected: N/A: the grid is read-only. RP_TAG.cs:2475 {{((ColumnViewOptionsBehavior)GridView1.OptionsBehavior).Editable = false;}} (asserted by `tag-stock.rights.grid-readonly`). The effect of editing a source voucher on the report is covered by `tag-stock.journey.*`.
Status: N/A: read-only report

---

## T10 Delete, cancel, reverse (report follows)

### tag-stock.reverse.delete-tag-cancel   (T10; T18)
Layer: browser
Steps: 1. Create a Tag Cancel voucher for tag A004 through the screen (A004 leaves Stock). 2. Delete the Tag Cancel voucher. 3. Stock Tag, To 31/05.
Expected: after step 1 A004 is absent (+104 − 104 = 0); after step 2 the minus movement is removed so the sum is +104 and A004 is present again. TR_TAG_CAN.cs:5144 {{dataRow3["ITM_SIGN"] = "-";}} RP_TAG.cs:4187 {{DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0";}}
Status: executable

### tag-stock.reverse.delete-sale   (T10; T18)
Layer: browser
Steps: 1. Delete the sale voucher that sold A003. 2. Stock Tag, To 31/05; All Tag for TagNo A003.
Expected: A003 returns to Stock (sum +103); All shows one row (Sign +) instead of two.
Status: executable

### tag-stock.reverse.delete-sale-return   (T10; T18)
Layer: browser
Steps: 1. Delete the sale return of A005. 2. Stock, To 31/05.
Expected: A005 leaves Stock (+105 − 105 = 0); All for A005 shows two rows (+, −).
Status: executable

---

## T11 Scope and rights

### tag-stock.scope.other-tenant-company   (T11; decision 4)
Layer: database
Steps: 1. Seed a sentinel dataset in another tenant and another company of the same tenant, each with tags, movements and approval rows; same tag numbers (A001) and ids as Seed B. 2. Call every mode, both summaries and the CSV as the Seed B user.
Expected: no returned row, total or CSV line belongs to the sentinel tenant or company; totals equal those in `total.*` exactly. Company merge is not in Lite scope and must not be a way across tenants: RP_TAG.cs:4052 {{A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO}} (desktop merge joins without company).
Status: executable

### tag-stock.scope.list-right-api   (T11)
Layer: database
Steps: 1. As a user without List on Tag Stock call JSON and CSV endpoints directly.
Expected: 403 for both; no data. Fails today only if the policy lacks the caption (existing coverage `desktopRightsCaptions.db.test.ts:63`; extend to the JSON/CSV routes).
Status: executable

### tag-stock.rights.print-export-refused   (T11; T16; addendum)
Layer: browser
Steps: 1. As a user with List but not Print, click Excel; then Print; then call the CSV API and the print API directly.
Expected: the Excel button shows "You Have No Print Rights....." and nothing downloads; Print is refused the same way; the CSV endpoint returns 403. RP_TAG.cs:3259 {{"You Have No Print Rights....."}} The desktop checks only Excel; the web refuses Print too (report addendum, decision 5). **DELIBERATE** for Print and CSV.
Status: executable

### tag-stock.rights.grid-readonly   (T11)
Layer: browser
Steps: 1. Run Stock Tag. 2. Double-click and type into a Pcs cell; try F2.
Expected: cells are not editable; no write request is sent. RP_TAG.cs:2475 {{((ColumnViewOptionsBehavior)GridView1.OptionsBehavior).Editable = false;}}
Status: executable

### tag-stock.scope.location-and-year   (T11; gap 3)
Layer: database
Steps: 1. Sentinel movements for another location of the same company and another CO_YEAR (Seed X AL1, AY1). 2. API Stock/Out/All with location L1 and the current year.
Expected: neither AL1 nor AY1 appears in rows, totals or CSV. RP_TAG.cs:4124 {{AND A.LC_CODE = '}}
Status: executable

### tag-stock.scope.reused-ids   (T11)
Layer: database
Steps: 1. Call the API with a TagNo that exists only in another company; 2. with a tag id belonging to another company.
Expected: zero rows, no data from the other company, status 200.
Status: executable

---

## T12 Concurrency

### tag-stock.concurrent.no-shared-staging   (T12; weakness 2)
Layer: database
Steps: 1. Two sessions (two users, same company) run Tag Summ Stock at the same time with different filters (Item GR in one, Item SC in the other), repeated 20 times each. 2. A third session runs Print staging at the same time.
Expected: every response equals its own filter's expected result ("Gold Ring" Qty 3 or "Silver Chain" Qty 1, as in `summ.stock-by-item`); neither session loses, sees or deletes the other's rows. The desktop deletes the shared tables each run: RP_TAG.cs:8518 {{DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA");}} RP_TAG.cs:8525 {{DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");}}
Status: executable

### tag-stock.concurrent.read-during-sale   (T12)
Layer: database
Steps: 1. Start a Stock report read while a sale of A001 commits.
Expected: the response is either the before state (A001 present, Qty 4) or the after state (A001 absent, Qty 3), never a mix (row present but totals without it).
Status: executable

---

## T13 and T14 (not applicable)

### tag-stock.na.retry   (T13 Retry/unknown)
Layer: unit
Steps: none.
Expected: N/A: the report endpoints are idempotent GETs; repeating a request has no effect on data.
Status: N/A: read-only report

### tag-stock.na.rollback   (T14 Rollback)
Layer: unit
Steps: none.
Expected: N/A: there is no write to roll back. The desktop print loop is non-transactional (RP_TAG.cs:8569 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}}) and the web does not port it.
Status: N/A: read-only report

---

## T15 Configuration and history

### tag-stock.history.item-master-rename   (T15)
Layer: browser
Steps: 1. Run Tag Summ Stock; 2. rename item "Gold Ring" to "Gold Band" in the item master; 3. run again; run Stock Tag.
Expected: the live master is read: summary group shows "Gold Band"; the Stock grid SafeName follows the master. Item name is joined from ITEM_MAST on every run. RP_TAG.cs:7866 {{DC_Main.RsQry += "GROUP BY C.IT_CODE,B.IT_NAME,B.IT_TYPE ";}}
Status: executable

### tag-stock.history.older-year   (T15; gap 3)
Layer: database
Steps: 1. Switch the session to the next financial year (01/04/2027 clock) with Seed B in the previous year.
Expected: Stock for year 2027-28 shows no Seed B tag whose movements are in the previous year (year-scoped), matching the desktop CO_YEAR predicate; the previous year still shows the four tags when selected. RP_TAG.cs:4124 {{A.TAG_NO <> 'N' AND A.VCH_DATE <= '}} Fails today: gap 3.
Status: blocked: the study does not establish how the desktop carries opening stock between financial years for this report (CO_YEAR predicate details in the Tag_Summ SELECT were not read); needs the year-rollover behaviour confirmed by a short desktop study.

### tag-stock.history.settings-snapshot   (T15)
Layer: browser
Steps: 1. Open the screen, change the "location box" user setting, reload.
Expected: Location box visibility follows the current setting on reopen. RP_TAG.cs:3700 {{tLcCode.Text = DC_Main.MLc_code;}}
Status: executable

---

## T16 Output and totals

### tag-stock.output.csv-equals-grid   (T16; decision 5; gap 11)
Layer: browser
Steps: 1. Stock Tag, To 31/05. 2. Click Excel (CSV/Excel export). 3. Parse the file.
Expected: the file has the same visible columns in the same order and the same 4 rows as the grid, followed by totals equal to the footer (Qty 4, Pcs 5, Grwt 20.000, NetWt 19.600, Mrp 62000, PrCost 54000, LbrAmt 1100, OthAmt 170). The desktop exports the grid: RP_TAG.cs:3263 {{DGV.ExportToXlsx(text);}} Fails today: gap 11 (web CSV has fewer columns and a blank gross total).
Status: executable

### tag-stock.output.csv-all-modes   (T16; gap 11)
Layer: database
Steps: 1. For each of In, Out, Stock, Mrp, Apr, All, Tag Summ and Product Stk download the CSV and compare to the JSON.
Expected: row count and every total equal the JSON response for the same filters; header row order equals the grid order of `entry.column-order-per-mode`.
Status: executable

### tag-stock.output.print-title-columns-totals   (T16; decision 5; gap 11)
Layer: browser
Steps: 1. Stock Tag, To 31/05; click Print.
Expected: the print window titles the report "Tag Wise Stock As on Date " followed by the date (branch prefix "Branch - L1" when a location is chosen), lists the grid columns of the screen and the footer totals of `total.stock-mode`. RP_TAG.cs:8696 {{text3 = "Tag Wise Stock As on Date ";}} RP_TAG.cs:8697 {{? "TagStkRpt"}} Layout fidelity beyond title, columns and totals is under Not covered. Fails today: gap 11.
Status: blocked: the web has no print window for this report yet and the template layout is not audited (study Open questions); unblocks when the print slice defines the PDF/print route (the XML `extraction_output/rpt_xml/TagStkRpt.xml` exists, study "Print").

### tag-stock.output.print-summary-templates   (T16; gap 11)
Layer: browser
Steps: 1. Tag Summ, click Print; click Summ and answer "Product Wise Group Report" Yes then No.
Expected: summary print titles per template choice (TagStkSummRpt for Yes, TagStkItemSumRpt for No). RP_TAG.cs:8847 {{DC_Main.RptName = "TagStkSummRpt";}}
Status: blocked: web print route absent and template formulas not audited; same unblock as `output.print-title-columns-totals`.

---

## T17 Keyboard

### tag-stock.keyboard.escape-closes   (T17; gap 12)
Layer: browser
Steps: 1. With focus anywhere on the Tag Stock screen press Escape.
Expected: the screen closes and returns to the menu page. RP_TAG.cs:3865 {{if ((int)e.KeyCode == 27)}} RP_TAG.cs:3867 {{((Form)this).Close();}} Fails today: gap 12.
Status: executable

### tag-stock.keyboard.arrow-focus-grid   (T17; gap 12)
Layer: browser
Steps: 1. Run Stock Tag. 2. Focus the Item box; press Down, then Up.
Expected: focus moves to the result grid on both arrows. RP_TAG.cs:3871 {{((Control)DGV).Focus();}} Fails today: gap 12.
Status: executable

### tag-stock.keyboard.date-enter-flow   (T17; gap 12)
Layer: browser
Steps: 1. In From enter a valid date and press Enter; repeat in To. 2. Enter an invalid date and press Enter.
Expected: a valid date moves focus on to the next control in tab order (From → To → Search); an invalid date shows the message and keeps focus in the same box. RP_TAG.cs:3714 {{CurActCtrl = (Control)(object)mFromDt;}} DC_Main.cs:1672 {{"Date Not Valid..."}}
Status: executable

### tag-stock.keyboard.mnemonics   (T17; gap 12)
Layer: browser
Steps: 1. Press Alt+I, Alt+O, Alt+M, Alt+P, Alt+E, Alt+C, Alt+X.
Expected: In Tag, Out Tag, Mrp Tag, Print, Excel, Cancel and Exit trigger respectively. The ambiguous letters S (Stock Tag / Summ) and A (Apr Pending / All Tag) are declared twice; the web may resolve them to the first button in tab order. RP_TAG.cs:2504 {{BtnStock.Text = "&Stock Tag";}} RP_TAG.cs:2362 {{BtnSumm.Text = "&Summ";}} RP_TAG.cs:2616 {{BtnApr.Text = "&Apr Pending";}} RP_TAG.cs:2644 {{BtnAll.Text = "&All Tag";}} Fails today: gap 12.
Status: executable

### tag-stock.keyboard.tab-order   (T17; gap 12)
Layer: browser
Steps: 1. From the From box press Tab repeatedly through the screen.
Expected: order From (tab index 0) → To (1) → Search (2) → It Type (3) → TagNo (6) → Stock Tag (7) → In Tag (8) → Out Tag (9) → Mrp Tag (10) → Apr Pending (11) → All Tag (12), then the remaining fields by designer index. RP_TAG.cs:2717 {{((Control)mFromDt).TabIndex = 0;}} RP_TAG.cs:2709 {{((Control)mToDt).TabIndex = 1;}} RP_TAG.cs:2465 {{((Control)tSerchAll).TabIndex = 2;}}
Status: executable

### tag-stock.keyboard.cancel-button   (T17)
Layer: browser
Steps: 1. Fill TagNo and Item, run Stock Tag, click Cancel.
Expected: text fields cleared, dates reset to the system date 31/05/2026, grid cleared, diagnostics hidden, focus in From. RP_TAG.cs:3736 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}} RP_TAG.cs:3741 {{((Control)mFromDt).Focus();}}
Status: executable

---

## T18 Full journey

### tag-stock.journey.lifecycle-reconcile   (T18; T10; decisions 2 and 3)
Layer: browser
Steps: 1. Through the real screens create: Tag Opening of A001, A002, A003, A004, A005, A006, A007 (Seed B values); a Sale of A003 and A005 on 20/04; a Tag Cancel of A004 on 25/04; a Sale Return of A005 on 10/05; an Approval Issue of A006 on 15/05. 2. After each voucher run Stock Tag, To = the voucher date (or 31/05). 3. Run In, Out, All at the end.
Expected (instance sums, ids = 101…107 of the tags): after Openings: Stock = all seven (Qty 7). After the sale: A003 and A005 drop (Qty 5). After the cancel: A004 drops (Qty 4: A001, A002, A006, A007). After the return: A005 returns (Qty 5). After the approval issue: A006 drops → final Qty 4 = A001, A002, A005, A007 with the totals of `total.stock-mode`. At the end In = six rows by date range as in `total.in-mode` and Out = four rows as in `total.out-mode`; All = 12 movements as in `total.all-mode`. Every step is also checked in the database: signed sum per tag as in the `stock.*` cases. Fails today: gaps 1, 2, 3, 6 (In, All and Apr differ).
Status: executable

### tag-stock.journey.edit-voucher-then-report   (T18; T09 effect)
Layer: browser
Steps: 1. Edit the sale of A003 changing its date from 20/04 to 22/04 and save. 2. Out Tag From 01/04 To 21/04, then To 22/04; Day for A003.
Expected: To 21/04: A005 only for sales (A003 absent, A004 cancel present) = A005, A004; To 22/04: A003 appears; Day for A003 = 22/04 − 05/04 = 17.
Status: executable

### tag-stock.journey.approval-return-then-sale   (T18)
Layer: browser
Steps: 1. Return A006 from approval on 25/05 (+106). 2. Stock To 31/05. 3. Apr Pending To 31/05. 4. Sell A006 on 28/05.
Expected: step 2: A006 in Stock (+106 − 106 + 106 = 106) and step 3: A006 not pending (ISU_REC marks returned) → Apr empty (zero rows); step 4: sale posts −106 → Stock excludes A006 (sum 0). Ac_Stock.cs:81 {{A.TBL_CODE,'I','+'}} RP_TAG.cs:4227 {{AND A.BOOK_NAME = 'APR ISU'  AND A.ISU_REC = 'N'}}
Status: executable

---

## Sort orders (decision 7; gap 14)

### tag-stock.sort.stock-in-mrp-by-tagno   (T02; T16; gap 14)
Layer: browser
Steps: 1. With Seed B add tags "A010" and "A009" (positive balance, designs default). 2. Stock, In and Mrp (setting design-help off).
Expected: rows ordered by TagNo ascending as text: A001, A002, A005, A007, A009, A010. RP_TAG.cs:4045 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}} Fails today: gap 14 only when the web does not sort by tag text; verify order, not input order.
Status: executable

### tag-stock.sort.stock-design-help   (T02; gap 14)
Layer: browser
Steps: 1. Set the design-help setting on (MsDesignHelp = Y). 2. Seed designs RG-10 (A001), RG-9 (A002), SC-1 (A007), RG-9 (A005). 3. Stock.
Expected: order by first two characters, then design length, then design: RG-9 (length 4) before RG-10 (length 5), then SC-1: A002, A005 (RG-9, tie: any stable order, assert both before A001), A001, A007. RP_TAG.cs:4041 {{DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";}} Fails today: gap 14.
Status: executable

### tag-stock.sort.out-by-vchtype-vchno   (T02; gap 14)
Layer: browser
Steps: 1. Out Tag, From 01/04, To 31/05.
Expected: rows in ascending (VchTyp, VchNo) of the four seeded minus vouchers, computed by the test from the stored values (e.g. sale 0001 and 0002 before the approval and cancel types if their codes sort later). RP_TAG.cs:4100 {{DC_Main.RsQry += "ORDER BY A.VCH_TYPE,A.VCH_NO";}} Fails today: gap 14.
Status: executable

### tag-stock.sort.apr-by-year-voucher-tag   (T02; gap 14)
Layer: database
Steps: 1. Seed X: three pending approvals in vouchers 0001 (tags A006), 0002 (tags AP2, AP1 in that entry order).
Expected: ordered CO_YEAR, VCH_NO, TagNo: A006 (0001), AP1, AP2 (0002). With design-help on, the third key is design. RP_TAG.cs:4263 {{DC_Main.RsQry += "ORDER BY A.CO_YEAR,A.VCH_NO,A.TAG_NO";}} RP_TAG.cs:4259 {{DC_Main.RsQry += "ORDER BY A.CO_YEAR,A.VCH_NO,C.DESIGN_NO";}} Fails today: gap 14.
Status: executable

### tag-stock.sort.all-by-date-tag   (T02; gap 14)
Layer: browser
Steps: 1. All Tag, From 01/04, To 31/05 (design-help off, then on).
Expected: ascending movement date, then TagNo: 05/04 rows in TagNo order (A001, A003, A004, A005, A006, A007), 10/04 A002, 20/04 A003 and A005, 25/04 A004, 10/05 A005, 15/05 A006 (design-help on: the second key is the design). RP_TAG.cs:4318 {{DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.TAG_NO";}} RP_TAG.cs:4314 {{DC_Main.RsQry += "ORDER BY A.VCH_DATE,C.DESIGN_NO";}} Fails today: gap 14.
Status: executable

---

## Coverage table

| Kind | Cases | Blocked | Note |
|---|---:|---:|---|
| T01 Entry/defaults | 9 | 0 |  |
| T02 Field route | 25 | 1 |  |
| T03 Formula sequence | 25 | 2 |  |
| T04 Lookup | 6 | 0 |  |
| T05 Children | 5 | 0 |  |
| T06 Required/invalid | 5 | 0 |  |
| T07 Create | 1 | 0 | N/A: read-only report (one placeholder case with the reason) |
| T08 Reopen/no-op | 1 | 0 | N/A: read-only report (one placeholder case with the reason) |
| T09 Edit | 1 | 0 | N/A: read-only report (one placeholder case with the reason) |
| T10 Delete/cancel/reverse | 3 | 0 |  |
| T11 Scope/rights | 6 | 0 |  |
| T12 Concurrency | 2 | 0 |  |
| T13 Retry/unknown | 1 | 0 | N/A: read-only report (one placeholder case with the reason) |
| T14 Rollback | 1 | 0 | N/A: read-only report (one placeholder case with the reason) |
| T15 Config/history | 3 | 1 |  |
| T16 Report/output | 4 | 2 |  |
| T17 Keyboard/usability | 6 | 0 |  |
| T18 Full journey | 3 | 0 |  |
| **Total** | **107** | **6** | 5 are N/A placeholders |

Counts are by the first kind in each case header; cases that also carry a second kind are counted once. Blocked: `filter.emp-isu-less`, `summ.mrp-and-size-from-staging`, `summ.stock-alt-location`, `history.older-year`, `output.print-title-columns-totals`, `output.print-summary-templates`.

Gap-to-case map (each gap has at least one case that fails today):

| Gap | Cases |
|---|---|
| 1 In reads creation rows | `filter.date-range-in`, `total.in-mode`, `journey.lifecycle-reconcile` |
| 2 All is a movement history | `total.all-mode`, `total.all-mode-sign-column`, `filter.all-specific-tag-bypasses-dates` |
| 3 Year, as-of, data type | `filter.date-range-*`, `filter.stock-ignores-from`, `filter.stock-as-of-date`, `filter.year-and-datatype`, `scope.location-and-year`, `history.older-year` (blocked) |
| 4 Sentinel N | `filter.sentinel-n` |
| 5 MRP nonzero | `filter.mrp-nonzero` |
| 6 Approval exactness | `total.apr-mode`, `drill.tour-prompt`, `stock.approval-pending-tag`, `journey.approval-return-then-sale` |
| 7 No row cap | `total.no-row-cap` |
| 8 Missing selectors and summaries | all `filter.*`, `lookup.*`, `summ.*`, `entry.defaults-*`, `entry.summ-relabel` |
| 9 Columns and formats | `entry.hidden-columns-default`, `entry.column-order-per-mode`, `total.stock-mode`, `display.number-formats`, `total.day-column` |
| 10 Voucher zoom | `drill.voucher-zoom-allowed`, `drill.voucher-zoom-no-right`, `drill.zoom-refusals` |
| 11 Output and titles | `output.csv-equals-grid`, `output.csv-all-modes`, `output.print-*` (blocked) |
| 12 Keys | `keyboard.*`, `invalid.date-day-month`, `lookup.tagno-existing-runs-all` |
| 13 Photo and other-item columns | `entry.no-photo-no-component-grid`, `drill.approval-other-items` |
| 14 Sort | `sort.*` |

## Test data

Seed B (base, created through the real screens for browser cases; inserted as rows only for database cases). One company C1, location L1, financial year 2026-27, data type "all", test clock 31/05/2026.

- Masters: items "Gold Ring" (GR, type G, product P1 "Rings", group G1) and "Silver Chain" (SC, type S, product P2 "Chains", group G2); counters C1 and C2; books: Tag Opening book TOP, a Sale book, a Tag Cancel book, a Sale Return book, an Approval Issue book (APR ISU); users: one with List and Print rights, one with List only, one without List, one without Read on the Sale menu, one with no rights row for Sale.
- Tags (id = VCH_SRNO; pcs / gross / net / MRP / cost / labour amount / other amount; size; counter; stock date):
  - A001, id 101: GR, 1 / 5.000 / 4.800 / 30000 / 25000 / 500 / 100; size 7; C1; 05/04/2026. Stays in stock.
  - A002, id 102: GR, 2 / 3.000 / 2.900 / 20000 / 16000 / 300 / 50; size 8; C1; 10/04/2026. Stays in stock.
  - A003, id 103: GR, 1 / 4.000 / 3.800 / 25000 / 20000 / 400 / 80; size 7; C1; 05/04. Sold 20/04 (−103).
  - A004, id 104: GR, 1 / 1.000 / 0.950 / 8000 / 6000 / 100 / 10; size 7; C1; 05/04. Cancelled 25/04 (−104).
  - A005, id 105: GR, 1 / 2.000 / 1.900 / 12000 / 9000 / 200 / 20; size 7; C1; 05/04. Sold 20/04 (−105), returned 10/05 (+105).
  - A006, id 106: GR, 1 / 6.000 / 5.800 / 40000 / 33000 / 600 / 120; size 7; C1; 05/04. Issued on approval 15/05 (−106), not returned.
  - A007, id 107: SC, 1 / 10.000 / 10.000 / 0 / 4000 / 100 / 0; size 18; C2; 05/04. Stays in stock.
- Movements: every movement repeats the tag's own pcs, weights, MRP and amounts.
- Seed X (supplements for single cases; each case lists what it adds): negative-MRP tag A008 (MRP −100); sentinel TAG_NO 'N' rows; other-year tag AY1; other data-type tag AD1; other-location tag AL1 (L2); EMP_ISU tags A013 (Y) and A014 (NULL); approval variants AE1 (EMP ISU, N), an APR ISU row with ISU_REC Y and one with NULL; sale-against-approval AA1 (id 201); zero-id tag AZ0, tag without BAR_DETL AM1, item-mismatch tag AI1; two-instance tag A100 (ids 301, 302); BAR_IDTL other-item rows for A006; extra tags A009, A010, AP1, AP2; 5,200 bulk tags; design values RG-9, RG-10, SC-1; and a sentinel tenant plus a sentinel company with the same tag numbers.

## Not covered

- **Detail-only and Jadtar projections** (Tag Detail, JdtTag Dtl: the component grid DGV_IDTL, photograph, RP_TAG.cs:3890 {{private void ItemSub_Detl(string RptType)}} (range `:3890-3976`), `:5615-7287`): separate menus, decision 1.
- **Company merge** behaviour: not Lite; only the isolation case `scope.other-tenant-company` applies (decision 4).
- **Wholesale columns** (Touch, West, Fine, Kr*, TagProfit, KrDif, OthFine, TotFine, GrTouch, TagType): `N/A` under the Lite defaults (decision 6).
- **Emp Isu Less in Lite**: only visible in edition E; the behaviour case is blocked pending an edition decision (see `filter.emp-isu-less`); the print-template prompt for edition E is not covered.
- **Crystal layout fidelity** beyond title, columns and totals, Counter print (`CntrTagSumRpt`, `CntrTagStkRpt`), Tag Wt Change and Tag Split prints, and the old/new engine title difference: decision 5 and study Open questions.
- **Registration-specific overrides** (hidden VchDate/Day, Design-prefix search, opening date in From): no registration setting is in the Lite target (study Open questions).
- **F1 TagNo repair writer and diagnostics panel** (`pnlDiff`, anomaly queries): not ported; only absence is tested (`entry.diagnostics-and-repair-absent`); the study's PARTIAL continuation on RP_TAG.cs:3154 {{private void Dgv_Adj_Feel()}} (range 3154–3253) and 9787–10814 stays open.
- **Image priority** (local JPG, HTTP, TAG_IMAGE_DATA) and image zoom: hidden for Tag Stock, so only absence is tested (gap 13).
- **Print staging writes** (TAG_STOCK_PRINT, TAG_SUM_DATA column mapping): a Crystal feed the web does not reproduce; only the no-interference rule is covered.
- **Summary MRP/size and alternate-location staging** (blocked cases) and **year rollover** (blocked) until decided.
- **Calendar defects** of the desktop date helper: the web refuses impossible dates; the desktop's wrong-substring acceptance is not reproduced (study weakness 8).
- **Sale-return outward replacement lines** (Ac_Stock.cs:245 {{INSERT INTO MAIN_}}): only referenced, not seeded; a separate Sale Return study owns them.
- **Concurrent print/Excel by two users with the same company** beyond `concurrent.no-shared-staging`.
