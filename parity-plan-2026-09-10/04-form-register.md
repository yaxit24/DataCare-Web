# Form, engine and menu register

> Frozen 10 September inventory. Current implementation/availability and scanner corrections are in [the 11 September review](11-current-completion-review.md); follow [the execution continuation](12-execution-addendum.md). Retain these source identities while revalidating all current web mappings.

Snapshot: 10 September 2026. All 204 desktop source units are accounted for here; 153 have a positive field surface in the heuristic extractor. The remaining units include launchers and shared logic. They still require behavioural disposition. A web route mapping below is inherited from the earlier matrix and rechecked only for file existence. It does not establish that a screen is equivalent or a workflow is working.

Use this register with P00–P14 in the implementation plan. Each unit must acquire an approved behaviour contract, per-mode mapping, field and transition tests, desktop differential evidence, and business acceptance. Shared pages require separate tests for each desktop variant.

The JSON companion records every named grid column and its source line candidates. All requirements start `unverified`; there is no automatic promotion from a matching label or a passing source scan.

The [additional source register](09-additional-source-register.md) adds 916 modifier-bearing input declarations missed by this frozen scanner and eight supporting C# files outside the 204-unit directory. Use both registers; these counts are not exhaustive business requirements.

Control declarations and event-handler locations are also indexed in `evidence/control-requirements.json` and `evidence/event-requirements.json`. Counts of validations/confirmations are scanner candidates: message-box style, caption, visibility and runtime branches still require interpretation.

| Unit | Track | Inputs | Named / declared grid columns | Candidate web routes |
| --- | --- | ---: | ---: | --- |
| `Ac_Final` | P10 | 0 | 0 / 0 | /utilities/year-end, /reports/balance-sheet |
| `Ac_Image` | P00 / P01 / P02 | 0 | 0 / 0 | /masters/party, /txn/tag-print |
| `Ac_Ledr` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `Ac_Rojmel` | P10 | 0 | 0 / 0 | /reports/day-book |
| `Ac_Stock` | P00 / P01 / P02 | 0 | 0 / 0 | /txn/stock, /reports/tag-stock |
| `Ac_Tax` | P00 / P01 / P02 | 0 | 0 / 0 | /reports/gstr1, /reports/gstr2, /reports/gstr3b |
| `AuthClass` | P00 / P01 / P02 | 0 | 0 / 0 | /login |
| `AuthError` | P00 / P01 / P02 | 0 | 0 / 0 | /login |
| `BtmSchm` | P00 / P01 / P02 | 0 | 0 / 0 | /txn/scheme |
| `ClassTagList` | P00 / P01 / P02 | 0 | 0 / 0 | /txn/stock, /reports/tag-stock |
| `ClsAddlDocDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsAttribDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsBchDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsBuyerDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsContrDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsDispDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsDocDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsDocPerdDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsExpDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsItemList` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `ClsPayDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsPrecDocDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsRefDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsSellerDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsShipDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsTranDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `ClsValDtls` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `DC_Main` | P00 / P01 / P02 | 0 | 0 / 0 | /dashboard |
| `Data` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `DcClass` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `DcPrintClass` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `ErrorResp` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `IRNClass` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `IRNData` | P00 / P01 / P02 | 0 | 0 / 0 | /utilities/e-invoice |
| `MDI_FORM` | P00 / P01 / P02 | 4 | 0 / 0 | /dashboard |
| `MS_ACCT` | P03 | 55 | 0 / 0 | /masters/accounts, /masters/customers, /masters/party |
| `MS_AC_GROUP` | P03 | 9 | 0 / 0 | /masters/ac-groups |
| `MS_ADD_MAST` | P03 | 32 | 0 / 0 | /masters/addresses |
| `MS_AUTO_ITEM` | P03 | 8 | 24 / 24 | /masters/auto-item |
| `MS_BOOK` | P03 | 15 | 4 / 4 | /masters/books |
| `MS_BOOKLIST` | P03 | 1 | 0 / 0 | /masters/books |
| `MS_COMPANY` | P03 | 39 | 0 / 0 | /masters/companies, /admin/provision, /select |
| `MS_DESIGN_BOOK` | P03 | 5 | 59 / 76 | /masters/styles, /masters/designs, /masters/models |
| `MS_DM` | P03 | 8 | 0 / 0 | /masters/diamonds |
| `MS_EMP` | P03 | 7 | 0 / 0 | /masters/employees |
| `MS_GOLD_MAST` | P03 | 11 | 0 / 0 | /masters/gold-rate |
| `MS_GROUP` | P03 | 16 | 0 / 0 | /masters/groups |
| `MS_HELP` | P03 | 1 | 0 / 0 | No candidate surface |
| `MS_ITEM` | P03 | 24 | 0 / 0 | /masters/items |
| `MS_LBR_TYPE` | P03 | 6 | 0 / 0 | /masters/labour, /masters/labour-update |
| `MS_LOCT` | P03 | 26 | 0 / 0 | /masters/locations |
| `MS_LOGIN` | P03 | 2 | 0 / 0 | /login, /admin/users |
| `MS_MEMB` | P03 | 34 | 0 / 0 | /txn/membership, /txn/scheme |
| `MS_MFG_MAST` | P03 | 1 | 14 / 14 | /masters/mfg |
| `MS_OPNCOMP` | P03 | 3 | 0 / 0 | /masters/companies, /admin/provision, /select |
| `MS_POINT` | P03 | 6 | 6 / 6 | /masters/points |
| `MS_PRINT` | P03 | 0 | 0 / 0 | /masters/print-formats |
| `MS_PRODUCT` | P03 | 12 | 0 / 0 | /masters/products |
| `MS_RATE` | P03 | 8 | 10 / 10 | /masters/rates, /txn/daily-rate |
| `MS_STK_LIMIT` | P03 | 4 | 11 / 11 | /masters/item-weights |
| `MS_STYLE` | P03 | 2 | 0 / 0 | /masters/styles, /masters/designs, /masters/models |
| `MS_TASTING` | P03 | 0 | 0 / 0 | No candidate surface |
| `MS_TAX` | P03 | 8 | 5 / 5 | /masters/taxes |
| `MS_TRADE` | P03 | 1 | 9 / 9 | /masters/trade |
| `MS_UPDATE` | P03 | 2 | 0 / 0 | /utilities/data-refresh, /masters/labour-update |
| `MS_USER` | P03 | 7 | 0 / 0 | /admin/users |
| `MS_WINDOW_SET` | P03 | 1 | 5 / 6 | /settings, /masters/styles |
| `MS_YEAR` | P03 | 4 | 0 / 0 | /masters/years, /masters/year-create, /utilities/year-end |
| `Mfg_Module` | P00 / P01 / P02 | 0 | 0 / 0 | /txn/mfg-issue, /txn/mfg-receive |
| `Module_Save` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `Module_Schm` | P00 / P01 / P02 | 0 | 0 / 0 | /txn/scheme |
| `Module_WhatsApp` | P00 / P01 / P02 | 0 | 0 / 0 | /integrations |
| `OlockerService` | P05 / P11 | 0 | 0 / 0 | No candidate surface |
| `PolicyModels` | P05 / P11 | 0 | 0 / 0 | /utilities/e-invoice |
| `RP_ADDRESS` | P10 | 11 | 0 / 0 | /reports/report-layouts |
| `RP_ALL` | P10 | 12 | 0 / 0 | /reports/report-layouts |
| `RP_BALANCE` | P10 | 7 | 0 / 0 | /reports/balance-sheet, /reports/account-balances |
| `RP_BAL_ZOOM` | P10 | 9 | 0 / 0 | /reports/account-balances |
| `RP_BILL_PROFIT` | P10 | 8 | 0 / 0 | /reports/report-layouts |
| `RP_CASH_BANK` | P10 | 12 | 0 / 0 | /reports/cash-book |
| `RP_CONSI_APR` | P10 | 3 | 0 / 0 | /reports/report-layouts |
| `RP_CUST` | P10 | 3 | 0 / 0 | /reports/customer-crm |
| `RP_CUST_CRM` | P10 | 11 | 0 / 0 | /reports/customer-crm |
| `RP_DAY_WORK` | P10 | 5 | 0 / 0 | /reports/day-book |
| `RP_DHRN_LOAN` | P10 | 10 | 0 / 0 | /reports/dhrn-outstanding |
| `RP_DHRN_OS` | P10 | 9 | 0 / 0 | /reports/dhrn-outstanding |
| `RP_EMP` | P10 | 9 | 0 / 0 | /reports/employee-sales |
| `RP_GRAPH` | P10 | 3 | 0 / 0 | /reports/daily-sales, /reports/top-items |
| `RP_GST` | P10 | 6 | 3 / 19 | /reports/gstr1, /reports/gstr2, /reports/gstr3b |
| `RP_HUID` | P10 | 4 | 0 / 0 | /reports/tag-stock |
| `RP_INOUT` | P10 | 6 | 0 / 0 | /reports/item-stock-ledger |
| `RP_JDTR_ZOOM` | P10 | 6 | 0 / 0 | /reports/karigar-ledger |
| `RP_LC_INOUT` | P10 | 4 | 0 / 0 | /reports/stock-by-location |
| `RP_LC_SALE` | P10 | 4 | 0 / 0 | /reports/location-wise-sales |
| `RP_LEDR` | P10 | 17 | 0 / 0 | /reports/account-ledger |
| `RP_MFG` | P10 | 5 | 0 / 0 | /reports/report-layouts |
| `RP_MFG_LEDR` | P10 | 6 | 0 / 0 | /reports/karigar-ledger |
| `RP_MFG_ZOOM` | P10 | 8 | 0 / 0 | /reports/report-layouts |
| `RP_MOVEMENT` | P10 | 6 | 0 / 0 | /reports/item-stock-ledger |
| `RP_ORDER` | P10 | 7 | 0 / 0 | /reports/report-layouts |
| `RP_ORD_TRACK` | P10 | 10 | 0 / 0 | /reports/report-layouts |
| `RP_OS` | P10 | 18 | 0 / 0 | /reports/outstanding, /reports/bill-outstanding |
| `RP_OTH_DETL` | P10 | 12 | 0 / 0 | /reports/report-layouts |
| `RP_PHY_STOCK` | P10 | 5 | 0 / 0 | /txn/physical-stock |
| `RP_REMINDER` | P10 | 3 | 0 / 0 | /utilities/reminders |
| `RP_ROJMEL` | P10 | 4 | 10 / 15 | /reports/day-book |
| `RP_SLPR_ZOOM` | P10 | 9 | 0 / 0 | /reports/sales-register, /reports/purchase-register |
| `RP_STK_LEVEL` | P10 | 4 | 0 / 0 | /reports/item-group-stock |
| `RP_STK_MOVE` | P10 | 4 | 0 / 0 | /reports/item-stock-ledger |
| `RP_STOCK` | P10 | 9 | 0 / 0 | /reports/stock-valuation |
| `RP_STOCK_FINE` | P10 | 3 | 0 / 0 | /reports/stock-valuation |
| `RP_STOCK_VALUE` | P10 | 4 | 0 / 0 | /reports/stock-valuation |
| `RP_TAG` | P10 | 19 | 0 / 0 | /reports/tag-stock |
| `RP_TAG_ESTMATE` | P10 | 5 | 0 / 0 | /reports/report-layouts |
| `RP_TAG_IMAGE` | P10 | 11 | 0 / 0 | /reports/report-layouts |
| `RP_TAX` | P10 | 7 | 0 / 0 | /reports/hsn-summary, /reports/gst-input-register |
| `RP_TOUR_ZOOM` | P10 | 8 | 0 / 0 | /reports/report-layouts |
| `RP_TRADING` | P10 | 5 | 0 / 0 | /reports/report-layouts |
| `RP_USER` | P10 | 6 | 0 / 0 | /reports/report-layouts |
| `TR_AC_OPBL` | P06 | 9 | 20 / 19 | /txn/ac-opbl, /masters/opening-balance |
| `TR_APR_ISU` | P05 | 9 | 64 / 99 | /txn/tour, /txn/tour-return, /txn/sales-order |
| `TR_BILL_TO` | P06 | 7 | 40 / 40 | /txn/bill-to-bill |
| `TR_BUL_BOOKING` | P06 | 6 | 15 / 19 | /txn/bullion |
| `TR_BUL_SALE` | P06 | 27 | 93 / 137 | /txn/bullion, /txn/rate-cut |
| `TR_CARD_REC` | P06 | 15 | 0 / 0 | /txn/receipt, /txn/payment, /txn/batch-receipt |
| `TR_CASH` | P06 | 7 | 11 / 14 | /txn/receipt, /txn/payment, /txn/batch-receipt |
| `TR_CONTRA` | P06 | 5 | 8 / 9 | /txn/contra, /txn/journal |
| `TR_DHRN_INTREC` | P09 | 28 | 0 / 0 | /txn/dhrn-interest |
| `TR_DHRN_ISU` | P09 | 25 | 16 / 27 | /txn/dhrn-issue |
| `TR_DHRN_REC` | P09 | 28 | 17 / 28 | /txn/dhrn-receipt |
| `TR_EMP_JV` | P06 | 5 | 19 / 25 | /txn/employee-jv |
| `TR_FINE_SL_PR` | P06 | 7 | 31 / 50 | /txn/fine-sale |
| `TR_FN_INOUT` | P06 | 10 | 61 / 114 | /txn/fine-inout |
| `TR_GOLD_BOOK` | P06 | 5 | 14 / 19 | /txn/gold-book |
| `TR_INOUT` | P06 | 9 | 65 / 127 | /txn/fine-inout |
| `TR_ITM_LOT` | P07 | 5 | 29 / 36 | /txn/item-lot |
| `TR_ITM_OPBL` | P07 | 2 | 19 / 18 | /txn/item-opening |
| `TR_JDT_REC` | P08 | 10 | 58 / 98 | /txn/jobwork-issue, /txn/jobwork-receive |
| `TR_KR_ISU` | P08 | 16 | 36 / 55 | /txn/karigar-issue |
| `TR_LEDR_ADJ` | P06 | 7 | 9 / 10 | /txn/ledger-adjust, /txn/fine-jv |
| `TR_LOCT_AMT` | P06 | 7 | 8 / 10 | /txn/location-amount |
| `TR_MEMB_ADJ` | P09 | 4 | 18 / 23 | /txn/membership, /txn/scheme, /reports/scheme-adjustments |
| `TR_MEMB_ENT` | P09 | 10 | 18 / 23 | /txn/membership, /txn/scheme |
| `TR_MFG_GHAT_REC` | P08 | 10 | 28 / 71 | /txn/mfg-receive |
| `TR_MFG_ISU_REC` | P08 | 11 | 43 / 82 | /txn/mfg-issue, /txn/mfg-receive |
| `TR_MFG_ITEM` | P08 | 10 | 42 / 104 | /txn/mfg-issue, /txn/mfg-receive |
| `TR_MFG_KR_ISU_REC` | P08 | 12 | 89 / 141 | /txn/karigar-issue, /txn/karigar-receive, /txn/mfg-issue, /txn/mfg-receive |
| `TR_MFG_ORD_ISU` | P08 | 8 | 74 / 113 | /txn/mfg-order-issue |
| `TR_MFG_ORD_REC` | P08 | 11 | 75 / 114 | /txn/mfg-receive |
| `TR_MFG_WITH_LOT` | P08 | 10 | 50 / 88 | /txn/mfg-receive |
| `TR_MLT_PRO` | P08 | 9 | 28 / 38 | /txn/melting |
| `TR_OTH_COMM` | P04 | 10 | 21 / 25 | /txn/other-commission |
| `TR_OTH_PURC` | P04 | 11 | 21 / 25 | /txn/other-purchase |
| `TR_PHYSTK` | P07 | 5 | 27 / 32 | /txn/physical-stock |
| `TR_PR_SL_HEDG` | P06 | 9 | 9 / 15 | /txn/rate-cut |
| `TR_PR_SL_UAE` | P00 / P13 | 26 | 69 / 108 | No candidate surface |
| `TR_PURC` | P04 | 30 | 153 / 222 | /txn/purchase, /txn/purchase-return |
| `TR_PURC_HM` | P04 | 21 | 89 / 123 | /txn/purchase-hm |
| `TR_REP_REC` | P05 | 15 | 28 / 58 | /txn/repair-receipt, /txn/repair-karigar-issue, /txn/repair-karigar-receipt, /txn/repair-customer-issue |
| `TR_SALE` | P05 | 31 | 109 / 179 | /txn/sales |
| `TR_SALE_HM` | P05 | 25 | 95 / 150 | /txn/hallmark-sale |
| `TR_SALE_LBR` | P05 | 21 | 100 / 144 | /txn/labour-sale |
| `TR_SALE_ORD` | P05 | 21 | 91 / 136 | /txn/sales-order, /txn/order-cancel |
| `TR_SALE_RTN` | P05 | 12 | 125 / 173 | /txn/sale-return |
| `TR_SALE_RTN_UAE` | P00 / P13 | 20 | 74 / 117 | No candidate surface |
| `TR_SL_EBILL` | P05 | 12 | 54 / 108 | /utilities/e-invoice |
| `TR_SL_ORD_ADJ` | P05 | 5 | 24 / 33 | /txn/sales-order, /txn/order-cancel |
| `TR_SL_PR_ITEM` | P05 | 10 | 58 / 120 | /txn/rate-cut |
| `TR_TAG_CAN` | P07 | 7 | 63 / 83 | /txn/tag-cancel |
| `TR_TAG_OPBL` | P07 | 18 | 104 / 153 | /txn/tag-opening |
| `TR_TAG_SPLIT` | P07 | 27 | 184 / 234 | /txn/tag-split |
| `TR_TAG_WT_DIFF` | P07 | 21 | 103 / 130 | /txn/tag-weight-diff |
| `TR_TOUR` | P05 | 7 | 55 / 94 | /txn/tour |
| `TR_TOUR_ORD` | P05 | 19 | 81 / 113 | /txn/tour, /txn/tour-return, /txn/sales-order |
| `TR_TOUR_SALE` | P05 | 34 | 122 / 166 | /txn/tour, /txn/tour-return, /txn/sales-order |
| `TR_UPI_REC` | P06 | 1 | 6 / 6 | /txn/receipt, /txn/payment, /txn/batch-receipt |
| `TR_VP` | P05 | 15 | 65 / 93 | /txn/vp-parcel |
| `TR_VP_ADJ` | P05 | 5 | 8 / 14 | /txn/vp-adjustment |
| `TR_WH_SALE` | P05 | 41 | 129 / 180 | /txn/wholesale-sale |
| `TR_WH_SALE_RTN` | P05 | 18 | 96 / 141 | /txn/wholesale-sale-return |
| `TagOthDetail` | P00 / P01 / P02 | 0 | 0 / 0 | /txn/stock, /reports/tag-stock |
| `Translator` | P00 / P01 / P02 | 0 | 0 / 0 | No candidate surface |
| `UT_AI_TRFR` | P11 / P12 | 4 | 0 / 0 | /txn/tag-transfer, /txn/counter-transfer |
| `UT_BANK` | P11 / P12 | 4 | 12 / 18 | /txn/bank-recon |
| `UT_BKP` | P11 / P12 | 0 | 0 / 0 | /backup |
| `UT_CUST_ENTRY` | P11 / P12 | 5 | 15 / 17 | /masters/party |
| `UT_EXPORT` | P11 / P12 | 0 | 0 / 0 | /backup, /masters/accounts |
| `UT_E_INVOICE` | P11 / P12 | 2 | 0 / 0 | /utilities/e-invoice |
| `UT_HDD` | P11 / P12 | 1 | 0 / 0 | /utilities/hdd-registry |
| `UT_IMPORT` | P11 / P12 | 1 | 0 / 0 | /backup, /masters/accounts |
| `UT_PWD_UPDATE` | P11 / P12 | 1 | 0 / 0 | /login |
| `UT_REMINDER` | P11 / P12 | 4 | 5 / 5 | /utilities/reminders, /utilities/reminder-entry, /txn/reminders |
| `UT_REPORT` | P11 / P12 | 0 | 0 / 0 | /reports/report-layouts |
| `UT_SETTING` | P11 / P12 | 2 | 6 / 6 | /settings, /admin/users |
| `UT_SETTING_MAIN` | P11 / P12 | 1 | 0 / 0 | /settings, /admin/users |
| `UT_SET_ADMIN` | P11 / P12 | 0 | 0 / 0 | /settings, /admin/users |
| `UT_SMS` | P11 / P12 | 8 | 0 / 0 | /integrations |
| `UT_TAG_PRINT` | P07 / P10 / P11 | 6 | 49 / 72 | /txn/tag-print |
| `UT_USER_REQUEST` | P11 / P12 | 0 | 0 / 0 | /utilities/user-request |
| `UT_VCH_RE_NUMBR` | P11 / P12 | 1 | 0 / 0 | /utilities/voucher-renumber |
| `UT_WAPP_WITH_API` | P11 / P12 | 9 | 0 / 0 | /integrations |
| `UT_WEB_CAM` | P11 / P12 | 0 | 0 / 0 | No candidate surface |
| `UT_WHATSAPP` | P11 / P12 | 10 | 0 / 0 | /integrations |
| `UT_WINDOW` | P11 / P12 | 0 | 0 / 0 | /utilities/window-tiles |

## Ac_Final

Track **P10**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Ac_Final.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>); [web/apps/web/app/(app)/utilities/year-end/page.tsx](<../web/apps/web/app/(app)/utilities/year-end/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/accounting/accounting.ts](<../web/apps/api/src/modules/accounting/accounting.ts>); [web/apps/api/src/modules/ops/yearEnd.ts](<../web/apps/api/src/modules/ops/yearEnd.ts>)

Retained write-table candidates: `AC_DATA`, `LEDR_AC_DATA`.

Source extraction: 0 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Ac_Image

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Ac_Image.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/party/page.tsx](<../web/apps/web/app/(app)/masters/party/page.tsx>); [web/apps/web/app/(app)/txn/tag-print/page.tsx](<../web/apps/web/app/(app)/txn/tag-print/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/party.ts](<../web/apps/api/src/modules/masters/party.ts>); [web/apps/api/src/modules/stock/tagPrint.ts](<../web/apps/api/src/modules/stock/tagPrint.ts>)

Retained write-table candidates: `COL_MAST`, `CO_SET`, `CO_SET_NEW`, `GROUP_MAST`, `INOUT_DETL`, `ITEM_MAST`, `ITM_WT_MAST`, `LOCT_MAST`, `MENU_DATA`, `PRODUCT_MAST`.

Source extraction: 0 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Ac_Ledr

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Ac_Ledr.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: [web/apps/api/src/modules/accounting/accounting.ts](<../web/apps/api/src/modules/accounting/accounting.ts>); [web/apps/api/src/modules/posting/posting.ts](<../web/apps/api/src/modules/posting/posting.ts>)

Retained write-table candidates: `AC_DATA`, `PR_DATA`, `PR_DETL`, `SL_DATA`.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Ac_Rojmel

Track **P10**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Ac_Rojmel.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `ROJ_MEL_DATA`.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Ac_Stock

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Ac_Stock.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/tag-stock/page.tsx](<../web/apps/web/app/(app)/reports/tag-stock/page.tsx>); [web/apps/web/app/(app)/txn/stock/page.tsx](<../web/apps/web/app/(app)/txn/stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>)

Retained write-table candidates: `BAR_DETL`, `DM_DATA`, `DM_KR_DATA`, `INOUT_DETL`, `LOT_DETL`, `MAIN_STOCK`, `TAG_SUM_DATA`.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Ac_Tax

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Ac_Tax.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/gst/gst.ts](<../web/apps/api/src/modules/gst/gst.ts>)

Retained write-table candidates: `AD_OS`, `BAR_DATA`, `DHRN_DATA`, `MFG_ISU_REC`, `REMARK_DATA`, `SL_ORD_ADJ`, `TAX_DATA`.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## AuthClass

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/AuthClass.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: [web/apps/api/src/modules/auth/auth.service.ts](<../web/apps/api/src/modules/auth/auth.service.ts>); [web/apps/api/src/modules/auth/jwt.ts](<../web/apps/api/src/modules/auth/jwt.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## AuthError

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/AuthError.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: [web/apps/api/src/modules/auth/auth.service.ts](<../web/apps/api/src/modules/auth/auth.service.ts>); [web/apps/api/src/modules/auth/jwt.ts](<../web/apps/api/src/modules/auth/jwt.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## BtmSchm

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/BtmSchm.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/scheme/page.tsx](<../web/apps/web/app/(app)/txn/scheme/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/membership/scheme.ts](<../web/apps/api/src/modules/membership/scheme.ts>)

Retained write-table candidates: `AC_DATA`, `AC_MAST`, `AD_ADJ`, `AD_DATA`, `AD_MAST`, `AD_MEMB`, `APR_DETL`, `APR_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `BUL_DATA`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `GROUP_MAST`, `ITEM_MAST`, `ITM_OPBL`, `LOT_DETL`, `MFG_DETL`, `MFG_IDTL`, `OP_DATA`, `OP_LDR`, `PRODUCT_MAST`, `RATE_CUT_DATA`, `REP_DETL`, `SL_DATA`, `SL_DETL`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `TABLE_MAST`.

Source extraction: 0 inputs; 0 named columns; 5 distinct validation-message candidates; 3 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClassTagList

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClassTagList.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/tag-stock/page.tsx](<../web/apps/web/app/(app)/reports/tag-stock/page.tsx>); [web/apps/web/app/(app)/txn/stock/page.tsx](<../web/apps/web/app/(app)/txn/stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsAddlDocDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsAddlDocDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsAttribDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsAttribDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsBchDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsBchDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsBuyerDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsBuyerDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsContrDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsContrDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsDispDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsDispDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsDocDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsDocDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsDocPerdDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsDocPerdDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsExpDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsExpDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsItemList

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsItemList.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsPayDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsPayDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsPrecDocDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsPrecDocDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsRefDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsRefDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsSellerDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsSellerDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsShipDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsShipDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsTranDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsTranDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ClsValDtls

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ClsValDtls.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## DC_Main

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/DC_Main.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/dashboard/page.tsx](<../web/apps/web/app/(app)/dashboard/page.tsx>)

