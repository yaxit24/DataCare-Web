# RP_ALL Sales branch: inventory (WP-11, phase one)

Inventory of what the desktop `RP_ALL` form does for the **Report → Sales Report** menu, read from
`unified/src/csharp/DataCareNext/RP_ALL.cs` (12,662 lines) and the extracted Crystal templates in
`extraction_output/rpt_xml/`. Every row cites the source line. It is the specification of the shared RP_ALL engine
in `web/apps/api/src/modules/reports/rpAll/` (N234) and of the Sales adapter built on it.

Written 9 November 2026 against `origin/main` `f6645ce6`. Line numbers are `RP_ALL.cs` unless another file is named.

## Counts

| Item | Count |
|---|---|
| Shared selectors on the form (§2) | 13 (plus the Select Book grid and 2 Yes/No prompts) |
| Buttons on the Sales panel (§3) | 15; 13 visible in Lite India (2 only for UAE or two registration numbers) |
| Templates the 13 Lite buttons open | 16 named (+ the PRINT_MAST-chosen bill files) |
| Templates inventoried column by column and implemented in phase one (§4) | 9: SaleReport, SaleRtnReport, SalesSumm, SalesRtnSumm, SalesItem, SalesRtnItem, SalesGroupWise, EmpSaleReport, SalesWithOrder |
| Columns in those 9 templates | 133 |
| Totals in those 9 templates | 61 (grand and group bands use the same column set) |
| Group levels in those 9 templates | 11 printed group bands (+ 9 Crystal groups that only order rows) |
| Buttons not served in phase one (§5) | 7 (Sales Bill, Cash/Bank Bill, Wh Sales, Wh Summ, Emp WhSales, Counter Sales, Labour Work) |
| Ambiguities and deliberate differences reported (§6) | 9 |

## 1. Dispatch

| Fact | Source |
|---|---|
| The menu caption "Sales Report" opens `RP_ALL` with that caption as the rights form | `MDI_FORM.cs:8901-8910`; `RP_ALL.cs:6656-6659` (`CurRpt = MsUserRightForm`, `USER_SET` read by `SUB_MENU`) |
| `CurRpt = "Sales Report"` shows `PanelSale`, the Employ label and box, and the Select Book box, then loads the book grid (`BookMast`) | `:6676-6681`, `:6698`, `BookMast` `:11405-11458` |
| UAE company: Item Bill and B2B Bill visible | `:6682-6686` |
| Registration `VK289NEPH`: the same two buttons, captioned Memb Comm / ShrHold Com | `:6687-6693` |
| Registration `DM019NEDM`: State label and box visible | `:6694-6697` |
| Rights read: `FRM_EDIT`, `FRM_DELETE`, `FRM_PRINT` of the `USER_SET` row | `:6772-6778` |
| Esc closes the form from anywhere (KeyPreview); KeyPress upper-cases and swallows `'` | `:7257-7265`, `:7242-7255` |

## 2. Shared selectors

Tab order from `InitializeComponent`; defaults from `RP_ALL_Load`.

