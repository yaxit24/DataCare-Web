# Retained surface and source register

Baseline: `03148fef5899224b8c4c9805ca07161a920efeb1`. Complete for the enumerated retained records only; semantic feature/caller/edition discovery and all acceptance remain open. Candidate routes below come from the old register and are not proof of correct mapping or usable behavior.

Use `desktop-form-reference.json` for freshly indexed source SHA-256, every discovered method anchor, posting-helper calls, report references and catalog paths. Use `requirement-index.json` to locate every original grid/control/event/additional-control row without losing its ID. All original detailed register rows remain normative discovery inputs.

## Source registers

| Kind | Retained records | Repository path |
|---|---:|---|
| form | 204 | `parity-plan-2026-09-10/evidence/form-register.json` |
| grid | 3508 | `parity-plan-2026-09-10/evidence/grid-requirements.json` |
| control | 1599 | `parity-plan-2026-09-10/evidence/control-requirements.json` |
| event | 5838 | `parity-plan-2026-09-10/evidence/event-requirements.json` |
| additional-control | 916 | `parity-plan-2026-09-10/evidence/additional-control-candidates.json` |
| support | 8 | `parity-plan-2026-09-10/evidence/supporting-source-register.json` |
| report | 275 | `parity-plan-2026-09-10/evidence/report-register.json` |
| table | 146 | `parity-plan-2026-09-10/evidence/table-register.json` |
| setting | 130 | `parity-plan-2026-09-10/evidence/settings-review.json` |
| menu | 198 | `web/docs/COMPLETION-REGISTER.json` |

Total indexed raw records: **12,822**. This total includes overlaps and infrastructure; do not report it as a distinct feature count. The 204 primary sources, eight support units and 198 menu rows are different views of the product.

## All 204 primary namespace units

Each row inherits T01–T18 and relevant J journeys. Zero scanned controls does not prove a file has no business behavior. The old phase and candidate UI are leads for the owning engineer, not an approved semantic mapping. `Module_Schm` and `BtmSchm` are specifically corrected to transfer/reset utility investigation (X27/X32); do not infer ordinary installment functionality from their names.