Candidate API modules: [web/apps/web/components/Shell.tsx](<../web/apps/web/components/Shell.tsx>); [web/apps/web/lib/nav.ts](<../web/apps/web/lib/nav.ts>)

Retained write-table candidates: `BAL_GR`, `GROUP_MAST`, `ITEM_MAST`.

Source extraction: 0 inputs; 0 named columns; 5 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Data

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Data.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## DcClass

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/DcClass.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## DcPrintClass

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/DcPrintClass.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## ErrorResp

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/ErrorResp.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## IRNClass

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/IRNClass.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## IRNData

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/IRNData.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MDI_FORM

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/MDI_FORM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/dashboard/page.tsx](<../web/apps/web/app/(app)/dashboard/page.tsx>)

Candidate API modules: [web/apps/web/components/Shell.tsx](<../web/apps/web/components/Shell.tsx>); [web/apps/web/lib/nav.ts](<../web/apps/web/lib/nav.ts>)

Retained write-table candidates: `CONV_MAST`, `CO_SET`.

Source extraction: 4 inputs; 0 named columns; 6 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_chkLiveRate` (CheckBox, line 194), `_cboTheme` (ComboBox, line 204), `_chkWappId` (CheckBox, line 484), `_chkNextAi` (CheckBox, line 574).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_ACCT

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_ACCT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>); [web/apps/web/app/(app)/masters/party/page.tsx](<../web/apps/web/app/(app)/masters/party/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>); [web/apps/api/src/modules/masters/party.ts](<../web/apps/api/src/modules/masters/party.ts>)

Retained write-table candidates: `AC_DATA`, `AC_MAST`, `AC_MAST_SRNO`, `OP_DATA`.

Source extraction: 55 inputs; 0 named columns; 24 distinct validation-message candidates; 4 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_Text1` (TextBox, line 39), `_tdistrict` (TextBox, line 44), `_TState` (TextBox, line 49), `_tCountry` (TextBox, line 54), `_tBankName` (TextBox, line 59), `_tBankArea` (TextBox, line 64), `_tBankAcNo` (TextBox, line 69), `_tRtgsNo` (TextBox, line 74), `_nCrDay` (TextBox, line 79), `_nDpcPrc` (TextBox, line 84), `_tAcShort` (TextBox, line 119), `_cboArea` (ComboBox, line 124), `_cboState` (ComboBox, line 129), `_cboDistrict` (ComboBox, line 134), `_tConParcon` (TextBox, line 139), `_tAcGrCode` (TextBox, line 144), `_tPhone` (TextBox, line 149), `_tAddress3` (TextBox, line 154), `_tAddress2` (TextBox, line 159), `_tAddress1` (TextBox, line 164), `_tPinCode` (TextBox, line 169), `_cboSilver` (ComboBox, line 194), `_nOpSilverFine` (TextBox, line 199), `_cboGold` (ComboBox, line 204), `_nOpGoldFine` (TextBox, line 209), `_cboAmt` (ComboBox, line 214), `_nOpAmt` (TextBox, line 219), `_tAcName` (TextBox, line 229), `_tAcCode` (TextBox, line 234), `_tPanNo` (TextBox, line 239), `_tGstNo` (TextBox, line 244), `_tMobile` (TextBox, line 249), `_tMobile2` (TextBox, line 254), `_tPhone2` (TextBox, line 259), `_cboGstType` (ComboBox, line 264), `_chkHoAcct` (CheckBox, line 279), `_mLastVisit` (MaskedTextBox, line 284), `_tKhataNo` (TextBox, line 289), `_mLdrDate` (MaskedTextBox, line 294), `_tAdharNo` (TextBox, line 309), `_nFineIntPrc` (TextBox, line 329), `_tRefAc` (TextBox, line 334), `_cboCountry` (ComboBox, line 339), `_tPartyGroup` (TextBox, line 364), `_cboAcType` (ComboBox, line 374), `_mBhlDate` (MaskedTextBox, line 379), `_mAnDate` (MaskedTextBox, line 384), `_mBhDate` (MaskedTextBox, line 389), `_tEmail` (TextBox, line 394), `_tMainAcCode` (TextBox, line 399), `_tPassportNo` (TextBox, line 404), `_mCustIdDt` (MaskedTextBox, line 409), `_mtrnIdDt` (MaskedTextBox, line 414), `_tLcsNo` (TextBox, line 419), `_cboCity` (ComboBox, line 424).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_AC_GROUP

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_AC_GROUP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `AC_GROUP`, `BOOK_IDTL`.

Source extraction: 9 inputs; 0 named columns; 13 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tGrCode` (TextBox, line 32), `_tGrName` (TextBox, line 37), `_Text1` (TextBox, line 42), `_cboMainGr` (ComboBox, line 77), `_tPwd` (TextBox, line 82), `_tMasterData` (TextBox, line 87), `_tDataBaseName` (TextBox, line 92), `_tServerIp` (TextBox, line 97), `_cboUserShow` (ComboBox, line 107).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_ADD_MAST

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_ADD_MAST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `AC_DATA`, `ADD_MAST`, `OP_DATA`.

Source extraction: 32 inputs; 0 named columns; 10 distinct validation-message candidates; 2 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_Text1` (TextBox, line 34), `_tdistrict` (TextBox, line 39), `_TState` (TextBox, line 44), `_tCountry` (TextBox, line 49), `_tRefAc` (TextBox, line 54), `_tBankName` (TextBox, line 59), `_tBankArea` (TextBox, line 64), `_tBankAcNo` (TextBox, line 69), `_tRtgsNo` (TextBox, line 74), `_nCrDay` (TextBox, line 79), `_nDpcPrc` (TextBox, line 84), `_cboArea` (ComboBox, line 119), `_cboCountry` (ComboBox, line 124), `_cboState` (ComboBox, line 129), `_cboDistrict` (ComboBox, line 134), `_cboCity` (ComboBox, line 139), `_tConParcon` (TextBox, line 144), `_tEmail` (TextBox, line 149), `_tPhone` (TextBox, line 154), `_tAddress3` (TextBox, line 159), `_tAddress2` (TextBox, line 164), `_tAddress1` (TextBox, line 169), `_tPinCode` (TextBox, line 174), `_tAcName` (TextBox, line 184), `_tAcCode` (TextBox, line 189), `_tMobile` (TextBox, line 194), `_tMobile2` (TextBox, line 199), `_tPhone2` (TextBox, line 204), `_cboGroup` (ComboBox, line 214), `_mBhlDate` (MaskedTextBox, line 219), `_mAnDate` (MaskedTextBox, line 224), `_mBhDate` (MaskedTextBox, line 229).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_AUTO_ITEM

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_AUTO_ITEM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/auto-item/page.tsx](<../web/apps/web/app/(app)/masters/auto-item/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/autoItem.ts](<../web/apps/api/src/modules/masters/autoItem.ts>)

Retained write-table candidates: `BAR_DETL`, `BAR_IDTL`, `CO_SET_NEW`, `ITEM_MAST`, `TOUCH_MAST`.

Source extraction: 8 inputs; 24 named columns; 11 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 30), `_tGrCode` (TextBox, line 40), `_mToDt` (MaskedTextBox, line 70), `_mFromDt` (MaskedTextBox, line 75), `_tPrCode` (TextBox, line 80), `_tMembAcCode` (TextBox, line 85), `_cboUPdateType` (ComboBox, line 90), `_nMrpMargin` (TextBox, line 95).

**MSG** — 24 named / 24 declared columns: `Sr.`, `Pr Code`, `Pr Name`, `MinStk`, `Y/N`, `AppItm`, `RType`, `AvgTch`, `Memb%`, `Touch`, `West%`, `Ghat%`, `Lbr%`, `LbrType`, `LbrRate`, `ItRate`, `EmpCom%`, `NWest%`, `Ght%`, `NGht%`, `OKrTch`, `KrTch`, `OKrWst%`, `KrWst%`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_BOOK

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_BOOK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `BOOK_DATA`, `BOOK_DETL`.

Source extraction: 15 inputs; 4 named columns; 14 distinct validation-message candidates; 1 confirmation candidates; 2 grid-cell handlers.

Declared input controls: `_tBkCode` (TextBox, line 34), `_tBkName` (TextBox, line 39), `_Text1` (TextBox, line 44), `_tVchSer` (TextBox, line 49), `_cboCurUse` (ComboBox, line 54), `_tBkShort` (TextBox, line 59), `_cboItmTyp` (ComboBox, line 64), `_cboTranInOut` (ComboBox, line 69), `_cboInvoTyp` (ComboBox, line 74), `_cboTrnsNm` (ComboBox, line 79), `_TEXT_ENTRY` (TextBox, line 84), `_tResetBook` (TextBox, line 129), `_tDataType` (TextBox, line 134), `_tTrfrBook` (TextBox, line 139), `_tEmpCode` (TextBox, line 149).

**MSG** — 4 named / 4 declared columns: `Sr`, `Account Desc`, `AcCode`, `AcName`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_BOOKLIST

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_BOOKLIST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 1 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tSearchText` (TextBox, line 36).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_COMPANY

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_COMPANY.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/provision/page.tsx](<../web/apps/web/app/(app)/admin/provision/page.tsx>); [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>); [web/apps/api/src/modules/ops/seedCompany.ts](<../web/apps/api/src/modules/ops/seedCompany.ts>)

Retained write-table candidates: `AC_DATA`, `AC_GROUP`, `AC_MAST`, `AC_MAST_SRNO`, `ADD_MAST`, `AD_ADJ`, `AD_DATA`, `AD_MAST`, `AD_MEMB`, `AD_OS`, `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAL_GR`, `BANK_RECONCILE`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `BOOK_DATA`, `BOOK_DETL`, `BOOK_IDTL`, `BUL_DATA`, `CARD_DATA`, `CASH_DATA`, `COL_MAST`, `CONTRA_DATA`, `CONV_MAST`, `CO_MAST`, `CO_SET`, `CO_SET_NEW`, `CRNT_DATA`, `CUT_DATA`, `CUT_DETL`, `CUT_STK_DETL`, `DELETE_DATA`, `DESIGN_DETL`, `DESIGN_IDTL`, `DESIGN_MAST`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `DM_DATA`, `DM_KR_DATA`, `DM_MAST`, `DM_SIZE`, `EMP_DATA`, `EMP_MAST`, `E_DATA`, `E_MAST`, `FAN_AC_MAST`, `FINE_DATA`, `GROUP_MAST`, `HDD_MAST`, `INOUT_DATA`, `INOUT_DETL`, `INOUT_IDTL`, `ITEM_MAST`, `ITM_CITY`, `ITM_LOT_DETL`, `ITM_OPBL`, `ITM_WT_MAST`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_MAST`, `LBR_REC_DETL`, `LDR_ADJ_DATA`, `LEDR_AC_DATA`, `LOCT_AMT`, `LOCT_MAST`, `LOGIN_MAST`, `LOT_DETL`, `MAIN_STOCK`, `MENU_DATA`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `MFG_MAST`, `MLT_DATA`, `MLT_DETL`, `MODEL_MAST`, `MSG_MAST`, `OP_DATA`, `OP_LDR`, `PAY_DATA`, `PAY_DETL`, `POINT_DATA`, `POINT_MAST`, `POINT_MEMB`, `PRINT_MAST`, `PRODUCT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `RATE_MAST`, `REM_DATA`, `REPORT_DATA`, `REP_DATA`, `REP_DETL`, `ROJMEL_BAL`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `SRNO_MAST`, `TABLE_MAST`, `TAG_DATA`, `TAG_IMAGE_DATA`, `TAG_PRINT_DATA`, `TAG_SET`, `TAG_STOCK_PRINT`, `TAG_SUM_DATA`, `TAX_DATA`, `TAX_MAST`, `TEMP_ADD`, `TEMP_AD_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `UPI_DATA`, `USER_DATA`, `USER_REQUEST`, `USER_SET`, `VP_ADJ_DATA`, `WEB_DATA`, `YEAR_MAST`.

Source extraction: 39 inputs; 0 named columns; 17 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboRptHader` (ComboBox, line 75), `_tMobile2` (TextBox, line 80), `_tPhone2` (TextBox, line 85), `_TState` (TextBox, line 90), `_tCountry` (TextBox, line 95), `_tEmail` (TextBox, line 100), `_tMobile` (TextBox, line 105), `_tPhone` (TextBox, line 110), `_tCity` (TextBox, line 115), `_tAddress3` (TextBox, line 120), `_tAddress2` (TextBox, line 125), `_tAddress1` (TextBox, line 130), `_tPinCode` (TextBox, line 135), `_tCoName` (TextBox, line 140), `_tCoCode` (TextBox, line 145), `_tRtgsNo` (TextBox, line 150), `_tBankAcNo` (TextBox, line 155), `_tBankArea` (TextBox, line 160), `_tBankName` (TextBox, line 165), `_tPanNo` (TextBox, line 170), `_tDhiranNo` (TextBox, line 175), `_tCstNo` (TextBox, line 180), `_tGstNo` (TextBox, line 185), `_Text1` (TextBox, line 190), `_cboMetalType` (ComboBox, line 200), `_cboWorkType` (ComboBox, line 205), `_tJudrection` (TextBox, line 210), `_tStateCode` (TextBox, line 215), `_mLockDate` (MaskedTextBox, line 220), `_tCoType` (TextBox, line 225), `_cboWithOldCoMast` (ComboBox, line 230), `_tC` (TextBox, line 240), `_tB` (TextBox, line 245), `_tA` (TextBox, line 250), `_tAspPwd` (TextBox, line 275), `_tePortalPwd` (TextBox, line 280), `_tHttpPath` (TextBox, line 295), `_tMailApi` (TextBox, line 300), `_tAcCode` (TextBox, line 315).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_DESIGN_BOOK

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `DESIGN_DETL`, `DESIGN_IDTL`, `TAG_IMAGE_DATA`.

Source extraction: 5 inputs; 59 named columns; 20 distinct validation-message candidates; 5 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 75), `_TEXT_IDTL` (TextBox, line 90), `_tEmpCode` (TextBox, line 125), `_tPrCode` (TextBox, line 135).

**MSG** — 29 named / 47 declared columns: `Sr`, `Page No`, `Design`, `Style`, `GrCode`, `Size`, `DieNo`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `ItRate`, `ItAmt`, `TagCost`, `PrCost`, `Margin`, `Mrp`, `Image`, `KrCod`.

**MSG_IDTL** — 29 named / 29 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `DmRemark`, `DmSfNo`, `Pcs`, `PcsWt`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldKrWt`, `OldGrWt`, `1RowVal`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_DM

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_DM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `DM_MAST`.

Source extraction: 8 inputs; 0 named columns; 9 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tDmCode` (TextBox, line 31), `_tDmName` (TextBox, line 36), `_Text1` (TextBox, line 41), `_nSlRate` (TextBox, line 51), `_cboCut` (ComboBox, line 81), `_cboClear` (ComboBox, line 86), `_tGrCode` (TextBox, line 91), `_nPrRate` (TextBox, line 96).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_EMP

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_EMP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `EMP_MAST`.

Source extraction: 7 inputs; 0 named columns; 9 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tEmpCode` (TextBox, line 31), `_tEmpName` (TextBox, line 36), `_Text1` (TextBox, line 41), `_tEmpAmt` (TextBox, line 51), `_tEmpAc` (TextBox, line 56), `_cboUser` (ComboBox, line 86), `_nDayHour` (TextBox, line 91).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_GOLD_MAST

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_GOLD_MAST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `DG_GOLD_MAST`.

Source extraction: 11 inputs; 0 named columns; 8 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tContryCode` (TextBox, line 29), `_nGoldRate` (TextBox, line 34), `_nOzConv` (TextBox, line 39), `_nGoldConv` (TextBox, line 44), `_nSilverRate` (TextBox, line 49), `_tBankCode` (TextBox, line 54), `_nSilverConv` (TextBox, line 84), `_chkGoldBookActiv` (CheckBox, line 89), `_chkBookWithLiveRate` (CheckBox, line 94), `_nCustSlRateLess` (TextBox, line 99), `_nCustBuyRateAdd` (TextBox, line 104).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_GROUP

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_GROUP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `GROUP_MAST`, `ITEM_MAST`.

Source extraction: 16 inputs; 0 named columns; 10 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tGrCode` (TextBox, line 31), `_tGrName` (TextBox, line 36), `_Text1` (TextBox, line 41), `_tGTradTyp` (TextBox, line 51), `_nGrTouch` (TextBox, line 56), `_nGrPrTouch` (TextBox, line 61), `_nWest` (TextBox, line 66), `_nMelting` (TextBox, line 71), `_tSaleAcName` (TextBox, line 76), `_tPurcAcName` (TextBox, line 81), `_tSalesAc` (TextBox, line 86), `_tPurcAc` (TextBox, line 91), `_cboItemTyp` (ComboBox, line 96), `_tHsnCode` (TextBox, line 126), `_nTaxPrc` (TextBox, line 131), `_nTochAdd` (TextBox, line 136).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_HELP

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_HELP.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 1 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tSearchText` (TextBox, line 34).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_ITEM

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_ITEM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `BAR_DETL`, `GROUP_MAST`, `ITEM_MAST`, `PRODUCT_MAST`.

Source extraction: 24 inputs; 0 named columns; 17 distinct validation-message candidates; 3 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tPrCode` (TextBox, line 32), `_tGrCode` (TextBox, line 37), `_Text1` (TextBox, line 42), `_tItName` (TextBox, line 52), `_tItCode` (TextBox, line 57), `_tTagType` (TextBox, line 62), `_nLbrPrc` (TextBox, line 67), `_nItemRate` (TextBox, line 72), `_nDiscPrc` (TextBox, line 77), `_nConPrc` (TextBox, line 82), `_cboRateType` (ComboBox, line 87), `_cboUnit` (ComboBox, line 92), `_tHsnCode` (TextBox, line 127), `_nOthRate` (TextBox, line 132), `_cboSafe` (ComboBox, line 137), `_nBagWt` (TextBox, line 142), `_nLbrRate` (TextBox, line 147), `_tItUniCode` (TextBox, line 152), `_tAcItem` (TextBox, line 157), `_cboOthRateType` (ComboBox, line 162), `_nGhtPrc` (TextBox, line 172), `_nTagLbrPrc` (TextBox, line 182), `_nTagKrWestPrc` (TextBox, line 187), `_nTagKrTch` (TextBox, line 192).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_LBR_TYPE

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_LBR_TYPE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>); [web/apps/web/app/(app)/masters/labour-update/page.tsx](<../web/apps/web/app/(app)/masters/labour-update/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/labourUpdate.ts](<../web/apps/api/src/modules/masters/labourUpdate.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `BAR_DETL`, `LBR_MAST`.

Source extraction: 6 inputs; 0 named columns; 12 distinct validation-message candidates; 2 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tlbrCode` (TextBox, line 31), `_Text1` (TextBox, line 36), `_nlbrValue` (TextBox, line 46), `_cboLbrType` (ComboBox, line 81), `_tGrCode` (TextBox, line 86), `_tPrCode` (TextBox, line 91).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_LOCT

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_LOCT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `AC_DATA`, `AD_ADJ`, `AD_DATA`, `AD_OS`, `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BOOK_DATA`, `BOOK_DETL`, `CASH_DATA`, `CONTRA_DATA`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `FINE_DATA`, `ITM_OPBL`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `LEDR_AC_DATA`, `LOCT_MAST`, `MAIN_STOCK`, `MENU_DATA`, `OP_DATA`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `RATE_MAST`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `SRNO_MAST`, `TABLE_MAST`, `TAG_PRINT_DATA`, `TAG_STOCK_PRINT`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 26 inputs; 0 named columns; 10 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboRptHader` (ComboBox, line 61), `_tJudrection` (TextBox, line 66), `_tMobile2` (TextBox, line 71), `_tPhone2` (TextBox, line 76), `_TState` (TextBox, line 81), `_tCountry` (TextBox, line 86), `_tEmail` (TextBox, line 91), `_tMobile` (TextBox, line 96), `_tPhone` (TextBox, line 101), `_tCity` (TextBox, line 106), `_tAddress3` (TextBox, line 111), `_tAddress2` (TextBox, line 116), `_tAddress1` (TextBox, line 121), `_tPinCode` (TextBox, line 126), `_tCoName` (TextBox, line 131), `_tCoCode` (TextBox, line 136), `_tRtgsNo` (TextBox, line 141), `_tBankAcNo` (TextBox, line 146), `_tBankArea` (TextBox, line 151), `_tBankName` (TextBox, line 156), `_tPanNo` (TextBox, line 161), `_tDhiranNo` (TextBox, line 166), `_tCstNo` (TextBox, line 171), `_tGstNo` (TextBox, line 176), `_Text1` (TextBox, line 181), `_tAcCode` (TextBox, line 186).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_LOGIN

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_LOGIN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/users/page.tsx](<../web/apps/web/app/(app)/admin/users/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/auth/auth.service.ts](<../web/apps/api/src/modules/auth/auth.service.ts>); [web/apps/api/src/modules/auth/jwt.ts](<../web/apps/api/src/modules/auth/jwt.ts>); [web/apps/api/src/modules/auth/password.ts](<../web/apps/api/src/modules/auth/password.ts>)

Retained write-table candidates: `AC_MAST_SRNO`, `CO_MAST`.

Source extraction: 2 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tUserName` (TextBox, line 25), `_tPasward` (TextBox, line 30).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_MEMB

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_MEMB.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/membership/page.tsx](<../web/apps/web/app/(app)/txn/membership/page.tsx>); [web/apps/web/app/(app)/txn/scheme/page.tsx](<../web/apps/web/app/(app)/txn/scheme/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/membership/membership.ts](<../web/apps/api/src/modules/membership/membership.ts>); [web/apps/api/src/modules/membership/scheme.ts](<../web/apps/api/src/modules/membership/scheme.ts>)

Retained write-table candidates: `AD_MEMB`.

Source extraction: 34 inputs; 0 named columns; 9 distinct validation-message candidates; 2 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_Text1` (TextBox, line 39), `_tdistrict` (TextBox, line 44), `_TState` (TextBox, line 49), `_tCountry` (TextBox, line 54), `_tRefAc` (TextBox, line 59), `_tBankName` (TextBox, line 64), `_tBankArea` (TextBox, line 69), `_tBankAcNo` (TextBox, line 74), `_tRtgsNo` (TextBox, line 79), `_cboArea` (ComboBox, line 109), `_cboDistrict` (ComboBox, line 114), `_cboCity` (ComboBox, line 119), `_tSchmCode` (TextBox, line 124), `_tEmail` (TextBox, line 129), `_tPhone` (TextBox, line 134), `_tAddress3` (TextBox, line 139), `_tAddress2` (TextBox, line 144), `_tAddress1` (TextBox, line 149), `_tPinCode` (TextBox, line 154), `_nGoldFine` (TextBox, line 179), `_nMembAmt` (TextBox, line 184), `_tAcName` (TextBox, line 194), `_tAcCode` (TextBox, line 199), `_tIdProof` (TextBox, line 204), `_tMobile` (TextBox, line 209), `_tMobile2` (TextBox, line 214), `_tPhone2` (TextBox, line 219), `_tEmpCode` (TextBox, line 234), `_mAnDate` (MaskedTextBox, line 239), `_mBhDate` (MaskedTextBox, line 244), `_mExpDate` (MaskedTextBox, line 249), `_mJoinDate` (MaskedTextBox, line 254), `_mBhlDate` (MaskedTextBox, line 259), `_tNomini` (TextBox, line 264).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_MFG_MAST

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_MFG_MAST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `BOOK_DATA`, `MENU_DATA`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `MFG_MAST`, `SL_ORD_DETL`, `TEMP_BOOK_DATA`, `USER_SET`.

Source extraction: 1 inputs; 14 named columns; 14 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 30).

**MSG** — 14 named / 14 declared columns: `Sr.`, `MnuCode`, `Mnu Name`, `Book`, `TrnCode`, `Trn Name`, `BksName`, `CurUse`, `LastTrn`, `TrnType`, `NextTrn`, `MainBook`, `StkLes`, `StkAdd`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_OPNCOMP

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_OPNCOMP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/provision/page.tsx](<../web/apps/web/app/(app)/admin/provision/page.tsx>); [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>); [web/apps/api/src/modules/ops/seedCompany.ts](<../web/apps/api/src/modules/ops/seedCompany.ts>)

Retained write-table candidates: `AC_MAST_SRNO`, `BOOK_IDTL`, `CO_SET`, `MENU_DATA`.

