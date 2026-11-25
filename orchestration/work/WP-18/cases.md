# WP-18 cases: Report → HuId Report (`huid-report`)

Frozen case list derived from `orchestration/work/WP-18/study.md` (29 gaps), the verification playbook
`docs/master-parity-plan-2026-09-29/04-verification-playbook.md` section 3 (T01 to T18) and the report addendum
`docs/agent-prompts/lite/00b-REPORT-ADDENDUM.md`. This document changes no code.

## How to read this list

- Desktop source is `unified/src/csharp/DataCareNext/RP_HUID.cs` (the form) and `MDI_FORM.cs`, `MS_OPNCOMP.cs`
  (settings). Every desktop statement carries `FILE.cs:line {{quote}}`, and the quote was copied from the file.
- Web statements carry `path:line` only. The web is not the authority for business behaviour.
- `gap N` in a heading names the study gap (1 to 29) the case proves. "passes today" means the case is a guard for
  behaviour the web already has.
- Status `executable` means a test can be written now and run on the isolated database. `blocked` names the open
  question or decision that stops it. `N/A` gives the reason.
- Dates in the seed and in steps are written day/month/year, as the form's date boxes show them.
- Money and weight values are written with the scale of the seed (three decimals, as `PRECISION.weight` allows).

### Desktop rules used by many cases (read once)

- Every view (Stock, In, Out) runs the four `BAR_DETL` updates first. They are a write and are covered by
  `huid-report.write.view-leaves-bar-detl-unchanged`.
  - `RP_HUID.cs:1754 {{UPDATE BAR_DETL SET HM_ID = '' WHERE CO_CODE = '}}`
- The In view base: `RP_HUID.cs:1761 {{AND C.CO_YEAR = '}}`, `RP_HUID.cs:1761 {{AND C.TAG_NO <> 'N'}}`,
  `RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}`. Dates are the voucher date, From and To both included.
- The Out view base: `RP_HUID.cs:1795 {{AND A.ITM_SIGN = '-'}}` and `RP_HUID.cs:1795 {{AND A.VCH_DATE >= '}}`.
  An Out row is one sale movement (`-`), dated by its own voucher date.
- The Stock base: `RP_HUID.cs:1838 {{AND C.STK_DATE <= '}}`, only To is applied, on the origin tag's stock date.
  The movement join is `RP_HUID.cs:1838 {{And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO}}`.
  Because the join forces every movement of a tag to carry the tag's `VCH_SRNO` (call it S), the stock expression
  reduces to S × (count of `+` movements − count of `-` movements). For every seeded tag S is positive except where
  a case says otherwise. Each Stock case still shows the full sum from the rule.
  - `RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}`
- Item type: the box opens on Gold. `RP_HUID.cs:1555 {{cboItemTyp.Items.Add((object)"Gold");}}` and the default
  `RP_HUID.cs:1564 {{cboItemTyp.SelectedIndex = 0;}}` apply when `RP_HUID.cs:1562 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}`.
  The filter is `B.IT_TYPE = 'G'` (first letter of the box text), `RP_HUID.cs:1778 {{if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)}}`.

---

## T01 Entry and defaults

### huid-report.entry.menu-opens-three-views   (T01 Entry/defaults) · gap 1
Layer: browser
Steps: 1. Log in as a user with the report view right. 2. Open Report → "HuId Report" from the navigation. 3. Read
the buttons on the report screen.
Expected: exactly three view buttons, captioned "Stock Tag", "In Tag" and "Out Tag", and no "All history" tab.
The desktop captions are `RP_HUID.cs:1121 {{BtnStock.Text = "&Stock Tag";}}`, `RP_HUID.cs:1177 {{BtnIn.Text = "&In Tag";}}`
and `RP_HUID.cs:1149 {{BtnOut.Text = "&Out Tag";}}`. The views are called from `RP_HUID.cs:2153 {{Tag_Summ("Stock");}}`,
`RP_HUID.cs:2158 {{Tag_Summ("In");}}` and `RP_HUID.cs:2163 {{Tag_Summ("Out");}}`. The desktop has no "All" view button
(study Gap 1). The removal of the web's fourth tab is a decision for the owner, listed under "Not covered".
Status: executable
Fails today: the web shows "All history" and "In stock" and has no Out view (`web/apps/web/app/(app)/reports/[report]/page.tsx:1393-1400`).

### huid-report.entry.default-dates-today   (T01 Entry/defaults) · gap 25
Layer: browser
Steps: 1. Open the report with the system date set to 05/04/2026 (the test sets the clock or reads the seeded
system date). 2. Read the From and To date boxes.
Expected: From = 05/04/2026 and To = 05/04/2026. Desktop: `RP_HUID.cs:1620 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`
and `RP_HUID.cs:1621 {{mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`.
Status: executable
Fails today: From and To start empty (`web/apps/web/app/(app)/reports/[report]/page.tsx:153`).

### huid-report.entry.default-item-type-gold   (T01 Entry/defaults) · gap 7
Layer: browser
Steps: 1. Seed the company metal type as G (test data, section Test data). 2. Open the report. 3. Read the Item
Type box. 4. Click "In Tag" with From 05/04/2026 and To 30/06/2026.
Expected: the Item Type box shows "Gold". The desktop items are `RP_HUID.cs:1555 {{cboItemTyp.Items.Add((object)"Gold");}}`,
`RP_HUID.cs:1556 {{cboItemTyp.Items.Add((object)"Silver");}}`, `RP_HUID.cs:1561 {{cboItemTyp.Items.Add((object)"Platinum");}}`.
The In view returns the 10 Gold rows of the Test data window (TG-001 to TG-006, TG-010, TG-012, TG-013, TG-015). TG-007
(Silver) is absent.
Status: executable
Fails today: no item-type control exists (study Gap 7; `page.tsx:1388-1433` has no item type).

### huid-report.entry.default-item-type-silver-when-not-gold   (T01 Entry/defaults) · gap 7
Layer: browser
Steps: 1. Seed the company metal type as not G. 2. Open the report and read the Item Type box.
Expected: "Silver". Desktop: `RP_HUID.cs:1562 {{if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)}}` and the
else branch `RP_HUID.cs:1568 {{cboItemTyp.SelectedIndex = 1;}}`.
Status: blocked: the source of `DC_Main.MsMetalType` (the company setting that holds the metal type) is not traced in
the study. It unblocks when the settings catalogue entry for the metal type is read.

### huid-report.entry.default-hallmark-all   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the report. 2. Read the HUID box. 3. Click "In Tag" for the Test data window.
Expected: the HUID box shows "All" and the In view contains 10 rows (not only tagged rows). Desktop:
`RP_HUID.cs:1573 {{cboHuId.SelectedIndex = 0;}}`, and the HUID box has no filter at index 0.
Status: executable
Passes today: `web/apps/api/test/p9Reports.db.test.ts:117-146` (default All).

### huid-report.entry.grid-empty-before-first-view   (T01 Entry/defaults)
Layer: browser
Steps: 1. Open the report. 2. Read the grid.
Expected: the grid has no rows. The desktop Load reads only the user setting and the product and group lists, and runs
no view query: `RP_HUID.cs:1373 {{private void RP_HUID_Load(object sender, EventArgs e)}}`, and the rows come from
`RP_HUID.cs:1877 {{DGV_FILL();}}` after a view button runs `Tag_Summ`.
Status: executable

### huid-report.entry.blank-product-group-tag-account   (T01 Entry/defaults) · gap 4, 5, 6
Layer: browser
Steps: 1. Open the report. 2. Read the Product, Group, TagNo and AcCode boxes.
Expected: Product and Group blank; TagNo empty; AcCode empty. Desktop: the lists start at index 0
(`RP_HUID.cs:1202 {{((Control)cboProduct).TabIndex = 4;}}`), and the TagNo and AcCode boxes are text boxes that start empty
(`RP_HUID.cs:1217 {{((Control)tTagNo).TabIndex = 6;}}`, `RP_HUID.cs:1300 {{((Control)tAcCode).TabIndex = 1180;}}`).
Status: executable
Fails today: no Product, Group, TagNo or AcCode box exists for HUID (study Gaps 4, 5, 6).

---

## T02 Field route (each filter changes the row set)

### huid-report.filter.in-date-window   (T02 Field route) · gap 2
Layer: browser
Steps: 1. Set From 05/04/2026 and To 30/06/2026, Item Type Gold, HUID All. 2. Click "In Tag".
Expected: exactly these 10 tags, in TAG_NO order: TG-001, TG-002, TG-003, TG-004, TG-005, TG-006, TG-010, TG-012, TG-013,
TG-015. Excluded: TG-014 (01/04/2026, before From), TG-011 (02/04/2026, before From), TG-016 (05/07/2026, after To).
The desktop bounds the voucher date from both sides: `RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}` and the To bound in the same
statement.
Status: executable
Fails today: no date is applied to HUID (`web/apps/api/src/routes/txn.ts:858-863` drops `fromDate` and `toDate`).