| Source unit and path | Historical phase | Scanned input / named-grid counts | Candidate web routes | Source method entry points |
|---|---|---|---|---|
| `Ac_Final` — `unified/src/csharp/DataCareNext/Ac_Final.cs` | P10 | 0 / 0 | /utilities/year-end; /reports/balance-sheet | `Trading_Stock:18`; `AcBalInsert:139` |
| `Ac_Image` — `unified/src/csharp/DataCareNext/Ac_Image.cs` | P00 / P01 / P02 | 0 / 0 | /masters/party; /txn/tag-print | `AsyncLoadImage:4037`; `AsyncLoadImageDrawCell:4359`; `SaveJPGWithCompressionSetting:4399`; `FtpDeleteFile:4536` |
| `Ac_Ledr` — `unified/src/csharp/DataCareNext/Ac_Ledr.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior | `AcOp_Ledr:9`; `Order_Ledr:28`; `Sales_Ledr:61` |
| `Ac_Rojmel` — `unified/src/csharp/DataCareNext/Ac_Rojmel.cs` | P10 | 0 / 0 | /reports/day-book | `Order_Rojmel:9`; `Sales_Rojmel:29`; `Purc_Rojmel:115` |
| `Ac_Stock` — `unified/src/csharp/DataCareNext/Ac_Stock.cs` | P00 / P01 / P02 | 0 / 0 | /txn/stock; /reports/tag-stock | `Itm_Opbl_Stk:11`; `Tag_Opbl_Stk:22`; `Item_Lot_Stk:36` |
| `Ac_Tax` — `unified/src/csharp/DataCareNext/Ac_Tax.cs` | P00 / P01 / P02 | 0 / 0 | /reports/gstr1; /reports/gstr2; /reports/gstr3b | `SchemeOp_Os:11`; `SchemeEnt_Os:17`; `SchemeAdj_Os:23` |
| `AuthClass` — `unified/src/csharp/DataCareNext/AuthClass.cs` | P00 / P01 / P02 | 0 / 0 | /login |  |
| `AuthError` — `unified/src/csharp/DataCareNext/AuthError.cs` | P00 / P01 / P02 | 0 / 0 | /login |  |
| `BtmSchm` — `unified/src/csharp/DataCareNext/BtmSchm.cs` | P00 / P01 / P02 | 0 / 0 | Old scheme mapping needs correction: transfer/reset utility; see X27/X32 | `MS_BAL_TRFR_Load:1929`; `BtnDelete_Click:2720` |
| `ClassTagList` — `unified/src/csharp/DataCareNext/ClassTagList.cs` | P00 / P01 / P02 | 0 / 0 | /txn/stock; /reports/tag-stock |  |
| `ClsAddlDocDtls` — `unified/src/csharp/DataCareNext/ClsAddlDocDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsAttribDtls` — `unified/src/csharp/DataCareNext/ClsAttribDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsBchDtls` — `unified/src/csharp/DataCareNext/ClsBchDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsBuyerDtls` — `unified/src/csharp/DataCareNext/ClsBuyerDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsContrDtls` — `unified/src/csharp/DataCareNext/ClsContrDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsDispDtls` — `unified/src/csharp/DataCareNext/ClsDispDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsDocDtls` — `unified/src/csharp/DataCareNext/ClsDocDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsDocPerdDtls` — `unified/src/csharp/DataCareNext/ClsDocPerdDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsExpDtls` — `unified/src/csharp/DataCareNext/ClsExpDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsItemList` — `unified/src/csharp/DataCareNext/ClsItemList.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior |  |
| `ClsPayDtls` — `unified/src/csharp/DataCareNext/ClsPayDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsPrecDocDtls` — `unified/src/csharp/DataCareNext/ClsPrecDocDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsRefDtls` — `unified/src/csharp/DataCareNext/ClsRefDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsSellerDtls` — `unified/src/csharp/DataCareNext/ClsSellerDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsShipDtls` — `unified/src/csharp/DataCareNext/ClsShipDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsTranDtls` — `unified/src/csharp/DataCareNext/ClsTranDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `ClsValDtls` — `unified/src/csharp/DataCareNext/ClsValDtls.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `DC_Main` — `unified/src/csharp/DataCareNext/DC_Main.cs` | P00 / P01 / P02 | 0 / 0 | /dashboard | `SoftLoad:2166`; `LoadImageWithoutLock:2289` |
| `Data` — `unified/src/csharp/DataCareNext/Data.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior |  |
| `DcClass` — `unified/src/csharp/DataCareNext/DcClass.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior |  |
| `DcPrintClass` — `unified/src/csharp/DataCareNext/DcPrintClass.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior |  |
| `ErrorResp` — `unified/src/csharp/DataCareNext/ErrorResp.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `IRNClass` — `unified/src/csharp/DataCareNext/IRNClass.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `IRNData` — `unified/src/csharp/DataCareNext/IRNData.cs` | P00 / P01 / P02 | 0 / 0 | /utilities/e-invoice |  |
| `MDI_FORM` — `unified/src/csharp/DataCareNext/MDI_FORM.cs` | P00 / P01 / P02 | 4 / 0 | /dashboard | `MDI_FORM_Load:11048`; `CboTheme_SelectedIndexChanged:12842`; `LoadGoldRate:13854` |
| `MS_ACCT` — `unified/src/csharp/DataCareNext/MS_ACCT.cs` | P03 | 55 / 0 | /masters/accounts; /masters/customers; /masters/party | `MS_ACCT_Load:5584`; `BtnSave_Click:7650`; `BtnDelete_Click:7963`; `CboGold_SelectedIndexChanged:8113`; `CboSilver_SelectedIndexChanged:8147`; `cboCity_SelectedIndexChanged:9640` |
| `MS_AC_GROUP` — `unified/src/csharp/DataCareNext/MS_AC_GROUP.cs` | P03 | 9 / 0 | /masters/ac-groups | `MS_AC_GROUP_Load:1206`; `BtnSave_Click:1764`; `BtnDelete_Click:1865` |
| `MS_ADD_MAST` — `unified/src/csharp/DataCareNext/MS_ADD_MAST.cs` | P03 | 32 / 0 | /masters/addresses | `MS_ADD_MAST_Load:3119`; `BtnSave_Click:4411`; `BtnDelete_Click:4517` |
| `MS_AUTO_ITEM` — `unified/src/csharp/DataCareNext/MS_AUTO_ITEM.cs` | P03 | 8 / 24 | /masters/auto-item | `MS_AUTO_ITEM_Load:1978`; `BtnSave_Click:2661`; `BtnDelete_Click:2927`; `cboUPdateType_SelectedIndexChanged:3717`; `BtnSave_KeyDown:3721` |
| `MS_BOOK` — `unified/src/csharp/DataCareNext/MS_BOOK.cs` | P03 | 15 / 4 | /masters/books | `MS_BOOK_Load:1900`; `BtnSave_Click:2579`; `BtnDelete_Click:2687` |
| `MS_BOOKLIST` — `unified/src/csharp/DataCareNext/MS_BOOKLIST.cs` | P03 | 1 / 0 | /masters/books | `MS_BOOKLIST_Load:349` |
| `MS_COMPANY` — `unified/src/csharp/DataCareNext/MS_COMPANY.cs` | P03 | 39 / 0 | /masters/companies; /admin/provision; /select | `MS_COMPANY_Load:5397`; `BtnSave_Click:6042`; `BtnDelete_Click:6254`; `cboWithOldCoMast_SelectedIndexChanged:7291`; `BtneSave_Click:7446`; `btnSaveUae_Click:7535` |
| `MS_DESIGN_BOOK` — `unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs` | P03 | 5 / 59 | /masters/styles; /masters/designs; /masters/models | `MS_DESIGN_BOOK_Load:4093`; `BtnSave_Click:4619`; `BtnDelete_Click:4771`; `Mobile_image_Save:5474` |
| `MS_DM` — `unified/src/csharp/DataCareNext/MS_DM.cs` | P03 | 8 / 0 | /masters/diamonds | `MS_DM_Load:1089`; `BtnSave_Click:1429`; `BtnDelete_Click:1510` |
| `MS_EMP` — `unified/src/csharp/DataCareNext/MS_EMP.cs` | P03 | 7 / 0 | /masters/employees | `MS_EMP_Load:976`; `BtnSave_Click:1462`; `BtnDelete_Click:1552`; `cboUser_SelectedIndexChanged:1725` |
| `MS_GOLD_MAST` — `unified/src/csharp/DataCareNext/MS_GOLD_MAST.cs` | P03 | 11 / 0 | /masters/gold-rate | `MS_GOLD_MAST_Load:1078`; `BtnSave_Click:1301`; `BtnDelete_Click:1373` |
| `MS_GROUP` — `unified/src/csharp/DataCareNext/MS_GROUP.cs` | P03 | 16 / 0 | /masters/groups | `MS_GROUP_Load:1463`; `BtnSave_Click:1825`; `BtnDelete_Click:1921` |
| `MS_HELP` — `unified/src/csharp/DataCareNext/MS_HELP.cs` | P03 | 1 / 0 | No route inferred; classify helper/caller behavior | `MS_HELP_Load:355` |
| `MS_ITEM` — `unified/src/csharp/DataCareNext/MS_ITEM.cs` | P03 | 24 / 0 | /masters/items | `MS_ITEM_Load:2548`; `BtnSave_Click:3165`; `BtnDelete_Click:3302` |
| `MS_LBR_TYPE` — `unified/src/csharp/DataCareNext/MS_LBR_TYPE.cs` | P03 | 6 / 0 | /masters/labour; /masters/labour-update | `MS_LBR_TYPE_Load:995`; `BtnSave_Click:1293`; `BtnDelete_Click:1404` |
| `MS_LOCT` — `unified/src/csharp/DataCareNext/MS_LOCT.cs` | P03 | 26 / 0 | /masters/locations | `MS_LOCT_Load:3059`; `BtnSave_Click:3532`; `BtnDelete_Click:3624` |
| `MS_LOGIN` — `unified/src/csharp/DataCareNext/MS_LOGIN.cs` | P03 | 2 / 0 | /login; /admin/users | `MS_LOGIN_Load:324` |
| `MS_MEMB` — `unified/src/csharp/DataCareNext/MS_MEMB.cs` | P03 | 34 / 0 | /txn/membership; /txn/scheme | `MS_MEMB_Load:3684`; `BtnSave_Click:4824`; `BtnDelete_Click:4974` |
| `MS_MFG_MAST` — `unified/src/csharp/DataCareNext/MS_MFG_MAST.cs` | P03 | 1 / 14 | /masters/mfg | `MS_MFG_MAST_Load:889`; `BtnSave_Click:1121`; `BtnDelete_Click:1238`; `btnEntryDelete_Click:1865` |
| `MS_OPNCOMP` — `unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | P03 | 3 / 0 | /masters/companies; /admin/provision; /select | `MS_OPNCOMP_Load:381` |
| `MS_POINT` — `unified/src/csharp/DataCareNext/MS_POINT.cs` | P03 | 6 / 6 | /masters/points | `MS_POINT_Load:1586`; `BtnSave_Click:1988`; `BtnDelete_Click:2088`; `DGV_AC_SelectionChanged:2283` |
| `MS_PRINT` — `unified/src/csharp/DataCareNext/MS_PRINT.cs` | P03 | 0 / 0 | /masters/print-formats | `MS_LOGIN_Load:385` |
| `MS_PRODUCT` — `unified/src/csharp/DataCareNext/MS_PRODUCT.cs` | P03 | 12 / 0 | /masters/products | `MS_PRODUCT_Load:1918`; `BtnSave_Click:2570`; `BtnDelete_Click:2706`; `cboImgType_SelectedValueChanged:3184` |
| `MS_RATE` — `unified/src/csharp/DataCareNext/MS_RATE.cs` | P03 | 8 / 10 | /masters/rates; /txn/daily-rate | `MS_RATE_Load:1539`; `BtnSave_Click:1867`; `BtnDelete_Click:2095` |
| `MS_STK_LIMIT` — `unified/src/csharp/DataCareNext/MS_STK_LIMIT.cs` | P03 | 4 / 11 | /masters/item-weights | `MS_STK_LIMIT_Load:1400`; `BtnSave_Click:1828`; `BtnDelete_Click:1921` |
| `MS_STYLE` — `unified/src/csharp/DataCareNext/MS_STYLE.cs` | P03 | 2 / 0 | /masters/styles; /masters/designs; /masters/models | `MS_STYLE_Load:624`; `BtnSave_Click:1048`; `BtnDelete_Click:1162` |
| `MS_TASTING` — `unified/src/csharp/DataCareNext/MS_TASTING.cs` | P03 | 0 / 0 | No route inferred; classify helper/caller behavior | `MS_TASTING_Load:283` |
| `MS_TAX` — `unified/src/csharp/DataCareNext/MS_TAX.cs` | P03 | 8 / 5 | /masters/taxes | `MS_TAX_Load:1312`; `BtnSave_Click:1824`; `BtnDelete_Click:1935` |
| `MS_TRADE` — `unified/src/csharp/DataCareNext/MS_TRADE.cs` | P03 | 1 / 9 | /masters/trade | `MS_TRADE_Load:678`; `BtnSave_Click:899`; `BtnDelete_Click:985` |
| `MS_UPDATE` — `unified/src/csharp/DataCareNext/MS_UPDATE.cs` | P03 | 2 / 0 | /utilities/data-refresh; /masters/labour-update | `MS_UPDATE_Load:2027`; `BtnDelete_Click:2330`; `btnTagStkDelete_Click:32423` |
| `MS_USER` — `unified/src/csharp/DataCareNext/MS_USER.cs` | P03 | 7 / 0 | /admin/users | `MS_USER_Load:1306`; `BtnSave_Click:1820`; `BtnDelete_Click:2067`; `CboUser_SelectedIndexChanged:2473` |
| `MS_WINDOW_SET` — `unified/src/csharp/DataCareNext/MS_WINDOW_SET.cs` | P03 | 1 / 5 | /settings; /masters/styles | `MS_WINDOW_SET_Load:836`; `BtnSave_Click:1090`; `BtnDelete_Click:1114` |
| `MS_YEAR` — `unified/src/csharp/DataCareNext/MS_YEAR.cs` | P03 | 4 / 0 | /masters/years; /masters/year-create; /utilities/year-end | `MS_YEAR_Load:759`; `BtnDelete_Click:970`; `BtnSave_Click:1140`; `DeleteOldYear_Data:1403` |
| `Mfg_Module` — `unified/src/csharp/DataCareNext/Mfg_Module.cs` | P00 / P01 / P02 | 0 / 0 | /txn/mfg-issue; /txn/mfg-receive | `Mfg_With_lot:10`; `Mfg_With_Order:25`; `Mfg_menu_set:178` |
| `Module_Save` — `unified/src/csharp/DataCareNext/Module_Save.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior | `OpenRecordSetDcSave:45`; `ExeQuteDcSave:63`; `MsInsertDataSave:86` |
| `Module_Schm` — `unified/src/csharp/DataCareNext/Module_Schm.cs` | P00 / P01 / P02 | 0 / 0 | Old scheme mapping needs correction: transfer/reset utility; see X27/X32 | `RunDcSelect:820`; `RunMcSelect:847` |
| `Module_WhatsApp` — `unified/src/csharp/DataCareNext/Module_WhatsApp.cs` | P00 / P01 / P02 | 0 / 0 | /integrations | `Description:74`; `_Lambda_0024__0:96`; `_Lambda_0024__0:160` |
| `OlockerService` — `unified/src/csharp/DataCareNext/OlockerService.cs` | P05 / P11 | 0 / 0 | No route inferred; classify helper/caller behavior | `Dispose:40`; `InitializeComponent:56`; `GetToken:67` |
| `PolicyModels` — `unified/src/csharp/DataCareNext/PolicyModels.cs` | P05 / P11 | 0 / 0 | /utilities/e-invoice |  |
| `RP_ADDRESS` — `unified/src/csharp/DataCareNext/RP_ADDRESS.cs` | P10 | 11 / 0 | /reports/report-layouts | `RP_ADDRESS_Load:2506`; `CboAddType_SelectedIndexChanged:3306`; `ChkAcSelect_CheckedChanged:3545` |
| `RP_ALL` — `unified/src/csharp/DataCareNext/RP_ALL.cs` | P10 | 12 / 0 | /reports/report-layouts | `RP_ALL_Load:6629`; `chkBookSelect_Click:11355` |
| `RP_BALANCE` — `unified/src/csharp/DataCareNext/RP_BALANCE.cs` | P10 | 7 / 0 | /reports/balance-sheet; /reports/account-balances | `RP_BALANCE_Load:1826`; `BtnSave_Click:2556`; `BtnDelete_Click:2646` |
| `RP_BAL_ZOOM` — `unified/src/csharp/DataCareNext/RP_BAL_ZOOM.cs` | P10 | 9 / 0 | /reports/account-balances | `BtnSave_Click:3325`; `RP_BAL_ZOOM_Load:4059` |
| `RP_BILL_PROFIT` — `unified/src/csharp/DataCareNext/RP_BILL_PROFIT.cs` | P10 | 8 / 0 | /reports/report-layouts | `BtnSave_Click:3729`; `BtnDelete_Click:4130`; `RP_BILL_PROFIT_Load:4134`; `chkBookSelect_Click:6065` |
| `RP_CASH_BANK` — `unified/src/csharp/DataCareNext/RP_CASH_BANK.cs` | P10 | 12 / 0 | /reports/cash-book | `BtnSave_Click:2357`; `BtnDelete_Click:2785`; `RP_CASH_BANK_Load:2789`; `cboScheme_SelectedIndexChanged:4608` |
| `RP_CONSI_APR` — `unified/src/csharp/DataCareNext/RP_CONSI_APR.cs` | P10 | 3 / 0 | /reports/report-layouts | `BtnSave_Click:1517`; `BtnDelete_Click:1817`; `RP_CONSI_APR_Load:1821` |
| `RP_CUST` — `unified/src/csharp/DataCareNext/RP_CUST.cs` | P10 | 3 / 0 | /reports/customer-crm | `BtnSave_Click:786`; `RP_CUST_Load:790` |
| `RP_CUST_CRM` — `unified/src/csharp/DataCareNext/RP_CUST_CRM.cs` | P10 | 11 / 0 | /reports/customer-crm | `BtnSave_Click:2826`; `RP_CUST_CRM_Load:3126` |
| `RP_DAY_WORK` — `unified/src/csharp/DataCareNext/RP_DAY_WORK.cs` | P10 | 5 / 0 | /reports/day-book | `RP_DAY_WORK_Load:1972` |
| `RP_DHRN_LOAN` — `unified/src/csharp/DataCareNext/RP_DHRN_LOAN.cs` | P10 | 10 / 0 | /reports/dhrn-outstanding | `RP_DHRN_LOAN_Load:2091` |
| `RP_DHRN_OS` — `unified/src/csharp/DataCareNext/RP_DHRN_OS.cs` | P10 | 9 / 0 | /reports/dhrn-outstanding | `BtnSave_Click:2713`; `BtnDelete_Click:3093`; `RP_DHRN_OS_Load:3097` |
| `RP_EMP` — `unified/src/csharp/DataCareNext/RP_EMP.cs` | P10 | 9 / 0 | /reports/employee-sales | `BtnSave_Click:2617`; `RP_EMP_Load:2940`; `chkItSelect_Click:3983` |
| `RP_GRAPH` — `unified/src/csharp/DataCareNext/RP_GRAPH.cs` | P10 | 3 / 0 | /reports/daily-sales; /reports/top-items | `BtnSave_Click:1403`; `RP_GRAPH_Load:1606` |
| `RP_GST` — `unified/src/csharp/DataCareNext/RP_GST.cs` | P10 | 6 / 3 | /reports/gstr1; /reports/gstr2; /reports/gstr3b | `RP_GST_Load:1474`; `BtnSave_Click:2162`; `SaveCSV:3114` |
| `RP_HUID` — `unified/src/csharp/DataCareNext/RP_HUID.cs` | P10 | 4 / 0 | /reports/tag-stock | `BtnSave_Click:1356`; `BtnDelete_Click:1369`; `RP_HUID_Load:1373` |
| `RP_INOUT` — `unified/src/csharp/DataCareNext/RP_INOUT.cs` | P10 | 6 / 0 | /reports/item-stock-ledger | `BtnSave_Click:2769`; `RP_INOUT_Load:3069` |
| `RP_JDTR_ZOOM` — `unified/src/csharp/DataCareNext/RP_JDTR_ZOOM.cs` | P10 | 6 / 0 | /reports/karigar-ledger | `RP_JDTR_ZOOM_Load:1851`; `BtnSave_Click:2100` |
| `RP_LC_INOUT` — `unified/src/csharp/DataCareNext/RP_LC_INOUT.cs` | P10 | 4 / 0 | /reports/stock-by-location | `BtnSave_Click:1723`; `BtnDelete_Click:2179`; `RP_LC_INOUT_Load:2183` |
| `RP_LC_SALE` — `unified/src/csharp/DataCareNext/RP_LC_SALE.cs` | P10 | 4 / 0 | /reports/location-wise-sales | `BtnSave_Click:2200`; `BtnDelete_Click:2634`; `RP_LC_SALE_Load:2638` |
| `RP_LEDR` — `unified/src/csharp/DataCareNext/RP_LEDR.cs` | P10 | 17 / 0 | /reports/account-ledger | `BtnSave_Click:3297`; `BtnDelete_Click:3984`; `RP_LEDR_Load:4088`; `tSerchAll_SelectedIndexChanged:11811` |
| `RP_MFG` — `unified/src/csharp/DataCareNext/RP_MFG.cs` | P10 | 5 / 0 | /reports/report-layouts | `RP_MFG_Load:1433` |
| `RP_MFG_LEDR` — `unified/src/csharp/DataCareNext/RP_MFG_LEDR.cs` | P10 | 6 / 0 | /reports/karigar-ledger | `BtnSave_Click:2432`; `BtnDelete_Click:2837`; `RP_MFG_LEDR_Load:2841` |
| `RP_MFG_ZOOM` — `unified/src/csharp/DataCareNext/RP_MFG_ZOOM.cs` | P10 | 8 / 0 | /reports/report-layouts | `RP_MFG_ZOOM_Load:2667`; `BtnSave_Click:2970` |
| `RP_MOVEMENT` — `unified/src/csharp/DataCareNext/RP_MOVEMENT.cs` | P10 | 6 / 0 | /reports/item-stock-ledger | `BtnSave_Click:3408`; `BtnDelete_Click:3864`; `RP_MOVEMENT_Load:3868`; `ChkItmSelect_CheckedChanged:4842`; `chkItmSelect_Click:4846` |
| `RP_ORDER` — `unified/src/csharp/DataCareNext/RP_ORDER.cs` | P10 | 7 / 0 | /reports/report-layouts | `RP_ORDER_Load:2199`; `BtnSave_Click:3222`; `BtnDelete_Click:3816`; `DeleteData:4894`; `cboCity_SelectedIndexChanged:5049`; `cboArea_SelectedIndexChanged:5053` |
| `RP_ORD_TRACK` — `unified/src/csharp/DataCareNext/RP_ORD_TRACK.cs` | P10 | 10 / 0 | /reports/report-layouts | `BtnSave_Click:2825`; `BtnDelete_Click:3116`; `RP_ORD_TRACK_Load:3120` |
| `RP_OS` — `unified/src/csharp/DataCareNext/RP_OS.cs` | P10 | 18 / 0 | /reports/outstanding; /reports/bill-outstanding | `RP_OS_Load:3146`; `ChkAcSelect_CheckedChanged:4606` |
| `RP_OTH_DETL` — `unified/src/csharp/DataCareNext/RP_OTH_DETL.cs` | P10 | 12 / 0 | /reports/report-layouts | `RP_OTH_DETL_Load:2597`; `chkBookSelect_Click:3513` |
| `RP_PHY_STOCK` — `unified/src/csharp/DataCareNext/RP_PHY_STOCK.cs` | P10 | 5 / 0 | /txn/physical-stock | `RP_PHY_STOCK_Load:1503`; `BtnSave_Click:2730` |
| `RP_REMINDER` — `unified/src/csharp/DataCareNext/RP_REMINDER.cs` | P10 | 3 / 0 | /utilities/reminders | `RP_REMINDER_Load:1609`; `BtnSave_Click:4473` |
| `RP_ROJMEL` — `unified/src/csharp/DataCareNext/RP_ROJMEL.cs` | P10 | 4 / 10 | /reports/day-book | `RP_ROJMEL_Load:2779`; `BtnSave_Click:3357`; `BtnDelete_Click:4914`; `btnBalSave_Click:5837` |
| `RP_SLPR_ZOOM` — `unified/src/csharp/DataCareNext/RP_SLPR_ZOOM.cs` | P10 | 9 / 0 | /reports/sales-register; /reports/purchase-register | `BtnSave_Click:4108`; `BtnDelete_Click:4574`; `RP_SLPR_ZOOM_Load:4578`; `ChkItmSelect_CheckedChanged:7050`; `chkItmSelect_Click:7054`; `chkBookSelect_Click:7433` |
| `RP_STK_LEVEL` — `unified/src/csharp/DataCareNext/RP_STK_LEVEL.cs` | P10 | 4 / 0 | /reports/item-group-stock | `BtnSave_Click:1585`; `RP_STK_LEVEL_Load:1997` |
| `RP_STK_MOVE` — `unified/src/csharp/DataCareNext/RP_STK_MOVE.cs` | P10 | 4 / 0 | /reports/item-stock-ledger | `BtnSave_Click:3049`; `BtnDelete_Click:3450`; `RP_STK_MOVE_Load:3454` |
| `RP_STOCK` — `unified/src/csharp/DataCareNext/RP_STOCK.cs` | P10 | 9 / 0 | /reports/stock-valuation | `BtnSave_Click:3232`; `RP_STOCK_Load:3341`; `BtnDelete_Click:5855` |
| `RP_STOCK_FINE` — `unified/src/csharp/DataCareNext/RP_STOCK_FINE.cs` | P10 | 3 / 0 | /reports/stock-valuation | `BtnSave_Click:1871`; `BtnDelete_Click:2276`; `RP_STOCK_FINE_Load:2280` |
| `RP_STOCK_VALUE` — `unified/src/csharp/DataCareNext/RP_STOCK_VALUE.cs` | P10 | 4 / 0 | /reports/stock-valuation | `BtnSave_Click:2098`; `BtnDelete_Click:2520`; `RP_STOCK_VALUE_Load:2524` |
| `RP_TAG` — `unified/src/csharp/DataCareNext/RP_TAG.cs` | P10 | 19 / 0 | /reports/tag-stock | `BtnSave_Click:3254`; `BtnDelete_Click:3267`; `RP_TAG_Load:3346`; `CboRptType_SelectedIndexChanged:9740` |
| `RP_TAG_ESTMATE` — `unified/src/csharp/DataCareNext/RP_TAG_ESTMATE.cs` | P10 | 5 / 0 | /reports/report-layouts | `BILL_TOTAL:3436`; `BtnSave_Click:3542`; `BtnDelete_Click:3555`; `RP_TAG_ESTMATE_Load:3559`; `Mobile_image_Save:4821`; `BtnSLImageDelete_Click:5066`; `SaveJPGWithCompressionSetting:5248`; `LoadImageSafe:6172` |
| `RP_TAG_IMAGE` — `unified/src/csharp/DataCareNext/RP_TAG_IMAGE.cs` | P10 | 11 / 0 | /reports/report-layouts | `BtnSave_Click:3513`; `BtnDelete_Click:3985`; `RP_TAG_IMAGE_Load:3989`; `BtnImgSelect_Click:4630`; `Mobile_image_Save:4829`; `cboItemTyp_SelectedIndexChanged:5778`; `chkItSelect_Click:5819` |
| `RP_TAX` — `unified/src/csharp/DataCareNext/RP_TAX.cs` | P10 | 7 / 0 | /reports/hsn-summary; /reports/gst-input-register | `RP_TAX_Load:1570` |
| `RP_TOUR_ZOOM` — `unified/src/csharp/DataCareNext/RP_TOUR_ZOOM.cs` | P10 | 8 / 0 | /reports/report-layouts | `RP_TOUR_ZOOM_Load:4480`; `BtnSave_Click:4846` |
| `RP_TRADING` — `unified/src/csharp/DataCareNext/RP_TRADING.cs` | P10 | 5 / 0 | /reports/report-layouts | `BtnSave_Click:1853`; `BtnDelete_Click:2153`; `RP_TRADING_Load:2157`; `BrnGrSelect_Click:3272`; `chkBookSelect_Click:3310` |
| `RP_USER` — `unified/src/csharp/DataCareNext/RP_USER.cs` | P10 | 6 / 0 | /reports/report-layouts | `BtnSave_Click:2550`; `RP_USER_Load:2568` |
| `TR_AC_OPBL` — `unified/src/csharp/DataCareNext/TR_AC_OPBL.cs` | P06 | 9 / 20 | /txn/ac-opbl; /masters/opening-balance | `TR_AC_OPBL_Load:1992`; `BtnSave_Click:2635`; `BtnDelete_Click:2855`; `CboBalType_SelectedIndexChanged:3258` |
| `TR_APR_ISU` — `unified/src/csharp/DataCareNext/TR_APR_ISU.cs` | P05 | 9 / 64 | /txn/tour; /txn/tour-return; /txn/sales-order | `TR_APR_ISU_Load:5355`; `BtnSave_Click:6007`; `BtnDelete_Click:6608` |
| `TR_BILL_TO` — `unified/src/csharp/DataCareNext/TR_BILL_TO.cs` | P06 | 7 / 40 | /txn/bill-to-bill | `BILL_TOTAL:3416`; `TR_BILL_TO_Load:3899`; `BtnSave_Click:4655`; `BtnDelete_Click:5010` |
| `TR_BUL_BOOKING` — `unified/src/csharp/DataCareNext/TR_BUL_BOOKING.cs` | P06 | 6 / 15 | /txn/bullion | `TempSave:2416`; `TR_BUL_BOOKING_Load:2479`; `BtnSave_Click:2967`; `BtnDelete_Click:3240` |
| `TR_BUL_SALE` — `unified/src/csharp/DataCareNext/TR_BUL_SALE.cs` | P06 | 27 / 93 | /txn/bullion; /txn/rate-cut | `TR_BUL_SALE_Load:7733`; `BtnSave_Click:8716`; `BtnDelete_Click:9183`; `BILL_TOTAL:10515` |
| `TR_CARD_REC` — `unified/src/csharp/DataCareNext/TR_CARD_REC.cs` | P06 | 15 / 0 | /txn/receipt; /txn/payment; /txn/batch-receipt | `TR_CARD_REC_Load:2813`; `BtnSave_Click:3192`; `BtnDelete_Click:3381`; `BILL_TOTAL:3792` |
| `TR_CASH` — `unified/src/csharp/DataCareNext/TR_CASH.cs` | P06 | 7 / 11 | /txn/receipt; /txn/payment; /txn/batch-receipt | `TR_CASH_Load:2344`; `BtnSave_Click:2877`; `BtnDelete_Click:3200` |
| `TR_CONTRA` — `unified/src/csharp/DataCareNext/TR_CONTRA.cs` | P06 | 5 / 8 | /txn/contra; /txn/journal | `TR_CONTRA_Load:2082`; `BtnSave_Click:2636`; `BtnDelete_Click:2944` |
| `TR_DHRN_INTREC` — `unified/src/csharp/DataCareNext/TR_DHRN_INTREC.cs` | P09 | 28 / 0 | /txn/dhrn-interest | `TR_DHRN_INTREC_Load:4084`; `BtnSave_Click:4634`; `BtnDelete_Click:4857`; `BILL_TOTAL:5339`; `CboIntMonth_SelectedIndexChanged:6249` |
| `TR_DHRN_ISU` — `unified/src/csharp/DataCareNext/TR_DHRN_ISU.cs` | P09 | 25 / 16 | /txn/dhrn-issue | `TR_DHRN_ISU_Load:4433`; `BtnSave_Click:5083`; `BtnDelete_Click:5493`; `BILL_TOTAL:6089` |
| `TR_DHRN_REC` — `unified/src/csharp/DataCareNext/TR_DHRN_REC.cs` | P09 | 28 / 17 | /txn/dhrn-receipt | `TR_DHRN_REC_Load:5377`; `BtnSave_Click:6049`; `BtnDelete_Click:6348`; `BILL_TOTAL:6879`; `cboLoanType_SelectedIndexChanged:8060` |
| `TR_EMP_JV` — `unified/src/csharp/DataCareNext/TR_EMP_JV.cs` | P06 | 5 / 19 | /txn/employee-jv | `TR_EMP_JV_Load:2361`; `BtnSave_Click:2799`; `BtnDelete_Click:3015` |
| `TR_FINE_SL_PR` — `unified/src/csharp/DataCareNext/TR_FINE_SL_PR.cs` | P06 | 7 / 31 | /txn/fine-sale | `BILL_TOTAL:2864`; `TR_FINE_SL_PR_Load:3615`; `BtnSave_Click:4393`; `BtnDelete_Click:4799` |
| `TR_FN_INOUT` — `unified/src/csharp/DataCareNext/TR_FN_INOUT.cs` | P06 | 10 / 61 | /txn/fine-inout | `TempSave:5022`; `TR_FN_INOUT_Load:5359`; `BtnSave_Click:6061`; `BtnDelete_Click:7011`; `BILL_TOTAL:8491` |
| `TR_GOLD_BOOK` — `unified/src/csharp/DataCareNext/TR_GOLD_BOOK.cs` | P06 | 5 / 14 | /txn/gold-book | `TR_GOLD_BOOK_Load:2099`; `BtnSave_Click:2562`; `BtnDelete_Click:2741` |
| `TR_INOUT` — `unified/src/csharp/DataCareNext/TR_INOUT.cs` | P06 | 9 / 65 | /txn/fine-inout | `TR_INOUT_Load:4989`; `BtnSave_Click:5675`; `Mobile_image_Save:10760`; `BtnDelete_Click:10838` |
| `TR_ITM_LOT` — `unified/src/csharp/DataCareNext/TR_ITM_LOT.cs` | P07 | 5 / 29 | /txn/item-lot | `TR_ITM_LOT_Load:3260`; `BtnSave_Click:3691`; `BtnDelete_Click:3908` |
| `TR_ITM_OPBL` — `unified/src/csharp/DataCareNext/TR_ITM_OPBL.cs` | P07 | 2 / 19 | /txn/item-opening | `TR_ITM_OPBL_Load:1032`; `BtnSave_Click:1380`; `BtnDelete_Click:1492` |
| `TR_JDT_REC` — `unified/src/csharp/DataCareNext/TR_JDT_REC.cs` | P08 | 10 / 58 | /txn/jobwork-issue; /txn/jobwork-receive | `TR_JDT_REC_Load:5320`; `BtnSave_Click:5999`; `BtnDelete_Click:6415`; `BILL_TOTAL:7883`; `Mobile_image_Save:8194` |
| `TR_KR_ISU` — `unified/src/csharp/DataCareNext/TR_KR_ISU.cs` | P08 | 16 / 36 | /txn/karigar-issue | `TR_KR_ISU_Load:4189`; `BtnSave_Click:4928`; `BtnDelete_Click:5356`; `BILL_TOTAL:6517` |
| `TR_LEDR_ADJ` — `unified/src/csharp/DataCareNext/TR_LEDR_ADJ.cs` | P06 | 7 / 9 | /txn/ledger-adjust; /txn/fine-jv | `TR_LEDR_ADJ_Load:2318`; `BtnSave_Click:2830`; `BtnDelete_Click:3136` |
| `TR_LOCT_AMT` — `unified/src/csharp/DataCareNext/TR_LOCT_AMT.cs` | P06 | 7 / 8 | /txn/location-amount | `TR_LOCT_AMT_Load:2531`; `BtnSave_Click:3026`; `BtnDelete_Click:3441` |
| `TR_MEMB_ADJ` — `unified/src/csharp/DataCareNext/TR_MEMB_ADJ.cs` | P09 | 4 / 18 | /txn/membership; /txn/scheme; /reports/scheme-adjustments | `TR_MEMB_ADJ_Load:2125`; `BtnSave_Click:2639`; `BtnDelete_Click:2860` |
| `TR_MEMB_ENT` — `unified/src/csharp/DataCareNext/TR_MEMB_ENT.cs` | P09 | 10 / 18 | /txn/membership; /txn/scheme | `TR_MEMB_ENT_Load:3877`; `BtnSave_Click:4449`; `BtnDelete_Click:4783` |
| `TR_MFG_GHAT_REC` — `unified/src/csharp/DataCareNext/TR_MFG_GHAT_REC.cs` | P08 | 10 / 28 | /txn/mfg-receive | `TR_MFG_GHAT_REC_Load:3893`; `BtnSave_Click:4465`; `BtnDelete_Click:4862`; `BILL_TOTAL:5915` |
| `TR_MFG_ISU_REC` — `unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs` | P08 | 11 / 43 | /txn/mfg-issue; /txn/mfg-receive | `TR_MFG_ISU_REC_Load:4931`; `BtnSave_Click:5662`; `BtnDelete_Click:6072`; `BILL_TOTAL:7395` |
| `TR_MFG_ITEM` — `unified/src/csharp/DataCareNext/TR_MFG_ITEM.cs` | P08 | 10 / 42 | /txn/mfg-issue; /txn/mfg-receive | `TR_MFG_ITEM_Load:6306`; `BtnSave_Click:7164`; `BtnDelete_Click:7556`; `BILL_TOTAL:8894` |
| `TR_MFG_KR_ISU_REC` — `unified/src/csharp/DataCareNext/TR_MFG_KR_ISU_REC.cs` | P08 | 12 / 89 | /txn/karigar-issue; /txn/karigar-receive; /txn/mfg-issue; /txn/mfg-receive | `TR_MFG_KR_ISU_REC_Load:8513`; `BtnSave_Click:9369`; `BtnDelete_Click:9918`; `BILL_TOTAL:11313` |
| `TR_MFG_ORD_ISU` — `unified/src/csharp/DataCareNext/TR_MFG_ORD_ISU.cs` | P08 | 8 / 74 | /txn/mfg-order-issue | `TR_MFG_ORD_ISU_Load:5164`; `BtnSave_Click:5778`; `BtnDelete_Click:6260` |
| `TR_MFG_ORD_REC` — `unified/src/csharp/DataCareNext/TR_MFG_ORD_REC.cs` | P08 | 11 / 75 | /txn/mfg-receive | `TR_MFG_ORD_REC_Load:5867`; `BtnSave_Click:6577`; `BtnDelete_Click:7141`; `BILL_TOTAL:8732` |
| `TR_MFG_WITH_LOT` — `unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs` | P08 | 10 / 50 | /txn/mfg-receive | `TR_MFG_WITH_LOT_Load:5205`; `BtnSave_Click:5855`; `BtnDelete_Click:6304`; `BILL_TOTAL:7646` |
| `TR_MLT_PRO` — `unified/src/csharp/DataCareNext/TR_MLT_PRO.cs` | P08 | 9 / 28 | /txn/melting | `BILL_TOTAL:3055`; `TR_MLT_PRO_Load:3583`; `BtnSave_Click:4048`; `BtnDelete_Click:4494` |
| `TR_OTH_COMM` — `unified/src/csharp/DataCareNext/TR_OTH_COMM.cs` | P04 | 10 / 21 | /txn/other-commission | `TR_OTH_COMM_Load:2785`; `BtnSave_Click:3425`; `BtnDelete_Click:3709`; `BILL_TOTAL:4731` |
| `TR_OTH_PURC` — `unified/src/csharp/DataCareNext/TR_OTH_PURC.cs` | P04 | 11 / 21 | /txn/other-purchase | `TR_OTH_PURC_Load:2944`; `BtnSave_Click:3602`; `BtnDelete_Click:3887`; `BILL_TOTAL:4988` |
| `TR_PHYSTK` — `unified/src/csharp/DataCareNext/TR_PHYSTK.cs` | P07 | 5 / 27 | /txn/physical-stock | `TR_PHYSTK_Load:3150`; `BtnSave_Click:3672`; `BtnDelete_Click:4050` |
| `TR_PR_SL_HEDG` — `unified/src/csharp/DataCareNext/TR_PR_SL_HEDG.cs` | P06 | 9 / 9 | /txn/rate-cut | `BILL_TOTAL:2128`; `TR_PR_SL_HEDG_Load:2743`; `BtnSave_Click:3382`; `BtnDelete_Click:3661` |
| `TR_PR_SL_UAE` — `unified/src/csharp/DataCareNext/TR_PR_SL_UAE.cs` | P00 / P13 | 26 / 69 | No route inferred; classify helper/caller behavior | `TR_PR_SL_UAE_Load:6873`; `BtnSave_Click:7962`; `BtnDelete_Click:8534`; `BILL_TOTAL:9960`; `btnBillSelect_Click:10313` |
| `TR_PURC` — `unified/src/csharp/DataCareNext/TR_PURC.cs` | P04 | 30 / 153 | /txn/purchase; /txn/purchase-return | `TR_PURC_Load:11309`; `BtnSave_Click:12773`; `BtnDelete_Click:13824`; `BILL_TOTAL:15477`; `Mobile_image_Save:16036`; `btnBillSelect_Click:16474` |
| `TR_PURC_HM` — `unified/src/csharp/DataCareNext/TR_PURC_HM.cs` | P04 | 21 / 89 | /txn/purchase-hm | `TR_PURC_HM_Load:6556`; `BtnSave_Click:7711`; `BtnDelete_Click:8580`; `BILL_TOTAL:9982`; `btnBillSelect_Click:10356` |
| `TR_REP_REC` — `unified/src/csharp/DataCareNext/TR_REP_REC.cs` | P05 | 15 / 28 | /txn/repair-receipt; /txn/repair-karigar-issue; /txn/repair-karigar-receipt; /txn/repair-customer-issue | `TR_REP_REC_Load:3869`; `BtnSave_Click:4563`; `BtnDelete_Click:4936`; `BILL_TOTAL:6048` |
| `TR_SALE` — `unified/src/csharp/DataCareNext/TR_SALE.cs` | P05 | 31 / 109 | /txn/sales | `TR_SALE_Load:13222`; `BtnSave_Click:14885`; `BtnDelete_Click:16299`; `BILL_TOTAL:19189` |
| `TR_SALE_HM` — `unified/src/csharp/DataCareNext/TR_SALE_HM.cs` | P05 | 25 / 95 | /txn/hallmark-sale | `TR_SALE_HM_Load:9655`; `BtnSave_Click:10887`; `BtnDelete_Click:11745`; `BILL_TOTAL:13812` |
| `TR_SALE_LBR` — `unified/src/csharp/DataCareNext/TR_SALE_LBR.cs` | P05 | 21 / 100 | /txn/labour-sale | `TR_SALE_LBR_Load:7887`; `BtnSave_Click:9110`; `BtnDelete_Click:9925`; `BILL_TOTAL:11582` |
| `TR_SALE_ORD` — `unified/src/csharp/DataCareNext/TR_SALE_ORD.cs` | P05 | 21 / 91 | /txn/sales-order; /txn/order-cancel | `TR_SALE_ORD_Load:7938`; `BtnSave_Click:8925`; `BtnDelete_Click:9654`; `BILL_TOTAL:11337`; `Mobile_image_Save:11587` |
| `TR_SALE_RTN` — `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | P05 | 12 / 125 | /txn/sale-return | `TR_SALE_RTN_Load:9513`; `BtnSave_Click:10549`; `BtnDelete_Click:15059`; `BILL_TOTAL:16381` |
| `TR_SALE_RTN_UAE` — `unified/src/csharp/DataCareNext/TR_SALE_RTN_UAE.cs` | P00 / P13 | 20 / 74 | No route inferred; classify helper/caller behavior | `TR_SALE_RTN_UAE_Load:7608`; `BtnSave_Click:8545`; `BtnDelete_Click:9251`; `BILL_TOTAL:10713` |
| `TR_SL_EBILL` — `unified/src/csharp/DataCareNext/TR_SL_EBILL.cs` | P05 | 12 / 54 | /utilities/e-invoice | `TR_SL_EBILL_Load:6520`; `BtnSave_Click:7366`; `BtnDelete_Click:7857`; `BILL_TOTAL:9062` |
| `TR_SL_ORD_ADJ` — `unified/src/csharp/DataCareNext/TR_SL_ORD_ADJ.cs` | P05 | 5 / 24 | /txn/sales-order; /txn/order-cancel | `TR_SL_ORD_ADJ_Load:2852`; `BtnSave_Click:3410`; `BtnDelete_Click:3726` |
| `TR_SL_PR_ITEM` — `unified/src/csharp/DataCareNext/TR_SL_PR_ITEM.cs` | P05 | 10 / 58 | /txn/rate-cut | `TR_SL_PR_ITEM_Load:5442`; `BtnSave_Click:6352`; `BtnDelete_Click:6877`; `BILL_TOTAL:8370` |
| `TR_TAG_CAN` — `unified/src/csharp/DataCareNext/TR_TAG_CAN.cs` | P07 | 7 / 63 | /txn/tag-cancel | `TR_TAG_CAN_Load:4365`; `BtnSave_Click:4942`; `BtnDelete_Click:5331` |
| `TR_TAG_OPBL` — `unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs` | P07 | 18 / 104 | /txn/tag-opening | `TempSave:9223`; `TR_TAG_OPBL_Load:9791`; `BtnSave_Click:10724`; `BtnDelete_Click:11359`; `Mobile_image_Save:12503`; `CboDataType_SelectedIndexChanged:13451` |
| `TR_TAG_SPLIT` — `unified/src/csharp/DataCareNext/TR_TAG_SPLIT.cs` | P07 | 27 / 184 | /txn/tag-split | `TR_TAG_SPLIT_Load:8840`; `BtnSave_Click:9960`; `Mobile_image_Save:10774`; `BtnDelete_Click:10871`; `BILL_TOTAL:12200` |
| `TR_TAG_WT_DIFF` — `unified/src/csharp/DataCareNext/TR_TAG_WT_DIFF.cs` | P07 | 21 / 103 | /txn/tag-weight-diff | `TR_TAG_WT_DIFF_Load:6812`; `BtnSave_Click:7819`; `Mobile_image_Save:8453`; `BtnDelete_Click:8517`; `BILL_TOTAL:9868` |
| `TR_TOUR` — `unified/src/csharp/DataCareNext/TR_TOUR.cs` | P05 | 7 / 55 | /txn/tour | `TR_TOUR_Load:4416`; `BtnSave_Click:4992`; `BtnDelete_Click:5348` |
| `TR_TOUR_ORD` — `unified/src/csharp/DataCareNext/TR_TOUR_ORD.cs` | P05 | 19 / 81 | /txn/tour; /txn/tour-return; /txn/sales-order | `TR_TOUR_ORD_Load:6270`; `BtnSave_Click:7118`; `BtnDelete_Click:7702`; `BILL_TOTAL:9344` |
| `TR_TOUR_SALE` — `unified/src/csharp/DataCareNext/TR_TOUR_SALE.cs` | P05 | 34 / 122 | /txn/tour; /txn/tour-return; /txn/sales-order | `TR_TOUR_SALE_Load:9450`; `BtnSave_Click:10585`; `BtnDelete_Click:11362`; `BILL_TOTAL:12996`; `cboItemTyp_SelectedIndexChanged:14049` |
| `TR_UPI_REC` — `unified/src/csharp/DataCareNext/TR_UPI_REC.cs` | P06 | 1 / 6 | /txn/receipt; /txn/payment; /txn/batch-receipt | `TR_UPI_REC_Load:1095`; `BtnSave_Click:1305` |
| `TR_VP` — `unified/src/csharp/DataCareNext/TR_VP.cs` | P05 | 15 / 65 | /txn/vp-parcel | `TR_VP_Load:4725`; `BtnSave_Click:5505`; `BtnDelete_Click:5860`; `BILL_TOTAL:6935` |
| `TR_VP_ADJ` — `unified/src/csharp/DataCareNext/TR_VP_ADJ.cs` | P05 | 5 / 8 | /txn/vp-adjustment | `TR_VP_ADJ_Load:2078`; `BtnSave_Click:2557`; `BtnDelete_Click:2737` |
| `TR_WH_SALE` — `unified/src/csharp/DataCareNext/TR_WH_SALE.cs` | P05 | 41 / 129 | /txn/wholesale-sale | `TR_WH_SALE_Load:11451`; `BtnSave_Click:12756`; `BtnDelete_Click:13552`; `LoadImageNoLock:14108`; `BILL_TOTAL:15369` |
| `TR_WH_SALE_RTN` — `unified/src/csharp/DataCareNext/TR_WH_SALE_RTN.cs` | P05 | 18 / 96 | /txn/wholesale-sale-return | `TR_WH_SALE_RTN_Load:6188`; `BtnSave_Click:7116`; `Mobile_image_Save:7831`; `BtnDelete_Click:7907`; `BILL_TOTAL:9101` |
| `TagOthDetail` — `unified/src/csharp/DataCareNext/TagOthDetail.cs` | P00 / P01 / P02 | 0 / 0 | /txn/stock; /reports/tag-stock |  |
| `Translator` — `unified/src/csharp/DataCareNext/Translator.cs` | P00 / P01 / P02 | 0 / 0 | No route inferred; classify helper/caller behavior | `Translate:31`; `LanguageEnumToIdentifier:107`; `EnsureInitialized:115` |
| `UT_AI_TRFR` — `unified/src/csharp/DataCareNext/UT_AI_TRFR.cs` | P11 / P12 | 4 / 0 | /txn/tag-transfer; /txn/counter-transfer | `UT_AI_TRFR_Load:1903`; `LoadImagesAsync:2447`; `SaveSingleTileImageAsync:2585`; `btnSaveUae_Click:2830` |
| `UT_BANK` — `unified/src/csharp/DataCareNext/UT_BANK.cs` | P11 / P12 | 4 / 12 | /txn/bank-recon | `UT_BANK_Load:1415`; `BtnSave_Click:1715`; `BtnDelete_Click:1803` |
| `UT_BKP` — `unified/src/csharp/DataCareNext/UT_BKP.cs` | P11 / P12 | 0 / 0 | /backup | `BtnSave_Click:938`; `UT_BKP_Load:942`; `BtnDelete_Click:1193` |
| `UT_CUST_ENTRY` — `unified/src/csharp/DataCareNext/UT_CUST_ENTRY.cs` | P11 / P12 | 5 / 15 | /masters/party | `LastRowSave:2064`; `UT_CUST_ENTRY_Load:2138`; `BtnSave_Click:2462`; `BtnDelete_Click:2588` |
| `UT_EXPORT` — `unified/src/csharp/DataCareNext/UT_EXPORT.cs` | P11 / P12 | 0 / 0 | /backup; /masters/accounts | `UT_EXPORT_Load:835` |
| `UT_E_INVOICE` — `unified/src/csharp/DataCareNext/UT_E_INVOICE.cs` | P11 / P12 | 2 / 0 | /utilities/e-invoice | `BtnSave_Click:1465`; `UT_E_INVOICE_Load:1734` |
| `UT_HDD` — `unified/src/csharp/DataCareNext/UT_HDD.cs` | P11 / P12 | 1 / 0 | /utilities/hdd-registry | `UT_HDD_Load:654` |
| `UT_IMPORT` — `unified/src/csharp/DataCareNext/UT_IMPORT.cs` | P11 / P12 | 1 / 0 | /backup; /masters/accounts | `UT_IMPORT_Load:3211`; `BtnDelete_Click:3453`; `AprTag_Delete_NotIn_Stock:6434`; `AcLdrZeroDelete:6471` |
| `UT_PWD_UPDATE` — `unified/src/csharp/DataCareNext/UT_PWD_UPDATE.cs` | P11 / P12 | 1 / 0 | /login | `UT_HDD_Load:645`; `BtnSave_Click:697` |
| `UT_REMINDER` — `unified/src/csharp/DataCareNext/UT_REMINDER.cs` | P11 / P12 | 4 / 5 | /utilities/reminders; /utilities/reminder-entry; /txn/reminders | `UT_REMINDER_Load:1648`; `BtnSave_Click:2033`; `BtnDelete_Click:2211` |
| `UT_REPORT` — `unified/src/csharp/DataCareNext/UT_REPORT.cs` | P11 / P12 | 0 / 0 | /reports/report-layouts | `UT_REPORT_Load:465` |
| `UT_SETTING` — `unified/src/csharp/DataCareNext/UT_SETTING.cs` | P11 / P12 | 2 / 6 | /settings; /admin/users | `UT_SETTING_Load:4054` |
| `UT_SETTING_MAIN` — `unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs` | P11 / P12 | 1 / 0 | /settings; /admin/users | `UT_SETTING_MAIN_Load:8128`; `BtnTagRowSave_Click:9243` |
| `UT_SET_ADMIN` — `unified/src/csharp/DataCareNext/UT_SET_ADMIN.cs` | P11 / P12 | 0 / 0 | /settings; /admin/users | `UT_SET_ADMIN_Load:2158` |
| `UT_SMS` — `unified/src/csharp/DataCareNext/UT_SMS.cs` | P11 / P12 | 8 / 0 | /integrations | `UT_SMS_Load:3070`; `CboSmsType_SelectedIndexChanged:3235`; `BtnSave_Click:3664`; `BtnDelete_Click:3734`; `CboBarth_SelectedIndexChanged:4041` |
| `UT_TAG_PRINT` — `unified/src/csharp/DataCareNext/UT_TAG_PRINT.cs` | P07 / P10 / P11 | 6 / 49 | /txn/tag-print | `TR_TAG_CAN_Load:4735`; `BtnSave_Click:5073`; `BtnDelete_Click:5097` |
| `UT_USER_REQUEST` — `unified/src/csharp/DataCareNext/UT_USER_REQUEST.cs` | P11 / P12 | 0 / 0 | /utilities/user-request | `BtnSave_Click:382`; `UT_USER_REQUEST_Load:409` |
| `UT_VCH_RE_NUMBR` — `unified/src/csharp/DataCareNext/UT_VCH_RE_NUMBR.cs` | P11 / P12 | 1 / 0 | /utilities/voucher-renumber | `UT_VCH_RE_NUMBR_Load:1477` |
| `UT_WAPP_WITH_API` — `unified/src/csharp/DataCareNext/UT_WAPP_WITH_API.cs` | P11 / P12 | 9 / 0 | /integrations | `UT_WAPP_WITH_API_Load:2785`; `SaveWebhookToDatabase:3241`; `LoadTemplates:3435`; `cboTemplate_SelectedIndexChanged:3484`; `CboSmsType_SelectedIndexChanged:3780`; `BtnSave_Click:4223`; `BtnDelete_Click:4232`; `CboBarth_SelectedIndexChanged:4555` |
| `UT_WEB_CAM` — `unified/src/csharp/DataCareNext/UT_WEB_CAM.cs` | P11 / P12 | 0 / 0 | No route inferred; classify helper/caller behavior | `BtnSave_Click:229`; `UT_WEB_CAM_Load:247` |
| `UT_WHATSAPP` — `unified/src/csharp/DataCareNext/UT_WHATSAPP.cs` | P11 / P12 | 10 / 0 | /integrations | `UT_WHATSAPP_Load:3672`; `CboSmsType_SelectedIndexChanged:4883`; `BtnSave_Click:5326`; `BtnDelete_Click:5396`; `CboBarth_SelectedIndexChanged:5765`; `CboMsgType_SelectedIndexChanged:6656` |
| `UT_WINDOW` — `unified/src/csharp/DataCareNext/UT_WINDOW.cs` | P11 / P12 | 0 / 0 | /utilities/window-tiles | `UT_WINDOW_Load:1178` |