Source extraction: 3 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tlcCode` (TextBox, line 29), `_tYearCode` (TextBox, line 34), `_tCoCode` (TextBox, line 39).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_POINT

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_POINT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `POINT_MAST`, `POINT_MEMB`.

Source extraction: 6 inputs; 6 named columns; 5 distinct validation-message candidates; 0 confirmation candidates; 2 grid-cell handlers.

Declared input controls: `_Text1` (TextBox, line 32), `_TEXT_ENTRY` (TextBox, line 37), `_tPointName` (TextBox, line 77), `_nPointAmt` (TextBox, line 82), `_nMinPoint` (TextBox, line 87), `_cboCurInUse` (ComboBox, line 92).

**MSG** — 6 named / 6 declared columns: `Sr`, `Point Type`, `Sl Value`, `Point Count`, `Fix Point`, `1Gm Point`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_PRINT

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_PRINT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_PRODUCT

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_PRODUCT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `AD_ADJ`, `AD_DATA`, `AD_MAST`, `AD_MEMB`, `AD_OS`, `APP_USER_DATA`, `BOOK_IDTL`, `CO_MAST`, `DG_GOLD_DATA`, `ITEM_MAST`, `LIKE_DATA`, `PRODUCT_MAST`, `RATE_MAST`, `TABLE_MAST`, `TAG_STOCK`.

Source extraction: 12 inputs; 0 named columns; 26 distinct validation-message candidates; 2 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tPrCode` (TextBox, line 34), `_tPrName` (TextBox, line 39), `_Text1` (TextBox, line 44), `_tAcCode` (TextBox, line 84), `_nSchmAmt` (TextBox, line 89), `_nSchmMonth` (TextBox, line 94), `_cboSchmType` (ComboBox, line 99), `_tHeading` (TextBox, line 104), `_cboforapp` (ComboBox, line 109), `_nBonusMonth` (TextBox, line 114), `_cboImgType` (ComboBox, line 129), `_tBankAc` (TextBox, line 134).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_RATE

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_RATE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>); [web/apps/web/app/(app)/txn/daily-rate/page.tsx](<../web/apps/web/app/(app)/txn/daily-rate/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/dailyRate.ts](<../web/apps/api/src/modules/masters/dailyRate.ts>); [web/apps/api/src/modules/masters/rate.ts](<../web/apps/api/src/modules/masters/rate.ts>)

Retained write-table candidates: `GROUP_MAST`, `RATE_MAST`.

Source extraction: 8 inputs; 10 named columns; 4 distinct validation-message candidates; 1 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 34), `_nSilverRate` (TextBox, line 69), `_nGoldRate` (TextBox, line 74), `_mVchDate` (MaskedTextBox, line 79), `_nGoldOzRate` (TextBox, line 89), `_nSilverOzRate` (TextBox, line 94), `_nPrSilverRate` (TextBox, line 99), `_nPrGoldRate` (TextBox, line 104).

**MSG** — 10 named / 10 declared columns: `Sr.`, `GrCode`, `GrName`, `Touch`, `Tax%`, `Rate10gm`, `TaxRate`, `PrTouch`, `PrRate`, `GrType`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_STK_LIMIT

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_STK_LIMIT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `DM_SIZE`, `ITM_WT_MAST`.

Source extraction: 4 inputs; 11 named columns; 8 distinct validation-message candidates; 1 confirmation candidates; 2 grid-cell handlers.

Declared input controls: `_Text1` (TextBox, line 32), `_TEXT_ENTRY` (TextBox, line 37), `_tItCode` (TextBox, line 77), `_tDesignNo` (TextBox, line 82).

**MSG** — 11 named / 11 declared columns: `Sr`, `FormWt`, `ToWt`, `Pcs`, `LbrCode`, `Ght%`, `Lbr%`, `MinLbr%`, `LType`, `LbrRate`, `LbrAmt`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_STYLE

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_STYLE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `DESIGN_MAST`, `ITM_CITY`, `MODEL_MAST`.

Source extraction: 2 inputs; 0 named columns; 14 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tStyleName` (TextBox, line 30), `_Text1` (TextBox, line 35).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_TASTING

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_TASTING.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_TAX

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_TAX.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `AC_MAST`, `TAX_MAST`.

Source extraction: 8 inputs; 5 named columns; 9 distinct validation-message candidates; 1 confirmation candidates; 2 grid-cell handlers.

Declared input controls: `_tTaxCode` (TextBox, line 32), `_tTaxName` (TextBox, line 37), `_Text1` (TextBox, line 42), `_nTaxPrc` (TextBox, line 52), `_tTaxAcCode` (TextBox, line 57), `_nAddTaxPrc` (TextBox, line 62), `_TEXT_ENTRY` (TextBox, line 97), `_tInputTax` (TextBox, line 102).

**MSG** — 5 named / 5 declared columns: `Sr`, `Tax Type`, `Tax Name`, `Ac Code`, `Tax %`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_TRADE

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_TRADE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/configs.ts](<../web/apps/api/src/modules/masters/configs.ts>); [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>)

Retained write-table candidates: `BAL_GR`.

Source extraction: 1 inputs; 9 named columns; 5 distinct validation-message candidates; 0 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 30).

**MSG** — 9 named / 9 declared columns: `Sr.`, `Trading Name`, `Trade Type`, `ItType`, `Sales Ac`, `Purc Ac`, `Closing Ac`, `Opening Ac`, `Clg Ac`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_UPDATE

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_UPDATE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/labour-update/page.tsx](<../web/apps/web/app/(app)/masters/labour-update/page.tsx>); [web/apps/web/app/(app)/utilities/data-refresh/page.tsx](<../web/apps/web/app/(app)/utilities/data-refresh/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/labourUpdate.ts](<../web/apps/api/src/modules/masters/labourUpdate.ts>); [web/apps/api/src/modules/utilities/dataRefresh.ts](<../web/apps/api/src/modules/utilities/dataRefresh.ts>)

Retained write-table candidates: `AC_DATA`, `AC_GROUP`, `AC_MAST`, `AD_MAST`, `AD_OS`, `APR_DETL`, `BAL_GR`, `BANK_RECONCILE`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `BOOK_DATA`, `BOOK_DETL`, `BOOK_IDTL`, `BUL_DATA`, `CASH_DATA`, `COL_MAST`, `CONTRA_DATA`, `CONV_MAST`, `CO_MAST`, `CO_SET_NEW`, `DESIGN_DETL`, `DG_GOLD_MAST`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `DM_DATA`, `DM_KR_DATA`, `DM_MAST`, `EMP_MAST`, `GROUP_MAST`, `INOUT_DETL`, `ITEM_MAST`, `ITM_LOT_DETL`, `ITM_OPBL`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `LOT_DETL`, `MAIN_STOCK`, `MENU_DATA`, `MFG_ISU_REC`, `MFG_MAST`, `OP_DATA`, `PAY_DATA`, `PAY_DETL`, `PRINT_MAST`, `PRODUCT_MAST`, `PR_DATA`, `PR_DETL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_PR_DETL`, `SRNO_MAST`, `TAG_IMAGE_DATA`, `TAX_DATA`, `TAX_MAST`, `TILE_DATA`, `USER_MAST`, `USER_SET`, `WEIGHT_MAST`.

Source extraction: 2 inputs; 0 named columns; 26 distinct validation-message candidates; 3 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mToDt` (MaskedTextBox, line 132), `_mFromDt` (MaskedTextBox, line 137).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_USER

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_USER.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/users/page.tsx](<../web/apps/web/app/(app)/admin/users/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/rbac/formRights.ts](<../web/apps/api/src/modules/rbac/formRights.ts>); [web/apps/api/src/modules/rbac/users.ts](<../web/apps/api/src/modules/rbac/users.ts>)

Retained write-table candidates: `BOOK_DATA`, `BOOK_DETL`, `BOOK_IDTL`, `LOGIN_MAST`, `MENU_DATA`, `TILE_DATA`, `USER_SET`.

Source extraction: 7 inputs; 0 named columns; 18 distinct validation-message candidates; 2 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboUserTyp` (ComboBox, line 65), `_tConPasword` (TextBox, line 70), `_tPasword` (TextBox, line 75), `_tUserName` (TextBox, line 80), `_tOldPasword` (TextBox, line 85), `_cboUser` (ComboBox, line 90), `_tResetPwd` (TextBox, line 110).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_WINDOW_SET

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_WINDOW_SET.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>); [web/apps/web/app/(app)/settings/page.tsx](<../web/apps/web/app/(app)/settings/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/settings/settings.ts](<../web/apps/api/src/modules/settings/settings.ts>)

Retained write-table candidates: `CO_SET_NEW`, `TILE_DATA`.

Source extraction: 1 inputs; 5 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 30).

**MSG** — 5 named / 6 declared columns: `Sr.`, `Menu Name`, `Display Name`, `ItType`, `Short`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## MS_YEAR

Track **P03**. Category `master`. [Desktop source](<../unified/src/csharp/DataCareNext/MS_YEAR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>); [web/apps/web/app/(app)/masters/year-create/page.tsx](<../web/apps/web/app/(app)/masters/year-create/page.tsx>); [web/apps/web/app/(app)/utilities/year-end/page.tsx](<../web/apps/web/app/(app)/utilities/year-end/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/year.ts](<../web/apps/api/src/modules/masters/year.ts>); [web/apps/api/src/modules/ops/yearEnd.ts](<../web/apps/api/src/modules/ops/yearEnd.ts>)

Retained write-table candidates: `AC_DATA`, `AC_GROUP`, `AC_MAST`, `AD_ADJ`, `AD_DATA`, `AD_OS`, `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAL_GR`, `BANK_RECONCILE`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `BOOK_DATA`, `BOOK_DETL`, `BUL_DATA`, `CARD_DATA`, `CASH_DATA`, `COL_MAST`, `CONTRA_DATA`, `CONV_MAST`, `CO_SET`, `CO_SET_NEW`, `CRNT_DATA`, `CUT_DATA`, `CUT_DETL`, `CUT_STK_DETL`, `DELETE_DATA`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `DM_DATA`, `DM_KR_DATA`, `EMP_DATA`, `EMP_MAST`, `E_DATA`, `FINE_DATA`, `GROUP_MAST`, `INOUT_DATA`, `INOUT_DETL`, `INOUT_IDTL`, `ITEM_MAST`, `ITM_LOT_DETL`, `ITM_OPBL`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `LDR_ADJ_DATA`, `LEDR_AC_DATA`, `LOCT_AMT`, `LOCT_MAST`, `LOGIN_MAST`, `LOT_DETL`, `MAIN_STOCK`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `MLT_DATA`, `MLT_DETL`, `OP_DATA`, `OP_LDR`, `PAY_DATA`, `PAY_DETL`, `PRINT_MAST`, `PRODUCT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `RATE_MAST`, `REP_DATA`, `REP_DETL`, `ROJMEL_BAL`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `TABLE_MAST`, `TAG_PRINT_DATA`, `TAG_STOCK_PRINT`, `TAG_SUM_DATA`, `TAX_DATA`, `TAX_MAST`, `TEMP_ADD`, `TEMP_AD_DATA`, `TEMP_BOOK_DATA`, `UPI_DATA`, `USER_DATA`, `USER_REQUEST`, `USER_SET`, `VP_ADJ_DATA`, `WEB_DATA`, `YEAR_MAST`.

Source extraction: 4 inputs; 0 named columns; 7 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tYearCode` (TextBox, line 55), `_tMonth` (TextBox, line 60), `_mOpDate` (MaskedTextBox, line 65), `_mClDate` (MaskedTextBox, line 70).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Mfg_Module

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Mfg_Module.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-issue/page.tsx](<../web/apps/web/app/(app)/txn/mfg-issue/page.tsx>); [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_MAST`, `BOOK_DATA`, `BOOK_DETL`, `BOOK_IDTL`, `CO_SET`, `CO_SET_NEW`, `ITEM_MAST`, `MENU_DATA`, `MFG_MAST`, `PRODUCT_MAST`, `STATE_MAST`, `TAX_MAST`, `YEAR_MAST`.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Module_Save

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Module_Save.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: [web/apps/api/src/modules/accounting/accounting.ts](<../web/apps/api/src/modules/accounting/accounting.ts>); [web/apps/api/src/modules/posting/posting.ts](<../web/apps/api/src/modules/posting/posting.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 5 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Module_Schm

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Module_Schm.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/scheme/page.tsx](<../web/apps/web/app/(app)/txn/scheme/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/membership/scheme.ts](<../web/apps/api/src/modules/membership/scheme.ts>)

Retained write-table candidates: `AC_DATA`, `AC_GROUP`, `AC_MAST`, `AC_MAST_SRNO`, `ADD_MAST`, `AD_ADJ`, `AD_DATA`, `AD_MAST`, `AD_MEMB`, `AD_OS`, `APP_USER_DATA`, `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAL_GR`, `BANK_RECONCILE`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `BOOK_DATA`, `BOOK_DETL`, `BOOK_IDTL`, `BUL_DATA`, `CARD_DATA`, `CASH_DATA`, `COL_MAST`, `CONTRA_DATA`, `CONV_MAST`, `CO_MAST`, `CO_SET`, `CRNT_DATA`, `CUT_DATA`, `CUT_DETL`, `CUT_STK_DETL`, `DELETE_DATA`, `DESIGN_DETL`, `DESIGN_IDTL`, `DESIGN_MAST`, `DG_GOLD_DATA`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `DM_DATA`, `DM_KR_DATA`, `DM_MAST`, `DM_SIZE`, `EMP_DATA`, `EMP_MAST`, `FINE_DATA`, `GROUP_MAST`, `INOUT_DATA`, `INOUT_DETL`, `INOUT_IDTL`, `ITEM_MAST`, `ITM_CITY`, `ITM_LOT_DETL`, `ITM_OPBL`, `ITM_WT_MAST`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_MAST`, `LBR_REC_DETL`, `LDR_ADJ_DATA`, `LEDR_AC_DATA`, `LOCT_AMT`, `LOCT_MAST`, `LOGIN_MAST`, `LOT_DETL`, `MAIN_STOCK`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `MFG_MAST`, `MLT_DATA`, `MLT_DETL`, `MODEL_MAST`, `MSG_MAST`, `OP_DATA`, `OP_LDR`, `PAY_DATA`, `PAY_DETL`, `POINT_DATA`, `POINT_MAST`, `POINT_MEMB`, `PRODUCT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `RATE_MAST`, `REM_DATA`, `REPORT_DATA`, `REP_DATA`, `REP_DETL`, `ROJMEL_BAL`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `SRNO_MAST`, `TABLE_MAST`, `TAG_IMAGE_DATA`, `TAG_PRINT_DATA`, `TAG_SET`, `TAG_STOCK_PRINT`, `TAX_DATA`, `TEMP_ADD`, `TEMP_AD_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `UPI_DATA`, `USER_DATA`, `USER_REQUEST`, `USER_SET`, `VP_ADJ_DATA`, `WEB_DATA`, `YEAR_MAST`.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Module_WhatsApp

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Module_WhatsApp.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/integrations/page.tsx](<../web/apps/web/app/(app)/integrations/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/integrations/messaging.ts](<../web/apps/api/src/modules/integrations/messaging.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## OlockerService

Track **P05 / P11**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/OlockerService.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## PolicyModels

Track **P05 / P11**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/PolicyModels.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_ADDRESS

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_ADDRESS.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `TEMP_ADD`.

Source extraction: 11 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcGroup` (TextBox, line 54), `_tAcCode` (TextBox, line 59), `_cboCity` (ComboBox, line 64), `_cboArea` (ComboBox, line 69), `_tLcCode` (TextBox, line 74), `_CboAddType` (ComboBox, line 94), `_chkAcSelect` (CheckBox, line 99), `_mAnDate` (MaskedTextBox, line 114), `_mBhDate` (MaskedTextBox, line 119), `_mToBDate` (MaskedTextBox, line 124), `_tSearchText` (TextBox, line 129).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_ALL

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_ALL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `RATE_CUT_ISU_REC`, `SL_ORD_DETL`.

Source extraction: 12 inputs; 0 named columns; 8 distinct validation-message candidates; 4 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tBookCode` (TextBox, line 47), `_tAcCode` (TextBox, line 52), `_cboCity` (ComboBox, line 57), `_cboArea` (ComboBox, line 62), `_tItCode` (TextBox, line 67), `_cboItemTyp` (ComboBox, line 72), `_tLcCode` (TextBox, line 92), `_mToDt` (MaskedTextBox, line 167), `_mFromDt` (MaskedTextBox, line 172), `_tGrCode` (TextBox, line 192), `_tCustName` (TextBox, line 222), `_chkBookSelect` (CheckBox, line 372).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_BALANCE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_BALANCE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `AC_DATA`, `BAL_GR`, `LEDR_AC_DATA`.

Source extraction: 7 inputs; 0 named columns; 3 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tLcCode` (TextBox, line 73), `_mToDt` (MaskedTextBox, line 78), `_mFromDt` (MaskedTextBox, line 83), `_nSilverAmt` (TextBox, line 88), `_nGoldAmt` (TextBox, line 93), `_chkOpBal` (CheckBox, line 123), `_chkTodayBal` (CheckBox, line 128).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_BAL_ZOOM

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_BAL_ZOOM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `AC_DATA`, `LEDR_AC_DATA`, `REPORT_DATA`.

Source extraction: 9 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 66), `_chkOpBal` (CheckBox, line 81), `_mToDt` (MaskedTextBox, line 86), `_mFromDt` (MaskedTextBox, line 91), `_nGoldAmt` (TextBox, line 111), `_nSilverAmt` (TextBox, line 116), `_tLcCode` (TextBox, line 121), `_chkTodayBal` (CheckBox, line 126), `_chkLedrFine` (CheckBox, line 131).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_BILL_PROFIT

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_BILL_PROFIT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 8 inputs; 0 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 67), `_mToDt` (MaskedTextBox, line 72), `_tGrCode` (TextBox, line 82), `_tPrCode` (TextBox, line 87), `_tAcCode` (TextBox, line 107), `_tBookCode` (TextBox, line 112), `_chkBookSelect` (CheckBox, line 117), `_tCounterCode` (TextBox, line 132).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_CASH_BANK

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_CASH_BANK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `TEMP_AD_DATA`.

Source extraction: 12 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 66), `_cboArea` (ComboBox, line 81), `_cboCity` (ComboBox, line 86), `_nMembAmt` (TextBox, line 91), `_chkSchmPanding` (CheckBox, line 96), `_cboScheme` (ComboBox, line 106), `_cboEmp` (ComboBox, line 111), `_mToDt` (MaskedTextBox, line 126), `_mFromDt` (MaskedTextBox, line 131), `_tBookCode` (TextBox, line 136), `_tMembCode` (TextBox, line 141), `_chkComplete` (CheckBox, line 146).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_CONSI_APR

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_CONSI_APR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 3 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 59), `_mToDt` (DateEdit, line 64), `_mFromDt` (DateEdit, line 69).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_CUST

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_CUST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `AC_MAST`.

Source extraction: 3 inputs; 0 named columns; 1 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboProduct` (ComboBox, line 60), `_mToDt` (MaskedTextBox, line 65), `_mFromDt` (MaskedTextBox, line 70).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_CUST_CRM

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_CUST_CRM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `CUST_DETL`.

Source extraction: 11 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 56), `_tAcName` (TextBox, line 61), `_mToDt` (MaskedTextBox, line 76), `_mFromDt` (MaskedTextBox, line 81), `_cboValType` (ComboBox, line 86), `_tCustCode` (TextBox, line 91), `_tEmpCode` (TextBox, line 101), `_mUpdDate` (MaskedTextBox, line 106), `_tItRemark` (TextBox, line 111), `_chkReminderClose` (CheckBox, line 116), `_chkItmSale` (CheckBox, line 131).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_DAY_WORK

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_DAY_WORK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 5 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 47), `_mToDt` (MaskedTextBox, line 57), `_mFromDt` (MaskedTextBox, line 67), `_cboUser` (ComboBox, line 72), `_tBookCode` (TextBox, line 77).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_DHRN_LOAN

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_DHRN_LOAN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `DHRN_DATA`, `DHRN_ISU_DATA`.

Source extraction: 10 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mToDt` (DateEdit, line 48), `_mFromDt` (DateEdit, line 53), `_tRefAc` (TextBox, line 58), `_tAcCode` (TextBox, line 63), `_cboCity` (ComboBox, line 68), `_cboArea` (ComboBox, line 73), `_tLcCode` (TextBox, line 78), `_cboPacket` (ComboBox, line 133), `_tRefNo` (TextBox, line 138), `_tCustName` (TextBox, line 143).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_DHRN_OS

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_DHRN_OS.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `REPORT_DATA`.

Source extraction: 9 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboArea` (ComboBox, line 63), `_cboCity` (ComboBox, line 68), `_chkIntType` (CheckBox, line 73), `_cboEmp` (ComboBox, line 78), `_tAcCode` (TextBox, line 93), `_chkInt` (CheckBox, line 98), `_mToDt` (MaskedTextBox, line 103), `_mFromDt` (MaskedTextBox, line 108), `_tPacketNo` (TextBox, line 113).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_EMP

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_EMP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `REPORT_DATA`.

Source extraction: 9 inputs; 0 named columns; 4 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 53), `_mToDt` (MaskedTextBox, line 63), `_cboItmType` (ComboBox, line 68), `_mFromDt` (MaskedTextBox, line 78), `_chkItSelect` (CheckBox, line 98), `_tBookCode` (TextBox, line 103), `_nComVal` (TextBox, line 108), `_tGrCode` (TextBox, line 113), `_chkItGroup` (CheckBox, line 118).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_GRAPH

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_GRAPH.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 3 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 84), `_mToDt` (MaskedTextBox, line 89), `_tGrCode` (TextBox, line 94).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_GST

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_GST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 6 inputs; 3 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tBookCode` (TextBox, line 53), `_tAcCode` (TextBox, line 58), `_cboSectionType` (ComboBox, line 63), `_tLcCode` (TextBox, line 68), `_mFromDt` (MaskedTextBox, line 98), `_mToDt` (MaskedTextBox, line 103).

**MSG_VCH** — 3 named / 19 declared columns: `GSTR 3B`, `Month =`, `1`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_HUID

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_HUID.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/tag-stock/page.tsx](<../web/apps/web/app/(app)/reports/tag-stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `BAR_DETL`, `TAG_STOCK_PRINT`.

Source extraction: 4 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tTagNo` (TextBox, line 87), `_mToDt` (MaskedTextBox, line 92), `_mFromDt` (MaskedTextBox, line 97), `_tAcCode` (TextBox, line 102).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_INOUT

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_INOUT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `REPORT_DATA`.

Source extraction: 6 inputs; 0 named columns; 2 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 52), `_mToDt` (MaskedTextBox, line 67), `_mFromDt` (MaskedTextBox, line 72), `_cboValType` (ComboBox, line 77), `_chkProcuctWise` (CheckBox, line 82), `_tLdrCode` (TextBox, line 87).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_JDTR_ZOOM

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_JDTR_ZOOM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/karigar-ledger/page.tsx](<../web/apps/web/app/(app)/reports/karigar-ledger/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 6 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboCity` (ComboBox, line 56), `_mToDt` (MaskedTextBox, line 61), `_mFromDt` (MaskedTextBox, line 66), `_cboProcessName` (ComboBox, line 71), `_tAcCode` (TextBox, line 76), `_tMainDesign` (TextBox, line 81).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_LC_INOUT

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_LC_INOUT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 4 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 72), `_mToDt` (MaskedTextBox, line 77), `_tGrCode` (TextBox, line 87), `_tPrCode` (TextBox, line 92).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_LC_SALE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_LC_SALE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 4 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 72), `_mToDt` (MaskedTextBox, line 77), `_tGrCode` (TextBox, line 87), `_tPrCode` (TextBox, line 92).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_LEDR

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_LEDR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `FINE_DATA`, `LEDR_AC_DATA`.

Source extraction: 17 inputs; 0 named columns; 12 distinct validation-message candidates; 5 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 76), `_tAcGrCode` (TextBox, line 86), `_cboCity` (ComboBox, line 91), `_chkZero` (CheckBox, line 96), `_tKhataNo` (TextBox, line 111), `_chkOpBal` (CheckBox, line 121), `_mToDt` (MaskedTextBox, line 126), `_mFromDt` (MaskedTextBox, line 131), `_tRefAc` (TextBox, line 136), `_chkHalfMonth` (CheckBox, line 156), `_tLcCode` (TextBox, line 166), `_cboArea` (ComboBox, line 176), `_tSearch` (TextBox, line 181), `_chkGoldCol` (CheckBox, line 186), `_cboAcType` (ComboBox, line 191), `_cboState` (ComboBox, line 201), `_tVchdesc` (TextBox, line 211).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_MFG

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_MFG.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 5 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tRefAc` (TextBox, line 46), `_tAcCode` (TextBox, line 51), `_tLcCode` (TextBox, line 56), `_mToDt` (MaskedTextBox, line 81), `_mFromDt` (MaskedTextBox, line 86).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_MFG_LEDR

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_MFG_LEDR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/karigar-ledger/page.tsx](<../web/apps/web/app/(app)/reports/karigar-ledger/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 6 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 59), `_mToDt` (MaskedTextBox, line 74), `_mFromDt` (MaskedTextBox, line 79), `_tBookCode` (TextBox, line 84), `_tSearch` (TextBox, line 94), `_chkZero` (CheckBox, line 104).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_MFG_ZOOM

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_MFG_ZOOM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `MFG_MAST`.

Source extraction: 8 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboCity` (ComboBox, line 64), `_mToDt` (MaskedTextBox, line 69), `_mFromDt` (MaskedTextBox, line 74), `_cboProcessName` (ComboBox, line 79), `_tAcCode` (TextBox, line 84), `_tKrCode` (TextBox, line 89), `_tOrdNo` (TextBox, line 99), `_tOrdDesgn` (TextBox, line 109).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_MOVEMENT

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_MOVEMENT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 6 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 87), `_mToDt` (MaskedTextBox, line 92), `_chkWtType` (CheckBox, line 97), `_tLcCode` (TextBox, line 107), `_chkItmSelect` (CheckBox, line 122), `_tGrCode` (TextBox, line 132).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_ORDER

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_ORDER.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 7 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 69), `_cboCity` (ComboBox, line 79), `_cboArea` (ComboBox, line 84), `_chkZero` (CheckBox, line 89), `_chkOpBal` (CheckBox, line 94), `_mToDt` (MaskedTextBox, line 99), `_mFromDt` (MaskedTextBox, line 104).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_ORD_TRACK

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_ORD_TRACK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 10 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 70), `_mToDt` (DateEdit, line 75), `_mFromDt` (DateEdit, line 80), `_cboOrderType` (ComboBox, line 110), `_mToOrdDt` (MaskedTextBox, line 115), `_mFromOrdDt` (MaskedTextBox, line 120), `_tKrAcCode` (TextBox, line 125), `_tOrdNo` (TextBox, line 130), `_tEmpCode` (TextBox, line 140), `_tLcCode` (TextBox, line 155).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_OS

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_OS.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `LEDR_AC_DATA`.

