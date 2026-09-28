using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using DataCareNext.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace DataCareNext;

[StandardModule]
internal sealed class DC_Main
{
	private static RegistryKey regKey;

	public static double MainPcW;

	public static double MainPcH;

	public static double PcW;

	public static double PcH;

	public static double ChildW;

	public static double ChildH;

	public static SqlConnection Mc = new SqlConnection();

	public static SqlConnection Dc = new SqlConnection();

	public static SqlConnection CnTr = new SqlConnection();

	public static SqlConnection Img = new SqlConnection();

	public static SqlConnection Crm = new SqlConnection();

	public static SqlConnection Scm = new SqlConnection();

	public static SqlCommand CmdDc = new SqlCommand();

	public static SqlTransaction MsTranDc;

	public static SqlCommand Cmd = new SqlCommand();

	public static SqlDataAdapter Da = new SqlDataAdapter();

	public static SqlCommandBuilder SqlBldr = new SqlCommandBuilder();

	public static DataSet DtSet = new DataSet();

	public static DataTable NewTbl = new DataTable();

	public static DataTable Rshlp;

	public static DataTable RsDg = new DataTable();

	public static DataTable Tbl = new DataTable();

	public static DataTable Mstbl = new DataTable();

	public static DataTable RsTblCol;

	public static string RsQry;

	public static DataTable RsTax;

	public static DataTable RsAc;

	public static DataTable RsIt;

	public static DataView RtView;

	public static int i = 0;

	public static int R = 0;

	public static int X = 0;

	public static int M = 0;

	public static int MsAmcUnlockDay = 0;

	public static string SqlServer;

	public static string SqlMain;

	public static string SqlData;

	public static string SqlOdbc;

	public static string CurLc;

	public static string LinkType;

	public static string MsLcMenuOpen;

	public static string SqlId;

	public static string SqlPwd;

	public static string MsTrfrSvr;

	public static string MsTrfrSvrMast;

	public static string MsTrfrIp;

	public static string MsTrfrPwd;

	public static bool MsSoftOpen = false;

	public static bool MembReg = false;

	public static bool MsImgDataOpen = false;

	public static string CurBook;

	public static string CurBookName;

	public static string CurBookType;

	public static string CurBookItm;

	public static string CurBookVch;

	public static string CurBookMain;

	public static string CurBookSname;

	public static string CurBookInOut;

	public static bool MsCreat;

	public static bool MsSubCreat;

	public static string MsCode;

	public static string MsName;

	public static string RptName;

	public static string RptFormula;

	public static string CrConnect;

	public static string MsPrintOpt;

	public static bool MsPrintOg;

	public static bool MsPrintDup;

	public static bool MsPrintTrip;

	public static bool MsPrintStatus;

	public static string MsMobileLen;

	public static int MsWappEndDay;

	public static bool MsWappMember;

	public static int MsPrintZoom;

	public static string MsCustMail;

	public static bool MsEmailOpen;

	public static string MsHttpPath;

	public static string MsUrlPath;

	public static string MsUrlId;

	public static string MsUrlPwd;

	public static string SmsId;

	public static string SmsPwd;

	public static string SmsUser;

	public static string SmsLink;

	public static string MsWappApiKey;

	public static string MsWappApiActive;

	public static string MsWappApiMobile;

	public static string MsWappApiId;

	public static string MsSoftType;

	public static string MsMainBtn;

	public static DataTable RsClDetl;

	public static DataTable RsClIdtl;

	public static string SSWithKey;

	public static string SSRegSrNo;

	public static string SSCompSrNo1;

	public static string SSCompSrNo2;

	public static DateTime AmcEndDate;

	public static string MsSoftDemoName;

	public static string MCo_Path;

	public static string MCo_code;

	public static string MLc_code;

	public static string MCo_year;

	public static string MCo_Book;

	public static string MCo_BookType;

	public static string MCo_Type;

	public static string MCo_Name;

	public static string MLc_Name;

	public static string MCo_SName;

	public static string MsAlterYear;

	public static string NewCompCode;

	public static string NewMstCreat;

	public static string NewYearCode;

	public static DateTime MsSysDate;

	public static string MsOldMethod;

	public static bool MsLcBoxShow;

	public static string MsSlAndTagWtDiff;

	public static string MsCrmProcess;

	public static bool MsSSPwd;

	public static string MsAppSchem;

	public static string MsAppDgGold;

	public static string MsNextAi;

	public static string MCo_State;

	public static string MCo_User;

	public static string MCo_UserType;

	public static DateTime MOp_dt;

	public static DateTime MCl_dt;

	public static string MCo_OpDate;

	public static string MCo_ClDate;

	public static int MsCoTheme;

	public static string MsDmMast;

	public static string FnYear;

	public static bool RongDate;

	public static string MMask;

	public static bool HelpClose;

	public static string MsWorkType;

	public static string MsMetalType;

	public static string MsGrCode;

	public static string MsUserRightForm = "";

	public static DateTime MsLockDt;

	public static int MsTaxRof = 0;

	public static string MsRatePar;

	public static double MsAcAmtOpBal;

	public static double MsAcGoldOpBal;

	public static double MsAcSilverOpBal;

	public static double MsAcAmtClBal;

	public static double MsAcGoldClBal;

	public static double MsAcSilverClBal;

	public static bool MsHoAcCreat = false;

	public static string MsSlRowChange;

	public static string MsVbImport;

	public static bool TakeBkp;

	public static double TestWt;

	public static string MsLbrGen;

	public static bool MsDailyRateGen = false;

	public static string MsRateMastOpen;

	public static string MsFineStkType;

	public static string MsTagRpt;

	public static string MsHelpSearch;

	public static string MsWeightPort;

	public static string MsLdrSumm;

	public static string MsSlAmtType;

	public static string MsPrAmtType;

	public static string MsTradFine;

	public static int MsLbrRof;

	public static string LdrAcMastCode;

	public static string MsEstmateReset;

	public static string MsReminderOpen;

	public static int MsItmRateRof;

	public static string MsCustSms;

	public static string MsAdminSms;

	public static string MsAdminMobile;

	public static string MsPurcWithLbr;

	public static string MsGridScroll;

	public static string MsStkRptType;

	public static string MsTchAutoSave;

	public static double MsPanCardVal;

	public static double MsDhrnPrc;

	public static string MsSlNwtLock;

	public static string MsWhBillImg;

	public static string MsSlDupPrint;

	public static bool MsDupPrintStatus;

	public static string MsRptBalZoomType;

	public static bool MsOnlyOpBalnce;

	public static string MsClgValueSave;

	public static string MsBalanceSheetType;

	public static string MsTaxCode;

	public static string MsQrCodeGen;

	public static string MsOsBillSms;

	public static string MsIpWith;

	public static string MsSlBillImg;

	public static string MsOldCoCode;

	public static string MsCoStockMerge;

	public static bool MsTodayBalance;

	public static string MsTotFineStkType;

	public static string MsOpblTrfrBtn;

	public static string MsTagVchAutoSave;

	public static string MsDesignHelp;

	public static string MsSalesWithHmTax;

	public static string MsPurcWithHmTax;

	public static string MsBillImgPath;

	public static bool MsTagVchSrnoUpdate;

	public static string MsSqlDataPath = "";

	public static string MsDataLogName;

	public static string MsNextMainLogName;

	public static string MsTileMenuShow;

	public static int MsPrRateRof;

	public static string MsLenImgPath;

	public static string MsCreatName;

	public static string MsSlTdsTax;

	public static string MsPrTdsTax;

	public static string MsFineInt;

	public static string MsBillProfit;

	public static string MsOldGoldType;

	public static string MsMfgType;

	public static string MsMfgWorkType;

	public static string MsDesignMastHelp;

	public static string MsOrdImgPrint;

	public static string MsOsBillOrnaIsu;

	public static string MsMobileHelp;

	public static string MsCashPurcAc;

	public static string MsPrintFormBtn;