### huid-report.filter.out-date-window   (T02 Field route) · gap 1, 2
Layer: browser
Steps: 1. Set From 05/04/2026 and To 30/06/2026. 2. Click "Out Tag".
Expected: exactly 2 rows: TG-005 (sale 25/04/2026) and TG-006 (sale 26/04/2026). The sale movement for TG-006 is dated
26/04/2026 and its return (28/04/2026) is not a sale row. Desktop Out bounds the movement date:
`RP_HUID.cs:1795 {{AND A.VCH_DATE >= '}}` and `RP_HUID.cs:1795 {{AND A.ITM_SIGN = '-'}}`.
Status: executable
Fails today: no Out view exists (study Gap 1).

### huid-report.filter.stock-to-date-only   (T02 Field route) · gap 2
Layer: browser
Steps: 1. Set From 20/06/2026 (ignored by Stock) and To 30/06/2026. 2. Click "Stock Tag". 3. Read the TagNo column.
Expected: exactly these 10 tags, in TAG_NO order: TG-001, TG-002, TG-003, TG-004, TG-006, TG-011, TG-013, TG-014, TG-015,
TG-016. The From date does not change the result. TG-011 and TG-014 appear although they are before the From date
(02/04/2026 and 01/04/2026). TG-010 is absent because its stock date is 15/07/2026, after To. Desktop: Stock bounds only the
To date on the stock date: `RP_HUID.cs:1838 {{AND C.STK_DATE <= '}}`.
Status: executable
Fails today: the web applies no date to any tab (study Gap 2) and includes TG-007, TG-008, TG-009 and TG-010.

### huid-report.filter.hallmark-with-first-slot   (T02 Field route) · gap 10
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026, Item Type Gold. 2. Choose HUID "With HuId". 3. Click "In Tag".
Expected: TG-001, TG-005, TG-006 (rows whose first HUID column HM_ID is non-empty). TG-004 is decided in its own case
(huid-report.hallmark.whitespace-only-first-slot). The desktop filter: `RP_HUID.cs:1762 {{if (cboHuId.SelectedIndex == 1)}}`
then `RP_HUID.cs:1764 {{DC_Main.RsQry += " AND C.HM_ID <> ''";}}`.
Status: executable
Fails today: the web tests all four slots (`web/apps/api/src/modules/reports/huid.ts:129-134`), so TG-003, TG-010 and
TG-013 are also returned.

### huid-report.filter.hallmark-without-first-slot   (T02 Field route) · gap 10
Layer: browser
Steps: 1. Same window and item type. 2. Choose HUID "Whout HuId" (the option label the desktop uses; the web label is a
separate decision, see huid-report.labels.hallmark-options). 3. Click "In Tag".
Expected: TG-002, TG-003, TG-010, TG-012, TG-013, TG-015. TG-003 has its HUID in the second slot, TG-010 in the second slot
and TG-013 in the fourth slot; the desktop counts all three as "without" because it tests the first column only.
The desktop filter: `RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}}`. Note that TG-004 is decided in its own case.
Status: executable
Fails today: the web returns TG-003, TG-010 and TG-013 as "with" (`huid.ts:129-134`).

### huid-report.filter.hallmark-slot-two-to-four-counts-as-without   (T02 Field route) · gap 10
Layer: database
Steps: 1. Run the In view with HUID "Whout HuId" (desktop rule). 2. Compare with the database rows for TG-003,
TG-010 and TG-013 (their HM_ID is NULL in the seed).
Expected: the three tags are present in the desktop result. The first column is NULL, and the desktop converts NULL to ''
on every view (`RP_HUID.cs:1754 {{UPDATE BAR_DETL SET HM_ID = '' WHERE CO_CODE = '}}` with `RP_HUID.cs:1757 {{AND HM_ID4 Is NULL}}`
for the fourth column).
Status: executable
Fails today: web `huid.ts:129-134` tests all four slots.

### huid-report.hallmark.whitespace-only-first-slot   (T02 Field route) · gap 11
Layer: browser
Steps: 1. Set the In window with Item Type Gold. 2. Read TG-004 (HM_ID is three spaces). 3. Choose HUID "With HuId" and
then "Whout HuId".
Expected: per the supervisor's fact 5 (only an empty string is "absent"), TG-004 is "with" and appears only under "With HuId".
Status: blocked: the desktop runs on SQL Server (`unified/src/csharp/DataCareNext/DC_Main.cs:37 {{public static SqlConnection Mc = new SqlConnection();}}`).
In SQL Server, `'   ' = ''` is true, so `RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}}` would put TG-004 under "Without".
The study's Gap 11 says the desktop counts it as present; that is not verified and may be wrong. The supervisor's rule and the
desktop engine disagree. Unblocks when the owner confirms the rule (and, if needed, a SQL Server check of `'   ' = ''`
on the desktop schema). The web currently treats TG-004 as absent (`web/apps/api/src/modules/reports/huid.ts:129-132`).

### huid-report.filter.tag-no-exact   (T02 Field route) · gap 4
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026. 2. Type "TG-001" in TagNo. 3. Click "In Tag", then "Stock Tag", then "Out Tag".
Expected: In: TG-001 only. Stock: TG-001 only. Out: no rows. The desktop filter is exact:
`RP_HUID.cs:1782-1785 {{if (Operators.CompareString(tTagNo.Text, "", false) != 0)}}` and
`RP_HUID.cs:1782-1785 {{AND C.TAG_NO = '}}`.
Status: executable
Fails today: no TagNo box for HUID (`txn.ts:858-863` does not pass a tag).

### huid-report.filter.tag-n-excluded   (T02 Field route) · gap 13
Layer: browser
Steps: 1. Set the window 01/04/2026 to 30/06/2026 and HUID All. 2. Click "In Tag", "Out Tag" and "Stock Tag" in turn.
Expected: TG-008 (tag number N) is absent in all three views. The desktop excludes it in every view:
`RP_HUID.cs:1761 {{AND C.TAG_NO <> 'N'}}` (In), `RP_HUID.cs:1795 {{AND A.TAG_NO <> 'N'}}` (Out) and
`RP_HUID.cs:1838 {{AND A.TAG_NO <> 'N'}}` (Stock; the Stock query has `A.TAG_NO <> 'N'`, see the Stock base above).
Status: executable
Fails today: the web's "All history" returns every BAR_DETL row including TG-008 (`huid.ts:150-153`).

### huid-report.filter.item-type-silver   (T02 Field route) · gap 7
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026. 2. Choose Item Type "Silver". 3. Click "In Tag".
Expected: TG-007 only. The desktop filter is `RP_HUID.cs:1778 {{if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)}}`,
with the first letter of the box text (S) as `B.IT_TYPE`.
Status: executable
Fails today: no Item Type box (study Gap 7).

### huid-report.filter.product-ring   (T02 Field route) · gap 6
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026, Item Type Gold. 2. Choose Product "PR-RING". 3. Click "In Tag".
Expected: TG-001, TG-003, TG-004, TG-005, TG-006, TG-010, TG-012 (seven rows). TG-002, TG-013 and TG-015 are excluded.
Desktop: `RP_HUID.cs:1770-1781 {{AND B.PR_CODE = '}}` with the product selected by index.
Status: executable
Fails today: no Product box (study Gap 6).

### huid-report.filter.group-link   (T02 Field route) · gap 6
Layer: browser
Steps: 1. Same window and item type. 2. Choose Group "GR-LINK". 3. Click "In Tag".
Expected: TG-002, TG-013, TG-015 (three rows). Desktop: `RP_HUID.cs:1813-1823 {{AND B.GR_CODE = '}}`.
Status: executable
Fails today: no Group box (study Gap 6).

### huid-report.filter.counter-absent   (T02 Field route) · gap 8
Layer: browser
Steps: 1. Open the report. 2. Look for a Counter box, a Counter filter or a TBL_CODE filter on the screen.
Expected: none exists. The desktop shows the counter as a column only: `RP_HUID.cs:1761 {{1 AS Qty,C.ITM_PCS as Pcs}}` sits
beside the counter column, and no `TBL_CODE` condition is written in any view. The window 05/04/2026 to 30/06/2026 with Gold
returns 10 rows whatever counter is typed (none can be typed).
Status: executable
Fails today: the web has a Counter box and filters `TBL_CODE` (`web/apps/web/app/(app)/reports/[report]/page.tsx:1425-1432`,
`huid.ts:124-126`). The decision to remove it is listed under "Not covered" for the owner.

### huid-report.filter.item-code-absent   (T02 Field route) · gap 9
Layer: browser
Steps: 1. Open the report. 2. Look for an Item (item code) filter on the screen.
Expected: none exists. The desktop has no item-code condition: the In view's conditions are the ones in the Test data
section (company, location, year, tag, date, item type, product, group, HUID, tag, account, data type).
Status: executable
Fails today: the web has an Item box filtering `IT_CODE` (`page.tsx:1416-1423`, `huid.ts:120-122`).