Source extraction: 18 inputs; 0 named columns; 7 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mToDt` (DateEdit, line 49), `_mFromDt` (DateEdit, line 54), `_tRefAc` (TextBox, line 59), `_tAcCode` (TextBox, line 64), `_cboCity` (ComboBox, line 69), `_cboArea` (ComboBox, line 74), `_tAcGroup` (TextBox, line 79), `_cboDistrict` (ComboBox, line 84), `_tLcCode` (TextBox, line 89), `_chkAcSelect` (CheckBox, line 144), `_chkAcGroup` (CheckBox, line 154), `_ChkCity` (CheckBox, line 159), `_nPayIntPrc` (TextBox, line 169), `_nRecIntPrc` (TextBox, line 174), `_cboRptType` (ComboBox, line 179), `_nIntDays` (TextBox, line 184), `_chkGoldInt` (CheckBox, line 199), `_chkSilver` (CheckBox, line 204).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_OTH_DETL

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_OTH_DETL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 12 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tBookCode` (TextBox, line 47), `_tAcCode` (TextBox, line 52), `_cboCity` (ComboBox, line 57), `_cboArea` (ComboBox, line 62), `_tPrCode` (TextBox, line 67), `_cboItemTyp` (ComboBox, line 72), `_tLcCode` (TextBox, line 77), `_mToDt` (MaskedTextBox, line 82), `_mFromDt` (MaskedTextBox, line 87), `_tGrCode` (TextBox, line 92), `_chkBookSelect` (CheckBox, line 127), `_tItCode` (TextBox, line 132).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_PHY_STOCK

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_PHY_STOCK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/physical-stock/page.tsx](<../web/apps/web/app/(app)/txn/physical-stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `TAG_STOCK_PRINT`.

Source extraction: 5 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 63), `_mToDt` (MaskedTextBox, line 68), `_cboProduct` (ComboBox, line 73), `_tItCode` (TextBox, line 78), `_tCounterCode` (TextBox, line 83).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_REMINDER

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_REMINDER.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/reminders/page.tsx](<../web/apps/web/app/(app)/utilities/reminders/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `PR_DATA`, `RATE_CUT_DATA`, `REPORT_DATA`, `SL_DATA`, `USER_REQUEST`.

Source extraction: 3 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mToDt` (MaskedTextBox, line 92), `_mFromDt` (MaskedTextBox, line 97), `_chkKrOrdRec` (CheckBox, line 137).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_ROJMEL

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_ROJMEL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `GROUP_MAST`, `LEDR_AC_DATA`, `ROJMEL_BAL`, `TAG_STOCK_PRINT`.

Source extraction: 4 inputs; 10 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 1 grid-cell handlers.

Declared input controls: `_tLcCode` (TextBox, line 61), `_mToDt` (MaskedTextBox, line 81), `_TEXT_ENTRY` (TextBox, line 116), `_nClBal` (TextBox, line 136).

**MSG** — 10 named / 15 declared columns: `Sr.`, `Book`, `VchNo`, `Name`, `Jama`, `Sr.`, `Book`, `VchNo`, `Name`, `Udhar`.

Recalculation/selection handlers to trace: `MSG_EnterCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_SLPR_ZOOM

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_SLPR_ZOOM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 9 inputs; 0 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 94), `_mToDt` (MaskedTextBox, line 99), `_chkSalesRtn` (CheckBox, line 104), `_tLcCode` (TextBox, line 114), `_chkItmSelect` (CheckBox, line 129), `_tGrCode` (TextBox, line 139), `_tBookCode` (TextBox, line 154), `_chkBookSelect` (CheckBox, line 159), `_tAcCode` (TextBox, line 164).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_STK_LEVEL

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_STK_LEVEL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 4 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 47), `_mToDt` (MaskedTextBox, line 57), `_cboItmType` (ComboBox, line 62), `_tLcCode` (TextBox, line 72).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_STK_MOVE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_STK_MOVE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `MAIN_STOCK`.

Source extraction: 4 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 72), `_mToDt` (MaskedTextBox, line 77), `_tGrCode` (TextBox, line 87), `_tPrCode` (TextBox, line 92).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_STOCK

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_STOCK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `ITEM_MAST`, `MAIN_STOCK`, `REPORT_DATA`.

Source extraction: 9 inputs; 0 named columns; 5 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 110), `_mToDt` (MaskedTextBox, line 115), `_chkWtType` (CheckBox, line 120), `_tGrCode` (TextBox, line 125), `_tPrCode` (TextBox, line 130), `_tLcCode` (TextBox, line 145), `_tAcCode` (TextBox, line 160), `_tItCode` (TextBox, line 165), `_tDesignNo` (TextBox, line 170).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_STOCK_FINE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_STOCK_FINE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `BAL_GR`, `GROUP_MAST`, `ITEM_MAST`.

Source extraction: 3 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 83), `_mToDt` (MaskedTextBox, line 88), `_cboProduct` (ComboBox, line 93).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_STOCK_VALUE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_STOCK_VALUE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 4 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 74), `_mToDt` (MaskedTextBox, line 79), `_cboProduct` (ComboBox, line 84), `_tItCode` (TextBox, line 89).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_TAG

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_TAG.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/tag-stock/page.tsx](<../web/apps/web/app/(app)/reports/tag-stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `APR_DETL`, `BAR_CAN_DETL`, `KR_DETL`, `LBR_ISU_DETL`, `MAIN_STOCK`, `RATE_CUT_ISU`, `SL_DETL`, `TAG_STOCK_PRINT`, `TAG_SUM_DATA`.

Source extraction: 19 inputs; 0 named columns; 12 distinct validation-message candidates; 6 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tTagNo` (TextBox, line 121), `_mToDt` (MaskedTextBox, line 126), `_mFromDt` (MaskedTextBox, line 131), `_tPrCode` (TextBox, line 146), `_tGrCode` (TextBox, line 151), `_chkZeroId` (CheckBox, line 156), `_chkDuplicatTag` (CheckBox, line 161), `_chkDoubelTag` (CheckBox, line 166), `_tLcCode` (TextBox, line 171), `_tItCode` (TextBox, line 176), `_cboRptType` (ComboBox, line 181), `_tBookCode` (TextBox, line 186), `_chkTagLessNotStk` (CheckBox, line 191), `_chkSlWtDiff` (CheckBox, line 196), `_chkItDiff` (CheckBox, line 201), `_chkTagPcsDiff` (CheckBox, line 211), `_chkTagNotInBarDetl` (CheckBox, line 226), `_chkslandStk` (CheckBox, line 231), `_chkStkTagDbl` (CheckBox, line 251).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_TAG_ESTMATE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_TAG_ESTMATE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `TAG_IMAGE_DATA`, `TAG_STOCK_PRINT`.

Source extraction: 5 inputs; 0 named columns; 11 distinct validation-message candidates; 4 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tTagNo` (TextBox, line 113), `_nLbrPrc` (TextBox, line 123), `_nLbrRate` (TextBox, line 128), `_tPrCode` (TextBox, line 153), `_tGrCode` (TextBox, line 158).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_TAG_IMAGE

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_TAG_IMAGE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `TAG_IMAGE_DATA`.

Source extraction: 11 inputs; 0 named columns; 13 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboItemTyp` (ComboBox, line 79), `_tItCode` (TextBox, line 109), `_tGrCode` (TextBox, line 114), `_tMobileNo` (TextBox, line 134), `_nToWt` (TextBox, line 144), `_nFromWt` (TextBox, line 149), `_nToRow` (TextBox, line 154), `_nFromRow` (TextBox, line 159), `_tBookCode` (TextBox, line 164), `_chkItSelect` (CheckBox, line 169), `_tVchNo` (TextBox, line 189).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_TAX

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_TAX.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 7 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tRefAc` (TextBox, line 46), `_tAcCode` (TextBox, line 51), `_tLcCode` (TextBox, line 56), `_mToDt` (MaskedTextBox, line 86), `_mFromDt` (MaskedTextBox, line 91), `_tBookCode` (TextBox, line 96), `_tTaxCode` (TextBox, line 101).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_TOUR_ZOOM

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_TOUR_ZOOM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 8 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_cboCity` (ComboBox, line 57), `_mToDt` (MaskedTextBox, line 62), `_mFromDt` (MaskedTextBox, line 67), `_tAcCode` (TextBox, line 72), `_tGrCode` (TextBox, line 77), `_tPrCode` (TextBox, line 82), `_tTagNo` (TextBox, line 87), `_tIsuNo` (TextBox, line 97).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_TRADING

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_TRADING.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 5 inputs; 0 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tSlAcCode` (TextBox, line 58), `_mToDt` (MaskedTextBox, line 73), `_mFromDt` (MaskedTextBox, line 78), `_tPrAcCode` (TextBox, line 83), `_chkBookSelect` (CheckBox, line 98).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## RP_USER

Track **P10**. Category `report`. [Desktop source](<../unified/src/csharp/DataCareNext/RP_USER.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>); [web/apps/api/src/modules/reports/reports.ts](<../web/apps/api/src/modules/reports/reports.ts>)

Retained write-table candidates: `REPORT_DATA`, `TAG_STOCK_PRINT`, `USER_DATA`.

Source extraction: 6 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tAcCode` (TextBox, line 53), `_mToDt` (MaskedTextBox, line 63), `_mFromDt` (MaskedTextBox, line 73), `_cboUser` (ComboBox, line 78), `_tBookCode` (TextBox, line 83), `_chkItmlist` (CheckBox, line 113).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_AC_OPBL

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_AC_OPBL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/opening-balance/page.tsx](<../web/apps/web/app/(app)/masters/opening-balance/page.tsx>); [web/apps/web/app/(app)/txn/ac-opbl/page.tsx](<../web/apps/web/app/(app)/txn/ac-opbl/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/acOpening.ts](<../web/apps/api/src/modules/finance/acOpening.ts>); [web/apps/api/src/modules/masters/openingBalance.ts](<../web/apps/api/src/modules/masters/openingBalance.ts>)

Retained write-table candidates: `AC_DATA`, `CONTRA_DATA`, `DELETE_DATA`, `OP_DATA`, `USER_DATA`.

Source extraction: 9 inputs; 20 named columns; 16 distinct validation-message candidates; 3 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 34), `_tAcCode` (TextBox, line 49), `_cboBalType` (ComboBox, line 59), `_nOpAmt` (TextBox, line 64), `_cboAmt` (ComboBox, line 69), `_cboGold` (ComboBox, line 74), `_nOpGoldFine` (TextBox, line 79), `_cboSilver` (ComboBox, line 84), `_nOpSilverFine` (TextBox, line 89).

**MSG** — 19 named / 19 declared columns: `Sr.`, `VchNo`, `VchDate`, `BillNo`, `Days`, `Item Name`, `ItType`, `GrWt`, `NetWt`, `GhtWt`, `Touch`, `West%`, `Gold Fine`, `Silver Fine`, `DmPcs`, `DmWt`, `DmAmt`, `Amount`, `Cr/Dr`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_APR_ISU

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_APR_ISU.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/sales-order/page.tsx](<../web/apps/web/app/(app)/txn/sales-order/page.tsx>); [web/apps/web/app/(app)/txn/tour-return/page.tsx](<../web/apps/web/app/(app)/txn/tour-return/page.tsx>); [web/apps/web/app/(app)/txn/tour/page.tsx](<../web/apps/web/app/(app)/txn/tour/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/salesOrder.ts](<../web/apps/api/src/modules/sales/salesOrder.ts>); [web/apps/api/src/modules/tour/tour.ts](<../web/apps/api/src/modules/tour/tour.ts>)

Retained write-table candidates: `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `REMARK_DATA`, `SL_ORD_DETL`, `TEMP_BOOK_DATA`.

Source extraction: 9 inputs; 64 named columns; 22 distinct validation-message candidates; 4 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 124), `_tEmpCode` (TextBox, line 129), `_tVchDesc` (TextBox, line 134), `_tIsuNo` (TextBox, line 144), `_tLcCode` (TextBox, line 164).

**MSG** — 42 named / 78 declared columns: `Sr`, `OrdNo`, `KrRecDt`, `Party Order`, `ItCode`, `TagNo`, `ItCode`, `Counter`, `Design`, `Size`, `HmId`, `Remark`, `MtlColor`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `LDisc%`, `LDiscAmt`, `NetAmt`, `KrCode`, `ItRec`, `IsuNo`, `Year`, `Book`, `SrNo`, `TagId`, `Image`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `KrWt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_BILL_TO

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_BILL_TO.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/bill-to-bill/page.tsx](<../web/apps/web/app/(app)/txn/bill-to-bill/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/billToBill.ts](<../web/apps/api/src/modules/finance/billToBill.ts>)

Retained write-table candidates: `AC_DATA`, `BILL_OS_DATA`, `CASH_DATA`, `DELETE_DATA`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_PR_DETL`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 40 named columns; 15 distinct validation-message candidates; 2 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_TEXT_ENTRY` (TextBox, line 81), `_TEXT_IDTL` (TextBox, line 91), `_tEmpCode` (TextBox, line 111), `_tAcCode` (TextBox, line 116), `_TEXT_OLD` (TextBox, line 141).

**MSG** — 7 named / 9 declared columns: `Sr`, `RecAc`, `Rac Ac Name`, `It Desc`, `Chq No`, `Amount`, `Kasar`.

**MSG_BILL_TOT** — 1 named / None declared columns: `Total :`.

**MSG_IDTL** — 18 named / 18 declared columns: `Sr`, `BillNo`, `Book`, `BillAmt`, `RecAdj`, `RecAmt`, `KasarAmt`, `DiffAmt`, `OrnaIsu`, `ItDesc`, `BillYrCd`, `BillDbCd`, `BillSr`, `BillLc`, `BillHdNo`, `InstAmt`, `InstDate`, `EntryMOde`.

**MSG_OLD** — 13 named / 13 declared columns: `Sr`, `RecCode`, `Rec ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `Fine`, `RTyp`, `Rate`, `NetAmt`, `ConWt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_BUL_BOOKING

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_BUL_BOOKING.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/bullion/page.tsx](<../web/apps/web/app/(app)/txn/bullion/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/bullion/bullion.ts](<../web/apps/api/src/modules/bullion/bullion.ts>)

Retained write-table candidates: `AC_DATA`, `BUL_DATA`, `DELETE_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 6 inputs; 15 named columns; 15 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_tItDesc` (TextBox, line 105), `_tToLcCode` (TextBox, line 110).

**MSG** — 14 named / 19 declared columns: `Sr`, `AcCode`, `AcName`, `ItCode`, `ItName`, `Grwt`, `McxRate`, `Premium`, `Rate`, `Amount`, `C/B`, `Tax`, `TotAmt`, `Time`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_BUL_SALE

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_BUL_SALE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/bullion/page.tsx](<../web/apps/web/app/(app)/txn/bullion/page.tsx>); [web/apps/web/app/(app)/txn/rate-cut/page.tsx](<../web/apps/web/app/(app)/txn/rate-cut/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/bullion/bullion.ts](<../web/apps/api/src/modules/bullion/bullion.ts>); [web/apps/api/src/modules/sales/rateCut.ts](<../web/apps/api/src/modules/sales/rateCut.ts>)

Retained write-table candidates: `AC_DATA`, `BUL_DATA`, `DELETE_DATA`, `MAIN_STOCK`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_IDTL`, `TAX_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`.

Source extraction: 27 inputs; 93 named columns; 15 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tAcCode` (TextBox, line 100), `_tAcName` (TextBox, line 105), `_tEmpCode` (TextBox, line 110), `_tVchDesc` (TextBox, line 115), `_TEXT_ENTRY_2` (TextBox, line 130), `_TEXT_PR` (TextBox, line 135), `_tBillNo` (TextBox, line 140), `_tMobile` (TextBox, line 145), `_tCity` (TextBox, line 150), `_tAdd3` (TextBox, line 155), `_tAdd2` (TextBox, line 160), `_tAdd1` (TextBox, line 165), `_nAcDrAmt` (TextBox, line 170), `_nAcCrFine` (TextBox, line 175), `_nAcCrAmt` (TextBox, line 180), `_nAcDrFine` (TextBox, line 185), `_nFineKsrDr` (TextBox, line 190), `_nFineKsrCr` (TextBox, line 195), `_nFineRate` (TextBox, line 200), `_nCrDays` (TextBox, line 205), `_cboItemTyp` (ComboBox, line 210), `_nConvPrc` (TextBox, line 215), `_nConvRate` (TextBox, line 220), `_cboBillType` (ComboBox, line 225).

**MSG** — 53 named / 81 declared columns: `Sr`, `SlOrdNo`, `ItCode`, `ItName`, `HuId`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `LTouch`, `LessWt`, `Fine`, `AdjWt`, `McxRate`, `Premium`, `ItRate`, `ItAmt`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `NetAmt`, `TotAmt`, `Tax%`, `Counter`, `Design`, `Size`, `BagWt`, `Ght%`, `GhtWt`, `West%`, `SlvrFine`, `ConRate`, `Con%`, `Lbr%`, `OFine`, `Mrp`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_PR** — 36 named / 50 declared columns: `Sr`, `PrOrdNo`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `LTouch`, `LesWt`, `Fine`, `AdjWt`, `McxRate`, `Premium`, `Rate`, `ItAmt`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `NetAmt`, `Counter`, `BagWt`, `PsWt`, `GhtWt`, `West%`, `SlvFine`, `ConRate`, `Con%`, `Lbr%`, `OFine`, `Mrp`, `HmFine`, `TotAmt`, `TaxPrc`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_CARD_REC

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_CARD_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/batch-receipt/page.tsx](<../web/apps/web/app/(app)/txn/batch-receipt/page.tsx>); [web/apps/web/app/(app)/txn/payment/page.tsx](<../web/apps/web/app/(app)/txn/payment/page.tsx>); [web/apps/web/app/(app)/txn/receipt/page.tsx](<../web/apps/web/app/(app)/txn/receipt/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/finance.ts](<../web/apps/api/src/modules/finance/finance.ts>); [web/apps/api/src/modules/finance/tender.ts](<../web/apps/api/src/modules/finance/tender.ts>)

Retained write-table candidates: `AC_DATA`, `CARD_DATA`, `DELETE_DATA`, `DHRN_DATA`, `DHRN_REC_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 15 inputs; 0 named columns; 10 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 37), `_tVchNo` (TextBox, line 42), `_tAcCode` (TextBox, line 87), `_tAcName` (TextBox, line 92), `_tEmpCode` (TextBox, line 97), `_tVchDesc` (TextBox, line 102), `_nBankComPrc` (TextBox, line 107), `_nSchPrc` (TextBox, line 112), `_nCardCommPrc` (TextBox, line 117), `_nCardComAmt` (TextBox, line 122), `_tCardAc` (TextBox, line 127), `_nBankCom1` (TextBox, line 132), `_nCardAmt` (TextBox, line 137), `_nBankCom2` (TextBox, line 142), `_nCashPaid` (TextBox, line 147).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_CASH

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_CASH.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/batch-receipt/page.tsx](<../web/apps/web/app/(app)/txn/batch-receipt/page.tsx>); [web/apps/web/app/(app)/txn/payment/page.tsx](<../web/apps/web/app/(app)/txn/payment/page.tsx>); [web/apps/web/app/(app)/txn/receipt/page.tsx](<../web/apps/web/app/(app)/txn/receipt/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/finance.ts](<../web/apps/api/src/modules/finance/finance.ts>); [web/apps/api/src/modules/finance/tender.ts](<../web/apps/api/src/modules/finance/tender.ts>)

Retained write-table candidates: `AC_DATA`, `APR_IDTL`, `CASH_DATA`, `DELETE_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 11 named columns; 12 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_TEXT_ENTRY` (TextBox, line 81), `_tEmpCode` (TextBox, line 101), `_tChqPrintName` (TextBox, line 111), `_tItDesc` (TextBox, line 116), `_tbankName` (TextBox, line 121).

**MSG** — 10 named / 14 declared columns: `Sr`, `AcCode`, `Ac Name`, `Chq No`, `Clearing Dt`, `Amount`, `Charges`, `Kasar`, `Remark`, `Chq No`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_CONTRA

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_CONTRA.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/contra/page.tsx](<../web/apps/web/app/(app)/txn/contra/page.tsx>); [web/apps/web/app/(app)/txn/journal/page.tsx](<../web/apps/web/app/(app)/txn/journal/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/finance.ts](<../web/apps/api/src/modules/finance/finance.ts>); [web/apps/api/src/modules/finance/journal.ts](<../web/apps/api/src/modules/finance/journal.ts>)

Retained write-table candidates: `AC_DATA`, `APR_IDTL`, `CONTRA_DATA`, `DELETE_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 5 inputs; 8 named columns; 13 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_cboItemTyp` (ComboBox, line 105).

**MSG** — 7 named / 9 declared columns: `Sr`, `Cr/Dr`, `AcCode`, `Ac Name`, `It Desc`, `CrAmt`, `DrAmt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_DHRN_INTREC

Track **P09**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_DHRN_INTREC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/dhrn-interest/page.tsx](<../web/apps/web/app/(app)/txn/dhrn-interest/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/dhrn/dhrn.ts](<../web/apps/api/src/modules/dhrn/dhrn.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `DHRN_DATA`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 28 inputs; 0 named columns; 9 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 38), `_tVchNo` (TextBox, line 43), `_tAcCode` (TextBox, line 88), `_tAcName` (TextBox, line 93), `_tEmpCode` (TextBox, line 98), `_tVchDesc` (TextBox, line 103), `_tBillNo` (TextBox, line 108), `_nDhrnAmt` (TextBox, line 113), `_nMonthlyInt` (TextBox, line 118), `_nDhrnMonth` (TextBox, line 123), `_nIntPrc` (TextBox, line 128), `_nIntDays` (TextBox, line 133), `_mToDate` (MaskedTextBox, line 138), `_nIntAmt` (TextBox, line 143), `_tIsuNo` (TextBox, line 148), `_tRecAc` (TextBox, line 158), `_nIntRecAmt` (TextBox, line 163), `_mIsuDate` (MaskedTextBox, line 168), `_mFromDate` (MaskedTextBox, line 173), `_nDhrnReceived` (TextBox, line 178), `_chkInt` (CheckBox, line 183), `_cboIntMonth` (ComboBox, line 188), `_cboLoanType` (ComboBox, line 193), `_nUnchakDhrnRec` (TextBox, line 198), `_nIntrestKasar` (TextBox, line 203), `_nRcutAmt` (TextBox, line 208), `_nFineRate` (TextBox, line 213), `_nPayAmt` (TextBox, line 218).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_DHRN_ISU

Track **P09**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_DHRN_ISU.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/dhrn-issue/page.tsx](<../web/apps/web/app/(app)/txn/dhrn-issue/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/dhrn/dhrn.ts](<../web/apps/api/src/modules/dhrn/dhrn.ts>)

Retained write-table candidates: `AC_DATA`, `AC_IMAGE`, `DELETE_DATA`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 25 inputs; 16 named columns; 14 distinct validation-message candidates; 4 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_tAcCode` (TextBox, line 103), `_tAcName` (TextBox, line 108), `_tEmpCode` (TextBox, line 113), `_tVchDesc` (TextBox, line 118), `_TEXT_ENTRY` (TextBox, line 128), `_tBillNo` (TextBox, line 133), `_tItDesc` (TextBox, line 138), `_nDhrnAmt` (TextBox, line 143), `_nMonthlyInt` (TextBox, line 148), `_nMonthIntAmt` (TextBox, line 153), `_tPacketNo` (TextBox, line 158), `_nDhrnMonth` (TextBox, line 163), `_nIntPrc` (TextBox, line 168), `_nIntDays` (TextBox, line 173), `_mToDate` (MaskedTextBox, line 178), `_cboIntMonth` (ComboBox, line 183), `_nIntAmt` (TextBox, line 188), `_nOtherCharges` (TextBox, line 193), `_tIsuNo` (TextBox, line 198), `_tRecAc` (TextBox, line 208), `_nRecAmt` (TextBox, line 228), `_cboLoanType` (ComboBox, line 233), `_mDueDate` (MaskedTextBox, line 243).

**MSG** — 15 named / 27 declared columns: `Sr`, `PacketNo`, `CustName`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `West%`, `Fine`, `Rate`, `ItAmt`, `NetAmt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_DHRN_REC

Track **P09**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_DHRN_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/dhrn-receipt/page.tsx](<../web/apps/web/app/(app)/txn/dhrn-receipt/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/dhrn/dhrn.ts](<../web/apps/api/src/modules/dhrn/dhrn.ts>); [web/apps/api/src/modules/dhrn/dhrnReceipt.ts](<../web/apps/api/src/modules/dhrn/dhrnReceipt.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 28 inputs; 17 named columns; 13 distinct validation-message candidates; 3 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_tAcCode` (TextBox, line 100), `_tAcName` (TextBox, line 105), `_tEmpCode` (TextBox, line 110), `_tVchDesc` (TextBox, line 115), `_TEXT_ENTRY` (TextBox, line 125), `_tBillNo` (TextBox, line 130), `_tItDesc` (TextBox, line 135), `_nDhrnAmt` (TextBox, line 140), `_nMonthlyInt` (TextBox, line 145), `_tPacketNo` (TextBox, line 150), `_nDhrnMonth` (TextBox, line 155), `_nIntPrc` (TextBox, line 160), `_nIntDays` (TextBox, line 165), `_mToDate` (MaskedTextBox, line 170), `_nIntAmt` (TextBox, line 175), `_tIsuNo` (TextBox, line 180), `_tRecAc` (TextBox, line 190), `_nIntRecAmt` (TextBox, line 195), `_mIsuDate` (MaskedTextBox, line 200), `_mFromDate` (MaskedTextBox, line 205), `_nDhrnReceived` (TextBox, line 210), `_nIntKasr` (TextBox, line 215), `_chkInt` (CheckBox, line 220), `_cboLoanType` (ComboBox, line 225), `_nFineRate` (TextBox, line 240), `_nPayAmt` (TextBox, line 245).