	public static string MsEmpCodeMendetry;

	public static string MsStockRptView;

	public static string MsLastDayLock;

	public static double MsCashLimit;

	public static double AcCash;

	public static bool MsOpenUserRequest;

	public static int MsTotAmtRof;

	public static string MsTaxWithEstmate;

	public static string MsMobileSearchNo;

	public static string MsTagRowAutoPrint;

	public static string MsDhrnWapp;

	public static string MsSchmWapp;

	public static string MsRptTotShow;

	public static string MsDefaulterAc;

	public static bool MsYearChange;

	public static string MsDefaultReminder;

	public static int MsVchDescHelpLenth;

	public static string MsOrdTagLessInStk;

	public static string MsAllBranchAcShow;

	public static string MsMrpTaxReverc;

	public static string MsEmpAsUser;

	public static string MsUserEmpCode;

	public static string MsUserEmpName;

	public static string MsWappImgGwt;

	public static double MsYearGoldSl;

	public static double MsYearSilverSl;

	public static bool F1Search;

	public static DateTime MsFDiscDt;

	public static DateTime MsTDiscDt;

	public static string MsLbrWithGht;

	public static string MsAprImgPrint;

	public static string MsOthItmWtRemove;

	public static string MsSilverWt3Digit;

	public static string MsLedrBillColShow;

	public static string MsAllRofRemove;

	public static string MsKrDesignImgPrint;

	public static string MsItmWitLotStk;

	public static string MsUserKrTouchHide;

	public static string MsMfgWithOrder;

	public static string MsMfgWithLedger;

	public static string MsCurDayPosting;

	public static string MsPostingDate;

	public static string MsOrderWithJadtar;

	public static string MsStkLimitWithDesign;

	public static string MsItmFineLock;

	public static string MsMfgWithLot;

	public static string MsMfgOneFormEntry;

	public static string MsLastYearTagSires;

	public static string MsOlocarActive;

	public static string MsOLocerKey;

	public static string MsOLocerVal;

	public static string MsItmMfg;

	public static string MsMeltingLotGenrate;

	public static string MsMasterResetAllData;

	public static double MsSlPrOzConv;

	public static double MsFxRate;

	public static string MsFxCode;

	public static double MsUpiAmt;

	public static string MsUpiVchNo;

	public static string MsUpiDbCd;

	public static string MsUpiAcCode;

	public static string MsUpiAcName;

	public static DateTime MsUpiDate;

	public static string MsUpiFormOpen;

	public static double MsUpiBillOsAmt;

	public static string MsUpiCurAcCode;

	public static string MsFontChange;

	public static string MsFontName;

	public static float MsFontSize;

	public static FontStyle MsFontStyle;

	public static int MsGridRowHeight;

	public static string MsMainFontChange;

	public static double DgvRowHight;

	public static double ScreenHight;

	public static int HaderFont;

	public static string FanMenuOpen;

	public static string MsPointCode;

	public static double MsOnePointVal;

	public static string MsPurcLot;

	public static string MsSoftNoUse;

	public static string MsUserNotShowGr;

	public static string MsReqUser;

	public static string MsReqBook;

	public static string MsReqVch;

	public static string MsReqAc;

	public static bool MsWhatTextSend;

	public static string MsWhatsAppOpen;

	public static string IdWappIdNo;

	public static string MsCustWappNo;

	public static string MsCountryId;

	public static string MsWappSlPrint;

	public static double MsWappOpAmt;

	public static double MsWappClAmt;

	public static double MsWappOpGlFine;

	public static double MsWappClGlFine;

	public static double MsWappOpSlFine;

	public static double MsWappClSlFine;

	public static string MsWappPrintType;

	public static string MsWappFree;

	public static string MsWappOrdOldItm;

	public static string MsCrystalRptType;

	public static bool MsWappSend;

	public static string MsRptTitel;

	public static string MsPrintType;

	public static string MsCrForName1;

	public static string MsCrForName2;

	public static string MsCrForName3;

	public static string MsCrForName4;

	public static string MsCrForName5;

	public static string MsCrForName6;

	public static string MsCrForName7;

	public static string MsRptTitelStr;

	public static string MaPirntCopy;

	public static string MsCrForStr1;

	public static string MsCrForStr2;

	public static string MsCrForStr3;

	public static string MsCrForStr4;

	public static string MsCrForStr5;

	public static string MsCrForStr6;

	public static string MsCrForStr7;

	public static string MsCrForVal1;

	public static string MsCrForVal2;

	public static string MsCrForVal3;

	public static string MsCrForVal4;

	public static string MsCrForVal5;

	public static string MsCrForVal6;

	public static string MsCrForVal7;

	public static string MsCardComAdj;

	public static bool MsCardSlAdj;

	public static double MsCardAdj;

	public static double MsCardAdjComm;

	public static string MsCardBank;

	public static string MsCardBankName;

	public static string MsNewTagNo;

	public static string MsAcUpdate;

	public static string MsBulProcess;

	public static string MsSoftHang;

	public static string MsOneCoOpen;

	public static string MsDhrnImgPrint;

	public static string MsCntrStk;

	public static string MsEstmateBankLock;

	public static string MsOldPurcTchGen;

	public static string MsNegativeStkSale;

	public static string MsDhrnIntType;

	public static double MsIntYearDays;

	public static string MsOpDhiran;

	public static string MsIntDayCalc;

	public static string MsDhrnCompound;

	public static string MsLoanIntType;

	public static string MsOpLoan;

	public static int TotOpenForm;

	public static double MsSlSchmAdj;

	public static bool MsSlAdj;

	public static bool MsOldPurc;

	public static bool MsOldPurcSl;

	public static double MsOldPurcAmt;

	public static double MsOldPurcWt;

	public static string MsSlBill;

	public static string MsSlBillHdNo;

	public static string MsSlAcCode;

	public static string MsSlYrCd;

	public static string MsSlDbCd;

	public static double MsSlAmt;

	public static string CustUrdName;

	public static bool MsOpenSlRtn;

	public static string BAllDataReSet;

	public static bool BDataRest;

	public static string MsCountryCode;

	public static string MsLbrType;

	public static string MsDataType;

	public static string MsImageNo;

	public static string MsImageType;

	public static string MsImagePath;

	public static string MSImageSavePath;

	public static string MSImageSavePathSmall;

	public static double MsOzGoldRate;

	public static double MsOzSilverRate;

	public static double MsOzConvVal;

	public static double MsOzSlConv;

	public static double MsOzGlConv;

	public static double MsCurrency;

	public static bool LiveRateDisplay;

	public static bool YearHelp;

	public static bool HelpLode;

	public static double[] ColWidth;

	public static string[] ColValue;

	public static short HelpSelect;

	public static string AcLcCodeLen;

	public static bool FirstImageLode;

	public static double MainImageW;

	public static double MainImageH;

	public static bool OpenMdi;

	public static string MsgTitle = "DataCareNext";

