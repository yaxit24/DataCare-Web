# WP-36 study: Master → Party, Address, Product, Group, Item, AutoItem, Employee, Tax (residuals)

Written for the next workers (fix, cases, matrix rows). Desktop citations are `FILE:LINE {{quoted text}}`. Web paths are
relative to `web/`. This study covers **only the residual items** the WP-36 row names and the "Remaining" text of the eight
catalog rows; the eight screens themselves were rebuilt under N211-N218 and N236 (lineage sections, see Web today) and
their browser modules are green with **0 blocked cases** (FEATURE-MATRIX.md:36-43: party 18/18, address 17/17, product
17/17, group 18/18, item 18/18, auto-item 18/18, employee 17/17, tax 18/18; `test/features/baseline.json` names none of
them). The matrix status of all eight is `PARTIAL`; the aim of WP-36 is to let each row be proposed `FULL`.

Residuals studied (one gap item each in "Gaps"):
R1 N58 help lists on a web-provisioned company (Group 25/30, Tax 12, Employee 09/10/45, Party AC_GROUP).
R2 Print layouts that are not in the repository (AcMast, PartyMast, GroupMast, EmpMast, TaxMast; ItemMast is dead code).
R3 `TAX_FREE_ITEM` / `EMP_COM_PRC` (and `APP_ITEM`, `AC_MEMB_COM_PRC`) columns missing from the web `ITEM_MAST`.
R4 Employee account help cannot create an account (desktop `MsCreat` round trip through MS_ACCT).
R5 Edition-only boxes and panels recorded as not shown in Lite (Item, Party) and the Product modes of other menus.
R6 Sales screen tax-code resolution by rate (cross-reference to WP-26 / G82; not re-studied here).

## Scope

**Menus and forms.** All eight are Master-tab menus of edition `L` in `docs/handbook/menu-editions.json` (smCode 01-08:
Party, Address, Product, Group, Item, AutoItem, Employee, Tax). `MDI_FORM.cs` opens each form directly on the button
caption:
- MDI_FORM.cs:7600 {{case "Party":}} → MDI_FORM.cs:7602 {{MS_ACCT mS_ACCT = new MS_ACCT();}} (MS_ACCT.cs, 9,651 lines)
- MDI_FORM.cs:7610 {{case "Address":}} → MDI_FORM.cs:7612 {{MS_ADD_MAST mS_ADD_MAST = new MS_ADD_MAST();}} (4,667)
- MDI_FORM.cs:7620 {{case "Product":}} → MDI_FORM.cs:7622 {{MS_PRODUCT mS_PRODUCT2 = new MS_PRODUCT();}} (3,533)
- MDI_FORM.cs:7630 {{case "Group":}} → MDI_FORM.cs:7632 {{MS_GROUP mS_GROUP = new MS_GROUP();}} (2,349)
- MDI_FORM.cs:7640 {{case "AutoItem":}} → MDI_FORM.cs:7642 {{MS_AUTO_ITEM mS_AUTO_ITEM4 = new MS_AUTO_ITEM();}} (3,724)
- MDI_FORM.cs:7650 {{case "Item":}} → MDI_FORM.cs:7652 {{MS_ITEM mS_ITEM = new MS_ITEM();}} (4,028)
- MDI_FORM.cs:7660 {{case "Employee":}} → MDI_FORM.cs:7662 {{MS_EMP mS_EMP = new MS_EMP();}} (1,729)
- MDI_FORM.cs:7670 {{case "Tax":}} → MDI_FORM.cs:7672 {{MS_TAX mS_TAX = new MS_TAX();}} (2,114)

**Shared forms.** MS_PRODUCT is also opened by two non-Lite menus: MDI_FORM.cs:7731 {{case "Counter":}} (MDI_FORM.cs:7733
{{MS_PRODUCT mS_PRODUCT = new MS_PRODUCT();}}) and MDI_FORM.cs:9374 {{case "Scheme Mast":}}. The form branches on the menu
caption it was opened from: MS_PRODUCT.cs:1944 {{CurMast = DC_Main.MsUserRightForm;}}, MS_PRODUCT.cs:2100
{{if (Operators.CompareString(CurMast, "Counter", false) == 0)}}, MS_PRODUCT.cs:2105
{{else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)}}. MS_AUTO_ITEM likewise serves Labour Disc,
Labour Update, Labour and Item Touch (MS_AUTO_ITEM.cs:2001 {{CurMast = DC_Main.MsUserRightForm;}}, MS_AUTO_ITEM.cs:1526
{{if (Operators.CompareString(CurMast, "Item Touch", false) == 0)}}). Those modes belong to other menus and are out of scope;
they matter here only because the `EMP_COM_PRC` grid column lives in one of them (R3).