| # | Control | Caption | Tab | Default for Sales Report | Behaviour | Source |
|---|---|---|---|---|---|---|
| 1 | `mFromDt` | From / To Date | 0 | system date (`MsSysDate`) | Enter → `SetDate`; refused while `RongDate` | `:5618-5622`, `:7195-7198`, `:7510-7524` |
| 2 | `mToDt` | (same label) | 1 | system date | as above | `:5610-5614`, `:7202`, `:7526-7540` |
| 3 | `tLcCode` | lc Code | 2 | session location; **disabled** unless the session location is `00` | Enter: `LOCT_MAST` lookup, help on miss | `:4914-4918`, `:6660-6671`, `:7680-7717` |
| 4 | `tBookCode` | Book | 3 | blank | Enter: `BOOK_DATA` of the session location, help on miss | `:4778-4782`, `:7288-7330` |
| 5 | `chkBookSelect` + `DGV_ITM` | Select Book | 1208 | unchecked | Ticking shows the grid; **Ok** builds `ScelectBook = 'B1','B2'`; nothing ticked → "Book Selection Not Done..."; success → "Book Selection is Ok..."; **Cancel** clears it | `:6532-6539`, `:11355-11403`, `:11460-11464` |
| 6 | `tItCode` | Pr Code | 4 | blank | a **product** code: Enter: `PRODUCT_MAST`, help on miss; empty Enter jumps to City | `:4874-4878`, `:4894`, `:7477-7507` |
| 7 | `tGrCode` | Gr Code | 5 | blank | Enter: `GROUP_MAST`, help on miss | `:5626-5646`, `:9265-9292` |
| 8 | `tAcCode` | Party Code | 6 | blank | Enter: `AC_MAST`, help on miss (all branches, by location, or `<100` + own location) | `:4812-4832`, `:7382-7428` |
| 9 | `cboCity` | City | 8 | blank | items = distinct `AC_MAST.AC_CITY` of the company | `:4839-4851`, `:7087-7102` |
| 10 | `cboArea` | Area | 9 | blank | distinct `AC_MAST.AC_AREA` | `:4858-4870`, `:7121-7136` |
| 11 | `cboItemTyp` | Item Type | 10 | blank | "", Gold, Silver, Diamond, Real Stone, Emitation, Other, Platinum; formulas use the **first letter** | `:4899-4910`, `:7165-7173`, `:7663` |
| 12 | `cboEmploy` | Employ | 1191 | blank (first item) | items `EMP_CODE-EMP_NAME`; formulas use `Mid(text, 1, 3)` | `:6396-6409`, `:7138-7156`, `:7647` |
| 13 | `cboState` | State | 1209 | blank | hidden except `DM019NEDM` (never in Lite) | `:6545-6558`, `:7104-7119`, `:6694-6697` |
| — | `DC_Main.MsDataType` | (no control) | — | session value A/B/C | A or B adds `BOOK_DATA.DATA_TYPE = 'A'/'B'` | `:7653-7660`; set by Ctrl+A/B/C in `MDI_FORM.cs:12720-12760` |

## 3. Buttons and their record-selection formulas

Every formula starts `{X.CO_CODE} = <company> AND {X.CO_YEAR} = <year>` and, where shown, `{X.VCH_DATE} >= From AND
<= To` (inclusive). "Filters" lists the predicates the handler appends, each only when its control is non-blank.
Key: L = location, B = book, SB = Select Book IN list, P = party, Ci/Ar/St = AC_MAST city/area/state, E = employee
(`Mid(text,1,3)`), Pr/Gr/IT = ITEM_MAST product/group/item type, DT = BOOK_DATA.DATA_TYPE.

