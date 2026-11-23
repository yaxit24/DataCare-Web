# WP-26 study: Sales Invoice residuals (TR_SALE)

Scope of this study: lossless reopen, the tender and source branches, G83, G82, the Crystal print variants and the
blocked cases in `salesInvoice.mjs`. Percentage labour and line precision (PR #241) are not re-studied. Web paths are
relative to `web/apps/`. Desktop quotes are copied from `unified/src/csharp/DataCareNext/`. Status of this study: PARTIAL
(see Open questions): the third blocked case was not found, and the keyboard flow of the old-metal and tender grids
is listed but not walked line by line.

## Scope

- Menu: Sales Invoice, desktop form `TR_SALE` (`TR_SALE.cs`, 21,586 lines; the index says 21,587 with the trailing line).
- Dispatch: `MDI_FORM.cs` creates the form at lines 7933, 8222 and 14053 (`new TR_SALE()`); the web page is
  `web/app/(app)/txn/sales/page.tsx`. The mode is chosen by `DC_Main.MCo_Book` (book "099" is the quotation print,
  see Print).
- Lite edition: the form checks `MsSoftType` for the "E" (Enterprise) edition only. Points, the old-data snapshot and
  the stone-tray (`SL_IDTL`) branch are Enterprise-only:
  TR_SALE.cs:14229 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}
  TR_SALE.cs:14786 {{SELECT A.*,B.MIN_POINT,B.POINT_AMT FROM POINT_DATA AS A}}
  So in Lite, `POINT_DATA` and the points panel are out of scope; the tender grids (UPI, credit note) and the
  old-metal grid are not edition-gated in the code read here.
