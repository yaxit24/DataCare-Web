# Module Map — 204 forms → 14 functional modules

_Generated 2026-06-30 from `module-map.json` (204 forms; 57 posting transactions). Functional grouping aligns to `web/apps/api/src/modules`._

Legend: **Posting** = writes the `AC_DATA` ledger on save. **Type** = master/transaction/report/utility/other (from auto-extraction).

## Summary

| Module | Forms | Posting txns |
|---|---|---|
| Foundation / Auth / Company-Year | 10 | 0 |
| Membership / Loyalty | 4 | 2 |
| Bullion / Tour / VP | 14 | 13 |
| Reports | 42 | 0 |
| Utilities / Settings / Integrations | 19 | 0 |
| Masters | 20 | 0 |
| Sales | 11 | 11 |
| Purchase | 4 | 4 |
| Inventory / Tags / Stock | 11 | 6 |
| Manufacturing / Karigar / Job-Work | 12 | 10 |
| Loans / Dhrn (pledge) | 5 | 3 |
| Finance / Cash-Bank | 6 | 4 |
| Accounting / Ledgers / Final Accounts | 8 | 2 |
| GST & E-Invoice | 4 | 1 |
| Framework / shared classes (not user forms) | 34 | 1 |

## Foundation / Auth / Company-Year

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `AuthClass` | other |  |  |
| `MS_COMPANY` | master |  | AC_GROUP, BOOK_DATA, BOOK_DETL, BOOK_IDTL, COL_MAST, CONV_MAST, CO_MAST, CO_SET, CO_SET_NEW, FAN_AC_MAST … |
| `MS_DM` | master |  |  |
| `MS_HELP` | master |  |  |
| `MS_LOGIN` | master |  | AC_MAST_SRNO |
| `MS_OPNCOMP` | master |  | AC_MAST_SRNO, BOOK_IDTL, CO_SET, MENU_DATA |
| `MS_UPDATE` | master |  | AC_DATA, AC_GROUP, AC_MAST, AD_MAST, APR_DETL, BAL_GR, BANK_RECONCILE, BAR_CAN_DETL, BAR_DATA, BAR_DETL … |
| `MS_USER` | master |  | BOOK_DATA, BOOK_IDTL, LOGIN_MAST, MENU_DATA, TILE_DATA, USER_SET |
| `MS_WINDOW_SET` | master |  | CO_SET_NEW, TILE_DATA |
| `MS_YEAR` | master |  | AC_GROUP, AC_MAST, BAL_GR, BOOK_DATA, BOOK_DETL, COL_MAST, CONV_MAST, CO_SET, CO_SET_NEW, EMP_MAST … |

## Membership / Loyalty

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `MS_MEMB` | master |  |  |
| `MS_POINT` | master |  |  |
| `TR_MEMB_ADJ` | transaction | ✅ | AD_MEMB, DELETE_DATA |
| `TR_MEMB_ENT` | transaction | ✅ | DELETE_DATA, TEMP_AD_DATA, USER_DATA |

## Bullion / Tour / VP

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `MS_GOLD_MAST` | master |  | DG_GOLD_MAST |
| `TR_BUL_BOOKING` | transaction | ✅ | DELETE_DATA |
| `TR_BUL_SALE` | transaction | ✅ | BUL_DATA, DELETE_DATA, RATE_CUT_ISU_REC, TOUCH_MAST |
| `TR_FINE_SL_PR` | transaction | ✅ | MAIN_STOCK, PR_DETL, RATE_CUT_ISU |
| `TR_FN_INOUT` | transaction | ✅ | DELETE_DATA, FAN_DATA, FAN_DETL, GROUP_MAST, ITEM_MAST, PRODUCT_MAST |
| `TR_GOLD_BOOK` | transaction | ✅ | DELETE_DATA |
| `TR_INOUT` | transaction | ✅ | DELETE_DATA, SL_ORD_DETL |
| `TR_OTH_COMM` | transaction | ✅ | DELETE_DATA |
| `TR_PR_SL_HEDG` | transaction | ✅ | MAIN_STOCK, PR_DETL, RATE_CUT_ISU |
| `TR_TOUR` | transaction | ✅ | APR_DETL, BAR_DETL, DELETE_DATA |
| `TR_TOUR_ORD` | transaction | ✅ | BAR_DETL, DELETE_DATA, MAIN_STOCK, SL_ORD_DETL, USER_DATA |
| `TR_TOUR_SALE` | transaction | ✅ | APR_DETL, BAR_DETL, DELETE_DATA, RATE_CUT_DATA, RATE_CUT_ISU_REC, SL_ORD_DETL, TOUCH_MAST, USER_DATA |
| `TR_VP` | transaction | ✅ | DELETE_DATA, RATE_CUT_ISU_REC |
| `TR_VP_ADJ` | transaction | ✅ | DELETE_DATA, RATE_CUT_DATA |