| Button (tab) | Handler | Prompt | Template(s) | Base predicate | Filters (lines) | Title |
|---|---|---|---|---|---|---|
| Sales Report (0) | `:7572-7678` | "Sales Return (Creditnote) Report", Yes/No default **No** (style 260), `:7584` | Yes: `SaleRtnReport` `:7588,:7593`; No: `SaleReport` `:7603,:7608` | Yes: `SL_DATA.RTN_NET_AMT <> 0` `:7597`; No: `SL_DATA.NET_AMT <> 0` `:7618` (UAE: `NET_AMT + TOT_TAX_FREE_AMT`, `:7614`) | L `:7623`, B `:7627`, P `:7631`, Ci `:7635`, Ar `:7639`, St `:7643`, E `:7647`, SB `:7651`, DT `:7655-7659`, IT `:7663` | "Sales Report From d To d" `:7610` / "Sales Return Report …" `:7595` |
| Sales Reg (1) | `:7722-7824` | same, `:7734` | `SalesRtnSumm` `:7738` / `SalesSumm` `:7753` | `RTN_NET_AMT <> 0` `:7747` / `NET_AMT <> 0` `:7768` | L `:7773`, B `:7777`, P `:7781`, Ci `:7785`, Ar `:7789`, St `:7793`, E `:7797`, SB `:7801`, DT `:7805-7809` (no item filters) | "Sales Register Report …" `:7760` / "Sales Return Register Report …" `:7745` |
| Item Wise (2) | `:7826-7940` | same, `:7838` | `SalesRtnItem` `:7842` / `SalesItem` `:7857` | `RTN_NET_AMT <> 0` `:7851` / `NET_AMT <> 0` `:7872` | L `:7877`, B `:7881`, P `:7885`, Pr `:7889`, Ci `:7893`, Ar `:7897`, St `:7901`, IT `:7905`, Gr `:7909`, E `:7913`, SB `:7917`, DT `:7921-7925` | "Item Wise Sales Report …" `:7864` / "Item Wise Sales Return Report …" `:7849` |
| Sales Bill (3) | `:9005-9133` | same, style 4 (default Yes), `:9053` | Yes: `SalesRtnA4Print` `:9062` (stages `RATE_CUT_ISU_REC` from `SL_DETL`/`SL_DETL_RTN` of book `SALES RETURNE`, `:9055-9059`); No: the `PRINT_MAST` row `PRINT_TYPE='SALES'`, `BOOK_TYPE='T'`, `PRINT_SET_A='Y'` `:9018-9052,:9071` | dates only `:9077` | L `:9080`, B `:9084`, P `:9088`, Ci `:9092`, Ar `:9096`, St `:9100`, SB `:9104`, DT `:9108-9112` | copy text "DUPLICATE FOR SUPPLIER" / "ACCOUNT COPY" `:9117-9124` |
| Employ Sales (5) | `:9135-9206` | none | `EmpSaleReport` `:9144,:9192` | dates only, **no amount predicate** `:9146` | L `:9149`, B `:9153`, P `:9157`, Ci `:9161`, Ar `:9165`, St `:9169`, E `:9173`, SB `:9177`, DT `:9181-9185` | "Salesman Wise Report …" `:9190` |
| Cash/Bank Bill (6) | `:9797-9895` | refuses without a book: "Please Select Book Code First And Try..." `:9810` | `CashBankBillAc` when `BOOK_TYPE='T'`, else `CashBankBill` `:9815-9839` | `CASH_DATA` dates `:9840` | L `:9843`, B `:9847`, P `:9851`, Ci `:9855`, Ar `:9859`, St `:9863`, SB `:9867`, DT `:9871-9875` | copy text `:9879-9888` |
| Wh Sales (4) | `:8913-9003` | none | `WhSalesIsuRec` `:8922,:8989` | **writes** `RATE_CUT_ISU_REC` (delete + insert from `RATE_CUT_ISU`/`RATE_CUT_REC` of the *session* location and dates) `:8924-8930`; formula company + year only `:8931` | L `:8934`, Pr `:8938`, B `:8942`, P `:8946`, Ci `:8950`, Ar `:8954`, St `:8958`, IT `:8962`, Gr `:8966`, E `:8970`, SB `:8974`, DT `:8978-8982` | "Wh Sales IsuRec Report …" `:8987` |
| Wh Summ (7) | `:10996-11202` | "Wh Sales Bill Print" `:11009` | Yes: `PRINT_MAST` `PRINT_TYPE='WH SALES'` `:11020-11059` on `RATE_CUT_DATA` `:11061-11096`; No: `WhSalesSumm` `:11126,:11186` on the staging table `:11128-11179` | staging as Wh Sales `:11000-11006` | (as listed at the cited lines) | "Wh Sales Summ Report …" `:11184` |
| Emp WhSales (8) | `:11265-11353` | none | `WhSalesEmp` `:11274,:11339` | staging from `RATE_CUT_ISU` only `:11276-11280` | L…DT `:11284-11332` | "Emp Wise Wh Sales Report …" `:11337` |
| Counter Sales (9) | `:11658-11733` | none | `CounterSale` `:11667,:11719` | `MAIN_STOCK.TR_TYPE = 'S'` + dates `:11669` | L `:11672`, B `:11676`, P `:11680`, Ci `:11684`, Ar `:11688`, IT `:11692`, Pr `:11696`, Gr `:11700`, SB `:11704`, `MAIN_STOCK.DATA_TYPE` `:11708-11712` | "Counter Wise Sales Report …" `:11717` |
| Sale With Order (10) | `:11735-11816` | "Only Item Sales With Order" Yes/No `:11749` → `SL_DETL.ORD_NO <> ''` `:11751` | `SalesWithOrder` `:11746,:11802` | on **SL_DETL**: company, year, `SL_DETL.VCH_DATE` `:11748`; no amount predicate | L `:11755`, B `:11759`, P `:11763`, Ci `:11767`, Ar `:11771`, IT `:11775`, Pr `:11779`, Gr `:11783`, SB `:11787`, DT `:11791-11795` | "Sales With Order Report …" `:11800` |
| Group Sales (11) | `:11928-12018` | none | `SalesGroupWise` `:11937,:12004` | `NET_AMT <> 0` `:11945` (UAE `:11941`) | L `:11949`, B `:11953`, P `:11957`, Pr `:11961`, Ci `:11965`, Ar `:11969`, St `:11973`, IT `:11977`, Gr `:11981`, E `:11985`, SB `:11989`, DT `:11993-11997` | "Item Group Sales Report …" `:12002` |
| Labour Work (12) | `:12020-12110` | none | `LbrWorkRpt` `:12029,:12096` | staging from `LBR_ISU_DETL`/`LBR_REC_DETL` `:12031-12037`; formula company + year `:12038` | L…DT `:12041-12089` | "Labour Work Report …" `:12094` |
| Item Bill (13) | `:12204-12385` | — | `MembCommRpt` (VK289NEPH) or a PRINT_MAST file | — | — | UAE / registration only: **not Lite** |
| B2B Bill (14) | `:12386-12535` | — | `MembCommRpt` or `B2BSaleBillA4Tax` | — | — | UAE / registration only: **not Lite** |

