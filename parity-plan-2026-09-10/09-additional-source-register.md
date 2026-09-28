# Additional source obligations found during re-verification

The first register is a useful seed, but its declaration regex misses modifiers. This supplement records **916 additional input declarations in 143 primary source units**, without changing the frozen 1,599-record scan. Together they contain 2,515 input declaration candidates; that is still not an exhaustive semantic field inventory or a parity percentage. Hidden/computed/duplicate controls must be classified, not indiscriminately exposed in the web.

Use these records alongside [the original form register](04-form-register.md), [source-check evidence](evidence/reverification-source-check.json), [additional control JSON](evidence/additional-control-candidates.json) and [supporting source JSON](evidence/supporting-source-register.json). Every record remains unverified. P00-01/P00-03/P00-05 must merge them into the canonical versioned requirement universe before completion can be judged.

## Source files outside the 204-unit namespace register

The complete primary C# tree contains 212 files. These eight support files need explicit disposition; compiler-generated code does not automatically mean irrelevant behaviour. `MyApplication.cs` selects the login form and saves settings on exit.

| File | Obligation |
| --- | --- |
| [unified/src/csharp/DataCareNext.My/MyApplication.cs](../unified/src/csharp/DataCareNext.My/MyApplication.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/DataCareNext.My/MyComputer.cs](../unified/src/csharp/DataCareNext.My/MyComputer.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/DataCareNext.My/MyProject.cs](../unified/src/csharp/DataCareNext.My/MyProject.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/DataCareNext.My/MySettings.cs](../unified/src/csharp/DataCareNext.My/MySettings.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/DataCareNext.My/MySettingsProperty.cs](../unified/src/csharp/DataCareNext.My/MySettingsProperty.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/DataCareNext.My.Resources/Resources.cs](../unified/src/csharp/DataCareNext.My.Resources/Resources.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/Properties/AssemblyInfo.cs](../unified/src/csharp/Properties/AssemblyInfo.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |
| [unified/src/csharp/VB-AnonymousDelegate_0.cs](../unified/src/csharp/VB-AnonymousDelegate_0.cs) | Trace startup/resource/settings/assembly effect or prove compiler-only with source/caller evidence |

## Additional input declarations by form

Full line references and stable candidate IDs are in the JSON companion. The declaration count is not the number of user-editable business fields.

| Source unit | Additional declarations | Control names |
| --- | ---: | --- |
| [BtmSchm](../unified/src/csharp/DataCareNext/BtmSchm.cs) | 1 | `_tYearCode` |
| [MDI_FORM](../unified/src/csharp/DataCareNext/MDI_FORM.cs) | 2 | `_nCurrncyRate`, `_tSoftDemoType` |
| [MS_ACCT](../unified/src/csharp/DataCareNext/MS_ACCT.cs) | 11 | `_tAcMainGr`, `_tAcGrName`, `_tCustDetl`, `_tRefAcName`, `_chkDefaulter`, `_nAcAmtLimit`, `_nAcSilverLimit`, `_nAcGoldLimit`, `_chkWithTdsTax`, `_chkAcMemb`, `_chkShareHolder` |
| [MS_ADD_MAST](../unified/src/csharp/DataCareNext/MS_ADD_MAST.cs) | 2 | `_tRefAcName`, `_tCustDetl` |
| [MS_AUTO_ITEM](../unified/src/csharp/DataCareNext/MS_AUTO_ITEM.cs) | 5 | `_tGrName`, `_tGrType`, `_tHsnCode`, `_tTradType`, `_tMembAcName` |
| [MS_BOOK](../unified/src/csharp/DataCareNext/MS_BOOK.cs) | 2 | `_tEmpName`, `_tMobileEntry` |
| [MS_COMPANY](../unified/src/csharp/DataCareNext/MS_COMPANY.cs) | 12 | `_tePortalId`, `_teGstNo`, `_tAspId`, `_tUrlPwd`, `_tUrlId`, `_tUrlPath`, `_tLigalName`, `_tTerminalCode`, `_tClientSecret`, `_tUaeClientId`, `_chkResetData`, `_tAcName` |
| [MS_DESIGN_BOOK](../unified/src/csharp/DataCareNext/MS_DESIGN_BOOK.cs) | 3 | `_tEmpName`, `_tHdVchNo`, `_tPrName` |
| [MS_DM](../unified/src/csharp/DataCareNext/MS_DM.cs) | 2 | `_tGrName`, `_tShortName` |
| [MS_EMP](../unified/src/csharp/DataCareNext/MS_EMP.cs) | 1 | `_tEmpAcName` |
| [MS_GOLD_MAST](../unified/src/csharp/DataCareNext/MS_GOLD_MAST.cs) | 1 | `_tBankName` |
| [MS_GROUP](../unified/src/csharp/DataCareNext/MS_GROUP.cs) | 1 | `_chkRateDisplay` |
| [MS_ITEM](../unified/src/csharp/DataCareNext/MS_ITEM.cs) | 11 | `_tPrName`, `_tGrName`, `_tItType`, `_tTradType`, `_cboStkDisplay`, `_chkTagOthDetail`, `_chkOthItmPosting`, `_chkOthItmWtRemove`, `_chkLotStock`, `_chktaxfreeItem`, `_chkAppItem` |
| [MS_LBR_TYPE](../unified/src/csharp/DataCareNext/MS_LBR_TYPE.cs) | 2 | `_tGrName`, `_tPrName` |
| [MS_LOCT](../unified/src/csharp/DataCareNext/MS_LOCT.cs) | 2 | `_tAcName`, `_chkItmDisc` |
| [MS_MEMB](../unified/src/csharp/DataCareNext/MS_MEMB.cs) | 4 | `_tRefAcName`, `_tSchmName`, `_tCustDetl`, `_tEmpName` |
| [MS_OPNCOMP](../unified/src/csharp/DataCareNext/MS_OPNCOMP.cs) | 1 | `_tMonth` |
| [MS_POINT](../unified/src/csharp/DataCareNext/MS_POINT.cs) | 2 | `_tPointCode`, `_TEXT_AC` |
| [MS_PRINT](../unified/src/csharp/DataCareNext/MS_PRINT.cs) | 3 | `_chkOrg`, `_ChkDup`, `_chkTrip` |
| [MS_PRODUCT](../unified/src/csharp/DataCareNext/MS_PRODUCT.cs) | 6 | `_tAcName`, `_tRemark`, `_tPwd`, `_tDataBaseName`, `_tServerIp`, `_tBankName` |
| [MS_RATE](../unified/src/csharp/DataCareNext/MS_RATE.cs) | 2 | `_tEmpCode`, `_tEmpName` |
| [MS_STK_LIMIT](../unified/src/csharp/DataCareNext/MS_STK_LIMIT.cs) | 1 | `_tItName` |
| [MS_TAX](../unified/src/csharp/DataCareNext/MS_TAX.cs) | 2 | `_tTaxAcName`, `_LblInputTaxName` |
| [MS_WINDOW_SET](../unified/src/csharp/DataCareNext/MS_WINDOW_SET.cs) | 1 | `_cboWindowMenu` |
| [RP_ADDRESS](../unified/src/csharp/DataCareNext/RP_ADDRESS.cs) | 13 | `_tAcGrName`, `_tAcName`, `_tLcName`, `_cboState`, `_cboDistrict`, `_cboAdd1`, `_cboAdd3`, `_tMobile`, `_tPhone`, `_nSkipLbl`, `_cboCustGroup`, `_cboPartyName`, `_cboAcType` |
| [RP_ALL](../unified/src/csharp/DataCareNext/RP_ALL.cs) | 7 | `_tBookName`, `_tAcName`, `_tItName`, `_tLcName`, `_tGrName`, `_cboEmploy`, `_cboState` |
| [RP_BALANCE](../unified/src/csharp/DataCareNext/RP_BALANCE.cs) | 1 | `_tLcName` |
| [RP_BAL_ZOOM](../unified/src/csharp/DataCareNext/RP_BAL_ZOOM.cs) | 2 | `_tAcName`, `_tLcName` |
| [RP_BILL_PROFIT](../unified/src/csharp/DataCareNext/RP_BILL_PROFIT.cs) | 4 | `_cboItemTyp`, `_tTagNo`, `_tAcName`, `_cboRptType` |
| [RP_CASH_BANK](../unified/src/csharp/DataCareNext/RP_CASH_BANK.cs) | 3 | `_tAcName`, `_nLineSkip`, `_tBookName` |
| [RP_CONSI_APR](../unified/src/csharp/DataCareNext/RP_CONSI_APR.cs) | 1 | `_tAcName` |
| [RP_CUST_CRM](../unified/src/csharp/DataCareNext/RP_CUST_CRM.cs) | 12 | `_tEmpName`, `_tVchNo`, `_mVchDate`, `_mUpdTime`, `_tUpdateEmpCode`, `_tUpdateEmpName`, `_nIsrNo`, `_nSrNo`, `_tCoYear`, `_tRemCustName`, `_tNewRemark`, `_tMainRemark` |
| [RP_DAY_WORK](../unified/src/csharp/DataCareNext/RP_DAY_WORK.cs) | 1 | `_tAcName` |
| [RP_DHRN_LOAN](../unified/src/csharp/DataCareNext/RP_DHRN_LOAN.cs) | 4 | `_tRefName`, `_tAcName`, `_tLcName`, `_cboLoanType` |
| [RP_DHRN_OS](../unified/src/csharp/DataCareNext/RP_DHRN_OS.cs) | 5 | `_tAcName`, `_cboLoanType`, `_nSlRate`, `_nGlRate`, `_chkOverValue` |
| [RP_EMP](../unified/src/csharp/DataCareNext/RP_EMP.cs) | 5 | `_tAcName`, `_chkVchSum`, `_tBookName`, `_cboCommType`, `_chkItemComm` |
| [RP_GRAPH](../unified/src/csharp/DataCareNext/RP_GRAPH.cs) | 6 | `_cboItemTyp`, `_tGrName`, `_tLcCode`, `_cboSlType`, `_cboBookType`, `_cboTrntype` |
| [RP_GST](../unified/src/csharp/DataCareNext/RP_GST.cs) | 3 | `_tBookName`, `_tAcName`, `_tLcName` |
| [RP_HUID](../unified/src/csharp/DataCareNext/RP_HUID.cs) | 4 | `_cboItemTyp`, `_cboProduct`, `_cboGroup`, `_cboHuId` |
| [RP_INOUT](../unified/src/csharp/DataCareNext/RP_INOUT.cs) | 2 | `_tAcName`, `_tLdrName` |
| [RP_JDTR_ZOOM](../unified/src/csharp/DataCareNext/RP_JDTR_ZOOM.cs) | 2 | `_tDesgnNo`, `_tAcName` |
| [RP_LC_INOUT](../unified/src/csharp/DataCareNext/RP_LC_INOUT.cs) | 1 | `_cboItemTyp` |
| [RP_LC_SALE](../unified/src/csharp/DataCareNext/RP_LC_SALE.cs) | 3 | `_cboItemTyp`, `_tGrName`, `_tPrName` |
| [RP_LEDR](../unified/src/csharp/DataCareNext/RP_LEDR.cs) | 4 | `_tAcName`, `_chkVchSum`, `_cboCrDr`, `_cboFineType` |
| [RP_MFG](../unified/src/csharp/DataCareNext/RP_MFG.cs) | 6 | `_tRefName`, `_tAcName`, `_cboPorcessType`, `_tLcName`, `_tDesignNo`, `_chkPorcessPanding` |
| [RP_MFG_LEDR](../unified/src/csharp/DataCareNext/RP_MFG_LEDR.cs) | 5 | `_tAcName`, `_tBookName`, `_tAcGrCode`, `_tLcCode`, `_tKhataNo` |
| [RP_MFG_ZOOM](../unified/src/csharp/DataCareNext/RP_MFG_ZOOM.cs) | 3 | `_tDesgnNo`, `_tAcName`, `_tKrName` |
| [RP_MOVEMENT](../unified/src/csharp/DataCareNext/RP_MOVEMENT.cs) | 6 | `_cboItemTyp`, `_tGrName`, `_cboMoveType`, `_cboSalesType`, `_cboState`, `_cboCity` |
| [RP_ORDER](../unified/src/csharp/DataCareNext/RP_ORDER.cs) | 1 | `_tAcName` |
| [RP_ORD_TRACK](../unified/src/csharp/DataCareNext/RP_ORD_TRACK.cs) | 5 | `_tAcName`, `_tKrAcName`, `_chkOrdTagStk`, `_tEmpName`, `_tDesignNo` |
| [RP_OS](../unified/src/csharp/DataCareNext/RP_OS.cs) | 6 | `_tRefName`, `_tAcName`, `_tAcGrName`, `_tLcName`, `_nAmount`, `_nBigAmt` |
| [RP_OTH_DETL](../unified/src/csharp/DataCareNext/RP_OTH_DETL.cs) | 8 | `_tBookName`, `_tAcName`, `_tPrName`, `_tLcName`, `_tGrName`, `_cboEmploy`, `_cboState`, `_tItName` |
| [RP_PHY_STOCK](../unified/src/csharp/DataCareNext/RP_PHY_STOCK.cs) | 5 | `_cboItemTyp`, `_cboStockType`, `_cboGroup`, `_tTagNo`, `_cboSize` |
| [RP_ROJMEL](../unified/src/csharp/DataCareNext/RP_ROJMEL.cs) | 1 | `_tLcName` |
| [RP_SLPR_ZOOM](../unified/src/csharp/DataCareNext/RP_SLPR_ZOOM.cs) | 4 | `_cboItemTyp`, `_cboSalesType`, `_chkOnlyTag`, `_tAcName` |
| [RP_STK_LEVEL](../unified/src/csharp/DataCareNext/RP_STK_LEVEL.cs) | 3 | `_tAcName`, `_cboStockType`, `_chkWithAdjSchm` |
| [RP_STK_MOVE](../unified/src/csharp/DataCareNext/RP_STK_MOVE.cs) | 5 | `_cboItemTyp`, `_tGrName`, `_tPrName`, `_tTagNo`, `_tDesignNo` |
| [RP_STOCK](../unified/src/csharp/DataCareNext/RP_STOCK.cs) | 5 | `_cboItemTyp`, `_cboStockType`, `_cboSafe`, `_cboTable`, `_tTagNo` |
| [RP_STOCK_FINE](../unified/src/csharp/DataCareNext/RP_STOCK_FINE.cs) | 3 | `_cboItemTyp`, `_cboStockType`, `_cboGroup` |
| [RP_STOCK_VALUE](../unified/src/csharp/DataCareNext/RP_STOCK_VALUE.cs) | 4 | `_cboItemTyp`, `_cboStockType`, `_cboGroup`, `_cboTable` |
| [RP_TAG](../unified/src/csharp/DataCareNext/RP_TAG.cs) | 6 | `_cboItemTyp`, `_tPrName`, `_tGrName`, `_tItName`, `_cboSize`, `_chkEmpIsuLess` |
| [RP_TAG_ESTMATE](../unified/src/csharp/DataCareNext/RP_TAG_ESTMATE.cs) | 8 | `_mFromDt`, `_mToDt`, `_cboItemTyp`, `_nTotAmt`, `_nTaxAmt`, `_nNetAmt`, `_tPrName`, `_tGrName` |
| [RP_TAG_IMAGE](../unified/src/csharp/DataCareNext/RP_TAG_IMAGE.cs) | 5 | `_mFromDt`, `_mToDt`, `_nTotAmt`, `_nLbrPrc`, `_numDelay` |
| [RP_TAX](../unified/src/csharp/DataCareNext/RP_TAX.cs) | 5 | `_tRefName`, `_tAcName`, `_tLcName`, `_tBookName`, `_tTaxName` |
| [RP_TOUR_ZOOM](../unified/src/csharp/DataCareNext/RP_TOUR_ZOOM.cs) | 6 | `_tDesgnNo`, `_tAcName`, `_chkItmStk`, `_chkOnlyTagStk`, `_tIsuYrCd`, `_tIsuDbCd` |
| [RP_TRADING](../unified/src/csharp/DataCareNext/RP_TRADING.cs) | 3 | `_tSlAcName`, `_tPrAcName`, `_CboTradingType` |
| [RP_USER](../unified/src/csharp/DataCareNext/RP_USER.cs) | 2 | `_tAcName`, `_chkPandingEntry` |
| [TR_AC_OPBL](../unified/src/csharp/DataCareNext/TR_AC_OPBL.cs) | 2 | `_tAcName`, `_tDataType` |
| [TR_APR_ISU](../unified/src/csharp/DataCareNext/TR_APR_ISU.cs) | 8 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_tIsuDbCd`, `_tIsuYrCd`, `_chkWapp` |
| [TR_BILL_TO](../unified/src/csharp/DataCareNext/TR_BILL_TO.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tAcName`, `_tMobileNo`, `_nTotRec`, `_chkWapp` |
| [TR_BUL_BOOKING](../unified/src/csharp/DataCareNext/TR_BUL_BOOKING.cs) | 7 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tToLcName`, `_tToVchNo`, `_tToCoBook` |
| [TR_BUL_SALE](../unified/src/csharp/DataCareNext/TR_BUL_SALE.cs) | 10 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nTotFineCr`, `_nTotFineDr`, `_nDiffFine`, `_chkItmImage`, `_chkHuIdPrint`, `_chkWapp` |
| [TR_CARD_REC](../unified/src/csharp/DataCareNext/TR_CARD_REC.cs) | 16 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nBillAmt`, `_mToDate`, `_tBillNo`, `_tBillYrCd`, `_tBillDbCd`, `_tCardBankName`, `_nBillAdjAmt`, `_mFromDate`, `_nBankNetAmt`, `_nBillOs`, `_nBankComAmt`, `_nCardNetAmt` |
| [TR_CASH](../unified/src/csharp/DataCareNext/TR_CASH.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_CONTRA](../unified/src/csharp/DataCareNext/TR_CONTRA.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_DHRN_INTREC](../unified/src/csharp/DataCareNext/TR_DHRN_INTREC.cs) | 14 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_tRecAcName`, `_nDhrnAdjAmt`, `_nPandingDhrn`, `_nIntMonth`, `_nIntYear`, `_nMonthIntAmt`, `_nPandingDays`, `_nOsAmt` |
| [TR_DHRN_ISU](../unified/src/csharp/DataCareNext/TR_DHRN_ISU.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_tRecAcName`, `_chkWapp` |
| [TR_DHRN_REC](../unified/src/csharp/DataCareNext/TR_DHRN_REC.cs) | 19 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_tRecAcName`, `_nDhrnAdjAmt`, `_nPandingDhrn`, `_nPanIntAmt`, `_nIntMonth`, `_nTotRec`, `_nAdjInt`, `_nAdjDhiran`, `_nIntYear`, `_nAdvanceDhiran`, `_nRcutAmt`, `_nOsAmt`, `_nOrnaAginestDhrn` |
| [TR_EMP_JV](../unified/src/csharp/DataCareNext/TR_EMP_JV.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_FINE_SL_PR](../unified/src/csharp/DataCareNext/TR_FINE_SL_PR.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tAcName`, `_cboItemTyp`, `_tMobileNo`, `_tVchDesc` |
| [TR_FN_INOUT](../unified/src/csharp/DataCareNext/TR_FN_INOUT.cs) | 11 | `_mDay`, `_mTime`, `_tToLcName`, `_tHdVchNo`, `_tEmpName`, `_tFromLcName`, `_tToVchNo`, `_tFromVchNo`, `_tToBook`, `_tFrombook`, `_nPartyFine` |
| [TR_GOLD_BOOK](../unified/src/csharp/DataCareNext/TR_GOLD_BOOK.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_INOUT](../unified/src/csharp/DataCareNext/TR_INOUT.cs) | 10 | `_mDay`, `_mTime`, `_tToLcName`, `_tHdVchNo`, `_tFrmLc`, `_tFromLcName`, `_tToVchNo`, `_tFromVchNo`, `_tToBook`, `_tFrombook` |
| [TR_ITM_LOT](../unified/src/csharp/DataCareNext/TR_ITM_LOT.cs) | 11 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tItName`, `_nPcs`, `_nItNwt`, `_nitGwt`, `_tVchDesc`, `_nLableSkip`, `_tAcName` |
| [TR_JDT_REC](../unified/src/csharp/DataCareNext/TR_JDT_REC.cs) | 6 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_nLableSkip` |
| [TR_KR_ISU](../unified/src/csharp/DataCareNext/TR_KR_ISU.cs) | 7 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tConsiYrCd`, `_tConsiDbCd`, `_chkWapp` |
| [TR_LEDR_ADJ](../unified/src/csharp/DataCareNext/TR_LEDR_ADJ.cs) | 5 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tAcName` |
| [TR_LOCT_AMT](../unified/src/csharp/DataCareNext/TR_LOCT_AMT.cs) | 10 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tFrombook`, `_tToBook`, `_tFromVchNo`, `_tToVchNo`, `_tFromLcName`, `_tToLcName` |
| [TR_MEMB_ADJ](../unified/src/csharp/DataCareNext/TR_MEMB_ADJ.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_MEMB_ENT](../unified/src/csharp/DataCareNext/TR_MEMB_ENT.cs) | 10 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tSchmName`, `_nMembAmt`, `_tSchmType`, `_nLineSkip`, `_chkWapp`, `_nSchmAmt` |
| [TR_MFG_GHAT_REC](../unified/src/csharp/DataCareNext/TR_MFG_GHAT_REC.cs) | 6 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_chkWapp`, `_tItRemark` |
| [TR_MFG_ISU_REC](../unified/src/csharp/DataCareNext/TR_MFG_ISU_REC.cs) | 7 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_nLableSkip`, `_tKrName` |
| [TR_MFG_ITEM](../unified/src/csharp/DataCareNext/TR_MFG_ITEM.cs) | 9 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_nLableSkip`, `_nPcs`, `_nItNwt`, `_nitGwt` |
| [TR_MFG_KR_ISU_REC](../unified/src/csharp/DataCareNext/TR_MFG_KR_ISU_REC.cs) | 9 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_nLableSkip`, `_nPcs`, `_nItNwt`, `_nitGwt` |
| [TR_MFG_ORD_ISU](../unified/src/csharp/DataCareNext/TR_MFG_ORD_ISU.cs) | 6 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_chkWapp` |
| [TR_MFG_ORD_REC](../unified/src/csharp/DataCareNext/TR_MFG_ORD_REC.cs) | 6 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nLableSkip`, `_tKrName` |
| [TR_MFG_WITH_LOT](../unified/src/csharp/DataCareNext/TR_MFG_WITH_LOT.cs) | 9 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_nLableSkip`, `_nPcs`, `_nItNwt`, `_nitGwt` |
| [TR_MLT_PRO](../unified/src/csharp/DataCareNext/TR_MLT_PRO.cs) | 9 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tAcName`, `_nPcs`, `_nItNwt`, `_nitGwt`, `_nAvgTouch` |
| [TR_OTH_COMM](../unified/src/csharp/DataCareNext/TR_OTH_COMM.cs) | 6 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_tAcType` |
| [TR_OTH_PURC](../unified/src/csharp/DataCareNext/TR_OTH_PURC.cs) | 7 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_tAcType`, `_tledrName` |
| [TR_PHYSTK](../unified/src/csharp/DataCareNext/TR_PHYSTK.cs) | 6 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_cboPrintfile`, `_nLableSkip` |
| [TR_PR_SL_HEDG](../unified/src/csharp/DataCareNext/TR_PR_SL_HEDG.cs) | 6 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tAcName`, `_tMobileNo` |
| [TR_PR_SL_UAE](../unified/src/csharp/DataCareNext/TR_PR_SL_UAE.cs) | 11 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nitGwt`, `_nItNwt`, `_chkHalfPrint`, `_nItPcs`, `_tConsiYrCd`, `_tConsiDbCd`, `_cboPrintfile` |
| [TR_PURC](../unified/src/csharp/DataCareNext/TR_PURC.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tSlBill_DbCd`, `_nitGwt`, `_nItNwt`, `_chkWapp` |
| [TR_PURC_HM](../unified/src/csharp/DataCareNext/TR_PURC_HM.cs) | 11 | `_mDay`, `_mTime`, `_TEXT_IDTL`, `_tHdVchNo`, `_tEmpName`, `_tSlBill`, `_tSlBill_DbCd`, `_nitGwt`, `_nItNwt`, `_chkHalfPrint`, `_chkWapp` |
| [TR_REP_REC](../unified/src/csharp/DataCareNext/TR_REP_REC.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_SALE](../unified/src/csharp/DataCareNext/TR_SALE.cs) | 24 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_cboPrintfile`, `_chkHuIdPrint`, `_tTrfrYrCd`, `_tTrfrDbCd`, `_chkWapp`, `_nBillProfit`, `_tPointCode`, `_nUseVal`, `_nBillPoint`, `_nPointBillVal`, `_nPointBal`, `_nPointVal`, `_nPointSlVal`, `_nTotPoint`, `_tRefName`, `_chkBillOrnaIsu`, `_tAcMembName`, `_chkWhoutcommBill` |
| [TR_SALE_HM](../unified/src/csharp/DataCareNext/TR_SALE_HM.cs) | 12 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_cboPrintfile`, `_chkHuIdPrint`, `_tTrfrYrCd`, `_tTrfrDbCd`, `_chkWapp`, `_chkRateUnFix` |
| [TR_SALE_LBR](../unified/src/csharp/DataCareNext/TR_SALE_LBR.cs) | 10 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nTotWtCr`, `_nTotWtDr`, `_nOrdWt`, `_nItmRate`, `_chkWapp`, `_nBillProfit` |
| [TR_SALE_ORD](../unified/src/csharp/DataCareNext/TR_SALE_ORD.cs) | 5 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_chkWapp` |
| [TR_SALE_RTN](../unified/src/csharp/DataCareNext/TR_SALE_RTN.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_nAcCrAmt`, `_nAcDrAmt` |
| [TR_SALE_RTN_UAE](../unified/src/csharp/DataCareNext/TR_SALE_RTN_UAE.cs) | 9 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuYrCd`, `_tIsuDbCd`, `_cboPrintfile`, `_chkWapp`, `_chkRateUnFix` |
| [TR_SL_EBILL](../unified/src/csharp/DataCareNext/TR_SL_EBILL.cs) | 13 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_tAcType`, `_TxtBoxError`, `_tTokan`, `_tBoxResponce`, `_mAckDt`, `_tAckNo`, `_tIrnNo`, `_tldrname` |
| [TR_SL_ORD_ADJ](../unified/src/csharp/DataCareNext/TR_SL_ORD_ADJ.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_SL_PR_ITEM](../unified/src/csharp/DataCareNext/TR_SL_PR_ITEM.cs) | 8 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_tAcType`, `_cboPrintfile`, `_chkWapp` |
| [TR_TAG_CAN](../unified/src/csharp/DataCareNext/TR_TAG_CAN.cs) | 5 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName` |
| [TR_TAG_OPBL](../unified/src/csharp/DataCareNext/TR_TAG_OPBL.cs) | 12 | `_mDay`, `_mTime`, `_cboPrintfile`, `_tItName`, `_tEmpName`, `_nItNwt`, `_nitGwt`, `_nPcs`, `_tHdVchNo`, `_cboPrintType`, `_nLotTouch`, `_nLotWestPrc` |
| [TR_TAG_SPLIT](../unified/src/csharp/DataCareNext/TR_TAG_SPLIT.cs) | 6 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_cboPrintfile`, `_nLableSkip` |
| [TR_TAG_WT_DIFF](../unified/src/csharp/DataCareNext/TR_TAG_WT_DIFF.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nTotWtCr`, `_nTotWtDr`, `_cboPrintfile`, `_nLableSkip` |
| [TR_TOUR](../unified/src/csharp/DataCareNext/TR_TOUR.cs) | 6 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_tIsuDbCd`, `_tIsuYrCd` |
| [TR_TOUR_ORD](../unified/src/csharp/DataCareNext/TR_TOUR_ORD.cs) | 5 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_chkWapp` |
| [TR_TOUR_SALE](../unified/src/csharp/DataCareNext/TR_TOUR_SALE.cs) | 14 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nTotFineCr`, `_nTotFineDr`, `_nDiffFine`, `_chkItmImage`, `_chkHuIdPrint`, `_chkWapp`, `_nBillProfit`, `_nSlvrFinOs`, `_nTotSilverDr`, `_nTotSilverCr` |
| [TR_UPI_REC](../unified/src/csharp/DataCareNext/TR_UPI_REC.cs) | 8 | `_tVchNo`, `_mTime`, `_mVchDate`, `_tAcCode`, `_tAcName`, `_tCoBook`, `_nUpiTotAmt`, `_nbillOsAmt` |
| [TR_VP](../unified/src/csharp/DataCareNext/TR_VP.cs) | 6 | `_mDay`, `_mTime`, `_tAcName`, `_tHdVchNo`, `_tEmpName`, `_tAngdiyaAcName` |
| [TR_VP_ADJ](../unified/src/csharp/DataCareNext/TR_VP_ADJ.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [TR_WH_SALE](../unified/src/csharp/DataCareNext/TR_WH_SALE.cs) | 16 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName`, `_nTotFineCr`, `_nTotFineDr`, `_nDiffFine`, `_tIsuYrCd`, `_tIsuDbCd`, `_chkItmImage`, `_chkHuIdPrint`, `_chkWapp`, `_nSlvrFinOs`, `_nTotSilverDr`, `_nTotSilverCr`, `_cboPrintfile` |
| [TR_WH_SALE_RTN](../unified/src/csharp/DataCareNext/TR_WH_SALE_RTN.cs) | 8 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tSlBill_DbCd`, `_nitGwt`, `_nItNwt`, `_tSlBillYrCd`, `_tEmpName` |
| [UT_AI_TRFR](../unified/src/csharp/DataCareNext/UT_AI_TRFR.cs) | 3 | `_tftpPwd`, `_tFtpId`, `_tFtpPath` |
| [UT_BANK](../unified/src/csharp/DataCareNext/UT_BANK.cs) | 1 | `_tAcName` |
| [UT_BKP](../unified/src/csharp/DataCareNext/UT_BKP.cs) | 1 | `_tSavePath` |
| [UT_CUST_ENTRY](../unified/src/csharp/DataCareNext/UT_CUST_ENTRY.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [UT_HDD](../unified/src/csharp/DataCareNext/UT_HDD.cs) | 2 | `_tSrNo1`, `_tSrNo2` |
| [UT_PWD_UPDATE](../unified/src/csharp/DataCareNext/UT_PWD_UPDATE.cs) | 5 | `_tSrNo1`, `_tSrNo2`, `_tConPasword`, `_tPasword`, `_tUserName` |
| [UT_REMINDER](../unified/src/csharp/DataCareNext/UT_REMINDER.cs) | 4 | `_mDay`, `_mTime`, `_tHdVchNo`, `_tEmpName` |
| [UT_SETTING](../unified/src/csharp/DataCareNext/UT_SETTING.cs) | 25 | `_cboLbrType`, `_cboRateType`, `_cboTaxRof`, `_cboTagRowChange`, `_cbolbrRateGen`, `_cboRateOpen`, `_cboOpDhrn`, `_cboDhrnType`, `_cboHelpSearch`, `_cboLdrSumm`, `_cboReminder`, `_cbolbrrof`, `_cboSlRateRof`, `_cboPurcLbr`, `_cboStkRptType`, `_cboWhTch`, `_cboPanCardVal`, `_cboDhrnIntPrc`, `_cboDupPrint`, `_cboPurcAc`, `_cboOpLoan`, `_cboOzCon`, `_cboFxRate`, `_cboFxCode`, `_cboPrintZoom` |
| [UT_SETTING_MAIN](../unified/src/csharp/DataCareNext/UT_SETTING_MAIN.cs) | 53 | `_cboQrCode`, `_cboCustOsSms`, `_cboLoanIntType`, `_cboSalesImagPrint`, `_cboTotFineStkType`, `_cboBalSheetType`, `_cboPrRateRof`, `_cboAdminSms`, `_cboCustSms`, `_cboCountryid`, `_cboWappSlPrint`, `_cboDesignGen`, `_cboOrdImage`, `_cboOrnaIsu`, `_cboMobileSearch`, `_cboPrintFormSet`, `_cboEmpMandatory`, `_cboFontStyle`, `_CboFontName`, `_cboFontSize`, `_cboFontChange`, `_cboGridRowHeight`, `_cboPreviousLock`, `_cboCashLimit`, `_cboBilTotRof`, `_cboScorlbar`, `_cboStkRptType`, `_cboTagSaleWtDiff`, `_cboEstmateWithTax`, `_cboTagRowSave`, `_cboTagRowPrint`, `_cboSchmWapp`, `_cboDhrnWapp`, `_cboRptTotShow`, `_cboReminderType`, `_cboHelpLent`, `_cboOrdTagStkLess`, `_cboAllBrancAcShow`, `_cboEmpAsUser`, `_cboImgWithWt`, `_cboDhrnImgPrint`, `_cboLbrWitGht`, `_cboAprlImg`, `_cboOthItmWtRemove`, `_cboSilverLedr3digit`, `_cboWhSaleImg`, `_cboitmWithLotStk`, `_cboFineStkType`, `_cboStkRefresh`, `_cboMainFontChange`, `_cboPurRateWith`, `_cboSlRateWith`, `_cboCrystalViewType` |
| [UT_SET_ADMIN](../unified/src/csharp/DataCareNext/UT_SET_ADMIN.cs) | 11 | `_cboCounterStk`, `_cboEstmatBank`, `_cboOldPurcTch`, `_cboNegativeStk`, `_cboSlNwtLock`, `_cbobillprofit`, `_cboPurcLot`, `_cboSlYearSale`, `_cboGlYearSale`, `_cboKrTouchHide`, `_cboStklimitWithDesign` |
| [UT_SMS](../unified/src/csharp/DataCareNext/UT_SMS.cs) | 7 | `_tMobileNo`, `_tsmstype`, `_ChkOnlyMoNo`, `_cboAcGroup`, `_TxtUniCode`, `__comboFrom`, `__comboTo` |
| [UT_TAG_PRINT](../unified/src/csharp/DataCareNext/UT_TAG_PRINT.cs) | 8 | `_tBookName`, `_tHdVchNo`, `_cboPrintfile`, `_nLableSkip`, `_tGrName`, `_tPrName`, `_cboItemTyp`, `_cboPrintType` |
| [UT_USER_REQUEST](../unified/src/csharp/DataCareNext/UT_USER_REQUEST.cs) | 3 | `_RadioDelete`, `_RadioEdit`, `_tItDesc` |
| [UT_VCH_RE_NUMBR](../unified/src/csharp/DataCareNext/UT_VCH_RE_NUMBR.cs) | 1 | `_tBookName` |
| [UT_WAPP_WITH_API](../unified/src/csharp/DataCareNext/UT_WAPP_WITH_API.cs) | 7 | `_ChkOnlyMoNo`, `_cboAcGroup`, `_txtFinalPreview`, `_tCountryCode`, `_cboArea`, `_cboCity`, `_txtPreview` |
| [UT_WHATSAPP](../unified/src/csharp/DataCareNext/UT_WHATSAPP.cs) | 12 | `_tsmstype`, `_ChkOnlyMoNo`, `_cboAcGroup`, `_TxtUniCode`, `__comboFrom`, `__comboTo`, `_numDelay`, `_tBoxAttach`, `_tMsg`, `_tCountryCode`, `_cboArea`, `_cboCity` |

## Remaining coverage limits

43 named-grid requirement records still lack a direct literal source-line match. Event-name extraction does not establish each handler’s internal decisions, dynamically selected actions, non-void/async helpers or complete write sets. Resource-driven controls, inherited components, SQL routines, templates and external services require source/runtime reconciliation. Passing this supplement’s structural checks does not discharge those obligations.