**MSG** — 16 named / 28 declared columns: `Sr`, `PacketNo`, `CustName`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `West%`, `Fine`, `Rate`, `ItAmt`, `NetAmt`, `PktReIsu`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_EMP_JV

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_EMP_JV.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/employee-jv/page.tsx](<../web/apps/web/app/(app)/txn/employee-jv/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/employeeJv.ts](<../web/apps/api/src/modules/finance/employeeJv.ts>)

Retained write-table candidates: `AC_DATA`, `APR_IDTL`, `EMP_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 5 inputs; 19 named columns; 11 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_tItDesc` (TextBox, line 110).

**MSG** — 18 named / 25 declared columns: `Sr`, `Tds%`, `Ac Name`, `Salary`, `DayHours`, `TotHours`, `Day`, `Salary Amt`, `Tds%`, `Tds%`, `Tds%`, `Ldr Bal`, `Type`, `Diff Amt`, `Pay Amt`, `PaidAc`, `ChqNo`, `Cash/BankName`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_FINE_SL_PR

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_FINE_SL_PR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/fine-sale/page.tsx](<../web/apps/web/app/(app)/txn/fine-sale/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/bullion/fineSalePurchase.ts](<../web/apps/api/src/modules/bullion/fineSalePurchase.ts>)

Retained write-table candidates: `AC_DATA`, `CUT_DATA`, `CUT_DETL`, `CUT_STK_DETL`, `MAIN_STOCK`, `PR_DETL`, `RATE_CUT_ISU`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 31 named columns; 14 distinct validation-message candidates; 2 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_TEXT_ENTRY` (TextBox, line 81), `_TEXT_IDTL` (TextBox, line 91), `_tEmpCode` (TextBox, line 111), `_tAcCode` (TextBox, line 116), `_TEXT_ENTRY_2` (TextBox, line 126).

**MSG** — 11 named / 14 declared columns: `Sr`, `NetWt`, `Touch`, `Fine`, `ConRate`, `Con%`, `Rate1Gm`, `Amount`, `TotAmt`, `Tax%`, `NetAmt`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_BILL_TOT** — 1 named / None declared columns: `Total :`.

**MSG_IDTL** — 17 named / 31 declared columns: `Sr`, `BillNo`, `Book`, `BkSr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `NetWt`, `Touch`, `West%`, `Fine`, `CutFine`, `CutGwt`, `CutNwt`, `CutPcs`, `CutAmt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_FN_INOUT

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_FN_INOUT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/fine-inout/page.tsx](<../web/apps/web/app/(app)/txn/fine-inout/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/inout/fineInout.ts](<../web/apps/api/src/modules/inout/fineInout.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `FAN_DATA`, `FAN_DETL`, `FAN_IDTL`, `GROUP_MAST`, `ITEM_MAST`, `MAIN_STOCK`, `PRODUCT_MAST`, `ROJ_MEL_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 61 named columns; 21 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tToLcCode` (TextBox, line 128), `_tEmpCode` (TextBox, line 133), `_tVchDesc` (TextBox, line 138), `_tFrmLc` (TextBox, line 143), `_tTagVch` (TextBox, line 148), `_TEXT_ENTRY_2` (TextBox, line 158).

**MSG** — 42 named / 77 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Color`, `Size`, `HmId`, `Sign`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `TagCost`, `MMargin`, `MainMrp`, `Margin`, `Mrp`, `NetAmt`, `TrfrItm`, `TrfrItmName`, `KrCode`, `Rfid`, `KrOthWt`, `KrNwt`, `KrTouch`, `KrWst%`, `KrFine`, `Image`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 17 named / 32 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `Weight`, `KrWt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_GOLD_BOOK

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_GOLD_BOOK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/gold-book/page.tsx](<../web/apps/web/app/(app)/txn/gold-book/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/goldBook.ts](<../web/apps/api/src/modules/finance/goldBook.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `DG_GOLD_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 5 inputs; 14 named columns; 13 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_tItDesc` (TextBox, line 105).

**MSG** — 13 named / 19 declared columns: `Sr`, `AcCode`, `AcName`, `Mobile`, `Amount`, `Rate`, `Fine`, `RecAc`, `TaxCod`, `Tax%`, `TaxAmt`, `TotAmt`, `Time`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_INOUT

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_INOUT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/fine-inout/page.tsx](<../web/apps/web/app/(app)/txn/fine-inout/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/inout/fineInout.ts](<../web/apps/api/src/modules/inout/fineInout.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `INOUT_DATA`, `INOUT_DETL`, `INOUT_IDTL`, `ITM_LOT_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_ORD_DETL`, `TAG_IMAGE_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 9 inputs; 65 named columns; 21 distinct validation-message candidates; 2 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tToLcCode` (TextBox, line 123), `_tEmpCode` (TextBox, line 128), `_tEmpName` (TextBox, line 133), `_tVchDesc` (TextBox, line 138), `_tTagVch` (TextBox, line 143).

**MSG** — 47 named / 95 declared columns: `Sr`, `TagNo`, `ItmLot`, `ItCode`, `Counter`, `Design`, `Style`, `Color`, `Size`, `HmId`, `Sign`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `TrfrItm`, `TrfrItmName`, `LCode`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `TagCost`, `Mrp`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `ItRate`, `ItAmt`, `Margin`, `Image`.

**MSG_IDTL** — 17 named / 32 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `Weight`, `KrWt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_ITM_LOT

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_ITM_LOT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/item-lot/page.tsx](<../web/apps/web/app/(app)/txn/item-lot/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>); [web/apps/api/src/modules/stock/stockVoucherLifecycle.ts](<../web/apps/api/src/modules/stock/stockVoucherLifecycle.ts>)

Retained write-table candidates: `BAR_DATA`, `ITM_LOT_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 5 inputs; 29 named columns; 11 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 79), `_tEmpCode` (TextBox, line 99), `_tItCode` (TextBox, line 134).

**MSG** — 28 named / 36 declared columns: `Sr`, `ItCode`, `ItmLot`, `AcCode`, `Design`, `Size`, `Counter`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `West%`, `Fine`, `KrOthWt`, `KrNwt`, `KrTouch`, `KrWst%`, `KrFine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Remark`, `KrName`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_ITM_OPBL

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_ITM_OPBL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/item-opening/page.tsx](<../web/apps/web/app/(app)/txn/item-opening/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>); [web/apps/api/src/modules/stock/stockVoucherLifecycle.ts](<../web/apps/api/src/modules/stock/stockVoucherLifecycle.ts>)

Retained write-table candidates: `DM_DATA`, `ITM_OPBL`, `MAIN_STOCK`.

Source extraction: 2 inputs; 19 named columns; 7 distinct validation-message candidates; 1 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 31), `_cboItemTyp` (ComboBox, line 41).

**MSG** — 18 named / 18 declared columns: `Sr.`, `ItCode`, `Item Name`, `Rtype`, `Pcs`, `GrWt`, `NetWt`, `Touch`, `West%`, `Fine`, `Rate`, `ItmAmt`, `LType`, `LRate`, `LbrAmt`, `OthAmt`, `NetAmt`, `ItType`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_JDT_REC

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_JDT_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/jobwork-issue/page.tsx](<../web/apps/web/app/(app)/txn/jobwork-issue/page.tsx>); [web/apps/web/app/(app)/txn/jobwork-receive/page.tsx](<../web/apps/web/app/(app)/txn/jobwork-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/karigar.ts](<../web/apps/api/src/modules/manufacturing/karigar.ts>); [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `DELETE_DATA`, `MAIN_STOCK`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_ORD_ADJ`, `TAG_IMAGE_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 58 named columns; 20 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tEmpCode` (TextBox, line 128), `_tVchDesc` (TextBox, line 133), `_tItRemark` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 148), `_tBillNo` (TextBox, line 153).

**MSG** — 40 named / 77 declared columns: `Sr`, `OrdNo`, `OrdSr`, `Design`, `ItCode`, `Design`, `Pcs`, `JdtrWt`, `GhtWt`, `Kundan`, `WaxWt`, `JdtGwt`, `JdtNwt`, `AddIt`, `AddGwt`, `AddNwt`, `AddTch`, `AddFine`, `TotGwt`, `TotOth`, `TotNwt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `LType`, `LRate`, `LAmt`, `OthAmt`, `NetAmt`, `Image`, `OrdNo`, `OrdSr`, `Ord Design`, `Order Cust`, `KrCode`, `ItRate`, `ItAmt`, `Lbr%`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 16 named / 16 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `KrLRate`, `KrLAmt`, `NetAmt`, `OldItm`, `ConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_KR_ISU

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_KR_ISU.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/karigar-issue/page.tsx](<../web/apps/web/app/(app)/txn/karigar-issue/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/karigar.ts](<../web/apps/api/src/modules/manufacturing/karigar.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `DM_KR_DATA`, `MAIN_STOCK`, `MFG_ISU_REC`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 16 inputs; 36 named columns; 16 distinct validation-message candidates; 4 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_tAcCode` (TextBox, line 103), `_tAcName` (TextBox, line 108), `_tEmpCode` (TextBox, line 113), `_tVchDesc` (TextBox, line 118), `_TEXT_ENTRY_2` (TextBox, line 133), `_TEXT_ENTRY` (TextBox, line 138), `_tBankName` (TextBox, line 143), `_tBillNo` (TextBox, line 148), `_tMobile` (TextBox, line 153), `_tCity` (TextBox, line 158), `_tAdd3` (TextBox, line 163), `_tAdd2` (TextBox, line 168), `_tAdd1` (TextBox, line 173), `_tConsiNo` (TextBox, line 183).

**MSG** — 34 named / 50 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Counter`, `Design`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `GhtWt`, `Touch`, `West%`, `LesTch`, `LesWt`, `Fine`, `OthAmt`, `ConIt`, `Con%`, `ConWt`, `TotWt`, `AvgRate`, `AvgAmt`, `ConRate`, `Rate`, `ItAmt`, `Ltype`, `LRate`, `LAmt`, `NetAmt`, `OFine`, `BagWt`, `PsWt`, `TagId`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_LEDR_ADJ

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_LEDR_ADJ.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/fine-jv/page.tsx](<../web/apps/web/app/(app)/txn/fine-jv/page.tsx>); [web/apps/web/app/(app)/txn/ledger-adjust/page.tsx](<../web/apps/web/app/(app)/txn/ledger-adjust/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/fineJv.ts](<../web/apps/api/src/modules/finance/fineJv.ts>); [web/apps/api/src/modules/finance/ledgerAdjust.ts](<../web/apps/api/src/modules/finance/ledgerAdjust.ts>)

Retained write-table candidates: `AC_DATA`, `LDR_ADJ_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 9 named columns; 14 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 42), `_tVchNo` (TextBox, line 47), `_TEXT_ENTRY` (TextBox, line 82), `_tEmpCode` (TextBox, line 102), `_tItDesc` (TextBox, line 112), `_tAcCode` (TextBox, line 117), `_chkRemark` (CheckBox, line 122).

**MSG** — 9 named / 10 declared columns: `Sr`, `CrAmt`, `DrAmt`, `DiffAmt`, `ItType`, `CrFine`, `DrFine`, `DiffFine`, `Remark`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_LOCT_AMT

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_LOCT_AMT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/location-amount/page.tsx](<../web/apps/web/app/(app)/txn/location-amount/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/locationAmount.ts](<../web/apps/api/src/modules/finance/locationAmount.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `LOCT_AMT`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 8 named columns; 13 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 42), `_tVchNo` (TextBox, line 47), `_TEXT_ENTRY` (TextBox, line 82), `_tEmpCode` (TextBox, line 102), `_tItDesc` (TextBox, line 112), `_tFrmLc` (TextBox, line 117), `_tToLcCode` (TextBox, line 122).

**MSG** — 7 named / 10 declared columns: `Sr`, `AcCode`, `Ac Name`, `Chq No`, `Amount`, `Remark`, `Kasar`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MEMB_ADJ

Track **P09**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MEMB_ADJ.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/[report]/page.tsx](<../web/apps/web/app/(app)/reports/[report]/page.tsx>); [web/apps/web/app/(app)/txn/membership/page.tsx](<../web/apps/web/app/(app)/txn/membership/page.tsx>); [web/apps/web/app/(app)/txn/scheme/page.tsx](<../web/apps/web/app/(app)/txn/scheme/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/membership/membership.ts](<../web/apps/api/src/modules/membership/membership.ts>); [web/apps/api/src/modules/membership/scheme.ts](<../web/apps/api/src/modules/membership/scheme.ts>)

Retained write-table candidates: `AC_DATA`, `AD_ADJ`, `AD_MEMB`, `AD_OS`, `DELETE_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 4 inputs; 18 named columns; 11 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100).

**MSG** — 17 named / 23 declared columns: `Sr`, `Schm`, `MembNo`, `Memb Name`, `MetalWt`, `MetalRate`, `MetalAmt`, `MembTot`, `Bonus`, `LessAmt`, `BillNo`, `BillAmt`, `AdjAmt`, `MembBal`, `PaidAc`, `Paid Ac Name`, `GlLessAmt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MEMB_ENT

Track **P09**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MEMB_ENT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/membership/page.tsx](<../web/apps/web/app/(app)/txn/membership/page.tsx>); [web/apps/web/app/(app)/txn/scheme/page.tsx](<../web/apps/web/app/(app)/txn/scheme/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/membership/membership.ts](<../web/apps/api/src/modules/membership/membership.ts>); [web/apps/api/src/modules/membership/scheme.ts](<../web/apps/api/src/modules/membership/scheme.ts>)

Retained write-table candidates: `AC_DATA`, `AD_DATA`, `AD_OS`, `DELETE_DATA`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_AD_DATA`, `TEMP_BOOK_DATA`, `UPI_DATA`, `USER_DATA`.

Source extraction: 10 inputs; 18 named columns; 16 distinct validation-message candidates; 2 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 45), `_tVchNo` (TextBox, line 50), `_TEXT_ENTRY` (TextBox, line 85), `_tEmpCode` (TextBox, line 105), `_tSchmCode` (TextBox, line 110), `_tBankName` (TextBox, line 115), `_tChqNo` (TextBox, line 120), `_tVchDesc` (TextBox, line 125), `_tQrCane` (TextBox, line 130), `_TEXT_UPI` (TextBox, line 145).

**MSG** — 9 named / 15 declared columns: `Sr`, `Code`, `Memb Name`, `Rec Date`, `WithUpi`, `RecAc`, `Rate`, `GrWt`, `Amount`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

**MSG_UPI** — 8 named / 8 declared columns: `Sr.`, `AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`, `UpiAmt`, `RowSrNo`, `MemebCode`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`, `MSG_UPI_EnterCell`, `MSG_UPI_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_GHAT_REC

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_GHAT_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `DELETE_DATA`, `MAIN_STOCK`, `MFG_DATA`, `MFG_DETL`, `MFG_ISU_REC`, `REMARK_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 28 named columns; 16 distinct validation-message candidates; 3 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_tAcCode` (TextBox, line 101), `_tAcName` (TextBox, line 106), `_tEmpCode` (TextBox, line 111), `_tVchDesc` (TextBox, line 116), `_TEXT_ENTRY_2` (TextBox, line 131), `_TEXT_ENTRY` (TextBox, line 136), `_tBillNo` (TextBox, line 141), `_tMobile` (TextBox, line 146).

**MSG** — 26 named / 66 declared columns: `Sr`, `OrdNo`, `OrdSr`, `ItCode`, `LotNo`, `Design`, `cSize`, `IsuGwt`, `Pcs`, `GrWt`, `MinoWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Chole`, `Ghis`, `LbrRat`, `LbrAmt`, `OthAmt`, `NetAmt`, `OrdParty`, `OrdYr`, `OrdBk`, `OrdAc`, `ItName`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_ISU_REC

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-issue/page.tsx](<../web/apps/web/app/(app)/txn/mfg-issue/page.tsx>); [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `DELETE_DATA`, `MAIN_STOCK`, `MENU_DATA`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `REMARK_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 11 inputs; 43 named columns; 17 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 45), `_tVchNo` (TextBox, line 50), `_TEXT_ENTRY` (TextBox, line 85), `_TEXT_IDTL` (TextBox, line 100), `_tAcCode` (TextBox, line 125), `_tEmpCode` (TextBox, line 130), `_tVchDesc` (TextBox, line 135), `_tItRemark` (TextBox, line 140), `_TEXT_ENTRY_2` (TextBox, line 150), `_tBillNo` (TextBox, line 155), `_tKrCode` (TextBox, line 180).

**MSG** — 19 named / 55 declared columns: `Sr`, `LotNo`, `ItCode`, `Design`, `IsPcs`, `IsGwt`, `IsOWt`, `IsNwt`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Chole`, `Ghis`, `NetAmt`, `DifP`, `DifWt`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 22 named / 22 declared columns: `Sr`, `ItCode`, `ItName`, `IsuPcs`, `IsuWt`, `Pcs`, `Weight`, `Con%`, `RtnPcs`, `RtnWt`, `BrkPcs`, `BrkWt`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `OldItm`, `ConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_ITEM

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_ITEM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-issue/page.tsx](<../web/apps/web/app/(app)/txn/mfg-issue/page.tsx>); [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `ITM_LOT_DETL`, `LOT_DETL`, `MAIN_STOCK`, `MENU_DATA`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `REMARK_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 42 named columns; 17 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tEmpCode` (TextBox, line 128), `_tVchDesc` (TextBox, line 133), `_tItRemark` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 148), `_tBillNo` (TextBox, line 153).

**MSG** — 17 named / 76 declared columns: `Sr`, `ItCode`, `ItName`, `TagLot`, `Design`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `West%`, `Fine`, `Ght%`, `GhtWt`, `LbrRate`, `LbrAmt`, `NetAmt`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 23 named / 23 declared columns: `Sr`, `ItmLot`, `ItCode`, `ItName`, `OrdPcs`, `OrdWt`, `Pcs`, `Weight`, `Con%`, `RtnPcs`, `RtnWt`, `BrkPcs`, `BrkWt`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `OldItm`, `ConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_KR_ISU_REC

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_KR_ISU_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/karigar-issue/page.tsx](<../web/apps/web/app/(app)/txn/karigar-issue/page.tsx>); [web/apps/web/app/(app)/txn/karigar-receive/page.tsx](<../web/apps/web/app/(app)/txn/karigar-receive/page.tsx>); [web/apps/web/app/(app)/txn/mfg-issue/page.tsx](<../web/apps/web/app/(app)/txn/mfg-issue/page.tsx>); [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/karigar.ts](<../web/apps/api/src/modules/manufacturing/karigar.ts>); [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `MAIN_STOCK`, `MENU_DATA`, `MFG_ASMBL_DETL`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `REMARK_DATA`, `SL_ORD_DETL`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 12 inputs; 89 named columns; 17 distinct validation-message candidates; 3 confirmation candidates; 9 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 124), `_tEmpCode` (TextBox, line 129), `_tVchDesc` (TextBox, line 134), `_tItRemark` (TextBox, line 139), `_TEXT_ENTRY_2` (TextBox, line 149), `_tBillNo` (TextBox, line 154), `_chklotAsemble` (CheckBox, line 179), `_TEXT_ADJ` (TextBox, line 199).

**MSG** — 43 named / 83 declared columns: `Sr`, `DesignVch`, `TagLot`, `ItmLot`, `ItCode`, `ItName`, `TagLot`, `Design`, `Size`, `RecWt`, `WaxWt`, `RtnWt`, `RtnIt`, `AddWt`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `LotNo`, `ItCode`, `ItName`, `LotWt`, `Ght%`, `GhtWt`, `Touch`, `Fine`, `Chole`, `CholIt`, `Ghis`, `LbrRate`, `LbrAmt`, `NetAmt`, `IsuGwt`, `DiffWt`, `OrdNo`, `OrdIt`, `OPcs`, `OGrWt`, `ONetWt`, `CustOrd`, `OrdSr`, `Design`, `OrdCust Name`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_ADJ** — 20 named / 29 declared columns: `Sr`, `LotNo`, `ItCode`, `ItName`, `Design`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `OPcs`, `OGrWt`, `OthWt`, `ONetWt`, `CustOrd`, `OrdYr`, `OrdBk`, `OrdSr`, `CustCode`, `OrdCust Name`, `NetAmt`.

**MSG_IDTL** — 24 named / 24 declared columns: `Sr`, `ItmLot`, `ItCode`, `ItName`, `OrdPcs`, `OrdWt`, `Pcs`, `Weight`, `Con%`, `RtnPcs`, `RtnWt`, `BrkPcs`, `BrkWt`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `OldItm`, `ConWt`, `ItType`, `RowSrNo`, `ItLotAc`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_ADJ_EnterCell`, `MSG_ADJ_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_ORD_ISU

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_ORD_ISU.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-order-issue/page.tsx](<../web/apps/web/app/(app)/txn/mfg-order-issue/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `APR_DATA`, `APR_DETL`, `APR_IDTL`, `DELETE_DATA`, `MAIN_STOCK`, `MFG_DETL`, `MFG_ISU_REC`, `REMARK_DATA`, `SL_ORD_DETL`, `TEMP_BOOK_DATA`.

Source extraction: 8 inputs; 74 named columns; 21 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 124), `_tEmpCode` (TextBox, line 129), `_tVchDesc` (TextBox, line 134), `_TEXT_OLD` (TextBox, line 159).

**MSG** — 34 named / 74 declared columns: `Sr`, `OrdNo`, `KrRecDt`, `Party Order`, `TagNo`, `ItCode`, `Counter`, `Design`, `Size`, `Remark`, `MtlColor`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `NetAmt`, `KrCode`, `TagId`, `Image`, `HmId`, `BagWt`, `Ght%`, `GhtWt`, `ItRate`, `ItAmt`, `Mrp`.

**MSG_DM** — 4 named / 4 declared columns: `Sr`, `ItCode`, `Pcs`, `Gwt`.

**MSG_IDTL** — 22 named / 22 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `PcsWt`, `Pcs`, `Weight`, `KrWt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_OLD** — 13 named / 13 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `Fine`, `RTyp`, `Rate`, `NetAmt`, `ConWt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_ORD_REC

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_ORD_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `DELETE_DATA`, `MAIN_STOCK`, `MENU_DATA`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `REMARK_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 11 inputs; 75 named columns; 20 distinct validation-message candidates; 4 confirmation candidates; 9 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tEmpCode` (TextBox, line 123), `_tVchDesc` (TextBox, line 128), `_tItRemark` (TextBox, line 133), `_TEXT_ENTRY_2` (TextBox, line 143), `_tBillNo` (TextBox, line 148), `_tKrCode` (TextBox, line 173), `_TEXT_OLD` (TextBox, line 183).

**MSG** — 31 named / 67 declared columns: `Sr`, `OrdNo`, `OrdSr`, `LotNo`, `ItCode`, `Design`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `DmGhtTch`, `DmGht`, `TotGht`, `Chole`, `Ghis`, `LbrRat`, `LbrAmt`, `OthAmt`, `NetAmt`, `IsuRec`, `OrdParty`, `OrdYr`, `OrdBk`, `OrdAc`, `IsPcs`, `IsGwt`, `IsNwt`, `DifP`, `DifWt`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 28 named / 28 declared columns: `Sr`, `ItCode`, `ItName`, `DmSize`, `PcsWt`, `Pcs`, `Weight`, `Con%`, `BrkPcs`, `BrkWt`, `PcsGht`, `TotGht`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `OldItm`, `OrdPcs`, `OrdWt`, `ConWt`, `ItType`, `RowSrNo`, `RtnPcs`, `RtnWt`, `oldGwt`, `AddWt`.

**MSG_OLD** — 14 named / 14 declared columns: `Sr`, `RtnIt`, `Rtn Item`, `Pcs`, `GrWt`, `NetWt`, `Touch`, `Fine`, `OthWt`, `RTyp`, `Rate`, `NetAmt`, `ConWt`, `EntryMode`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MFG_WITH_LOT

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/mfg-receive/page.tsx](<../web/apps/web/app/(app)/txn/mfg-receive/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/mfg.ts](<../web/apps/api/src/modules/manufacturing/mfg.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `MAIN_STOCK`, `MENU_DATA`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `MFG_ISU_REC`, `REMARK_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 50 named columns; 17 distinct validation-message candidates; 3 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tEmpCode` (TextBox, line 128), `_tVchDesc` (TextBox, line 133), `_tItRemark` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 148), `_tBillNo` (TextBox, line 153).

**MSG** — 25 named / 60 declared columns: `Sr`, `TagLot`, `ItmLot`, `ItCode`, `ItName`, `ItmTag`, `Design`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Chole`, `Ghis`, `LbrRate`, `LbrAmt`, `NetAmt`, `IsPcs`, `IsGwt`, `IsOWt`, `IsNwt`, `DifP`, `DifWt`, `LotItCod`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 23 named / 23 declared columns: `Sr`, `ItmLot`, `ItCode`, `ItName`, `IsuPcs`, `IsuWt`, `Pcs`, `Weight`, `Con%`, `RtnPcs`, `RtnWt`, `BrkPcs`, `BrkWt`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `OldItm`, `ConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_MLT_PRO

Track **P08**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_MLT_PRO.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/melting/page.tsx](<../web/apps/web/app/(app)/txn/melting/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/manufacturing/melting.ts](<../web/apps/api/src/modules/manufacturing/melting.ts>); [web/apps/api/src/modules/manufacturing/meltingParity.ts](<../web/apps/api/src/modules/manufacturing/meltingParity.ts>); [web/apps/api/src/modules/manufacturing/meltingPro.ts](<../web/apps/api/src/modules/manufacturing/meltingPro.ts>)