`MsCrystalRptType = "N"` routes every button through `Module_Save.ShowReportPreview` with the same formula and
template name (`:7665-7671` and the matching lines of each handler); `"O"` uses the Crystal OCX. Both produce the same
report.

## 4. Templates implemented in phase one

Bands are listed in print order. "Total" = the column is summed in the band. Captions are the template's text
objects verbatim; a caption marked *(field)* has no text object and is named after its field.

### 4.1 SaleReport / SaleRtnReport (Sales Report)

- Tables: `SL_DATA` ⟕ `AC_MAST` (CO, AC) ⟕ `BOOK_DATA` (CO, LC, BOOK) ⟕ `SL_DETL` (CO, LC, YEAR, BOOK, VCH) ⟕
  `SL_IDTL` (+ SR_NO) ⟕ `ITEM_MAST` (line item) ⟕ `ITEM_MAST_IDTL` (sub item). The return template replaces the
  lines with `SL_DETL_RTN` and the sub-lines with `BAR_IDTL`.
- Groups: `CO_BOOK` (header: book code + `BOOK_NAME`, footer suppressed) → `@VchGroup = CO_BOOK + VCH_NO` → `@SrNo`.
- Voucher band (Section4): Date *(field)* `VCH_DATE`, Vch No *(field)*, Party *(field)* `SL_DATA.AC_NAME`, **Net Amt**
  `@ItmAmt = NET_AMT` (return: `RTN_NET_AMT`), **Disc** `@DiscAmt = DISC_AMT` (return: `0`), **Tax** `TAX_AMT`,
  **Bill Tot** `@VchAmt = TOT_AMT` (return: `RTN_TOT_AMT`). Section14 "Rof Amt" `ROF_AMT`, suppressed when 0 (sale only).
- Line band (Section5): Tag No, Item Code & Name (`IT_NAME`), Pcs, GrossWt, Net Wt, Rate, L.Rate, LbrAmt, Net Amt.
- Sub-line band (Section6): item name, pcs, gross wt, rate, net amount; **suppressed when `OTH_AMT = 0`**.
- Report footer (Section10): `#TotPcs`, `#GrossWt`, `#NetWt`, `#RTotal2` (Net Amt), `#RTotal3` (Disc, sale only),
  `#RTotal0` (LbrAmt), `#TotTaxAmt`, `#TotBillAmt` — running totals "evaluated on change of group".
- Web: 22 / 21 columns, 8 / 7 totals (`salesLayouts.ts` `saleReportLayout`).

### 4.2 SalesSumm / SalesRtnSumm (Sales Reg)

- SalesSumm tables as SaleReport (BOOK_DATA linked by CO + BOOK only). Groups `VCH_DATE` (header suppressed, footer
  "DATE TOTAL :") → `@VchNo = VCH_NO` → `@SrNo`; record sort `CO_BOOK`.