## Reports

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `RP_ADDRESS` | report |  | TEMP_ADD |
| `RP_ALL` | report |  | RATE_CUT_ISU_REC, SL_ORD_DETL |
| `RP_BALANCE` | report |  | AC_DATA, BAL_GR |
| `RP_BAL_ZOOM` | report |  | LEDR_AC_DATA, REPORT_DATA |
| `RP_BILL_PROFIT` | report |  |  |
| `RP_CASH_BANK` | report |  | TEMP_AD_DATA |
| `RP_CONSI_APR` | report |  |  |
| `RP_CUST` | report |  | AC_MAST |
| `RP_CUST_CRM` | report |  |  |
| `RP_DAY_WORK` | report |  |  |
| `RP_EMP` | report |  | REPORT_DATA |
| `RP_GRAPH` | report |  |  |
| `RP_HUID` | report |  | BAR_DETL, TAG_STOCK_PRINT |
| `RP_INOUT` | report |  | REPORT_DATA |
| `RP_JDTR_ZOOM` | report |  |  |
| `RP_LC_INOUT` | report |  |  |
| `RP_LC_SALE` | report |  |  |
| `RP_LEDR` | report |  | FINE_DATA, LEDR_AC_DATA |
| `RP_MFG` | report |  |  |
| `RP_MFG_LEDR` | report |  |  |
| `RP_MFG_ZOOM` | report |  | MFG_MAST |
| `RP_MOVEMENT` | report |  |  |
| `RP_ORDER` | report |  |  |
| `RP_ORD_TRACK` | report |  |  |
| `RP_OS` | report |  | LEDR_AC_DATA |
| `RP_OTH_DETL` | report |  |  |
| `RP_PHY_STOCK` | report |  | TAG_STOCK_PRINT |
| `RP_REMINDER` | report |  | PR_DATA, RATE_CUT_DATA, REPORT_DATA, SL_DATA, USER_REQUEST |
| `RP_ROJMEL` | report |  | GROUP_MAST, LEDR_AC_DATA, ROJMEL_BAL, TAG_STOCK_PRINT |
| `RP_SLPR_ZOOM` | report |  |  |
| `RP_STK_LEVEL` | report |  |  |
| `RP_STK_MOVE` | report |  | MAIN_STOCK |
| `RP_STOCK` | report |  | ITEM_MAST, MAIN_STOCK, REPORT_DATA |
| `RP_STOCK_FINE` | report |  | BAL_GR, GROUP_MAST, ITEM_MAST |
| `RP_STOCK_VALUE` | report |  |  |
| `RP_TAG` | report |  | APR_DETL, BAR_CAN_DETL, KR_DETL, LBR_ISU_DETL, MAIN_STOCK, RATE_CUT_ISU, SL_DETL, TAG_STOCK_PRINT, TAG_SUM_DATA |
| `RP_TAG_ESTMATE` | report |  | TAG_IMAGE_DATA, TAG_STOCK_PRINT |
| `RP_TAG_IMAGE` | report |  |  |
| `RP_TAX` | report |  |  |
| `RP_TOUR_ZOOM` | report |  |  |
| `RP_TRADING` | report |  |  |
| `RP_USER` | report |  | REPORT_DATA, TAG_STOCK_PRINT, USER_DATA |