	public static void DcPwdLink()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		StreamReader streamReader = default(StreamReader);
		FileStream fileStream = default(FileStream);
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
				case 155:
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
							goto IL_0019;
						case 4:
							goto IL_0023;
						case 5:
							goto IL_0030;
						case 6:
							goto IL_003e;
						case 7:
							goto IL_004c;
						case 8:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 9:
						case 10:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0030:
					num2 = 5;
					SqlId = streamReader.ReadLine();
					goto IL_003e;
					IL_003e:
					num2 = 6;
					SqlPwd = streamReader.ReadLine();
					goto IL_004c;
					IL_0023:
					num2 = 4;
					if (streamReader == null)
					{
						goto end_IL_0001_3;
					}
					goto IL_0030;
					IL_004c:
					num2 = 7;
					streamReader.Close();
					break;
					IL_000b:
					num2 = 2;
					fileStream = File.Open("C:\\DcLink\\DcOpen.txt", FileMode.Open);
					goto IL_0019;
					IL_0019:
					num2 = 3;
					streamReader = new StreamReader(fileStream);
					goto IL_0023;
					end_IL_0001_2:
					break;
				}
				num2 = 8;
				fileStream.Close();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 155;
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

	public static void DataCon()
	{
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		DcPwdLink();
		FileStream fileStream = File.Open(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlName.txt", FileMode.Open);
		StreamReader streamReader = new StreamReader(fileStream);
		SqlServer = streamReader.ReadLine();
		SqlData = streamReader.ReadLine();
		SqlMain = streamReader.ReadLine();
		SqlOdbc = streamReader.ReadLine();
		CurLc = streamReader.ReadLine();
		LinkType = streamReader.ReadLine();
		MSImageSavePath = streamReader.ReadLine();
		MsSqlDataPath = streamReader.ReadLine();
		MsDataLogName = streamReader.ReadLine();
		MsNextMainLogName = streamReader.ReadLine();
		if (Strings.Len(SqlOdbc) > 4)
		{
			MsOneCoOpen = Strings.Mid(SqlOdbc, 6, 2);
			SqlOdbc = Strings.Mid(SqlOdbc, 1, 4);
		}
		streamReader.Close();
		fileStream.Close();
		if (Operators.CompareString(SqlServer, "188.241.187.122", false) == 0)
		{
			SqlId = "sa";
			SqlPwd = "Vsg@2718";
		}
		if (Operators.CompareString(SqlId, "", false) == 0)
		{
			SqlId = "sa";
		}
		if (Operators.CompareString(SqlPwd, "", false) == 0)
		{
			SqlPwd = "datacare@123";
		}
		try
		{
			if (Operators.CompareString(LinkType, "W", false) == 0)
			{
				Mc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + SqlMain + ";Integrated Security=True";
			}
			else
			{
				Mc.ConnectionString = ("Data Source=" + SqlServer + ";Initial Catalog=" + SqlMain + ";Persist Security Info=True;User ID=" + SqlId + ";Password=" + SqlPwd) ?? "";
			}
			if (Mc.State == ConnectionState.Open)
			{
				Mc.Close();
			}
			Mc.Open();
			Mc.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Operators.CompareString(MsSqlDataPath, "", false) != 0)
			{
				Mc.ConnectionString = ("Data Source=" + SqlServer + ";Initial Catalog=master;Persist Security Info=True;User ID=" + SqlId + ";Password=" + SqlPwd) ?? "";
				RsQry = "CREATE DATABASE [" + SqlMain + "] ON (FILENAME = N'" + MsSqlDataPath + SqlMain + ".mdf'),( FILENAME = N'" + MsSqlDataPath + MsNextMainLogName + ".ldf') FOR ATTACH";
				ExeQuteMc(RsQry);
				RsQry = "CREATE DATABASE [" + SqlData + "] ON (FILENAME = N'" + MsSqlDataPath + SqlData + ".mdf'),( FILENAME = N'" + MsSqlDataPath + MsDataLogName + ".ldf') FOR ATTACH";
				ExeQuteMc(RsQry);
				if (Mc.State == ConnectionState.Open)
				{
					Mc.Close();
				}
				Interaction.MsgBox((object)"Database Is Attach Please ReLogin Software...", (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			else
			{
				Interaction.MsgBox((object)(ex2.Message + "\r\n" + ex2.StackTrace), (MsgBoxStyle)16, (object)null);
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DataConYear()
	{
		if (Dc.State == ConnectionState.Open)
		{
			Dc.Close();
		}
		if (Operators.CompareString(LinkType, "W", false) == 0)
		{
			Dc.ConnectionString = "Data Source=" + SqlServer + ";Initial Catalog=" + SqlData + ";Integrated Security=True";
		}
		else
		{
			Dc.ConnectionString = ("Data Source=" + SqlServer + ";Initial Catalog=" + SqlData + ";Persist Security Info=True;User ID=" + SqlId + ";Password=" + SqlPwd) ?? "";
		}
		CrConnect = "DSN=" + SqlOdbc + ";UID=" + SqlId + ";PWD=" + SqlPwd + ";DSQ=" + SqlData + ";";
		if (Strings.Len(LinkType) > 1)
		{
			try
			{
				CreateOrUpdateSqlServerOdbc17UserDsn(SqlOdbc, SqlServer, SqlData, useSqlAuth: true, SqlId, SqlPwd, encrypt: true, trustServerCert: true);
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
				return;
			}
		}
		NextOdbc();
	}

	public static void NextOdbc()
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software", writable: true).OpenSubKey("WOW6432Node", writable: true);
			regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI", writable: true);
			RegistryKey registryKey2 = regKey;
			object obj = SqlOdbc ?? "";
			if (obj == null)
			{
				obj = "";
			}
			registryKey2.CreateSubKey((string)obj);
			regKey.Close();
			regKey = Registry.CurrentUser.OpenSubKey(("SOFTWARE\\ODBC\\ODBC.INI\\" + SqlOdbc) ?? "", writable: true);
			if (registryKey == null)
			{
				regKey.SetValue("Driver", "C: \\\\Windows\\\\system32\\\\sqlncli11.dll");
			}
			else if (registryKey != null)
			{
				regKey.SetValue("Driver", "C:\\\\Windows\\\\SysWOW64\\\\sqlncli11.dll");
			}
			regKey.SetValue("Description", (SqlOdbc ?? "") ?? "");
			regKey.SetValue("Server", (SqlServer ?? "") ?? "");
			regKey.SetValue("Database", (SqlData ?? "") ?? "");
			regKey.SetValue("LastUser", (SqlId ?? "") ?? "");
			regKey.Close();
			regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources", writable: true);
			regKey.SetValue((SqlOdbc ?? "") ?? "", "SQL Server Native Client 11.0");
			regKey.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void CreateOrUpdateSqlServerOdbc17UserDsn(string dsnName, string server, string database, bool useSqlAuth = false, string userId = "", string password = "", bool encrypt = true, bool trustServerCert = false)
	{
		string value = DetectOdbc17DriverPath();
		if (string.IsNullOrEmpty(value))
		{
			throw new ApplicationException("ODBC Driver 17 for SQL Server મળ\u0acdય\u0acb નથ\u0ac0. ક\u0ac3પ\u0abe કર\u0ac0ન\u0ac7 x86/x64 match કર\u0ac0ન\u0ac7 install કર\u0acb.");
		}
		try
		{
			using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\ODBC\\ODBC.INI\\" + dsnName, writable: true))
			{
				registryKey.SetValue("Driver", value, RegistryValueKind.String);
				registryKey.SetValue("Description", dsnName, RegistryValueKind.String);
				registryKey.SetValue("Server", server, RegistryValueKind.String);
				registryKey.SetValue("Database", database, RegistryValueKind.String);
				if (useSqlAuth)
				{
					registryKey.SetValue("Trusted_Connection", "No", RegistryValueKind.String);
					if (!string.IsNullOrWhiteSpace(userId))
					{
						registryKey.SetValue("UID", userId, RegistryValueKind.String);
					}
					if (!string.IsNullOrWhiteSpace(password))
					{
						registryKey.SetValue("PWD", password, RegistryValueKind.String);
					}
					registryKey.SetValue("LastUser", userId, RegistryValueKind.String);
				}
				else
				{
					registryKey.SetValue("Trusted_Connection", "Yes", RegistryValueKind.String);
					registryKey.DeleteValue("UID", throwOnMissingValue: false);
					registryKey.DeleteValue("PWD", throwOnMissingValue: false);
					registryKey.SetValue("LastUser", Environment.UserName, RegistryValueKind.String);
				}
				registryKey.SetValue("Encrypt", encrypt ? "Yes" : "No", RegistryValueKind.String);
				registryKey.SetValue("TrustServerCertificate", trustServerCert ? "Yes" : "No", RegistryValueKind.String);
				registryKey.SetValue("QuotedId", "No", RegistryValueKind.String);
				registryKey.SetValue("AnsiNPW", "Yes", RegistryValueKind.String);
			}
			using RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\ODBC\\ODBC.INI\\ODBC Data Sources", writable: true);
			registryKey2.SetValue(dsnName, "ODBC Driver 17 for SQL Server", RegistryValueKind.String);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new ApplicationException("ODBC 17 User DSN બન\u0abeવત\u0ac0 વખત\u0ac7 ભ\u0ac2લ: " + ex2.Message, ex2);
		}
	}

	private static string DetectOdbc17DriverPath()
	{
		string text = TryGetDriverPathFromView(RegistryView.Registry64);
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		text = TryGetDriverPathFromView(RegistryView.Registry32);
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
		string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		string text2 = Path.Combine(folderPath, "Microsoft ODBC Driver 17 for SQL Server", "msodbcsql17.dll");
		string text3 = Path.Combine(folderPath2, "Microsoft ODBC Driver 17 for SQL Server", "msodbcsql17.dll");
		if (File.Exists(text2))
		{
			return text2;
		}
		if (File.Exists(text3))
		{
			return text3;
		}
		return string.Empty;
	}

	private static string TryGetDriverPathFromView(RegistryView view)
	{
		try
		{
			using RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view);
			using RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\ODBC\\ODBCINST.INI\\ODBC Driver 17 for SQL Server", writable: false);
			if (registryKey2 != null)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(registryKey2.GetValue("Driver"));
				if (objectValue != null)
				{
					string text = objectValue.ToString();
					if (File.Exists(text))
					{
						return text;
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return string.Empty;
	}

	public static DataTable OpenRecordSetMc(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		NewTbl = new DataTable();
		Da = new SqlDataAdapter(sql, Mc);
		((DbDataAdapter)(object)Da).Fill(NewTbl);
		return NewTbl;
	}

	public static DataTable OpenRecordSetDc(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		NewTbl = new DataTable();
		Da = new SqlDataAdapter(sql, Dc);
		((DbDataAdapter)(object)Da).Fill(NewTbl);
		return NewTbl;
	}

	public static DataTable OpenRecordSetImg(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		NewTbl = new DataTable();
		Da = new SqlDataAdapter(sql, Img);
		((DbDataAdapter)(object)Da).Fill(NewTbl);
		return NewTbl;
	}

	public static DataTable OpenRecordSetCrm(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		NewTbl = new DataTable();
		Da = new SqlDataAdapter(sql, Crm);
		((DbDataAdapter)(object)Da).Fill(NewTbl);
		return NewTbl;
	}

	public static DataTable OpenRecordSetScm(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		NewTbl = new DataTable();
		Da = new SqlDataAdapter(sql, Scm);
		((DbDataAdapter)(object)Da).Fill(NewTbl);
		return NewTbl;
	}

	public static void ExeQuteScm(string Sql)
	{
		if (Scm.State == ConnectionState.Open)
		{
			Scm.Close();
		}
		Scm.Open();
		Cmd.Connection = Scm;
		Cmd.CommandText = Sql;
		Cmd.ExecuteNonQuery();
		Scm.Close();
	}

	public static void MsInsertData()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		SqlBldr = new SqlCommandBuilder(Da);
		Da.InsertCommand = SqlBldr.GetInsertCommand();
	}

	public static void ExeQuteRb(string Sql)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		CmdDc = new SqlCommand(Sql, Dc, MsTranDc);
	}

	public static void ExeQuteMc(string Sql)
	{
		if (Mc.State == ConnectionState.Open)
		{
			Mc.Close();
		}
		Mc.Open();
		Cmd.Connection = Mc;
		Cmd.CommandText = Sql;
		Cmd.ExecuteNonQuery();
		Mc.Close();
	}

	public static void ExeQuteDc(string Sql)
	{
		if (MsSoftOpen)
		{
			if (Dc.State == ConnectionState.Open)
			{
				Dc.Close();
			}
			Dc.Open();
			Cmd.Connection = Dc;
			Cmd.CommandText = Sql;
			Cmd.ExecuteNonQuery();
			Dc.Close();
		}
		else
		{
			if (Dc.State == ConnectionState.Open)
			{
				Dc.Close();
			}
			Dc.Open();
			Cmd.Connection = Dc;
			Cmd.CommandText = Sql;
			Cmd.ExecuteNonQuery();
			Dc.Close();
		}
	}

	public static void ExeQuteImg(string Sql)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					switch (try0001_dispatch)
					{
					default:
					{
						if (MsImgDataOpen)
						{
							if (Img.State == ConnectionState.Open)
							{
								Img.Close();
							}
							Img.Open();
							Cmd.Connection = Img;
							Cmd.CommandText = Sql;
							Cmd.ExecuteNonQuery();
							Img.Close();
							break;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						RsQry = "SELECT name, state_desc from sys.databases GO";
						Tbl = OpenRecordSetDc(RsQry);
						bool flag = false;
						int num3 = Tbl.Rows.Count - 1;
						for (int i = 0; i <= num3; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(Tbl.Rows[i]["name"], (object)"NextImage", false))
							{
								flag = true;
							}
						}
						if (!flag)
						{
							Interaction.MsgBox((object)"Please Create Next Image Data In Database...", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if (Img.State == ConnectionState.Open)
						{
							Img.Close();
						}
						Img.Open();
						Cmd.Connection = Img;
						Cmd.CommandText = Sql;
						Cmd.ExecuteNonQuery();
						Img.Close();
						goto end_IL_0001;
					}
					case 680:
						num = -1;
						switch (num2)
						{
						case 2:
							break;
						default:
							goto end_IL_0001_2;
						}
						break;
					}
					if (!MsImgDataOpen)
					{
						string text = "NextImage";
						if (Img.State == ConnectionState.Open)
						{
							Img.Close();
						}
						Img.ConnectionString = ("Data Source=" + SqlServer + ";Initial Catalog=master;Persist Security Info=True;User ID=" + SqlId + ";Password=" + SqlPwd) ?? "";
						RsQry = "USE [master]   ALTER DATABASE [" + text + "] SET  OFFLINE";
						ExeQuteImg(RsQry);
						RsQry = "USE [master]   ALTER DATABASE [" + text + "] SET  ONLINE";
						ExeQuteImg(RsQry);
						if (Img.State == ConnectionState.Open)
						{
							Img.Close();
						}
						Img.ConnectionString = ("Data Source=" + SqlServer + ";Initial Catalog=" + text + ";Persist Security Info=True;User ID=" + SqlId + ";Password=" + SqlPwd) ?? "";
					}
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 680;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	public static void ExeQuteCrm(string Sql)
	{
		if (Crm.State == ConnectionState.Open)
		{
			Crm.Close();
		}
		Crm.Open();
		Cmd.Connection = Crm;
		Cmd.CommandText = Sql;
		Cmd.ExecuteNonQuery();
		Crm.Close();
	}

	public static void MsAcBal(string AcCode, DateTime TranTime)
	{
		MsAcAmtOpBal = 0.0;
		MsAcAmtClBal = 0.0;
		MsAcGoldOpBal = 0.0;
		MsAcGoldClBal = 0.0;
		MsAcSilverOpBal = 0.0;
		MsAcSilverClBal = 0.0;
		RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_CODE,Sum(CR_AMT-DR_AMT) as Amount,SUM(CASE WHEN IT_TYPE = 'G' THEN(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN IT_TYPE = 'S' THEN (CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA  WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CO_YEAR = '" + MCo_year + "' AND AC_CODE = '" + AcCode + "' and ENTRY_TIME < '" + Strings.Format((object)TranTime, "MM/dd/yyyy HH:mm:ss") + "' "), Interaction.IIf(Operators.CompareString(MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + MsDataType + "'"))), (object)"   GROUP BY AC_CODE"));
		DataTable dataTable = OpenRecordSetDc(RsQry);
		if (dataTable.Rows.Count > 0)
		{
			MsAcAmtOpBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]), "0.00"));
			MsAcGoldOpBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GoldWt"]), "0.000"));
			MsAcSilverOpBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"]), "0.000"));
		}
		RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_CODE,Sum(CR_AMT-DR_AMT) as Amount,SUM(CASE WHEN IT_TYPE = 'G' THEN(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN IT_TYPE = 'S' THEN (CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA  WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CO_YEAR = '" + MCo_year + "' AND AC_CODE = '" + AcCode + "' and ENTRY_TIME <= '" + Strings.Format((object)TranTime, "MM/dd/yyyy HH:mm:ss") + "' "), Interaction.IIf(Operators.CompareString(MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + MsDataType + "'"))), (object)"   GROUP BY AC_CODE"));
		dataTable = OpenRecordSetDc(RsQry);
		if (dataTable.Rows.Count > 0)
		{
			MsAcAmtClBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Amount"]), "0.00"));
			MsAcGoldClBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GoldWt"]), "0.000"));
			MsAcSilverClBal = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SilverWt"]), "0.000"));
		}
	}

	public static void CurBookHelp(string CurMainBook)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(MsDataType, "A", false) == 0)
		{
			RsQry = "SELECT BOOK_NAME as BookNameT,CO_BOOK As BookCodeT,BOOK_TYPE AS TypeL,ITM_TYPE AS ItemL,MAIN_BOOK As MainBookL,BOOK_SNAME As BookSNameL,BOOK_INOUT As BookInOutL,USER_EMP_CODE FROM BOOK_DATA WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CUR_USE = 'Y' AND DATA_TYPE = 'A' AND MAIN_BOOK = '" + CurMainBook + "' ORDER BY BOOK_NAME";
		}
		else if (Operators.CompareString(MsDataType, "B", false) == 0)
		{
			RsQry = "SELECT BOOK_NAME as BookNameT,CO_BOOK As BookCodeT,BOOK_TYPE AS TypeL,ITM_TYPE AS ItemL,MAIN_BOOK As MainBookL,BOOK_SNAME As BookSNameL,BOOK_INOUT As BookInOutL,USER_EMP_CODE FROM BOOK_DATA WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CUR_USE = 'Y' AND DATA_TYPE = 'B' AND MAIN_BOOK = '" + CurMainBook + "' ORDER BY BOOK_NAME";
		}
		else
		{
			RsQry = "SELECT BOOK_NAME as BookNameT,CO_BOOK As BookCodeT,BOOK_TYPE AS TypeL,ITM_TYPE AS ItemL,MAIN_BOOK As MainBookL,BOOK_SNAME As BookSNameL,BOOK_INOUT As BookInOutL,USER_EMP_CODE FROM BOOK_DATA WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND CUR_USE = 'Y' AND MAIN_BOOK = '" + CurMainBook + "' ORDER BY BOOK_NAME";
		}
		RsDg = OpenRecordSetDc(RsQry);
		if (RsDg.Rows.Count == 0)
		{
			Interaction.MsgBox((object)("Please Creat Book From " + CurMainBook + "...."), (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(MsUserEmpCode, "", false) != 0)
		{
			DataView dataView = new DataView(RsDg);
			dataView.RowFilter = "USER_EMP_CODE =  '" + MsUserEmpCode + "'";
			if (dataView.Count > 0)
			{
				CurBook = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["BookCodeT"], (object)""));
				CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["BookNameT"], (object)""));
				CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["TypeL"], (object)""));
				CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["ItemL"], (object)""));
				CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["MainBookL"], (object)""));
				CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["BookSNameL"], (object)""));
				CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataView[0]["BookInOutL"], (object)""));
				return;
			}
		}
		if (RsDg.Rows.Count == 1)
		{
			DataTable rsDg = RsDg;
			CurBook = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["BookCodeT"], (object)""));
			CurBookName = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["BookNameT"], (object)""));
			CurBookType = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["TypeL"], (object)""));
			CurBookItm = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["ItemL"], (object)""));
			CurBookMain = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["MainBookL"], (object)""));
			CurBookSname = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["BookSNameL"], (object)""));
			CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(RsDg.Rows[0]["BookInOutL"], (object)""));
			return;
		}
		ColWidth = new double[8];
		ColWidth[0] = 300.0;
		ColWidth[1] = 0.0;
		ColWidth[2] = 0.0;
		ColWidth[3] = 0.0;
		ColWidth[4] = 0.0;
		ColWidth[5] = 0.0;
		ColWidth[6] = 0.0;
		HelpSelect = 1;
		((Form)MyProject.Forms.MS_BOOKLIST).ShowDialog();
		if (!HelpClose && Operators.CompareString(ColValue[1], "", false) != 0)
		{
			CurBook = ColValue[1];
			CurBookName = ColValue[0];
			CurBookType = ColValue[2];
			CurBookItm = ColValue[3];
			CurBookMain = ColValue[4];
			CurBookSname = ColValue[5];
			CurBookInOut = ColValue[6];
		}
	}

	public static void SetDate(ref MaskedTextBox MsDate)
	{
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		RongDate = false;
		string text = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
		checked
		{
			int num = Strings.Len(MsDate.Text) - 1;
			int i;
			for (i = 1; i <= num && !((Operators.CompareString(Strings.Mid(MsDate.Text, i, 1), "_", false) == 0) | (Operators.CompareString(Strings.Mid(MsDate.Text, i, 1), " ", false) == 0)); i++)
			{
			}
			if (Operators.CompareString(MsAlterYear, "Y", false) == 0)
			{
				if (i > 5)
				{
					FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)(Conversions.ToDouble(Strings.Left(MCo_year, 4)) + 1.0), (object)Strings.Left(MCo_year, 4)));
				}
				else
				{
					FnYear = Conversions.ToString(Interaction.IIf((Conversion.Val(Strings.Mid(text, 4, 2)) < 4.0) | (Operators.CompareString(Strings.Mid(text, 4, 2), "", false) == 0), (object)(Conversions.ToDouble(Strings.Left(MCo_year, 4)) + 1.0), (object)Strings.Left(MCo_year, 4)));
				}
			}
			else if (Operators.CompareString(MCo_SName, "UAE", false) == 0)
			{
				FnYear = Strings.Left(MCo_year, 4);
			}
			else if (i > 5)
			{
				FnYear = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(MsDate.Text, 4, 2)) < 4.0, (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));
			}
			else
			{
				FnYear = Conversions.ToString(Interaction.IIf((Conversion.Val(Strings.Mid(text, 4, 2)) < 4.0) | (Operators.CompareString(Strings.Mid(text, 4, 2), "", false) == 0), (object)Strings.Right(MCo_year, 4), (object)Strings.Left(MCo_year, 4)));
			}
			if (i == 2)
			{
				RongDate = true;
				return;
			}
			switch (i)
			{
			case 1:
				MsDate.Text = DateAndTime.Today.Day.ToString("00") + "/" + DateAndTime.Today.Month.ToString("00") + "/" + FnYear;
				break;
			case 2:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 1) + "/" + Strings.Mid(text, 2, 5) + "/" + FnYear;
				break;
			case 3:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;
				break;
			case 4:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;
				break;
			case 5:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(text, 4, 2) + "/" + FnYear;
				break;
			case 6:
				MsDate.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Strings.Mid(MsDate.Text, 1, 2) + "/"), Interaction.IIf((Operators.CompareString(Strings.Mid(MsDate.Text, 4, 2), "  ", false) == 0) | (Operators.CompareString(Strings.Mid(MsDate.Text, 5, 1), " ", false) == 0), (object)Strings.Mid(text, 4, 2), (object)Strings.Mid(MsDate.Text, 4, 2))), (object)"/"), (object)FnYear));
				break;
			case 7:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;
				break;
			case 8:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;
				break;
			case 9:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + FnYear;
				break;
			case 10:
				MsDate.Text = Strings.Mid(MsDate.Text, 1, 2) + "/" + Strings.Mid(MsDate.Text, 4, 2) + "/" + Strings.Mid(MsDate.Text, 7, 10);
				break;
			}
			double num2 = Conversion.Val(Strings.Mid(MsDate.Text, 4, 2));
			if (num2 == 2.0)
			{
				if (Operators.CompareString(Strings.Mid(MsDate.Text, 1, 1), "29", false) > 0)
				{
					RongDate = true;
					Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);
					MsDate.Text = "__/__/____";
					((TextBoxBase)MsDate).SelectAll();
					return;
				}
			}
			else if (num2 == 4.0 || num2 == 6.0 || num2 == 9.0 || num2 == 11.0)
			{
				if (Operators.CompareString(Strings.Mid(MsDate.Text, 1, 1), "30", false) > 0)
				{
					RongDate = true;
					Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);
					MsDate.Text = "__/__/____";
					((TextBoxBase)MsDate).SelectAll();
					return;
				}
			}
			else if (num2 > 12.0)
			{
				RongDate = true;
				Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);
				MsDate.Text = "__/__/____";
				((TextBoxBase)MsDate).SelectAll();
				return;
			}
			if (Conversion.Val(Strings.Mid(MsDate.Text, 1, 2)) > 31.0)
			{
				RongDate = true;
				Interaction.MsgBox((object)"Date Not Valid...", (MsgBoxStyle)0, (object)null);
				MsDate.Text = "__/__/____";
				((TextBoxBase)MsDate).SelectAll();
			}
			else if (Conversion.Val(Strings.Mid(MsDate.Text, 3, 2)) > 12.0)
			{
				RongDate = true;
				Interaction.MsgBox((object)"Month Not Valid...", (MsgBoxStyle)0, (object)null);
				MsDate.Text = "__/__/____";
				((TextBoxBase)MsDate).SelectAll();
			}
		}
	}

	public static void OpenTable_ColMast()
	{
		RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + MCo_code + "' AND BOOK_NAME NOT IN ('TAG_IDTL')";
		RsClDetl = OpenRecordSetDc(RsQry);
		RsQry = "SELECT * FROM COL_MAST WHERE CO_CODE = '" + MCo_code + "' AND BOOK_NAME IN ('TAG_IDTL')";
		RsClIdtl = OpenRecordSetDc(RsQry);
	}

	public static void AvgTouch(DateTime TranDate, string CurLoct)
	{
		DataTable dataTable = new DataTable();
		DataTable dataTable2 = new DataTable();
		ExeQuteDc("UPDATE ITEM_MAST SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0,AVG_RATE = 0 WHERE  CO_CODE = '" + MCo_code + "'");
		ExeQuteDc("UPDATE GROUP_MAST SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0 WHERE  CO_CODE = '" + MCo_code + "'");
		ExeQuteDc("UPDATE BAL_GR SET AVG_TOUCH = 0,AVG_FINE = 0,AVG_NWT = 0,AVG_AMT = 0 WHERE  CO_CODE = '" + MCo_code + "'");
		checked
		{
			if (Operators.CompareString(MsBalanceSheetType, "A", false) == 0)
			{
				RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN A.ITM_AMT+A.KR_OTH_AMT+A.KR_LBR_AMT ELSE 0 END) AS TotAmt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" And A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.RATE_TYPE <> 'P' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.TR_TYPE IN ('P','I') GROUP BY A.IT_CODE "));
				Tbl = OpenRecordSetDc(RsQry);
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					double num = 0.0;
					double num2 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
						RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND A.IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"' AND B.RATE_TYPE <> 'P' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE "));
						dataTable2 = OpenRecordSetDc(RsQry);
						if (dataTable2.Rows.Count > 0)
						{
							num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"]));
						}
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_RATE = " + Strings.Format((object)num, "0.00") + ",AVG_NWT = " + Strings.Format((object)num2, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
					}
					else
					{
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_RATE = 0,AVG_NWT = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])), "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE 0 END) AS TotPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN CASE WHEN KR_COST <> 0 THEN A.KR_COST ELSE A.ITM_AMT+A.KR_OTH_AMT+A.KR_LBR_AMT END ELSE 0 END) AS TotAmt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.RATE_TYPE = 'P' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.TR_TYPE IN ('P','I')  GROUP BY A.IT_CODE "));
				Tbl = OpenRecordSetDc(RsQry);
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					double num = 0.0;
					double num2 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"]));
						RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS TotPcs FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND A.IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"' AND B.RATE_TYPE = 'P' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE "));
						dataTable2 = OpenRecordSetDc(RsQry);
						if (dataTable2.Rows.Count > 0)
						{
							num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotPcs"]));
						}
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET PCS_RATE = " + Strings.Format((object)num, "0.00") + ",TOT_PCS = " + Strings.Format((object)num2, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
					}
					else
					{
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET PCS_RATE = 0,TOT_PCS = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])), "0") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				RsQry = "Select GR_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' GROUP BY GR_CODE ORDER BY GR_CODE ";
				dataTable = OpenRecordSetDc(RsQry);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.IT_CODE,B.AVG_NWT,B.AVG_RATE,PCS_RATE,TOT_PCS FROM  ITEM_MAST AS B WHERE B.CO_CODE = '" + MCo_code + "' AND B.GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"' GROUP BY B.IT_CODE,B.AVG_NWT, B.AVG_RATE,PCS_RATE,TOT_PCS "));
					Tbl = OpenRecordSetDc(RsQry);
					M = 0;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					while (M < Tbl.Rows.Count)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_NWT"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"])) != 0.0))
						{
							num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_NWT"]));
							num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_NWT"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"]));
						}
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TOT_PCS"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["PCS_RATE"])) != 0.0))
						{
							num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TOT_PCS"]));
							num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TOT_PCS"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["PCS_RATE"]));
						}
						M++;
					}
					double num = 0.0;
					unchecked
					{
						if (num4 != 0.0 && num3 != 0.0)
						{
							num = num3 / num4;
						}
						double num7 = 0.0;
						if (num5 != 0.0 && num6 != 0.0)
						{
							num7 = num6 / num5;
						}
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET AVG_RATE = " + Strings.Format((object)num, "0.00") + ",AVG_NWT = " + Strings.Format((object)num4, "0.000") + ",TOT_PCS = " + Strings.Format((object)num5, "0") + ",PCS_RATE = " + Strings.Format((object)num7, "0.00") + " WHERE CO_CODE = '" + MCo_code + "' AND GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				dataTable.Rows.Clear();
				dataTable.Columns.Clear();
				RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
				dataTable = OpenRecordSetDc(RsQry);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.IT_CODE,B.AVG_NWT,B.AVG_RATE,PCS_RATE,TOT_PCS FROM  ITEM_MAST AS B WHERE B.CO_CODE = '" + MCo_code + "' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' GROUP BY B.IT_CODE,B.AVG_NWT, B.AVG_RATE,PCS_RATE,TOT_PCS "));
					Tbl = OpenRecordSetDc(RsQry);
					M = 0;
					double num3 = 0.0;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					while (M < Tbl.Rows.Count)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_NWT"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"])) != 0.0))
						{
							num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_NWT"]));
							num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_NWT"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"]));
						}
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TOT_PCS"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["PCS_RATE"])) != 0.0))
						{
							num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TOT_PCS"]));
							num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TOT_PCS"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["PCS_RATE"]));
						}
						M++;
					}
					double num = 0.0;
					unchecked
					{
						if (num4 != 0.0 && num3 != 0.0)
						{
							num = num3 / num4;
						}
						double num7 = 0.0;
						if (num5 != 0.0 && num6 != 0.0)
						{
							num7 = num6 / num5;
						}
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_RATE = " + Strings.Format((object)num, "0.00") + ",AVG_NWT = " + Strings.Format((object)num4, "0.000") + ",TOT_PCS = " + Strings.Format((object)num5, "0") + ",PCS_RATE = " + Strings.Format((object)num7, "0.00") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				dataTable.Rows.Clear();
				dataTable.Columns.Clear();
				return;
			}
			if (Operators.CompareString(MsFineStkType, "G", false) == 0)
			{
				GroupStockTouch(TranDate);
			}
			else
			{
				if (Operators.CompareString(MsFineStkType, "N", false) == 0)
				{
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code ,B.IT_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_FINE ELSE -A.ITM_FINE END) ELSE 0 END) AS ClFine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.LC_CODE = '"), (object)MLc_code), (object)"' AND A.CO_YEAR = '"), (object)MCo_year), (object)"' "), Interaction.IIf(Operators.CompareString(MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + MsDataType + "'"))), (object)" AND B.RATE_TYPE <> 'P'"));
					RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE ORDER BY B.IT_NAME";
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						double num8 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClNwt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClFine"])) != 0.0))
						{
							num8 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClFine"])) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClNwt"]));
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = " + Strings.Format((object)num8, "0.00") + ",AVG_FINE = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClFine"])), "0.000") + ",AVG_NWT = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClNwt"])), "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["Code"]), (object)"'")));
						}
						else
						{
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = 100,AVG_FINE = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClFine"])), "0.000") + ",AVG_NWT = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["ClNwt"])), "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["Code"]), (object)"'")));
						}
					}
					Tbl.Rows.Clear();
					Tbl.Columns.Clear();
				}
				else
				{
					if (Operators.CompareString(SSRegSrNo, "DD033NSDD", false) == 0)
					{
						RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0 AND A.ITM_MRP = 0 AND A.TAG_NO <> 'N' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.TR_TYPE IN ('P','I') GROUP BY A.IT_CODE "));
					}
					else
					{
						RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0 AND A.ITM_MRP = 0  and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.TR_TYPE IN ('P','I') GROUP BY A.IT_CODE "));
					}
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						double num8 = 0.0;
						double num9 = 0.0;
						double num2 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotFine"])) != 0.0))
						{
							num8 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotFine"])) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
							RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND A.IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'  and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE "));
							dataTable2 = OpenRecordSetDc(RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"]));
								num9 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"])) * num8 / 100.0;
							}
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = " + Strings.Format((object)num8, "0.00") + ",AVG_FINE = " + Strings.Format((object)num9, "0.000") + ",AVG_NWT = " + Strings.Format((object)num2, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
						}
						else
						{
							ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = 100,AVG_FINE = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])), "0.000") + ",AVG_NWT = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])), "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
						}
					}
					Tbl.Rows.Clear();
					Tbl.Columns.Clear();
				}
				RsQry = "Select GR_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY GR_CODE ORDER BY GR_CODE ";
				dataTable = OpenRecordSetDc(RsQry);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num4 = 0.0;
					double num10 = 0.0;
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.ITM_MRP = 0 GROUP BY A.IT_CODE,B.AVG_TOUCH "));
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						double num8 = 0.0;
						double num9 = 0.0;
						double num2 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"])) != 0.0))
						{
							num8 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"]));
							num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
							num9 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num8 / 100.0;
							num4 += num2;
							num10 += num9;
						}
					}
					if (unchecked(num4 != 0.0 && num10 != 0.0))
					{
						double num8 = Conversion.Val((object)(num10 * 100.0 / num4));
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET AVG_TOUCH = " + Strings.Format((object)num8, "0.000") + ",AVG_FINE = " + Strings.Format((object)num10, "0.000") + ",AVG_NWT = " + Strings.Format((object)num4, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				dataTable.Rows.Clear();
				dataTable.Columns.Clear();
				dataTable2.Rows.Clear();
				dataTable2.Columns.Clear();
				RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
				dataTable = OpenRecordSetDc(RsQry);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double num4 = 0.0;
					double num10 = 0.0;
					RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.ITM_MRP = 0 GROUP BY A.IT_CODE,B.AVG_TOUCH "));
					Tbl = OpenRecordSetDc(RsQry);
					for (M = 0; M < Tbl.Rows.Count; M++)
					{
						double num8 = 0.0;
						double num9 = 0.0;
						double num2 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"])) != 0.0))
						{
							num8 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"]));
							num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
							num9 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num8 / 100.0;
							num4 += num2;
							num10 += num9;
						}
					}
					if (num4 + num10 != 0.0)
					{
						double num8 = num10 * 100.0 / num4;
						ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_TOUCH = " + Strings.Format((object)num8, "0.000") + ",AVG_FINE = " + Strings.Format((object)num10, "0.000") + ",AVG_NWT = " + Strings.Format((object)num4, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
					}
				}
				Tbl.Rows.Clear();
				Tbl.Columns.Clear();
				dataTable.Rows.Clear();
				dataTable.Columns.Clear();
				dataTable2.Rows.Clear();
				dataTable2.Columns.Clear();
			}
			RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE 0 END) AS TotPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_COST ELSE 0 END) AS TotAmt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND (B.RATE_TYPE = 'P' OR A.ITM_MRP <> 0) AND A.KR_COST <> 0  and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' AND A.TR_TYPE IN ('P','I') GROUP BY A.IT_CODE "));
			Tbl = OpenRecordSetDc(RsQry);
			for (M = 0; M < Tbl.Rows.Count; M++)
			{
				double num = 0.0;
				if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) != 0.0))
				{
					num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotAmt"])) / Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"]));
					ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_RATE = " + Strings.Format((object)num, "0.00") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
				}
			}
			Tbl.Rows.Clear();
			Tbl.Columns.Clear();
			RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "'  GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
			dataTable = OpenRecordSetDc(RsQry);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				double num = 0.0;
				RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_RATE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS TotPcs FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' "), Interaction.IIf(Operators.CompareString(CurLoct, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + CurLoct + "'"))), (object)" AND A.CO_YEAR = '"), (object)MCo_year), (object)"' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' AND (B.RATE_TYPE = 'P' OR A.ITM_MRP <> 0) AND A.ITM_PCS <> 0  and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_RATE "));
				Tbl = OpenRecordSetDc(RsQry);
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"])) != 0.0))
					{
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotPcs"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_RATE"]));
					}
				}
				ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_AMT = " + Strings.Format((object)num, "0.00") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
			}
			Tbl.Rows.Clear();
			Tbl.Columns.Clear();
			dataTable.Rows.Clear();
			dataTable.Columns.Clear();
		}
	}

	public static void GroupStockTouch(DateTime TranDate)
	{
		DataTable dataTable = new DataTable();
		DataTable dataTable2 = new DataTable();
		RsQry = "Select A.IT_CODE,C.MELTING_PRC,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM (MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.RATE_TYPE <> 'P' AND B.IT_TYPE IN ('G','S')  and VCH_DATE <= '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' GROUP BY A.IT_CODE,C.MELTING_PRC ";
		Tbl = OpenRecordSetDc(RsQry);
		checked
		{
			for (M = 0; M < Tbl.Rows.Count; M++)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"])) != 0.0))
				{
					num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"]));
					num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
					num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
					ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET AVG_TOUCH = " + Strings.Format((object)num, "0.00") + ",AVG_FINE = " + Strings.Format((object)num2, "0.000") + ",AVG_NWT = " + Strings.Format((object)num3, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND IT_CODE = '"), Tbl.Rows[M]["IT_CODE"]), (object)"'")));
				}
			}
			Tbl.Rows.Clear();
			Tbl.Columns.Clear();
			RsQry = "Select B.GR_CODE,C.MELTING_PRC,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM (MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.IT_TYPE IN ('G','S')  and VCH_DATE <= '" + Strings.Format((object)TranDate, "MM/dd/yyyy") + "' GROUP BY B.GR_CODE,C.MELTING_PRC ";
			Tbl = OpenRecordSetDc(RsQry);
			for (M = 0; M < Tbl.Rows.Count; M++)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"])) != 0.0))
				{
					num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["MELTING_PRC"]));
					num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
					num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
					ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET AVG_TOUCH = " + Strings.Format((object)num, "0.00") + ",AVG_FINE = " + Strings.Format((object)num2, "0.000") + ",AVG_NWT = " + Strings.Format((object)num3, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND GR_CODE = '"), Tbl.Rows[M]["GR_CODE"]), (object)"'")));
				}
			}
			Tbl.Rows.Clear();
			Tbl.Columns.Clear();
			RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
			dataTable = OpenRecordSetDc(RsQry);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				double num4 = 0.0;
				double num5 = 0.0;
				RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + MCo_code + "' AND A.CO_YEAR = '" + MCo_year + "' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)TranDate, "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_TOUCH "));
				Tbl = OpenRecordSetDc(RsQry);
				for (M = 0; M < Tbl.Rows.Count; M++)
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["AVG_TOUCH"]));
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"]));
						num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(Tbl.Rows[M]["TotNetWt"])) * num / 100.0;
						num4 += num3;
						num5 += num2;
					}
				}
				if (num4 + num5 != 0.0)
				{
					double num = num5 * 100.0 / num4;
					ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET AVG_TOUCH = " + Strings.Format((object)num, "0.000") + ",AVG_FINE = " + Strings.Format((object)num5, "0.000") + ",AVG_NWT = " + Strings.Format((object)num4, "0.000") + " WHERE CO_CODE = '" + MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
				}
			}
			Tbl.Rows.Clear();
			Tbl.Columns.Clear();
			dataTable.Rows.Clear();
			dataTable.Columns.Clear();
			dataTable2.Rows.Clear();
			dataTable2.Columns.Clear();
		}
	}

	public static double Fnv(ref object Value)
	{
		if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)))
		{
			return 0.0;
		}
		if (Value == null)
		{
			return 0.0;
		}
		if (Operators.CompareString(Value.ToString(), "", false) == 0)
		{
			return 0.0;
		}
		return Conversion.Val(Value.ToString());
	}

	public static void DcDateFormat()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\International", writable: true);
		if (Operators.CompareString(Convert.ToString(registryKey).Trim(), string.Empty, false) == 0)
		{
			Interaction.MsgBox((object)"Blank", (MsgBoxStyle)0, (object)null);
			return;
		}
		registryKey.SetValue("sShortDate", "dd/MM/yyyy");
		registryKey.SetValue("sLongDate", "dddd,d MMMM yyyy");
	}

	public static void NewYearTagGen(string tPrCode, string tItType)
	{
		if (Operators.CompareString(MsVbImport, "Y", false) != 0)
		{
			return;
		}
		RsQry = "SELECT TAG_NO FROM BAR_DETL WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND TAG_TYPE = '" + tItType + "' AND  PR_CODE = '" + tPrCode + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND TAG_TYPE = '" + tItType + "' AND  PR_CODE = '" + tPrCode + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
		DataTable dataTable = OpenRecordSetDc(RsQry);
		X = 0;
		double num = 1.0;
		checked
		{
			for (MsNewTagNo = ""; X < dataTable.Rows.Count; X++)
			{
				if (Conversion.Val(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[X]["TAG_NO"], (object)"")), 4, 4)) != num)
				{
					MsNewTagNo = tPrCode + tItType + Strings.Format((object)num, "0000");
					break;
				}
				num += 1.0;
			}
			MsNewTagNo = tPrCode + tItType + Strings.Format((object)num, "0000");
		}
	}

	public static void TableCol()
	{
		RsQry = "SELECT * FROM USER_MAST ";
		RsTblCol = OpenRecordSetDc(RsQry);
	}

	public static void LedrCash(string AcCode, string AcCurBook, string AcCurVch)
	{
		AcCash = 0.0;
		RsQry = "SELECT SUM(CR_AMT) As CashAmt  FROM AC_DATA WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND AC_CODE = '" + AcCode + "' AND LD_CODE = '00001' HAVING SUM(CR_AMT) > 0 ";
		DataTable dataTable = OpenRecordSetDc(RsQry);
		if (dataTable.Rows.Count > 0)
		{
			AcCash = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CashAmt"]));
		}
		RsQry = "SELECT SUM(CR_AMT) As CashAmt  FROM AC_DATA WHERE CO_CODE = '" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND AC_CODE = '" + AcCode + "' AND LD_CODE = '00001' AND CO_BOOK = '" + AcCurBook + "' AND VCH_NO = '" + AcCurVch + "' HAVING SUM(CR_AMT) > 0 ";
		dataTable = OpenRecordSetDc(RsQry);
		if (dataTable.Rows.Count > 0)
		{
			AcCash -= Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CashAmt"]));
		}
	}

	public static void SoftLoad()
	{
		checked
		{
			int num = (int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, MOp_dt, MsSysDate, (FirstDayOfWeek)1, (FirstWeekOfYear)1));
			if (Conversion.Val(Strings.Mid(Conversions.ToString(MsSysDate), 4, 2)) >= 8.0)
			{
				num -= 120;
				if (num > 100)
				{
					Thread.Sleep(num * 45);
				}
				else if (num > 90)
				{
					Thread.Sleep(num * 40);
				}
				else if (num > 70)
				{
					Thread.Sleep(num * 36);
				}
				else if (num > 55)
				{
					Thread.Sleep(num * 33);
				}
				else if (num > 40)
				{
					Thread.Sleep(num * 30);
				}
				else if (num > 30)
				{
					Thread.Sleep(num * 25);
				}
				else if (num > 20)
				{
					Thread.Sleep(num * 20);
				}
				else if (num > 15)
				{
					Thread.Sleep(num * 15);
				}
				else if (num > 10)
				{
					Thread.Sleep(num * 10);
				}
				else if (num > 5)
				{
					Thread.Sleep(num * 5);
				}
			}
			else if (num > 100)
			{
				Thread.Sleep(num * 45);
			}
			else if (num > 90)
			{
				Thread.Sleep(num * 40);
			}
			else if (num > 70)
			{
				Thread.Sleep(num * 36);
			}
			else if (num > 55)
			{
				Thread.Sleep(num * 33);
			}
			else if (num > 40)
			{
				Thread.Sleep(num * 30);
			}
			else if (num > 30)
			{
				Thread.Sleep(num * 25);
			}
			else if (num > 20)
			{
				Thread.Sleep(num * 20);
			}
			else if (num > 15)
			{
				Thread.Sleep(num * 15);
			}
			else if (num > 10)
			{
				Thread.Sleep(num * 10);
			}
			else if (num > 5)
			{
				Thread.Sleep(num * 5);
			}
		}
	}

	public static void DefaulterAc(string CurAcCode)
	{
		RsQry = "SELECT DEFAULTER_AC FROM AC_MAST WHERE CO_CODE ='" + MCo_code + "' AND LC_CODE = '" + MLc_code + "' AND AC_CODE = '" + CurAcCode + "'";
		DataTable dataTable = OpenRecordSetDc(RsQry);
		if (dataTable.Rows.Count > 0)
		{
			MsDefaulterAc = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DEFAULTER_AC"], (object)""));
		}
		else
		{
			MsDefaulterAc = "N";
		}
	}

	public static byte[] CompressImage(string inputPath, int quality)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		Bitmap val = new Bitmap(inputPath);
		ImageCodecInfo val2 = ImageCodecInfo.GetImageEncoders().First([SpecialName] (ImageCodecInfo c) => c.FormatID == ImageFormat.Jpeg.Guid);
		EncoderParameters val3 = new EncoderParameters(1);
		val3.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);
		using MemoryStream memoryStream = new MemoryStream();
		((Image)val).Save((Stream)memoryStream, val2, val3);
		return memoryStream.ToArray();
	}

	public static Image LoadImageWithoutLock(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		byte[] array = new byte[checked((int)(fileStream.Length - 1) + 1)];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		MemoryStream memoryStream = new MemoryStream(array);
		return Image.FromStream((Stream)memoryStream);
	}
}