- Voucher band: BIL_NO, BIL_DATE, AC NAME (`AC_MAST.AC_NAME`, live master), City, Mobile, Pan No, GST No, Net AMT,
  CGST, SGST, TOT_AMT, CASH (`CASH_AMT`), Bank (`@Crd_amt = CHQ_AMT`), Les:Adv (`ADV_AMT`), Old Gold, Old Sl, Kasar,
  Os Amt (`BILL_OS`). Line band: Product Name (`ITEM_MAST.IT_NAME`), Net Wt.
- DATE TOTAL and GRAND TOTAL: Net Wt and every amount column (12 totals) as plain `Sum()`.
- SalesRtnSumm: `SL_DATA` ⟕ `AC_MAST` ⟕ `BOOK_DATA` only; detail = one row per bill: BK, BIL_NO, BIL_DATE, AC NAME,
  TOT_AMT (`RTN_TOT_AMT`), CASH (`RTN_CASH_AMT`), CARD (`RTN_CARD_AMT`), Bank (`RTN_CHQ_AMT`), Kasar, Os Amt; DATE
  TOTAL and GRAND TOTAL of the six amounts.

### 4.3 SalesItem / SalesRtnItem / SalesGroupWise (Item Wise, Group Sales)

- Tables: `SL_DATA` ⟕ `SL_DETL` (return: `SL_DETL_RTN`) ⟕ `ITEM_MAST` ⟕ `PRODUCT_MAST` (Group: `GROUP_MAST`) ⟕
  `BOOK_DATA`. **No `AC_MAST`** (see §6.4).
- Groups: `ITEM_MAST.IT_TYPE` (label `@ItemType`: G → GOLD, S → SILVER, else OTHER) → `PR_CODE` (label `PR_NAME`;
  Group Sales: `GR_CODE`, label `GR_NAME`); both print their sums in the **group header**. Record sort `VCH_DATE`,
  `AC_CODE`.
- Line band: Bill Date, Vch No, Bill No, Party Name (`SL_DATA.AC_NAME`), Net Weight, Rate, Item Amt, Labour, Other,
  Net Amt, MRP, Total Amt. `@ItmTotAmt` = `SL_DETL.TOT_AMT` (Item), `SL_DETL_RTN.NET_AMT` (Return),
  `NET_AMT + IT_TAX_AMT - IT_DISC_AMT` (Group). Group Sales suppresses the line band (Section8): bands only.
- "Total:" footer: the seven sums.

### 4.4 EmpSaleReport (Employ Sales)

- Tables as SaleReport plus `EMP_MAST` (CO, EMP_CODE). Groups `EMP_CODE` (header: code + `EMP_NAME`) → `VCH_DATE`
  (suppressed) → `@VchGroup` → `@SrNo`.
- Voucher band: Book (`BOOK_SNAME`), Vch Date, Vch No, Name (`SL_DATA.AC_NAME`), Bill Amount (`TOT_AMT`), Kasar Amt,
  Net Amount (`@VchAmt = TOT_AMT - KASAR_AMT`). Line band suppressed. Detail (Section6) prints `SL_IDTL` pcs, gross
  wt, rate, net amount without captions, suppressed when `SL_DETL.IT_CODE = ''`.
- Employee footer "Total :": `#RTotal3` (TOT_AMT), `#RTotal2` (KASAR_AMT), `#RTotal1` (@VchAmt), reset per group.
  Report footer suppressed: **no grand total**.

### 4.5 SalesWithOrder (Sale With Order)

- Tables: `SL_DETL` ⟕ `ITEM_MAST` ⟕ `TABLE_MAST` ⟕ `BOOK_DATA` ⟕ `AC_MAST` (no `SL_DATA`). Group `VCH_DATE`
  (header and footer suppressed); record sort `IT_CODE`.
- Detail: VchType, Date, VchNo, Party Name (`AC_MAST.AC_NAME`), Ord No, Ord Year (`ORD_YRCD`), Book (`ORD_DBCD`),
  Tag No, Item Name, Pcs, Gross Wt, Net Wt, Net amt. "GRAND TOTAL :": Pcs, Gross Wt, Net Wt, Net amt.