## All 198 retained menu mappings

Every row has open whole-menu acceptance. Shared routes must carry the correct alias/book/constructor/mode. Cross-check dispatcher and hidden callers before treating this retained list as the complete reachable menu universe.

| Desktop tab / menu | Source units | Declared web surface | Acceptance |
|---|---|---|---|
| Analysis / Bill Os Day | RP_INOUT | GET /reports/outstanding | implemented-unverified |
| Analysis / Delete Data | RP_ORDER | GET /reports/delete-data | implemented-unverified |
| Analysis / Last Visit | RP_CUST | GET /reports/last-visit | implemented-unverified |
| Analysis / Order Zoom | RP_ORDER | GET /reports/order-lot-zoom | implemented-unverified |
| Analysis / Party InOut | RP_INOUT | GET /reports/party-statement | implemented-unverified |
| Analysis / Stock Ledger | RP_INOUT | GET /reports/item-stock-ledger | implemented-unverified |
| Analysis / Stock Move | RP_STK_MOVE | GET /reports/size-movement | implemented-unverified |
| Analysis / Tag Detail | RP_TAG | GET /reports/tag-stock | implemented-unverified |
| Company / Account Group | MS_AC_GROUP | ac-groups | implemented-unverified |
| Company / Admin Setting | UT_SET_ADMIN | GET /settings | implemented-unverified |
| Company / Balance TrFr | BtmSchm | POST /balance-transfer/preview | implemented-unverified |
| Company / Books | MS_BOOK | books | implemented-unverified |
| Company / Company | MS_COMPANY | companies | implemented-unverified |
| Company / Data Backup | UT_BKP | GET /backup | implemented-unverified |
| Company / Data Refresh | MS_UPDATE | GET /utilities/data-repair/operations | implemented-unverified |
| Company / Location | MS_LOCT | locations | implemented-unverified |
| Company / Main Menu |  | web/apps/web/app/(app)/dashboard/page.tsx | implemented-unverified |
| Company / Menu Set | MS_WINDOW_SET | GET /utilities/window-tiles | implemented-unverified |
| Company / Setting | UT_SETTING | GET /settings | implemented-unverified |
| Company / Setting Main | UT_SETTING_MAIN | GET /settings | implemented-unverified |
| Company / Trade Master | MS_TRADE | trade | implemented-unverified |
| Company / User Create | MS_USER | GET /admin/users | implemented-unverified |
| Company / Year Create | MS_YEAR | POST /years | implemented-unverified |
| Company / Year Select |  | POST /context/select | implemented-unverified |
| Crm / Cust Entry | RP_CUST_CRM | GET /reports/customer-crm | implemented-unverified |
| Crm / Cust Report | RP_CUST_CRM | GET /reports/customer-crm | implemented-unverified |
| Dhiran / Dhiran Report | RP_DHRN_LOAN | GET /reports/dhiran-report | implemented-unverified |
| Dhiran / Dhrn Due | RP_DHRN_OS | GET /reports/dhrn-outstanding | implemented-unverified |
| Dhiran / Dhrn Issue | TR_DHRN_ISU | POST /dhrn/issue | implemented-unverified |
| Dhiran / Dhrn Os Letter | TR_DHRN_INTREC | GET /dhrn/khata | implemented-unverified |
| Dhiran / Dhrn Rec | TR_DHRN_REC | POST /dhrn/receipt | implemented-unverified |
| Dhiran / Intrest All | RP_DHRN_OS | GET /reports/dhrn-outstanding | implemented-unverified |
| Dhiran / Intrest Isu All | RP_DHRN_OS | GET /reports/dhrn-outstanding | implemented-unverified |
| Dhiran / Intrest Rec | TR_DHRN_INTREC | POST /dhrn/interest | implemented-unverified |
| Dhiran / Loan Intrest | TR_DHRN_INTREC | POST /dhrn/interest | implemented-unverified |
| Dhiran / Loan Issue | TR_DHRN_REC | POST /loan/issue | implemented-unverified |
| Dhiran / Loan Received | TR_DHRN_ISU | POST /loan/received | implemented-unverified |
| Dhiran / Loan Report | RP_DHRN_LOAN | GET /reports/loan-report | implemented-unverified |
| ExtraTran / Amt In | TR_LOCT_AMT | POST /finance/location-amount | implemented-unverified |
| ExtraTran / Amt Out | TR_LOCT_AMT | POST /finance/location-amount | implemented-unverified |
| ExtraTran / Approval Isu | TR_APR_ISU | POST /tour/issue | implemented-unverified |
| ExtraTran / Approval Rtn | TR_APR_ISU | POST /tour/return | implemented-unverified |
| ExtraTran / Bill Wise Rec | TR_BILL_TO | POST /bill-to-bill/settle | implemented-unverified |
| ExtraTran / Card Rec | TR_CARD_REC | POST /receipts | implemented-unverified |
| ExtraTran / Consi Isu | TR_APR_ISU | POST /tour/issue | implemented-unverified |
| ExtraTran / Consi Purc | TR_PR_SL_UAE | POST /consignment-purchases | implemented-unverified |
| ExtraTran / Consi Rec | TR_APR_ISU | POST /tour/return | implemented-unverified |
| ExtraTran / Employee Jv | TR_EMP_JV | POST /employee-jv | implemented-unverified |
| ExtraTran / Fine Jv Entry | TR_CONTRA | POST /fine-jv | implemented-unverified |
| ExtraTran / Fine Purc | TR_FINE_SL_PR | POST /fine-sale | implemented-unverified |
| ExtraTran / Fine Sales | TR_FINE_SL_PR | POST /fine-sale | implemented-unverified |
| ExtraTran / Labour Work | TR_SALE_LBR | POST /labour-invoice | implemented-unverified |
| ExtraTran / Old Item Sales | TR_PURC | web/apps/web/app/(app)/txn/old-item-sales/page.tsx | implemented-unverified |
| ExtraTran / Other Expenses | TR_OTH_PURC | POST /other-purchase | implemented-unverified |
| ExtraTran / Other Income | TR_OTH_PURC | POST /other-income | implemented-unverified |
| ExtraTran / Service Comm | TR_OTH_COMM | POST /other-commission | implemented-unverified |
| ExtraTran / Tag Wise Purc | TR_PURC_HM | web/apps/web/app/(app)/txn/purchase-hm/page.tsx | implemented-unverified |
| ExtraTran / Vp Adjust | TR_VP_ADJ | POST /finance/vp-adjustment | implemented-unverified |
| ExtraTran / Vp Parcel | TR_VP | POST /sales/vp-parcel | implemented-unverified |
| Karigar / Cust Repar Isu | TR_REP_REC | POST /repair-customer-issues | implemented-unverified |
| Karigar / Cust Repar Rec | TR_REP_REC | POST /repair-receipts | implemented-unverified |
| Karigar / Kr Design Isu | TR_APR_ISU | POST /mfg/order-issue | implemented-unverified |
| Karigar / Kr Issue | TR_KR_ISU | POST /karigar/issue | implemented-unverified |
| Karigar / Kr Received | TR_PURC | POST /karigar/receive | implemented-unverified |
| Karigar / Kr Repar Isu | TR_REP_REC | POST /repair-karigar-issues | implemented-unverified |
| Karigar / Kr Repar Rec | TR_REP_REC | POST /repair-karigar-receipts | implemented-unverified |
| Karigar / Kr Report | RP_ALL | GET /reports/karigar-report | implemented-unverified |
| Karigar / Reparing Rpt | RP_ALL | GET /reports/repair-report | implemented-unverified |
| Karigar / Stock Isu | TR_TOUR | POST /tour/issue | implemented-unverified |
| Karigar / Stock Rec | TR_TOUR | POST /tour/return | implemented-unverified |
| Karigar / Tour Order | TR_SALE_ORD | POST /tour-orders | implemented-unverified |
| Karigar / Tour Report | RP_TOUR_ZOOM | GET /reports/tour-report | implemented-unverified |
| Karigar / Tour Sales | TR_TOUR | POST /tour/:vchNo/bill | implemented-unverified |
| Karigar / Tour Tag | RP_TOUR_ZOOM | GET /reports/tour-tag | implemented-unverified |
| Master / Address | MS_ADD_MAST | addresses | implemented-unverified |
| Master / AutoItem | MS_AUTO_ITEM | POST /masters/auto-item | implemented-unverified |
| Master / Counter | MS_PRODUCT | counters | implemented-unverified |
| Master / Design Book | MS_PRODUCT | GET /masters/design-book | implemented-unverified |
| Master / Diamond | MS_DM | diamonds | implemented-unverified |
| Master / Dm Size | MS_STK_LIMIT | GET /masters/diamond-sizes | implemented-unverified |
| Master / Employee | MS_EMP | employees | implemented-unverified |
| Master / Group | MS_GROUP | groups | implemented-unverified |
| Master / Item | MS_ITEM | items | implemented-unverified |
| Master / Item Opening | TR_ITM_OPBL | POST /stock/item-opening | implemented-unverified |
| Master / Item Touch | MS_AUTO_ITEM | touch | implemented-unverified |
| Master / ItStk Limit | MS_STK_LIMIT | GET /masters/item-stock-limits | implemented-unverified |
| Master / Labour | MS_AUTO_ITEM | GET /labour-update | implemented-unverified |
| Master / Labour Disc | MS_AUTO_ITEM | GET /labour-update | implemented-unverified |
| Master / Labour Type | MS_LBR_TYPE | labour | implemented-unverified |
| Master / Lot Opening | MS_PRODUCT | POST /stock/item-lot | implemented-unverified |
| Master / Party | MS_ACCT | web/apps/web/app/(app)/masters/party/page.tsx | implemented-unverified |
| Master / Party Opening | TR_AC_OPBL | POST /ac-opbl | implemented-unverified |
| Master / Point Mast | MS_POINT | points | implemented-unverified |
| Master / Product | MS_PRODUCT | products | implemented-unverified |
| Master / Style | MS_STYLE | styles | implemented-unverified |
| Master / Tag Opening |  | POST /stock/tag-opening | implemented-unverified |
| Master / Tax | MS_TAX | taxes | implemented-unverified |
| Mfg / Lot IsuRec | RP_MFG_ZOOM | GET /reports/mfg-lot-isurec | implemented-unverified |
| Mfg / Mfg InOut | RP_MFG_ZOOM | GET /reports/mfg-inout | implemented-unverified |
| Mfg / Mfg Ledger | RP_LEDR, RP_MFG_LEDR | GET /reports/mfg-ledger | implemented-unverified |
| Mfg / Mfg Mast | MS_MFG_MAST | mfg | implemented-unverified |
| More / Bill Wise Profit | RP_BILL_PROFIT | GET /reports/bill-profit | implemented-unverified |
| More / Deisgn Move | RP_STK_MOVE | GET /reports/design-move | implemented-unverified |
| More / Emp Sale | RP_EMP | GET /reports/employee-sales | implemented-unverified |
| More / Entry Check | RP_USER | GET /reports/entry-check | implemented-unverified |
| More / Graph Report | RP_GRAPH | GET /reports/graph-report | implemented-unverified |
| More / ItStk Level | RP_STK_LEVEL | GET /reports/item-weight-levels | implemented-unverified |
| More / Lot Report | RP_ORDER | GET /reports/order-lot-zoom | implemented-unverified |
| More / Movement | RP_MOVEMENT | GET /reports/item-stock-ledger | implemented-unverified |
| More / Order Track | RP_ORD_TRACK | GET /reports/order-track | implemented-unverified |
| More / Oth Itm Rpt | RP_OTH_DETL | GET /reports/other-item-report | implemented-unverified |
| More / Point Report | RP_ORDER | GET /reports/point-report | implemented-unverified |
| More / User Report | RP_USER | GET /reports/user-report | implemented-unverified |
| Other / Bank Reconcile | UT_BANK | GET /bank-recon | implemented-unverified |
| Other / Counter Trfr | TR_PHYSTK | POST /stock/counter-transfer | implemented-unverified |
| Other / Daily Rate | MS_RATE | POST /daily-rate | implemented-unverified |
| Other / Data Export | UT_EXPORT | GET /utilities/data-export/preview | implemented-unverified |
| Other / Data Import | UT_IMPORT | POST /masters/:name/import | implemented-unverified |
| Other / E-Excel | UT_E_INVOICE | GET /einvoice/export.xlsx | implemented-unverified |
| Other / Estimate Reset | UT_IMPORT | POST /utilities/estimate-reset/preview | implemented-unverified |
| Other / Labour Update | MS_AUTO_ITEM | GET /labour-update | implemented-unverified |
| Other / Ledger Adjust | UT_E_INVOICE | POST /ledger-adjust | implemented-unverified |
| Other / Only Tag Entry |  | POST /stock/tag-opening | implemented-unverified |
| Other / Order Cancel | TR_SL_ORD_ADJ | POST /sales-orders/:vchNo/cancel-refund | implemented-unverified |
| Other / Physical Stock |  | POST /stock/physical-stock | implemented-unverified |
| Other / Reminder Entry | UT_REMINDER | POST /reminder-entries | implemented-unverified |
| Other / Sms | UT_SMS | POST /integrations/notify | implemented-unverified |
| Other / Stock Adjust | TR_TAG_CAN | POST /stock/adjust | implemented-unverified |
| Other / Stone/Dm-Cf | TR_PHYSTK | POST /stock/stone-dm-cf | implemented-unverified |
| Other / Tag Adjust | TR_TAG_CAN | POST /stock/tag-adjust | implemented-unverified |
| Other / Tag Cancel | UT_TAG_PRINT | POST /stock/tag-cancel | implemented-unverified |
| Other / Tag Print | UT_TAG_PRINT | GET /stock/tag-print | implemented-unverified |
| Other / Tag Split |  | POST /stock/tag-split | implemented-unverified |
| Other / Tag Transfer | TR_TAG_CAN | POST /stock/tag-transfer | implemented-unverified |
| Other / Tag Wt Change |  | POST /stock/tag-weight-diff | implemented-unverified |
| Other / Vch ReNumber | UT_VCH_RE_NUMBR | GET /utilities/vch-renumber/preview | implemented-unverified |
| Other / Whatsapp |  | POST /integrations/notify | implemented-unverified |
| Report / Address Print | RP_ADDRESS | GET /reports/address-print | implemented-unverified |
| Report / Approval Rpt | RP_ALL | GET /reports/approval-report | implemented-unverified |
| Report / Bul Report | RP_ALL | GET /reports/bullion-report | implemented-unverified |
| Report / Cash Bank | RP_CASH_BANK | GET /reports/cash-book | implemented-unverified |
| Report / Consi Report | RP_CONSI_APR | GET /reports/consi-report | implemented-unverified |
| Report / Final Reports | RP_BALANCE | final-reports | implemented-unverified |
| Report / Gst Report | RP_TAX | GET /reports/gst-report | implemented-unverified |
| Report / HuId Report | RP_HUID | GET /reports/tag-stock | implemented-unverified |
| Report / Item InOut | RP_ALL | GET /reports/item-stock-ledger | implemented-unverified |
| Report / Ledger Report | RP_LEDR | GET /reports/account-ledger/:acCode | implemented-unverified |
| Report / Old Stock | RP_SLPR_ZOOM | GET /reports/old-stock | implemented-unverified |
| Report / Order Report | RP_ALL | GET /sales-orders | implemented-unverified |
| Report / Party Os | RP_OS | GET /reports/outstanding | implemented-unverified |
| Report / Purc Zoom | RP_SLPR_ZOOM | GET /reports/purchase-register | implemented-unverified |
| Report / Purchase Rpt | RP_ALL | GET /reports/purchase-register | implemented-unverified |
| Report / Reminder Rpt | MS_RATE, RP_REMINDER | GET /reminders | implemented-unverified |
| Report / Rojmel | RP_ROJMEL | GET /reports/rojmel | implemented-unverified |
| Report / Sale Zoom | RP_SLPR_ZOOM | GET /reports/sales-register | implemented-unverified |
| Report / Sales Report | RP_ALL | GET /reports/sales-register | implemented-unverified |
| Report / Stock Report | RP_STOCK | GET /reports/tag-stock | implemented-unverified |
| Report / Stock With Fine | RP_STOCK_FINE | GET /reports/stock-valuation | implemented-unverified |
| Report / Tag Estmate | RP_TAG_ESTMATE | GET /reports/tag-estimate | implemented-unverified |
| Report / Tag Image | RP_TAG_IMAGE | GET /stock/tag-image | implemented-unverified |
| Report / Tag Stock | RP_TAG | GET /reports/tag-stock | implemented-unverified |
| Report / Trading Report | RP_TRADING | GET /reports/trading-report | implemented-unverified |
| Report / Vp Report | RP_ALL | GET /reports/vp-report | implemented-unverified |
| Scheme / Branch InOut | RP_LC_INOUT | GET /reports/branch-inout | implemented-unverified |
| Scheme / Day Sales | RP_LC_SALE | GET /reports/daily-sales | implemented-unverified |
| Scheme / Gold Adjust | TR_MEMB_ADJ | POST /scheme/gold-adjust | implemented-unverified |
| Scheme / Memb Adjust | TR_MEMB_ADJ | POST /scheme/maturity | implemented-unverified |
| Scheme / Memb Entry | TR_MEMB_ENT | POST /scheme/installment | implemented-unverified |
| Scheme / Memb Opening | TR_MEMB_ENT | POST /scheme/opening | implemented-unverified |
| Scheme / Member Mast | MS_MEMB | POST /members | implemented-unverified |
| Scheme / Monthly Report | RP_STK_LEVEL | GET /reports/scheme-monthly | implemented-unverified |
| Scheme / Scheme Ledger | RP_CASH_BANK | GET /scheme/passbook | implemented-unverified |
| Scheme / Scheme Mast | MS_PRODUCT | schemes | implemented-unverified |
| Scheme / Scheme Report | RP_ALL | GET /reports/scheme-adjustments | implemented-unverified |
| Transaction / Bank Payment | TR_CASH | POST /payments | implemented-unverified |
| Transaction / Bank Received | TR_CASH | POST /receipts | implemented-unverified |
| Transaction / Bul LcBook | TR_BUL_BOOKING | POST /bullion/booking | implemented-unverified |
| Transaction / Bul Sales | TR_BUL_SALE | web/apps/web/app/(app)/txn/bullion-sale/page.tsx | implemented-unverified |
| Transaction / Cash Payment | TR_CASH | POST /payments | implemented-unverified |
| Transaction / Cash Received | TR_CASH | POST /receipts | implemented-unverified |
| Transaction / Contra Entry | TR_CONTRA | POST /contra | implemented-unverified |
| Transaction / E CrntNote | TR_SL_EBILL | POST /einvoice/credit-note/irn | implemented-unverified |
| Transaction / E Invoice | TR_SL_EBILL | POST /einvoice/irn | implemented-unverified |
| Transaction / Pr Quotation | TR_PURC | web/apps/web/app/(app)/txn/purchase-quotation/page.tsx | implemented-unverified |
| Transaction / Purc Booking | TR_BUL_BOOKING | POST /bullion/booking | implemented-unverified |
| Transaction / Purchase | TR_PURC, TR_PURC_HM | POST /purchases | implemented-unverified |
| Transaction / Purchase Rtn | TR_KR_ISU | POST /purchase-returns | implemented-unverified |
| Transaction / Rate Cut | TR_WH_SALE | POST /rate-cut | implemented-unverified |
| Transaction / Sale Booking | TR_BUL_BOOKING | POST /bullion/booking | implemented-unverified |
| Transaction / Sales | TR_SALE_HM | POST /sales | implemented-unverified |
| Transaction / Sales Order | TR_SALE_ORD | POST /sales-orders | implemented-unverified |
| Transaction / Sales Return |  | POST /sales-returns | implemented-unverified |
| Transaction / Sl Quotation | TR_SALE | web/apps/web/app/(app)/txn/sales-quotation/page.tsx | implemented-unverified |
| Transaction / Stock In | TR_INOUT | POST /stock/in | implemented-unverified |
| Transaction / Stock Out | TR_INOUT | POST /stock/out | implemented-unverified |
| Transaction / Wh Quotation | TR_WH_SALE | web/apps/web/app/(app)/txn/wholesale-sale/page.tsx | implemented-unverified |
| Transaction / Wh Sales | TR_WH_SALE | web/apps/web/app/(app)/txn/wholesale-sale/page.tsx | implemented-unverified |
| Transaction / Wh Sl Return | TR_WH_SALE_RTN | POST /sales/wholesale-sale-return | implemented-unverified |