## Utilities / Settings / Integrations

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `UT_AI_TRFR` | utility |  | BAR_DETL, BOOK_IDTL, TAG_DATA |
| `UT_BKP` | utility |  |  |
| `UT_CUST_ENTRY` | utility |  |  |
| `UT_EXPORT` | utility |  | AC_MAST, AD_ADJ, AD_DATA, AD_MAST, AD_MEMB, BAR_CAN_DATA, BAR_CAN_DETL, BAR_CAN_IDTL, BAR_DATA, BAR_DETL … |
| `UT_HDD` | utility |  | HDD_MAST |
| `UT_IMPORT` | utility |  | AC_GROUP, AC_MAST, AC_MAST_SRNO, ADD_MAST, AD_ADJ, AD_DATA, AD_MAST, AD_MEMB, AD_OS, APR_DATA … |
| `UT_PWD_UPDATE` | utility |  | LOGIN_MAST |
| `UT_REMINDER` | utility |  |  |
| `UT_REPORT` | utility |  |  |
| `UT_SETTING` | utility |  | COL_MAST, CO_SET, CO_SET_NEW |
| `UT_SETTING_MAIN` | utility |  | CO_SET, CO_SET_NEW, MENU_DATA |
| `UT_SET_ADMIN` | utility |  | CO_SET_NEW |
| `UT_SMS` | utility |  | LEDR_AC_DATA, MSG_MAST |
| `UT_USER_REQUEST` | utility |  | USER_REQUEST |
| `UT_VCH_RE_NUMBR` | utility |  | AD_ADJ, BAR_DATA, BAR_DETL, BAR_IDTL, BILL_OS_DATA, CASH_DATA, PR_DATA, PR_DETL, PR_IDTL, RATE_CUT_DATA … |
| `UT_WAPP_WITH_API` | utility |  | LEDR_AC_DATA, POINT_MAST |
| `UT_WEB_CAM` | utility |  |  |
| `UT_WHATSAPP` | utility |  | CO_SET_NEW, LEDR_AC_DATA, MSG_MAST, POINT_MAST |
| `UT_WINDOW` | utility |  |  |

## Masters

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `MS_ACCT` | master |  | AC_MAST |
| `MS_AC_GROUP` | master |  | AC_GROUP, BOOK_IDTL |
| `MS_ADD_MAST` | master |  | ADD_MAST |
| `MS_AUTO_ITEM` | master |  | BAR_DETL, BAR_IDTL, CO_SET_NEW, ITEM_MAST |
| `MS_BOOK` | master |  | BOOK_DATA, BOOK_DETL |
| `MS_BOOKLIST` | master |  |  |
| `MS_DESIGN_BOOK` | master |  | DESIGN_DETL |
| `MS_EMP` | master |  |  |
| `MS_GROUP` | master |  | ITEM_MAST |
| `MS_ITEM` | master |  | BAR_DETL, GROUP_MAST, PRODUCT_MAST |
| `MS_LBR_TYPE` | master |  | BAR_DETL |
| `MS_LOCT` | master |  | BOOK_DATA, BOOK_DETL, MENU_DATA, TABLE_MAST |
| `MS_PRINT` | master |  |  |
| `MS_PRODUCT` | master |  | AD_MAST, BOOK_IDTL, CO_MAST, ITEM_MAST, PRODUCT_MAST, TABLE_MAST, TAG_STOCK |
| `MS_RATE` | master |  | GROUP_MAST, RATE_MAST |
| `MS_STK_LIMIT` | master |  |  |
| `MS_STYLE` | master |  | DESIGN_MAST, ITM_CITY, MODEL_MAST |
| `MS_TASTING` | master |  |  |
| `MS_TAX` | master |  | AC_MAST |
| `MS_TRADE` | master |  |  |

## Sales

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `TR_BILL_TO` | transaction | ✅ | DELETE_DATA, SL_DATA |
| `TR_SALE` | transaction | ✅ | AC_MAST, APR_DETL, BAR_DETL, BILL_OS_DATA, DELETE_DATA, MAIN_STOCK, POINT_MEMB, PRINT_MAST, PR_DATA, SL_DATA … |
| `TR_SALE_HM` | transaction | ✅ | AC_MAST, APR_DETL, BAR_DETL, BILL_OS_DATA, DELETE_DATA, PRINT_MAST, SL_DATA, SL_DETL, SL_IDTL, SL_ORD_ADJ … |
| `TR_SALE_LBR` | transaction | ✅ | DELETE_DATA, LBR_ISU_DETL, RATE_CUT_ISU_REC, SL_DETL, SL_ORD_DETL, TOUCH_MAST, USER_DATA |
| `TR_SALE_ORD` | transaction | ✅ | AC_DATA, BAR_DETL, DELETE_DATA, MAIN_STOCK, ROJ_MEL_DATA, SL_ORD_DETL, UPI_DATA, USER_DATA |
| `TR_SALE_RTN` | transaction | ✅ | BAR_DETL, DELETE_DATA, MAIN_STOCK, RATE_CUT_ISU_REC, TAG_SET, USER_DATA |
| `TR_SALE_RTN_UAE` | transaction | ✅ | APR_DETL, BAR_DETL, DELETE_DATA, PRINT_MAST, SRNO_MAST |
| `TR_SL_ORD_ADJ` | transaction | ✅ | BAR_DETL, BAR_IDTL, SL_ORD_DETL |
| `TR_SL_PR_ITEM` | transaction | ✅ | DELETE_DATA, PRINT_MAST |
| `TR_WH_SALE` | transaction | ✅ | APR_DETL, BAR_DETL, DELETE_DATA, MAIN_STOCK, PRINT_MAST, RATE_CUT_DATA, RATE_CUT_ISU_REC, SL_ORD_DETL, TOUCH_MAST, USER_DATA |
| `TR_WH_SALE_RTN` | transaction | ✅ | DELETE_DATA, RATE_CUT_ISU_REC |