### huid-report.filter.search-first-column-set   (T02 Field route) · gap 15
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026, Item Type Gold. 2. Click "In Tag". 3. Type "HU00" in the search box.
Expected: TG-001, TG-005, TG-006 (three rows). The desktop searches the loaded rows and stops at the first column set
that has a match. HuId matches three rows, so the result is those three. A union over all four columns would also add
TG-003, TG-010 and TG-013, and that is wrong. Desktop: `RP_HUID.cs:1669-1689 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text +}}`
and the search box `RP_HUID.cs:1082 {{((Control)tSerchAll).TabIndex = 2;}}`.
Status: executable
Fails today: the web has no HUID search box (study Gap 15).

### huid-report.filter.search-second-column-match   (T02 Field route) · gap 15
Layer: browser
Steps: 1. Same In window. 2. Type "HU0003" in the search box.
Expected: TG-003 only. HuId has no match, so the search tries HuId2 and TG-003 matches (`RP_HUID.cs:1675 {{dataView.RowFilter = "HuId2 Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";}}`, the second
RowFilter).
Status: executable
Fails today: no search box (study Gap 15).

### huid-report.order.tag-no-ascending   (T02 Field route) · gap 16
Layer: browser
Steps: 1. Set the In window with HUID All and Item Type Gold. 2. Read the TagNo column top to bottom.
Expected: TG-001, TG-002, TG-003, TG-004, TG-005, TG-006, TG-010, TG-012, TG-013, TG-015. The desktop orders only by tag:
`RP_HUID.cs:1790 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}}`.
Status: executable
Passes today: `web/apps/api/src/modules/reports/huid.ts:159` orders by tag, then serial.
Note: study Gap 16 has no failing case by design, because the desktop does not define an order inside one tag, and
no desktop-derived expected value can fail. The supervisor should confirm that this guard is enough (see questions).

---

## T03 Formula sequence (totals and the stock sum)

### huid-report.total.in-window-sums   (T03 Formula) · gap 19
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026, Item Type Gold, HUID All. 2. Click "In Tag". 3. Read the footer totals.
Expected, computed from the 10 rows of the window: Qty = 10 (one per row, `RP_HUID.cs:1761 {{1 AS Qty,C.ITM_PCS as Pcs}}`).
Pcs = 1+2+1+1+1+1+1+1+1+1 = 11. Grwt = 10+20+8+5+6+4+3+1+12+2 = 71.000. NetWt = 9.5+19+7.8+4.9+5.8+3.9+2.9+1+11.5+1.9 = 68.200.
HuWt (first slot weight) = 0.500+0.400+0.200 = 1.100. HuWt2 = 0.300+0.100 = 0.400. HuWt3 = 0.000. HuWt4 = 0.250.
The desktop sums each column: `RP_HUID.cs:2068 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");}}`,
then Pcs, Grwt, NetWt, HuWt, HuWt2, HuWt3 and `RP_HUID.cs:2096 {{Columns["HuWt4"].Summary.Add((SummaryItemType)0, "HuWt4", "{0}");}}`.
Status: executable
Fails today: the web shows count, hallmarkedTags, slots, netWt and huidWt only; it has no Pcs or Grwt total and its `huidWt` adds all
four slots (`huid.ts:199-203`). On the same ten rows that is 1.750, not 1.100 (study Gap 19).

### huid-report.total.out-window-sums   (T03 Formula) · gap 19
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026, Item Type Gold. 2. Click "Out Tag".
Expected: 2 rows. Qty = 2. Pcs = 1+1 = 2. Grwt = 6.000+4.000 = 10.000. NetWt = 5.800+3.900 = 9.700. HuWt = 0.400+0.200 = 0.600.
The Out row values are the sale movement's own pcs and weights (the seed copies the tag's values onto the sale), and HuWt
comes from the origin tag's first slot (`RP_HUID.cs:1795 {{C.HM_ID_WT As HuWt}}`-style join, same quote as the In view).
Status: executable
Fails today: no Out view and no per-column totals (study Gaps 1 and 19).

