using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[StandardModule]
internal sealed class Module_Schm
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__14_002D0
	{
		public string _0024VB_0024Local_LocalMasterReset;

		public string _0024VB_0024Local_DcConStr;

		public string _0024VB_0024Local_McConStr;

		public string _0024VB_0024Local_LocalCoYear;

		public bool _0024VB_0024Local_LocalImgOpen;

		public string _0024VB_0024Local_LocalRegSrNo;

		public string _0024VB_0024Local_LocalCoCode;

		public string _0024VB_0024Local_LocalLcCode;

		public string _0024VB_0024Local_LocalMfgType;

		public _Closure_0024__14_002D0(_Closure_0024__14_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_LocalMasterReset = arg0._0024VB_0024Local_LocalMasterReset;
				_0024VB_0024Local_DcConStr = arg0._0024VB_0024Local_DcConStr;
				_0024VB_0024Local_McConStr = arg0._0024VB_0024Local_McConStr;
				_0024VB_0024Local_LocalCoYear = arg0._0024VB_0024Local_LocalCoYear;
				_0024VB_0024Local_LocalImgOpen = arg0._0024VB_0024Local_LocalImgOpen;
				_0024VB_0024Local_LocalRegSrNo = arg0._0024VB_0024Local_LocalRegSrNo;
				_0024VB_0024Local_LocalCoCode = arg0._0024VB_0024Local_LocalCoCode;
				_0024VB_0024Local_LocalLcCode = arg0._0024VB_0024Local_LocalLcCode;
				_0024VB_0024Local_LocalMfgType = arg0._0024VB_0024Local_LocalMfgType;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			string text = "";
			checked
			{
				int i;
				if (Operators.CompareString(_0024VB_0024Local_LocalMasterReset, "Y", false) == 0)
				{
					string text2 = "";
					text = "SELECT CO_CODE FROM CO_MAST WHERE RTGS_TYPE = 'Y'";
					DataTable dataTable = RunDcSelect(_0024VB_0024Local_DcConStr, text);
					if (dataTable.Rows.Count > 0)
					{
						int num = dataTable.Rows.Count - 1;
						for (i = 0; i <= num; i++)
						{
							text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.AddObject((object)(text2 + "'"), dataTable.Rows[i]["CO_CODE"]), (object)"',"));
						}
						text2 = Strings.Mid(text2, 1, Strings.Len(text2) - 1);
					}
					if (Operators.CompareString(text2, "", false) != 0)
					{
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM AC_MAST_SRNO WHERE CO_CODE IN (" + text2 + ")");
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM LOCT_MAST WHERE CO_CODE IN (" + text2 + ") AND LC_CODE <> '00'");
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM LOGIN_MAST WHERE CO_CODE  IN (" + text2 + ") AND LOGIN_NAME <> 'ABC' ");
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM USER_SET WHERE CO_CODE  IN (" + text2 + ") AND USER_NAME <> 'ABC'");
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM YEAR_MAST WHERE CO_CODE  IN (" + text2 + ") AND CO_YEAR <> '" + _0024VB_0024Local_LocalCoYear + "'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE AC_GROUP SET USER_SHOW_GROUP = 'Y' WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_MAST WHERE CO_CODE  IN (" + text2 + ") AND CAST(AC_CODE AS INT) > 99");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AD_ADJ WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AD_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AD_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AD_MEMB WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AD_OS WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ADD_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM APR_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM APR_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM APR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAL_GR WHERE CO_CODE  IN (" + text2 + ") AND CAST(SALE_AC AS INT) > 7 ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BANK_RECONCILE WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAR_CAN_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAR_CAN_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAR_CAN_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAR_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAR_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BAR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BILL_OS_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE BOOK_DETL SET AC_CODE = '00075' WHERE CO_CODE  IN (" + text2 + ") AND CO_BOOK IN('005','006','007','008','009','010','011','012','013','014') AND SR_NO = 1");
						RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE BOOK_IDTL SET AC_CODE = 0 WHERE MAIN_BOOK = 'PURC RETURN' AND SR_NO = 5");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM BUL_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CARD_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CASH_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CO_MAST WHERE CO_CODE  IN (" + text2 + ") AND CO_CODE <> '01'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM COL_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE CO_SET SET VB_IMPORT = 'N' WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CONTRA_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE CONV_MAST SET GOLD_CONV = 1.0573,SILVER_CONV = 1.022 WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CRNT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CUT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CUT_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CUT_STK_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DELETE_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DESIGN_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DESIGN_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DESIGN_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DHRN_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DHRN_ISU_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DHRN_ISU_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DHRN_REC_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DHRN_REC_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DM_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DM_KR_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DM_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM DM_SIZE WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM EMP_MAST WHERE CO_CODE  IN (" + text2 + ") AND EMP_CODE <> '001'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM EMP_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM FINE_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM GROUP_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM IMAGE_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM INOUT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM INOUT_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM INOUT_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ITEM_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ITM_CITY WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ITM_LOT_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ITM_OPBL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ITM_WT_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM KR_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM KR_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM KR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LBR_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LBR_ISU_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LBR_ISU_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LBR_REC_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LBR_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LDR_ADJ_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LEDR_AC_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LOCT_AMT WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LOCT_MAST WHERE CO_CODE  IN (" + text2 + ") AND LC_CODE <> '00'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE LOCT_MAST SET TRY_DATE = NULL");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LOGIN_MAST WHERE CO_CODE  IN (" + text2 + ") AND LOGIN_NAME <> 'ABC'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM LOT_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MSG_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MFG_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MFG_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MFG_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MFG_ISU_REC WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MFG_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MLT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MLT_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MODEL_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM OP_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM OP_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM OP_LDR WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PAY_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PAY_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM POINT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM POINT_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM POINT_MEMB WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PRODUCT_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_ISU WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_ISU_REC ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_REC WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM RATE_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM REM_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM REP_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM REP_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM REPORT_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ROJMEL_BAL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL_RTN WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_ADJ WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_IDTL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_PR_DETL WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SRNO_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TABLE_MAST WHERE CO_CODE  IN (" + text2 + ") AND TABLE_CODE <> '001'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TAG_PRINT_DATA");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TAG_SET WHERE CO_CODE  IN (" + text2 + ") ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TAG_STOCK_PRINT ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TAX_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TOUCH_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM USER_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TEMP_AD_DATA");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM TEMP_ADD");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM UPI_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM USER_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM USER_REQUEST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM VP_ADJ_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM WEB_DATA WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM YEAR_MAST WHERE CO_CODE  IN (" + text2 + ") AND CO_YEAR <> '" + _0024VB_0024Local_LocalCoYear + "'");
						if (_0024VB_0024Local_LocalImgOpen)
						{
							DC_Main.ExeQuteImg("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE  IN (" + text2 + ")");
						}
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM CO_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM CO_MAST WHERE CO_CODE  IN (" + text2 + ")");
						RunMcQuery(_0024VB_0024Local_McConStr, "DELETE FROM YEAR_MAST WHERE CO_CODE  IN (" + text2 + ")");
					}
					return;
				}
				if (Operators.CompareString(_0024VB_0024Local_LocalRegSrNo, "HM530NEHP", false) == 0)
				{
					RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE CO_MAST SET HTTP_NAME = ''");
					RunMcQuery(_0024VB_0024Local_McConStr, "UPDATE CO_MAST SET HTTP_NAME = ''");
					if ((Operators.CompareString(_0024VB_0024Local_LocalCoYear, "2025-2026", false) == 0) & (Operators.CompareString(_0024VB_0024Local_LocalCoCode, "01", false) == 0))
					{
						return;
					}
					if (((Operators.CompareString(_0024VB_0024Local_LocalCoYear, "2024-2025", false) == 0) & (Operators.CompareString(_0024VB_0024Local_LocalCoCode, "01", false) == 0)) | (Operators.CompareString(_0024VB_0024Local_LocalCoCode, "02", false) == 0) | (Operators.CompareString(_0024VB_0024Local_LocalCoCode, "03", false) == 0))
					{
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_DETL WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL WHERE CO_CODE = '04' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_DATA WHERE CO_CODE = '05' AND CO_YEAR = '2024-2025'");
						RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM PR_DETL WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
					}
				}
				RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE BOOK_DATA SET CUR_USE = 'N' WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND BOOK_TYPE = 'M'");
				RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE BOOK_DATA SET CUR_USE = 'N' WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND BOOK_TYPE = 'F'");
				RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM OP_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND DATA_TYPE  = 'B'");
				RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND DATA_TYPE  = 'B'");
				RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND DATA_TYPE  = 'B'");
				RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND FINE_WT  <> 0");
				RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE OP_DATA SET FINE_BAL = 0 WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' ");
				RunDcQuery(_0024VB_0024Local_DcConStr, "UPDATE OP_DATA SET SL_FINE_BAL = 0 WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' ");
				RunDcQuery(_0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_BOOK = '000'");
				Ac_Ledr.AcOp_Ledr("", "");
				text = "SELECT A.* FROM SL_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				DataTable dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text);
				for (i = 0; i < dataTable2.Rows.Count; i++)
				{
					text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TAG_NO,VCH_SRNO FROM SL_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					DataTable dataTable3 = RunDcSelect(_0024VB_0024Local_DcConStr, text);
					for (int j = 0; j < dataTable3.Rows.Count; j++)
					{
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND TAG_NO = '"), dataTable3.Rows[j]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable3.Rows[j]["VCH_SRNO"]), (object)" ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND TAG_NO = '"), dataTable3.Rows[j]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable3.Rows[j]["VCH_SRNO"]), (object)" ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND TAG_NO = '"), dataTable3.Rows[j]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable3.Rows[j]["VCH_SRNO"]), (object)" ")));
					}
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM PR_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM KR_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_IDTL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM RATE_CUT_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM CONTRA_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND  B.DATA_TYPE  = 'B' ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
				}
				i = 0;
				text = "SELECT A.* FROM CASH_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND  B.DATA_TYPE  = 'B' ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CASH_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
				}
				if ((Operators.CompareString(_0024VB_0024Local_LocalMfgType, "J", false) == 0) | (Operators.CompareString(_0024VB_0024Local_LocalMfgType, "M", false) == 0))
				{
					i = 0;
					text = "SELECT A.* FROM MFG_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
					for (dataTable2 = RunDcSelect(_0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
					{
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MFG_DATA WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MFG_DETL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(_0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + _0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + _0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					}
				}
			}
		}
	}

	public static bool SchmClickTrfr = false;

	public static string SchmServerIp = "";

	public static string SchmServerPwd = "";

	public static string SchmServerDb = "";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bgWorker")]
	private static BackgroundWorker _bgWorker;

	public static BackgroundWorker bgWorker
	{
		[CompilerGenerated]
		get
		{
			return _bgWorker;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoWorkEventHandler value2 = bgWorker_DoWork;
			BackgroundWorker backgroundWorker = _bgWorker;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork -= value2;
			}
			_bgWorker = value;
			backgroundWorker = _bgWorker;
			if (backgroundWorker != null)
			{
				backgroundWorker.DoWork += value2;
			}
		}
	}

	static Module_Schm()
	{
		bgWorker = new BackgroundWorker();
	}

	public static void bgWorker_DoWork(object sender, DoWorkEventArgs e)
	{
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Expected O, but got Unknown
		//IL_1d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Expected O, but got Unknown
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Expected O, but got Unknown
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		bgWorker.WorkerReportsProgress = true;
		bgWorker.WorkerSupportsCancellation = true;
		if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				SchmServerIp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
				SchmServerPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
				SchmServerDb = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			}
		}
		string text = ("Data Source=" + SchmServerIp + ";Initial Catalog=" + SchmServerDb + ";Persist Security Info=True;User ID=sa;Password=" + SchmServerPwd) ?? "";
		string text2 = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + DC_Main.SqlData + ";Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
		List<(string, string, string, string)> list = new List<(string, string, string, string)>();
		try
		{
			SqlConnection val = new SqlConnection(text);
			try
			{
				SqlConnection val2 = new SqlConnection(text2);
				try
				{
					val.Open();
					val2.Open();
					SqlTransaction val3 = val.BeginTransaction();
					SqlTransaction val4 = val2.BeginTransaction();
					try
					{
						SqlCommand val5 = new SqlCommand("SELECT * FROM AD_MEMB WHERE CO_CODE = @CO_CODE AND DATA_TRFR = 'N'", val, val3);
						val5.Parameters.AddWithValue("@CO_CODE", (object)DC_Main.MCo_code);
						SqlDataReader val6 = val5.ExecuteReader();
						while (val6.Read())
						{
							SqlCommand val7 = new SqlCommand("DELETE FROM AD_MEMB WHERE CO_CODE = @CO_CODE AND LC_CODE = @LC_CODE AND SCHM_CODE = @SCHM_CODE AND MEMB_CODE = @MEMB_CODE", val2, val4);
							val7.Parameters.AddWithValue("@CO_CODE", RuntimeHelpers.GetObjectValue(val6["CO_CODE"]));
							val7.Parameters.AddWithValue("@LC_CODE", RuntimeHelpers.GetObjectValue(val6["LC_CODE"]));
							val7.Parameters.AddWithValue("@SCHM_CODE", RuntimeHelpers.GetObjectValue(val6["SCHM_CODE"]));
							val7.Parameters.AddWithValue("@MEMB_CODE", RuntimeHelpers.GetObjectValue(val6["MEMB_CODE"]));
							val7.ExecuteNonQuery();
							SqlCommand val8 = new SqlCommand("INSERT INTO AD_MEMB(CO_CODE,LC_CODE,SCHM_CODE,MEMB_CODE,MEMB_NAME,MEMB_AMT, ITM_GWT,EMP_CODE,AC_PHONE,AC_MOBILE,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_AREA,AC_MOBILE2,AC_PHONE2, ID_PROF,NOMINEE_NAME,AC_EMAIL,AC_DISTRICT,BIRTH_DATE,ANV_DATE,L_BR_DATE,JOIN_DATE,EXP_DATE,BANK_NAME, BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,AC_REF_CODE,SCHM_SHORT,MEMB_BONUS,DATA_TRFR,MAIN_USER) VALUES (@CO_CODE,@LC_CODE,@SCHM_CODE,@MEMB_CODE,@MEMB_NAME,@MEMB_AMT, @ITM_GWT,@EMP_CODE,@AC_PHONE,@AC_MOBILE,@AC_ADD1,@AC_ADD2,@AC_ADD3,@AC_CITY,@AC_PIN,@AC_AREA,@AC_MOBILE2,@AC_PHONE2, @ID_PROF,@NOMINEE_NAME,@AC_EMAIL,@AC_DISTRICT,@BIRTH_DATE,@ANV_DATE,@L_BR_DATE,@JOIN_DATE,@EXP_DATE,@BANK_NAME, @BANK_AREA,@BANK_AC_NO,@BANK_RTGS_NO,@AC_REF_CODE,@SCHM_SHORT,@MEMB_BONUS,@DATA_TRFR,@MAIN_USER)", val2, val4);
							string[] array = new string[36]
							{
								"CO_CODE", "LC_CODE", "SCHM_CODE", "MEMB_CODE", "MEMB_NAME", "MEMB_AMT", "ITM_GWT", "EMP_CODE", "AC_PHONE", "AC_MOBILE",
								"AC_ADD1", "AC_ADD2", "AC_ADD3", "AC_CITY", "AC_PIN", "AC_AREA", "AC_MOBILE2", "AC_PHONE2", "ID_PROF", "NOMINEE_NAME",
								"AC_EMAIL", "AC_DISTRICT", "BIRTH_DATE", "ANV_DATE", "L_BR_DATE", "JOIN_DATE", "EXP_DATE", "BANK_NAME", "BANK_AREA", "BANK_AC_NO",
								"BANK_RTGS_NO", "AC_REF_CODE", "SCHM_SHORT", "MEMB_BONUS", "DATA_TRFR", "MAIN_USER"
							};
							foreach (string text3 in array)
							{
								val8.Parameters.AddWithValue("@" + text3, RuntimeHelpers.GetObjectValue(val6[text3]));
							}
							val8.ExecuteNonQuery();
							list.Add((val6["CO_CODE"].ToString(), val6["LC_CODE"].ToString(), val6["SCHM_CODE"].ToString(), val6["MEMB_CODE"].ToString()));
						}
						val6.Close();
						foreach (var item in list)
						{
							SqlCommand val9 = new SqlCommand("UPDATE AD_MEMB SET DATA_TRFR = 'Y' WHERE CO_CODE = @CO_CODE AND LC_CODE = @LC_CODE AND SCHM_CODE = @SCHM_CODE AND MEMB_CODE = @MEMB_CODE", val, val3);
							val9.Parameters.AddWithValue("@CO_CODE", (object)item.Item1);
							val9.Parameters.AddWithValue("@LC_CODE", (object)item.Item2);
							val9.Parameters.AddWithValue("@SCHM_CODE", (object)item.Item3);
							val9.Parameters.AddWithValue("@MEMB_CODE", (object)item.Item4);
							val9.ExecuteNonQuery();
						}
						val4.Commit();
						val3.Commit();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val4.Rollback();
						val3.Rollback();
						MessageBox.Show("Error occurred during transaction: " + ex2.Message);
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			MessageBox.Show("Connection/Execution Error: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
		List<(string, string, string, string, string, string)> list2 = new List<(string, string, string, string, string, string)>();
		try
		{
			SqlConnection val10 = new SqlConnection(text);
			try
			{
				SqlConnection val11 = new SqlConnection(text2);
				try
				{
					val10.Open();
					val11.Open();
					SqlTransaction val12 = val10.BeginTransaction();
					SqlTransaction val13 = val11.BeginTransaction();
					try
					{
						SqlCommand val14 = new SqlCommand("SELECT * FROM AD_DATA WHERE CO_CODE = @CO_CODE AND DATA_TRFR = 'N'", val10, val12);
						val14.Parameters.AddWithValue("@CO_CODE", (object)DC_Main.MCo_code);
						SqlDataReader val15 = val14.ExecuteReader();
						while (val15.Read())
						{
							SqlCommand val16 = new SqlCommand("DELETE FROM AD_DATA WHERE CO_CODE = @CO_CODE AND LC_CODE = @LC_CODE AND CO_YEAR = @CO_YEAR AND CO_BOOK = @CO_BOOK AND VCH_NO = @VCH_NO AND SR_NO = @SR_NO", val11, val13);
							val16.Parameters.AddWithValue("@CO_CODE", RuntimeHelpers.GetObjectValue(val15["CO_CODE"]));
							val16.Parameters.AddWithValue("@LC_CODE", RuntimeHelpers.GetObjectValue(val15["LC_CODE"]));
							val16.Parameters.AddWithValue("@CO_YEAR", RuntimeHelpers.GetObjectValue(val15["CO_YEAR"]));
							val16.Parameters.AddWithValue("@CO_BOOK", RuntimeHelpers.GetObjectValue(val15["CO_BOOK"]));
							val16.Parameters.AddWithValue("@VCH_NO", RuntimeHelpers.GetObjectValue(val15["VCH_NO"]));
							val16.Parameters.AddWithValue("@SR_NO", RuntimeHelpers.GetObjectValue(val15["SR_NO"]));
							val16.ExecuteNonQuery();
							SqlCommand val17 = new SqlCommand("INSERT INTO AD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_CODE,SCHM_DATE,MEMB_CODE,MEMB_AMT,TOT_AMT,IT_DESC,MONTH_CODE,EMP_CODE,ENT_TYPE,REC_AC,ITM_GWT,ITM_RATE,BANK_NAME,CHQ_NO,ENTRY_TIME,HD_VCH_NO,MAIN_USER,DATA_TRFR,VCH_TIME,VCH_TYPE,INOUT_TYPE,BOOK_NAME,USER_UPDATE,USER_DELETE,WITH_UPI,UPI_NAME) VALUES (@CO_CODE,@LC_CODE,@CO_YEAR,@CO_BOOK,@VCH_NO,@SR_NO,@VCH_DATE,@SCHM_CODE,@SCHM_DATE,@MEMB_CODE,@MEMB_AMT,@TOT_AMT,@IT_DESC,@MONTH_CODE,@EMP_CODE,@ENT_TYPE,@REC_AC,@ITM_GWT,@ITM_RATE,@BANK_NAME,@CHQ_NO,@ENTRY_TIME,@HD_VCH_NO,@MAIN_USER,@DATA_TRFR,@VCH_TIME,@VCH_TYPE,@INOUT_TYPE,@BOOK_NAME,@USER_UPDATE,@USER_DELETE,@WITH_UPI,@UPI_NAME)", val11, val13);
							string[] array2 = new string[33]
							{
								"CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO", "SR_NO", "VCH_DATE", "SCHM_CODE", "SCHM_DATE", "MEMB_CODE",
								"MEMB_AMT", "TOT_AMT", "IT_DESC", "MONTH_CODE", "EMP_CODE", "ENT_TYPE", "REC_AC", "ITM_GWT", "ITM_RATE", "BANK_NAME",
								"CHQ_NO", "ENTRY_TIME", "HD_VCH_NO", "MAIN_USER", "DATA_TRFR", "VCH_TIME", "VCH_TYPE", "INOUT_TYPE", "BOOK_NAME", "USER_UPDATE",
								"USER_DELETE", "WITH_UPI", "UPI_NAME"
							};
							foreach (string text4 in array2)
							{
								val17.Parameters.AddWithValue("@" + text4, RuntimeHelpers.GetObjectValue(val15[text4]));
							}
							val17.ExecuteNonQuery();
							list2.Add((val15["CO_CODE"].ToString(), val15["LC_CODE"].ToString(), val15["CO_YEAR"].ToString(), val15["CO_BOOK"].ToString(), val15["VCH_NO"].ToString(), val15["SR_NO"].ToString()));
						}
						val15.Close();
						foreach (var item2 in list2)
						{
							SqlCommand val18 = new SqlCommand("UPDATE AD_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = @CO_CODE AND LC_CODE = @LC_CODE AND CO_YEAR = @CO_YEAR AND CO_BOOK = @CO_BOOK AND VCH_NO = @VCH_NO AND SR_NO = @SR_NO", val10, val12);
							val18.Parameters.AddWithValue("@CO_CODE", (object)item2.Item1);
							val18.Parameters.AddWithValue("@LC_CODE", (object)item2.Item2);
							val18.Parameters.AddWithValue("@CO_YEAR", (object)item2.Item3);
							val18.Parameters.AddWithValue("@CO_BOOK", (object)item2.Item4);
							val18.Parameters.AddWithValue("@VCH_NO", (object)item2.Item5);
							val18.Parameters.AddWithValue("@SR_NO", (object)item2.Item6);
							val18.ExecuteNonQuery();
						}
						val13.Commit();
						val12.Commit();
						foreach (var item3 in list2)
						{
							DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + item3.Item4 + "' AND  VCH_NO = '" + item3.Item5 + "' ");
							Ac_Tax.SchemeEnt_Os(item3.Item4, item3.Item5);
							DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + item3.Item4 + "' AND VCH_NO = '" + item3.Item5 + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Ledr.Schm_Ledr(item3.Item4, item3.Item5);
							DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + item3.Item4 + "' AND VCH_NO = '" + item3.Item5 + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Rojmel.Schm_RojMel(item3.Item4, item3.Item5);
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						val13.Rollback();
						val12.Rollback();
						MessageBox.Show("Error occurred during transaction: " + ex6.Message);
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val11)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val10)?.Dispose();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			MessageBox.Show("Connection/Execution Error: " + ex8.Message);
			ProjectData.ClearProjectError();
		}
		checked
		{
			if (Operators.CompareString(DC_Main.MsAppDgGold, "Y", false) == 0)
			{
				Application.DoEvents();
				DC_Main.Scm.ConnectionString = ("Data Source=" + SchmServerIp + ";Initial Catalog=" + SchmServerDb + ";Persist Security Info=True;User ID=sa;Password=" + SchmServerPwd) ?? "";
				DC_Main.RsQry = "SELECT * FROM APP_USER_DATA WHERE AC_ADD1 <> '' AND DATA_TRFR = 'N'";
				DataTable dataTable = DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				DC_Main.M = 0;
				string text5 = "00201";
				while (DC_Main.M < dataTable.Rows.Count)
				{
					DataTable dataTable2 = dataTable;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MOBILE = '"), dataTable2.Rows[DC_Main.M]["MEMB_NUMBER"]), (object)"'"));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
						{
							DC_Main.RsQry = "SELECT MAX(AC_CODE) As LAST_AC_CODE,RIGHT('00000' + CAST(ISNULL(CAST(MAX(AC_CODE) AS INT), 0) + 1 AS VARCHAR(10)), 5) AS NEXT_AC_CODE  FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
							DataTable dataTable3 = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0)
							{
								text5 = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["NEXT_AC_CODE"], (object)""));
							}
						}
						else
						{
							DC_Main.RsQry = "SELECT MAX(AC_CODE) As LAST_AC_CODE,RIGHT('000000' + CAST(ISNULL(CAST(MAX(AC_CODE) AS INT), 0) + 1 AS VARCHAR(10)), 6) AS NEXT_AC_CODE  FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
							DataTable dataTable3 = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0)
							{
								text5 = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["NEXT_AC_CODE"], (object)""));
							}
						}
						string text6 = "INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_PERSON,AC_ADD1,AC_ADD2,  AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_PHONE2,AC_MOBILE,AC_MOBILE2,AC_EMAIL,  AC_GSTNO,AC_GST_TYPE,AC_PANNO,AC_REF_CODE,AC_KHATA_NO,BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,DPC_PRC,  BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,DATA_TRFR,MAIN_USER,LAST_VISIT,VISIT_TRAN,  APP_TRFR,AC_REF_NAME)   VALUES ('" + DC_Main.MCo_code + "','" + text5 + "','" + DC_Main.MLc_code + "','";
						object[] array3;
						DataRow dataRow;
						bool[] array4;
						object obj = NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", array3 = new object[1] { (dataRow = dataTable2.Rows[DC_Main.M])["MEMB_NAME"] }, (string[])null, (Type[])null, array4 = new bool[1] { true });
						if (array4[0])
						{
							dataRow["MEMB_NAME"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array3[0]));
						}
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject((object)text6, obj), (object)"','','2','20','','");
						object obj3 = NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", array3 = new object[1] { (dataRow = dataTable2.Rows[DC_Main.M])["AC_ADD1"] }, (string[])null, (Type[])null, array4 = new bool[1] { true });
						if (array4[0])
						{
							dataRow["AC_ADD1"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array3[0]));
						}
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, obj3), (object)"','");
						object obj5 = NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", array3 = new object[1] { (dataRow = dataTable2.Rows[DC_Main.M])["AC_ADD2"] }, (string[])null, (Type[])null, array4 = new bool[1] { true });
						if (array4[0])
						{
							dataRow["AC_ADD2"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array3[0]));
						}
						object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, obj5), (object)"', "), (object)" '','INDIA','"), NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_STATE"], (object)"") }, (string[])null, (Type[])null, (bool[])null)), (object)"','','"), NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_CITY"], (object)"") }, (string[])null, (Type[])null, (bool[])null)), (object)"','','"), dataTable2.Rows[DC_Main.M]["AC_PIN"]), (object)"','','','"), NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["MEMB_NUMBER"], (object)"") }, (string[])null, (Type[])null, (bool[])null)), (object)"','','"), dataTable2.Rows[DC_Main.M]["MEMB_EMAIL"]), (object)"', "), (object)" '','L','");
						object obj7 = NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", array3 = new object[1] { (dataRow = dataTable2.Rows[DC_Main.M])["AC_PANNO"] }, (string[])null, (Type[])null, array4 = new bool[1] { true });
						if (array4[0])
						{
							dataRow["AC_PANNO"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array3[0]));
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, obj7), (object)"','','',NULL,NULL,NULL,0,0,0, "), (object)" '','','','','','A',NULL,'N','ABC','"), (object)Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy")), (object)"','AC', "), (object)" 'N','')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						string text7 = "INSERT INTO AC_MAST_SRNO(CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_GR,MAIN_USER)   VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + text5 + "','";
						object obj8 = NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", array3 = new object[1] { (dataRow = dataTable2.Rows[DC_Main.M])["MEMB_NAME"] }, (string[])null, (Type[])null, array4 = new bool[1] { true });
						if (array4[0])
						{
							dataRow["MEMB_NAME"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array3[0]));
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)text7, obj8), (object)"','20','ABC')"));
						DC_Main.ExeQuteMc(DC_Main.RsQry);
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE APP_USER_DATA SET MEMB_NAME = '", DC_Main.Tbl.Rows[0]["AC_NAME"]), (object)"' WHERE MEMB_NUMBER = '"), dataTable2.Rows[DC_Main.M]["MEMB_NUMBER"]), (object)"'"));
						DC_Main.ExeQuteScm(DC_Main.RsQry);
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE APP_USER_DATA SET DATA_TRFR = 'Y' WHERE MEMB_NUMBER = '", dataTable2.Rows[DC_Main.M]["MEMB_NUMBER"]), (object)"'"));
					DC_Main.ExeQuteScm(DC_Main.RsQry);
					dataTable2 = null;
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT * FROM DG_GOLD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND DATA_TRFR = 'N'";
				dataTable = DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				DC_Main.M = 0;
				while (DC_Main.M < dataTable.Rows.Count)
				{
					DataTable dataTable4 = dataTable;
					string text8 = "";
					string text9 = "";
					string text10 = "00075";
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_CODE,AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MOBILE = '"), dataTable4.Rows[DC_Main.M]["MEMB_MOBILE"]), (object)"'"));
					DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable3.Rows.Count > 0)
					{
						text8 = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["AC_CODE"], (object)""));
						text9 = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["AC_NAME"], (object)""));
					}
					DC_Main.RsQry = "SELECT BANK_AC FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BANK_AC <> ''";
					dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable3.Rows.Count > 0)
					{
						text10 = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["BANK_AC"], (object)""));
					}
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM DG_GOLD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable4.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable4.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable4.Rows[DC_Main.M]["SR_NO"]), (object)"")));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DG_GOLD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,AC_NAME,AC_MOBILE,  ITM_RATE,ITM_AMT,ITM_FINE,LDR_AC,TAX_CODE,TAX_PRC,TAX_AMT,TOT_AMT,  ITM_TYPE,ITM_SIGN,DATA_TRFR,DATA_TYPE,APP_TRFR,EMP_CODE,IT_DESC, MAIN_USER,HD_VCH_NO,USER_UPDATE,USER_DELETE)   VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), dataTable4.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), dataTable4.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), dataTable4.Rows[DC_Main.M]["SR_NO"]), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(dataTable4.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format((object)Conversions.ToDate(dataTable4.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" 'DGOLD','I','T','DG GOLD','"), (object)text8), (object)"', '"), (object)text9), (object)"','"), dataTable4.Rows[DC_Main.M]["MEMB_MOBILE"]), (object)"', "), (object)" "), dataTable4.Rows[DC_Main.M]["ITM_RATE"]), (object)","), dataTable4.Rows[DC_Main.M]["ITM_AMT"]), (object)","), dataTable4.Rows[DC_Main.M]["ITM_FINE"]), (object)",'"), (object)text10), (object)"','10',3,"), dataTable4.Rows[DC_Main.M]["TAX_AMT"]), (object)","), dataTable4.Rows[DC_Main.M]["TOT_AMT"]), (object)", "), (object)" 'G','+','N','A','N','','', "), (object)" 'ABC','"), dataTable4.Rows[DC_Main.M]["VCH_NO"]), (object)"','N','N')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable4.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Ac_Ledr.Dg_Gold_Booking(Conversions.ToString(dataTable4.Rows[DC_Main.M]["CO_BOOK"]), Conversions.ToString(dataTable4.Rows[DC_Main.M]["VCH_NO"]));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable4.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Ac_Rojmel.Dg_Gold_Booking_Rojmel(Conversions.ToString(dataTable4.Rows[DC_Main.M]["CO_BOOK"]), Conversions.ToString(dataTable4.Rows[DC_Main.M]["VCH_NO"]));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE DG_GOLD_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable4.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable4.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable4.Rows[DC_Main.M]["SR_NO"]), (object)""));
					DC_Main.ExeQuteScm(DC_Main.RsQry);
					dataTable4 = null;
					DC_Main.M++;
				}
			}
			if (SchmClickTrfr)
			{
				SchmClickTrfr = false;
				MessageBox.Show("✅ Member Transection Data import successfully...");
			}
		}
	}

	private static void RunDcQuery(string DcConStr, string Sql)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		SqlConnection val = new SqlConnection(DcConStr);
		try
		{
			val.Open();
			SqlCommand val2 = new SqlCommand(Sql, val);
			try
			{
				val2.ExecuteNonQuery();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static void RunMcQuery(string McConStr, string Sql)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		SqlConnection val = new SqlConnection(McConStr);
		try
		{
			val.Open();
			SqlCommand val2 = new SqlCommand(Sql, val);
			try
			{
				val2.ExecuteNonQuery();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private static DataTable RunDcSelect(string DcConStr, string Sql)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		SqlConnection val = new SqlConnection(DcConStr);
		try
		{
			SqlDataAdapter val2 = new SqlDataAdapter(Sql, val);
			try
			{
				((DbDataAdapter)(object)val2).Fill(dataTable);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return dataTable;
	}

	private static DataTable RunMcSelect(string McConStr, string Sql)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		SqlConnection val = new SqlConnection(McConStr);
		try
		{
			SqlDataAdapter val2 = new SqlDataAdapter(Sql, val);
			try
			{
				((DbDataAdapter)(object)val2).Fill(dataTable);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return dataTable;
	}

	public static async void CompnyRest()
	{
		_Closure_0024__14_002D0 arg = default(_Closure_0024__14_002D0);
		_Closure_0024__14_002D0 CS_0024_003C_003E8__locals379 = new _Closure_0024__14_002D0(arg);
		CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + DC_Main.SqlData + ";Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
		CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + DC_Main.SqlMain + ";Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoYear = DC_Main.MCo_year;
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode = DC_Main.MCo_code;
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode = DC_Main.MLc_code;
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalMfgType = DC_Main.MsMfgType;
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalMasterReset = DC_Main.MsMasterResetAllData;
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalRegSrNo = DC_Main.SSRegSrNo;
		CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalImgOpen = DC_Main.MsImgDataOpen;
		await Task.Run(checked([SpecialName] () =>
		{
			string text = "";
			if (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalMasterReset, "Y", false) == 0)
			{
				string text2 = "";
				text = "SELECT CO_CODE FROM CO_MAST WHERE RTGS_TYPE = 'Y'";
				DataTable dataTable = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text);
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.AddObject((object)(text2 + "'"), dataTable.Rows[i]["CO_CODE"]), (object)"',"));
					}
					text2 = Strings.Mid(text2, 1, Strings.Len(text2) - 1);
				}
				if (Operators.CompareString(text2, "", false) != 0)
				{
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM AC_MAST_SRNO WHERE CO_CODE IN (" + text2 + ")");
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM LOCT_MAST WHERE CO_CODE IN (" + text2 + ") AND LC_CODE <> '00'");
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM LOGIN_MAST WHERE CO_CODE  IN (" + text2 + ") AND LOGIN_NAME <> 'ABC' ");
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM USER_SET WHERE CO_CODE  IN (" + text2 + ") AND USER_NAME <> 'ABC'");
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM YEAR_MAST WHERE CO_CODE  IN (" + text2 + ") AND CO_YEAR <> '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoYear + "'");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE AC_GROUP SET USER_SHOW_GROUP = 'Y' WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_MAST WHERE CO_CODE  IN (" + text2 + ") AND CAST(AC_CODE AS INT) > 99");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AD_ADJ WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AD_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AD_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AD_MEMB WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AD_OS WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ADD_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM APR_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM APR_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM APR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAL_GR WHERE CO_CODE  IN (" + text2 + ") AND CAST(SALE_AC AS INT) > 7 ");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BANK_RECONCILE WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAR_CAN_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAR_CAN_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAR_CAN_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAR_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAR_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BAR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BILL_OS_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE BOOK_DETL SET AC_CODE = '00075' WHERE CO_CODE  IN (" + text2 + ") AND CO_BOOK IN('005','006','007','008','009','010','011','012','013','014') AND SR_NO = 1");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE BOOK_IDTL SET AC_CODE = 0 WHERE MAIN_BOOK = 'PURC RETURN' AND SR_NO = 5");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM BUL_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CARD_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CASH_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CO_MAST WHERE CO_CODE  IN (" + text2 + ") AND CO_CODE <> '01'");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM COL_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE CO_SET SET VB_IMPORT = 'N' WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CONTRA_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE CONV_MAST SET GOLD_CONV = 1.0573,SILVER_CONV = 1.022 WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CRNT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CUT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CUT_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CUT_STK_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DELETE_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DESIGN_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DESIGN_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DESIGN_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DHRN_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DHRN_ISU_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DHRN_ISU_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DHRN_REC_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DHRN_REC_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DM_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DM_KR_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DM_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM DM_SIZE WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM EMP_MAST WHERE CO_CODE  IN (" + text2 + ") AND EMP_CODE <> '001'");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM EMP_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM FINE_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM GROUP_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM IMAGE_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM INOUT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM INOUT_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM INOUT_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ITEM_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ITM_CITY WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ITM_LOT_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ITM_OPBL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ITM_WT_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM KR_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM KR_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM KR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LBR_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LBR_ISU_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LBR_ISU_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LBR_REC_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LBR_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LDR_ADJ_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LEDR_AC_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LOCT_AMT WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LOCT_MAST WHERE CO_CODE  IN (" + text2 + ") AND LC_CODE <> '00'");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE LOCT_MAST SET TRY_DATE = NULL");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LOGIN_MAST WHERE CO_CODE  IN (" + text2 + ") AND LOGIN_NAME <> 'ABC'");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM LOT_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MSG_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MFG_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MFG_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MFG_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MFG_ISU_REC WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MFG_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MLT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MLT_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MODEL_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM OP_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM OP_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM OP_LDR WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PAY_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PAY_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM POINT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM POINT_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM POINT_MEMB WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PRODUCT_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_ISU WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_ISU_REC ");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM RATE_CUT_REC WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM RATE_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM REM_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM REP_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM REP_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM REPORT_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ROJMEL_BAL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL_RTN WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_ADJ WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_ORD_IDTL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_PR_DETL WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SRNO_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TABLE_MAST WHERE CO_CODE  IN (" + text2 + ") AND TABLE_CODE <> '001'");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TAG_PRINT_DATA");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TAG_SET WHERE CO_CODE  IN (" + text2 + ") ");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TAG_STOCK_PRINT ");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TAX_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TOUCH_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM USER_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TEMP_AD_DATA");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM TEMP_ADD");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM UPI_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM USER_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM USER_REQUEST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM VP_ADJ_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM WEB_DATA WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM YEAR_MAST WHERE CO_CODE  IN (" + text2 + ") AND CO_YEAR <> '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoYear + "'");
					if (CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalImgOpen)
					{
						DC_Main.ExeQuteImg("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE  IN (" + text2 + ")");
					}
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM CO_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM CO_MAST WHERE CO_CODE  IN (" + text2 + ")");
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "DELETE FROM YEAR_MAST WHERE CO_CODE  IN (" + text2 + ")");
				}
			}
			else
			{
				if (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalRegSrNo, "HM530NEHP", false) == 0)
				{
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE CO_MAST SET HTTP_NAME = ''");
					RunMcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_McConStr, "UPDATE CO_MAST SET HTTP_NAME = ''");
					if ((Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoYear, "2025-2026", false) == 0) & (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode, "01", false) == 0))
					{
						return;
					}
					if (((Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoYear, "2024-2025", false) == 0) & (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode, "01", false) == 0)) | (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode, "02", false) == 0) | (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode, "03", false) == 0))
					{
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '01' AND CO_YEAR = '2024-2025' AND CO_BOOK = '032' AND VCH_NO IN ('00022','00002','00005') ");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_DATA WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_DETL WHERE CO_CODE = '02' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DATA WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM SL_DETL WHERE CO_CODE = '04' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_DATA WHERE CO_CODE = '05' AND CO_YEAR = '2024-2025'");
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM PR_DETL WHERE CO_CODE = '03' AND CO_YEAR = '2024-2025'");
					}
				}
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE BOOK_DATA SET CUR_USE = 'N' WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND BOOK_TYPE = 'M'");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE BOOK_DATA SET CUR_USE = 'N' WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND BOOK_TYPE = 'F'");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM OP_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND DATA_TYPE  = 'B'");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND DATA_TYPE  = 'B'");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND DATA_TYPE  = 'B'");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND FINE_WT  <> 0");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE OP_DATA SET FINE_BAL = 0 WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' ");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "UPDATE OP_DATA SET SL_FINE_BAL = 0 WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' ");
				RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, "DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_BOOK = '000'");
				Ac_Ledr.AcOp_Ledr("", "");
				text = "SELECT A.* FROM SL_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				DataTable dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text);
				int i;
				for (i = 0; i < dataTable2.Rows.Count; i++)
				{
					text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TAG_NO,VCH_SRNO FROM SL_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					DataTable dataTable3 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text);
					for (int j = 0; j < dataTable3.Rows.Count; j++)
					{
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND TAG_NO = '"), dataTable3.Rows[j]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable3.Rows[j]["VCH_SRNO"]), (object)" ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND TAG_NO = '"), dataTable3.Rows[j]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable3.Rows[j]["VCH_SRNO"]), (object)" ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND TAG_NO = '"), dataTable3.Rows[j]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable3.Rows[j]["VCH_SRNO"]), (object)" ")));
					}
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM PR_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM KR_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_IDTL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM RATE_CUT_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
				}
				i = 0;
				text = "SELECT A.* FROM CONTRA_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND  B.DATA_TYPE  = 'B' ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
				}
				i = 0;
				text = "SELECT A.* FROM CASH_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND  B.DATA_TYPE  = 'B' ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
				for (dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
				{
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CASH_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
				}
				if ((Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalMfgType, "J", false) == 0) | (Operators.CompareString(CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalMfgType, "M", false) == 0))
				{
					i = 0;
					text = "SELECT A.* FROM MFG_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND A.LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND B.BOOK_TYPE IN ('M','F') ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
					for (dataTable2 = RunDcSelect(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, text); i < dataTable2.Rows.Count; i++)
					{
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MFG_DATA WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"'")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MFG_DETL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
						RunDcQuery(CS_0024_003C_003E8__locals379._0024VB_0024Local_DcConStr, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalCoCode + "' AND LC_CODE = '" + CS_0024_003C_003E8__locals379._0024VB_0024Local_LocalLcCode + "' AND CO_YEAR = '"), dataTable2.Rows[i]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[i]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[i]["VCH_NO"]), (object)"' ")));
					}
				}
			}
		}));
	}
}