## Purchase

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `TR_OTH_PURC` | transaction | ✅ | DELETE_DATA |
| `TR_PR_SL_UAE` | transaction | ✅ | APR_DETL, DELETE_DATA |
| `TR_PURC` | transaction | ✅ | APR_DETL, DELETE_DATA, SL_ORD_DETL, SRNO_MAST, TAG_SET, TOUCH_MAST, USER_DATA |
| `TR_PURC_HM` | transaction | ✅ | BAR_DETL, BAR_IDTL, DELETE_DATA, SRNO_MAST |

## Inventory / Tags / Stock

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `Ac_Stock` | other |  | BAR_DETL, DM_DATA, DM_KR_DATA, INOUT_DETL, LOT_DETL, MAIN_STOCK, TAG_SUM_DATA |
| `ClassTagList` | other |  |  |
| `TR_ITM_LOT` | transaction | ✅ | TAG_PRINT_DATA |
| `TR_ITM_OPBL` | transaction |  |  |
| `TR_PHYSTK` | transaction | ✅ | APR_DETL, BAR_DETL, BAR_IDTL, MAIN_STOCK, TAG_PRINT_DATA |
| `TR_TAG_CAN` | transaction | ✅ | BAR_DETL, DELETE_DATA, MAIN_STOCK |
| `TR_TAG_OPBL` | transaction | ✅ | BAR_DETL, BAR_IDTL, DELETE_DATA, MFG_DETL, PRINT_MAST, SL_ORD_DETL, SRNO_MAST, TAG_IMAGE_DATA, TAG_PRINT_DATA, TAG_SET |
| `TR_TAG_SPLIT` | transaction | ✅ | RATE_CUT_ISU_REC, TAG_PRINT_DATA, TAG_SET, USER_DATA |
| `TR_TAG_WT_DIFF` | transaction | ✅ | BAR_DETL, LBR_ISU_DETL, RATE_CUT_ISU_REC, TAG_PRINT_DATA |
| `TagOthDetail` | other |  |  |
| `UT_TAG_PRINT` | utility |  | BAR_DETL, PRINT_MAST, TAG_PRINT_DATA |

## Manufacturing / Karigar / Job-Work

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `MS_MFG_MAST` | master |  | BOOK_DATA, MENU_DATA, MFG_MAST, SL_ORD_DETL, USER_SET |
| `Mfg_Module` | other |  | AC_MAST, BOOK_DATA, BOOK_IDTL, CO_SET, CO_SET_NEW, ITEM_MAST, MENU_DATA, MFG_MAST, PRODUCT_MAST, STATE_MAST … |
| `TR_KR_ISU` | transaction | ✅ | DELETE_DATA |
| `TR_MFG_GHAT_REC` | transaction | ✅ | APR_DETL, DELETE_DATA, MFG_DETL |
| `TR_MFG_ISU_REC` | transaction | ✅ | DELETE_DATA, MENU_DATA, MFG_DETL, MFG_ISU_REC, TAG_PRINT_DATA |
| `TR_MFG_ITEM` | transaction | ✅ | DELETE_DATA, MENU_DATA, MFG_DETL, TAG_PRINT_DATA |
| `TR_MFG_KR_ISU_REC` | transaction | ✅ | DELETE_DATA, MENU_DATA, MFG_DETL, SL_ORD_DETL, TAG_PRINT_DATA |
| `TR_MFG_ORD_ISU` | transaction | ✅ | DELETE_DATA, SL_ORD_DETL |
| `TR_MFG_ORD_REC` | transaction | ✅ | APR_DETL, DELETE_DATA, MENU_DATA, MFG_DETL, TAG_PRINT_DATA |
| `TR_MFG_WITH_LOT` | transaction | ✅ | DELETE_DATA, MENU_DATA, MFG_DETL, TAG_PRINT_DATA |
| `TR_MLT_PRO` | transaction | ✅ | DELETE_DATA, SL_DATA |
| `TR_REP_REC` | transaction | ✅ | REP_DETL |

