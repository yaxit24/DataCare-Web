using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_SALE : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private Label _lblBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mVchDate")]
	private MaskedTextBox _mVchDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchNo")]
	private TextBox _tVchNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_IDTL")]
	private AxMSFlexGrid _MSG_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_IDTL")]
	private TextBox _TEXT_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnFirst")]
	private SimpleButton _BtnFirst;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLast")]
	private SimpleButton _BtnLast;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItDesc")]
	private TextBox _tItDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_OLD")]
	private AxMSFlexGrid _MSG_OLD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_OLD")]
	private TextBox _TEXT_OLD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillNo")]
	private TextBox _tBillNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCity")]
	private TextBox _tCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdd3")]
	private TextBox _tAdd3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdd2")]
	private TextBox _tAdd2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdd1")]
	private TextBox _tAdd1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_ORD")]
	private AxMSFlexGrid _MSG_ORD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ORD")]
	private TextBox _TEXT_ORD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIsuNo")]
	private SimpleButton _btnIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDays")]
	private TextBox _nCrDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPanNo")]
	private TextBox _tPanNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSet")]
	private SimpleButton _btnTagSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tNewPrint")]
	private TextBox _tNewPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblTrfrOpen")]
	private Label _lblTrfrOpen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTrfr")]
	private SimpleButton _btnTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrNo")]
	private TextBox _tTrfrNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUpdate")]
	private SimpleButton _btnUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nUsePoint")]
	private TextBox _nUsePoint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkPointMemb")]
	private CheckBox _chkPointMemb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnQuot")]
	private SimpleButton _btnQuot;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_UPI")]
	private TextBox _TEXT_UPI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_UPI")]
	private AxMSFlexGrid _MSG_UPI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkRateUnFix")]
	private CheckBox _chkRateUnFix;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_CRNT")]
	private TextBox _TEXT_CRNT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_CRNT")]
	private AxMSFlexGrid _MSG_CRNT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcMembCode")]
	private TextBox _tAcMembCode;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private double ColHight;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string AcGstType;

	private bool MobileSearch;

	private string SmsDetail;

	private double CurItGwtStk;

	private bool OsAmtSave;

	private double AcTcsAmt;

	private double OldTcsPrc;

	private string PointMemb;

	private bool MobHelpOpen;

	private bool UpiTypeAdd;

	private string CurPrnMobile;

	private DataTable VchOldData;

	private double ToDayGlRate;

	private double ToDaySlRate;

	private string WappAcName;

	private string WappMobile;

	private string WappMsg;

	private string AdminWappMsg;

	private string MoBook;

	private string MoVch;

	private string MainDbCd;

	private string MainVchNo;

	private string MainHdVchNo;

	private string OldAcCode;

	private double CustOpAmt;

	private double CustClAmt;

	private double LessAdvAmt;

	private double CrntAdjAmt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private double OldCardAmt;

	private double OldGoldPurcAmt;

	private double OldSilverPurcAmt;

	private double OldSchmAmt;

	private double OldNetAmt;

	private double OldTaxPrc;

	private string MsVchSrno;

	private string FormPrintFile;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsOldDetl;

	private DataTable RsImg;

	private DataTable RsBillOs;

	private string CardCommAdj;

	private DataTable RsComDetl;

	private DataTable RsGrTch;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private bool MsgIdtlLeft;

	private bool MsgOldLeft;

	private string FormBook;

	private string FormName;

	private string FormBookType;

	private string FormItmType;

	private string FormVchNo;

	private string FormMainBook;

	private string FormBookSname;

	private string FormBookInOut;

	private string MaxVchNo;

	private string LastVchNo;

	private bool RowChang;

	private string QtDbCd;

	private string QtNo;

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItmLot = 2;

	private const int cItCode = 3;

	private const int cCounter = 4;

	private const int cOrderNo = 5;

	private const int cDesign = 6;

	private const int cStyle = 7;

	private const int cSize = 8;

	private const int cHmId = 9;

	private const int cBagWt = 10;

	private const int cPcs = 11;

	private const int cGrWt = 12;

	private const int cOthWt = 13;

	private const int cNetWt = 14;

	private const int cGhtPrc = 15;

	private const int cFixGhtPrc = 16;

	private const int cGhtWt = 17;

	private const int cTouch = 18;

	private const int cWestPrc = 19;

	private const int cFine = 20;

	private const int cRateWith = 21;

	private const int cItRate = 22;

	private const int cItAmt = 23;

	private const int cLbrPrc = 24;

	private const int cLbrType = 25;

	private const int cLbrRate = 26;

	private const int cLbrAmt = 27;

	private const int cGhtAmt = 28;

	private const int cOthAmt = 29;

	private const int cMrp = 30;

	private const int cLbrDiscPrc = 31;

	private const int cLbrDiscAmt = 32;

	private const int cNetLbrAmt = 33;

	private const int cEmpCode = 34;

	private const int cTotAmt = 35;

	private const int cTaxPrc = 36;

	private const int cNetAmt = 37;

	private const int cPrCost = 38;

	private const int cMembComPrc = 39;

	private const int cMembComVal = 40;

	private const int cKrName = 41;

	private const int cKrOthWt = 42;

	private const int cKrNetWt = 43;

	private const int cKrGhatPrc = 44;

	private const int cKrGhatWt = 45;

	private const int cKrTouch = 46;

	private const int cKrWestPrc = 47;

	private const int cKrFine = 48;

	private const int cKrLRate = 49;

	private const int cKrLAmt = 50;

	private const int cKrOthAmt = 51;

	private const int cVchSrno = 52;

	private const int cTagCost = 53;

	private const int cMargin = 54;

	private const int cImageTake = 55;

	private const int cTagSrNo = 56;

	private const int cOldSrNo = 57;

	private const int cRateType = 58;

	private const int cItType = 59;

	private const int cTagType = 60;

	private const int cPrCode = 61;

	private const int cItName = 62;

	private const int cEntryMod = 63;

	private const int cOldTagType = 64;

	private const int cOldPrCode = 65;

	private const int cOldGrWt = 66;

	private const int cOldNtWt = 67;

	private const int cOldGhatPrc = 68;

	private const int cOldGhatWt = 69;

	private const int cOldTouch = 70;

	private const int cOldWestPrc = 71;

	private const int cOldKrNetWt = 72;

	private const int cOldKrTouch = 73;

	private const int cOldKrWest = 74;

	private const int cItDesc = 75;

	private const int cOldLbrRate = 76;

	private const int cOldLbrAmt = 77;

	private const int cIsuNo = 78;

	private const int cIsuYrCd = 79;

	private const int cIsuDbCd = 80;

	private const int cIsuSrNo = 81;

	private const int cOldItRate = 82;

	private const int cOldLbrPrc = 83;

	private const int cOldOthWt = 84;

	private const int cOldLbrType = 85;

	private const int cHmId2 = 86;

	private const int cHmId3 = 87;

	private const int cHmId4 = 88;

	private const int cHmIdWt = 89;

	private const int cHmId2Wt = 90;

	private const int cHmId3Wt = 91;

	private const int cHmId4wt = 92;

	private const int cOldValChange = 93;

	private const int cOrdYrCd = 94;

	private const int cOrdDbCd = 95;

	private const int cOrdSrNo = 96;

	private const int cTagGwt = 97;

	private const int cTagNwt = 98;

	private const int cItProfit = 99;

	private const int cOrdTagStkAdd = 100;

	private const int cDesignImgId = 101;

	private const int cOldRateWith = 102;

	private const int cQuotDbCd = 103;

	private const int cQuotNo = 104;

	private const int cOldFixGhtPrc = 105;

	private const int cItmGrTch = 106;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmColor = 5;

	private const int c1DmSize = 6;

	private const int c1DmOrigin = 7;

	private const int c1DmRemark = 8;

	private const int c1DmSfNo = 9;

	private const int c1Pcs = 10;

	private const int c1GrWt = 11;

	private const int c1ConPrc = 12;

	private const int c1RateType = 13;

	private const int c1ItRate = 14;

	private const int c1ItmAmt = 15;

	private const int c1LbrRate = 16;

	private const int c1LbrAmt = 17;

	private const int c1NetAmt = 18;

	private const int c1ConWt = 19;

	private const int c1KrWt = 20;

	private const int c1KrConWt = 21;

	private const int c1ItType = 22;

	private const int c1RowSr = 23;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cTcs2 = 3;

	private const int cRof2 = 4;

	private const int cTot2 = 5;

	private const int cChq2 = 6;

	private const int cCard2 = 7;

	private const int cOrder2 = 8;

	private const int cOldGold2 = 9;

	private const int cOldSl2 = 10;

	private const int cSchem2 = 11;

	private const int cCash2 = 12;

	private const int cCashPaid2 = 13;

	private const int cKasar2 = 14;

	private const int cOs2 = 15;

	private const int cUrSrNo = 0;

	private const int cUrItCode = 1;

	private const int cUrItName = 2;

	private const int cUrPcs = 3;

	private const int cUrGrWt = 4;

	private const int cUrLess = 5;

	private const int cUrNetWt = 6;

	private const int cUrTouch = 7;

	private const int cUrFine = 8;

	private const int cUrConTouch = 9;

	private const int cUrConWt = 10;

	private const int cUrRate = 11;

	private const int cUrRateType = 12;

	private const int cUrNetAmt = 13;

	private const int cUrItType = 14;

	private const int cUrOldGwt = 15;

	private const int cUrOldLess = 16;

	private const int cUrPrCost = 17;

	private const int cOrSrNo = 0;

	private const int cOrVchNo = 1;

	private const int cOrVchAmt = 2;

	private const int cOrLc = 3;

	private const int cOrYrCd = 4;

	private const int cOrDbCd = 5;

	private const int cOrAcCode = 6;

	private const int cOrHdVchNo = 7;

	private const int cOrPandingAmt = 8;

	private const int cUpSrNo = 0;

	private const int cUpAcCode = 1;

	private const int cUpAcName = 2;

	private const int cUpUpiType = 3;

	private const int cUpUpiId = 4;

	private const int cUpUpiAmt = 5;

	private const int cCrSrNo = 0;

	private const int cCrVchNo = 1;

	private const int cCrVchAmt = 2;

	private const int cCrLc = 3;

	private const int cCrYrCd = 4;

	private const int cCrDbCd = 5;

	private const int cCrAcCode = 6;

	private const int cCrHdVchNo = 7;

	private const int cCrPandingAmt = 8;

	internal virtual Label lblBook
	{
		[CompilerGenerated]
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblBook_DoubleClick;
			Label val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_lblBook = value;
			val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mVchDate
	{
		[CompilerGenerated]
		get
		{
			return _mVchDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mVchDate_KeyDown);
			EventHandler eventHandler2 = mVchDate_Click;
			MaskInputRejectedEventHandler val2 = new MaskInputRejectedEventHandler(mVchDate_MaskInputRejected);
			MaskedTextBox val3 = _mVchDate;
			if (val3 != null)
			{
				((Control)val3).GotFocus -= eventHandler;
				((Control)val3).KeyDown -= val;
				((TextBoxBase)val3).Click -= eventHandler2;
				val3.MaskInputRejected -= val2;
			}
			_mVchDate = value;
			val3 = _mVchDate;
			if (val3 != null)
			{
				((Control)val3).GotFocus += eventHandler;
				((Control)val3).KeyDown += val;
				((TextBoxBase)val3).Click += eventHandler2;
				val3.MaskInputRejected += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBDate")]
	private virtual Label _lblBDate;

	internal virtual Label lblBDate
	{
		get
		{
			return _lblBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBDate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private virtual Label _Label2;

	internal virtual Label Label2
	{
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label2 = value;
		}
	}

	internal virtual TextBox tVchNo
	{
		[CompilerGenerated]
		get
		{
			return _tVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tVchNo_DoubleClick;
			EventHandler eventHandler2 = TVchNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mDay")]
	private virtual TextBox _mDay;

	internal virtual TextBox mDay
	{
		get
		{
			return _mDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mDay = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mTime")]
	private virtual TextBox _mTime;

	internal virtual TextBox mTime
	{
		get
		{
			return _mTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mTime = value;
		}
	}

	internal virtual SimpleButton BtnPrint
	{
		[CompilerGenerated]
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPrint_Click;
			SimpleButton val = _BtnPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPrint = value;
			val = _BtnPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnSave
	{
		[CompilerGenerated]
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSave_Click;
			SimpleButton val = _BtnSave;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSave = value;
			val = _BtnSave;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCancel_Click;
			SimpleButton val = _BtnCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCancel = value;
			val = _BtnCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDelete_Click;
			SimpleButton val = _BtnDelete;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDelete = value;
			val = _BtnDelete;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnExit
	{
		[CompilerGenerated]
		get
		{
			return _BtnExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExit_Click;
			SimpleButton val = _BtnExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExit = value;
			val = _BtnExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private virtual FlowLayoutPanel _PnlBotam;

	internal virtual FlowLayoutPanel PnlBotam
	{
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlBotam = value;
		}
	}

	internal virtual AxMSFlexGrid MSG
	{
		[CompilerGenerated]
		get
		{
			return _MSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_ClickEvent;
			EventHandler eventHandler2 = MSG_EnterCell;
			EventHandler eventHandler3 = MSG_LeaveCell;
			EventHandler eventHandler4 = MSG_RowColChange;
			EventHandler eventHandler5 = MSG_Scroll;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
				val.Scroll -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
				val.Scroll += eventHandler5;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_TOT")]
	private virtual AxMSFlexGrid _MSG_TOT;

	internal virtual AxMSFlexGrid MSG_TOT
	{
		get
		{
			return _MSG_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_TOT = value;
		}
	}

	internal virtual TextBox TEXT_ENTRY
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual PictureBox PicImage
	{
		[CompilerGenerated]
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicImage_DoubleClick;
			PictureBox val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicImage = value;
			val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblItem")]
	private virtual Label _lblItem;

	internal virtual Label lblItem
	{
		get
		{
			return _lblItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblItem = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_IDTL = value;
			val = _MSG_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_IDTL_KeyDown);
			TextBox val2 = _TEXT_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_IDTL = value;
			val2 = _TEXT_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpen")]
	private virtual OpenFileDialog _DlgOpen;

	internal virtual OpenFileDialog DlgOpen
	{
		get
		{
			return _DlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpen = value;
		}
	}

	internal virtual SimpleButton BtnFirst
	{
		[CompilerGenerated]
		get
		{
			return _BtnFirst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFirst_Click;
			SimpleButton val = _BtnFirst;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnFirst = value;
			val = _BtnFirst;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual PictureBox PicZoom
	{
		[CompilerGenerated]
		get
		{
			return _PicZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicZoom_DoubleClick;
			PictureBox val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicZoom = value;
			val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnLast
	{
		[CompilerGenerated]
		get
		{
			return _BtnLast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLast_Click;
			SimpleButton val = _BtnLast;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnLast = value;
			val = _BtnLast;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnF1
	{
		[CompilerGenerated]
		get
		{
			return _BtnF1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnF1_Click;
			SimpleButton val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnF1 = value;
			val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Cr")]
	private virtual AxCrystalReport _Cr;

	internal virtual AxCrystalReport Cr
	{
		get
		{
			return _Cr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Cr = value;
		}
	}

	internal virtual TextBox tAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			EventHandler eventHandler2 = tAcCode_DoubleClick;
			EventHandler eventHandler3 = tAcCode_GotFocus;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler2;
				((Control)val2).GotFocus -= eventHandler3;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler2;
				((Control)val2).GotFocus += eventHandler3;
			}
		}
	}

	internal virtual TextBox tAcName
	{
		[CompilerGenerated]
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tAcName_GotFocus;
			EventHandler eventHandler2 = tAcName_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			TextBox val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_tAcName = value;
			val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private virtual Label _Label1;

	internal virtual Label Label1
	{
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHdVchNo")]
	private virtual TextBox _tHdVchNo;

	internal virtual TextBox tHdVchNo
	{
		get
		{
			return _tHdVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tHdVchNo = value;
		}
	}

	internal virtual TextBox tEmpCode
	{
		[CompilerGenerated]
		get
		{
			return _tEmpCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmpCode_KeyDown);
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpName")]
	private virtual TextBox _tEmpName;

	internal virtual TextBox tEmpName
	{
		get
		{
			return _tEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tEmpName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private virtual Label _Label3;

	internal virtual Label Label3
	{
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label4")]
	private virtual Label _Label4;

	internal virtual Label Label4
	{
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label4 = value;
		}
	}

	internal virtual TextBox tVchDesc
	{
		[CompilerGenerated]
		get
		{
			return _tVchDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tVchDesc_KeyDown);
			EventHandler eventHandler = tVchDesc_DoubleClick;
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual TextBox tItDesc
	{
		[CompilerGenerated]
		get
		{
			return _tItDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItDesc_KeyDown);
			TextBox val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItDesc = value;
			val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label5")]
	private virtual Label _Label5;

	internal virtual Label Label5
	{
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label5 = value;
		}
	}

	internal virtual AxMSFlexGrid MSG2_TOTAL
	{
		[CompilerGenerated]
		get
		{
			return _MSG2_TOTAL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG2_TOTAL_ClickEvent;
			EventHandler eventHandler2 = MSG2_TOTAL_EnterCell;
			EventHandler eventHandler3 = MSG2_TOTAL_LeaveCell;
			AxMSFlexGrid val = _MSG2_TOTAL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG2_TOTAL = value;
			val = _MSG2_TOTAL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG_OLD
	{
		[CompilerGenerated]
		get
		{
			return _MSG_OLD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_OLD_ClickEvent;
			EventHandler eventHandler2 = MSG_OLD_EnterCell;
			EventHandler eventHandler3 = MSG_OLD_LeaveCell;
			AxMSFlexGrid val = _MSG_OLD;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_OLD = value;
			val = _MSG_OLD;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_ENTRY_2
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY_2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_2_TextChanged;
			EventHandler eventHandler2 = TEXT_ENTRY_2_DoubleClick;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_2_KeyDown);
			TextBox val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).DoubleClick -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY_2 = value;
			val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).DoubleClick += eventHandler2;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox TEXT_OLD
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_OLD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_OLD_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_OLD_KeyDown);
			TextBox val2 = _TEXT_OLD;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_OLD = value;
			val2 = _TEXT_OLD;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankName
	{
		[CompilerGenerated]
		get
		{
			return _tBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankName_KeyDown);
			TextBox val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankName = value;
			val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label7")]
	private virtual Label _Label7;

	internal virtual Label Label7
	{
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label7 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label8")]
	private virtual Label _Label8;

	internal virtual Label Label8
	{
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label8 = value;
		}
	}

	internal virtual TextBox tBillNo
	{
		[CompilerGenerated]
		get
		{
			return _tBillNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBillNo_KeyDown);
			TextBox val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBillNo = value;
			val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelAdd")]
	private virtual Panel _PanelAdd;

	internal virtual Panel PanelAdd
	{
		get
		{
			return _PanelAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelAdd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label13")]
	private virtual Label _Label13;

	internal virtual Label Label13
	{
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual TextBox tMobile
	{
		[CompilerGenerated]
		get
		{
			return _tMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMobile_KeyDown);
			TextBox val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile = value;
			val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label11")]
	private virtual Label _Label11;

	internal virtual Label Label11
	{
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual TextBox tCity
	{
		[CompilerGenerated]
		get
		{
			return _tCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCity_KeyDown);
			TextBox val2 = _tCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCity = value;
			val2 = _tCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label10")]
	private virtual Label _Label10;

	internal virtual Label Label10
	{
		get
		{
			return _Label10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label10 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label9")]
	private virtual Label _Label9;

	internal virtual Label Label9
	{
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label9 = value;
		}
	}

	internal virtual TextBox tAdd3
	{
		[CompilerGenerated]
		get
		{
			return _tAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd3_KeyDown);
			TextBox val2 = _tAdd3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdd3 = value;
			val2 = _tAdd3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAdd2
	{
		[CompilerGenerated]
		get
		{
			return _tAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd2_KeyDown);
			TextBox val2 = _tAdd2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdd2 = value;
			val2 = _tAdd2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAdd1
	{
		[CompilerGenerated]
		get
		{
			return _tAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd1_KeyDown);
			TextBox val2 = _tAdd1;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdd1 = value;
			val2 = _tAdd1;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label6")]
	private virtual Label _Label6;

	internal virtual Label Label6
	{
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label6 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LOpAmt")]
	private virtual Label _LOpAmt;

	internal virtual Label LOpAmt
	{
		get
		{
			return _LOpAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LClAmt")]
	private virtual Label _LClAmt;

	internal virtual Label LClAmt
	{
		get
		{
			return _LClAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LClAmt = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_ORD
	{
		[CompilerGenerated]
		get
		{
			return _MSG_ORD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_ORD_ClickEvent;
			EventHandler eventHandler2 = MSG_ORD_EnterCell;
			EventHandler eventHandler3 = MSG_ORD_LeaveCell;
			AxMSFlexGrid val = _MSG_ORD;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_ORD = value;
			val = _MSG_ORD;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_ORD
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ORD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ORD_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ORD_KeyDown);
			TextBox val2 = _TEXT_ORD;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ORD = value;
			val2 = _TEXT_ORD;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuYrCd")]
	private virtual TextBox _tIsuYrCd;

	internal virtual TextBox tIsuYrCd
	{
		get
		{
			return _tIsuYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuDbCd")]
	private virtual TextBox _tIsuDbCd;

	internal virtual TextBox tIsuDbCd
	{
		get
		{
			return _tIsuDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuDbCd = value;
		}
	}

	internal virtual SimpleButton btnIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _btnIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnIsuNo_Click;
			SimpleButton val = _btnIsuNo;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIsuNo = value;
			val = _btnIsuNo;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label12")]
	private virtual Label _Label12;

	internal virtual Label Label12
	{
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label12 = value;
		}
	}

	internal virtual TextBox tIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _tIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tIsuNo_KeyDown);
			TextBox val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tIsuNo = value;
			val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label14")]
	private virtual Label _Label14;

	internal virtual Label Label14
	{
		get
		{
			return _Label14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label14 = value;
		}
	}

	internal virtual TextBox nCrDays
	{
		[CompilerGenerated]
		get
		{
			return _nCrDays;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrDays_KeyDown);
			TextBox val2 = _nCrDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrDays = value;
			val2 = _nCrDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPanNo
	{
		[CompilerGenerated]
		get
		{
			return _tPanNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPanNo_KeyDown);
			TextBox val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPanNo = value;
			val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton btnTagSet
	{
		[CompilerGenerated]
		get
		{
			return _btnTagSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTagSet_Click;
			SimpleButton val = _btnTagSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagSet = value;
			val = _btnTagSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintfile")]
	private virtual ComboBox _cboPrintfile;

	internal virtual ComboBox cboPrintfile
	{
		get
		{
			return _cboPrintfile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintfile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label15")]
	private virtual Label _Label15;

	internal virtual Label Label15
	{
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label15 = value;
		}
	}

	internal virtual TextBox tNewPrint
	{
		[CompilerGenerated]
		get
		{
			return _tNewPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tNewPrint_KeyDown);
			TextBox val2 = _tNewPrint;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tNewPrint = value;
			val2 = _tNewPrint;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("WebBrowser1")]
	private virtual WebBrowser _WebBrowser1;

	internal virtual WebBrowser WebBrowser1
	{
		get
		{
			return _WebBrowser1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_WebBrowser1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblItStock")]
	private virtual Label _lblItStock;

	internal virtual Label lblItStock
	{
		get
		{
			return _lblItStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblItStock = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkHuIdPrint")]
	private virtual CheckBox _chkHuIdPrint;

	internal virtual CheckBox chkHuIdPrint
	{
		get
		{
			return _chkHuIdPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkHuIdPrint = value;
		}
	}

	internal virtual Label lblTrfrOpen
	{
		[CompilerGenerated]
		get
		{
			return _lblTrfrOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblTrfrOpen_Click;
			Label val = _lblTrfrOpen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_lblTrfrOpen = value;
			val = _lblTrfrOpen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlTrfrVch")]
	private virtual Panel _PnlTrfrVch;

	internal virtual Panel PnlTrfrVch
	{
		get
		{
			return _PnlTrfrVch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlTrfrVch = value;
		}
	}

	internal virtual SimpleButton btnTrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTrfr_Click;
			SimpleButton val = _btnTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTrfr = value;
			val = _btnTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrYrCd")]
	private virtual TextBox _tTrfrYrCd;

	internal virtual TextBox tTrfrYrCd
	{
		get
		{
			return _tTrfrYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTrfrYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrDbCd")]
	private virtual TextBox _tTrfrDbCd;

	internal virtual TextBox tTrfrDbCd
	{
		get
		{
			return _tTrfrDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTrfrDbCd = value;
		}
	}

	internal virtual TextBox tTrfrNo
	{
		[CompilerGenerated]
		get
		{
			return _tTrfrNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTrfrNo_KeyDown);
			EventHandler eventHandler = tTrfrNo_TextChanged;
			TextBox val2 = _tTrfrNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tTrfrNo = value;
			val2 = _tTrfrNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label19")]
	private virtual Label _Label19;

	internal virtual Label Label19
	{
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label19 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlUpdate")]
	private virtual Panel _PnlUpdate;

	internal virtual Panel PnlUpdate
	{
		get
		{
			return _PnlUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlUpdate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label23")]
	private virtual Label _Label23;

	internal virtual Label Label23
	{
		get
		{
			return _Label23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label23 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label22")]
	private virtual Label _Label22;

	internal virtual Label Label22
	{
		get
		{
			return _Label22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label22 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	private virtual Label _Label16;

	internal virtual Label Label16
	{
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label16 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label17")]
	private virtual Label _Label17;

	internal virtual Label Label17
	{
		get
		{
			return _Label17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label17 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label18")]
	private virtual Label _Label18;

	internal virtual Label Label18
	{
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label18 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label20")]
	private virtual Label _Label20;

	internal virtual Label Label20
	{
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label20 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label21")]
	private virtual Label _Label21;

	internal virtual Label Label21
	{
		get
		{
			return _Label21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label21 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label25")]
	private virtual Label _Label25;

	internal virtual Label Label25
	{
		get
		{
			return _Label25;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label25 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label24")]
	private virtual Label _Label24;

	internal virtual Label Label24
	{
		get
		{
			return _Label24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label24 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAnvDate")]
	private virtual Label _UAnvDate;

	internal virtual Label UAnvDate
	{
		get
		{
			return _UAnvDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAnvDate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UBrDate")]
	private virtual Label _UBrDate;

	internal virtual Label UBrDate
	{
		get
		{
			return _UBrDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UBrDate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UMobile")]
	private virtual Label _UMobile;

	internal virtual Label UMobile
	{
		get
		{
			return _UMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UGstNo")]
	private virtual Label _UGstNo;

	internal virtual Label UGstNo
	{
		get
		{
			return _UGstNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UGstNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("URefBy")]
	private virtual Label _URefBy;

	internal virtual Label URefBy
	{
		get
		{
			return _URefBy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_URefBy = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UCity")]
	private virtual Label _UCity;

	internal virtual Label UCity
	{
		get
		{
			return _UCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UCity = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAdd3")]
	private virtual Label _UAdd3;

	internal virtual Label UAdd3
	{
		get
		{
			return _UAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAdd3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAdd2")]
	private virtual Label _UAdd2;

	internal virtual Label UAdd2
	{
		get
		{
			return _UAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAdd2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAdd1")]
	private virtual Label _UAdd1;

	internal virtual Label UAdd1
	{
		get
		{
			return _UAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAdd1 = value;
		}
	}

	internal virtual SimpleButton btnUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnUpdate_Click;
			SimpleButton val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUpdate = value;
			val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWapp")]
	private virtual CheckBox _chkWapp;

	internal virtual CheckBox chkWapp
	{
		get
		{
			return _chkWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkWapp = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nItProfit")]
	private virtual Label _nItProfit;

	internal virtual Label nItProfit
	{
		get
		{
			return _nItProfit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nItProfit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBillProfit")]
	private virtual TextBox _nBillProfit;

	internal virtual TextBox nBillProfit
	{
		get
		{
			return _nBillProfit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBillProfit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlPoint")]
	private virtual Panel _PnlPoint;

	internal virtual Panel PnlPoint
	{
		get
		{
			return _PnlPoint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlPoint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPointCode")]
	private virtual TextBox _tPointCode;

	internal virtual TextBox tPointCode
	{
		get
		{
			return _tPointCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPointCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nUseVal")]
	private virtual TextBox _nUseVal;

	internal virtual TextBox nUseVal
	{
		get
		{
			return _nUseVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nUseVal = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label28")]
	private virtual Label _Label28;

	internal virtual Label Label28
	{
		get
		{
			return _Label28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label28 = value;
		}
	}

	internal virtual TextBox nUsePoint
	{
		[CompilerGenerated]
		get
		{
			return _nUsePoint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nUsePoint_KeyDown);
			TextBox val2 = _nUsePoint;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nUsePoint = value;
			val2 = _nUsePoint;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBillPoint")]
	private virtual TextBox _nBillPoint;

	internal virtual TextBox nBillPoint
	{
		get
		{
			return _nBillPoint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBillPoint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPointBillVal")]
	private virtual TextBox _nPointBillVal;

	internal virtual TextBox nPointBillVal
	{
		get
		{
			return _nPointBillVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPointBillVal = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label27")]
	private virtual Label _Label27;

	internal virtual Label Label27
	{
		get
		{
			return _Label27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label27 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPointBal")]
	private virtual TextBox _nPointBal;

	internal virtual TextBox nPointBal
	{
		get
		{
			return _nPointBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPointBal = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label26")]
	private virtual Label _Label26;

	internal virtual Label Label26
	{
		get
		{
			return _Label26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label26 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPointVal")]
	private virtual TextBox _nPointVal;

	internal virtual TextBox nPointVal
	{
		get
		{
			return _nPointVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPointVal = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPointSlVal")]
	private virtual TextBox _nPointSlVal;

	internal virtual TextBox nPointSlVal
	{
		get
		{
			return _nPointSlVal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPointSlVal = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label30")]
	private virtual Label _Label30;

	internal virtual Label Label30
	{
		get
		{
			return _Label30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label30 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotPoint")]
	private virtual TextBox _nTotPoint;

	internal virtual TextBox nTotPoint
	{
		get
		{
			return _nTotPoint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotPoint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label29")]
	private virtual Label _Label29;

	internal virtual Label Label29
	{
		get
		{
			return _Label29;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label29 = value;
		}
	}

	internal virtual TextBox tRefAc
	{
		[CompilerGenerated]
		get
		{
			return _tRefAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRefAc_KeyDown);
			TextBox val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRefAc = value;
			val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefName")]
	private virtual TextBox _tRefName;

	internal virtual TextBox tRefName
	{
		get
		{
			return _tRefName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRefName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label31")]
	private virtual Label _Label31;

	internal virtual Label Label31
	{
		get
		{
			return _Label31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label31 = value;
		}
	}

	internal virtual CheckBox chkPointMemb
	{
		[CompilerGenerated]
		get
		{
			return _chkPointMemb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkPointMemb_Click;
			CheckBox val = _chkPointMemb;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkPointMemb = value;
			val = _chkPointMemb;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBillOrnaIsu")]
	private virtual CheckBox _chkBillOrnaIsu;

	internal virtual CheckBox chkBillOrnaIsu
	{
		get
		{
			return _chkBillOrnaIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkBillOrnaIsu = value;
		}
	}

	internal virtual SimpleButton btnQuot
	{
		[CompilerGenerated]
		get
		{
			return _btnQuot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnQuot_Click;
			SimpleButton val = _btnQuot;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnQuot = value;
			val = _btnQuot;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlUpi")]
	private virtual Panel _PnlUpi;

	internal virtual Panel PnlUpi
	{
		get
		{
			return _PnlUpi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlUpi = value;
		}
	}

	internal virtual TextBox TEXT_UPI
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_UPI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_UPI_KeyDown);
			TextBox val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TEXT_UPI = value;
			val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG_UPI
	{
		[CompilerGenerated]
		get
		{
			return _MSG_UPI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_UPI_ClickEvent;
			EventHandler eventHandler2 = MSG_UPI_EnterCell;
			EventHandler eventHandler3 = MSG_UPI_LeaveCell;
			AxMSFlexGrid val = _MSG_UPI;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_UPI = value;
			val = _MSG_UPI;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual CheckBox chkRateUnFix
	{
		[CompilerGenerated]
		get
		{
			return _chkRateUnFix;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkRateUnFix_KeyDown);
			CheckBox val2 = _chkRateUnFix;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkRateUnFix = value;
			val2 = _chkRateUnFix;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("picAc")]
	private virtual PictureBox _picAc;

	internal virtual PictureBox picAc
	{
		get
		{
			return _picAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_picAc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlCrnt")]
	private virtual Panel _pnlCrnt;

	internal virtual Panel pnlCrnt
	{
		get
		{
			return _pnlCrnt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlCrnt = value;
		}
	}

	internal virtual TextBox TEXT_CRNT
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_CRNT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_CRNT_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_CRNT_KeyDown);
			TextBox val2 = _TEXT_CRNT;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_CRNT = value;
			val2 = _TEXT_CRNT;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG_CRNT
	{
		[CompilerGenerated]
		get
		{
			return _MSG_CRNT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_CRNT_ClickEvent;
			EventHandler eventHandler2 = MSG_CRNT_EnterCell;
			EventHandler eventHandler3 = MSG_CRNT_LeaveCell;
			AxMSFlexGrid val = _MSG_CRNT;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_CRNT = value;
			val = _MSG_CRNT;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlMobile")]
	private virtual Panel _pnlMobile;

	internal virtual Panel pnlMobile
	{
		get
		{
			return _pnlMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcMobile")]
	private virtual Label _tAcMobile;

	internal virtual Label tAcMobile
	{
		get
		{
			return _tAcMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlMembAcCode")]
	private virtual Panel _pnlMembAcCode;

	internal virtual Panel pnlMembAcCode
	{
		get
		{
			return _pnlMembAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlMembAcCode = value;
		}
	}

	internal virtual TextBox tAcMembCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcMembCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcMembCode_KeyDown);
			TextBox val2 = _tAcMembCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcMembCode = value;
			val2 = _tAcMembCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcMembName")]
	private virtual TextBox _tAcMembName;

	internal virtual TextBox tAcMembName
	{
		get
		{
			return _tAcMembName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcMembName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label32")]
	private virtual Label _Label32;

	internal virtual Label Label32
	{
		get
		{
			return _Label32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label32 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWhoutcommBill")]
	private virtual CheckBox _chkWhoutcommBill;

	internal virtual CheckBox chkWhoutcommBill
	{
		get
		{
			return _chkWhoutcommBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkWhoutcommBill = value;
		}
	}

	public TR_SALE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((Form)this).Load += TR_SALE_Load;
		((Form)this).Deactivate += TR_SALE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SALE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SALE_KeyDown);
		((Form)this).Activated += TR_SALE_Activated;
		((Form)this).Closed += TR_SALE_Closed;
		((Control)this).DoubleClick += TR_SALE_DoubleClick;
		((Control)this).KeyUp += new KeyEventHandler(TR_SALE_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected O, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Expected O, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected O, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Expected O, but got Unknown
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected O, but got Unknown
		//IL_059a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Expected O, but got Unknown
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected O, but got Unknown
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Expected O, but got Unknown
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Expected O, but got Unknown
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Expected O, but got Unknown
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected O, but got Unknown
		//IL_062a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Expected O, but got Unknown
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected O, but got Unknown
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Expected O, but got Unknown
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected O, but got Unknown
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Expected O, but got Unknown
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Expected O, but got Unknown
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected O, but got Unknown
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c0: Expected O, but got Unknown
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Expected O, but got Unknown
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f4: Expected O, but got Unknown
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aac: Expected O, but got Unknown
		//IL_0b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3d: Expected O, but got Unknown
		//IL_0bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be2: Expected O, but got Unknown
		//IL_0c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7b: Expected O, but got Unknown
		//IL_0cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce8: Expected O, but got Unknown
		//IL_0d91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9b: Expected O, but got Unknown
		//IL_0dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e08: Expected O, but got Unknown
		//IL_0eb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebb: Expected O, but got Unknown
		//IL_0fd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe2: Expected O, but got Unknown
		//IL_10ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Expected O, but got Unknown
		//IL_115a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1164: Expected O, but got Unknown
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1373: Unknown result type (might be due to invalid IL or missing references)
		//IL_137d: Expected O, but got Unknown
		//IL_1435: Unknown result type (might be due to invalid IL or missing references)
		//IL_143f: Expected O, but got Unknown
		//IL_14e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f0: Expected O, but got Unknown
		//IL_15e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f2: Expected O, but got Unknown
		//IL_16f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1700: Expected O, but got Unknown
		//IL_17bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c6: Expected O, but got Unknown
		//IL_1843: Unknown result type (might be due to invalid IL or missing references)
		//IL_184d: Expected O, but got Unknown
		//IL_1911: Unknown result type (might be due to invalid IL or missing references)
		//IL_191b: Expected O, but got Unknown
		//IL_19c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cc: Expected O, but got Unknown
		//IL_1ac4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ace: Expected O, but got Unknown
		//IL_1b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b39: Expected O, but got Unknown
		//IL_1c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4c: Expected O, but got Unknown
		//IL_1d24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2e: Expected O, but got Unknown
		//IL_1dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd4: Expected O, but got Unknown
		//IL_1f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f19: Expected O, but got Unknown
		//IL_1f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6e: Expected O, but got Unknown
		//IL_1feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff5: Expected O, but got Unknown
		//IL_2076: Unknown result type (might be due to invalid IL or missing references)
		//IL_2080: Expected O, but got Unknown
		//IL_214a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2154: Expected O, but got Unknown
		//IL_21fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2205: Expected O, but got Unknown
		//IL_2286: Unknown result type (might be due to invalid IL or missing references)
		//IL_2290: Expected O, but got Unknown
		//IL_2318: Unknown result type (might be due to invalid IL or missing references)
		//IL_2322: Expected O, but got Unknown
		//IL_23d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e0: Expected O, but got Unknown
		//IL_2494: Unknown result type (might be due to invalid IL or missing references)
		//IL_249e: Expected O, but got Unknown
		//IL_2540: Unknown result type (might be due to invalid IL or missing references)
		//IL_254a: Expected O, but got Unknown
		//IL_25cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d5: Expected O, but got Unknown
		//IL_269f: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a9: Expected O, but got Unknown
		//IL_2710: Unknown result type (might be due to invalid IL or missing references)
		//IL_271a: Expected O, but got Unknown
		//IL_2775: Unknown result type (might be due to invalid IL or missing references)
		//IL_277f: Expected O, but got Unknown
		//IL_281e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2828: Expected O, but got Unknown
		//IL_28b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c1: Expected O, but got Unknown
		//IL_2946: Unknown result type (might be due to invalid IL or missing references)
		//IL_2950: Expected O, but got Unknown
		//IL_29f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fa: Expected O, but got Unknown
		//IL_2aa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab2: Expected O, but got Unknown
		//IL_2c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca8: Expected O, but got Unknown
		//IL_2d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d5f: Expected O, but got Unknown
		//IL_2dee: Unknown result type (might be due to invalid IL or missing references)
		//IL_2df8: Expected O, but got Unknown
		//IL_2ea6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb0: Expected O, but got Unknown
		//IL_2f3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f49: Expected O, but got Unknown
		//IL_2ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3001: Expected O, but got Unknown
		//IL_30af: Unknown result type (might be due to invalid IL or missing references)
		//IL_30b9: Expected O, but got Unknown
		//IL_3148: Unknown result type (might be due to invalid IL or missing references)
		//IL_3152: Expected O, but got Unknown
		//IL_31e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_31eb: Expected O, but got Unknown
		//IL_3279: Unknown result type (might be due to invalid IL or missing references)
		//IL_3283: Expected O, but got Unknown
		//IL_3330: Unknown result type (might be due to invalid IL or missing references)
		//IL_333a: Expected O, but got Unknown
		//IL_33ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_33f8: Expected O, but got Unknown
		//IL_34c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_34cf: Expected O, but got Unknown
		//IL_352a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3534: Expected O, but got Unknown
		//IL_35c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_35d0: Expected O, but got Unknown
		//IL_365b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3665: Expected O, but got Unknown
		//IL_3713: Unknown result type (might be due to invalid IL or missing references)
		//IL_371d: Expected O, but got Unknown
		//IL_37f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_37ff: Expected O, but got Unknown
		//IL_389b: Unknown result type (might be due to invalid IL or missing references)
		//IL_38a5: Expected O, but got Unknown
		//IL_39a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_39b0: Expected O, but got Unknown
		//IL_3a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a68: Expected O, but got Unknown
		//IL_3af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b00: Expected O, but got Unknown
		//IL_3bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bbe: Expected O, but got Unknown
		//IL_3c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c56: Expected O, but got Unknown
		//IL_3d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d26: Expected O, but got Unknown
		//IL_3dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e05: Expected O, but got Unknown
		//IL_3ea1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eab: Expected O, but got Unknown
		//IL_3ffa: Unknown result type (might be due to invalid IL or missing references)
		//IL_4004: Expected O, but got Unknown
		//IL_407e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4088: Expected O, but got Unknown
		//IL_4139: Unknown result type (might be due to invalid IL or missing references)
		//IL_4143: Expected O, but got Unknown
		//IL_4236: Unknown result type (might be due to invalid IL or missing references)
		//IL_4240: Expected O, but got Unknown
		//IL_44a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_44b3: Expected O, but got Unknown
		//IL_4588: Unknown result type (might be due to invalid IL or missing references)
		//IL_4592: Expected O, but got Unknown
		//IL_462b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4635: Expected O, but got Unknown
		//IL_4742: Unknown result type (might be due to invalid IL or missing references)
		//IL_474c: Expected O, but got Unknown
		//IL_47e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_47ef: Expected O, but got Unknown
		//IL_4887: Unknown result type (might be due to invalid IL or missing references)
		//IL_4891: Expected O, but got Unknown
		//IL_491b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4925: Expected O, but got Unknown
		//IL_4cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cc6: Expected O, but got Unknown
		//IL_4de5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4def: Expected O, but got Unknown
		//IL_4ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ead: Expected O, but got Unknown
		//IL_4f61: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f6b: Expected O, but got Unknown
		//IL_501f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5029: Expected O, but got Unknown
		//IL_50dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_50e7: Expected O, but got Unknown
		//IL_5198: Unknown result type (might be due to invalid IL or missing references)
		//IL_51a2: Expected O, but got Unknown
		//IL_5253: Unknown result type (might be due to invalid IL or missing references)
		//IL_525d: Expected O, but got Unknown
		//IL_530e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5318: Expected O, but got Unknown
		//IL_53c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_53d3: Expected O, but got Unknown
		//IL_5484: Unknown result type (might be due to invalid IL or missing references)
		//IL_548e: Expected O, but got Unknown
		//IL_553e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5548: Expected O, but got Unknown
		//IL_55f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5602: Expected O, but got Unknown
		//IL_56b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_56bd: Expected O, but got Unknown
		//IL_576b: Unknown result type (might be due to invalid IL or missing references)
		//IL_5775: Expected O, but got Unknown
		//IL_5825: Unknown result type (might be due to invalid IL or missing references)
		//IL_582f: Expected O, but got Unknown
		//IL_58dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_58e7: Expected O, but got Unknown
		//IL_5995: Unknown result type (might be due to invalid IL or missing references)
		//IL_599f: Expected O, but got Unknown
		//IL_5a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a57: Expected O, but got Unknown
		//IL_5ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5baf: Expected O, but got Unknown
		//IL_5c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c5e: Expected O, but got Unknown
		//IL_5ec1: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ecb: Expected O, but got Unknown
		//IL_5f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f57: Expected O, but got Unknown
		//IL_5fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fe9: Expected O, but got Unknown
		//IL_6097: Unknown result type (might be due to invalid IL or missing references)
		//IL_60a1: Expected O, but got Unknown
		//IL_6139: Unknown result type (might be due to invalid IL or missing references)
		//IL_6143: Expected O, but got Unknown
		//IL_61ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_61d4: Expected O, but got Unknown
		//IL_6280: Unknown result type (might be due to invalid IL or missing references)
		//IL_628a: Expected O, but got Unknown
		//IL_6305: Unknown result type (might be due to invalid IL or missing references)
		//IL_630f: Expected O, but got Unknown
		//IL_63bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_63c7: Expected O, but got Unknown
		//IL_6442: Unknown result type (might be due to invalid IL or missing references)
		//IL_644c: Expected O, but got Unknown
		//IL_64fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_6504: Expected O, but got Unknown
		//IL_6590: Unknown result type (might be due to invalid IL or missing references)
		//IL_659a: Expected O, but got Unknown
		//IL_6633: Unknown result type (might be due to invalid IL or missing references)
		//IL_663d: Expected O, but got Unknown
		//IL_66c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_66cf: Expected O, but got Unknown
		//IL_6780: Unknown result type (might be due to invalid IL or missing references)
		//IL_678a: Expected O, but got Unknown
		//IL_6812: Unknown result type (might be due to invalid IL or missing references)
		//IL_681c: Expected O, but got Unknown
		//IL_68ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_68d4: Expected O, but got Unknown
		//IL_696e: Unknown result type (might be due to invalid IL or missing references)
		//IL_6978: Expected O, but got Unknown
		//IL_6a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a30: Expected O, but got Unknown
		//IL_6b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b17: Expected O, but got Unknown
		//IL_6bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_6bfe: Expected O, but got Unknown
		//IL_6cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ce0: Expected O, but got Unknown
		//IL_6d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d86: Expected O, but got Unknown
		//IL_6eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ec1: Expected O, but got Unknown
		//IL_701e: Unknown result type (might be due to invalid IL or missing references)
		//IL_7028: Expected O, but got Unknown
		//IL_70c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_70d2: Expected O, but got Unknown
		//IL_718f: Unknown result type (might be due to invalid IL or missing references)
		//IL_7199: Expected O, but got Unknown
		//IL_72ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_72f6: Expected O, but got Unknown
		//IL_7373: Unknown result type (might be due to invalid IL or missing references)
		//IL_737d: Expected O, but got Unknown
		//IL_7401: Unknown result type (might be due to invalid IL or missing references)
		//IL_740b: Expected O, but got Unknown
		//IL_74c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_74d0: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SALE));
		lblBook = new Label();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		Label2 = new Label();
		tVchNo = new TextBox();
		mDay = new TextBox();
		mTime = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		chkWapp = new CheckBox();
		nItProfit = new Label();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		chkHuIdPrint = new CheckBox();
		TEXT_ENTRY = new TextBox();
		lblItem = new Label();
		TEXT_IDTL = new TextBox();
		MSG_IDTL = new AxMSFlexGrid();
		PicImage = new PictureBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		Label4 = new Label();
		tVchDesc = new TextBox();
		tItDesc = new TextBox();
		Label5 = new Label();
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_OLD = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_OLD = new TextBox();
		tBankName = new TextBox();
		Label7 = new Label();
		Label8 = new Label();
		tBillNo = new TextBox();
		PanelAdd = new Panel();
		Label13 = new Label();
		tMobile = new TextBox();
		Label11 = new Label();
		tCity = new TextBox();
		Label10 = new Label();
		Label9 = new Label();
		tAdd3 = new TextBox();
		tAdd2 = new TextBox();
		tAdd1 = new TextBox();
		Label6 = new Label();
		LOpAmt = new Label();
		LClAmt = new Label();
		MSG_ORD = new AxMSFlexGrid();
		TEXT_ORD = new TextBox();
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		btnIsuNo = new SimpleButton();
		Label12 = new Label();
		tIsuNo = new TextBox();
		Label14 = new Label();
		nCrDays = new TextBox();
		tPanNo = new TextBox();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label15 = new Label();
		tNewPrint = new TextBox();
		WebBrowser1 = new WebBrowser();
		lblItStock = new Label();
		lblTrfrOpen = new Label();
		PnlTrfrVch = new Panel();
		btnTrfr = new SimpleButton();
		tTrfrYrCd = new TextBox();
		tTrfrDbCd = new TextBox();
		tTrfrNo = new TextBox();
		Label19 = new Label();
		PnlUpdate = new Panel();
		picAc = new PictureBox();
		btnUpdate = new SimpleButton();
		UAnvDate = new Label();
		UBrDate = new Label();
		UMobile = new Label();
		UGstNo = new Label();
		URefBy = new Label();
		UCity = new Label();
		UAdd3 = new Label();
		UAdd2 = new Label();
		UAdd1 = new Label();
		Label25 = new Label();
		Label24 = new Label();
		Label23 = new Label();
		Label22 = new Label();
		Label16 = new Label();
		Label17 = new Label();
		Label18 = new Label();
		Label20 = new Label();
		Label21 = new Label();
		PnlUpi = new Panel();
		TEXT_UPI = new TextBox();
		MSG_UPI = new AxMSFlexGrid();
		PnlPoint = new Panel();
		tRefAc = new TextBox();
		tRefName = new TextBox();
		Label31 = new Label();
		nPointVal = new TextBox();
		nPointSlVal = new TextBox();
		Label30 = new Label();
		nTotPoint = new TextBox();
		Label29 = new Label();
		nUseVal = new TextBox();
		Label28 = new Label();
		nUsePoint = new TextBox();
		nBillPoint = new TextBox();
		nPointBillVal = new TextBox();
		Label27 = new Label();
		nPointBal = new TextBox();
		Label26 = new Label();
		tPointCode = new TextBox();
		nBillProfit = new TextBox();
		chkPointMemb = new CheckBox();
		chkBillOrnaIsu = new CheckBox();
		btnQuot = new SimpleButton();
		chkRateUnFix = new CheckBox();
		pnlCrnt = new Panel();
		TEXT_CRNT = new TextBox();
		MSG_CRNT = new AxMSFlexGrid();
		pnlMobile = new Panel();
		tAcMobile = new Label();
		pnlMembAcCode = new Panel();
		tAcMembCode = new TextBox();
		tAcMembName = new TextBox();
		Label32 = new Label();
		chkWhoutcommBill = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_OLD).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_ORD).BeginInit();
		((Control)PnlTrfrVch).SuspendLayout();
		((Control)PnlUpdate).SuspendLayout();
		((ISupportInitialize)picAc).BeginInit();
		((Control)PnlUpi).SuspendLayout();
		((ISupportInitialize)MSG_UPI).BeginInit();
		((Control)PnlPoint).SuspendLayout();
		((Control)pnlCrnt).SuspendLayout();
		((ISupportInitialize)MSG_CRNT).BeginInit();
		((Control)pnlMobile).SuspendLayout();
		((Control)pnlMembAcCode).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(192, 0, 0);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 6;
		lblBook.Text = "Sales";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(312, 42);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(230, 43);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(96, 42);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(86, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(483, 42);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(394, 42);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(83, 23);
		((Control)mTime).TabIndex = 1132;
		mTime.TextAlign = (HorizontalAlignment)2;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(827, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(924, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 0;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1021, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 2;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1118, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 3;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1215, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 4;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)chkWapp);
		((Control)PnlBotam).Controls.Add((Control)(object)nItProfit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 15;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(728, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(93, 34);
		((Control)chkWapp).TabIndex = 6;
		((ButtonBase)chkWapp).Text = "Whatsapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
		((Control)nItProfit).BackColor = Color.Transparent;
		((Control)nItProfit).Font = new Font("Bahnschrift SemiCondensed", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItProfit).ForeColor = Color.White;
		nItProfit.ImeMode = (ImeMode)0;
		((Control)nItProfit).Location = new Point(244, 0);
		((Control)nItProfit).Name = "nItProfit";
		((Control)nItProfit).Size = new Size(478, 38);
		((Control)nItProfit).TabIndex = 1163;
		nItProfit.Text = "It Profit :";
		nItProfit.TextAlign = (ContentAlignment)16;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(197, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 5;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(150, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 6;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((ButtonBase)chkHuIdPrint).BackColor = Color.Transparent;
		((Control)chkHuIdPrint).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHuIdPrint).ForeColor = Color.Black;
		((Control)chkHuIdPrint).Location = new Point(1194, 520);
		((Control)chkHuIdPrint).Name = "chkHuIdPrint";
		((Control)chkHuIdPrint).RightToLeft = (RightToLeft)0;
		((Control)chkHuIdPrint).Size = new Size(79, 27);
		((Control)chkHuIdPrint).TabIndex = 5;
		((ButtonBase)chkHuIdPrint).Text = "HuId Prn";
		((ButtonBase)chkHuIdPrint).UseVisualStyleBackColor = false;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(907, 142);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 6;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(326, 234);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(392, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(152, 325);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 8;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 263);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(710, 110);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(12, 463);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(115, 74);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 213);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1159, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 102);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1162, 108);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1181, 264);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(35, 20);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1147;
		PicZoom.TabStop = false;
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(190, 42);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(30, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1194, 290);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(312, 71);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 71);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(326, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(231, 70);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Party Code";
		Label1.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tHdVchNo).BackColor = Color.FromArgb(255, 224, 192);
		((TextBoxBase)tHdVchNo).BorderStyle = (BorderStyle)0;
		((Control)tHdVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((TextBoxBase)tHdVchNo).ForeColor = Color.Maroon;
		((Control)tHdVchNo).Location = new Point(8, 8);
		((TextBoxBase)tHdVchNo).MaxLength = 8;
		((Control)tHdVchNo).Name = "tHdVchNo";
		((TextBoxBase)tHdVchNo).ReadOnly = true;
		((Control)tHdVchNo).Size = new Size(56, 15);
		((Control)tHdVchNo).TabIndex = 1159;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(225, 463);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 11;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(288, 463);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(140, 463);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(140, 517);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(225, 520);
		((TextBoxBase)tVchDesc).MaxLength = 250;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(279, 39);
		((Control)tVchDesc).TabIndex = 14;
		((TextBoxBase)tItDesc).BackColor = Color.White;
		((Control)tItDesc).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItDesc).Location = new Point(96, 234);
		((TextBoxBase)tItDesc).MaxLength = 50;
		((Control)tItDesc).Name = "tItDesc";
		((Control)tItDesc).Size = new Size(220, 22);
		((Control)tItDesc).TabIndex = 7;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(10, 233);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Print Name";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(732, 235);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 323);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_OLD).Location = new Point(12, 381);
		((Control)MSG_OLD).Name = "MSG_OLD";
		((AxHost)MSG_OLD).OcxState = (State)componentResourceManager.GetObject("MSG_OLD.OcxState");
		((Control)MSG_OLD).Size = new Size(710, 73);
		((Control)MSG_OLD).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(934, 382);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 9;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_OLD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_OLD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_OLD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_OLD).ForeColor = Color.White;
		((Control)TEXT_OLD).Location = new Point(109, 428);
		((Control)TEXT_OLD).Name = "TEXT_OLD";
		((Control)TEXT_OLD).Size = new Size(100, 18);
		((Control)TEXT_OLD).TabIndex = 10;
		((Control)TEXT_OLD).Visible = false;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(225, 491);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(172, 23);
		((Control)tBankName).TabIndex = 12;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(140, 490);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)16;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 71);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(96, 71);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(86, 23);
		((Control)tBillNo).TabIndex = 2;
		((Control)PanelAdd).BackColor = Color.FromArgb(255, 224, 192);
		PanelAdd.BorderStyle = (BorderStyle)2;
		((Control)PanelAdd).Controls.Add((Control)(object)Label13);
		((Control)PanelAdd).Controls.Add((Control)(object)tMobile);
		((Control)PanelAdd).Controls.Add((Control)(object)Label11);
		((Control)PanelAdd).Controls.Add((Control)(object)tCity);
		((Control)PanelAdd).Controls.Add((Control)(object)Label10);
		((Control)PanelAdd).Controls.Add((Control)(object)Label9);
		((Control)PanelAdd).Controls.Add((Control)(object)tAdd3);
		((Control)PanelAdd).Controls.Add((Control)(object)tAdd2);
		((Control)PanelAdd).Controls.Add((Control)(object)tAdd1);
		((Control)PanelAdd).Controls.Add((Control)(object)Label6);
		((Control)PanelAdd).Location = new Point(312, 104);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 152);
		((Control)PanelAdd).TabIndex = 5;
		((Control)PanelAdd).Visible = false;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Maroon;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(3, 119);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(73, 20);
		((Control)Label13).TabIndex = 1169;
		Label13.Text = "Mobile No  :";
		Label13.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobile).BackColor = Color.White;
		((Control)tMobile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tMobile).ForeColor = Color.Maroon;
		((Control)tMobile).Location = new Point(82, 118);
		((TextBoxBase)tMobile).MaxLength = 12;
		((Control)tMobile).Name = "tMobile";
		((Control)tMobile).Size = new Size(205, 23);
		((Control)tMobile).TabIndex = 4;
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Maroon;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(17, 90);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(59, 20);
		((Control)Label11).TabIndex = 1166;
		Label11.Text = "City  :";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tCity).BackColor = Color.White;
		((Control)tCity).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tCity).ForeColor = Color.Maroon;
		((Control)tCity).Location = new Point(82, 90);
		((TextBoxBase)tCity).MaxLength = 20;
		((Control)tCity).Name = "tCity";
		((Control)tCity).Size = new Size(301, 23);
		((Control)tCity).TabIndex = 3;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Maroon;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(17, 62);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(59, 20);
		((Control)Label10).TabIndex = 1163;
		Label10.Text = "Add 3  :";
		Label10.TextAlign = (ContentAlignment)64;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Maroon;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(17, 34);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(59, 20);
		((Control)Label9).TabIndex = 1162;
		Label9.Text = "Add 2  :";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAdd3).BackColor = Color.White;
		((Control)tAdd3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tAdd3).ForeColor = Color.Maroon;
		((Control)tAdd3).Location = new Point(82, 62);
		((TextBoxBase)tAdd3).MaxLength = 50;
		((Control)tAdd3).Name = "tAdd3";
		((Control)tAdd3).Size = new Size(301, 23);
		((Control)tAdd3).TabIndex = 2;
		((TextBoxBase)tAdd2).BackColor = Color.White;
		((Control)tAdd2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tAdd2).ForeColor = Color.Maroon;
		((Control)tAdd2).Location = new Point(82, 34);
		((TextBoxBase)tAdd2).MaxLength = 50;
		((Control)tAdd2).Name = "tAdd2";
		((Control)tAdd2).Size = new Size(301, 23);
		((Control)tAdd2).TabIndex = 1;
		((TextBoxBase)tAdd1).BackColor = Color.White;
		((Control)tAdd1).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tAdd1).ForeColor = Color.Maroon;
		((Control)tAdd1).Location = new Point(82, 6);
		((TextBoxBase)tAdd1).MaxLength = 50;
		((Control)tAdd1).Name = "tAdd1";
		((Control)tAdd1).Size = new Size(301, 23);
		((Control)tAdd1).TabIndex = 0;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Maroon;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(17, 6);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(59, 20);
		((Control)Label6).TabIndex = 1158;
		Label6.Text = "Add 1  :";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1021, 74);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1206;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(595, 537);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(127, 20);
		((Control)LClAmt).TabIndex = 1209;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)MSG_ORD).Location = new Point(511, 462);
		((Control)MSG_ORD).Name = "MSG_ORD";
		((AxHost)MSG_ORD).OcxState = (State)componentResourceManager.GetObject("MSG_ORD.OcxState");
		((Control)MSG_ORD).Size = new Size(211, 72);
		((Control)MSG_ORD).TabIndex = 1210;
		((TextBoxBase)TEXT_ORD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ORD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ORD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ORD).ForeColor = Color.White;
		((Control)TEXT_ORD).Location = new Point(596, 486);
		((Control)TEXT_ORD).Name = "TEXT_ORD";
		((Control)TEXT_ORD).Size = new Size(75, 18);
		((Control)TEXT_ORD).TabIndex = 1211;
		((Control)TEXT_ORD).Visible = false;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuYrCd).Location = new Point(724, 44);
		((TextBoxBase)tIsuYrCd).MaxLength = 8;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(76, 22);
		((Control)tIsuYrCd).TabIndex = 1216;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuDbCd).Location = new Point(804, 44);
		((TextBoxBase)tIsuDbCd).MaxLength = 8;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(76, 22);
		((Control)tIsuDbCd).TabIndex = 1215;
		((BaseStyleControl)btnIsuNo).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnIsuNo).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnIsuNo).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnIsuNo).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnIsuNo).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseForeColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnIsuNo).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnIsuNo).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIsuNo).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnIsuNo).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnIsuNo).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnIsuNo).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseFont = true;
		((Control)btnIsuNo).Location = new Point(886, 43);
		((BaseControl)btnIsuNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIsuNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIsuNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIsuNo).Name = "btnIsuNo";
		((Control)btnIsuNo).Size = new Size(35, 23);
		((Control)btnIsuNo).TabIndex = 1214;
		btnIsuNo.Text = "A";
		((BaseControl)btnIsuNo).ToolTip = "Approval Help";
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(572, 43);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(64, 20);
		((Control)Label12).TabIndex = 1213;
		Label12.Text = "Apr No";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuNo).Location = new Point(644, 44);
		((TextBoxBase)tIsuNo).MaxLength = 8;
		((Control)tIsuNo).Name = "tIsuNo";
		((TextBoxBase)tIsuNo).ReadOnly = true;
		((Control)tIsuNo).Size = new Size(76, 22);
		((Control)tIsuNo).TabIndex = 1212;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(401, 492);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(53, 20);
		((Control)Label14).TabIndex = 1217;
		Label14.Text = "CrDay";
		Label14.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(459, 491);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(45, 23);
		((Control)nCrDays).TabIndex = 13;
		nCrDays.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tPanNo).BackColor = Color.White;
		((Control)tPanNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tPanNo).ForeColor = Color.Maroon;
		((Control)tPanNo).Location = new Point(836, 520);
		((TextBoxBase)tPanNo).MaxLength = 12;
		((Control)tPanNo).Name = "tPanNo";
		((Control)tPanNo).Size = new Size(171, 23);
		((Control)tPanNo).TabIndex = 1218;
		((Control)tPanNo).Visible = false;
		((BaseStyleControl)btnTagSet).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTagSet).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTagSet).Appearance.Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagSet).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTagSet).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTagSet).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTagSet).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)btnTagSet).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTagSet).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTagSet).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTagSet).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTagSet).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTagSet).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTagSet).AppearancePressed.Options.UseFont = true;
		((Control)btnTagSet).Location = new Point(1125, 41);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(44, 24);
		((Control)btnTagSet).TabIndex = 1220;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		cboPrintfile.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(1006, 41);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(113, 24);
		((Control)cboPrintfile).TabIndex = 1219;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(949, 44);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(51, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Print";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tNewPrint).BackColor = Color.White;
		((Control)tNewPrint).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tNewPrint).Location = new Point(1175, 42);
		((TextBoxBase)tNewPrint).MaxLength = 50;
		((Control)tNewPrint).Name = "tNewPrint";
		((Control)tNewPrint).Size = new Size(125, 23);
		((Control)tNewPrint).TabIndex = 1222;
		((Control)tNewPrint).Visible = false;
		((Control)WebBrowser1).Location = new Point(1215, 348);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(101, 63);
		((Control)WebBrowser1).TabIndex = 1223;
		((Control)lblItStock).BackColor = Color.Transparent;
		((Control)lblItStock).Font = new Font("Tahoma", 9f);
		((Control)lblItStock).ForeColor = Color.Blue;
		lblItStock.ImeMode = (ImeMode)0;
		((Control)lblItStock).Location = new Point(12, 540);
		((Control)lblItStock).Name = "lblItStock";
		((Control)lblItStock).Size = new Size(205, 20);
		((Control)lblItStock).TabIndex = 1224;
		lblItStock.Text = "Itm Stock :";
		lblItStock.TextAlign = (ContentAlignment)16;
		((Control)lblTrfrOpen).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblTrfrOpen).Location = new Point(1133, 5);
		((Control)lblTrfrOpen).Name = "lblTrfrOpen";
		((Control)lblTrfrOpen).Size = new Size(25, 23);
		((Control)lblTrfrOpen).TabIndex = 1225;
		lblTrfrOpen.Text = ".";
		lblTrfrOpen.TextAlign = (ContentAlignment)2;
		((Control)lblTrfrOpen).Visible = false;
		((Control)PnlTrfrVch).BackColor = Color.FromArgb(255, 224, 192);
		PnlTrfrVch.BorderStyle = (BorderStyle)2;
		((Control)PnlTrfrVch).Controls.Add((Control)(object)btnTrfr);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)tTrfrYrCd);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)tTrfrDbCd);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)tTrfrNo);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)Label19);
		((Control)PnlTrfrVch).Location = new Point(725, 37);
		((Control)PnlTrfrVch).Name = "PnlTrfrVch";
		((Control)PnlTrfrVch).Size = new Size(447, 52);
		((Control)PnlTrfrVch).TabIndex = 1226;
		((Control)PnlTrfrVch).Visible = false;
		((BaseStyleControl)btnTrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTrfr).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnTrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTrfr).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnTrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTrfr).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnTrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTrfr).AppearancePressed.Options.UseFont = true;
		((Control)btnTrfr).Location = new Point(324, 8);
		((BaseControl)btnTrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTrfr).Name = "btnTrfr";
		((Control)btnTrfr).Size = new Size(97, 32);
		((Control)btnTrfr).TabIndex = 3;
		btnTrfr.Text = "Transfer";
		((BaseControl)btnTrfr).ToolTip = "Party Help";
		((TextBoxBase)tTrfrYrCd).BackColor = Color.White;
		((Control)tTrfrYrCd).Font = new Font("Tahoma", 9.75f);
		((TextBoxBase)tTrfrYrCd).ForeColor = Color.Maroon;
		((Control)tTrfrYrCd).Location = new Point(222, 14);
		((TextBoxBase)tTrfrYrCd).MaxLength = 10;
		((Control)tTrfrYrCd).Name = "tTrfrYrCd";
		((TextBoxBase)tTrfrYrCd).ReadOnly = true;
		((Control)tTrfrYrCd).Size = new Size(88, 23);
		((Control)tTrfrYrCd).TabIndex = 2;
		((TextBoxBase)tTrfrDbCd).BackColor = Color.White;
		((Control)tTrfrDbCd).Font = new Font("Tahoma", 9.75f);
		((TextBoxBase)tTrfrDbCd).ForeColor = Color.Maroon;
		((Control)tTrfrDbCd).Location = new Point(145, 14);
		((TextBoxBase)tTrfrDbCd).MaxLength = 3;
		((Control)tTrfrDbCd).Name = "tTrfrDbCd";
		((TextBoxBase)tTrfrDbCd).ReadOnly = true;
		((Control)tTrfrDbCd).Size = new Size(70, 23);
		((Control)tTrfrDbCd).TabIndex = 1;
		((TextBoxBase)tTrfrNo).BackColor = Color.White;
		((Control)tTrfrNo).Font = new Font("Tahoma", 9.75f);
		((TextBoxBase)tTrfrNo).ForeColor = Color.Maroon;
		((Control)tTrfrNo).Location = new Point(69, 14);
		((TextBoxBase)tTrfrNo).MaxLength = 10;
		((Control)tTrfrNo).Name = "tTrfrNo";
		((Control)tTrfrNo).Size = new Size(71, 23);
		((Control)tTrfrNo).TabIndex = 0;
		((Control)Label19).BackColor = Color.Transparent;
		((Control)Label19).Font = new Font("Arial", 9f, (FontStyle)1);
		((Control)Label19).ForeColor = Color.Maroon;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(15, 14);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(50, 20);
		((Control)Label19).TabIndex = 1158;
		Label19.Text = "VchNo";
		Label19.TextAlign = (ContentAlignment)64;
		((Control)PnlUpdate).BackColor = Color.FromArgb(255, 224, 192);
		PnlUpdate.BorderStyle = (BorderStyle)2;
		((Control)PnlUpdate).Controls.Add((Control)(object)picAc);
		((Control)PnlUpdate).Controls.Add((Control)(object)btnUpdate);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAnvDate);
		((Control)PnlUpdate).Controls.Add((Control)(object)UBrDate);
		((Control)PnlUpdate).Controls.Add((Control)(object)UMobile);
		((Control)PnlUpdate).Controls.Add((Control)(object)UGstNo);
		((Control)PnlUpdate).Controls.Add((Control)(object)URefBy);
		((Control)PnlUpdate).Controls.Add((Control)(object)UCity);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAdd3);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAdd2);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAdd1);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label25);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label24);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label23);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label22);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label16);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label17);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label18);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label20);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label21);
		((Control)PnlUpdate).Location = new Point(312, 102);
		((Control)PnlUpdate).Name = "PnlUpdate";
		((Control)PnlUpdate).Size = new Size(584, 244);
		((Control)PnlUpdate).TabIndex = 1227;
		((Control)PnlUpdate).Visible = false;
		((Control)picAc).BackColor = Color.SeaShell;
		picAc.BorderStyle = (BorderStyle)1;
		picAc.ImeMode = (ImeMode)0;
		((Control)picAc).Location = new Point(405, 67);
		((Control)picAc).Name = "picAc";
		((Control)picAc).Size = new Size(169, 166);
		picAc.SizeMode = (PictureBoxSizeMode)4;
		picAc.TabIndex = 1235;
		picAc.TabStop = false;
		((BaseStyleControl)btnUpdate).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnUpdate).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnUpdate).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnUpdate.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)btnUpdate).Location = new Point(291, 193);
		((BaseControl)btnUpdate).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnUpdate).Name = "btnUpdate";
		((Control)btnUpdate).Size = new Size(91, 37);
		((Control)btnUpdate).TabIndex = 1183;
		btnUpdate.Text = "&Update";
		((BaseButton)btnUpdate).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)UAnvDate).BackColor = Color.Transparent;
		((Control)UAnvDate).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAnvDate).ForeColor = Color.Maroon;
		UAnvDate.ImeMode = (ImeMode)0;
		((Control)UAnvDate).Location = new Point(85, 210);
		((Control)UAnvDate).Name = "UAnvDate";
		((Control)UAnvDate).Size = new Size(156, 20);
		((Control)UAnvDate).TabIndex = 1182;
		UAnvDate.Text = ".";
		UAnvDate.TextAlign = (ContentAlignment)16;
		((Control)UBrDate).BackColor = Color.Transparent;
		((Control)UBrDate).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UBrDate).ForeColor = Color.Maroon;
		UBrDate.ImeMode = (ImeMode)0;
		((Control)UBrDate).Location = new Point(85, 185);
		((Control)UBrDate).Name = "UBrDate";
		((Control)UBrDate).Size = new Size(156, 20);
		((Control)UBrDate).TabIndex = 1181;
		UBrDate.Text = ".";
		UBrDate.TextAlign = (ContentAlignment)16;
		((Control)UMobile).BackColor = Color.Transparent;
		((Control)UMobile).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UMobile).ForeColor = Color.Maroon;
		UMobile.ImeMode = (ImeMode)0;
		((Control)UMobile).Location = new Point(85, 160);
		((Control)UMobile).Name = "UMobile";
		((Control)UMobile).Size = new Size(311, 20);
		((Control)UMobile).TabIndex = 1180;
		UMobile.Text = ".";
		UMobile.TextAlign = (ContentAlignment)16;
		((Control)UGstNo).BackColor = Color.Transparent;
		((Control)UGstNo).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UGstNo).ForeColor = Color.Maroon;
		UGstNo.ImeMode = (ImeMode)0;
		((Control)UGstNo).Location = new Point(85, 135);
		((Control)UGstNo).Name = "UGstNo";
		((Control)UGstNo).Size = new Size(311, 20);
		((Control)UGstNo).TabIndex = 1179;
		UGstNo.Text = ".";
		UGstNo.TextAlign = (ContentAlignment)16;
		((Control)URefBy).BackColor = Color.Transparent;
		((Control)URefBy).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)URefBy).ForeColor = Color.Maroon;
		URefBy.ImeMode = (ImeMode)0;
		((Control)URefBy).Location = new Point(85, 110);
		((Control)URefBy).Name = "URefBy";
		((Control)URefBy).Size = new Size(311, 20);
		((Control)URefBy).TabIndex = 1178;
		URefBy.Text = ".";
		URefBy.TextAlign = (ContentAlignment)16;
		((Control)UCity).BackColor = Color.Transparent;
		((Control)UCity).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UCity).ForeColor = Color.Maroon;
		UCity.ImeMode = (ImeMode)0;
		((Control)UCity).Location = new Point(85, 85);
		((Control)UCity).Name = "UCity";
		((Control)UCity).Size = new Size(311, 20);
		((Control)UCity).TabIndex = 1177;
		UCity.Text = ".";
		UCity.TextAlign = (ContentAlignment)16;
		((Control)UAdd3).BackColor = Color.Transparent;
		((Control)UAdd3).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAdd3).ForeColor = Color.Maroon;
		UAdd3.ImeMode = (ImeMode)0;
		((Control)UAdd3).Location = new Point(85, 60);
		((Control)UAdd3).Name = "UAdd3";
		((Control)UAdd3).Size = new Size(311, 20);
		((Control)UAdd3).TabIndex = 1176;
		UAdd3.Text = ".";
		UAdd3.TextAlign = (ContentAlignment)16;
		((Control)UAdd2).BackColor = Color.Transparent;
		((Control)UAdd2).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAdd2).ForeColor = Color.Maroon;
		UAdd2.ImeMode = (ImeMode)0;
		((Control)UAdd2).Location = new Point(85, 35);
		((Control)UAdd2).Name = "UAdd2";
		((Control)UAdd2).Size = new Size(489, 20);
		((Control)UAdd2).TabIndex = 1175;
		UAdd2.Text = ".";
		UAdd2.TextAlign = (ContentAlignment)16;
		((Control)UAdd1).BackColor = Color.Transparent;
		((Control)UAdd1).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAdd1).ForeColor = Color.Maroon;
		UAdd1.ImeMode = (ImeMode)0;
		((Control)UAdd1).Location = new Point(85, 10);
		((Control)UAdd1).Name = "UAdd1";
		((Control)UAdd1).Size = new Size(489, 20);
		((Control)UAdd1).TabIndex = 1174;
		UAdd1.Text = ".";
		UAdd1.TextAlign = (ContentAlignment)16;
		((Control)Label25).BackColor = Color.Transparent;
		((Control)Label25).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label25).ForeColor = Color.Maroon;
		Label25.ImeMode = (ImeMode)0;
		((Control)Label25).Location = new Point(7, 210);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(73, 20);
		((Control)Label25).TabIndex = 1173;
		Label25.Text = "Anv Dt  :";
		Label25.TextAlign = (ContentAlignment)64;
		((Control)Label24).BackColor = Color.Transparent;
		((Control)Label24).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label24).ForeColor = Color.Maroon;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(7, 185);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(73, 20);
		((Control)Label24).TabIndex = 1172;
		Label24.Text = "Brth Dt  :";
		Label24.TextAlign = (ContentAlignment)64;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Maroon;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(14, 135);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(66, 20);
		((Control)Label23).TabIndex = 1171;
		Label23.Text = "Gst No  :";
		Label23.TextAlign = (ContentAlignment)64;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Maroon;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(12, 110);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(68, 20);
		((Control)Label22).TabIndex = 1170;
		Label22.Text = "Ref By  :";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Maroon;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(7, 160);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(73, 20);
		((Control)Label16).TabIndex = 1169;
		Label16.Text = "Mobile  :";
		Label16.TextAlign = (ContentAlignment)64;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Maroon;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(21, 85);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(59, 20);
		((Control)Label17).TabIndex = 1166;
		Label17.Text = "City  :";
		Label17.TextAlign = (ContentAlignment)64;
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Maroon;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(21, 60);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(59, 20);
		((Control)Label18).TabIndex = 1163;
		Label18.Text = "Add 3  :";
		Label18.TextAlign = (ContentAlignment)64;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Maroon;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(21, 35);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(59, 20);
		((Control)Label20).TabIndex = 1162;
		Label20.Text = "Add 2  :";
		Label20.TextAlign = (ContentAlignment)64;
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.Maroon;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(21, 10);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(59, 20);
		((Control)Label21).TabIndex = 1158;
		Label21.Text = "Add 1  :";
		Label21.TextAlign = (ContentAlignment)64;
		((Control)PnlUpi).Controls.Add((Control)(object)TEXT_UPI);
		((Control)PnlUpi).Controls.Add((Control)(object)MSG_UPI);
		((Control)PnlUpi).Location = new Point(1181, 189);
		((Control)PnlUpi).Name = "PnlUpi";
		((Control)PnlUpi).Size = new Size(713, 331);
		((Control)PnlUpi).TabIndex = 1233;
		((Control)PnlUpi).Visible = false;
		((TextBoxBase)TEXT_UPI).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_UPI).BorderStyle = (BorderStyle)0;
		((Control)TEXT_UPI).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_UPI).ForeColor = Color.White;
		((Control)TEXT_UPI).Location = new Point(204, 147);
		((Control)TEXT_UPI).Name = "TEXT_UPI";
		((Control)TEXT_UPI).Size = new Size(100, 18);
		((Control)TEXT_UPI).TabIndex = 10;
		((Control)TEXT_UPI).Visible = false;
		((Control)MSG_UPI).Location = new Point(9, 10);
		((Control)MSG_UPI).Name = "MSG_UPI";
		((AxHost)MSG_UPI).OcxState = (State)componentResourceManager.GetObject("MSG_UPI.OcxState");
		((Control)MSG_UPI).Size = new Size(694, 311);
		((Control)MSG_UPI).TabIndex = 0;
		((Control)PnlPoint).BackColor = Color.FromArgb(255, 224, 192);
		PnlPoint.BorderStyle = (BorderStyle)2;
		((Control)PnlPoint).Controls.Add((Control)(object)tRefAc);
		((Control)PnlPoint).Controls.Add((Control)(object)tRefName);
		((Control)PnlPoint).Controls.Add((Control)(object)Label31);
		((Control)PnlPoint).Controls.Add((Control)(object)nPointVal);
		((Control)PnlPoint).Controls.Add((Control)(object)nPointSlVal);
		((Control)PnlPoint).Controls.Add((Control)(object)Label30);
		((Control)PnlPoint).Controls.Add((Control)(object)nTotPoint);
		((Control)PnlPoint).Controls.Add((Control)(object)Label29);
		((Control)PnlPoint).Controls.Add((Control)(object)nUseVal);
		((Control)PnlPoint).Controls.Add((Control)(object)Label28);
		((Control)PnlPoint).Controls.Add((Control)(object)nUsePoint);
		((Control)PnlPoint).Controls.Add((Control)(object)nBillPoint);
		((Control)PnlPoint).Controls.Add((Control)(object)nPointBillVal);
		((Control)PnlPoint).Controls.Add((Control)(object)Label27);
		((Control)PnlPoint).Controls.Add((Control)(object)nPointBal);
		((Control)PnlPoint).Controls.Add((Control)(object)Label26);
		((Control)PnlPoint).Controls.Add((Control)(object)tPointCode);
		((Control)PnlPoint).Location = new Point(12, 381);
		((Control)PnlPoint).Name = "PnlPoint";
		((Control)PnlPoint).Size = new Size(458, 178);
		((Control)PnlPoint).TabIndex = 1229;
		((Control)PnlPoint).Visible = false;
		((TextBoxBase)tRefAc).BackColor = Color.White;
		((Control)tRefAc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefAc).Location = new Point(103, 146);
		((TextBoxBase)tRefAc).MaxLength = 10;
		((Control)tRefAc).Name = "tRefAc";
		((Control)tRefAc).Size = new Size(67, 23);
		((Control)tRefAc).TabIndex = 1185;
		((TextBoxBase)tRefName).BackColor = Color.White;
		((Control)tRefName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRefName).Location = new Point(178, 146);
		((TextBoxBase)tRefName).MaxLength = 50;
		((Control)tRefName).Name = "tRefName";
		((Control)tRefName).Size = new Size(269, 23);
		((Control)tRefName).TabIndex = 1186;
		((Control)Label31).BackColor = Color.Transparent;
		((Control)Label31).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label31).ForeColor = Color.Black;
		Label31.ImeMode = (ImeMode)0;
		((Control)Label31).Location = new Point(28, 148);
		((Control)Label31).Name = "Label31";
		((Control)Label31).Size = new Size(67, 20);
		((Control)Label31).TabIndex = 1187;
		Label31.Text = "Ref Ac";
		Label31.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPointVal).BackColor = Color.White;
		((Control)nPointVal).Font = new Font("Tahoma", 9f);
		((Control)nPointVal).Location = new Point(380, 6);
		((TextBoxBase)nPointVal).MaxLength = 9;
		((Control)nPointVal).Name = "nPointVal";
		((TextBoxBase)nPointVal).ReadOnly = true;
		((Control)nPointVal).Size = new Size(67, 22);
		((Control)nPointVal).TabIndex = 1184;
		nPointVal.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nPointSlVal).BackColor = Color.White;
		((Control)nPointSlVal).Font = new Font("Tahoma", 9f);
		((Control)nPointSlVal).Location = new Point(284, 6);
		((TextBoxBase)nPointSlVal).MaxLength = 9;
		((Control)nPointSlVal).Name = "nPointSlVal";
		((TextBoxBase)nPointSlVal).ReadOnly = true;
		((Control)nPointSlVal).Size = new Size(90, 22);
		((Control)nPointSlVal).TabIndex = 1182;
		nPointSlVal.TextAlign = (HorizontalAlignment)1;
		((Control)Label30).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label30).ForeColor = Color.Black;
		Label30.ImeMode = (ImeMode)0;
		((Control)Label30).Location = new Point(5, 7);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(224, 20);
		((Control)Label30).TabIndex = 1183;
		Label30.Text = "Point Code /Point Value / Point Count";
		Label30.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nTotPoint).BackColor = Color.Lavender;
		((Control)nTotPoint).Font = new Font("Tahoma", 9f);
		((Control)nTotPoint).Location = new Point(380, 90);
		((TextBoxBase)nTotPoint).MaxLength = 9;
		((Control)nTotPoint).Name = "nTotPoint";
		((Control)nTotPoint).Size = new Size(67, 22);
		((Control)nTotPoint).TabIndex = 1180;
		nTotPoint.TextAlign = (HorizontalAlignment)1;
		((Control)Label29).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label29).ForeColor = Color.Black;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(275, 90);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(98, 20);
		((Control)Label29).TabIndex = 1181;
		Label29.Text = "Total Point";
		Label29.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nUseVal).BackColor = Color.White;
		((Control)nUseVal).Font = new Font("Tahoma", 9f);
		((Control)nUseVal).Location = new Point(284, 118);
		((TextBoxBase)nUseVal).MaxLength = 9;
		((Control)nUseVal).Name = "nUseVal";
		((Control)nUseVal).Size = new Size(90, 22);
		((Control)nUseVal).TabIndex = 1179;
		nUseVal.TextAlign = (HorizontalAlignment)1;
		((Control)Label28).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label28).ForeColor = Color.Black;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(110, 119);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(167, 20);
		((Control)Label28).TabIndex = 1178;
		Label28.Text = "Use Value / Use Point";
		Label28.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nUsePoint).BackColor = Color.White;
		((Control)nUsePoint).Font = new Font("Tahoma", 9f);
		((Control)nUsePoint).Location = new Point(380, 118);
		((TextBoxBase)nUsePoint).MaxLength = 9;
		((Control)nUsePoint).Name = "nUsePoint";
		((Control)nUsePoint).Size = new Size(67, 22);
		((Control)nUsePoint).TabIndex = 1177;
		nUsePoint.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nBillPoint).BackColor = Color.White;
		((Control)nBillPoint).Font = new Font("Tahoma", 9f);
		((Control)nBillPoint).Location = new Point(380, 62);
		((TextBoxBase)nBillPoint).MaxLength = 9;
		((Control)nBillPoint).Name = "nBillPoint";
		((TextBoxBase)nBillPoint).ReadOnly = true;
		((Control)nBillPoint).Size = new Size(67, 22);
		((Control)nBillPoint).TabIndex = 1176;
		nBillPoint.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nPointBillVal).BackColor = Color.White;
		((Control)nPointBillVal).Font = new Font("Tahoma", 9f);
		((Control)nPointBillVal).Location = new Point(283, 62);
		((TextBoxBase)nPointBillVal).MaxLength = 9;
		((Control)nPointBillVal).Name = "nPointBillVal";
		((TextBoxBase)nPointBillVal).ReadOnly = true;
		((Control)nPointBillVal).Size = new Size(90, 22);
		((Control)nPointBillVal).TabIndex = 1174;
		nPointBillVal.TextAlign = (HorizontalAlignment)1;
		((Control)Label27).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label27).ForeColor = Color.Black;
		Label27.ImeMode = (ImeMode)0;
		((Control)Label27).Location = new Point(135, 62);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(142, 20);
		((Control)Label27).TabIndex = 1175;
		Label27.Text = "Bill Total / Bill Point";
		Label27.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPointBal).BackColor = Color.Lavender;
		((Control)nPointBal).Font = new Font("Tahoma", 9f);
		((Control)nPointBal).Location = new Point(380, 34);
		((TextBoxBase)nPointBal).MaxLength = 9;
		((Control)nPointBal).Name = "nPointBal";
		((TextBoxBase)nPointBal).ReadOnly = true;
		((Control)nPointBal).Size = new Size(67, 22);
		((Control)nPointBal).TabIndex = 1172;
		nPointBal.TextAlign = (HorizontalAlignment)1;
		((Control)Label26).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label26).ForeColor = Color.Black;
		Label26.ImeMode = (ImeMode)0;
		((Control)Label26).Location = new Point(276, 36);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(98, 20);
		((Control)Label26).TabIndex = 1173;
		Label26.Text = "Old Bal Point";
		Label26.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPointCode).BackColor = Color.White;
		((Control)tPointCode).Font = new Font("Tahoma", 9f);
		((Control)tPointCode).Location = new Point(235, 6);
		((TextBoxBase)tPointCode).MaxLength = 6;
		((Control)tPointCode).Name = "tPointCode";
		((TextBoxBase)tPointCode).ReadOnly = true;
		((Control)tPointCode).Size = new Size(42, 22);
		((Control)tPointCode).TabIndex = 1170;
		tPointCode.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)nBillProfit).BackColor = Color.White;
		((Control)nBillProfit).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nBillProfit).Location = new Point(511, 536);
		((TextBoxBase)nBillProfit).MaxLength = 10;
		((Control)nBillProfit).Name = "nBillProfit";
		((Control)nBillProfit).Size = new Size(78, 23);
		((Control)nBillProfit).TabIndex = 1228;
		nBillProfit.TextAlign = (HorizontalAlignment)1;
		((Control)nBillProfit).Visible = false;
		((ButtonBase)chkPointMemb).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkPointMemb).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkPointMemb).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkPointMemb).Location = new Point(855, 5);
		((Control)chkPointMemb).Name = "chkPointMemb";
		((Control)chkPointMemb).RightToLeft = (RightToLeft)0;
		((Control)chkPointMemb).Size = new Size(116, 19);
		((Control)chkPointMemb).TabIndex = 1230;
		((ButtonBase)chkPointMemb).Text = "Point Member";
		((ButtonBase)chkPointMemb).UseVisualStyleBackColor = false;
		((Control)chkPointMemb).Visible = false;
		((ButtonBase)chkBillOrnaIsu).BackColor = Color.Transparent;
		chkBillOrnaIsu.Checked = true;
		chkBillOrnaIsu.CheckState = (CheckState)1;
		((Control)chkBillOrnaIsu).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBillOrnaIsu).ForeColor = Color.Maroon;
		((Control)chkBillOrnaIsu).Location = new Point(732, 71);
		((Control)chkBillOrnaIsu).Name = "chkBillOrnaIsu";
		((Control)chkBillOrnaIsu).RightToLeft = (RightToLeft)0;
		((Control)chkBillOrnaIsu).Size = new Size(125, 24);
		((Control)chkBillOrnaIsu).TabIndex = 1231;
		((ButtonBase)chkBillOrnaIsu).Text = "Bill Orna Isu";
		((ButtonBase)chkBillOrnaIsu).UseVisualStyleBackColor = false;
		((Control)chkBillOrnaIsu).Visible = false;
		((BaseStyleControl)btnQuot).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnQuot).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnQuot).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnQuot).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnQuot).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnQuot).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnQuot).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnQuot).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnQuot).Appearance.Options.UseForeColor = true;
		((BaseButton)btnQuot).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnQuot).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnQuot).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnQuot).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnQuot).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnQuot).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnQuot).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnQuot).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnQuot).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnQuot).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnQuot).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnQuot).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnQuot).AppearancePressed.Options.UseFont = true;
		((Control)btnQuot).Location = new Point(190, 71);
		((BaseControl)btnQuot).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnQuot).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnQuot).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnQuot).Name = "btnQuot";
		((Control)btnQuot).Size = new Size(30, 23);
		((Control)btnQuot).TabIndex = 1232;
		btnQuot.Text = "Q";
		((BaseControl)btnQuot).ToolTip = "Sales Quotation";
		((Control)btnQuot).Visible = false;
		((ButtonBase)chkRateUnFix).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkRateUnFix).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkRateUnFix).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkRateUnFix).Location = new Point(96, 7);
		((Control)chkRateUnFix).Name = "chkRateUnFix";
		((Control)chkRateUnFix).RightToLeft = (RightToLeft)0;
		((Control)chkRateUnFix).Size = new Size(116, 19);
		((Control)chkRateUnFix).TabIndex = 1234;
		((ButtonBase)chkRateUnFix).Text = "Rate UnFix";
		((ButtonBase)chkRateUnFix).UseVisualStyleBackColor = false;
		((Control)chkRateUnFix).Visible = false;
		((Control)pnlCrnt).Controls.Add((Control)(object)TEXT_CRNT);
		((Control)pnlCrnt).Controls.Add((Control)(object)MSG_CRNT);
		((Control)pnlCrnt).Location = new Point(487, 455);
		((Control)pnlCrnt).Name = "pnlCrnt";
		((Control)pnlCrnt).Size = new Size(255, 102);
		((Control)pnlCrnt).TabIndex = 1235;
		((Control)pnlCrnt).Visible = false;
		((TextBoxBase)TEXT_CRNT).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_CRNT).BorderStyle = (BorderStyle)0;
		((Control)TEXT_CRNT).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_CRNT).ForeColor = Color.White;
		((Control)TEXT_CRNT).Location = new Point(128, 58);
		((Control)TEXT_CRNT).Name = "TEXT_CRNT";
		((Control)TEXT_CRNT).Size = new Size(82, 18);
		((Control)TEXT_CRNT).TabIndex = 10;
		((Control)TEXT_CRNT).Visible = false;
		((Control)MSG_CRNT).Location = new Point(6, 5);
		((Control)MSG_CRNT).Name = "MSG_CRNT";
		((AxHost)MSG_CRNT).OcxState = (State)componentResourceManager.GetObject("MSG_CRNT.OcxState");
		((Control)MSG_CRNT).Size = new Size(245, 91);
		((Control)MSG_CRNT).TabIndex = 0;
		((Control)pnlMobile).Controls.Add((Control)(object)tAcMobile);
		((Control)pnlMobile).Location = new Point(573, 37);
		((Control)pnlMobile).Name = "pnlMobile";
		((Control)pnlMobile).Size = new Size(385, 30);
		((Control)pnlMobile).TabIndex = 1236;
		((Control)pnlMobile).Visible = false;
		((Control)tAcMobile).BackColor = Color.Transparent;
		((Control)tAcMobile).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f);
		((Control)tAcMobile).ForeColor = Color.Maroon;
		tAcMobile.ImeMode = (ImeMode)0;
		((Control)tAcMobile).Location = new Point(3, 4);
		((Control)tAcMobile).Name = "tAcMobile";
		((Control)tAcMobile).Size = new Size(379, 20);
		((Control)tAcMobile).TabIndex = 1181;
		tAcMobile.Text = ".";
		tAcMobile.TextAlign = (ContentAlignment)16;
		((Control)pnlMembAcCode).Controls.Add((Control)(object)tAcMembCode);
		((Control)pnlMembAcCode).Controls.Add((Control)(object)tAcMembName);
		((Control)pnlMembAcCode).Controls.Add((Control)(object)Label32);
		((Control)pnlMembAcCode).Location = new Point(727, 70);
		((Control)pnlMembAcCode).Name = "pnlMembAcCode";
		((Control)pnlMembAcCode).Size = new Size(298, 30);
		((Control)pnlMembAcCode).TabIndex = 1237;
		((Control)pnlMembAcCode).Visible = false;
		((TextBoxBase)tAcMembCode).BackColor = Color.White;
		((Control)tAcMembCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcMembCode).Location = new Point(70, 4);
		((TextBoxBase)tAcMembCode).MaxLength = 8;
		((Control)tAcMembCode).Name = "tAcMembCode";
		((Control)tAcMembCode).Size = new Size(64, 23);
		((Control)tAcMembCode).TabIndex = 1158;
		((TextBoxBase)tAcMembName).BackColor = Color.White;
		((Control)tAcMembName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcMembName).Location = new Point(139, 4);
		((TextBoxBase)tAcMembName).MaxLength = 50;
		((Control)tAcMembName).Name = "tAcMembName";
		((Control)tAcMembName).Size = new Size(154, 23);
		((Control)tAcMembName).TabIndex = 1159;
		((Control)Label32).BackColor = Color.Transparent;
		((Control)Label32).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label32).ForeColor = Color.Black;
		Label32.ImeMode = (ImeMode)0;
		((Control)Label32).Location = new Point(5, 5);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(68, 20);
		((Control)Label32).TabIndex = 1160;
		Label32.Text = "Memb Ac";
		Label32.TextAlign = (ContentAlignment)16;
		((ButtonBase)chkWhoutcommBill).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkWhoutcommBill).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWhoutcommBill).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkWhoutcommBill).Location = new Point(977, 5);
		((Control)chkWhoutcommBill).Name = "chkWhoutcommBill";
		((Control)chkWhoutcommBill).RightToLeft = (RightToLeft)0;
		((Control)chkWhoutcommBill).Size = new Size(142, 19);
		((Control)chkWhoutcommBill).TabIndex = 1238;
		((ButtonBase)chkWhoutcommBill).Text = "Whout Comm Bill";
		((ButtonBase)chkWhoutcommBill).UseVisualStyleBackColor = false;
		((Control)chkWhoutcommBill).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkWhoutcommBill);
		((Control)this).Controls.Add((Control)(object)PnlTrfrVch);
		((Control)this).Controls.Add((Control)(object)pnlMembAcCode);
		((Control)this).Controls.Add((Control)(object)pnlMobile);
		((Control)this).Controls.Add((Control)(object)pnlCrnt);
		((Control)this).Controls.Add((Control)(object)PnlUpdate);
		((Control)this).Controls.Add((Control)(object)chkRateUnFix);
		((Control)this).Controls.Add((Control)(object)PnlUpi);
		((Control)this).Controls.Add((Control)(object)chkHuIdPrint);
		((Control)this).Controls.Add((Control)(object)btnQuot);
		((Control)this).Controls.Add((Control)(object)chkBillOrnaIsu);
		((Control)this).Controls.Add((Control)(object)chkPointMemb);
		((Control)this).Controls.Add((Control)(object)PnlPoint);
		((Control)this).Controls.Add((Control)(object)nBillProfit);
		((Control)this).Controls.Add((Control)(object)lblTrfrOpen);
		((Control)this).Controls.Add((Control)(object)lblItStock);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)tNewPrint);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)tPanNo);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)btnIsuNo);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
		((Control)this).Controls.Add((Control)(object)TEXT_ORD);
		((Control)this).Controls.Add((Control)(object)MSG_ORD);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)TEXT_OLD);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG_OLD);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItDesc);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)TEXT_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_IDTL);
		((Control)this).Controls.Add((Control)(object)lblItem);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)mDay);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_SALE";
		((Form)this).Text = "Sales";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_OLD).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_ORD).EndInit();
		((Control)PnlTrfrVch).ResumeLayout(false);
		((Control)PnlTrfrVch).PerformLayout();
		((Control)PnlUpdate).ResumeLayout(false);
		((ISupportInitialize)picAc).EndInit();
		((Control)PnlUpi).ResumeLayout(false);
		((Control)PnlUpi).PerformLayout();
		((ISupportInitialize)MSG_UPI).EndInit();
		((Control)PnlPoint).ResumeLayout(false);
		((Control)PnlPoint).PerformLayout();
		((Control)pnlCrnt).ResumeLayout(false);
		((Control)pnlCrnt).PerformLayout();
		((ISupportInitialize)MSG_CRNT).EndInit();
		((Control)pnlMobile).ResumeLayout(false);
		((Control)pnlMembAcCode).ResumeLayout(false);
		((Control)pnlMembAcCode).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CRNT_CLEAR()
	{
		AxMSFlexGrid mSG_CRNT = MSG_CRNT;
		mSG_CRNT.Clear();
		mSG_CRNT.Cols = 9;
		mSG_CRNT.FixedRows = 1;
		mSG_CRNT.Rows = 2;
		mSG_CRNT.Row = 1;
		mSG_CRNT[0] = 0;
		mSG_CRNT[1] = 0;
		mSG_CRNT.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_CRNT[0] = (int)Math.Round(400.0 * ColCon);
			mSG_CRNT[0] = 3;
			mSG_CRNT[0, 0] = "Sr";
			mSG_CRNT[1] = (int)Math.Round(1100.0 * ColCon);
			mSG_CRNT[1] = 0;
			mSG_CRNT[0, 1] = "Crnt No";
			mSG_CRNT[2] = (int)Math.Round(1250.0 * ColCon);
			mSG_CRNT[2] = 7;
			mSG_CRNT[0, 2] = "Crnt Amt";
			mSG_CRNT[4] = 0;
			mSG_CRNT[5] = 0;
			mSG_CRNT[6] = 0;
			mSG_CRNT[7] = 0;
			mSG_CRNT[3] = 0;
			mSG_CRNT[8] = 0;
			mSG_CRNT[1, 0] = Conversions.ToString(1);
			mSG_CRNT.Row = 1;
			mSG_CRNT.Col = 1;
			((Control)TEXT_CRNT).Visible = false;
			mSG_CRNT[0] = (int)Math.Round(325.0 * ColCon);
			mSG_CRNT[1] = (int)Math.Round(300.0 * ColCon);
			mSG_CRNT.ScrollBars = (ScrollBarsSettings)3;
			mSG_CRNT = null;
		}
	}

	private void MSG_CRNT_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_CRNT = MSG_CRNT;
		checked
		{
			if (mSG_CRNT.CellWidth >= 0)
			{
				((Control)TEXT_CRNT).Left = (int)Math.Round((double)((Control)mSG_CRNT).Left + (double)mSG_CRNT.CellLeft / 15.0);
				((Control)TEXT_CRNT).Top = (int)Math.Round((double)((Control)mSG_CRNT).Top + (double)mSG_CRNT.CellTop / 15.0);
				((Control)TEXT_CRNT).Width = (int)Math.Round((double)mSG_CRNT.CellWidth / 15.0);
				((Control)TEXT_CRNT).Height = (int)Math.Round((double)mSG_CRNT.CellHeight / 15.0);
				TEXT_CRNT.Text = mSG_CRNT[mSG_CRNT.Row, mSG_CRNT.Col];
				((Control)TEXT_CRNT).Visible = true;
				((TextBoxBase)TEXT_CRNT).SelectAll();
				((Control)TEXT_CRNT).Focus();
				mSG_CRNT = null;
			}
		}
	}

	private void MSG_CRNT_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_CRNT = MSG_CRNT;
		checked
		{
			if (!((mSG_CRNT.Row == 0) | (mSG_CRNT.CellWidth <= 0)) && mSG_CRNT[mSG_CRNT.Col] != 0)
			{
				((Control)TEXT_CRNT).Left = (int)Math.Round((double)((Control)mSG_CRNT).Left + (double)mSG_CRNT.CellLeft / 15.0);
				((Control)TEXT_CRNT).Top = (int)Math.Round((double)((Control)mSG_CRNT).Top + (double)mSG_CRNT.CellTop / 15.0);
				((Control)TEXT_CRNT).Width = (int)Math.Round((double)mSG_CRNT.CellWidth / 15.0);
				((Control)TEXT_CRNT).Height = (int)Math.Round((double)mSG_CRNT.CellHeight / 15.0);
				((Control)TEXT_CRNT).Visible = true;
				((TextBoxBase)TEXT_CRNT).ReadOnly = false;
				switch (MSG_CRNT.Col)
				{
				case 0:
					((TextBoxBase)TEXT_CRNT).MaxLength = 5;
					TEXT_CRNT.Text = mSG_CRNT[mSG_CRNT.Row, mSG_CRNT.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_CRNT).MaxLength = 8;
					TEXT_CRNT.Text = mSG_CRNT[mSG_CRNT.Row, mSG_CRNT.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_CRNT).MaxLength = 10;
					TEXT_CRNT.Text = Strings.Format((object)Conversion.Val(mSG_CRNT[mSG_CRNT.Row, mSG_CRNT.Col]), "0.00");
					break;
				}
				mSG_CRNT = null;
				((TextBoxBase)TEXT_CRNT).SelectAll();
			}
		}
	}

	private void MSG_CRNT_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_CRNT.Row != 0 && MSG_CRNT[MSG_CRNT.Col] != 0 && ((Control)TEXT_CRNT).Visible)
		{
			AxMSFlexGrid mSG_CRNT = MSG_CRNT;
			switch (MSG_CRNT.Col)
			{
			case 1:
				mSG_CRNT[mSG_CRNT.Row, mSG_CRNT.Col] = TEXT_CRNT.Text;
				break;
			case 2:
				mSG_CRNT[mSG_CRNT.Row, mSG_CRNT.Col] = Strings.Format((object)Conversion.Val(TEXT_CRNT.Text), "0.00");
				break;
			}
			mSG_CRNT = null;
			BILL_TOTAL();
		}
	}

	private void TEXT_CRNT_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_CRNT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_CRNT = MSG_CRNT;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG_CRNT.Col > 1)
					{
						mSG_CRNT.Col -= 1;
					}
					return;
				case 2:
					if (mSG_CRNT.Col < 2)
					{
						mSG_CRNT.Col += 1;
					}
					return;
				case 1:
					if (mSG_CRNT.Row > 1)
					{
						mSG_CRNT.Row -= 1;
					}
					return;
				case 3:
					if (mSG_CRNT.Row < mSG_CRNT.Rows - 1)
					{
						mSG_CRNT.Row += 1;
					}
					return;
				}
				if (unchecked((int)keyCode) == 112 && mSG_CRNT.Col == 1)
				{
					if (Operators.CompareString(FormBookType, "T", false) == 0)
					{
						DC_Main.CurBook = "346";
						DC_Main.CurBookType = "T";
						DC_Main.CurBookName = "Credit Note";
						DC_Main.MsUserRightForm = "Sales Return";
						DC_Main.CurBookItm = "A";
						DC_Main.CurBookMain = "SALES RETURNE";
						DC_Main.CurBookSname = "GSRTN";
						DC_Main.CurBookInOut = "I";
					}
					else
					{
						DC_Main.CurBook = "046";
						DC_Main.CurBookType = "F";
						DC_Main.CurBookName = "Sales Return";
						DC_Main.MsUserRightForm = "Sales Return";
						DC_Main.CurBookItm = "A";
						DC_Main.CurBookMain = "SALES RETURNE";
						DC_Main.CurBookSname = "SLRTN";
						DC_Main.CurBookInOut = "I";
					}
					DC_Main.MsSlAcCode = tAcCode.Text;
					DC_Main.CustUrdName = tAcName.Text;
					DC_Main.MsOpenSlRtn = true;
					DC_Main.MsSlBill = tVchNo.Text;
					DC_Main.MsSlBillHdNo = tHdVchNo.Text;
					DC_Main.MsSlYrCd = DC_Main.MCo_year;
					DC_Main.MsSlDbCd = DC_Main.MCo_Book;
					TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
					((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE_RTN).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE_RTN).Show();
					((Control)tR_SALE_RTN).Focus();
					return;
				}
			}
			else
			{
				switch (mSG_CRNT.Col)
				{
				case 1:
					if (Operators.CompareString(TEXT_CRNT.Text, "", false) == 0)
					{
						((Control)pnlCrnt).Visible = false;
						((Control)TEXT_CRNT).Visible = false;
						MSG2_TOTAL.Col = 3;
						MSG2_TOTAL.Row = 8;
						MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					}
					if (!((Operators.CompareString(TEXT_CRNT.Text, "", false) == 0) | (Operators.CompareString(TEXT_CRNT.Text, mSG_CRNT[mSG_CRNT.Row, 1], false) != 0)))
					{
						break;
					}
					DC_Main.RsQry = "SELECT * FROM SL_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG_CRNT[mSG_CRNT.Row, 4] + "' AND CO_BOOK = '" + mSG_CRNT[mSG_CRNT.Row, 5] + "' AND VCH_NO = '" + TEXT_CRNT.Text + "' ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS OrderDtL,A.RTN_BILL_OS AS CrntAmtR,CASE WHEN SUM(B.CRNT_AMT) IS NULL THEN 0 ELSE SUM(B.CRNT_AMT) END As AdjAmtR,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL FROM (SL_DATA AS A LEFT JOIN CRNT_DATA AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CRNT_YRCD AND A.CO_BOOK = B.CRNT_DBCD AND A.VCH_NO = B.CRNT_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' AND C.MAIN_BOOK = 'SALES RETURNE' AND C.BOOK_TYPE = "), Interaction.IIf(Operators.CompareString(FormBookType, "M", false) == 0, (object)"'F'", (object)("'" + FormBookType + "'"))), (object)" "), (object)" GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.RTN_BILL_OS,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING (CASE WHEN SUM(B.CRNT_AMT) IS NULL THEN 0 ELSE SUM(B.CRNT_AMT) END) < A.RTN_BILL_OS  ORDER BY A.VCH_DATE,A.VCH_NO "));
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[10];
						DC_Main.ColWidth[0] = 320.0;
						DC_Main.ColWidth[1] = 100.0;
						DC_Main.ColWidth[2] = 95.0;
						DC_Main.ColWidth[3] = 130.0;
						DC_Main.ColWidth[4] = 115.0;
						DC_Main.ColWidth[5] = 115.0;
						DC_Main.ColWidth[6] = 0.0;
						DC_Main.ColWidth[7] = 0.0;
						DC_Main.ColWidth[8] = 0.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose)
						{
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_CRNT.Text = DC_Main.ColValue[2];
								mSG_CRNT[mSG_CRNT.Row, 4] = DC_Main.ColValue[6];
								mSG_CRNT[mSG_CRNT.Row, 5] = DC_Main.ColValue[7];
								mSG_CRNT[mSG_CRNT.Row, 6] = DC_Main.ColValue[1];
								mSG_CRNT[mSG_CRNT.Row, 7] = DC_Main.ColValue[8];
								mSG_CRNT[mSG_CRNT.Row, 3] = DC_Main.MLc_code;
								CrntAdjAmt = Conversions.ToDouble(DC_Main.ColValue[5]);
							}
							((Control)TEXT_CRNT).Focus();
						}
					}
					else
					{
						mSG_CRNT[mSG_CRNT.Row, 1] = TEXT_CRNT.Text;
						mSG_CRNT[mSG_CRNT.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
						mSG_CRNT[mSG_CRNT.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HD_VCH_NO"], (object)""));
						AxMSFlexGrid obj = mSG_CRNT;
						int row = mSG_CRNT.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["RTN_BILL_OS"]);
						double num = DC_Main.Fnv(ref Value);
						dataRow["RTN_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 2] = Strings.Format((object)(num - CrntAdjAmt), "0.00");
						AxMSFlexGrid obj2 = mSG_CRNT;
						int row2 = mSG_CRNT.Row;
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["RTN_BILL_OS"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["RTN_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
						obj2[row2, 8] = Strings.Format((object)(num2 - CrntAdjAmt), "0.00");
						mSG_CRNT[mSG_CRNT.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_CRNT[mSG_CRNT.Row, 3] = DC_Main.MLc_code;
						CrntAdjAmt = 0.0;
						BILL_TOTAL();
					}
					return;
				case 2:
					if (mSG_CRNT.Row == mSG_CRNT.Rows - 1)
					{
						if (Conversion.Val(mSG_CRNT[mSG_CRNT.Row, 8]) != 0.0)
						{
							if (Conversion.Val(mSG_CRNT[mSG_CRNT.Row, 8]) < Conversion.Val(TEXT_CRNT.Text))
							{
								Interaction.MsgBox((object)("Cant Insert Mor Then CreditNot Value CreditNot Value Is " + Conversions.ToString(Conversion.Val(mSG_CRNT[mSG_CRNT.Row, 8])) + " Please Insert Less Value..."), (MsgBoxStyle)0, (object)null);
								return;
							}
							mSG_CRNT[mSG_CRNT.Row, 2] = Strings.Format((object)Conversion.Val(TEXT_CRNT.Text), "0.00");
						}
						else
						{
							mSG_CRNT[mSG_CRNT.Row, 2] = Strings.Format((object)Conversion.Val(TEXT_CRNT.Text), "0.00");
						}
						mSG_CRNT.Rows += 1;
						mSG_CRNT.Row += 1;
						mSG_CRNT.Col = 1;
						mSG_CRNT[mSG_CRNT.Row, 0] = Conversions.ToString(mSG_CRNT.Row);
					}
					else
					{
						mSG_CRNT.Row += 1;
					}
					mSG_CRNT.Col = 1;
					((Control)TEXT_CRNT).Visible = true;
					((Control)TEXT_CRNT).Focus();
					return;
				}
				if (mSG_CRNT.Col < mSG_CRNT.Cols - 1)
				{
					mSG_CRNT.Col += 1;
				}
				((Control)TEXT_CRNT).Visible = true;
				((Control)TEXT_CRNT).Focus();
			}
			mSG_CRNT = null;
		}
	}

	private void MSG_UPI_CLEAR()
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		MsgClear = true;
		mSG_UPI.Clear();
		mSG_UPI.Cols = 6;
		mSG_UPI.Rows = 2;
		mSG_UPI.Row = 0;
		mSG_UPI[0] = 325;
		checked
		{
			mSG_UPI[0] = (int)Math.Round(450.0 * ColCon);
			mSG_UPI[0] = 3;
			mSG_UPI[0, 0] = "Sr.";
			mSG_UPI[1] = (int)Math.Round(1100.0 * ColCon);
			mSG_UPI[1] = 0;
			mSG_UPI[0, 1] = "AcCode";
			mSG_UPI[2] = (int)Math.Round(3300.0 * ColCon);
			mSG_UPI[2] = 0;
			mSG_UPI[0, 2] = "Upi Bank Name";
			mSG_UPI[3] = (int)Math.Round(1500.0 * ColCon);
			mSG_UPI[3] = 0;
			mSG_UPI[0, 3] = "UpiType";
			mSG_UPI[4] = (int)Math.Round(2500.0 * ColCon);
			mSG_UPI[4] = 0;
			mSG_UPI[0, 4] = "Upi Id";
			mSG_UPI[5] = (int)Math.Round(1400.0 * ColCon);
			mSG_UPI[5] = 7;
			mSG_UPI[0, 5] = "UpiAmt";
			mSG_UPI[0] = (int)Math.Round(325.0 * ColCon);
			mSG_UPI[1] = (int)Math.Round(300.0 * ColCon);
			mSG_UPI.Row = 1;
			mSG_UPI.Col = 0;
			((Control)TEXT_UPI).Visible = false;
			MsgClear = false;
			mSG_UPI = null;
		}
	}

	private void CommPassAddUpi()
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		mSG_UPI[mSG_UPI.Row, 0] = Conversions.ToString(MSG_UPI.Row);
		mSG_UPI = null;
	}

	private void MSG_UPI_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		UpDown = false;
		checked
		{
			if (mSG_UPI.CellWidth >= 0)
			{
				((Control)TEXT_UPI).Left = (int)Math.Round((double)((Control)mSG_UPI).Left + (double)mSG_UPI.CellLeft / 15.0);
				((Control)TEXT_UPI).Top = (int)Math.Round((double)((Control)mSG_UPI).Top + (double)mSG_UPI.CellTop / 15.0);
				((Control)TEXT_UPI).Width = (int)Math.Round((double)mSG_UPI.CellWidth / 15.0);
				((Control)TEXT_UPI).Height = (int)Math.Round((double)mSG_UPI.CellHeight / 15.0);
				((Control)TEXT_UPI).Visible = true;
				((TextBoxBase)TEXT_UPI).SelectAll();
				((Control)TEXT_UPI).Focus();
				mSG_UPI = null;
			}
		}
	}

	private void MSG_UPI_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		checked
		{
			if (mSG_UPI[mSG_UPI.Col] == 0)
			{
				TEXT_UPI.Text = "";
				mSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = "";
				DC_Main.M = 1;
				while (mSG_UPI[mSG_UPI.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG_UPI.Col > 1)
						{
							mSG_UPI.Col -= 1;
						}
					}
					else if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						mSG_UPI.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 5)
					{
						break;
					}
				}
			}
			if (!((mSG_UPI.Row == 0) | (mSG_UPI.CellWidth <= 0)) && MSG_UPI[MSG_UPI.Col] != 0)
			{
				((Control)TEXT_UPI).Left = (int)Math.Round((double)((Control)mSG_UPI).Left + (double)mSG_UPI.CellLeft / 15.0);
				((Control)TEXT_UPI).Top = (int)Math.Round((double)((Control)mSG_UPI).Top + (double)mSG_UPI.CellTop / 15.0);
				((Control)TEXT_UPI).Width = (int)Math.Round((double)mSG_UPI.CellWidth / 15.0);
				((Control)TEXT_UPI).Height = (int)Math.Round((double)mSG_UPI.CellHeight / 15.0);
				((Control)TEXT_UPI).Visible = true;
				((TextBoxBase)TEXT_UPI).ReadOnly = false;
				switch (MSG_UPI.Col)
				{
				case 0:
					((TextBoxBase)TEXT_UPI).MaxLength = 5;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_UPI).MaxLength = 10;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 3:
				case 4:
					((TextBoxBase)TEXT_UPI).MaxLength = 25;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_UPI).MaxLength = 50;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_UPI).MaxLength = 10;
					TEXT_UPI.Text = Strings.Format((object)Conversion.Val(mSG_UPI[mSG_UPI.Row, mSG_UPI.Col]), "0.00");
					break;
				}
				mSG_UPI = null;
				((TextBoxBase)TEXT_UPI).SelectAll();
			}
		}
	}

	private void MSG_UPI_LeaveCell(object sender, EventArgs e)
	{
		if (!UpDown && !MsgClear && MSG_UPI.Row != 0 && MSG_UPI[MSG_UPI.Col] != 0 && ((Control)TEXT_UPI).Visible)
		{
			AxMSFlexGrid mSG_UPI = MSG_UPI;
			switch (MSG_UPI.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				MSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = TEXT_UPI.Text;
				break;
			case 5:
				MSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = Strings.Format((object)Conversion.Val(TEXT_UPI.Text), "0.00");
				TotAmt();
				break;
			}
			mSG_UPI = null;
		}
	}

	private void TotAmt()
	{
		checked
		{
			int num = MSG_UPI.Rows - 1;
			double num2 = default(double);
			for (int i = 1; i <= num; i++)
			{
				if ((Operators.CompareString(MSG_UPI[i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[i, 5]) != 0.0))
				{
					num2 += Conversion.Val(MSG_UPI[i, 5]);
				}
			}
			MSG2_TOTAL[12, 1] = Strings.Format((object)num2, "0.00");
			BILL_TOTAL();
		}
	}

	private void TEXT_UPI_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Invalid comparison between Unknown and I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Invalid comparison between Unknown and I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Invalid comparison between Unknown and I4
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG_UPI.Col == 3)
			{
				UpiTypeAdd = true;
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_UPI.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_UPI[mSG_UPI.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_UPI.Text = "";
					TotAmt();
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_UPI.Col > 1)
				{
					mSG_UPI.Col = checked(mSG_UPI.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						mSG_UPI.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG_UPI.Row > 1)
				{
					mSG_UPI.Row = checked(mSG_UPI.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_UPI.Row < mSG_UPI.Rows - 1)
					{
						mSG_UPI.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_UPI.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_UPI.Text, "", false) == 0)
						{
							TotAmt();
							((Control)PnlUpi).Visible = false;
							((Control)TEXT_UPI).Visible = false;
							MSG2_TOTAL.Col = 3;
							MSG2_TOTAL.Row = 12;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_UPI.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '19','22','23','21','02') ORDER BY A.LC_CODE,A.AC_NAME";
							}
							else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
							{
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.AC_GR in( '19','22','23','21','02') AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 AND A.AC_GR in( '19','22','23','21','02') ORDER BY C.AC_NAME ";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR in( '19','22','23','02') ORDER BY A.AC_NAME";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[8];
							DC_Main.ColWidth[0] = 270.0;
							DC_Main.ColWidth[1] = 80.0;
							DC_Main.ColWidth[2] = 170.0;
							DC_Main.ColWidth[3] = 180.0;
							DC_Main.ColWidth[4] = 220.0;
							DC_Main.ColWidth[5] = 160.0;
							DC_Main.ColWidth[6] = 110.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (DC_Main.MsCreat)
							{
								MS_ACCT mS_ACCT = new MS_ACCT();
								((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_ACCT).Show();
								((Control)mS_ACCT).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_UPI.Text = DC_Main.ColValue[1];
								mSG_UPI[mSG_UPI.Row, 1] = DC_Main.ColValue[1];
								mSG_UPI[mSG_UPI.Row, 2] = DC_Main.ColValue[0];
							}
							((Control)TEXT_UPI).Focus();
							return;
						}
						mSG_UPI[mSG_UPI.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_UPI[mSG_UPI.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
						break;
					case 3:
					{
						DC_Main.RsQry = "SELECT UPI_TYPE As UpiTypeL  From UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_TYPE = '" + TEXT_UPI.Text + "' ORDER BY UPI_TYPE";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count != 0)
						{
							break;
						}
						int num2 = MSG_UPI.Rows - 1;
						for (int i = 1; i <= num2; i++)
						{
							if (Operators.CompareString(mSG_UPI[i, 3], TEXT_UPI.Text, false) == 0)
							{
								UpiTypeAdd = true;
							}
						}
						if (!UpiTypeAdd)
						{
							DC_Main.RsQry = "SELECT DISTINCT UPI_TYPE As UpiTypeL From UPI_DATA ORDER BY UPI_TYPE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[2];
							DC_Main.ColWidth[0] = 350.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_UPI.Text = DC_Main.ColValue[0];
							}
							return;
						}
						UpiTypeAdd = false;
						break;
					}
					case 4:
						if (Operators.CompareString(TEXT_UPI.Text, "", false) != 0)
						{
							DC_Main.RsQry = "SELECT UPI_ID,CO_BOOK,VCH_NO FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_ID = '" + TEXT_UPI.Text + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This UpiId already Exist In Book No =  ", DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)" AND VchNo = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)" Please Change Upi Id ..."), (MsgBoxStyle)0, (object)null);
								((TextBoxBase)TEXT_UPI).SelectAll();
								return;
							}
						}
						break;
					case 5:
						if (Conversion.Val(TEXT_UPI.Text) != 0.0)
						{
							if (mSG_UPI.Row == mSG_UPI.Rows - 1)
							{
								mSG_UPI.Rows += 1;
								mSG_UPI.Row += 1;
								CommPassAddUpi();
								mSG_UPI.Col = 1;
							}
							else
							{
								mSG_UPI.Row += 1;
								mSG_UPI.Col = 1;
								((Control)TEXT_UPI).Visible = true;
								((Control)TEXT_UPI).Focus();
							}
						}
						return;
					}
					if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						MSG_UPI.Col += 1;
					}
					((Control)TEXT_UPI).Visible = true;
					((Control)TEXT_UPI).Focus();
				}
			}
		}
		mSG_UPI = null;
	}

	private void MSG_ORD_CLEAR()
	{
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		mSG_ORD.Clear();
		mSG_ORD.Cols = 9;
		mSG_ORD.FixedRows = 1;
		mSG_ORD.Rows = 2;
		mSG_ORD.Row = 1;
		mSG_ORD[0] = 0;
		mSG_ORD[1] = 0;
		mSG_ORD.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_ORD[0] = (int)Math.Round(400.0 * ColCon);
			mSG_ORD[0] = 3;
			mSG_ORD[0, 0] = "Sr";
			mSG_ORD[1] = (int)Math.Round(1100.0 * ColCon);
			mSG_ORD[1] = 0;
			mSG_ORD[0, 1] = "Ord No";
			mSG_ORD[2] = (int)Math.Round(1250.0 * ColCon);
			mSG_ORD[2] = 7;
			mSG_ORD[0, 2] = "Ord Amt";
			mSG_ORD[4] = 0;
			mSG_ORD[5] = 0;
			mSG_ORD[6] = 0;
			mSG_ORD[7] = 0;
			mSG_ORD[3] = 0;
			mSG_ORD[8] = 0;
			mSG_ORD[1, 0] = Conversions.ToString(1);
			mSG_ORD.Row = 1;
			mSG_ORD.Col = 1;
			((Control)TEXT_ORD).Visible = false;
			mSG_ORD[0] = (int)Math.Round(325.0 * ColCon);
			mSG_ORD[1] = (int)Math.Round(300.0 * ColCon);
			mSG_ORD.ScrollBars = (ScrollBarsSettings)3;
			mSG_ORD = null;
		}
	}

	private void MSG_ORD_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		checked
		{
			if (mSG_ORD.CellWidth >= 0)
			{
				((Control)TEXT_ORD).Left = (int)Math.Round((double)((Control)mSG_ORD).Left + (double)mSG_ORD.CellLeft / 15.0);
				((Control)TEXT_ORD).Top = (int)Math.Round((double)((Control)mSG_ORD).Top + (double)mSG_ORD.CellTop / 15.0);
				((Control)TEXT_ORD).Width = (int)Math.Round((double)mSG_ORD.CellWidth / 15.0);
				((Control)TEXT_ORD).Height = (int)Math.Round((double)mSG_ORD.CellHeight / 15.0);
				TEXT_ORD.Text = mSG_ORD[mSG_ORD.Row, mSG_ORD.Col];
				((Control)TEXT_ORD).Visible = true;
				((TextBoxBase)TEXT_ORD).SelectAll();
				((Control)TEXT_ORD).Focus();
				mSG_ORD = null;
			}
		}
	}

	private void MSG_ORD_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		checked
		{
			if (!((mSG_ORD.Row == 0) | (mSG_ORD.CellWidth <= 0)) && mSG_ORD[mSG_ORD.Col] != 0)
			{
				((Control)TEXT_ORD).Left = (int)Math.Round((double)((Control)mSG_ORD).Left + (double)mSG_ORD.CellLeft / 15.0);
				((Control)TEXT_ORD).Top = (int)Math.Round((double)((Control)mSG_ORD).Top + (double)mSG_ORD.CellTop / 15.0);
				((Control)TEXT_ORD).Width = (int)Math.Round((double)mSG_ORD.CellWidth / 15.0);
				((Control)TEXT_ORD).Height = (int)Math.Round((double)mSG_ORD.CellHeight / 15.0);
				((Control)TEXT_ORD).Visible = true;
				((TextBoxBase)TEXT_ORD).ReadOnly = false;
				switch (MSG_ORD.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ORD).MaxLength = 5;
					TEXT_ORD.Text = mSG_ORD[mSG_ORD.Row, mSG_ORD.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ORD).MaxLength = 8;
					TEXT_ORD.Text = mSG_ORD[mSG_ORD.Row, mSG_ORD.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ORD).MaxLength = 10;
					TEXT_ORD.Text = Strings.Format((object)Conversion.Val(mSG_ORD[mSG_ORD.Row, mSG_ORD.Col]), "0.00");
					break;
				}
				mSG_ORD = null;
				((TextBoxBase)TEXT_ORD).SelectAll();
			}
		}
	}

	private void MSG_ORD_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_ORD.Row != 0 && MSG_ORD[MSG_ORD.Col] != 0 && ((Control)TEXT_ORD).Visible)
		{
			AxMSFlexGrid mSG_ORD = MSG_ORD;
			switch (MSG_ORD.Col)
			{
			case 1:
				mSG_ORD[mSG_ORD.Row, mSG_ORD.Col] = TEXT_ORD.Text;
				break;
			case 2:
				mSG_ORD[mSG_ORD.Row, mSG_ORD.Col] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.00");
				break;
			}
			mSG_ORD = null;
			BILL_TOTAL();
		}
	}

	private void TEXT_ORD_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ORD_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG_ORD.Col > 1)
					{
						mSG_ORD.Col -= 1;
					}
					return;
				case 2:
					if (mSG_ORD.Col < 18)
					{
						mSG_ORD.Col += 1;
					}
					return;
				case 1:
					if (mSG_ORD.Row > 1)
					{
						mSG_ORD.Row -= 1;
					}
					return;
				case 3:
					if (mSG_ORD.Row < mSG_ORD.Rows - 1)
					{
						mSG_ORD.Row += 1;
					}
					return;
				}
			}
			else
			{
				switch (mSG_ORD.Col)
				{
				case 1:
					if (Operators.CompareString(TEXT_ORD.Text, "", false) == 0)
					{
						((Control)TEXT_ORD).Visible = false;
						MSG2_TOTAL.Col = 3;
						MSG2_TOTAL.Row = 9;
						MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					}
					if (!((Operators.CompareString(TEXT_ORD.Text, "", false) == 0) | (Operators.CompareString(TEXT_ORD.Text, mSG_ORD[mSG_ORD.Row, 1], false) != 0)))
					{
						break;
					}
					DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG_ORD[mSG_ORD.Row, 4] + "' AND CO_BOOK = '" + mSG_ORD[mSG_ORD.Row, 5] + "' AND VCH_NO = '" + TEXT_ORD.Text + "' ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS OrderDtL,A.ADV_AMT AS AmountR,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmountR ,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "VK163NEVK", false) == 0, (object)(" AND A.AC_CODE = '" + tAcCode.Text + "'"), (object)"")), (object)" "), (object)" GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) > 0  ORDER BY A.VCH_DATE,A.VCH_NO "));
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[10];
						DC_Main.ColWidth[0] = 320.0;
						DC_Main.ColWidth[1] = 100.0;
						DC_Main.ColWidth[2] = 95.0;
						DC_Main.ColWidth[3] = 130.0;
						DC_Main.ColWidth[4] = 115.0;
						DC_Main.ColWidth[5] = 115.0;
						DC_Main.ColWidth[6] = 0.0;
						DC_Main.ColWidth[7] = 0.0;
						DC_Main.ColWidth[8] = 0.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (DC_Main.HelpClose)
						{
							return;
						}
						if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
						{
							TEXT_ORD.Text = DC_Main.ColValue[2];
							int num = mSG_ORD.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num)
							{
								if ((Operators.CompareString(mSG_ORD[DC_Main.X, 5] + mSG_ORD[DC_Main.X, 1], DC_Main.ColValue[7] + TEXT_ORD.Text, false) == 0) & (mSG_ORD.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Order No", (MsgBoxStyle)0, (object)null);
									TEXT_ORD.Text = "";
									return;
								}
								DC_Main.X++;
							}
							mSG_ORD[mSG_ORD.Row, 4] = DC_Main.ColValue[6];
							mSG_ORD[mSG_ORD.Row, 5] = DC_Main.ColValue[7];
							mSG_ORD[mSG_ORD.Row, 6] = DC_Main.ColValue[1];
							mSG_ORD[mSG_ORD.Row, 7] = DC_Main.ColValue[8];
							mSG_ORD[mSG_ORD.Row, 3] = DC_Main.MLc_code;
							LessAdvAmt = Conversions.ToDouble(DC_Main.ColValue[5]);
						}
						((Control)TEXT_ORD).Focus();
					}
					else
					{
						mSG_ORD[mSG_ORD.Row, 1] = TEXT_ORD.Text;
						mSG_ORD[mSG_ORD.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
						mSG_ORD[mSG_ORD.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HD_VCH_NO"], (object)""));
						AxMSFlexGrid obj = mSG_ORD;
						int row = mSG_ORD.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 2] = Strings.Format((object)(num2 - LessAdvAmt), "0.00");
						AxMSFlexGrid obj2 = mSG_ORD;
						int row2 = mSG_ORD.Row;
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
						double num3 = DC_Main.Fnv(ref Value);
						dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						obj2[row2, 8] = Strings.Format((object)(num3 - LessAdvAmt), "0.00");
						mSG_ORD[mSG_ORD.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_ORD[mSG_ORD.Row, 3] = DC_Main.MLc_code;
						LessAdvAmt = 0.0;
						BILL_TOTAL();
					}
					return;
				case 2:
					if (mSG_ORD.Row == mSG_ORD.Rows - 1)
					{
						if (Conversion.Val(mSG_ORD[mSG_ORD.Row, 8]) != 0.0)
						{
							if (Conversion.Val(mSG_ORD[mSG_ORD.Row, 8]) < Conversion.Val(TEXT_ORD.Text))
							{
								Interaction.MsgBox((object)("Cant Insert Mor Then Order Value Order Value Is " + Conversions.ToString(Conversion.Val(mSG_ORD[mSG_ORD.Row, 8])) + " Please Insert Less Value..."), (MsgBoxStyle)0, (object)null);
								return;
							}
							mSG_ORD[mSG_ORD.Row, 2] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.00");
						}
						else
						{
							mSG_ORD[mSG_ORD.Row, 2] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.00");
						}
						mSG_ORD.Rows += 1;
						mSG_ORD.Row += 1;
						mSG_ORD.Col = 1;
						mSG_ORD[mSG_ORD.Row, 0] = Conversions.ToString(mSG_ORD.Row);
					}
					else
					{
						mSG_ORD.Row += 1;
					}
					mSG_ORD.Col = 1;
					((Control)TEXT_ORD).Visible = true;
					((Control)TEXT_ORD).Focus();
					return;
				}
				if (mSG_ORD.Col < mSG_ORD.Cols - 1)
				{
					mSG_ORD.Col += 1;
				}
				((Control)TEXT_ORD).Visible = true;
				((Control)TEXT_ORD).Focus();
			}
			mSG_ORD = null;
		}
	}

	private void MSG_OLD_CLEAR()
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		mSG_OLD.Clear();
		mSG_OLD.Cols = 18;
		mSG_OLD.FixedRows = 1;
		mSG_OLD.Rows = 2;
		mSG_OLD.Row = 1;
		mSG_OLD[0] = 0;
		mSG_OLD[1] = 0;
		mSG_OLD.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_OLD[0] = (int)Math.Round(450.0 * ColCon);
			mSG_OLD[0] = 3;
			mSG_OLD[0, 0] = "Sr";
			mSG_OLD[1] = (int)Math.Round(850.0 * ColCon);
			mSG_OLD[1] = 0;
			mSG_OLD[0, 1] = "ItCode";
			mSG_OLD[2] = (int)Math.Round(1750.0 * ColCon);
			mSG_OLD[2] = 0;
			mSG_OLD[0, 2] = "ItName";
			mSG_OLD[3] = (int)Math.Round(500.0 * ColCon);
			mSG_OLD[3] = 7;
			mSG_OLD[0, 3] = "Pcs";
			mSG_OLD[4] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[4] = 7;
			mSG_OLD[0, 4] = "GrWt";
			mSG_OLD[5] = (int)Math.Round(700.0 * ColCon);
			mSG_OLD[5] = 7;
			mSG_OLD[0, 5] = "LsWt";
			mSG_OLD[6] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[6] = 7;
			mSG_OLD[0, 6] = "NetWt";
			mSG_OLD[7] = (int)Math.Round(675.0 * ColCon);
			mSG_OLD[7] = 3;
			mSG_OLD[0, 7] = "Touch";
			mSG_OLD[8] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[8] = 7;
			mSG_OLD[0, 8] = "Fine";
			mSG_OLD[9] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[9] = 7;
			mSG_OLD[0, 9] = "Con%";
			mSG_OLD[10] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[10] = 7;
			mSG_OLD[0, 10] = "ConWt";
			mSG_OLD[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_OLD[11] = 7;
			mSG_OLD[0, 11] = "Rate";
			mSG_OLD[12] = (int)Math.Round(675.0 * ColCon);
			mSG_OLD[12] = 3;
			mSG_OLD[0, 12] = "RTyp";
			mSG_OLD[13] = (int)Math.Round(1100.0 * ColCon);
			mSG_OLD[13] = 7;
			mSG_OLD[0, 13] = "NetAmt";
			mSG_OLD[14] = 0;
			mSG_OLD[15] = 0;
			mSG_OLD[16] = 0;
			mSG_OLD[17] = 0;
			mSG_OLD.Row = 1;
			mSG_OLD.Col = 1;
			((Control)TEXT_OLD).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG_OLD.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'OLD_GL_REC' AND COL_NAME = '" + mSG_OLD[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_OLD[DC_Main.M] = 0;
						}
						mSG_OLD[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_OLD[0] = (int)Math.Round(325.0 * ColCon);
			mSG_OLD[1] = (int)Math.Round(300.0 * ColCon);
			mSG_OLD.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Old();
			mSG_OLD = null;
		}
	}

	private void CommPassAdd_Old()
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		mSG_OLD[mSG_OLD.Row, 0] = Conversions.ToString(mSG_OLD.Row);
		mSG_OLD[mSG_OLD.Row, 12] = "F";
		mSG_OLD = null;
	}

	private void TEXT_OLD_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_OLD_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Invalid comparison between Unknown and I4
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Invalid comparison between Unknown and I4
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Invalid comparison between Unknown and I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Invalid comparison between Unknown and I4
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Invalid comparison between Unknown and I4
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		MsgOldLeft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_OLD.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_OLD[mSG_OLD.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_OLD.Text = "";
					Interaction.MsgBox((object)"Record Is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG_OLD.Col == 11)
			{
				if (Conversion.Val(TEXT_OLD.Text) == 0.0)
				{
					DC_Main.RsQry = "SELECT GR_RATE FROM  RATE_MAST AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND B.IT_CODE = '" + mSG_OLD[mSG_OLD.Row, 1] + "'";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num2 = default(double);
					if (dataTable.Rows.Count > 0)
					{
						num2 = Conversions.ToDouble(dataTable.Rows[0]["GR_RATE"]);
					}
					if (num2 > 0.0)
					{
						TEXT_OLD.Text = Strings.Format((object)Math.Round(num2 / 10.0, 0), "0.00");
					}
					else
					{
						mSG_OLD[mSG_OLD.Row, 11] = "";
					}
				}
				return;
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_OLD.Col > 1)
				{
					MsgOldLeft = true;
					mSG_OLD.Col = checked(mSG_OLD.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_OLD.Col < 18)
				{
					mSG_OLD.Col = checked(mSG_OLD.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_OLD.Row > 1)
				{
					mSG_OLD.Row = checked(mSG_OLD.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_OLD.Row < mSG_OLD.Rows - 1)
					{
						mSG_OLD.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_OLD.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_OLD.Text, "", false) == 0)
						{
							((Control)TEXT_OLD).Visible = false;
							MSG2_TOTAL.Col = 3;
							MSG2_TOTAL.Row = 11;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_OLD.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[7];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 0.0;
							DC_Main.ColWidth[4] = 0.0;
							DC_Main.ColWidth[5] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_OLD.Text = DC_Main.ColValue[1];
									mSG_OLD[mSG_OLD.Row, 1] = DC_Main.ColValue[1];
									mSG_OLD[mSG_OLD.Row, 2] = DC_Main.ColValue[0];
									mSG_OLD[mSG_OLD.Row, 14] = DC_Main.ColValue[4];
								}
								((Control)TEXT_OLD).Focus();
							}
							return;
						}
						mSG_OLD[mSG_OLD.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_OLD[mSG_OLD.Row, 14] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						break;
					case 12:
						if ((Operators.CompareString(TEXT_OLD.Text, "N", false) != 0) & (Operators.CompareString(TEXT_OLD.Text, "F", false) != 0))
						{
							Interaction.MsgBox((object)"Please Slelect Rate type = N - Net Wise Or F - Fine Wise", (MsgBoxStyle)0, (object)null);
							return;
						}
						break;
					case 13:
						if (mSG_OLD.Row == mSG_OLD.Rows - 1)
						{
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
							{
								if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0) & (Conversion.Val(TEXT_OLD.Text) != Conversion.Val(mSG_OLD[mSG_OLD.Row, 13])))
								{
									mSG_OLD[mSG_OLD.Row, 7] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * 100.0), "0.00");
									mSG_OLD[mSG_OLD.Row, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 7]) / 100.0), "0.000");
								}
								mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
								CommPassTotal_Old(mSG_OLD.Row);
							}
							else
							{
								mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
								CommPassTotal_Old(mSG_OLD.Row);
							}
							MsgClearIdtl = true;
							mSG_OLD.Rows += 1;
							mSG_OLD.Row += 1;
							MsgClearIdtl = false;
							mSG_OLD.Col = 1;
							CommPassAdd_Old();
							((Control)TEXT_OLD).Visible = true;
							((Control)TEXT_OLD).Focus();
						}
						else
						{
							mSG_OLD.Row += 1;
							mSG_OLD.Col = 1;
							((Control)TEXT_OLD).Visible = true;
							((Control)TEXT_OLD).Focus();
						}
						return;
					}
					if (mSG_OLD.Col < mSG_OLD.Cols - 1)
					{
						mSG_OLD.Col += 1;
					}
					((Control)TEXT_OLD).Visible = true;
					((Control)TEXT_OLD).Focus();
				}
			}
		}
		mSG_OLD = null;
	}

	private void MSG_OLD_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		checked
		{
			if (mSG_OLD.CellWidth >= 0)
			{
				((Control)TEXT_OLD).Left = (int)Math.Round((double)((Control)mSG_OLD).Left + (double)mSG_OLD.CellLeft / 15.0);
				((Control)TEXT_OLD).Top = (int)Math.Round((double)((Control)mSG_OLD).Top + (double)mSG_OLD.CellTop / 15.0);
				((Control)TEXT_OLD).Width = (int)Math.Round((double)mSG_OLD.CellWidth / 15.0);
				((Control)TEXT_OLD).Height = (int)Math.Round((double)mSG_OLD.CellHeight / 15.0);
				TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
				((Control)TEXT_OLD).Visible = true;
				((TextBoxBase)TEXT_OLD).SelectAll();
				((Control)TEXT_OLD).Focus();
				mSG_OLD = null;
			}
		}
	}

	private void MSG_OLD_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		checked
		{
			if (mSG_OLD[mSG_OLD.Col] == 0)
			{
				TEXT_OLD.Text = "";
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = "";
				DC_Main.M = 1;
				while (mSG_OLD[mSG_OLD.Col] == 0)
				{
					if (MsgOldLeft)
					{
						if (mSG_OLD.Col > 1)
						{
							mSG_OLD.Col -= 1;
						}
					}
					else if (mSG_OLD.Col < mSG_OLD.Cols - 1)
					{
						mSG_OLD.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 5)
					{
						break;
					}
				}
			}
			if (!((mSG_OLD.Row == 0) | (mSG_OLD.CellWidth <= 0)) && mSG_OLD[mSG_OLD.Col] != 0)
			{
				((Control)TEXT_OLD).Left = (int)Math.Round((double)((Control)mSG_OLD).Left + (double)mSG_OLD.CellLeft / 15.0);
				((Control)TEXT_OLD).Top = (int)Math.Round((double)((Control)mSG_OLD).Top + (double)mSG_OLD.CellTop / 15.0);
				((Control)TEXT_OLD).Width = (int)Math.Round((double)mSG_OLD.CellWidth / 15.0);
				((Control)TEXT_OLD).Height = (int)Math.Round((double)mSG_OLD.CellHeight / 15.0);
				((Control)TEXT_OLD).Visible = true;
				((TextBoxBase)TEXT_OLD).ReadOnly = false;
				switch (MSG_OLD.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_OLD).MaxLength = 5;
					TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_OLD).MaxLength = 50;
					TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
					break;
				case 12:
					((TextBoxBase)TEXT_OLD).MaxLength = 1;
					TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_OLD).MaxLength = 6;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0");
					break;
				case 7:
				case 9:
				case 11:
				case 13:
					((TextBoxBase)TEXT_OLD).MaxLength = 10;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0.00");
					break;
				case 4:
				case 5:
				case 6:
				case 8:
				case 10:
					((TextBoxBase)TEXT_OLD).MaxLength = 10;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0.000");
					break;
				}
				mSG_OLD = null;
				((TextBoxBase)TEXT_OLD).SelectAll();
			}
		}
	}

	private void MSG_OLD_LeaveCell(object sender, EventArgs e)
	{
		if (MsgClearIdtl || MSG_OLD.Row == 0 || MSG_OLD[MSG_OLD.Col] == 0 || !((Control)TEXT_OLD).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		switch (MSG_OLD.Col)
		{
		case 0:
		case 1:
		case 2:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = TEXT_OLD.Text;
			break;
		case 12:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = TEXT_OLD.Text;
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		case 3:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0");
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		case 7:
		case 9:
		case 11:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		case 4:
		case 5:
		case 6:
		case 8:
		case 10:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.000");
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		case 13:
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
			{
				if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0) & (Conversion.Val(TEXT_OLD.Text) != Conversion.Val(mSG_OLD[mSG_OLD.Row, 13])))
				{
					mSG_OLD[mSG_OLD.Row, 7] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * 100.0), "0.00");
					double num = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * 100.0), "0.00"));
					mSG_OLD[mSG_OLD.Row, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 7]) / 100.0), "0.000");
				}
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
			}
			else
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) != 0 && ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 13]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0)))
				{
					if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 12], "N", false) == 0)
					{
						mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 13]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6])), "0.00");
					}
					else
					{
						mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 13]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8])), "0.00");
					}
				}
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
			}
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		}
		mSG_OLD = null;
	}

	private void CommPassTotal_Old(int CRow)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		if (Conversion.Val(mSG_OLD[CRow, 4]) != Conversion.Val(mSG_OLD[CRow, 15]))
		{
			mSG_OLD[CRow, 15] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 4]), "0.000");
			mSG_OLD[CRow, 6] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 4]) - Conversion.Val(mSG_OLD[CRow, 5])), "0.000");
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 5]) != Conversion.Val(mSG_OLD[CRow, 16]))
		{
			mSG_OLD[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 5]), "0.000");
			mSG_OLD[CRow, 6] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 4]) - Conversion.Val(mSG_OLD[CRow, 5])), "0.000");
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 8]) == 0.0)
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 9]) != 0.0)
		{
			if (Conversion.Val(mSG_OLD[CRow, 9]) > 100.0)
			{
				if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) != 0.0))
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) / 100.0, 3), "0.000");
				}
				if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0)
				{
					mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
			{
				if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) != 0.0))
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) / 100.0), "0.000");
				}
				if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0)
				{
					mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
					mSG_OLD[mSG_OLD.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
				}
			}
			else
			{
				if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) != 0.0))
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)(Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) * 100.0 - Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), 3) + Conversion.Val(mSG_OLD[mSG_OLD.Row, 8])), "0.000");
				}
				if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0)
				{
					mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
				}
				if (((Conversion.Val(mSG_OLD[CRow, 13]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 10]) != 0.0)) && mSG_OLD.Col == 13)
				{
					mSG_OLD[CRow, 11] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[CRow, 10])), "0.00");
					mSG_OLD[CRow, 13] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				}
			}
		}
		else
		{
			if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0)
			{
				if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 12], "N", false) == 0)
				{
					mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
				}
				else
				{
					mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
				}
			}
			if (((Conversion.Val(mSG_OLD[CRow, 13]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 8]) != 0.0)) && mSG_OLD.Col == 13)
			{
				if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 12], "N", false) == 0)
				{
					mSG_OLD[CRow, 11] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[CRow, 6])), "0.00");
					mSG_OLD[CRow, 13] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				}
				else
				{
					mSG_OLD[CRow, 11] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[CRow, 8])), "0.00");
					mSG_OLD[CRow, 13] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				}
			}
			if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 12], "N", false) == 0)
			{
				if ((Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OG", false) == 0) & (ToDayGlRate != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 13]) != 0.0))
				{
					mSG_OLD[CRow, 7] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 13]) / ToDayGlRate / Conversion.Val(mSG_OLD[CRow, 6]) * 100.0), "0.00");
				}
				if ((Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OS", false) == 0) & (ToDaySlRate != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 13]) != 0.0))
				{
					mSG_OLD[CRow, 7] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 13]) / ToDaySlRate / Conversion.Val(mSG_OLD[CRow, 6]) * 100.0), "0.00");
				}
				if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
				{
					mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
			{
				mSG_OLD[mSG_OLD.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), 0), "0.00");
			}
		}
		BILL_TOTAL();
		mSG_OLD = null;
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 24;
		mSG_IDTL.FixedRows = 1;
		mSG_IDTL.Rows = 2;
		mSG_IDTL.Row = 0;
		mSG_IDTL[0] = 0;
		mSG_IDTL[1] = 0;
		mSG_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_IDTL[0] = 3;
			mSG_IDTL[0, 0] = "Sr";
			mSG_IDTL[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[1] = 0;
			mSG_IDTL[0, 1] = "ItCode";
			mSG_IDTL[2] = (int)Math.Round(2200.0 * ColCon);
			mSG_IDTL[2] = 0;
			mSG_IDTL[0, 2] = "ItName";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG_IDTL[3] = (int)Math.Round(875.0 * ColCon);
				mSG_IDTL[3] = 0;
				mSG_IDTL[0, 3] = "DmCode";
				mSG_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
				mSG_IDTL[4] = 0;
				mSG_IDTL[0, 4] = "DmName";
				mSG_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[5] = 0;
				mSG_IDTL[0, 5] = "DmColor";
				mSG_IDTL[6] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[6] = 3;
				mSG_IDTL[0, 6] = "DmSize";
				mSG_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[7] = 0;
				mSG_IDTL[0, 7] = "DmOrigin";
				mSG_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[8] = 0;
				mSG_IDTL[0, 8] = "DmRemark";
				mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[9] = 0;
				mSG_IDTL[0, 9] = "DmSfNo";
			}
			else
			{
				mSG_IDTL[3] = 0;
				mSG_IDTL[0, 3] = "DmCode";
				mSG_IDTL[4] = 0;
				mSG_IDTL[0, 4] = "DmName";
				mSG_IDTL[5] = 0;
				mSG_IDTL[0, 5] = "DmColor";
				mSG_IDTL[6] = 0;
				mSG_IDTL[0, 6] = "DmSize";
				mSG_IDTL[7] = 0;
				mSG_IDTL[0, 7] = "DmOrigin";
				mSG_IDTL[8] = 0;
				mSG_IDTL[0, 8] = "Remark";
				mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[9] = 0;
				mSG_IDTL[0, 9] = "DmSfNo";
			}
			mSG_IDTL[10] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "Pcs";
			mSG_IDTL[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "Weight";
			mSG_IDTL[12] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "Con%";
			mSG_IDTL[13] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[13] = 3;
			mSG_IDTL[0, 13] = "P/W";
			mSG_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "Rate";
			mSG_IDTL[15] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "ItAmt";
			mSG_IDTL[16] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "LbrRate";
			mSG_IDTL[17] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "LbrAmt";
			mSG_IDTL[18] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[18] = 7;
			mSG_IDTL[0, 18] = "NetAmt";
			mSG_IDTL[19] = 0;
			mSG_IDTL[0, 19] = "ConWt";
			mSG_IDTL[20] = 0;
			mSG_IDTL[0, 20] = "KrWt";
			mSG_IDTL[21] = 0;
			mSG_IDTL[0, 21] = "KrConWt";
			mSG_IDTL[22] = 0;
			mSG_IDTL[0, 22] = "ItType";
			mSG_IDTL[23] = 0;
			mSG_IDTL[0, 23] = "RowSrNo";
			mSG_IDTL.Row = 1;
			mSG_IDTL.Col = 0;
			((Control)TEXT_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_IDTL[DC_Main.M] = 0;
						}
						mSG_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Idtl();
			mSG_IDTL = null;
		}
	}

	private void CommPassAdd_Idtl()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL[mSG_IDTL.Row, 0] = Conversions.ToString(mSG_IDTL.Row);
		mSG_IDTL[mSG_IDTL.Row, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 57]));
		checked
		{
			if (mSG_IDTL.Row > 1)
			{
				DataView dataView = new DataView(DC_Main.RsClIdtl);
				if (dataView.Count > 0)
				{
					int num = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NEW_NAME = '" + mSG_IDTL[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							mSG_IDTL[mSG_IDTL.Row, DC_Main.M] = mSG_IDTL[mSG_IDTL.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG_IDTL = null;
		}
	}

	private void TEXT_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Invalid comparison between Unknown and I4
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Invalid comparison between Unknown and I4
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Invalid comparison between Unknown and I4
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = DtIdtl.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 23])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
						{
							DtIdtl.Rows.Remove(DtIdtl.Rows[i]);
							DtIdtl.AcceptChanges();
							break;
						}
					}
					int num2 = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_IDTL[mSG_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Idtl(1);
					TEXT_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_IDTL.Col = checked(mSG_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_IDTL.Col < 18)
				{
					mSG_IDTL.Col = checked(mSG_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_IDTL.Row > 1)
				{
					mSG_IDTL.Row = checked(mSG_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_IDTL.Row < mSG_IDTL.Rows - 1)
					{
						mSG_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_IDTL.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_IDTL).Visible = false;
							MSG.Col = 14;
							MSG_EnterCell(MSG, new EventArgs());
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_IDTL.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[7];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 0.0;
							DC_Main.ColWidth[4] = 0.0;
							DC_Main.ColWidth[5] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_IDTL.Text = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_IDTL[mSG_IDTL.Row, 22] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
							}
						}
						break;
					case 3:
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0 || mSG_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_IDTL.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.DM_NAME As ItemNameL,A.DM_CODE as ItCodeL,B.GR_NAME As GroupL FROM DM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.DM_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_IDTL.Text = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_CODE"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 18:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 18] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							MsgClearIdtl = true;
							mSG_IDTL.Rows += 1;
							mSG_IDTL.Row += 1;
							MsgClearIdtl = false;
							mSG_IDTL.Col = 1;
							CommPassAdd_Idtl();
						}
						else
						{
							mSG_IDTL.Row += 1;
							mSG_IDTL.Col = 1;
							((Control)TEXT_IDTL).Visible = true;
							((Control)TEXT_IDTL).Focus();
						}
						return;
					}
					if (mSG_IDTL.Col < mSG_IDTL.Cols - 1)
					{
						mSG_IDTL.Col += 1;
					}
					((Control)TEXT_IDTL).Visible = true;
					((Control)TEXT_IDTL).Focus();
				}
			}
		}
		mSG_IDTL = null;
	}

	private void MSG_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		checked
		{
			if (mSG_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_IDTL).Left = (int)Math.Round((double)((Control)mSG_IDTL).Left + (double)mSG_IDTL.CellLeft / 15.0);
				((Control)TEXT_IDTL).Top = (int)Math.Round((double)((Control)mSG_IDTL).Top + (double)mSG_IDTL.CellTop / 15.0);
				((Control)TEXT_IDTL).Width = (int)Math.Round((double)mSG_IDTL.CellWidth / 15.0);
				((Control)TEXT_IDTL).Height = (int)Math.Round((double)mSG_IDTL.CellHeight / 15.0);
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				((Control)TEXT_IDTL).Visible = true;
				MSG.Col = 29;
				((Control)TEXT_ENTRY).Visible = false;
				((TextBoxBase)TEXT_IDTL).SelectAll();
				((Control)TEXT_IDTL).Focus();
				mSG_IDTL = null;
			}
		}
	}

	private void MSG_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		checked
		{
			if (mSG_IDTL[mSG_IDTL.Col] == 0)
			{
				TEXT_IDTL.Text = "";
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_IDTL[mSG_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_IDTL.Col > 1)
						{
							mSG_IDTL.Col -= 1;
						}
					}
					else if (mSG_IDTL.Col < mSG_IDTL.Cols - 1)
					{
						mSG_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_IDTL.Row == 0) | (mSG_IDTL.CellWidth <= 0)) && mSG_IDTL[mSG_IDTL.Col] != 0)
			{
				((Control)TEXT_IDTL).Left = (int)Math.Round((double)((Control)mSG_IDTL).Left + (double)mSG_IDTL.CellLeft / 15.0);
				((Control)TEXT_IDTL).Top = (int)Math.Round((double)((Control)mSG_IDTL).Top + (double)mSG_IDTL.CellTop / 15.0);
				((Control)TEXT_IDTL).Width = (int)Math.Round((double)mSG_IDTL.CellWidth / 15.0);
				((Control)TEXT_IDTL).Height = (int)Math.Round((double)mSG_IDTL.CellHeight / 15.0);
				((Control)TEXT_IDTL).Visible = true;
				((TextBoxBase)TEXT_IDTL).ReadOnly = false;
				switch (MSG_IDTL.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_IDTL).MaxLength = 5;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_IDTL).MaxLength = 8;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 2:
				case 4:
					((TextBoxBase)TEXT_IDTL).MaxLength = 50;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_IDTL).MaxLength = 15;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 6:
				case 7:
				case 8:
				case 9:
					((TextBoxBase)TEXT_IDTL).MaxLength = 20;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 13:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 12:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 11:
				case 19:
				case 20:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				}
				mSG_IDTL = null;
				((TextBoxBase)TEXT_IDTL).SelectAll();
			}
		}
	}

	private void MSG_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_IDTL.Row != 0 && MSG_IDTL[MSG_IDTL.Col] != 0 && ((Control)TEXT_IDTL).Visible)
		{
			AxMSFlexGrid mSG_IDTL = MSG_IDTL;
			switch (MSG_IDTL.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 13:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 12:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 11:
			case 19:
			case 20:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			}
			mSG_IDTL = null;
		}
	}

	private void CommPassTotal_Idtl(int CRow)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 20]) == 0.0))
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 11]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0))
		{
			mSG_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 19] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0))
		{
			mSG_IDTL[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 20]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 21] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 13], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 11]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 13], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 14])))) != 0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0)
		{
			if (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0)
			{
				mSG_IDTL[CRow, 17] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else
			{
				mSG_IDTL[CRow, 17] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
			}
		}
		if (Conversion.Val(mSG_IDTL[CRow, 15]) + Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) + Conversion.Val(mSG_IDTL[CRow, 17])), "0.00");
		}
		checked
		{
			int num = mSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			while (DC_Main.M <= num)
			{
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 19]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 21]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 18]);
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 13] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 84] = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 13]), "0.000");
				MSG[MSG.Row, 14] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 13])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 42] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 43] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 42])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 29] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 51] = Strings.Format((object)num5, "0.00");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])) == Conversion.Val(mSG_IDTL[CRow, 23])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
					{
						flag = true;
						DtIdtl.Rows[i][0] = mSG_IDTL[CRow, 0];
						DtIdtl.Rows[i][1] = mSG_IDTL[CRow, 1];
						DtIdtl.Rows[i][2] = mSG_IDTL[CRow, 2];
						DtIdtl.Rows[i][3] = mSG_IDTL[CRow, 3];
						DtIdtl.Rows[i][4] = mSG_IDTL[CRow, 4];
						DtIdtl.Rows[i][5] = mSG_IDTL[CRow, 5];
						DtIdtl.Rows[i][6] = mSG_IDTL[CRow, 6];
						DtIdtl.Rows[i][7] = mSG_IDTL[CRow, 7];
						DtIdtl.Rows[i][8] = mSG_IDTL[CRow, 8];
						DtIdtl.Rows[i][9] = mSG_IDTL[CRow, 9];
						DtIdtl.Rows[i][10] = mSG_IDTL[CRow, 10];
						DtIdtl.Rows[i][11] = mSG_IDTL[CRow, 11];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][21] = mSG_IDTL[CRow, 21];
						DtIdtl.Rows[i][22] = mSG_IDTL[CRow, 22];
						DtIdtl.Rows[i][23] = mSG_IDTL[CRow, 23];
						break;
					}
				}
				if (!flag)
				{
					dr = DtIdtl.NewRow();
					dr[0] = mSG_IDTL[CRow, 0];
					dr[1] = mSG_IDTL[CRow, 1];
					dr[2] = mSG_IDTL[CRow, 2];
					dr[3] = mSG_IDTL[CRow, 3];
					dr[4] = mSG_IDTL[CRow, 4];
					dr[5] = mSG_IDTL[CRow, 5];
					dr[6] = mSG_IDTL[CRow, 6];
					dr[7] = mSG_IDTL[CRow, 7];
					dr[8] = mSG_IDTL[CRow, 8];
					dr[9] = mSG_IDTL[CRow, 9];
					dr[10] = mSG_IDTL[CRow, 10];
					dr[11] = mSG_IDTL[CRow, 11];
					dr[20] = mSG_IDTL[CRow, 20];
					dr[12] = mSG_IDTL[CRow, 12];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[16] = mSG_IDTL[CRow, 16];
					dr[17] = mSG_IDTL[CRow, 17];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[21] = mSG_IDTL[CRow, 21];
					dr[22] = mSG_IDTL[CRow, 22];
					dr[23] = mSG_IDTL[CRow, 23];
					DtIdtl.Rows.Add(dr);
				}
			}
			CommPassTotal();
			mSG_IDTL = null;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 107;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[3] = (int)Math.Round(850.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItCode";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			if (Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0)
			{
				mSG[2] = (int)Math.Round(1000.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "ItmLot";
			}
			else
			{
				mSG[2] = 0;
				mSG[2] = 0;
				mSG[0, 2] = "ItmLot";
			}
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Counter";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG[5] = (int)Math.Round(1000.0 * ColCon);
				mSG[5] = 0;
				mSG[0, 5] = "OrdNo";
			}
			else
			{
				mSG[5] = 0;
			}
			mSG[6] = (int)Math.Round(1300.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Design";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0)
			{
				mSG[8] = (int)Math.Round(1200.0 * ColCon);
				mSG[8] = 0;
				mSG[0, 8] = "Size";
			}
			else
			{
				mSG[8] = (int)Math.Round(800.0 * ColCon);
				mSG[8] = 0;
				mSG[0, 8] = "Size";
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				mSG[7] = (int)Math.Round(1200.0 * ColCon);
				mSG[7] = 0;
				mSG[0, 7] = "Style";
			}
			else
			{
				mSG[7] = 0;
			}
			mSG[9] = (int)Math.Round(900.0 * ColCon);
			mSG[9] = 0;
			mSG[0, 9] = "HuId";
			mSG[10] = (int)Math.Round(800.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "BagWt";
			mSG[11] = (int)Math.Round(700.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "Pcs";
			mSG[12] = (int)Math.Round(1000.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "GrWt";
			mSG[13] = (int)Math.Round(800.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "LsWt";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "NetWt";
			mSG[42] = (int)Math.Round(0.0 * ColCon);
			mSG[42] = 7;
			mSG[0, 42] = "KrOthWt";
			mSG[43] = (int)Math.Round(0.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "KrNwt";
			mSG[44] = (int)Math.Round(0.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "KrGht%";
			mSG[45] = (int)Math.Round(0.0 * ColCon);
			mSG[45] = 7;
			mSG[0, 45] = "KrGht";
			mSG[46] = (int)Math.Round(0.0 * ColCon);
			mSG[46] = 7;
			mSG[0, 46] = "KrTouch";
			mSG[47] = (int)Math.Round(0.0 * ColCon);
			mSG[47] = 7;
			mSG[0, 47] = "KrWst%";
			mSG[48] = (int)Math.Round(0.0 * ColCon);
			mSG[48] = 7;
			mSG[0, 48] = "KrFine";
			mSG[15] = (int)Math.Round(750.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "Ght%";
			mSG[16] = (int)Math.Round(875.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "FixGht%";
			mSG[17] = (int)Math.Round(850.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "GhtWt";
			mSG[18] = (int)Math.Round(850.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "Touch";
			mSG[19] = (int)Math.Round(850.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "West%";
			mSG[20] = (int)Math.Round(1000.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "Fine";
			mSG[24] = (int)Math.Round(800.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "Lbr%";
			mSG[25] = (int)Math.Round(750.0 * ColCon);
			mSG[25] = 3;
			mSG[0, 25] = "LType";
			mSG[26] = (int)Math.Round(900.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "LbrRate";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM619NBHM", false) == 0)
			{
				mSG[27] = (int)Math.Round(1100.0 * ColCon);
				mSG[27] = 7;
				mSG[0, 27] = "LbrAmt";
			}
			else
			{
				mSG[27] = (int)Math.Round(950.0 * ColCon);
				mSG[27] = 7;
				mSG[0, 27] = "LbrAmt";
			}
			mSG[31] = (int)Math.Round(850.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "LDisc%";
			mSG[32] = (int)Math.Round(950.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "LDiscAmt";
			mSG[33] = (int)Math.Round(1000.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "NtLbrAmt";
			mSG[28] = (int)Math.Round(950.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "GhtAmt";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM619NBHM", false) == 0)
			{
				mSG[29] = (int)Math.Round(1100.0 * ColCon);
				mSG[29] = 7;
				mSG[0, 29] = "OthAmt";
			}
			else
			{
				mSG[29] = (int)Math.Round(900.0 * ColCon);
				mSG[29] = 7;
				mSG[0, 29] = "OthAmt";
			}
			mSG[38] = (int)Math.Round(950.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "PrCost";
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				mSG[39] = (int)Math.Round(900.0 * ColCon);
				mSG[39] = 7;
				mSG[0, 39] = "MCom%";
				mSG[40] = (int)Math.Round(1000.0 * ColCon);
				mSG[40] = 7;
				mSG[0, 40] = "MComWt";
				mSG[106] = (int)Math.Round(800.0 * ColCon);
				mSG[106] = 7;
				mSG[0, 106] = "GrTch%";
			}
			else
			{
				mSG[39] = 0;
				mSG[40] = 0;
				mSG[106] = 0;
			}
			mSG[49] = (int)Math.Round(0.0 * ColCon);
			mSG[49] = 7;
			mSG[0, 49] = "KrLRate";
			mSG[50] = (int)Math.Round(0.0 * ColCon);
			mSG[50] = 7;
			mSG[0, 50] = "KrLAmt";
			mSG[51] = (int)Math.Round(0.0 * ColCon);
			mSG[51] = 7;
			mSG[0, 51] = "KrOthAmt";
			mSG[21] = (int)Math.Round(900.0 * ColCon);
			mSG[21] = 3;
			mSG[0, 21] = "RtWith";
			mSG[22] = (int)Math.Round(1000.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "ItRate";
			mSG[23] = (int)Math.Round(1100.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "ItAmt";
			mSG[53] = (int)Math.Round(0.0 * ColCon);
			mSG[53] = 7;
			mSG[0, 53] = "TagCost";
			mSG[54] = (int)Math.Round(0.0 * ColCon);
			mSG[54] = 7;
			mSG[0, 54] = "Margin";
			mSG[30] = (int)Math.Round(900.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Mrp";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG[34] = (int)Math.Round(900.0 * ColCon);
				mSG[34] = 3;
				mSG[0, 34] = "EmpCod";
			}
			else
			{
				mSG[34] = 0;
			}
			mSG[35] = (int)Math.Round(1100.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "TotAmt";
			mSG[36] = (int)Math.Round(600.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "Tax%";
			mSG[37] = (int)Math.Round(1100.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "NetAmt";
			mSG[55] = (int)Math.Round(0.0 * ColCon);
			mSG[55] = 3;
			mSG[0, 55] = "Image";
			mSG[41] = (int)Math.Round(0.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "KrCode";
			if (DC_Main.MsTagVchSrnoUpdate)
			{
				mSG[52] = (int)Math.Round(1500.0 * ColCon);
				mSG[52] = 3;
				mSG[0, 52] = "TagId";
			}
			else
			{
				mSG[52] = 0;
			}
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
			mSG[60] = 0;
			mSG[61] = 0;
			mSG[62] = 0;
			mSG[63] = 0;
			mSG[64] = 0;
			mSG[65] = 0;
			mSG[66] = 0;
			mSG[67] = 0;
			mSG[68] = 0;
			mSG[69] = 0;
			mSG[70] = 0;
			mSG[71] = 0;
			mSG[72] = 0;
			mSG[73] = 0;
			mSG[74] = 0;
			mSG[75] = 0;
			mSG[76] = 0;
			mSG[77] = 0;
			mSG[78] = 0;
			mSG[81] = 0;
			mSG[79] = 0;
			mSG[80] = 0;
			mSG[82] = 0;
			mSG[83] = 0;
			mSG[84] = 0;
			mSG[85] = 0;
			mSG[86] = 0;
			mSG[87] = 0;
			mSG[88] = 0;
			mSG[89] = 0;
			mSG[90] = 0;
			mSG[91] = 0;
			mSG[92] = 0;
			mSG[93] = 0;
			mSG[94] = 0;
			mSG[95] = 0;
			mSG[96] = 0;
			mSG[97] = 0;
			mSG[98] = 0;
			mSG[99] = 0;
			mSG[100] = 0;
			mSG[101] = 0;
			mSG[102] = 0;
			mSG[103] = 0;
			mSG[104] = 0;
			mSG[105] = 0;
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) != 0)
			{
				mSG[106] = 0;
			}
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'SALES' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG[DC_Main.M] = 0;
						}
						mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			MsgLastCol = 37;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num2 = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)
			{
				MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
			}
			MSG_TOT_FILL();
			mSG_TOT = null;
		}
	}

	private void MSG_TOT_FILL()
	{
		checked
		{
			if (!UpDown)
			{
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 6] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.000");
					mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.00");
					mSG_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 27]) + Conversion.Val(MSG[DC_Main.M, 27]))), "0.00");
					mSG_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 28]) + Conversion.Val(MSG[DC_Main.M, 28]))), "0.00");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
					mSG_TOT[0, 53] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 53]) + Conversion.Val(MSG[DC_Main.M, 53]))), "0.00");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.000");
					mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[DC_Main.M, 35]))), "0.00");
					mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");
					mSG_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 42]) + Conversion.Val(MSG[DC_Main.M, 42]))), "0.000");
					mSG_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 43]) + Conversion.Val(MSG[DC_Main.M, 43]))), "0.000");
					mSG_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 45]) + Conversion.Val(MSG[DC_Main.M, 45]))), "0.000");
					mSG_TOT[0, 48] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 48]) + Conversion.Val(MSG[DC_Main.M, 48]))), "0.000");
					mSG_TOT[0, 50] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 50]) + Conversion.Val(MSG[DC_Main.M, 50]))), "0.00");
					mSG_TOT[0, 51] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 51]) + Conversion.Val(MSG[DC_Main.M, 51]))), "0.00");
					mSG_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 38]) + Conversion.Val(MSG[DC_Main.M, 38]))), "0.00");
					mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 43]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 27]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			mSG.Row = mSG.Rows - 1;
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
			mSG[mSG.Row, 25] = DC_Main.MsLbrType;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 57] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 57] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 57]) + 1.0);
			}
			mSG[mSG.Row, 63] = "A";
			mSG[mSG.Row, 55] = "N";
			mSG[mSG.Row, 100] = "N";
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM349NEPK", false) == 0))
			{
				mSG[mSG.Row, 11] = Conversions.ToString(1);
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "AK014NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK017NSAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK027NSAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM469NPHM", false) == 0))
			{
				mSG[mSG.Row, 36] = "3.00";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0)
			{
				mSG[mSG.Row, 36] = "10.00";
			}
			mSG[mSG.Row, 93] = "N";
			mSG[mSG.Row, 101] = "N";
			mSG[mSG.Row, 21] = DC_Main.MsSlAmtType;
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				mSG[mSG.Row, 34] = DC_Main.MsUserEmpCode;
			}
			MSG_IDTL_CLEAR();
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM603NAHM", false) == 0 && mSG.Row > 1)
			{
				DataView dataView = new DataView(DC_Main.RsClDetl);
				if (dataView.Count > 0)
				{
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						dataView.RowFilter = "BOOK_NAME = 'SALES' AND COL_NEW_NAME = '" + mSG[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							mSG[mSG.Row, DC_Main.M] = mSG[mSG.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		UpDown = false;
		checked
		{
			if (mSG.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (MsgOldRow != MSG.Row)
				{
					MsgOldRow = 0;
				}
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
				((Control)TEXT_ENTRY).Focus();
				mSG = null;
			}
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (mSG[mSG.Col] == 0)
			{
				TEXT_ENTRY.Text = "";
				if ((mSG.Col != 4) & (mSG.Col != 6) & (mSG.Col != 8))
				{
					mSG[mSG.Row, mSG.Col] = "";
				}
				DC_Main.M = 1;
				while (mSG[mSG.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG.Col > 1)
						{
							mSG.Col -= 1;
						}
					}
					else if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (((mSG.Row == 0) | (mSG.CellWidth <= 0)) || MSG[MSG.Col] == 0)
			{
				return;
			}
			((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
			((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
			((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
			((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
			((Control)TEXT_ENTRY).Visible = true;
			((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
			switch (MSG.Col)
			{
			case 0:
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 34:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 2:
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 9:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 21:
			case 25:
			case 55:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 11:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 15:
			case 16:
			case 18:
			case 19:
			case 24:
			case 46:
			case 47:
			case 54:
			case 106:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 30:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if (((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)) && Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0 && ((Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VK163NEVK", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VS233NEBU", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "HM495NEKU", false) != 0)))
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 31:
			case 32:
			case 33:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if (((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)) && Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 22:
			case 23:
			case 26:
			case 27:
			case 28:
			case 29:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 49:
			case 50:
			case 51:
			case 53:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 12:
			case 13:
			case 14:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if (((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)) && Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 10:
			case 17:
			case 20:
			case 40:
			case 42:
			case 43:
			case 44:
			case 45:
			case 48:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 52:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			}
			mSG = null;
			((TextBoxBase)TEXT_ENTRY).SelectAll();
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (UpDown || MsgClear || MSG.Row == 0 || MSG[MSG.Col] == 0 || !((Control)TEXT_ENTRY).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG = MSG;
		switch (MSG.Col)
		{
		case 3:
		case 34:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 6:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			if (Operators.CompareString(MSG[MSG.Row, 1], "", false) == 0)
			{
				if (Operators.CompareString(MSG[MSG.Row, 6], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 6] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
				}
				else
				{
					DC_Main.MsImageNo = "";
				}
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			}
			break;
		case 0:
		case 1:
		case 2:
		case 4:
		case 5:
		case 7:
		case 8:
		case 9:
		case 41:
		case 55:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 21:
		case 25:
			if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
			{
				mSG[mSG.Row, 82] = Conversions.ToString(0);
			}
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			CommPassTotal();
			break;
		case 11:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			CommPassTotal();
			break;
		case 15:
		case 16:
		case 18:
		case 19:
		case 24:
		case 46:
		case 47:
		case 54:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 35:
		case 36:
			CommPassTotal();
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			break;
		case 22:
			if (Conversion.Val(mSG[mSG.Row, mSG.Col]) != Conversion.Val(TEXT_ENTRY.Text))
			{
				mSG[mSG.Row, 66] = Conversions.ToString(0);
			}
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 23:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 37:
		case 38:
		case 39:
		case 49:
		case 50:
		case 51:
		case 53:
		case 106:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 13:
		case 42:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 10:
		case 12:
		case 14:
		case 17:
		case 20:
		case 40:
		case 43:
		case 44:
		case 45:
		case 48:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal();
			break;
		case 52:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		}
		mSG = null;
	}

	private void CommPassTotal()
	{
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int digits = default(int);
		int digits2 = default(int);
		double num5 = default(double);
		string text = default(string);
		DataView dataView = default(DataView);
		int num6 = default(int);
		double num8 = default(double);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				object Value;
				DataRowView dataRowView;
				double num7;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 20007:
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
							goto IL_000f;
						case 4:
							goto IL_0014;
						case 5:
							goto IL_0043;
						case 6:
							goto IL_0047;
						case 7:
						case 8:
							goto IL_004f;
						case 9:
							goto IL_0059;
						case 10:
							goto IL_0082;
						case 11:
							goto IL_00db;
						case 12:
							goto IL_00f8;
						case 13:
							goto IL_011e;
						case 15:
						case 16:
						case 17:
						case 18:
						case 19:
							goto IL_015a;
						case 20:
							goto IL_0195;
						case 21:
							goto IL_01af;
						case 22:
							goto IL_01c9;
						case 23:
							goto IL_0201;
						case 24:
							goto IL_024f;
						case 25:
							goto IL_029d;
						case 26:
							goto IL_02b6;
						case 27:
							goto IL_02d0;
						case 28:
						case 29:
							goto IL_02ec;
						case 30:
							goto IL_0318;
						case 31:
							goto IL_036b;
						case 32:
							goto IL_03b9;
						case 33:
							goto IL_03d3;
						case 34:
						case 35:
						case 36:
							goto IL_0425;
						case 37:
							goto IL_043c;
						case 38:
							goto IL_0477;
						case 39:
							goto IL_04af;
						case 40:
							goto IL_04f8;
						case 41:
							goto IL_0512;
						case 42:
						case 43:
						case 44:
							goto IL_0530;
						case 45:
							goto IL_05b3;
						case 46:
							goto IL_05cd;
						case 47:
							goto IL_0605;
						case 48:
							goto IL_063d;
						case 49:
							goto IL_0695;
						case 50:
							goto IL_06cd;
						case 51:
							goto IL_06e6;
						case 53:
							goto IL_0707;
						case 54:
							goto IL_073f;
						case 55:
							goto IL_0777;
						case 56:
						case 57:
							goto IL_0793;
						case 58:
							goto IL_07f2;
						case 59:
							goto IL_080c;
						case 60:
							goto IL_0844;
						case 61:
							goto IL_089c;
						case 62:
							goto IL_08b5;
						case 52:
						case 63:
						case 64:
						case 65:
							goto IL_08d2;
						case 66:
							goto IL_090d;
						case 67:
							goto IL_0927;
						case 68:
							goto IL_0941;
						case 69:
							goto IL_0991;
						case 71:
							goto IL_09ef;
						case 72:
							goto IL_0a3f;
						case 70:
						case 73:
						case 74:
							goto IL_0a98;
						case 75:
						case 76:
							goto IL_0ad2;
						case 77:
							goto IL_0b25;
						case 78:
						case 79:
							goto IL_0b51;
						case 80:
						case 81:
							goto IL_0ba7;
						case 82:
							goto IL_0be2;
						case 83:
							goto IL_0bfc;
						case 84:
							goto IL_0c16;
						case 85:
							goto IL_0c30;
						case 86:
							goto IL_0c4a;
						case 87:
							goto IL_0c82;
						case 88:
							goto IL_0cd0;
						case 89:
							goto IL_0d08;
						case 90:
							goto IL_0d71;
						case 92:
							goto IL_0df9;
						case 91:
						case 93:
						case 94:
						case 95:
							goto IL_0e34;
						case 96:
							goto IL_0e6f;
						case 97:
							goto IL_0e89;
						case 98:
							goto IL_0ec1;
						case 99:
							goto IL_0f2a;
						case 100:
						case 101:
						case 102:
							goto IL_0fb2;
						case 103:
							goto IL_0fed;
						case 104:
							goto IL_1007;
						case 105:
							goto IL_103f;
						case 106:
							goto IL_10a8;
						case 107:
						case 108:
						case 109:
							goto IL_1130;
						case 110:
							goto IL_116f;
						case 111:
						case 112:
							goto IL_11bf;
						case 113:
							goto IL_11cd;
						case 114:
							goto IL_11d7;
						case 115:
							goto IL_11ef;
						case 116:
							goto IL_1221;
						case 117:
							goto IL_1245;
						case 118:
							goto IL_125f;
						case 121:
							goto IL_127a;
						case 119:
						case 120:
						case 122:
						case 123:
							goto IL_1285;
						case 124:
							goto IL_12a1;
						case 125:
							goto IL_12b9;
						case 126:
							goto IL_1322;
						case 127:
							goto IL_139c;
						case 128:
							goto IL_13c1;
						case 130:
							goto IL_1409;
						case 133:
							goto IL_142b;
						case 136:
							goto IL_144c;
						case 137:
							goto IL_1468;
						case 139:
							goto IL_1489;
						case 129:
						case 131:
						case 132:
						case 134:
						case 135:
						case 138:
						case 140:
						case 141:
							goto IL_14a7;
						case 142:
							goto IL_14d1;
						case 143:
						case 144:
							goto IL_14f0;
						case 145:
							goto IL_1568;
						case 146:
							goto IL_15a3;
						case 147:
							goto IL_15c1;
						case 149:
							goto IL_160f;
						case 151:
							goto IL_166c;
						case 153:
							goto IL_16d6;
						case 155:
							goto IL_1740;
						case 156:
							goto IL_176a;
						case 158:
							goto IL_17b2;
						case 148:
						case 150:
						case 152:
						case 154:
						case 157:
						case 159:
						case 160:
						case 161:
							goto IL_1810;
						case 162:
						case 163:
							goto IL_182e;
						case 164:
							goto IL_1848;
						case 165:
							goto IL_1906;
						case 167:
							goto IL_1954;
						case 169:
							goto IL_19b0;
						case 171:
							goto IL_1a19;
						case 173:
							goto IL_1a82;
						case 174:
							goto IL_1aac;
						case 176:
							goto IL_1af3;
						case 166:
						case 168:
						case 170:
						case 172:
						case 175:
						case 177:
						case 178:
						case 179:
							goto IL_1b50;
						case 180:
						case 181:
						case 182:
							goto IL_1b8f;
						case 183:
							goto IL_1bf1;
						case 184:
							goto IL_1c2c;
						case 185:
							goto IL_1c7f;
						case 187:
							goto IL_1cd9;
						case 186:
						case 188:
						case 189:
							goto IL_1d3f;
						case 190:
							goto IL_1d60;
						case 191:
							goto IL_1d8c;
						case 192:
							goto IL_1da8;
						case 193:
							goto IL_1dc4;
						case 194:
						case 195:
						case 196:
						case 197:
							goto IL_1de6;
						case 198:
							goto IL_1e0a;
						case 199:
							goto IL_1e3f;
						case 200:
							goto IL_1e66;
						case 201:
						case 202:
						case 203:
							goto IL_1e87;
						case 204:
							goto IL_1ee9;
						case 205:
							goto IL_1f25;
						case 207:
							goto IL_1f88;
						case 209:
							goto IL_1fe6;
						case 210:
							goto IL_2005;
						case 212:
							goto IL_2061;
						case 215:
							goto IL_20d6;
						case 217:
							goto IL_2154;
						case 219:
							goto IL_21af;
						case 206:
						case 208:
						case 211:
						case 213:
						case 214:
						case 216:
						case 218:
						case 220:
						case 221:
							goto IL_2220;
						case 222:
							goto IL_225b;
						case 224:
							goto IL_227e;
						case 225:
							goto IL_22c5;
						case 227:
							goto IL_2313;
						case 229:
							goto IL_2374;
						case 230:
							goto IL_2393;
						case 232:
							goto IL_23f2;
						case 235:
							goto IL_246a;
						case 237:
							goto IL_24e8;
						case 226:
						case 228:
						case 231:
						case 233:
						case 234:
						case 236:
						case 238:
						case 239:
							goto IL_2546;
						case 223:
						case 240:
						case 241:
						case 242:
							goto IL_2584;
						case 243:
							goto IL_25d7;
						case 244:
						case 245:
							goto IL_263e;
						case 246:
							goto IL_266d;
						case 247:
						case 248:
							goto IL_26ca;
						case 249:
							goto IL_26f6;
						case 250:
							goto IL_2716;
						case 251:
						case 252:
						case 253:
							goto IL_276b;
						case 254:
							goto IL_279d;
						case 255:
							goto IL_27f3;
						case 256:
							goto IL_2858;
						case 258:
							goto IL_28ad;
						case 257:
						case 259:
						case 260:
							goto IL_28e9;
						case 261:
							goto IL_2918;
						case 262:
						case 263:
							goto IL_2985;
						case 264:
							goto IL_29a1;
						case 265:
							goto IL_29bd;
						case 266:
							goto IL_29d9;
						case 267:
							goto IL_29f5;
						case 269:
							goto IL_2a18;
						case 270:
							goto IL_2a32;
						case 271:
							goto IL_2a68;
						case 272:
						case 273:
							goto IL_2a86;
						case 274:
							goto IL_2ab8;
						case 275:
							goto IL_2ae7;
						case 276:
							goto IL_2b49;
						case 277:
							goto IL_2bc1;
						case 278:
							goto IL_2bf0;
						case 283:
							goto IL_2c58;
						case 284:
							goto IL_2c8a;
						case 285:
							goto IL_2cc3;
						case 286:
							goto IL_2d0c;
						case 290:
							goto IL_2d79;
						case 291:
							goto IL_2dc2;
						case 279:
						case 280:
						case 281:
						case 282:
						case 287:
						case 288:
						case 289:
						case 292:
						case 293:
						case 294:
						case 295:
							goto IL_2e28;
						case 296:
							goto IL_2e5a;
						case 297:
							goto IL_2e76;
						case 298:
							goto IL_2e92;
						case 300:
						case 301:
							goto IL_2ecc;
						case 302:
							goto IL_2f19;
						case 304:
							goto IL_2f67;
						case 306:
							goto IL_2fc8;
						case 308:
							goto IL_3036;
						case 310:
							goto IL_30a4;
						case 311:
							goto IL_30c0;
						case 313:
							goto IL_310c;
						case 303:
						case 305:
						case 307:
						case 309:
						case 312:
						case 314:
						case 315:
						case 316:
							goto IL_316e;
						case 317:
						case 318:
							goto IL_31ab;
						case 319:
							goto IL_31e9;
						case 320:
							goto IL_3240;
						case 322:
							goto IL_328e;
						case 324:
							goto IL_32ef;
						case 325:
							goto IL_330e;
						case 327:
							goto IL_336d;
						case 330:
							goto IL_33e5;
						case 332:
							goto IL_3463;
						case 321:
						case 323:
						case 326:
						case 328:
						case 329:
						case 331:
						case 333:
						case 334:
							goto IL_34c1;
						case 335:
							goto IL_34fc;
						case 336:
							goto IL_3552;
						case 337:
							goto IL_35a5;
						case 339:
							goto IL_35f5;
						case 338:
						case 340:
						case 341:
						case 342:
						case 343:
						case 344:
						case 345:
							goto IL_3659;
						case 346:
							goto IL_3683;
						case 347:
						case 348:
							goto IL_3702;
						case 349:
							goto IL_372e;
						case 268:
						case 350:
						case 351:
						case 352:
							goto IL_37ae;
						case 353:
							goto IL_37da;
						case 354:
						case 355:
							goto IL_3817;
						case 356:
							goto IL_3831;
						case 357:
							goto IL_3867;
						case 358:
							goto IL_389d;
						case 359:
						case 360:
						case 361:
							goto IL_38bd;
						case 362:
							goto IL_38ef;
						case 363:
							goto IL_391c;
						case 364:
							goto IL_3938;
						case 365:
							goto IL_39a3;
						case 366:
							goto IL_39c5;
						case 367:
							goto IL_39f4;
						case 368:
						case 369:
							goto IL_3a65;
						case 371:
							goto IL_3ab3;
						case 373:
							goto IL_3b14;
						case 375:
							goto IL_3b82;
						case 377:
							goto IL_3bf0;
						case 378:
							goto IL_3c0c;
						case 380:
							goto IL_3c58;
						case 370:
						case 372:
						case 374:
						case 376:
						case 379:
						case 381:
						case 382:
						case 383:
							goto IL_3cba;
						case 385:
							goto IL_3cfc;
						case 386:
							goto IL_3d4c;
						case 384:
						case 387:
						case 388:
						case 389:
							goto IL_3dbd;
						case 390:
							goto IL_3e27;
						case 391:
							goto IL_3e75;
						case 393:
							goto IL_3ecc;
						case 394:
							goto IL_3f1d;
						case 395:
							goto IL_3f3c;
						case 397:
							goto IL_3f91;
						case 400:
							goto IL_3fff;
						case 401:
							goto IL_404d;
						case 403:
							goto IL_40ae;
						case 404:
							goto IL_40fc;
						case 406:
							goto IL_4151;
						case 392:
						case 396:
						case 398:
						case 399:
						case 402:
						case 405:
						case 407:
						case 408:
						case 409:
							goto IL_41bb;
						case 410:
							goto IL_4211;
						case 411:
							goto IL_423d;
						case 412:
						case 413:
							goto IL_429a;
						case 414:
							goto IL_42b4;
						case 415:
							goto IL_42e1;
						case 416:
							goto IL_4337;
						case 417:
							goto IL_4392;
						case 418:
							goto IL_43cd;
						case 419:
						case 420:
						case 421:
						case 422:
						case 423:
							goto IL_43f1;
						case 426:
							goto IL_4432;
						case 424:
						case 425:
						case 427:
						case 428:
							goto IL_446e;
						case 429:
							goto IL_4490;
						case 430:
							goto IL_44e6;
						case 431:
							goto IL_44f9;
						case 432:
							goto IL_4525;
						case 433:
							goto IL_452e;
						case 434:
							goto IL_4547;
						case 435:
							goto IL_459a;
						case 436:
							goto IL_45c2;
						case 437:
							goto IL_4616;
						case 439:
							goto IL_4666;
						case 440:
							goto IL_4682;
						case 438:
						case 441:
						case 442:
						case 443:
						case 444:
							goto IL_46f9;
						case 445:
							goto IL_46fc;
						case 446:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 14:
						case 299:
						case 447:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_4682:
					num2 = 440;
					val[val.Row, 40] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 39]) / 100.0), "0.000");
					goto IL_46f9;
					IL_46f9:
					val = null;
					goto IL_46fc;
					IL_4666:
					num2 = 439;
					val[val.Row, 106] = "100.00";
					goto IL_4682;
					IL_46fc:
					num2 = 445;
					MSG_TOT_FILL();
					break;
					IL_000b:
					num2 = 2;
					digits = 0;
					goto IL_000f;
					IL_000f:
					num2 = 3;
					digits2 = 0;
					goto IL_0014;
					IL_0014:
					num2 = 4;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM035NPDM", false) == 0) | (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0))
					{
						goto IL_0043;
					}
					goto IL_004f;
					IL_0043:
					num2 = 5;
					digits = 2;
					goto IL_0047;
					IL_0047:
					num2 = 6;
					digits2 = 2;
					goto IL_004f;
					IL_004f:
					num2 = 8;
					val = MSG;
					goto IL_0059;
					IL_0059:
					num2 = 9;
					if (Operators.CompareString(val[val.Row, 1], "", false) == 0)
					{
						goto IL_0082;
					}
					goto IL_015a;
					IL_0082:
					num2 = 10;
					if ((Operators.CompareString(DC_Main.MsNegativeStkSale, "N", false) == 0) & (Operators.CompareString(val[val.Row, 63], "A", false) == 0) & (Operators.CompareString(val[val.Row, 5], "", false) == 0))
					{
						goto IL_00db;
					}
					goto IL_015a;
					IL_00db:
					num2 = 11;
					if (Operators.CompareString(FormMainBook, "SL QUOT", false) != 0)
					{
						goto IL_00f8;
					}
					goto IL_015a;
					IL_00f8:
					num2 = 12;
					if (Conversion.Val(val[val.Row, 12]) > CurItGwtStk)
					{
						goto IL_011e;
					}
					goto IL_015a;
					IL_011e:
					num2 = 13;
					Interaction.MsgBox((object)("Negative Stock is Not Allow Curent Stock = " + Strings.Format((object)CurItGwtStk, "0.000") + " "), (MsgBoxStyle)0, (object)null);
					goto end_IL_0001_3;
					IL_015a:
					num2 = 19;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_0195;
					}
					goto IL_02ec;
					IL_0195:
					num2 = 20;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_01af;
					IL_01af:
					num2 = 21;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_01c9;
					IL_01c9:
					num2 = 22;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_0201;
					IL_0201:
					num2 = 23;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_024f;
					IL_024f:
					num2 = 24;
					val[val.Row, 43] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 42])), "0.000");
					goto IL_029d;
					IL_029d:
					num2 = 25;
					val[val.Row, 93] = "N";
					goto IL_02b6;
					IL_02b6:
					num2 = 26;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_02d0;
					IL_02d0:
					num2 = 27;
					val[val.Row, 105] = Conversions.ToString(0);
					goto IL_02ec;
					IL_02ec:
					num2 = 29;
					if ((Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0) & (val[10] != 0))
					{
						goto IL_0318;
					}
					goto IL_0425;
					IL_0318:
					num2 = 30;
					if ((Conversion.Val(val[val.Row, 10]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_036b;
					}
					goto IL_0425;
					IL_036b:
					num2 = 31;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_03b9;
					IL_03b9:
					num2 = 32;
					val[val.Row, 84] = Conversions.ToString(0);
					goto IL_03d3;
					IL_03d3:
					num2 = 33;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_0425;
					IL_0425:
					num2 = 36;
					if (val.Col == 13)
					{
						goto IL_043c;
					}
					goto IL_0530;
					IL_043c:
					num2 = 37;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 84]))
					{
						goto IL_0477;
					}
					goto IL_0530;
					IL_0477:
					num2 = 38;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_04af;
					IL_04af:
					num2 = 39;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(TEXT_ENTRY.Text)), "0.000");
					goto IL_04f8;
					IL_04f8:
					num2 = 40;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_0512;
					IL_0512:
					num2 = 41;
					val[val.Row, 105] = Conversions.ToString(0);
					goto IL_0530;
					IL_0530:
					num2 = 44;
					if ((Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 105])) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_05b3;
					}
					goto IL_0707;
					IL_05b3:
					num2 = 45;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_05cd;
					IL_05cd:
					num2 = 46;
					val[val.Row, 105] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_0605;
					IL_0605:
					num2 = 47;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_063d;
					IL_063d:
					num2 = 48;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 16]) / 100.0), "0.000");
					goto IL_0695;
					IL_0695:
					num2 = 49;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.000");
					goto IL_06cd;
					IL_06cd:
					num2 = 50;
					val[val.Row, 93] = "N";
					goto IL_06e6;
					IL_06e6:
					num2 = 51;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_08d2;
					IL_0707:
					num2 = 53;
					if (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 105]))
					{
						goto IL_073f;
					}
					goto IL_0793;
					IL_073f:
					num2 = 54;
					val[val.Row, 105] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_0777;
					IL_0777:
					num2 = 55;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_0793;
					IL_0793:
					num2 = 57;
					if ((Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 68])) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_07f2;
					}
					goto IL_08d2;
					IL_07f2:
					num2 = 58;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_080c;
					IL_080c:
					num2 = 59;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_0844;
					IL_0844:
					num2 = 60;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 15]) / 100.0), "0.000");
					goto IL_089c;
					IL_089c:
					num2 = 61;
					val[val.Row, 93] = "N";
					goto IL_08b5;
					IL_08b5:
					num2 = 62;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_08d2;
					IL_08d2:
					num2 = 65;
					if (Conversion.Val(val[val.Row, 17]) != Conversion.Val(val[val.Row, 69]))
					{
						goto IL_090d;
					}
					goto IL_0ad2;
					IL_090d:
					num2 = 66;
					val[val.Row, 28] = Conversions.ToString(0);
					goto IL_0927;
					IL_0927:
					num2 = 67;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0941;
					IL_0941:
					num2 = 68;
					if ((Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0991;
					}
					goto IL_09ef;
					IL_0991:
					num2 = 69;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 16]) / 100.0), "0.000");
					goto IL_0a98;
					IL_09ef:
					num2 = 71;
					if ((Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0a3f;
					}
					goto IL_0a98;
					IL_0a3f:
					num2 = 72;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 15]) / 100.0), "0.000");
					goto IL_0a98;
					IL_0a98:
					num2 = 74;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.000");
					goto IL_0ad2;
					IL_0ad2:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_0b25;
					}
					goto IL_0ba7;
					IL_0b25:
					num2 = 77;
					if (!(Conversion.Val((object)val[28]) >= 0.0))
					{
					}
					goto IL_0b51;
					IL_0b51:
					num2 = 79;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_0ba7;
					IL_0ba7:
					num2 = 81;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_0be2;
					}
					goto IL_0e34;
					IL_0be2:
					num2 = 82;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0bfc;
					IL_0bfc:
					num2 = 83;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_0c16;
					IL_0c16:
					num2 = 84;
					val[val.Row, 68] = Conversions.ToString(0);
					goto IL_0c30;
					IL_0c30:
					num2 = 85;
					val[val.Row, 105] = Conversions.ToString(0);
					goto IL_0c4a;
					IL_0c4a:
					num2 = 86;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
					goto IL_0c82;
					IL_0c82:
					num2 = 87;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_0cd0;
					IL_0cd0:
					num2 = 88;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_0d08;
					IL_0d08:
					num2 = 89;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0d71;
					}
					goto IL_0df9;
					IL_0d71:
					num2 = 90;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0e34;
					IL_0df9:
					num2 = 92;
					val[val.Row, 20] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
					goto IL_0e34;
					IL_0e34:
					num2 = 95;
					if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_0e6f;
					}
					goto IL_0fb2;
					IL_0e6f:
					num2 = 96;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_0e89;
					IL_0e89:
					num2 = 97;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0ec1;
					IL_0ec1:
					num2 = 98;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0f2a;
					}
					goto IL_0fb2;
					IL_0f2a:
					num2 = 99;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0fb2;
					IL_0fb2:
					num2 = 102;
					if (Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 71]))
					{
						goto IL_0fed;
					}
					goto IL_1130;
					IL_0fed:
					num2 = 103;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_1007;
					IL_1007:
					num2 = 104;
					val[val.Row, 71] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_103f;
					IL_103f:
					num2 = 105;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_10a8;
					}
					goto IL_1130;
					IL_10a8:
					num2 = 106;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_1130;
					IL_1130:
					num2 = 109;
					if (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) == 0.0)
					{
						goto IL_116f;
					}
					goto IL_11bf;
					IL_116f:
					num2 = 110;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])), "0.000");
					goto IL_11bf;
					IL_11bf:
					num2 = 112;
					num5 = 0.0;
					goto IL_11cd;
					IL_11cd:
					num2 = 113;
					text = "N";
					goto IL_11d7;
					IL_11d7:
					num2 = 114;
					if (val[21] > 0)
					{
						goto IL_11ef;
					}
					goto IL_127a;
					IL_11ef:
					num2 = 115;
					if (Operators.CompareString(val[val.Row, 102], val[val.Row, 21], false) != 0)
					{
						goto IL_1221;
					}
					goto IL_1285;
					IL_1221:
					num2 = 116;
					val[val.Row, 102] = val[val.Row, 21];
					goto IL_1245;
					IL_1245:
					num2 = 117;
					val[val.Row, 82] = Conversions.ToString(0);
					goto IL_125f;
					IL_125f:
					num2 = 118;
					text = val[val.Row, 21];
					goto IL_1285;
					IL_127a:
					num2 = 121;
					text = DC_Main.MsSlAmtType;
					goto IL_1285;
					IL_1285:
					num2 = 123;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_12a1;
					}
					goto IL_144c;
					IL_12a1:
					num2 = 124;
					if (val[20] != 0)
					{
						goto IL_12b9;
					}
					goto IL_142b;
					IL_12b9:
					num2 = 125;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_1322;
					}
					goto IL_1409;
					IL_1322:
					num2 = 126;
					num5 = Conversions.ToDouble(Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000"));
					goto IL_139c;
					IL_139c:
					num2 = 127;
					val[val.Row, 20] = Strings.Format((object)num5, "0.000");
					goto IL_13c1;
					IL_13c1:
					num2 = 128;
					val[val.Row, 23] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_14a7;
					IL_1409:
					num2 = 130;
					num5 = Conversion.Val(val[val.Row, 14]);
					goto IL_14a7;
					IL_142b:
					num2 = 133;
					num5 = Conversion.Val(val[val.Row, 14]);
					goto IL_14a7;
					IL_144c:
					num2 = 136;
					if (Operators.CompareString(text, "G", false) == 0)
					{
						goto IL_1468;
					}
					goto IL_1489;
					IL_1468:
					num2 = 137;
					num5 = Conversion.Val(val[val.Row, 12]);
					goto IL_14a7;
					IL_1489:
					num2 = 139;
					num5 = Conversion.Val(val[val.Row, 14]);
					goto IL_14a7;
					IL_14a7:
					num2 = 141;
					if (Operators.CompareString(val[val.Row, 21], "F", false) == 0)
					{
						goto IL_14d1;
					}
					goto IL_14f0;
					IL_14d1:
					num2 = 142;
					num5 = Conversion.Val(val[val.Row, 20]);
					goto IL_14f0;
					IL_14f0:
					num2 = 144;
					if ((Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 82])) & (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_1568;
					}
					goto IL_182e;
					IL_1568:
					num2 = 145;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_15a3;
					IL_15a3:
					num2 = 146;
					val[val.Row, 83] = Conversions.ToString(0);
					goto IL_15c1;
					IL_15c1:
					num2 = 147;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_166c;
					case "K":
						goto IL_16d6;
					default:
						goto IL_1740;
					}
					goto IL_160f;
					IL_1740:
					num2 = 155;
					if (Operators.CompareString(val[val.Row, 21], "F", false) == 0)
					{
						goto IL_176a;
					}
					goto IL_17b2;
					IL_176a:
					num2 = 156;
					val[val.Row, 23] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_1810;
					IL_17b2:
					num2 = 158;
					val[val.Row, 23] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_1810;
					IL_16d6:
					num2 = 153;
					val[val.Row, 23] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 22]) / 1000.0), digits), "0.00");
					goto IL_1810;
					IL_166c:
					num2 = 151;
					val[val.Row, 23] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 22]) / 10.0), digits), "0.00");
					goto IL_1810;
					IL_160f:
					num2 = 149;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 22]), digits), "0.00");
					goto IL_1810;
					IL_1810:
					num2 = 161;
					val[val.Row, 93] = "N";
					goto IL_182e;
					IL_182e:
					num2 = 163;
					if (val.Col == 23)
					{
						goto IL_1848;
					}
					goto IL_1b8f;
					IL_1848:
					num2 = 164;
					if ((Conversion.Val(val[val.Row, 22]) == 0.0) | ((Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 82])) & (Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 11]) != 0.0)))
					{
						goto IL_1906;
					}
					goto IL_1b8f;
					IL_1906:
					num2 = 165;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_19b0;
					case "K":
						goto IL_1a19;
					default:
						goto IL_1a82;
					}
					goto IL_1954;
					IL_1a82:
					num2 = 173;
					if (Operators.CompareString(val[val.Row, 21], "F", false) == 0)
					{
						goto IL_1aac;
					}
					goto IL_1af3;
					IL_1aac:
					num2 = 174;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_1b50;
					IL_1af3:
					num2 = 176;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / num5 + Conversion.Val(val[val.Row, 17]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1b50;
					IL_1a19:
					num2 = 171;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1b50;
					IL_19b0:
					num2 = 169;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 17])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1b50;
					IL_1954:
					num2 = 167;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1b50;
					IL_1b50:
					num2 = 179;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1b8f;
					IL_1b8f:
					num2 = 182;
					if ((Conversion.Val(val[val.Row, 24]) != Conversion.Val(val[val.Row, 83])) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_1bf1;
					}
					goto IL_1de6;
					IL_1bf1:
					num2 = 183;
					val[val.Row, 83] = Strings.Format((object)Conversion.Val(val[val.Row, 24]), "0.00");
					goto IL_1c2c;
					IL_1c2c:
					num2 = 184;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM199NEPK", false) == 0) & (ToDayGlRate != 0.0) & (Operators.CompareString(val[val.Row, 59], "G", false) == 0))
					{
						goto IL_1c7f;
					}
					goto IL_1cd9;
					IL_1c7f:
					num2 = 185;
					val[val.Row, 26] = Strings.Format((object)Math.Round(ToDayGlRate * Conversion.Val(val[val.Row, 24]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1d3f;
					IL_1cd9:
					num2 = 187;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * Conversion.Val(val[val.Row, 24]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1d3f;
					IL_1d3f:
					num2 = 189;
					if (0u - ((val.Col == 24) ? 1u : 0u) != 0)
					{
						goto IL_1d60;
					}
					goto IL_1de6;
					IL_1d60:
					num2 = 190;
					if (Conversion.Val(val[val.Row, 24]) == 0.0)
					{
						goto IL_1d8c;
					}
					goto IL_1de6;
					IL_1d8c:
					num2 = 191;
					val[val.Row, 83] = "";
					goto IL_1da8;
					IL_1da8:
					num2 = 192;
					val[val.Row, 26] = "";
					goto IL_1dc4;
					IL_1dc4:
					num2 = 193;
					val[val.Row, 27] = "";
					goto IL_1de6;
					IL_1de6:
					num2 = 197;
					if ((val.Col == 25) & (val[25] != 0))
					{
						goto IL_1e0a;
					}
					goto IL_1e87;
					IL_1e0a:
					num2 = 198;
					if (Operators.CompareString(val[val.Row, 25], val[val.Row, 85], false) != 0)
					{
						goto IL_1e3f;
					}
					goto IL_1e87;
					IL_1e3f:
					num2 = 199;
					val[val.Row, 85] = val[val.Row, 25];
					goto IL_1e66;
					IL_1e66:
					num2 = 200;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_1e87;
					IL_1e87:
					num2 = 203;
					if ((Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 76]) != Conversion.Val(val[val.Row, 26])))
					{
						goto IL_1ee9;
					}
					goto IL_227e;
					IL_1ee9:
					num2 = 204;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_1f25;
					IL_1f25:
					num2 = 205;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_1fe6;
					case "K":
						goto IL_20d6;
					case "G":
						goto IL_2154;
					default:
						goto IL_21af;
					}
					goto IL_1f88;
					IL_21af:
					num2 = 219;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_2220;
					IL_2154:
					num2 = 217;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_2220;
					IL_20d6:
					num2 = 215;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 26]) / 1000.0), digits2), "0.00");
					goto IL_2220;
					IL_1fe6:
					num2 = 209;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_2005;
					}
					goto IL_2061;
					IL_2005:
					num2 = 210;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_2220;
					IL_2061:
					num2 = 212;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_2220;
					IL_1f88:
					num2 = 207;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 26]), digits2), "0.00");
					goto IL_2220;
					IL_2220:
					num2 = 221;
					val[val.Row, 77] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_225b;
					IL_225b:
					num2 = 222;
					val[val.Row, 93] = "N";
					goto IL_2584;
					IL_227e:
					num2 = 224;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
					{
						goto IL_22c5;
					}
					goto IL_2584;
					IL_22c5:
					num2 = 225;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_2374;
					case "K":
						goto IL_246a;
					default:
						goto IL_24e8;
					}
					goto IL_2313;
					IL_24e8:
					num2 = 237;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12]), DC_Main.MsLbrRof), "0.00");
					goto IL_2546;
					IL_246a:
					num2 = 235;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2546;
					IL_2374:
					num2 = 229;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_2393;
					}
					goto IL_23f2;
					IL_2393:
					num2 = 230;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 14]), DC_Main.MsLbrRof), "0.00");
					goto IL_2546;
					IL_23f2:
					num2 = 232;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])), DC_Main.MsLbrRof), "0.00");
					goto IL_2546;
					IL_2313:
					num2 = 227;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_2546;
					IL_2546:
					num2 = 239;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_2584;
					IL_2584:
					num2 = 242;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 27]) != 0.0))
					{
						goto IL_25d7;
					}
					goto IL_263e;
					IL_25d7:
					num2 = 243;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) * Conversion.Val(val[val.Row, 31]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_263e;
					IL_263e:
					num2 = 245;
					if (Conversion.Val(val[val.Row, 32]) != 0.0)
					{
						goto IL_266d;
					}
					goto IL_26ca;
					IL_266d:
					num2 = 246;
					val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) - Conversion.Val(val[val.Row, 32]), DC_Main.MsLbrRof), "0.00");
					goto IL_26ca;
					IL_26ca:
					num2 = 248;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_26f6;
					}
					goto IL_276b;
					IL_26f6:
					num2 = 249;
					if (Operators.CompareString(EntryMode, "A", false) == 0)
					{
						goto IL_2716;
					}
					goto IL_276b;
					IL_2716:
					num2 = 250;
					val[val.Row, 38] = Strings.Format((object)(Conversion.Val(val[val.Row, 50]) + Conversion.Val(val[val.Row, 51])), "0.0");
					goto IL_276b;
					IL_276b:
					num2 = 253;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_279d;
					}
					goto IL_2a18;
					IL_279d:
					num2 = 254;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 30]) != 0.0))
					{
						goto IL_27f3;
					}
					goto IL_28ad;
					IL_27f3:
					num2 = 255;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 30]) * Conversion.Val(val[val.Row, 31]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2858;
					IL_2858:
					num2 = 256;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 30]) - Conversion.Val(val[val.Row, 32])), "0.00");
					goto IL_28e9;
					IL_28ad:
					num2 = 258;
					val[val.Row, 35] = Strings.Format((object)Conversion.Val(val[val.Row, 30]), "0.00");
					goto IL_28e9;
					IL_28e9:
					num2 = 260;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_2918;
					}
					goto IL_2985;
					IL_2918:
					num2 = 261;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 35]) / (Conversion.Val(val[val.Row, 36]) + 100.0) * 100.0, digits), "0.00");
					goto IL_2985;
					IL_2985:
					num2 = 263;
					val[val.Row, 22] = "";
					goto IL_29a1;
					IL_29a1:
					num2 = 264;
					val[val.Row, 23] = "";
					goto IL_29bd;
					IL_29bd:
					num2 = 265;
					val[val.Row, 27] = "";
					goto IL_29d9;
					IL_29d9:
					num2 = 266;
					val[val.Row, 26] = "";
					goto IL_29f5;
					IL_29f5:
					num2 = 267;
					val[val.Row, 29] = "";
					goto IL_37ae;
					IL_2a18:
					num2 = 269;
					if (val.Col == 35)
					{
						goto IL_2a32;
					}
					goto IL_3659;
					IL_2a32:
					num2 = 270;
					if (Conversion.Val(val[val.Row, 35]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2a68;
					}
					goto IL_2a86;
					IL_2a68:
					num2 = 271;
					val[val.Row, 93] = "N";
					goto IL_2a86;
					IL_2a86:
					num2 = 273;
					if (Conversion.Val(val[val.Row, 32]) != 0.0)
					{
						goto IL_2ab8;
					}
					goto IL_2c58;
					IL_2ab8:
					num2 = 274;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_2ae7;
					}
					goto IL_2e28;
					IL_2ae7:
					num2 = 275;
					if (Conversion.Val(TEXT_ENTRY.Text) < Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 27]))
					{
						goto IL_2b49;
					}
					goto IL_2e28;
					IL_2b49:
					num2 = 276;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 27]) - Conversion.Val(TEXT_ENTRY.Text)), "0.00");
					goto IL_2bc1;
					IL_2bc1:
					num2 = 277;
					if (Conversion.Val(val[val.Row, 31]) != 0.0)
					{
						goto IL_2bf0;
					}
					goto IL_2e28;
					IL_2bf0:
					num2 = 278;
					val[val.Row, 31] = Strings.Format((object)(Conversion.Val(val[val.Row, 32]) * 100.0 / Conversion.Val(val[val.Row, 27])), "0.00");
					goto IL_2e28;
					IL_2c58:
					num2 = 283;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_2c8a;
					}
					goto IL_2d79;
					IL_2c8a:
					num2 = 284;
					if (Conversion.Val(val[val.Row, 35]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2cc3;
					}
					goto IL_2e28;
					IL_2cc3:
					num2 = 285;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]))
					{
						goto IL_2d0c;
					}
					goto IL_2e28;
					IL_2d0c:
					num2 = 286;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2e28;
					IL_2d79:
					num2 = 290;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]))
					{
						goto IL_2dc2;
					}
					goto IL_2e28;
					IL_2dc2:
					num2 = 291;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2e28;
					IL_2e28:
					num2 = 295;
					if (Conversion.Val(val[val.Row, 27]) <= 0.0)
					{
						goto IL_2e5a;
					}
					goto IL_31ab;
					IL_2e5a:
					num2 = 296;
					val[val.Row, 27] = "";
					goto IL_2e76;
					IL_2e76:
					num2 = 297;
					val[val.Row, 26] = "";
					goto IL_2e92;
					IL_2e92:
					num2 = 298;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM240NPPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0))
					{
						goto end_IL_0001_3;
					}
					goto IL_2ecc;
					IL_2ecc:
					num2 = 301;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 29])), "0.00");
					goto IL_2f19;
					IL_2f19:
					num2 = 302;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_2fc8;
					case "K":
						goto IL_3036;
					default:
						goto IL_30a4;
					}
					goto IL_2f67;
					IL_30a4:
					num2 = 310;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_30c0;
					}
					goto IL_310c;
					IL_30c0:
					num2 = 311;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_316e;
					IL_310c:
					num2 = 313;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])), DC_Main.MsItmRateRof), "0.00");
					goto IL_316e;
					IL_3036:
					num2 = 308;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_316e;
					IL_2fc8:
					num2 = 306;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_316e;
					IL_2f67:
					num2 = 304;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_316e;
					IL_316e:
					num2 = 316;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_31ab;
					IL_31ab:
					num2 = 318;
					if (Conversion.Val(val[val.Row, 27]) != Conversion.Val(val[val.Row, 77]))
					{
						goto IL_31e9;
					}
					goto IL_3659;
					IL_31e9:
					num2 = 319;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 26]) != 0.0))
					{
						goto IL_3240;
					}
					goto IL_3659;
					IL_3240:
					num2 = 320;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_32ef;
					case "K":
						goto IL_33e5;
					default:
						goto IL_3463;
					}
					goto IL_328e;
					IL_3463:
					num2 = 332;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12]), DC_Main.MsLbrRof), "0.00");
					goto IL_34c1;
					IL_33e5:
					num2 = 330;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_34c1;
					IL_32ef:
					num2 = 324;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_330e;
					}
					goto IL_336d;
					IL_330e:
					num2 = 325;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 14]), DC_Main.MsLbrRof), "0.00");
					goto IL_34c1;
					IL_336d:
					num2 = 327;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])), DC_Main.MsLbrRof), "0.00");
					goto IL_34c1;
					IL_328e:
					num2 = 322;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_34c1;
					IL_34c1:
					num2 = 334;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_34fc;
					IL_34fc:
					num2 = 335;
					if ((Conversion.Val(val[val.Row, 24]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_3552;
					}
					goto IL_3659;
					IL_3552:
					num2 = 336;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM199NEPK", false) == 0) & (ToDayGlRate != 0.0) & (Operators.CompareString(val[val.Row, 59], "G", false) == 0))
					{
						goto IL_35a5;
					}
					goto IL_35f5;
					IL_35a5:
					num2 = 337;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / ToDayGlRate), "0.000");
					goto IL_3659;
					IL_35f5:
					num2 = 339;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / Conversion.Val(val[val.Row, 22])), "0.000");
					goto IL_3659;
					IL_3659:
					num2 = 345;
					if (Operators.CompareString(val[val.Row, 93], "N", false) == 0)
					{
						goto IL_3683;
					}
					goto IL_3702;
					IL_3683:
					num2 = 346;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 32])), "0.00");
					goto IL_3702;
					IL_3702:
					num2 = 348;
					if (Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_372e;
					}
					goto IL_37ae;
					IL_372e:
					num2 = 349;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 32])), "0.00");
					goto IL_37ae;
					IL_37ae:
					num2 = 352;
					if (Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_37da;
					}
					goto IL_3817;
					IL_37da:
					num2 = 353;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");
					goto IL_3817;
					IL_3817:
					num2 = 355;
					if (val.Col == 36)
					{
						goto IL_3831;
					}
					goto IL_38bd;
					IL_3831:
					num2 = 356;
					if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(val[val.Row, 36]))
					{
						goto IL_3867;
					}
					goto IL_38bd;
					IL_3867:
					num2 = 357;
					val[val.Row, 36] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
					goto IL_389d;
					IL_389d:
					num2 = 358;
					val[val.Row, 93] = "N";
					goto IL_38bd;
					IL_38bd:
					num2 = 361;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_38ef;
					}
					goto IL_4432;
					IL_38ef:
					num2 = 362;
					if (Operators.CompareString(val[val.Row, 93], "N", false) == 0)
					{
						goto IL_391c;
					}
					goto IL_446e;
					IL_391c:
					num2 = 363;
					val[val.Row, 93] = "Y";
					goto IL_3938;
					IL_3938:
					num2 = 364;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 35]) / (Conversion.Val(val[val.Row, 36]) + 100.0) * 100.0, digits), "0.00");
					goto IL_39a3;
					IL_39a3:
					num2 = 365;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
					{
						goto IL_39c5;
					}
					goto IL_3cfc;
					IL_39c5:
					num2 = 366;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_39f4;
					}
					goto IL_3a65;
					IL_39f4:
					num2 = 367;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) - Conversion.Val(val[val.Row, 27]) - Conversion.Val(val[val.Row, 29]), digits2), "0.00");
					goto IL_3a65;
					IL_3a65:
					num2 = 369;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_3b14;
					case "K":
						goto IL_3b82;
					default:
						goto IL_3bf0;
					}
					goto IL_3ab3;
					IL_3bf0:
					num2 = 377;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_3c0c;
					}
					goto IL_3c58;
					IL_3c0c:
					num2 = 378;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_3cba;
					IL_3c58:
					num2 = 380;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])), DC_Main.MsItmRateRof), "0.00");
					goto IL_3cba;
					IL_3b82:
					num2 = 375;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3cba;
					IL_3b14:
					num2 = 373;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (num5 + Conversion.Val(val[val.Row, 17])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3cba;
					IL_3ab3:
					num2 = 371;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_3cba;
					IL_3cba:
					num2 = 383;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_3dbd;
					IL_3cfc:
					num2 = 385;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 32]) == 0.0))
					{
						goto IL_3d4c;
					}
					goto IL_3dbd;
					IL_3d4c:
					num2 = 386;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) - Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 29]), digits2), "0.00");
					goto IL_3dbd;
					IL_3dbd:
					num2 = 389;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & ((Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0) | (Conversion.Val(val[val.Row, 26]) != 0.0)))
					{
						goto IL_3e27;
					}
					goto IL_41bb;
					IL_3e27:
					num2 = 390;
					if ((Operators.CompareString(val[val.Row, 25], "P", false) == 0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_3e75;
					}
					goto IL_3ecc;
					IL_3e75:
					num2 = 391;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 11])), "0.00");
					goto IL_41bb;
					IL_3ecc:
					num2 = 393;
					if ((Operators.CompareString(val[val.Row, 25], "N", false) == 0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_3f1d;
					}
					goto IL_3fff;
					IL_3f1d:
					num2 = 394;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_3f3c;
					}
					goto IL_3f91;
					IL_3f3c:
					num2 = 395;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 14])), "0.00");
					goto IL_41bb;
					IL_3f91:
					num2 = 397;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17]))), "0.00");
					goto IL_41bb;
					IL_3fff:
					num2 = 400;
					if ((Operators.CompareString(val[val.Row, 25], "K", false) == 0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_404d;
					}
					goto IL_40ae;
					IL_404d:
					num2 = 401;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12]) * 1000.0), "0.00");
					goto IL_41bb;
					IL_40ae:
					num2 = 403;
					if ((Operators.CompareString(val[val.Row, 25], "G", false) == 0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_40fc;
					}
					goto IL_4151;
					IL_40fc:
					num2 = 404;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / Conversion.Val(val[val.Row, 12])), "0.00");
					goto IL_41bb;
					IL_4151:
					num2 = 406;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17]))), "0.00");
					goto IL_41bb;
					IL_41bb:
					num2 = 409;
					if ((Conversion.Val(val[val.Row, 24]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_4211;
					}
					goto IL_43f1;
					IL_4211:
					num2 = 410;
					if (Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_423d;
					}
					goto IL_429a;
					IL_423d:
					num2 = 411;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / Conversion.Val(val[val.Row, 22])), "0.00");
					goto IL_429a;
					IL_429a:
					num2 = 413;
					if (val.Col == 36)
					{
						goto IL_42b4;
					}
					goto IL_43f1;
					IL_42b4:
					num2 = 414;
					if (Conversion.Val(TEXT_ENTRY.Text) != 0.0)
					{
						goto IL_42e1;
					}
					goto IL_43f1;
					IL_42e1:
					num2 = 415;
					if ((Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_4337;
					}
					goto IL_43f1;
					IL_4337:
					num2 = 416;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) * 100.0 / Conversion.Val(val[val.Row, 22])), "0.00");
					goto IL_4392;
					IL_4392:
					num2 = 417;
					val[val.Row, 83] = Strings.Format((object)Conversion.Val(val[val.Row, 24]), "0.00");
					goto IL_43cd;
					IL_43cd:
					num2 = 418;
					val[val.Row, 93] = "Y";
					goto IL_43f1;
					IL_43f1:
					num2 = 423;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_446e;
					IL_4432:
					num2 = 426;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");
					goto IL_446e;
					IL_446e:
					num2 = 428;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						goto IL_4490;
					}
					goto IL_46f9;
					IL_4490:
					num2 = 429;
					if ((Conversion.Val(val[val.Row, 39]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_44e6;
					}
					goto IL_46f9;
					IL_44e6:
					num2 = 430;
					dataView = new DataView(RsGrTch);
					goto IL_44f9;
					IL_44f9:
					num2 = 431;
					dataView.RowFilter = "IT_CODE = '" + val[val.Row, 3] + "'";
					goto IL_4525;
					IL_4525:
					num2 = 432;
					num6 = 0;
					goto IL_452e;
					IL_452e:
					num2 = 433;
					if (dataView.Count > 0)
					{
						goto IL_4547;
					}
					goto IL_4666;
					IL_4547:
					num2 = 434;
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView[0])["MELTING_PRC"]);
					num7 = DC_Main.Fnv(ref Value);
					dataRowView["MELTING_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					num8 = Conversions.ToDouble(Strings.Format((object)num7, "0.00"));
					goto IL_459a;
					IL_459a:
					num2 = 435;
					val[val.Row, 106] = Strings.Format((object)num8, "0.00");
					goto IL_45c2;
					IL_45c2:
					num2 = 436;
					num6 = Conversions.ToInteger(Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 17])) * num8 / 100.0), "0.000"));
					goto IL_4616;
					IL_4616:
					num2 = 437;
					val[val.Row, 40] = Strings.Format((object)((double)num6 * Conversion.Val(val[val.Row, 39]) / 100.0), "0.000");
					goto IL_46f9;
					end_IL_0001_2:
					break;
				}
				num2 = 446;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 20007;
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

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Invalid comparison between Unknown and I4
		//IL_223f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2242: Invalid comparison between Unknown and I4
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Invalid comparison between Unknown and I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2254: Unknown result type (might be due to invalid IL or missing references)
		//IL_2256: Invalid comparison between Unknown and I4
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_2268: Unknown result type (might be due to invalid IL or missing references)
		//IL_226b: Invalid comparison between Unknown and I4
		//IL_2120: Unknown result type (might be due to invalid IL or missing references)
		//IL_22bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_22bf: Invalid comparison between Unknown and I4
		//IL_2338: Unknown result type (might be due to invalid IL or missing references)
		//IL_233b: Invalid comparison between Unknown and I4
		//IL_23c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c7: Invalid comparison between Unknown and I4
		//IL_2457: Unknown result type (might be due to invalid IL or missing references)
		//IL_245a: Invalid comparison between Unknown and I4
		//IL_1dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_5844: Unknown result type (might be due to invalid IL or missing references)
		//IL_64fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_6903: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_54a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_6fcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_6673: Unknown result type (might be due to invalid IL or missing references)
		//IL_69c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d86: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f4b: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x49 & (0 - (e.Control ? 1 : 0))))
		{
			if (mSG.Col == 3)
			{
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
			}
			if (mSG.Col == 11)
			{
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((Operators.CompareString(UserDelete, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
			{
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				return;
			}
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				if (Operators.CompareString(mSG[mSG.Row, 78], "", false) != 0)
				{
					DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 79] + "' AND CO_BOOK = '" + mSG[mSG.Row, 80] + "' AND VCH_NO = '" + mSG[mSG.Row, 78] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 81])) + " ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + mSG[mSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 52])) + " ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APP_TRFR = 'R' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + mSG[mSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 52])) + " ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 57]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][23])) == Conversion.Val(mSG[mSG.Row, 57]))
						{
							list.Add(DtIdtl.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						DtIdtl.Rows.Remove(item);
						DtIdtl.AcceptChanges();
					}
					int num3 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num3)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					if (mSG.Row == mSG.Rows - 1)
					{
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							mSG[mSG.Row, 57] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 57] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 57]) + 1.0);
						}
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			checked
			{
				if (mSG.Col == 1)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.ORD_NO As OrdNoL,D.AC_NAME As AcNameL,A.TAG_NO AS TagNoL,A.DESIGN_NO AS DesignNoL,C.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.ORD_YRCD As OrdYrCdL,A.ORD_DBCD As OrdDbCdL,A.ORD_SRNO As OrdSrNoL,B.TAG_STK_LESS As TagStkLessM From ((BAR_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.ORD_YRCD = B.CO_YEAR AND A.ORD_DBCD = B.CO_BOOK AND A.ORD_NO = B.VCH_NO AND A.ORD_SRNO = B.OLD_SRNO)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE =  C.IT_CODE)  LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.LC_CODE = '" + DC_Main.MLc_code + "' and A.ORD_NO <> '' AND B.TAG_SALE = 'N' AND A.ORD_AC = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)"  ORDER BY A.ORD_NO,A.TAG_NO"));
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[15];
					DC_Main.ColWidth[0] = 90.0;
					DC_Main.ColWidth[1] = 275.0;
					DC_Main.ColWidth[2] = 110.0;
					DC_Main.ColWidth[3] = 100.0;
					DC_Main.ColWidth[4] = 200.0;
					DC_Main.ColWidth[5] = 80.0;
					DC_Main.ColWidth[6] = 100.0;
					DC_Main.ColWidth[7] = 100.0;
					DC_Main.ColWidth[8] = 110.0;
					DC_Main.ColWidth[9] = 0.0;
					DC_Main.ColWidth[10] = 0.0;
					DC_Main.ColWidth[11] = 0.0;
					DC_Main.ColWidth[12] = 0.0;
					DC_Main.ColWidth[13] = 100.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) == 0)
					{
						TEXT_ENTRY.Text = "";
						mSG[mSG.Row, 5] = "";
						mSG[mSG.Row, 94] = "";
						mSG[mSG.Row, 95] = "";
						mSG[mSG.Row, 96] = "";
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					TEXT_ENTRY.Text = DC_Main.ColValue[2];
					if (Operators.CompareString(DC_Main.ColValue[13], "Y", false) != 0)
					{
						int num4 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num4)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 5] = DC_Main.ColValue[0];
						mSG[mSG.Row, 62] = DC_Main.ColValue[4];
						mSG[mSG.Row, 75] = DC_Main.ColValue[4];
						tItDesc.Text = DC_Main.ColValue[4];
						mSG[mSG.Row, 3] = DC_Main.ColValue[5];
						mSG[mSG.Row, 6] = DC_Main.ColValue[3];
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
						mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
						mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
						mSG[mSG.Row, 52] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[9]));
						mSG[mSG.Row, 94] = DC_Main.ColValue[10];
						mSG[mSG.Row, 95] = DC_Main.ColValue[11];
						mSG[mSG.Row, 96] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					DC_Main.i = 0;
					DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.ColValue[10] + "' AND CO_BOOK = '" + DC_Main.ColValue[11] + "' AND VCH_NO = '" + DC_Main.ColValue[0] + "' AND OLD_SRNO = '" + DC_Main.ColValue[12] + "'";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (RsDetl.Rows.Count > 0)
					{
						int num5 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num5)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 5] = DC_Main.ColValue[0];
						mSG[mSG.Row, 94] = DC_Main.ColValue[10];
						mSG[mSG.Row, 95] = DC_Main.ColValue[11];
						mSG[mSG.Row, 96] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[mSG.Row, 62] = DC_Main.ColValue[4];
						mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						mSG[mSG.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						mSG[mSG.Row, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						mSG[mSG.Row, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID"], (object)""));
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
						mSG[mSG.Row, 11] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[mSG.Row, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
						mSG[mSG.Row, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
						mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[mSG.Row, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[mSG.Row, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						mSG[mSG.Row, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG[mSG.Row, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						mSG[mSG.Row, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG[mSG.Row, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG[mSG.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						mSG[mSG.Row, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[mSG.Row, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[mSG.Row, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[mSG.Row, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[mSG.Row, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[mSG.Row, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[mSG.Row, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
						mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						mSG[mSG.Row, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
						mSG[mSG.Row, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
						mSG[mSG.Row, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
						mSG[mSG.Row, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
						mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						mSG[mSG.Row, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[mSG.Row, 86] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID2"], (object)""));
						mSG[mSG.Row, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID3"], (object)""));
						mSG[mSG.Row, 88] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID4"], (object)""));
						mSG[mSG.Row, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID_WT"])), "0.000");
						mSG[mSG.Row, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID2_WT"])), "0.000");
						mSG[mSG.Row, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID3_WT"])), "0.000");
						mSG[mSG.Row, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID4_WT"])), "0.000");
						mSG[mSG.Row, 101] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["DESIGN_IMG_ID"], (object)""));
						mSG[mSG.Row, 100] = "Y";
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 52] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[23] = Conversion.Val(MSG[mSG.Row, 57]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
							dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
							dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
					}
				}
				if (mSG.Col == 22)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME AS AcNameL,A.VCH_DATE AS OrderDtL,A.VCH_NO AS OrderNoL, B.ITM_REMARK AS ItemNameL,B.DESIGN_NO AS DesignL,B.ITM_GWT AS GrWtW,B.ITM_RATE AS RateR ,B.LBR_RATE AS LbrRateR,LBR_AMT As LbrAmtR,B.ITM_GHT_WT As GhtWtW,B.RATE_FIX As RatFixM FROM SL_ORD_DATA AS A INNER JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ADV_AMT - A.ORD_ADJ_AMT > 0  OR B.TAG_SALE = 'N' AND A.AC_CODE IN ('00020','" + tAcCode.Text + "') ORDER BY A.VCH_DATE DESC ";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[12];
					DC_Main.ColWidth[0] = 250.0;
					DC_Main.ColWidth[1] = 100.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 160.0;
					DC_Main.ColWidth[3] = 140.0;
					DC_Main.ColWidth[4] = 130.0;
					DC_Main.ColWidth[5] = 100.0;
					DC_Main.ColWidth[6] = 100.0;
					DC_Main.ColWidth[7] = 100.0;
					DC_Main.ColWidth[8] = 100.0;
					DC_Main.ColWidth[9] = 100.0;
					DC_Main.ColWidth[10] = 75.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.ColValue[10], "Y", false) == 0)
						{
							TEXT_ENTRY.Text = DC_Main.ColValue[6];
							mSG[mSG.Row, 22] = DC_Main.ColValue[6];
						}
						mSG[mSG.Row, 26] = DC_Main.ColValue[7];
						if (Conversion.Val(mSG[mSG.Row, 27]) == 0.0)
						{
							mSG[mSG.Row, 27] = DC_Main.ColValue[8];
						}
						if (Conversion.Val(mSG[mSG.Row, 17]) == 0.0)
						{
							mSG[mSG.Row, 17] = DC_Main.ColValue[9];
						}
						((Control)TEXT_ENTRY).Focus();
						return;
					}
				}
			}
		}
		else if ((int)keyCode == 46)
		{
			MsTxtDelete = true;
		}
		else if ((int)keyCode == 8)
		{
			MsTxtDelete = true;
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG.Col > 1)
				{
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						Msgleft = true;
						UpDown = true;
					}
					mSG.Col = checked(mSG.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG.Col >= MsgLastCol)
					{
						((Control)TEXT_ENTRY).Focus();
					}
					else if (mSG.Col < mSG.Cols - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						mSG.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
				if (mSG.Row > 1)
				{
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						UpDown = true;
					}
					MsgOldRow = 0;
					mSG.Row = checked(mSG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
				checked
				{
					if (mSG.Row < mSG.Rows - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						MsgOldRow = 0;
						mSG.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG.Col)
					{
					case 1:
					{
						if (Operators.CompareString(FormBookInOut, "O", false) != 0)
						{
							break;
						}
						if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Conversion.Val(mSG[mSG.Row, 52]) == 0.0))
						{
							mSG[mSG.Row, 1] = "";
						}
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						mSG[mSG.Row, 52] = Conversions.ToString(0);
						if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 52]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 52]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 52]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 52]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND C.EMP_ISU <> 'Y'  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
							}
							else if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select C.DESIGN_NO AS DesignNoL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND C.EMP_ISU <> 'Y'  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO,A.TAG_NO,C.VCH_TIME DESC"));
							}
							else
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND C.EMP_ISU <> 'Y'  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[10];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 120.0;
							DC_Main.ColWidth[2] = 300.0;
							DC_Main.ColWidth[3] = 100.0;
							DC_Main.ColWidth[4] = 100.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 110.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if ((Operators.CompareString(DC_Main.ColValue[0], "", false) != 0) | (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0))
							{
								if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 6] = DC_Main.ColValue[0];
								}
								else
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 6] = DC_Main.ColValue[1];
								}
								mSG[mSG.Row, 62] = DC_Main.ColValue[2];
								mSG[mSG.Row, 75] = DC_Main.ColValue[2];
								tItDesc.Text = DC_Main.ColValue[1];
								mSG[mSG.Row, 3] = DC_Main.ColValue[3];
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 97] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 98] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 52] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
							else
							{
								mSG[mSG.Row, 52] = "";
								mSG[mSG.Row, 1] = "";
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						int num8 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num8)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[10];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 300.0;
							DC_Main.ColWidth[2] = 100.0;
							DC_Main.ColWidth[3] = 120.0;
							DC_Main.ColWidth[4] = 100.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 110.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								mSG[mSG.Row, 62] = DC_Main.ColValue[1];
								mSG[mSG.Row, 3] = DC_Main.ColValue[0];
								mSG[mSG.Row, 6] = DC_Main.ColValue[3];
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 97] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 98] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 52] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE,B.RATE_TYPE As RateType,B.DISC_PRC As LbrDisc,B.MRP_DISC_PRC As MrpDisc,B.AC_MEMB_COM_PRC,B.ITM_FIX_GHT_PRC As FixGhtPrc FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 52]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""), (object)"", false))
							{
								if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK131NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK149NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "KJ003NPKJ", false) == 0))
								{
									mSG[DC_Main.i, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
									tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
								}
								else
								{
									mSG[DC_Main.i, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
									tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
								}
							}
							else
							{
								mSG[DC_Main.i, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
								tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							}
							if (DC_Main.MsTagVchSrnoUpdate)
							{
								if (Operators.CompareString(mSG[mSG.Row, 63], "E", false) == 0)
								{
									mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
									DC_Main.MsTagVchSrnoUpdate = false;
									return;
								}
								DC_Main.MsTagVchSrnoUpdate = false;
							}
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_STYLE"], (object)""));
							mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG[DC_Main.i, 11] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 97] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							if ((Conversion.Val(mSG[DC_Main.i, 12]) != Conversion.Val(mSG[DC_Main.i, 14])) & (Conversion.Val(mSG[DC_Main.i, 13]) == 0.0))
							{
								mSG[DC_Main.i, 13] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 12]) - Conversion.Val(mSG[DC_Main.i, 14])), "0.000");
							}
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
							{
								mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							}
							mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RateType"], (object)""));
							if (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) == 0.0 && ((Conversion.Val(mSG[mSG.Row, 30]) == 0.0) & (DC_Main.RtView != null)))
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
								DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								double num9 = default(double);
								if (dataTable2.Rows.Count > 0)
								{
									num9 = Conversions.ToDouble(dataTable2.Rows[0]["GR_RATE"]);
								}
								else
								{
									DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
									if (DC_Main.RtView.Count > 0)
									{
										num9 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
									}
								}
								if (num9 > 0.0)
								{
									mSG[mSG.Row, 82] = Conversions.ToString(0);
									if (Operators.CompareString(mSG[DC_Main.i, 58], "G", false) == 0)
									{
										mSG[mSG.Row, 22] = Strings.Format((object)Math.Round(num9 / 10.0, 2), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 58], "K", false) == 0)
									{
										mSG[mSG.Row, 22] = Strings.Format((object)Math.Round(num9 * 10.0, 0), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 58], "1", false) == 0)
									{
										mSG[mSG.Row, 22] = Strings.Format((object)Math.Round(num9, 0), "0.00");
									}
								}
								else
								{
									mSG[mSG.Row, 22] = "";
								}
							}
							mSG[DC_Main.i, 82] = Conversions.ToString(0);
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_PRC"], (object)"")), "0.00");
							if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"", false))
							{
								mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							}
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_RATE"], (object)"")), "0.00");
							mSG[DC_Main.i, 76] = Conversions.ToString(0);
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OTH_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 43] = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_GHT_WT"], (object)""))), "0.000");
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
							mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
							AxMSFlexGrid obj3 = mSG;
							int i = DC_Main.i;
							object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"], (object)"");
							obj3[i, 49] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							AxMSFlexGrid obj4 = mSG;
							int i2 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"], (object)"");
							obj4[i2, 50] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							mSG[DC_Main.i, 51] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"], (object)"")), "0.00");
							AxMSFlexGrid obj5 = mSG;
							int i3 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"");
							obj5[i3, 38] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							mSG[DC_Main.i, 53] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							if (((Operators.CompareString(DC_Main.MsMrpTaxReverc, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) == 0)) && Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) != 0.0)
							{
								mSG[DC_Main.i, 36] = "3.00";
							}
							if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK197NSVK", false) == 0)) && ((DateTime.Compare(DC_Main.MsSysDate, DC_Main.MsFDiscDt) >= 0) & (DateTime.Compare(DC_Main.MsSysDate, DC_Main.MsTDiscDt) <= 0)))
							{
								if (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LbrDisc"], (object)"")) > 0.0 && Conversion.Val(mSG[DC_Main.i, 31]) == 0.0)
								{
									mSG[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LbrDisc"], (object)"")), "0.00");
								}
								if (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FixGhtPrc"], (object)"")) > 0.0 && Conversion.Val(mSG[DC_Main.i, 16]) == 0.0)
								{
									mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FixGhtPrc"], (object)"")), "0.00");
								}
								if (((Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MrpDisc"], (object)"")) > 0.0) & (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) > 0.0)) && Conversion.Val(mSG[DC_Main.i, 31]) == 0.0)
								{
									mSG[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MrpDisc"], (object)"")), "0.00");
								}
							}
							mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							AxMSFlexGrid obj6 = mSG;
							int i4 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"");
							obj6[i4, 56] = Strings.Format((object)DC_Main.Fnv(ref Value), "0");
							mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
							{
								DC_Main.RsQry = "Select AC_MEMB_COM_PRC From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 3] + "' AND AC_CODE  = '" + tAcMembCode.Text + "' AND AC_MEMB_COM_PRC <> 0";
								DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (dataTable3.Rows.Count > 0)
								{
									mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
								}
								else
								{
									mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
								}
							}
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" Itm : ", DC_Main.Rshlp.Rows[0]["IT_NAME"]), (object)""));
							mSG[DC_Main.i, 86] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[DC_Main.i, 87] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[DC_Main.i, 88] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[DC_Main.i, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[DC_Main.i, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[DC_Main.i, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[DC_Main.i, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG[DC_Main.i, 101] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							MsgOldRow = 0;
						}
						ItmStk(DC_Main.i);
						int num10 = 0;
						int num11 = DtIdtl.Rows.Count - 1;
						int num12 = num11;
						for (int j = 0; j <= num12; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num10][23], (object)Conversion.Val(mSG[DC_Main.i, 57]), false))
							{
								DtIdtl.Rows[num10].Delete();
								DtIdtl.AcceptChanges();
								num10--;
							}
							num10++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG[mSG.Row, 1]), (object)"' AND A.VCH_SRNO = "), (object)mSG[mSG.Row, 52]), (object)" "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[23] = Conversion.Val(MSG[mSG.Row, 57]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
							dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
							dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) == 0)
						{
							CommPassTotal();
							MsgOldRow = 0;
							if (mSG.Row == mSG.Rows - 1)
							{
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								mSG.Col = 1;
								MsgClear = false;
								CommPassAdd();
								return;
							}
						}
						break;
					}
					case 2:
					{
						if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0 || !((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(mSG[mSG.Row, 2], TEXT_ENTRY.Text, false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "SELECT ITM_LOT,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_LOT = '" + TEXT_ENTRY.Text + "' AND ITM_LOT <> '' AND TAG_NO = 'N'  GROUP BY ITM_LOT HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) > 0";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.ITM_LOT As ItmLotL,A.IT_CODE as ItCodeL,B.IT_NAME As ItemNameL,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWtW  FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_LOT <> '' AND TAG_NO = 'N' GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME ORDER BY A.ITM_LOT,B.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[5];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 120.0;
							DC_Main.ColWidth[2] = 300.0;
							DC_Main.ColWidth[3] = 125.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								if (Operators.CompareString(mSG[mSG.Row, 63], "A", false) == 0)
								{
									mSG[mSG.Row, 62] = DC_Main.ColValue[0];
								}
								mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0.000");
								mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0.000");
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						AxMSFlexGrid obj = mSG;
						int row = mSG.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["GrWt"]);
						double num6 = DC_Main.Fnv(ref Value);
						dataRow["GrWt"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 12] = Strings.Format((object)num6, "0.000");
						AxMSFlexGrid obj2 = mSG;
						int row2 = mSG.Row;
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["GrWt"]);
						double num7 = DC_Main.Fnv(ref Value);
						dataRow["GrWt"] = RuntimeHelpers.GetObjectValue(Value);
						obj2[row2, 14] = Strings.Format((object)num7, "0.000");
						break;
					}
					case 3:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND IT_TYPE = '" + FormItmType + "'"))), (object)" AND IT_CODE = '"), (object)TEXT_ENTRY.Text), (object)"' "), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0, (object)"", (object)"AND BULK_SALE <> 'N'")), (object)" "));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND A.IT_TYPE = '" + FormItmType + "'"))), (object)" AND BULK_SALE <> 'N'  ORDER BY A.IT_NAME"));
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[7];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 0.0;
							DC_Main.ColWidth[4] = 0.0;
							DC_Main.ColWidth[5] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[1];
								mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								mSG[mSG.Row, 62] = DC_Main.ColValue[0];
								mSG[mSG.Row, 61] = DC_Main.ColValue[3];
								mSG[mSG.Row, 59] = DC_Main.ColValue[4];
								mSG[mSG.Row, 60] = DC_Main.ColValue[4];
								if (Operators.CompareString(mSG[mSG.Row, 63], "A", false) == 0)
								{
									mSG[mSG.Row, 82] = Conversions.ToString(0);
									mSG[mSG.Row, 22] = Conversions.ToString(0);
									mSG[mSG.Row, 23] = Conversions.ToString(0);
								}
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						if ((Operators.CompareString(mSG[mSG.Row, 63], "A", false) == 0) & (mSG.Row == mSG.Rows - 1) & (Operators.CompareString(mSG[mSG.Row, 58], "P", false) == 0))
						{
							mSG[mSG.Row, 25] = "P";
							mSG[mSG.Row, 76] = Conversions.ToString(0);
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
						{
							DC_Main.RsQry = "Select AC_MEMB_COM_PRC From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 3] + "' AND AC_CODE  = '" + tAcMembCode.Text + "' AND AC_MEMB_COM_PRC <> 0";
							DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable4.Rows.Count > 0)
							{
								mSG[mSG.Row, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable4.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
							}
							else
							{
								mSG[mSG.Row, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
							}
						}
						if ((Conversion.Val(mSG[mSG.Row, 22]) == 0.0) & (Conversion.Val(mSG[mSG.Row, 30]) == 0.0) & (DC_Main.RtView != null))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Tbl.Rows[0]["GR_CODE"]), (object)"'"));
							DataTable dataTable5 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							double num13 = default(double);
							if (dataTable5.Rows.Count > 0)
							{
								num13 = Conversions.ToDouble(dataTable5.Rows[0]["GR_RATE"]);
							}
							else
							{
								DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Tbl.Rows[0]["GR_CODE"]), (object)"'"));
								if (DC_Main.RtView.Count > 0)
								{
									num13 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
								}
							}
							if (num13 > 0.0)
							{
								if (Operators.CompareString(mSG[mSG.Row, 58], "G", false) == 0)
								{
									mSG[mSG.Row, 22] = Strings.Format((object)Math.Round(num13 / 10.0, 2), "0.00");
								}
								else if (Operators.CompareString(mSG[mSG.Row, 58], "K", false) == 0)
								{
									mSG[mSG.Row, 22] = Strings.Format((object)Math.Round(num13 * 10.0, 0), "0.00");
								}
								else if (Operators.CompareString(mSG[mSG.Row, 58], "1", false) == 0)
								{
									mSG[mSG.Row, 22] = Strings.Format((object)Math.Round(num13, 0), "0.00");
								}
							}
							else
							{
								mSG[mSG.Row, 22] = "";
							}
						}
						if (Operators.CompareString(mSG[mSG.Row, 1], "", false) == 0)
						{
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" Itm : ", DC_Main.Tbl.Rows[0]["IT_NAME"]), (object)""));
						}
						if (Operators.CompareString(mSG[mSG.Row, 63], "A", false) == 0)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
							double num14 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num14 != 0.0) & (Conversion.Val(mSG[mSG.Row, 26]) == 0.0))
							{
								AxMSFlexGrid obj7 = mSG;
								int row3 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
								double num15 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								obj7[row3, 26] = Strings.Format((object)num15, "0.00");
							}
							if (mSG[24] != 0)
							{
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
								double num16 = DC_Main.Fnv(ref Value);
								dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								if ((num16 != 0.0) & (Conversion.Val(mSG[mSG.Row, 24]) == 0.0))
								{
									AxMSFlexGrid obj8 = mSG;
									int row4 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
									double num17 = DC_Main.Fnv(ref Value);
									dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
									obj8[row4, 24] = Strings.Format((object)num17, "0.00");
								}
							}
						}
						mSG[mSG.Row, 3] = TEXT_ENTRY.Text;
						if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && ((Operators.CompareString(Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy"), Strings.Format((object)DC_Main.MsFDiscDt, "MM/dd/yyyy"), false) >= 0) & (Operators.CompareString(Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy"), Strings.Format((object)DC_Main.MsTDiscDt, "MM/dd/yyyy"), false) <= 0)))
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["DISC_PRC"]);
							double num18 = DC_Main.Fnv(ref Value);
							dataRow["DISC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							if (num18 != 0.0 && Conversion.Val(mSG[mSG.Row, 31]) == 0.0)
							{
								mSG[mSG.Row, 31] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DISC_PRC"], (object)"")), "0.00");
							}
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["MRP_DISC_PRC"]);
							double num19 = DC_Main.Fnv(ref Value);
							dataRow["MRP_DISC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							if (num19 != 0.0 && Conversion.Val(mSG[mSG.Row, 31]) == 0.0)
							{
								mSG[mSG.Row, 31] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MRP_DISC_PRC"], (object)"")), "0.00");
							}
						}
						if (Operators.CompareString(tItDesc.Text, "", false) == 0)
						{
							tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						((Control)TEXT_ENTRY).Visible = false;
						if (Operators.CompareString(mSG[mSG.Row, 1], "", false) == 0)
						{
							ItmStk(mSG.Row);
						}
						((Control)tItDesc).Focus();
						return;
					case 4:
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT TABLE_NAME As CounterL,TABLE_CODE as CodeL  FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[3];
							DC_Main.ColWidth[0] = 400.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 4] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 34:
						DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND EMP_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT EMP_NAME As EmpNameL,EMP_CODE as CodeL  FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[3];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 34] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_CODE"], (object)""));
						break;
					case 5:
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 5], false) != 0) & (mSG[5] != 0)))
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.ORD_NO As OrdNoL,D.AC_NAME As AcNameL,A.TAG_NO AS TagNoL,A.DESIGN_NO AS DesignNoL,C.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.ORD_YRCD As OrdYrCdL,A.ORD_DBCD As OrdDbCdL,A.ORD_SRNO As OrdSrNoL From ((BAR_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.ORD_YRCD = B.CO_YEAR AND A.ORD_DBCD = B.CO_BOOK AND A.ORD_NO = B.VCH_NO AND A.ORD_SRNO = B.OLD_SRNO)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE =  C.IT_CODE)  LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.LC_CODE = '" + DC_Main.MLc_code + "' and A.ORD_NO <> '' AND B.TAG_SALE = 'N' AND A.ORD_AC = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)"  ORDER BY A.ORD_NO,A.TAG_NO"));
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[14];
						DC_Main.ColWidth[0] = 90.0;
						DC_Main.ColWidth[1] = 275.0;
						DC_Main.ColWidth[2] = 110.0;
						DC_Main.ColWidth[3] = 100.0;
						DC_Main.ColWidth[4] = 200.0;
						DC_Main.ColWidth[5] = 80.0;
						DC_Main.ColWidth[6] = 100.0;
						DC_Main.ColWidth[7] = 100.0;
						DC_Main.ColWidth[8] = 110.0;
						DC_Main.ColWidth[9] = 0.0;
						DC_Main.ColWidth[10] = 0.0;
						DC_Main.ColWidth[11] = 0.0;
						DC_Main.ColWidth[12] = 0.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (DC_Main.HelpClose)
						{
							return;
						}
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							TEXT_ENTRY.Text = DC_Main.ColValue[0];
							mSG[mSG.Row, 5] = DC_Main.ColValue[0];
							mSG[mSG.Row, 62] = DC_Main.ColValue[4];
							mSG[mSG.Row, 75] = DC_Main.ColValue[4];
							tItDesc.Text = DC_Main.ColValue[4];
							if (Operators.CompareString(mSG[mSG.Row, 1], DC_Main.ColValue[2], false) != 0)
							{
								Interaction.MsgBox((object)"Order TagNo Is Not Valid...", (MsgBoxStyle)0, (object)null);
								TEXT_ENTRY.Text = "";
								mSG[mSG.Row, 5] = "";
								mSG[mSG.Row, 94] = "";
								mSG[mSG.Row, 95] = "";
								mSG[mSG.Row, 96] = "";
							}
							else
							{
								mSG[mSG.Row, 1] = DC_Main.ColValue[2];
								mSG[mSG.Row, 3] = DC_Main.ColValue[5];
								mSG[mSG.Row, 6] = DC_Main.ColValue[3];
								mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
								mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
								mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
								mSG[mSG.Row, 52] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[9]));
								mSG[mSG.Row, 94] = DC_Main.ColValue[10];
								mSG[mSG.Row, 95] = DC_Main.ColValue[11];
								mSG[mSG.Row, 96] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
								((Control)TEXT_ENTRY).Focus();
							}
						}
						else
						{
							TEXT_ENTRY.Text = "";
							mSG[mSG.Row, 5] = "";
							mSG[mSG.Row, 94] = "";
							mSG[mSG.Row, 95] = "";
							mSG[mSG.Row, 96] = "";
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					case 12:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 58], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && mSG.Row == mSG.Rows - 1)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 3] + "' "), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 6], "", false) == 0, (object)" AND IT_DESIGN = 'N' ", (object)("AND IT_DESIGN = '" + mSG[mSG.Row, 6] + "'"))), (object)" AND FROM_WT <= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)" AND TO_WT >= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)""));
							DataTable dataTable6 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable6.Rows.Count > 0 && Operators.ConditionalCompareObjectNotEqual(dataTable6.Rows[0]["LBR_AMT"], (object)0, false))
							{
								mSG[mSG.Row, 26] = "";
								mSG[mSG.Row, 27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable6.Rows[0]["LBR_AMT"], (object)"")), "0.00");
							}
						}
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 24:
					{
						if (mSG[24] <= 0)
						{
							break;
						}
						DC_Main.RsQry = "SELECT MIN_LBR_PRC FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 3] + "' AND FROM_WT <= " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 12])) + " AND TO_WT >= " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 12])) + " AND MIN_LBR_PRC <> 0";
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable.Rows.Count > 0 && Conversion.Val(TEXT_ENTRY.Text) < Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["MIN_LBR_PRC"], (object)"")))
						{
							Interaction.MsgBox((object)("You Cant Insert Lbr% Less then  " + Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["MIN_LBR_PRC"], (object)""))) + "...."), (MsgBoxStyle)0, (object)null);
							if ((Operators.CompareString(DC_Main.SSRegSrNo, "VS055NEVS", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS182NEBU", false) == 0))
							{
								return;
							}
						}
						break;
					}
					case 23:
						if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(mSG[mSG.Row, 23]))
						{
							mSG[mSG.Row, 22] = Conversions.ToString(0);
							mSG[mSG.Row, 82] = Conversions.ToString(0);
						}
						break;
					case 37:
					case 39:
					case 40:
					case 52:
					case 106:
						if (mSG.Row == mSG.Rows - 1)
						{
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							mSG.Col = 1;
							CommPassAdd();
						}
						else
						{
							mSG.Row += 1;
							mSG.Col = 1;
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					}
					if (mSG.Col < mSG.Cols - 1)
					{
						MSG.Col += 1;
					}
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
			}
		}
		mSG = null;
	}

	private void ItmStk(int Row)
	{
		if (Operators.CompareString(MSG[Row, 1], "", false) == 0)
		{
			DataTable dataTable;
			if (Operators.CompareString(MSG[Row, 2], "", false) != 0)
			{
				DC_Main.RsQry = "Select A.ITM_LOT,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 3] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TAG_NO = 'N'  GROUP BY A.ITM_LOT ";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P = ", dataTable.Rows[0]["StkPcs"]), (object)"  G = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
				}
				else
				{
					lblItStock.Text = "Lot Stk :";
				}
				return;
			}
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 3] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TAG_NO = 'N'  GROUP BY A.IT_CODE ";
			dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P= ", dataTable.Rows[0]["StkPcs"]), (object)"  G= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
				CurItGwtStk = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.000"));
			}
			else
			{
				CurItGwtStk = 0.0;
				lblItStock.Text = "Itm Stk :";
			}
		}
		else
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 3] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P= ", dataTable.Rows[0]["StkPcs"]), (object)"  G= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
				CurItGwtStk = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.000"));
			}
			else
			{
				CurItGwtStk = 0.0;
				lblItStock.Text = "Itm Stk :";
			}
		}
	}

	private void TR_SALE_Load(object sender, EventArgs e)
	{
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_2324: Unknown result type (might be due to invalid IL or missing references)
		//IL_2329: Unknown result type (might be due to invalid IL or missing references)
		//IL_2333: Expected O, but got Unknown
		//IL_2358: Unknown result type (might be due to invalid IL or missing references)
		//IL_235d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2367: Expected O, but got Unknown
		//IL_238c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2391: Unknown result type (might be due to invalid IL or missing references)
		//IL_239b: Expected O, but got Unknown
		//IL_23c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_23cf: Expected O, but got Unknown
		//IL_23f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2403: Expected O, but got Unknown
		//IL_2428: Unknown result type (might be due to invalid IL or missing references)
		//IL_242d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2437: Expected O, but got Unknown
		//IL_245c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2461: Unknown result type (might be due to invalid IL or missing references)
		//IL_246b: Expected O, but got Unknown
		//IL_24aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_24af: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b9: Expected O, but got Unknown
		//IL_24d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e2: Expected O, but got Unknown
		//IL_24fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2501: Unknown result type (might be due to invalid IL or missing references)
		//IL_250b: Expected O, but got Unknown
		//IL_2525: Unknown result type (might be due to invalid IL or missing references)
		//IL_252a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2534: Expected O, but got Unknown
		//IL_254e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2553: Unknown result type (might be due to invalid IL or missing references)
		//IL_255d: Expected O, but got Unknown
		//IL_2577: Unknown result type (might be due to invalid IL or missing references)
		//IL_257c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2586: Expected O, but got Unknown
		//IL_25a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25af: Expected O, but got Unknown
		//IL_25c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d8: Expected O, but got Unknown
		//IL_2600: Unknown result type (might be due to invalid IL or missing references)
		//IL_2607: Expected O, but got Unknown
		//IL_26e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_26f7: Expected O, but got Unknown
		//IL_277f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2784: Unknown result type (might be due to invalid IL or missing references)
		//IL_278e: Expected O, but got Unknown
		//IL_2827: Unknown result type (might be due to invalid IL or missing references)
		//IL_282c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2832: Expected O, but got Unknown
		//IL_28e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ef: Expected O, but got Unknown
		//IL_297a: Unknown result type (might be due to invalid IL or missing references)
		//IL_297f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2985: Expected O, but got Unknown
		//IL_2a10: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a1b: Expected O, but got Unknown
		//IL_2aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab1: Expected O, but got Unknown
		//IL_2b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b47: Expected O, but got Unknown
		//IL_2bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bde: Expected O, but got Unknown
		//IL_2c03: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c12: Expected O, but got Unknown
		//IL_2c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c49: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
		}
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		ColCon = 1.0 + num;
		ColHight = 1.0 + num2;
		checked
		{
			foreach (Control control in ((Control)this).Controls)
			{
				Control val = control;
				Control val2;
				(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
				(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
				(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
				(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num2);
			}
			foreach (object control2 in ((Control)PnlBotam).Controls)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(control2);
				object obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control3 in ((Control)PanelAdd).Controls)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
				object obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control4 in ((Control)PnlUpdate).Controls)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
				object obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control5 in ((Control)PnlPoint).Controls)
			{
				object objectValue4 = RuntimeHelpers.GetObjectValue(control5);
				object obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control6 in ((Control)PnlUpi).Controls)
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(control6);
				object obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control7 in ((Control)pnlCrnt).Controls)
			{
				object objectValue6 = RuntimeHelpers.GetObjectValue(control7);
				object obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue6;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue6, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control8 in ((Control)pnlMobile).Controls)
			{
				object objectValue7 = RuntimeHelpers.GetObjectValue(control8);
				object obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue7;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue7, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control9 in ((Control)pnlMembAcCode).Controls)
			{
				object objectValue8 = RuntimeHelpers.GetObjectValue(control9);
				object obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue8;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue8, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			((Control)MSG_TOT).Top = ((Control)MSG).Bottom + 1;
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblTrfrOpen;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				TextBox obj6 = tHdVchNo;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj6).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				CheckBox obj8 = chkRateUnFix;
				object? obj9 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				Label obj10 = lblBook;
				object? obj11 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj10).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)nItProfit).ForeColor = Color.Maroon;
				AxMSFlexGrid mSG = MSG;
				object? obj13 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj14 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj15 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj16 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj17 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj18 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				object? obj19 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
				object? obj20 = colorConverter.ConvertFromString("DarkGray");
				mSG_IDTL2.BackColorBkg = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_IDTL3 = MSG_IDTL;
				object? obj21 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_IDTL3.BackColorFixed = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				object? obj22 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_OLD2 = MSG_OLD;
				object? obj23 = colorConverter.ConvertFromString("DarkGray");
				mSG_OLD2.BackColorBkg = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_OLD3 = MSG_OLD;
				object? obj24 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_OLD3.BackColorFixed = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj25 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj26 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj27 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_ORD = MSG_ORD;
				object? obj28 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_ORD2 = MSG_ORD;
				object? obj29 = colorConverter.ConvertFromString("DarkGray");
				mSG_ORD2.BackColorBkg = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_ORD3 = MSG_ORD;
				object? obj30 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_ORD3.BackColorFixed = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_UPI = MSG_UPI;
				object? obj31 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_UPI2 = MSG_UPI;
				object? obj32 = colorConverter.ConvertFromString("DarkGray");
				mSG_UPI2.BackColorBkg = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_UPI3 = MSG_UPI;
				object? obj33 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_UPI3.BackColorFixed = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_CRNT = MSG_CRNT;
				object? obj34 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_CRNT.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_CRNT2 = MSG_CRNT;
				object? obj35 = colorConverter.ConvertFromString("DarkGray");
				mSG_CRNT2.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_CRNT3 = MSG_CRNT;
				object? obj36 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_CRNT3.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
				CheckBox obj37 = chkPointMemb;
				object? obj38 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj37).BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				CheckBox obj39 = chkPointMemb;
				object? obj40 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj39).ForeColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj41 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				Panel pnlPoint = PnlPoint;
				object? obj42 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)pnlPoint).BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblTrfrOpen).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				((ButtonBase)chkRateUnFix).BackColor = Color.SlateGray;
				Panel pnlUpdate = PnlUpdate;
				object? obj43 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)pnlUpdate).BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj44 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj45 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj46 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj47 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj48 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj49 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj50 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj51 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj52 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj53 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG_OLD4 = MSG_OLD;
				object? obj54 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD4.BackColor = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AxMSFlexGrid mSG_OLD5 = MSG_OLD;
				object? obj55 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_OLD5.BackColorBkg = ((obj55 != null) ? ((Color)obj55) : default(Color));
				AxMSFlexGrid mSG_OLD6 = MSG_OLD;
				object? obj56 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_OLD6.BackColorFixed = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj57 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj58 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj59 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG_ORD4 = MSG_ORD;
				object? obj60 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD4.BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG_ORD5 = MSG_ORD;
				object? obj61 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_ORD5.BackColorBkg = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG_ORD6 = MSG_ORD;
				object? obj62 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_ORD6.BackColorFixed = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG_UPI4 = MSG_UPI;
				object? obj63 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI4.BackColor = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG_UPI5 = MSG_UPI;
				object? obj64 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_UPI5.BackColorBkg = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG_UPI6 = MSG_UPI;
				object? obj65 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_UPI6.BackColorFixed = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_CRNT4 = MSG_CRNT;
				object? obj66 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_CRNT4.BackColor = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_CRNT5 = MSG_CRNT;
				object? obj67 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_CRNT5.BackColorBkg = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG_CRNT6 = MSG_CRNT;
				object? obj68 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_CRNT6.BackColorFixed = ((obj68 != null) ? ((Color)obj68) : default(Color));
				((Control)chkPointMemb).ForeColor = Color.White;
				((ButtonBase)chkPointMemb).BackColor = Color.LightSlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj69 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj69 != null) ? ((Color)obj69) : default(Color));
				Panel pnlPoint2 = PnlPoint;
				object? obj70 = colorConverter.ConvertFromString("Cornsilk");
				((Control)pnlPoint2).BackColor = ((obj70 != null) ? ((Color)obj70) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((Control)lblTrfrOpen).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				((ButtonBase)chkRateUnFix).BackColor = Color.Cornsilk;
				Label obj71 = lblBook;
				object? obj72 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj71).ForeColor = ((obj72 != null) ? ((Color)obj72) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj73 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj73 != null) ? ((Color)obj73) : default(Color));
				Panel pnlUpdate2 = PnlUpdate;
				object? obj74 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)pnlUpdate2).BackColor = ((obj74 != null) ? ((Color)obj74) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj75 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj75 != null) ? ((Color)obj75) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj76 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj76 != null) ? ((Color)obj76) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj77 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj77 != null) ? ((Color)obj77) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj78 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj78 != null) ? ((Color)obj78) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj79 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj79 != null) ? ((Color)obj79) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj80 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj80 != null) ? ((Color)obj80) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj81 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj81 != null) ? ((Color)obj81) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj82 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj82 != null) ? ((Color)obj82) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj83 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj83 != null) ? ((Color)obj83) : default(Color));
				AxMSFlexGrid mSG_OLD7 = MSG_OLD;
				object? obj84 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD7.BackColor = ((obj84 != null) ? ((Color)obj84) : default(Color));
				AxMSFlexGrid mSG_OLD8 = MSG_OLD;
				object? obj85 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_OLD8.BackColorBkg = ((obj85 != null) ? ((Color)obj85) : default(Color));
				AxMSFlexGrid mSG_OLD9 = MSG_OLD;
				object? obj86 = colorConverter.ConvertFromString("Cornsilk");
				mSG_OLD9.BackColorFixed = ((obj86 != null) ? ((Color)obj86) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj87 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj87 != null) ? ((Color)obj87) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj88 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj88 != null) ? ((Color)obj88) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj89 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj89 != null) ? ((Color)obj89) : default(Color));
				AxMSFlexGrid mSG_ORD7 = MSG_ORD;
				object? obj90 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD7.BackColor = ((obj90 != null) ? ((Color)obj90) : default(Color));
				AxMSFlexGrid mSG_ORD8 = MSG_ORD;
				object? obj91 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_ORD8.BackColorBkg = ((obj91 != null) ? ((Color)obj91) : default(Color));
				AxMSFlexGrid mSG_ORD9 = MSG_ORD;
				object? obj92 = colorConverter.ConvertFromString("Cornsilk");
				mSG_ORD9.BackColorFixed = ((obj92 != null) ? ((Color)obj92) : default(Color));
				AxMSFlexGrid mSG_UPI7 = MSG_UPI;
				object? obj93 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI7.BackColor = ((obj93 != null) ? ((Color)obj93) : default(Color));
				AxMSFlexGrid mSG_UPI8 = MSG_UPI;
				object? obj94 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_UPI8.BackColorBkg = ((obj94 != null) ? ((Color)obj94) : default(Color));
				AxMSFlexGrid mSG_UPI9 = MSG_UPI;
				object? obj95 = colorConverter.ConvertFromString("Cornsilk");
				mSG_UPI9.BackColorFixed = ((obj95 != null) ? ((Color)obj95) : default(Color));
				AxMSFlexGrid mSG_CRNT7 = MSG_CRNT;
				object? obj96 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_CRNT7.BackColor = ((obj96 != null) ? ((Color)obj96) : default(Color));
				AxMSFlexGrid mSG_CRNT8 = MSG_CRNT;
				object? obj97 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_CRNT8.BackColorBkg = ((obj97 != null) ? ((Color)obj97) : default(Color));
				AxMSFlexGrid mSG_CRNT9 = MSG_CRNT;
				object? obj98 = colorConverter.ConvertFromString("Cornsilk");
				mSG_CRNT9.BackColorFixed = ((obj98 != null) ? ((Color)obj98) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj99 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj99 != null) ? ((Color)obj99) : default(Color));
				((ButtonBase)chkPointMemb).BackColor = Color.Cornsilk;
				CheckBox obj100 = chkPointMemb;
				object? obj101 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj100).ForeColor = ((obj101 != null) ? ((Color)obj101) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_OLD).AutoSize = false;
				((TextBoxBase)TEXT_ORD).AutoSize = false;
				((TextBoxBase)TEXT_UPI).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				((TextBoxBase)TEXT_CRNT).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_OLD).Font = new Font(((Control)TEXT_OLD).Font.FontFamily, (float)num3, ((Control)TEXT_OLD).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ORD).Font = new Font(((Control)TEXT_ORD).Font.FontFamily, (float)num3, ((Control)TEXT_ORD).Font.Style);
				((Control)TEXT_UPI).Font = new Font(((Control)TEXT_UPI).Font.FontFamily, (float)num3, ((Control)TEXT_UPI).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				((Control)TEXT_CRNT).Font = new Font(((Control)TEXT_CRNT).Font.FontFamily, (float)num3, ((Control)TEXT_CRNT).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_OLD.Font = new Font("Segoe UI Semibold", (float)num3, MSG_OLD.Font.Style);
				MSG_ORD.Font = new Font("Segoe UI Semibold", (float)num3, MSG_ORD.Font.Style);
				MSG_UPI.Font = new Font("Segoe UI Semibold", (float)num3, MSG_UPI.Font.Style);
				MSG_CRNT.Font = new Font("Segoe UI Semibold", (float)num3, MSG_UPI.Font.Style);
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control10 in ((Control)this).Controls)
					{
						Control val3 = control10;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ORD", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_UPI", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control11 in ((Control)PnlBotam).Controls)
					{
						object objectValue9 = RuntimeHelpers.GetObjectValue(control11);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue9, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
						{
							NewLateBinding.LateSet(objectValue9, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)UAdd1).Font.Size * (1.0 + num2));
				Font font3 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control12 in ((Control)PnlUpdate).Controls)
					{
						object objectValue10 = RuntimeHelpers.GetObjectValue(control12);
						NewLateBinding.LateSet(objectValue10, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				Font font4 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control13 in ((Control)PanelAdd).Controls)
					{
						object objectValue11 = RuntimeHelpers.GetObjectValue(control13);
						NewLateBinding.LateSet(objectValue11, (Type)null, "Font", new object[1] { (object)new Font(font4.FontFamily, (float)num3, font4.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font4)?.Dispose();
				}
				Font font5 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control14 in ((Control)PnlPoint).Controls)
					{
						object objectValue12 = RuntimeHelpers.GetObjectValue(control14);
						NewLateBinding.LateSet(objectValue12, (Type)null, "Font", new object[1] { (object)new Font(font5.FontFamily, (float)num3, font5.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font5)?.Dispose();
				}
				Font font6 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control15 in ((Control)pnlMobile).Controls)
					{
						object objectValue13 = RuntimeHelpers.GetObjectValue(control15);
						NewLateBinding.LateSet(objectValue13, (Type)null, "Font", new object[1] { (object)new Font(font6.FontFamily, (float)num3, font6.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font6)?.Dispose();
				}
				Font font7 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control16 in ((Control)pnlMembAcCode).Controls)
					{
						object objectValue14 = RuntimeHelpers.GetObjectValue(control16);
						NewLateBinding.LateSet(objectValue14, (Type)null, "Font", new object[1] { (object)new Font(font7.FontFamily, (float)num3, font7.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font7)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((Control)chkWapp).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
				}
			}
			FormBook = DC_Main.CurBook;
			FormName = DC_Main.CurBookName;
			FormBookType = DC_Main.CurBookType;
			FormItmType = DC_Main.CurBookItm;
			FormMainBook = DC_Main.CurBookMain;
			FormBookSname = DC_Main.CurBookSname;
			FormBookInOut = DC_Main.CurBookInOut;
			DC_Main.MCo_Book = FormBook;
			if (Operators.CompareString(FormItmType, "", false) == 0)
			{
				FormItmType = "A";
			}
			if (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0)
			{
				FormVchNo = DC_Main.CurBookVch;
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)chkRateUnFix).Visible = true;
			}
			if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && Operators.CompareString(DC_Main.MCo_Book, "099", false) != 0)
			{
				((Control)lblTrfrOpen).Visible = true;
				((Control)btnQuot).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AB002NPAB", false) == 0)
			{
				((Control)lblTrfrOpen).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS105NPBU", false) == 0)
			{
				((Control)lblTrfrOpen).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS287NEBU", false) == 0)
			{
				((Control)pnlMobile).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
			{
				((Control)pnlMembAcCode).Visible = true;
				((Control)chkWhoutcommBill).Visible = true;
				DC_Main.RsQry = "SELECT A.IT_CODE,A.GR_CODE,B.MELTING_PRC FROM ITEM_MAST AS A INNER JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.MELTING_PRC <> 0";
				RsGrTch = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = 'L' ORDER BY MSG_TYPE ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				SmsDetail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MSG_DETL"], (object)""));
			}
			else
			{
				SmsDetail = "Thank You For Buy Ornaments With " + DC_Main.MCo_Name + " Have A Nice Day..";
			}
			DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ORDER BY PRINT_FILE";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			cboPrintfile.Items.Add((object)"");
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				int num4 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						FormPrintFile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '01'  AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ORDER BY PRINT_FILE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num5 = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num5)
					{
						cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
						{
							FormPrintFile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						}
						DC_Main.X++;
					}
				}
			}
			cboPrintfile.SelectedIndex = 0;
			cboPrintfile.Text = FormPrintFile;
			if (Operators.CompareString(DC_Main.MsPointCode, "", false) != 0)
			{
				((Control)chkPointMemb).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK061NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK061NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK146NEVK", false) == 0))
			{
				((Control)chkWapp).Visible = true;
			}
			if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && Operators.CompareString(DC_Main.MsOsBillOrnaIsu, "N", false) == 0)
			{
				((Control)chkBillOrnaIsu).Visible = true;
			}
			((Control)PnlUpi).Left = ((Control)Label5).Left;
			((Control)PnlUpi).Top = ((Control)Label5).Top;
			CurActCtrl = (Control)(object)tVchNo;
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
			else if (val is MaskedTextBox)
			{
				val.Text = DC_Main.MMask;
			}
		}
		MainUser = DC_Main.MCo_User;
		DataTrfr = "N";
		lblItem.Text = "";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		DC_Main.MsSlAdj = false;
		chkHuIdPrint.Checked = false;
		chkWapp.Checked = false;
		UpiTypeAdd = false;
		chkRateUnFix.Checked = false;
		chkWhoutcommBill.Checked = false;
		picAc.Image = null;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		tPointCode.Text = "";
		nPointSlVal.Text = "";
		nPointVal.Text = "";
		nPointBal.Text = "";
		nPointBillVal.Text = "";
		nBillPoint.Text = "";
		nTotPoint.Text = "";
		nUseVal.Text = "";
		nUsePoint.Text = "";
		tRefAc.Text = "";
		tRefName.Text = "";
		UAdd1.Text = "";
		UAdd2.Text = "";
		UAdd3.Text = "";
		UCity.Text = "";
		URefBy.Text = "";
		UGstNo.Text = "";
		UMobile.Text = "";
		UBrDate.Text = "";
		UAnvDate.Text = "";
		picAc.Image = null;
		tTrfrNo.Text = "";
		tTrfrDbCd.Text = "";
		tTrfrYrCd.Text = "";
		((Control)tTrfrNo).Enabled = true;
		((Control)PnlTrfrVch).Visible = false;
		lblItStock.Text = "Itm Stock :";
		((Control)PanelAdd).Visible = false;
		tPanNo.Text = "";
		tAcMembCode.Text = "";
		tAcMembName.Text = "";
		nItProfit.Text = "";
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
		{
			nItProfit.Text = "It Profit :";
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
		{
			nItProfit.Text = "It Profit :";
			((Control)nBillProfit).Visible = true;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
		{
			nItProfit.Text = "It Profit :";
			((Control)nBillProfit).Visible = true;
		}
		((Control)tPanNo).Visible = false;
		OsAmtSave = false;
		DC_Main.MsCardSlAdj = false;
		((Control)PnlPoint).Visible = false;
		MobHelpOpen = true;
		((Control)PnlUpdate).Visible = false;
		chkPointMemb.Checked = false;
		((Control)chkPointMemb).Enabled = true;
		((Control)PnlUpi).Visible = false;
		((Control)pnlCrnt).Visible = false;
		tAcMobile.Text = "Mobile";
		if (VchOldData != null)
		{
			VchOldData.Clear();
		}
		QtDbCd = "";
		QtNo = "";
		MoBook = "";
		MoVch = "";
		chkBillOrnaIsu.Checked = true;
		if (Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0)
		{
			tEmpCode.Text = "";
		}
		else
		{
			tEmpCode.Text = "001";
		}
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		if (Operators.CompareString(DC_Main.MsCardComAdj, "Y", false) == 0)
		{
			CardCommAdj = "Y";
		}
		else
		{
			CardCommAdj = "N";
		}
		OldValTot = 0.0;
		NewValTot = 0.0;
		LessAdvAmt = 0.0;
		CrntAdjAmt = 0.0;
		OldSchmAmt = 0.0;
		OldNetAmt = 0.0;
		OldTaxPrc = 0.0;
		CurItGwtStk = 0.0;
		AcTcsAmt = 0.0;
		OldTcsPrc = 0.0;
		PointMemb = "";
		DC_Main.MsOldPurc = false;
		DC_Main.MsOldPurcSl = false;
		OldGoldPurcAmt = 0.0;
		OldSilverPurcAmt = 0.0;
		OldCardAmt = 0.0;
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK081NSVK", false) != 0)
		{
			tAcCode.Text = "00045";
		}
		AcGstType = "L";
		cboPrintfile.Text = FormPrintFile;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_OLD).Visible = false;
		((Control)TEXT_ORD).Visible = false;
		((Control)TEXT_CRNT).Visible = false;
		UsUPdate = "N";
		UsDelete = "N";
		MSG_CLEAR();
		MSG_TOT_FILL();
		MSG_IDTL_CLEAR();
		MSG_OLD_CLEAR();
		MSG_ORD_CLEAR();
		MSG_CRNT_CLEAR();
		MSG2_CLEAR();
		MSG_UPI_CLEAR();
		CommPassAddUpi();
		if ((Operators.CompareString(FormBookType, "T", false) == 0) | (Operators.CompareString(DC_Main.MsTaxWithEstmate, "Y", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + DC_Main.MsTaxCode + "'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[2, 2] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num2 = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tVchNo.Text = "00001";
			}
			else
			{
				tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
				MaxVchNo = tVchNo.Text;
			}
			LastVchNo = tVchNo.Text;
			DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tHdVchNo.Text = "00001";
			}
			else
			{
				tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
			}
			TodayFineRate();
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			VchOldData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_NO"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]))), "0.00"));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				OldTaxPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"])), "0.00"));
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				OldTcsPrc = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000"));
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)
				{
					MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TDS_CODE"], (object)""));
					MSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_PRC"]), "0.000");
					MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]), "0.00");
					DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[4, 4] + "'";
					DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsAc.Rows.Count > 0)
					{
						MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
					}
				}
				else
				{
					MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
				}
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				OldCardAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00"));
				CardCommAdj = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_ADJ"], (object)""));
				MSG2_TOTAL[7, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_COM_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADV_AMT"]), "0.00");
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL_AMT"]), "0.00");
				OldGoldPurcAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL_AMT"]), "0.00"));
				MSG2_TOTAL[10, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL_AMT"]), "0.00");
				OldSilverPurcAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL_AMT"]), "0.00"));
				MSG2_TOTAL[11, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SCHM_AMT"]), "0.00");
				OldSchmAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SCHM_AMT"]), "0.00"));
				MSG2_TOTAL[12, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				MSG2_TOTAL[12, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UPI_AMT"]), "0.00");
				MSG2_TOTAL[13, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_PAID"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[14, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[15, 3] = Strings.Format((object)num2, "0.00");
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["OLD_GL"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["OLD_GL"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[9, 2] = Strings.Format((object)num3, "0.000");
				MSG2_TOTAL[10, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL"]), "0.000");
				MSG2_TOTAL[15, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["POINT_VAL"]), "0.00");
				if (Conversion.Val(MSG2_TOTAL[15, 2]) == 0.0)
				{
					MSG2_TOTAL[15, 2] = "";
				}
				MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[6, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[6, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[7, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[11, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SCHM_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[11, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[11, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[3, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VS287NEBU", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_MOBILE,AC_ADD1 FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
					DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsAc.Rows.Count > 0)
					{
						tAcMobile.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_MOBILE"], (object)" - "), DC_Main.RsAc.Rows[0]["AC_ADD1"]));
					}
				}
				tAcMembCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MEMB_COM_AC_CODE"], (object)""));
				if (Operators.CompareString(tAcMembCode.Text, "", false) != 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcMembCode.Text + "'";
					DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsAc.Rows.Count > 0)
					{
						tAcMembName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
					}
				}
				tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_NAME"], (object)""));
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
				tIsuDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_DBCD"], (object)""));
				tIsuYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_YRCD"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				CurPrnMobile = tMobile.Text;
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["ORNA_ISU"], (object)""), (object)"N", false))
				{
					chkBillOrnaIsu.Checked = false;
				}
				else
				{
					chkBillOrnaIsu.Checked = true;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RATE_UNFIX"], (object)""), (object)"Y", false))
				{
					chkRateUnFix.Checked = true;
				}
				else
				{
					chkRateUnFix.Checked = false;
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["WHOUT_COMM_BILL"], (object)""), (object)"Y", false))
				{
					chkWhoutcommBill.Checked = true;
				}
				else
				{
					chkWhoutcommBill.Checked = false;
				}
				DataTrfr = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DATA_TRFR"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					DataTrfr = "Y";
				}
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				if (Operators.CompareString(UsUPdate, "Y", false) == 0)
				{
					((BaseStyleControl)BtnSave).ForeColor = Color.Green;
				}
				if (Operators.CompareString(UsDelete, "Y", false) == 0)
				{
					((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
				}
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
				DC_Main.RsQry = "SELECT SUM(TOT_AMT) As TOT_AMT FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						DC_Main.MsAcAmtOpBal -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)"")), "0.00"));
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						DC_Main.MsAcAmtOpBal += Conversions.ToDouble(Strings.Format((object)(0.0 - Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)""))), "0.00"));
					}
				}
				DC_Main.RsQry = "SELECT SUM(ADJ_AMT) As TOT_AMT FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SBILL_YRCD = '" + DC_Main.MCo_year + "' AND SBILL_DBCD = '" + DC_Main.MCo_Book + "' AND SBILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						DC_Main.MsAcAmtOpBal -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)"")), "0.00"));
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						DC_Main.MsAcAmtOpBal += Conversions.ToDouble(Strings.Format((object)(0.0 - Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)""))), "0.00"));
					}
				}
				if (DC_Main.MsAcAmtOpBal > 0.0)
				{
					LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
					((Control)LOpAmt).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcAmtOpBal < 0.0)
				{
					LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
					((Control)LOpAmt).ForeColor = Color.Red;
				}
				else
				{
					LOpAmt.Text = ": Amt";
				}
				if (DC_Main.MsAcAmtClBal > 0.0)
				{
					LClAmt.Text = Strings.Format((object)DC_Main.MsAcAmtClBal, "0.00") + " : Cr Amt";
					((Control)LClAmt).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcAmtClBal < 0.0)
				{
					LClAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtClBal), "0.00") + " : Dr Amt";
					((Control)LClAmt).ForeColor = Color.Red;
				}
				else
				{
					LClAmt.Text = ": Amt";
				}
				CustOpAmt = DC_Main.MsAcAmtOpBal;
				CustClAmt = DC_Main.MsAcAmtClBal;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
				MobHelpOpen = false;
				TodayFineRate();
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 97] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FIX_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 105] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FIX_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 85] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["GHT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);
					mSG[DC_Main.i + 1, 102] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_COST"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_CODE"], (object)""));
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num4 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num4, 81] = Conversions.ToString(num5);
					mSG[DC_Main.i + 1, 86] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 88] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["AC_MEMB_COM_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["AC_MEMB_COM_VAL"])), "0.000");
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						DataView dataView = new DataView(RsGrTch);
						dataView.RowFilter = "IT_CODE = '" + mSG[mSG.Row, 3] + "'";
						if (dataView.Count > 0)
						{
							AxMSFlexGrid obj2 = mSG;
							int row = mSG.Row;
							DataRowView dataRowView;
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView[0])["MELTING_PRC"]);
							double num6 = DC_Main.Fnv(ref Value);
							dataRowView["MELTING_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							obj2[row, 106] = Strings.Format((object)num6, "0.00");
						}
						else
						{
							mSG[mSG.Row, 106] = "100.00";
						}
					}
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 63] = "E";
					mSG[DC_Main.i + 1, 93] = "Y";
					mSG[DC_Main.i + 1, 94] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 95] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					AxMSFlexGrid obj3 = mSG;
					int num7 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ORD_SRNO"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRow["ORD_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj3[num7, 96] = Conversions.ToString(num8);
					mSG[DC_Main.i + 1, 100] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_TAG_STK_ADD"], (object)""));
					mSG[DC_Main.i + 1, 101] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_LOT"], (object)""));
					mSG.Rows += 1;
					DC_Main.i++;
				}
				EntryMode = "E";
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				ItmProfit(1);
				mSG = null;
				if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | ((Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)))
				{
					double num9 = 0.0;
					int num10 = MSG.Rows - 1;
					for (int i = 0; i <= num10; i++)
					{
						ItmProfit(i);
						num9 += Conversion.Val(MSG[i, 99]);
					}
					nBillProfit.Text = Strings.Format((object)num9, "0.00");
				}
				tItDesc.Text = MSG[1, 75];
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num11 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num11)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					dr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					dr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT A.* FROM SL_PR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsOldDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				while (DC_Main.i < RsOldDetl.Rows.Count)
				{
					mSG_OLD[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_OLD[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_OLD[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					mSG_OLD[DC_Main.i + 1, 3] = Conversions.ToString(RsOldDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_OLD[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["CON_PRC"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["CON_WT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["ITM_RATE_TYPE"], (object)""));
					mSG_OLD[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["PR_COST"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 14] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_OLD.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_OLD.Rows > 2)
				{
					mSG_OLD.Rows -= 1;
				}
				mSG_OLD = null;
				DC_Main.i = 0;
				DC_Main.RsQry = "Select * From SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'  Order By Sr_No";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < dataTable.Rows.Count)
				{
					AxMSFlexGrid mSG_ORD = MSG_ORD;
					mSG_ORD[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_ORD[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_HD_VCH_NO"], (object)""));
					mSG_ORD[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG_ORD[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_LC"], (object)""));
					mSG_ORD[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_AC_CODE"], (object)""));
					mSG_ORD[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG_ORD[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG_ORD[DC_Main.i + 1, 2] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ORD_AMT"])), "0.00");
					mSG_ORD.Rows += 1;
					DC_Main.i++;
					mSG_ORD = null;
				}
				if (MSG_ORD.Rows > 2)
				{
					MSG_ORD.Rows -= 1;
				}
				dataTable.Clear();
				DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ORDER BY SR_NO ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					DC_Main.i = 0;
					AxMSFlexGrid mSG_UPI = MSG_UPI;
					while (DC_Main.i < DC_Main.Tbl.Rows.Count)
					{
						mSG_UPI[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG_UPI[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_CODE"], (object)""));
						mSG_UPI[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_NAME"], (object)""));
						mSG_UPI[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_TYPE"], (object)""));
						mSG_UPI[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_ID"], (object)""));
						mSG_UPI[DC_Main.i + 1, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AMT"]), "0.00");
						if (Conversion.Val(mSG_UPI[DC_Main.i + 1, 5]) == 0.0)
						{
							mSG_UPI[DC_Main.i + 1, 5] = "";
						}
						mSG_UPI.Rows += 1;
						DC_Main.i++;
					}
					if (mSG_UPI.Rows > 2)
					{
						mSG_UPI.Rows -= 1;
					}
					mSG_UPI = null;
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.*,B.MIN_POINT,B.POINT_AMT FROM POINT_DATA AS A LEFT JOIN POINT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.POINT_CODE = B.POINT_CODE WHERE A.CO_CODE='" + DC_Main.MCo_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' AND A.SR_NO = 1 ";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						PointMemb = tAcCode.Text;
						chkPointMemb.Checked = true;
						((Control)chkPointMemb).Enabled = false;
						nPointSlVal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["POINT_AMT"])), "0.00");
						tPointCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[0]["POINT_CODE"], (object)""));
						nPointBillVal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TOT_AMT"])), "0.00");
						nPointVal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["POINT_VAL"])), "0");
						nBillPoint.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TOT_POINT"])), "0");
						MSG2_TOTAL[14, 2] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TOT_POINT"])), "0");
						tRefAc.Text = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[0]["REF_CUST"], (object)""));
						tRefName.Text = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[0]["REF_NAME"], (object)""));
						nTotPoint.Text = Conversions.ToString(Conversion.Val(nBillPoint.Text) + Conversion.Val(nPointBal.Text));
					}
					DC_Main.RsQry = "SELECT * FROM POINT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' AND SR_NO = 2 ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						nUsePoint.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TOT_POINT"])), "0");
						nUseVal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TOT_AMT"])), "0.00");
					}
				}
				DC_Main.i = 0;
				DC_Main.RsQry = "Select * From CRNT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'  Order By Sr_No";
				DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < dataTable3.Rows.Count)
				{
					AxMSFlexGrid mSG_CRNT = MSG_CRNT;
					mSG_CRNT[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_CRNT[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[DC_Main.i]["CRNT_HD_VCH_NO"], (object)""));
					mSG_CRNT[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[DC_Main.i]["CRNT_NO"], (object)""));
					mSG_CRNT[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[DC_Main.i]["CRNT_LC"], (object)""));
					mSG_CRNT[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[DC_Main.i]["CRNT_AC_CODE"], (object)""));
					mSG_CRNT[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[DC_Main.i]["CRNT_YRCD"], (object)""));
					mSG_CRNT[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[DC_Main.i]["CRNT_DBCD"], (object)""));
					mSG_CRNT[DC_Main.i + 1, 2] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable3.Rows[DC_Main.i]["CRNT_AMT"])), "0.00");
					mSG_CRNT.Rows += 1;
					DC_Main.i++;
					mSG_CRNT = null;
				}
				if (MSG_CRNT.Rows > 2)
				{
					MSG_CRNT.Rows -= 1;
				}
				dataTable3.Clear();
				if (MSG.Rows >= 1)
				{
					MSG.Row = 1;
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				EntryMode = "E";
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 43]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 27]) + Conversion.Val(MSG2_TOTAL[15, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 43]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 27]) + Conversion.Val(MSG2_TOTAL[15, 3]);
				MsVchSrno = "";
				((TextBoxBase)tVchNo).ReadOnly = true;
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)mVchDate).Focus();
				EntryMode = "A";
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_SALE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SALE_KeyPress(object sender, KeyPressEventArgs e)
	{
		short num;
		checked
		{
			num = (short)Strings.Asc(e.KeyChar);
			num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));
		}
		e.KeyChar = Strings.Chr((int)num);
		if (num == 0 || num == 39)
		{
			e.Handled = true;
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_8288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_8264: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d05: Invalid comparison between Unknown and I4
		//IL_10a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eda: Unknown result type (might be due to invalid IL or missing references)
		//IL_319c: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a3: Expected O, but got Unknown
		((Control)BtnSave).Enabled = false;
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			DC_Main.DefaulterAc(tAcCode.Text);
			if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[15, 3]) > 0.0))
			{
				Interaction.MsgBox((object)"You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...", (MsgBoxStyle)0, (object)null);
				DC_Main.MsDefaulterAc = "N";
				return;
			}
			if ((Operators.CompareString(tAcCode.Text, "00045", false) != 0) & (Operators.CompareString(EntryMode, "E", false) != 0))
			{
				DC_Main.RsQry = "Select B.AMT_LIMIT,B.GOLD_LIMIT,SILVER_LIMIT FROM AC_MAST AS B WHERE B.CO_CODE = '" + DC_Main.MCo_code + "'  AND B.AC_CODE = '" + tAcCode.Text + "' AND AMT_LIMIT > 0 ";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					double num = Conversions.ToDouble(dataTable.Rows[0]["AMT_LIMIT"]);
					DC_Main.RsQry = "Select Sum(A.CR_AMT-A.DR_AMT) as Amount FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' HAVING Sum(A.CR_AMT-A.DR_AMT) <> 0 ";
					dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						bool num2 = Operators.ConditionalCompareObjectGreater(dataTable.Rows[0]["Amount"], (object)0, false);
						object obj = Operators.SubtractObject((object)Conversion.Val(MSG2_TOTAL[15, 3]), dataTable.Rows[0]["Amount"]);
						Type? typeFromHandle = typeof(Math);
						DataRow dataRow;
						object[] obj2 = new object[1] { (dataRow = dataTable.Rows[0])["Amount"] };
						object[] array = obj2;
						bool[] obj3 = new bool[1] { true };
						bool[] array2 = obj3;
						object obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj2, (string[])null, (Type[])null, obj3);
						if (array2[0])
						{
							dataRow["Amount"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
						}
						double num3 = Conversions.ToDouble(Interaction.IIf(num2, obj, Operators.AddObject(obj4, (object)Conversion.Val(MSG2_TOTAL[15, 3]))));
						if (num3 > num)
						{
							Interaction.MsgBox((object)(" You Cant Save Entry Because This Party Amount Os Limit Is " + Conversions.ToString(num) + "...Please Change It"), (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							return;
						}
					}
					else if (Conversion.Val(MSG2_TOTAL[15, 3]) > num)
					{
						Interaction.MsgBox((object)(" You Cant Save Entry Because This Party Amount Os Limit Is " + Conversions.ToString(num) + "...Please Change It"), (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						return;
					}
				}
			}
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "VK217NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS233NEBU", false) == 0)) && Conversion.Val(MSG2_TOTAL[15, 3]) != 0.0 && Conversion.Val(nCrDays.Text) == 0.0)
		{
			Interaction.MsgBox((object)"Please Insert Cr Days And Try...", (MsgBoxStyle)0, (object)null);
			((Control)nCrDays).Focus();
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(FormMainBook, "SL QUOT", false) != 0 && DC_Main.MsCashLimit > 0.0 && Operators.CompareString(tAcCode.Text, "00045", false) != 0)
		{
			DC_Main.LedrCash(tAcCode.Text, DC_Main.MCo_Book, tVchNo.Text);
			if (Conversion.Val(MSG2_TOTAL[12, 3]) + DC_Main.AcCash > DC_Main.MsCashLimit)
			{
				Interaction.MsgBox((object)("Cash Recieved Limit Amount = " + Conversions.ToString(DC_Main.MsCashLimit) + " \r\nOld Ledr Value Is " + Conversions.ToString(DC_Main.AcCash) + " \r\nAnd Total Cash Amount Is " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[12, 3]) + DC_Main.AcCash) + " You Can Not Receive More Then Cash Limit ..."), (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
		}
		checked
		{
			int num4 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num4)
			{
				if ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 52]) == 0.0))
				{
					if (Operators.CompareString(EntryMode, "E", false) == 0)
					{
						Interaction.MsgBox((object)(" " + MSG[DC_Main.i, 1] + "  This TagNo Has No Tag Id Please Re Enter This Tag and Try..."), (MsgBoxStyle)0, (object)null);
						MSG.Row = DC_Main.i;
						MSG.Col = 1;
						MSG_EnterCell(MSG, new EventArgs());
						((Control)TEXT_ENTRY).Visible = true;
						((Control)TEXT_ENTRY).Focus();
					}
					else
					{
						DC_Main.RsQry = "Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + MSG[DC_Main.i, 1] + "' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC ";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							MSG[DC_Main.i, 52] = Conversions.ToString(DC_Main.Tbl.Rows[0]["VCH_SRNO"]);
						}
					}
				}
				if ((Operators.CompareString(MSG[DC_Main.i, 3], "", false) == 0) & (Conversion.Val(MSG[DC_Main.i, 12]) + Conversion.Val(MSG[DC_Main.i, 27]) + Conversion.Val(MSG[DC_Main.i, 37]) + Conversion.Val(MSG[DC_Main.i, 30]) != 0.0))
				{
					Interaction.MsgBox((object)("Please Select Item Code In Row " + Conversions.ToString(DC_Main.i) + " and Try......"), (MsgBoxStyle)0, (object)null);
					return;
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK204NEVK", false) == 0 && ((Operators.CompareString(MSG[DC_Main.i, 34], "", false) == 0) & (Conversion.Val(MSG[DC_Main.i, 37]) != 0.0)))
				{
					Interaction.MsgBox((object)("Please Select Select Employ " + Conversions.ToString(DC_Main.i) + " and Try......"), (MsgBoxStyle)0, (object)null);
					((Control)BtnSave).Enabled = true;
					return;
				}
				DC_Main.i++;
			}
			if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
				((Control)tEmpCode).Focus();
				return;
			}
			if ((Conversion.Val(MSG2_TOTAL[6, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[6, 4], "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (((Conversion.Val(MSG2_TOTAL[7, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[7, 4], "", false) == 0)) && Operators.CompareString(CardCommAdj, "N", false) == 0)
			{
				Interaction.MsgBox((object)"Please Select Card Bank Account And Try Because Card Amt <> 0......", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
			{
				Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mTime.Text = DateTime.Now.ToString("HH:mm:ss");
			}
			((Control)BtnSave).Enabled = false;
			Application.DoEvents();
			if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
			{
				Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
			{
				Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
			{
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (Operators.CompareString(tAcCode.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Party and try", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				((Control)tAcCode).Focus();
				return;
			}
			if (Operators.CompareString(tVchNo.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			MSG_TOT_FILL();
			if (Conversion.Val(MSG2_TOTAL[0, 3]) == 0.0)
			{
				Interaction.MsgBox((object)"Please Insert Item Value Nat Amount  = 0 and try", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (((Operators.CompareString(DC_Main.SSRegSrNo, "VK033NPVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK133NEVK", false) == 0)) && ((Conversion.Val(MSG2_TOTAL[15, 3]) != 0.0) & !OsAmtSave))
			{
				if (unchecked((int)Interaction.MsgBox((object)("This Bill Outstanding Amount =  " + Strings.Format((object)Conversion.Val(MSG2_TOTAL[15, 3]), "0.00") + " ...You Want to Save It ?"), (MsgBoxStyle)260, (object)DC_Main.MsgTitle)) == 6)
				{
					OsAmtSave = true;
					((Control)BtnSave).Enabled = true;
					((Control)BtnSave).Focus();
				}
				else
				{
					((Control)BtnSave).Enabled = true;
					((Control)BtnSave).Focus();
				}
				return;
			}
			if (Operators.CompareString(FormMainBook, "SL QUOT", false) != 0 && ((Conversion.Val(MSG2_TOTAL[0, 3]) >= DC_Main.MsPanCardVal) & (Operators.CompareString(DC_Main.MCo_BookType, "T", false) == 0)))
			{
				if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
				{
					Interaction.MsgBox((object)(("Please Select Party Account Because Bill Value > " + Conversions.ToString(DC_Main.MsPanCardVal)) ?? ""), (MsgBoxStyle)0, (object)null);
					((Control)BtnSave).Enabled = true;
					tAcCode.Text = "";
					((Control)tAcCode).Focus();
					return;
				}
				DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_PANNO"], (object)""), (object)"", false))
				{
					Interaction.MsgBox((object)(("Please Insert Party PanNo in Party mast...BIll Value > " + Conversions.ToString(DC_Main.MsPanCardVal)) ?? ""), (MsgBoxStyle)0, (object)null);
					((Control)BtnSave).Enabled = true;
					((Control)tPanNo).Visible = true;
					((Control)tPanNo).Focus();
					return;
				}
			}
			DC_Main.MsTagVchSrnoUpdate = false;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
						tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
					}
				}
				DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
					}
				}
			}
			Module_Save.SlTran = null;
			try
			{
				if (DC_Main.Dc.State != ConnectionState.Open)
				{
					DC_Main.Dc.Open();
				}
				Module_Save.SlTran = DC_Main.Dc.BeginTransaction();
				Module_Save.ExeQuteDcSave("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				Module_Save.ExeQuteDcSave("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				Module_Save.ExeQuteDcSave("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				if (Conversion.Val(MSG_TOT[0, 30]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 37]) != 0.0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ", Module_Save.SlTran);
					DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
					DataTable dataTable2 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
					DataRow dataRow2 = dataTable2.NewRow();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow2["VCH_NO"] = tHdVchNo.Text;
					dataRow2["BOOK_NAME"] = FormName;
					dataTable2.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
					dataTable2.Clear();
					DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
					DataRow dataRow3 = RsData.NewRow();
					dataRow3["CO_CODE"] = DC_Main.MCo_code;
					dataRow3["LC_CODE"] = DC_Main.MLc_code;
					dataRow3["CO_YEAR"] = DC_Main.MCo_year;
					dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow3["VCH_NO"] = tVchNo.Text;
					dataRow3["AC_CODE"] = tAcCode.Text;
					dataRow3["VCH_DATE"] = mVchDate.Text;
					dataRow3["BILL_NO"] = tBillNo.Text;
					dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow3["AC_CODE"] = tAcCode.Text;
					dataRow3["AC_NAME"] = tAcName.Text;
					dataRow3["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
					dataRow3["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
					dataRow3["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
					dataRow3["TAX_CODE"] = MSG2_TOTAL[2, 4];
					dataRow3["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
					dataRow3["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
					dataRow3["TCS_CODE"] = MSG2_TOTAL[3, 4];
					dataRow3["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
					dataRow3["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
					if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)
					{
						dataRow3["ROF_AMT"] = 0;
						dataRow3["TDS_CODE"] = MSG2_TOTAL[4, 4];
						dataRow3["TDS_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
						dataRow3["TDS_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
					}
					else
					{
						dataRow3["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
						dataRow3["TDS_CODE"] = "";
						dataRow3["TDS_PRC"] = 0;
						dataRow3["TDS_AMT"] = 0;
					}
					dataRow3["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 27]);
					dataRow3["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 29]);
					dataRow3["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
					dataRow3["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
					dataRow3["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
					dataRow3["CARD_COM_AMT"] = Conversion.Val(MSG2_TOTAL[7, 2]);
					dataRow3["ADV_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
					dataRow3["CRNT_ADJ_AMT"] = Conversion.Val(MSG2_TOTAL[8, 1]);
					dataRow3["OLD_GL_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
					dataRow3["OLD_SL_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
					dataRow3["SCHM_AMT"] = Conversion.Val(MSG2_TOTAL[11, 3]);
					if (Operators.CompareString(FormBookType, "T", false) != 0)
					{
						dataRow3["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[12, 3]);
					}
					else if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
					{
						if (Conversion.Val(MSG2_TOTAL[9, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]) < Conversion.Val(MSG2_TOTAL[12, 3]))
						{
							dataRow3["CASH_AMT"] = Strings.Format((object)Math.Round(Conversion.Val(MSG2_TOTAL[12, 3]) + Conversion.Val(MSG2_TOTAL[9, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]), 0), "0.00");
						}
						else
						{
							dataRow3["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]) - Conversion.Val(MSG2_TOTAL[8, 3]) - Conversion.Val(MSG2_TOTAL[14, 3]);
						}
					}
					else
					{
						dataRow3["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[12, 3]);
					}
					dataRow3["UPI_AMT"] = Conversion.Val(MSG2_TOTAL[12, 1]);
					dataRow3["CASH_PAID"] = Conversion.Val(MSG2_TOTAL[13, 3]);
					dataRow3["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[14, 3]);
					dataRow3["BILL_OS"] = Conversion.Val(MSG2_TOTAL[15, 3]);
					dataRow3["OLD_GL"] = Conversion.Val(MSG2_TOTAL[9, 2]);
					dataRow3["OLD_SL"] = Conversion.Val(MSG2_TOTAL[10, 2]);
					dataRow3["CARD_AC"] = MSG2_TOTAL[7, 4];
					dataRow3["BANK_AC"] = MSG2_TOTAL[6, 4];
					dataRow3["CHQ_NO"] = MSG2_TOTAL[6, 2];
					dataRow3["SCHM_AC"] = MSG2_TOTAL[11, 4];
					dataRow3["POINT_VAL"] = Conversion.Val(MSG2_TOTAL[15, 2]);
					dataRow3["MEMB_COM_AC_CODE"] = tAcMembCode.Text;
					dataRow3["AC_MEMB_COM_PRC"] = 0;
					dataRow3["AC_MEMB_COM_VAL"] = Conversion.Val(MSG_TOT[0, 40]);
					dataRow3["WHOUT_COMM_BILL"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(chkWhoutcommBill.Checked, (object)"Y", (object)"N"));
					dataRow3["BANK_NAME"] = tBankName.Text;
					dataRow3["CARD_ADJ"] = CardCommAdj;
					dataRow3["CR_DAYS"] = Conversion.Val(nCrDays.Text);
					dataRow3["ADD1"] = tAdd1.Text;
					dataRow3["ADD2"] = tAdd2.Text;
					dataRow3["ADD3"] = tAdd3.Text;
					dataRow3["CITY"] = tCity.Text;
					dataRow3["MOBILE"] = tMobile.Text;
					dataRow3["AC_GST_TYPE"] = AcGstType;
					if (Conversion.Val(MSG2_TOTAL[2, 3]) != 0.0)
					{
						if (Operators.CompareString(AcGstType, "I", false) == 0)
						{
							dataRow3["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);
							dataRow3["SGST_TAX"] = 0;
							dataRow3["CGST_TAX"] = 0;
						}
						else
						{
							dataRow3["IGST_TAX"] = 0;
							dataRow3["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
							dataRow3["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
						}
					}
					else
					{
						dataRow3["IGST_TAX"] = 0;
						dataRow3["SGST_TAX"] = 0;
						dataRow3["CGST_TAX"] = 0;
					}
					dataRow3["HM_AMT"] = 0;
					dataRow3["HM_TAX_CODE"] = "";
					dataRow3["HM_TAX_PRC"] = 0;
					dataRow3["HM_TAX_AMT"] = 0;
					dataRow3["RTN_TOT_AMT"] = 0;
					dataRow3["RTN_CHQ_AMT"] = 0;
					dataRow3["RTN_CARD_AMT"] = 0;
					dataRow3["RTN_CASH_AMT"] = 0;
					dataRow3["RTN_KASAR_AMT"] = 0;
					dataRow3["RTN_BILL_OS"] = 0;
					dataRow3["RTN_MEMB_COM_PRC"] = 0;
					dataRow3["RTN_MEMB_COM_VAL"] = 0;
					dataRow3["ISU_NO"] = tIsuNo.Text;
					dataRow3["ISU_LC_CODE"] = DC_Main.MLc_code;
					dataRow3["ISU_YRCD"] = tIsuYrCd.Text;
					dataRow3["ISU_DBCD"] = tIsuDbCd.Text;
					dataRow3["EMP_CODE"] = tEmpCode.Text;
					dataRow3["VCH_DESC"] = tVchDesc.Text;
					if (Operators.CompareString(DC_Main.MsOsBillOrnaIsu, "N", false) == 0)
					{
						if (!chkBillOrnaIsu.Checked)
						{
							dataRow3["ORNA_ISU"] = "N";
						}
						else
						{
							dataRow3["ORNA_ISU"] = "Y";
						}
					}
					else
					{
						dataRow3["ORNA_ISU"] = "W";
					}
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["DATA_TRFR"] = "N";
					if (Operators.CompareString(DataTrfr, "Y", false) == 0)
					{
						dataRow3["RE_TRFR"] = "Y";
					}
					else
					{
						dataRow3["RE_TRFR"] = "N";
					}
					dataRow3["MAIN_USER"] = MainUser;
					dataRow3["USER_UPDATE"] = "N";
					dataRow3["USER_DELETE"] = "N";
					dataRow3["MOB_ENTRY_SAVE"] = "Y";
					if (chkRateUnFix.Checked)
					{
						dataRow3["RATE_UNFIX"] = "Y";
					}
					else
					{
						dataRow3["RATE_UNFIX"] = "N";
					}
					dataRow3["OZ_RATE"] = 0;
					dataRow3["OZ_CONV"] = 0;
					dataRow3["FX_RATE"] = 0;
					dataRow3["FX_CODE"] = "";
					dataRow3["MTL_RATE"] = 0;
					RsData.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
					RsData.Clear();
				}
				DC_Main.RsQry = "SELECT * FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow4 = RsDetl.NewRow();
				int num5 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num5)
				{
					AxMSFlexGrid mSG = MSG;
					if ((Operators.CompareString(mSG[DC_Main.i, 3], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 12]) + Conversion.Val(mSG[DC_Main.i, 27]) + Conversion.Val(mSG[DC_Main.i, 37]) + Conversion.Val(mSG[DC_Main.i, 30]) != 0.0))
					{
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow4["VCH_NO"] = tVchNo.Text;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow4["AC_CODE"] = tAcCode.Text;
						dataRow4["VCH_TYPE"] = FormBookSname;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						dataRow4["ENTRY_TYPE"] = "S";
						dataRow4["BOOK_NAME"] = FormMainBook;
						dataRow4["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow4["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 57]);
						dataRow4["IT_CODE"] = mSG[DC_Main.i, 3];
						if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
						{
							dataRow4["TAG_NO"] = "N";
							if (Operators.CompareString(mSG[DC_Main.i, 4], "", false) == 0)
							{
								dataRow4["TBL_CODE"] = "001";
							}
						}
						else
						{
							dataRow4["TAG_NO"] = mSG[DC_Main.i, 1];
							dataRow4["TBL_CODE"] = mSG[DC_Main.i, 4];
						}
						dataRow4["ORD_NO"] = mSG[DC_Main.i, 5];
						dataRow4["DESIGN_NO"] = mSG[DC_Main.i, 6];
						dataRow4["ITM_STYLE"] = mSG[DC_Main.i, 7];
						dataRow4["ITM_SIZE"] = mSG[DC_Main.i, 8];
						dataRow4["HM_ID"] = mSG[DC_Main.i, 9];
						dataRow4["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 10]);
						dataRow4["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 11]);
						dataRow4["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 12]);
						dataRow4["TAG_GWT"] = Conversion.Val(mSG[DC_Main.i, 97]);
						dataRow4["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow4["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow4["TAG_NWT"] = Conversion.Val(mSG[DC_Main.i, 98]);
						if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
						{
							dataRow4["TAG_GWT"] = Conversion.Val(mSG[DC_Main.i, 12]);
							dataRow4["TAG_NWT"] = Conversion.Val(mSG[DC_Main.i, 14]);
						}
						dataRow4["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 15]);
						dataRow4["FIX_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 16]);
						dataRow4["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 17]);
						dataRow4["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 18]);
						dataRow4["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow4["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 20]);
						dataRow4["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 24]);
						dataRow4["LBR_TYPE"] = mSG[DC_Main.i, 25];
						dataRow4["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 26]);
						dataRow4["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 27]);
						dataRow4["DISC_PRC"] = Conversion.Val(mSG[DC_Main.i, 31]);
						dataRow4["DISC_AMT"] = Conversion.Val(mSG[DC_Main.i, 32]);
						dataRow4["GHT_AMT"] = Conversion.Val(mSG[DC_Main.i, 28]);
						dataRow4["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 29]);
						dataRow4["RATE_WITH"] = mSG[DC_Main.i, 21];
						dataRow4["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 22]);
						dataRow4["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 23]);
						dataRow4["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 30]);
						dataRow4["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 35]);
						dataRow4["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 36]);
						dataRow4["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 37]);
						dataRow4["HM_AMT"] = 0;
						dataRow4["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 43]);
						dataRow4["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 46]);
						dataRow4["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 47]);
						dataRow4["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 48]);
						dataRow4["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 38]);
						dataRow4["KR_NAME"] = mSG[DC_Main.i, 41];
						dataRow4["RATE_TYPE"] = mSG[DC_Main.i, 58];
						dataRow4["IT_TYPE"] = mSG[DC_Main.i, 59];
						dataRow4["PR_CODE"] = mSG[DC_Main.i, 61];
						dataRow4["ITM_REMARK"] = mSG[DC_Main.i, 75];
						dataRow4["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 52]);
						dataRow4["ISU_NO"] = mSG[DC_Main.i, 78];
						dataRow4["ISU_LC_CODE"] = DC_Main.MLc_code;
						dataRow4["ISU_YRCD"] = mSG[DC_Main.i, 79];
						dataRow4["ISU_DBCD"] = mSG[DC_Main.i, 80];
						dataRow4["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 81]);
						dataRow4["HM_ID2"] = mSG[DC_Main.i, 86];
						dataRow4["HM_ID3"] = mSG[DC_Main.i, 87];
						dataRow4["HM_ID4"] = mSG[DC_Main.i, 88];
						dataRow4["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 89]);
						dataRow4["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 90]);
						dataRow4["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 91]);
						dataRow4["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 92]);
						dataRow4["AC_MEMB_COM_PRC"] = Conversion.Val(mSG[DC_Main.i, 39]);
						dataRow4["AC_MEMB_COM_VAL"] = Conversion.Val(mSG[DC_Main.i, 40]);
						dataRow4["ORD_LC_CODE"] = DC_Main.MLc_code;
						dataRow4["ORD_YRCD"] = mSG[DC_Main.i, 94];
						dataRow4["ORD_DBCD"] = mSG[DC_Main.i, 95];
						dataRow4["ORD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 96]);
						dataRow4["ORD_TAG_STK_ADD"] = mSG[DC_Main.i, 100];
						dataRow4["DESIGN_IMG_ID"] = mSG[DC_Main.i, 101];
						dataRow4["ITM_LOT"] = mSG[DC_Main.i, 2];
						dataRow4["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						if (Operators.CompareString(mSG[DC_Main.i, 34], "", false) != 0)
						{
							dataRow4["EMP_CODE"] = mSG[DC_Main.i, 34];
						}
						else
						{
							dataRow4["EMP_CODE"] = tEmpCode.Text;
						}
						dataRow4["MAIN_USER"] = MainUser;
						RsDetl.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG = null;
					DC_Main.i++;
				}
				if (Operators.CompareString(DC_Main.MsSlBillImg, "Y", false) == 0)
				{
					DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
					int num6 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num6)
					{
						AxMSFlexGrid mSG2 = MSG;
						TagItmImage(DC_Main.i);
						if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0 && PicImage.Image != null)
						{
							byte[] value;
							using (MemoryStream memoryStream = new MemoryStream())
							{
								Bitmap val = new Bitmap(PicImage.Image);
								try
								{
									((Image)val).Save((Stream)memoryStream, ImageFormat.Jpeg);
								}
								finally
								{
									((IDisposable)val)?.Dispose();
								}
								value = memoryStream.ToArray();
							}
							DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG2[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 52]))) ?? "";
							DataTable dataTable3 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
							Module_Save.MsInsertDataSave(Module_Save.SlTran);
							DataRow dataRow5 = dataTable3.NewRow();
							dataRow5["CO_CODE"] = DC_Main.MCo_code;
							dataRow5["LC_CODE"] = DC_Main.MLc_code;
							if (Operators.CompareString(mSG2[DC_Main.i, 101], "N", false) != 0)
							{
								dataRow5["TAG_NO"] = mSG2[DC_Main.i, 101];
							}
							else
							{
								dataRow5["TAG_NO"] = mSG2[DC_Main.i, 1];
							}
							dataRow5["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 52]);
							dataRow5["TAG_IMAGE"] = value;
							dataTable3.Rows.Add(dataRow5);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable3);
							dataTable3.Clear();
						}
						mSG2 = null;
						DC_Main.i++;
					}
				}
				DC_Main.RsQry = "SELECT * FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow6 = RsIdtl.NewRow();
				int num7 = 0;
				int num8 = 1;
				int num9 = 0;
				if (DtIdtl.Rows.Count > 0)
				{
					DataView dataView = new DataView(DtIdtl);
					dataView.Sort = "RowSrNo Asc";
					DtIdtl = dataView.ToTable();
				}
				int num10 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num10; i++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18])) != 0.0)
					{
						if ((double)num9 != Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])))
						{
							num9 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])));
							num8 = 1;
						}
						int num11 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])));
						int num12 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num12)
						{
							if ((double)num11 == Conversion.Val(MSG[DC_Main.M, 57]))
							{
								num7 = (int)Math.Round(Conversion.Val(MSG[DC_Main.M, 0]));
								break;
							}
							DC_Main.M++;
						}
						dataRow6["CO_CODE"] = DC_Main.MCo_code;
						dataRow6["LC_CODE"] = DC_Main.MLc_code;
						dataRow6["CO_YEAR"] = DC_Main.MCo_year;
						dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow6["VCH_NO"] = tVchNo.Text;
						dataRow6["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow6["VCH_DATE"] = mVchDate.Text;
						dataRow6["AC_CODE"] = tAcCode.Text;
						dataRow6["VCH_TYPE"] = FormBookSname;
						dataRow6["INOUT_TYPE"] = FormBookInOut;
						dataRow6["ENTRY_TYPE"] = "S";
						dataRow6["BOOK_NAME"] = FormMainBook;
						dataRow6["SR_NO"] = Conversion.Val(MSG[num7, 57]);
						dataRow6["TAG_NO"] = MSG[num7, 1];
						dataRow6["VCH_SRNO"] = Conversion.Val(MSG[num7, 52]);
						dataRow6["ISR_NO"] = num8;
						dataRow6["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
						dataRow6["DM_CODE"] = Operators.ConcatenateObject(DtIdtl.Rows[i][3], (object)"");
						dataRow6["DM_NAME"] = Operators.ConcatenateObject(DtIdtl.Rows[i][4], (object)"");
						dataRow6["DM_COLOR"] = Operators.ConcatenateObject(DtIdtl.Rows[i][5], (object)"");
						dataRow6["DM_SIZE"] = Operators.ConcatenateObject(DtIdtl.Rows[i][6], (object)"");
						dataRow6["DM_ORIGIN"] = Operators.ConcatenateObject(DtIdtl.Rows[i][7], (object)"");
						dataRow6["DM_REMARK"] = Operators.ConcatenateObject(DtIdtl.Rows[i][8], (object)"");
						dataRow6["DM_SFNO"] = Operators.ConcatenateObject(DtIdtl.Rows[i][9], (object)"");
						dataRow6["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
						dataRow6["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
						dataRow6["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
						dataRow6["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
						dataRow6["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]);
						dataRow6["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
						dataRow6["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
						dataRow6["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
						dataRow6["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
						dataRow6["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
						dataRow6["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
						dataRow6["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]);
						dataRow6["MAIN_USER"] = MainUser;
						num8++;
						RsIdtl.Rows.Add(dataRow6);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtl = null;
				}
				Module_Save.ExeQuteDcSave("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				RsOldDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow7 = RsOldDetl.NewRow();
				int num13 = MSG_OLD.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num13)
				{
					AxMSFlexGrid mSG_OLD = MSG_OLD;
					if ((Conversion.Val(MSG_OLD[DC_Main.i, 6]) + Conversion.Val(MSG_OLD[DC_Main.i, 13]) != 0.0) & (Operators.CompareString(MSG_OLD[DC_Main.i, 1], "", false) != 0))
					{
						dataRow7["CO_CODE"] = DC_Main.MCo_code;
						dataRow7["LC_CODE"] = DC_Main.MLc_code;
						dataRow7["CO_YEAR"] = DC_Main.MCo_year;
						dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow7["VCH_NO"] = tVchNo.Text;
						dataRow7["VCH_DATE"] = mVchDate.Text;
						dataRow7["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow7["AC_CODE"] = tAcCode.Text;
						dataRow7["VCH_TYPE"] = FormBookSname;
						dataRow7["INOUT_TYPE"] = FormBookInOut;
						dataRow7["ENTRY_TYPE"] = "A";
						dataRow7["BOOK_NAME"] = FormMainBook;
						dataRow7["SR_NO"] = Conversion.Val(mSG_OLD[DC_Main.i, 0]);
						dataRow7["IT_CODE"] = mSG_OLD[DC_Main.i, 1];
						dataRow7["IT_TYPE"] = mSG_OLD[DC_Main.i, 14];
						dataRow7["IT_DESC"] = mSG_OLD[DC_Main.i, 2];
						dataRow7["ITM_PCS"] = Conversion.Val(mSG_OLD[DC_Main.i, 3]);
						dataRow7["ITM_GWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 4]);
						dataRow7["ITM_OTH_WT"] = Conversion.Val(mSG_OLD[DC_Main.i, 5]);
						dataRow7["ITM_NWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 6]);
						dataRow7["ITM_TOUCH"] = Conversion.Val(mSG_OLD[DC_Main.i, 7]);
						dataRow7["ITM_FINE"] = Conversion.Val(mSG_OLD[DC_Main.i, 8]);
						dataRow7["CON_PRC"] = Conversion.Val(mSG_OLD[DC_Main.i, 9]);
						dataRow7["CON_WT"] = Conversion.Val(mSG_OLD[DC_Main.i, 10]);
						dataRow7["ITM_RATE"] = Conversion.Val(mSG_OLD[DC_Main.i, 11]);
						dataRow7["ITM_RATE_TYPE"] = mSG_OLD[DC_Main.i, 12];
						dataRow7["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 13]);
						dataRow7["PR_COST"] = Conversion.Val(mSG_OLD[DC_Main.i, 17]);
						dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow7["MAIN_USER"] = MainUser;
						dataRow7["HM_ID_WT"] = 0;
						dataRow7["HM_ID2_WT"] = 0;
						dataRow7["HM_ID3_WT"] = 0;
						dataRow7["HM_ID4_WT"] = 0;
						dataRow7["ITM_OTH"] = 0;
						RsOldDetl.Rows.Add(dataRow7);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsOldDetl);
						RsOldDetl.Clear();
					}
					mSG_OLD = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				DataTable dataTable4 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow8 = dataTable4.NewRow();
				if (Conversion.Val(MSG2_TOTAL[8, 3]) != 0.0)
				{
					AxMSFlexGrid mSG_ORD = MSG_ORD;
					int num14 = MSG_ORD.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num14)
					{
						if (Conversion.Val(MSG_ORD[DC_Main.i, 2]) != 0.0)
						{
							dataRow8["CO_CODE"] = DC_Main.MCo_code;
							dataRow8["LC_CODE"] = DC_Main.MLc_code;
							dataRow8["CO_YEAR"] = DC_Main.MCo_year;
							dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow8["VCH_NO"] = tVchNo.Text;
							dataRow8["SR_NO"] = DC_Main.i;
							dataRow8["VCH_DATE"] = mVchDate.Text;
							dataRow8["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow8["AC_CODE"] = tAcCode.Text;
							dataRow8["AC_NAME"] = tAcName.Text;
							dataRow8["VCH_TYPE"] = FormBookSname;
							dataRow8["INOUT_TYPE"] = FormBookInOut;
							dataRow8["ENTRY_TYPE"] = "S";
							dataRow8["BOOK_NAME"] = FormMainBook;
							dataRow8["ORD_HD_VCH_NO"] = mSG_ORD[DC_Main.i, 7];
							dataRow8["ORD_NO"] = mSG_ORD[DC_Main.i, 1];
							dataRow8["ORD_LC"] = mSG_ORD[DC_Main.i, 3];
							dataRow8["ORD_YRCD"] = mSG_ORD[DC_Main.i, 4];
							dataRow8["ORD_DBCD"] = mSG_ORD[DC_Main.i, 5];
							dataRow8["ORD_AC_CODE"] = mSG_ORD[DC_Main.i, 6];
							dataRow8["ORD_SIGN"] = "-";
							dataRow8["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);
							dataRow8["PAID_AC"] = "";
							dataRow8["PAID_AMT"] = 0;
							dataRow8["ORD_BAL_AMT"] = 0;
							dataRow8["ORD_GOLD"] = 0;
							dataRow8["ORD_SILVER"] = 0;
							dataRow8["KASAR_AMT"] = 0;
							dataRow8["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow8["DATA_TRFR"] = "N";
							dataRow8["EMP_CODE"] = tEmpCode.Text;
							dataRow8["IT_DESC"] = "";
							dataRow8["MAIN_USER"] = MainUser;
							dataTable4.Rows.Add(dataRow8);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable4);
							dataTable4.Clear();
						}
						DC_Main.i++;
					}
					mSG_ORD = null;
				}
				if ((Operators.CompareString(tAcCode.Text, "00045", false) != 0) & (Operators.CompareString(FormMainBook, "SL QUOT", false) != 0))
				{
					Module_Save.ExeQuteDcSave("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
					DC_Main.RsQry = "SELECT * FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
					RsBillOs = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
					DataRow dataRow9 = RsBillOs.NewRow();
					if (Conversion.Val(MSG2_TOTAL[5, 3]) != 0.0)
					{
						dataRow9["CO_CODE"] = DC_Main.MCo_code;
						dataRow9["LC_CODE"] = DC_Main.MLc_code;
						dataRow9["CO_YEAR"] = DC_Main.MCo_year;
						dataRow9["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow9["VCH_NO"] = tVchNo.Text;
						dataRow9["SR_NO"] = 1;
						dataRow9["VCH_DATE"] = mVchDate.Text;
						dataRow9["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow9["AC_CODE"] = tAcCode.Text;
						dataRow9["VCH_TYPE"] = FormBookSname;
						dataRow9["INOUT_TYPE"] = FormBookInOut;
						dataRow9["ENTRY_TYPE"] = "O";
						dataRow9["BOOK_NAME"] = FormMainBook;
						dataRow9["BILL_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
						dataRow9["OLD_ADJ_AMT"] = 0;
						dataRow9["REC_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]) - (Conversion.Val(MSG2_TOTAL[15, 3]) + Conversion.Val(MSG2_TOTAL[14, 3]));
						dataRow9["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[14, 3]);
						dataRow9["BILL_GOLD"] = 0;
						dataRow9["OLD_ADJ_GOLD"] = 0;
						dataRow9["REC_GOLD"] = 0;
						dataRow9["KASAR_GOLD"] = 0;
						dataRow9["BILL_SILVER"] = 0;
						dataRow9["OLD_ADJ_SILVER"] = 0;
						dataRow9["REC_SILVER"] = 0;
						dataRow9["KASAR_SILVER"] = 0;
						dataRow9["BILL_LC"] = DC_Main.MLc_code;
						dataRow9["BILL_YRCD"] = DC_Main.MCo_year;
						dataRow9["BILL_DBCD"] = DC_Main.MCo_Book;
						dataRow9["BILL_NO"] = tVchNo.Text;
						dataRow9["BILL_HD_VCH_NO"] = tHdVchNo.Text;
						dataRow9["BILL_SRNO"] = 1;
						dataRow9["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow9["MAIN_USER"] = MainUser;
						dataRow9["DATA_TRFR"] = "N";
						dataRow9["DATA_TYPE"] = "A";
						RsBillOs.Rows.Add(dataRow9);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBillOs);
						RsBillOs.Clear();
					}
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					if (Conversion.Val(nBillPoint.Text) != 0.0)
					{
						DC_Main.RsQry = "Delete FROM POINT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' AND SR_NO = 1 ";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
						DC_Main.RsQry = "SELECT * FROM POINT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' AND SR_NO = 1 ";
						DataTable dataTable5 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
						Module_Save.MsInsertDataSave(Module_Save.SlTran);
						DataRow dataRow10 = dataTable5.NewRow();
						dataRow10["CO_CODE"] = DC_Main.MCo_code;
						dataRow10["LC_CODE"] = DC_Main.MLc_code;
						dataRow10["CO_YEAR"] = DC_Main.MCo_year;
						dataRow10["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow10["VCH_NO"] = tVchNo.Text;
						dataRow10["VCH_DATE"] = mVchDate.Text;
						dataRow10["SR_NO"] = 1;
						dataRow10["MEMB_CODE"] = tAcCode.Text;
						dataRow10["POINT_CODE"] = tPointCode.Text;
						dataRow10["POINT_TYPE"] = "S";
						dataRow10["ITM_SIGN"] = "+";
						dataRow10["TOT_AMT"] = Conversion.Val(nPointBillVal.Text);
						dataRow10["POINT_VAL"] = Conversion.Val(nPointVal.Text);
						dataRow10["TOT_POINT"] = Conversion.Val(nBillPoint.Text);
						dataRow10["REF_CUST"] = tRefAc.Text;
						dataRow10["REF_NAME"] = tRefName.Text;
						dataTable5.Rows.Add(dataRow10);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable5);
						dataTable5.Clear();
					}
					if (Conversion.Val(nUsePoint.Text) != 0.0)
					{
						DC_Main.RsQry = "Delete FROM POINT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' AND SR_NO = 2 ";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
						DC_Main.RsQry = "SELECT * FROM POINT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' AND SR_NO = 2 ";
						DataTable dataTable5 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
						Module_Save.MsInsertDataSave(Module_Save.SlTran);
						DataRow dataRow11 = dataTable5.NewRow();
						dataRow11["CO_CODE"] = DC_Main.MCo_code;
						dataRow11["LC_CODE"] = DC_Main.MLc_code;
						dataRow11["CO_YEAR"] = DC_Main.MCo_year;
						dataRow11["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow11["VCH_NO"] = tVchNo.Text;
						dataRow11["VCH_DATE"] = mVchDate.Text;
						dataRow11["SR_NO"] = 2;
						dataRow11["MEMB_CODE"] = tAcCode.Text;
						dataRow11["POINT_CODE"] = tPointCode.Text;
						dataRow11["POINT_TYPE"] = "S";
						dataRow11["ITM_SIGN"] = "-";
						dataRow11["TOT_AMT"] = Conversion.Val(nUseVal.Text);
						dataRow11["POINT_VAL"] = Conversion.Val(nPointVal.Text);
						dataRow11["TOT_POINT"] = Conversion.Val(nUsePoint.Text);
						dataRow11["REF_CUST"] = "";
						dataRow11["REF_NAME"] = "";
						dataTable5.Rows.Add(dataRow11);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable5);
						dataTable5.Clear();
					}
				}
				DC_Main.RsQry = "DELETE FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow12 = RsDetl.NewRow();
				int num15 = MSG_UPI.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num15)
				{
					if ((Operators.CompareString(MSG_UPI[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[DC_Main.i, 5]) != 0.0))
					{
						dataRow12["CO_CODE"] = DC_Main.MCo_code;
						dataRow12["LC_CODE"] = DC_Main.MLc_code;
						dataRow12["CO_YEAR"] = DC_Main.MCo_year;
						dataRow12["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow12["VCH_NO"] = tVchNo.Text;
						dataRow12["SR_NO"] = DC_Main.i;
						dataRow12["AC_CODE"] = tAcCode.Text;
						dataRow12["VCH_DATE"] = mVchDate.Text;
						dataRow12["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow12["UPI_AC_CODE"] = MSG_UPI[DC_Main.i, 1];
						dataRow12["UPI_AC_NAME"] = MSG_UPI[DC_Main.i, 2];
						dataRow12["UPI_TYPE"] = MSG_UPI[DC_Main.i, 3];
						dataRow12["UPI_ID"] = MSG_UPI[DC_Main.i, 4];
						dataRow12["UPI_AMT"] = Conversion.Val(MSG_UPI[DC_Main.i, 5]);
						RsDetl.Rows.Add(dataRow12);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					DC_Main.i++;
				}
				DC_Main.RsQry = "Delete FROM CRNT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				if (Conversion.Val(MSG2_TOTAL[8, 1]) != 0.0)
				{
					DC_Main.RsQry = "SELECT * FROM CRNT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
					DataTable dataTable6 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
					DataRow dataRow13 = dataTable6.NewRow();
					AxMSFlexGrid mSG_CRNT = MSG_CRNT;
					int num16 = MSG_CRNT.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num16)
					{
						if (Conversion.Val(MSG_CRNT[DC_Main.i, 2]) != 0.0)
						{
							dataRow13["CO_CODE"] = DC_Main.MCo_code;
							dataRow13["LC_CODE"] = DC_Main.MLc_code;
							dataRow13["CO_YEAR"] = DC_Main.MCo_year;
							dataRow13["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow13["VCH_NO"] = tVchNo.Text;
							dataRow13["SR_NO"] = DC_Main.i;
							dataRow13["VCH_DATE"] = mVchDate.Text;
							dataRow13["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow13["AC_CODE"] = tAcCode.Text;
							dataRow13["AC_NAME"] = tAcName.Text;
							dataRow13["VCH_TYPE"] = FormBookSname;
							dataRow13["INOUT_TYPE"] = FormBookInOut;
							dataRow13["ENTRY_TYPE"] = "S";
							dataRow13["BOOK_NAME"] = FormMainBook;
							dataRow13["CRNT_HD_VCH_NO"] = mSG_CRNT[DC_Main.i, 7];
							dataRow13["CRNT_NO"] = mSG_CRNT[DC_Main.i, 1];
							dataRow13["CRNT_LC"] = mSG_CRNT[DC_Main.i, 3];
							dataRow13["CRNT_YRCD"] = mSG_CRNT[DC_Main.i, 4];
							dataRow13["CRNT_DBCD"] = mSG_CRNT[DC_Main.i, 5];
							dataRow13["CRNT_AC_CODE"] = mSG_CRNT[DC_Main.i, 6];
							dataRow13["CRNT_AMT"] = Conversion.Val(mSG_CRNT[DC_Main.i, 2]);
							dataRow13["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow13["DATA_TRFR"] = "N";
							dataRow13["EMP_CODE"] = tEmpCode.Text;
							dataRow13["MAIN_USER"] = MainUser;
							dataTable6.Rows.Add(dataRow13);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable6);
							dataTable6.Clear();
						}
						DC_Main.i++;
					}
					mSG_CRNT = null;
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM COMM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
					if (!chkWhoutcommBill.Checked)
					{
						string value2 = "";
						string value3 = "";
						DC_Main.RsQry = "SELECT AC_CITY,AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_CODE <> '00045' AND (AC_CITY <> '' OR  AC_AREA <> '')";
						DC_Main.Tbl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							value2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CITY"], (object)""));
							value3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_AREA"], (object)""));
						}
						int num17 = 0;
						DC_Main.RsQry = "SELECT AC_CODE,AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CITY = '" + tCity.Text + "' AND AC_SHARE_HOLDER_COM ='Y'";
						DC_Main.Tbl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							num17 = DC_Main.Tbl.Rows.Count;
						}
						DC_Main.RsQry = "SELECT * FROM COMM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
						RsComDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
						Module_Save.MsInsertDataSave(Module_Save.SlTran);
						DataRow dataRow14 = RsComDetl.NewRow();
						int num18 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num18)
						{
							AxMSFlexGrid mSG3 = MSG;
							if (Operators.CompareString(tAcMembCode.Text, "", false) != 0)
							{
								num17 = 1;
							}
							int num19 = num17;
							DC_Main.M = 1;
							while (DC_Main.M <= num19)
							{
								if ((Conversion.Val(MSG[DC_Main.i, 14]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 40]) != 0.0))
								{
									dataRow14["CO_CODE"] = DC_Main.MCo_code;
									dataRow14["LC_CODE"] = DC_Main.MLc_code;
									dataRow14["CO_YEAR"] = DC_Main.MCo_year;
									dataRow14["CO_BOOK"] = DC_Main.MCo_Book;
									dataRow14["VCH_NO"] = tVchNo.Text;
									dataRow14["VCH_DATE"] = mVchDate.Text;
									dataRow14["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow14["VCH_TYPE"] = FormBookSname;
									dataRow14["INOUT_TYPE"] = FormBookInOut;
									dataRow14["BOOK_NAME"] = FormMainBook;
									dataRow14["AC_CODE"] = tAcCode.Text;
									if (Operators.CompareString(tAcMembCode.Text, "", false) != 0)
									{
										dataRow14["MEMB_AC_CODE"] = tAcMembCode.Text;
									}
									else
									{
										dataRow14["MEMB_AC_CODE"] = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M - 1]["AC_CODE"]);
									}
									dataRow14["COM_TYPE"] = "";
									dataRow14["SR_NO"] = Conversion.Val(mSG3[DC_Main.i, 0]);
									dataRow14["ISR_NO"] = DC_Main.M;
									dataRow14["IT_CODE"] = mSG3[DC_Main.i, 3];
									dataRow14["TOT_NET_WT"] = Conversion.Val(mSG3[DC_Main.i, 14]) + Conversion.Val(mSG3[DC_Main.i, 17]);
									dataRow14["COM_WT"] = Conversion.Val(mSG3[DC_Main.i, 14]);
									dataRow14["COM_GHT"] = Conversion.Val(mSG3[DC_Main.i, 17]);
									dataRow14["ITM_TOUCH"] = Conversion.Val(mSG3[DC_Main.i, 106]);
									dataRow14["COM_PRC"] = Conversion.Val(mSG3[DC_Main.i, 39]);
									dataRow14["COM_FINE"] = Strings.Format((object)(Conversion.Val(mSG3[DC_Main.i, 40]) / (double)num17), "0.000");
									dataRow14["LBR_AMT"] = Conversion.Val(mSG3[DC_Main.i, 27]);
									dataRow14["NET_AMT"] = Conversion.Val(mSG3[DC_Main.i, 37]);
									dataRow14["COM_AMT"] = 0;
									dataRow14["ITM_TYPE"] = mSG3[DC_Main.i, 59];
									dataRow14["DATA_TYPE"] = "A";
									dataRow14["EMP_CODE"] = tEmpCode.Text;
									dataRow14["AC_CITY"] = value2;
									dataRow14["AC_AREA"] = value3;
									dataRow14["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow14["MAIN_USER"] = MainUser;
									RsComDetl.Rows.Add(dataRow14);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsComDetl);
									RsComDetl.Clear();
								}
								DC_Main.M++;
							}
							mSG3 = null;
							DC_Main.i++;
						}
					}
				}
				if (Operators.CompareString(FormBookType, "T", false) == 0)
				{
					if (Conversion.Val(MSG2_TOTAL[9, 3]) != 0.0)
					{
						DC_Main.RsQry = "UPDATE PR_DATA SET SL_BILL_NO = '" + tVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '043' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TOT_AMT = " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[9, 3])) + " AND AC_CODE = '" + tAcCode.Text + "'";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
					}
					if (Conversion.Val(MSG2_TOTAL[10, 3]) != 0.0)
					{
						DC_Main.RsQry = "UPDATE PR_DATA SET SL_BILL_NO = '" + tVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '044' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TOT_AMT = " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[10, 3])) + " AND AC_CODE = '" + tAcCode.Text + "'";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
					}
				}
				string text = "";
				string text2 = "";
				string text3 = "";
				if ((Operators.CompareString(DC_Main.SmsPwd, "", false) != 0) & (Operators.CompareString(DC_Main.SmsId, "", false) != 0))
				{
					if (((Operators.CompareString(DC_Main.MsAdminSms, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)) && Operators.CompareString(DC_Main.MsAdminMobile, "", false) != 0)
					{
						text = tAcName.Text + " Bill No = " + tVchNo.Text + " Total : " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[5, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[15, 3]));
						if (Operators.CompareString(DC_Main.SmsLink, "001", false) == 0)
						{
							text2 = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + DC_Main.MsAdminMobile + "&message=" + text + "&sender=JEWELL&route=1";
						}
						else if ((Operators.CompareString(DC_Main.SmsLink, "002", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "012", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "022", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "032", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "042", false) == 0))
						{
							text2 = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) != 0) ? ("https://sms.mobileadz.in/api/push.json?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + DC_Main.MsAdminMobile + "&text=" + text) : ("http://site.ping4sms.com/api/smsapi?key=" + DC_Main.SmsUser + "&route=2&sender=" + DC_Main.SmsId + "&number=" + DC_Main.MsAdminMobile + "&sms=" + text + "&templateid=1607100000000291855"));
						}
						WebBrowser1.Navigate(text2);
						WebBrowser1.Refresh();
					}
					if (((Operators.CompareString(DC_Main.MsCustSms, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)) && Operators.CompareString(tMobile.Text, "", false) != 0)
					{
						text3 = ((Operators.CompareString(DC_Main.MsOsBillSms, "Y", false) != 0) ? SmsDetail : ("Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[5, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[15, 3])) + " " + SmsDetail));
						if (Operators.CompareString(DC_Main.SmsLink, "001", false) == 0)
						{
							text2 = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + tMobile.Text + "&message=" + text3 + "&sender=JEWELL&route=1";
						}
						else if ((Operators.CompareString(DC_Main.SmsLink, "002", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "012", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "022", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "032", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "042", false) == 0))
						{
							text2 = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) != 0) ? ("https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + tMobile.Text + "&text=" + text3) : ("http://site.ping4sms.com/api/smsapi?key=" + DC_Main.SmsUser + "&route=2&sender=" + DC_Main.SmsId + "&number=" + tMobile.Text + "&sms=" + text3 + "&templateid=1607100000000291855"));
						}
						WebBrowser1.Navigate(text2);
						WebBrowser1.Refresh();
					}
				}
				if (Operators.CompareString(QtNo, "", false) == 0)
				{
					if (Operators.CompareString(DC_Main.MsOsBillSms, "Y", false) == 0)
					{
						WappMsg = "Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[5, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[15, 3])) + " " + SmsDetail;
					}
					else
					{
						WappMsg = SmsDetail;
					}
					AdminWappMsg = tAcName.Text + " Book = " + DC_Main.MCo_Book + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[5, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[15, 3]));
					if (Operators.CompareString(EntryMode, "E", false) == 0)
					{
						WappMsg = "";
						AdminWappMsg = "";
					}
					WappAcName = tAcName.Text;
					WappMobile = tMobile.Text;
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					int num20 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num20)
					{
						AxMSFlexGrid mSG4 = MSG;
						if (Operators.CompareString(mSG4[DC_Main.i, 104], "", false) != 0)
						{
							Module_Save.ExeQuteDcSave("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + mSG4[DC_Main.i, 103] + "' AND VCH_NO = '" + mSG4[DC_Main.i, 104] + "'", Module_Save.SlTran);
							Module_Save.ExeQuteDcSave("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + mSG4[DC_Main.i, 103] + "' AND VCH_NO = '" + mSG4[DC_Main.i, 104] + "'", Module_Save.SlTran);
							Module_Save.ExeQuteDcSave("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + mSG4[DC_Main.i, 103] + "' AND VCH_NO = '" + mSG4[DC_Main.i, 104] + "'", Module_Save.SlTran);
						}
						mSG4 = null;
						DC_Main.i++;
					}
				}
				if (Operators.CompareString(QtNo, "", false) != 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'", Module_Save.SlTran);
					Module_Save.ExeQuteDcSave("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'", Module_Save.SlTran);
					Module_Save.ExeQuteDcSave("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'", Module_Save.SlTran);
				}
				if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
				{
					DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.DATA_TYPE = C.DATA_TYPE FROM SL_DETL,BAR_DETL AS B,BOOK_DATA AS C WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = C.CO_CODE AND SL_DETL.LC_CODE = C.LC_CODE AND SL_DETL.CO_BOOK = C.CO_BOOK AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' AND SL_DETL.TAG_NO <> 'N' ";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
					DC_Main.RsQry = "UPDATE MAIN_STOCK SET MAIN_STOCK.DATA_TYPE = C.DATA_TYPE FROM SL_DETL,MAIN_STOCK AS B,BOOK_DATA AS C WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = C.CO_CODE AND SL_DETL.LC_CODE = C.LC_CODE AND SL_DETL.CO_BOOK = C.CO_BOOK AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' AND SL_DETL.TAG_NO <> 'N' ";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				}
				DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'Y'  FROM SL_ORD_DETL,SL_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.LC_CODE = A.LC_CODE AND SL_ORD_DETL.VCH_NO = A.ORD_NO AND SL_ORD_DETL.CO_YEAR = A.ORD_YRCD AND SL_ORD_DETL.CO_BOOK = A.ORD_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ORD_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y' FROM APR_DETL,SL_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.SR_NO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.CO_BOOK = '018'  AND B.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'N' FROM SL_DETL,BAR_DETL AS B WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Ledr.Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Rojmel.Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Tax.Sales_GST(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Stock.Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Stock.Dm_Sale_Detl(DC_Main.MCo_Book, tVchNo.Text);
				if (Operators.CompareString(MoVch, "", false) != 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + MoBook + "' AND VCH_NO = '" + MoVch + "'", Module_Save.SlTran);
					Module_Save.ExeQuteDcSave("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + MoBook + "' AND VCH_NO = '" + MoVch + "'", Module_Save.SlTran);
				}
				Module_Save.SlTran.Commit();
				Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
				DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,NET_AMT,TAX_AMT FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND TAX_AMT <> 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				double num23;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["TAX_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["NET_AMT"], (object)0, false))))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
						DataTable dataTable7 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						int num21 = 0;
						int num22 = dataTable7.Rows.Count - 1;
						for (num21 = 0; num21 <= num22; num21++)
						{
							if (Operators.ConditionalCompareObjectNotEqual(dataTable7.Rows[num21]["NET_AMT"], (object)0, false))
							{
								num23 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject(dataTable7.Rows[num21]["NET_AMT"], DC_Main.Rshlp.Rows[0]["TAX_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_TAX_AMT = " + Conversions.ToString(num23) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable7.Rows[num21]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable7.Rows[num21]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable7.Rows[num21]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable7.Rows[num21]["SR_NO"]), (object)"")));
							}
						}
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_TAX_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
					}
				}
				num23 = 0.0;
				DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,NET_AMT,DISC_AMT FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND DISC_AMT <> 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["DISC_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["NET_AMT"], (object)0, false))))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
						DataTable dataTable7 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						int num21 = 0;
						int num24 = dataTable7.Rows.Count - 1;
						for (num21 = 0; num21 <= num24; num21++)
						{
							if (Operators.ConditionalCompareObjectNotEqual(dataTable7.Rows[num21]["NET_AMT"], (object)0, false))
							{
								num23 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject(dataTable7.Rows[num21]["NET_AMT"], DC_Main.Rshlp.Rows[0]["DISC_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_DISC_AMT = " + Conversions.ToString(num23) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable7.Rows[num21]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable7.Rows[num21]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable7.Rows[num21]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable7.Rows[num21]["SR_NO"]), (object)"")));
							}
						}
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_DISC_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
					}
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
				{
					DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.TableCol();
					string text4 = "";
					int num25 = RsData.Columns.Count - 2;
					DC_Main.M = 0;
					while (DC_Main.M <= num25)
					{
						if (VchOldData.Rows.Count > 0 && Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
						{
							int num26 = DC_Main.RsTblCol.Rows.Count - 1;
							for (int j = 0; j <= num26; j++)
							{
								if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[j]["TBL_COL_NAME"], false))
								{
									text4 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[j]["COL_NAME"], (object)""));
								}
							}
							if (Operators.CompareString(text4, "", false) == 0)
							{
								text4 = RsData.Columns[DC_Main.M].ColumnName;
							}
							DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text4 + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','N')";
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							text4 = "";
						}
						DC_Main.M++;
					}
					DC_Main.RsTblCol.Clear();
				}
				if (Operators.CompareString(FormVchNo, "", false) != 0)
				{
					CLEAR_DATA();
					((Form)this).Close();
					return;
				}
				DC_Main.RsQry = "SELECT TOT_AMT FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						DC_Main.MsAcAmtOpBal -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TOT_AMT"])), "0.00"));
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						DC_Main.MsAcAmtOpBal += Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TOT_AMT"])), "0.00"));
					}
				}
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
				CustOpAmt = DC_Main.MsAcAmtOpBal;
				CustClAmt = DC_Main.MsAcAmtClBal;
				CurPrnMobile = tMobile.Text;
				CurPrnVch = tVchNo.Text;
				CLEAR_DATA();
				BtnPrint_Click(BtnPrint, new EventArgs());
				CurPrnVch = "";
				CurPrnMobile = "";
				CustOpAmt = 0.0;
				CustClAmt = 0.0;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Module_Save.SlTran.Rollback();
					Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Interaction.MsgBox((object)("Rollback Failed: " + ex4.Message), (MsgBoxStyle)0, (object)null);
					ProjectData.ClearProjectError();
				}
				((Control)BtnSave).Enabled = true;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_186d: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				return;
			}
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,TOT_AMT,OLD_GL_AMT+OLD_SL_AMT+CASH_AMT+CARD_AMT+CHQ_AMT-CASH_PAID+KASAR_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,150) FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,SR_NO,A.VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,A.VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,A.NET_AMT,0,A.IT_TYPE,0,A.ITM_NWT,A.HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + ' / ' + IT_CODE + '   TagNo' + ' / ' + TAG_NO FROM (SL_DATA AS C LEFT JOIN SL_DETL AS A ON C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE AND C.CO_YEAR = A.CO_YEAR AND C.CO_BOOK = A.CO_BOOK AND C.VCH_NO = A.VCH_NO)  LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'N'  FROM SL_ORD_DETL,SL_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.VCH_NO = A.ORD_NO AND SL_ORD_DETL.CO_YEAR = A.ORD_YRCD AND SL_ORD_DETL.CO_BOOK = A.ORD_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ORD_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' FROM APR_DETL,SL_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.SR_NO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.CO_BOOK = '018' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' FROM SL_DETL,BAR_DETL AS B WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APP_TRFR = 'N' FROM SL_DETL,BAR_DETL AS B WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM POINT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR='" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("Delete FROM CRNT_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.RsQry = "SELECT * FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						DC_Main.M++;
					}
				}
				DC_Main.RsQry = "SELECT * FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BILL_YRCD = '" + DC_Main.MCo_year + "' AND BILL_DBCD = '" + DC_Main.MCo_Book + "' AND BILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				}
				DC_Main.RsQry = "SELECT * FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SBILL_YRCD = '" + DC_Main.MCo_year + "' AND SBILL_DBCD = '" + DC_Main.MCo_Book + "' AND SBILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				}
				DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
		}
	}

	private void TR_SALE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			checked
			{
				if (((Control)TEXT_ENTRY).Visible)
				{
					MSG_LeaveCell(MSG, new EventArgs());
					MSG.Row = MSG.Rows - 1;
					MSG.Col = 0;
					((Control)TEXT_ENTRY).Visible = false;
					MSG_TOT_FILL();
					MSG2_TOTAL.Row = 1;
					MSG2_TOTAL.Col = 3;
					MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
					((Control)TEXT_ENTRY_2).Focus();
				}
				else if (((Control)TEXT_IDTL).Visible)
				{
					((Control)TEXT_IDTL).Visible = false;
					MSG.Col += 1;
					MSG_EnterCell(MSG, new EventArgs());
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
				else if (((Control)TEXT_ENTRY_2).Visible)
				{
					MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
					((Control)TEXT_ENTRY_2).Visible = false;
					((Control)tEmpCode).Focus();
				}
				else if (OldValTot == NewValTot)
				{
					((Form)this).Close();
				}
			}
		}
	}

	private async void BtnPrint_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsSlDupPrint, "Y", false) == 0)
		{
			DC_Main.MsDupPrintStatus = true;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr[(short)7] = "";
		string curPrnVch = CurPrnVch;
		if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsCustSms, "Y", false) == 0) & (Operators.CompareString(WappMsg, "", false) != 0))
		{
			await WappReport();
			await Task.Delay(3000);
		}
		Application.DoEvents();
		if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsAdminSms, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsAdminMobile, "", false) != 0))
		{
			await AdminWappReport();
			await Task.Delay(3000);
		}
		Application.DoEvents();
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0)
		{
			DC_Main.RptName = "SalesBillDubai";
			DC_Main.RptFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + curPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			return;
		}
		string rptName;
		if (chkHuIdPrint.Checked)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RtlHuidPrint.RPT";
			rptName = "RtlHuidPrint";
		}
		else if (Operators.CompareString(DC_Main.MCo_Book, "099", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesQuotation.RPT";
			rptName = "SalesQuotation";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
			rptName = cboPrintfile.Text;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0) & (Operators.CompareString(DC_Main.MCo_Book, "026", false) == 0))
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesBillHzGST.RPT";
			rptName = "SalesBillHzGST";
		}
		Cr.SelectionFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + curPrnVch + "'";
		if (!chkHuIdPrint.Checked)
		{
			Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
			Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		}
		if ((Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0) | chkWapp.Checked)
		{
			DC_Main.RsQry = "SELECT AC_EMAIL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_EMAIL <> ''";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)"")));
			}
			else
			{
				DC_Main.MsCustMail = "";
			}
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + CurPrnMobile;
			DC_Main.MsWappPrintType = "RtlSale";
			if (Operators.CompareString(DC_Main.MsWappSlPrint, "Y", false) == 0)
			{
				DC_Main.RptName = "SlBillWapp";
			}
			else
			{
				DC_Main.RptName = rptName;
			}
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.RptFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + curPrnVch + "'";
			UT_REPORT uT_REPORT2 = new UT_REPORT();
			((Control)uT_REPORT2).Show();
			((Control)uT_REPORT2).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				Cr[(short)1] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintTrip)
			{
				Cr[(short)1] = "InVoiceType = 'TRIPLICATE FOR TRANSPORTER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
		}
		else
		{
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
		DC_Main.MsPrintStatus = false;
	}

	private async Task WappReport()
	{
		if ((Strings.Len(WappMobile) > 5) & (Operators.CompareString(WappMsg, "", false) != 0))
		{
			try
			{
				if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) != 0)
				{
					string phone = DC_Main.MsCountryId + WappMobile;
					(bool, string) tuple = await whatsApp.SendMessageAsync(phone, WappMsg);
					if (!tuple.Item1)
					{
						Console.WriteLine("WhatsApp send failed: " + tuple.Item2);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				MessageBox.Show(ex3.Message);
				ProjectData.ClearProjectError();
			}
		}
		WappMsg = "";
		WappAcName = "";
		WappMobile = "";
	}

	private async Task AdminWappReport()
	{
		try
		{
			if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) != 0)
			{
				string phone = DC_Main.MsCountryId + DC_Main.MsAdminMobile;
				(bool, string) tuple = await whatsApp.SendMessageAsync(phone, AdminWappMsg);
				if (!tuple.Item1)
				{
					Console.WriteLine("WhatsApp send failed: " + tuple.Item2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show(ex3.Message);
			ProjectData.ClearProjectError();
		}
		AdminWappMsg = "";
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CurPrnMobile = "";
		CLEAR_DATA();
	}

	private void TR_SALE_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		DC_Main.MCo_Book = FormBook;
		DC_Main.MCo_BookType = FormBookType;
		lblBook.Text = FormName;
		if ((Operators.CompareString(FormVchNo, "", false) != 0) & (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0))
		{
			DC_Main.CurBookVch = "";
			tVchNo.Text = FormVchNo;
			DISPLAY_DATA();
			Application.DoEvents();
			((Control)TEXT_ENTRY).Visible = false;
			((Control)mVchDate).Focus();
			return;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			if ((Operators.CompareString(DC_Main.MsCode, "", false) != 0) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0) & (Operators.CompareString(tAcCode.Text, "00100", false) != 0))
			{
				tAcCode.Text = DC_Main.MsCode;
			}
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		if (DC_Main.MsSlAdj & (DC_Main.MsSlSchmAdj != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsSlSchmAdj, "0.00");
			MSG2_TOTAL[11, 3] = Strings.Format((object)DC_Main.MsSlSchmAdj, "0.00");
			DC_Main.MsSlSchmAdj = 0.0;
		}
		if ((DC_Main.MsOldPurcSl & !DC_Main.MsSlAdj & (DC_Main.MsOldPurcAmt != 0.0)) && Conversion.Val(MSG2_TOTAL[10, 3]) == 0.0)
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[10, 3] = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[10, 2] = Strings.Format((object)DC_Main.MsOldPurcWt, "0.000");
			DC_Main.MsOldPurcAmt = 0.0;
			DC_Main.MsOldPurcWt = 0.0;
			((Control)TEXT_ENTRY_2).Focus();
		}
		else if (DC_Main.MsOldPurc & !DC_Main.MsSlAdj & (DC_Main.MsOldPurcAmt != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[9, 3] = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[9, 2] = Strings.Format((object)DC_Main.MsOldPurcWt, "0.000");
			DC_Main.MsOldPurcAmt = 0.0;
			DC_Main.MsOldPurcWt = 0.0;
			((Control)TEXT_ENTRY_2).Focus();
		}
		else if (DC_Main.MsOpenSlRtn)
		{
			((Control)TEXT_CRNT).Focus();
			DC_Main.MsOpenSlRtn = false;
		}
		else if (DC_Main.MsCardSlAdj & (DC_Main.MsCardAdj != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsCardAdj, "0.00");
			MSG2_TOTAL[7, 3] = Strings.Format((object)DC_Main.MsCardAdj, "0.00");
			MSG2_TOTAL[7, 2] = Strings.Format((object)DC_Main.MsCardAdjComm, "0.00");
			MSG2_TOTAL[7, 1] = DC_Main.MsCardBankName;
			MSG2_TOTAL[7, 4] = DC_Main.MsCardBank;
			DC_Main.MsCardAdj = 0.0;
			DC_Main.MsCardAdjComm = 0.0;
			DC_Main.MsCardBankName = "";
			DC_Main.MsCardBank = "";
			((Control)TEXT_ENTRY_2).Focus();
		}
		else
		{
			((ContainerControl)this).ActiveControl = CurActCtrl;
			CurActCtrl.Focus();
		}
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS315NBBU", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,BILL_NO As RefNoL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_MOBILE As MobileL,A.MAIN_USER As UserL,TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,BILL_NO As RefNoL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_REF_NAME As RefByL,A.MAIN_USER As UserL,TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 105.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 275.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.ColWidth[5] = 200.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.ColWidth[7] = 110.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				CLEAR_DATA();
				tVchNo.Text = DC_Main.ColValue[0];
				DISPLAY_DATA();
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MsgClear || MSG.Row == 0)
		{
			return;
		}
		checked
		{
			if ((MsgOldRow != MSG.Row) & !MsgClear)
			{
				MsgOldRow = MSG.Row;
				if (Operators.CompareString(MSG[MSG.Row, 88], "", false) != 0)
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 62] + "  Hu2 : " + MSG[MSG.Row, 86] + "  Hu3 : " + MSG[MSG.Row, 87] + "  Hu4 : " + MSG[MSG.Row, 88];
				}
				else if (Operators.CompareString(MSG[MSG.Row, 87], "", false) != 0)
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 62] + "  Hu2 : " + MSG[MSG.Row, 86] + "  Hu3 : " + MSG[MSG.Row, 87];
				}
				else if (Operators.CompareString(MSG[MSG.Row, 86], "", false) != 0)
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 62] + "  Hu2 : " + MSG[MSG.Row, 86];
				}
				else
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 62];
				}
				tItDesc.Text = MSG[MSG.Row, 75];
				MSG_IDTL_CLEAR();
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				int row = MSG.Row;
				int num4 = 1;
				int num5 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if (Conversion.Val(MSG[MSG.Row, 57] ?? "") == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])))
					{
						MSG_IDTL[num4, 0] = Conversions.ToString(num4);
						MSG_IDTL[num4, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
						MSG_IDTL[num4, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
						MSG_IDTL[num4, 3] = Conversions.ToString(DtIdtl.Rows[i][3]);
						MSG_IDTL[num4, 4] = Conversions.ToString(DtIdtl.Rows[i][4]);
						MSG_IDTL[num4, 5] = Conversions.ToString(DtIdtl.Rows[i][5]);
						MSG_IDTL[num4, 6] = Conversions.ToString(DtIdtl.Rows[i][6]);
						MSG_IDTL[num4, 7] = Conversions.ToString(DtIdtl.Rows[i][7]);
						MSG_IDTL[num4, 8] = Conversions.ToString(DtIdtl.Rows[i][8]);
						MSG_IDTL[num4, 9] = Conversions.ToString(DtIdtl.Rows[i][9]);
						MSG_IDTL[num4, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
						MSG_IDTL[num4, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
						MSG_IDTL[num4, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
						MSG_IDTL[num4, 12] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][12], (object)""));
						MSG_IDTL[num4, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
						MSG_IDTL[num4, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
						MSG_IDTL[num4, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
						MSG_IDTL[num4, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
						MSG_IDTL[num4, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
						MSG_IDTL[num4, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
						MSG_IDTL[num4, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
						MSG_IDTL[num4, 21] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][21], (object)""));
						MSG_IDTL[num4, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
						MSG_IDTL[num4, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
						num3 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][21], (object)""));
						MSG_IDTL.Rows += 1;
						num4++;
					}
				}
				if (num2 != 0.0)
				{
					MSG[MSG.Row, 13] = Strings.Format((object)num2, "0.000");
					MSG[MSG.Row, 84] = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 13]), "0.000");
				}
				if (num3 != 0.0)
				{
					MSG[MSG.Row, 42] = Strings.Format((object)num3, "0.000");
					MSG[MSG.Row, 43] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 42])), "0.000");
				}
				if (num != 0.0)
				{
					MSG[MSG.Row, 29] = Strings.Format((object)num, "0.00");
				}
				ItmStk(MSG.Row);
				CommPassTotal();
				TagItmImage(MSG.Row);
				MSG_IDTL[num4, 0] = Conversions.ToString(num4);
				MSG_IDTL[num4, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 57]));
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				ItmProfit(MSG.Row);
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0) | ((Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)))
			{
				ItmProfit(MSG.Row);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TagItmImage(int Row)
	{
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Expected O, but got Unknown
		PicImage.Image = null;
		DataTable dataTable;
		if ((Operators.CompareString(MSG[Row, 101], "N", false) != 0) & (Operators.CompareString(MSG[Row, 6], "", false) != 0))
		{
			DC_Main.MsImageNo = MSG[Row, 101];
			DC_Main.MsImageType = "TagImage";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
				return;
			}
			DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[Row, 101] + "' AND IMAGE_TYPE = 'D'";
			dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
				{
					PicImage.Image = null;
					return;
				}
				object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
				byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
				object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
				PicImage.Image = (Image)objectValue;
			}
			return;
		}
		DC_Main.MsImageNo = MSG[Row, 1] + "_" + MSG[Row, 52];
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
		{
			try
			{
				string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
				return;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[Row, 52]))) ?? "";
				dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						PicImage.Image = null;
						ProjectData.ClearProjectError();
						return;
					}
					object obj2 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
					byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
					object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
					PicImage.Image = (Image)objectValue2;
				}
				else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					Image image;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					PicImage.Image = image;
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[Row, 52]))) ?? "";
		dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
			{
				PicImage.Image = null;
				return;
			}
			object obj3 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
			byte[] bA3 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj3));
			object objectValue3 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA3));
			PicImage.Image = (Image)objectValue3;
		}
		else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			Image image2;
			using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
			{
				image2 = Image.FromStream(stream2);
			}
			PicImage.Image = image2;
		}
	}

	private void ItmProfit(int Row)
	{
		double num = 0.0;
		double num2 = 0.0;
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(mSG[Row, 59], "G", false) == 0)
		{
			num = ToDayGlRate;
		}
		else if (Operators.CompareString(mSG[Row, 59], "S", false) == 0)
		{
			num = ToDaySlRate;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
		{
			DC_Main.RsQry = "SELECT B.GR_TOUCH FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + mSG[Row, 3] + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if ((DC_Main.Tbl.Rows.Count > 0) & (Conversion.Val(mSG[Row, 22]) != 0.0))
			{
				num = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 22]) * 100.0 / Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["GR_TOUCH"], (object)""))), "0.00"));
			}
		}
		if (Conversion.Val(mSG[Row, 30]) != 0.0)
		{
			nItProfit.Text = "PrCost = " + Strings.Format((object)Conversion.Val(mSG[Row, 38]), "0.00") + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 37]) - Conversion.Val(mSG[Row, 38])), "0.00");
			mSG[Row, 99] = Conversions.ToString(Conversion.Val(mSG[Row, 37]) - Conversion.Val(mSG[Row, 38]));
		}
		else if ((Conversion.Val(mSG[Row, 48]) != 0.0) & (Operators.CompareString(mSG[Row, 1], "", false) != 0))
		{
			double num3 = Conversion.Val(mSG[Row, 38]);
			num2 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 48]) * num + Conversion.Val(mSG[Row, 38])), "0.00"));
			nItProfit.Text = "Kf = " + mSG[Row, 48] + "  Fr = " + Conversions.ToString(num) + "  Ko = " + Strings.Format((object)Conversion.Val(mSG[Row, 38]), "0.00") + " = " + Conversions.ToString(num2) + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 35]) - num2), "0.00");
			mSG[Row, 99] = Conversions.ToString(Conversion.Val(mSG[Row, 35]) - num2);
		}
		else
		{
			double num4 = 0.0;
			DC_Main.RsQry = "SELECT AVG_TOUCH FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[Row, 3] + "' AND AVG_TOUCH <> 0";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				if (Conversion.Val(mSG[Row, 14]) != 0.0)
				{
					num4 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 14]) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AVG_TOUCH"])) / 100.0), "0.000"));
					num2 = Conversions.ToDouble(Strings.Format((object)(num4 * num), "0.00"));
					nItProfit.Text = "Kf = " + Conversions.ToString(num4) + "  Fr = " + Conversions.ToString(num) + " = " + Conversions.ToString(num2) + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 35]) - num2), "0.00");
					mSG[Row, 99] = Conversions.ToString(Conversion.Val(mSG[Row, 35]) - num2);
				}
			}
			else
			{
				nItProfit.Text = "It Profit :";
			}
		}
		if (!(((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) == 0)))
		{
			nItProfit.Text = "";
		}
		mSG = null;
	}

	private void tVchNo_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)tVchNo).ReadOnly = false;
	}

	private void TVchNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tVchNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			BtnF1_Click(BtnF1, new EventArgs());
		}
		if ((int)e.KeyCode == 38)
		{
			BtnLast_Click(BtnLast, new EventArgs());
		}
		if ((int)e.KeyCode == 40)
		{
			BtnFirst_Click(BtnFirst, new EventArgs());
		}
		if ((int)e.KeyCode == 13)
		{
			DISPLAY_DATA();
		}
		if (!(((int)e.KeyCode == 86) & e.Control))
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_CODE MasterAcL,B.AC_NAME As AcMastNameL,A.AC_CODE As VchAcL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.AC_NAME <> A.AC_NAME AND A.AC_CODE <> '00045'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 0.0;
		DC_Main.ColWidth[5] = 300.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 150.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				CLEAR_DATA();
				tVchNo.Text = DC_Main.ColValue[0];
				DISPLAY_DATA();
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	private void mVchDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mVchDate).SelectionStart = 0;
		((TextBoxBase)mVchDate).SelectionLength = Strings.Len(mVchDate.Text);
	}

	private void mVchDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			DC_Main.MsReqBook = DC_Main.MCo_Book;
			DC_Main.MsReqVch = tVchNo.Text;
			DC_Main.MsReqUser = DC_Main.MCo_User;
			DC_Main.MsReqAc = tAcCode.Text;
			((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();
		}
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mVchDate;
			DC_Main.SetDate(ref MsDate);
			mVchDate = MsDate;
			if (!DC_Main.RongDate)
			{
				TodayFineRate();
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void BtnFirst_Click(object sender, EventArgs e)
	{
		if (Conversion.Val(tVchNo.Text) < 2.0)
		{
			return;
		}
		string text = Strings.Format((object)(Conversion.Val(tVchNo.Text) - 1.0), "00000");
		DC_Main.i = 1;
		checked
		{
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count != 0 || Conversion.Val(text) == 1.0)
				{
					break;
				}
				text = Strings.Format((object)(Conversion.Val(text) - 1.0), "00000");
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			CLEAR_DATA();
			tVchNo.Text = text;
			DISPLAY_DATA();
			((Control)tVchNo).Focus();
		}
	}

	private void BtnLast_Click(object sender, EventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Conversion.Val(tVchNo.Text) >= Conversion.Val(LastVchNo))
		{
			Interaction.MsgBox((object)"Last Record...", (MsgBoxStyle)0, (object)null);
			((Control)tVchNo).Focus();
			return;
		}
		string text = Strings.Format((object)(Conversions.ToDouble(tVchNo.Text) + 1.0), "00000");
		DC_Main.i = 1;
		checked
		{
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count != 0 || Conversion.Val(text) == Conversion.Val(LastVchNo))
				{
					break;
				}
				text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			CLEAR_DATA();
			tVchNo.Text = text;
			DISPLAY_DATA();
			((Control)tVchNo).Focus();
		}
	}

	private void PicImage_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicImage.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void PicZoom_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = null;
		((Control)PicZoom).Dock = (DockStyle)0;
		((Control)PicZoom).Visible = false;
	}

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void TR_SALE_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		DC_Main.MsTagVchSrnoUpdate = false;
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsMobileHelp, "N", false) == 0 || ((Operators.CompareString(DC_Main.MsSoftType, "A", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0)))
		{
			return;
		}
		if (Strings.Len(tAcCode.Text) == 0)
		{
			MobHelpOpen = true;
		}
		if ((Operators.CompareString(EntryMode, "E", false) == 0) & !MobHelpOpen)
		{
			((TextBoxBase)tAcCode).SelectAll();
			return;
		}
		if (Strings.Len(tAcCode.Text) > 3)
		{
			MobileSearch = true;
		}
		else
		{
			MobileSearch = false;
		}
		if (!((Strings.Len(tAcCode.Text) >= 2) & !MobileSearch & Versioned.IsNumeric((object)tAcCode.Text)))
		{
			return;
		}
		DC_Main.MsMobileLen = tAcCode.Text;
		MobileSearch = true;
		if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.AC_MOBILE As MobileL,A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND SUBSTRING(A.AC_MOBILE,1,2)  = '" + Strings.Mid(tAcCode.Text, 1, 2) + "'  ORDER BY A.AC_MOBILE";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.AC_MOBILE As MobileL,A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND SUBSTRING(A.AC_MOBILE,1,2)  = '" + Strings.Mid(tAcCode.Text, 1, 2) + "'  ORDER BY A.AC_MOBILE";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 120.0;
		DC_Main.ColWidth[1] = 300.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (DC_Main.HelpClose)
		{
			return;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsGrCode = "20";
			MS_ACCT mS_ACCT = new MS_ACCT();
			((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)mS_ACCT).Show();
			((Control)mS_ACCT).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			tAcCode.Text = DC_Main.ColValue[2];
			tAcName.Text = DC_Main.ColValue[1];
			tAdd1.Text = DC_Main.ColValue[3];
			tCity.Text = DC_Main.ColValue[4];
			tMobile.Text = DC_Main.ColValue[0];
		}
		MobileSearch = false;
		((Control)tAcCode).Focus();
		((TextBoxBase)tAcCode).SelectAll();
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_2c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c57: Invalid comparison between Unknown and I4
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f46: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0 && (int)e.KeyCode == 112)
		{
			DC_Main.F1Search = true;
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.AC_ADD2 As Add2,A.AC_ADD3 As Add3,A.AC_GSTNO As Gst,A.AC_REF_NAME As Ref,A.BR_DATE As BrDt,A.AN_DATE As AnDt FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0, (object)"", (object)" AND A.AC_GR <> '15'")), (object)" ORDER BY A.LC_CODE,A.AC_NAME"));
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL,C.AC_ADD2 As Add2,C.AC_ADD3 As Add3,C.AC_GSTNO As Gst,C.AC_REF_NAME As Ref,C.BR_DATE As BrDt,C.AN_DATE As AnDt FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_ADD2,A.AC_ADD3,A.AC_GSTNO,A.AC_REF_NAME,A.BR_DATE,A.AN_DATE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0, (object)"", (object)" AND A.AC_GR <> '15'")), (object)" AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.AC_ADD2 As Add2,A.AC_ADD3 As Add3,A.AC_GSTNO As Gst,A.AC_REF_NAME As Ref,A.BR_DATE As BrDt,A.AN_DATE As AnDt FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0, (object)"", (object)" AND A.AC_GR <> '15'")), (object)" ORDER BY A.AC_NAME"));
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[13];
			DC_Main.ColWidth[0] = 270.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 170.0;
			DC_Main.ColWidth[3] = 180.0;
			DC_Main.ColWidth[4] = 220.0;
			DC_Main.ColWidth[5] = 160.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.ColWidth[7] = 0.0;
			DC_Main.ColWidth[8] = 0.0;
			DC_Main.ColWidth[9] = 0.0;
			DC_Main.ColWidth[10] = 0.0;
			DC_Main.ColWidth[11] = 0.0;
			DC_Main.ColWidth[12] = 0.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (DC_Main.MsCreat)
			{
				DC_Main.MsGrCode = "20";
				MS_ACCT mS_ACCT = new MS_ACCT();
				((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ACCT).Show();
				((Control)mS_ACCT).Focus();
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					((Control)PnlUpdate).Visible = true;
					UAdd1.Text = DC_Main.ColValue[4];
					UAdd2.Text = DC_Main.ColValue[7];
					UAdd3.Text = DC_Main.ColValue[8];
					UCity.Text = DC_Main.ColValue[5];
					UGstNo.Text = DC_Main.ColValue[9];
					URefBy.Text = DC_Main.ColValue[10];
					UMobile.Text = DC_Main.ColValue[6];
					UBrDate.Text = DC_Main.ColValue[11];
					UAnvDate.Text = DC_Main.ColValue[12];
					AcImgShow();
				}
			}
			((TextBoxBase)tAcCode).SelectAll();
			((Control)tAcCode).Focus();
		}
		else if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			tAcCode.Text = "";
			tAcName.Text = "";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_REF_NAME As RefByL,TOT_AMT As BillAmtR,A.CO_BOOK As MBookL FROM (SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  C.WITH_MOBILE_ENTRY = 'Y'  ORDER BY A.VCH_NO";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_REF_NAME As RefByL,TOT_AMT As BillAmtR,A.CO_BOOK As MBookL FROM (SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND (A.CO_BOOK = '033' OR C.WITH_MOBILE_ENTRY = 'Y' ) ORDER BY A.VCH_NO";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[8];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 200.0;
			DC_Main.ColWidth[4] = 250.0;
			DC_Main.ColWidth[5] = 120.0;
			DC_Main.ColWidth[6] = 100.0;
			DC_Main.HelpSelect = 0;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose || DC_Main.HelpClose)
			{
				return;
			}
			checked
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					CLEAR_DATA();
					MoBook = DC_Main.ColValue[6];
					MoVch = DC_Main.ColValue[0];
					DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + MoBook + "' AND VCH_NO = '" + MoVch + "'";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (RsData.Rows.Count > 0)
					{
						tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
						tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
						DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
						DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.RsAc.Rows.Count > 0)
						{
							tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
						}
						OldAcCode = tAcCode.Text;
						tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
						AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
						DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
						if (DC_Main.MsAcAmtOpBal > 0.0)
						{
							LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
							((Control)LOpAmt).ForeColor = Color.Blue;
						}
						else if (DC_Main.MsAcAmtOpBal < 0.0)
						{
							LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
							((Control)LOpAmt).ForeColor = Color.Red;
						}
						else
						{
							LOpAmt.Text = ": Amt";
						}
						CustOpAmt = DC_Main.MsAcAmtOpBal;
						DC_Main.MsAcAmtOpBal = 0.0;
						DC_Main.MsAcGoldOpBal = 0.0;
						DC_Main.MsAcSilverOpBal = 0.0;
						DC_Main.MsAcAmtClBal = 0.0;
						DC_Main.MsAcGoldClBal = 0.0;
						DC_Main.MsAcSilverClBal = 0.0;
					}
					DtIdtl.Clear();
					DtIdtl.Reset();
					FilRow = 0;
					int num = MSG_IDTL.Cols - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
						DC_Main.M++;
					}
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.PR_CODE,B.RATE_TYPE,B.IT_TYPE FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + MoBook + "' AND A.VCH_NO = '" + MoVch + "' ORDER BY A.SR_NO";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					AxMSFlexGrid mSG = MSG;
					while (DC_Main.i < RsDetl.Rows.Count)
					{
						mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 57] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"", false))
						{
							mSG[DC_Main.i + 1, 1] = "";
							mSG[DC_Main.i + 1, 11] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
							mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i + 1, 97] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
							if (Conversion.Val(mSG[DC_Main.i + 1, 37]) == 0.0)
							{
								mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
							}
							mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
							mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
							mSG[DC_Main.i + 1, 52] = Conversions.ToString(0);
						}
						else
						{
							mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
							mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE,B.AC_MEMB_COM_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), RsDetl.Rows[DC_Main.i]["TAG_NO"]), (object)""), (object)"' AND A.ITM_GWT = '"), RsDetl.Rows[DC_Main.i]["ITM_GWT"]), (object)"' ORDER BY A.VCH_TIME DESC "));
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
								mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
								mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
								mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
								mSG[DC_Main.i + 1, 11] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
								mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i + 1, 97] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
								mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								mSG[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"", false))
								{
									mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
								}
								mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")), "0.000");
								mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
								AxMSFlexGrid obj = mSG;
								int num2 = DC_Main.i + 1;
								object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"], (object)"");
								obj[num2, 49] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
								AxMSFlexGrid obj2 = mSG;
								int num3 = DC_Main.i + 1;
								Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"], (object)"");
								obj2[num3, 50] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
								mSG[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"], (object)"")), "0.00");
								AxMSFlexGrid obj3 = mSG;
								int num4 = DC_Main.i + 1;
								Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"");
								obj3[num4, 38] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
								mSG[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
								AxMSFlexGrid obj4 = mSG;
								int num5 = DC_Main.i + 1;
								Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"");
								obj4[num5, 56] = Strings.Format((object)DC_Main.Fnv(ref Value), "0");
								mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
								mSG[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
								mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
								mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
								if (Conversion.Val(mSG[DC_Main.i + 1, 37]) == 0.0)
								{
									mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
								}
								lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" Itm : ", DC_Main.Rshlp.Rows[0]["IT_NAME"]), (object)""));
								mSG[DC_Main.i + 1, 86] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
								mSG[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
								mSG[DC_Main.i + 1, 88] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
								mSG[DC_Main.i + 1, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
								mSG[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
								mSG[DC_Main.i + 1, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
								mSG[DC_Main.i + 1, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
								if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
								{
									DC_Main.RsQry = "Select AC_MEMB_COM_PRC From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 3] + "' AND AC_CODE  = '" + tAcMembCode.Text + "' AND AC_MEMB_COM_PRC <> 0";
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
									}
									else
									{
										mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
									}
								}
							}
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG[DC_Main.i + 1, 1]), (object)"' AND A.VCH_SRNO = "), (object)mSG[DC_Main.i + 1, 52]), (object)" "));
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.M = 0;
							while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
							{
								dr = DtIdtl.NewRow();
								dr[23] = Conversion.Val(MSG[DC_Main.i + 1, 57]);
								dr[0] = DC_Main.M + 1;
								dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"], (object)"");
								dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"], (object)"");
								dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_CODE"], (object)"");
								dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_NAME"], (object)"");
								dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_COLOR"], (object)"");
								dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_SIZE"], (object)"");
								dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_ORIGIN"], (object)"");
								dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_REMARK"], (object)"");
								dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_SFNO"], (object)"");
								dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_PCS"]);
								dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_GWT"])), "0.000");
								dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_WT"])), "0.000");
								dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CON_PRC"])), "0.000");
								dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_RATE_TYPE"], (object)"");
								dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_RATE"])), "0.00");
								dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_AMT"])), "0.00");
								dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_LBR_RATE"])), "0.00");
								dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_LBR_AMT"])), "0.00");
								dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NET_AMT"])), "0.00");
								dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CON_WT"])), "0.000");
								dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["KR_CON_WT"], (object)"")), "0.000");
								dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"], (object)"");
								DtIdtl.Rows.Add(dr);
								DC_Main.M++;
							}
						}
						ItmStk(MSG.Row);
						CommPassTotal();
						mSG.Rows += 1;
						DC_Main.i++;
					}
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					mSG = null;
				}
				else
				{
					MoBook = "";
					MoVch = "";
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			if ((int)e.KeyCode != 13)
			{
				return;
			}
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.AC_ADD2 As Add2,A.AC_ADD3 As Add3,A.AC_GSTNO As Gst,A.AC_REF_NAME As Ref,A.BR_DATE As BrDt,A.AN_DATE As AnDt FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0, (object)"", (object)" AND A.AC_GR <> '15'")), (object)" ORDER BY A.LC_CODE,A.AC_NAME"));
				}
				else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL,C.AC_ADD2 As Add2,C.AC_ADD3 As Add3,C.AC_GSTNO As Gst,C.AC_REF_NAME As Ref,C.BR_DATE As BrDt,C.AN_DATE As AnDt FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_ADD2,A.AC_ADD3,A.AC_GSTNO,A.AC_REF_NAME,A.BR_DATE,A.AN_DATE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0, (object)"", (object)" AND A.AC_GR <> '15'")), (object)" AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME "));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.AC_ADD2 As Add2,A.AC_ADD3 As Add3,A.AC_GSTNO As Gst,A.AC_REF_NAME As Ref,A.BR_DATE As BrDt,A.AN_DATE As AnDt FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0, (object)"", (object)" AND A.AC_GR <> '15'")), (object)" ORDER BY A.AC_NAME"));
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[13];
				DC_Main.ColWidth[0] = 270.0;
				DC_Main.ColWidth[1] = 80.0;
				DC_Main.ColWidth[2] = 170.0;
				DC_Main.ColWidth[3] = 180.0;
				DC_Main.ColWidth[4] = 220.0;
				DC_Main.ColWidth[5] = 160.0;
				DC_Main.ColWidth[6] = 110.0;
				DC_Main.ColWidth[7] = 0.0;
				DC_Main.ColWidth[8] = 0.0;
				DC_Main.ColWidth[9] = 0.0;
				DC_Main.ColWidth[10] = 0.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (DC_Main.MsCreat)
				{
					DC_Main.MsGrCode = "20";
					MS_ACCT mS_ACCT2 = new MS_ACCT();
					((Form)mS_ACCT2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)mS_ACCT2).Show();
					((Control)mS_ACCT2).Focus();
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
					if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
					{
						((Control)PnlUpdate).Visible = true;
						UAdd1.Text = DC_Main.ColValue[4];
						UAdd2.Text = DC_Main.ColValue[7];
						UAdd3.Text = DC_Main.ColValue[8];
						UCity.Text = DC_Main.ColValue[5];
						tCity.Text = DC_Main.ColValue[5];
						UGstNo.Text = DC_Main.ColValue[9];
						URefBy.Text = DC_Main.ColValue[10];
						UMobile.Text = DC_Main.ColValue[6];
						UBrDate.Text = DC_Main.ColValue[11];
						UAnvDate.Text = DC_Main.ColValue[12];
						tAcMobile.Text = DC_Main.ColValue[6] + " - " + DC_Main.ColValue[4];
						AcImgShow();
					}
				}
				((TextBoxBase)tAcCode).SelectAll();
				((Control)tAcCode).Focus();
				return;
			}
			((Control)PnlUpdate).Visible = false;
			if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			}
			if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
			{
				OldAcCode = tAcCode.Text;
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CR_DAYS"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CITY"], (object)""));
				if ((Operators.CompareString(tAcCode.Text, "00045", false) != 0) | (Operators.CompareString(tAcCode.Text, "00040", false) != 0) | (Operators.CompareString(tAcCode.Text, "00100", false) != 0))
				{
					DC_Main.RsQry = "SELECT AC_CODE,SUM(DR_AMT)As TcsDr FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = 'A' AND VCH_DATE >= '" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "' GROUP BY AC_CODE";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						AcTcsAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TcsDr"]), "0.00"));
					}
					else
					{
						AcTcsAmt = 0.0;
					}
				}
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
				if (DC_Main.MsAcAmtOpBal > 0.0)
				{
					LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
					((Control)LOpAmt).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcAmtOpBal < 0.0)
				{
					LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
					((Control)LOpAmt).ForeColor = Color.Red;
				}
				else
				{
					LOpAmt.Text = ": Amt";
				}
				CustOpAmt = DC_Main.MsAcAmtOpBal;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
				DC_Main.RsQry = "Select MEMB_CODE,LAST_BILL_DATE FROM POINT_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MEMB_CODE = '" + tAcCode.Text + "' AND SL_POINT = 'Y' AND POINT_CODE = '" + DC_Main.MsPointCode + "'";
				DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable3.Rows.Count > 0)
				{
					PointMemb = tAcCode.Text;
					chkPointMemb.Checked = true;
					((Control)chkPointMemb).Enabled = false;
				}
				else
				{
					chkPointMemb.Checked = false;
					((Control)chkPointMemb).Enabled = true;
					PointMemb = "";
				}
			}
			if ((Operators.CompareString(tAcCode.Text, "00045", false) == 0) | (Operators.CompareString(tAcCode.Text, "00040", false) == 0) | (Operators.CompareString(tAcCode.Text, "00100", false) == 0))
			{
				((Control)tAcName).Focus();
				return;
			}
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void AcImgShow()
	{
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + tAcCode.Text;
			}
			else
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
			}
		}
		else
		{
			DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
		}
		DC_Main.MsImageType = "AcImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			picAc.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			picAc.Image = null;
		}
	}

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND EMP_CODE = '" + tEmpCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT EMP_NAME As EmpNameL,EMP_CODE As EmpL FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tEmpCode.Text = DC_Main.ColValue[1];
					tEmpName.Text = DC_Main.ColValue[0];
				}
				if (!((Control)PnlTrfrVch).Visible)
				{
					((Control)BtnSave).Enabled = true;
				}
				((Control)tEmpCode).Focus();
			}
		}
		else
		{
			if (!((Control)PnlTrfrVch).Visible)
			{
				((Control)BtnSave).Enabled = true;
			}
			tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void tVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13 && !((Control)PnlTrfrVch).Visible)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM SL_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC  ORDER BY VCH_DESC";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 700.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tVchDesc.Text = DC_Main.ColValue[0];
				((TextBoxBase)tVchDesc).SelectionStart = Strings.Len(tVchDesc.Text);
			}
		}
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void MSG2_CLEAR()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		mSG2_TOTAL.Clear();
		mSG2_TOTAL.Rows = 16;
		mSG2_TOTAL.Row = 0;
		mSG2_TOTAL.Cols = 5;
		mSG2_TOTAL.ScrollBars = (ScrollBarsSettings)0;
		mSG2_TOTAL[0] = 7;
		checked
		{
			mSG2_TOTAL[0] = (int)Math.Round(1800.0 * ColCon);
			mSG2_TOTAL[1] = 0;
			mSG2_TOTAL[1] = (int)Math.Round(2500.0 * ColCon);
			mSG2_TOTAL[2] = 7;
			mSG2_TOTAL[2] = (int)Math.Round(800.0 * ColCon);
			mSG2_TOTAL[3] = 7;
			mSG2_TOTAL[3] = (int)Math.Round(1500.0 * ColCon);
			mSG2_TOTAL[4] = 7;
			mSG2_TOTAL[4] = 0;
			ColorConverter colorConverter = new ColorConverter();
			mSG2_TOTAL.FillStyle = (FillStyleSettings)1;
			DC_Main.i = 0;
			do
			{
				mSG2_TOTAL.Row = DC_Main.i;
				mSG2_TOTAL[DC_Main.i] = (int)Math.Round(300.0 * ColCon);
				switch (DC_Main.i)
				{
				case 0:
				case 5:
				case 15:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj7 = mSG2_TOTAL;
						object? obj8 = colorConverter.ConvertFromString("233, 235, 240");
						obj7.CellBackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj9 = mSG2_TOTAL;
						object? obj10 = colorConverter.ConvertFromString("Cornsilk");
						obj9.CellBackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj11 = mSG2_TOTAL;
						object? obj12 = colorConverter.ConvertFromString("255, 224, 192");
						obj11.CellBackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
					}
					break;
				case 6:
				case 7:
				case 9:
				case 10:
				case 14:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj17 = mSG2_TOTAL;
					object? obj18 = colorConverter.ConvertFromString("DarkBlue");
					obj17.CellForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
					break;
				}
				case 12:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj15 = mSG2_TOTAL;
					object? obj16 = colorConverter.ConvertFromString("Green");
					obj15.CellForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
					break;
				}
				case 13:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj13 = mSG2_TOTAL;
					object? obj14 = colorConverter.ConvertFromString("Red");
					obj13.CellForeColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
					break;
				}
				case 8:
				case 11:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj = mSG2_TOTAL;
						object? obj2 = colorConverter.ConvertFromString("233, 235, 240");
						obj.CellBackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj3 = mSG2_TOTAL;
						object? obj4 = colorConverter.ConvertFromString("238, 244, 236");
						obj3.CellBackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj5 = mSG2_TOTAL;
						object? obj6 = colorConverter.ConvertFromString("Linen");
						obj5.CellBackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
					}
					break;
				}
				DC_Main.i++;
			}
			while (DC_Main.i <= 15);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Tcs Amt : ";
			if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)
			{
				mSG2_TOTAL[4, 0] = "Tds Amt : ";
			}
			else
			{
				mSG2_TOTAL[4, 0] = "Rof Amt : ";
			}
			mSG2_TOTAL[5, 0] = "Total Amt : ";
			mSG2_TOTAL[6, 0] = "Cheque Amt : ";
			mSG2_TOTAL[7, 0] = "Card Amt : ";
			mSG2_TOTAL[8, 0] = "Crnt / Ord Amt : ";
			mSG2_TOTAL[9, 0] = "Old Gold Amt : ";
			mSG2_TOTAL[10, 0] = "Old Silver Amt : ";
			mSG2_TOTAL[11, 0] = "Scheme Amt : ";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
			{
				mSG2_TOTAL[12, 0] = "Zelle / Cash Amt : ";
			}
			else
			{
				mSG2_TOTAL[12, 0] = "Upi / Cash Amt : ";
			}
			mSG2_TOTAL[13, 0] = "Cash Paid Amt : ";
			mSG2_TOTAL[14, 0] = "Kasar Amt : ";
			mSG2_TOTAL[15, 0] = "Os Amt : ";
			mSG2_TOTAL.Row = 1;
			mSG2_TOTAL.Col = 1;
			((Control)TEXT_ENTRY_2).Visible = false;
			mSG2_TOTAL = null;
		}
	}

	private void MSG2_TOTAL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		checked
		{
			if (mSG2_TOTAL.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY_2).Left = (int)Math.Round((double)((Control)mSG2_TOTAL).Left + (double)mSG2_TOTAL.CellLeft / 15.0);
				((Control)TEXT_ENTRY_2).Top = (int)Math.Round((double)((Control)mSG2_TOTAL).Top + (double)mSG2_TOTAL.CellTop / 15.0);
				((Control)TEXT_ENTRY_2).Width = (int)Math.Round((double)mSG2_TOTAL.CellWidth / 15.0);
				((Control)TEXT_ENTRY_2).Height = (int)Math.Round((double)mSG2_TOTAL.CellHeight / 15.0);
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				((Control)TEXT_ENTRY_2).Visible = true;
				((TextBoxBase)TEXT_ENTRY_2).SelectAll();
				((Control)TEXT_ENTRY_2).Focus();
				mSG2_TOTAL = null;
			}
		}
	}

	private void MSG2_TOTAL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		if (!((Control)BtnSave).Enabled || ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.CellWidth <= 0)) || mSG2_TOTAL[mSG2_TOTAL.Col] == 0)
		{
			return;
		}
		checked
		{
			((Control)TEXT_ENTRY_2).Left = (int)Math.Round((double)((Control)mSG2_TOTAL).Left + (double)mSG2_TOTAL.CellLeft / 15.0);
			((Control)TEXT_ENTRY_2).Top = (int)Math.Round((double)((Control)mSG2_TOTAL).Top + (double)mSG2_TOTAL.CellTop / 15.0);
			((Control)TEXT_ENTRY_2).Width = (int)Math.Round((double)mSG2_TOTAL.CellWidth / 15.0);
			((Control)TEXT_ENTRY_2).Height = (int)Math.Round((double)mSG2_TOTAL.CellHeight / 15.0);
			((Control)TEXT_ENTRY_2).Visible = true;
			((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
			switch (MSG2_TOTAL.Col)
			{
			case 1:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 50;
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 15) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 12))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 10;
				if ((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 11))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if (mSG2_TOTAL.Row == 2)
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 15) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 9))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 12;
				TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				if (chkPointMemb.Checked & (mSG2_TOTAL.Row == 14))
				{
					((Control)PnlPoint).Visible = true;
				}
				if ((Operators.CompareString(DC_Main.MsEstmateBankLock, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) != 0))
				{
					if ((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
					break;
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 15))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) == 0) & (mSG2_TOTAL.Row == 4))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				break;
			}
			mSG2_TOTAL = null;
			((TextBoxBase)TEXT_ENTRY_2).SelectAll();
		}
	}

	private void MSG2_TOTAL_LeaveCell(object sender, EventArgs e)
	{
		if (!((Control)BtnSave).Enabled || MSG2_TOTAL.Row == 0 || MSG2_TOTAL[MSG2_TOTAL.Col] == 0 || !((Control)TEXT_ENTRY_2).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		switch (MSG2_TOTAL.Col)
		{
		case 1:
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
			BILL_TOTAL();
			break;
		case 2:
			if ((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 11))
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
				break;
			}
			if (mSG2_TOTAL.Row == 2)
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			}
			else
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			}
			BILL_TOTAL();
			break;
		case 3:
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			BILL_TOTAL();
			if (chkPointMemb.Checked)
			{
				((Control)PnlPoint).Visible = false;
			}
			break;
		}
		mSG2_TOTAL = null;
	}

	private void TEXT_ENTRY_2_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ENTRY_2_DoubleClick(object sender, EventArgs e)
	{
		if ((MSG2_TOTAL.Row == 9) & (MSG2_TOTAL.Col == 2))
		{
			((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
		}
		if ((MSG2_TOTAL.Row == 10) & (MSG2_TOTAL.Col == 2))
		{
			((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && ((MSG2_TOTAL.Row == 14) & (MSG2_TOTAL.Col == 2)))
		{
			if (((Control)PnlPoint).Visible)
			{
				((Control)PnlPoint).Visible = false;
			}
			else
			{
				((Control)PnlPoint).Visible = true;
			}
		}
	}

	private void NetAmtChange()
	{
		//IL_184d: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				if (Conversion.Val(TEXT_ENTRY_2.Text) == 0.0)
				{
					return;
				}
				double num = Conversion.Val(MSG2_TOTAL[5, 3]) - Conversion.Val(TEXT_ENTRY_2.Text);
				if (num == 0.0)
				{
					return;
				}
				double num2 = 0.0;
				DC_Main.X = 0;
				int num3 = MSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num3)
				{
					AxMSFlexGrid mSG = MSG;
					if (Conversion.Val(mSG[DC_Main.X, 37]) != 0.0)
					{
						if (Conversion.Val(mSG[DC_Main.X, 30]) != 0.0)
						{
							num2 = Conversions.ToDouble(Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 35]) * num / Conversion.Val(MSG2_TOTAL[5, 3]), 2), "0.000"));
							mSG[DC_Main.X, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 30]) - num2, DC_Main.MsItmRateRof), "0.00");
							mSG[DC_Main.X, 35] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 30]), DC_Main.MsItmRateRof), "0.00");
						}
						else
						{
							num2 = Conversions.ToDouble(Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 37]) * num / Conversion.Val(MSG2_TOTAL[5, 3]), 2), "0.000"));
							mSG[DC_Main.X, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 27]) - num2, DC_Main.MsItmRateRof), "0.00");
						}
						mSG[DC_Main.X, 77] = Conversions.ToString(Conversion.Val(mSG[DC_Main.X, 27]));
						if (Conversion.Val(mSG[DC_Main.X, 27]) > 0.0)
						{
							switch (mSG[DC_Main.X, 25])
							{
							case "P":
								mSG[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 27]) / Conversion.Val(mSG[DC_Main.X, 11]), DC_Main.MsLbrRof), "0.00");
								break;
							case "N":
								if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
								{
									mSG[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 27]) / Conversion.Val(mSG[DC_Main.X, 14]), DC_Main.MsLbrRof), "0.00");
								}
								else
								{
									mSG[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 27]) / (Conversion.Val(mSG[DC_Main.X, 14]) + Conversion.Val(mSG[DC_Main.X, 17])), DC_Main.MsLbrRof), "0.00");
								}
								break;
							case "K":
								mSG[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 27]) / (Conversion.Val(mSG[DC_Main.X, 14]) + Conversion.Val(mSG[DC_Main.X, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
								break;
							default:
								mSG[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 27]) / Conversion.Val(mSG[DC_Main.X, 12]), DC_Main.MsLbrRof), "0.00");
								break;
							}
							mSG[DC_Main.X, 76] = Conversions.ToString(Conversion.Val(mSG[DC_Main.X, 26]));
							if ((Conversion.Val(mSG[DC_Main.X, 24]) != 0.0) & (Conversion.Val(mSG[DC_Main.X, 22]) != 0.0) & (Conversion.Val(mSG[DC_Main.X, 26]) != 0.0))
							{
								mSG[DC_Main.X, 24] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.X, 26]) * 100.0 / Conversion.Val(mSG[DC_Main.X, 22])), "0.000");
							}
						}
						else
						{
							double num4 = Conversion.Val(mSG[DC_Main.X, 23]);
							double num5 = Conversion.Val(mSG[DC_Main.X, 23]) - Math.Abs(Conversion.Val(mSG[DC_Main.X, 27]));
							mSG[DC_Main.X, 23] = Strings.Format((object)num5, "0.00");
							mSG[DC_Main.X, 27] = Conversions.ToString(0);
							mSG[DC_Main.X, 77] = Conversions.ToString(0);
							mSG[DC_Main.X, 26] = Conversions.ToString(0);
							mSG[DC_Main.X, 82] = Conversions.ToString(0);
							if (Conversion.Val(mSG[DC_Main.X, 17]) != 0.0)
							{
								double num6 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[DC_Main.X, 23]) * (Conversion.Val(mSG[DC_Main.X, 17]) + Conversion.Val(mSG[DC_Main.X, 14])) / num4 - Conversion.Val(mSG[DC_Main.X, 14])), "0.000"));
								mSG[DC_Main.X, 17] = Conversions.ToString(num6);
								mSG[DC_Main.X, 15] = Strings.Format((object)(num6 * 100.0 / Conversion.Val(mSG[DC_Main.X, 14])), "0.00");
								mSG[DC_Main.X, 68] = Conversions.ToString(Conversion.Val(mSG[DC_Main.X, 15]));
								string text = ((mSG[21] <= 0) ? DC_Main.MsSlAmtType : mSG[DC_Main.X, 21]);
								double num7 = ((Operators.CompareString(text, "F", false) == 0) ? ((mSG[20] == 0) ? (Conversion.Val(mSG[DC_Main.X, 14]) + Conversion.Val(mSG[DC_Main.X, 17])) : Conversion.Val(mSG[DC_Main.X, 20])) : ((Operators.CompareString(text, "G", false) != 0) ? (Conversion.Val(mSG[DC_Main.X, 14]) + Conversion.Val(mSG[DC_Main.X, 17])) : (Conversion.Val(mSG[DC_Main.X, 12]) + Conversion.Val(mSG[DC_Main.X, 17]))));
								if ((Conversion.Val(mSG[DC_Main.X, 22]) == 0.0) | ((Conversion.Val(mSG[DC_Main.X, 22]) != Conversion.Val(mSG[DC_Main.X, 82])) & (Conversion.Val(mSG[DC_Main.X, 23]) != 0.0) & (Conversion.Val(mSG[DC_Main.X, 12]) + Conversion.Val(mSG[DC_Main.X, 11]) != 0.0)))
								{
									switch (mSG[DC_Main.X, 58])
									{
									case "P":
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / Conversion.Val(mSG[DC_Main.X, 11]), DC_Main.MsItmRateRof), "0.00");
										break;
									case "1":
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / (num7 * 10.0), DC_Main.MsItmRateRof), "0.00");
										break;
									case "K":
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / (num7 * 1000.0), DC_Main.MsItmRateRof), "0.00");
										break;
									default:
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / num7, DC_Main.MsItmRateRof), "0.00");
										break;
									}
									mSG[DC_Main.X, 82] = Strings.Format((object)Conversion.Val(mSG[DC_Main.X, 22]), "0.00");
									mSG[DC_Main.X, 93] = "N";
								}
							}
							else
							{
								string text2 = ((mSG[21] <= 0) ? DC_Main.MsSlAmtType : mSG[DC_Main.X, 21]);
								double num8 = ((Operators.CompareString(text2, "F", false) == 0) ? ((mSG[20] == 0) ? (Conversion.Val(mSG[DC_Main.X, 14]) + Conversion.Val(mSG[DC_Main.X, 17])) : Conversion.Val(mSG[DC_Main.X, 20])) : ((Operators.CompareString(text2, "G", false) != 0) ? (Conversion.Val(mSG[DC_Main.X, 14]) + Conversion.Val(mSG[DC_Main.X, 17])) : (Conversion.Val(mSG[DC_Main.X, 12]) + Conversion.Val(mSG[DC_Main.X, 17]))));
								if ((Conversion.Val(mSG[DC_Main.X, 22]) == 0.0) | ((Conversion.Val(mSG[DC_Main.X, 22]) != Conversion.Val(mSG[DC_Main.X, 82])) & (Conversion.Val(mSG[DC_Main.X, 23]) != 0.0) & (Conversion.Val(mSG[DC_Main.X, 12]) + Conversion.Val(mSG[DC_Main.X, 11]) != 0.0)))
								{
									switch (mSG[DC_Main.X, 58])
									{
									case "P":
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / Conversion.Val(mSG[DC_Main.X, 11]), DC_Main.MsItmRateRof), "0.00");
										break;
									case "1":
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / (num8 * 10.0), DC_Main.MsItmRateRof), "0.00");
										break;
									case "K":
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / (num8 * 1000.0), DC_Main.MsItmRateRof), "0.00");
										break;
									default:
										mSG[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) / num8, DC_Main.MsItmRateRof), "0.00");
										break;
									}
									mSG[DC_Main.X, 82] = Strings.Format((object)Conversion.Val(mSG[DC_Main.X, 22]), "0.00");
									mSG[DC_Main.X, 93] = "N";
								}
							}
						}
						mSG[DC_Main.X, 35] = Strings.Format((object)Math.Round(Conversion.Val(mSG[DC_Main.X, 23]) + Conversion.Val(mSG[DC_Main.X, 27]) + Conversion.Val(mSG[DC_Main.X, 29]), 0), "0.00");
						mSG[DC_Main.X, 37] = mSG[DC_Main.X, 35];
					}
					mSG = null;
					DC_Main.X++;
				}
				if (Conversion.Val(MSG2_TOTAL[2, 2]) != 0.0)
				{
					DC_Main.X = 0;
					int num9 = MSG.Rows - 1;
					DC_Main.X = 1;
					while (DC_Main.X <= num9)
					{
						AxMSFlexGrid mSG2 = MSG;
						mSG2[DC_Main.X, 37] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 35]) / (Conversion.Val(MSG2_TOTAL[2, 2]) + 100.0) * 100.0, 0), "0.00");
						if (Conversion.Val(mSG2[mSG2.Row, 27]) > 0.0)
						{
							mSG2[mSG2.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[mSG2.Row, 37]) - Conversion.Val(mSG2[mSG2.Row, 23]) - Conversion.Val(mSG2[mSG2.Row, 29]), 0), "0.00");
						}
						mSG2[DC_Main.X, 77] = Conversions.ToString(Conversion.Val(mSG2[DC_Main.X, 27]));
						if (Conversion.Val(mSG2[DC_Main.X, 27]) > 0.0)
						{
							switch (mSG2[DC_Main.X, 25])
							{
							case "P":
								mSG2[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 27]) / Conversion.Val(mSG2[DC_Main.X, 11]), DC_Main.MsLbrRof), "0.00");
								break;
							case "N":
								if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
								{
									mSG2[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 27]) / Conversion.Val(mSG2[DC_Main.X, 14]), DC_Main.MsLbrRof), "0.00");
								}
								else
								{
									mSG2[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 27]) / (Conversion.Val(mSG2[DC_Main.X, 14]) + Conversion.Val(mSG2[DC_Main.X, 17])), DC_Main.MsLbrRof), "0.00");
								}
								break;
							case "K":
								mSG2[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 27]) / (Conversion.Val(mSG2[DC_Main.X, 14]) + Conversion.Val(mSG2[DC_Main.X, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
								break;
							default:
								mSG2[DC_Main.X, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 27]) / Conversion.Val(mSG2[DC_Main.X, 12]), DC_Main.MsLbrRof), "0.00");
								break;
							}
							mSG2[DC_Main.X, 76] = Conversions.ToString(Conversion.Val(mSG2[DC_Main.X, 26]));
							if ((Conversion.Val(mSG2[DC_Main.X, 24]) != 0.0) & (Conversion.Val(mSG2[DC_Main.X, 22]) != 0.0) & (Conversion.Val(mSG2[DC_Main.X, 26]) != 0.0))
							{
								mSG2[DC_Main.X, 24] = Strings.Format((object)(Conversion.Val(mSG2[DC_Main.X, 26]) * 100.0 / Conversion.Val(mSG2[DC_Main.X, 22])), "0.000");
							}
						}
						else
						{
							double num10 = Conversion.Val(mSG2[DC_Main.X, 23]) - Math.Abs(Conversion.Val(mSG2[DC_Main.X, 27]));
							mSG2[DC_Main.X, 23] = Strings.Format((object)num10, "0.00");
							mSG2[DC_Main.X, 27] = Conversions.ToString(0);
							mSG2[DC_Main.X, 77] = Conversions.ToString(0);
							mSG2[DC_Main.X, 26] = Conversions.ToString(0);
							mSG2[DC_Main.X, 82] = Conversions.ToString(0);
							string text3 = ((mSG2[21] <= 0) ? DC_Main.MsSlAmtType : mSG2[DC_Main.X, 21]);
							double num11 = ((Operators.CompareString(text3, "F", false) == 0) ? ((mSG2[20] == 0) ? (Conversion.Val(mSG2[DC_Main.X, 14]) + Conversion.Val(mSG2[DC_Main.X, 17])) : Conversion.Val(mSG2[DC_Main.X, 20])) : ((Operators.CompareString(text3, "G", false) != 0) ? (Conversion.Val(mSG2[DC_Main.X, 14]) + Conversion.Val(mSG2[DC_Main.X, 17])) : (Conversion.Val(mSG2[DC_Main.X, 12]) + Conversion.Val(mSG2[DC_Main.X, 17]))));
							if ((Conversion.Val(mSG2[DC_Main.X, 22]) == 0.0) | ((Conversion.Val(mSG2[DC_Main.X, 22]) != Conversion.Val(mSG2[DC_Main.X, 82])) & (Conversion.Val(mSG2[DC_Main.X, 23]) != 0.0) & (Conversion.Val(mSG2[DC_Main.X, 12]) + Conversion.Val(mSG2[DC_Main.X, 11]) != 0.0)))
							{
								switch (mSG2[DC_Main.X, 58])
								{
								case "P":
									mSG2[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 23]) / Conversion.Val(mSG2[DC_Main.X, 11]), DC_Main.MsItmRateRof), "0.00");
									break;
								case "1":
									mSG2[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 23]) / (num11 * 10.0), DC_Main.MsItmRateRof), "0.00");
									break;
								case "K":
									mSG2[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 23]) / (num11 * 1000.0), DC_Main.MsItmRateRof), "0.00");
									break;
								default:
									mSG2[DC_Main.X, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG2[DC_Main.X, 23]) / num11, DC_Main.MsItmRateRof), "0.00");
									break;
								}
								mSG2[DC_Main.X, 82] = Strings.Format((object)Conversion.Val(mSG2[DC_Main.X, 22]), "0.00");
								mSG2[DC_Main.X, 93] = "N";
							}
						}
						mSG2 = null;
						DC_Main.X++;
					}
				}
				int num12 = MSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num12)
				{
					MSG.Row = DC_Main.X;
					CommPassTotal();
					DC_Main.X++;
				}
				MSG_TOT_FILL();
				BILL_TOTAL();
			}
			else
			{
				Interaction.MsgBox((object)"This Function Not Working in Your Software Virson Please Upgrad Advance or Enterprise Then Try", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void TEXT_ENTRY_2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_0657: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				default:
					if (unchecked((int)keyCode) != 112)
					{
						break;
					}
					if ((mSG2_TOTAL.Row == 1) & (mSG2_TOTAL.Col == 1))
					{
						NetAmtChange();
					}
					if (mSG2_TOTAL.Row == 12 && MSG2_TOTAL.Col == 1)
					{
						((Control)PnlUpi).Visible = true;
						MSG_UPI.Row = MSG_UPI.Rows - 1;
						MSG_UPI.Col = 1;
						MSG_UPI_EnterCell(MSG_UPI, new EventArgs());
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)TEXT_UPI).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == 8 && MSG2_TOTAL.Col == 1)
					{
						((Control)pnlCrnt).Visible = true;
						MSG_CRNT.Row = MSG_CRNT.Rows - 1;
						MSG_CRNT.Col = 1;
						MSG_CRNT_EnterCell(MSG_CRNT, new EventArgs());
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)TEXT_CRNT).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == 14 && Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && MSG2_TOTAL.Col == 2)
					{
						if (((Control)PnlPoint).Visible)
						{
							((Control)PnlPoint).Visible = false;
						}
						else
						{
							((Control)PnlPoint).Visible = true;
						}
					}
					break;
				case 0:
					if (mSG2_TOTAL.Col > 1)
					{
						mSG2_TOTAL.Col -= 1;
					}
					return;
				case 2:
					if (mSG2_TOTAL.Col < mSG2_TOTAL.Cols - 1)
					{
						mSG2_TOTAL.Col += 1;
					}
					break;
				case 1:
					if (mSG2_TOTAL.Row > 1)
					{
						mSG2_TOTAL.Row -= 1;
					}
					break;
				case 3:
					if (mSG2_TOTAL.Row < mSG2_TOTAL.Rows - 1)
					{
						mSG2_TOTAL.Row += 1;
					}
					break;
				}
			}
			else
			{
				bool flag = true;
				switch (mSG2_TOTAL.Col)
				{
				case 1:
					if (((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 11)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 6)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 7)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','19','22','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 11)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '04')  ORDER BY A.AC_NAME";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[3];
							DC_Main.ColWidth[0] = 400.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
									mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = DC_Main.ColValue[0];
									mSG2_TOTAL[mSG2_TOTAL.Row, 4] = DC_Main.ColValue[1];
									RowChang = true;
								}
								((Control)TEXT_ENTRY_2).Focus();
							}
							return;
						}
						mSG2_TOTAL[mSG2_TOTAL.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
						mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
						RowChang = true;
					}
					if (mSG2_TOTAL.Row == 2)
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcR, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[4];
								DC_Main.ColWidth[0] = 250.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
										mSG2_TOTAL[2, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
										mSG2_TOTAL[2, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
										mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 6;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"])), "0.00");
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 6;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							if (Operators.CompareString(DC_Main.MCo_BookType, "T", false) != 0)
							{
								TEXT_ENTRY_2.Text = "TAX FREE";
								mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
							}
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 6;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 3)
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE IN ('20','00') AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[4];
								DC_Main.ColWidth[0] = 250.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
										mSG2_TOTAL[3, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										OldTcsPrc = 111.0;
										mSG2_TOTAL[3, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										mSG2_TOTAL[3, 1] = "";
										mSG2_TOTAL[3, 2] = "";
										mSG2_TOTAL[3, 3] = "";
										mSG2_TOTAL[3, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 6;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 6;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							if (Operators.CompareString(DC_Main.MCo_BookType, "T", false) != 0)
							{
								TEXT_ENTRY_2.Text = "";
								mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "";
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "";
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "";
							}
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 6;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if ((mSG2_TOTAL.Row == 4) & (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0))
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE IN ('25','00') AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[4];
								DC_Main.ColWidth[0] = 250.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
										mSG2_TOTAL[4, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										OldTcsPrc = 111.0;
										mSG2_TOTAL[4, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										mSG2_TOTAL[4, 1] = "";
										mSG2_TOTAL[4, 2] = "";
										mSG2_TOTAL[4, 3] = "";
										mSG2_TOTAL[4, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 6;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 6;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							TEXT_ENTRY_2.Text = "";
							mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "";
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "";
							mSG2_TOTAL[mSG2_TOTAL.Row, 3] = "";
							mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "";
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 6;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 12)
					{
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					}
					break;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 4:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 6;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 2:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 6;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 12:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 13:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 8:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							MSG_ORD.Row = 1;
							MSG_ORD.Col = 1;
							MSG_ORD_EnterCell(MSG_ORD, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = false;
							((Control)TEXT_ORD).Focus();
						}
						else
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 6:
						if ((Conversion.Val(TEXT_ENTRY_2.Text) != 0.0) & !RowChang)
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Col = 1;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
							{
								TEXT_ENTRY_2.Text = ".";
							}
							((Control)TEXT_ENTRY_2).Focus();
						}
						else
						{
							RowChang = false;
							BILL_TOTAL();
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 7:
						if ((Operators.CompareString(DC_Main.MsCardComAdj, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) == 0))
						{
							if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
							{
								if (!DC_Main.MsCardSlAdj & (OldCardAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0))
								{
									OldCardAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00"));
									DC_Main.MsSlBill = tVchNo.Text;
									DC_Main.MsSlAcCode = tAcCode.Text;
									DC_Main.MsSlYrCd = DC_Main.MCo_year;
									DC_Main.MsSlDbCd = DC_Main.MCo_Book;
									DC_Main.MsSlAmt = Conversion.Val(mSG2_TOTAL[5, 3]);
									DC_Main.MsCardSlAdj = true;
									DC_Main.CurBookHelp("CARD ADJUST");
									TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
									((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
									DC_Main.TotOpenForm++;
									((Form)tR_CARD_REC).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
									((Control)tR_CARD_REC).Show();
									((Control)tR_CARD_REC).Focus();
								}
								else
								{
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									BILL_TOTAL();
									mSG2_TOTAL.Row += 1;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Visible = true;
									((Control)TEXT_ENTRY_2).Focus();
								}
								return;
							}
							break;
						}
						if ((Conversion.Val(TEXT_ENTRY_2.Text) != 0.0) & !RowChang)
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Col = 1;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
							{
								TEXT_ENTRY_2.Text = ".";
							}
							((Control)TEXT_ENTRY_2).Focus();
						}
						else
						{
							RowChang = false;
							BILL_TOTAL();
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 9:
					case 10:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							if (Operators.CompareString(FormBookType, "T", false) == 0)
							{
								if (!DC_Main.MsOldPurc & (OldGoldPurcAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (mSG2_TOTAL.Row == 9))
								{
									DC_Main.MsSlAcCode = tAcCode.Text;
									DC_Main.CustUrdName = tAcName.Text;
									DC_Main.MsOldPurc = true;
									DC_Main.MsSlBill = tVchNo.Text;
									DC_Main.MsSlBillHdNo = tHdVchNo.Text;
									DC_Main.MsSlYrCd = DC_Main.MCo_year;
									DC_Main.MsSlDbCd = DC_Main.MCo_Book;
									DC_Main.CurBook = "043";
									DC_Main.CurBookType = "T";
									DC_Main.CurBookName = "Gold URD Purchase";
									DC_Main.MsUserRightForm = "Purchase";
									DC_Main.CurBookItm = "G";
									DC_Main.CurBookMain = "PURCHASE";
									DC_Main.CurBookSname = "GLURD";
									DC_Main.CurBookInOut = "I";
									if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
									{
										TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
										((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC_HM).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC_HM).Show();
										((Control)tR_PURC_HM).Focus();
									}
									else
									{
										TR_PURC tR_PURC = new TR_PURC();
										((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC).Show();
										((Control)tR_PURC).Focus();
									}
									return;
								}
								if (!DC_Main.MsOldPurcSl & (OldSilverPurcAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (mSG2_TOTAL.Row == 10))
								{
									DC_Main.MsSlAcCode = tAcCode.Text;
									DC_Main.CustUrdName = tAcName.Text;
									DC_Main.MsOldPurcSl = true;
									DC_Main.MsSlBill = tVchNo.Text;
									DC_Main.MsSlBillHdNo = tHdVchNo.Text;
									DC_Main.MsSlYrCd = DC_Main.MCo_year;
									DC_Main.MsSlDbCd = DC_Main.MCo_Book;
									DC_Main.CurBook = "044";
									DC_Main.CurBookType = "T";
									DC_Main.CurBookName = "Silver URD Purchase";
									DC_Main.MsUserRightForm = "Purchase";
									DC_Main.CurBookItm = "S";
									DC_Main.CurBookMain = "PURCHASE";
									DC_Main.CurBookSname = "SLURD";
									DC_Main.CurBookInOut = "I";
									if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
									{
										TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
										((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC_HM2).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC_HM2).Show();
										((Control)tR_PURC_HM2).Focus();
									}
									else
									{
										TR_PURC tR_PURC2 = new TR_PURC();
										((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC2).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC2).Show();
										((Control)tR_PURC2).Focus();
									}
									return;
								}
								break;
							}
							MSG_OLD.Row = 1;
							MSG_OLD.Col = 1;
							MSG_OLD_EnterCell(MSG_OLD, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = false;
							return;
						}
						BILL_TOTAL();
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 14:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					case 11:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0))
							{
								if ((Conversion.Val(TEXT_ENTRY_2.Text) != 0.0) & !RowChang)
								{
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Col = 1;
									MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
									if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
									{
										TEXT_ENTRY_2.Text = ".";
									}
									((Control)TEXT_ENTRY_2).Focus();
								}
								else
								{
									RowChang = false;
									BILL_TOTAL();
									mSG2_TOTAL.Row += 1;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Visible = true;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else if (!DC_Main.MsSlAdj & (OldSchmAmt != Conversion.Val(TEXT_ENTRY_2.Text)))
							{
								DC_Main.MsSlBill = tVchNo.Text;
								DC_Main.MsSlBillHdNo = tHdVchNo.Text;
								DC_Main.MsSlAcCode = tAcCode.Text;
								DC_Main.MsSlYrCd = DC_Main.MCo_year;
								DC_Main.MsSlDbCd = DC_Main.MCo_Book;
								DC_Main.MsSlAmt = Conversion.Val(mSG2_TOTAL[5, 3]);
								DC_Main.MsSlAdj = true;
								DC_Main.CurBookHelp("MEMB ADJUST");
								if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
								{
									TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
									((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
									DC_Main.TotOpenForm++;
									((Form)tR_MEMB_ADJ).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
									((Control)tR_MEMB_ADJ).Show();
									((Control)tR_MEMB_ADJ).Focus();
								}
							}
							else
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								BILL_TOTAL();
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Visible = true;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							BILL_TOTAL();
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
						CommPassTotal();
						BILL_TOTAL();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						if (!((Control)PnlTrfrVch).Visible)
						{
							((Control)BtnSave).Enabled = true;
							((Control)BtnSave).Focus();
						}
						return;
					}
					mSG2_TOTAL.Row += 1;
					mSG2_TOTAL.Col = 1;
					((Control)TEXT_ENTRY_2).Visible = true;
					((Control)TEXT_ENTRY_2).Focus();
					flag = false;
					break;
				}
				if (flag)
				{
					MSG2_TOTAL.Col += 1;
					((Control)TEXT_ENTRY_2).Visible = true;
					((Control)TEXT_ENTRY_2).Focus();
				}
			}
			mSG2_TOTAL = null;
		}
	}

	private void BILL_TOTAL()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 37]), DC_Main.MsTotAmtRof), "0.00");
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 27]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
		}
		if ((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) != OldNetAmt) | (Conversion.Val(mSG2_TOTAL[2, 2]) != OldTaxPrc))
		{
			OldNetAmt = Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]);
			OldTaxPrc = Conversion.Val(mSG2_TOTAL[2, 2]);
			OldTcsPrc = 111.0;
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		if ((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0))
		{
			if (AcTcsAmt + (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3])) - Conversion.Val(mSG2_TOTAL[1, 3]) > 5000000.0)
			{
				if ((OldTcsPrc != Conversion.Val(MSG2_TOTAL[3, 2])) & (Operators.CompareString(MSG2_TOTAL[3, 4], "00", false) != 0))
				{
					if (Operators.CompareString(FormBookType, "T", false) == 0)
					{
						DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '20'";
						DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.RsTax.Rows.Count > 0)
						{
							TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
							MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
							AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
							double num = DC_Main.Fnv(ref Value);
							dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							mSG2_TOTAL2[3, 2] = Strings.Format((object)num, "0.000");
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
							double num2 = DC_Main.Fnv(ref Value);
							dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							OldTcsPrc = Conversions.ToDouble(Strings.Format((object)num2, "0.000"));
							MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
							double num3 = 5000000.0 - AcTcsAmt;
							double num4 = 0.0;
							num4 = Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - (Conversion.Val(mSG2_TOTAL[1, 3]) + num3);
							if (num3 > 0.0)
							{
								mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round(num4 * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
							}
							else
							{
								mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
							}
						}
					}
				}
				else if (Operators.CompareString(MSG2_TOTAL[3, 4], "00", false) == 0)
				{
					MSG2_TOTAL[3, 3] = "";
				}
			}
		}
		else if (OldTcsPrc != Conversion.Val(MSG2_TOTAL[3, 2]))
		{
			OldTcsPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[3, 2]), "0.000"));
			if ((Conversion.Val(mSG2_TOTAL[3, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
			{
				mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
			}
			else
			{
				mSG2_TOTAL[3, 3] = "";
			}
		}
		if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)
		{
			if ((Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
			{
				mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
			}
			else
			{
				mSG2_TOTAL[4, 3] = "";
			}
		}
		if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), DC_Main.MsTotAmtRof), "0.00");
		}
		else if (Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0)
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), 1), "0.00");
		}
		else
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), DC_Main.MsTotAmtRof), "0.00");
		}
		if (((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && Operators.CompareString(PointMemb, "", false) != 0)
		{
			if (Conversion.Val(nPointVal.Text) == 0.0)
			{
				DC_Main.RsQry = "SELECT * FROM POINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND POINT_CODE = '" + DC_Main.MsPointCode + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					tPointCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["POINT_CODE"], (object)""));
					nPointVal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SL_AMT"])), "0");
					nPointSlVal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POINT_AMT"])), "0.00");
				}
				DC_Main.RsQry = "Select A.POINT_CODE, A.MEMB_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN A.TOT_POINT ELSE - A.TOT_POINT END) As BalPoint FROM POINT_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.MEMB_CODE = '" + tAcCode.Text + "' AND A.POINT_CODE = '" + DC_Main.MsPointCode + "'  GROUP BY A.POINT_CODE,A.MEMB_CODE ";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					nPointBal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BalPoint"])), "0");
				}
			}
			else
			{
				nPointBillVal.Text = Conversions.ToString(Conversion.Val(mSG2_TOTAL[0, 3]));
				if ((Conversion.Val(nPointBillVal.Text) != 0.0) & (Conversion.Val(nPointVal.Text) != 0.0))
				{
					nBillPoint.Text = Conversions.ToString(Math.Round(Conversion.Val(nPointBillVal.Text) / Conversion.Val(nPointVal.Text), 0));
				}
			}
			nTotPoint.Text = Conversions.ToString(Conversion.Val(nPointBal.Text) + Conversion.Val(nBillPoint.Text));
			mSG2_TOTAL[14, 2] = Strings.Format((object)Conversion.Val(nBillPoint.Text), "0");
		}
		mSG2_TOTAL[8, 3] = "";
		checked
		{
			int num5 = MSG_ORD.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				mSG2_TOTAL[8, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(MSG_ORD[DC_Main.M, 2])), "0.00");
				DC_Main.M++;
			}
			mSG2_TOTAL[8, 1] = "";
			int num6 = MSG_CRNT.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num6)
			{
				mSG2_TOTAL[8, 1] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[8, 1]) + Conversion.Val(MSG_CRNT[DC_Main.M, 2])), "0.00");
				DC_Main.M++;
			}
			double num7 = 0.0;
			if (Operators.CompareString(DC_Main.MCo_BookType, "M", false) == 0)
			{
				mSG2_TOTAL[9, 2] = "";
				mSG2_TOTAL[9, 3] = "";
				mSG2_TOTAL[10, 2] = "";
				mSG2_TOTAL[10, 3] = "";
				int num8 = MSG_OLD.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num8)
				{
					if (Operators.CompareString(MSG_OLD[DC_Main.M, 14], "G", false) == 0)
					{
						mSG2_TOTAL[9, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");
						mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 13])), "0.00");
					}
					if (Operators.CompareString(MSG_OLD[DC_Main.M, 14], "G", false) != 0)
					{
						mSG2_TOTAL[10, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[10, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");
						mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[10, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 13])), "0.00");
					}
					if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
					{
						num7 += Conversion.Val(MSG_OLD[DC_Main.M, 13]) - Conversion.Val(MSG_OLD[DC_Main.M, 17]);
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				if (Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(mSG2_TOTAL[10, 3]) > Conversion.Val(mSG2_TOTAL[5, 3]))
				{
					if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
					{
						mSG2_TOTAL[13, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]), 2), "0.00");
					}
					else
					{
						mSG2_TOTAL[13, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]), 0), "0.00");
					}
					mSG2_TOTAL[12, 3] = "";
					mSG2_TOTAL[15, 3] = "0.00";
				}
				else
				{
					if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
					{
						mSG2_TOTAL[12, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[12, 1]), 2), "0.00");
					}
					else
					{
						mSG2_TOTAL[12, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[12, 1]), 0), "0.00");
					}
					mSG2_TOTAL[15, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[12, 1]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(mSG2_TOTAL[7, 2]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]) + Conversion.Val(mSG2_TOTAL[13, 3]) - Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[15, 2])), "0.00");
				}
			}
			else
			{
				mSG2_TOTAL[15, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[12, 1]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(mSG2_TOTAL[7, 2]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]) + Conversion.Val(mSG2_TOTAL[13, 3]) - Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[8, 1]) - Conversion.Val(mSG2_TOTAL[15, 2])), "0.00");
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | ((Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)))
			{
				double num9 = 0.0;
				int num10 = MSG.Rows - 1;
				for (int i = 0; i <= num10; i++)
				{
					num9 += Conversion.Val(MSG[i, 99]);
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
				{
					if (num7 > 0.0)
					{
						num9 -= num7;
					}
					else if (num7 < 0.0)
					{
						num9 += num7;
					}
				}
				nBillProfit.Text = Strings.Format((object)num9, "0.00");
			}
			if (CustOpAmt > 0.0)
			{
				if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
				{
					CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[15, 3]);
				}
				else
				{
					CustClAmt = CustOpAmt - (Conversion.Val(mSG2_TOTAL[15, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(mSG2_TOTAL[8, 1]));
				}
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = 0.0 - (Math.Abs(CustOpAmt) + (Conversion.Val(mSG2_TOTAL[15, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(mSG2_TOTAL[8, 1])));
			}
			else
			{
				CustClAmt = 0.0 - Conversion.Val(mSG2_TOTAL[15, 3]);
			}
			if (CustClAmt > 0.0)
			{
				LClAmt.Text = Strings.Format((object)CustClAmt, "0.00") + " : Cr Amt";
				((Control)LClAmt).ForeColor = Color.Blue;
			}
			else if (CustClAmt < 0.0)
			{
				LClAmt.Text = Strings.Format((object)Math.Abs(CustClAmt), "0.00") + " : Dr Amt";
				((Control)LClAmt).ForeColor = Color.Red;
			}
			else
			{
				LClAmt.Text = ": Amt";
			}
			mSG2_TOTAL = null;
		}
	}

	private void tBillNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAcName_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcName).SelectionStart = 0;
		((TextBoxBase)tAcName).SelectionLength = Strings.Len(tAcName.Text);
		if ((Operators.CompareString(tAcCode.Text, "00045", false) == 0) | (Operators.CompareString(tAcCode.Text, "00040", false) == 0) | (Operators.CompareString(tAcCode.Text, "00100", false) == 0))
		{
			((TextBoxBase)tAcName).ReadOnly = false;
		}
		else
		{
			((TextBoxBase)tAcName).ReadOnly = true;
		}
	}

	private void tAcName_TextChanged(object sender, EventArgs e)
	{
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		if (Strings.Len(tAcName.Text) > 3)
		{
			MobileSearch = true;
		}
		else
		{
			MobileSearch = false;
		}
		if (!((Strings.Len(tAcName.Text) >= 2) & !MobileSearch & Versioned.IsNumeric((object)tAcName.Text)))
		{
			return;
		}
		DC_Main.MsMobileLen = tAcName.Text;
		MobileSearch = true;
		DC_Main.RsQry = "SELECT A.AC_MOBILE As MobileL,A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND SUBSTRING(A.AC_MOBILE,1,2)  = '" + Strings.Mid(tAcName.Text, 1, 2) + "'  ORDER BY A.AC_MOBILE";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 120.0;
		DC_Main.ColWidth[1] = 300.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (DC_Main.HelpClose)
		{
			return;
		}
		if (DC_Main.MsCreat)
		{
			MS_ADD_MAST mS_ADD_MAST = new MS_ADD_MAST();
			((Form)mS_ADD_MAST).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)mS_ADD_MAST).Show();
			((Control)mS_ADD_MAST).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			tAcName.Text = DC_Main.ColValue[1];
			tAdd1.Text = DC_Main.ColValue[3];
			tCity.Text = DC_Main.ColValue[4];
			tMobile.Text = DC_Main.ColValue[0];
		}
		MobileSearch = false;
		((Control)tAcName).Focus();
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Invalid comparison between Unknown and I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Invalid comparison between Unknown and I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[6];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 200.0;
			DC_Main.ColWidth[4] = 120.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (DC_Main.MsCreat)
			{
				MS_ADD_MAST mS_ADD_MAST = new MS_ADD_MAST();
				((Form)mS_ADD_MAST).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ADD_MAST).Show();
				((Control)mS_ADD_MAST).Focus();
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcName.Text = DC_Main.ColValue[0];
				tAdd1.Text = DC_Main.ColValue[2];
				tCity.Text = DC_Main.ColValue[3];
				tMobile.Text = DC_Main.ColValue[4];
			}
			((Control)tAcName).Focus();
		}
		else
		{
			if ((int)e.KeyCode != 13)
			{
				return;
			}
			if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
			{
				((Control)PanelAdd).Visible = true;
				if ((int)e.KeyCode == 13)
				{
					((Control)tAdd1).Focus();
				}
			}
			else
			{
				MSG.Col = 1;
				MSG.Row = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void tAdd1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tMobile_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)PanelAdd).Visible = false;
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tItDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 4;
			MSG[MSG.Row, 75] = tItDesc.Text;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Invalid comparison between Unknown and I4
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					AxMSFlexGrid obj;
					int num7;
					Type? typeFromHandle;
					object[] obj2;
					DataRowView dataRowView;
					object[] array;
					bool[] obj3;
					bool[] array2;
					object obj4;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (unchecked((int)e.KeyCode) != 13)
						{
							goto end_IL_0001;
						}
						goto IL_0015;
					case 7038:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001_2;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_0015;
							case 3:
								goto IL_0094;
							case 4:
								goto IL_00a5;
							case 5:
								goto IL_00bf;
							case 7:
								goto IL_00da;
							case 8:
								goto IL_0111;
							case 9:
								goto IL_0151;
							case 10:
								goto IL_0163;
							case 11:
								goto IL_017e;
							case 12:
								goto IL_01b6;
							case 13:
								goto IL_01d5;
							case 14:
								goto IL_01de;
							case 15:
								goto IL_01ed;
							case 16:
								goto IL_01fc;
							case 17:
								goto IL_0206;
							case 18:
								goto IL_0220;
							case 19:
								goto IL_0245;
							case 20:
								goto IL_025d;
							case 21:
								goto IL_0267;
							case 24:
								goto IL_0277;
							case 25:
								goto IL_0296;
							case 26:
								goto IL_02cd;
							case 27:
								goto IL_030e;
							case 28:
								goto IL_034f;
							case 29:
								goto IL_0390;
							case 30:
								goto IL_03e0;
							case 31:
								goto IL_0420;
							case 32:
								goto IL_0461;
							case 33:
								goto IL_049d;
							case 35:
								goto IL_04b9;
							case 34:
							case 36:
							case 37:
								goto IL_04fa;
							case 38:
								goto IL_053a;
							case 39:
								goto IL_057a;
							case 40:
								goto IL_05ba;
							case 41:
								goto IL_05fb;
							case 42:
								goto IL_0646;
							case 43:
								goto IL_067d;
							case 44:
								goto IL_06c8;
							case 45:
								goto IL_0713;
							case 46:
								goto IL_075e;
							case 47:
								goto IL_07a9;
							case 48:
								goto IL_07f4;
							case 49:
								goto IL_083f;
							case 50:
								goto IL_088a;
							case 51:
								goto IL_08d5;
							case 52:
								goto IL_0920;
							case 53:
								goto IL_096b;
							case 54:
								goto IL_09b6;
							case 55:
								goto IL_0a01;
							case 56:
								goto IL_0a4c;
							case 57:
								goto IL_0a8d;
							case 58:
								goto IL_0ad8;
							case 59:
								goto IL_0b23;
							case 60:
								goto IL_0b6e;
							case 61:
								goto IL_0bb9;
							case 62:
								goto IL_0bfa;
							case 63:
								goto IL_0c13;
							case 64:
								goto IL_0c60;
							case 65:
								goto IL_0c74;
							case 66:
								goto IL_0cb9;
							case 67:
								goto IL_0cd2;
							case 68:
								goto IL_0cf9;
							case 70:
								goto IL_0d6d;
							case 71:
								goto IL_0d94;
							case 73:
								goto IL_0e08;
							case 74:
								goto IL_0e32;
							case 77:
								goto IL_0ece;
							case 69:
							case 72:
							case 75:
							case 76:
							case 78:
							case 79:
							case 80:
							case 81:
								goto IL_0eec;
							case 82:
								goto IL_0f37;
							case 83:
								goto IL_0f82;
							case 84:
								goto IL_0fcd;
							case 85:
								goto IL_1018;
							case 86:
								goto IL_1059;
							case 87:
								goto IL_109a;
							case 88:
								goto IL_10db;
							case 89:
								goto IL_111c;
							case 90:
								goto IL_115d;
							case 91:
								goto IL_1176;
							case 92:
								goto IL_1228;
							case 93:
								goto IL_123b;
							case 96:
								goto IL_1246;
							case 97:
								goto IL_125a;
							case 98:
								goto IL_128c;
							case 99:
								goto IL_12bd;
							case 100:
								goto IL_12f3;
							case 101:
								goto IL_1329;
							case 102:
								goto IL_135f;
							case 103:
								goto IL_1395;
							case 104:
								goto IL_13cb;
							case 105:
								goto IL_1401;
							case 106:
								goto IL_1437;
							case 107:
								goto IL_146d;
							case 108:
								goto IL_14a4;
							case 109:
								goto IL_14d6;
							case 110:
								goto IL_151c;
							case 111:
								goto IL_1562;
							case 112:
								goto IL_15a8;
							case 113:
								goto IL_15df;
							case 114:
								goto IL_1625;
							case 115:
								goto IL_166b;
							case 116:
								goto IL_16b1;
							case 117:
								goto IL_16f7;
							case 118:
								goto IL_173d;
							case 119:
								goto IL_1783;
							case 120:
								goto IL_17ce;
							case 121:
								goto IL_1805;
							case 122:
								goto IL_181f;
							case 94:
							case 95:
							case 123:
								goto IL_1829;
							case 124:
								goto IL_1849;
							case 125:
								goto IL_185d;
							case 126:
								goto IL_186c;
							case 127:
								goto IL_187c;
							case 22:
							case 23:
							case 128:
								goto IL_1887;
							case 129:
								goto IL_18a9;
							case 130:
								goto IL_18c1;
							case 131:
								goto IL_18c4;
							case 132:
								goto IL_18d1;
							case 133:
								goto IL_18de;
							case 134:
								goto IL_18f6;
							case 135:
								goto IL_1909;
							case 137:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 6:
							case 136:
							case 138:
							case 139:
							case 140:
							case 141:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_17ce:
						num2 = 120;
						dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["IT_TYPE"], (object)"");
						goto IL_1805;
						IL_1805:
						num2 = 121;
						DtIdtl.Rows.Add(dr);
						goto IL_181f;
						IL_1783:
						num2 = 119;
						dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[num5]["KR_CON_WT"], (object)"")), "0.000");
						goto IL_17ce;
						IL_181f:
						num2 = 122;
						num5++;
						goto IL_1829;
						IL_0015:
						num2 = 2;
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.GR_CODE aS RateGr FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' AND ISU_REC = 'N'";
						goto IL_0094;
						IL_0094:
						num2 = 3;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00a5;
						IL_00a5:
						num2 = 4;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_00bf;
						}
						goto IL_00da;
						IL_00bf:
						num2 = 5;
						btnIsuNo_Click(btnIsuNo, new EventArgs());
						goto end_IL_0001;
						IL_00da:
						num2 = 7;
						tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
						goto IL_0111;
						IL_0111:
						num2 = 8;
						DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
						goto IL_0151;
						IL_0151:
						num2 = 9;
						DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0163;
						IL_0163:
						num2 = 10;
						if (DC_Main.RsAc.Rows.Count > 0)
						{
							goto IL_017e;
						}
						goto IL_01b6;
						IL_017e:
						num2 = 11;
						tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
						goto IL_01b6;
						IL_01b6:
						num2 = 12;
						if (unchecked((int)Interaction.MsgBox((object)"All Approval Tag In This Voucher Import?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							break;
						}
						goto IL_01d5;
						IL_01d5:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_01de;
						IL_01de:
						num2 = 14;
						DtIdtl.Clear();
						goto IL_01ed;
						IL_01ed:
						num2 = 15;
						DtIdtl.Reset();
						goto IL_01fc;
						IL_01fc:
						num2 = 16;
						FilRow = 0;
						goto IL_0206;
						IL_0206:
						num2 = 17;
						num6 = MSG_IDTL.Cols - 1;
						DC_Main.M = 0;
						goto IL_0254;
						IL_0254:
						if (DC_Main.M <= num6)
						{
							goto IL_0220;
						}
						goto IL_025d;
						IL_025d:
						num2 = 20;
						DC_Main.i = 0;
						goto IL_0267;
						IL_0267:
						num2 = 21;
						val = MSG;
						goto IL_1887;
						IL_1887:
						num2 = 23;
						if (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_0277;
						}
						goto IL_18a9;
						IL_18a9:
						num2 = 129;
						val.Rows -= 1;
						goto IL_18c1;
						IL_18c1:
						val = null;
						goto IL_18c4;
						IL_18c4:
						num2 = 131;
						MSG_TOT_FILL();
						goto IL_18d1;
						IL_18d1:
						num2 = 132;
						MsgOldRow = 0;
						goto IL_18de;
						IL_18de:
						num2 = 133;
						MSG_RowColChange(MSG, new EventArgs());
						goto IL_18f6;
						IL_18f6:
						num2 = 134;
						((Control)TEXT_ENTRY).Visible = false;
						goto IL_1909;
						IL_1909:
						num2 = 135;
						((Control)tAcCode).Focus();
						goto end_IL_0001;
						IL_0277:
						num2 = 24;
						val[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						goto IL_0296;
						IL_0296:
						num2 = 25;
						val[DC_Main.i + 1, 57] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
						goto IL_02cd;
						IL_02cd:
						num2 = 26;
						val[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"], (object)""));
						goto IL_030e;
						IL_030e:
						num2 = 27;
						val[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"], (object)""));
						goto IL_034f;
						IL_034f:
						num2 = 28;
						val[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"], (object)""));
						goto IL_0390;
						IL_0390:
						num2 = 29;
						val[DC_Main.i + 1, 81] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"], (object)"")), "0");
						goto IL_03e0;
						IL_03e0:
						num2 = 30;
						val[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
						goto IL_0420;
						IL_0420:
						num2 = 31;
						val[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
						goto IL_0461;
						IL_0461:
						num2 = 32;
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
						{
							goto IL_049d;
						}
						goto IL_04b9;
						IL_049d:
						num2 = 33;
						val[DC_Main.i + 1, 1] = "";
						goto IL_04fa;
						IL_04b9:
						num2 = 35;
						val[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
						goto IL_04fa;
						IL_04fa:
						num2 = 37;
						val[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						goto IL_053a;
						IL_053a:
						num2 = 38;
						val[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						goto IL_057a;
						IL_057a:
						num2 = 39;
						val[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						goto IL_05ba;
						IL_05ba:
						num2 = 40;
						val[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
						goto IL_05fb;
						IL_05fb:
						num2 = 41;
						val[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
						goto IL_0646;
						IL_0646:
						num2 = 42;
						val[DC_Main.i + 1, 11] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
						goto IL_067d;
						IL_067d:
						num2 = 43;
						val[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						goto IL_06c8;
						IL_06c8:
						num2 = 44;
						val[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						goto IL_0713;
						IL_0713:
						num2 = 45;
						val[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						goto IL_075e;
						IL_075e:
						num2 = 46;
						val[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						goto IL_07a9;
						IL_07a9:
						num2 = 47;
						val[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						goto IL_07f4;
						IL_07f4:
						num2 = 48;
						val[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						goto IL_083f;
						IL_083f:
						num2 = 49;
						val[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						goto IL_088a;
						IL_088a:
						num2 = 50;
						val[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						goto IL_08d5;
						IL_08d5:
						num2 = 51;
						val[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						goto IL_0920;
						IL_0920:
						num2 = 52;
						val[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						goto IL_096b;
						IL_096b:
						num2 = 53;
						val[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						goto IL_09b6;
						IL_09b6:
						num2 = 54;
						val[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						goto IL_0a01;
						IL_0a01:
						num2 = 55;
						val[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						goto IL_0a4c;
						IL_0a4c:
						num2 = 56;
						val[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						goto IL_0a8d;
						IL_0a8d:
						num2 = 57;
						val[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						goto IL_0ad8;
						IL_0ad8:
						num2 = 58;
						val[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						goto IL_0b23;
						IL_0b23:
						num2 = 59;
						val[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						goto IL_0b6e;
						IL_0b6e:
						num2 = 60;
						val[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						goto IL_0bb9;
						IL_0bb9:
						num2 = 61;
						val[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						goto IL_0bfa;
						IL_0bfa:
						num2 = 62;
						val[DC_Main.i + 1, 21] = "N";
						goto IL_0c13;
						IL_0c13:
						num2 = 63;
						if ((Conversion.Val(val[DC_Main.i + 1, 22]) == 0.0) & (Conversion.Val(val[DC_Main.i + 1, 30]) == 0.0))
						{
							goto IL_0c60;
						}
						goto IL_0eec;
						IL_0c60:
						num2 = 64;
						if (DC_Main.RtView != null)
						{
							goto IL_0c74;
						}
						goto IL_0eec;
						IL_0c74:
						num2 = 65;
						DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[DC_Main.i]["RateGr"]), (object)"'"));
						goto IL_0cb9;
						IL_0cb9:
						num2 = 66;
						if (DC_Main.RtView.Count > 0)
						{
							goto IL_0cd2;
						}
						goto IL_0ece;
						IL_0cd2:
						num2 = 67;
						if (Operators.CompareString(val[DC_Main.i + 1, 58], "G", false) == 0)
						{
							goto IL_0cf9;
						}
						goto IL_0d6d;
						IL_0cf9:
						num2 = 68;
						val[DC_Main.i + 1, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
							2
						}, (string[])null, (Type[])null, (bool[])null)), "0.00");
						goto IL_0eec;
						IL_0d6d:
						num2 = 70;
						if (Operators.CompareString(val[DC_Main.i + 1, 58], "K", false) == 0)
						{
							goto IL_0d94;
						}
						goto IL_0e08;
						IL_0d94:
						num2 = 71;
						val[DC_Main.i + 1, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
							0
						}, (string[])null, (Type[])null, (bool[])null)), "0.00");
						goto IL_0eec;
						IL_0e08:
						num2 = 73;
						if (Operators.CompareString(val[DC_Main.i + 1, 58], "1", false) == 0)
						{
							goto IL_0e32;
						}
						goto IL_0eec;
						IL_0e32:
						num2 = 74;
						obj = val;
						num7 = DC_Main.i + 1;
						typeFromHandle = typeof(Math);
						obj2 = new object[2]
						{
							(dataRowView = DC_Main.RtView[0])["GR_RATE"],
							0
						};
						array = obj2;
						obj3 = new bool[2] { true, false };
						array2 = obj3;
						obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Round", obj2, (string[])null, (Type[])null, obj3);
						if (array2[0])
						{
							dataRowView["GR_RATE"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
						}
						obj[num7, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0.00");
						goto IL_0eec;
						IL_0245:
						num2 = 19;
						DC_Main.M++;
						goto IL_0254;
						IL_0220:
						num2 = 18;
						DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
						goto IL_0245;
						IL_0ece:
						num2 = 77;
						val[DC_Main.i + 1, 22] = "";
						goto IL_0eec;
						IL_0eec:
						num2 = 81;
						val[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						goto IL_0f37;
						IL_0f37:
						num2 = 82;
						val[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						goto IL_0f82;
						IL_0f82:
						num2 = 83;
						val[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						goto IL_0fcd;
						IL_0fcd:
						num2 = 84;
						val[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						goto IL_1018;
						IL_1018:
						num2 = 85;
						val[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
						goto IL_1059;
						IL_1059:
						num2 = 86;
						val[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						goto IL_109a;
						IL_109a:
						num2 = 87;
						val[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
						goto IL_10db;
						IL_10db:
						num2 = 88;
						val[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						goto IL_111c;
						IL_111c:
						num2 = 89;
						val[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
						goto IL_115d;
						IL_115d:
						num2 = 90;
						val[DC_Main.i + 1, 63] = "A";
						goto IL_1176;
						IL_1176:
						num2 = 91;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM APR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' AND A.SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]), (object)" ORDER BY A.SR_NO,A.ISR_NO"));
						goto IL_1228;
						IL_1228:
						num2 = 92;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_123b;
						IL_123b:
						num2 = 93;
						num5 = 0;
						goto IL_1829;
						IL_1829:
						num2 = 95;
						if (num5 < RsIdtl.Rows.Count)
						{
							goto IL_1246;
						}
						goto IL_1849;
						IL_1849:
						num2 = 124;
						val.Rows += 1;
						goto IL_185d;
						IL_185d:
						num2 = 125;
						DC_Main.i++;
						goto IL_186c;
						IL_186c:
						num2 = 126;
						val.Row = DC_Main.i;
						goto IL_187c;
						IL_187c:
						num2 = 127;
						CommPassTotal();
						goto IL_1887;
						IL_1246:
						num2 = 96;
						dr = DtIdtl.NewRow();
						goto IL_125a;
						IL_125a:
						num2 = 97;
						dr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["SR_NO"]);
						goto IL_128c;
						IL_128c:
						num2 = 98;
						dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["ISR_NO"]);
						goto IL_12bd;
						IL_12bd:
						num2 = 99;
						dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["IT_CODE"], (object)"");
						goto IL_12f3;
						IL_12f3:
						num2 = 100;
						dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["IT_NAME"], (object)"");
						goto IL_1329;
						IL_1329:
						num2 = 101;
						dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_CODE"], (object)"");
						goto IL_135f;
						IL_135f:
						num2 = 102;
						dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_NAME"], (object)"");
						goto IL_1395;
						IL_1395:
						num2 = 103;
						dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_COLOR"], (object)"");
						goto IL_13cb;
						IL_13cb:
						num2 = 104;
						dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_SIZE"], (object)"");
						goto IL_1401;
						IL_1401:
						num2 = 105;
						dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_ORIGIN"], (object)"");
						goto IL_1437;
						IL_1437:
						num2 = 106;
						dr[8] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_REMARK"], (object)"");
						goto IL_146d;
						IL_146d:
						num2 = 107;
						dr[9] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["DM_SFNO"], (object)"");
						goto IL_14a4;
						IL_14a4:
						num2 = 108;
						dr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_PCS"]);
						goto IL_14d6;
						IL_14d6:
						num2 = 109;
						dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_GWT"])), "0.000");
						goto IL_151c;
						IL_151c:
						num2 = 110;
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["KR_WT"])), "0.000");
						goto IL_1562;
						IL_1562:
						num2 = 111;
						dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_CON_PRC"])), "0.000");
						goto IL_15a8;
						IL_15a8:
						num2 = 112;
						dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[num5]["IT_RATE_TYPE"], (object)"");
						goto IL_15df;
						IL_15df:
						num2 = 113;
						dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_RATE"])), "0.00");
						goto IL_1625;
						IL_1625:
						num2 = 114;
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_AMT"])), "0.00");
						goto IL_166b;
						IL_166b:
						num2 = 115;
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_LBR_RATE"])), "0.00");
						goto IL_16b1;
						IL_16b1:
						num2 = 116;
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_LBR_AMT"])), "0.00");
						goto IL_16f7;
						IL_16f7:
						num2 = 117;
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_NET_AMT"])), "0.00");
						goto IL_173d;
						IL_173d:
						num2 = 118;
						dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[num5]["IT_CON_WT"])), "0.000");
						goto IL_1783;
						end_IL_0001_3:
						break;
					}
					num2 = 137;
					((Control)tAcCode).Focus();
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj5) when (obj5 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj5);
				try0001_dispatch = 7038;
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

	private void btnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.AC_NAME As PartyNameL,COUNT(*) As TagQtyM,A.CO_YEAR As YearL,A.CO_BOOK As BookL FROM (APR_DETL AS A   LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND D.MAIN_BOOK = 'APR ISU'  AND A.ISU_REC = 'N' GROUP BY A.VCH_NO,A.VCH_DATE,C.AC_NAME,A.CO_YEAR,A.CO_BOOK ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 110.0;
		DC_Main.ColWidth[5] = 90.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tIsuNo.Text = DC_Main.ColValue[0];
				tIsuYrCd.Text = DC_Main.ColValue[4];
				tIsuDbCd.Text = DC_Main.ColValue[5];
				((Control)tIsuNo).Focus();
			}
			else
			{
				((Control)tIsuNo).Focus();
			}
		}
	}

	private void nCrDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tPanNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPanNo.Text, "", false) != 0)
		{
			DC_Main.ExeQuteDc("UPDATE AC_MAST SET AC_PANNO = '" + tPanNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'");
			Interaction.MsgBox((object)"Pancard is Update...", (MsgBoxStyle)0, (object)null);
			((Control)tPanNo).Visible = false;
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void btnTagSet_Click(object sender, EventArgs e)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		FormPrintFile = cboPrintfile.Text;
		Interaction.MsgBox((object)"Print Report Default Set", (MsgBoxStyle)0, (object)null);
	}

	private void TR_SALE_DoubleClick(object sender, EventArgs e)
	{
		((Control)tNewPrint).Visible = true;
	}

	private void tNewPrint_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + tNewPrint.Text + "' AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "INSERT INTO PRINT_MAST(CO_CODE,PRINT_TYPE,PRINT_FILE,PRINT_SET_A,BOOK_TYPE) VALUES ('01','" + FormMainBook + "','" + tNewPrint.Text + "','N','" + FormBookType + "')";
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"New Report is Insert ok...Please This Form Close And Reopen...", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				Interaction.MsgBox((object)"This Report is Alrady Exsist...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void tTrfrNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(EntryMode, "A", false) != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' And CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME AS CustNameL,VCH_NO AS VchNoL,replace(convert(NVARCHAR,VCH_DATE, 103), ' ', '/') AS VchDateL ,B.BOOK_NAME As BookL,A.AC_CODE,A.CO_BOOK As BookL ,A.CO_YEAR As YearL,A.TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.MAIN_BOOK = 'SALES' AND A.CO_BOOK <> '" + DC_Main.MCo_Book + "' ORDER BY A.CO_BOOK,A.VCH_NO ";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[9];
			DC_Main.ColWidth[0] = 350.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 120.0;
			DC_Main.ColWidth[3] = 200.0;
			DC_Main.ColWidth[4] = 0.0;
			DC_Main.ColWidth[5] = 0.0;
			DC_Main.ColWidth[6] = 0.0;
			DC_Main.ColWidth[7] = 110.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tTrfrNo.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[3];
				tAcCode.Text = DC_Main.ColValue[4];
				tTrfrDbCd.Text = DC_Main.ColValue[5];
				tTrfrYrCd.Text = DC_Main.ColValue[6];
				((Control)tTrfrNo).Focus();
			}
			else
			{
				((Control)tTrfrNo).Focus();
			}
		}
		else
		{
			((Control)tTrfrNo).Enabled = false;
			MainDbCd = DC_Main.MCo_Book;
			MainVchNo = tVchNo.Text;
			MainHdVchNo = tHdVchNo.Text;
			DC_Main.MCo_Book = tTrfrDbCd.Text;
			tVchNo.Text = tTrfrNo.Text;
			DISPLAY_DATA();
			((Control)BtnSave).Enabled = false;
			DC_Main.MCo_Book = MainDbCd;
			tVchNo.Text = MainVchNo;
			tHdVchNo.Text = MainHdVchNo;
		}
	}

	private void lblTrfrOpen_Click(object sender, EventArgs e)
	{
		((Control)PnlTrfrVch).Visible = true;
		((Control)tTrfrNo).Focus();
	}

	private void btnTrfr_Click(object sender, EventArgs e)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		if (!((Operators.CompareString(tTrfrDbCd.Text, "", false) == 0) & (Operators.CompareString(tTrfrNo.Text, "", false) == 0)) && (int)Interaction.MsgBox((object)"Are You Sour To Transfer Voucher ?", (MsgBoxStyle)292, (object)"DataCare Message") == 6)
		{
			DC_Main.ExeQuteDc("UPDATE SL_DATA SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_DETL SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_IDTL SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_ORD_ADJ SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_PR_DETL SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE BILL_OS_DATA SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE UPI_DATA SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			Ac_Ledr.Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Rojmel.Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Tax.Sales_GST(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Stock.Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
			Interaction.MsgBox((object)"Voucher are transferred sucessfully...", (MsgBoxStyle)0, (object)null);
			CLEAR_DATA();
			((Control)PnlTrfrVch).Visible = false;
		}
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		((Control)PnlUpdate).Visible = false;
		DC_Main.MsAcUpdate = tAcCode.Text;
		MS_ACCT mS_ACCT = new MS_ACCT();
		((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)mS_ACCT).Show();
		((Control)mS_ACCT).Focus();
	}

	private void TodayFineRate()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		DataTable dataTable = default(DataTable);
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
				case 604:
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
							goto IL_006f;
						case 4:
							goto IL_007c;
						case 5:
							goto IL_0095;
						case 6:
							goto IL_00b3;
						case 7:
							goto IL_0112;
						case 9:
							goto IL_0178;
						case 10:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 8:
						case 11:
						case 12:
						case 13:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00b3:
					num2 = 6;
					ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 103.0 * 100.0 / 10.0), "0.00"));
					goto IL_0112;
					IL_0112:
					num2 = 7;
					ToDaySlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 103.0 * 100.0 / 1000.0), "0.00"));
					goto end_IL_0001_3;
					IL_0095:
					num2 = 5;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
					{
						goto IL_00b3;
					}
					goto IL_0178;
					IL_0178:
					num2 = 9;
					ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 10.0), "0.00"));
					break;
					IL_000b:
					num2 = 2;
					DC_Main.RsQry = "SELECT TOP(1) FINE_GL_RATE,FINE_SL_RATE,VCH_DATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND SR_NO = 1  ORDER BY VCH_DATE DESC";
					goto IL_006f;
					IL_006f:
					num2 = 3;
					dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_007c;
					IL_007c:
					num2 = 4;
					if (dataTable.Rows.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0095;
					end_IL_0001_2:
					break;
				}
				num2 = 10;
				ToDaySlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 1000.0), "0.00"));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 604;
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

	private void chkPointMemb_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(EntryMode, "A", false) == 0 && (chkPointMemb.Checked & (Operators.CompareString(PointMemb, "", false) == 0) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0) & (Operators.CompareString(tAcCode.Text, "", false) != 0)))
		{
			DC_Main.RsQry = "INSERT INTO POINT_MEMB(CO_CODE,POINT_CODE,MEMB_CODE,MEMB_NAME,MOBILE_NO,SL_POINT,REF_POINT,MEMB_POINT)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MsPointCode + "','" + tAcCode.Text + "','" + tAcName.Text + "','" + tMobile.Text + "','Y','','')";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			((Control)chkPointMemb).Enabled = false;
			PointMemb = tAcCode.Text;
			((Control)tAcCode).Focus();
		}
	}

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From POINT_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MEMB_CODE = '" + tRefAc.Text + "' AND POINT_CODE = '" + DC_Main.MsPointCode + "' ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT MEMB_NAME As AcNameL,MEMB_CODE as AcCodeL,CARD_NO AS CardNoL,MOBILE_NO AS MobileL FROM POINT_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND POINT_CODE = '" + DC_Main.MsPointCode + "' AND MEMB_CODE <> '" + tAcCode.Text + "' ORDER BY MEMB_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 3500.0;
				DC_Main.ColWidth[1] = 1100.0;
				DC_Main.ColWidth[2] = 1200.0;
				DC_Main.ColWidth[3] = 1300.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
						tRefName.Text = DC_Main.ColValue[0];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				tRefName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)""));
				((Control)TEXT_ENTRY_2).Focus();
			}
		}
		else
		{
			((Control)TEXT_ENTRY_2).Focus();
		}
	}

	private void nUsePoint_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Conversion.Val(nUsePoint.Text) != 0.0)
			{
				nUseVal.Text = Conversions.ToString(Conversion.Val(nUsePoint.Text) * Conversion.Val(nPointSlVal.Text));
				MSG2_TOTAL[15, 2] = Conversions.ToString(Math.Round(Conversion.Val(nUseVal.Text), 0));
				((Control)TEXT_ENTRY_2).Focus();
			}
			else
			{
				((Control)TEXT_ENTRY_2).Focus();
			}
		}
	}

	private void TR_SALE_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Invalid comparison between Unknown and I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Invalid comparison between Unknown and I4
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Invalid comparison between Unknown and I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Invalid comparison between Unknown and I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Invalid comparison between Unknown and I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Invalid comparison between Unknown and I4
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Invalid comparison between Unknown and I4
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Invalid comparison between Unknown and I4
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Invalid comparison between Unknown and I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Invalid comparison between Unknown and I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Invalid comparison between Unknown and I4
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_IDTL).SelectionLength = Strings.Len(TEXT_IDTL.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_OLD", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_OLD).SelectionStart = 0;
			((TextBoxBase)TEXT_OLD).SelectionLength = Strings.Len(TEXT_OLD.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
		}
	}

	private void BtnQuot_Click(object sender, EventArgs e)
	{
		//IL_1e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		if (Operators.CompareString(EntryMode, "A", false) != 0)
		{
			return;
		}
		checked
		{
			if ((Operators.CompareString(tAcCode.Text, "00045", false) != 0) & (Operators.CompareString(tAcCode.Text, "", false) != 0))
			{
				if (unchecked((int)Interaction.MsgBox((object)("All Quatation Import From  " + tAcCode.Text + " This Account ?"), (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
				{
					return;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,C.MAIN_BOOK FROM (SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.AC_CODE = '" + tAcCode.Text + "' AND C.MAIN_BOOK = 'SL QUOT' ORDER BY A.VCH_NO,A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 103] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["CO_BOOK"], (object)""));
					mSG[DC_Main.i + 1, 104] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_NO"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 97] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 85] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["GHT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_COST"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_CODE"], (object)""));
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num2 = DC_Main.i + 1;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num2, 81] = Conversions.ToString(num3);
					mSG[DC_Main.i + 1, 86] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 88] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 63] = "E";
					mSG[DC_Main.i + 1, 93] = "Y";
					mSG[DC_Main.i + 1, 94] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 95] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					AxMSFlexGrid obj2 = mSG;
					int num4 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ORD_SRNO"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["ORD_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj2[num4, 96] = Conversions.ToString(num5);
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.AC_CODE = '" + tAcCode.Text + "'  AND A.TAG_NO = '" + MSG[DC_Main.i + 1, 1] + "' AND A.VCH_SRNO = " + MSG[DC_Main.i + 1, 52] + " ORDER BY A.ISR_NO";
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					for (int i = 0; i < RsIdtl.Rows.Count; i++)
					{
						dr = DtIdtl.NewRow();
						dr[23] = DC_Main.i + 1;
						dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["ISR_NO"]);
						dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[i]["IT_CODE"], (object)"");
						dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[i]["IT_NAME"], (object)"");
						dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_CODE"], (object)"");
						dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_NAME"], (object)"");
						dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_COLOR"], (object)"");
						dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_SIZE"], (object)"");
						dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_ORIGIN"], (object)"");
						dr[8] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_REMARK"], (object)"");
						dr[9] = Operators.ConcatenateObject(RsIdtl.Rows[i]["DM_SFNO"], (object)"");
						dr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_PCS"]);
						dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_GWT"])), "0.000");
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["KR_WT"])), "0.000");
						dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_CON_PRC"])), "0.000");
						dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[i]["IT_RATE_TYPE"], (object)"");
						dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_RATE"])), "0.00");
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_AMT"])), "0.00");
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_LBR_RATE"])), "0.00");
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_LBR_AMT"])), "0.00");
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_NET_AMT"])), "0.00");
						dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[i]["IT_CON_WT"])), "0.000");
						dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[i]["KR_CON_WT"], (object)"")), "0.000");
						dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[i]["IT_TYPE"], (object)"");
						DtIdtl.Rows.Add(dr);
					}
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					BILL_TOTAL();
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				tItDesc.Text = MSG[1, 75];
				((Control)TEXT_ENTRY).Visible = false;
				((Control)tAcCode).Focus();
				return;
			}
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,CO_BOOK As BookL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_REF_NAME As RefByL,TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '099'  ORDER BY A.VCH_NO";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[8];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 300.0;
			DC_Main.ColWidth[4] = 200.0;
			DC_Main.ColWidth[5] = 250.0;
			DC_Main.ColWidth[6] = 120.0;
			DC_Main.HelpSelect = 0;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose || DC_Main.HelpClose)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				QtNo = DC_Main.ColValue[0];
				QtDbCd = DC_Main.ColValue[2];
				DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (RsData.Rows.Count > 0)
				{
					tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
					OldAcCode = tAcCode.Text;
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
					AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
					DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 4] + "'";
					DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsAc.Rows.Count > 0)
					{
						MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
					}
					tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
					DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
					DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsAc.Rows.Count > 0)
					{
						tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
					}
					tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_NAME"], (object)""));
					tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
					nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
					tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
					tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
					tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
					tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
					tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
					MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
					DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
					DC_Main.RsQry = "SELECT SUM(TOT_AMT) As TOT_AMT FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + QtDbCd + "' AND SL_BILL_NO = '" + QtNo + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						if (DC_Main.MsAcAmtOpBal > 0.0)
						{
							DC_Main.MsAcAmtOpBal -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)"")), "0.00"));
						}
						else if (DC_Main.MsAcAmtOpBal < 0.0)
						{
							DC_Main.MsAcAmtOpBal += Conversions.ToDouble(Strings.Format((object)(0.0 - Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)""))), "0.00"));
						}
					}
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
						((Control)LOpAmt).ForeColor = Color.Blue;
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
						((Control)LOpAmt).ForeColor = Color.Red;
					}
					else
					{
						LOpAmt.Text = ": Amt";
					}
					if (DC_Main.MsAcAmtClBal > 0.0)
					{
						LClAmt.Text = Strings.Format((object)DC_Main.MsAcAmtClBal, "0.00") + " : Cr Amt";
						((Control)LClAmt).ForeColor = Color.Blue;
					}
					else if (DC_Main.MsAcAmtClBal < 0.0)
					{
						LClAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtClBal), "0.00") + " : Dr Amt";
						((Control)LClAmt).ForeColor = Color.Red;
					}
					else
					{
						LClAmt.Text = ": Amt";
					}
					CustOpAmt = DC_Main.MsAcAmtOpBal;
					CustClAmt = DC_Main.MsAcAmtClBal;
					DC_Main.MsAcAmtOpBal = 0.0;
					DC_Main.MsAcGoldOpBal = 0.0;
					DC_Main.MsAcSilverOpBal = 0.0;
					DC_Main.MsAcAmtClBal = 0.0;
					DC_Main.MsAcGoldClBal = 0.0;
					DC_Main.MsAcSilverClBal = 0.0;
				}
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + QtDbCd + "' AND A.VCH_NO = '" + QtNo + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG2 = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG2[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG2[DC_Main.i + 1, 57] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG2[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG2[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG2[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG2[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG2[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG2[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG2[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG2[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG2[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG2[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG2[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 11] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG2[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG2[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG2[DC_Main.i + 1, 97] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_GWT"])), "0.000");
					mSG2[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG2[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG2[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_NWT"])), "0.000");
					mSG2[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG2[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG2[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG2[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG2[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG2[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG2[DC_Main.i + 1, 85] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG2[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG2[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG2[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["GHT_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["RATE_WITH"]);
					mSG2[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG2[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG2[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG2[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_COST"], (object)"")), "0.00");
					mSG2[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG2[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG2[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG2[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_CODE"], (object)""));
					mSG2[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG2[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG2[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG2[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG2[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG2[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG2[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj3 = mSG2;
					int num6 = DC_Main.i + 1;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj3[num6, 81] = Conversions.ToString(num7);
					mSG2[DC_Main.i + 1, 86] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG2[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG2[DC_Main.i + 1, 88] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG2[DC_Main.i + 1, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG2[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG2[DC_Main.i + 1, 63] = "E";
					mSG2[DC_Main.i + 1, 93] = "Y";
					mSG2[DC_Main.i + 1, 94] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG2[DC_Main.i + 1, 95] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					AxMSFlexGrid obj4 = mSG2;
					int num8 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ORD_SRNO"]);
					double num9 = DC_Main.Fnv(ref Value);
					dataRow["ORD_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj4[num8, 96] = Conversions.ToString(num9);
					mSG2.Rows += 1;
					DC_Main.i++;
				}
				if (mSG2.Rows > 2)
				{
					mSG2.Rows -= 1;
				}
				mSG2 = null;
				tItDesc.Text = MSG[1, 75];
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num10 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num10)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + QtDbCd + "' AND A.VCH_NO = '" + QtNo + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					dr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					dr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				BILL_TOTAL();
				((Control)tAcCode).Focus();
			}
			else
			{
				QtNo = "";
				QtDbCd = "";
				((Control)tVchNo).Focus();
			}
		}
	}

	private void tAcCode_DoubleClick(object sender, EventArgs e)
	{
		if (!((Control)PnlUpdate).Visible)
		{
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				((Control)PnlUpdate).Visible = true;
			}
			else
			{
				((Control)PnlUpdate).Visible = false;
			}
		}
		else
		{
			((Control)PnlUpdate).Visible = false;
		}
	}

	private void mVchDate_Click(object sender, EventArgs e)
	{
		((TextBoxBase)mVchDate).SelectionStart = 0;
		((TextBoxBase)mVchDate).SelectionLength = Strings.Len(mVchDate.Text);
		if (!((Control)PnlTrfrVch).Visible)
		{
			((Control)BtnSave).Enabled = true;
		}
	}

	private void tAcCode_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcCode).SelectionStart = 0;
		((TextBoxBase)tAcCode).SelectionLength = Strings.Len(tAcCode.Text);
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		if (!((Control)PnlTrfrVch).Visible)
		{
			((Control)BtnSave).Enabled = true;
		}
	}

	private void chkRateUnFix_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)mVchDate).Focus();
		}
	}

	private void tAcMembCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcMembCode.Text + "' AND AC_CITY = '" + tCity.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CITY = '" + tCity.Text + "' AND (A.AC_WITH_MEMB_COM = 'Y' OR A.AC_SHARE_HOLDER_COM = 'Y') ORDER BY A.LC_CODE,A.AC_NAME";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CITY = '" + tCity.Text + "' AND (A.AC_WITH_MEMB_COM = 'Y' OR A.AC_SHARE_HOLDER_COM = 'Y') ORDER BY A.AC_NAME";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[8];
			DC_Main.ColWidth[0] = 270.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 170.0;
			DC_Main.ColWidth[3] = 180.0;
			DC_Main.ColWidth[4] = 220.0;
			DC_Main.ColWidth[5] = 160.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcMembCode.Text = DC_Main.ColValue[1];
					tAcMembName.Text = DC_Main.ColValue[0];
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcMembName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			((Control)tAcCode).Focus();
		}
	}

	private void tTrfrNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void mVchDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
	{
	}
}