## All 275 report references

The binding labels are historical diagnostics. Inspect current `reportBind.ts` and binding contracts to assign actual status. A pointer-backed binary/spec path is not rendered or physically verified output. Map every template and mode to explicit data/filters/layout/rights and J22.

| Reference | Kind | Desktop binary | Web specification | Required state |
|---|---|---|---|---|
| AcCrList | supplied-crystal | unified/reports/AcCrList.rpt | web/apps/api/report-specs/AcCrList.spec.json | Unverified |
| AcDrList | supplied-crystal | unified/reports/AcDrList.rpt | web/apps/api/report-specs/AcDrList.spec.json | Unverified |
| AcFineGold | supplied-crystal | unified/reports/AcFineGold.rpt | web/apps/api/report-specs/AcFineGold.spec.json | Unverified |
| AcFineSilver | supplied-crystal | unified/reports/AcFineSilver.rpt | web/apps/api/report-specs/AcFineSilver.spec.json | Unverified |
| AcGroupRpt | supplied-crystal | unified/reports/AcGroupRpt.rpt | web/apps/api/report-specs/AcGroupRpt.spec.json | Unverified |
| AcLastVisit | supplied-crystal | unified/reports/AcLastVisit.rpt | web/apps/api/report-specs/AcLastVisit.spec.json | Unverified |
| AcLedger | supplied-crystal | unified/reports/AcLedger.rpt | web/apps/api/report-specs/AcLedger.spec.json | Unverified |
| AcLedgerSelected | supplied-crystal | unified/reports/AcLedgerSelected.rpt | web/apps/api/report-specs/AcLedgerSelected.spec.json | Unverified |
| AcOsArea | supplied-crystal | unified/reports/AcOsArea.rpt | web/apps/api/report-specs/AcOsArea.spec.json | Unverified |
| AcOsWithAdd | supplied-crystal | unified/reports/AcOsWithAdd.rpt | web/apps/api/report-specs/AcOsWithAdd.spec.json | Unverified |
| AcPurcRpt | supplied-crystal | unified/reports/AcPurcRpt.rpt | web/apps/api/report-specs/AcPurcRpt.spec.json | Unverified |
| AcPurcSummRpt | supplied-crystal | unified/reports/AcPurcSummRpt.rpt | web/apps/api/report-specs/AcPurcSummRpt.spec.json | Unverified |
| AcPurcWhRpt | supplied-crystal | unified/reports/AcPurcWhRpt.rpt | web/apps/api/report-specs/AcPurcWhRpt.spec.json | Unverified |
| AcSaleWhRpt | supplied-crystal | unified/reports/AcSaleWhRpt.rpt | web/apps/api/report-specs/AcSaleWhRpt.spec.json | Unverified |
| AcSumm | supplied-crystal | unified/reports/AcSumm.rpt | web/apps/api/report-specs/AcSumm.spec.json | Unverified |
| AcSummLdr | supplied-crystal | unified/reports/AcSummLdr.rpt | web/apps/api/report-specs/AcSummLdr.spec.json | Unverified |
| AcWithWt | supplied-crystal | unified/reports/AcWithWt.rpt | web/apps/api/report-specs/AcWithWt.spec.json | Unverified |
| AcWithWtGold | supplied-crystal | unified/reports/AcWithWtGold.rpt | web/apps/api/report-specs/AcWithWtGold.spec.json | Unverified |
| AcWithWtSumm | supplied-crystal | unified/reports/AcWithWtSumm.rpt | web/apps/api/report-specs/AcWithWtSumm.spec.json | Unverified |
| AngdiyaIsuRpt | supplied-crystal | unified/reports/AngdiyaIsuRpt.rpt | web/apps/api/report-specs/AngdiyaIsuRpt.spec.json | Unverified |
| AprBill | supplied-crystal | unified/reports/AprBill.rpt | web/apps/api/report-specs/AprBill.spec.json | Unverified |
| AprInOut | supplied-crystal | unified/reports/AprInOut.rpt | web/apps/api/report-specs/AprInOut.spec.json | Unverified |
| AprPan | supplied-crystal | unified/reports/AprPan.rpt | web/apps/api/report-specs/AprPan.spec.json | Unverified |
| AprPartyWise | supplied-crystal | unified/reports/AprPartyWise.rpt | web/apps/api/report-specs/AprPartyWise.spec.json | Unverified |
| B2BPurcBillA4Tax | supplied-crystal | unified/reports/B2BPurcBillA4Tax.rpt | web/apps/api/report-specs/B2BPurcBillA4Tax.spec.json | Unverified |
| B2BPurcImgVch | supplied-crystal | unified/reports/B2BPurcImgVch.rpt | web/apps/api/report-specs/B2BPurcImgVch.spec.json | Unverified |
| B2BSaleBillA4Tax | supplied-crystal | unified/reports/B2BSaleBillA4Tax.rpt | web/apps/api/report-specs/B2BSaleBillA4Tax.spec.json | Unverified |
| B2BSaleImgVch | supplied-crystal | unified/reports/B2BSaleImgVch.rpt | web/apps/api/report-specs/B2BSaleImgVch.spec.json | Unverified |
| BalanceHz | supplied-crystal | unified/reports/BalanceHz.rpt | web/apps/api/report-specs/BalanceHz.spec.json | Unverified |
| BarPrint10 | supplied-crystal | unified/reports/BarPrint10.rpt | web/apps/api/report-specs/BarPrint10.spec.json | Unverified |
| BarPrint13 | supplied-crystal | unified/reports/BarPrint13.rpt | web/apps/api/report-specs/BarPrint13.spec.json | Unverified |
| BillRecVch | supplied-crystal | unified/reports/BillRecVch.rpt | web/apps/api/report-specs/BillRecVch.spec.json | Unverified |
| BillWiseOrderAdjust | supplied-crystal | unified/reports/BillWiseOrderAdjust.rpt | web/apps/api/report-specs/BillWiseOrderAdjust.spec.json | Unverified |
| BulCustAdjust | supplied-crystal | unified/reports/BulCustAdjust.rpt | web/apps/api/report-specs/BulCustAdjust.spec.json | Unverified |
| BulCustBooking | supplied-crystal | unified/reports/BulCustBooking.rpt | web/apps/api/report-specs/BulCustBooking.spec.json | Unverified |
| BullBookBill | supplied-crystal | unified/reports/BullBookBill.rpt | web/apps/api/report-specs/BullBookBill.spec.json | Unverified |
| CashBankBill | supplied-crystal | unified/reports/CashBankBill.rpt | web/apps/api/report-specs/CashBankBill.spec.json | Unverified |
| CashBankBillAc | supplied-crystal | unified/reports/CashBankBillAc.rpt | web/apps/api/report-specs/CashBankBillAc.spec.json | Unverified |
| ChqPrint010 | supplied-crystal | unified/reports/ChqPrint010.rpt | web/apps/api/report-specs/ChqPrint010.spec.json | Unverified |
| ChqPrint011 | supplied-crystal | unified/reports/ChqPrint011.rpt | web/apps/api/report-specs/ChqPrint011.spec.json | Unverified |
| ChqPrint012 | supplied-crystal | unified/reports/ChqPrint012.rpt | web/apps/api/report-specs/ChqPrint012.spec.json | Unverified |
| ChqPrint013 | supplied-crystal | unified/reports/ChqPrint013.rpt | web/apps/api/report-specs/ChqPrint013.spec.json | Unverified |
| ChqPrint014 | supplied-crystal | unified/reports/ChqPrint014.rpt | web/apps/api/report-specs/ChqPrint014.spec.json | Unverified |
| ChqPrint135 | supplied-crystal | unified/reports/ChqPrint135.rpt | web/apps/api/report-specs/ChqPrint135.spec.json | Unverified |
| CntrTagStkRpt | supplied-crystal | unified/reports/CntrTagStkRpt.rpt | web/apps/api/report-specs/CntrTagStkRpt.spec.json | Unverified |
| CntrTagSumRpt | supplied-crystal | unified/reports/CntrTagSumRpt.rpt | web/apps/api/report-specs/CntrTagSumRpt.spec.json | Unverified |
| Company | supplied-crystal | unified/reports/Company.rpt | web/apps/api/report-specs/Company.spec.json | Unverified |
| ConsiBill | supplied-crystal | unified/reports/ConsiBill.rpt | web/apps/api/report-specs/ConsiBill.spec.json | Unverified |
| ContraBill | supplied-crystal | unified/reports/ContraBill.rpt | web/apps/api/report-specs/ContraBill.spec.json | Unverified |
| CounterSale | supplied-crystal | unified/reports/CounterSale.rpt | web/apps/api/report-specs/CounterSale.spec.json | Unverified |
| CounterTrfr | supplied-crystal | unified/reports/CounterTrfr.rpt | web/apps/api/report-specs/CounterTrfr.spec.json | Unverified |
| CustRepIsu | supplied-crystal | unified/reports/CustRepIsu.rpt | web/apps/api/report-specs/CustRepIsu.spec.json | Unverified |
| CustRepRec | supplied-crystal | unified/reports/CustRepRec.rpt | web/apps/api/report-specs/CustRepRec.spec.json | Unverified |
| CustRepRecBill | supplied-crystal | unified/reports/CustRepRecBill.rpt | web/apps/api/report-specs/CustRepRecBill.spec.json | Unverified |
| DharnDue | supplied-crystal | unified/reports/DharnDue.rpt | web/apps/api/report-specs/DharnDue.spec.json | Unverified |
| DhiranIssuRec | supplied-crystal | unified/reports/DhiranIssuRec.rpt | web/apps/api/report-specs/DhiranIssuRec.spec.json | Unverified |
| DhiranitemRpt | supplied-crystal | unified/reports/DhiranitemRpt.rpt | web/apps/api/report-specs/DhiranitemRpt.spec.json | Unverified |
| DhiranReg | supplied-crystal | unified/reports/DhiranReg.rpt | web/apps/api/report-specs/DhiranReg.spec.json | Unverified |
| DhiranStock | supplied-crystal | unified/reports/DhiranStock.rpt | web/apps/api/report-specs/DhiranStock.spec.json | Unverified |
| DhrnIntRec | supplied-crystal | unified/reports/DhrnIntRec.rpt | web/apps/api/report-specs/DhrnIntRec.spec.json | Unverified |
| DhrnIssue | supplied-crystal | unified/reports/DhrnIssue.rpt | web/apps/api/report-specs/DhrnIssue.spec.json | Unverified |
| DhrnIssueImg | supplied-crystal | unified/reports/DhrnIssueImg.rpt | web/apps/api/report-specs/DhrnIssueImg.spec.json | Unverified |
| DhrnKhataVahi | supplied-crystal | unified/reports/DhrnKhataVahi.rpt | web/apps/api/report-specs/DhrnKhataVahi.spec.json | Unverified |
| DhrnKhataVahiSumm | supplied-crystal | unified/reports/DhrnKhataVahiSumm.rpt | web/apps/api/report-specs/DhrnKhataVahiSumm.spec.json | Unverified |
| DhrnOsLetter | supplied-crystal | unified/reports/DhrnOsLetter.rpt | web/apps/api/report-specs/DhrnOsLetter.spec.json | Unverified |
| DhrnReceivedSumm | supplied-crystal | unified/reports/DhrnReceivedSumm.rpt | web/apps/api/report-specs/DhrnReceivedSumm.spec.json | Unverified |
| DiamondSf | supplied-crystal | unified/reports/DiamondSf.rpt | web/apps/api/report-specs/DiamondSf.spec.json | Unverified |
| EInvoice | supplied-crystal | unified/reports/EInvoice.rpt | web/apps/api/report-specs/EInvoice.spec.json | Unverified |
| EInvOthIncom | supplied-crystal | unified/reports/EInvOthIncom.rpt | web/apps/api/report-specs/EInvOthIncom.spec.json | Unverified |
| EmpIsuRecVch | supplied-crystal | unified/reports/EmpIsuRecVch.rpt | web/apps/api/report-specs/EmpIsuRecVch.spec.json | Unverified |
| EmpSaleReport | supplied-crystal | unified/reports/EmpSaleReport.rpt | web/apps/api/report-specs/EmpSaleReport.spec.json | Unverified |
| FineJvBill | supplied-crystal | unified/reports/FineJvBill.rpt | web/apps/api/report-specs/FineJvBill.spec.json | Unverified |
| FineSalesGstBill | supplied-crystal | unified/reports/FineSalesGstBill.rpt | web/apps/api/report-specs/FineSalesGstBill.spec.json | Unverified |
| Form12 | supplied-crystal | unified/reports/Form12.rpt | web/apps/api/report-specs/Form12.spec.json | Unverified |
| Form8 | supplied-crystal | unified/reports/Form8.rpt | web/apps/api/report-specs/Form8.spec.json | Unverified |
| GhatDesignIsu | supplied-crystal | unified/reports/GhatDesignIsu.rpt | web/apps/api/report-specs/GhatDesignIsu.spec.json | Unverified |
| GhatTagPrnt | supplied-crystal | unified/reports/GhatTagPrnt.rpt | web/apps/api/report-specs/GhatTagPrnt.spec.json | Unverified |
| GoldInterest | supplied-crystal | unified/reports/GoldInterest.rpt | web/apps/api/report-specs/GoldInterest.spec.json | Unverified |
| GroupStkRpt | supplied-crystal | unified/reports/GroupStkRpt.rpt | web/apps/api/report-specs/GroupStkRpt.spec.json | Unverified |
| Gstr_1 | supplied-crystal | unified/reports/Gstr_1.rpt | web/apps/api/report-specs/Gstr_1.spec.json | Unverified |
| Gstr_2 | supplied-crystal | unified/reports/Gstr_2.rpt | web/apps/api/report-specs/Gstr_2.spec.json | Unverified |
| Gstr_3 | supplied-crystal | unified/reports/Gstr_3.rpt | web/apps/api/report-specs/Gstr_3.spec.json | Unverified |
| HedgingFixVch | supplied-crystal | unified/reports/HedgingFixVch.rpt | web/apps/api/report-specs/HedgingFixVch.spec.json | Unverified |
| InTax_PurcRpt | supplied-crystal | unified/reports/InTax_PurcRpt.rpt | web/apps/api/report-specs/InTax_PurcRpt.spec.json | Unverified |
| ItemInOut | supplied-crystal | unified/reports/ItemInOut.rpt | web/apps/api/report-specs/ItemInOut.spec.json | Unverified |
| ItemInOutSumm | supplied-crystal | unified/reports/ItemInOutSumm.rpt | web/apps/api/report-specs/ItemInOutSumm.spec.json | Unverified |
| ItemInword | supplied-crystal | unified/reports/ItemInword.rpt | web/apps/api/report-specs/ItemInword.spec.json | Unverified |
| ItemLedger | supplied-crystal | unified/reports/ItemLedger.rpt | web/apps/api/report-specs/ItemLedger.spec.json | Unverified |
| ItemOutword | supplied-crystal | unified/reports/ItemOutword.rpt | web/apps/api/report-specs/ItemOutword.spec.json | Unverified |
| ItemPurcVch | supplied-crystal | unified/reports/ItemPurcVch.rpt | web/apps/api/report-specs/ItemPurcVch.spec.json | Unverified |
| ItemSalesVch | supplied-crystal | unified/reports/ItemSalesVch.rpt | web/apps/api/report-specs/ItemSalesVch.spec.json | Unverified |
| ItemSalesVchWithQr | supplied-crystal | unified/reports/ItemSalesVchWithQr.rpt | web/apps/api/report-specs/ItemSalesVchWithQr.spec.json | Unverified |
| ItemStkRpt | supplied-crystal | unified/reports/ItemStkRpt.rpt | web/apps/api/report-specs/ItemStkRpt.spec.json | Unverified |
| ItmLotPrint | supplied-crystal | unified/reports/ItmLotPrint.rpt | web/apps/api/report-specs/ItmLotPrint.spec.json | Unverified |
| ItmStkBalance | supplied-crystal | unified/reports/ItmStkBalance.rpt | web/apps/api/report-specs/ItmStkBalance.spec.json | Unverified |
| ItmStkWithGrid | supplied-crystal | unified/reports/ItmStkWithGrid.rpt | web/apps/api/report-specs/ItmStkWithGrid.spec.json | Unverified |
| ItmStkWithOthWt | supplied-crystal | unified/reports/ItmStkWithOthWt.rpt | web/apps/api/report-specs/ItmStkWithOthWt.spec.json | Unverified |
| JadtarInOut | supplied-crystal | unified/reports/JadtarInOut.rpt | web/apps/api/report-specs/JadtarInOut.spec.json | Unverified |
| JadtarIssue | supplied-crystal | unified/reports/JadtarIssue.rpt | web/apps/api/report-specs/JadtarIssue.spec.json | Unverified |
| JadtarRec | supplied-crystal | unified/reports/JadtarRec.rpt | web/apps/api/report-specs/JadtarRec.spec.json | Unverified |
| JdtProcessRec | supplied-crystal | unified/reports/JdtProcessRec.rpt | web/apps/api/report-specs/JdtProcessRec.spec.json | Unverified |
| JmUdAmt | supplied-crystal | unified/reports/JmUdAmt.rpt | web/apps/api/report-specs/JmUdAmt.spec.json | Unverified |
| JmUdFine | supplied-crystal | unified/reports/JmUdFine.rpt | web/apps/api/report-specs/JmUdFine.spec.json | Unverified |
| JmUdFineHz | supplied-crystal | unified/reports/JmUdFineHz.rpt | web/apps/api/report-specs/JmUdFineHz.spec.json | Unverified |
| JmUdFineHzSumm | supplied-crystal | unified/reports/JmUdFineHzSumm.rpt | web/apps/api/report-specs/JmUdFineHzSumm.spec.json | Unverified |
| JmUdFineHzSummVch | supplied-crystal | unified/reports/JmUdFineHzSummVch.rpt | web/apps/api/report-specs/JmUdFineHzSummVch.spec.json | Unverified |
| JmUdFineSl | supplied-crystal | unified/reports/JmUdFineSl.rpt | web/apps/api/report-specs/JmUdFineSl.spec.json | Unverified |
| JmUdFineSlHz | supplied-crystal | unified/reports/JmUdFineSlHz.rpt | web/apps/api/report-specs/JmUdFineSlHz.spec.json | Unverified |
| JmUdFineSlSum | supplied-crystal | unified/reports/JmUdFineSlSum.rpt | web/apps/api/report-specs/JmUdFineSlSum.spec.json | Unverified |
| KrDesignIsuImg | supplied-crystal | unified/reports/KrDesignIsuImg.rpt | web/apps/api/report-specs/KrDesignIsuImg.spec.json | Unverified |
| KrDesignIsuVch | supplied-crystal | unified/reports/KrDesignIsuVch.rpt | web/apps/api/report-specs/KrDesignIsuVch.spec.json | Unverified |
| KrDmIsuRec | supplied-crystal | unified/reports/KrDmIsuRec.rpt | web/apps/api/report-specs/KrDmIsuRec.spec.json | Unverified |
| KrDmWtInOut | supplied-crystal | unified/reports/KrDmWtInOut.rpt | web/apps/api/report-specs/KrDmWtInOut.spec.json | Unverified |
| KrIsuBill | supplied-crystal | unified/reports/KrIsuBill.rpt | web/apps/api/report-specs/KrIsuBill.spec.json | Unverified |
| KrIsuBillGst | supplied-crystal | unified/reports/KrIsuBillGst.rpt | web/apps/api/report-specs/KrIsuBillGst.spec.json | Unverified |
| KrRecVch | supplied-crystal | unified/reports/KrRecVch.rpt | web/apps/api/report-specs/KrRecVch.spec.json | Unverified |
| KrRecVchGst | supplied-crystal | unified/reports/KrRecVchGst.rpt | web/apps/api/report-specs/KrRecVchGst.spec.json | Unverified |
| KrRepRec | supplied-crystal | unified/reports/KrRepRec.rpt | web/apps/api/report-specs/KrRepRec.spec.json | Unverified |
| LabourBill | supplied-crystal | unified/reports/LabourBill.rpt | web/apps/api/report-specs/LabourBill.spec.json | Unverified |
| LabourBillGst | supplied-crystal | unified/reports/LabourBillGst.rpt | web/apps/api/report-specs/LabourBillGst.spec.json | Unverified |
| LabourWorkVch | supplied-crystal | unified/reports/LabourWorkVch.rpt | web/apps/api/report-specs/LabourWorkVch.spec.json | Unverified |
| LbrWorkRpt | supplied-crystal | unified/reports/LbrWorkRpt.rpt | web/apps/api/report-specs/LbrWorkRpt.spec.json | Unverified |
| LedrAdjVch | supplied-crystal | unified/reports/LedrAdjVch.rpt | web/apps/api/report-specs/LedrAdjVch.spec.json | Unverified |
| LedrInOut | supplied-crystal | unified/reports/LedrInOut.rpt | web/apps/api/report-specs/LedrInOut.spec.json | Unverified |
| LedrInOutWh | supplied-crystal | unified/reports/LedrInOutWh.rpt | web/apps/api/report-specs/LedrInOutWh.spec.json | Unverified |
| LoanStock | supplied-crystal | unified/reports/LoanStock.rpt | web/apps/api/report-specs/LoanStock.spec.json | Unverified |
| LoanWisePacket | supplied-crystal | unified/reports/LoanWisePacket.rpt | web/apps/api/report-specs/LoanWisePacket.spec.json | Unverified |
| MembBonus | supplied-crystal | unified/reports/MembBonus.rpt | web/apps/api/report-specs/MembBonus.spec.json | Unverified |
| MembCommRpt | supplied-crystal | unified/reports/MembCommRpt.rpt | web/apps/api/report-specs/MembCommRpt.spec.json | Unverified |
| MembDailyRecRpt | supplied-crystal | unified/reports/MembDailyRecRpt.rpt | web/apps/api/report-specs/MembDailyRecRpt.spec.json | Unverified |
| MembGoldRpt | supplied-crystal | unified/reports/MembGoldRpt.rpt | web/apps/api/report-specs/MembGoldRpt.spec.json | Unverified |
| MembOpenNew | supplied-crystal | unified/reports/MembOpenNew.rpt | web/apps/api/report-specs/MembOpenNew.spec.json | Unverified |
| MembQr | supplied-crystal | unified/reports/MembQr.rpt | web/apps/api/report-specs/MembQr.spec.json | Unverified |
| MembRpt | supplied-crystal | unified/reports/MembRpt.rpt | web/apps/api/report-specs/MembRpt.spec.json | Unverified |
| MembRptAdd | supplied-crystal | unified/reports/MembRptAdd.rpt | web/apps/api/report-specs/MembRptAdd.spec.json | Unverified |
| MembSumm | supplied-crystal | unified/reports/MembSumm.rpt | web/apps/api/report-specs/MembSumm.spec.json | Unverified |
| MembVch | supplied-crystal | unified/reports/MembVch.rpt | web/apps/api/report-specs/MembVch.spec.json | Unverified |
| MfgGhatIsu | supplied-crystal | unified/reports/MfgGhatIsu.rpt | web/apps/api/report-specs/MfgGhatIsu.spec.json | Unverified |
| MfgGhatRec | supplied-crystal | unified/reports/MfgGhatRec.rpt | web/apps/api/report-specs/MfgGhatRec.spec.json | Unverified |
| MfgLedger | supplied-crystal | unified/reports/MfgLedger.rpt | web/apps/api/report-specs/MfgLedger.spec.json | Unverified |
| MfgMinoIsuRec | supplied-crystal | unified/reports/MfgMinoIsuRec.rpt | web/apps/api/report-specs/MfgMinoIsuRec.spec.json | Unverified |
| MfgVch | supplied-crystal | unified/reports/MfgVch.rpt | web/apps/api/report-specs/MfgVch.spec.json | Unverified |
| MtlIsu | supplied-crystal | unified/reports/MtlIsu.rpt | web/apps/api/report-specs/MtlIsu.spec.json | Unverified |
| OldItmSaleVch | supplied-crystal | unified/reports/OldItmSaleVch.rpt | web/apps/api/report-specs/OldItmSaleVch.spec.json | Unverified |
| OrdAdjBillWise | supplied-crystal | unified/reports/OrdAdjBillWise.rpt | web/apps/api/report-specs/OrdAdjBillWise.spec.json | Unverified |
| OrdAdvAdj | supplied-crystal | unified/reports/OrdAdvAdj.rpt | web/apps/api/report-specs/OrdAdvAdj.spec.json | Unverified |
| OrdAdvRpt | supplied-crystal | unified/reports/OrdAdvRpt.rpt | web/apps/api/report-specs/OrdAdvRpt.spec.json | Unverified |
| OrdDesignSumm | supplied-crystal | unified/reports/OrdDesignSumm.rpt | web/apps/api/report-specs/OrdDesignSumm.spec.json | Unverified |
| OrdDetlPanding | supplied-crystal | unified/reports/OrdDetlPanding.rpt | web/apps/api/report-specs/OrdDetlPanding.spec.json | Unverified |
| OrdDetlRpt | supplied-crystal | unified/reports/OrdDetlRpt.rpt | web/apps/api/report-specs/OrdDetlRpt.spec.json | Unverified |
| OrderBill | supplied-crystal | unified/reports/OrderBill.rpt | web/apps/api/report-specs/OrderBill.spec.json | Unverified |
| OrderCancelVch | supplied-crystal | unified/reports/OrderCancelVch.rpt | web/apps/api/report-specs/OrderCancelVch.spec.json | Unverified |
| OrderVch | supplied-crystal | unified/reports/OrderVch.rpt | web/apps/api/report-specs/OrderVch.spec.json | Unverified |
| OrdVchImg | supplied-crystal | unified/reports/OrdVchImg.rpt | web/apps/api/report-specs/OrdVchImg.spec.json | Unverified |
| OthCommVch | supplied-crystal | unified/reports/OthCommVch.rpt | web/apps/api/report-specs/OthCommVch.spec.json | Unverified |
| OthExpUae | supplied-crystal | unified/reports/OthExpUae.rpt | web/apps/api/report-specs/OthExpUae.spec.json | Unverified |
| OthItmLoose | supplied-crystal | unified/reports/OthItmLoose.rpt | web/apps/api/report-specs/OthItmLoose.spec.json | Unverified |
| OthItmStud | supplied-crystal | unified/reports/OthItmStud.rpt | web/apps/api/report-specs/OthItmStud.spec.json | Unverified |
| OutTax_SaleRpt | supplied-crystal | unified/reports/OutTax_SaleRpt.rpt | web/apps/api/report-specs/OutTax_SaleRpt.spec.json | Unverified |
| PartyInterest | supplied-crystal | unified/reports/PartyInterest.rpt | web/apps/api/report-specs/PartyInterest.spec.json | Unverified |
| PartyIntSumm | supplied-crystal | unified/reports/PartyIntSumm.rpt | web/apps/api/report-specs/PartyIntSumm.spec.json | Unverified |
| PaymentVch | supplied-crystal | unified/reports/PaymentVch.rpt | web/apps/api/report-specs/PaymentVch.spec.json | Unverified |
| ProdStkRpt | supplied-crystal | unified/reports/ProdStkRpt.rpt | web/apps/api/report-specs/ProdStkRpt.spec.json | Unverified |
| ProfitLossHz | supplied-crystal | unified/reports/ProfitLossHz.rpt | web/apps/api/report-specs/ProfitLossHz.spec.json | Unverified |
| PrRtnBill | supplied-crystal | unified/reports/PrRtnBill.rpt | web/apps/api/report-specs/PrRtnBill.spec.json | Unverified |
| PrRtnBillGst | supplied-crystal | unified/reports/PrRtnBillGst.rpt | web/apps/api/report-specs/PrRtnBillGst.spec.json | Unverified |
| PrTaxRpt | supplied-crystal | unified/reports/PrTaxRpt.rpt | web/apps/api/report-specs/PrTaxRpt.spec.json | Unverified |
| PurcBillA4 | supplied-crystal | unified/reports/PurcBillA4.rpt | web/apps/api/report-specs/PurcBillA4.spec.json | Unverified |
| PurcBillA4Gst | supplied-crystal | unified/reports/PurcBillA4Gst.rpt | web/apps/api/report-specs/PurcBillA4Gst.spec.json | Unverified |
| PurcBillHalfGst | supplied-crystal | unified/reports/PurcBillHalfGst.rpt | web/apps/api/report-specs/PurcBillHalfGst.spec.json | Unverified |
| PurcGroupWise | supplied-crystal | unified/reports/PurcGroupWise.rpt | web/apps/api/report-specs/PurcGroupWise.spec.json | Unverified |
| PurcItem | supplied-crystal | unified/reports/PurcItem.rpt | web/apps/api/report-specs/PurcItem.spec.json | Unverified |
| PurcReport | supplied-crystal | unified/reports/PurcReport.rpt | web/apps/api/report-specs/PurcReport.spec.json | Unverified |
| PurcSumm | supplied-crystal | unified/reports/PurcSumm.rpt | web/apps/api/report-specs/PurcSumm.spec.json | Unverified |
| PurcToSalesFixingVch | supplied-crystal | unified/reports/PurcToSalesFixingVch.rpt | web/apps/api/report-specs/PurcToSalesFixingVch.spec.json | Unverified |
| QrPrint10 | supplied-crystal | unified/reports/QrPrint10.rpt | web/apps/api/report-specs/QrPrint10.spec.json | Unverified |
| RateCutBill | supplied-crystal | unified/reports/RateCutBill.rpt | web/apps/api/report-specs/RateCutBill.spec.json | Unverified |
| RateCutItmBill | supplied-crystal | unified/reports/RateCutItmBill.rpt | web/apps/api/report-specs/RateCutItmBill.spec.json | Unverified |
| RateRpt | supplied-crystal | unified/reports/RateRpt.rpt | web/apps/api/report-specs/RateRpt.spec.json | Unverified |
| ReminderAll | supplied-crystal | unified/reports/ReminderAll.rpt | web/apps/api/report-specs/ReminderAll.spec.json | Unverified |
| ReparingCustIsu | supplied-crystal | unified/reports/ReparingCustIsu.rpt | web/apps/api/report-specs/ReparingCustIsu.spec.json | Unverified |
| ReparingKrRec | supplied-crystal | unified/reports/ReparingKrRec.rpt | web/apps/api/report-specs/ReparingKrRec.spec.json | Unverified |
| ReparingRec | supplied-crystal | unified/reports/ReparingRec.rpt | web/apps/api/report-specs/ReparingRec.spec.json | Unverified |
| RojMel | supplied-crystal | unified/reports/RojMel.rpt | web/apps/api/report-specs/RojMel.spec.json | Unverified |
| RojMelCash | supplied-crystal | unified/reports/RojMelCash.rpt | web/apps/api/report-specs/RojMelCash.spec.json | Unverified |
| RojMelCrDr | supplied-crystal | unified/reports/RojMelCrDr.rpt | web/apps/api/report-specs/RojMelCrDr.spec.json | Unverified |
| RojMelEstmat | supplied-crystal | unified/reports/RojMelEstmat.rpt | web/apps/api/report-specs/RojMelEstmat.spec.json | Unverified |
| RojMelGr | supplied-crystal | unified/reports/RojMelGr.rpt | web/apps/api/report-specs/RojMelGr.spec.json | Unverified |
| RojMelItem | supplied-crystal | unified/reports/RojMelItem.rpt | web/apps/api/report-specs/RojMelItem.spec.json | Unverified |
| RojMelJmaUdhar | supplied-crystal | unified/reports/RojMelJmaUdhar.rpt | web/apps/api/report-specs/RojMelJmaUdhar.spec.json | Unverified |
| RtlHuidPrint | supplied-crystal | unified/reports/RtlHuidPrint.rpt | web/apps/api/report-specs/RtlHuidPrint.spec.json | Unverified |
| SafeStkSumm | supplied-crystal | unified/reports/SafeStkSumm.rpt | web/apps/api/report-specs/SafeStkSumm.spec.json | Unverified |
| SalarySlip | supplied-crystal | unified/reports/SalarySlip.rpt | web/apps/api/report-specs/SalarySlip.spec.json | Unverified |
| SaleOrnaIsu | supplied-crystal | unified/reports/SaleOrnaIsu.rpt | web/apps/api/report-specs/SaleOrnaIsu.spec.json | Unverified |
| SaleReport | supplied-crystal | unified/reports/SaleReport.rpt | web/apps/api/report-specs/SaleReport.spec.json | Unverified |
| SaleRtnReport | supplied-crystal | unified/reports/SaleRtnReport.rpt | web/apps/api/report-specs/SaleRtnReport.spec.json | Unverified |
| SalesBillA4 | supplied-crystal | unified/reports/SalesBillA4.rpt | web/apps/api/report-specs/SalesBillA4.spec.json | Unverified |
| SalesBillA4_WithImage | supplied-crystal | unified/reports/SalesBillA4_WithImage.rpt | web/apps/api/report-specs/SalesBillA4_WithImage.spec.json | Unverified |
| SalesBillA4Gst | supplied-crystal | unified/reports/SalesBillA4Gst.rpt | web/apps/api/report-specs/SalesBillA4Gst.spec.json | Unverified |
| SalesBillHz | supplied-crystal | unified/reports/SalesBillHz.rpt | web/apps/api/report-specs/SalesBillHz.spec.json | Unverified |
| SalesBillHzGst | supplied-crystal | unified/reports/SalesBillHzGst.rpt | web/apps/api/report-specs/SalesBillHzGst.spec.json | Unverified |
| SalesBillOrgDup | supplied-crystal | unified/reports/SalesBillOrgDup.rpt | web/apps/api/report-specs/SalesBillOrgDup.spec.json | Unverified |
| SalesBillOs | supplied-crystal | unified/reports/SalesBillOs.rpt | web/apps/api/report-specs/SalesBillOs.spec.json | Unverified |
| SalesBillVr | supplied-crystal | unified/reports/SalesBillVr.rpt | web/apps/api/report-specs/SalesBillVr.spec.json | Unverified |
| SalesGroupWise | supplied-crystal | unified/reports/SalesGroupWise.rpt | web/apps/api/report-specs/SalesGroupWise.spec.json | Unverified |
| SalesItem | supplied-crystal | unified/reports/SalesItem.rpt | web/apps/api/report-specs/SalesItem.spec.json | Unverified |
| SalesQuotation | supplied-crystal | unified/reports/SalesQuotation.rpt | web/apps/api/report-specs/SalesQuotation.spec.json | Unverified |
| SalesRtnA4 | supplied-crystal | unified/reports/SalesRtnA4.rpt | web/apps/api/report-specs/SalesRtnA4.spec.json | Unverified |
| SalesRtnA4Gst | supplied-crystal | unified/reports/SalesRtnA4Gst.rpt | web/apps/api/report-specs/SalesRtnA4Gst.spec.json | Unverified |
| SalesRtnBillUae | supplied-crystal | unified/reports/SalesRtnBillUae.rpt | web/apps/api/report-specs/SalesRtnBillUae.spec.json | Unverified |
| SalesRtnItem | supplied-crystal | unified/reports/SalesRtnItem.rpt | web/apps/api/report-specs/SalesRtnItem.spec.json | Unverified |
| SalesRtnSumm | supplied-crystal | unified/reports/SalesRtnSumm.rpt | web/apps/api/report-specs/SalesRtnSumm.spec.json | Unverified |
| SalesSumm | supplied-crystal | unified/reports/SalesSumm.rpt | web/apps/api/report-specs/SalesSumm.spec.json | Unverified |
| SalesToPurcFixingVch | supplied-crystal | unified/reports/SalesToPurcFixingVch.rpt | web/apps/api/report-specs/SalesToPurcFixingVch.spec.json | Unverified |
| SalesWithOrder | supplied-crystal | unified/reports/SalesWithOrder.rpt | web/apps/api/report-specs/SalesWithOrder.spec.json | Unverified |
| SchmAdj | supplied-crystal | unified/reports/SchmAdj.rpt | web/apps/api/report-specs/SchmAdj.spec.json | Unverified |
| SchmMonthRpt | supplied-crystal | unified/reports/SchmMonthRpt.rpt | web/apps/api/report-specs/SchmMonthRpt.spec.json | Unverified |
| SchmPassBook | supplied-crystal | unified/reports/SchmPassBook.rpt | web/apps/api/report-specs/SchmPassBook.spec.json | Unverified |
| SchmRecVch | supplied-crystal | unified/reports/SchmRecVch.rpt | web/apps/api/report-specs/SchmRecVch.spec.json | Unverified |
| SlBillWapp | supplied-crystal | unified/reports/SlBillWapp.rpt | web/apps/api/report-specs/SlBillWapp.spec.json | Unverified |
| SlTaxRpt | supplied-crystal | unified/reports/SlTaxRpt.rpt | web/apps/api/report-specs/SlTaxRpt.spec.json | Unverified |
| StkInOutVch | supplied-crystal | unified/reports/StkInOutVch.rpt | web/apps/api/report-specs/StkInOutVch.spec.json | Unverified |
| StngIsuRec | supplied-crystal | unified/reports/StngIsuRec.rpt | web/apps/api/report-specs/StngIsuRec.spec.json | Unverified |
| TableStkGwtRpt | supplied-crystal | unified/reports/TableStkGwtRpt.rpt | web/apps/api/report-specs/TableStkGwtRpt.spec.json | Unverified |
| TagCanBill | supplied-crystal | unified/reports/TagCanBill.rpt | web/apps/api/report-specs/TagCanBill.spec.json | Unverified |
| TagHuIdRpt | supplied-crystal | unified/reports/TagHuIdRpt.rpt | web/apps/api/report-specs/TagHuIdRpt.spec.json | Unverified |
| TagItmSumm | supplied-crystal | unified/reports/TagItmSumm.rpt | web/apps/api/report-specs/TagItmSumm.spec.json | Unverified |
| TagReNumberVch | supplied-crystal | unified/reports/TagReNumberVch.rpt | web/apps/api/report-specs/TagReNumberVch.spec.json | Unverified |
| TagSplitVch | supplied-crystal | unified/reports/TagSplitVch.rpt | web/apps/api/report-specs/TagSplitVch.spec.json | Unverified |
| TagStkIdtlRpt | supplied-crystal | unified/reports/TagStkIdtlRpt.rpt | Absent: resolve artifact/caller | Unverified |
| TagStkItemSumRpt | supplied-crystal | unified/reports/TagStkItemSumRpt.rpt | web/apps/api/report-specs/TagStkItemSumRpt.spec.json | Unverified |
| TagStkRpt | supplied-crystal | unified/reports/TagStkRpt.rpt | web/apps/api/report-specs/TagStkRpt.spec.json | Unverified |
| TagStkRptDmSum | supplied-crystal | unified/reports/TagStkRptDmSum.rpt | web/apps/api/report-specs/TagStkRptDmSum.spec.json | Unverified |
| TagStkSummRpt | supplied-crystal | unified/reports/TagStkSummRpt.rpt | web/apps/api/report-specs/TagStkSummRpt.spec.json | Unverified |
| TagWtChangeVch | supplied-crystal | unified/reports/TagWtChangeVch.rpt | web/apps/api/report-specs/TagWtChangeVch.spec.json | Unverified |
| TagWtChangSplit | supplied-crystal | unified/reports/TagWtChangSplit.rpt | web/apps/api/report-specs/TagWtChangSplit.spec.json | Unverified |
| TaxInOutRpt | supplied-crystal | unified/reports/TaxInOutRpt.rpt | web/apps/api/report-specs/TaxInOutRpt.spec.json | Unverified |
| TaxSummUae | supplied-crystal | unified/reports/TaxSummUae.rpt | web/apps/api/report-specs/TaxSummUae.spec.json | Unverified |
| TempAdd2 | supplied-crystal | unified/reports/TempAdd2.rpt | web/apps/api/report-specs/TempAdd2.spec.json | Unverified |
| TempAdd3 | supplied-crystal | unified/reports/TempAdd3.rpt | web/apps/api/report-specs/TempAdd3.spec.json | Unverified |
| TempPhone | supplied-crystal | unified/reports/TempPhone.rpt | web/apps/api/report-specs/TempPhone.spec.json | Unverified |
| TourOrdImg | supplied-crystal | unified/reports/TourOrdImg.rpt | web/apps/api/report-specs/TourOrdImg.spec.json | Unverified |
| TourOrdVch | supplied-crystal | unified/reports/TourOrdVch.rpt | web/apps/api/report-specs/TourOrdVch.spec.json | Unverified |
| TRialBalHz | supplied-crystal | unified/reports/TRialBalHz.rpt | web/apps/api/report-specs/TRialBalHz.spec.json | Unverified |
| UserDtlRpt | supplied-crystal | unified/reports/UserDtlRpt.rpt | web/apps/api/report-specs/UserDtlRpt.spec.json | Unverified |
| VpAdjustBill | supplied-crystal | unified/reports/VpAdjustBill.rpt | web/apps/api/report-specs/VpAdjustBill.spec.json | Unverified |
| VpIsuRpt | supplied-crystal | unified/reports/VpIsuRpt.rpt | web/apps/api/report-specs/VpIsuRpt.spec.json | Unverified |
| WhHuidPrint | supplied-crystal | unified/reports/WhHuidPrint.rpt | web/apps/api/report-specs/WhHuidPrint.spec.json | Unverified |
| WhSalesBill | supplied-crystal | unified/reports/WhSalesBill.rpt | web/apps/api/report-specs/WhSalesBill.spec.json | Unverified |
| WhSalesBillSumm | supplied-crystal | unified/reports/WhSalesBillSumm.rpt | web/apps/api/report-specs/WhSalesBillSumm.spec.json | Unverified |
| WhSalesEmp | supplied-crystal | unified/reports/WhSalesEmp.rpt | web/apps/api/report-specs/WhSalesEmp.spec.json | Unverified |
| WhSalesImage | supplied-crystal | unified/reports/WhSalesImage.rpt | web/apps/api/report-specs/WhSalesImage.spec.json | Unverified |
| WhSalesIsuRec | supplied-crystal | unified/reports/WhSalesIsuRec.rpt | web/apps/api/report-specs/WhSalesIsuRec.spec.json | Unverified |
| WhSalesRtnBill | supplied-crystal | unified/reports/WhSalesRtnBill.rpt | web/apps/api/report-specs/WhSalesRtnBill.spec.json | Unverified |
| WhSalesSumm | supplied-crystal | unified/reports/WhSalesSumm.rpt | web/apps/api/report-specs/WhSalesSumm.spec.json | Unverified |
| aprbillimg | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| balzoom | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| bankadj | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| billwiseos | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| empdaysumm | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| empsumm | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| franchisebill | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| jdterskt | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| jdtvch | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| krisureport | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| krrecreport | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| loctamtvch | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| mainacsumm | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| mltingisu | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| purcquot | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| reminderschm | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| remindervch | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| salesrtna4print | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| vpparcelbill | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |
| whquotation | absent-referenced | Absent: resolve artifact/caller | Absent: resolve artifact/caller | Unverified |