## Loans / Dhrn (pledge)

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `RP_DHRN_LOAN` | report |  | DHRN_DATA, DHRN_ISU_DATA |
| `RP_DHRN_OS` | report |  | REPORT_DATA |
| `TR_DHRN_INTREC` | transaction | ✅ | DELETE_DATA |
| `TR_DHRN_ISU` | transaction | ✅ | DELETE_DATA, DHRN_ISU_DATA |
| `TR_DHRN_REC` | transaction | ✅ | DELETE_DATA, DHRN_ISU_DATA, DHRN_ISU_DETL |

## Finance / Cash-Bank

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `TR_CARD_REC` | transaction | ✅ | DELETE_DATA |
| `TR_CASH` | transaction | ✅ | DELETE_DATA |
| `TR_CONTRA` | transaction | ✅ | DELETE_DATA |
| `TR_LOCT_AMT` | transaction | ✅ | DELETE_DATA |
| `TR_UPI_REC` | transaction |  |  |
| `UT_BANK` | utility |  | AC_DATA, CASH_DATA |

## Accounting / Ledgers / Final Accounts

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `Ac_Final` | other |  | AC_DATA, LEDR_AC_DATA |
| `Ac_Image` | other |  | COL_MAST, CO_SET, CO_SET_NEW, GROUP_MAST, INOUT_DETL, ITEM_MAST, ITM_WT_MAST, LOCT_MAST, MENU_DATA, PRODUCT_MAST |
| `Ac_Ledr` | other |  | AC_DATA, PR_DATA, PR_DETL, SL_DATA |
| `Ac_Rojmel` | other |  | ROJ_MEL_DATA |
| `TR_AC_OPBL` | transaction | ✅ | CONTRA_DATA, DELETE_DATA, OP_DATA, USER_DATA |
| `TR_EMP_JV` | transaction |  |  |
| `TR_JDT_REC` | transaction | ✅ | APR_DETL, DELETE_DATA, MFG_DETL, TAG_PRINT_DATA |
| `TR_LEDR_ADJ` | transaction |  |  |

## GST & E-Invoice

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `Ac_Tax` | other |  | AD_OS, BAR_DATA, DHRN_DATA, MFG_ISU_REC, REMARK_DATA, SL_ORD_ADJ, TAX_DATA |
| `RP_GST` | report |  |  |
| `TR_SL_EBILL` | transaction | ✅ | DELETE_DATA, ITEM_MAST, SL_DATA |
| `UT_E_INVOICE` | utility |  |  |

## Framework / shared classes (not user forms)

| Form | Type | Posting | Tables written (header/detail/ledger/…) |
|---|---|---|---|
| `AuthError` | other |  |  |
| `BtmSchm` | other |  | AC_DATA, AC_MAST, AD_ADJ, AD_DATA, AD_MAST, AD_MEMB, APR_DETL, APR_IDTL, BAR_DATA, BAR_DETL … |
| `ClsAddlDocDtls` | other |  |  |
| `ClsAttribDtls` | other |  |  |
| `ClsBchDtls` | other |  |  |
| `ClsBuyerDtls` | other |  |  |
| `ClsContrDtls` | other |  |  |
| `ClsDispDtls` | other |  |  |
| `ClsDocDtls` | other |  |  |
| `ClsDocPerdDtls` | other |  |  |
| `ClsExpDtls` | other |  |  |
| `ClsItemList` | other |  |  |
| `ClsPayDtls` | other |  |  |
| `ClsPrecDocDtls` | other |  |  |
| `ClsRefDtls` | other |  |  |
| `ClsSellerDtls` | other |  |  |
| `ClsShipDtls` | other |  |  |
| `ClsTranDtls` | other |  |  |
| `ClsValDtls` | other |  |  |
| `DC_Main` | other |  | BAL_GR, GROUP_MAST, ITEM_MAST |
| `Data` | other |  |  |
| `DcClass` | other |  |  |
| `DcPrintClass` | other |  |  |
| `ErrorResp` | other |  |  |
| `IRNClass` | other |  |  |
| `IRNData` | other |  |  |
| `MDI_FORM` | other |  | CONV_MAST, CO_SET |
| `Module_Save` | other |  |  |
| `Module_Schm` | other |  | AC_GROUP, AC_MAST, AC_MAST_SRNO, AD_DATA, AD_MEMB, APP_USER_DATA, BOOK_DATA, BOOK_DETL, BOOK_IDTL, CONV_MAST … |
| `Module_WhatsApp` | other |  |  |
| `OlockerService` | other |  |  |
| `PolicyModels` | other |  |  |
| `TR_APR_ISU` | transaction | ✅ | APR_DETL, BAR_DETL, DELETE_DATA, SL_ORD_DETL |
| `Translator` | other |  |  |