**Edition checks (`MsSoftType`).** None in MS_ADD_MAST, MS_GROUP, MS_TAX, MS_EMP, MS_PRODUCT (grep count 0). MS_ACCT has
one (MS_ACCT.cs:5971 {{DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E"}}), MS_ITEM
two (MS_ITEM.cs:2753 {{DC_Main.MsSoftType, "P", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "A"}},
MS_ITEM.cs:2757 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}), MS_AUTO_ITEM two (MS_AUTO_ITEM.cs:1584
{{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}} in the Item Touch grid). Lite (`L`) takes none of
these branches, so every box behind them is correctly absent from the web (R5).

**Out of scope.** The full screens, keys, rules and write sets of the eight forms (studied and ported under N211-N218,
N236; documented in each browser module header). Esc with no focused control is WP-09. The Sales screen's tax code
(R6) is WP-26. The Item Excel import (Ctrl+O) belongs to Data Import. Desktop-runtime comparison (Track O) is WP-40+.

## Screen

Only the controls the residuals touch. Captions are in the `.resx` resources (the `.cs` designer calls
`componentResourceManager.ApplyResources`), so the names below are control names; the web pages use the captions the
browser modules record (`Sales Ac`, `Purchase Ac`, `Ac Code`, ...).

| Form | Control | Role in the residual | Visible rule |
|---|---|---|---|
| MS_GROUP | `tSalesAc`, `tSaleAcName` | Sales account; help over `AC_GR = '25'` (R1) | always |
| MS_GROUP | `tPurcAc`, `tPurcAcName` | Purchase account; help over `AC_GR = '30'` (R1) | always |
| MS_TAX | `tTaxAcCode`, `tTaxAcName` | Header tax account; help over `AC_GR = '12'` or `00013` (R1) | always |
| MS_TAX | `tInputTax`, `LblInputTaxName` | Input-tax account, same help (R1) | one registration only (lineage N213 `:1518-1527`) |
| MS_TAX | grid `MSG` col 3 via `TEXT_ENTRY` | Component account; help lists **every** account (R1 control case) | always |
| MS_EMP | `tEmpAc`, `tEmpAcName` | Employee ledger; help over groups 09/10/45 without `00020`; F1 in the help creates (R1, R4) | always |
| MS_ACCT | `tAcGrCode`, `tAcGrName`, `tAcMainGr` | Account group from `AC_GROUP` (R1) | always |
| MS_ACCT | `btnAdminSet`, `chkDefaulter`, `nAcAmtLimit`, `nAcGoldLimit`, `nAcSilverLimit`, `PnlAdminSet` | Admin panel, defaulter, limits (R5) | MS_ACCT.cs:5973 {{((Control)btnAdminSet).Visible = true;}} under the A/E/UAE test at :5971 |
| MS_ACCT | `btnExcel`, `btnOldYearAcImprt` | Hidden imports (R5) | MS_ACCT.cs:6754 {{((Control)btnExcel).Visible = true;}} on Ctrl+O; MS_ACCT.cs:6758 {{((Control)btnOldYearAcImprt).Visible = true;}} on Ctrl+Y |
| MS_ACCT | UAE relabels | `Po-Box`, `TRN No`, `Civil Id` (R5) | MS_ACCT.cs:5982 {{if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}}, MS_ACCT.cs:5984 {{lblBookCo.Text = "Po-Box";}} |
| MS_ITEM | `chktaxfreeItem`, `tItUniCode` | `TAX_FREE_ITEM`, `UNICODE_NAME` (R3, R5) | MS_ITEM.cs:2743 {{if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)}} → MS_ITEM.cs:2747 {{((Control)chktaxfreeItem).Visible = true;}} |
| MS_ITEM | `chkTagOthDetail` | `TAG_IDTL_COL` | P/A/E only, MS_ITEM.cs:2755 {{((Control)chkTagOthDetail).Visible = true;}} |
| MS_ITEM | `chkOthItmPosting` | `OTH_DETL_POSTING` | E only, MS_ITEM.cs:2759 {{((Control)chkOthItmPosting).Visible = true;}} |
| MS_ITEM | `lblAcItem`, `tAcItem` | `AC_ITEM` | MS_ITEM.cs:2761 {{if (Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0)}} → MS_ITEM.cs:2763 {{((Control)lblAcItem).Visible = true;}} |
| MS_ITEM | `chkAppItem` | `APP_ITEM` (R3) | MS_ITEM.cs:2770 {{if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)}} → MS_ITEM.cs:2772 {{((Control)chkAppItem).Visible = true;}} |
| MS_ITEM | (none) | `EMP_COM_PRC` has **no control**; it is a field MS_ITEM.cs:202 {{private double EmpComPrc;}} | — |
| MS_AUTO_ITEM | grid col 16 `EmpCom%` | The only place `EMP_COM_PRC` is typed (R3) | Item Touch mode **and** Enterprise: MS_AUTO_ITEM.cs:1584 {{if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)}}, MS_AUTO_ITEM.cs:1588 {{mSG[0, 16] = "EmpCom%";}} |
| all eight | `BtnPrint` | Print (R2) | always; see Print |

## Keyboard

Keys that drive the residuals only (the full key maps are in the browser module headers).
- Enter on an account box runs the help: MS_GROUP.cs:2200 {{if ((int)e.KeyCode != 13)}} (Sales Ac; Purchase Ac the same
  at :2238), MS_TAX.cs:2031 {{if ((int)e.KeyCode != 13)}}, MS_EMP.cs:1636 {{if ((int)e.KeyCode != 13)}}.
- Inside the help, **F1** (key 112) is "create": MS_HELP.cs:2240 {{else if ((int)e.KeyCode == 112)}} → MS_HELP.cs:2252
  {{DC_Main.MsCreat = true;}} and the help closes. Esc closes the help (MS_HELP.cs:2236-2238).
- Ctrl+O / Ctrl+Y on the Party form reveal the two import buttons (MS_ACCT.cs:6752 {{if (((int)e.KeyCode == 79) & e.Control)}},
  MS_ACCT.cs:6756 {{if (((int)e.KeyCode == 89) & e.Control)}}). Not ported (R5, weakness 4).