Retained write-table candidates: `DELETE_DATA`, `MAIN_STOCK`, `MFG_DETL`, `MFG_ISU_REC`, `MLT_DATA`, `MLT_DETL`, `REMARK_DATA`, `SL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 9 inputs; 28 named columns; 16 distinct validation-message candidates; 2 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_TEXT_ENTRY` (TextBox, line 81), `_TEXT_IDTL` (TextBox, line 91), `_tEmpCode` (TextBox, line 111), `_tAcCode` (TextBox, line 116), `_tVchDesc` (TextBox, line 121), `_cboItemTyp` (ComboBox, line 126), `_tLotGen` (TextBox, line 131).

**MSG** — 9 named / 13 declared columns: `Sr`, `ItCode`, `It Name`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `Fine`.

**MSG_BILL_TOT** — 1 named / None declared columns: `Total :`.

**MSG_IDTL** — 17 named / 25 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `Touch`, `Fine`, `Con%`, `Alloy`, `LesIt`, `Fine%`, `AddFine`, `MltWt`, `RtnWt`, `RtnIt`, `RecGwt`, `LossWt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_OTH_COMM

Track **P04**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_OTH_COMM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/other-commission/page.tsx](<../web/apps/web/app/(app)/txn/other-commission/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/purchase/otherCommission.ts](<../web/apps/api/src/modules/purchase/otherCommission.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `PAY_DATA`, `PAY_DETL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 21 named columns; 13 distinct validation-message candidates; 2 confirmation candidates; 4 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_tAcCode` (TextBox, line 100), `_tEmpCode` (TextBox, line 105), `_tVchDesc` (TextBox, line 110), `_TEXT_ENTRY_2` (TextBox, line 125), `_TEXT_ENTRY` (TextBox, line 130), `_tBankName` (TextBox, line 135), `_tBillNo` (TextBox, line 140), `_mbillDate` (MaskedTextBox, line 145).

**MSG** — 19 named / 20 declared columns: `Sr`, `Code`, `ItDesc`, `Remark`, `SaleAmt`, `Com%`, `TaxableAmt`, `TaxCode`, `Tax%`, `IGSTamt`, `CGSTamt`, `SGSTamt`, `TotalAmt`, `AvgRate`, `AvgAmt`, `ConRate`, `ConIt`, `Con%`, `TaxType`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_OTH_PURC

Track **P04**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_OTH_PURC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/other-purchase/page.tsx](<../web/apps/web/app/(app)/txn/other-purchase/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/purchase/purchase.ts](<../web/apps/api/src/modules/purchase/purchase.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `PAY_DATA`, `PAY_DETL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 11 inputs; 21 named columns; 14 distinct validation-message candidates; 3 confirmation candidates; 4 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_tAcCode` (TextBox, line 100), `_tEmpCode` (TextBox, line 105), `_tVchDesc` (TextBox, line 110), `_TEXT_ENTRY_2` (TextBox, line 125), `_TEXT_ENTRY` (TextBox, line 130), `_tBankName` (TextBox, line 135), `_tBillNo` (TextBox, line 140), `_tledrAc` (TextBox, line 145), `_mbillDate` (MaskedTextBox, line 150).

**MSG** — 19 named / 20 declared columns: `Sr`, `HsnCode`, `ItName`, `TaxCode`, `Tax%`, `NetAmt`, `Disc%`, `DiscAmt`, `TaxType`, `TaxableAmt`, `IGSTamt`, `CGSTamt`, `SGSTamt`, `TotalAmt`, `IgstPrc`, `CgstPrc`, `SgstPrc`, `ConIt`, `Con%`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_PHYSTK

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_PHYSTK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/physical-stock/page.tsx](<../web/apps/web/app/(app)/txn/physical-stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/physicalStock.ts](<../web/apps/api/src/modules/stock/physicalStock.ts>); [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>)

Retained write-table candidates: `APR_DETL`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_DETL`, `BAR_IDTL`, `DM_DATA`, `MAIN_STOCK`, `REMARK_DATA`, `TAG_PRINT_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 5 inputs; 27 named columns; 20 distinct validation-message candidates; 3 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_tEmpCode` (TextBox, line 104), `_tVchDesc` (TextBox, line 139).

**MSG** — 26 named / 32 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Design`, `Color`, `Purity`, `Size`, `Cf.No`, `Cntr`, `FCounter`, `ToCode`, `ToCounter`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Fine`, `LbrAmt`, `OthAmt`, `TagCost`, `Mrp`, `Mar%`, `NwMrp`, `Remark`, `KrName`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_PR_SL_HEDG

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_PR_SL_HEDG.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/rate-cut/page.tsx](<../web/apps/web/app/(app)/txn/rate-cut/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/bullion/fineSalePurchase.ts](<../web/apps/api/src/modules/bullion/fineSalePurchase.ts>); [web/apps/api/src/modules/sales/rateCut.ts](<../web/apps/api/src/modules/sales/rateCut.ts>)

Retained write-table candidates: `AC_DATA`, `CUT_DATA`, `CUT_DETL`, `CUT_STK_DETL`, `MAIN_STOCK`, `PR_DETL`, `RATE_CUT_ISU`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 9 inputs; 9 named columns; 12 distinct validation-message candidates; 2 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_TEXT_ENTRY` (TextBox, line 81), `_tEmpCode` (TextBox, line 101), `_tAcCode` (TextBox, line 106), `_cboItemTyp` (ComboBox, line 111), `_TEXT_ENTRY_2` (TextBox, line 121), `_cboFixingType` (ComboBox, line 126), `_tVchDesc` (TextBox, line 131).

**MSG** — 7 named / 10 declared columns: `Sr`, `Fine`, `Rate1Gm`, `Amount`, `NetAmt`, `ConRate`, `Con%`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_PR_SL_UAE

Track **P00 / P13**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_PR_SL_UAE.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `LOT_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `TAG_SET`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 26 inputs; 69 named columns; 22 distinct validation-message candidates; 6 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 41), `_tVchNo` (TextBox, line 46), `_tAcCode` (TextBox, line 96), `_tAcName` (TextBox, line 101), `_tEmpCode` (TextBox, line 106), `_tVchDesc` (TextBox, line 111), `_TEXT_ENTRY_2` (TextBox, line 126), `_TEXT_PR` (TextBox, line 131), `_tBankName` (TextBox, line 136), `_tBillNo` (TextBox, line 141), `_tMobile` (TextBox, line 146), `_tCity` (TextBox, line 151), `_tAdd3` (TextBox, line 156), `_tAdd2` (TextBox, line 161), `_tAdd1` (TextBox, line 166), `_cboItemTyp` (ComboBox, line 171), `_nPartyFine` (TextBox, line 176), `_TEXT_PR_IDTL` (TextBox, line 186), `_chkBillImage` (CheckBox, line 211), `_cboRateFixType` (ComboBox, line 216), `_nOzRate` (TextBox, line 241), `_nOzConv` (TextBox, line 246), `_nFxRate` (TextBox, line 251), `_tFxCode` (TextBox, line 256), `_nMtlRate` (TextBox, line 261), `_tConsiNo` (TextBox, line 271).

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_PR** — 46 named / 82 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Counter`, `Design`, `LotNo`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `McxRate`, `Premium`, `PrmDisc`, `RatWith`, `Rate`, `ItAmt`, `ItDscont`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `TotAmt`, `TaxPrc`, `NetAmt`, `ConNo`, `ConYear`, `ConBk`, `ConSr`, `Size`, `BagWt`, `PsWt`, `SlvFine`, `ConRate`, `Con%`, `HmAmt`, `HmFine`.

**MSG_PR_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `PcsWt`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `PRate`, `PAmt`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `ItType`, `RowSrNo`, `KrConWt`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_IDTL_EnterCell`, `MSG_PR_IDTL_LeaveCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_PURC

Track **P04**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_PURC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/purchase-return/page.tsx](<../web/apps/web/app/(app)/txn/purchase-return/page.tsx>); [web/apps/web/app/(app)/txn/purchase/page.tsx](<../web/apps/web/app/(app)/txn/purchase/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/purchase/purchase.ts](<../web/apps/api/src/modules/purchase/purchase.ts>); [web/apps/api/src/modules/purchase/purchaseBill.ts](<../web/apps/api/src/modules/purchase/purchaseBill.ts>); [web/apps/api/src/modules/purchase/purchaseReturn.ts](<../web/apps/api/src/modules/purchase/purchaseReturn.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `ITM_LOT_DETL`, `LOT_DETL`, `MAIN_STOCK`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_ORD_DETL`, `SL_PR_DETL`, `SRNO_MAST`, `TAG_IMAGE_DATA`, `TAG_SET`, `TAX_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `USER_DATA`.

Source extraction: 30 inputs; 153 named columns; 35 distinct validation-message candidates; 6 confirmation candidates; 12 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 124), `_tAcName` (TextBox, line 129), `_tEmpCode` (TextBox, line 134), `_tVchDesc` (TextBox, line 139), `_TEXT_ENTRY_2` (TextBox, line 154), `_TEXT_PR` (TextBox, line 159), `_tBankName` (TextBox, line 164), `_tBillNo` (TextBox, line 169), `_tMobile` (TextBox, line 174), `_tCity` (TextBox, line 179), `_tAdd3` (TextBox, line 184), `_tAdd2` (TextBox, line 189), `_tAdd1` (TextBox, line 194), `_tSlBill` (TextBox, line 214), `_cboItemTyp` (ComboBox, line 219), `_nPartyFine` (TextBox, line 224), `_TEXT_PR_IDTL` (TextBox, line 234), `_nHmWt` (TextBox, line 239), `_nHmWt4` (TextBox, line 244), `_tHmId4` (TextBox, line 249), `_nHmWt3` (TextBox, line 254), `_tHmId3` (TextBox, line 259), `_nHmWt2` (TextBox, line 264), `_tHmId2` (TextBox, line 269), `_chkBillImage` (CheckBox, line 294), `_nCrDays` (TextBox, line 299).

**MSG** — 45 named / 88 declared columns: `Sr`, `OrdNo`, `ItCode`, `TagNo`, `Counter`, `Design`, `Style`, `Size`, `HuId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `LCode`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `ItRate`, `ItAmt`, `TagCost`, `Margin`, `Mrp`, `Image`, `Remark`, `EmpCod`, `KrCod`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 34 named / 34 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `MotiPs`, `MotiWt`, `Pcs`, `PcsWt`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `KrCon%`, `KrP/W`, `PRate`, `PAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldKrWt`, `OldGrWt`.

**MSG_PR** — 46 named / 70 declared columns: `Sr`, `ItCode`, `ItName`, `Counter`, `Design`, `LotNo`, `ItmLot`, `WthStk`, `BagWt`, `Pcs`, `BagTot`, `PsWt`, `GrWt`, `OthWt`, `LossWt`, `Kundan`, `KunTch`, `KunFine`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `LesTch%`, `Fine`, `NetFine`, `SlvFine`, `ConRate`, `Con%`, `Rate`, `RTyp`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `TotAmt`, `Com%`, `ComAmt`, `TaxPrc`, `NetAmt`, `HmFine`.

**MSG_PR_IDTL** — 25 named / 25 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `DmRemark`, `DmSfNo`, `MotiPs`, `MotiWt`, `Pcs`, `PcsWt`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `ItType`, `RowSrNo`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_IDTL_EnterCell`, `MSG_PR_IDTL_LeaveCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_PURC_HM

Track **P04**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_PURC_HM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/purchase-hm/page.tsx](<../web/apps/web/app/(app)/txn/purchase-hm/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/purchase/purchase.ts](<../web/apps/api/src/modules/purchase/purchase.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `LOT_DETL`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SRNO_MAST`, `TAG_SET`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 21 inputs; 89 named columns; 20 distinct validation-message candidates; 5 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 42), `_tVchNo` (TextBox, line 47), `_tAcCode` (TextBox, line 97), `_tAcName` (TextBox, line 102), `_tEmpCode` (TextBox, line 107), `_tVchDesc` (TextBox, line 112), `_TEXT_ENTRY_2` (TextBox, line 127), `_TEXT_PR` (TextBox, line 132), `_tBankName` (TextBox, line 137), `_tBillNo` (TextBox, line 142), `_tMobile` (TextBox, line 147), `_tCity` (TextBox, line 152), `_tAdd3` (TextBox, line 157), `_tAdd2` (TextBox, line 162), `_tAdd1` (TextBox, line 167), `_cboItemTyp` (ComboBox, line 172), `_nPartyFine` (TextBox, line 177), `_TEXT_PR_IDTL` (TextBox, line 187), `_chkBillImage` (CheckBox, line 212), `_chkRateUnFix` (CheckBox, line 217), `_nCrDays` (TextBox, line 222).

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_PR** — 64 named / 95 declared columns: `Sr`, `ItCode`, `ItName`, `TagNo`, `Counter`, `Design`, `LotNo`, `Color`, `Size`, `BagWt`, `Pcs`, `PsWt`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `SlvFine`, `ConRate`, `Con%`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `PrCost`, `Mrp`, `TotAmt`, `TaxPrc`, `NetAmt`, `HmAmt`, `TOthWt`, `TgNwt`, `LCode`, `TgTch`, `TgW%`, `TgFine`, `TagRate`, `TagItAmt`, `TgLbr%`, `TgLRat`, `TgLAmt`, `TgOth`, `TagCost`, `Margin%`, `TgMrp`, `HmId`, `KrName`, `HmWt`, `HmId2`, `HmWt2`, `HmId3`, `HmWt3`, `HmId4`, `HmWt4`, `HmFine`, `PrCode`.

**MSG_PR_IDTL** — 23 named / 23 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `PcsWt`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `PRate`, `PAmt`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `ItType`, `RowSrNo`, `KrConWt`, `2RowVal`, `2RowText`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_IDTL_EnterCell`, `MSG_PR_IDTL_LeaveCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_REP_REC

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_REP_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/repair-customer-issue/page.tsx](<../web/apps/web/app/(app)/txn/repair-customer-issue/page.tsx>); [web/apps/web/app/(app)/txn/repair-karigar-issue/page.tsx](<../web/apps/web/app/(app)/txn/repair-karigar-issue/page.tsx>); [web/apps/web/app/(app)/txn/repair-karigar-receipt/page.tsx](<../web/apps/web/app/(app)/txn/repair-karigar-receipt/page.tsx>); [web/apps/web/app/(app)/txn/repair-receipt/page.tsx](<../web/apps/web/app/(app)/txn/repair-receipt/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/repair/repairImage.ts](<../web/apps/api/src/modules/repair/repairImage.ts>); [web/apps/api/src/modules/repair/repairReceipt.ts](<../web/apps/api/src/modules/repair/repairReceipt.ts>)

Retained write-table candidates: `AC_DATA`, `REMARK_DATA`, `REP_DATA`, `REP_DETL`, `ROJ_MEL_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 15 inputs; 28 named columns; 18 distinct validation-message candidates; 4 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_tAcCode` (TextBox, line 100), `_tAcName` (TextBox, line 105), `_tEmpCode` (TextBox, line 110), `_TEXT_ENTRY_2` (TextBox, line 125), `_TEXT_ENTRY` (TextBox, line 130), `_tBankName` (TextBox, line 135), `_tBillNo` (TextBox, line 140), `_tMobile` (TextBox, line 145), `_tCity` (TextBox, line 150), `_tAdd3` (TextBox, line 155), `_tAdd2` (TextBox, line 160), `_tAdd1` (TextBox, line 165), `_tVchDesc` (TextBox, line 185).

**MSG** — 26 named / 53 declared columns: `Sr`, `IsuNo`, `RepNo`, `TagNo`, `ItCode`, `ItName`, `Size`, `Reparing Desc`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `LessWt`, `LesTch`, `LsFine`, `AddWt`, `Touch`, `West%`, `Fine`, `Rate`, `ItAmt`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `NetAmt`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SALE

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SALE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/sales/page.tsx](<../web/apps/web/app/(app)/txn/sales/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/invoice.ts](<../web/apps/api/src/modules/sales/invoice.ts>); [web/apps/api/src/modules/sales/sales.ts](<../web/apps/api/src/modules/sales/sales.ts>)

Retained write-table candidates: `AC_DATA`, `AC_MAST`, `AD_ADJ`, `APR_DETL`, `BAR_DETL`, `BILL_OS_DATA`, `CARD_DATA`, `COMM_DATA`, `CRNT_DATA`, `DELETE_DATA`, `DM_DATA`, `LOT_DETL`, `MAIN_STOCK`, `POINT_DATA`, `POINT_MEMB`, `PRINT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DETL`, `SL_PR_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`, `UPI_DATA`, `USER_DATA`.

Source extraction: 31 inputs; 109 named columns; 35 distinct validation-message candidates; 5 confirmation candidates; 15 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 45), `_tVchNo` (TextBox, line 50), `_TEXT_ENTRY` (TextBox, line 85), `_TEXT_IDTL` (TextBox, line 100), `_tAcCode` (TextBox, line 125), `_tAcName` (TextBox, line 130), `_tEmpCode` (TextBox, line 135), `_tVchDesc` (TextBox, line 140), `_tItDesc` (TextBox, line 145), `_TEXT_ENTRY_2` (TextBox, line 160), `_TEXT_OLD` (TextBox, line 165), `_tBankName` (TextBox, line 170), `_tBillNo` (TextBox, line 175), `_tMobile` (TextBox, line 180), `_tCity` (TextBox, line 185), `_tAdd3` (TextBox, line 190), `_tAdd2` (TextBox, line 195), `_tAdd1` (TextBox, line 200), `_TEXT_ORD` (TextBox, line 210), `_tIsuNo` (TextBox, line 220), `_nCrDays` (TextBox, line 225), `_tPanNo` (TextBox, line 230), `_tNewPrint` (TextBox, line 240), `_tTrfrNo` (TextBox, line 255), `_nUsePoint` (TextBox, line 265), `_tRefAc` (TextBox, line 270), `_chkPointMemb` (CheckBox, line 275), `_TEXT_UPI` (TextBox, line 285), `_chkRateUnFix` (CheckBox, line 295), `_TEXT_CRNT` (TextBox, line 300), `_tAcMembCode` (TextBox, line 310).

**MSG** — 57 named / 108 declared columns: `Sr`, `TagNo`, `ItmLot`, `ItCode`, `Counter`, `OrdNo`, `Design`, `Style`, `Size`, `HuId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `FixGht%`, `GhtWt`, `Touch`, `West%`, `Fine`, `RtWith`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `GhtAmt`, `OthAmt`, `Mrp`, `LDisc%`, `LDiscAmt`, `NtLbrAmt`, `EmpCod`, `TotAmt`, `Tax%`, `NetAmt`, `PrCost`, `MCom%`, `MComWt`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `TagId`, `TagCost`, `Margin`, `Image`, `GrTch%`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_CRNT** — 3 named / 9 declared columns: `Sr`, `Crnt No`, `Crnt Amt`.

**MSG_IDTL** — 24 named / 24 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_OLD** — 14 named / 18 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Touch`, `Fine`, `Con%`, `ConWt`, `Rate`, `RTyp`, `NetAmt`.

**MSG_ORD** — 3 named / 9 declared columns: `Sr`, `Ord No`, `Ord Amt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

**MSG_UPI** — 6 named / 6 declared columns: `Sr.`, `AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`, `UpiAmt`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_CRNT_EnterCell`, `MSG_CRNT_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_ORD_EnterCell`, `MSG_ORD_LeaveCell`, `MSG_RowColChange`, `MSG_UPI_EnterCell`, `MSG_UPI_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SALE_HM

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SALE_HM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/hallmark-sale/page.tsx](<../web/apps/web/app/(app)/txn/hallmark-sale/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/sales.ts](<../web/apps/api/src/modules/sales/sales.ts>)

Retained write-table candidates: `AC_DATA`, `AC_MAST`, `APR_DETL`, `BAR_DETL`, `BILL_OS_DATA`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `PRINT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DETL`, `SL_PR_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`, `UPI_DATA`.

Source extraction: 25 inputs; 95 named columns; 25 distinct validation-message candidates; 4 confirmation candidates; 13 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 45), `_tVchNo` (TextBox, line 50), `_TEXT_ENTRY` (TextBox, line 85), `_TEXT_IDTL` (TextBox, line 100), `_tAcCode` (TextBox, line 125), `_tAcName` (TextBox, line 130), `_tEmpCode` (TextBox, line 135), `_tVchDesc` (TextBox, line 140), `_tItDesc` (TextBox, line 145), `_TEXT_ENTRY_2` (TextBox, line 160), `_TEXT_OLD` (TextBox, line 165), `_tBankName` (TextBox, line 170), `_tBillNo` (TextBox, line 175), `_tMobile` (TextBox, line 180), `_tCity` (TextBox, line 185), `_tAdd3` (TextBox, line 190), `_tAdd2` (TextBox, line 195), `_tAdd1` (TextBox, line 200), `_TEXT_ORD` (TextBox, line 210), `_tIsuNo` (TextBox, line 220), `_nCrDays` (TextBox, line 225), `_tPanNo` (TextBox, line 230), `_tNewPrint` (TextBox, line 240), `_tTrfrNo` (TextBox, line 255), `_TEXT_UPI` (TextBox, line 265).

**MSG** — 48 named / 92 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `OrdNo`, `Design`, `Size`, `HuId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `GhtAmt`, `OthAmt`, `Mrp`, `LDisc%`, `LDiscAmt`, `TotAmt`, `Tax%`, `NetAmt`, `HmAmt`, `PrCost`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 25 named / 25 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldKrWt`.

**MSG_OLD** — 11 named / 14 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Touch`, `Fine`, `Rate`, `NetAmt`.

**MSG_ORD** — 3 named / 8 declared columns: `Sr`, `Ord No`, `Ord Amt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

**MSG_UPI** — 6 named / 6 declared columns: `Sr.`, `AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`, `UpiAmt`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_ORD_EnterCell`, `MSG_ORD_LeaveCell`, `MSG_RowColChange`, `MSG_UPI_EnterCell`, `MSG_UPI_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SALE_LBR

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SALE_LBR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/labour-sale/page.tsx](<../web/apps/web/app/(app)/txn/labour-sale/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/labourInvoice.ts](<../web/apps/api/src/modules/sales/labourInvoice.ts>)

Retained write-table candidates: `AC_DATA`, `BILL_OS_DATA`, `CARD_DATA`, `DELETE_DATA`, `DM_DATA`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `MAIN_STOCK`, `RATE_CUT_ISU_REC`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_DETL`, `SL_ORD_ADJ`, `SL_ORD_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `UPI_DATA`, `USER_DATA`.

Source extraction: 21 inputs; 100 named columns; 19 distinct validation-message candidates; 3 confirmation candidates; 13 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tAcName` (TextBox, line 128), `_tEmpCode` (TextBox, line 133), `_tVchDesc` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 153), `_TEXT_PR` (TextBox, line 158), `_nCrAmt` (TextBox, line 163), `_nCrFine` (TextBox, line 168), `_nDrAmt` (TextBox, line 173), `_nDrFine` (TextBox, line 178), `_nDrRate` (TextBox, line 183), `_nCrDays` (TextBox, line 188), `_cboItemTyp` (ComboBox, line 193), `_TEXT_ORD` (TextBox, line 203), `_TEXT_UPI` (TextBox, line 213), `_nConvRate` (TextBox, line 218), `_nConvPrc` (TextBox, line 223).

**MSG** — 30 named / 60 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Design`, `HuId`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `NetAmt`, `Counter`, `KrCode`, `Mrp`, `KrOthWt`, `KrNwt`, `KrTouch`, `KrWst%`, `KrFine`, `TagCost`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_IDTL** — 24 named / 24 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `MotiPs`, `MotiWt`, `Pcs`, `PcsWt`, `KrWt`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_ORD** — 4 named / 9 declared columns: `Sr`, `Ord No`, `Ord Weight`, `Ord Amt`.

**MSG_PR** — 32 named / 39 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `NetWt`, `Touch`, `LTouch`, `Fine`, `GhtWt`, `Counter`, `Design`, `BagWt`, `PsWt`, `OthWt`, `West%`, `HmFine`, `SlvFine`, `Sign`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `NetAmt`, `TotAmt`, `TaxPrc`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