## All 146 retained table units

Reconcile these with the 162-table inferred catalog and seven unresolved table candidates in document 03; source-only and later live tables must be added. Required for every row: source/target type domain, owner/scope/key, load order, dependencies, exact conversion, retry/reconcile, historic continuation and backup/restore disposition.

| Table | Ownership/migration acceptance |
|---|---|
| `AC_DATA` | Open — P01/P12, X05/X30 |
| `AC_GROUP` | Open — P01/P12, X05/X30 |
| `AC_MAST` | Open — P01/P12, X05/X30 |
| `ADD_MAST` | Open — P01/P12, X05/X30 |
| `AD_ADJ` | Open — P01/P12, X05/X30 |
| `AD_DATA` | Open — P01/P12, X05/X30 |
| `AD_MAST` | Open — P01/P12, X05/X30 |
| `AD_MEMB` | Open — P01/P12, X05/X30 |
| `AD_OS` | Open — P01/P12, X05/X30 |
| `APR_DATA` | Open — P01/P12, X05/X30 |
| `APR_DETL` | Open — P01/P12, X05/X30 |
| `APR_IDTL` | Open — P01/P12, X05/X30 |
| `BAL_GR` | Open — P01/P12, X05/X30 |
| `BANK_RECONCILE` | Open — P01/P12, X05/X30 |
| `BAR_CAN_DATA` | Open — P01/P12, X05/X30 |
| `BAR_CAN_DETL` | Open — P01/P12, X05/X30 |
| `BAR_CAN_IDTL` | Open — P01/P12, X05/X30 |
| `BAR_DATA` | Open — P01/P12, X05/X30 |
| `BAR_DETL` | Open — P01/P12, X05/X30 |
| `BAR_IDTL` | Open — P01/P12, X05/X30 |
| `BILL_OS_DATA` | Open — P01/P12, X05/X30 |
| `BOOK_DATA` | Open — P01/P12, X05/X30 |
| `BOOK_DETL` | Open — P01/P12, X05/X30 |
| `BOOK_IDTL` | Open — P01/P12, X05/X30 |
| `BUL_DATA` | Open — P01/P12, X05/X30 |
| `CARD_DATA` | Open — P01/P12, X05/X30 |
| `CASH_DATA` | Open — P01/P12, X05/X30 |
| `COL_MAST` | Open — P01/P12, X05/X30 |
| `CONTRA_DATA` | Open — P01/P12, X05/X30 |
| `CONV_MAST` | Open — P01/P12, X05/X30 |
| `COUNTRY_MAST` | Open — P01/P12, X05/X30 |
| `CO_MAST` | Open — P01/P12, X05/X30 |
| `CO_SET` | Open — P01/P12, X05/X30 |
| `CO_SET_NEW` | Open — P01/P12, X05/X30 |
| `CRNT_DATA` | Open — P01/P12, X05/X30 |
| `CUT_DATA` | Open — P01/P12, X05/X30 |
| `CUT_DETL` | Open — P01/P12, X05/X30 |
| `CUT_STK_DETL` | Open — P01/P12, X05/X30 |
| `DELETE_DATA` | Open — P01/P12, X05/X30 |
| `DESIGN_DETL` | Open — P01/P12, X05/X30 |
| `DESIGN_IDTL` | Open — P01/P12, X05/X30 |
| `DESIGN_MAST` | Open — P01/P12, X05/X30 |
| `DHRN_DATA` | Open — P01/P12, X05/X30 |
| `DHRN_ISU_DATA` | Open — P01/P12, X05/X30 |
| `DHRN_ISU_DETL` | Open — P01/P12, X05/X30 |
| `DHRN_REC_DATA` | Open — P01/P12, X05/X30 |
| `DHRN_REC_DETL` | Open — P01/P12, X05/X30 |
| `DM_DATA` | Open — P01/P12, X05/X30 |
| `DM_KR_DATA` | Open — P01/P12, X05/X30 |
| `DM_MAST` | Open — P01/P12, X05/X30 |
| `DM_SIZE` | Open — P01/P12, X05/X30 |
| `EMP_DATA` | Open — P01/P12, X05/X30 |
| `EMP_MAST` | Open — P01/P12, X05/X30 |
| `E_DATA` | Open — P01/P12, X05/X30 |
| `E_MAST` | Open — P01/P12, X05/X30 |
| `FINE_DATA` | Open — P01/P12, X05/X30 |
| `GROUP_MAST` | Open — P01/P12, X05/X30 |
| `HDD_MAST` | Open — P01/P12, X05/X30 |
| `IMAGE_DATA` | Open — P01/P12, X05/X30 |
| `INOUT_DATA` | Open — P01/P12, X05/X30 |
| `INOUT_DETL` | Open — P01/P12, X05/X30 |
| `INOUT_IDTL` | Open — P01/P12, X05/X30 |
| `ITEM_MAST` | Open — P01/P12, X05/X30 |
| `ITM_CITY` | Open — P01/P12, X05/X30 |
| `ITM_LOT_DETL` | Open — P01/P12, X05/X30 |
| `ITM_OPBL` | Open — P01/P12, X05/X30 |
| `ITM_WT_MAST` | Open — P01/P12, X05/X30 |
| `KR_DATA` | Open — P01/P12, X05/X30 |
| `KR_DETL` | Open — P01/P12, X05/X30 |
| `KR_IDTL` | Open — P01/P12, X05/X30 |
| `LBR_DATA` | Open — P01/P12, X05/X30 |
| `LBR_ISU_DETL` | Open — P01/P12, X05/X30 |
| `LBR_ISU_IDTL` | Open — P01/P12, X05/X30 |
| `LBR_MAST` | Open — P01/P12, X05/X30 |
| `LBR_REC_DETL` | Open — P01/P12, X05/X30 |
| `LDR_ADJ_DATA` | Open — P01/P12, X05/X30 |
| `LEDR_AC_DATA` | Open — P01/P12, X05/X30 |
| `LOCT_AMT` | Open — P01/P12, X05/X30 |
| `LOCT_MAST` | Open — P01/P12, X05/X30 |
| `LOGIN_MAST` | Open — P01/P12, X05/X30 |
| `LOT_DETL` | Open — P01/P12, X05/X30 |
| `MAIN_STOCK` | Open — P01/P12, X05/X30 |
| `MFG_DATA` | Open — P01/P12, X05/X30 |
| `MFG_DETL` | Open — P01/P12, X05/X30 |
| `MFG_IDTL` | Open — P01/P12, X05/X30 |
| `MFG_ISU_REC` | Open — P01/P12, X05/X30 |
| `MFG_MAST` | Open — P01/P12, X05/X30 |
| `MLT_DATA` | Open — P01/P12, X05/X30 |
| `MLT_DETL` | Open — P01/P12, X05/X30 |
| `MODEL_MAST` | Open — P01/P12, X05/X30 |
| `MSG_MAST` | Open — P01/P12, X05/X30 |
| `OP_DATA` | Open — P01/P12, X05/X30 |
| `OP_DETL` | Open — P01/P12, X05/X30 |
| `OP_LDR` | Open — P01/P12, X05/X30 |
| `PAY_DATA` | Open — P01/P12, X05/X30 |
| `PAY_DETL` | Open — P01/P12, X05/X30 |
| `POINT_DATA` | Open — P01/P12, X05/X30 |
| `POINT_MAST` | Open — P01/P12, X05/X30 |
| `POINT_MEMB` | Open — P01/P12, X05/X30 |
| `PRINT_MAST` | Open — P01/P12, X05/X30 |
| `PRODUCT_MAST` | Open — P01/P12, X05/X30 |
| `PR_DATA` | Open — P01/P12, X05/X30 |
| `PR_DETL` | Open — P01/P12, X05/X30 |
| `PR_IDTL` | Open — P01/P12, X05/X30 |
| `RATE_CUT_DATA` | Open — P01/P12, X05/X30 |
| `RATE_CUT_ISU` | Open — P01/P12, X05/X30 |
| `RATE_CUT_ISU_REC` | Open — P01/P12, X05/X30 |
| `RATE_CUT_REC` | Open — P01/P12, X05/X30 |
| `RATE_MAST` | Open — P01/P12, X05/X30 |
| `REM_DATA` | Open — P01/P12, X05/X30 |
| `REPORT_DATA` | Open — P01/P12, X05/X30 |
| `REP_DATA` | Open — P01/P12, X05/X30 |
| `REP_DETL` | Open — P01/P12, X05/X30 |
| `ROJMEL_BAL` | Open — P01/P12, X05/X30 |
| `ROJ_MEL_DATA` | Open — P01/P12, X05/X30 |
| `SL_DATA` | Open — P01/P12, X05/X30 |
| `SL_DETL` | Open — P01/P12, X05/X30 |
| `SL_DETL_RTN` | Open — P01/P12, X05/X30 |
| `SL_IDTL` | Open — P01/P12, X05/X30 |
| `SL_ORD_ADJ` | Open — P01/P12, X05/X30 |
| `SL_ORD_DATA` | Open — P01/P12, X05/X30 |
| `SL_ORD_DETL` | Open — P01/P12, X05/X30 |
| `SL_ORD_IDTL` | Open — P01/P12, X05/X30 |
| `SL_PR_DETL` | Open — P01/P12, X05/X30 |
| `SRNO_MAST` | Open — P01/P12, X05/X30 |
| `STATE_MAST` | Open — P01/P12, X05/X30 |
| `TABLE_MAST` | Open — P01/P12, X05/X30 |
| `TAG_DATA` | Open — P01/P12, X05/X30 |
| `TAG_PRINT_DATA` | Open — P01/P12, X05/X30 |
| `TAG_SET` | Open — P01/P12, X05/X30 |
| `TAG_STOCK_PRINT` | Open — P01/P12, X05/X30 |
| `TAG_SUM_DATA` | Open — P01/P12, X05/X30 |
| `TAX_DATA` | Open — P01/P12, X05/X30 |
| `TAX_MAST` | Open — P01/P12, X05/X30 |
| `TEMP_ADD` | Open — P01/P12, X05/X30 |
| `TEMP_AD_DATA` | Open — P01/P12, X05/X30 |
| `TEMP_BOOK_DATA` | Open — P01/P12, X05/X30 |
| `TOUCH_MAST` | Open — P01/P12, X05/X30 |
| `UPI_DATA` | Open — P01/P12, X05/X30 |
| `USER_DATA` | Open — P01/P12, X05/X30 |
| `USER_MAST` | Open — P01/P12, X05/X30 |
| `USER_REQUEST` | Open — P01/P12, X05/X30 |
| `VP_ADJ_DATA` | Open — P01/P12, X05/X30 |
| `WEB_DATA` | Open — P01/P12, X05/X30 |
| `WEIGHT_MAST` | Open — P01/P12, X05/X30 |
| `YEAR_MAST` | Open — P01/P12, X05/X30 |