### huid-report.total.stock-rule-sum   (T03 Formula) · gap 12
Layer: database
Steps: 1. Run the Stock base for the Test data (To 30/06/2026, Gold, year 2026-27, tag not N), computing the desktop
expression per origin tag: SUM(CASE WHEN ITM_SIGN='+' THEN VCH_SRNO ELSE -VCH_SRNO END) over its MAIN_STOCK movements. 2. Compare the
returned tags with the expected list.
Expected, per tag (S is the tag's VCH_SRNO):
- TG-001: +1 → sum 1 → in.
- TG-002: +2 → sum 2 → in.
- TG-003: +3 → sum 3 → in.
- TG-004: +4 → sum 4 → in.
- TG-005: +5, −5 → sum 0 → out (sold).
- TG-006: +6, −6, +6 → sum 6 → in (sold and returned).
- TG-010: stock date 15/07/2026 → out by the date bound (not summed).
- TG-011: +11 → sum 11 → in (stock date 02/04/2026, before From, still in stock).
- TG-012: srno 0, +0 → sum 0 → out (desktop rule; see the next case).
- TG-013: +13 → sum 13 → in.
- TG-014: +14 → sum 14 → in (stock date 01/04/2026).
- TG-015: +15 → sum 15 → in.
- TG-016: +16 → sum 16 → in (stock date 30/06/2026, the To date itself).
The in-stock sum of the included tags is 1+2+3+4+6+11+13+14+15+16 = 85. Desktop: `RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}`.
Status: executable
Fails today: the web's stock tab uses a net count and has no date, so it returns the 10 rows above plus TG-007, TG-008, TG-009 and TG-010 (study Gap 12, `huid.ts:139-146`).

### huid-report.total.stock-rule-srno-zero   (T03 Formula) · gap 12
Layer: browser
Steps: 1. Set To 30/06/2026, Item Type Gold. 2. Click "Stock Tag". 3. Look for TG-012.
Expected: TG-012 is absent. Its only movement is a `+` with VCH_SRNO 0, so the desktop sum is 0 and the HAVING test
`> 0` fails. Boundary note: a real tag normally has a serial above 0. The case pins the literal rule so the web cannot
silently use a count instead.
Status: executable
Fails today: the web's count is +1 for TG-012 and it is returned (`huid.ts:139-146`).

### huid-report.total.stock-rule-sold-and-returned   (T03 Formula) · gap 12
Layer: browser
Steps: 1. Set To 30/06/2026, Item Type Gold. 2. Click "Stock Tag". 3. Read TG-005 and TG-006.
Expected: TG-005 absent (sum 5 − 5 = 0). TG-006 present (sum 6 − 6 + 6 = 6). The rule as written gives these results.
Status: executable
Passes today: the web's count gives the same answer for these two tags (`huid.ts:139-146`), so this is a guard.

### huid-report.total.weights-rounding-to-precision   (T03 Formula) · gap 29
Layer: database
Steps: 1. Seed TG-001 with HM_ID_WT 0.5005 (four decimals, if the column stores them). 2. Run the In view. 3. Read HuWt.
Expected: the value the database stores, shown as the desktop shows it (no rounding in the form, `RP_HUID.cs:2068 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");}}`
only sets the format `"{0}"`).
Status: blocked: the stored precision of the weight columns is not known (study Open question 9). The web rounds each weight to
`PRECISION.weight` (`web/apps/api/src/modules/reports/huid.ts:82`, `:177`). It unblocks when the weight column's scale is
read from the schema, and the owner accepts the result.

---

## T04 Lookup (search, select, cancel, not found)

### huid-report.lookup.tag-no-found-focus-stays   (T04 Lookup) · gap 4
Layer: browser
Steps: 1. Click the TagNo box. 2. Type "TG-005" and press Enter.
Expected: no help list opens and the focus stays in the TagNo box. The desktop checks the tag in `BAR_DETL` for the company
and location and does nothing more when it exists: `RP_HUID.cs:2229 {{if ((int)e.KeyCode != 13)}}` and
`RP_HUID.cs:2233 {{Select A.TAG_NO FROM BAR_DETL AS A WHERE A.CO_CODE}}`, with the help branch at `RP_HUID.cs:2235 {{if (DC_Main.Rshlp.Rows.Count == 0)}}`.
Status: executable
Fails today: no TagNo box.

### huid-report.lookup.tag-no-missing-opens-help   (T04 Lookup) · gap 4
Layer: browser
Steps: 1. Type "TG-999" in TagNo and press Enter. 2. In the tag help list, choose "TG-001". 3. Read the TagNo box.
Expected: the help list opens with no message. After the choice, the TagNo box shows "TG-001". Desktop: the list opens with
`RP_HUID.cs:2244 {{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}` and the choice is copied with
`RP_HUID.cs:2247 {{tTagNo.Text = DC_Main.ColValue[0];}}`. There is no message box (study Rules).
Status: executable
Fails today: no TagNo box and no tag help.

### huid-report.lookup.account-found-selects-text   (T04 Lookup) · gap 5
Layer: browser
Steps: 1. Type "V1" in AcCode and press Enter.
Expected: no help list. The AcCode text is selected (SelectAll). Desktop: the account is found in `AC_MAST` and then
`RP_HUID.cs:2729 {{((TextBoxBase)tAcCode).SelectAll();}}`. The lookup itself is `RP_HUID.cs:2695 {{Select * From AC_MAST WHERE CO_CODE = '}}`.
Status: executable
Fails today: no AcCode box.

### huid-report.lookup.account-missing-opens-help   (T04 Lookup) · gap 5
Layer: browser
Steps: 1. Type "X999" in AcCode and press Enter. 2. In the account help list, choose "V2". 3. Read the AcCode box.
Expected: the help list opens with no message. After the choice the AcCode box shows "V2" and has focus. Desktop:
`RP_HUID.cs:2699 {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}` leads to the help branch,
`RP_HUID.cs:2722 {{tAcCode.Text = DC_Main.ColValue[1];}}` copies the code, and the box is refocused.
Status: executable
Fails today: no AcCode box.

### huid-report.lookup.account-filter-in-view   (T04 Lookup) · gap 5
Layer: browser
Steps: 1. Set the In window with Item Type Gold. 2. Type "V1" in AcCode. 3. Click "In Tag".
Expected: TG-001 only (the only origin row whose account is V1). Desktop: `RP_HUID.cs:1786-1789 {{AND C.AC_CODE = '}}`.
Status: executable
Fails today: web sends no account (`txn.ts:858-863`).

---

## T05 Children (drill-down)

### huid-report.drill.double-click-opens-source-voucher   (T05 Children) · gap 23
Layer: browser
Steps: 1. Run the In view for the window with Gold. 2. Double-click the TG-001 row.
Expected: a screen for the source voucher of TG-001 opens and shows the voucher number held in the row's VchNo column. The
desktop reads the row's voucher number and opens the form for its book: `RP_HUID.cs:2272 {{DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("V}}`
inside `RP_HUID.cs:2252 {{private void DGV_DoubleClick(object sender, EventArgs e)}}`.
Status: blocked: the target voucher screens were not traced in the study (its open question 4) and this package builds no drill-down handler (supervisor decision, 16 November 2026). Unblocks when the drill-down targets are studied.
Fails today: no drill-down (study Gap 23; `page.tsx` has no `onDoubleClick`).
Note: the identity of the target screen for each book is a separate case below (blocked).

### huid-report.drill.target-form-per-main-book   (T05 Children) · gap 23
Layer: browser
Steps: 1. Double-click a row whose book is OPSTK. 2. Repeat for a SALES book row and a TAG CANCEL row.
Expected: the form the desktop picks for each MAIN_BOOK: OPSTK → `RP_HUID.cs:2273 {{if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)}}`;
TAG CANCEL → `RP_HUID.cs:2290 {{else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)}}`;
SALES → `RP_HUID.cs:2325 {{else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)}}`.
Status: blocked: the target forms of these branches were not traced (study Open question 4). The branch list was read but not each target.
It unblocks when the target forms for the three branches are read.

### huid-report.drill.disabled-when-stock-merge-y   (T05 Children) · gap 23
Layer: browser
Steps: 1. Set the company's stock merge setting to Y. 2. Double-click a row.
Expected: nothing opens. Desktop: `RP_HUID.cs:2254 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)}}`.
Status: blocked: the meaning of `CO_STK_MERGE` is not known (study Open question 3, `MS_OPNCOMP.cs:706 {{DC_Main.MsCoStockMerge = }}`).
It unblocks when the owner states what the flag means and the settings catalogue has an entry for it.

---

## T06 Required and invalid

### huid-report.invalid.from-after-to-empty   (T06 Required/invalid) · gap 2
Layer: browser
Steps: 1. Set From 30/06/2026 and To 05/04/2026 (From after To). 2. Click "In Tag", then "Out Tag", then "Stock Tag".
Expected: all three grids are empty. No message is shown. The desktop checks no order of the dates (study Rules), so the
voucher-date conditions `RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}` and the To bound match no row. The Stock view with To 05/04/2026
returns the tags whose stock date is on or before 05/04/2026 (TG-011, TG-014) and is therefore not empty; the case checks
In and Out only for emptiness, and checks Stock for TG-011 and TG-014 only.
Status: executable
Fails today: the web applies no date, so the In result is not empty.

### huid-report.invalid.blank-or-bad-date   (T06 Required/invalid) · gap 2
Layer: browser
Steps: 1. Clear the From box. 2. Click "In Tag". 3. Type "31/02/2026" in From and click "In Tag" again.
Expected: the desktop result for a blank or invalid date is set by `DC_Main.SetDate` and by
`RP_HUID.cs:1761 {{Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}`.
Status: blocked: `DC_Main.SetDate` was not read (study Open question 6), so the desktop message and behaviour are unknown.
It unblocks when `DC_Main.SetDate` is read in the desktop source.

### huid-report.invalid.empty-result-no-message   (T06 Required/invalid) · gap 6
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026, Item Type Silver, Product "PR-RING". 2. Click "In Tag".
Expected: the grid is empty and no message is shown. Product PR-RING holds only gold rings, so no row matches. Desktop: the empty
result shows an empty grid with no message (`RP_HUID.cs:1876 {{RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}`
then `RP_HUID.cs:1877 {{DGV_FILL();}}`).
Status: executable
Fails today: no Item Type or Product box (study Gaps 6 and 7).

### huid-report.invalid.search-apostrophe-no-error   (T06 Required/invalid) · gap 15
Layer: browser
Steps: 1. Click "In Tag" for the window. 2. Type O'NEIL in the search box.
Expected: no error is shown and the grid is empty. The desktop breaks on an apostrophe (it concatenates the text into the
RowFilter, `RP_HUID.cs:1669-1689 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text +}}`); the web must not reproduce
that. Desktop weakness 6 in the study is not ported.
Status: executable
Fails today: no search box.

---

## T07 Create, T08 Reopen and no-op, T09 Edit, T10 Delete, cancel or reverse

### huid-report.lifecycle.create-not-applicable   (T07 Create)
Layer: unit
Steps: none.
Expected: none. This is a read report. The desktop's Delete button is empty: `RP_HUID.cs:1369 {{private void BtnDelete_Click(object sender, EventArgs e)}}`
with an empty body, and no create or edit path exists in the form (study Lifecycle).
Status: N/A: a report writes no voucher, so there is nothing to create (addendum: "a report writes nothing").

### huid-report.lifecycle.reopen-not-applicable   (T08 Reopen/no-op)
Layer: unit
Steps: none.
Expected: none.
Status: N/A: the report has no document to reopen; its only state is the screen filters, which the Cancel case covers.

### huid-report.lifecycle.edit-not-applicable   (T09 Edit)
Layer: unit
Steps: none.
Expected: none. `UserEdit` is read and never used (`RP_HUID.cs:1412 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.}}`).
Status: N/A: the report edits nothing.

### huid-report.lifecycle.delete-cancel-not-applicable   (T10 Delete/cancel/reverse)
Layer: unit
Steps: none.
Expected: none. The Delete button does nothing (`RP_HUID.cs:1369-1371 {{private void BtnDelete_Click(object sender, EventArgs e)}}`). The Cancel button only clears the screen, which is
covered by `huid-report.keys.cancel-clears-screen`.
Status: N/A: there is no voucher to delete, cancel or reverse.

---

## T11 Scope and rights

### huid-report.scope.other-company-never-appears   (T11 Scope/rights)
Layer: browser
Steps: 1. Seed TG-S1 in another company (GD-RING, VCH 10/04/2026, HUID "HUS001", a sale and a stock row). 2. Run In, Out and
Stock for company 01's window, and export CSV.
Expected: TG-S1 appears in no view, no total and no export. Desktop with merge N: `RP_HUID.cs:1761 {{WHERE C.CO_CODE = '}}`-style
company filter, the same in the In base (`RP_HUID.cs:1761 {{WHERE C.CO_CODE = '}}`).
Status: executable
Passes today: `web/apps/api/src/modules/reports/huid.ts:118` filters `CO_CODE`.

### huid-report.scope.other-location-never-appears   (T11 Scope/rights)
Layer: browser
Steps: 1. Seed TG-S2 in the same company and another location (GD-RING, VCH 10/04/2026, HUID "HUS002"). 2. Run all views.
Expected: TG-S2 appears in no view. Desktop: `RP_HUID.cs:1761 {{AND C.LC_CODE = '}}`.
Status: executable
Passes today: `huid.ts:119` filters `LC_CODE`.

### huid-report.scope.prior-year-tag-never-appears   (T11 Scope/rights) · gap 3
Layer: browser
Steps: 1. Set the window 05/04/2026 to 30/06/2026 and Item Type Gold. 2. Run In, Out and Stock. 3. Look for TG-009.
Expected: TG-009 (financial year 2025-26, stock date 10/05/2025) appears in no view. Desktop: In `RP_HUID.cs:1761 {{AND C.CO_YEAR = '}}`,
Out `RP_HUID.cs:1795 {{AND A.CO_YEAR = '}}`, Stock `RP_HUID.cs:1838 {{AND A.CO_YEAR = '}}`.
Status: executable
Fails today: the web applies no year (`huid.ts:118-119`), so TG-009 appears in the web's stock and all-history results.

### huid-report.scope.other-tenant-never-appears   (T11 Scope/rights)
Layer: database
Steps: 1. Seed TG-S3 in a second tenant with HUID "HUT001". 2. Run the report as tenant 1 and call the API directly with the
other tenant's scope values.
Expected: TG-S3 is never returned, and the API returns only tenant 1 rows. The web must enforce this through the tenant row-level
security, not only through the company filter.
Status: executable
Passes today: `huid.ts:92` (`withTxBudget(prisma, tenantId, 'read', …)`) runs in the tenant context.

### huid-report.rights.print-refused-without-print-right   (T11 Scope/rights) · gap 22
Layer: browser
Steps: 1. Log in as a user with the view right but without the print right. 2. Click the report's PDF output, then the CSV and the Excel outputs.
Expected: each request is refused by the API with status 403 and the body `{"error":"forbidden","action":"print"}`. This is the
web's rule from the report addendum and supervisor fact 3, a deliberate difference from the desktop, whose Print button has no check
(`RP_HUID.cs:2189 {{private void BtnPrint_Click(object sender, EventArgs e)}}`). The guard: `web/apps/api/src/routes/txn.ts:921-929`
(`reply.code(403).send({ error: 'forbidden', action })`), and `txn.ts:4451`, `:4464`, `:4482`.
Status: executable
Passes today at the API. The screen part is covered by the next case.

### huid-report.rights.print-refusal-text   (T11 Scope/rights) · gap 22
Layer: browser
Steps: 1. As the user without the print right, click "Excel" (the desktop's Excel button) and read the message.
Expected: the message "You Have No Print Rights....." is shown, and the grid does not change. The desktop text is the
only message in the form, `RP_HUID.cs:1361 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}`,
shown by Excel when the condition `RP_HUID.cs:1359 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}` holds.
Status: executable
Fails today: the web's refusal text is not the desktop's (study Gap 22; the web returns a JSON 403 and no such message).

### huid-report.rights.view-refused-without-view-right   (T11 Scope/rights)
Layer: database
Steps: 1. Call `GET /reports/huid` as a user without the report right.
Expected: refused. Existing test: `web/apps/api/test/reportScreens.routes.db.test.ts:176-190`.
Status: executable
Passes today.

### huid-report.rights.list-right   (T11 Scope/rights)
Layer: browser
Steps: 1. Log in with rights `----PL` but no List right. 2. Try the report.
Expected: owner decision. The catalog row says the report has List (`docs/handbook/menu-catalog.jsonl`, `----PL`), but no code
in the form reads a list right (`RP_HUID.cs:1412-1414 {{UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));}}`, and the lines after it read delete and print only, study Rights).
Status: blocked: study Open question 8. It unblocks when the owner decides whether List is checked.

---

## T12 Concurrency

### huid-report.concurrency.two-users-export-independent   (T12 Concurrency) · desktop weakness 3
Layer: browser
Steps: 1. Two users with the print right, in the same company, run "Excel" on the same filter at the same time. 2. Compare the
two files.
Expected: both files hold the same rows and totals, and neither overwrites the other. The desktop's print list is one shared
table with no user key: `RP_HUID.cs:2168 {{DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE}}` (study weakness 3). The web must not share
a staging list.
Status: executable
Passes today: the web's export re-runs the query per request (`txn.ts:4451-4482`).

---

## T13 Retry and unknown result

### huid-report.retry.not-applicable   (T13 Retry/unknown)
Layer: unit
Steps: none.
Expected: none.
Status: N/A: the report is read-only. A duplicate request returns the same rows and writes nothing, so there is no financial
effect to protect.

---

## T14 Rollback and no partial write

### huid-report.write.view-leaves-bar-detl-unchanged   (T14 Rollback) · desktop weakness 1
Layer: database
Steps: 1. Seed TG-001 with HM_ID NULL and TG-002 with HM_ID2 NULL in the company. 2. Click "In Tag", "Out Tag" and "Stock Tag".
3. Read `BAR_DETL` for those tags.
Expected: the rows are unchanged. HM_ID stays NULL (not converted to ''). The desktop rewrites every NULL to '' on each view
for the whole company: `RP_HUID.cs:1754 {{UPDATE BAR_DETL SET HM_ID = '' WHERE CO_CODE = '}}` and `RP_HUID.cs:1757 {{AND HM_ID4 Is NULL}}`.
The web must read NULL, empty and blank the same way without writing (study recommendation, "Lifecycle and write set").
Status: executable
Passes today: the web's report is read-only (`huid.ts:117-207` has no write).

### huid-report.write.print-leaves-no-staging-rows   (T14 Rollback) · desktop weakness 2-4
Layer: database
Steps: 1. Click "Excel" and the PDF output for the Stock view. 2. Count the rows in any staging table the desktop would use
(TAG_STOCK_PRINT) and in `BAR_DETL`, `MAIN_STOCK` before and after. 3. Close the screen.
Expected: no row is added to any table and no row is deleted. The desktop prints from a shared staging table and deletes it
without a key at close: `RP_HUID.cs:2140 {{DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");}}`, and inserts one row per grid row
(`RP_HUID.cs:2179 {{VCH_SRNO,'+',1,ITM_PCS,ITM_GWT,ITM_NWT,'A',}}`). The web must not port any of this (study weaknesses 2 to 4).
Status: executable
Passes today: the web has no staging table for this report.

---

## T15 Configuration and history

### huid-report.config.stock-merge-y-company-scope   (T15 Config/history)
Layer: browser
Steps: 1. Set the company's stock merge setting to Y. 2. Run Out and Stock. 3. Check for another company's movements.
Expected: owner decision. The desktop drops the company filter when the flag is Y
(`RP_HUID.cs:1795 {{WHERE  A.LC_CODE = '}}`), which lets other companies' movements in (study weakness 7). The web must keep the company filter
(T11). What the flag means is not known.
Status: blocked: `CO_STK_MERGE` has no entry in the settings catalogue (study Open question 3, `MS_OPNCOMP.cs:706 {{Rows[0]["CO_STK_MERGE"]}}`).
It unblocks when the owner states the meaning of the flag.

### huid-report.config.data-type-filter   (T15 Config/history) · gap 14
Layer: browser
Steps: 1. Set the company data type to A. 2. Run In. 3. Set it to C and run In again.
Expected: with C there is no data-type condition, and with A the condition `AND C.DATA_TYPE = 'A'` restricts the rows. Desktop:
`RP_HUID.cs:1761 {{Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0}}` and the codes
`MDI_FORM.cs:12740 {{DC_Main.MsDataType = "C";}}` and `MDI_FORM.cs:12732-12736 {{DC_Main.MsDataType = "A";}}` (the B branch is at 12736).
Status: blocked: what the codes A, B and C mean is not known (study Open question 3). It unblocks when the owner states what
each data-type code is for.

### huid-report.history.group-renamed-live-master   (T15 Config/history) · gap 6
Layer: browser
Steps: 1. Seed a tag sold on 12/06/2026 whose item's group is GR-LINK. 2. Change the item's group to GR-LINK2 after the sale.
3. Filter the Out view by group GR-LINK2.
Expected: the sale row is returned, because the desktop joins `ITEM_MAST` at report time. Desktop: `RP_HUID.cs:1813-1823 {{AND B.GR_CODE = '}}`
on the live join `ITEM_MAST AS B` (`RP_HUID.cs:1795 {{LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE}}`).
Status: executable
Fails today: no Group box (study Gap 6).

---

## T16 Report output (grid, CSV, Excel, PDF, print)

### huid-report.output.excel-follows-search   (T16 Output) · gap 20
Layer: browser
Steps: 1. Click "In Tag" for the window with Gold. 2. Type "HU00" in the search box. 3. Click "Excel" (the web's export; the
desktop's Excel is `RP_HUID.cs:1365 {{DGV.ExportToXlsx(text);}}`).
Expected: the exported file holds TG-001, TG-005 and TG-006 only (the search result), with the same totals as the grid.
Status: executable
Fails today: no search box, and the web's Excel re-derives the rows (`web/apps/web/app/(app)/reports/[report]/page.tsx:1564-1566`).

### huid-report.output.csv-matches-grid-totals   (T16 Output)
Layer: browser
Steps: 1. Click "In Tag" for the window with Gold. 2. Export CSV. 3. Compare the rows and the footer with the grid.
Expected: the same 10 rows and the same totals as `huid-report.total.in-window-sums`.
Status: executable
Fails today: the CSV has the web's totals, not the desktop's per-column sums (study Gap 19).

### huid-report.output.columns-desktop-order   (T16 Output) · gap 17
Layer: browser
Steps: 1. Click "In Tag". 2. Read the column headers in order.
Expected: the 24 columns of the desktop SELECT, in order: CoCode, VchTyp, VchNo, VchDate, TagNo, ItCode, Counter, Qty, Pcs, Grwt,
NetWt, HuId, HuWt, HuId2, HuWt2, HuId3, HuWt3, HuId4, HuWt4, KrName, Book, BookName, ItRemark, TagId (`RP_HUID.cs:1761 {{C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.VCH_DATE As VchDate}}`
and the rest of that SELECT).
Status: executable
Fails today: the web's grid has its own fields, including `itName`, which the desktop does not show (study Gap 17, `huid.ts:161-190`).

### huid-report.output.stock-date-column   (T16 Output) · gap 17
Layer: browser
Steps: 1. Click "Stock Tag". 2. Read the date column header.
Expected: the Stock view's date column is "StkDate", from the stock date, and the In and Out views use "VchDate". Desktop: `RP_HUID.cs:1838 {{C.STK_DATE As StkDate}}`
and the In/Out `C.VCH_DATE As VchDate` at `RP_HUID.cs:1761 {{C.VCH_DATE As VchDate}}`.
Status: executable
Fails today: the web returns `vchDate` for every tab (study Gap 17).

### huid-report.output.out-kr-name-blank   (T16 Output) · gap 17
Layer: browser
Steps: 1. Seed the sale of TG-005 with a karigar name on the origin tag. 2. Click "Out Tag" and read the KrName column for TG-005.
Expected: blank. The desktop's Out view selects an empty string: `RP_HUID.cs:1795 {{'' As KrName,A.CO_BOOK As Book}}`.
Status: executable
Fails today: the web returns `KR_NAME` for every tab (`huid.ts:184`).

### huid-report.output.coCode-book-hidden-when-merge-n   (T16 Output) · gap 17
Layer: browser
Steps: 1. Keep the merge flag at N. 2. Click "In Tag" and read the visible columns.
Expected: the CoCode, Book and BookName columns are not shown. Desktop: `RP_HUID.cs:2038 {{((ColumnView)GridView1).Columns["CoCode"].Visible = false;}}`,
`RP_HUID.cs:2042 {{((ColumnView)GridView1).Columns["Book"].Visible = false;}}`, `RP_HUID.cs:2046 {{((ColumnView)GridView1).Columns["BookName"].Visible = false;}}`.
The CoCode rule is `RP_HUID.cs:2031 {{if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) != 0)}}`.
Status: executable
Fails today: the web has no HUID column definition (study Gap 17), so the columns are not hidden.

### huid-report.output.headers-desktop-aliases   (T16 Output) · gap 18
Layer: browser
Steps: 1. Click "In Tag". 2. Read the header row.
Expected: the desktop shows the SELECT aliases as headers because no caption is set (study Gap 18). The exact header text the
web must show is the owner's choice.
Status: blocked: the owner must choose the header text (study Open question 10; a desktop screenshot or the video knowledge base
would settle it, neither was read here).

### huid-report.output.print-title-and-grouping   (T16 Output) · gap 21
Layer: browser
Steps: 1. Set the Stock window to To 30/06/2026, Item Type Gold. 2. Click the print output.
Expected: the title "Tag Wise Huid Report As on Date 30/06/2026". The desktop title is `RP_HUID.cs:2192 {{string text = "Tag Wise Huid Report As on Date ";}}`
followed by the To date in dd/MM/yyyy. The rows are grouped by product, then by group (the Crystal template
`extraction_output/rpt_xml/TagHuIdRpt.xml` line 312 groups on `ITEM_MAST.PR_CODE`, line 313 on `ITEM_MAST.GR_CODE`; the
template file is present, study "Print", so this is not a missing template).
Status: executable
Fails today: the web's PDF is the generic route (`txn.ts:4481-4483`) and has no TagHuIdRpt layout (study Gap 21).

### huid-report.output.print-rows-follow-grid-search   (T16 Output) · gap 21
Layer: browser
Steps: 1. Click "Stock Tag" for the window. 2. Type "HU00" in search. 3. Click Print.
Expected: the printed report holds only the rows shown in the grid after the search (the three rows with HU00 in HuId). Desktop:
`RP_HUID.cs:2191 {{Stk_Insert();}}` inserts one row for each grid row currently shown (study Print).
Status: executable
Fails today: no search box and no HUID print layout.

### huid-report.output.print-stock-date-to-filter   (T16 Output) · gap 12, 21
Layer: browser
Steps: 1. Seed TG-016 (VCH 05/07/2026, STK 30/06/2026, in stock; see Test data). 2. Set To 30/06/2026, Item Type Gold. 3. Click
"Stock Tag" and read the grid: TG-016 is shown. 4. Click print.
Expected: the grid shows 10 rows including TG-016. The printed report shows 9 rows, without TG-016, because the desktop's print
selection filters the voucher date on the staging rows: `RP_HUID.cs:2219 {{{TAG_STOCK_PRINT.VCH_DATE} <= #}}` (the voucher date of
TG-016 is 05/07/2026, after To). The Stock grid filters the stock date (study Gap 12).
Status: executable
Fails today: the web prints all grid rows (study Gap 12). Owner to confirm the desktop rule is to be kept (questions).

### huid-report.output.print-formula-totals   (T16 Output) · gap 21
Layer: browser
Steps: 1. Print the Stock Gold window. 2. Read the group totals and the report totals on the printed page.
Expected: the group and report summaries of the weights (Crystal template `TagHuIdRpt.xml`, summaries on the four weight formulas and
the four `BAR_DETL` HUID weights, study Print).
Status: blocked: the Crystal formula bodies `@TagQty`, `@TagGwt`, `@TagNwt`, `@TagPcs`, `@NewBal`, `@VchSrno` were not extracted
(study Open question 5, marked MISSING). It unblocks when the formula bodies are extracted from `extraction_output/rpt_xml/TagHuIdRpt.xml`.

### huid-report.output.pdf-whole-result-beyond-page   (T16 Output)
Layer: browser
Steps: 1. Seed 60 Gold tags in the window (any tags beyond the page size; the test seed generates them). 2. Export PDF and CSV.
Expected: the export holds all 60 new rows plus the 10 window rows (70 in total), and the totals cover all 70, not one page.
Status: executable
Passes or fails: to be measured. The web returns every row from `huidReport` (`huid.ts:149-161`), so the totals should cover the full result.

### huid-report.output.stkdate-column-hidden-for-named-registrations   (T16 Output) · gap 17
Layer: browser
Steps: none.
Expected: none. The desktop hides StkDate for two named registrations (`RP_HUID.cs:2064 {{((ColumnView)GridView1).Columns["StkDate"].Visible = false;}}`),
a customer-specific rule (study weakness 11).
Status: N/A: customer-specific behaviour; the study says do not port it.

### huid-report.labels.title-desktop-text   (T16 Output) · gap 28
Layer: browser
Steps: 1. Open the report and read the header.
Expected: the desktop title is "Tag Stock With HuId" (`RP_HUID.cs:1067 {{lblBook.Text = "Tag Stock With HuId";}}`, caption `RP_HUID.cs:1331 {{((XtraForm)this).Text = "Tag Stock With Huid";}}`).
The web shows "HUID Report" (`web/apps/web/app/(app)/reports/[report]/page.tsx:56`).
Status: blocked: the owner chooses the title (study Gap 28, Open question 11: the run-time caption comes from `DC_Main.MsUserRightForm`, whose setter was not found).

### huid-report.labels.hallmark-options   (T16 Output) · gap 27
Layer: browser
Steps: 1. Open the HUID box and read its options.
Expected: the desktop options are "All", "With HuId", "Whout HuId" (`RP_HUID.cs:1571 {{cboHuId.Items.Add((object)"With HuId");}}`,
`RP_HUID.cs:1572 {{cboHuId.Items.Add((object)"Whout HuId");}}`). "Whout" is a typo in the source. The web uses "With HUID" and "Without HUID".
Status: blocked: the owner must confirm the wording (study Gap 27). The web wording is intended, per the study.

---

## T17 Keyboard and usability

### huid-report.keys.enter-from-date-moves-to-to-date   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Focus the From box, type 05/04/2026, press Enter.
Expected: the focus moves to the To box. Desktop: `RP_HUID.cs:2644 {{if ((int)e.KeyCode == 13)}}`, then `RP_HUID.cs:2651 {{SendKeys.Send("{tab}");}}`.
Status: executable
Fails today: no keyboard handling for HUID (study Gap 24).

### huid-report.keys.enter-to-date-moves-next   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Focus the To box and press Enter.
Expected: the focus moves to the next control in tab order. Desktop: `RP_HUID.cs:2660 {{if ((int)e.KeyCode == 13)}}`, then the same Tab.
Status: executable
Fails today: no keyboard handling (study Gap 24).

### huid-report.keys.focus-from-date-on-open   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Open the report by keyboard only.
Expected: the focus is in the From box. Desktop: `RP_HUID.cs:1622 {{CurActCtrl = (Control)(object)mFromDt;}}`.
Status: executable
Fails today: no focus rule (study Gap 24).

### huid-report.keys.date-text-selected-on-focus   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Tab into the From box.
Expected: the whole date text is selected. Desktop: `RP_HUID.cs:2675 {{((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);}}`.
Status: executable
Fails today: not implemented for HUID.

### huid-report.keys.alt-mnemonics-run-views   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Set the window. 2. Press Alt+S (Stock), Alt+I (In) and Alt+O (Out) in turn.
Expected: each key runs its view. The mnemonics come from the captions with `&`: `RP_HUID.cs:1121 {{BtnStock.Text = "&Stock Tag";}}`,
`RP_HUID.cs:1177 {{BtnIn.Text = "&In Tag";}}`, `RP_HUID.cs:1149 {{BtnOut.Text = "&Out Tag";}}`.
Status: executable
Fails today: the web's buttons have no such mnemonics, and no Out button exists (study Gap 1).

### huid-report.keys.escape-closes   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Press Escape on the report.
Expected: the report closes (returns to the previous screen). Desktop: `RP_HUID.cs:1732 {{if ((int)e.KeyCode == 27)}}` and `RP_HUID.cs:1734 {{((Form)this).Close();}}`.
Status: executable
Fails today: no Escape handling for HUID (study Gap 24).

### huid-report.keys.arrow-moves-to-grid   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. Focus the HUID box and press the Down arrow.
Expected: the focus moves to the grid. Desktop: `RP_HUID.cs:1736 {{if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))}}`
and `RP_HUID.cs:1738 {{((Control)DGV).Focus();}}`.
Status: executable
Fails today: no arrow handling for HUID.

### huid-report.keys.typed-upper-case   (T17 Keyboard) · gap 24
Layer: browser
Steps: 1. In the TagNo box type "tg-001" with the keyboard.
Expected: the box shows "TG-001". Desktop: every typed character is upper-cased (`RP_HUID.cs:1715 {{num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));}}`).
The desktop also drops the apostrophe and NUL characters (`RP_HUID.cs:1718 {{if (num == 0 || num == 39)}}`); the web must not
drop characters that a valid tag can hold. Only the upper-case rule is tested here.
Status: executable
Fails today: no TagNo box for HUID.

### huid-report.keys.cancel-clears-screen   (T17 Keyboard) · gap 26
Layer: browser
Steps: 1. Set the window, Item Type Silver and HUID "With HuId". 2. Run "In Tag". 3. Click "Cancel" (Alt+C).
Expected: the screen is cleared and the dates return to today (the desktop clears the screen and resets the dates).
Desktop: `RP_HUID.cs:1744 {{CLEAR_DATA();}}` and `RP_HUID.cs:1626 {{private void CLEAR_DATA()}}`, with the dates set in the body
(`RP_HUID.cs:1620 {{mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);}}`).
Status: executable
Fails today: no Cancel control for HUID (study Gap 26, `page.tsx:1388-1433`).

### huid-report.keys.tab-order-ties-blocked   (T17 Keyboard) · gap 1
Layer: browser
Steps: 1. Press Tab from the first control and record the order of focus stops.
Expected: the order follows the TabIndex values, and the ties (0, 2 and 7) resolve as the desktop does. The desktop does not resolve
ties in the source (study Open question 12).
Status: blocked: the tie order is not in the source (study Open question 12). It unblocks when the owner accepts a tie-break rule, or
a desktop run records the order.

---

## T18 Full journey (tags made through the screens, then sold, returned and cancelled)

Setup modules: `web/apps/web/test/features/modules/tagOpening.mjs` (Tag Opening, hallmark id slots), `purchaseInvoice.mjs`
(Purchase with a hallmark), `salesInvoice.mjs` (Sales), `salesReturn.mjs` (Sales Return) and `tagCancel.mjs` (Tag Cancel). These
are the feature modules the journey uses to create its vouchers through the real screens.

Journey tags (run in the same test, not the static seed):
- JT-1: GD-RING, Tag Opening dated 10/06/2026, HUID slot 1 "HUJ001" (weight 0.300), gross 5.000, net 4.800.
- JT-2: GD-CHAIN, Tag Opening dated 10/06/2026, no HUID, gross 7.000, net 6.700.
- JT-3: GD-RING, Purchase (hallmarked) dated 11/06/2026, HUID slot 1 "HUJ003" (weight 0.250), gross 6.000, net 5.700.
- JT-4: GD-RING, Purchase dated 11/06/2026, no HUID, gross 3.000, net 2.900.
- Sale of JT-1 dated 12/06/2026 (the sale movement carries JT-1's values: pcs 1, gross 5.000, net 4.800, HUID weight 0.300).
- Return of JT-1 dated 14/06/2026 (a `+` movement with JT-1's serial).
- Cancel of JT-2 dated 13/06/2026 (Tag Cancel).
Window for every stage: From 10/06/2026 to 14/06/2026, Item Type Gold.
The desktop rules are the ones in the rules section above. Each tag's VCH_SRNO is read from the database after creation; the expected
values below are written as formulas in those serials (s1 for JT-1, s2 for JT-2, s3 for JT-3, s4 for JT-4).

### huid-report.journey.stage-1-tags-and-purchase-in-view   (T18 Journey) · gap 1
Layer: browser
Steps: 1. Create JT-1 and JT-2 through Tag Opening and JT-3 and JT-4 through the hallmarked Purchase. 2. Open the report, set
the window, click "In Tag". 3. Click "Out Tag" and "Stock Tag".
Expected: In: 4 rows (JT-1, JT-2, JT-3, JT-4). Pcs = 4. Grwt = 5+7+6+3 = 21.000. NetWt = 4.8+6.7+5.7+2.9 = 20.100. HuWt = 0.300+0.250 = 0.550.
With HUID (first slot) = 2 (JT-1, JT-3). Out: 0 rows. Stock: 4 rows (JT-1, JT-2, JT-3, JT-4), sum s1+s2+s3+s4.
Status: executable
Fails today: no Out view and no Stock tab with the desktop rule (study Gap 1).

### huid-report.journey.stage-2-sale-out-and-stock   (T18 Journey) · gap 1
Layer: browser
Steps: 1. Sell JT-1 through the sales screen dated 12/06/2026. 2. Read the three views for the window.
Expected: In: 4 rows (unchanged; the In view shows the origin). Out: 1 row (JT-1, Grwt 5.000, NetWt 4.800, HuWt 0.300). Stock: 3 rows
(JT-2, JT-3, JT-4), sum s2+s3+s4 (JT-1 has +s1 −s1 = 0 and is out). Consistency: In (4) = Stock (3) + sold and not returned (1) + cancelled (0).
Status: executable
Fails today: no Out view (study Gap 1).

### huid-report.journey.stage-3-return-views-agree   (T18 Journey) · gap 1
Layer: browser
Steps: 1. Return JT-1 through the sales return screen dated 14/06/2026. 2. Read the three views for the window.
Expected: In: 4 rows. Out: still 1 row (the sale; the return is a `+` movement and is not an Out row). Stock: 4 rows (JT-1 back in stock, JT-1 net
s1 − s1 + s1 = s1), sum s1+s2+s3+s4. Consistency: In (4) = Stock (4) + sold and not returned (0) + cancelled (0).
Status: executable
Fails today: no Out view and no desktop Stock rule (study Gap 1 and 12).

### huid-report.journey.stage-4-cancel-views-agree   (T18 Journey) · gap 1
Layer: browser
Steps: 1. Cancel JT-2 through the Tag Cancel screen dated 13/06/2026. 2. Read the three views for the window.
Expected: the cancelled tag leaves Stock, and the consistency check In = Stock + sold-and-not-returned + cancelled must hold.
Status: blocked: the MAIN_STOCK and BAR_DETL rows that Tag Cancel writes are not in this study. The Stock result for JT-2 depends on them.
It unblocks when the Tag Cancel desktop form is read and its rows traced (the form is outside this menu).

---

## Test data

The seed runs on the isolated database started by `web/scripts/parity-test-env.mjs`. Values are synthetic.

Company, location and year: one company, one location, financial year 2026-27 (April to March). A second company, a second location, a
2025-26 year and a second tenant hold only the sentinel tags below.

Masters:
- Items: GD-RING (Gold, product PR-RING, group GR-PLAIN); GD-CHAIN (Gold, product PR-CHAIN, group GR-LINK); SV-CHAIN (Silver,
  product PR-CHAIN, group GR-SILV).
- Counters C1 and C2 (TBL_CODE values).
- Accounts: V1 and V2 (vendors, `AC_MAST`); K1 and K2 (customers).
- Settings: metal type G; stock merge N; the data-type code that gives no data-type condition (desktop `C`, `MDI_FORM.cs:12740 {{DC_Main.MsDataType = "C";}}`).

Origin tags (one `BAR_DETL` row each; the stated `+` movement is one `MAIN_STOCK` row carrying the tag's VCH_SRNO and item):

| Tag | Item | Origin date | Stock date | VCH_SRNO | Counter | Pcs | Gross | Net | HUID slots (value / weight) | Movements | Other |
|---|---|---|---|---|---|---|---|---|---|---|---|
| TG-001 | GD-RING | 10/04/2026 | 10/04/2026 | 1 | C1 | 1 | 10.000 | 9.500 | HM_ID HU0001 / 0.500 | + | account V1 |
| TG-002 | GD-CHAIN | 12/04/2026 | 12/04/2026 | 2 | C1 | 2 | 20.000 | 19.000 | none | + | account V2 |
| TG-003 | GD-RING | 15/04/2026 | 15/04/2026 | 3 | C2 | 1 | 8.000 | 7.800 | HM_ID2 HU0003 / 0.300 | + | account V2 |
| TG-004 | GD-RING | 16/04/2026 | 16/04/2026 | 4 | C1 | 1 | 5.000 | 4.900 | HM_ID three spaces / 0.000 | + | whitespace case |
| TG-005 | GD-RING | 20/04/2026 | 20/04/2026 | 5 | C1 | 1 | 6.000 | 5.800 | HM_ID HU0005 / 0.400 | +, then − on 25/04/2026 (sale to K1) | sold |
| TG-006 | GD-RING | 22/04/2026 | 22/04/2026 | 6 | C2 | 1 | 4.000 | 3.900 | HM_ID HU0006 / 0.200 | +, then − on 26/04/2026 (sale to K2), then + on 28/04/2026 (return) | sold and returned |
| TG-007 | SV-CHAIN | 05/05/2026 | 05/05/2026 | 7 | C1 | 3 | 30.000 | 29.000 | HM_ID HS0007 / 1.000 | + | Silver |
| TG-008 | GD-RING | 06/05/2026 | 06/05/2026 | 8 | C1 | 1 | 2.000 | 2.000 | none | + | TAG_NO is N |
| TG-009 | GD-RING | 10/05/2025 | 10/05/2025 | 9 | C1 | 1 | 7.000 | 6.900 | none | + | year 2025-26 |
| TG-010 | GD-RING | 20/05/2026 | 15/07/2026 | 10 | C1 | 1 | 3.000 | 2.900 | HM_ID2 HU0010 / 0.100 | + | stock date after To |
| TG-011 | GD-RING | 02/04/2026 | 02/04/2026 | 11 | C1 | 1 | 9.000 | 8.900 | HM_ID HU0011 / 0.600 | + | before From |
| TG-012 | GD-RING | 25/05/2026 | 25/05/2026 | 0 | C1 | 1 | 1.000 | 1.000 | none | + | serial 0 boundary |
| TG-013 | GD-CHAIN | 18/04/2026 | 18/04/2026 | 13 | C2 | 1 | 12.000 | 11.500 | HM_ID4 HU0013 / 0.250 | + | slot 4 only |
| TG-014 | GD-RING | 01/04/2026 | 01/04/2026 | 14 | C1 | 1 | 1.000 | 0.950 | none | + | before From |
| TG-015 | GD-CHAIN | 30/06/2026 | 30/06/2026 | 15 | C1 | 1 | 2.000 | 1.900 | none | + | To boundary |
| TG-016 | GD-RING | 05/07/2026 | 30/06/2026 | 16 | C1 | 1 | 1.000 | 0.900 | none | + | voucher after To, stock on To |

Account codes on origin rows: V1 for TG-001, V2 for every other origin tag. The sale rows carry K1 (TG-005) and K2 (TG-006).

Sentinels (never appear in any view of the company 01 window): TG-S1 in the other company (GD-RING, origin 10/04/2026, HUID HUS001,
one sale); TG-S2 in the other location (GD-RING, origin 10/04/2026, HUID HUS002); TG-S3 in the other tenant (HUID HUT001, origin 10/04/2026).
TG-009 (prior year) is the year sentinel inside the company.

Journey tags are created by the journey test itself (section T18). Nothing else is needed; the static seed above is enough for T01 to T17.

## Coverage table

Counts are case entries in this file. "Blocked" counts entries whose status is `blocked`. N/A entries are counted as cases with
the N/A status.

| Kind | Name | Cases | Blocked | Executable | N/A |
|---|---|---|---|---|---|
| T01 | Entry and defaults | 7 | 1 | 6 | 0 |
| T02 | Field route | 17 | 1 | 16 | 0 |
| T03 | Formula sequence | 6 | 1 | 5 | 0 |
| T04 | Lookup | 5 | 0 | 5 | 0 |
| T05 | Children (drill-down) | 3 | 3 | 0 | 0 |
| T06 | Required and invalid | 4 | 1 | 3 | 0 |
| T07 | Create | 1 | 0 | 0 | 1 |
| T08 | Reopen and no-op | 1 | 0 | 0 | 1 |
| T09 | Edit | 1 | 0 | 0 | 1 |
| T10 | Delete, cancel or reverse | 1 | 0 | 0 | 1 |
| T11 | Scope and rights | 8 | 1 | 7 | 0 |
| T12 | Concurrency | 1 | 0 | 1 | 0 |
| T13 | Retry and unknown result | 1 | 0 | 0 | 1 |
| T14 | Rollback and no partial write | 2 | 0 | 2 | 0 |
| T15 | Configuration and history | 3 | 2 | 1 | 0 |
| T16 | Report output | 15 | 4 | 10 | 1 |
| T17 | Keyboard and usability | 10 | 1 | 9 | 0 |
| T18 | Full journey | 4 | 1 | 3 | 0 |
| **Total** | | **90** | **16** | **68** | **6** |

## Not covered

Each item is a behaviour in the study that no case covers, or a decision the owner must confirm.

1. **Removal of the web's "All history" tab** (`page.tsx:1393-1400`). Supervisor fact 1 says the web follows the three desktop views. The case
   `huid-report.entry.menu-opens-three-views` expects this removal. The removal itself is a decision for the owner to confirm.
2. **Counter and Item code filters on the web** (`page.tsx:1416-1432`, `huid.ts:120-127`). Supervisor fact 7 says the desktop has none. The
   cases `huid-report.filter.counter-absent` and `huid-report.filter.item-code-absent` expect them absent. The owner must confirm.
3. **Gap 16 (sort order inside one tag)** has no failing case. The desktop defines no order inside one tag, so no desktop-derived
   expectation can fail. The guard `huid-report.order.tag-no-ascending` is the only case.
4. **Gap 22 (print rights)** is a deliberate difference (supervisor fact 3). The refusal cases pass today at the API. The desktop text appears
   in `huid-report.rights.print-refusal-text`, which fails today.
5. **Gap 11 (whitespace)** is blocked, not failing, because the desktop's SQL Server comparison and supervisor fact 5 disagree.
6. **Stock sum rule (gap 12)** reduces, on the desktop join, to `VCH_SRNO × (count + − count −)`. Only a serial of 0 or below separates the desktop
   rule from the web's net count. The case `stock-rule-srno-zero` pins that boundary; the owner should confirm it matters for real data.
7. **The desktop's `BAR_DETL` writes, shared staging table and drill-down** are not ported (study weaknesses 1 to 4). Cases `write.*` and the
   drill-down cases pin the web's expected behaviour; the drill-down target screens are blocked (Open question 4).
8. **Customer-specific StkDate hiding** (study weakness 11) is N/A and not ported.
9. **Crystal formula bodies** (`@TagQty` … `@VchSrno`), **`DC_Main.SetDate`**, **`CO_STK_MERGE`**, **the data-type codes A, B and C**, **the
   metal type setting**, **the header text** and **the stored weight precision** are open questions. Their cases are blocked, as listed above.
10. **Tab order inside ties** (Open question 12) is blocked.
11. **Tag Cancel's stock effect** (T18 stage 4) is blocked; it is outside this menu.
12. **Other reports** (Ledger, Stock, Purchase) and the UAE variants are out of scope (study Scope).