**MSG_UPI** — 6 named / 6 declared columns: `Sr.`, `AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`, `UpiAmt`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_ORD_EnterCell`, `MSG_ORD_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_RowColChange`, `MSG_UPI_EnterCell`, `MSG_UPI_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SALE_ORD

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SALE_ORD.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/order-cancel/page.tsx](<../web/apps/web/app/(app)/txn/order-cancel/page.tsx>); [web/apps/web/app/(app)/txn/sales-order/page.tsx](<../web/apps/web/app/(app)/txn/sales-order/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/salesOrder.ts](<../web/apps/api/src/modules/sales/salesOrder.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DETL`, `DELETE_DATA`, `MAIN_STOCK`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `TAG_IMAGE_DATA`, `TEMP_BOOK_DATA`, `UPI_DATA`, `USER_DATA`.

Source extraction: 21 inputs; 91 named columns; 30 distinct validation-message candidates; 6 confirmation candidates; 11 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 124), `_tAcName` (TextBox, line 129), `_tEmpCode` (TextBox, line 134), `_tVchDesc` (TextBox, line 139), `_tItRemark` (TextBox, line 149), `_TEXT_ENTRY_2` (TextBox, line 164), `_TEXT_OLD` (TextBox, line 169), `_mDelDate` (MaskedTextBox, line 174), `_tBankName` (TextBox, line 179), `_tBillNo` (TextBox, line 199), `_tMobile` (TextBox, line 204), `_tCity` (TextBox, line 209), `_tAdd3` (TextBox, line 214), `_tAdd2` (TextBox, line 219), `_tAdd1` (TextBox, line 224), `_mFunDate` (MaskedTextBox, line 229), `_TEXT_UPI` (TextBox, line 239).

**MSG** — 45 named / 87 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Color`, `Size`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `RtFix`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `DelDate`, `TotAmt`, `Tax%`, `NetAmt`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_OLD** — 17 named / 17 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `Fine`, `RTyp`, `Rate`, `NetAmt`, `ConWt`, `OldRate`, `OldNetAmt`, `OldFine`, `OldNwt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

**MSG_UPI** — 6 named / 6 declared columns: `Sr.`, `AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`, `UpiAmt`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_RowColChange`, `MSG_UPI_EnterCell`, `MSG_UPI_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SALE_RTN

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SALE_RTN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/sale-return/page.tsx](<../web/apps/web/app/(app)/txn/sale-return/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/salesReturn.ts](<../web/apps/api/src/modules/sales/salesReturn.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `RATE_CUT_ISU_REC`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SRNO_MAST`, `TAG_SET`, `TAX_DATA`, `TEMP_BOOK_DATA`, `USER_DATA`.

Source extraction: 12 inputs; 125 named columns; 23 distinct validation-message candidates; 4 confirmation candidates; 12 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tAcName` (TextBox, line 128), `_tEmpCode` (TextBox, line 133), `_tVchDesc` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 153), `_TEXT_PR` (TextBox, line 158), `_TEXT_RTN_IDTL` (TextBox, line 168), `_tIsuNo` (TextBox, line 178).

**MSG** — 33 named / 48 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Design`, `Size`, `HmId`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `NetAmt`, `Counter`, `KrCode`, `KrOthWt`, `KrNwt`, `KrTouch`, `KrWst%`, `KrFine`, `TagCost`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_IDTL** — 24 named / 24 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `KrWt`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_PR** — 40 named / 71 declared columns: `Sr`, `RecCode`, `TagNo`, `Receive Item`, `Counter`, `Design`, `Style`, `Size`, `HmId`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `LCode`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `LDisc%`, `LDiscAmt`, `OthAmt`, `RtnMrp`, `TgLCode`, `Tag%`, `TagLRate`, `TagLAmt`, `TagOtAmt`, `TagCost`, `TagMrp`, `TotAmt`, `TaxPrc`, `NetAmt`, `KrCode`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_RTN_IDTL** — 24 named / 24 declared columns: `Sr`, `Itm`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `KrWt`, `Gwt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`, `MSG_RTN_IDTL_EnterCell`, `MSG_RTN_IDTL_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SALE_RTN_UAE

Track **P00 / P13**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SALE_RTN_UAE.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `PRINT_MAST`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_ORD_ADJ`, `SL_PR_DETL`, `SRNO_MAST`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 20 inputs; 74 named columns; 21 distinct validation-message candidates; 4 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 45), `_tVchNo` (TextBox, line 50), `_TEXT_ENTRY` (TextBox, line 85), `_TEXT_IDTL` (TextBox, line 100), `_tAcCode` (TextBox, line 125), `_tAcName` (TextBox, line 130), `_tEmpCode` (TextBox, line 135), `_tVchDesc` (TextBox, line 140), `_tItDesc` (TextBox, line 145), `_TEXT_ENTRY_2` (TextBox, line 155), `_tBankName` (TextBox, line 160), `_tBillNo` (TextBox, line 165), `_tMobile` (TextBox, line 170), `_tCity` (TextBox, line 175), `_tAdd3` (TextBox, line 180), `_tAdd2` (TextBox, line 185), `_tAdd1` (TextBox, line 190), `_tIsuNo` (TextBox, line 200), `_nCrDays` (TextBox, line 205), `_tNewPrint` (TextBox, line 215).

**MSG** — 48 named / 88 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Size`, `HuId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `RatWith`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `GhtAmt`, `OthAmt`, `Mrp`, `LDisc%`, `LDiscAmt`, `TotAmt`, `Tax%`, `NetAmt`, `HmAmt`, `PrCost`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 24 named / 24 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SL_EBILL

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SL_EBILL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `DM_DATA`, `E_DATA`, `ITEM_MAST`, `MAIN_STOCK`, `REMARK_DATA`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_PR_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 12 inputs; 54 named columns; 25 distinct validation-message candidates; 2 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 48), `_tVchNo` (TextBox, line 53), `_TEXT_ENTRY` (TextBox, line 88), `_TEXT_IDTL` (TextBox, line 103), `_tAcCode` (TextBox, line 128), `_tEmpCode` (TextBox, line 133), `_tVchDesc` (TextBox, line 138), `_tItRemark` (TextBox, line 143), `_TEXT_ENTRY_2` (TextBox, line 153), `_tBillNo` (TextBox, line 158), `_tVchIrnNo` (TextBox, line 163), `_tldrCode` (TextBox, line 198).

**MSG** — 31 named / 82 declared columns: `Sr`, `TagNo`, `ItCode`, `Design`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `Disc%`, `DiscAmt`, `TxblAmt`, `TxblRate`, `TxCode`, `Tax%`, `IGSTamt`, `CGSTamt`, `SGSTamt`, `NetAmt`, `HuId`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SL_ORD_ADJ

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SL_ORD_ADJ.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/order-cancel/page.tsx](<../web/apps/web/app/(app)/txn/order-cancel/page.tsx>); [web/apps/web/app/(app)/txn/sales-order/page.tsx](<../web/apps/web/app/(app)/txn/sales-order/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/salesOrder.ts](<../web/apps/api/src/modules/sales/salesOrder.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `BAR_DETL`, `BAR_IDTL`, `MAIN_STOCK`, `ROJ_MEL_DATA`, `SL_ORD_ADJ`, `SL_ORD_DETL`, `TEMP_BOOK_DATA`.

Source extraction: 5 inputs; 24 named columns; 13 distinct validation-message candidates; 2 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_TEXT_TAG` (TextBox, line 110).

**MSG** — 11 named / 16 declared columns: `Sr`, `OrdNo`, `AcCode`, `Ac Name`, `It Desc`, `OrdAmt`, `AdjAmt`, `KsarAmt`, `PaidAmt`, `PaiidAc`, `Paid Ac Name`.

**MSG_TAG** — 12 named / 17 declared columns: `Sr`, `TagNo`, `OrdNo`, `ItCode`, `ItName`, `Counter`, `Design`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Mrp`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`, `MSG_TAG_EnterCell`, `MSG_TAG_LeaveCell`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_SL_PR_ITEM

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_SL_PR_ITEM.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/rate-cut/page.tsx](<../web/apps/web/app/(app)/txn/rate-cut/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/bullion/fineSalePurchase.ts](<../web/apps/api/src/modules/bullion/fineSalePurchase.ts>); [web/apps/api/src/modules/sales/rateCut.ts](<../web/apps/api/src/modules/sales/rateCut.ts>)

Retained write-table candidates: `AC_DATA`, `CARD_DATA`, `DELETE_DATA`, `DM_DATA`, `E_DATA`, `MAIN_STOCK`, `PRINT_MAST`, `ROJ_MEL_DATA`, `SL_ORD_ADJ`, `SL_PR_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 10 inputs; 58 named columns; 24 distinct validation-message candidates; 4 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 100), `_tVchNo` (TextBox, line 105), `_TEXT_ENTRY` (TextBox, line 140), `_TEXT_IDTL` (TextBox, line 155), `_tAcCode` (TextBox, line 180), `_tEmpCode` (TextBox, line 185), `_tVchDesc` (TextBox, line 190), `_tItRemark` (TextBox, line 195), `_TEXT_ENTRY_2` (TextBox, line 205), `_tBillNo` (TextBox, line 210).

**MSG** — 35 named / 94 declared columns: `Sr`, `TagNo`, `ItCode`, `Design`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `Disc%`, `DiscAmt`, `TxType`, `TxFreeAmt`, `TxblAmt`, `TxCode`, `Tax%`, `TxRvrs`, `TaxAmt`, `NetAmt`, `CGSTamt`, `SGSTamt`, `HuId`, `TxblRate`, `ReversAmt`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TAG_CAN

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TAG_CAN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/tag-cancel/page.tsx](<../web/apps/web/app/(app)/txn/tag-cancel/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/tagOps.ts](<../web/apps/api/src/modules/stock/tagOps.ts>)

Retained write-table candidates: `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DETL`, `DELETE_DATA`, `DM_DATA`, `LOT_DETL`, `MAIN_STOCK`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 63 named columns; 14 distinct validation-message candidates; 2 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 124), `_tEmpCode` (TextBox, line 129), `_tVchDesc` (TextBox, line 134).

**MSG** — 45 named / 66 declared columns: `Sr`, `TagNo`, `TagLot`, `ItmLot`, `ItCode`, `Counter`, `Design`, `Size`, `Sign`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Type`, `TrfrItm`, `TrfrItmName`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `ItRate`, `ItAmt`, `TagCost`, `Margin`, `Image`.

**MSG_IDTL** — 17 named / 17 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `Weight`, `KrWt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TAG_OPBL

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/tag-opening/page.tsx](<../web/apps/web/app/(app)/txn/tag-opening/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>); [web/apps/api/src/modules/stock/stockVoucherLifecycle.ts](<../web/apps/api/src/modules/stock/stockVoucherLifecycle.ts>)

Retained write-table candidates: `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `LOT_DETL`, `MAIN_STOCK`, `MFG_DETL`, `PRINT_MAST`, `SL_ORD_DETL`, `SRNO_MAST`, `TAG_IMAGE_DATA`, `TAG_PRINT_DATA`, `TAG_SET`, `TEMP_BOOK_DATA`.

Source extraction: 18 inputs; 104 named columns; 40 distinct validation-message candidates; 5 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 52), `_tVchNo` (TextBox, line 57), `_TEXT_ENTRY` (TextBox, line 92), `_TEXT_IDTL` (TextBox, line 107), `_nLableSkip` (TextBox, line 157), `_tItCode` (TextBox, line 162), `_tVchDesc` (TextBox, line 167), `_tEmpCode` (TextBox, line 172), `_tHmId2` (TextBox, line 187), `_nHmWt` (TextBox, line 192), `_nHmWt2` (TextBox, line 197), `_nHmWt3` (TextBox, line 202), `_tHmId3` (TextBox, line 207), `_nHmWt4` (TextBox, line 212), `_tHmId4` (TextBox, line 217), `_cboItType` (ComboBox, line 222), `_tLotNo` (TextBox, line 232), `_cboDataType` (ComboBox, line 252).

**MSG** — 62 named / 112 declared columns: `Sr`, `Design`, `MfgOrd`, `ItCode`, `OrdNo`, `TagNo`, `Counter`, `Design`, `Style`, `Color`, `Size`, `HuId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `LCode`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `SlType`, `OthRate`, `OthFine`, `TotFine`, `GwtTouch`, `ItRate`, `ItAmt`, `PrCost`, `TagCost`, `MMargin`, `MainMrp`, `Margin`, `Mrp`, `Image`, `Remark`, `KrCod`, `JdtWt`, `JGhatWt`, `Kundan`, `KndTch%`, `KndNwt`, `Wax`, `KrWax`, `TagId`.

**MSG_IDTL** — 41 named / 41 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `DmRemark`, `DmSfNo`, `MotiPs`, `MotiWt`, `Pcs`, `PcsWt`, `KrAWt`, `KrA%`, `KrWt`, `KrLs%`, `KrLsWt`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `Disc%`, `DiscAmt`, `KrCon%`, `KrP/W`, `PRate`, `PAmt`, `KrLRate`, `KrLAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldKrWt`, `OldGrWt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TAG_SPLIT

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TAG_SPLIT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/tag-split/page.tsx](<../web/apps/web/app/(app)/txn/tag-split/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/tagSplit.ts](<../web/apps/api/src/modules/stock/tagSplit.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `DM_DATA`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `MAIN_STOCK`, `RATE_CUT_ISU_REC`, `ROJ_MEL_DATA`, `SRNO_MAST`, `TAG_IMAGE_DATA`, `TAG_PRINT_DATA`, `TAG_SET`, `TEMP_BOOK_DATA`, `USER_DATA`.

Source extraction: 27 inputs; 184 named columns; 20 distinct validation-message candidates; 3 confirmation candidates; 12 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 45), `_tVchNo` (TextBox, line 50), `_TEXT_ENTRY` (TextBox, line 85), `_TEXT_IDTL` (TextBox, line 100), `_tAcCode` (TextBox, line 125), `_tAcName` (TextBox, line 130), `_tEmpCode` (TextBox, line 135), `_tVchDesc` (TextBox, line 140), `_TEXT_ENTRY_2` (TextBox, line 155), `_TEXT_PR` (TextBox, line 160), `_TEXT_RTN_IDTL` (TextBox, line 170), `_nCrWt` (TextBox, line 175), `_nDrWt` (TextBox, line 180), `_nCrFine` (TextBox, line 185), `_nCrTouch` (TextBox, line 190), `_nCrLbrAmt` (TextBox, line 195), `_nDrTouch` (TextBox, line 200), `_nDrFine` (TextBox, line 205), `_chkSameTag` (CheckBox, line 210), `_cboItemTyp` (ComboBox, line 215), `_nHmWt4` (TextBox, line 220), `_tHmId4` (TextBox, line 225), `_nHmWt3` (TextBox, line 230), `_tHmId3` (TextBox, line 235), `_nHmWt2` (TextBox, line 240), `_nHmWt` (TextBox, line 245), `_tHmId2` (TextBox, line 250).

**MSG** — 59 named / 73 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Color`, `Size`, `HuId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `LCode`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `SlType`, `OthRate`, `OthFine`, `TotFine`, `GwtTouch`, `ItRate`, `ItAmt`, `PrCost`, `TagCost`, `Margin`, `Mrp`, `Image`, `Remark`, `KrCod`, `JdtWt`, `JGhatWt`, `Kundan`, `KndTch%`, `KndNwt`, `Wax`, `KrWax`, `TagId`, `HuId2`, `HuId3`, `HuId4`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_IDTL** — 32 named / 32 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `DmRemark`, `DmSfNo`, `Pcs`, `PcsWt`, `KrAWt`, `KrA%`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `PRate`, `PAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldKrWt`, `OldGrWt`.

**MSG_PR** — 57 named / 91 declared columns: `Sr`, `ItCode`, `TagNo`, `Counter`, `Design`, `Color`, `Size`, `HuId`, `+/-`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `LCode`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `SlType`, `OthRate`, `OthFine`, `TotFine`, `GwtTouch`, `ItRate`, `ItAmt`, `PrCost`, `TagCost`, `Margin`, `Mrp`, `Image`, `Remark`, `KrCod`, `JdtWt`, `JGhatWt`, `Kundan`, `KndTch%`, `KndNwt`, `Wax`, `KrWax`, `TagId`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_RTN_IDTL** — 32 named / 32 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `DmRemark`, `DmSfNo`, `Pcs`, `PcsWt`, `KrAWt`, `KrA%`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `PRate`, `PAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldKrWt`, `OldGrWt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`, `MSG_RTN_IDTL_EnterCell`, `MSG_RTN_IDTL_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TAG_WT_DIFF

Track **P07**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TAG_WT_DIFF.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/tag-weight-diff/page.tsx](<../web/apps/web/app/(app)/txn/tag-weight-diff/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/tagOps.ts](<../web/apps/api/src/modules/stock/tagOps.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DETL`, `BAR_IDTL`, `DM_DATA`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `MAIN_STOCK`, `RATE_CUT_ISU_REC`, `ROJ_MEL_DATA`, `SRNO_MAST`, `TAG_IMAGE_DATA`, `TAG_PRINT_DATA`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 21 inputs; 103 named columns; 18 distinct validation-message candidates; 3 confirmation candidates; 9 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 129), `_tAcName` (TextBox, line 134), `_tEmpCode` (TextBox, line 139), `_tVchDesc` (TextBox, line 144), `_TEXT_ENTRY_2` (TextBox, line 159), `_TEXT_PR` (TextBox, line 164), `_nCrAmt` (TextBox, line 169), `_nCrFine` (TextBox, line 174), `_nDrAmt` (TextBox, line 179), `_nDrFine` (TextBox, line 184), `_nDrTouch` (TextBox, line 189), `_nCrTouch` (TextBox, line 194), `_nCrRate` (TextBox, line 199), `_nDrRate` (TextBox, line 204), `_nCrDays` (TextBox, line 209), `_cboItemTyp` (ComboBox, line 214), `_nCrLbrAmt` (TextBox, line 219).

**MSG** — 42 named / 60 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Design`, `Size`, `OPcs`, `OGrWt`, `OthWt`, `ONetWt`, `NwPcs`, `NwGwt`, `NOthWt`, `NwNet`, `Diff GWt`, `Diff NWt`, `LCode`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `NewMrp`, `Ght%`, `GhtWt`, `Touch`, `West%`, `NwFine`, `KrCode`, `NewTagId`, `Counter`, `OldTagId`, `KrOthWt`, `KrNwt`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_IDTL** — 25 named / 25 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_PR** — 32 named / 39 declared columns: `Sr`, `ItCode`, `ItName`, `Counter`, `Design`, `BagWt`, `Pcs`, `PsWt`, `GrWt`, `OthWt`, `NetWt`, `GhtWt`, `Touch`, `West%`, `LTouch`, `Fine`, `HmFine`, `SlvFine`, `Sign`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `NetAmt`, `TotAmt`, `TaxPrc`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TOUR

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TOUR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/tour/page.tsx](<../web/apps/web/app/(app)/txn/tour/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/tour/tour.ts](<../web/apps/api/src/modules/tour/tour.ts>)

Retained write-table candidates: `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAR_DETL`, `DELETE_DATA`, `MAIN_STOCK`, `TEMP_BOOK_DATA`.

Source extraction: 7 inputs; 55 named columns; 17 distinct validation-message candidates; 3 confirmation candidates; 5 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tEmpCode` (TextBox, line 123), `_tVchDesc` (TextBox, line 128), `_tIsuNo` (TextBox, line 138).

**MSG** — 33 named / 73 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Size`, `HmId`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `NetAmt`, `KrCode`, `ItRec`, `IsuNo`, `Year`, `Book`, `SrNo`, `Image`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `KrWt`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TOUR_ORD

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TOUR_ORD.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/sales-order/page.tsx](<../web/apps/web/app/(app)/txn/sales-order/page.tsx>); [web/apps/web/app/(app)/txn/tour-return/page.tsx](<../web/apps/web/app/(app)/txn/tour-return/page.tsx>); [web/apps/web/app/(app)/txn/tour/page.tsx](<../web/apps/web/app/(app)/txn/tour/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/salesOrder.ts](<../web/apps/api/src/modules/sales/salesOrder.ts>); [web/apps/api/src/modules/tour/tour.ts](<../web/apps/api/src/modules/tour/tour.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DETL`, `DELETE_DATA`, `MAIN_STOCK`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `ROJ_MEL_DATA`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `TEMP_BOOK_DATA`, `USER_DATA`.

Source extraction: 19 inputs; 81 named columns; 25 distinct validation-message candidates; 5 confirmation candidates; 9 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 44), `_tVchNo` (TextBox, line 49), `_TEXT_ENTRY` (TextBox, line 84), `_TEXT_IDTL` (TextBox, line 99), `_tAcCode` (TextBox, line 119), `_tAcName` (TextBox, line 124), `_tEmpCode` (TextBox, line 129), `_tVchDesc` (TextBox, line 134), `_tItRemark` (TextBox, line 144), `_TEXT_ENTRY_2` (TextBox, line 159), `_TEXT_OLD` (TextBox, line 164), `_mDelDate` (MaskedTextBox, line 169), `_tBankName` (TextBox, line 174), `_tBillNo` (TextBox, line 194), `_tMobile` (TextBox, line 199), `_tCity` (TextBox, line 204), `_tAdd3` (TextBox, line 209), `_tAdd2` (TextBox, line 214), `_tAdd1` (TextBox, line 219).

**MSG** — 45 named / 74 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Color`, `Size`, `BagWt`, `Qty`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `RtFix`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `TotAmt`, `Tax%`, `NetAmt`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_OLD** — 13 named / 13 declared columns: `Sr`, `ItCode`, `ItName`, `Pcs`, `GrWt`, `OthWt`, `NetWt`, `Touch`, `Fine`, `RTyp`, `Rate`, `NetAmt`, `ConWt`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_OLD_EnterCell`, `MSG_OLD_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_TOUR_SALE

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_TOUR_SALE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/sales-order/page.tsx](<../web/apps/web/app/(app)/txn/sales-order/page.tsx>); [web/apps/web/app/(app)/txn/tour-return/page.tsx](<../web/apps/web/app/(app)/txn/tour-return/page.tsx>); [web/apps/web/app/(app)/txn/tour/page.tsx](<../web/apps/web/app/(app)/txn/tour/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/salesOrder.ts](<../web/apps/api/src/modules/sales/salesOrder.ts>); [web/apps/api/src/modules/tour/tour.ts](<../web/apps/api/src/modules/tour/tour.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `BAR_DETL`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `ROJ_MEL_DATA`, `SL_IDTL`, `SL_ORD_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `USER_DATA`.

Source extraction: 34 inputs; 122 named columns; 26 distinct validation-message candidates; 4 confirmation candidates; 10 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tAcName` (TextBox, line 128), `_tEmpCode` (TextBox, line 133), `_tVchDesc` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 153), `_TEXT_PR` (TextBox, line 158), `_tBillNo` (TextBox, line 163), `_tMobile` (TextBox, line 168), `_tCity` (TextBox, line 173), `_tAdd3` (TextBox, line 178), `_tAdd2` (TextBox, line 183), `_tAdd1` (TextBox, line 188), `_nAcDrAmt` (TextBox, line 193), `_nAcCrFine` (TextBox, line 198), `_nAcCrAmt` (TextBox, line 203), `_nAcDrFine` (TextBox, line 208), `_nFineKsrDr` (TextBox, line 213), `_nFineKsrCr` (TextBox, line 218), `_nFineRate` (TextBox, line 223), `_nCrDays` (TextBox, line 228), `_cboItemTyp` (ComboBox, line 233), `_nConvPrc` (TextBox, line 238), `_nConvRate` (TextBox, line 243), `_chkSilverCut` (CheckBox, line 248), `_nSlvrFineRate` (TextBox, line 253), `_nSlvrDrAmt` (TextBox, line 258), `_nSlvrFineDr` (TextBox, line 263), `_nSlvrFineCr` (TextBox, line 268), `_nSlvrCrAmt` (TextBox, line 273), `_nWestPrc` (TextBox, line 278).

**MSG** — 56 named / 91 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Counter`, `Design`, `Color`, `Size`, `HuId`, `BagWt`, `Pcs`, `BagTot`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `LTouch`, `LessWt`, `HmFine`, `Fine`, `NetFine`, `SlvrFine`, `ConRate`, `Con%`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `NetAmt`, `TotAmt`, `Tax%`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrOthAmt`, `PrCost`, `TagCost`, `Margin`, `Image`, `KrLAmt`, `OrdNo`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_IDTL** — 28 named / 28 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `PcsWt`, `KrgWt`, `Krg%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldGwt`.

**MSG_PR** — 34 named / 41 declared columns: `Sr`, `ItCode`, `ItName`, `Counter`, `Design`, `BagWt`, `Pcs`, `PsWt`, `GrWt`, `OthWt`, `NetWt`, `GhtWt`, `Touch`, `West%`, `LTouch`, `Fine`, `NetFine`, `SlvFine`, `ConRate`, `Con%`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `NetAmt`, `HmFine`, `TotAmt`, `TaxPrc`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_UPI_REC

Track **P06**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_UPI_REC.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/batch-receipt/page.tsx](<../web/apps/web/app/(app)/txn/batch-receipt/page.tsx>); [web/apps/web/app/(app)/txn/payment/page.tsx](<../web/apps/web/app/(app)/txn/payment/page.tsx>); [web/apps/web/app/(app)/txn/receipt/page.tsx](<../web/apps/web/app/(app)/txn/receipt/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/finance.ts](<../web/apps/api/src/modules/finance/finance.ts>); [web/apps/api/src/modules/finance/tender.ts](<../web/apps/api/src/modules/finance/tender.ts>)

Retained write-table candidates: `UPI_DATA`.

Source extraction: 1 inputs; 6 named columns; 3 distinct validation-message candidates; 1 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 30).

**MSG** — 6 named / 6 declared columns: `Sr.`, `AcCode`, `Upi Bank Name`, `UpiType`, `Upi Id`, `UpiAmt`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_VP

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_VP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/vp-parcel/page.tsx](<../web/apps/web/app/(app)/txn/vp-parcel/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/vpParcel.ts](<../web/apps/api/src/modules/sales/vpParcel.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `ROJ_MEL_DATA`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_PR_DETL`, `TEMP_BOOK_DATA`.

Source extraction: 15 inputs; 65 named columns; 14 distinct validation-message candidates; 2 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 43), `_tVchNo` (TextBox, line 48), `_TEXT_ENTRY` (TextBox, line 83), `_TEXT_IDTL` (TextBox, line 98), `_tAcCode` (TextBox, line 123), `_tEmpCode` (TextBox, line 128), `_tVchDesc` (TextBox, line 133), `_tItRemark` (TextBox, line 138), `_TEXT_ENTRY_2` (TextBox, line 148), `_tBillNo` (TextBox, line 153), `_tAngdiyaAc` (TextBox, line 158), `_cboItemTyp` (ComboBox, line 163), `_nVpCharge` (TextBox, line 168), `_nVpInsAmt` (TextBox, line 173), `_cboVpChargType` (ComboBox, line 178).

**MSG** — 42 named / 67 declared columns: `Sr`, `TagNo`, `ItCode`, `Counter`, `Design`, `Size`, `BagWt`, `Pcs`, `GrWt`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `TotAmt`, `Tax%`, `NetAmt`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_IDTL** — 21 named / 21 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmSize`, `DmSfNo`, `Pcs`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `KrWt`, `KrConWt`, `ItType`, `RowSrNo`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_VP_ADJ

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_VP_ADJ.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/vp-adjustment/page.tsx](<../web/apps/web/app/(app)/txn/vp-adjustment/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/vpAdjustment.ts](<../web/apps/api/src/modules/finance/vpAdjustment.ts>)

