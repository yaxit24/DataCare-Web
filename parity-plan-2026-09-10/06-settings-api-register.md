# Settings and API field review register

> Frozen 10 September inventory. Current implementation/availability and scanner corrections are in [the 11 September review](11-current-completion-review.md); follow [the execution continuation](12-execution-addendum.md). Retain these source identities while revalidating all current web mappings.

The original raw-key scan is not a settings-effect certificate. It excludes the typed loader and misses camelCase consumers; it can also count comments, collisions or unrelated uses. The alias column below is a code-search lead, not a complete data-flow proof. Every key requires an observed outcome for each allowed value, blank/missing/default handling and invalid-value rejection. A setting need not be operator input merely because it is stored.

| Key | Raw scanner class | Typed alias | Consumer leads outside loader | Desktop reader count |
| --- | --- | --- | --- | ---: |
| THEME | inert | none found | none found | 152 |
| TAG_RPT | inert | tagReport | none found | 7 |
| FINE_STK_TYPE | inert | fineStockType | web/apps/api/src/modules/reports/reports.ts | 2 |
| RATE_MAST_OPEN | inert | none found | none found | 1 |
| LBR_RATE_GEN | inert | labourRateGeneration | web/apps/api/src/modules/purchase/purchase.ts; web/apps/api/src/modules/sales/sales.ts | 10 |
| VB_IMPORT | inert | vbImport | none found | 22 |
| SL_ROW_CHANGE | inert | none found | none found | 10 |
| DHRN_INT_TYPE | honoured | dhrnIntType | none found | 5 |
| INT_YEAR_DAYS | honoured | intYearDays | none found | 7 |
| OP_DHRN | inert | openingDhrn | none found | 2 |
| INT_DAY | honoured | intDay | none found | 2 |
| HELP_SERCH | inert | none found | none found | 2 |
| WEIGHT_PORT | honoured | weightPort | web/apps/api/src/modules/integrations/readiness.ts | 2 |
| LDR_SUMM | inert | ledgerSummary | web/apps/api/src/modules/accounting/accounting.ts | 3 |
| SL_AMT_TYPE | honoured | saleAmountType | web/apps/api/src/modules/sales/sales.ts | 9 |
| SMS_LINK | inert | smsGateway | none found | 0 |
| OP_LOAN | inert | openingLoan | none found | 2 |
| LOAN_INT_TYPE | honoured | loanIntType | none found | 4 |
| TRAD_FINE | honoured | none found | none found | 1 |
| LBR_ROF | honoured | none found | none found | 26 |
| REMINDER_OPEN | inert | none found | none found | 1 |
| ITM_RATE_ROF | honoured | none found | none found | 11 |
| ADMIN_SMS | honoured | adminSms | none found | 4 |
| CUST_SMS | honoured | customerSms | none found | 10 |
| PURC_WITH_LBR | honoured | purchaseWithLabour | web/apps/api/src/modules/purchase/purchase.ts | 4 |
| DHIRN_COMPOUND | honoured | dhrnCompound | none found | 3 |
| GRID_SCROLL | inert | none found | none found | 60 |
| STK_RPT_TYPE | honoured | stockReportGrossWeight | web/apps/api/src/modules/reports/reports.ts | 2 |
| TOUCH_AUTO_SAVE | inert | touchAutoSave | web/apps/api/src/modules/purchase/purchase.ts; web/apps/api/src/modules/sales/sales.ts | 4 |
| PAN_CARD_VAL | honoured | panCardVal | web/apps/api/src/modules/finance/tender.ts; web/apps/api/src/modules/sales/sales.ts | 3 |
| DHRN_PRC | honoured | dhrnDefaultRate | web/apps/api/src/modules/dhrn/dhrn.ts | 2 |
| DUP_PRINT | inert | duplicatePrint | none found | 23 |
| TAX_CODE | honoured | none found | none found | 9 |
| IP_WITH_PC | inert | exportDatabaseTarget | web/apps/api/src/modules/ops/backup.ts | 1 |
| CO_STK_MERGE | inert | companyStockMerge | web/apps/api/src/modules/stock/stock.ts | 22 |
| STK_RPT_VIEW | inert | none found | none found | 0 |
| PR_AMT_TYPE | honoured | purchaseAmountType | web/apps/api/src/modules/purchase/purchase.ts | 5 |
| CARD_COM_ADJ | honoured | cardCommissionAdjustment | web/apps/api/src/modules/finance/finance.ts; web/apps/api/src/modules/sales/sales.ts | 5 |
| CASH_PURC_AC | inert | cashPurchaseAccount | web/apps/api/src/modules/purchase/purchase.ts | 2 |
| EMP_CODE_MANDATORY | honoured | none found | none found | 33 |
| STOCK_RPT_TYPE | inert | stockWeightSource | web/apps/api/src/modules/sales/sales.ts | 3 |
| LAST_DAY_LOCK | honoured | lastDayLock | none found | 1 |
| CASH_LIMIT | honoured | cashLimit | web/apps/api/src/modules/finance/finance.ts; web/apps/api/src/modules/finance/tender.ts; web/apps/api/src/modules/sales/sales.ts | 10 |
| DHRN_WAPP | inert | dhrnWhatsapp | none found | 2 |
| SCHM_WAPP | inert | schemeWhatsapp | none found | 2 |
| LEDR_BILL_COL | inert | none found | none found | 2 |
| ALL_ROF_REMOVE | honoured | allRoundingRemoved | none found | 10 |
| CO_CODE | honoured | none found | none found | 0 |
| BTN_NAME | inert | none found | none found | 0 |
| COUNTRY_CODE | inert | none found | none found | 0 |
| LBR_TYPE | honoured | labourType | web/apps/api/src/modules/inout/fineInout.ts; web/apps/api/src/modules/masters/designBook.ts; web/apps/api/src/modules/purchase/purchase.ts; web/apps/api/src/modules/purchase/purchaseReturn.ts; web/apps/api/src/modules/repair/repairCustomerIssue.ts; web/apps/api/src/modules/repair/repairKarigarReceipt.ts; web/apps/api/src/modules/repair/repairReceipt.ts; web/apps/api/src/modules/sales/labourInvoice.ts; web/apps/api/src/modules/sales/sales.ts; web/apps/api/src/modules/sales/salesOrder.ts; web/apps/api/src/modules/sales/salesReturn.ts; web/apps/api/src/modules/sales/vpParcel.ts; web/apps/api/src/modules/sales/wholesaleSaleReturn.ts; web/apps/api/src/modules/stock/tagOps.ts; web/apps/api/src/modules/tour/tour.ts; web/apps/web/app/(app)/txn/labour-sale/page.tsx; web/apps/web/app/(app)/txn/purchase/page.tsx; web/apps/web/app/(app)/txn/repair-customer-issue/page.tsx; web/apps/web/app/(app)/txn/repair-karigar-receipt/page.tsx; web/apps/web/app/(app)/txn/repair-receipt/page.tsx; web/apps/web/app/(app)/txn/sales-order/page.tsx; web/apps/web/app/(app)/txn/sales/page.tsx; web/apps/web/app/(app)/txn/vp-parcel/page.tsx; web/apps/web/app/(app)/txn/wholesale-sale-return/page.tsx; web/apps/web/lib/lineRecalc.ts | 34 |
| AC_LC_CODE_LEN | honoured | accountCodeLength | web/apps/api/src/modules/masters/master.service.ts | 0 |
| LOCK_DATE | honoured | none found | none found | 63 |
| TAX_ROF | honoured | none found | none found | 0 |
| RATE_PAR | honoured | rateBasis | web/apps/api/src/modules/sales/rateCut.ts | 9 |
| OZ_CON_VAL | honoured | ounceConversion | web/apps/api/src/modules/integrations/rates.ts | 2 |
| FX_RATE | honoured | fxRate | none found | 2 |
| FX_CODE | honoured | fxCode | none found | 2 |
| COUNTRY_ID | inert | none found | none found | 35 |
| MFG_ONE_FORM | honoured | none found | none found | 0 |
| CO_CODE | honoured | none found | none found | 0 |
| COUNTER_STK | honoured | none found | none found | 5 |
| APR_IMG_PRINT | inert | none found | none found | 2 |
| BILL_PROFIT | honoured | none found | none found | 5 |
| BRANCH_ALL_AC_SHOW | inert | branchAllAccountShow | none found | 68 |
| COUNTRY_ID | inert | none found | none found | 35 |
| CUR_DAY_POSTING | inert | stockRefreshFromDateOnly | none found | 3 |
| DEFAULT_REMINDER | inert | none found | none found | 2 |
| DESIGN_HELP | inert | none found | none found | 13 |
| DHRN_IMG_PRINT | inert | none found | none found | 2 |
| EMP_AS_USER | inert | none found | none found | 57 |
| ESTMATE_BANK_LOCK | inert | estimateBankLocked | none found | 23 |
| ESTMATE_TAX | inert | estimateTax | none found | 3 |
| FONT_CHANGE | inert | none found | none found | 71 |
| FONT_NAME | inert | none found | none found | 69 |
| FONT_SIZE | inert | none found | none found | 69 |
| FONT_STYLE_TYPE | inert | none found | none found | 69 |
| F_DISC_DATE | inert | none found | none found | 3 |
| GRID_ROW_HIGHT | inert | none found | none found | 68 |
| ITM_FINE_LOCK | unknown | itemFineLocked | none found | 3 |
| ITM_WITH_LOT_STK | inert | itemWithLotStock | none found | 10 |
| KR_DESIGN_IMG_PRINT | inert | none found | none found | 3 |
| LBR_WITH_GHT | honoured | labourIncludesGhat | web/apps/api/src/modules/purchase/purchase.ts; web/apps/api/src/modules/sales/sales.ts; web/apps/web/lib/lineRecalc.ts | 23 |
| LEN_IMG_PATH | inert | none found | none found | 0 |
| MAIN_FONT_CHANGE | inert | none found | none found | 125 |
| MOBILE_HELP | inert | none found | none found | 4 |
| NEGATIVE_STK_SALE | honoured | negativeStockSale | web/apps/api/src/modules/sales/sales.ts | 7 |
| OLD_GOLD_TYPE | inert | none found | none found | 1 |
| OLD_PURC_TOUCH | inert | oldPurchaseTouchGenerated | none found | 5 |
| OPBL_TRFR_BTN | inert | none found | none found | 2 |
| ORD_IMG_PRINT | inert | none found | none found | 3 |
| ORD_TAG_STK_LESS | inert | orderReducesTagStock | none found | 3 |
| OS_BILL_ORNA_ISU | honoured | none found | none found | 5 |
| OS_BILL_SMS | inert | none found | none found | 7 |
| OS_FINE_INT | inert | none found | none found | 1 |
| OTH_ITM_WT_REMOVE | inert | otherItemWeightRemoved | none found | 3 |
| PRINT_FORM_BTN | inert | none found | none found | 2 |
| PROFIT_RPT_TYPE | honoured | none found | none found | 4 |
| PR_RATE_ROF | honoured | none found | none found | 5 |
| PR_TDS_TAX | honoured | purchaseTdsEnabled | web/apps/api/src/modules/purchase/purchase.ts | 3 |
| PURC_LOT | inert | purchaseLot | none found | 6 |
| PURC_WITH_HMTAX | honoured | purchaseWithHallmarkTax | web/apps/api/src/modules/purchase/purchase.ts | 31 |
| QR_CODE_GEN | inert | qrCodeGeneration | none found | 7 |
| RPT_TOT_SHOW | inert | none found | none found | 3 |
| SALES_WITH_HMTAX | honoured | salesWithHallmarkTax | web/apps/api/src/modules/sales/sales.ts | 28 |
| SILVER_THREE_DIGIT | inert | silverThreeDigit | none found | 11 |
| SL_BILL_IMG | inert | none found | none found | 3 |
| SL_MRP_TAX_REVERC | inert | none found | none found | 2 |
| SL_NWT_LOCK | unknown | saleNetWeightLocked | none found | 11 |
| SL_TAG_WT_DIFF | inert | saleTagWeightDiffReconciled | none found | 2 |
| SL_TDS_TAX | honoured | none found | none found | 2 |
| STK_LMIT_WITH_DESIGN | inert | none found | none found | 5 |
| TAG_AUTO_PRINT | inert | none found | none found | 2 |
| TAG_ENTRY_DESIGN_GEN | inert | none found | none found | 3 |
| TAG_VCH_AUTO_SAVE | inert | none found | none found | 4 |
| TILE_MENU | inert | none found | none found | 2 |
| TOT_AMT_ROF | honoured | none found | none found | 8 |
| TOT_FINE_STK_TYPE | inert | totalFineStockType | none found | 2 |
| T_DISC_DATE | inert | none found | none found | 3 |
| USER_KR_TOUCH_HIDE | inert | none found | none found | 3 |
| VCH_DESC_HELP_LENT | inert | none found | none found | 41 |
| WAPP_DELAY | inert | none found | none found | 0 |
| WAPP_IMG_GWT | inert | none found | none found | 2 |
| WAPP_SL_PRINT | inert | none found | none found | 3 |
| WAP_DELAY | inert | none found | none found | 0 |
| WEB_IMAGE | inert | none found | none found | 0 |
| WEB_PATH | inert | none found | none found | 0 |
| WH_BILL_IMG | inert | none found | none found | 4 |
| YEAR_GOLD_SL | inert | none found | none found | 1 |
| YEAR_SILVER_SL | inert | none found | none found | 1 |

## API fields with no frontend name match

Fresh scan: 96 fields; classifier proposes 14 operator fields, 53 server-derived and 29 internal. These categories need validation against each actual request adapter. A same-name occurrence on an unrelated page does not prove reachability. Do not expose tenant IDs, ledger-account slots or audit identities to clear a metric.

| Interface | Module | Operator candidates |
| --- | --- | --- |
| `SaleLineInput` | sales | tagLabourPct, tagLabourRate, tagLabourAmount, tagOtherAmount |
| `TagCancelLine` | stock | tagLot, itmPolish, toTblCode |
| `ChequeInput` | finance | payee, acPayee |
| `DesignBookLine` | masters | pageNo, dieNo |
| `LabourInvoiceInput` | sales | receiveLines |
| `SchemeInstallmentInput` | membership | withUpi |
| `SchemeInstallmentLine` | membership | withUpi |

Every exposed field must be traced through UI state → request → route adapter → domain input → calculation/writer → reader → hydration → unchanged save → print/export. Fields that only exist in JSON interfaces remain incomplete. See `evidence/GAP-MANIFEST.json` for every scanned interface and `evidence/UNREACHABLE-TRIAGE.json` for the complete candidate classification.

