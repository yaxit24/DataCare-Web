using System;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[StandardModule]
internal sealed class Ac_Final
{
	public static DataTable DtTradStock;

	public static double AcLdrFineGold = 0.0;

	public static double AcLdrFineSilver = 0.0;

	public static void Trading_Stock(DateTime FinalClDt, string FinalLc, double GoldRate, double SilverRate)
	{
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.ExeQuteDc("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '999'");
		DC_Main.RsQry = "SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_BOOK  = '888'";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			DC_Main.MsClgValueSave = "Y";
		}
		else
		{
			DC_Main.MsClgValueSave = "N";
		}
		checked
		{
			if (Operators.CompareString(DC_Main.MsClgValueSave, "N", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MsBalanceSheetType, "F", false) == 0)
				{
					if (GoldRate + SilverRate != 0.0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.TRAD_TYPE AS Code ,C.TRAD_NAME AS Name,C.IT_TYPE As ItType,C.AVG_FINE As ClFine,C.AVG_TOUCH,C.AVG_AMT,C.CLG_AC,C.CLOSING_AC,C.TRAD_AMT, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)FinalClDt, "MM/dd/yyyy") + "' AND A.ITM_MRP <> 0 THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)FinalClDt, "MM/dd/yyyy") + "' AND A.ITM_MRP = 0 THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.TRAD_TYPE <> '' "));
						DC_Main.RsQry += "GROUP BY B.TRAD_TYPE,C.TRAD_NAME,C.IT_TYPE,C.AVG_FINE,C.AVG_TOUCH,C.AVG_AMT,C.CLG_AC,C.CLOSING_AC,C.TRAD_AMT ORDER BY C.TRAD_NAME";
						DtTradStock = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.R = 0;
						int num = DtTradStock.Rows.Count - 1;
						DC_Main.M = 0;
						while (DC_Main.M <= num)
						{
							double num2 = 0.0;
							double num3 = 0.0;
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DtTradStock.Rows[DC_Main.M]["ItType"], (object)""), (object)"G", false))
							{
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DtTradStock.Rows[DC_Main.M]["Code"], (object)""), (object)"GO", false))
								{
									double num4 = ((AcLdrFineGold > 0.0) ? (Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) - AcLdrFineGold) : ((!(AcLdrFineGold < 0.0)) ? Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) : (Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) + Math.Abs(AcLdrFineGold))));
									if (GoldRate != 0.0)
									{
										num2 = num4 * (GoldRate / 10.0);
									}
								}
								else if (GoldRate != 0.0)
								{
									num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) * (GoldRate / 10.0);
								}
							}
							else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DtTradStock.Rows[DC_Main.M]["ItType"], (object)""), (object)"S", false))
							{
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DtTradStock.Rows[DC_Main.M]["Code"], (object)""), (object)"SL", false))
								{
									double num5 = 0.0;
									num5 = ((AcLdrFineSilver > 0.0) ? (Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) - AcLdrFineSilver) : ((!(AcLdrFineSilver < 0.0)) ? Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) : (Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) + Math.Abs(AcLdrFineSilver))));
									if (SilverRate != 0.0)
									{
										num3 = num5 * (SilverRate / 10.0);
									}
								}
								else if (SilverRate != 0.0)
								{
									num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClFine"])) * (SilverRate / 10.0);
								}
							}
							double num6 = num2 + num3;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DtTradStock.Rows[DC_Main.M])["AVG_AMT"]);
							double num7 = DC_Main.Fnv(ref Value);
							dataRow["AVG_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							if (num6 + num7 != 0.0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' , "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)("'" + DC_Main.MLc_code + "'"), (object)("'" + FinalLc + "'"))), (object)" ,'"), (object)DC_Main.MCo_year), (object)"' ,'999','CLGBL','00001','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','"), (object)DC_Main.MCo_code), DtTradStock.Rows[DC_Main.M]["Code"]), (object)"','FINAL BALANCE','',NULL,'', '"), DtTradStock.Rows[DC_Main.M]["CLG_AC"]), (object)"','"), DtTradStock.Rows[DC_Main.M]["CLOSING_AC"]), (object)"', "), (object)" 0,"), Operators.AddObject((object)(num2 + num3), DtTradStock.Rows[DC_Main.M]["AVG_AMT"])), (object)", '','',0,'','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' ,"), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)("'" + DC_Main.MLc_code + "'"), (object)("'" + FinalLc + "'"))), (object)",'"), (object)DC_Main.MCo_year), (object)"' ,'999','CLGBL','00001','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','"), (object)DC_Main.MCo_code), DtTradStock.Rows[DC_Main.M]["Code"]), (object)1), (object)"','FINAL BALANCE','',NULL,'','"), DtTradStock.Rows[DC_Main.M]["CLOSING_AC"]), (object)"', '"), DtTradStock.Rows[DC_Main.M]["CLG_AC"]), (object)"', "), (object)" "), Operators.AddObject((object)(num2 + num3), DtTradStock.Rows[DC_Main.M]["AVG_AMT"])), (object)",0, '','',0,'','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
								DC_Main.ExeQuteDc(DC_Main.RsQry);
							}
							DC_Main.M++;
						}
					}
					else
					{
						Interaction.MsgBox((object)"Please Insert Gold And Silver Rate", (MsgBoxStyle)0, (object)null);
					}
					return;
				}
				DC_Main.RsQry = "SELECT A.TRAD_TYPE AS Code,B.IT_TYPE As ItType,B.TRAD_NAME AS Name,B.AVG_RATE As ClRate,B.AVG_NWT AS ClNwt,B.TOT_PCS AS ClPcs,B.PCS_RATE,B.CLG_AC,B.CLOSING_AC,B.AVG_AMT,0 As ClFine,0 as TRAD_AMT FROM ITEM_MAST AS A LEFT JOIN BAL_GR AS B ON A.CO_CODE = B.CO_CODE AND A.TRAD_TYPE = B.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TRAD_TYPE <> '' ";
				DC_Main.RsQry += "GROUP BY  A.TRAD_TYPE,B.IT_TYPE,B.TRAD_NAME,B.AVG_RATE,B.AVG_NWT,B.TOT_PCS,B.PCS_RATE,B.CLG_AC,B.CLOSING_AC,B.AVG_AMT ORDER BY B.TRAD_NAME";
				DtTradStock = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				int num8 = DtTradStock.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num8)
				{
					double num9 = 0.0;
					double num10 = 0.0;
					num9 = Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClNwt"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClRate"]));
					num10 = Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["ClPcs"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(DtTradStock.Rows[DC_Main.M]["PCS_RATE"]));
					if (num9 + num10 != 0.0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' , "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)("'" + DC_Main.MLc_code + "'"), (object)("'" + FinalLc + "'"))), (object)" ,'"), (object)DC_Main.MCo_year), (object)"' ,'999','CLGBL','00001','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','"), (object)DC_Main.MCo_code), DtTradStock.Rows[DC_Main.M]["Code"]), (object)"','FINAL BALANCE','',NULL,'', '"), DtTradStock.Rows[DC_Main.M]["CLG_AC"]), (object)"','"), DtTradStock.Rows[DC_Main.M]["CLOSING_AC"]), (object)"', "), (object)" 0,"), (object)Strings.Format((object)(num9 + num10), "0.00")), (object)", '','',0,'','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' ,"), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)("'" + DC_Main.MLc_code + "'"), (object)("'" + FinalLc + "'"))), (object)",'"), (object)DC_Main.MCo_year), (object)"' ,'999','CLGBL','00001','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','"), (object)DC_Main.MCo_code), DtTradStock.Rows[DC_Main.M]["Code"]), (object)1), (object)"','FINAL BALANCE','',NULL,'','"), DtTradStock.Rows[DC_Main.M]["CLOSING_AC"]), (object)"', '"), DtTradStock.Rows[DC_Main.M]["CLG_AC"]), (object)"', "), (object)" "), (object)Strings.Format((object)(num9 + num10), "0.00")), (object)",0, '','',0,'','"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.M++;
				}
			}
			else if (Operators.CompareString(DC_Main.MsBalanceSheetType, "F", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.TRAD_TYPE AS Code ,C.TRAD_NAME AS Name,C.IT_TYPE As ItType,C.AVG_FINE As ClFine,C.AVG_TOUCH,C.AVG_AMT,C.CLG_AC,C.CLOSING_AC,C.TRAD_AMT, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)FinalClDt, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -A.ITM_PCS END) ELSE 0 END) AS ClPcs, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)FinalClDt, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND B.TRAD_TYPE <> ''"));
				DC_Main.RsQry += "GROUP BY B.TRAD_TYPE,C.TRAD_NAME,C.IT_TYPE,C.AVG_FINE,C.AVG_TOUCH,C.AVG_AMT,C.CLG_AC,C.CLOSING_AC,C.TRAD_AMT ORDER BY C.TRAD_NAME";
				DtTradStock = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.RsQry = "SELECT A.TRAD_TYPE AS Code,A.IT_TYPE As ItType,B.TRAD_NAME AS Name,B.AVG_RATE As ClRate,B.AVG_NWT AS ClNwt,B.TOT_PCS AS ClPcs,B.PCS_RATE,B.CLG_AC,B.CLOSING_AC,B.AVG_AMT,0 As ClFine,B.TRAD_AMT FROM ITEM_MAST AS A LEFT JOIN BAL_GR AS B ON A.CO_CODE = B.CO_CODE AND A.TRAD_TYPE = B.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TRAD_TYPE <> '' ";
				DC_Main.RsQry += "GROUP BY  A.TRAD_TYPE,A.IT_TYPE,B.TRAD_NAME,B.AVG_RATE,B.AVG_NWT,B.TOT_PCS,B.PCS_RATE,B.CLG_AC,B.CLOSING_AC,B.AVG_AMT,B.TRAD_AMT ORDER BY B.TRAD_NAME";
				DtTradStock = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
		}
	}

	public static void AcBalInsert(bool Opbal, DateTime FinalOpDt, DateTime FinalClDt, string RptData, string ToDayBal, string FinalLc)
	{
		DC_Main.RsQry = "DELETE FROM LEDR_AC_DATA ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		if (Conversions.ToBoolean(ToDayBal))
		{
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,ROUND(SUM(CR_AMT-DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" and VCH_DATE = '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' GROUP BY B.AC_GR,A.AC_CODE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,A.DATA_TYPE,ROUND(SUM(CR_AMT-DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" and VCH_DATE = '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY B.AC_GR,A.AC_CODE,A.DATA_TYPE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
			}
		}
		else if (Opbal)
		{
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,ROUND(SUM(A.CR_AMT-A.DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"' AND A.CO_BOOK <> '999' GROUP BY B.AC_GR,A.AC_CODE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,A.DATA_TYPE,ROUND(SUM(A.CR_AMT-A.DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.CO_BOOK <> '999' GROUP BY B.AC_GR,A.AC_CODE,A.DATA_TYPE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
			}
		}
		else if (DateTime.Compare(FinalOpDt, DC_Main.MOp_dt) == 0)
		{
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,ROUND(SUM(A.CR_AMT-A.DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"' GROUP BY B.AC_GR,A.AC_CODE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,A.DATA_TYPE,ROUND(SUM(A.CR_AMT-A.DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" and VCH_DATE <= '"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY B.AC_GR,A.AC_CODE,A.DATA_TYPE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
			}
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,ROUND(SUM(A.CR_AMT-A.DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" AND VCH_DATE >= '"), (object)Strings.Format((object)FinalOpDt, "MM/dd/yyyy")), (object)"' And VCH_DATE <= '"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"' GROUP BY B.AC_GR,A.AC_CODE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.AC_GR,A.AC_CODE,A.DATA_TYPE,ROUND(SUM(A.CR_AMT-A.DR_AMT),2) AS BalAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + FinalLc + "'"))), (object)" AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'"), Interaction.IIf(Operators.CompareString(RptData, "T", false) == 0, (object)"", RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(RptData, "P", false) == 0, (object)"AND B.AC_MAIN_GR >= '3'", (object)"AND B.AC_MAIN_GR < '3'")))), (object)" AND VCH_DATE >= '"), (object)Strings.Format((object)FinalOpDt, "MM/dd/yyyy")), (object)"' And VCH_DATE <= '"), (object)Strings.Format((object)FinalClDt, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY B.AC_GR,A.AC_CODE,A.DATA_TYPE HAVING ROUND(SUM(A.CR_AMT-A.DR_AMT),2) <> 0 ORDER BY A.AC_CODE "));
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["BalAmt"])) > 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE,AC_GR) VALUES('" + DC_Main.MCo_code + "',"), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)("'" + DC_Main.MLc_code + "'"), (object)("'" + FinalLc + "'"))), (object)",'"), (object)DC_Main.MCo_year), (object)"','',"), Interaction.IIf(Opbal, (object)("'" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "'"), (object)("'" + Strings.Format((object)FinalClDt, "MM/dd/yyyy") + "'"))), (object)",'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',"), dataTable.Rows[DC_Main.X]["BalAmt"]), (object)",0,0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"','"), dataTable.Rows[DC_Main.X]["AC_GR"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["BalAmt"])) < 0.0)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE,AC_GR) VALUES('" + DC_Main.MCo_code + "',"), Interaction.IIf(Operators.CompareString(FinalLc, "", false) == 0, (object)("'" + DC_Main.MLc_code + "'"), (object)("'" + FinalLc + "'"))), (object)",'"), (object)DC_Main.MCo_year), (object)"','',"), Interaction.IIf(Opbal, (object)("'" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "'"), (object)("'" + Strings.Format((object)FinalClDt, "MM/dd/yyyy") + "'"))), (object)",'','"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,");
					Type? typeFromHandle = typeof(Math);
					DataRow dataRow;
					object[] obj2 = new object[1] { (dataRow = dataTable.Rows[DC_Main.X])["BalAmt"] };
					object[] array = obj2;
					bool[] obj3 = new bool[1] { true };
					bool[] array2 = obj3;
					object obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj2, (string[])null, (Type[])null, obj3);
					if (array2[0])
					{
						dataRow["BalAmt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, obj4), (object)",0,0,0,0,'"), (object)DC_Main.MsDataType), (object)"','"), dataTable.Rows[DC_Main.X]["AC_GR"]), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
	}
}