## 5. Not served in phase one

| Button | Why it is separate | Template in repo? |
|---|---|---|
| Sales Bill | Prints the bill template chosen in PRINT_MAST per voucher (a document print, not a register); the return branch stages rows | the chosen files vary; `SalesRtnA4Print` is **missing** from `extraction_output/rpt_xml/` and the repository |
| Cash/Bank Bill | `CASH_DATA` receipt prints; needs a book | `CashBankBill.xml`, `CashBankBillAc.xml` present |
| Wh Sales, Wh Summ, Emp WhSales | Read `RATE_CUT_*` through a staging table the desktop **writes** during a report (delete + insert, scoped to the session location, not `tLcCode`); the web must derive the same rows read-only | `WhSalesIsuRec`, `WhSalesSumm`, `WhSalesEmp` present |
| Counter Sales | `MAIN_STOCK` (`TR_TYPE='S'`), its own DATA_TYPE column; groups sign → counter → date → item type | `CounterSale.xml` present |
| Labour Work | `LBR_ISU_DETL`/`LBR_REC_DETL` through the same staging table | `LbrWorkRpt.xml` present |

They become further Sales adapter variants on the same engine; none needs an engine change.

## 6. Ambiguities and deliberate differences (reported, not guessed)

1. **Running-total evaluation group is not in the extracted XML.** SaleReport, SaleRtnReport and EmpSaleReport total
   with running totals "evaluated on change of group", but RptToXml does not record *which* group. Totals are only
   meaningful if header fields evaluate once per voucher group and line fields once per `@SrNo` group; the engine
   counts each value once per key of its own level. Confirming needs the `.rpt` opened in Crystal on Windows
   (Track O). Source: `SaleReport.xml` `RunningTotalFieldDefinitions`.
2. **SalesSumm double-counts multi-line bills (deliberate difference).** Its DATE TOTAL and GRAND TOTAL are plain
   `Sum({SL_DATA.NET_AMT})` etc. over a record set joined to `SL_DETL` and `SL_IDTL`, so a bill with two lines is
   added twice and `ITM_NWT` once per sub-line. The web counts each bill once (`engine.ts` header comment;
   `rpAllEngine.test.ts` proves the literal sum would differ). Owner decision welcome; not ported as a defect.
3. **Employee filter truncates the code (deliberate difference).** `Mid(cboEmploy.Text, 1, 3)` compares the first
   three characters of `CODE-NAME` (`:7647` and every handler), so codes shorter or longer than three characters
   never match. The web compares the whole code.
4. **Party-master filters on templates without `AC_MAST`.** Item Wise and Group Sales append
   `{AC_MAST.AC_CITY}`/`AC_AREA`/`AC_STATE` (`:7893-7901`, `:11965-11973`) but `SalesItem`, `SalesRtnItem` and
   `SalesGroupWise` contain no `AC_MAST` table, so Crystal cannot resolve the field. What the desktop shows then
   (error or empty) is unknown without a Windows run; the web refuses the combination with `400
   filter-not-in-template` rather than invent a result.
5. **`MsDataType` (BOOK_DATA.DATA_TYPE) is not ported.** It is a session value switched by Ctrl+A/B/C
   (`MDI_FORM.cs:12720-12760`) that hides one set of books from the other; the web session has no such value.
   Needs an owner decision before it is ported.
6. **Unticking Select Book keeps the list.** `chkBookSelect_Click` only hides the grid (`:11355-11364`); only Cancel
   clears `ScelectBook` (`:11460-11464`). The web has no hidden state: an omitted `books` parameter is no filter.
7. **Location groups.** The Crystal voucher group `@VchGroup = CO_BOOK + VCH_NO` ignores `LC_CODE`, so for a
   head-office "all locations" run two locations' identical book/number would merge. The web keys a voucher by
   location, book and number.
8. **Employ Sales detail band on lines without sub-lines.** Section6 prints `SL_IDTL` values on every line record
   where `IT_CODE <> ''`; for a line with no `SL_IDTL` row Crystal prints a row of nulls whose rendering depends on the
   template's null option (not extracted). The web prints sub-line rows only where a sub-line exists.