- Out of scope: percentage labour, line precision (PR #241), customer-specific registration branches
  (`SSRegSrNo` equal to "KJ001NEKJ", "VS287NEBU", "VK050NEVK", "HM249NEHP": per-installation code, see Weaknesses).

## Screen

Only the controls that matter to these items. Names and captions are from the index (`.orch/index/TR_SALE.md`).

| Control | Caption / role | Notes |
|---|---|---|
| `MSG` | item grid | 108+ columns; columns 57, 62, 75 hold old serial, item name, remark (reopen) |
| `MSG_OLD` | old-metal (exchange) grid | col 1 code, 2 desc, 3 pcs, 4 gross, 5 other, 6 net, 7 touch, 8 fine, 9 Con%, 10 Con wt, 11 rate, 12 rate type, 13 amount, 14 type, 17 PR_COST |
| `MSG_ORD` | order-advance grid | col 1 order no, 2 amount, 3 LC, 4 year, 5 book, 6 account, 7 hidden voucher no |
| `MSG_CRNT` | credit-note grid | same column layout as `MSG_ORD` |
| `MSG_UPI` | UPI grid | col 1 account, 2 name, 3 type, 4 UPI id, 5 amount |
| `MSG2_TOTAL` | totals panel | rows: 2 tax, 3 TCS, 4 TDS/round, 5 total, 6 cheque, 7 card, 8 advance/credit note, 9 old gold, 10 old silver, 11 scheme, 12 cash/UPI, 13 cash paid, 14 kasar, 15 bill outstanding |
| `chkRateUnFix`, `chkWhoutcommBill`, `chkBillOrnaIsu` | header flags | reopen sets them from `RATE_UNFIX`, `WHOUT_COMM_BILL`, `ORNA_ISU` |
| `tAcMembCode` | "Memb Ac" | member-commission account (TR_SALE.cs:6220 {{Label32.Text = "Memb Ac";}}) |
| `cboPrintfile`, `btnTagSet` ("Set"), `tNewPrint` | print file choice | per-company print list from `PRINT_MAST` |
| `btnQuot` ("Q"), `btnIsuNo` ("A"), `tTrfrNo`/`btnTrfr` ("Transfer"), `btnOlocar` ("O Locar") | source and transfer buttons | quotation import, approval import, voucher transfer, token check |

Default value, tab order and enabled/visible rules were not extracted for every control (see Open questions).

## Keyboard

- Esc (`TR_SALE_KeyDown`): TR_SALE.cs:16397 {{if ((int)e.KeyCode == 27)}}. It steps back one level: item cell editor, then
  stone editor, then totals editor (focus goes to `tEmpCode`), and only when `OldValTot == NewValTot` it closes the form.
- F1 (key code 112) in the UPI grid opens the account help: TR_SALE.cs:6899 {{if ((int)keyCode == 112)}}.
- Each grid has its own `KeyDown` handler (`TEXT_OLD_KeyDown` 7507-7720, `TEXT_ORD_KeyDown` 7229-7405,
  `TEXT_UPI_KeyDown` 6872-7112, `TEXT_CRNT_KeyDown` 6492-6696). Delete-row confirmation text is shared:
  TR_SALE.cs:7539 {{This Row Record will Removed permantley ?}}
- `tVchNo_KeyDown` (17068-17129), `BtnFirst`/`BtnLast` (17164-17224) drive reopen: they call `CLEAR_DATA` then `DISPLAY_DATA`.

## Rules

Messages quoted verbatim, spelling included.

| Rule | Message | Source |
|---|---|---|
| Old-metal rate type must be N or F | "Please Slelect Rate type = N - Net Wise Or F - Fine Wise" | TR_SALE.cs:7669 {{Please Slelect Rate type = N - Net Wise Or F - Fine Wise}} (case 12, :7666) |
| Duplicate order in order grid | "Duplicate Order No" | TR_SALE.cs:7326 {{Duplicate Order No}} |
| Order/UPI row needs a saved voucher | "Please Save This Voucher Then Effect...." | TR_SALE.cs:6921 {{Please Save This Voucher Then Effect....}} |
| Approval import | "All Approval Tag In This Voucher Import?" | TR_SALE.cs:20050 {{All Approval Tag In This Voucher Import?}} |
| O Locar needs a saved voucher | "Please First Save Voucher and Reopen Voucher and try..." | TR_SALE.cs:21571 {{Please First Save Voucher and Reopen Voucher and try...}} |
| Edit without right | "You Have No Rights....." | TR_SALE.cs:15072 {{You Have No Rights.....}} |
| Print without right | "You Have No Print Rights....." | TR_SALE.cs:16439 {{You Have No Print Rights.....}} |

Focus after each message is `TEXT_OLD`/`TEXT_ORD` of the same cell (the handler `return`s with the cell editor kept).

## Calculations

Old-metal row (`CommPassTotal_Old`, :7888-8002), in the order the form applies it:

1. Fine: TR_SALE.cs:7905 {{Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000")}}; with no touch the fine is the net weight. Three decimals, format-string (half-up).
2. Conversion weight (col 10) from Con% (col 9): above 100 it is `Math.Round(fine * Con% / 100, 3)`:
   TR_SALE.cs:7921 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 1}}
   The `KJ001NEKJ` branch (:7869, :7933) is a per-installation customisation and is not to be ported.
3. Amount from rate, rate type N: TR_SALE.cs:7959 {{Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 1}} (whole rupees; `Math.Round` is half to even).
4. Rate type N and old-gold code "OG": touch is back-calculated from a typed amount and today's gold rate:
   TR_SALE.cs:7981 {{if ((Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OG", false) == 0) & (ToDayGlRate != 0.0)}} (and "OS" with `ToDaySlRate` right after it).
5. Header totals: gold and silver are separated by the row type (col 14 = "G" or not) and summed from column 13 (amount) and column 6 (net weight):
   TR_SALE.cs:19346 {{mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 13])), "0.00");}}
6. `BILL_TOTAL()` runs at the end of the handler (:8001), so every old-metal edit reprices the whole bill.

Tender: `CASH_AMT` is derived, not typed, when old metal exceeds the cash cell:
TR_SALE.cs:15240 {{if (Conversion.Val(MSG2_TOTAL[9, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]) < Conversion.Val(MSG2_TOTAL[12, 3]))}}

## Lifecycle and write set

### Reopen (`DISPLAY_DATA`, :14226-14855) - what the desktop reads

Header read: TR_SALE.cs:14228 {{SELECT * FROM SL_DATA WHERE CO_CODE}} (whole row), and these columns reach the screen:

| Column(s) | Screen target | Line |
|---|---|---|
| `NET_AMT`, `DISC_*`, `TAX_*`, `TCS_*`, `TDS_*` | totals rows 1-4 | 14240-14275 |
| `OLD_GL_AMT` | `MSG2_TOTAL[9,3]` | TR_SALE.cs:14284 {{RsData.Rows[0]["OLD_GL_AMT"]}} |
| `OLD_GL` (fine weight) | `MSG2_TOTAL[9,2]` | TR_SALE.cs:14305 {{(dataRow = RsData.Rows[0])["OLD_GL"]}} |
| `OLD_SL` (weight) | `MSG2_TOTAL[10,2]` | TR_SALE.cs:14309 {{RsData.Rows[0]["OLD_SL"]}} |
| `MEMB_COM_AC_CODE` | `tAcMembCode` | TR_SALE.cs:14365 {{RsData.Rows[0]["MEMB_COM_AC_CODE"]}} |
| `ISU_NO`, `ISU_YRCD`, `ISU_DBCD` | approval number boxes | TR_SALE.cs:14377 {{RsData.Rows[0]["ISU_NO"]}} |
| `RATE_UNFIX` | `chkRateUnFix` | TR_SALE.cs:14398 {{chkRateUnFix.Checked = true}} |
| `WHOUT_COMM_BILL` | `chkWhoutcommBill` | TR_SALE.cs:14404 {{RsData.Rows[0]["WHOUT_COMM_BILL"]}} |
| `DATA_TRFR`, `RE_TRFR` | `DataTrfr` flag | TR_SALE.cs:14415 {{DataTrfr = "Y"}} |
| `USER_UPDATE`, `USER_DELETE` | per-voucher edit/delete grant | TR_SALE.cs:14417 {{UsUPdate = Conversions}} |

Detail grids read on reopen:
- Old metal: TR_SALE.cs:14703 {{SELECT A.* FROM SL_PR_DETL AS A}} and column 17 from `PR_COST`:
  TR_SALE.cs:14724 {{RsOldDetl.Rows[DC_Main.i]["PR_COST"]}}
- Stones: TR_SALE.cs:14670 {{SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST}}
- Orders: TR_SALE.cs:14735 {{Select * From SL_ORD_ADJ WHERE}}; UPI: TR_SALE.cs:14757 {{FROM UPI_DATA WHERE CO_CODE}}; credit notes: TR_SALE.cs:14812 {{Select * From CRNT_DATA WHERE}}
- Points (Enterprise): TR_SALE.cs:14786 {{SELECT A.*,B.MIN_POINT,B.POINT_AMT FROM POINT_DATA AS A}}

### Save (`BtnSave_Click`, :14885-16298) - what the desktop writes (edit = delete then insert, one transaction `Module_Save.SlTran`)

1. `SL_DATA` header row: includes the columns the web does not carry:
   TR_SALE.cs:15257 {{dataRow3["OLD_GL"] = Conversion.Val(MSG2_TOTAL[9, 2]);}}
   TR_SALE.cs:15258 {{dataRow3["OLD_SL"] = Conversion.Val(MSG2_TOTAL[10, 2]);}}
   TR_SALE.cs:15264 {{dataRow3["MEMB_COM_AC_CODE"] = tAcMembCode.Text;}}
   TR_SALE.cs:15267 {{dataRow3["WHOUT_COMM_BILL"]}}
   TR_SALE.cs:15230 {{dataRow3["CRNT_ADJ_AMT"] = Conversion.Val(MSG2_TOTAL[8, 1]);}}
   TR_SALE.cs:15231 {{dataRow3["OLD_GL_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);}}
2. `SL_PR_DETL`: delete at :15626 then one row per old-metal grid row that has a code and a non-zero net plus amount:
   TR_SALE.cs:15636 {{if ((Conversion.Val(MSG_OLD[DC_Main.i, 6]) + Conversion.Val(MSG_OLD[DC_Main.i, 13]) != 0.0)}}
   TR_SALE.cs:15664 {{dataRow7["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 13]);}}
   TR_SALE.cs:15665 {{dataRow7["PR_COST"] = Conversion.Val(mSG_OLD[DC_Main.i, 17]);}}
   Note `NET_AMT` of the detail row and `OLD_GL_AMT` of the header come from the same grid column 13 (this is G83).
3. `SL_ORD_ADJ`: delete at :15680, rows only when the advance cell is non-zero, one per `MSG_ORD` row:
   TR_SALE.cs:15686 {{if (Conversion.Val(MSG2_TOTAL[8, 3]) != 0.0)}}
   TR_SALE.cs:15715 {{dataRow8["ORD_SIGN"] = "-";}}
   TR_SALE.cs:15716 {{dataRow8["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);}}
4. `UPI_DATA`: TR_SALE.cs:15844 {{DELETE FROM UPI_DATA WHERE}} then one row per grid row:
   TR_SALE.cs:15869 {{dataRow12["UPI_AMT"] = Conversion.Val(MSG_UPI[DC_Main.i, 5]);}}
5. `CRNT_DATA`: TR_SALE.cs:15876 {{Delete FROM CRNT_DATA WHERE}}, rows only when `MSG2_TOTAL[8,1]` is non-zero:
   TR_SALE.cs:15878 {{if (Conversion.Val(MSG2_TOTAL[8, 1]) != 0.0)}}
   TR_SALE.cs:15911 {{dataRow13["CRNT_AMT"] = Conversion.Val(mSG_CRNT[DC_Main.i, 2]);}}
6. `POINT_DATA` (Enterprise only, :15789-15840), `COMM_DATA` (:15926), `BILL_OS_DATA` (:15738), `AC_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`.
7. Source flags: approval tags set back with `UPDATE APR_DETL ... ISU_REC` and `BAR_DETL` (11968-11973, 16105-16114); order detail `SL_ORD_DETL` (16110).

### Delete (`BtnDelete_Click`, :16299-16392)
Deletes `AC_DATA`, `MAIN_STOCK`, `ROJ_MEL_DATA`, `TAX_DATA`, `BILL_OS_DATA`, `POINT_DATA`, `UPI_DATA`, `CRNT_DATA`,
`SL_ORD_ADJ`, `SL_PR_DETL`, `SL_IDTL`, `SL_DETL`, `SL_DATA` (lines in the index table) and writes `DELETE_DATA` (:16320, :16322).
Rights: TR_SALE.cs:16312 {{You Have No Rights.....}}; confirmation TR_SALE.cs:16316 {{Are You Sure To Delete This Voucher now?}}.

## Print

- Print rights: TR_SALE.cs:16439 {{You Have No Print Rights.....}} when `UserPrint` is not "Y".
- Template choice in `BtnPrint_Click` (:16435-16609), in order:
  1. `SSRegSrNo` = "VK050NEVK": TR_SALE.cs:16474 {{DC_Main.RptName = "SalesBillDubai";}} (per-installation; do not port).
  2. HUID box ticked: TR_SALE.cs:16484 {{RtlHuidPrint.RPT}}
  3. Book "099" (quotation): TR_SALE.cs:16489 {{SalesQuotation.RPT}}
  4. Otherwise the file chosen in `cboPrintfile`: TR_SALE.cs:16494 {{cboPrintfile.Text + ".RPT"}}
  5. `SSRegSrNo` = "HM249NEHP" in book "026": TR_SALE.cs:16499 {{SalesBillHzGST.RPT}} (per-installation).
- The file list comes from `PRINT_MAST` by `PRINT_TYPE`/`BOOK_TYPE`, falling back to company "01":
  TR_SALE.cs:13933 {{SELECT * FROM PRINT_MAST WHERE CO_CODE = '}}
- Parameters: `OpAmt = ` and `ClAmt = ` formulas (customer opening and closing balance) are passed for all but the HUID template (`Cr[2]`, `Cr[3]`, :16505-16506). The selection formula is set at :16502 on `SL_DATA`.
- Duplicate, original and triplicate copies: TR_SALE.cs:16537 {{DC_Main.MsPrintType = "InVoiceType";}}
- "Set" button (`btnTagSet`) saves the default file: TR_SALE.cs:20622 {{UPDATE PRINT_MAST SET PRINT_SET_A = 'Y'}}
- `Report/*.rpt` files at the repository root include `SalesBillHzGST.RPT`-style templates; the exact Crystal files present in the
  repository for the names above were not enumerated (Open questions).

## Rights

- Save (edit): TR_SALE.cs:15070 {{if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0)}} -> "You Have No Rights....." (:15072).
- Delete row of the item grid: TR_SALE.cs:11959 {{if ((Operators.CompareString(UserDelete, "Y", false) != 0)}} -> "You Have No Rights....." (:11961).
- Delete voucher: `UsDelete`/`UserDelete` at :16311 -> :16312.
- Print: `UserPrint` -> :16439.
- The rights are loaded from `USER_SET` by sub-menu: TR_SALE.cs:13309 {{Select * From USER_SET WHERE LC_CODE}}.
- A per-voucher grant: reopen turns the Save/Delete buttons green when `USER_UPDATE`/`USER_DELETE` is "Y" (:14418-14424).

## Desktop weaknesses not to port

- Per-installation code keyed by registration serial: TR_SALE.cs:7869 {{DC_Main.SSRegSrNo, "KJ001NEKJ"}}, TR_SALE.cs:13911 {{DC_Main.SSRegSrNo, "VS287NEBU"}}. Not business rules; skip.
- SQL built by joining strings everywhere, for example TR_SALE.cs:14228 {{SELECT * FROM SL_DATA WHERE CO_CODE}} (all parameters concatenated).
- A write outside the save transaction (partial write): TR_SALE.cs:11969 {{DC_Main.ExeQuteDc(DC_Main.RsQry);}} resets approval flags immediately on a grid-row delete, before Save.
- Reopen keeps a copy of the whole header only for Enterprise (`VchOldData`, :14229-14231); the web already compares the full reloaded header (`sales.ts:2658`).

## Web today

| File | What it does now |
|---|---|
| `web/app/(app)/txn/sales/page.tsx` | Sales Invoice screen. Reopen is the `get('/sales/...')` call near line 503; it sets about 40 fields (cash, card, UPI amounts, old-metal rows at :553, order ref at :524). `headerExtra` (line 283) is never filled on reopen; it is sent on save at :733-742. |
| `api/src/modules/sales/sales.ts` | `getSale` (:2334-2547) reads `SL_DATA`, `SL_DETL`, `SL_PR_DETL` and one `SL_ORD_ADJ` row; `editSale` (:2616-2672) deletes `SALE_WRITE_TABLES` (:2176-2194) and rewrites from the request; `writeSaleTx` builds the header at :1431. |
| `api/src/modules/sales/salesOrder.ts` | `adjustOrderIntoSaleTx` (:2029) writes `SL_ORD_ADJ` as `ENTRY_TYPE 'A'`, `ORD_SIGN 'C'`, `PAID_AMT`, `NEW_VCH_NO` (:2060-2066). |
| `packages/core/src/oldGold.ts` | Old-metal valuation kernel (fine, conversion weight, amount from rate, rate from amount). |
| `api/src/modules/shared/taxPolicy.ts` | Resolves a tax code through the parent row `SR_NO = 0` (:96-110). |
| `api/src/modules/ops/seedCompany.ts` | Provisions `TAX_MAST` parent (`SR_NO` 0, :723) and components (1/2/3, :745); no `TAX_AC`. |
| `web/test/features/modules/salesInvoice.mjs` | 33 cases; reopen round trip at :538 and unchanged save at :566; two `blocked` cases (:964, :1381). |

## Gaps

1. **Lossless reopen: header columns that are never loaded, then rewritten from defaults.** Desktop reads `OLD_GL`, `OLD_SL`,
   `MEMB_COM_AC_CODE`, `WHOUT_COMM_BILL`, `RATE_UNFIX`, `TAX_CODE`, `DATA_TRFR` (table above). `getSale` selects none of
   `OLD_GL`, `OLD_SL`, `MEMB_COM_AC_CODE`, `WHOUT_COMM_BILL`, `AC_MEMB_COM_VAL`, `CARD_ADJ`, `ADV_AMT`, `DATA_TRFR`, `USER_UPDATE`,
   `USER_DELETE` (`sales.ts:2347-2360`). It does return `rateUnfix` and `taxCode`, but the page ignores them on reopen:
   `headerExtra` is only declared (`page.tsx:283`) and read at save (`page.tsx:738`, `:742`), so a reopen-and-save writes
   `RATE_UNFIX = 'N'` for a rate-unfixed bill and loses the account overrides. `OLD_GL`/`OLD_SL` are recomputed from the grid
   (`sales.ts:1402-1430`), which is right only when the old-metal rows reload exactly (see 3). Kind: wrong result.
   Fix: load every column the desktop's `DISPLAY_DATA` reads into the view; set `headerExtra` and the flags from it; add a
   case that reopens a desktop-saved voucher (all those columns non-default) and saves unchanged, comparing the full
   `SL_DATA` row except `VCH_TIME`, like `salesInvoice.mjs:566`.
2. **Lossless reopen: stone detail and the source tables.** The desktop reloads `SL_IDTL` (:14670) and the web `getSale`
   never selects it (no `SL_IDTL` in `sales.ts:2347-2430`), yet `editSale` deletes and rewrites `SL_IDTL`
   (`SALE_WRITE_TABLES`, `sales.ts:2178`). A saved invoice with stones loses them on an unchanged save when the page does
   not send them. `UPI_DATA`, `CRNT_DATA`, `POINT_DATA`, `CARD_DATA` are in `SALE_WRITE_TABLES` (`sales.ts:2184-2188`) and so
   deleted on edit, but `sales.ts` has no insert for `UPI_DATA` rows, `CRNT_DATA` or `POINT_DATA`, and `getSale` reads none of
   them. Kind: wrong result (rows disappear). Fix: either read and rewrite them (see 4, 5) or make the edit delete only the
   tables it rewrites; add a write-set test that reopens a desktop-shaped voucher holding rows in each table and
   asserts every table is unchanged.
3. **Lossless reopen: old-metal rows lose `IT_TYPE`, `PR_COST` and the fine weight.** Desktop loads `PR_COST` (:14724) and
   writes it back (:15665); `getSale` selects `IT_TYPE` but not `PR_COST` or `ITM_RATE` rounding (`sales.ts:2381-2385`), and the
   old-gold input type has no `prCost` (`sales.ts:244-260`). Kind: wrong result for installations that use `PR_COST`;
   default 0 elsewhere. Fix: carry `PR_COST` through, leave it as stored when the row is unchanged.
4. **Tender branch: UPI grid.** Desktop writes one `UPI_DATA` row per grid row (:15869) with account, name, type and id;
   the web has one `UPI ₹` box (`page.tsx:971`) writing only `SL_DATA.UPI_AMT`. Kind: missing feature. Fix: a UPI rows editor
   (code, name, type, id, amount), validate that the rows sum to `UPI_AMT`, write `UPI_DATA` in the same transaction, load them on reopen.
5. **Tender branch: credit note (`CRNT_DATA`) and the credit-note adjustment.** Desktop writes `CRNT_ADJ_AMT` (:15230) and
   rows only when it is non-zero (:15878). The web carries `currentAdjustmentAmount` as a number (`sales.ts:228`) but writes no
   `CRNT_DATA` rows and the page has no grid. Kind: missing feature. Fix: add the grid, write the rows, include the amount in the bill outstanding.
6. **Source branch: order advance shape.** The desktop writes `SL_ORD_ADJ` from the `MSG_ORD` grid with `ORD_SIGN '-'`, `ORD_AMT` and no
   `PAID_AMT` (:15715-15716), many rows, written when the advance cell is non-zero (:15686). The web writes one row with
   `ORD_SIGN 'C'`, `PAID_AMT` and `NEW_VCH_NO` (`salesOrder.ts:2060-2066`) and `getSale` reads back only `PAID_AMT`/`NEW_VCH_NO` with
   `LIMIT 1` (`sales.ts:2388-2392`). A desktop-saved bill with advance reopens with `orderRef = null`, and an unchanged save drops the
   rows and recomputes `ADV_AMT` to 0, so `BILL_OS` changes. Kind: wrong result. Fix: read the desktop shape (`ORD_AMT`, `ORD_HD_VCH_NO`, `ORD_LC`,
   `ORD_YRCD`, `ORD_DBCD`, `ORD_AC_CODE`), support several orders, write the desktop columns. Inferred: `ORD_SIGN` value meaning
   differs between `TR_SALE` and the order-cancel form; confirm with the owner before changing the web value used by the order screen.
7. **Source branch: approval import and quotation import.** The web already releases and consumes approval tags
   (`sales.ts:2313`, `:2019`). The desktop's "import all approval tags" prompt (:20050) and quotation import (`BtnQuot_Click`, :21016, only in
   add mode: TR_SALE.cs:21021 {{if (Operators.CompareString(EntryMode, "A", false) != 0)}}) are not on the page; there is no `btnQuot` equivalent in `page.tsx`.
   Kind: missing feature (quotation import). Fix: an "import quotation" action that copies lines, old metal and stones from
   `getSalesQuotation` (`sales.ts:2153`) into a new invoice, as :21145-21147 does for stones.
8. **G83 (old-metal header valuation).** The one-figure rule is done (`sales.ts:1402-1430`, kernel `oldGold.ts`): detail, header
   `OLD_GL_AMT`, ledger and `BILL_OS` use the same value, as the desktop does at :15231 and :15664. Residuals the desktop has and the
   web does not: (a) the rate-type check "Please Slelect Rate type = N - Net Wise Or F - Fine Wise" (:7669) has no web text
   (no match in `web/`), so any rate type is saved; (b) back-calculation of touch from a typed amount for codes "OG"/"OS" (:7981)
   is not in `oldGold.ts` (its header says only the rate from amount is done); (c) `PR_COST` (item 3); (d) the desktop
   separates gold from silver by `IT_TYPE <> 'G'` (:19343 and :19348), the web by `metal === 'G'` (`sales.ts:1415-1420`), so an old row with a type other than G or S is silver
   on the desktop but dropped or gold in the web. Kind: wrong text (a), wrong result (b, d). Fix: add (a)-(d) to `oldGold.ts` with kernel vectors from :7905, :7921, :7959, :7981 and :19346.
9. **G82 (tax codes on web-provisioned companies).** Done and covered: parent `SR_NO = 0`, components 1/2/3, repair migration,
   by-name and by-percentage lookup (`seedCompany.ts:723-745`, `taxPolicy.ts:96-110`, tests `provisioning.db.test.ts`,
   `taxMasterGst.db.test.ts`). The desktop reads the tax name on reopen by parent row:
   TR_SALE.cs:14337 {{SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE}} (with `SR_NO = 0`) and the tax help lists parents:
   TR_SALE.cs:18664 {{Select * From TAX_MAST WHERE CO_CODE}}. Still open: (a) `TAX_AC` unset (G86, deliberately); (b) reopen on the page does not load `taxCode`
   into the screen (item 1), so on a company with two codes at one percentage the save asks the by-percentage lookup, which refuses as ambiguous; (c) the TCS/TDS names (:14257-14275) are not shown.
   Kind: wrong result (b). Fix: send `taxCode` back on save from the loaded view; add a db test that reopens a sale on a company with two codes at one rate and saves unchanged.
10. **Crystal print variants.** The web page has no print-file choice, no `PRINT_MAST` read, and no `SalesQuotation`, `RtlHuidPrint` or
    per-company template (`grep` of `PRINT_MAST` in the sales page and module returns nothing). Kind: missing feature.
    Fix: read `PRINT_MAST` for `PRINT_TYPE`/`BOOK_TYPE`, offer the list and default (`PRINT_SET_A = 'Y'`), pick `RtlHuidPrint` when the HUID box is ticked and
    `SalesQuotation` for book 099, pass `OpAmt`/`ClAmt`, and check the print right before rendering. Skip the `VK050NEVK`/`HM249NEHP` branches (per-installation).
11. **Blocked case `refusal.negative-weight` (`salesInvoice.mjs:964`).** Reason in the file: "Expected behaviour undecided: no desktop source refuses a negative weight, and the web saves it." The grid handler
    `TEXT_ENTRY_KeyDown` (:11896-13172) shows no message for a negative weight (message list has none). Kind: undecided; needs a decision or an original-Windows run before a test can assert it. Fix: record the decision; if "accept", turn the case into `expected: saved`.
12. **Blocked case `config.setting-change` (`salesInvoice.mjs:1381`).** Reason: "Settings-variant fixture pack (SL_AMT_TYPE=F company) not yet in the catalogue." Fix: add a fixture company with `CO_SET.SL_AMT_TYPE = 'F'` to the catalogue, run the preview-then-save with a change between them, and reopen a voucher saved under the old setting (the reopen must show the stored `RATE_WITH`, not the new default).
13. **Blocked case, the third.** The packet says three; only two `blocked` entries exist in `salesInvoice.mjs` (lines 964 and 1381). MISSING: the third blocked case (see Open questions).

## Open questions

- Which is the third blocked case? `grep -n blocked salesInvoice.mjs` finds two; the master plan's WP-26 text was not found in the documents searched (`docs/master-parity-plan-2026-09-29/*.md`). Ask the supervisor or name the case id.
- Tab order, default values and enabled/visible rules of the old-metal, UPI and credit-note controls: the layout file `web/apps/api/form-specs/TR_SALE.initcomp.json` was not read here.
- `ORD_SIGN` meaning (`'-'` in `TR_SALE`, `'C'`/`'D'` in the web order code): the order-cancel form (`TR_SL_ORD_ADJ`) was not compared.
- Which Crystal templates exist as files for the print names above, and what formulas `Cr[2]`/`Cr[3]` map to in each.
- Whether UPI rows must sum to `UPI_AMT` (the desktop `TotAmt`, :6854-6871, was not read).