## All 130 scanned setting records

These records have 128 distinct labels: `CO_CODE` and `COUNTRY_ID` each occur twice. Both original records are preserved with register-row identity until their semantic scope is resolved; do not discard duplicates or call 130 a unique-setting count. Old scanner labels do not decide whether a setting works. Follow each desktop global/reader to current authoritative load, UI/formula/validation/output effect, both value branches, stale drafts and imported documents (J21).

| Setting | Desktop globals | Reader units (retained candidates) | Acceptance |
|---|---|---|---|
| THEME | MsCoTheme | BtmSchm, MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_AUTO_ITEM, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GOLD_MAST, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_MFG_MAST, MS_POINT, MS_PRODUCT, MS_RATE, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_TRADE, MS_UPDATE, MS_USER, MS_WINDOW_SET, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST, RP_CUST_CRM, RP_DAY_WORK, RP_DHRN_LOAN, RP_DHRN_OS, RP_EMP, RP_GRAPH, RP_GST, RP_HUID, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MFG, RP_MFG_LEDR, RP_MFG_ZOOM, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_PHY_STOCK, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TAX, RP_TOUR_ZOOM, RP_TRADING, RP_USER, TR_AC_OPBL, TR_APR_ISU, TR_BILL_TO, TR_BUL_BOOKING, TR_BUL_SALE, TR_CARD_REC, TR_CASH, TR_CONTRA, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_EMP_JV, TR_FINE_SL_PR, TR_FN_INOUT, TR_GOLD_BOOK, TR_INOUT, TR_ITM_LOT, TR_ITM_OPBL, TR_JDT_REC, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ADJ, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_MLT_PRO, TR_OTH_COMM, TR_OTH_PURC, TR_PHYSTK, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR, TR_TOUR_ORD, TR_TOUR_SALE, TR_UPI_REC, TR_VP, TR_VP_ADJ, TR_WH_SALE, TR_WH_SALE_RTN, UT_AI_TRFR, UT_BANK, UT_BKP, UT_CUST_ENTRY, UT_EXPORT, UT_E_INVOICE, UT_IMPORT, UT_REMINDER, UT_SETTING, UT_SETTING_MAIN, UT_SET_ADMIN, UT_SMS, UT_TAG_PRINT, UT_USER_REQUEST, UT_VCH_RE_NUMBR, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| TAG_RPT | MsTagRpt | TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE_RTN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_WH_SALE_RTN | Open — X08 plus domain owner |
| FINE_STK_TYPE | MsFineStkType | RP_STOCK_FINE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| RATE_MAST_OPEN | MsRateMastOpen | UT_SETTING | Open — X08 plus domain owner |
| LBR_RATE_GEN | MsLbrGen | TR_KR_ISU, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_WH_SALE_RTN, UT_SETTING | Open — X08 plus domain owner |
| VB_IMPORT | MsVbImport | Ac_Ledr, MS_ACCT, MS_ADD_MAST, MS_COMPANY, MS_UPDATE, Module_Schm, RP_ADDRESS, RP_OS, TR_APR_ISU, TR_DHRN_ISU, TR_DHRN_REC, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_RTN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_WH_SALE_RTN, UT_IMPORT, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| SL_ROW_CHANGE | MsSlRowChange | Mfg_Module, TR_KR_ISU, TR_PR_SL_UAE, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_TOUR_SALE, TR_VP, TR_WH_SALE, UT_SETTING | Open — X08 plus domain owner |
| DHRN_INT_TYPE | MsDhrnIntType | RP_DHRN_OS, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, UT_SETTING | Open — X08 plus domain owner |
| INT_YEAR_DAYS | MsIntYearDays | RP_DHRN_OS, RP_INOUT, RP_OS, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_WH_SALE | Open — X08 plus domain owner |
| OP_DHRN | MsOpDhiran | Ac_Ledr, UT_SETTING | Open — X08 plus domain owner |
| INT_DAY | MsIntDayCalc | TR_DHRN_INTREC, TR_DHRN_REC | Open — X08 plus domain owner |
| HELP_SERCH | MsHelpSearch | MS_HELP, UT_SETTING | Open — X08 plus domain owner |
| WEIGHT_PORT | MsWeightPort | MS_DESIGN_BOOK, TR_TAG_OPBL | Open — X08 plus domain owner |
| LDR_SUMM | MsLdrSumm | RP_BAL_ZOOM, RP_LEDR, UT_SETTING | Open — X08 plus domain owner |
| SL_AMT_TYPE | MsSlAmtType | RP_TAG_ESTMATE, TR_PR_SL_UAE, TR_SALE, TR_SALE_HM, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_PR_ITEM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| SMS_LINK |  |  | Open — X08 plus domain owner |
| OP_LOAN | MsOpLoan | Ac_Ledr, UT_SETTING | Open — X08 plus domain owner |
| LOAN_INT_TYPE | MsLoanIntType | RP_DHRN_OS, TR_DHRN_INTREC, TR_DHRN_REC, UT_SETTING_MAIN | Open — X08 plus domain owner |
| TRAD_FINE | MsTradFine | Ac_Ledr | Open — X08 plus domain owner |
| LBR_ROF | MsLbrRof | TR_APR_ISU, TR_JDT_REC, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TOUR, TR_TOUR_ORD, TR_VP, TR_WH_SALE_RTN, UT_SETTING, UT_SETTING_MAIN | Open — X08 plus domain owner |
| REMINDER_OPEN | MsReminderOpen | UT_SETTING | Open — X08 plus domain owner |
| ITM_RATE_ROF | MsItmRateRof | TR_BUL_BOOKING, TR_BUL_SALE, TR_DHRN_ISU, TR_KR_ISU, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING, UT_SETTING_MAIN | Open — X08 plus domain owner |
| ADMIN_SMS | MsAdminSms | TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| CUST_SMS | MsCustSms | TR_BILL_TO, TR_CASH, TR_LEDR_ADJ, TR_LOCT_AMT, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_SL_PR_ITEM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| PURC_WITH_LBR | MsPurcWithLbr | Ac_Ledr, Ac_Rojmel, Mfg_Module, UT_SETTING | Open — X08 plus domain owner |
| DHIRN_COMPOUND | MsDhrnCompound | RP_DHRN_OS, TR_DHRN_INTREC, TR_DHRN_REC | Open — X08 plus domain owner |
| GRID_SCROLL | MsGridScroll | MS_DESIGN_BOOK, TR_AC_OPBL, TR_APR_ISU, TR_BILL_TO, TR_BUL_BOOKING, TR_BUL_SALE, TR_CASH, TR_CONTRA, TR_DHRN_ISU, TR_DHRN_REC, TR_EMP_JV, TR_FINE_SL_PR, TR_FN_INOUT, TR_GOLD_BOOK, TR_INOUT, TR_ITM_LOT, TR_ITM_OPBL, TR_JDT_REC, TR_KR_ISU, TR_LOCT_AMT, TR_MEMB_ADJ, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_MLT_PRO, TR_OTH_COMM, TR_OTH_PURC, TR_PHYSTK, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR, TR_TOUR_ORD, TR_TOUR_SALE, TR_VP, TR_VP_ADJ, TR_WH_SALE, TR_WH_SALE_RTN, UT_CUST_ENTRY, UT_SETTING_MAIN | Open — X08 plus domain owner |
| STK_RPT_TYPE | MsStkRptType | RP_STOCK, UT_SETTING | Open — X08 plus domain owner |
| TOUCH_AUTO_SAVE | MsTchAutoSave | TR_BUL_SALE, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING | Open — X08 plus domain owner |
| PAN_CARD_VAL | MsPanCardVal | TR_SALE, TR_SALE_HM, UT_SETTING | Open — X08 plus domain owner |
| DHRN_PRC | MsDhrnPrc | TR_DHRN_ISU, UT_SETTING | Open — X08 plus domain owner |
| DUP_PRINT | MsSlDupPrint | TR_APR_ISU, TR_BUL_SALE, TR_CASH, TR_FINE_SL_PR, TR_JDT_REC, TR_KR_ISU, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_PURC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING | Open — X08 plus domain owner |
| TAX_CODE | MsTaxCode | TR_BUL_SALE, TR_FINE_SL_PR, TR_PR_SL_UAE, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_ORD, TR_SALE_RTN_UAE, TR_TOUR_ORD | Open — X08 plus domain owner |
| IP_WITH_PC | MsIpWith | UT_EXPORT | Open — X08 plus domain owner |
| CO_STK_MERGE | MsCoStockMerge | BtmSchm, MS_DESIGN_BOOK, RP_HUID, RP_INOUT, RP_PHY_STOCK, RP_ROJMEL, RP_STOCK, RP_TAG, RP_TAG_ESTMATE, RP_TOUR_ZOOM, TR_APR_ISU, TR_FN_INOUT, TR_PHYSTK, TR_PR_SL_UAE, TR_PURC, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TAG_OPBL, TR_TOUR | Open — X08 plus domain owner |
| STK_RPT_VIEW |  |  | Open — X08 plus domain owner |
| PR_AMT_TYPE | MsPrAmtType | TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_WH_SALE_RTN, UT_SETTING_MAIN | Open — X08 plus domain owner |
| CARD_COM_ADJ | MsCardComAdj | TR_SALE, TR_SALE_LBR, TR_SALE_ORD, TR_SL_PR_ITEM, TR_TOUR_ORD | Open — X08 plus domain owner |
| CASH_PURC_AC | MsCashPurcAc | TR_PURC, UT_SETTING | Open — X08 plus domain owner |
| EMP_CODE_MANDATORY | MsEmpCodeMendetry | TR_APR_ISU, TR_BILL_TO, TR_CASH, TR_CONTRA, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_FINE_SL_PR, TR_INOUT, TR_ITM_LOT, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ADJ, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MLT_PRO, TR_PHYSTK, TR_PR_SL_HEDG, TR_PURC, TR_SALE, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TOUR_ORD, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| STOCK_RPT_TYPE | MsStockRptView | Ac_Stock, MS_UPDATE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| LAST_DAY_LOCK | MsLastDayLock | UT_SETTING_MAIN | Open — X08 plus domain owner |
| CASH_LIMIT | MsCashLimit | TR_BILL_TO, TR_CASH, TR_SALE, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TOUR_ORD, UT_SETTING_MAIN | Open — X08 plus domain owner |
| DHRN_WAPP | MsDhrnWapp | TR_DHRN_ISU, UT_SETTING_MAIN | Open — X08 plus domain owner |
| SCHM_WAPP | MsSchmWapp | TR_MEMB_ENT, UT_SETTING_MAIN | Open — X08 plus domain owner |
| LEDR_BILL_COL | MsLedrBillColShow | RP_LEDR, UT_SETTING_MAIN | Open — X08 plus domain owner |
| ALL_ROF_REMOVE | MsAllRofRemove | TR_FINE_SL_PR, TR_OTH_PURC, TR_PR_SL_UAE, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| CO_CODE |  |  | Open — X08 plus domain owner |
| BTN_NAME | MsMainBtn |  | Open — X08 plus domain owner |
| COUNTRY_CODE | MsCountryCode |  | Open — X08 plus domain owner |
| LBR_TYPE | MsLbrType | MS_DESIGN_BOOK, TR_APR_ISU, TR_BUL_SALE, TR_FN_INOUT, TR_INOUT, TR_JDT_REC, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR, TR_TOUR_ORD, TR_TOUR_SALE, TR_VP, TR_WH_SALE, TR_WH_SALE_RTN, UT_SETTING, UT_TAG_PRINT | Open — X08 plus domain owner |
| AC_LC_CODE_LEN |  |  | Open — X08 plus domain owner |
| LOCK_DATE | MsLockDt | MS_COMPANY, TR_APR_ISU, TR_BILL_TO, TR_BUL_BOOKING, TR_BUL_SALE, TR_CARD_REC, TR_CASH, TR_CONTRA, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_EMP_JV, TR_FINE_SL_PR, TR_FN_INOUT, TR_GOLD_BOOK, TR_INOUT, TR_ITM_LOT, TR_JDT_REC, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ADJ, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_MLT_PRO, TR_OTH_COMM, TR_OTH_PURC, TR_PHYSTK, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR, TR_TOUR_ORD, TR_TOUR_SALE, TR_VP, TR_VP_ADJ, TR_WH_SALE, TR_WH_SALE_RTN, UT_BANK, UT_CUST_ENTRY, UT_REMINDER, UT_SETTING_MAIN | Open — X08 plus domain owner |
| TAX_ROF |  |  | Open — X08 plus domain owner |
| RATE_PAR | MsRatePar | TR_BUL_SALE, TR_FINE_SL_PR, TR_PR_SL_HEDG, TR_SALE_LBR, TR_TAG_WT_DIFF, TR_TOUR_SALE, TR_WH_SALE, TR_WH_SALE_RTN, UT_SETTING | Open — X08 plus domain owner |
| OZ_CON_VAL | MsSlPrOzConv | TR_PR_SL_UAE, UT_SETTING | Open — X08 plus domain owner |
| FX_RATE | MsFxRate | TR_PR_SL_UAE, UT_SETTING | Open — X08 plus domain owner |
| FX_CODE | MsFxCode | TR_PR_SL_UAE, UT_SETTING | Open — X08 plus domain owner |
| COUNTRY_ID | MsCountryId | Module_Save, RP_TAG_IMAGE, TR_APR_ISU, TR_BILL_TO, TR_BUL_SALE, TR_CASH, TR_CONTRA, TR_DHRN_ISU, TR_FINE_SL_PR, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ORD_ISU, TR_MLT_PRO, TR_OTH_PURC, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN_UAE, TR_SL_PR_ITEM, TR_TOUR_ORD, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| MFG_ONE_FORM |  |  | Open — X08 plus domain owner |
| CO_CODE |  |  | Open — X08 plus domain owner |
| COUNTER_STK | MsCntrStk | TR_PURC, TR_SALE_RTN, TR_TAG_OPBL, TR_TAG_SPLIT, UT_SET_ADMIN | Open — X08 plus domain owner |
| APR_IMG_PRINT | MsAprImgPrint | TR_APR_ISU, UT_SETTING_MAIN | Open — X08 plus domain owner |
| BILL_PROFIT | MsBillProfit | TR_SALE, TR_SALE_LBR, TR_TOUR_SALE, TR_WH_SALE, UT_SET_ADMIN | Open — X08 plus domain owner |
| BRANCH_ALL_AC_SHOW | MsAllBranchAcShow | MS_ACCT, MS_AUTO_ITEM, MS_LOCT, MS_PRODUCT, RP_ADDRESS, RP_ALL, RP_BILL_PROFIT, RP_DAY_WORK, RP_DHRN_LOAN, RP_DHRN_OS, RP_GST, RP_INOUT, RP_LEDR, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_REMINDER, RP_SLPR_ZOOM, RP_USER, TR_AC_OPBL, TR_APR_ISU, TR_BILL_TO, TR_BUL_BOOKING, TR_BUL_SALE, TR_CARD_REC, TR_CASH, TR_CONTRA, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_EMP_JV, TR_FINE_SL_PR, TR_GOLD_BOOK, TR_ITM_LOT, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ORD_ISU, TR_MLT_PRO, TR_OTH_COMM, TR_OTH_PURC, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR_ORD, TR_TOUR_SALE, TR_UPI_REC, TR_VP, TR_VP_ADJ, TR_WH_SALE, UT_SETTING_MAIN, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| COUNTRY_ID | MsCountryId | Module_Save, RP_TAG_IMAGE, TR_APR_ISU, TR_BILL_TO, TR_BUL_SALE, TR_CASH, TR_CONTRA, TR_DHRN_ISU, TR_FINE_SL_PR, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ORD_ISU, TR_MLT_PRO, TR_OTH_PURC, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN_UAE, TR_SL_PR_ITEM, TR_TOUR_ORD, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| CUR_DAY_POSTING | MsCurDayPosting | Ac_Stock, MS_UPDATE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| DEFAULT_REMINDER | MsDefaultReminder | RP_REMINDER, UT_SETTING_MAIN | Open — X08 plus domain owner |
| DESIGN_HELP | MsDesignHelp | RP_TAG, RP_TAG_IMAGE, TR_APR_ISU, TR_PR_SL_UAE, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_RTN, TR_TAG_CAN, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING_MAIN, UT_TAG_PRINT | Open — X08 plus domain owner |
| DHRN_IMG_PRINT | MsDhrnImgPrint | TR_DHRN_ISU, UT_SETTING_MAIN | Open — X08 plus domain owner |
| EMP_AS_USER | MsEmpAsUser | TR_APR_ISU, TR_BILL_TO, TR_BUL_BOOKING, TR_BUL_SALE, TR_CARD_REC, TR_CASH, TR_CONTRA, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_EMP_JV, TR_FINE_SL_PR, TR_FN_INOUT, TR_GOLD_BOOK, TR_INOUT, TR_ITM_LOT, TR_JDT_REC, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ADJ, TR_MEMB_ENT, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_MLT_PRO, TR_OTH_COMM, TR_OTH_PURC, TR_PHYSTK, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR_ORD, TR_VP, TR_VP_ADJ, TR_WH_SALE, TR_WH_SALE_RTN, UT_SETTING_MAIN | Open — X08 plus domain owner |
| ESTMATE_BANK_LOCK | MsEstmateBankLock | TR_FN_INOUT, TR_JDT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TAG_SPLIT, TR_TOUR_ORD, TR_VP, TR_WH_SALE_RTN, UT_SET_ADMIN | Open — X08 plus domain owner |
| ESTMATE_TAX | MsTaxWithEstmate | TR_FINE_SL_PR, TR_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| FONT_CHANGE | MsFontChange | MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_POINT, MS_PRODUCT, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_USER, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST, RP_CUST_CRM, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_GST, RP_HUID, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MFG_LEDR, RP_MFG_ZOOM, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_PHY_STOCK, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TOUR_ZOOM, RP_TRADING, RP_USER, TR_AC_OPBL, TR_MEMB_ENT, TR_MFG_ISU_REC, UT_AI_TRFR, UT_E_INVOICE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| FONT_NAME | MsFontName | MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_POINT, MS_PRODUCT, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_USER, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST, RP_CUST_CRM, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MFG_LEDR, RP_MFG_ZOOM, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_PHY_STOCK, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TOUR_ZOOM, RP_TRADING, RP_USER, TR_AC_OPBL, TR_MEMB_ENT, TR_MFG_ISU_REC, UT_AI_TRFR, UT_E_INVOICE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| FONT_SIZE | MsFontSize | MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_POINT, MS_PRODUCT, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_USER, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST, RP_CUST_CRM, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MFG_LEDR, RP_MFG_ZOOM, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_PHY_STOCK, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TOUR_ZOOM, RP_TRADING, RP_USER, TR_AC_OPBL, TR_MEMB_ENT, TR_MFG_ISU_REC, UT_AI_TRFR, UT_E_INVOICE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| FONT_STYLE_TYPE | MsFontStyle | MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_POINT, MS_PRODUCT, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_USER, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST, RP_CUST_CRM, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MFG_LEDR, RP_MFG_ZOOM, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_PHY_STOCK, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TOUR_ZOOM, RP_TRADING, RP_USER, TR_AC_OPBL, TR_MEMB_ENT, TR_MFG_ISU_REC, UT_AI_TRFR, UT_E_INVOICE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| F_DISC_DATE | MsFDiscDt | MS_AUTO_ITEM, TR_SALE, TR_WH_SALE | Open — X08 plus domain owner |
| GRID_ROW_HIGHT | MsGridRowHeight | MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_POINT, MS_PRODUCT, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_USER, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST_CRM, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MFG_LEDR, RP_MFG_ZOOM, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_PHY_STOCK, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TOUR_ZOOM, RP_TRADING, RP_USER, TR_AC_OPBL, TR_MEMB_ENT, TR_MFG_ISU_REC, UT_AI_TRFR, UT_E_INVOICE, UT_SETTING_MAIN, UT_SMS, UT_WAPP_WITH_API, UT_WHATSAPP | Open — X08 plus domain owner |
| ITM_FINE_LOCK | MsItmFineLock | TR_PURC, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| ITM_WITH_LOT_STK | MsItmWitLotStk | Ac_Tax, MS_ITEM, RP_STOCK, TR_INOUT, TR_MFG_KR_ISU_REC, TR_PURC, TR_SALE, TR_TAG_CAN, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| KR_DESIGN_IMG_PRINT | MsKrDesignImgPrint | TR_APR_ISU, TR_MFG_ORD_ISU, UT_SETTING_MAIN | Open — X08 plus domain owner |
| LBR_WITH_GHT | MsLbrWithGht | TR_APR_ISU, TR_BUL_SALE, TR_ITM_LOT, TR_MFG_ORD_ISU, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_VP, TR_WH_SALE, TR_WH_SALE_RTN, UT_SETTING_MAIN | Open — X08 plus domain owner |
| LEN_IMG_PATH | MsLenImgPath |  | Open — X08 plus domain owner |
| MAIN_FONT_CHANGE | MsMainFontChange | BtmSchm, MS_ACCT, MS_AC_GROUP, MS_ADD_MAST, MS_AUTO_ITEM, MS_BOOK, MS_BOOKLIST, MS_COMPANY, MS_DESIGN_BOOK, MS_DM, MS_EMP, MS_GOLD_MAST, MS_GROUP, MS_HELP, MS_ITEM, MS_LBR_TYPE, MS_LOCT, MS_MEMB, MS_MFG_MAST, MS_POINT, MS_PRODUCT, MS_RATE, MS_STK_LIMIT, MS_STYLE, MS_TAX, MS_TRADE, MS_UPDATE, MS_USER, MS_WINDOW_SET, RP_ADDRESS, RP_ALL, RP_BALANCE, RP_BILL_PROFIT, RP_CASH_BANK, RP_CONSI_APR, RP_CUST, RP_DAY_WORK, RP_DHRN_LOAN, RP_DHRN_OS, RP_EMP, RP_GRAPH, RP_GST, RP_HUID, RP_INOUT, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MOVEMENT, RP_ORDER, RP_ORD_TRACK, RP_OS, RP_OTH_DETL, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_LEVEL, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_TAG, RP_TAG_ESTMATE, RP_TAG_IMAGE, RP_TRADING, RP_USER, TR_AC_OPBL, TR_APR_ISU, TR_BILL_TO, TR_BUL_BOOKING, TR_BUL_SALE, TR_CARD_REC, TR_CASH, TR_CONTRA, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_EMP_JV, TR_FINE_SL_PR, TR_GOLD_BOOK, TR_INOUT, TR_ITM_LOT, TR_ITM_OPBL, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MEMB_ADJ, TR_MEMB_ENT, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_WITH_LOT, TR_OTH_COMM, TR_OTH_PURC, TR_PHYSTK, TR_PR_SL_HEDG, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_ORD_ADJ, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR, TR_TOUR_ORD, TR_TOUR_SALE, TR_VP, TR_VP_ADJ, TR_WH_SALE, TR_WH_SALE_RTN, UT_AI_TRFR, UT_BANK, UT_BKP, UT_REMINDER, UT_SETTING, UT_SETTING_MAIN, UT_SET_ADMIN, UT_TAG_PRINT | Open — X08 plus domain owner |
| MOBILE_HELP | MsMobileHelp | TR_SALE, TR_SALE_ORD, TR_TOUR_ORD, UT_SETTING_MAIN | Open — X08 plus domain owner |
| NEGATIVE_STK_SALE | MsNegativeStkSale | TR_BUL_SALE, TR_KR_ISU, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_SL_PR_ITEM, UT_SET_ADMIN | Open — X08 plus domain owner |
| OLD_GOLD_TYPE | MsOldGoldType | Ac_Stock | Open — X08 plus domain owner |
| OLD_PURC_TOUCH | MsOldPurcTchGen | TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_WH_SALE_RTN, UT_SET_ADMIN | Open — X08 plus domain owner |
| OPBL_TRFR_BTN | MsOpblTrfrBtn | MS_COMPANY, UT_EXPORT | Open — X08 plus domain owner |
| ORD_IMG_PRINT | MsOrdImgPrint | TR_SALE_ORD, TR_TOUR_ORD, UT_SETTING_MAIN | Open — X08 plus domain owner |
| ORD_TAG_STK_LESS | MsOrdTagLessInStk | TR_SALE_ORD, TR_TOUR_ORD, UT_SETTING_MAIN | Open — X08 plus domain owner |
| OS_BILL_ORNA_ISU | MsOsBillOrnaIsu | BtmSchm, TR_BILL_TO, TR_MLT_PRO, TR_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| OS_BILL_SMS | MsOsBillSms | TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_SL_PR_ITEM, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| OS_FINE_INT | MsFineInt | TR_WH_SALE | Open — X08 plus domain owner |
| OTH_ITM_WT_REMOVE | MsOthItmWtRemove | MS_ITEM, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| PRINT_FORM_BTN | MsPrintFormBtn | MS_PRINT, UT_SETTING_MAIN | Open — X08 plus domain owner |
| PROFIT_RPT_TYPE | MsBalanceSheetType | Ac_Final, RP_BALANCE, RP_BAL_ZOOM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| PR_RATE_ROF | MsPrRateRof | TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_WH_SALE_RTN, UT_SETTING_MAIN | Open — X08 plus domain owner |
| PR_TDS_TAX | MsPrTdsTax | TR_FN_INOUT, TR_PURC, UT_SETTING_MAIN | Open — X08 plus domain owner |
| PURC_LOT | MsPurcLot | TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_TAG_CAN, TR_TAG_OPBL, UT_SET_ADMIN | Open — X08 plus domain owner |
| PURC_WITH_HMTAX | MsPurcWithHmTax | MS_COMPANY, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_HUID, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MOVEMENT, RP_ORDER, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TRADING, RP_USER, TR_SALE, TR_SALE_HM, TR_SALE_ORD, TR_TOUR_ORD, UT_SETTING_MAIN | Open — X08 plus domain owner |
| QR_CODE_GEN | MsQrCodeGen | TR_ITM_LOT, TR_PHYSTK, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, UT_SETTING_MAIN, UT_TAG_PRINT | Open — X08 plus domain owner |
| RPT_TOT_SHOW | MsRptTotShow | RP_LEDR, RP_MFG_LEDR, UT_SETTING_MAIN | Open — X08 plus domain owner |
| SALES_WITH_HMTAX | MsSalesWithHmTax | MS_COMPANY, RP_BAL_ZOOM, RP_BILL_PROFIT, RP_CASH_BANK, RP_DAY_WORK, RP_DHRN_OS, RP_EMP, RP_HUID, RP_INOUT, RP_JDTR_ZOOM, RP_LC_INOUT, RP_LC_SALE, RP_LEDR, RP_MOVEMENT, RP_ORDER, RP_REMINDER, RP_ROJMEL, RP_SLPR_ZOOM, RP_STK_MOVE, RP_STOCK, RP_STOCK_FINE, RP_STOCK_VALUE, RP_TAG, RP_TAG_ESTMATE, RP_TRADING, RP_USER, UT_SETTING_MAIN, UT_WINDOW | Open — X08 plus domain owner |
| SILVER_THREE_DIGIT | MsSilverWt3Digit | RP_LEDR, RP_MFG_LEDR, TR_BUL_SALE, TR_FINE_SL_PR, TR_KR_ISU, TR_MFG_GHAT_REC, TR_PURC, TR_PURC_HM, TR_SALE_LBR, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| SL_BILL_IMG | MsSlBillImg | TR_SALE, TR_SALE_HM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| SL_MRP_TAX_REVERC | MsMrpTaxReverc | TR_PR_SL_UAE, TR_SALE | Open — X08 plus domain owner |
| SL_NWT_LOCK | MsSlNwtLock | TR_BUL_SALE, TR_FN_INOUT, TR_PR_SL_UAE, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, TR_TOUR_SALE, TR_WH_SALE, TR_WH_SALE_RTN, UT_SET_ADMIN | Open — X08 plus domain owner |
| SL_TAG_WT_DIFF | MsSlAndTagWtDiff | Ac_Stock, UT_SETTING_MAIN | Open — X08 plus domain owner |
| SL_TDS_TAX | MsSlTdsTax | TR_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| STK_LMIT_WITH_DESIGN | MsStkLimitWithDesign | MS_STK_LIMIT, TR_PURC, TR_SALE_ORD, TR_TAG_OPBL, UT_SET_ADMIN | Open — X08 plus domain owner |
| TAG_AUTO_PRINT | MsTagRowAutoPrint | TR_TAG_OPBL, UT_SETTING_MAIN | Open — X08 plus domain owner |
| TAG_ENTRY_DESIGN_GEN | MsDesignMastHelp | TR_PURC, TR_TAG_OPBL, UT_SETTING_MAIN | Open — X08 plus domain owner |
| TAG_VCH_AUTO_SAVE | MsTagVchAutoSave | MS_DESIGN_BOOK, TR_PURC, TR_TAG_OPBL, UT_SETTING_MAIN | Open — X08 plus domain owner |
| TILE_MENU | MsTileMenuShow | MS_WINDOW_SET, UT_WINDOW | Open — X08 plus domain owner |
| TOT_AMT_ROF | MsTotAmtRof | TR_FN_INOUT, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_SALE, TR_SALE_HM, TR_SALE_RTN_UAE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| TOT_FINE_STK_TYPE | MsTotFineStkType | RP_BAL_ZOOM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| T_DISC_DATE | MsTDiscDt | MS_AUTO_ITEM, TR_SALE, TR_WH_SALE | Open — X08 plus domain owner |
| USER_KR_TOUCH_HIDE | MsUserKrTouchHide | TR_PURC, TR_TAG_OPBL, UT_SET_ADMIN | Open — X08 plus domain owner |
| VCH_DESC_HELP_LENT | MsVchDescHelpLenth | TR_APR_ISU, TR_BUL_SALE, TR_CARD_REC, TR_CASH, TR_DHRN_INTREC, TR_DHRN_ISU, TR_DHRN_REC, TR_FN_INOUT, TR_INOUT, TR_JDT_REC, TR_KR_ISU, TR_LEDR_ADJ, TR_LOCT_AMT, TR_MFG_GHAT_REC, TR_MFG_ISU_REC, TR_MFG_ITEM, TR_MFG_KR_ISU_REC, TR_MFG_ORD_ISU, TR_MFG_ORD_REC, TR_MFG_WITH_LOT, TR_OTH_PURC, TR_PR_SL_UAE, TR_PURC, TR_PURC_HM, TR_REP_REC, TR_SALE, TR_SALE_HM, TR_SALE_LBR, TR_SALE_ORD, TR_SALE_RTN, TR_SALE_RTN_UAE, TR_SL_EBILL, TR_SL_PR_ITEM, TR_TAG_CAN, TR_TAG_OPBL, TR_TAG_SPLIT, TR_TAG_WT_DIFF, TR_TOUR, TR_TOUR_ORD, TR_WH_SALE_RTN, UT_SETTING_MAIN | Open — X08 plus domain owner |
| WAPP_DELAY |  |  | Open — X08 plus domain owner |
| WAPP_IMG_GWT | MsWappImgGwt | RP_TAG_IMAGE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| WAPP_SL_PRINT | MsWappSlPrint | TR_SALE, TR_SALE_HM, UT_SETTING_MAIN | Open — X08 plus domain owner |
| WAP_DELAY |  |  | Open — X08 plus domain owner |
| WEB_IMAGE |  |  | Open — X08 plus domain owner |
| WEB_PATH |  |  | Open — X08 plus domain owner |
| WH_BILL_IMG | MsWhBillImg | TR_BUL_SALE, TR_TOUR_SALE, TR_WH_SALE, UT_SETTING_MAIN | Open — X08 plus domain owner |
| YEAR_GOLD_SL | MsYearGoldSl | UT_SET_ADMIN | Open — X08 plus domain owner |
| YEAR_SILVER_SL | MsYearSilverSl | UT_SET_ADMIN | Open — X08 plus domain owner |

## Companion, startup and inferred-source obligations

The eight supporting primary C# units are indexed under `support` requirements. The 199 NextDm source units include 123 differing shared implementations; inspect the changed branches and settings, not only filenames. The MDI lexical case index in `desktop-form-reference.json` contains 283 case occurrences (267 distinct strings), which includes group captions/aliases and requires semantic reconciliation with the 198 retained menu entries.

Preserve NextEmp/NextImage/AllImage and other actual integration/startup references under P13/X32. Classify their real supported functions; do not invent payroll or other modules from their filenames. Scope resolution and missing-artifact recovery remain mandatory before final acceptance.