9. **Web Sales Return writes the wrong columns (G246).** The desktop return/exchange form stores the sold part in
   `SL_DATA.NET_AMT` and the returned part in `RTN_NET_AMT`/`RTN_TOT_AMT` (`TR_SALE_RTN.cs:12623`, `:12707`,
   `:12789`, values from `:16385-16386`). The web Sales Return (`modules/sales/salesReturn.ts` header) stores the
   return value in `NET_AMT`/`TOT_AMT` and leaves `RTN_NET_AMT` 0, so by the desktop rule a web return lists as a
   sale and the return variant is empty. A writer defect, recorded as G246; the report is not bent around it.

## 7. Web design (phase one)

| Piece | File | Notes |
|---|---|---|
| Types | `web/apps/api/src/modules/reports/rpAll/types.ts` | layout = template, groups, sort, keys per level, printed levels, band suppression |
| Pure engine | `rpAll/engine.ts` | sort (Crystal ascending, nulls first), group bands, count-once totals, rows, `dd/MM/yyyy`, title |
| Selectors | `rpAll/filters.ts` | the 13 selectors, fail-closed; location lock; From after To allowed |
| Sales modes | `rpAll/salesLayouts.ts` | 6 modes (report, register, item, group, employee, with-order), 3 return variants, 9 layouts |
| SQL | `rpAll/salesQuery.ts` | constant fragments chosen by mode; every value a `$n` parameter; read inside `withTxBudget(…, 'read')` (forced RLS) |
| Entry and shaping | `rpAll/index.ts` | `salesReport(prisma, session, query)`; `shapeSalesResult` is pure |
| Exports | `rpAll/exportRows.ts` | CSV/Excel of every row, band and total, from the same result as the screen |
| Routes | `web/apps/api/src/routes/rpAllReport.ts` | `GET /reports/sales-report`, `/export.csv`, `/export.xlsx`; rights = the Sales Report caption |

A sibling report (Purchase Rpt, Approval Rpt, Order Report) adds its mode table and query beside `salesLayouts.ts` /
`salesQuery.ts` and reuses `engine.ts`, `filters.ts`, `exportRows.ts` and the route pattern unchanged.

## 8. Browser case plan (phase two runs it)

Frozen in `web/apps/web/test/features/modules/salesReport.mjs`, every case blocked until the dedicated screen
exists. T08-T10 and T12-T14 are not applicable (a report writes nothing; the addendum maps them to T02, T03, T05 and
T16).

| Case | Group | What it proves |
|---|---|---|
| entry.defaults-and-thirteen-buttons | T01 | defaults (From = To = today), location lock, Employ / Select Book visible, State hidden, 13 buttons, API refusal without the right |
| filters.one-at-a-time | T02 | each selector's exact voucher ids per button; ignored selectors listed |
| filters.combined-and-year-boundary | T02 | AND of selectors; inclusive From/To; two sale books |
| formula.register-report-totals | T03 | SaleReport and SalesSumm totals = hand sums, each bill once |
| formula.item-group-employee-order | T03 | header subtotals, employee "Total :", order grand total |
| lookup.party-book-product-group | T04 | Enter → help, pick, Esc, stale response |
| grouping.templates-and-zoom | T05 | bands per template; zoom to the voucher and back |
| invalid.dates-and-empty | T06 | bad date refused; From after To → empty, no crash |
| source.create-edit-delete-return | T07 | create, edit, delete through the Sales screen; return only under the prompt (needs G246) |
| scope.tenant-company-location-year-book-rights | T11 | sentinels never appear; List and Print rights refused by the API |
| history.live-master-and-snapshot | T15 | SaleReport keeps `SL_DATA.AC_NAME`; SalesSumm shows the live `AC_MAST.AC_NAME` |
| output.grid-pdf-xlsx-csv-match | T16 | grid = CSV = Excel = print over more rows than a page; `SalesRtnA4Print` missing (blocked) |
| keyboard.selector-run-flow | T17 | keyboard-only run, Esc closes |
| journey.create-edit-delete-return-reconcile | T18 | the prompt-01 journey reconciled to hand totals and the ledger |