Retained write-table candidates: `AC_DATA`, `DELETE_DATA`, `RATE_CUT_DATA`, `ROJ_MEL_DATA`, `TEMP_BOOK_DATA`, `VP_ADJ_DATA`.

Source extraction: 5 inputs; 8 named columns; 11 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_tItDesc` (TextBox, line 105).

**MSG** — 7 named / 14 declared columns: `Sr`, `VpNo`, `AcCode`, `AcName`, `Amount`, `Kasar`, `AngdiyaName`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_WH_SALE

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_WH_SALE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/wholesale-sale/page.tsx](<../web/apps/web/app/(app)/txn/wholesale-sale/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/rateCut.ts](<../web/apps/api/src/modules/sales/rateCut.ts>); [web/apps/api/src/modules/sales/sales.ts](<../web/apps/api/src/modules/sales/sales.ts>)

Retained write-table candidates: `AC_DATA`, `APR_DETL`, `BAR_DETL`, `DELETE_DATA`, `DM_DATA`, `LOT_DETL`, `MAIN_STOCK`, `PRINT_MAST`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_ISU_REC`, `RATE_CUT_REC`, `ROJ_MEL_DATA`, `SL_IDTL`, `SL_ORD_DETL`, `TAX_DATA`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `USER_DATA`.

Source extraction: 41 inputs; 129 named columns; 30 distinct validation-message candidates; 4 confirmation candidates; 10 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 46), `_tVchNo` (TextBox, line 51), `_TEXT_ENTRY` (TextBox, line 86), `_TEXT_IDTL` (TextBox, line 101), `_tAcCode` (TextBox, line 126), `_tAcName` (TextBox, line 131), `_tEmpCode` (TextBox, line 136), `_tVchDesc` (TextBox, line 141), `_TEXT_ENTRY_2` (TextBox, line 156), `_TEXT_PR` (TextBox, line 161), `_tBillNo` (TextBox, line 166), `_tMobile` (TextBox, line 171), `_tCity` (TextBox, line 176), `_tAdd3` (TextBox, line 181), `_tAdd2` (TextBox, line 186), `_tAdd1` (TextBox, line 191), `_nAcDrAmt` (TextBox, line 196), `_nAcCrFine` (TextBox, line 201), `_nAcCrAmt` (TextBox, line 206), `_nAcDrFine` (TextBox, line 211), `_nFineKsrDr` (TextBox, line 216), `_nFineKsrCr` (TextBox, line 221), `_nFineRate` (TextBox, line 226), `_nCrDays` (TextBox, line 231), `_cboItemTyp` (ComboBox, line 236), `_nConvPrc` (TextBox, line 241), `_nConvRate` (TextBox, line 246), `_tIsuNo` (TextBox, line 256), `_nIntFine` (TextBox, line 266), `_nIntDay` (TextBox, line 271), `_nIntPrc` (TextBox, line 276), `_nBillProfit` (TextBox, line 281), `_chkSilverCut` (CheckBox, line 286), `_nSlvrFineRate` (TextBox, line 291), `_nSlvrDrAmt` (TextBox, line 296), `_nSlvrFineDr` (TextBox, line 301), `_nSlvrFineCr` (TextBox, line 306), `_nSlvrCrAmt` (TextBox, line 311), `_nWestPrc` (TextBox, line 316), `_tNewPrint` (TextBox, line 321), `_chkOthItmWtRemove` (CheckBox, line 331).

**MSG** — 60 named / 101 declared columns: `Sr`, `TagNo`, `ItmLot`, `ItCode`, `ItName`, `Counter`, `Design`, `Style`, `Color`, `Size`, `HuId`, `BagWt`, `Pcs`, `BagTot`, `PsWt`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `FixWst%`, `LTouch`, `LessWt`, `HmFine`, `Fine`, `NetFine`, `SlvrFine`, `ConRate`, `Con%`, `ItRate`, `ItAmt`, `Lbr%`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `NetAmt`, `OrdNo`, `TotAmt`, `Tax%`, `KrCode`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `TagCost`, `Margin`, `Image`.

**MSG2_TOTAL** — 2 named / 6 declared columns: `Payment`, `Received`.

**MSG_IDTL** — 31 named / 31 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `PcsWt`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `Rate`, `ItAmt`, `Disc%`, `DiscAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `KrCon%`, `ConWt`, `tagKrWt`, `KrConWt`, `ItType`, `RowSrNo`, `OldGwt`.

**MSG_PR** — 34 named / 42 declared columns: `Sr`, `ItCode`, `ItName`, `Counter`, `Design`, `BagWt`, `Pcs`, `PsWt`, `GrWt`, `OthWt`, `NetWt`, `GhtWt`, `Touch`, `West%`, `LTouch`, `Fine`, `NetFine`, `SlvFine`, `ConRate`, `Con%`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `Mrp`, `NetAmt`, `HmFine`, `TotAmt`, `TaxPrc`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

**MSG_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_EnterCell`, `MSG_IDTL_EnterCell`, `MSG_IDTL_LeaveCell`, `MSG_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TR_WH_SALE_RTN

Track **P05**. Category `transaction`. [Desktop source](<../unified/src/csharp/DataCareNext/TR_WH_SALE_RTN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/wholesale-sale-return/page.tsx](<../web/apps/web/app/(app)/txn/wholesale-sale-return/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/sales/wholesaleSaleReturn.ts](<../web/apps/api/src/modules/sales/wholesaleSaleReturn.ts>)

Retained write-table candidates: `AC_DATA`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `DELETE_DATA`, `DM_DATA`, `MAIN_STOCK`, `RATE_CUT_ISU_REC`, `ROJ_MEL_DATA`, `TAG_IMAGE_DATA`, `TAG_SET`, `TAX_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 18 inputs; 96 named columns; 16 distinct validation-message candidates; 4 confirmation candidates; 7 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 42), `_tVchNo` (TextBox, line 47), `_tAcCode` (TextBox, line 97), `_tAcName` (TextBox, line 102), `_tVchDesc` (TextBox, line 107), `_TEXT_ENTRY_2` (TextBox, line 122), `_TEXT_PR` (TextBox, line 127), `_tBillNo` (TextBox, line 132), `_tMobile` (TextBox, line 137), `_tCity` (TextBox, line 142), `_tAdd3` (TextBox, line 147), `_tAdd2` (TextBox, line 152), `_tAdd1` (TextBox, line 157), `_tSlBill` (TextBox, line 162), `_cboItemTyp` (ComboBox, line 167), `_nPartyFine` (TextBox, line 172), `_TEXT_PR_IDTL` (TextBox, line 182), `_tEmpCode` (TextBox, line 187).

**MSG2_TOTAL** — 1 named / 5 declared columns: `Net Amt :`.

**MSG_PR** — 64 named / 106 declared columns: `Sr`, `TagNo`, `ItCode`, `ItName`, `Counter`, `Design`, `Style`, `Color`, `Size`, `BagWt`, `Pcs`, `PsWt`, `GrWt`, `OthWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `SlvFine`, `ConRate`, `Con%`, `Rate`, `ItAmt`, `Lbr%`, `Ltype`, `LRate`, `LAmt`, `OthAmt`, `ORate`, `OFine`, `PrCost`, `Mrp`, `TotAmt`, `TaxPrc`, `NetAmt`, `HmAmt`, `TOthWt`, `TgNwt`, `LCode`, `TgTch`, `TgW%`, `TgFine`, `TagRate`, `TagItAmt`, `TgLbr%`, `TgLRat`, `TgLAmt`, `TgOth`, `TagCost`, `Margin%`, `TgMrp`, `HmId`, `KrName`, `HmWt`, `HmId2`, `HmWt2`, `HmId3`, `HmWt3`, `HmId4`, `HmWt4`, `HmFine`, `PrCode`.

**MSG_PR_IDTL** — 30 named / 30 declared columns: `Sr`, `ItCode`, `ItName`, `DmCode`, `DmName`, `DmColor`, `DmSize`, `DmOrigin`, `Remark`, `DmSfNo`, `Pcs`, `PcsWt`, `KrWt`, `KrLs%`, `Weight`, `Con%`, `P/W`, `PRate`, `PAmt`, `Rate`, `ItAmt`, `LbrRate`, `LbrAmt`, `NetAmt`, `ConWt`, `ItType`, `RowSrNo`, `KrConWt`, `2RowVal`, `2RowText`.

**MSG_PR_TOT** — 1 named / None declared columns: `Total :`.

Recalculation/selection handlers to trace: `MSG2_TOTAL_EnterCell`, `MSG2_TOTAL_LeaveCell`, `MSG_PR_EnterCell`, `MSG_PR_IDTL_EnterCell`, `MSG_PR_IDTL_LeaveCell`, `MSG_PR_LeaveCell`, `MSG_PR_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## TagOthDetail

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/TagOthDetail.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/tag-stock/page.tsx](<../web/apps/web/app/(app)/reports/tag-stock/page.tsx>); [web/apps/web/app/(app)/txn/stock/page.tsx](<../web/apps/web/app/(app)/txn/stock/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## Translator

Track **P00 / P01 / P02**. Category `other`. [Desktop source](<../unified/src/csharp/DataCareNext/Translator.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_AI_TRFR

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_AI_TRFR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/counter-transfer/page.tsx](<../web/apps/web/app/(app)/txn/counter-transfer/page.tsx>); [web/apps/web/app/(app)/txn/tag-transfer/page.tsx](<../web/apps/web/app/(app)/txn/tag-transfer/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/stock/stock.ts](<../web/apps/api/src/modules/stock/stock.ts>)

Retained write-table candidates: `BAR_DETL`, `BOOK_IDTL`, `TAG_DATA`, `TAG_IMAGE_DATA`.

Source extraction: 4 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mToDt` (MaskedTextBox, line 219), `_mFromDt` (MaskedTextBox, line 229), `_tGrCode` (TextBox, line 239), `_tPrCode` (TextBox, line 244).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_BANK

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_BANK.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/bank-recon/page.tsx](<../web/apps/web/app/(app)/txn/bank-recon/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/bankRecon.ts](<../web/apps/api/src/modules/finance/bankRecon.ts>)

Retained write-table candidates: `AC_DATA`, `CASH_DATA`.

Source extraction: 4 inputs; 12 named columns; 5 distinct validation-message candidates; 1 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mFromDt` (MaskedTextBox, line 32), `_TEXT_ENTRY` (TextBox, line 67), `_tAcCode` (TextBox, line 72), `_mToDt` (MaskedTextBox, line 77).

**MSG** — 12 named / 18 declared columns: `Sr`, `BookType`, `Ac Name`, `Tran Id`, `VchNo`, `VchDate`, `ChqNo`, `ClrDate`, `DrAmt`, `CrAmt`, `AmtBal`, `CrDr`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_BKP

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_BKP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/backup/page.tsx](<../web/apps/web/app/(app)/backup/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/ops/backup.ts](<../web/apps/api/src/modules/ops/backup.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_CUST_ENTRY

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_CUST_ENTRY.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/masters/party/page.tsx](<../web/apps/web/app/(app)/masters/party/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/party.ts](<../web/apps/api/src/modules/masters/party.ts>)

Retained write-table candidates: `CUST_DATA`, `CUST_DETL`.

Source extraction: 5 inputs; 15 named columns; 11 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100), `_tItRemark` (TextBox, line 105).

**MSG** — 15 named / 17 declared columns: `Sr`, `AcCode`, `CustAc`, `Ac Name`, `Mobile`, `RemDate`, `Remark`, `TagNo`, `ItCode`, `ItLike`, `Pcs`, `GrWt`, `NetWt`, `Fine`, `ItName`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_EXPORT

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_EXPORT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/backup/page.tsx](<../web/apps/web/app/(app)/backup/page.tsx>); [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>); [web/apps/api/src/modules/ops/backup.ts](<../web/apps/api/src/modules/ops/backup.ts>)

Retained write-table candidates: `AC_DATA`, `AC_MAST`, `AD_ADJ`, `AD_DATA`, `AD_MAST`, `AD_MEMB`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `BOOK_DATA`, `BOOK_DETL`, `CARD_DATA`, `CASH_DATA`, `CONTRA_DATA`, `CO_SET`, `FINE_DATA`, `GROUP_MAST`, `ITEM_MAST`, `ITM_OPBL`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LBR_DATA`, `LBR_ISU_DETL`, `LBR_REC_DETL`, `MAIN_STOCK`, `OP_DATA`, `PAY_DATA`, `PRODUCT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_REC`, `REP_DATA`, `REP_DETL`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_DETL_RTN`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `TABLE_MAST`, `TAX_DATA`, `TEMP_BOOK_DATA`, `UPI_DATA`.

Source extraction: 0 inputs; 0 named columns; 12 distinct validation-message candidates; 5 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_E_INVOICE

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_E_INVOICE.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/e-invoice/page.tsx](<../web/apps/web/app/(app)/utilities/e-invoice/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/einvoice/einvoice.ts](<../web/apps/api/src/modules/einvoice/einvoice.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 2 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mToDt` (MaskedTextBox, line 60), `_mFromDt` (MaskedTextBox, line 65).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_HDD

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_HDD.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/hdd-registry/page.tsx](<../web/apps/web/app/(app)/utilities/hdd-registry/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/utilities/hddRegistry.ts](<../web/apps/api/src/modules/utilities/hddRegistry.ts>)

Retained write-table candidates: `HDD_MAST`.

Source extraction: 1 inputs; 0 named columns; 1 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tHddNo` (TextBox, line 35).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_IMPORT

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_IMPORT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/backup/page.tsx](<../web/apps/web/app/(app)/backup/page.tsx>); [web/apps/web/app/(app)/masters/[name]/page.tsx](<../web/apps/web/app/(app)/masters/[name]/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/masters/master.service.ts](<../web/apps/api/src/modules/masters/master.service.ts>); [web/apps/api/src/modules/ops/backup.ts](<../web/apps/api/src/modules/ops/backup.ts>)

Retained write-table candidates: `AC_DATA`, `AC_GROUP`, `AC_MAST`, `AC_MAST_SRNO`, `ADD_MAST`, `AD_ADJ`, `AD_DATA`, `AD_MAST`, `AD_MEMB`, `AD_OS`, `APR_DATA`, `APR_DETL`, `APR_IDTL`, `BAR_CAN_DATA`, `BAR_CAN_DETL`, `BAR_CAN_IDTL`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `CASH_DATA`, `CO_SET`, `DHRN_DATA`, `DHRN_ISU_DATA`, `DHRN_ISU_DETL`, `DHRN_REC_DATA`, `DHRN_REC_DETL`, `EMP_MAST`, `FINE_DATA`, `GROUP_MAST`, `HDD_MAST`, `ITEM_MAST`, `ITM_OPBL`, `KR_DATA`, `KR_DETL`, `KR_IDTL`, `LOCT_MAST`, `MAIN_STOCK`, `MFG_DATA`, `MFG_DETL`, `MFG_IDTL`, `OP_DATA`, `OP_LDR`, `POINT_DATA`, `POINT_MAST`, `POINT_MEMB`, `PRODUCT_MAST`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_REC`, `REP_DETL`, `ROJ_MEL_DATA`, `SL_DATA`, `SL_DETL`, `SL_IDTL`, `SL_ORD_DATA`, `SL_ORD_DETL`, `SL_ORD_IDTL`, `SL_PR_DETL`, `SRNO_MAST`, `TABLE_MAST`, `TEMP_BOOK_DATA`, `TOUCH_MAST`, `YEAR_MAST`.

Source extraction: 1 inputs; 0 named columns; 22 distinct validation-message candidates; 16 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_mClDate` (MaskedTextBox, line 68).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_PWD_UPDATE

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_PWD_UPDATE.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: [web/apps/api/src/modules/auth/password.ts](<../web/apps/api/src/modules/auth/password.ts>)

Retained write-table candidates: `LOGIN_MAST`.

Source extraction: 1 inputs; 0 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tOldPasword` (TextBox, line 34).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_REMINDER

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_REMINDER.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/reminders/page.tsx](<../web/apps/web/app/(app)/txn/reminders/page.tsx>); [web/apps/web/app/(app)/utilities/reminder-entry/page.tsx](<../web/apps/web/app/(app)/utilities/reminder-entry/page.tsx>); [web/apps/web/app/(app)/utilities/reminders/page.tsx](<../web/apps/web/app/(app)/utilities/reminders/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/finance/reminders.ts](<../web/apps/api/src/modules/finance/reminders.ts>); [web/apps/api/src/modules/utilities/reminderEntry.ts](<../web/apps/api/src/modules/utilities/reminderEntry.ts>)

Retained write-table candidates: `REM_DATA`, `TEMP_BOOK_DATA`.

Source extraction: 4 inputs; 5 named columns; 9 distinct validation-message candidates; 2 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_mVchDate` (MaskedTextBox, line 40), `_tVchNo` (TextBox, line 45), `_TEXT_ENTRY` (TextBox, line 80), `_tEmpCode` (TextBox, line 100).

**MSG** — 5 named / 5 declared columns: `Sr`, `AcCode`, `Ac Name`, `It Desc`, `Date`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_REPORT

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_REPORT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/reports/report-layouts/page.tsx](<../web/apps/web/app/(app)/reports/report-layouts/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/reports/reportEngine.ts](<../web/apps/api/src/modules/reports/reportEngine.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 4 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_SETTING

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_SETTING.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/users/page.tsx](<../web/apps/web/app/(app)/admin/users/page.tsx>); [web/apps/web/app/(app)/settings/page.tsx](<../web/apps/web/app/(app)/settings/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/rbac/formRights.ts](<../web/apps/api/src/modules/rbac/formRights.ts>); [web/apps/api/src/modules/settings/settings.ts](<../web/apps/api/src/modules/settings/settings.ts>)

Retained write-table candidates: `COL_MAST`, `CO_SET`, `CO_SET_NEW`.

Source extraction: 2 inputs; 6 named columns; 28 distinct validation-message candidates; 0 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_TEXT_ENTRY` (TextBox, line 30), `_cboColSet` (ComboBox, line 40).

**MSG** — 6 named / 6 declared columns: `Sr`, `ColName`, `ColNewName`, `RptCol`, `ShowCol`, `BookName`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_SETTING_MAIN

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/users/page.tsx](<../web/apps/web/app/(app)/admin/users/page.tsx>); [web/apps/web/app/(app)/settings/page.tsx](<../web/apps/web/app/(app)/settings/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/rbac/formRights.ts](<../web/apps/api/src/modules/rbac/formRights.ts>); [web/apps/api/src/modules/settings/settings.ts](<../web/apps/api/src/modules/settings/settings.ts>)

Retained write-table candidates: `CO_SET`, `CO_SET_NEW`, `MENU_DATA`.

Source extraction: 1 inputs; 0 named columns; 64 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tDcPwd` (TextBox, line 167).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_SET_ADMIN

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_SET_ADMIN.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/admin/users/page.tsx](<../web/apps/web/app/(app)/admin/users/page.tsx>); [web/apps/web/app/(app)/settings/page.tsx](<../web/apps/web/app/(app)/settings/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/rbac/formRights.ts](<../web/apps/api/src/modules/rbac/formRights.ts>); [web/apps/api/src/modules/settings/settings.ts](<../web/apps/api/src/modules/settings/settings.ts>)

Retained write-table candidates: `CO_SET_NEW`.

Source extraction: 0 inputs; 0 named columns; 11 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_SMS

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_SMS.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/integrations/page.tsx](<../web/apps/web/app/(app)/integrations/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/integrations/messaging.ts](<../web/apps/api/src/modules/integrations/messaging.ts>)

Retained write-table candidates: `LEDR_AC_DATA`, `MSG_MAST`.

Source extraction: 8 inputs; 0 named columns; 13 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_CboSmsType` (ComboBox, line 70), `_nFromOs` (TextBox, line 75), `_nToOs` (TextBox, line 80), `_tMsg` (TextBox, line 90), `_chkAllRow` (CheckBox, line 120), `_cboBarth` (ComboBox, line 130), `_chkOsAmt` (CheckBox, line 135), `_chkRetSend` (CheckBox, line 140).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_TAG_PRINT

Track **P07 / P10 / P11**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_TAG_PRINT.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/txn/tag-print/page.tsx](<../web/apps/web/app/(app)/txn/tag-print/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/integrations/barcode.ts](<../web/apps/api/src/modules/integrations/barcode.ts>); [web/apps/api/src/modules/stock/tagPrint.ts](<../web/apps/api/src/modules/stock/tagPrint.ts>)

Retained write-table candidates: `BAR_DETL`, `PRINT_MAST`, `TAG_PRINT_DATA`.

Source extraction: 6 inputs; 49 named columns; 6 distinct validation-message candidates; 1 confirmation candidates; 3 grid-cell handlers.

Declared input controls: `_tVchNo` (TextBox, line 44), `_TEXT_ENTRY` (TextBox, line 79), `_tBookCode` (TextBox, line 89), `_tPrCode` (TextBox, line 99), `_tGrCode` (TextBox, line 104), `_chkHmIdUpdate` (CheckBox, line 109).

**MSG** — 49 named / 72 declared columns: `Sr`, `Y/N`, `TagNo`, `ItCode`, `Counter`, `Design`, `Size`, `BagWt`, `Pcs`, `GrWt`, `HmId`, `HmWt`, `HmId2`, `HmWt2`, `HmId3`, `HmWt3`, `HmId4`, `HmWt4`, `LsWt`, `NetWt`, `Ght%`, `GhtWt`, `Touch`, `West%`, `Fine`, `LCode`, `LType`, `LbrRate`, `LbrAmt`, `OthAmt`, `Mrp`, `KrCode`, `Lbr%`, `KrOthWt`, `KrNwt`, `KrGht%`, `KrGht`, `KrTouch`, `KrWst%`, `KrFine`, `KrLRate`, `KrLAmt`, `KrOthAmt`, `PrCost`, `ItRate`, `ItAmt`, `TagCost`, `Margin`, `Image`.

Recalculation/selection handlers to trace: `MSG_EnterCell`, `MSG_LeaveCell`, `MSG_RowColChange`.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_USER_REQUEST

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_USER_REQUEST.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/user-request/page.tsx](<../web/apps/web/app/(app)/utilities/user-request/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/utilities/userRequest.ts](<../web/apps/api/src/modules/utilities/userRequest.ts>)

Retained write-table candidates: `USER_REQUEST`.

Source extraction: 0 inputs; 0 named columns; 2 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_VCH_RE_NUMBR

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_VCH_RE_NUMBR.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/voucher-renumber/page.tsx](<../web/apps/web/app/(app)/utilities/voucher-renumber/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/utilities/voucherRenumber.ts](<../web/apps/api/src/modules/utilities/voucherRenumber.ts>)

Retained write-table candidates: `AD_ADJ`, `BAR_DATA`, `BAR_DETL`, `BAR_IDTL`, `BILL_OS_DATA`, `CASH_DATA`, `PR_DATA`, `PR_DETL`, `PR_IDTL`, `RATE_CUT_DATA`, `RATE_CUT_ISU`, `RATE_CUT_REC`, `SL_DATA`, `SL_DETL`, `SL_IDTL`, `SL_ORD_ADJ`, `SL_PR_DETL`, `UPI_DATA`.

Source extraction: 1 inputs; 0 named columns; 2 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_tBookCode` (TextBox, line 81).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_WAPP_WITH_API

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_WAPP_WITH_API.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/integrations/page.tsx](<../web/apps/web/app/(app)/integrations/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/integrations/messaging.ts](<../web/apps/api/src/modules/integrations/messaging.ts>)

Retained write-table candidates: `LEDR_AC_DATA`, `MSG_MAST`, `POINT_MAST`.

Source extraction: 9 inputs; 0 named columns; 11 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_CboSmsType` (ComboBox, line 80), `_nFromOs` (TextBox, line 85), `_nToOs` (TextBox, line 90), `_tMobileNo` (TextBox, line 100), `_chkAllRow` (CheckBox, line 120), `_cboBarth` (ComboBox, line 130), `_nFromRow` (TextBox, line 155), `_nToRow` (TextBox, line 160), `_cboTemplate` (ComboBox, line 170).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_WEB_CAM

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_WEB_CAM.cs>). Status: **unverified**.

Candidate web files: none

Candidate API modules: none

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 0 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_WHATSAPP

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_WHATSAPP.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/integrations/page.tsx](<../web/apps/web/app/(app)/integrations/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/integrations/messaging.ts](<../web/apps/api/src/modules/integrations/messaging.ts>)

Retained write-table candidates: `CO_SET_NEW`, `LEDR_AC_DATA`, `MSG_MAST`, `POINT_MAST`.

Source extraction: 10 inputs; 0 named columns; 14 distinct validation-message candidates; 1 confirmation candidates; 0 grid-cell handlers.

Declared input controls: `_CboSmsType` (ComboBox, line 79), `_nFromOs` (TextBox, line 84), `_nToOs` (TextBox, line 89), `_tMobileNo` (TextBox, line 99), `_chkAllRow` (CheckBox, line 119), `_cboBarth` (ComboBox, line 129), `_chkBoxHeadLess` (CheckBox, line 154), `_cboMsgType` (ComboBox, line 164), `_nFromRow` (TextBox, line 204), `_nToRow` (TextBox, line 209).

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

## UT_WINDOW

Track **P11 / P12**. Category `utility`. [Desktop source](<../unified/src/csharp/DataCareNext/UT_WINDOW.cs>). Status: **unverified**.

Candidate web files: [web/apps/web/app/(app)/utilities/window-tiles/page.tsx](<../web/apps/web/app/(app)/utilities/window-tiles/page.tsx>)

Candidate API modules: [web/apps/api/src/modules/utilities/windowTiles.ts](<../web/apps/api/src/modules/utilities/windowTiles.ts>)

Retained write-table candidates: none recorded; verify shared engines and indirect writes.

Source extraction: 0 inputs; 0 named columns; 3 distinct validation-message candidates; 0 confirmation candidates; 0 grid-cell handlers.

Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.

