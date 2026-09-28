using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[StandardModule]
internal sealed class Mfg_Module
{
	public static string MsRendomTag;

	public static void Mfg_With_lot()
	{
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','00','00','','','N','L','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','06','06','Setting Isu','Setting Isu','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','07','07','Setting Rec','Setting Rec','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','08','08','Polish Isu','Polish Isu','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','09','09','Polish Rec','Polish Rec','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','21','21','Mfg Mast','Mfg Mast','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','22','22','MfgTag Entry','MfgTag Entry','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','23','23','','','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','25','25','Lot IsuRec','Lot IsuRec','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','26','26','Mfg Ledger','Mfg Ledger','Y','S','N')");
		DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','28','28','Mfg InOut','Mfg InOut','Y','S','N')");
	}

	public static void Mfg_With_Order()
	{
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) != 0)
		{
			DC_Main.OpenRecordSetMc("DELETE FROM MENU_DATA WHERE BTN_NAME = 'Mfg'");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','00','00','','','N','L','N')");
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK300NUST", false) != 0)
			{
				DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','01','01','Melting Work','Melting Work','Y','S','N')");
			}
			else
			{
				DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','01','01','Metl Isu','Metl Isu','Y','S','N')");
			}
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','02','02','Design Isu','Design Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','04','04','Wex Rec','Wex Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','05','05','Casting Isu','Casting Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','06','06','Casting Rec','Casting Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','07','07','Filling Isu','Filling Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','08','08','Filling Rec','Filling Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','09','09','Pre Polish Isu','Pre Polish Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','10','10','Pre Polish Rec','Pre Polish Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','11','11','Mino Isu','Mino Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','12','12','Mino Rec','Mino Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','13','13','Setting Isu','Setting Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','14','14','Setting Rec','Setting Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','15','15','Assemble Isu','Assemble Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','16','16','Assemble Rec','Assemble Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','17','17','Nakshi isu','Nakshi isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','18','18','Nakshi Rec','Nakshi Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','19','19','Polish Isu','Polish Isu','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','20','20','Polish Rec','Polish Rec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','21','21','Mfg Mast','Mfg Mast','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','22','22','MfgTag Entry','MfgTag Entry','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','23','23','','','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','25','25','Lot IsuRec','Lot IsuRec','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','26','26','Mfg Ledger','Mfg Ledger','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','27','27','Mfg Order','Mfg Order','Y','S','N')");
			DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','28','28','Mfg InOut','Mfg InOut','Y','S','N')");
			DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '02' AND SM_MAIN_CODE = '12' AND SM_MAIN_NAME = 'Lot Opening'");
			DC_Main.OpenRecordSetDc("DELETE FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.OpenRecordSetDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('300','301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319','320','323','324')");
			DC_Main.OpenRecordSetDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('300','301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319','320','323','324')");
			DC_Main.OpenRecordSetDc("DELETE FROM BOOK_IDTL WHERE MAIN_BOOK IN ('MLT PRO','METAL ISU','DESIGN ISU','MFG WEX REC','MFG CAST ISU','MFG CAST REC','MFG FILE ISU','MFG FILE REC','MFG PREP ISU','MFG PREP REC','MFG MINO ISU','MFG MINO REC','MFG STNG ISU','MFG STNG REC','MFG ASMBL ISU','MFG ASMBL REC','MFG NAKSHI ISU','MFG NAKSHI REC','MFG POLISH ISU','MFG POLISH REC','MFG CASTING ISU','MFG CASTING REC')");
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK300NUST", false) == 0)
			{
				DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','01','01','300','MTLIS','Metl Isu','Metl Isu','Y','X','X','X','Y','N','METAL ISU')");
				DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('METAL ISU',1,'O','00001','CASH ON HAND')");
				DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('METAL ISU',2,'O','00008','PURCHASE GOLD A/C')");
				DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','300','Metal Isu','MTLIS','O','F','A','','METAL ISU','N','A','N','Metl Isu','MFG_DATA')";
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','01','01','300','MLTNG','Melting Work','Melting Work','Y','L','L','G','N','N','MLT PRO')");
				DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MLT PRO',1,'O','00001','CASH ON HAND')");
				DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MLT PRO',2,'O','00042','KASAR AVAK A/C')");
				DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','300','Melting Isu','MLTIS','O','F','A','','MLT PRO','N','A','N','Metal Isu','MFG_DATA')";
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','02','02','301','DISIS','Design Isu','Design Isu','Y','X','D','W','N','N','DESIGN ISU')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('DESIGN ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','301','Design Isu','DISIS','O','F','A','','DESIGN ISU','N','A','N','Design Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','04','04','302','WXREC','Wex Rec','Wex Rec','Y','D','W','C','N','N','MFG WEX REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG WEX REC',1,'I','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','302','Wex Rec','WXREC','I','F','A','','MFG WEX REC','N','A','N','Wex Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','05','05','303','CSTIS','Casting Isu','Casting Isu','Y','W','C','C','N','N','MFG CAST ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','06','06','304','CSTRC','Casting Rec','Casting Rec','Y','C','C','F','N','N','MFG CAST REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST ISU',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST ISU',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','303','Casting Isu','CSTIS','O','F','A','','MFG CAST ISU','N','A','N','Casting Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','304','Casting Rec','CSTRC','I','F','A','','MFG CAST REC','N','A','N','Casting Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','07','07','305','FILIS','Filling Isu','Filling Isu','Y','C','F','F','N','N','MFG FILE ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','08','08','306','FILRC','Filling Rec','Filling Rec','Y','F','F','R','N','N','MFG FILE REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','305','Filling Isu','FILIS','O','F','A','','MFG FILE ISU','N','A','N','Filling Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','306','Filling Rec','FILRC','I','F','A','','MFG FILE REC','N','A','N','Filling Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','09','09','307','PREIS','Pre Polish Isu','Pre Polish Isu','Y','F','R','R','N','N','MFG PREP ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','10','10','308','PRERC','Pre Polish Rec','Pre Polish Rec','Y','R','R','M','N','N','MFG PREP REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','307','Pre Polish Isu','PREIS','O','F','A','','MFG PREP ISU','N','A','N','Pre Polish Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','308','Pre Polish Rec','PRERC','I','F','A','','MFG PREP REC','N','A','N','Pre Polish Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','11','11','309','MNOIS','Mino Isu','Mino Isu','Y','R','M','M','N','N','MFG MINO ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','12','12','310','MNORC','Mino Rec','Mino Rec','Y','M','M','S','N','N','MFG MINO REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','309','Mino Isu','MNOIS','O','F','A','','MFG MINO ISU','N','A','N','Mino Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','310','Mino Rec','MNORC','I','F','A','','MFG MINO REC','N','A','N','Mino Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','13','13','311','STNIS','Setting Isu','Setting Isu','Y','M','S','S','N','N','MFG STNG ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','14','14','312','STNRC','Setting Rec','Setting Rec','Y','S','S','A','N','N','MFG STNG REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','311','Setting Isu','STNIS','O','F','A','','MFG STNG ISU','N','A','N','Setting Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','312','Setting Rec','STNRC','I','F','A','','MFG STNG REC','N','A','N','Setting Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','15','15','313','ASMIS','Assemble Isu','Assemble Isu','Y','S','A','A','N','N','MFG ASMBL ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','16','16','314','ASMRC','Assemble Rec','Assemble Rec','Y','A','A','N','N','N','MFG ASMBL REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG ASMBL ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','313','Assemble Isu','ASISU','O','F','A','','MFG ASMBL ISU','N','A','N','Nakshi isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG ASMBL REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG ASMBL REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG ASMBL REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','314','Assemble Rec','NKSRC','I','F','A','','MFG ASMBL REC','N','A','N','Nakshi Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','17','17','315','NKSIS','Nakshi isu','Nakshi isu','Y','A','N','N','N','N','MFG NAKSHI ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','18','18','316','NKSRC','Nakshi Rec','Nakshi Rec','Y','N','N','P','N','N','MFG NAKSHI REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','315','Nakshi isu','NKSIS','O','F','A','','MFG NAKSHI ISU','N','A','N','Nakshi isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','316','Nakshi Rec','NKSRC','I','F','A','','MFG NAKSHI REC','N','A','N','Nakshi Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','19','19','317','POLIS','Polish Isu','Polish Isu','Y','N','P','P','N','N','MFG POLISH ISU')");
			DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','20','20','318','POLRC','Polish Rec','Polish Rec','Y','P','P','X','N','Y','MFG POLISH REC')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH ISU',1,'O','00001','CASH ON HAND')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','317','Polish Isu','POLIS','O','F','A','','MFG POLISH ISU','N','A','N','Polish Isu','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH REC',1,'I','00001','CASH ON HAND')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH REC',2,'I','00008','PURCHASE GOLD A/C')");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH REC',3,'I','00056','LABOUR EXP A/C')");
			DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','318','Polish Rec','POLRC','I','F','A','','MFG POLISH REC','N','A','N','Polish Rec','MFG_DATA')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '02' AND SM_MAIN_CODE = '24' AND SM_MAIN_NAME = 'Dm Size'");
		}
	}

	public static void Mfg_menu_set()
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','00','00','','','N','L','N')");
					goto IL_000f;
				case 3583:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000f;
						case 3:
							goto IL_001c;
						case 4:
							goto IL_0029;
						case 5:
							goto IL_0036;
						case 6:
							goto IL_0043;
						case 7:
							goto IL_0050;
						case 8:
							goto IL_005d;
						case 9:
							goto IL_006a;
						case 10:
							goto IL_0078;
						case 11:
							goto IL_0086;
						case 12:
							goto IL_0094;
						case 13:
							goto IL_00a2;
						case 14:
							goto IL_00b0;
						case 15:
							goto IL_00be;
						case 16:
							goto IL_00cc;
						case 17:
							goto IL_00da;
						case 18:
							goto IL_00e8;
						case 19:
							goto IL_00f6;
						case 20:
							goto IL_0104;
						case 21:
							goto IL_0112;
						case 22:
							goto IL_0120;
						case 23:
							goto IL_012e;
						case 24:
							goto IL_013c;
						case 25:
							goto IL_014a;
						case 26:
							goto IL_0158;
						case 27:
							goto IL_0175;
						case 28:
							goto IL_01b1;
						case 29:
							goto IL_01ed;
						case 30:
							goto IL_020a;
						case 31:
							goto IL_0227;
						case 32:
							goto IL_0244;
						case 33:
							goto IL_0261;
						case 34:
							goto IL_027e;
						case 35:
							goto IL_029b;
						case 36:
							goto IL_02b8;
						case 37:
							goto IL_02d5;
						case 38:
							goto IL_02f2;
						case 39:
							goto IL_030f;
						case 40:
							goto IL_032c;
						case 41:
							goto IL_0349;
						case 42:
							goto IL_0366;
						case 43:
							goto IL_0383;
						case 44:
							goto IL_03a0;
						case 45:
							goto IL_03bd;
						case 46:
							goto IL_03da;
						case 47:
							goto IL_03f7;
						case 48:
							goto IL_0414;
						case 49:
							goto IL_0431;
						case 50:
							goto IL_043a;
						case 51:
							goto IL_0475;
						case 52:
							goto IL_0483;
						case 53:
							goto IL_04be;
						case 54:
							goto IL_04cc;
						case 55:
							goto IL_0507;
						case 56:
							goto IL_0515;
						case 57:
							goto IL_0550;
						case 58:
							goto IL_055e;
						case 59:
							goto IL_0599;
						case 60:
							goto IL_05a7;
						case 61:
							goto IL_05e2;
						case 62:
							goto IL_05f0;
						case 63:
							goto IL_062b;
						case 64:
							goto IL_0639;
						case 65:
							goto IL_0674;
						case 66:
							goto IL_0682;
						case 67:
							goto IL_06bd;
						case 68:
							goto IL_06cb;
						case 69:
							goto IL_0706;
						case 70:
							goto IL_0714;
						case 71:
							goto IL_074f;
						case 72:
							goto IL_075d;
						case 73:
							goto IL_0798;
						case 74:
							goto IL_07a6;
						case 75:
							goto IL_07e1;
						case 76:
							goto IL_07ef;
						case 77:
							goto IL_082a;
						case 78:
							goto IL_0838;
						case 79:
							goto IL_0873;
						case 80:
							goto IL_0881;
						case 81:
							goto IL_08bc;
						case 82:
							goto IL_08ca;
						case 83:
							goto IL_0905;
						case 84:
							goto IL_0913;
						case 85:
							goto IL_094e;
						case 86:
							goto IL_095c;
						case 87:
							goto IL_0997;
						case 88:
							goto IL_09a5;
						case 89:
							goto IL_09b3;
						case 90:
							goto IL_09c1;
						case 91:
							goto IL_09cf;
						case 92:
							goto IL_09dd;
						case 93:
							goto IL_09eb;
						case 94:
							goto IL_09f9;
						case 95:
							goto IL_0a07;
						case 96:
							goto IL_0a15;
						case 97:
							goto IL_0a23;
						case 98:
							goto IL_0a31;
						case 99:
							goto IL_0a3f;
						case 100:
							goto IL_0a4d;
						case 101:
							goto IL_0a5b;
						case 102:
							goto IL_0a69;
						case 103:
							goto IL_0a77;
						case 104:
							goto IL_0a85;
						case 105:
							goto IL_0a93;
						case 106:
							goto IL_0aa1;
						case 107:
							goto IL_0aaf;
						case 108:
							goto IL_0abd;
						case 109:
							goto IL_0acb;
						case 110:
							goto IL_0ad9;
						case 111:
							goto IL_0ae7;
						case 112:
							goto IL_0af5;
						case 113:
							goto IL_0b03;
						case 114:
							goto IL_0b11;
						case 115:
							goto IL_0b1f;
						case 116:
							goto IL_0b2d;
						case 117:
							goto IL_0b3b;
						case 118:
							goto IL_0b49;
						case 119:
							goto IL_0b57;
						case 120:
							goto IL_0b65;
						case 121:
							goto IL_0b73;
						case 122:
							goto IL_0b81;
						case 123:
							goto IL_0b8f;
						case 124:
							goto IL_0b9d;
						case 125:
							goto IL_0bab;
						case 126:
							goto IL_0bb9;
						case 127:
							goto IL_0bc7;
						case 128:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 129:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0bab:
					num2 = 125;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH REC',1,'I','00001','CASH ON HAND')");
					goto IL_0bb9;
					IL_0bb9:
					num2 = 126;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0bc7;
					IL_0b9d:
					num2 = 124;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0bab;
					IL_0bc7:
					num2 = 127;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH REC',3,'I','00056','LABOUR EXP A/C')");
					break;
					IL_000f:
					num2 = 2;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','01','01','Melting Work','Melting Work','Y','S','N')");
					goto IL_001c;
					IL_001c:
					num2 = 3;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','02','02','Ghat Isu','Ghat Isu','Y','S','N')");
					goto IL_0029;
					IL_0029:
					num2 = 4;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','03','03','Ghat Rec','Ghat Rec','Y','S','N')");
					goto IL_0036;
					IL_0036:
					num2 = 5;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','04','04','Wex Rec','Wex Rec','N','S','N')");
					goto IL_0043;
					IL_0043:
					num2 = 6;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','05','05','Casting Isu','Casting Isu','N','S','N')");
					goto IL_0050;
					IL_0050:
					num2 = 7;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','06','06','Casting Rec','Casting Rec','N','S','N')");
					goto IL_005d;
					IL_005d:
					num2 = 8;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','07','07','Filling Isu','Filling Isu','Y','S','N')");
					goto IL_006a;
					IL_006a:
					num2 = 9;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','08','08','Filling Rec','Filling Rec','Y','S','N')");
					goto IL_0078;
					IL_0078:
					num2 = 10;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','09','09','Pre Polish Isu','Pre Polish Isu','Y','S','N')");
					goto IL_0086;
					IL_0086:
					num2 = 11;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','10','10','Pre Polish Rec','Pre Polish Rec','Y','S','N')");
					goto IL_0094;
					IL_0094:
					num2 = 12;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','11','11','Nakshi isu','Nakshi isu','Y','S','N')");
					goto IL_00a2;
					IL_00a2:
					num2 = 13;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','12','12','Nakshi Rec','Nakshi Rec','Y','S','N')");
					goto IL_00b0;
					IL_00b0:
					num2 = 14;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','13','13','Setting Isu','Setting Isu','Y','S','N')");
					goto IL_00be;
					IL_00be:
					num2 = 15;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','14','14','Setting Rec','Setting Rec','Y','S','N')");
					goto IL_00cc;
					IL_00cc:
					num2 = 16;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','15','15','Mino Isu','Mino Isu','Y','S','N')");
					goto IL_00da;
					IL_00da:
					num2 = 17;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','16','16','Mino Rec','Mino Rec','Y','S','N')");
					goto IL_00e8;
					IL_00e8:
					num2 = 18;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','17','17','Filling2 Isu','Filling2 Isu','Y','S','N')");
					goto IL_00f6;
					IL_00f6:
					num2 = 19;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','18','18','Filling2 Rec','Filling2 Rec','Y','S','N')");
					goto IL_0104;
					IL_0104:
					num2 = 20;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','19','19','Polish Isu','Polish Isu','Y','S','N')");
					goto IL_0112;
					IL_0112:
					num2 = 21;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','20','20','Polish Rec','Polish Rec','Y','S','N')");
					goto IL_0120;
					IL_0120:
					num2 = 22;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','21','21','Mfg Mast','Mfg Mast','Y','S','N')");
					goto IL_012e;
					IL_012e:
					num2 = 23;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','25','25','Lot IsuRec','Lot IsuRec','Y','S','N')");
					goto IL_013c;
					IL_013c:
					num2 = 24;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','26','26','Mfg Ledger','Mfg Ledger','Y','S','N')");
					goto IL_014a;
					IL_014a:
					num2 = 25;
					DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('14','Mfg','28','28','Mfg InOut','Mfg InOut','Y','S','N')");
					goto IL_0158;
					IL_0158:
					num2 = 26;
					DC_Main.OpenRecordSetDc("DELETE FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
					goto IL_0175;
					IL_0175:
					num2 = 27;
					DC_Main.OpenRecordSetDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')");
					goto IL_01b1;
					IL_01b1:
					num2 = 28;
					DC_Main.OpenRecordSetDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')");
					goto IL_01ed;
					IL_01ed:
					num2 = 29;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','01','01','300','MLTNG','Melting Work','Melting Work','Y','L','L','G','N','N','MLT PRO')");
					goto IL_020a;
					IL_020a:
					num2 = 30;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','02','02','301','GHTIS','Ghat Isu','Ghat Isu','Y','L','G','G','N','N','GHAT ISU')");
					goto IL_0227;
					IL_0227:
					num2 = 31;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','03','03','302','GHTRC','Ghat Rec','Ghat Rec','Y','G','G','R','N','N','MFG GHAT REC')");
					goto IL_0244;
					IL_0244:
					num2 = 32;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','04','04','319','WXREC','Wex Rec','Wex Rec','N','G','W','C','N','N','MFG WEX REC')");
					goto IL_0261;
					IL_0261:
					num2 = 33;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','05','05','303','CSTIS','Casting Isu','Casting Isu','N','G','C','C','N','N','MFG CAST ISU')");
					goto IL_027e;
					IL_027e:
					num2 = 34;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','06','06','304','CSTRC','Casting Rec','Casting Rec','N','C','C','F','N','N','MFG CAST REC')");
					goto IL_029b;
					IL_029b:
					num2 = 35;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','07','07','305','FILIS','Filling Isu','Filling Isu','Y','C','F','F','N','N','MFG FILE ISU')");
					goto IL_02b8;
					IL_02b8:
					num2 = 36;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','08','08','306','FILRC','Filling Rec','Filling Rec','Y','F','F','R','N','N','MFG FILE REC')");
					goto IL_02d5;
					IL_02d5:
					num2 = 37;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','09','09','307','PREIS','Pre Polish Isu','Pre Polish Isu','Y','F','R','R','N','N','MFG PREP ISU')");
					goto IL_02f2;
					IL_02f2:
					num2 = 38;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','10','10','308','PRERC','Pre Polish Rec','Pre Polish Rec','Y','R','R','N','N','N','MFG PREP REC')");
					goto IL_030f;
					IL_030f:
					num2 = 39;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','11','11','309','NKSIS','Nakshi isu','Nakshi isu','Y','R','N','N','N','N','MFG NAKSHI ISU')");
					goto IL_032c;
					IL_032c:
					num2 = 40;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','12','12','310','NKSRC','Nakshi Rec','Nakshi Rec','Y','N','N','S','N','N','MFG NAKSHI REC')");
					goto IL_0349;
					IL_0349:
					num2 = 41;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','13','13','311','STNIS','Setting Isu','Setting Isu','Y','N','S','S','N','N','MFG STNG ISU')");
					goto IL_0366;
					IL_0366:
					num2 = 42;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','14','14','312','STNRC','Setting Rec','Setting Rec','Y','S','S','M','N','N','MFG STNG REC')");
					goto IL_0383;
					IL_0383:
					num2 = 43;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','15','15','313','MNOIS','Mino Isu','Mino Isu','N','S','M','M','N','N','MFG MINO ISU')");
					goto IL_03a0;
					IL_03a0:
					num2 = 44;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','16','16','314','MNORC','Mino Rec','Mino Rec','N','M','M','I','N','N','MFG MINO REC')");
					goto IL_03bd;
					IL_03bd:
					num2 = 45;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','17','17','315','FL2IS','Filling2 Isu','Filling2 Isu','N','M','I','I','N','N','MFG FILE2 ISU')");
					goto IL_03da;
					IL_03da:
					num2 = 46;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','18','18','316','FL2RC','Filling2 Rec','Filling2 Rec','N','I','I','P','N','N','MFG FILE2 REC')");
					goto IL_03f7;
					IL_03f7:
					num2 = 47;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','19','19','317','POLIS','Polish Isu','Polish Isu','Y','I','P','P','N','N','MFG POLISH ISU')");
					goto IL_0414;
					IL_0414:
					num2 = 48;
					DC_Main.ExeQuteDc("INSERT INTO MFG_MAST(CO_CODE,SM_MAIN_CODE,SM_CODE,CO_BOOK,BOOK_SNAME,MENU_NAME,TRAN_NAME,CUR_IN_USE,LAST_TRAN,ENTRY_TYPE,NEXT_TRAN,STK_ISU,STK_REC,MAIN_BOOK) VALUES ('" + DC_Main.MCo_code + "','20','20','318','POLRC','Polish Rec','Polish Rec','Y','P','P','00','N','Y','MFG POLISH REC')");
					goto IL_0431;
					IL_0431:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_043a;
					IL_043a:
					num2 = 50;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','302','Ghat Rec','GHTRC','I','F','A','','MFG GHAT REC','N','A','N','Ghat Rec','MFG_DATA')";
					goto IL_0475;
					IL_0475:
					num2 = 51;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0483;
					IL_0483:
					num2 = 52;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','319','Wex Rec','WXREC','I','F','A','','MFG WEX REC','N','A','N','Wex Rec','MFG_DATA')";
					goto IL_04be;
					IL_04be:
					num2 = 53;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_04cc;
					IL_04cc:
					num2 = 54;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','303','Casting Isu','CSTIS','O','F','A','','MFG CAST ISU','N','A','N','Casting Isu','MFG_DATA')";
					goto IL_0507;
					IL_0507:
					num2 = 55;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0515;
					IL_0515:
					num2 = 56;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','304','Casting Rec','CSTRC','I','F','A','','MFG CAST REC','N','A','N','Casting Rec','MFG_DATA')";
					goto IL_0550;
					IL_0550:
					num2 = 57;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_055e;
					IL_055e:
					num2 = 58;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','305','Filling Isu','FILIS','O','F','A','','MFG FILE ISU','N','A','N','Filling Isu','MFG_DATA')";
					goto IL_0599;
					IL_0599:
					num2 = 59;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_05a7;
					IL_05a7:
					num2 = 60;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','306','Filling Rec','FILRC','I','F','A','','MFG FILE REC','N','A','N','Filling Rec','MFG_DATA')";
					goto IL_05e2;
					IL_05e2:
					num2 = 61;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_05f0;
					IL_05f0:
					num2 = 62;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','307','Pre Polish Isu','PREIS','O','F','A','','MFG PREP ISU','N','A','N','Pre Polish Isu','MFG_DATA')";
					goto IL_062b;
					IL_062b:
					num2 = 63;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0639;
					IL_0639:
					num2 = 64;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','308','Pre Polish Rec','PRERC','I','F','A','','MFG PREP REC','N','A','N','Pre Polish Rec','MFG_DATA')";
					goto IL_0674;
					IL_0674:
					num2 = 65;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0682;
					IL_0682:
					num2 = 66;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','309','Nakshi isu','NKSIS','O','F','A','','MFG NAKSHI ISU','N','A','N','Nakshi isu','MFG_DATA')";
					goto IL_06bd;
					IL_06bd:
					num2 = 67;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_06cb;
					IL_06cb:
					num2 = 68;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','310','Nakshi Rec','NKSRC','I','F','A','','MFG NAKSHI REC','N','A','N','Nakshi Rec','MFG_DATA')";
					goto IL_0706;
					IL_0706:
					num2 = 69;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0714;
					IL_0714:
					num2 = 70;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','311','Setting Isu','STNIS','O','F','A','','MFG STNG ISU','N','A','N','Setting Isu','MFG_DATA')";
					goto IL_074f;
					IL_074f:
					num2 = 71;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_075d;
					IL_075d:
					num2 = 72;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','312','Setting Rec','STNRC','I','F','A','','MFG STNG REC','N','A','N','Setting Rec','MFG_DATA')";
					goto IL_0798;
					IL_0798:
					num2 = 73;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_07a6;
					IL_07a6:
					num2 = 74;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','313','Mino Isu','MNOIS','O','F','A','','MFG MINO ISU','N','A','N','Mino Isu','MFG_DATA')";
					goto IL_07e1;
					IL_07e1:
					num2 = 75;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_07ef;
					IL_07ef:
					num2 = 76;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','314','Mino Rec','MNORC','I','F','A','','MFG MINO REC','N','A','N','Mino Rec','MFG_DATA')";
					goto IL_082a;
					IL_082a:
					num2 = 77;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0838;
					IL_0838:
					num2 = 78;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','315','Filling2 Isu','FL2IS','O','F','A','','MFG FILE2 ISU','N','A','N','Filling2 Isu','MFG_DATA')";
					goto IL_0873;
					IL_0873:
					num2 = 79;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0881;
					IL_0881:
					num2 = 80;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','316','Filling2 Rec','FL2RC','I','F','A','','MFG FILE2 REC','N','A','N','Filling2 Rec','MFG_DATA')";
					goto IL_08bc;
					IL_08bc:
					num2 = 81;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_08ca;
					IL_08ca:
					num2 = 82;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','317','Polish Isu','POLIS','O','F','A','','MFG POLISH ISU','N','A','N','Polish Isu','MFG_DATA')";
					goto IL_0905;
					IL_0905:
					num2 = 83;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0913;
					IL_0913:
					num2 = 84;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','318','Polish Rec','POLRC','I','F','A','','MFG POLISH REC','N','A','N','Polish Rec','MFG_DATA')";
					goto IL_094e;
					IL_094e:
					num2 = 85;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_095c;
					IL_095c:
					num2 = 86;
					DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','301','Melting Isu','MLTIS','O','F','A','','MLT ISU','N','A','N','Metal Isu','MFG_DATA')";
					goto IL_0997;
					IL_0997:
					num2 = 87;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_09a5;
					IL_09a5:
					num2 = 88;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MLT ISU',1,'O','00001','CASH ON HAND')");
					goto IL_09b3;
					IL_09b3:
					num2 = 89;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MLT ISU',2,'O','00042','KASAR AVAK A/C')");
					goto IL_09c1;
					IL_09c1:
					num2 = 90;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST REC',1,'I','00001','CASH ON HAND')");
					goto IL_09cf;
					IL_09cf:
					num2 = 91;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_09dd;
					IL_09dd:
					num2 = 92;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_09eb;
					IL_09eb:
					num2 = 93;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO REC',1,'I','00001','CASH ON HAND')");
					goto IL_09f9;
					IL_09f9:
					num2 = 94;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0a07;
					IL_0a07:
					num2 = 95;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES (MFG MINO REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0a15;
					IL_0a15:
					num2 = 96;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI REC',1,'I','00001','CASH ON HAND')");
					goto IL_0a23;
					IL_0a23:
					num2 = 97;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0a31;
					IL_0a31:
					num2 = 98;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0a3f;
					IL_0a3f:
					num2 = 99;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE2 REC',1,'I','00001','CASH ON HAND')");
					goto IL_0a4d;
					IL_0a4d:
					num2 = 100;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE2 REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0a5b;
					IL_0a5b:
					num2 = 101;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE2 REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0a69;
					IL_0a69:
					num2 = 102;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG WEX REC',1,'I','00001','CASH ON HAND')");
					goto IL_0a77;
					IL_0a77:
					num2 = 103;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG WEX REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0a85;
					IL_0a85:
					num2 = 104;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG WEX REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0a93;
					IL_0a93:
					num2 = 105;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0aa1;
					IL_0aa1:
					num2 = 106;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0aaf;
					IL_0aaf:
					num2 = 107;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0abd;
					IL_0abd:
					num2 = 108;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG POLISH ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0acb;
					IL_0acb:
					num2 = 109;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG CAST ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0ad9;
					IL_0ad9:
					num2 = 110;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG MINO ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0ae7;
					IL_0ae7:
					num2 = 111;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG NAKSHI ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0af5;
					IL_0af5:
					num2 = 112;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE2 ISU',1,'O','00001','CASH ON HAND')");
					goto IL_0b03;
					IL_0b03:
					num2 = 113;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG GHAT REC',1,'I','00001','CASH ON HAND')");
					goto IL_0b11;
					IL_0b11:
					num2 = 114;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG GHAT REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0b1f;
					IL_0b1f:
					num2 = 115;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG GHAT REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0b2d;
					IL_0b2d:
					num2 = 116;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE REC',1,'I','00001','CASH ON HAND')");
					goto IL_0b3b;
					IL_0b3b:
					num2 = 117;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0b49;
					IL_0b49:
					num2 = 118;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG FILE REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0b57;
					IL_0b57:
					num2 = 119;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP REC',1,'I','00001','CASH ON HAND')");
					goto IL_0b65;
					IL_0b65:
					num2 = 120;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0b73;
					IL_0b73:
					num2 = 121;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG PREP REC',3,'I','00056','LABOUR EXP A/C')");
					goto IL_0b81;
					IL_0b81:
					num2 = 122;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG REC',1,'I','00001','CASH ON HAND')");
					goto IL_0b8f;
					IL_0b8f:
					num2 = 123;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG STNG REC',2,'I','00008','PURCHASE GOLD A/C')");
					goto IL_0b9d;
					end_IL_0001_2:
					break;
				}
				num2 = 128;
				DC_Main.ExeQuteDc("UPDATE BOOK_IDTL SET MAIN_BOOK = 'GHAT ISU' WHERE MAIN_BOOK = 'MLT ISU'");
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3583;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	public static void Other_set()
	{
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'BAR_DATA',BOOK_TBL_DETL = 'BAR_DETL' WHERE MAIN_BOOK IN ('OPSTK','TAG GEN')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CASH_DATA',BOOK_TBL_DETL = 'CASH_DATA' WHERE MAIN_BOOK IN ('CASH REC','CASH PAY','BANK REC','BANK PAY')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'BAR_CAN_DATA',BOOK_TBL_DETL = 'BAR_CAN_DETL' WHERE MAIN_BOOK IN ('TAG CANCEL','STOCK ADJUST','PHY STOCK','TAG TRFR','COUNTER TRFR','SF PRINT','TAG ADJ')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CONTRA_DATA',BOOK_TBL_DETL = 'CONTRA_DATA' WHERE MAIN_BOOK = 'CONTRA'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'APR_DATA',BOOK_TBL_DETL = 'APR_DETL' WHERE MAIN_BOOK IN ('APR ISU','APR RTN','KARIGAR ORDER','CON REC','CON ISU')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'SL_ORD_DATA',BOOK_TBL_DETL = 'SL_ORD_DETL' WHERE MAIN_BOOK IN ('SALES ORDER','TOUR ORDER')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'SL_DATA',BOOK_TBL_DETL = 'SL_DETL' WHERE MAIN_BOOK IN ('SALES','E INVOICE','SALES RETURNE','E CRNT','SL QUOT')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'RATE_CUT_DATA',BOOK_TBL_DETL = 'RATE_CUT_ISU' WHERE MAIN_BOOK IN ('WH SALES','RATE CUT','VP PARCEL','BUL WH SALE','TOUR SALES')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'PR_DATA',BOOK_TBL_DETL = 'PR_DETL' WHERE MAIN_BOOK IN ('PURCHASE','PURC RETURN','CON PUR','TAG PURCHASE','PR QUOT')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'KR_DATA',BOOK_TBL_DETL = 'KR_DETL' WHERE MAIN_BOOK IN ('KARIGAR ISSUE','KARIGAR RECEIPT','OLD ITEM SALES')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'REP_DATA',BOOK_TBL_DETL = 'REP_DETL' WHERE MAIN_BOOK IN ('CUSTREP RECEIPT','KRREP ISSUE','KRREP RECEIPT','CUSTREP ISSUE')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'INOUT_DATA',BOOK_TBL_DETL = 'INOUT_DETL' WHERE MAIN_BOOK IN ('OUTWORD','INWORD')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'DHRN_ISU_DATA',BOOK_TBL_DETL = 'DHRN_ISU_DETL' WHERE MAIN_BOOK = 'DHIRAN ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'DHRN_REC_DATA',BOOK_TBL_DETL = 'DHRN_REC_DETL' WHERE MAIN_BOOK IN ('INTREST RECIVED')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'DHRN_REC_DATA',BOOK_TBL_DETL = 'DHRN_REC_DETL' WHERE MAIN_BOOK IN ('DHIRAN RECEIVED','OS LETTER')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'DHRN_ISU_DATA',BOOK_TBL_DETL = 'DHRN_ISU_DETL' WHERE MAIN_BOOK = 'LOAN REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'DHRN_REC_DATA',BOOK_TBL_DETL = 'DHRN_REC_DETL' WHERE MAIN_BOOK = 'LOAN ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'DHRN_REC_DATA',BOOK_TBL_DETL = 'DHRN_REC_DETL' WHERE MAIN_BOOK = 'LOAN INT ENTRY'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'AD_DATA',BOOK_TBL_DETL = 'AD_DATA' WHERE MAIN_BOOK IN ('MEMB ENTRY','MEMB OPENING')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'AD_ADJ',BOOK_TBL_DETL = 'AD_ADJ' WHERE MAIN_BOOK IN ('MEMB ADJUST','MEMB GOLD ADJ')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CONTRA_DATA',BOOK_TBL_DETL = 'CONTRA_DATA' WHERE MAIN_BOOK = 'FINE JV'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CARD_DATA',BOOK_TBL_DETL = 'CARD_DATA' WHERE MAIN_BOOK = 'CARD ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'SL_ORD_ADJ',BOOK_TBL_DETL = 'SL_ORD_ADJ' WHERE MAIN_BOOK = 'ORDER CANCEL'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'LBR_DATA',BOOK_TBL_DETL = 'LBR_ISU_DETL' WHERE MAIN_BOOK IN ('LABOUR WORK','TAG WT CHANGE','TAG SPLIT')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'MFG_DATA',BOOK_TBL_DETL = 'MFG_DETL' WHERE MAIN_BOOK IN ('GHAT REC','JDTR ISU','JDTR REC','FTNG REC','FTNG ISU','JDTR TAG','CHEDIYA ISU','CHEDIYA REC','PARA ISU','PARA REC')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'EMP_DATA',BOOK_TBL_DETL = 'EMP_DATA' WHERE MAIN_BOOK = 'EMP JV'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CASH_DATA',BOOK_TBL_DETL = 'BILL_OS_DATA' WHERE MAIN_BOOK = 'BILL REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'VP_ADJ_DATA',BOOK_TBL_DETL = 'VP_ADJ_DATA' WHERE MAIN_BOOK = 'VP REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'BUL_DATA',BOOK_TBL_DETL = 'BUL_DATA' WHERE MAIN_BOOK IN ('BUL SALE','BUL PURC','BUL LC SALE')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'PAY_DATA',BOOK_TBL_DETL = 'PAY_DETL' WHERE MAIN_BOOK IN ('OTH INC','OTH EXP','OTH COMM')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'RATE_CUT_DATA',BOOK_TBL_DETL = 'RATE_CUT_REC' WHERE MAIN_BOOK = 'WH RTN'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'MLT_DATA',BOOK_TBL_DETL = 'MLT_DETL' WHERE MAIN_BOOK = 'MLT PRO'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CUT_DATA',BOOK_TBL_DETL = 'CUT_DETL' WHERE MAIN_BOOK IN ('FINE SALE','FINE PURC','OTH COMM')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'LOCT_AMT',BOOK_TBL_DETL = 'LOCT_AMT' WHERE MAIN_BOOK IN ('AMT IN','AMT OUT')");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'LDR_ADJ_DATA',BOOK_TBL_DETL = 'LDR_ADJ_DATA' WHERE MAIN_BOOK = 'LD ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'SL_DATA',BOOK_TBL_DETL = 'SL_DETL' WHERE MAIN_BOOK = 'B2B SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'PR_DATA',BOOK_TBL_DETL = 'PR_DETL' WHERE MAIN_BOOK = 'B2B PURC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CUT_DATA',BOOK_TBL_DETL = 'CUT_DETL' WHERE MAIN_BOOK = 'HEDGING FIX'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'SL_DATA',BOOK_TBL_DETL = 'SL_DETL' WHERE MAIN_BOOK = 'ITEM SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'PR_DATA',BOOK_TBL_DETL = 'PR_DETL' WHERE MAIN_BOOK = 'ITEM PURC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'PR_DATA',BOOK_TBL_DETL = 'PR_DETL' WHERE MAIN_BOOK = 'CON PUR'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Opening' WHERE MAIN_BOOK = 'OPSTK'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Cash Received' WHERE MAIN_BOOK = 'CASH REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Cash Payment' WHERE MAIN_BOOK = 'CASH PAY'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Bank Received' WHERE MAIN_BOOK = 'BANK REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Bank Payment' WHERE MAIN_BOOK = 'BANK PAY'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Only Tag Entry' WHERE MAIN_BOOK = 'TAG GEN'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Cancel' WHERE MAIN_BOOK = 'TAG CANCEL'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Contra Entry' WHERE MAIN_BOOK = 'CONTRA'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Approval Isu' WHERE MAIN_BOOK = 'APR ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Approval Rtn' WHERE MAIN_BOOK = 'APR RTN'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Sales Order' WHERE MAIN_BOOK = 'SALES ORDER'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'E Invoice' WHERE MAIN_BOOK = 'E INVOICE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Sales' WHERE MAIN_BOOK = 'SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Wh Sales' WHERE MAIN_BOOK = 'WH SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Purchase' WHERE MAIN_BOOK = 'PURCHASE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Sales Return' WHERE MAIN_BOOK = 'SALES RETURNE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Purchase Rtn' WHERE MAIN_BOOK = 'PURC RETURN'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Kr Issue' WHERE MAIN_BOOK = 'KARIGAR ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Kr Design Isu' WHERE MAIN_BOOK = 'KARIGAR ORDER'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Kr Received' WHERE MAIN_BOOK = 'KARIGAR RECEIPT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Cust Repar Rec' WHERE MAIN_BOOK = 'CUSTREP RECEIPT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Kr Repar Isu' WHERE MAIN_BOOK = 'KRREP ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Kr Repar Rec' WHERE MAIN_BOOK = 'KRREP RECEIPT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Cust Repar Isu' WHERE MAIN_BOOK = 'CUSTREP ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Out' WHERE MAIN_BOOK = 'OUTWORD'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock In' WHERE MAIN_BOOK = 'INWORD'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Old Item Sales' WHERE MAIN_BOOK = 'OLD ITEM SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Adjust' WHERE MAIN_BOOK = 'STOCK ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Rate Cut' WHERE MAIN_BOOK = 'RATE CUT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Outword' WHERE MAIN_BOOK = 'OUTWORD'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Inword' WHERE MAIN_BOOK = 'INWORD'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Card Rec' WHERE MAIN_BOOK = 'CARD ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Dhrn Issue' WHERE MAIN_BOOK = 'DHIRAN ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Intrest Rec' WHERE MAIN_BOOK = 'INTREST RECIVED'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Dhrn Rec' WHERE MAIN_BOOK = 'DHIRAN RECEIVED'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Intrest All' WHERE MAIN_BOOK = 'LOAN INT ENTRY'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Loan Received' WHERE MAIN_BOOK = 'LOAN REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Loan Issue' WHERE MAIN_BOOK = 'LOAN ISSUE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Intrest Isu All' WHERE MAIN_BOOK = 'INT LOAN ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Memb Entry' WHERE MAIN_BOOK = 'MEMB ENTRY'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Memb Opening' WHERE MAIN_BOOK = 'MEMB OPENING'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Memb Adjust' WHERE MAIN_BOOK = 'MEMB ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Physical Stock' WHERE MAIN_BOOK = 'PHY STOCK'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Service Comm' WHERE MAIN_BOOK = 'OTH COMM'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Card Rec' WHERE MAIN_BOOK = 'CARD ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Fine Jv Entry' WHERE MAIN_BOOK = 'FINE JV'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Order Cancel' WHERE MAIN_BOOK = 'ORDER CANCEL'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Labour Work' WHERE MAIN_BOOK = 'LABOUR WORK'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Wt Change' WHERE MAIN_BOOK = 'TAG WT CHANGE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Reminder Entry' WHERE MAIN_BOOK = 'REM ENTRY'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Rec' WHERE MAIN_BOOK = 'CON REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Isu' WHERE MAIN_BOOK = 'CON ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Purc' WHERE MAIN_BOOK = 'CON PUR'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Bill Wise Rec' WHERE MAIN_BOOK = 'BILL REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Other Expenses' WHERE MAIN_BOOK = 'OTH EXP'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Other Income' WHERE MAIN_BOOK = 'OTH INC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Ghat Rec' WHERE MAIN_BOOK = 'GHAT REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Jadtar Isu' WHERE MAIN_BOOK = 'JDTR ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Jadtar Rec' WHERE MAIN_BOOK = 'JDTR REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Fitting Isu' WHERE MAIN_BOOK = 'FTNG ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Fitting Rec' WHERE MAIN_BOOK = 'FTNG REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Chediya Isu' WHERE MAIN_BOOK = 'CHEDIYA ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Chediya Rec' WHERE MAIN_BOOK = 'CHEDIYA REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Para Isu' WHERE MAIN_BOOK = 'PARA ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Para Rec' WHERE MAIN_BOOK = 'PARA REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'JdtTag Entry' WHERE MAIN_BOOK = 'JDTR TAG'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Transfer' WHERE MAIN_BOOK = 'TAG TRFR'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Wise Purc' WHERE MAIN_BOOK = 'TAG PURCHASE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Counter Trfr' WHERE MAIN_BOOK = 'COUNTER TRFR'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Wh Sl Return' WHERE MAIN_BOOK = 'WH RTN'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Employee Jv' WHERE MAIN_BOOK = 'EMP JV'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'E CrntNote' WHERE MAIN_BOOK = 'E CRNT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Amt In' WHERE MAIN_BOOK = 'AMT IN'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Amt Out' WHERE MAIN_BOOK = 'AMT OUT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Adjust' WHERE MAIN_BOOK = 'STOCK ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Lot Opening' WHERE MAIN_BOOK = 'ITM LOT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Gold Adjust' WHERE MAIN_BOOK = 'MEMB GOLD ADJ'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Split' WHERE MAIN_BOOK = 'TAG SPLIT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Rec' WHERE MAIN_BOOK = 'CON REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Rec' WHERE MAIN_BOOK = 'CON ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Purc' WHERE MAIN_BOOK = 'CON PUR'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Bill Wise Rec' WHERE MAIN_BOOK = 'BILL REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Ledger Adjust' WHERE MAIN_BOOK = 'LD ADJUST'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Vp Parcel' WHERE MAIN_BOOK = 'VP PARCEL'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Vp Adjust' WHERE MAIN_BOOK = 'VP REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stone/Dm-Cf' WHERE MAIN_BOOK = 'SF PRINT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Dhrn Os Letter' WHERE MAIN_BOOK = 'OS LETTER'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Pr Quotation' WHERE MAIN_BOOK = 'PR QUOT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Sale Booking' WHERE MAIN_BOOK = 'BUL SALE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Bul LcBook' WHERE MAIN_BOOK = 'BUL LC SALE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Purc Booking' WHERE MAIN_BOOK = 'BUL PURC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Bul Sales' WHERE MAIN_BOOK = 'BUL WH SALE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Melting Work' WHERE MAIN_BOOK = 'MLT PRO'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Ghat Isu' WHERE MAIN_BOOK = 'GHAT ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Ghat Rec' WHERE MAIN_BOOK = 'MFG GHAT REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Filling Isu' WHERE MAIN_BOOK = 'MFG FILE ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Filling Rec' WHERE MAIN_BOOK = 'MFG FILE REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Pre Polish Isu' WHERE MAIN_BOOK = 'MFG PREP ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Pre Polish Rec' WHERE MAIN_BOOK = 'MFG PREP REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Setting Isu' WHERE MAIN_BOOK = 'MFG STNG ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Setting Rec' WHERE MAIN_BOOK = 'MFG STNG REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Polish Isu' WHERE MAIN_BOOK = 'MFG POLISH ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Polish Rec' WHERE MAIN_BOOK = 'MFG POLISH REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'MfgTag Entry' WHERE MAIN_BOOK = 'MFG TAG'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Other Expenses' WHERE MAIN_BOOK = 'OTH EXP'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Other Income' WHERE MAIN_BOOK = 'OTH INC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tag Adjust' WHERE MAIN_BOOK = 'TAG ADJ'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Fine Sales' WHERE MAIN_BOOK = 'FINE SALE'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Fine Purc' WHERE MAIN_BOOK = 'FINE PURC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Wh Quotation' WHERE MAIN_BOOK = 'WH QUOT'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Isu' WHERE MAIN_BOOK = 'EMP ISU'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Stock Rec' WHERE MAIN_BOOK = 'EMP REC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tour Order' WHERE MAIN_BOOK = 'TOUR ORDER'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Tour Sales' WHERE MAIN_BOOK = 'TOUR SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Item Sales' WHERE MAIN_BOOK = 'ITEM SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Item Purc' WHERE MAIN_BOOK = 'ITEM PURC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'B2B Purc' WHERE MAIN_BOOK = 'B2B PURC'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'B2B Sales' WHERE MAIN_BOOK = 'B2B SALES'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Hedging Fix' WHERE MAIN_BOOK = 'HEDGING FIX'");
		DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET MENU_NAME = 'Consi Purc' WHERE MAIN_BOOK = 'CON PUR'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'N'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Opening'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Purchase'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Purchase Rtn'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Sales'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Sales Return'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Sales Order'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Wh Sales'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Cash Received'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Cash Payment'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Bank Received'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Bank Payment'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Contra Entry'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Rate Cut'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Approval Isu'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Approval Rtn'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Labour Work'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Old Item Sales'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Bill Wise Rec'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Fine Jv Entry'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Other Expenses'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Vp Parcel'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Consi Rec'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Consi Purc'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Consi Isu'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Only Tag Entry'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Cancel'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Print'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Stock Adjust'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Order Cancel'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Reminder Entry'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Physical Stock'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Transfer'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Wt Change'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Sms'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Counter Trfr'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Kr Issue'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Kr Received'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Kr Design Isu'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Cust Repar Rec'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Kr Repar Isu'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Kr Repar Rec'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Cust Repar Isu'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Kr Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Member Mast'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Memb Opening'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Memb Entry'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Memb Adjust'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Scheme Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Scheme Ledger'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Dhrn Issue'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Dhrn Rec'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Intrest Rec'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Dhiran Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Intrest All'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Dhrn Os Letter'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Dhrn Due'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Loan Received'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Loan Intrest'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Loan Issue'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Loan Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Intrest Isu All'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Ledger Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Stock Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Stock'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Sales Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Purchase Rpt'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Approval Rpt'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Order Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Cash Bank'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Gst Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Party Os'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Final Reports'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Estmate'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Tag Image'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Consi Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Trading Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'HuId Report'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Rojmel'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Stock With Fine'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Sale Zoom'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Purc Zoom'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Old Stock'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Item InOut'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Reminder Rpt'");
		DC_Main.ExeQuteMc("UPDATE MENU_DATA SET TILE_ITEM = 'Y' WHERE SM_MAIN_NAME = 'Address Print'");
	}

	public static void Uae_Setting()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 1831:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0027;
						case 4:
							goto IL_0034;
						case 5:
							goto IL_0041;
						case 6:
							goto IL_004e;
						case 7:
							goto IL_005b;
						case 8:
							goto IL_0068;
						case 9:
							goto IL_0075;
						case 10:
							goto IL_0083;
						case 11:
							goto IL_0091;
						case 12:
							goto IL_009f;
						case 13:
							goto IL_00ad;
						case 14:
							goto IL_00bb;
						case 15:
							goto IL_00c9;
						case 16:
							goto IL_00d7;
						case 17:
							goto IL_00e5;
						case 18:
							goto IL_00f3;
						case 19:
							goto IL_0101;
						case 20:
							goto IL_010f;
						case 21:
							goto IL_011d;
						case 22:
							goto IL_012b;
						case 23:
							goto IL_0139;
						case 24:
							goto IL_0147;
						case 25:
							goto IL_0155;
						case 26:
							goto IL_0163;
						case 27:
							goto IL_0171;
						case 28:
							goto IL_017f;
						case 29:
							goto IL_018d;
						case 30:
							goto IL_019b;
						case 31:
							goto IL_01a9;
						case 32:
							goto IL_01b7;
						case 33:
							goto IL_01c5;
						case 34:
							goto IL_01d3;
						case 35:
							goto IL_01e1;
						case 36:
							goto IL_01ef;
						case 37:
							goto IL_01fd;
						case 38:
							goto IL_0219;
						case 39:
							goto IL_0227;
						case 40:
							goto IL_0234;
						case 41:
							goto IL_0250;
						case 42:
							goto IL_025e;
						case 43:
							goto IL_026b;
						case 44:
							goto IL_0287;
						case 45:
							goto IL_0295;
						case 46:
							goto IL_02b1;
						case 47:
							goto IL_02bf;
						case 48:
							goto IL_02db;
						case 49:
							goto IL_02e9;
						case 50:
							goto IL_0305;
						case 51:
							goto IL_0317;
						case 52:
							goto IL_0332;
						case 53:
							goto IL_034e;
						case 54:
						case 55:
							goto IL_035e;
						case 56:
							goto IL_037a;
						case 57:
							goto IL_038c;
						case 58:
							goto IL_03aa;
						case 59:
							goto IL_03c6;
						case 60:
							goto IL_03d4;
						case 61:
							goto IL_03f0;
						case 62:
							goto IL_03fe;
						case 63:
							goto IL_041a;
						case 64:
							goto IL_0428;
						case 65:
							goto IL_0444;
						case 66:
						case 67:
							goto IL_0454;
						case 68:
							goto IL_0470;
						case 69:
							goto IL_047e;
						case 70:
							goto IL_049a;
						case 71:
							goto IL_04a8;
						case 72:
							goto IL_04c4;
						case 73:
							goto IL_04d2;
						case 74:
							goto IL_04ee;
						case 75:
							goto IL_04fc;
						case 76:
							goto IL_0518;
						case 77:
							goto IL_0526;
						case 78:
							goto IL_0542;
						case 79:
							goto IL_0550;
						case 80:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 81:
						case 82:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0526:
					num2 = 77;
					DC_Main.RsQry = "UPDATE TAX_MAST SET TAX_NAME = 'VAT 5%',TAX_AC = '00014' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '11'";
					goto IL_0542;
					IL_0542:
					num2 = 78;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0550;
					IL_0518:
					num2 = 76;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0526;
					IL_0550:
					num2 = 79;
					DC_Main.RsQry = "UPDATE YEAR_MAST SET OP_DATE = '01/01/" + Strings.Mid(DC_Main.MCo_year, 1, 4) + "',CL_DATE = '31/12/" + Strings.Mid(DC_Main.MCo_year, 1, 4) + "',YEAR_MONTH = '01'  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'";
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0027;
					IL_0027:
					num2 = 3;
					DC_Main.ExeQuteDc("DELETE FROM STATE_MAST");
					goto IL_0034;
					IL_0034:
					num2 = 4;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('01','01','Abu Dhabi')");
					goto IL_0041;
					IL_0041:
					num2 = 5;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('02','02','Dubai')");
					goto IL_004e;
					IL_004e:
					num2 = 6;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('03','03','Sharjah')");
					goto IL_005b;
					IL_005b:
					num2 = 7;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('04','04','Ajman')");
					goto IL_0068;
					IL_0068:
					num2 = 8;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('05','05','Umm Al Quwain')");
					goto IL_0075;
					IL_0075:
					num2 = 9;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('06','06','Ras Al Khaimah')");
					goto IL_0083;
					IL_0083:
					num2 = 10;
					DC_Main.ExeQuteDc("INSERT INTO STATE_MAST(STATE_CODE,STATE_SHORT,STATE_NAME) VALUES ('07','07','Fujairah')");
					goto IL_0091;
					IL_0091:
					num2 = 11;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET COUNTRY_ID = '971'");
					goto IL_009f;
					IL_009f:
					num2 = 12;
					DC_Main.ExeQuteDc("DELETE FROM BOOK_IDTL WHERE MAIN_BOOK = 'B2B SALES'");
					goto IL_00ad;
					IL_00ad:
					num2 = 13;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',1,'O','00003','SALES GOLD A/C')");
					goto IL_00bb;
					IL_00bb:
					num2 = 14;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',2,'O','00001','CASH ON HAND')");
					goto IL_00c9;
					IL_00c9:
					num2 = 15;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',3,'O','00057','KASAR JAVK A/C')");
					goto IL_00d7;
					IL_00d7:
					num2 = 16;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',4,'O','00041','LABOUR INCOM. A/C')");
					goto IL_00e5;
					IL_00e5:
					num2 = 17;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',5,'O','00076','DISCOUNT A/C')");
					goto IL_00f3;
					IL_00f3:
					num2 = 18;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',6,'O','00004','SALES SILVER A/C')");
					goto IL_0101;
					IL_0101:
					num2 = 19;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',7,'O','00090','SALE GOLD FIXING')");
					goto IL_010f;
					IL_010f:
					num2 = 20;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B SALES',8,'O','00091','SALE SILVER FIXING')");
					goto IL_011d;
					IL_011d:
					num2 = 21;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',1,'I','00008','PURCHASE A/C')");
					goto IL_012b;
					IL_012b:
					num2 = 22;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',2,'I','00001','CASH ON HAND')");
					goto IL_0139;
					IL_0139:
					num2 = 23;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',3,'I','00042','KASAR AVAK A/C')");
					goto IL_0147;
					IL_0147:
					num2 = 24;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',4,'I','00056','LABOUR EXP A/C')");
					goto IL_0155;
					IL_0155:
					num2 = 25;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',5,'I','00076','DISCOUNT A/C')");
					goto IL_0163;
					IL_0163:
					num2 = 26;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',6,'I','00009','PURCHASE SILVER A/C')");
					goto IL_0171;
					IL_0171:
					num2 = 27;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',7,'I','00092','PURC GOLD FIXING')");
					goto IL_017f;
					IL_017f:
					num2 = 28;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('B2B PURC',8,'I','00093','PURC SILVER FIXING')");
					goto IL_018d;
					IL_018d:
					num2 = 29;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',1,'O','00001','CASH ON HAND')");
					goto IL_019b;
					IL_019b:
					num2 = 30;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',2,'O','00090','SALE GOLD FIXING A/C')");
					goto IL_01a9;
					IL_01a9:
					num2 = 31;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',3,'O','00091','SALE SILVER FIXING A/C')");
					goto IL_01b7;
					IL_01b7:
					num2 = 32;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',4,'O','00092','PURC GOLD FIXING A/C')");
					goto IL_01c5;
					IL_01c5:
					num2 = 33;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',5,'O','00093','PURC SILVER FIXING A/C')");
					goto IL_01d3;
					IL_01d3:
					num2 = 34;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',6,'O','00057','KASAR JAVK A/C')");
					goto IL_01e1;
					IL_01e1:
					num2 = 35;
					DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('HEDGING FIX',7,'O','00042','KASAR AVAK A/C')");
					goto IL_01ef;
					IL_01ef:
					num2 = 36;
					DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_MAIN_NAME = 'Tax Report',SM_NAME = 'Tax Report' WHERE MAIN_SRNO = '05' AND SM_MAIN_CODE = '09' AND SM_MAIN_NAME = 'Gst Report'");
					goto IL_01fd;
					IL_01fd:
					num2 = 37;
					DC_Main.RsQry = "UPDATE CO_SET SET TAX_CODE = '11' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_0219;
					IL_0219:
					num2 = 38;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0227;
					IL_0227:
					num2 = 39;
					DC_Main.MsSlRowChange = "11";
					goto IL_0234;
					IL_0234:
					num2 = 40;
					DC_Main.RsQry = "UPDATE CO_SET SET PURC_WITH_LBR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_0250;
					IL_0250:
					num2 = 41;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_025e;
					IL_025e:
					num2 = 42;
					DC_Main.MsPurcWithLbr = "N";
					goto IL_026b;
					IL_026b:
					num2 = 43;
					DC_Main.RsQry = "UPDATE CO_SET_NEW SET SALES_WITH_HMTAX = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_0287;
					IL_0287:
					num2 = 44;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0295;
					IL_0295:
					num2 = 45;
					DC_Main.RsQry = "UPDATE CO_SET_NEW SET PURC_WITH_HMTAX = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_02b1;
					IL_02b1:
					num2 = 46;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_02bf;
					IL_02bf:
					num2 = 47;
					DC_Main.RsQry = "INSERT INTO AC_MAST (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_SHORT,AC_GR,AC_MAIN_GR,AC_AREA,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_TYPE,DATA_TRFR,VISIT_TRAN,APP_TRFR)  VALUES ('" + DC_Main.MCo_code + "','00','00090','SALES GOLD FIXING A/C','','16','2','','','','','','','','','','','A','N','AC','N')";
					goto IL_02db;
					IL_02db:
					num2 = 48;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_02e9;
					IL_02e9:
					num2 = 49;
					DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '00084'";
					goto IL_0305;
					IL_0305:
					num2 = 50;
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0317;
					IL_0317:
					num2 = 51;
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						goto IL_0332;
					}
					goto IL_035e;
					IL_0332:
					num2 = 52;
					DC_Main.RsQry = "INSERT INTO AC_MAST (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_SHORT,AC_GR,AC_MAIN_GR,AC_AREA,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_TYPE,DATA_TRFR,VISIT_TRAN,APP_TRFR)  VALUES ('" + DC_Main.MCo_code + "','00','00084','VAT PLANET TAX FREE','','12','1','','','','','','','','','','','A','N','AC','N')";
					goto IL_034e;
					IL_034e:
					num2 = 53;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_035e;
					IL_035e:
					num2 = 55;
					DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '00090'";
					goto IL_037a;
					IL_037a:
					num2 = 56;
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_038c;
					IL_038c:
					num2 = 57;
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						goto IL_03aa;
					}
					goto IL_0454;
					IL_03aa:
					num2 = 58;
					DC_Main.RsQry = "INSERT INTO AC_MAST (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_SHORT,AC_GR,AC_MAIN_GR,AC_AREA,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_TYPE,DATA_TRFR,VISIT_TRAN,APP_TRFR)  VALUES ('" + DC_Main.MCo_code + "','00','00090','SALES GOLD FIXING A/C','','16','2','','','','','','','','','','','A','N','AC','N')";
					goto IL_03c6;
					IL_03c6:
					num2 = 59;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_03d4;
					IL_03d4:
					num2 = 60;
					DC_Main.RsQry = "INSERT INTO AC_MAST (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_SHORT,AC_GR,AC_MAIN_GR,AC_AREA,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_TYPE,DATA_TRFR,VISIT_TRAN,APP_TRFR)  VALUES ('" + DC_Main.MCo_code + "','00','00091','SALES SILVER FIXING A/C','','16','2','','','','','','','','','','','A','N','AC','N')";
					goto IL_03f0;
					IL_03f0:
					num2 = 61;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_03fe;
					IL_03fe:
					num2 = 62;
					DC_Main.RsQry = "INSERT INTO AC_MAST (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_SHORT,AC_GR,AC_MAIN_GR,AC_AREA,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_TYPE,DATA_TRFR,VISIT_TRAN,APP_TRFR)  VALUES ('" + DC_Main.MCo_code + "','00','00092','PURCHASE GOLD FIXING A/C','','07','1','','','','','','','','','','','A','N','AC','N')";
					goto IL_041a;
					IL_041a:
					num2 = 63;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0428;
					IL_0428:
					num2 = 64;
					DC_Main.RsQry = "INSERT INTO AC_MAST (CO_CODE,LC_CODE,AC_CODE,AC_NAME,AC_SHORT,AC_GR,AC_MAIN_GR,AC_AREA,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_PHONE,AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_TYPE,DATA_TRFR,VISIT_TRAN,APP_TRFR)  VALUES ('" + DC_Main.MCo_code + "','00','00093','PURCHASE SILVER FIXING A/C','','07','1','','','','','','','','','','','A','N','AC','N')";
					goto IL_0444;
					IL_0444:
					num2 = 65;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0454;
					IL_0454:
					num2 = 67;
					DC_Main.RsQry = "UPDATE CO_SET_NEW SET PROFIT_RPT_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_0470;
					IL_0470:
					num2 = 68;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_047e;
					IL_047e:
					num2 = 69;
					DC_Main.RsQry = "UPDATE CO_SET SET FINE_STK_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_049a;
					IL_049a:
					num2 = 70;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_04a8;
					IL_04a8:
					num2 = 71;
					DC_Main.RsQry = "UPDATE CO_SET_NEW SET TOT_FINE_STK_TYPE = 'I' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_04c4;
					IL_04c4:
					num2 = 72;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_04d2;
					IL_04d2:
					num2 = 73;
					DC_Main.RsQry = "UPDATE CO_SET SET FX_CODE = 'AED' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_04ee;
					IL_04ee:
					num2 = 74;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_04fc;
					IL_04fc:
					num2 = 75;
					DC_Main.RsQry = "UPDATE CO_SET SET FX_RATE = 3.67 WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_0518;
					end_IL_0001_2:
					break;
				}
				num2 = 80;
				DC_Main.ExeQuteMc(DC_Main.RsQry);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1831;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	public static void ItemCreate()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 361:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0024;
						case 4:
							goto IL_0031;
						case 5:
							goto IL_003e;
						case 6:
							goto IL_004b;
						case 7:
							goto IL_0058;
						case 8:
							goto IL_0065;
						case 9:
						case 10:
							goto IL_0074;
						case 11:
							goto IL_0090;
						case 12:
							goto IL_009e;
						case 13:
							goto IL_00ac;
						case 14:
							goto IL_00ba;
						case 15:
							goto IL_00c8;
						case 16:
							goto IL_00e4;
						case 17:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 18:
						case 19:
						case 20:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00ba:
					num2 = 14;
					DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,  MIN_STK,MAIN_USER,AC_ITEM,STK_DISPLAY,OTH_RATE,SAFE_NAME,DATA_TRFR,TAG_IDTL_COL)  VALUES('01','RN','RANI','G','G','RN','OG','OG','GMS','G','',0,0,0,0,0,0,0,0,'ABC','RN','N',0,'MAIN','N','N')");
					goto IL_00c8;
					IL_00c8:
					num2 = 15;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00e4;
					IL_00ac:
					num2 = 13;
					DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES('01','RN','RANI','ABC','N')");
					goto IL_00ba;
					IL_00e4:
					num2 = 16;
					DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES('01','CP','COPPER','ABC','N')");
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
					{
						goto IL_0024;
					}
					goto IL_0074;
					IL_0024:
					num2 = 3;
					DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES('01','WX','WAX','ABC','N')");
					goto IL_0031;
					IL_0031:
					num2 = 4;
					DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,  MIN_STK,MAIN_USER,AC_ITEM,STK_DISPLAY,OTH_RATE,SAFE_NAME,DATA_TRFR,TAG_IDTL_COL)  VALUES('01','WX','WAX','O','O','WX','OT','OT','GMS','G','',0,0,0,0,0,0,0,0,'ABC','WX','N',0,'MAIN','N','N')");
					goto IL_003e;
					IL_003e:
					num2 = 5;
					DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES('01','MT','MOTI','ABC','N')");
					goto IL_004b;
					IL_004b:
					num2 = 6;
					DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,  MIN_STK,MAIN_USER,AC_ITEM,STK_DISPLAY,OTH_RATE,SAFE_NAME,DATA_TRFR,TAG_IDTL_COL)  VALUES('01','MT','MOTI','O','O','MT','OT','OT','GMS','G','',0,0,0,0,0,0,0,0,'ABC','MT','N',0,'MAIN','N','N')");
					goto IL_0058;
					IL_0058:
					num2 = 7;
					DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES('01','ZM','ZUMKHI','ABC','N')");
					goto IL_0065;
					IL_0065:
					num2 = 8;
					DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,  MIN_STK,MAIN_USER,AC_ITEM,STK_DISPLAY,OTH_RATE,SAFE_NAME,DATA_TRFR,TAG_IDTL_COL)  VALUES('01','ZM','ZUMKHI','O','O','ZM','OT','OT','GMS','G','',0,0,0,0,0,0,0,0,'ABC','ZM','N',0,'MAIN','N','N')");
					goto IL_0074;
					IL_0074:
					num2 = 10;
					if (Operators.CompareString(DC_Main.MsMfgType, "M", false) != 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0090;
					IL_0090:
					num2 = 11;
					DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES('01','MN','MINO','ABC','N')");
					goto IL_009e;
					IL_009e:
					num2 = 12;
					DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,  MIN_STK,MAIN_USER,AC_ITEM,STK_DISPLAY,OTH_RATE,SAFE_NAME,DATA_TRFR,TAG_IDTL_COL)  VALUES('01','MN','MINO','O','O','MN','OT','OT','GMS','G','',0,0,0,0,0,0,0,0,'ABC','MN','N',0,'MAIN','N','N')");
					goto IL_00ac;
					end_IL_0001_2:
					break;
				}
				num2 = 17;
				DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,  MIN_STK,MAIN_USER,AC_ITEM,STK_DISPLAY,OTH_RATE,SAFE_NAME,DATA_TRFR,TAG_IDTL_COL)  VALUES('01','CP','COPPER','O','O','CP','OT','OT','GMS','G','',0,0,0,0,0,0,0,0,'ABC','CP','N',0,'MAIN','N','N')");
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 361;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}
}