- Esc closes each form (MS_ACCT.cs:6760, MS_ADD_MAST.cs:3734, MS_PRODUCT.cs:2539, MS_GROUP.cs:2077 {{KeyCode == 27}},
  MS_ITEM.cs:3147, MS_EMP.cs:1444, MS_TAX.cs:1810; MS_AUTO_ITEM has none at form level in the AutoItem mode, Esc in its
  grid goes to Save). The no-focus case is WP-09.

## Rules

Rules that bear on the residuals, with the exact texts.

**Group account helps (R1).** Enter on Sales Ac first looks the typed code up **inside group 25**: MS_GROUP.cs:2204
{{AND AC_GR = '25' AND AC_CODE = '" + tSalesAc.Text}}. If not found, the help lists group 25 without the sales total
account: MS_GROUP.cs:2208 {{AND AC_CODE <> '00099' AND AC_GR = '25' ORDER BY AC_NAME}} and opens MS_GROUP.cs:2214
{{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}; after a pick the form goes to edit mode, MS_GROUP.cs:2222
{{EntryMode = "E";}}. Purchase Ac is the same over group 30: MS_GROUP.cs:2242 {{AND AC_GR = '30' AND AC_CODE = '" + tPurcAc.Text}},
MS_GROUP.cs:2246 {{AND AC_GR = '30' ORDER BY AC_NAME}}. So a code typed into Sales Ac that sits in another group is **refused**
(the help opens instead). Save needs both: MS_GROUP.cs:1851 {{Please Select Sales and Purchase Account And Try}} (focus
`tSalesAc`), then MS_GROUP.cs:1859 {{Enter Group Detail}}; the edit right first, MS_GROUP.cs:1846 {{You Have No Rights.....}}.
The Trading master uses the same two groups for the same two roles (MS_TRADE.cs:1169 {{AND AC_GR = '25' AND AC_CODE = '" + TEXT_ENTRY.Text}},
MS_TRADE.cs:1213 {{AND AC_GR = '30' AND AC_CODE = '" + TEXT_ENTRY.Text}}), which fixes the meaning of 25 = sales accounts and
30 = purchase accounts in the desktop chart.

**Tax account helps (R1).** The header account takes a typed code **from any group** (MS_TAX.cs:2035
{{AND AC_CODE = '" + tTaxAcCode.Text}}); only the list is filtered: MS_TAX.cs:2039
{{AND (AC_GR = '12' OR  AC_CODE = '00013') ORDER BY AC_NAME}} (two spaces after `OR` in the source), MS_TAX.cs:2045
{{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}. The input-tax box is identical (MS_TAX.cs:2086
{{AND AC_CODE = '" + tInputTax.Text}}, MS_TAX.cs:2090 {{AND (AC_GR = '12' OR  AC_CODE = '00013')}}). The component grid's
account help has **no group filter**: MS_TAX.cs:1252
{{FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE}}. So group 12 =
tax accounts in the desktop chart (the template's `00085`-`00087` GST, CGST, IGST per `desktop-conventions.json`).

**Employee account help (R1, R4).** Typed code from any group: MS_EMP.cs:1640 {{AND AC_CODE = '" + tEmpAc.Text}}; the list:
MS_EMP.cs:1644 {{AND AC_CODE <> '00020' AND AC_GR IN ('09','10','45') ORDER BY AC_GR,AC_NAME}}; MS_EMP.cs:1651
{{((Form)MyProject.Forms.MS_HELP).ShowDialog();}}. After the help: MS_EMP.cs:1656 {{if (DC_Main.MsCreat)}} → MS_EMP.cs:1658
{{DC_Main.MsGrCode = "10";}} → MS_EMP.cs:1659 {{MS_ACCT mS_ACCT = new MS_ACCT();}} (the Party form opens as a child of the MDI
with group 10 preset). The Party form applies the preset at load: MS_ACCT.cs:5961
{{if (Operators.CompareString(DC_Main.MsGrCode, "", false) != 0)}}, MS_ACCT.cs:5963 {{tAcGrCode.Text = DC_Main.MsGrCode;}}.
On Save it hands the new code back and closes: MS_ACCT.cs:7930 {{if (DC_Main.MsCreat)}}, MS_ACCT.cs:7932
{{DC_Main.MsCode = tAcCode.Text;}}, MS_ACCT.cs:7933 {{DC_Main.MsName = tAcName.Text;}}, MS_ACCT.cs:7934 {{((Form)this).Close();}}.
The Employee form picks it up when it is activated again: MS_EMP.cs:1179 {{private void MS_EMP_Activated(object sender, EventArgs e)}},
MS_EMP.cs:1181 {{if (DC_Main.MsCreat)}}, MS_EMP.cs:1184 {{tEmpAc.Text = DC_Main.MsCode;}}, MS_EMP.cs:1185
{{tEmpAcName.Text = DC_Main.MsName;}}. Group 10 is the customer (sundry debtor) group; `00020` is excluded by code.

**Party account group (R1).** The group must exist in `AC_GROUP`: MS_ACCT.cs:7039
{{Select * From AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_GR = '" + tAcGrCode.Text}}; else the help lists
MS_ACCT.cs:7043 {{FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY AC_GR}}. Save refuses a blank group:
MS_ACCT.cs:7712 {{Enter Party Name and Account group Detail}}. `AC_GROUP` is copied, all 35 rows, into every new company by
Year Create: MS_YEAR.cs:1511 {{INSERT INTO AC_GROUP (CO_CODE,AC_GR,AC_GR_NAME,AC_MAIN_GR,AC_SUB_GR,MAIN_USER)}}
(`desktop-conventions.json` `accountGroups.rule`: the same 35 rows in every company, checksum 551216197).

**Item hidden boxes (R3, R5).** A new item clears them: MS_ITEM.cs:2866 {{EmpComPrc = 0.0;}}, MS_ITEM.cs:2871
{{chktaxfreeItem.Checked = false;}}. Reopen reads them: MS_ITEM.cs:2986
{{Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["EMP_COM_PRC"]);}}, MS_ITEM.cs:2989
{{EmpComPrc = Conversions.ToDouble(Strings.Format((object)num9, "0.00"));}}, MS_ITEM.cs:3024
{{dataView2[0]["TAX_FREE_ITEM"], (object)""), (object)"Y", false))}}. Save writes them back whatever the edition:
MS_ITEM.cs:3261 {{dataRow["TAX_FREE_ITEM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chktaxfreeItem.Checked, (object)"Y", (object)"N"));}},
MS_ITEM.cs:3262 {{dataRow["APP_ITEM"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkAppItem.Checked}}, MS_ITEM.cs:3263
{{dataRow["EMP_COM_PRC"] = EmpComPrc;}}. In Lite the three values are therefore always `N`, `N`, `0` for a web-created item and
whatever the migrated row holds for a desktop-created one (the form preserves them).

**AutoItem (R3).** The AutoItem mode's insert sets 22 columns including MS_AUTO_ITEM.cs:2893
{{dataRow2["IT_CODE"] = MSG[DC_Main.i, 1] + tGrCode.Text;}}, MS_AUTO_ITEM.cs:2904 {{dataRow2["EMP_COM_PRC"] = 0;}} and
MS_AUTO_ITEM.cs:2912 {{dataRow2["TAX_FREE_ITEM"] = "N";}}, then MS_AUTO_ITEM.cs:2922 {{Data Are Saved.}}. The column is typed
only in the Item Touch mode: MS_AUTO_ITEM.cs:2461 {{else if (Operators.CompareString(CurMast, "Item Touch", false) == 0)}} lists
MS_AUTO_ITEM.cs:2463 {{APP_ITEM,EMP_COM_PRC,AC_MEMB_COM_PRC FROM ITEM_MAST WHERE CO_CODE}} and its save runs MS_AUTO_ITEM.cs:2835
{{EMP_COM_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 16]))}} under MS_AUTO_ITEM.cs:2829
{{if (Operators.CompareString(CurMast, "Item Touch", false) == 0)}} — a column that exists only when :1584 (Enterprise) built it.

## Calculations

None in the residual scope. `EMP_COM_PRC` is formatted `0.00` on reopen (MS_ITEM.cs:2989, above) and `Val` on the Item
Touch grid (MS_AUTO_ITEM.cs:2835, above); no formula reads it in any Lite form (consumers: `RP_EMP.cs`, `MS_UPDATE.cs`,
`Ac_Image.cs` only). `TAX_FREE_ITEM` is read by the UAE and hallmark sale forms only: TR_SALE_HM.cs:11634
{{C.TAX_FREE_ITEM = 'Y'}} (sum of zero-rated lines into `SL_DATA.ZERO_RATED_AMT`) and TR_SL_PR_ITEM.cs:5071
{{B.TAX_FREE_ITEM FROM BAR_DETL AS A LEFT JOIN ITEM_MAST}}; `TR_SALE.cs` never reads it.

## Lifecycle and write set

Covered by N211-N218/N236 and the browser modules; here only the schema facts for R3.
- Desktop `ITEM_MAST` gains the columns by upgrade script: Ac_Image.cs:8044
  {{ALTER TABLE ITEM_MAST ADD TAX_FREE_ITEM VARCHAR(1)Not NULL DEFAULT 'N'}} and Ac_Image.cs:8258
  {{ALTER TABLE ITEM_MAST ADD AC_MEMB_COM_PRC FLOAT Not NULL Default 0}}. The `EMP_COM_PRC` add in `Ac_Image.cs` is for
  `TOUCH_MAST` (Ac_Image.cs:8228 {{ALTER TABLE TOUCH_MAST ADD EMP_COM_PRC FLOAT Not NULL Default 0}}); the `ITEM_MAST`
  column predates the upgrade script (open question 2) but is written by MS_ITEM and MS_AUTO_ITEM (above), so it is a
  real desktop column with `NOT NULL DEFAULT 0` semantics by the pattern of :8228/:8258.
- Web `ITEM_MAST` (`packages/db/prisma/schema.prisma` model `ITEM_MAST`, 46 columns) has `AC_ITEM`, `UNICODE_NAME`,
  `TAG_IDTL_COL`, `OTH_DETL_POSTING`, `OTH_ITM_WT_REMOVE`, `ITM_WITH_LOT_STK`, `BULK_SALE` but **no** `TAX_FREE_ITEM`,
  `APP_ITEM`, `EMP_COM_PRC`, `AC_MEMB_COM_PRC` (grep over `web/` finds the two names only in the `autoItem.ts` header
  comment, :25-26). `deploy/sql/augment-columns.sql:15-29` adds the five hidden columns and no more.
- Web writers: `apps/api/src/modules/masters/itemMaster.ts:124-129` `HIDDEN_DEFAULTS` = `UNICODE_NAME ''`, `TAG_IDTL_COL 'N'`,
  `AC_ITEM ''`, `OTH_DETL_POSTING 'N'`; `apps/api/src/modules/masters/autoItem.ts:196-215` inserts 19 columns (the
  desktop's 22 minus `EMP_COM_PRC`, `TAX_FREE_ITEM` and the `MIN_STK` difference is nil). A migrated desktop row keeps its
  values only if the migration loader carries the columns; with no schema column they are dropped.

## Print

Every form reads `FRM_PRINT` from `USER_SET` at load (MS_ACCT.cs:5630 {{SUB_MENU = 'Party' }}; MS_ACCT.cs:5637
{{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"]}}; the same three lines at
MS_ADD_MAST.cs:3166, MS_GROUP.cs:1494, MS_EMP.cs:1007, MS_TAX.cs:1349, MS_ITEM.cs:2582, MS_PRODUCT.cs:1951,
MS_AUTO_ITEM.cs:2007) and refuses with one text: MS_GROUP.cs:1813 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}},
MS_GROUP.cs:1815 {{You Have No Print Rights.....}} (identical at MS_ACCT.cs:6694, MS_ADD_MAST.cs:3680, MS_EMP.cs:1590,
MS_TAX.cs:1963, MS_ITEM.cs:3702, MS_AUTO_ITEM.cs:2657).

| Form | Template (`DC_Main.RptName`) | Selection formula | In repo? |
|---|---|---|---|
| MS_ACCT | MS_ACCT.cs:6697 {{DC_Main.RptName = "AcMast";}} (also sets MS_ACCT.cs:6698 {{DC_Main.MsCustWappNo = "919879966455";}}, a hard-coded WhatsApp number) | none | **no** |
| MS_ADD_MAST | MS_ADD_MAST.cs:3683 {{DC_Main.RptName = "PartyMast";}} | MS_ADD_MAST.cs:3684 {{{ADD_MAST.CO_CODE}= '" + DC_Main.MCo_code + "' AND {ADD_MAST.LC_CODE}= '"}} (company **and location**) | **no** |
| MS_GROUP | MS_GROUP.cs:1818 {{DC_Main.RptName = "GroupMast";}} | MS_GROUP.cs:1819 {{DC_Main.RptFormula = "{GROUP_MAST.CO_CODE}= '"}} | **no** |
| MS_EMP | MS_EMP.cs:1593 {{DC_Main.RptName = "EmpMast";}} | MS_EMP.cs:1594 {{{EMP_MAST.CO_CODE}= '"}} | **no** |
| MS_TAX | MS_TAX.cs:1966 {{DC_Main.RptName = "TaxMast";}} | MS_TAX.cs:1967 {{{TAX_MAST.CO_CODE}= '"}} | **no** |
| MS_ITEM | MS_ITEM.cs:3359 {{DC_Main.RptName = "ItemMast";}} in MS_ITEM.cs:3357 {{private void BtnPrint_Click(object sender, EventArgs e)}} — **not wired**: the designer binds MS_ITEM.cs:990 {{EventHandler eventHandler = BtnPrint_Click_1;}}, and MS_ITEM.cs:3697 {{private void BtnPrint_Click_1(object sender, EventArgs e)}} only checks the right (MS_ITEM.cs:3700 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}) and does nothing else | — | dead code |
| MS_AUTO_ITEM | none; MS_AUTO_ITEM.cs:2655 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}} then nothing | — | — |
| MS_PRODUCT | MS_PRODUCT.cs:1914 {{private void BtnPrint_Click(object sender, EventArgs e)}} is empty (body :1915-1916) | — | — |

The viewer loads the template by name from the executable's folder: UT_REPORT.cs:254
{{"\\Report\\" + DC_Main.RptName + ".rpt"}}. The repository holds 254 extracted layouts in `extraction_output/rpt_xml/`
and 724 lines of `all_rpt_fields.txt`; a case-insensitive search for AcMast, PartyMast, GroupMast, EmpMast, TaxMast and
ItemMast finds **nothing** in either, and `find -iname '*.rpt'` outside `node_modules` finds nothing. The five layouts are
therefore **truly absent** and stay recorded gaps (R2); the web's on-screen list under the same right is the agreed
substitute (`apps/api/src/routes/groupMaster.ts:60-62` `GET /masters/group-master/print` behind `guard(req, reply, 'print')`;
party :87-89, address :64-66, tax :59-61; employee and item pages render the list client-side). The address list is scoped
by location like the desktop formula (`apps/api/src/modules/masters/addressMaster.ts:160` `AND "LC_CODE"=$3`).

## Rights

`USER_SET` row per menu caption (above). Texts in the residual scope: Print `You Have No Print Rights.....` (all eight
forms, lines above); Save/edit `You Have No Rights.....` (MS_GROUP.cs:1846 for Group; the others are in the module
headers). Web: each route file exposes `guard(req, reply, action)` with `action: 'view' | 'create' | 'update' | 'delete' | 'print'`
(`apps/api/src/routes/partyMaster.ts:51`) and the pages hold `NO_PRINT_RIGHTS = 'You Have No Print Rights.....'`
(`apps/web/app/(app)/masters/taxes/page.tsx:37`, employees :41, items :37, auto-item :30, party :38).

## Desktop weaknesses not to port

1. Hard-coded WhatsApp number on Party Print (MS_ACCT.cs:6698 {{DC_Main.MsCustWappNo = "919879966455";}}).
2. Group Save deletes and re-inserts the row (MS_GROUP.cs:1862 {{DELETE FROM GROUP_MAST WHERE CO_CODE}}), wiping columns the
   form does not set (G98; the web updates in place, `groupMaster.ts`).
3. Item Print is dead code (MS_ITEM.cs:990 binds `BtnPrint_Click_1`); the web rightly checks the right and stops.
4. Hidden key-chords that reveal bulk imports on the Party form (MS_ACCT.cs:6752-6758), and the admin panel that reloads the
   whole chart under group 20 (MS_ACCT.cs:9079 {{private void BtnAdminSet_Click(object sender, EventArgs e)}}, MS_ACCT.cs:9081
   {{tPartyGroup.Text = "20";}}).
5. The `MsCreat` round trip is global mutable state (`DC_Main.MsCreat`, `MsCode`, `MsName`, `MsGrCode`) across three forms;
   port the *behaviour* (create an account from the Employee help and return with it), not the mechanism.
6. Account roles by literal group number (`'25'`, `'30'`, `'12'`, `'09','10','45'`) and literal codes (`'00099'`, `'00013'`,
   `'00020'`). The web keeps the numbers because the migrated data carries them (D15); a web-provisioned company must then
   carry the same numbers (R1), or the helps are wrong.

## Web today

- Pages (`apps/web/app/(app)/masters/`): `party/page.tsx` (1,467 lines), `addresses/page.tsx` (771), `groups/page.tsx` (816),
  `taxes/page.tsx` (744), `employees/page.tsx` (615), `items/page.tsx` (973), `auto-item/page.tsx` (425), `products/page.tsx`
  (414). Each header comment cites the desktop lines it follows and the deliberate differences.
- API modules (`apps/api/src/modules/masters/`): `partyMaster.ts` (1,223), `addressMaster.ts` (448), `groupMaster.ts` (491),
  `taxMaster.ts` (400), `employeeMaster.ts` (390), `itemMaster.ts` (531), `autoItem.ts` (221), `productMaster.ts` (240);
  routes under `apps/api/src/routes/<same name>.ts`; DB tests `apps/api/test/<name>.db.test.ts` for all eight plus
  `taxMasterGst.db.test.ts`, `partyMaster.test.ts`, `employeeMaster.test.ts`.
- Helps already filter like the desktop: `groupMaster.ts:396` `const group = kind === 'sale' ? '25' : '30';` with
  `:401` `AND "AC_GR"=$7` and `:397` `AND "AC_CODE"<>'00099'`; `taxMaster.ts:343`
  `AND ("AC_GR"='12' OR "AC_CODE"='00013')` for the header, none for a component; `employeeMaster.ts:340`
  `("AC_GR" IN ('09','10','45') AND "AC_CODE"<>'00020'`; `partyMaster.ts:857` lists `AC_GROUP` and `:646` reads
  `AC_MAIN_GR` from it on save. Group Save refuses an account absent from `AC_MAST` (`groupMaster.ts:302`
  `is not in the account master`) but, unlike the desktop Enter, **does not** check the account's group.
- Provisioning (`apps/api/src/modules/ops/seedCompany.ts`): `SYSTEM_ACCOUNTS` :15-50 put `SALES`/`SLVSALE`/`BULLION`/
  `FINESALE` in group `'20'`, `PURCHASE`/`SLVPURC`/`OLDGOLD`/`OG`/`OS`/`FINEPURC`/`DHRN` in `'21'`, `GST`/`GSTINPUT`/`TCS` in
  `'30'`, `CAPITAL` in `'25'`, `WALKIN` in `'10'`; it inserts **no `AC_GROUP` rows** (grep count 0) and `TAX_MAST` with no
  `TAX_AC` (:104-108). The feature fixtures build the base company with this same routine
  (`apps/web/test/features/fixtures/catalogue.mjs:38`) and the Party module inserts its own `AC_GROUP` row to be able to
  save (`modules/partyMaster.mjs:182`), which is how the suite stays green on a company the desktop helps would not serve.
- Browser modules: `partyMaster.mjs` (1,492 lines), `addressMaster.mjs` (1,079), `groupMaster.mjs` (1,442), `taxMaster.mjs`
  (1,453), `employeeMaster.mjs` (1,435), `itemMaster.mjs` (1,311), `autoItem.mjs` (1,007), `productMaster.mjs` (986); no
  `blocked`/`pending` marker in any of them. `taxMaster.mjs:546` already picks the provisioned `GST` account (group 30)
  through the header help, i.e. the test asserts the N58-broken behaviour as a convenience.
- Lineage: N211 Employee (lineage :2598), N213 Tax (:2689), N214 Group (:2755), N215 Product (:2826), N217 Address
  (:2917), N218 Item (:2973), N236 Party (G236). The open residuals are recorded at lineage :2733-2737 (Tax, N58 and the
  by-rate resolver) and :2867-2871 region for Group (N58: CAPITAL in 25, GST/TCS in 30, sales/purchase in 20/21).

## Gaps

1. **R1a Group helps on a web-provisioned company (wrong result).** Desktop: Sales Ac accepts only group 25
   (MS_GROUP.cs:2204 {{AND AC_GR = '25' AND AC_CODE = '" + tSalesAc.Text}}) and lists group 25 (:2208); Purchase Ac group 30
   (:2242, :2246). Web help is the same filter (`groupMaster.ts:396-401`), but `seedCompany.ts:23-24` provisions `SALES` in
   `'20'` and `PURCHASE` in `'21'`, and `:39` puts `CAPITAL A/C` in `'25'`, `:25-29` `GST`/`GSTINPUT`/`TCS` in `'30'`. On such a
   company the Sales Ac help offers CAPITAL and the Purchase Ac help offers the tax accounts; `SALES` typed in is not
   listed. Also, web Save (`groupMaster.ts:290-304`) accepts any existing account, so the operator can save `SALE_AC = 'SALES'`
   from group 20 — a value the desktop Enter would have refused. **Fix:** (a) provision the desktop chart: `AC_GROUP` 35 rows
   and sales accounts in 25, purchase in 30, tax in 12 (N58, D15), with `TAX_AC` set; (b) make Save enforce the same group
   test as the help (`AC_GR = '25'` / `'30'`), with the desktop's behaviour (refuse and reopen the help) and a DB test;
   (c) a browser case on a freshly provisioned company proving the two helps list the sales and purchase accounts.
2. **R1b Tax header help (wrong result).** Desktop lists MS_TAX.cs:2039 {{AND (AC_GR = '12' OR  AC_CODE = '00013') ORDER BY AC_NAME}};
   web `taxMaster.ts:343` the same; `seedCompany.ts:25-29` puts every tax account in `'30'`, so the help lists **none** of
   them (lineage :2733). `taxMaster.mjs:546` passes only because an exact typed code bypasses the filter (desktop :2035 does
   the same, so the module is faithful, but it hides the empty list). **Fix:** provision `GST`, `GSTINPUT`, `TCS` (or the
   template's `00085`-`00087`) in group 12 and set `TAX_MAST.TAX_AC`; add a case that opens the header help with an empty
   term on a provisioned company and expects the tax accounts.
3. **R1c Employee help (wrong result, narrower).** Desktop lists groups 09/10/45 (MS_EMP.cs:1644). Web the same
   (`employeeMaster.ts:340`). `seedCompany.ts:20` seeds only `WALKIN` in `'10'`, so a fresh company's help offers the
   walk-in customer as the employee ledger and nothing else; the fix is the N58 chart (groups 09 employee/karigar, 45) plus
   the create path (gap 4).
4. **R1d Party group help (missing data, wrong result).** Desktop requires the group in `AC_GROUP` (MS_ACCT.cs:7039) and
   Year Create copies 35 rows (MS_YEAR.cs:1511 {{INSERT INTO AC_GROUP (CO_CODE,AC_GR,AC_GR_NAME,AC_MAIN_GR,AC_SUB_GR,MAIN_USER)}}).
   `seedCompany.ts` writes none, so on a web-provisioned company the Party group help is empty, `AC_MAIN_GR` stays blank
   (`partyMaster.ts:646-650`), and the browser module has to insert its own group (`partyMaster.mjs:182`). **Fix:** seed the
   35 `AC_GROUP` rows in `seedCompany.ts` (idempotent insert-if-absent like the accounts) and drop the module's private
   insert; a DB test that a provisioned company has 35 groups with the desktop `AC_MAIN_GR` letters.
5. **R2 Print layouts (missing feature, recorded).** Desktop prints Crystal `AcMast`, `PartyMast`, `GroupMast`, `EmpMast`,
   `TaxMast` (table above) from `\Report\<name>.rpt` (UT_REPORT.cs:254 {{"\\Report\\" + DC_Main.RptName + ".rpt"}}). None of
   the five is in the repository; the web shows the list on screen behind the print right. **No fix possible from the
   source**; keep the five catalog "Remaining" sentences, and record that `ItemMast` is dead code (MS_ITEM.cs:990) and
   Product/AutoItem print nothing (MS_PRODUCT.cs:1914-1916, MS_AUTO_ITEM.cs:2655), so those three rows carry **no** print
   gap. Owner decision (open question 1) whether a web-designed layout replaces the on-screen list; until then the rows
   can go `FULL` with the sentence kept, because the desktop file itself is unavailable, not the behaviour.
6. **R3 `TAX_FREE_ITEM`, `EMP_COM_PRC` (and `APP_ITEM`, `AC_MEMB_COM_PRC`) columns (missing columns).** Desktop writes them on
   every item save (MS_ITEM.cs:3261-3263) and on every AutoItem insert (MS_AUTO_ITEM.cs:2904 {{dataRow2["EMP_COM_PRC"] = 0;}},
   :2912 {{dataRow2["TAX_FREE_ITEM"] = "N";}}); schema: Ac_Image.cs:8044
   {{ALTER TABLE ITEM_MAST ADD TAX_FREE_ITEM VARCHAR(1)Not NULL DEFAULT 'N'}}, :8258 `AC_MEMB_COM_PRC FLOAT`. Web
   `schema.prisma` model `ITEM_MAST` lacks all four; `itemMaster.ts:124-129` and `autoItem.ts:196-215` cannot write them. No
   Lite form shows or reads them (Screen table; Calculations), so **no Lite behaviour is wrong today**; the cost is a lossy
   migration (a desktop company's `TAX_FREE_ITEM = 'Y'` items and `EMP_COM_PRC` rates are dropped) and a divergence from
   the desktop schema. **Fix:** add the four columns to `schema.prisma` and `deploy/sql/augment-columns.sql` with the
   desktop defaults (`'N'`, `0`, `'N'`, `0`); write them from `itemMaster.ts` (`HIDDEN_DEFAULTS`) and `autoItem.ts` as the
   desktop does; carry them in the migration loader; a DB test that a new item and an AutoItem item store `N/0/N/0` and
   that an edit preserves a migrated `Y`. Do **not** add boxes to the Lite screens (R5).
7. **R4 Employee help cannot create an account (missing feature).** Desktop: F1 in the help (MS_HELP.cs:2240
   {{else if ((int)e.KeyCode == 112)}}, :2252 {{DC_Main.MsCreat = true;}}) opens the Party form with group 10 preset
   (MS_EMP.cs:1658 {{DC_Main.MsGrCode = "10";}}, MS_ACCT.cs:5963 {{tAcGrCode.Text = DC_Main.MsGrCode;}}); Save returns the code
   and name (MS_ACCT.cs:7932-7934) and the Employee form fills `tEmpAc`/`tEmpAcName` on activation (MS_EMP.cs:1184-1185).
   Web: `employees/page.tsx:38` records "The account help cannot create an account"; the party page takes no preset
   (`party/page.tsx` has no group query parameter). **Fix:** F1 in the employee account help opens `/masters/party` in
   create mode with `group=10` and a return target; on Save the party page returns the new code and name to the employee
   box (query parameter or `sessionStorage` hand-back), focus stays on the account box as MS_EMP.cs:1189 restores
   `CurActCtrl`. Browser case: create an employee whose ledger did not exist, through the help.
8. **R5 Edition boxes (not a gap; record as verified).** Item: `chktaxfreeItem`/`tItUniCode` UAE only (MS_ITEM.cs:2743, :2747),
   `chkTagOthDetail` P/A/E (:2753-2755), `chkOthItmPosting` E (:2757-2759), `tAcItem` company type P (:2761-2763), `chkAppItem`
   on `MsAppSchem` (:2770-2772). Party: admin panel, defaulter and limits A/E/UAE (MS_ACCT.cs:5971-5978), UAE relabels
   (:5982-5984), imports on Ctrl+O/Ctrl+Y (:6752-6758). Product: Counter and Scheme Mast modes are other menus
   (MS_PRODUCT.cs:2100, :2105; MDI_FORM.cs:7731, :9374). The catalog "Remaining" sentences for Item, Party and Product can be
   closed as **verified absent by design** once the row is proposed FULL; nothing to build.
9. **R6 Sales tax code by rate (cross-reference, wrong result elsewhere).** Desktop MS_TAX gives the code; the Sales screen
   picks the code from the header rows (lineage :2735, `TR_SALE.cs:18668`), while the web resolves by `TAX_PRC`
   (`apps/api/src/modules/shared/taxPolicy.ts:91` `coalesce("TAX_PRC",0)::numeric=$n`). Owned by WP-26 (G82); the Tax row's
   "Remaining" sentence should point there rather than stay on the Tax master.
10. **Test honesty (missing case).** No browser or DB case runs any of the four helps against the company exactly as
    `seedCompany.ts` leaves it: `partyMaster.mjs:182` adds a group, `taxMaster.mjs:546` types the code. Add one
    "provisioned-company helps" case per module (group, tax, employee, party) that uses only provisioning output; they go
    red today and green with gap 1-4's seed change.

## Open questions

1. Owner: should the five missing master prints get a web-designed layout (columns to be chosen from `GROUP_MAST`,
   `TAX_MAST`, `EMP_MAST`, `ADD_MAST`, `AC_MAST`), or does the on-screen list remain the agreed substitute? The source
   cannot answer (the `.rpt` files are not in the repository).
2. Where does the desktop create `ITEM_MAST.EMP_COM_PRC` and `APP_ITEM`? `Ac_Image.cs` adds `EMP_COM_PRC` to `TOUCH_MAST`
   (:8228) and `AC_MEMB_COM_PRC` to `ITEM_MAST` (:8258) but no `ITEM_MAST ADD EMP_COM_PRC` / `ADD APP_ITEM`; they are in the
   base schema (`extraction_output/DataCareNext_db_schema.json` was not parsed in this study). Types are needed for the
   Prisma column (`FLOAT`/`VARCHAR(1)` by the sibling patterns).
3. Which 35 `AC_GROUP` rows (codes, names, `AC_MAIN_GR`, `AC_SUB_GR`) make up the desktop chart? `desktop-conventions.json`
   gives the count, checksum and main-group letters only; the N58 template generator (WP-07) must take them from a
   restored desktop database. Groups 09 and 45 (employee help) need their names confirmed from that dump.
4. Should web Group Save enforce the account's group (gap 1b), or is accepting any `AC_MAST` code a deliberate web
   difference? The desktop never reaches Save with a wrong group because Enter refuses it (:2204/:2242) — but a code pasted
   without Enter could; the form's `Validating` handlers were not read for this study.
5. For gap 7, does the owner want the Party form's full create flow inside the Employee screen (modal) or a navigation
   with hand-back? The desktop uses an MDI child plus global state; either web design satisfies the behaviour.
