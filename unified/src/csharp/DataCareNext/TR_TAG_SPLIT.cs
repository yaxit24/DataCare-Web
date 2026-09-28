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
using QRCoder;

namespace DataCareNext;

[DesignerGenerated]
public class TR_TAG_SPLIT : Form
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
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_PR")]
	private AxMSFlexGrid _MSG_PR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_PR")]
	private TextBox _TEXT_PR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_RTN_IDTL")]
	private AxMSFlexGrid _MSG_RTN_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_RTN_IDTL")]
	private TextBox _TEXT_RTN_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrWt")]
	private TextBox _nCrWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDrWt")]
	private TextBox _nDrWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrFine")]
	private TextBox _nCrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrTouch")]
	private TextBox _nCrTouch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrLbrAmt")]
	private TextBox _nCrLbrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDrTouch")]
	private TextBox _nDrTouch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDrFine")]
	private TextBox _nDrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkSameTag")]
	private CheckBox _chkSameTag;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt4")]
	private TextBox _nHmWt4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId4")]
	private TextBox _tHmId4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt3")]
	private TextBox _nHmWt3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId3")]
	private TextBox _tHmId3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt2")]
	private TextBox _nHmWt2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt")]
	private TextBox _nHmWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId2")]
	private TextBox _tHmId2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label15")]
	private Label _Label15;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnVchPrint")]
	private SimpleButton _btnVchPrint;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgPrClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private string CurRatePar;

	private double LessAdvAmt;

	private double LessAdvNetWt;

	private double CrDrTot;

	private string CurRptTagNo;

	private bool EditOPen;

	private double SlOthAmtLess;

	private double PrOthAmtLess;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private DataTable VchOldData;

	private double TotCrFine;

	private double TotDrFine;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsPrDetl;

	private DataTable RsBarDetl;

	private DataTable RsBarData;

	private DataTable RsBillOs;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private int RtnRow;

	private DataTable RtnIdtl;

	private DataRow Rtndr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private int RtnOldRow;

	private bool MsgIdtlLeft;

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

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItCode = 2;

	private const int cCounter = 3;

	private const int cDesign = 4;

	private const int cColor = 5;

	private const int cSize = 6;

	private const int cHmId = 7;

	private const int cBagWt = 8;

	private const int cPcs = 9;

	private const int cGrWt = 10;

	private const int cOthWt = 11;

	private const int cNetWt = 12;

	private const int cKrOthWt = 13;

	private const int cKrNetWt = 14;

	private const int cKrGhatPrc = 15;

	private const int cKrGhatWt = 16;

	private const int cKrTouch = 17;

	private const int cKrWestPrc = 18;

	private const int cKrFine = 19;

	private const int cLbrCode = 20;

	private const int cGhtPrc = 21;

	private const int cGhtWt = 22;

	private const int cTouch = 23;

	private const int cWestPrc = 24;

	private const int cFine = 25;

	private const int cLbrPrc = 26;

	private const int cLbrType = 27;

	private const int cLbrRate = 28;

	private const int cLbrAmt = 29;

	private const int cOthAmt = 30;

	private const int cKrLRate = 31;

	private const int cKrLAmt = 32;

	private const int cKrOthAmt = 33;

	private const int cSlType = 34;

	private const int cKrOthRate = 35;

	private const int cKrOthFine = 36;

	private const int cKrTotFine = 37;

	private const int cKrGwtTouch = 38;

	private const int cItRate = 39;

	private const int cItAmt = 40;

	private const int cPrCost = 41;

	private const int cTagCost = 42;

	private const int cMargin = 43;

	private const int cMrp = 44;

	private const int cImageTake = 45;

	private const int cItRemark = 46;

	private const int cKrName = 47;

	private const int cJdtNet = 48;

	private const int cGhatWt = 49;

	private const int cKundan = 50;

	private const int cKndTch = 51;

	private const int cKndNwt = 52;

	private const int cWax = 53;

	private const int cKrWax = 54;

	private const int cTagSrNo = 55;

	private const int cOldSrNo = 56;

	private const int cRateType = 57;

	private const int cItType = 58;

	private const int cTagType = 59;

	private const int cPrCode = 60;

	private const int cVchSrno = 61;

	private const int cItName = 62;

	private const int cEntryMod = 63;

	private const int cHmId2 = 64;

	private const int cHmId3 = 65;

	private const int cHmId4 = 66;

	private const int cHmIdWt = 67;

	private const int cHmId2Wt = 68;

	private const int cHmId3Wt = 69;

	private const int cHmId4Wt = 70;

	private const int cDataType = 71;

	private const int cDesignImgId = 72;

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

	private const int c1PcsWt = 11;

	private const int c1KrActWt = 12;

	private const int c1KrActPrc = 13;

	private const int c1KrWt = 14;

	private const int c1KrPrc = 15;

	private const int c1GrWt = 16;

	private const int c1ConPrc = 17;

	private const int c1RateType = 18;

	private const int c1ItRate = 19;

	private const int c1ItmAmt = 20;

	private const int c1KrRate = 21;

	private const int c1KrAmt = 22;

	private const int c1LbrRate = 23;

	private const int c1LbrAmt = 24;

	private const int c1NetAmt = 25;

	private const int c1ConWt = 26;

	private const int c1KrConWt = 27;

	private const int c1ItType = 28;

	private const int c1RowSr = 29;

	private const int c1oldKrWt = 30;

	private const int c1oldGrWt = 31;

	private const int cTitel2 = 0;

	private const int cNetAmt2 = 1;

	private const int cTax2 = 2;

	private const int cTot2 = 3;

	private const int cChq2 = 4;

	private const int cCard2 = 5;

	private const int cCash2 = 6;

	private const int cKasar2 = 7;

	private const int cOs2 = 8;

	private const int cPSrNo = 0;

	private const int cPItCode = 1;

	private const int cPTagNo = 2;

	private const int cPCounter = 3;

	private const int cPDesign = 4;

	private const int cPColor = 5;

	private const int cPSize = 6;

	private const int cPHmId = 7;

	private const int cPSign = 8;

	private const int cPBagWt = 9;

	private const int cPPcs = 10;

	private const int cPGrWt = 11;

	private const int cPOthWt = 12;

	private const int cPNetWt = 13;

	private const int cPKrOthWt = 14;

	private const int cPKrNetWt = 15;

	private const int cPKrGhatPrc = 16;

	private const int cPKrGhatWt = 17;

	private const int cPKrTouch = 18;

	private const int cPKrWestPrc = 19;

	private const int cPKrFine = 20;

	private const int cPLbrCode = 21;

	private const int cPGhtPrc = 22;

	private const int cPGhtWt = 23;

	private const int cPTouch = 24;

	private const int cPWestPrc = 25;

	private const int cPFine = 26;

	private const int cPLbrPrc = 27;

	private const int cPLbrType = 28;

	private const int cPLbrRate = 29;

	private const int cPLbrAmt = 30;

	private const int cPOthAmt = 31;

	private const int cPKrLRate = 32;

	private const int cPKrLAmt = 33;

	private const int cPKrOthAmt = 34;

	private const int cPSlType = 35;

	private const int cPKrOthRate = 36;

	private const int cPKrOthFine = 37;

	private const int cPKrTotFine = 38;

	private const int cPKrGwtTouch = 39;

	private const int cPItRate = 40;

	private const int cPItAmt = 41;

	private const int cPPrCost = 42;

	private const int cPTagCost = 43;

	private const int cPMargin = 44;

	private const int cPMrp = 45;

	private const int cPImageTake = 46;

	private const int cPItRemark = 47;

	private const int cPKrName = 48;

	private const int cPJdtNet = 49;

	private const int cPGhatWt = 50;

	private const int cPKundan = 51;

	private const int cPKndTch = 52;

	private const int cPKndNwt = 53;

	private const int cPWax = 54;

	private const int cPKrWax = 55;

	private const int cPTagSrNo = 56;

	private const int cPOldSrNo = 57;

	private const int cPRateType = 58;

	private const int cPItType = 59;

	private const int cPTagType = 60;

	private const int cPPrCode = 61;

	private const int cPVchSrno = 62;

	private const int cPItName = 63;

	private const int cPEntryMod = 64;

	private const int cPOldTagType = 65;

	private const int cPOldPrCode = 66;

	private const int cPOldGrWt = 67;

	private const int cPOldNtWt = 68;

	private const int cPOldGhatPrc = 69;

	private const int cPOldGhatWt = 70;

	private const int cPOldTouch = 71;

	private const int cPOldWestPrc = 72;

	private const int cPOldKrNetWt = 73;

	private const int cPOldKrTouch = 74;

	private const int cPOldKrWest = 75;

	private const int cPAprIsu = 76;

	private const int cPHmId2 = 77;

	private const int cPHmId3 = 78;

	private const int cPHmId4 = 79;

	private const int cPHmIdWt = 80;

	private const int cPHmId2Wt = 81;

	private const int cPHmId3Wt = 82;

	private const int cPHmId4Wt = 83;

	private const int cPDataType = 84;

	private const int cPOldMargin = 85;

	private const int cPOldTagNo = 86;

	private const int cPOldMainMargin = 87;

	private const int cPOldKrGhatWt = 88;

	private const int cPEmpIsu = 89;

	private const int cPrDesignImgId = 90;

	private const int c2SrNo = 0;

	private const int c2ItCode = 1;

	private const int c2ItName = 2;

	private const int c2DmCode = 3;

	private const int c2DmName = 4;

	private const int c2DmColor = 5;

	private const int c2DmSize = 6;

	private const int c2DmOrigin = 7;

	private const int c2DmRemark = 8;

	private const int c2DmSfNo = 9;

	private const int c2Pcs = 10;

	private const int c2PcsWt = 11;

	private const int c2KrActWt = 12;

	private const int c2KrActPrc = 13;

	private const int c2KrWt = 14;

	private const int c2KrPrc = 15;

	private const int c2GrWt = 16;

	private const int c2ConPrc = 17;

	private const int c2RateType = 18;

	private const int c2ItRate = 19;

	private const int c2ItmAmt = 20;

	private const int c2KrRate = 21;

	private const int c2KrAmt = 22;

	private const int c2LbrRate = 23;

	private const int c2LbrAmt = 24;

	private const int c2NetAmt = 25;

	private const int c2ConWt = 26;

	private const int c2KrConWt = 27;

	private const int c2ItType = 28;

	private const int c2RowSr = 29;

	private const int c2oldKrWt = 30;

	private const int c2oldGrWt = 31;

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
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mVchDate_KeyDown);
			MaskedTextBox val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mVchDate = value;
			val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TVchNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			EventHandler eventHandler2 = tVchNo_DoubleClick;
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler2;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler2;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private virtual FlowLayoutPanel _FlowLayoutPanel1;

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_FlowLayoutPanel1 = value;
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
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual AxMSFlexGrid MSG_PR
	{
		[CompilerGenerated]
		get
		{
			return _MSG_PR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_PR_ClickEvent;
			EventHandler eventHandler2 = MSG_PR_EnterCell;
			EventHandler eventHandler3 = MSG_PR_LeaveCell;
			EventHandler eventHandler4 = MSG_PR_RowColChange;
			EventHandler eventHandler5 = MSG_PR_Scroll;
			AxMSFlexGrid val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
				val.Scroll -= eventHandler5;
			}
			_MSG_PR = value;
			val = _MSG_PR;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_2_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_2_KeyDown);
			EventHandler eventHandler2 = TEXT_ENTRY_2_GotFocus;
			TextBox val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler2;
			}
			_TEXT_ENTRY_2 = value;
			val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler2;
			}
		}
	}

	internal virtual TextBox TEXT_PR
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_PR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_PR_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_PR_KeyDown);
			TextBox val2 = _TEXT_PR;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_PR = value;
			val2 = _TEXT_PR;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_PR_TOT")]
	private virtual AxMSFlexGrid _MSG_PR_TOT;

	internal virtual AxMSFlexGrid MSG_PR_TOT
	{
		get
		{
			return _MSG_PR_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_PR_TOT = value;
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

	internal virtual AxMSFlexGrid MSG_RTN_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_RTN_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_RTN_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_RTN_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_RTN_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_RTN_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_RTN_IDTL = value;
			val = _MSG_RTN_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_RTN_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_RTN_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_RTN_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_RTN_IDTL_KeyDown);
			TextBox val2 = _TEXT_RTN_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_RTN_IDTL = value;
			val2 = _TEXT_RTN_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nCrWt
	{
		[CompilerGenerated]
		get
		{
			return _nCrWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrWt_KeyDown);
			TextBox val2 = _nCrWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrWt = value;
			val2 = _nCrWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nDrWt
	{
		[CompilerGenerated]
		get
		{
			return _nDrWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDrWt_KeyDown);
			TextBox val2 = _nDrWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDrWt = value;
			val2 = _nDrWt;
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

	internal virtual TextBox nCrFine
	{
		[CompilerGenerated]
		get
		{
			return _nCrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrFine_KeyDown);
			TextBox val2 = _nCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrFine = value;
			val2 = _nCrFine;
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

	internal virtual TextBox nCrTouch
	{
		[CompilerGenerated]
		get
		{
			return _nCrTouch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrTouch_KeyDown);
			TextBox val2 = _nCrTouch;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrTouch = value;
			val2 = _nCrTouch;
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

	internal virtual TextBox nCrLbrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nCrLbrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrLbrAmt_KeyDown);
			TextBox val2 = _nCrLbrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrLbrAmt = value;
			val2 = _nCrLbrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nDrTouch
	{
		[CompilerGenerated]
		get
		{
			return _nDrTouch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDrTouch_KeyDown);
			TextBox val2 = _nDrTouch;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDrTouch = value;
			val2 = _nDrTouch;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nDrFine
	{
		[CompilerGenerated]
		get
		{
			return _nDrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDrFine_KeyDown);
			TextBox val2 = _nDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDrFine = value;
			val2 = _nDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private virtual PictureBox _PictureBox1;

	internal virtual PictureBox PictureBox1
	{
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PictureBox1 = value;
		}
	}

	internal virtual CheckBox chkSameTag
	{
		[CompilerGenerated]
		get
		{
			return _chkSameTag;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkSameTag_KeyDown);
			CheckBox val2 = _chkSameTag;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkSameTag = value;
			val2 = _chkSameTag;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboItemTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
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

	internal virtual TextBox nHmWt4
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt4_KeyDown);
			TextBox val2 = _nHmWt4;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nHmWt4 = value;
			val2 = _nHmWt4;
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

	internal virtual TextBox tHmId4
	{
		[CompilerGenerated]
		get
		{
			return _tHmId4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHmId4_KeyDown);
			TextBox val2 = _tHmId4;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHmId4 = value;
			val2 = _tHmId4;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nHmWt3
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt3_KeyDown);
			TextBox val2 = _nHmWt3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nHmWt3 = value;
			val2 = _nHmWt3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tHmId3
	{
		[CompilerGenerated]
		get
		{
			return _tHmId3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHmId3_KeyDown);
			TextBox val2 = _tHmId3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHmId3 = value;
			val2 = _tHmId3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nHmWt2
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt2_KeyDown);
			EventHandler eventHandler = nHmWt2_TextChanged;
			TextBox val2 = _nHmWt2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nHmWt2 = value;
			val2 = _nHmWt2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
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

	internal virtual TextBox nHmWt
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt_KeyDown);
			EventHandler eventHandler = nHmWt_TextChanged;
			TextBox val2 = _nHmWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nHmWt = value;
			val2 = _nHmWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	internal virtual TextBox tHmId2
	{
		[CompilerGenerated]
		get
		{
			return _tHmId2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHmId2_KeyDown);
			TextBox val2 = _tHmId2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHmId2 = value;
			val2 = _tHmId2;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSet")]
	private virtual SimpleButton _btnTagSet;

	internal virtual SimpleButton btnTagSet
	{
		get
		{
			return _btnTagSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_btnTagSet = value;
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

	internal virtual Label Label15
	{
		[CompilerGenerated]
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Label15_Click;
			Label val = _Label15;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Label15 = value;
			val = _Label15;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox2")]
	private virtual PictureBox _PictureBox2;

	internal virtual PictureBox PictureBox2
	{
		get
		{
			return _PictureBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PictureBox2 = value;
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
	[AccessedThroughProperty("nLableSkip")]
	private virtual TextBox _nLableSkip;

	internal virtual TextBox nLableSkip
	{
		get
		{
			return _nLableSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLableSkip = value;
		}
	}

	internal virtual SimpleButton btnVchPrint
	{
		[CompilerGenerated]
		get
		{
			return _btnVchPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnVchPrint_Click;
			SimpleButton val = _btnVchPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnVchPrint = value;
			val = _btnVchPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public TR_TAG_SPLIT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_TAG_SPLIT_Load;
		((Form)this).Deactivate += TR_TAG_SPLIT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_TAG_SPLIT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_TAG_SPLIT_KeyDown);
		((Form)this).Activated += TR_TAG_SPLIT_Activated;
		((Form)this).Closed += TR_TAG_SPLIT_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_TAG_SPLIT_KeyUp);
		LessAdvAmt = 0.0;
		LessAdvNetWt = 0.0;
		CrDrTot = 0.0;
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		RtnIdtl = new DataTable();
		Rtndr = RtnIdtl.NewRow();
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
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected O, but got Unknown
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected O, but got Unknown
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Expected O, but got Unknown
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b2: Expected O, but got Unknown
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected O, but got Unknown
		//IL_09ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b8: Expected O, but got Unknown
		//IL_0a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6b: Expected O, but got Unknown
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Expected O, but got Unknown
		//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Expected O, but got Unknown
		//IL_0ca8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb2: Expected O, but got Unknown
		//IL_0dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc7: Expected O, but got Unknown
		//IL_0e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e34: Expected O, but got Unknown
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Unknown result type (might be due to invalid IL or missing references)
		//IL_1041: Expected O, but got Unknown
		//IL_10a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ae: Expected O, but got Unknown
		//IL_11b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bd: Expected O, but got Unknown
		//IL_12b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bf: Expected O, but got Unknown
		//IL_13d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13da: Expected O, but got Unknown
		//IL_1454: Unknown result type (might be due to invalid IL or missing references)
		//IL_145e: Expected O, but got Unknown
		//IL_151f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1529: Expected O, but got Unknown
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15da: Expected O, but got Unknown
		//IL_16d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16df: Expected O, but got Unknown
		//IL_1740: Unknown result type (might be due to invalid IL or missing references)
		//IL_174a: Expected O, but got Unknown
		//IL_1853: Unknown result type (might be due to invalid IL or missing references)
		//IL_185d: Expected O, but got Unknown
		//IL_1935: Unknown result type (might be due to invalid IL or missing references)
		//IL_193f: Expected O, but got Unknown
		//IL_19db: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e5: Expected O, but got Unknown
		//IL_1b20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2a: Expected O, but got Unknown
		//IL_1b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7f: Expected O, but got Unknown
		//IL_1bfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c07: Expected O, but got Unknown
		//IL_1c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c96: Expected O, but got Unknown
		//IL_1d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6a: Expected O, but got Unknown
		//IL_1e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1b: Expected O, but got Unknown
		//IL_1e9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea6: Expected O, but got Unknown
		//IL_1f2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f38: Expected O, but got Unknown
		//IL_1fec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff6: Expected O, but got Unknown
		//IL_20aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b4: Expected O, but got Unknown
		//IL_216c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2176: Expected O, but got Unknown
		//IL_21ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f4: Expected O, but got Unknown
		//IL_224f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2259: Expected O, but got Unknown
		//IL_22f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2302: Expected O, but got Unknown
		//IL_23a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b3: Expected O, but got Unknown
		//IL_2401: Unknown result type (might be due to invalid IL or missing references)
		//IL_240b: Expected O, but got Unknown
		//IL_24bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c6: Expected O, but got Unknown
		//IL_2590: Unknown result type (might be due to invalid IL or missing references)
		//IL_259a: Expected O, but got Unknown
		//IL_25f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ff: Expected O, but got Unknown
		//IL_2691: Unknown result type (might be due to invalid IL or missing references)
		//IL_269b: Expected O, but got Unknown
		//IL_2749: Unknown result type (might be due to invalid IL or missing references)
		//IL_2753: Expected O, but got Unknown
		//IL_27f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_27fa: Expected O, but got Unknown
		//IL_28ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b5: Expected O, but got Unknown
		//IL_296a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2974: Expected O, but got Unknown
		//IL_2a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a2f: Expected O, but got Unknown
		//IL_2adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae6: Expected O, but got Unknown
		//IL_2b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b9e: Expected O, but got Unknown
		//IL_2c3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c45: Expected O, but got Unknown
		//IL_2cf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d00: Expected O, but got Unknown
		//IL_2da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2daa: Expected O, but got Unknown
		//IL_2e5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e65: Expected O, but got Unknown
		//IL_2f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f17: Expected O, but got Unknown
		//IL_2fc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fd2: Expected O, but got Unknown
		//IL_311b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3125: Expected O, but got Unknown
		//IL_31ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_31f7: Expected O, but got Unknown
		//IL_3260: Unknown result type (might be due to invalid IL or missing references)
		//IL_326a: Expected O, but got Unknown
		//IL_331b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3325: Expected O, but got Unknown
		//IL_33a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_33aa: Expected O, but got Unknown
		//IL_345e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3468: Expected O, but got Unknown
		//IL_34ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_34f4: Expected O, but got Unknown
		//IL_356f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3579: Expected O, but got Unknown
		//IL_362d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3637: Expected O, but got Unknown
		//IL_36b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_36c3: Expected O, but got Unknown
		//IL_373e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3748: Expected O, but got Unknown
		//IL_37fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3806: Expected O, but got Unknown
		//IL_3891: Unknown result type (might be due to invalid IL or missing references)
		//IL_389b: Expected O, but got Unknown
		//IL_3908: Unknown result type (might be due to invalid IL or missing references)
		//IL_3912: Expected O, but got Unknown
		//IL_39e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_39ed: Expected O, but got Unknown
		//IL_3ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3acc: Expected O, but got Unknown
		//IL_3b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b72: Expected O, but got Unknown
		//IL_3cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cc1: Expected O, but got Unknown
		//IL_3d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d48: Expected O, but got Unknown
		//IL_3e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e7f: Expected O, but got Unknown
		//IL_3f33: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f3d: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_TAG_SPLIT));
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
		btnVchPrint = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
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
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_PR = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_PR = new TextBox();
		MSG_PR_TOT = new AxMSFlexGrid();
		LOpAmt = new Label();
		LClAmt = new Label();
		MSG_RTN_IDTL = new AxMSFlexGrid();
		TEXT_RTN_IDTL = new TextBox();
		Label23 = new Label();
		nCrWt = new TextBox();
		Label20 = new Label();
		nDrWt = new TextBox();
		Label5 = new Label();
		nCrFine = new TextBox();
		Label6 = new Label();
		nCrTouch = new TextBox();
		Label7 = new Label();
		nCrLbrAmt = new TextBox();
		Label8 = new Label();
		nDrTouch = new TextBox();
		Label9 = new Label();
		nDrFine = new TextBox();
		PictureBox1 = new PictureBox();
		chkSameTag = new CheckBox();
		cboItemTyp = new ComboBox();
		Label10 = new Label();
		nHmWt4 = new TextBox();
		Label11 = new Label();
		tHmId4 = new TextBox();
		nHmWt3 = new TextBox();
		Label12 = new Label();
		tHmId3 = new TextBox();
		nHmWt2 = new TextBox();
		Label13 = new Label();
		nHmWt = new TextBox();
		tHmId2 = new TextBox();
		Label14 = new Label();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label15 = new Label();
		PictureBox2 = new PictureBox();
		Label16 = new Label();
		nLableSkip = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((ISupportInitialize)MSG_RTN_IDTL).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)PictureBox2).BeginInit();
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
		lblBook.Text = "Tag Split";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(298, 37);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(222, 38);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 39);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(95, 37);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(469, 37);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(380, 37);
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
		((Control)BtnPrint).Location = new Point(730, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&TagPrn";
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnVchPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 25;
		((BaseStyleControl)btnVchPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnVchPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnVchPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnVchPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnVchPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnVchPrint.ImageOptions.SvgImage");
		((Control)btnVchPrint).Location = new Point(827, 3);
		((BaseControl)btnVchPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnVchPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnVchPrint).Name = "btnVchPrint";
		((Control)btnVchPrint).Size = new Size(91, 37);
		((Control)btnVchPrint).TabIndex = 29;
		btnVchPrint.Text = "VchPrn";
		((BaseButton)btnVchPrint).ToolTipAnchor = (ToolTipAnchor)1;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(240, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(484, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(193, 3);
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
		((Control)BtnFirst).Location = new Point(146, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 6;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(394, 95);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 4;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(952, 40);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(218, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(246, 191);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 5;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 167);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(934, 87);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(952, 167);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(108, 87);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 147);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 65);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 84);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1222, 341);
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
		((Control)BtnF1).Location = new Point(177, 37);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1222, 307);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(93, 482);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(90, 23);
		((Control)tAcCode).TabIndex = 15;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(189, 482);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(238, 23);
		((Control)tAcName).TabIndex = 26;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(11, 481);
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
		((Control)tEmpCode).Location = new Point(908, 483);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(60, 23);
		((Control)tEmpCode).TabIndex = 23;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(970, 483);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(200, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(828, 483);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(824, 510);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(73, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(908, 512);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(263, 49);
		((Control)tVchDesc).TabIndex = 24;
		((Control)MSG2_TOTAL).Location = new Point(1222, 373);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(541, 185);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG2_TOTAL).Visible = false;
		((Control)MSG_PR).Location = new Point(12, 259);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1159, 84);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(1238, 463);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 27;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(405, 295);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).RightToLeft = (RightToLeft)0;
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 6;
		((Control)MSG_PR_TOT).Location = new Point(15, 343);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(1153, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1222, 40);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(66, 20);
		((Control)LOpAmt).TabIndex = 1205;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(1222, 274);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(84, 20);
		((Control)LClAmt).TabIndex = 1208;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)MSG_RTN_IDTL).Location = new Point(12, 388);
		((Control)MSG_RTN_IDTL).Name = "MSG_RTN_IDTL";
		((AxHost)MSG_RTN_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_RTN_IDTL.OcxState");
		((Control)MSG_RTN_IDTL).Size = new Size(934, 88);
		((Control)MSG_RTN_IDTL).TabIndex = 1213;
		((TextBoxBase)TEXT_RTN_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_RTN_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_RTN_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_RTN_IDTL).ForeColor = Color.White;
		((Control)TEXT_RTN_IDTL).Location = new Point(514, 418);
		((Control)TEXT_RTN_IDTL).Name = "TEXT_RTN_IDTL";
		((Control)TEXT_RTN_IDTL).RightToLeft = (RightToLeft)0;
		((Control)TEXT_RTN_IDTL).Size = new Size(100, 18);
		((Control)TEXT_RTN_IDTL).TabIndex = 14;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Green;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(9, 510);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(79, 20);
		((Control)Label23).TabIndex = 1225;
		Label23.Text = "Weight Cr";
		Label23.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrWt).BackColor = Color.Beige;
		((Control)nCrWt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nCrWt).ForeColor = Color.Green;
		((Control)nCrWt).Location = new Point(93, 510);
		((TextBoxBase)nCrWt).MaxLength = 10;
		((Control)nCrWt).Name = "nCrWt";
		((Control)nCrWt).Size = new Size(90, 22);
		((Control)nCrWt).TabIndex = 16;
		nCrWt.TextAlign = (HorizontalAlignment)1;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Maroon;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(433, 486);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(76, 20);
		((Control)Label20).TabIndex = 1224;
		Label20.Text = "Weight Dr";
		Label20.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDrWt).BackColor = Color.Lavender;
		((Control)nDrWt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nDrWt).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nDrWt).Location = new Point(514, 484);
		((TextBoxBase)nDrWt).MaxLength = 10;
		((Control)nDrWt).Name = "nDrWt";
		((TextBoxBase)nDrWt).ReadOnly = true;
		((Control)nDrWt).Size = new Size(83, 22);
		((Control)nDrWt).TabIndex = 20;
		nDrWt.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Green;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(195, 511);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1227;
		Label5.Text = "Fine Cr";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrFine).BackColor = Color.Beige;
		((Control)nCrFine).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nCrFine).ForeColor = Color.Green;
		((Control)nCrFine).Location = new Point(279, 511);
		((TextBoxBase)nCrFine).MaxLength = 10;
		((Control)nCrFine).Name = "nCrFine";
		((TextBoxBase)nCrFine).ReadOnly = true;
		((Control)nCrFine).Size = new Size(90, 22);
		((Control)nCrFine).TabIndex = 18;
		nCrFine.TextAlign = (HorizontalAlignment)1;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Green;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(9, 538);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(79, 20);
		((Control)Label6).TabIndex = 1229;
		Label6.Text = "Touch Cr";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrTouch).BackColor = Color.Beige;
		((Control)nCrTouch).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nCrTouch).ForeColor = Color.Green;
		((Control)nCrTouch).Location = new Point(93, 539);
		((TextBoxBase)nCrTouch).MaxLength = 10;
		((Control)nCrTouch).Name = "nCrTouch";
		((Control)nCrTouch).Size = new Size(90, 22);
		((Control)nCrTouch).TabIndex = 17;
		nCrTouch.TextAlign = (HorizontalAlignment)1;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Green;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(195, 539);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(79, 20);
		((Control)Label7).TabIndex = 1231;
		Label7.Text = "Lbr Amt";
		Label7.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrLbrAmt).BackColor = Color.Beige;
		((Control)nCrLbrAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nCrLbrAmt).ForeColor = Color.Green;
		((Control)nCrLbrAmt).Location = new Point(279, 539);
		((TextBoxBase)nCrLbrAmt).MaxLength = 10;
		((Control)nCrLbrAmt).Name = "nCrLbrAmt";
		((Control)nCrLbrAmt).Size = new Size(90, 22);
		((Control)nCrLbrAmt).TabIndex = 19;
		nCrLbrAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Maroon;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(433, 513);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(76, 20);
		((Control)Label8).TabIndex = 1233;
		Label8.Text = "Touch Dr";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDrTouch).BackColor = Color.Lavender;
		((Control)nDrTouch).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nDrTouch).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nDrTouch).Location = new Point(514, 511);
		((TextBoxBase)nDrTouch).MaxLength = 10;
		((Control)nDrTouch).Name = "nDrTouch";
		((Control)nDrTouch).Size = new Size(83, 22);
		((Control)nDrTouch).TabIndex = 21;
		nDrTouch.TextAlign = (HorizontalAlignment)1;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Maroon;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(433, 539);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(76, 20);
		((Control)Label9).TabIndex = 1235;
		Label9.Text = "Fine Dr";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDrFine).BackColor = Color.Lavender;
		((Control)nDrFine).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nDrFine).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nDrFine).Location = new Point(514, 539);
		((TextBoxBase)nDrFine).MaxLength = 10;
		((Control)nDrFine).Name = "nDrFine";
		((TextBoxBase)nDrFine).ReadOnly = true;
		((Control)nDrFine).Size = new Size(83, 22);
		((Control)nDrFine).TabIndex = 22;
		nDrFine.TextAlign = (HorizontalAlignment)1;
		((Control)PictureBox1).BackColor = Color.Transparent;
		PictureBox1.BorderStyle = (BorderStyle)1;
		PictureBox1.ImeMode = (ImeMode)0;
		((Control)PictureBox1).Location = new Point(952, 388);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(108, 87);
		PictureBox1.SizeMode = (PictureBoxSizeMode)4;
		PictureBox1.TabIndex = 1236;
		PictureBox1.TabStop = false;
		((ButtonBase)chkSameTag).BackColor = Color.Transparent;
		((Control)chkSameTag).Font = new Font("Arial", 9.75f);
		((Control)chkSameTag).ForeColor = Color.Black;
		((ButtonBase)chkSameTag).ImeMode = (ImeMode)0;
		((Control)chkSameTag).Location = new Point(566, 38);
		((Control)chkSameTag).Name = "chkSameTag";
		((Control)chkSameTag).RightToLeft = (RightToLeft)0;
		((Control)chkSameTag).Size = new Size(174, 21);
		((Control)chkSameTag).TabIndex = 2;
		((ButtonBase)chkSameTag).Text = "Modify As Same Tag";
		((ButtonBase)chkSameTag).UseVisualStyleBackColor = false;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(841, 38);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(103, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(761, 37);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(74, 20);
		((Control)Label10).TabIndex = 1238;
		Label10.Text = "Item Type";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nHmWt4).BackColor = Color.Linen;
		((Control)nHmWt4).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt4).Location = new Point(687, 361);
		((TextBoxBase)nHmWt4).MaxLength = 10;
		((Control)nHmWt4).Name = "nHmWt4";
		((Control)nHmWt4).Size = new Size(65, 23);
		((Control)nHmWt4).TabIndex = 13;
		nHmWt4.TextAlign = (HorizontalAlignment)1;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(563, 362);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(54, 20);
		((Control)Label11).TabIndex = 1250;
		Label11.Text = "HuId4";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId4).BackColor = Color.White;
		((Control)tHmId4).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId4).Location = new Point(620, 361);
		((TextBoxBase)tHmId4).MaxLength = 10;
		((Control)tHmId4).Name = "tHmId4";
		((Control)tHmId4).Size = new Size(65, 23);
		((Control)tHmId4).TabIndex = 12;
		((TextBoxBase)nHmWt3).BackColor = Color.Linen;
		((Control)nHmWt3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt3).Location = new Point(489, 361);
		((TextBoxBase)nHmWt3).MaxLength = 10;
		((Control)nHmWt3).Name = "nHmWt3";
		((Control)nHmWt3).Size = new Size(65, 23);
		((Control)nHmWt3).TabIndex = 11;
		nHmWt3.TextAlign = (HorizontalAlignment)1;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(365, 363);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(54, 20);
		((Control)Label12).TabIndex = 1249;
		Label12.Text = "HuId3";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId3).BackColor = Color.White;
		((Control)tHmId3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId3).Location = new Point(422, 361);
		((TextBoxBase)tHmId3).MaxLength = 10;
		((Control)tHmId3).Name = "tHmId3";
		((Control)tHmId3).Size = new Size(65, 23);
		((Control)tHmId3).TabIndex = 10;
		((TextBoxBase)nHmWt2).BackColor = Color.Linen;
		((Control)nHmWt2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt2).Location = new Point(293, 361);
		((TextBoxBase)nHmWt2).MaxLength = 10;
		((Control)nHmWt2).Name = "nHmWt2";
		((Control)nHmWt2).Size = new Size(65, 23);
		((Control)nHmWt2).TabIndex = 9;
		nHmWt2.TextAlign = (HorizontalAlignment)1;
		((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(169, 362);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(54, 20);
		((Control)Label13).TabIndex = 1248;
		Label13.Text = "HuId2";
		Label13.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nHmWt).BackColor = Color.Linen;
		((Control)nHmWt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt).Location = new Point(94, 361);
		((TextBoxBase)nHmWt).MaxLength = 10;
		((Control)nHmWt).Name = "nHmWt";
		((Control)nHmWt).Size = new Size(65, 23);
		((Control)nHmWt).TabIndex = 7;
		nHmWt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tHmId2).BackColor = Color.White;
		((Control)tHmId2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId2).Location = new Point(226, 361);
		((TextBoxBase)tHmId2).MaxLength = 10;
		((Control)tHmId2).Name = "tHmId2";
		((Control)tHmId2).Size = new Size(65, 23);
		((Control)tHmId2).TabIndex = 8;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(38, 361);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(52, 20);
		((Control)Label14).TabIndex = 1247;
		Label14.Text = "HuWt";
		Label14.TextAlign = (ContentAlignment)64;
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
		((Control)btnTagSet).Location = new Point(783, 485);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(36, 24);
		((Control)btnTagSet).TabIndex = 1253;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(677, 485);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(101, 24);
		((Control)cboPrintfile).TabIndex = 1251;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(609, 486);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(65, 20);
		((Control)Label15).TabIndex = 1252;
		Label15.Text = "Print file";
		Label15.TextAlign = (ContentAlignment)16;
		((Control)PictureBox2).Location = new Point(1215, 191);
		((Control)PictureBox2).Name = "PictureBox2";
		((Control)PictureBox2).Size = new Size(56, 48);
		PictureBox2.SizeMode = (PictureBoxSizeMode)3;
		PictureBox2.TabIndex = 1254;
		PictureBox2.TabStop = false;
		((Control)PictureBox2).Visible = false;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(697, 516);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(80, 20);
		((Control)Label16).TabIndex = 1256;
		Label16.Text = "Lable Skip";
		Label16.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nLableSkip).BackColor = Color.White;
		((Control)nLableSkip).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLableSkip).Location = new Point(783, 515);
		((TextBoxBase)nLableSkip).MaxLength = 15;
		((Control)nLableSkip).Name = "nLableSkip";
		((Control)nLableSkip).Size = new Size(36, 22);
		((Control)nLableSkip).TabIndex = 1255;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)nLableSkip);
		((Control)this).Controls.Add((Control)(object)PictureBox2);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)nHmWt4);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)tHmId4);
		((Control)this).Controls.Add((Control)(object)nHmWt3);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tHmId3);
		((Control)this).Controls.Add((Control)(object)nHmWt2);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)nHmWt);
		((Control)this).Controls.Add((Control)(object)tHmId2);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)chkSameTag);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nDrFine);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)nDrTouch);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)nCrLbrAmt);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nCrTouch);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nCrFine);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)nCrWt);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)nDrWt);
		((Control)this).Controls.Add((Control)(object)TEXT_RTN_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_RTN_IDTL);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_PR_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)TEXT_PR);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG_PR);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
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
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
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
		((Control)this).Name = "TR_TAG_SPLIT";
		((Form)this).Text = "Tag Split";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_PR).EndInit();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((ISupportInitialize)MSG_RTN_IDTL).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)PictureBox2).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_RTN_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		mSG_RTN_IDTL.Clear();
		mSG_RTN_IDTL.Cols = 32;
		mSG_RTN_IDTL.FixedRows = 1;
		mSG_RTN_IDTL.Rows = 2;
		mSG_RTN_IDTL.Row = 0;
		mSG_RTN_IDTL[0] = 0;
		mSG_RTN_IDTL[1] = 0;
		mSG_RTN_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_RTN_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_RTN_IDTL[0] = 3;
			mSG_RTN_IDTL[0, 0] = "Sr";
			mSG_RTN_IDTL[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_RTN_IDTL[1] = 0;
			mSG_RTN_IDTL[0, 1] = "ItCode";
			mSG_RTN_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_RTN_IDTL[2] = 0;
			mSG_RTN_IDTL[0, 2] = "ItName";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG_RTN_IDTL[3] = (int)Math.Round(875.0 * ColCon);
				mSG_RTN_IDTL[3] = 0;
				mSG_RTN_IDTL[0, 3] = "DmCode";
				mSG_RTN_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
				mSG_RTN_IDTL[4] = 0;
				mSG_RTN_IDTL[0, 4] = "DmName";
				mSG_RTN_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_RTN_IDTL[5] = 0;
				mSG_RTN_IDTL[0, 5] = "DmColor";
				mSG_RTN_IDTL[6] = (int)Math.Round(900.0 * ColCon);
				mSG_RTN_IDTL[6] = 3;
				mSG_RTN_IDTL[0, 6] = "DmSize";
				mSG_RTN_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[7] = 0;
				mSG_RTN_IDTL[0, 7] = "DmOrigin";
				mSG_RTN_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[8] = 0;
				mSG_RTN_IDTL[0, 8] = "DmRemark";
				mSG_RTN_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[9] = 0;
				mSG_RTN_IDTL[0, 9] = "DmSfNo";
			}
			else
			{
				mSG_RTN_IDTL[3] = 0;
				mSG_RTN_IDTL[0, 3] = "DmCode";
				mSG_RTN_IDTL[4] = 0;
				mSG_RTN_IDTL[0, 4] = "DmName";
				mSG_RTN_IDTL[5] = 0;
				mSG_RTN_IDTL[0, 5] = "DmColor";
				mSG_RTN_IDTL[6] = 0;
				mSG_RTN_IDTL[0, 6] = "DmSize";
				mSG_RTN_IDTL[7] = 0;
				mSG_RTN_IDTL[0, 7] = "DmOrigin";
				mSG_RTN_IDTL[8] = 0;
				mSG_RTN_IDTL[0, 8] = "DmRemark";
				mSG_RTN_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[9] = 0;
				mSG_RTN_IDTL[0, 9] = "DmSfNo";
			}
			mSG_RTN_IDTL[10] = (int)Math.Round(750.0 * ColCon);
			mSG_RTN_IDTL[10] = 7;
			mSG_RTN_IDTL[0, 10] = "Pcs";
			mSG_RTN_IDTL[11] = (int)Math.Round(750.0 * ColCon);
			mSG_RTN_IDTL[11] = 7;
			mSG_RTN_IDTL[0, 11] = "PcsWt";
			mSG_RTN_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[12] = 7;
			mSG_RTN_IDTL[0, 12] = "KrAWt";
			mSG_RTN_IDTL[13] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[13] = 7;
			mSG_RTN_IDTL[0, 13] = "KrA%";
			mSG_RTN_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[14] = 7;
			mSG_RTN_IDTL[0, 14] = "KrWt";
			mSG_RTN_IDTL[15] = (int)Math.Round(800.0 * ColCon);
			mSG_RTN_IDTL[15] = 7;
			mSG_RTN_IDTL[0, 15] = "KrLs%";
			mSG_RTN_IDTL[16] = (int)Math.Round(1000.0 * ColCon);
			mSG_RTN_IDTL[16] = 7;
			mSG_RTN_IDTL[0, 16] = "Weight";
			mSG_RTN_IDTL[17] = (int)Math.Round(850.0 * ColCon);
			mSG_RTN_IDTL[17] = 7;
			mSG_RTN_IDTL[0, 17] = "Con%";
			mSG_RTN_IDTL[18] = (int)Math.Round(850.0 * ColCon);
			mSG_RTN_IDTL[18] = 3;
			mSG_RTN_IDTL[0, 18] = "P/W";
			mSG_RTN_IDTL[19] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[19] = 7;
			mSG_RTN_IDTL[0, 19] = "Rate";
			mSG_RTN_IDTL[20] = (int)Math.Round(1000.0 * ColCon);
			mSG_RTN_IDTL[20] = 7;
			mSG_RTN_IDTL[0, 20] = "ItAmt";
			mSG_RTN_IDTL[21] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[21] = 7;
			mSG_RTN_IDTL[0, 21] = "PRate";
			mSG_RTN_IDTL[22] = (int)Math.Round(1000.0 * ColCon);
			mSG_RTN_IDTL[22] = 7;
			mSG_RTN_IDTL[0, 22] = "PAmt";
			mSG_RTN_IDTL[23] = (int)Math.Round(850.0 * ColCon);
			mSG_RTN_IDTL[23] = 7;
			mSG_RTN_IDTL[0, 23] = "LbrRate";
			mSG_RTN_IDTL[24] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[24] = 7;
			mSG_RTN_IDTL[0, 24] = "LbrAmt";
			mSG_RTN_IDTL[25] = (int)Math.Round(1050.0 * ColCon);
			mSG_RTN_IDTL[25] = 7;
			mSG_RTN_IDTL[0, 25] = "NetAmt";
			mSG_RTN_IDTL[26] = 0;
			mSG_RTN_IDTL[0, 26] = "ConWt";
			mSG_RTN_IDTL[27] = 0;
			mSG_RTN_IDTL[0, 27] = "KrConWt";
			mSG_RTN_IDTL[28] = 0;
			mSG_RTN_IDTL[0, 28] = "ItType";
			mSG_RTN_IDTL[29] = 0;
			mSG_RTN_IDTL[0, 29] = "RowSrNo";
			mSG_RTN_IDTL[30] = 0;
			mSG_RTN_IDTL[0, 30] = "OldKrWt";
			mSG_RTN_IDTL[31] = 0;
			mSG_RTN_IDTL[0, 31] = "OldGrWt";
			mSG_RTN_IDTL.Row = 1;
			mSG_RTN_IDTL.Col = 0;
			((Control)TEXT_RTN_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_RTN_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_RTN_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_RTN_IDTL[DC_Main.M] = 0;
						}
						mSG_RTN_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_RTN_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_RTN_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_RTN_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Rtn_Idtl();
			mSG_RTN_IDTL = null;
		}
	}

	private void CommPassAdd_Rtn_Idtl()
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 0] = Conversions.ToString(mSG_RTN_IDTL.Row);
		mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 29] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 57]));
		mSG_RTN_IDTL = null;
	}

	private void MSG_RTN_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		checked
		{
			if (mSG_RTN_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_RTN_IDTL).Left = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Left + (double)mSG_RTN_IDTL.CellLeft / 15.0);
				((Control)TEXT_RTN_IDTL).Top = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Top + (double)mSG_RTN_IDTL.CellTop / 15.0);
				((Control)TEXT_RTN_IDTL).Width = (int)Math.Round((double)mSG_RTN_IDTL.CellWidth / 15.0);
				((Control)TEXT_RTN_IDTL).Height = (int)Math.Round((double)mSG_RTN_IDTL.CellHeight / 15.0);
				TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
				((Control)TEXT_RTN_IDTL).Visible = true;
				((Control)TEXT_PR).Visible = false;
				((Control)TEXT_ENTRY).Visible = false;
				((Control)TEXT_IDTL).Visible = false;
				((Control)TEXT_ENTRY_2).Visible = false;
				((TextBoxBase)TEXT_RTN_IDTL).SelectAll();
				((Control)TEXT_RTN_IDTL).Focus();
				mSG_RTN_IDTL = null;
			}
		}
	}

	private void MSG_RTN_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		checked
		{
			if (mSG_RTN_IDTL[mSG_RTN_IDTL.Col] == 0)
			{
				TEXT_RTN_IDTL.Text = "";
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_RTN_IDTL[mSG_RTN_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_RTN_IDTL.Col > 1)
						{
							mSG_RTN_IDTL.Col -= 1;
						}
					}
					else if (mSG_RTN_IDTL.Col < mSG_RTN_IDTL.Cols - 1)
					{
						mSG_RTN_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_RTN_IDTL.Row == 0) | (mSG_RTN_IDTL.CellWidth <= 0)) && mSG_RTN_IDTL[mSG_RTN_IDTL.Col] != 0)
			{
				((Control)TEXT_RTN_IDTL).Left = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Left + (double)mSG_RTN_IDTL.CellLeft / 15.0);
				((Control)TEXT_RTN_IDTL).Top = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Top + (double)mSG_RTN_IDTL.CellTop / 15.0);
				((Control)TEXT_RTN_IDTL).Width = (int)Math.Round((double)mSG_RTN_IDTL.CellWidth / 15.0);
				((Control)TEXT_RTN_IDTL).Height = (int)Math.Round((double)mSG_RTN_IDTL.CellHeight / 15.0);
				((Control)TEXT_RTN_IDTL).Visible = true;
				((TextBoxBase)TEXT_RTN_IDTL).ReadOnly = false;
				switch (MSG_RTN_IDTL.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 5;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 8;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 2:
				case 4:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 50;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 15;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 6:
				case 7:
				case 8:
				case 9:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 20;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 18:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 1;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 6;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0");
					break;
				case 17:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 10;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0.000");
					break;
				case 13:
				case 15:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 10;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0.00");
					break;
				case 11:
				case 12:
				case 14:
				case 16:
				case 26:
				case 27:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 10;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0.000");
					break;
				}
				mSG_RTN_IDTL = null;
				((TextBoxBase)TEXT_RTN_IDTL).SelectAll();
			}
		}
	}

	private void MSG_RTN_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_RTN_IDTL.Row != 0 && MSG_RTN_IDTL[MSG_RTN_IDTL.Col] != 0 && ((Control)TEXT_RTN_IDTL).Visible)
		{
			AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
			switch (MSG_RTN_IDTL.Col)
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
			case 18:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = TEXT_RTN_IDTL.Text;
				break;
			case 10:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			case 17:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.000");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			case 13:
			case 15:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.00");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			case 11:
			case 12:
			case 14:
			case 16:
			case 26:
			case 27:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.000");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			}
			mSG_RTN_IDTL = null;
		}
	}

	private void TEXT_RTN_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_RTN_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Invalid comparison between Unknown and I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Invalid comparison between Unknown and I4
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Invalid comparison between Unknown and I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Invalid comparison between Unknown and I4
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = RtnIdtl.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][29])) == Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 29])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][0])) == Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 0])))
						{
							RtnIdtl.Rows.Remove(RtnIdtl.Rows[i]);
							RtnIdtl.AcceptChanges();
							break;
						}
					}
					int num2 = mSG_RTN_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Rtn_Idtl(1);
					TEXT_RTN_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_RTN_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_RTN_IDTL.Col = checked(mSG_RTN_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_RTN_IDTL.Col < 25)
				{
					mSG_RTN_IDTL.Col = checked(mSG_RTN_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_RTN_IDTL.Row > 1)
				{
					mSG_RTN_IDTL.Row = checked(mSG_RTN_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_RTN_IDTL.Row < mSG_RTN_IDTL.Rows - 1)
					{
						mSG_RTN_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_RTN_IDTL.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_RTN_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_RTN_IDTL).Visible = false;
							MSG_PR.Col += 1;
							MSG_PR_EnterCell(MSG_PR, new EventArgs());
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_RTN_IDTL.Text + "'";
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
									TEXT_RTN_IDTL.Text = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 28] = DC_Main.ColValue[4];
								}
								((Control)TEXT_RTN_IDTL).Focus();
							}
							return;
						}
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 17]) == 0.0)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						if (Operators.CompareString(EntryMode, "A", false) != 0)
						{
							break;
						}
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))
						{
							if (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 25]) == 0.0)
							{
								mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
						}
						else if (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 19]) == 0.0)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))) && Operators.CompareString(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 18], "", false) == 0)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""));
						}
						break;
					case 3:
						if (Operators.CompareString(TEXT_RTN_IDTL.Text, "", false) == 0 || mSG_RTN_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_RTN_IDTL.Text + "'";
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
									TEXT_RTN_IDTL.Text = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_RTN_IDTL).Focus();
							}
							return;
						}
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_CODE"], (object)""));
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 19]) == 0.0)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 11:
						if (mSG_RTN_IDTL[12] > 0)
						{
							if ((Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_RTN_IDTL.Text) != 0.0))
							{
								mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 10]) * Conversion.Val(TEXT_RTN_IDTL.Text)), "0.000");
							}
						}
						else if ((Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_RTN_IDTL.Text) != 0.0))
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 10]) * Conversion.Val(TEXT_RTN_IDTL.Text)), "0.000");
						}
						break;
					case 16:
						if ((Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 10]) == 0.0) & (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 16]) == 0.0))
						{
							if (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 25]) == 0.0)
							{
								mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 19] = "";
						}
						break;
					case 25:
						if (mSG_RTN_IDTL.Row == mSG_RTN_IDTL.Rows - 1)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.00");
							CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
							MsgClearIdtl = true;
							mSG_RTN_IDTL.Rows += 1;
							mSG_RTN_IDTL.Row += 1;
							MsgClearIdtl = false;
							mSG_RTN_IDTL.Col = 1;
							CommPassAdd_Rtn_Idtl();
						}
						else
						{
							mSG_RTN_IDTL.Row += 1;
							mSG_RTN_IDTL.Col = 1;
							((Control)TEXT_RTN_IDTL).Visible = true;
							((Control)TEXT_RTN_IDTL).Focus();
						}
						return;
					}
					if (mSG_RTN_IDTL.Col < mSG_RTN_IDTL.Cols - 1)
					{
						mSG_RTN_IDTL.Col += 1;
					}
					((Control)TEXT_RTN_IDTL).Visible = true;
					((Control)TEXT_RTN_IDTL).Focus();
				}
			}
		}
		mSG_RTN_IDTL = null;
	}

	private void CommPassTotal_Rtn_Idtl(int CRow)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		if (mSG_RTN_IDTL[12] > 0)
		{
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 11]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 10]) * Conversion.Val(mSG_RTN_IDTL[CRow, 11])), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 13]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 12]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 12]) * Conversion.Val(mSG_RTN_IDTL[CRow, 13]) / 100.0), "0.000");
			}
			else if (Conversion.Val(mSG_RTN_IDTL[CRow, 12]) != 0.0)
			{
				mSG_RTN_IDTL[CRow, 14] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 12]), "0.000");
			}
			if (Conversion.Val(mSG_RTN_IDTL[CRow, 15]) != 0.0)
			{
				mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 12]) * Conversion.Val(mSG_RTN_IDTL[CRow, 15]) / 100.0), "0.000");
				mSG_RTN_IDTL[CRow, 31] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 16]), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 12]) != Conversion.Val(mSG_RTN_IDTL[CRow, 30])) & (Conversion.Val(mSG_RTN_IDTL[CRow, 16]) == 0.0))
			{
				mSG_RTN_IDTL[CRow, 30] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 12]), "0.000");
				mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 14]), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 16]) != Conversion.Val(mSG_RTN_IDTL[CRow, 31])) & (Conversion.Val(mSG_RTN_IDTL[CRow, 14]) == 0.0))
			{
				mSG_RTN_IDTL[CRow, 31] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 16]), "0.000");
				mSG_RTN_IDTL[CRow, 14] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 16]), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 17]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 26] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 16]) * Conversion.Val(mSG_RTN_IDTL[CRow, 17])), "0.000");
			}
			else
			{
				mSG_RTN_IDTL[CRow, 26] = Conversions.ToString(0);
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 17]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 27] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 14]) * Conversion.Val(mSG_RTN_IDTL[CRow, 17])), "0.000");
			}
			else
			{
				mSG_RTN_IDTL[CRow, 27] = Conversions.ToString(0);
			}
		}
		else
		{
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 11]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 10]) * Conversion.Val(mSG_RTN_IDTL[CRow, 11])), "0.000");
			}
			if (Conversion.Val(mSG_RTN_IDTL[CRow, 15]) != 0.0)
			{
				mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 14]) * Conversion.Val(mSG_RTN_IDTL[CRow, 15]) / 100.0), "0.000");
				mSG_RTN_IDTL[CRow, 31] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 16]), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 14]) != Conversion.Val(mSG_RTN_IDTL[CRow, 30])) & (Conversion.Val(mSG_RTN_IDTL[CRow, 16]) == 0.0))
			{
				mSG_RTN_IDTL[CRow, 30] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 14]), "0.000");
				mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 14]), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 16]) != Conversion.Val(mSG_RTN_IDTL[CRow, 31])) & (Conversion.Val(mSG_RTN_IDTL[CRow, 14]) == 0.0))
			{
				mSG_RTN_IDTL[CRow, 31] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 16]), "0.000");
				mSG_RTN_IDTL[CRow, 14] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 16]), "0.000");
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 17]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 26] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 16]) * Conversion.Val(mSG_RTN_IDTL[CRow, 17])), "0.000");
			}
			else
			{
				mSG_RTN_IDTL[CRow, 26] = Conversions.ToString(0);
			}
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 17]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 27] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 14]) * Conversion.Val(mSG_RTN_IDTL[CRow, 17])), "0.000");
			}
			else
			{
				mSG_RTN_IDTL[CRow, 27] = Conversions.ToString(0);
			}
		}
		if (Operators.CompareString(mSG_RTN_IDTL[CRow, 18], "", false) == 0)
		{
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 16]) == 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 19]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 19]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_RTN_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 19]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 19]) * Conversion.Val(mSG_RTN_IDTL[CRow, 16])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_RTN_IDTL[CRow, 18], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_RTN_IDTL[CRow, 19])))) != 0)
		{
			mSG_RTN_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 19]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_RTN_IDTL[CRow, 19]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 19]) * Conversion.Val(mSG_RTN_IDTL[CRow, 16])), "0.00");
		}
		if (Operators.CompareString(mSG_RTN_IDTL[CRow, 18], "", false) == 0)
		{
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 14]) == 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 21]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 21]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_RTN_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 21]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 21]) * Conversion.Val(mSG_RTN_IDTL[CRow, 14])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_RTN_IDTL[CRow, 18], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_RTN_IDTL[CRow, 21])))) != 0)
		{
			mSG_RTN_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 21]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_RTN_IDTL[CRow, 21]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 21]) * Conversion.Val(mSG_RTN_IDTL[CRow, 14])), "0.00");
		}
		if (Conversion.Val(mSG_RTN_IDTL[CRow, 23]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 23]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
		}
		if (Conversion.Val(mSG_RTN_IDTL[CRow, 20]) + Conversion.Val(mSG_RTN_IDTL[CRow, 24]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 25] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 20]) + Conversion.Val(mSG_RTN_IDTL[CRow, 24])), "0.00");
		}
		checked
		{
			int num5 = mSG_RTN_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 26]);
				num4 += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 27]);
				num += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 25]);
				num2 += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 22]);
				if ((Operators.CompareString(mSG_RTN_IDTL[DC_Main.M, 1], "WX", false) == 0) & (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0))
				{
					MSG_PR[MSG_PR.Row, 54] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 16]), "0.000");
				}
				DC_Main.M++;
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 12] = Strings.Format((object)num3, "0.000");
				MSG_PR[MSG_PR.Row, 13] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 11]) - Conversion.Val(MSG_PR[MSG_PR.Row, 12])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 14] = Strings.Format((object)num4, "0.000");
				MSG_PR[MSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 11]) - Conversion.Val(MSG_PR[MSG_PR.Row, 14])), "0.000");
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 31] = Strings.Format((object)num, "0.00");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 13] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 11]) - num3), "0.000");
			}
			if (num2 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 34] = Strings.Format((object)num2, "0.00");
				MSG_PR[MSG_PR.Row, 42] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 33]) + Conversion.Val(MSG_PR[MSG_PR.Row, 34])), "0.0");
			}
			if (Operators.CompareString(mSG_RTN_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = RtnIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][29])) == Conversion.Val(mSG_RTN_IDTL[CRow, 29])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][0])) == Conversion.Val(mSG_RTN_IDTL[CRow, 0])))
					{
						flag = true;
						RtnIdtl.Rows[i][0] = mSG_RTN_IDTL[CRow, 0];
						RtnIdtl.Rows[i][1] = mSG_RTN_IDTL[CRow, 1];
						RtnIdtl.Rows[i][2] = mSG_RTN_IDTL[CRow, 2];
						RtnIdtl.Rows[i][3] = mSG_RTN_IDTL[CRow, 3];
						RtnIdtl.Rows[i][4] = mSG_RTN_IDTL[CRow, 4];
						RtnIdtl.Rows[i][5] = mSG_RTN_IDTL[CRow, 5];
						RtnIdtl.Rows[i][6] = mSG_RTN_IDTL[CRow, 6];
						RtnIdtl.Rows[i][7] = mSG_RTN_IDTL[CRow, 7];
						RtnIdtl.Rows[i][8] = mSG_RTN_IDTL[CRow, 8];
						RtnIdtl.Rows[i][9] = mSG_RTN_IDTL[CRow, 9];
						RtnIdtl.Rows[i][10] = mSG_RTN_IDTL[CRow, 10];
						RtnIdtl.Rows[i][11] = mSG_RTN_IDTL[CRow, 11];
						RtnIdtl.Rows[i][16] = mSG_RTN_IDTL[CRow, 16];
						RtnIdtl.Rows[i][12] = mSG_RTN_IDTL[CRow, 12];
						RtnIdtl.Rows[i][13] = mSG_RTN_IDTL[CRow, 13];
						RtnIdtl.Rows[i][14] = mSG_RTN_IDTL[CRow, 14];
						RtnIdtl.Rows[i][15] = mSG_RTN_IDTL[CRow, 15];
						RtnIdtl.Rows[i][17] = mSG_RTN_IDTL[CRow, 17];
						RtnIdtl.Rows[i][18] = mSG_RTN_IDTL[CRow, 18];
						RtnIdtl.Rows[i][19] = mSG_RTN_IDTL[CRow, 19];
						RtnIdtl.Rows[i][20] = mSG_RTN_IDTL[CRow, 20];
						RtnIdtl.Rows[i][21] = mSG_RTN_IDTL[CRow, 21];
						RtnIdtl.Rows[i][22] = mSG_RTN_IDTL[CRow, 22];
						RtnIdtl.Rows[i][23] = mSG_RTN_IDTL[CRow, 23];
						RtnIdtl.Rows[i][24] = mSG_RTN_IDTL[CRow, 24];
						RtnIdtl.Rows[i][25] = mSG_RTN_IDTL[CRow, 25];
						RtnIdtl.Rows[i][26] = mSG_RTN_IDTL[CRow, 26];
						RtnIdtl.Rows[i][27] = mSG_RTN_IDTL[CRow, 27];
						RtnIdtl.Rows[i][28] = mSG_RTN_IDTL[CRow, 28];
						RtnIdtl.Rows[i][29] = mSG_RTN_IDTL[CRow, 29];
						RtnIdtl.Rows[i][30] = mSG_RTN_IDTL[CRow, 30];
						RtnIdtl.Rows[i][31] = mSG_RTN_IDTL[CRow, 31];
						break;
					}
				}
				if (!flag)
				{
					Rtndr = RtnIdtl.NewRow();
					Rtndr[0] = mSG_RTN_IDTL[CRow, 0];
					Rtndr[1] = mSG_RTN_IDTL[CRow, 1];
					Rtndr[2] = mSG_RTN_IDTL[CRow, 2];
					Rtndr[3] = mSG_RTN_IDTL[CRow, 3];
					Rtndr[4] = mSG_RTN_IDTL[CRow, 4];
					Rtndr[5] = mSG_RTN_IDTL[CRow, 5];
					Rtndr[6] = mSG_RTN_IDTL[CRow, 6];
					Rtndr[7] = mSG_RTN_IDTL[CRow, 7];
					Rtndr[8] = mSG_RTN_IDTL[CRow, 8];
					Rtndr[9] = mSG_RTN_IDTL[CRow, 9];
					Rtndr[10] = mSG_RTN_IDTL[CRow, 10];
					Rtndr[11] = mSG_RTN_IDTL[CRow, 11];
					Rtndr[16] = mSG_RTN_IDTL[CRow, 16];
					Rtndr[12] = mSG_RTN_IDTL[CRow, 12];
					Rtndr[13] = mSG_RTN_IDTL[CRow, 13];
					Rtndr[14] = mSG_RTN_IDTL[CRow, 14];
					Rtndr[15] = mSG_RTN_IDTL[CRow, 15];
					Rtndr[17] = mSG_RTN_IDTL[CRow, 17];
					Rtndr[18] = mSG_RTN_IDTL[CRow, 18];
					Rtndr[19] = mSG_RTN_IDTL[CRow, 19];
					Rtndr[20] = mSG_RTN_IDTL[CRow, 20];
					Rtndr[21] = mSG_RTN_IDTL[CRow, 21];
					Rtndr[22] = mSG_RTN_IDTL[CRow, 22];
					Rtndr[23] = mSG_RTN_IDTL[CRow, 23];
					Rtndr[24] = mSG_RTN_IDTL[CRow, 24];
					Rtndr[25] = mSG_RTN_IDTL[CRow, 25];
					Rtndr[26] = mSG_RTN_IDTL[CRow, 26];
					Rtndr[27] = mSG_RTN_IDTL[CRow, 27];
					Rtndr[28] = mSG_RTN_IDTL[CRow, 28];
					Rtndr[29] = mSG_RTN_IDTL[CRow, 29];
					Rtndr[30] = mSG_RTN_IDTL[CRow, 30];
					Rtndr[31] = mSG_RTN_IDTL[CRow, 31];
					RtnIdtl.Rows.Add(Rtndr);
				}
			}
			mSG_RTN_IDTL = null;
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		MsgPrClear = true;
		mSG_PR.Clear();
		mSG_PR.Cols = 91;
		mSG_PR.FixedRows = 1;
		mSG_PR.Rows = 2;
		mSG_PR.Row = 1;
		mSG_PR[0] = 0;
		mSG_PR[1] = 0;
		mSG_PR.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_PR[0] = (int)Math.Round(500.0 * ColCon);
			mSG_PR[0] = 3;
			mSG_PR[0, 0] = "Sr";
			mSG_PR[1] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[1] = 0;
			mSG_PR[0, 1] = "ItCode";
			mSG_PR[2] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "TagNo";
			mSG_PR[3] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "Counter";
			mSG_PR[4] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Design";
			mSG_PR[5] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[5] = 0;
			mSG_PR[0, 5] = "Color";
			mSG_PR[6] = (int)Math.Round(700.0 * ColCon);
			mSG_PR[6] = 0;
			mSG_PR[0, 6] = "Size";
			mSG_PR[7] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[7] = 0;
			mSG_PR[0, 7] = "HuId";
			mSG_PR[8] = (int)Math.Round(450.0 * ColCon);
			mSG_PR[8] = 3;
			mSG_PR[0, 8] = "+/-";
			mSG_PR[9] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "BagWt";
			mSG_PR[10] = (int)Math.Round(700.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "Pcs";
			mSG_PR[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "GrWt";
			mSG_PR[12] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "LsWt";
			mSG_PR[13] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[13] = 7;
			mSG_PR[0, 13] = "NetWt";
			mSG_PR[14] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[14] = 7;
			mSG_PR[0, 14] = "KrOthWt";
			mSG_PR[15] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "KrNwt";
			mSG_PR[16] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "KrGht%";
			mSG_PR[17] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "KrGht";
			mSG_PR[18] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[18] = 7;
			mSG_PR[0, 18] = "KrTouch";
			mSG_PR[19] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "KrWst%";
			mSG_PR[20] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[20] = 7;
			mSG_PR[0, 20] = "KrFine";
			mSG_PR[22] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[22] = 7;
			mSG_PR[0, 22] = "Ght%";
			mSG_PR[23] = (int)Math.Round(850.0 * ColCon);
			mSG_PR[23] = 7;
			mSG_PR[0, 23] = "GhtWt";
			mSG_PR[24] = (int)Math.Round(850.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "Touch";
			mSG_PR[25] = (int)Math.Round(850.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "West%";
			mSG_PR[26] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "Fine";
			mSG_PR[21] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[21] = 3;
			mSG_PR[0, 21] = "LCode";
			mSG_PR[27] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "Lbr%";
			mSG_PR[28] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[28] = 3;
			mSG_PR[0, 28] = "LType";
			mSG_PR[29] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[29] = 7;
			mSG_PR[0, 29] = "LbrRate";
			mSG_PR[30] = (int)Math.Round(950.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "LbrAmt";
			mSG_PR[31] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "OthAmt";
			mSG_PR[32] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[32] = 7;
			mSG_PR[0, 32] = "KrLRate";
			mSG_PR[33] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[33] = 7;
			mSG_PR[0, 33] = "KrLAmt";
			mSG_PR[34] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[34] = 7;
			mSG_PR[0, 34] = "KrOthAmt";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
			{
				mSG_PR[35] = (int)Math.Round(700.0 * ColCon);
				mSG_PR[35] = 3;
				mSG_PR[0, 35] = "SlType";
				mSG_PR[36] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[36] = 7;
				mSG_PR[0, 36] = "OthRate";
				mSG_PR[37] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[37] = 7;
				mSG_PR[0, 37] = "OthFine";
				mSG_PR[38] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[38] = 7;
				mSG_PR[0, 38] = "TotFine";
				mSG_PR[39] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[39] = 7;
				mSG_PR[0, 39] = "GwtTouch";
			}
			else
			{
				mSG_PR[35] = 0;
				mSG_PR[36] = 0;
				mSG_PR[37] = 0;
				mSG_PR[38] = 0;
				mSG_PR[39] = 0;
			}
			mSG_PR[42] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[42] = 7;
			mSG_PR[0, 42] = "PrCost";
			mSG_PR[40] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[40] = 7;
			mSG_PR[0, 40] = "ItRate";
			mSG_PR[41] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[41] = 7;
			mSG_PR[0, 41] = "ItAmt";
			mSG_PR[43] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[43] = 7;
			mSG_PR[0, 43] = "TagCost";
			mSG_PR[44] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[44] = 7;
			mSG_PR[0, 44] = "Margin";
			mSG_PR[45] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[45] = 7;
			mSG_PR[0, 45] = "Mrp";
			mSG_PR[46] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[46] = 3;
			mSG_PR[0, 46] = "Image";
			mSG_PR[47] = (int)Math.Round(2200.0 * ColCon);
			mSG_PR[47] = 0;
			mSG_PR[0, 47] = "Remark";
			mSG_PR[48] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[48] = 7;
			mSG_PR[0, 48] = "KrCod";
			if (DC_Main.MsTagVchSrnoUpdate)
			{
				mSG_PR[62] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR[62] = 3;
				mSG_PR[0, 62] = "TagId";
			}
			else
			{
				mSG_PR[62] = 0;
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) != 0)
			{
				mSG_PR[49] = 0;
				mSG_PR[50] = 0;
				mSG_PR[51] = 0;
				mSG_PR[52] = 0;
				mSG_PR[53] = 0;
				mSG_PR[54] = 0;
				mSG_PR[55] = 0;
			}
			mSG_PR[56] = 0;
			mSG_PR[57] = 0;
			mSG_PR[58] = 0;
			mSG_PR[59] = 0;
			mSG_PR[60] = 0;
			mSG_PR[61] = 0;
			mSG_PR[63] = 0;
			mSG_PR[64] = 0;
			mSG_PR[65] = 0;
			mSG_PR[66] = 0;
			mSG_PR[67] = 0;
			mSG_PR[68] = 0;
			mSG_PR[69] = 0;
			mSG_PR[70] = 0;
			mSG_PR[71] = 0;
			mSG_PR[72] = 0;
			mSG_PR[73] = 0;
			mSG_PR[74] = 0;
			mSG_PR[75] = 0;
			mSG_PR[76] = 0;
			mSG_PR[77] = 0;
			mSG_PR[78] = 0;
			mSG_PR[79] = 0;
			mSG_PR[80] = 0;
			mSG_PR[81] = 0;
			mSG_PR[82] = 0;
			mSG_PR[83] = 0;
			mSG_PR[84] = 0;
			mSG_PR[85] = 0;
			mSG_PR[86] = 0;
			mSG_PR[87] = 0;
			mSG_PR[88] = 0;
			mSG_PR[89] = 0;
			mSG_PR[90] = 0;
			mSG_PR.Row = 1;
			mSG_PR.Col = 1;
			((Control)TEXT_PR).Visible = false;
			MsgPrClear = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG_PR.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_PR[DC_Main.M] = 0;
						}
						mSG_PR[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
			{
				mSG_PR[14] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[14] = 7;
				mSG_PR[0, 14] = "KrOthWt";
				mSG_PR[15] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[15] = 7;
				mSG_PR[0, 15] = "KrNwt";
				mSG_PR[18] = (int)Math.Round(900.0 * ColCon);
				mSG_PR[18] = 7;
				mSG_PR[0, 18] = "KrTouch";
				mSG_PR[19] = (int)Math.Round(900.0 * ColCon);
				mSG_PR[19] = 7;
				mSG_PR[0, 19] = "KrWst%";
				mSG_PR[20] = (int)Math.Round(900.0 * ColCon);
				mSG_PR[20] = 7;
				mSG_PR[0, 20] = "KrFine";
				mSG_PR[49] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[49] = 7;
				mSG_PR[0, 49] = "JdtWt";
				mSG_PR[50] = (int)Math.Round(900.0 * ColCon);
				mSG_PR[50] = 7;
				mSG_PR[0, 50] = "JGhatWt";
				mSG_PR[51] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[51] = 7;
				mSG_PR[0, 51] = "Kundan";
				mSG_PR[52] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[52] = 7;
				mSG_PR[0, 52] = "KndTch%";
				mSG_PR[53] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[53] = 7;
				mSG_PR[0, 53] = "KndNwt";
				mSG_PR[54] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[54] = 7;
				mSG_PR[0, 54] = "Wax";
				mSG_PR[55] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[55] = 7;
				mSG_PR[0, 55] = "KrWax";
			}
			mSG_PR[0] = (int)Math.Round(325.0 * ColCon);
			mSG_PR[1] = (int)Math.Round(300.0 * ColCon);
			mSG_PR.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Pr();
			mSG_PR = null;
			AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
			mSG_PR_TOT.Cols = MSG_PR.Cols;
			int num2 = MSG_PR.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				mSG_PR_TOT[DC_Main.M] = MSG_PR[DC_Main.M];
				mSG_PR_TOT[DC_Main.M] = MSG_PR[DC_Main.M];
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)
			{
				MSG_PR_TOT.ScrollBars = (ScrollBarsSettings)0;
			}
			MSG_PR_TOT_FILL();
			mSG_PR_TOT = null;
		}
	}

	private void CommPassAdd_Pr()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR[mSG_PR.Row, 0] = Conversions.ToString(mSG_PR.Row);
		mSG_PR[mSG_PR.Row, 28] = DC_Main.MsLbrType;
		mSG_PR[mSG_PR.Row, 76] = "N";
		mSG_PR[mSG_PR.Row, 89] = "N";
		mSG_PR[mSG_PR.Row, 64] = "A";
		mSG_PR[mSG_PR.Row, 84] = "A";
		mSG_PR[mSG_PR.Row, 8] = "+";
		mSG_PR[mSG_PR.Row, 10] = Conversions.ToString(1);
		mSG_PR[mSG_PR.Row, 90] = "N";
		mSG_PR[mSG_PR.Row, 35] = "N";
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG_PR[mSG_PR.Row, 57] = Conversions.ToString(MSG_PR.Row);
		}
		else
		{
			mSG_PR[mSG_PR.Row, 57] = Conversions.ToString(Conversion.Val(mSG_PR[checked(mSG_PR.Row - 1), 57]) + 1.0);
		}
		mSG_PR[mSG_PR.Row, 62] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm");
		mSG_PR = null;
	}

	private void TEXT_PR_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_PR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Invalid comparison between Unknown and I4
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Invalid comparison between Unknown and I4
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Invalid comparison between Unknown and I4
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Invalid comparison between Unknown and I4
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Invalid comparison between Unknown and I4
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG_PR = MSG_PR;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				List<DataRow> list = new List<DataRow>();
				checked
				{
					int num = RtnIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[DC_Main.M][29])) == Conversion.Val(mSG_PR[mSG_PR.Row, 57]))
						{
							list.Add(RtnIdtl.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						RtnIdtl.Rows.Remove(item);
						RtnIdtl.AcceptChanges();
					}
					int num2 = (int)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 0]));
					int num3 = mSG_PR.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num3)
					{
						mSG_PR[mSG_PR.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_PR.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG_PR.Col == 2 && ((Operators.CompareString(DC_Main.SSRegSrNo, "VK188NESD", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0)))
			{
				((TextBoxBase)TEXT_PR).ReadOnly = false;
			}
			if (mSG_PR.Col == 48)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_SHORT <> '' ORDER BY AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
				}
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
						TEXT_PR.Text = DC_Main.ColValue[1];
						mSG_PR[mSG_PR.Row, 48] = DC_Main.ColValue[1];
					}
					((Control)TEXT_PR).Focus();
				}
				return;
			}
			if (mSG_PR.Col == 4)
			{
				DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,B.PR_NAME As ProductL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[11];
				DC_Main.ColWidth[0] = 120.0;
				DC_Main.ColWidth[1] = 120.0;
				DC_Main.ColWidth[2] = 150.0;
				DC_Main.ColWidth[3] = 110.0;
				DC_Main.ColWidth[4] = 100.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.ColWidth[6] = 100.0;
				DC_Main.ColWidth[7] = 100.0;
				DC_Main.ColWidth[8] = 100.0;
				DC_Main.ColWidth[9] = 0.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					TEXT_PR.Text = DC_Main.ColValue[0];
					mSG_PR[mSG_PR.Row, 4] = DC_Main.ColValue[0];
					mSG_PR[mSG_PR.Row, 6] = DC_Main.ColValue[3];
					if (Operators.CompareString(EntryMode, "E", false) != 0)
					{
						if (Conversion.Val(DC_Main.ColValue[5]) != 0.0)
						{
							mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[6]) != 0.0)
						{
							mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
						{
							mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
						{
							mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
						}
					}
					mSG_PR[mSG_PR.Row, 90] = DC_Main.ColValue[9];
					RtnOldRow = 0;
					MSG_PR_RowColChange(MSG_PR, new EventArgs());
				}
				((Control)TEXT_PR).Focus();
				return;
			}
			TEXT_PR.Text = "";
			mSG_PR[mSG_PR.Row, 4] = "";
			mSG_PR[mSG_PR.Row, 90] = "N";
		}
		else
		{
			if ((int)keyCode == 37)
			{
				checked
				{
					if (mSG_PR.Col > 1)
					{
						Msgleft = true;
						mSG_PR.Col -= 1;
					}
					((TextBoxBase)TEXT_PR).SelectionLength = Strings.Len(TEXT_PR.Text) + 1;
					return;
				}
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR.Col < 55)
				{
					mSG_PR.Col = checked(mSG_PR.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_PR.Row > 1)
				{
					mSG_PR.Row = checked(mSG_PR.Row - 1);
				}
				RtnOldRow = 0;
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_PR.Row < mSG_PR.Rows - 1)
					{
						mSG_PR.Row += 1;
					}
					RtnOldRow = 0;
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_PR.Col)
					{
					case 1:
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.IT_NAME";
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
									TEXT_PR.Text = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 1] = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 63] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 59] = DC_Main.ColValue[4];
									mSG_PR[mSG_PR.Row, 60] = DC_Main.ColValue[5];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 60], mSG_PR[mSG_PR.Row, 65], false) != 0) | (Operators.CompareString(mSG_PR[mSG_PR.Row, 61], mSG_PR[mSG_PR.Row, 66], false) != 0))
						{
							mSG_PR[mSG_PR.Row, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[mSG_PR.Row, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG_PR[mSG_PR.Row, 2] = "";
							mSG_PR[mSG_PR.Row, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						RtnOldRow = 0;
						break;
					case 3:
						if (Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_PR.Text + "'";
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
									TEXT_PR.Text = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[1];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 21:
					{
						if (Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						string text = mSG_PR[mSG_PR.Row, 21];
						DC_Main.RsQry = "Select * From LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LBR_CODE = '" + TEXT_PR.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						string text2;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT LBR_CODE As LbrCodeL,LBR_CATG as CategoryL,LBR_VAL As LbrValueR  FROM LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LBR_CATG,LBR_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 90.0;
							DC_Main.ColWidth[1] = 250.0;
							DC_Main.ColWidth[2] = 110.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_PR.Text = DC_Main.ColValue[0];
									text2 = Strings.Mid(DC_Main.ColValue[0], 1, 2);
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						if (Operators.CompareString(text, TEXT_PR.Text, false) != 0)
						{
							mSG_PR[mSG_PR.Row, 29] = "";
							mSG_PR[mSG_PR.Row, 30] = "";
							mSG_PR[mSG_PR.Row, 27] = "";
							mSG_PR[mSG_PR.Row, 22] = "";
							mSG_PR[mSG_PR.Row, 25] = "";
							mSG_PR[mSG_PR.Row, 45] = "";
						}
						text2 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG_PR[mSG_PR.Row, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						switch (text2)
						{
						case "01":
							mSG_PR[mSG_PR.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG_PR[mSG_PR.Row, 27] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG_PR[mSG_PR.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "04":
							mSG_PR[mSG_PR.Row, 25] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "05":
							mSG_PR[mSG_PR.Row, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG_PR[mSG_PR.Row, 28] = "K";
							mSG_PR[mSG_PR.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG_PR[mSG_PR.Row, 45] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal_Pr(mSG_PR.Row);
						break;
					}
					case 7:
						if (Operators.CompareString(TEXT_PR.Text, "", false) != 0)
						{
							mSG_PR[mSG_PR.Row, 7] = TEXT_PR.Text;
							((Control)nHmWt).Focus();
							return;
						}
						break;
					case 8:
						if ((Operators.CompareString(TEXT_PR.Text, "+", false) != 0) & (Operators.CompareString(TEXT_PR.Text, "-", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						break;
					case 11:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 58], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						mSG_PR[mSG_PR.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
						CommPassTotal_Pr(mSG_PR.Row);
						((Control)TEXT_PR).Visible = false;
						MSG_RTN_IDTL.Row = 1;
						MSG_RTN_IDTL.Col = 1;
						MSG_RTN_IDTL_EnterCell(MSG_RTN_IDTL, new EventArgs());
						((Control)TEXT_RTN_IDTL).Focus();
						((TextBoxBase)TEXT_RTN_IDTL).SelectAll();
						return;
					case 48:
					case 55:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							if (mSG_PR.Col == 48)
							{
								mSG_PR[mSG_PR.Row, 48] = TEXT_PR.Text;
							}
							if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG_PR[mSG_PR.Row, 2] + "','" + mSG_PR[mSG_PR.Row, 62] + "','" + mSG_PR[mSG_PR.Row, 60] + "','" + mSG_PR[mSG_PR.Row, 61] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG_PR[mSG_PR.Row, 2] + "','" + mSG_PR[mSG_PR.Row, 62] + "','" + mSG_PR[mSG_PR.Row, 60] + "','" + mSG_PR[mSG_PR.Row, 61] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							MsgPrClear = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							MsgPrClear = false;
							mSG_PR.Col = 1;
							CommPassAdd_Pr();
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
						}
						else
						{
							mSG_PR.Row += 1;
							mSG_PR.Col = 1;
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
						}
						return;
					}
					if (mSG_PR.Col < mSG_PR.Cols - 1)
					{
						mSG_PR.Col += 1;
					}
					((Control)TEXT_PR).Visible = true;
					((Control)TEXT_PR).Focus();
				}
			}
		}
		mSG_PR = null;
	}

	private void MSG_PR_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		RtnOldRow = 0;
		checked
		{
			if (mSG_PR.CellWidth >= 0)
			{
				((Control)TEXT_PR).Left = (int)Math.Round((double)((Control)mSG_PR).Left + (double)mSG_PR.CellLeft / 15.0);
				((Control)TEXT_PR).Top = (int)Math.Round((double)((Control)mSG_PR).Top + (double)mSG_PR.CellTop / 15.0);
				((Control)TEXT_PR).Width = (int)Math.Round((double)mSG_PR.CellWidth / 15.0);
				((Control)TEXT_PR).Height = (int)Math.Round((double)mSG_PR.CellHeight / 15.0);
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				if (RtnOldRow != MSG_PR.Row)
				{
					RtnOldRow = 0;
				}
				((Control)TEXT_ENTRY).Visible = false;
				((Control)TEXT_IDTL).Visible = false;
				((Control)TEXT_RTN_IDTL).Visible = false;
				((Control)TEXT_PR).Visible = true;
				((TextBoxBase)TEXT_PR).SelectAll();
				((Control)TEXT_PR).Focus();
				mSG_PR = null;
			}
		}
	}

	private void MSG_PR_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		checked
		{
			if (mSG_PR[mSG_PR.Col] == 0)
			{
				TEXT_PR.Text = "";
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = "";
				DC_Main.M = 1;
				while (mSG_PR[mSG_PR.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG_PR.Col > 1)
						{
							mSG_PR.Col -= 1;
						}
					}
					else if (mSG_PR.Col < mSG_PR.Cols - 1)
					{
						mSG_PR.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (((mSG_PR.Row == 0) | (mSG_PR.CellWidth <= 0)) || mSG_PR[mSG_PR.Col] == 0)
			{
				return;
			}
			((Control)TEXT_PR).Left = (int)Math.Round((double)((Control)mSG_PR).Left + (double)mSG_PR.CellLeft / 15.0);
			((Control)TEXT_PR).Top = (int)Math.Round((double)((Control)mSG_PR).Top + (double)mSG_PR.CellTop / 15.0);
			((Control)TEXT_PR).Width = (int)Math.Round((double)mSG_PR.CellWidth / 15.0);
			((Control)TEXT_PR).Height = (int)Math.Round((double)mSG_PR.CellHeight / 15.0);
			((Control)TEXT_PR).Visible = true;
			((TextBoxBase)TEXT_PR).ReadOnly = false;
			switch (MSG_PR.Col)
			{
			case 0:
			case 1:
			case 48:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 8:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 47:
			case 62:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK188NESD", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0))
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 4:
			case 6:
				((TextBoxBase)TEXT_PR).MaxLength = 20;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 21:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 7:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 28:
			case 35:
			case 46:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 25:
			case 27:
			case 29:
			case 30:
			case 45:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				if (Operators.CompareString(mSG_PR[mSG_PR.Row, 21], "", false) != 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 10:
				((TextBoxBase)TEXT_PR).MaxLength = 6;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				break;
			case 18:
			case 19:
			case 22:
			case 24:
			case 44:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 31:
			case 32:
			case 33:
			case 34:
			case 40:
			case 41:
			case 42:
			case 43:
			case 52:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 9:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 20:
			case 23:
			case 26:
			case 36:
			case 39:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 37:
			case 38:
			case 49:
			case 50:
			case 51:
			case 53:
			case 54:
			case 55:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				((TextBoxBase)TEXT_PR).ReadOnly = true;
				break;
			}
			mSG_PR = null;
			((TextBoxBase)TEXT_PR).SelectAll();
		}
	}

	private void MSG_PR_LeaveCell(object sender, EventArgs e)
	{
		if (MsgPrClear || MSG_PR.Row == 0 || MSG_PR[MSG_PR.Col] == 0 || !((Control)TEXT_PR).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		switch (MSG_PR.Col)
		{
		case 1:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			if (chkSameTag.Checked)
			{
				if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 2], "", false) == 0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0) & (mSG_PR.Row > 1))
				{
					NewTagNo(mSG_PR.Row);
				}
			}
			else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 2], "", false) == 0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0))
			{
				NewTagNo(mSG_PR.Row);
			}
			break;
		case 0:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 21:
		case 28:
		case 35:
		case 46:
		case 47:
		case 48:
		case 62:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			break;
		case 10:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
			break;
		case 18:
		case 19:
		case 22:
		case 24:
		case 25:
		case 27:
		case 44:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 36:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 45:
		case 52:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 12:
		case 14:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 9:
		case 11:
		case 13:
		case 15:
		case 16:
		case 17:
		case 20:
		case 23:
		case 26:
		case 37:
		case 38:
		case 49:
		case 50:
		case 51:
		case 53:
		case 54:
		case 55:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		}
		mSG_PR = null;
	}

	private void NewTagNo(int Y)
	{
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			RepitTagNo(Y);
			return;
		}
		if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
		{
			string tagPrefix = "";
			if (Operators.CompareString(Module_Save.MsRendomWithPrCode, "Y", false) == 0)
			{
				tagPrefix = MSG_PR[Y, 61] + MSG_PR[Y, 60];
			}
			string text = Module_Save.RendomTagGen(DC_Main.MCo_Book, tagPrefix);
			if (Operators.CompareString(text, "", false) != 0)
			{
				MSG_PR[Y, 2] = text;
				TEXT_PR.Text = text;
			}
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Operators.CompareString(DC_Main.MsLastYearTagSires, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG_PR[Y, 61] + "'  AND TAG_TYPE = '" + mSG_PR[Y, 60] + "'  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=9  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG_PR[Y, 61] + "' AND LEN(A.TAG_NO) > 6 AND LEN(A.TAG_NO) < =9 AND B.TAG_TYPE = '" + mSG_PR[Y, 60] + "' ) AS X GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
			}
			else
			{
				DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG_PR[Y, 61] + "'  AND TAG_TYPE = '" + mSG_PR[Y, 60] + "'  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=10  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG_PR[Y, 61] + "' AND LEN(A.TAG_NO) > 6 AND LEN(A.TAG_NO) < =9 AND B.TAG_TYPE = '" + mSG_PR[Y, 60] + "' ) AS X GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
			}
		}
		else if (Operators.CompareString(DC_Main.MCo_Type, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG_PR[Y, 61] + "'  AND B.TAG_TYPE = '" + mSG_PR[Y, 60] + "' ORDER BY A.TAG_NO DESC";
		}
		else if (Operators.CompareString(DC_Main.MsLastYearTagSires, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT MAX(TAG_SRNO) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG_PR[Y, 61] + "'  AND TAG_TYPE = '" + mSG_PR[Y, 60] + "'   UNION ALL SELECT  MAX(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO))) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG_PR[Y, 61] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG_PR[Y, 60] + "' ";
		}
		else
		{
			DC_Main.RsQry = "SELECT TOP 2 TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG_PR[Y, 61] + "'  AND TAG_TYPE = '" + mSG_PR[Y, 60] + "' ORDER BY TAG_SRNO DESC";
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				CurTagNo = "0001";
			}
			else
			{
				CurTagNo = "00001";
			}
		}
		else if (Operators.CompareString(DC_Main.MsLastYearTagSires, "Y", false) == 0)
		{
			if (dataTable.Rows.Count > 1)
			{
				if (Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) > Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[1]["TAG_SRNO"], (object)"")))
				{
					CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "0000");
				}
				else
				{
					CurTagNo = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[1]["TAG_SRNO"], (object)"")) + 1.0), "0000");
				}
			}
			else
			{
				CurTagNo = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "0000");
			}
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				CurTagNo = Strings.Format((object)Conversion.Val(CurTagNo), "0000");
			}
			else
			{
				CurTagNo = Strings.Format((object)Conversion.Val(CurTagNo), "00000");
			}
		}
		else if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "0000");
		}
		else
		{
			CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "00000");
		}
		checked
		{
			int num = mSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG_PR[Y, 2], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 61], mSG_PR[Y, 61], false) == 0) & (Operators.CompareString(mSG_PR[DC_Main.i, 60], mSG_PR[Y, 60], false) == 0) & (Conversion.Val(mSG_PR[DC_Main.i, 56]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 56]) + 1.0)) > Conversion.Val(CurTagNo))
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 56]) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 56]) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
			mSG_PR[mSG_PR.Row, 56] = CurTagNo;
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG_PR[mSG_PR.Row, 2] = mSG_PR[Y, 61] + mSG_PR[Y, 60] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
			}
			else
			{
				mSG_PR[mSG_PR.Row, 2] = mSG_PR[Y, 61] + mSG_PR[Y, 60] + CurTagNo;
			}
			mSG_PR = null;
			dataTable.Clear();
		}
	}

	private void RepitTagNo(int Y)
	{
		checked
		{
			DataTable dataTable;
			DataTable dataTable2;
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,4) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + MSG_PR[Y, 61] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG_PR[Y, 60] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "0001";
					int num = 1;
					int num2 = 0;
					double num3 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO ,'',0 FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 60] + "' AND  PR_CODE = '" + MSG_PR[Y, 61] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["TAG_NO"], (object)"")), 4, 4));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "0000");
							break;
						}
						DC_Main.X++;
					}
					if (num2 >= num)
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "0000");
					}
				}
				else
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["SrNo"]);
					double a = DC_Main.Fnv(ref Value);
					dataRow["SrNo"] = RuntimeHelpers.GetObjectValue(Value);
					int num = (int)Math.Round(a);
					int num2 = 0;
					CurRptTagNo = Strings.Format((object)(num + 1), "0000");
					double num3 = 0.0;
					DC_Main.RsQry = "Select A.TAG_NO From MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.TAG_TYPE = '" + MSG_PR[Y, 60] + "' AND  B.PR_CODE = '" + MSG_PR[Y, 61] + "' AND B.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7   GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 59] + "' AND  PR_CODE = '" + MSG_PR[Y, 61] + "' GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num4 = 0.0;
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.X]["TAG_NO"]), 4, 7));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "0000");
							num4 = Conversions.ToDouble(CurRptTagNo);
							break;
						}
						DC_Main.X++;
					}
					if (num4 != Conversion.Val((object)num2))
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "0000");
					}
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,5) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + MSG_PR[Y, 61] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG_PR[Y, 60] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "00001";
					int num = 1;
					int num2 = 0;
					double num3 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO ,'',0 FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 60] + "' AND  PR_CODE = '" + MSG_PR[Y, 61] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["TAG_NO"], (object)"")), 4, 5));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "00000");
							break;
						}
						DC_Main.X++;
					}
					if (num2 >= num)
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "00000");
					}
				}
				else
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["SrNo"]);
					double a2 = DC_Main.Fnv(ref Value);
					dataRow["SrNo"] = RuntimeHelpers.GetObjectValue(Value);
					int num = (int)Math.Round(a2);
					int num2 = 0;
					CurRptTagNo = Strings.Format((object)(num + 1), "00000");
					double num3 = 0.0;
					DC_Main.RsQry = "Select A.TAG_NO From MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.TAG_TYPE = '" + MSG_PR[Y, 60] + "' AND  B.PR_CODE = '" + MSG_PR[Y, 61] + "' AND B.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8   GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 59] + "' AND  PR_CODE = '" + MSG_PR[Y, 61] + "' GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num5 = 0.0;
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.X]["TAG_NO"]), 4, 5));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "00000");
							num5 = Conversions.ToDouble(CurRptTagNo);
							break;
						}
						DC_Main.X++;
					}
					if (num5 != Conversion.Val((object)num2))
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "00000");
					}
				}
			}
			MSG_PR[Y, 56] = Conversions.ToString(Conversion.Val(CurRptTagNo));
			MSG_PR[Y, 2] = MSG_PR[Y, 61] + MSG_PR[Y, 60] + CurRptTagNo;
			TEXT_ENTRY.Text = MSG_PR[Y, 2];
			dataTable.Clear();
			dataTable.Columns.Clear();
			dataTable2.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != Conversion.Val(mSG_PR[mSG_PR.Row, 67]))
		{
			mSG_PR[mSG_PR.Row, 67] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 11]), "0.000");
			mSG_PR[mSG_PR.Row, 13] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) - Conversion.Val(mSG_PR[mSG_PR.Row, 12])), "0.000");
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 13] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) - Conversion.Val(mSG_PR[mSG_PR.Row, 12])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != Conversion.Val(mSG_PR[mSG_PR.Row, 68]))
		{
			mSG_PR[mSG_PR.Row, 68] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 13]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 13]), "0.000");
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 13]) * Conversion.Val(mSG_PR[mSG_PR.Row, 22]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != Conversion.Val(mSG_PR[mSG_PR.Row, 71]))
		{
			mSG_PR[mSG_PR.Row, 71] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 24]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != Conversion.Val(mSG_PR[mSG_PR.Row, 72]))
		{
			mSG_PR[mSG_PR.Row, 72] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 25]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 26]) == 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25])) / 100.0), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])), "0.000");
		}
		else if (mSG_PR[14] == 0)
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 13]), "0.000");
		}
		else
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != Conversion.Val(mSG_PR[mSG_PR.Row, 73]))
		{
			mSG_PR[mSG_PR.Row, 73] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != Conversion.Val(mSG_PR[mSG_PR.Row, 74]))
		{
			mSG_PR[mSG_PR.Row, 74] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 18]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != Conversion.Val(mSG_PR[mSG_PR.Row, 75]))
		{
			mSG_PR[mSG_PR.Row, 75] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 19]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 20]) == 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19])) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != Conversion.Val(mSG_PR[mSG_PR.Row, 88]))
		{
			mSG_PR[mSG_PR.Row, 88] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 17]), "0.000");
			mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19])) / 100.0), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 40]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0))
		{
			switch (mSG_PR[mSG_PR.Row, 58])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 41] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 40]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 41] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 40]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 41] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 40]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 41] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) * Conversion.Val(mSG_PR[mSG_PR.Row, 40]), 0), "0.00");
				break;
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) != 0.0)
		{
			switch (mSG_PR[mSG_PR.Row, 28])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 13]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				break;
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 32]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
		{
			switch (mSG_PR[mSG_PR.Row, 28])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 0), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 0), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 0), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 32]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 11]) * Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 0), "0.00");
				break;
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM310NEPK", false) != 0 && Conversion.Val(mSG_PR[mSG_PR.Row, 33]) + Conversion.Val(mSG_PR[mSG_PR.Row, 34]) + Conversion.Val(mSG_PR[mSG_PR.Row, 41]) != 0.0)
		{
			mSG_PR[mSG_PR.Row, 42] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 33]) + Conversion.Val(mSG_PR[mSG_PR.Row, 34]) + Conversion.Val(mSG_PR[mSG_PR.Row, 41])), "0.00");
			mSG_PR[mSG_PR.Row, 43] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 33]) + Conversion.Val(mSG_PR[mSG_PR.Row, 34]) + Conversion.Val(mSG_PR[mSG_PR.Row, 41])), "0.00");
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) == 0))
		{
			mSG_PR[mSG_PR.Row, 43] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 41]) + Conversion.Val(mSG_PR[mSG_PR.Row, 30]) + Conversion.Val(mSG_PR[mSG_PR.Row, 31])), "0.0");
			mSG_PR[mSG_PR.Row, 42] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 41]) + Conversion.Val(mSG_PR[mSG_PR.Row, 30]) + Conversion.Val(mSG_PR[mSG_PR.Row, 31])), "0.0");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 43]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 44]) != Conversion.Val(mSG_PR[mSG_PR.Row, 85])))
		{
			mSG_PR[mSG_PR.Row, 85] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 44]), "0.00");
			mSG_PR[mSG_PR.Row, 45] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 43]) * (1.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 44]) / 100.0)), "0.00");
		}
		if (((mSG_PR[42] == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 42]) != 0.0)) && Conversion.Val(mSG_PR[mSG_PR.Row, 44]) != Conversion.Val(mSG_PR[mSG_PR.Row, 85]))
		{
			mSG_PR[mSG_PR.Row, 85] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 44]), "0.00");
			mSG_PR[mSG_PR.Row, 45] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 42]) * (1.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 44]) / 100.0)), "0.00");
		}
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0 && Operators.CompareString(mSG_PR[mSG_PR.Row, 59], "G", false) == 0)
			{
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0)
				{
					if (Conversion.Val(mSG_PR[mSG_PR.Row, 36]) == 0.0)
					{
						mSG_PR[mSG_PR.Row, 37] = "";
					}
					else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 36]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 34]) / Conversion.Val(mSG_PR[mSG_PR.Row, 36]), 3), "0.000");
					}
					mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 20]) + Conversion.Val(mSG_PR[mSG_PR.Row, 37])), "0.000");
					if (Operators.CompareString(mSG_PR[mSG_PR.Row, 35], "G", false) == 0)
					{
						mSG_PR[mSG_PR.Row, 39] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.00");
					}
					else
					{
						mSG_PR[mSG_PR.Row, 39] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 13])), "0.00");
					}
				}
				else if (Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != 0.0)
				{
					mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 20]) + Conversion.Val(mSG_PR[mSG_PR.Row, 37])), "0.000");
					if (Operators.CompareString(mSG_PR[mSG_PR.Row, 35], "G", false) == 0)
					{
						mSG_PR[mSG_PR.Row, 39] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.00");
					}
					else
					{
						mSG_PR[mSG_PR.Row, 39] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 13])), "0.00");
					}
				}
				double num = 0.0;
				string text = "";
				num = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 39]) + Conversion.Val(mSG_PR[mSG_PR.Row, 44])), "0.00"));
				string text2 = Strings.Format((object)num, "0.00");
				int num2 = Strings.Len(text2);
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					string text3 = Strings.Mid(text2, DC_Main.M, 1);
					if (Operators.CompareString(text3, ".", false) == 0)
					{
						text += "|";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(1), false) == 0)
					{
						text += "B";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(2), false) == 0)
					{
						text += "O";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(3), false) == 0)
					{
						text += "Y";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(4), false) == 0)
					{
						text += "F";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(5), false) == 0)
					{
						text += "R";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(6), false) == 0)
					{
						text += "I";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(7), false) == 0)
					{
						text += "E";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(8), false) == 0)
					{
						text += "N";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(9), false) == 0)
					{
						text += "D";
					}
					else if (Operators.CompareString(text3, Conversions.ToString(0), false) == 0)
					{
						text += "U";
					}
					DC_Main.M++;
				}
				mSG_PR[mSG_PR.Row, 79] = text;
				tHmId4.Text = text;
			}
			MSG_PR_TOT_FILL();
			BILL_TOTAL();
			mSG_PR = null;
		}
	}

	private void MSG_PR_TOT_FILL()
	{
		if (UpDown)
		{
			return;
		}
		TotCrFine = 0.0;
		PrOthAmtLess = 0.0;
		AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
		checked
		{
			int num = MSG_PR.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG_PR_TOT[0, DC_Main.M] = "";
				DC_Main.M++;
			}
			mSG_PR_TOT[0, 4] = "Total :";
			int num2 = MSG_PR.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				if (Operators.CompareString(MSG_PR[DC_Main.M, 8], "+", false) == 0)
				{
					mSG_PR_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR[DC_Main.M, 10]))), "0");
					mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0.000");
					mSG_PR_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 11]) + Conversion.Val(MSG_PR[DC_Main.M, 11]))), "0.000");
					mSG_PR_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR[DC_Main.M, 12]))), "0.000");
					mSG_PR_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 13]) + Conversion.Val(MSG_PR[DC_Main.M, 13]))), "0.000");
					mSG_PR_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 23]) + Conversion.Val(MSG_PR[DC_Main.M, 23]))), "0.000");
					mSG_PR_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 26]) + Conversion.Val(MSG_PR[DC_Main.M, 26]))), "0.000");
					mSG_PR_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 41]) + Conversion.Val(MSG_PR[DC_Main.M, 41]))), "0.00");
					mSG_PR_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 30]) + Conversion.Val(MSG_PR[DC_Main.M, 30]))), "0.00");
					mSG_PR_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR[DC_Main.M, 31]))), "0.00");
					mSG_PR_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 43]) + Conversion.Val(MSG_PR[DC_Main.M, 43]))), "0.00");
					mSG_PR_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 45]) + Conversion.Val(MSG_PR[DC_Main.M, 45]))), "0.000");
					mSG_PR_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 14]) + Conversion.Val(MSG_PR[DC_Main.M, 14]))), "0.000");
					mSG_PR_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR[DC_Main.M, 15]))), "0.000");
					mSG_PR_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 17]) + Conversion.Val(MSG_PR[DC_Main.M, 17]))), "0.000");
					mSG_PR_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 20]) + Conversion.Val(MSG_PR[DC_Main.M, 20]))), "0.000");
					mSG_PR_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 33]) + Conversion.Val(MSG_PR[DC_Main.M, 33]))), "0.00");
					mSG_PR_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 34]) + Conversion.Val(MSG_PR[DC_Main.M, 34]))), "0.00");
					mSG_PR_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 42]) + Conversion.Val(MSG_PR[DC_Main.M, 42]))), "0.00");
				}
				else
				{
					mSG_PR_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 10]) - Conversion.Val(MSG_PR[DC_Main.M, 10]))), "0");
					mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) - Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0.000");
					mSG_PR_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 11]) - Conversion.Val(MSG_PR[DC_Main.M, 11]))), "0.000");
					mSG_PR_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 12]) - Conversion.Val(MSG_PR[DC_Main.M, 12]))), "0.000");
					mSG_PR_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 13]) - Conversion.Val(MSG_PR[DC_Main.M, 13]))), "0.000");
					mSG_PR_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 23]) - Conversion.Val(MSG_PR[DC_Main.M, 23]))), "0.000");
					mSG_PR_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 26]) - Conversion.Val(MSG_PR[DC_Main.M, 26]))), "0.000");
					mSG_PR_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 41]) - Conversion.Val(MSG_PR[DC_Main.M, 41]))), "0.00");
					mSG_PR_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 30]) - Conversion.Val(MSG_PR[DC_Main.M, 30]))), "0.00");
					mSG_PR_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 31]) - Conversion.Val(MSG_PR[DC_Main.M, 31]))), "0.00");
					mSG_PR_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 43]) - Conversion.Val(MSG_PR[DC_Main.M, 43]))), "0.00");
					mSG_PR_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 45]) - Conversion.Val(MSG_PR[DC_Main.M, 45]))), "0.000");
					mSG_PR_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 14]) - Conversion.Val(MSG_PR[DC_Main.M, 14]))), "0.000");
					mSG_PR_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 15]) - Conversion.Val(MSG_PR[DC_Main.M, 15]))), "0.000");
					mSG_PR_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 17]) - Conversion.Val(MSG_PR[DC_Main.M, 17]))), "0.000");
					mSG_PR_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 20]) - Conversion.Val(MSG_PR[DC_Main.M, 20]))), "0.000");
					mSG_PR_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 33]) - Conversion.Val(MSG_PR[DC_Main.M, 33]))), "0.00");
					mSG_PR_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 34]) - Conversion.Val(MSG_PR[DC_Main.M, 34]))), "0.00");
					mSG_PR_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 42]) - Conversion.Val(MSG_PR[DC_Main.M, 42]))), "0.00");
				}
				DC_Main.M++;
			}
			mSG_PR_TOT = null;
		}
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 32;
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
			mSG_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
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
				mSG_IDTL[0, 8] = "DmRemark";
				mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[9] = 0;
				mSG_IDTL[0, 9] = "DmSfNo";
			}
			mSG_IDTL[10] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "Pcs";
			mSG_IDTL[11] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "PcsWt";
			mSG_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "KrAWt";
			mSG_IDTL[13] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[13] = 7;
			mSG_IDTL[0, 13] = "KrA%";
			mSG_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "KrWt";
			mSG_IDTL[15] = (int)Math.Round(800.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "KrLs%";
			mSG_IDTL[16] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "Weight";
			mSG_IDTL[17] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "Con%";
			mSG_IDTL[18] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[18] = 3;
			mSG_IDTL[0, 18] = "P/W";
			mSG_IDTL[19] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[19] = 7;
			mSG_IDTL[0, 19] = "Rate";
			mSG_IDTL[20] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[20] = 7;
			mSG_IDTL[0, 20] = "ItAmt";
			mSG_IDTL[21] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[21] = 7;
			mSG_IDTL[0, 21] = "PRate";
			mSG_IDTL[22] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[22] = 7;
			mSG_IDTL[0, 22] = "PAmt";
			mSG_IDTL[23] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[23] = 7;
			mSG_IDTL[0, 23] = "LbrRate";
			mSG_IDTL[24] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[24] = 7;
			mSG_IDTL[0, 24] = "LbrAmt";
			mSG_IDTL[25] = (int)Math.Round(1050.0 * ColCon);
			mSG_IDTL[25] = 7;
			mSG_IDTL[0, 25] = "NetAmt";
			mSG_IDTL[26] = 0;
			mSG_IDTL[0, 26] = "ConWt";
			mSG_IDTL[27] = 0;
			mSG_IDTL[0, 27] = "KrConWt";
			mSG_IDTL[28] = 0;
			mSG_IDTL[0, 28] = "ItType";
			mSG_IDTL[29] = 0;
			mSG_IDTL[0, 29] = "RowSrNo";
			mSG_IDTL[30] = 0;
			mSG_IDTL[0, 30] = "OldKrWt";
			mSG_IDTL[31] = 0;
			mSG_IDTL[0, 31] = "OldGrWt";
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
		mSG_IDTL[mSG_IDTL.Row, 29] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 56]));
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
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Invalid comparison between Unknown and I4
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Invalid comparison between Unknown and I4
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Invalid comparison between Unknown and I4
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Invalid comparison between Unknown and I4
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0935: Unknown result type (might be due to invalid IL or missing references)
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
						string text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29])));
						string text2 = Conversions.ToString(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 29]));
						string text3 = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])));
						string text4 = Conversions.ToString(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0]));
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 29])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
						{
							DtIdtl.Rows.Remove(DtIdtl.Rows[i]);
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
				if (mSG_IDTL.Col < 25)
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
							MSG.Col += 1;
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
									mSG_IDTL[mSG_IDTL.Row, 28] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 17]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						if (Operators.CompareString(EntryMode, "A", false) != 0)
						{
							break;
						}
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 25]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
						}
						else if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))) && Operators.CompareString(mSG_IDTL[mSG_IDTL.Row, 18], "", false) == 0)
						{
							mSG_IDTL[mSG_IDTL.Row, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""));
						}
						break;
					case 3:
					{
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0 || mSG_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_IDTL.Text + "'";
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable.Rows.Count == 0)
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
						mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_CODE"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					}
					case 11:
						if (mSG_IDTL[12] > 0)
						{
							if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
							{
								mSG_IDTL[mSG_IDTL.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
							}
						}
						else if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
						{
							mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
						}
						break;
					case 16:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) == 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 16]) == 0.0))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 25]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_IDTL[mSG_IDTL.Row, 19] = "";
						}
						break;
					case 25:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
							mSG_IDTL[mSG_IDTL.Row, 25] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							((Control)TEXT_IDTL).Visible = false;
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
				((TextBoxBase)TEXT_IDTL).ReadOnly = true;
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
				case 18:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 17:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				case 13:
				case 15:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 11:
				case 12:
				case 14:
				case 16:
				case 26:
				case 27:
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
			case 18:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 17:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 13:
			case 15:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 11:
			case 12:
			case 14:
			case 16:
			case 26:
			case 27:
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
		checked
		{
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29])) == Conversion.Val(mSG_IDTL[CRow, 29])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
						DtIdtl.Rows[i][21] = mSG_IDTL[CRow, 21];
						DtIdtl.Rows[i][22] = mSG_IDTL[CRow, 22];
						DtIdtl.Rows[i][23] = mSG_IDTL[CRow, 23];
						DtIdtl.Rows[i][24] = mSG_IDTL[CRow, 24];
						DtIdtl.Rows[i][25] = mSG_IDTL[CRow, 25];
						DtIdtl.Rows[i][26] = mSG_IDTL[CRow, 26];
						DtIdtl.Rows[i][27] = mSG_IDTL[CRow, 27];
						DtIdtl.Rows[i][28] = mSG_IDTL[CRow, 28];
						DtIdtl.Rows[i][29] = mSG_IDTL[CRow, 29];
						DtIdtl.Rows[i][30] = mSG_IDTL[CRow, 30];
						DtIdtl.Rows[i][31] = mSG_IDTL[CRow, 31];
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
					dr[16] = mSG_IDTL[CRow, 16];
					dr[12] = mSG_IDTL[CRow, 12];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[17] = mSG_IDTL[CRow, 17];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[20] = mSG_IDTL[CRow, 20];
					dr[21] = mSG_IDTL[CRow, 21];
					dr[22] = mSG_IDTL[CRow, 22];
					dr[23] = mSG_IDTL[CRow, 23];
					dr[24] = mSG_IDTL[CRow, 24];
					dr[25] = mSG_IDTL[CRow, 25];
					dr[26] = mSG_IDTL[CRow, 26];
					dr[27] = mSG_IDTL[CRow, 27];
					dr[28] = mSG_IDTL[CRow, 28];
					dr[29] = mSG_IDTL[CRow, 29];
					dr[30] = mSG_IDTL[CRow, 30];
					dr[31] = mSG_IDTL[CRow, 31];
					DtIdtl.Rows.Add(dr);
				}
			}
			mSG_IDTL = null;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 73;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 0;
		mSG[1] = 0;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[2] = (int)Math.Round(900.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[3] = (int)Math.Round(900.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Counter";
			mSG[4] = (int)Math.Round(1300.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Design";
			mSG[5] = (int)Math.Round(1100.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Color";
			mSG[6] = (int)Math.Round(800.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Size";
			mSG[7] = (int)Math.Round(900.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "HuId";
			mSG[8] = (int)Math.Round(800.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "BagWt";
			mSG[9] = (int)Math.Round(700.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Pcs";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "GrWt";
			mSG[11] = (int)Math.Round(900.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "LsWt";
			mSG[12] = (int)Math.Round(1000.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "NetWt";
			mSG[13] = (int)Math.Round(1000.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "KrOthWt";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "KrNwt";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "KrGht%";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "KrGht";
			mSG[17] = (int)Math.Round(900.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "KrTouch";
			mSG[18] = (int)Math.Round(900.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "KrWst%";
			mSG[19] = (int)Math.Round(900.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "KrFine";
			mSG[21] = (int)Math.Round(750.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "Ght%";
			mSG[22] = (int)Math.Round(850.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "GhtWt";
			mSG[23] = (int)Math.Round(850.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "Touch";
			mSG[24] = (int)Math.Round(850.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "West%";
			mSG[25] = (int)Math.Round(1000.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "Fine";
			mSG[20] = (int)Math.Round(800.0 * ColCon);
			mSG[20] = 3;
			mSG[0, 20] = "LCode";
			mSG[26] = (int)Math.Round(800.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "Lbr%";
			mSG[27] = (int)Math.Round(800.0 * ColCon);
			mSG[27] = 3;
			mSG[0, 27] = "LType";
			mSG[28] = (int)Math.Round(900.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "LbrRate";
			mSG[29] = (int)Math.Round(950.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "LbrAmt";
			mSG[30] = (int)Math.Round(1000.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "OthAmt";
			mSG[31] = (int)Math.Round(900.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "KrLRate";
			mSG[32] = (int)Math.Round(1000.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "KrLAmt";
			mSG[33] = (int)Math.Round(1100.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrOthAmt";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
			{
				mSG[34] = (int)Math.Round(700.0 * ColCon);
				mSG[34] = 3;
				mSG[0, 34] = "SlType";
				mSG[35] = (int)Math.Round(1000.0 * ColCon);
				mSG[35] = 7;
				mSG[0, 35] = "OthRate";
				mSG[36] = (int)Math.Round(1000.0 * ColCon);
				mSG[36] = 7;
				mSG[0, 36] = "OthFine";
				mSG[37] = (int)Math.Round(1000.0 * ColCon);
				mSG[37] = 7;
				mSG[0, 37] = "TotFine";
				mSG[38] = (int)Math.Round(1000.0 * ColCon);
				mSG[38] = 7;
				mSG[0, 38] = "GwtTouch";
			}
			else
			{
				mSG[34] = 0;
				mSG[35] = 0;
				mSG[36] = 0;
				mSG[37] = 0;
				mSG[38] = 0;
			}
			mSG[41] = (int)Math.Round(1000.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "PrCost";
			mSG[39] = (int)Math.Round(1000.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "ItRate";
			mSG[40] = (int)Math.Round(1100.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "ItAmt";
			mSG[42] = (int)Math.Round(1100.0 * ColCon);
			mSG[42] = 7;
			mSG[0, 42] = "TagCost";
			mSG[43] = (int)Math.Round(800.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "Margin";
			mSG[44] = (int)Math.Round(1000.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "Mrp";
			mSG[45] = (int)Math.Round(750.0 * ColCon);
			mSG[45] = 3;
			mSG[0, 45] = "Image";
			mSG[46] = (int)Math.Round(2200.0 * ColCon);
			mSG[46] = 0;
			mSG[0, 46] = "Remark";
			mSG[47] = (int)Math.Round(800.0 * ColCon);
			mSG[47] = 7;
			mSG[0, 47] = "KrCod";
			if (DC_Main.MsTagVchSrnoUpdate)
			{
				mSG[61] = (int)Math.Round(1500.0 * ColCon);
				mSG[61] = 3;
				mSG[0, 61] = "TagId";
			}
			else
			{
				mSG[61] = 0;
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) != 0)
			{
				mSG[48] = 0;
				mSG[49] = 0;
				mSG[50] = 0;
				mSG[51] = 0;
				mSG[52] = 0;
				mSG[53] = 0;
				mSG[54] = 0;
			}
			mSG[55] = 0;
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
			mSG[60] = 0;
			mSG[62] = 0;
			mSG[63] = 0;
			mSG[64] = (int)Math.Round(900.0 * ColCon);
			mSG[64] = 0;
			mSG[0, 64] = "HuId2";
			mSG[65] = (int)Math.Round(900.0 * ColCon);
			mSG[65] = 0;
			mSG[0, 65] = "HuId3";
			mSG[66] = (int)Math.Round(900.0 * ColCon);
			mSG[66] = 0;
			mSG[0, 66] = "HuId4";
			mSG[67] = 0;
			mSG[68] = 0;
			mSG[69] = 0;
			mSG[70] = 0;
			mSG[71] = 0;
			mSG[72] = 0;
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
					dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
			{
				mSG[13] = (int)Math.Round(1000.0 * ColCon);
				mSG[13] = 7;
				mSG[0, 13] = "KrOthWt";
				mSG[14] = (int)Math.Round(1000.0 * ColCon);
				mSG[14] = 7;
				mSG[0, 14] = "KrNwt";
				mSG[17] = (int)Math.Round(900.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "KrTouch";
				mSG[18] = (int)Math.Round(900.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "KrWst%";
				mSG[19] = (int)Math.Round(900.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "KrFine";
				mSG[48] = (int)Math.Round(1000.0 * ColCon);
				mSG[48] = 7;
				mSG[0, 48] = "JdtWt";
				mSG[49] = (int)Math.Round(900.0 * ColCon);
				mSG[49] = 7;
				mSG[0, 49] = "JGhatWt";
				mSG[50] = (int)Math.Round(1000.0 * ColCon);
				mSG[50] = 7;
				mSG[0, 50] = "Kundan";
				mSG[51] = (int)Math.Round(0.0 * ColCon);
				mSG[51] = 7;
				mSG[0, 51] = "KndTch%";
				mSG[52] = (int)Math.Round(0.0 * ColCon);
				mSG[52] = 7;
				mSG[0, 52] = "KndNwt";
				mSG[53] = (int)Math.Round(1000.0 * ColCon);
				mSG[53] = 7;
				mSG[0, 53] = "Wax";
				mSG[54] = (int)Math.Round(1000.0 * ColCon);
				mSG[54] = 7;
				mSG[0, 54] = "KrWax";
			}
			MsgLastCol = 47;
			DC_Main.M = 48;
			while (DC_Main.M <= 41)
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[41] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 41;
					break;
				}
				DC_Main.M++;
			}
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
				mSG_TOT[0, 4] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.000");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
					mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[DC_Main.M, 25]))), "0.000");
					mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.00");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.00");
					mSG_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 42]) + Conversion.Val(MSG[DC_Main.M, 42]))), "0.00");
					mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.000");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
					mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.000");
					mSG_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 32]) + Conversion.Val(MSG[DC_Main.M, 32]))), "0.00");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.00");
					mSG_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 41]) + Conversion.Val(MSG[DC_Main.M, 41]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 30]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 44]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 9] = Conversions.ToString(1);
		mSG[mSG.Row, 27] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 56] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 56] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 56]) + 1.0);
		}
		mSG[mSG.Row, 63] = "A";
		mSG[mSG.Row, 72] = "N";
		mSG[mSG.Row, 34] = "N";
		MSG_IDTL_CLEAR();
		mSG = null;
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		UpDown = false;
		MsgOldRow = 0;
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
				mSG[mSG.Row, mSG.Col] = "";
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
			if (!((mSG.Row == 0) | (mSG.CellWidth <= 0)) && MSG[MSG.Col] != 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				switch (MSG.Col)
				{
				case 0:
				case 2:
				case 47:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 20:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 4;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 61:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 46:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 150;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
					break;
				case 4:
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 7:
				case 64:
				case 65:
				case 66:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 27:
				case 34:
				case 45:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 9:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 17:
				case 18:
				case 21:
				case 23:
				case 24:
				case 26:
				case 43:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 28:
				case 29:
				case 30:
				case 31:
				case 32:
				case 33:
				case 35:
				case 38:
				case 39:
				case 40:
				case 41:
				case 42:
				case 44:
				case 51:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 8:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 19:
				case 22:
				case 25:
				case 36:
				case 37:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					break;
				case 48:
				case 49:
				case 50:
				case 52:
				case 53:
				case 54:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (!UpDown && !MsgClear && MSG.Row != 0 && MSG[MSG.Col] != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 2:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 20:
			case 27:
			case 34:
			case 45:
			case 46:
			case 47:
			case 61:
			case 64:
			case 65:
			case 66:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 9:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 17:
			case 18:
			case 21:
			case 23:
			case 24:
			case 26:
			case 43:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 35:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 44:
			case 51:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 11:
			case 13:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal_Idtl(1);
				CommPassTotal();
				break;
			case 8:
			case 10:
			case 12:
			case 14:
			case 15:
			case 16:
			case 19:
			case 22:
			case 25:
			case 36:
			case 37:
			case 48:
			case 49:
			case 50:
			case 52:
			case 53:
			case 54:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			}
			mSG = null;
		}
	}

	private void CommPassTotal()
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
				AxMSFlexGrid mSG;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000c;
				case 84:
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
							goto IL_000c;
						case 3:
							goto IL_0016;
						case 4:
							goto IL_0018;
						case 5:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 6:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_000c:
					num2 = 2;
					mSG = MSG;
					goto IL_0016;
					IL_0016:
					mSG = null;
					goto IL_0018;
					IL_0018:
					num2 = 4;
					MSG_TOT_FILL();
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 5;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 84;
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
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Invalid comparison between Unknown and I4
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Invalid comparison between Unknown and I4
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Invalid comparison between Unknown and I4
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Invalid comparison between Unknown and I4
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Invalid comparison between Unknown and I4
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Invalid comparison between Unknown and I4
		//IL_4370: Unknown result type (might be due to invalid IL or missing references)
		//IL_464e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				List<DataRow> list = new List<DataRow>();
				checked
				{
					int num = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][29])) == Conversion.Val(mSG[mSG.Row, 56]))
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
					int num2 = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 0]));
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
							mSG[mSG.Row, 56] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 56] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 56]) + 1.0);
						}
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
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
					((TextBoxBase)TEXT_ENTRY).SelectAll();
					((Control)TEXT_ENTRY).Focus();
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG.Col >= 54)
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
					RtnOldRow = 0;
					mSG.Row = checked(mSG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
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
						RtnOldRow = 0;
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
						if (Operators.CompareString(FormBookInOut, "O", false) != 0 || !((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						mSG[mSG.Row, 61] = Conversions.ToString(0);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> '' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 61]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 61]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> '' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC";
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
								mSG[mSG.Row, 2] = DC_Main.ColValue[2];
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 10] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 61] = DC_Main.ColValue[7];
								if (chkSameTag.Checked)
								{
									mSG[mSG.Row, 2] = DC_Main.ColValue[0];
									mSG[mSG.Row, 63] = DC_Main.ColValue[1];
									mSG[mSG.Row, 1] = DC_Main.ColValue[2];
									mSG[mSG.Row, 4] = DC_Main.ColValue[3];
									mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 13] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								}
								((Control)TEXT_ENTRY).Focus();
							}
							else
							{
								mSG[mSG.Row, 61] = "";
								mSG[mSG.Row, 1] = "";
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
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
						mSG[mSG.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
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
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 10] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 61] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 61]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_COLOR"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
							mSG[DC_Main.i, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
							mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 20] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_CODE"], (object)""));
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 27] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_TYPE"], (object)""));
							mSG[DC_Main.i, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_RATE"])), "0.00");
							mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_FINE"])), "0.000");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOT_FINE"])), "0.000");
							mSG[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_GWT_TOUCH"])), "0.00");
							mSG[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
							mSG[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 46] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
							mSG[DC_Main.i, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
							mSG[DC_Main.i, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_SRNO"])), "0");
							mSG[DC_Main.i, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DATA_TYPE"], (object)""));
							mSG[DC_Main.i, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[DC_Main.i, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[DC_Main.i, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[DC_Main.i, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[DC_Main.i, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_JDT_WT"])), "0.000");
							mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_KUN_WT"])), "0.000");
							mSG[DC_Main.i, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_KUN_TOUCH"])), "0.00");
							mSG[DC_Main.i, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_KUN_NET"])), "0.000");
							mSG[DC_Main.i, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_WAX_WT"])), "0.000");
							mSG[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WAX_WT"])), "0.000");
							mSG[DC_Main.i, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
							if (chkSameTag.Checked)
							{
								MSG_PR[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
								MSG_PR[DC_Main.i, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
								MSG_PR[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
								MSG_PR[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
								MSG_PR[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
								MSG_PR[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_COLOR"], (object)""));
								MSG_PR[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
								MSG_PR[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
								MSG_PR[DC_Main.i, 8] = "+";
								MSG_PR[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
								MSG_PR[DC_Main.i, 10] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
								MSG_PR[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								MSG_PR[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
								MSG_PR[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								MSG_PR[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_WT"])), "0.000");
								MSG_PR[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.000");
								MSG_PR[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_GHT_PRC"])), "0.00");
								MSG_PR[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_GHT_WT"])), "0.000");
								MSG_PR[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
								MSG_PR[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
								MSG_PR[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
								MSG_PR[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
								MSG_PR[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
								MSG_PR[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								MSG_PR[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								MSG_PR[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
								MSG_PR[DC_Main.i, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_CODE"], (object)""));
								MSG_PR[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
								MSG_PR[DC_Main.i, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
								MSG_PR[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
								MSG_PR[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
								MSG_PR[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
								MSG_PR[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
								MSG_PR[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
								MSG_PR[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
								MSG_PR[DC_Main.i, 35] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_TYPE"], (object)""));
								MSG_PR[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_RATE"])), "0.00");
								MSG_PR[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_FINE"])), "0.000");
								MSG_PR[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOT_FINE"])), "0.000");
								MSG_PR[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_GWT_TOUCH"])), "0.00");
								MSG_PR[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
								MSG_PR[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
								MSG_PR[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
								MSG_PR[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
								MSG_PR[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
								MSG_PR[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
								MSG_PR[DC_Main.i, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
								MSG_PR[DC_Main.i, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
								MSG_PR[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
								MSG_PR[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
								MSG_PR[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
								MSG_PR[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								MSG_PR[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								MSG_PR[DC_Main.i, 84] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DATA_TYPE"], (object)""));
								MSG_PR[DC_Main.i, 77] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
								MSG_PR[DC_Main.i, 78] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
								MSG_PR[DC_Main.i, 79] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
								MSG_PR[DC_Main.i, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
								MSG_PR[DC_Main.i, 81] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
								MSG_PR[DC_Main.i, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
								MSG_PR[DC_Main.i, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
								MSG_PR[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_JDT_WT"])), "0.000");
								MSG_PR[DC_Main.i, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_GHT_WT"])), "0.000");
								MSG_PR[DC_Main.i, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_KUN_WT"])), "0.000");
								MSG_PR[DC_Main.i, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_KUN_TOUCH"])), "0.00");
								MSG_PR[DC_Main.i, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_KUN_NET"])), "0.000");
								MSG_PR[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["JDT_WAX_WT"])), "0.000");
								MSG_PR[DC_Main.i, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WAX_WT"])), "0.000");
								MSG_PR[DC_Main.i, 90] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
								int num5 = 0;
								int num6 = RtnIdtl.Rows.Count - 1;
								int num7 = num6;
								for (int i = 0; i <= num7; i++)
								{
									if (Operators.ConditionalCompareObjectEqual(RtnIdtl.Rows[num5][29], (object)Conversion.Val(mSG[DC_Main.i, 57]), false))
									{
										RtnIdtl.Rows[num5].Delete();
										RtnIdtl.AcceptChanges();
										num5--;
									}
									num5++;
								}
								MSG_RTN_IDTL_CLEAR();
								DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 61] + " ";
								DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.i = 0;
								while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
								{
									Rtndr = RtnIdtl.NewRow();
									Rtndr[29] = Conversion.Val(MSG_PR[mSG.Row, 57]);
									Rtndr[0] = DC_Main.i + 1;
									Rtndr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
									Rtndr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
									Rtndr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
									Rtndr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
									Rtndr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
									Rtndr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
									Rtndr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
									Rtndr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
									Rtndr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
									Rtndr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
									Rtndr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
									Rtndr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
									Rtndr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
									Rtndr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_WT"])), "0.000");
									Rtndr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_PRC"])), "0.00");
									Rtndr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
									Rtndr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
									Rtndr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
									Rtndr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
									Rtndr[18] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
									Rtndr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
									Rtndr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
									Rtndr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_RATE"])), "0.00");
									Rtndr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_AMT"])), "0.00");
									Rtndr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
									Rtndr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
									Rtndr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
									Rtndr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
									Rtndr[27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
									Rtndr[28] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
									RtnIdtl.Rows.Add(Rtndr);
									DC_Main.i++;
								}
								RtnOldRow = 0;
								CommPassTotal_Pr(DC_Main.i);
								MSG_PR_RowColChange(MSG_PR, new EventArgs());
								MSG_PR_TOT_FILL();
							}
						}
						int num8 = 0;
						int num9 = DtIdtl.Rows.Count - 1;
						int num10 = num9;
						for (int j = 0; j <= num10; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num8][29], (object)Conversion.Val(mSG[DC_Main.i, 56]), false))
							{
								DtIdtl.Rows[num8].Delete();
								DtIdtl.AcceptChanges();
								num8--;
							}
							num8++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 61] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[29] = Conversion.Val(MSG[mSG.Row, 56]);
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
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_WT"])), "0.000");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_PRC"])), "0.00");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
							dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[18] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_RATE"])), "0.00");
							dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_AMT"])), "0.00");
							dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[28] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (mSG.Row == mSG.Rows - 1)
						{
							if (chkSameTag.Checked)
							{
								MsgOldRow = 0;
								mSG[mSG.Row, 1] = TEXT_ENTRY.Text;
								((Control)TEXT_ENTRY).Visible = false;
								MSG_PR.Row = 1;
								MSG_PR.Col = 11;
								MSG_PR_EnterCell(MSG_PR, new EventArgs());
								((Control)TEXT_PR).Focus();
							}
							else
							{
								mSG[mSG.Row, 1] = TEXT_ENTRY.Text;
								MsgOldRow = 0;
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								MsgClear = false;
								mSG.Col = 1;
								CommPassAdd();
							}
							return;
						}
						break;
					}
					case 2:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "' "), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0, (object)"", (object)"AND BULK_SALE <> 'N'")), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND BULK_SALE <> 'N' ORDER BY A.IT_NAME";
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
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[1];
									mSG[mSG.Row, 62] = DC_Main.ColValue[0];
									mSG[mSG.Row, 60] = DC_Main.ColValue[3];
									mSG[mSG.Row, 58] = DC_Main.ColValue[4];
									mSG[mSG.Row, 59] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						break;
					case 3:
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
									mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 10:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 47:
						if (mSG.Row == mSG.Rows - 1)
						{
							CommPassTotal();
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							MSG.Col = 1;
							CommPassAdd();
						}
						else
						{
							mSG.Row += 1;
							MSG.Col = 1;
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

	private void TR_TAG_SPLIT_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_123c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1241: Unknown result type (might be due to invalid IL or missing references)
		//IL_124b: Expected O, but got Unknown
		//IL_1270: Unknown result type (might be due to invalid IL or missing references)
		//IL_1275: Unknown result type (might be due to invalid IL or missing references)
		//IL_127f: Expected O, but got Unknown
		//IL_12a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b3: Expected O, but got Unknown
		//IL_12d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e7: Expected O, but got Unknown
		//IL_130c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1311: Unknown result type (might be due to invalid IL or missing references)
		//IL_131b: Expected O, but got Unknown
		//IL_135a: Unknown result type (might be due to invalid IL or missing references)
		//IL_135f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1369: Expected O, but got Unknown
		//IL_1383: Unknown result type (might be due to invalid IL or missing references)
		//IL_1388: Unknown result type (might be due to invalid IL or missing references)
		//IL_1392: Expected O, but got Unknown
		//IL_13ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bb: Expected O, but got Unknown
		//IL_13d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13da: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e4: Expected O, but got Unknown
		//IL_13fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1403: Unknown result type (might be due to invalid IL or missing references)
		//IL_140d: Expected O, but got Unknown
		//IL_1427: Unknown result type (might be due to invalid IL or missing references)
		//IL_142c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1436: Expected O, but got Unknown
		//IL_1450: Unknown result type (might be due to invalid IL or missing references)
		//IL_1455: Unknown result type (might be due to invalid IL or missing references)
		//IL_145f: Expected O, but got Unknown
		//IL_1487: Unknown result type (might be due to invalid IL or missing references)
		//IL_148e: Expected O, but got Unknown
		//IL_1559: Unknown result type (might be due to invalid IL or missing references)
		//IL_155e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1568: Expected O, but got Unknown
		//IL_15f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ff: Expected O, but got Unknown
		//IL_1698: Unknown result type (might be due to invalid IL or missing references)
		//IL_169d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a3: Expected O, but got Unknown
		//IL_172d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1732: Unknown result type (might be due to invalid IL or missing references)
		//IL_173c: Expected O, but got Unknown
		//IL_1761: Unknown result type (might be due to invalid IL or missing references)
		//IL_1766: Unknown result type (might be due to invalid IL or missing references)
		//IL_1770: Expected O, but got Unknown
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
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				TextBox obj4 = tHdVchNo;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				Label obj6 = lblBook;
				object? obj7 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj6).ForeColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj8 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj13 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj14 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
				object? obj16 = colorConverter.ConvertFromString("DarkGray");
				mSG_IDTL2.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_IDTL3 = MSG_IDTL;
				object? obj17 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_IDTL3.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_RTN_IDTL.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL2 = MSG_RTN_IDTL;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG_RTN_IDTL2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL3 = MSG_RTN_IDTL;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_RTN_IDTL3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj21 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj22 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj23 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj24 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj25 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj26 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj28 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj29 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj32 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj33 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj34 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj35 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj36 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj38 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj39 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj40 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL4 = MSG_RTN_IDTL;
				object? obj41 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_RTN_IDTL4.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL5 = MSG_RTN_IDTL;
				object? obj42 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_RTN_IDTL5.BackColorBkg = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL6 = MSG_RTN_IDTL;
				object? obj43 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_RTN_IDTL6.BackColorFixed = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj44 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj45 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj46 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj47 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj48 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj49 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj50 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj51 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj52 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj52 != null) ? ((Color)obj52) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj53 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj54 = lblBook;
				object? obj55 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj54).ForeColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj56 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj57 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj58 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj59 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj60 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj61 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj62 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL7 = MSG_RTN_IDTL;
				object? obj63 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_RTN_IDTL7.BackColor = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL8 = MSG_RTN_IDTL;
				object? obj64 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_RTN_IDTL8.BackColorBkg = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL9 = MSG_RTN_IDTL;
				object? obj65 = colorConverter.ConvertFromString("Cornsilk");
				mSG_RTN_IDTL9.BackColorFixed = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj66 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj67 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj68 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj68 != null) ? ((Color)obj68) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj69 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj69 != null) ? ((Color)obj69) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj70 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj70 != null) ? ((Color)obj70) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj71 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj71 != null) ? ((Color)obj71) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj72 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj72 != null) ? ((Color)obj72) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj73 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj73 != null) ? ((Color)obj73) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj74 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj74 != null) ? ((Color)obj74) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj75 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj75 != null) ? ((Color)obj75) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj76 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj76 != null) ? ((Color)obj76) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj77 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj77 != null) ? ((Color)obj77) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj78 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj78 != null) ? ((Color)obj78) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				((TextBoxBase)TEXT_RTN_IDTL).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				((Control)TEXT_RTN_IDTL).Font = new Font(((Control)TEXT_RTN_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_RTN_IDTL).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_RTN_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_RTN_IDTL.Font.Style);
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is CheckBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_RTN_IDTL", false) != 0)))
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
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkBillImage", false))
						{
							NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
					MSG_PR_TOT.ScrollBars = (ScrollBarsSettings)0;
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
			if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'QR' ORDER BY PRINT_FILE";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE";
			}
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			string text = "";
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboPrintfile.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
				cboPrintfile.SelectedIndex = 0;
			}
			else
			{
				cboPrintfile.Items.Add((object)"");
			}
			cboPrintfile.Text = text;
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 0;
			}
			else
			{
				cboItemTyp.SelectedIndex = 1;
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)nHmWt).Visible = false;
				((Control)tHmId2).Visible = false;
				((Control)nHmWt2).Visible = false;
				((Control)tHmId3).Visible = false;
				((Control)nHmWt3).Visible = false;
				((Control)tHmId4).Visible = false;
				((Control)nHmWt4).Visible = false;
				((Control)Label14).Visible = false;
				((Control)Label13).Visible = false;
				((Control)Label12).Visible = false;
				((Control)Label11).Visible = false;
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			BtnCancel_Click(BtnCancel, new EventArgs());
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
		lblItem.Text = "";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		UsUPdate = "N";
		UsDelete = "N";
		chkSameTag.Checked = false;
		OldValTot = 0.0;
		NewValTot = 0.0;
		TotCrFine = 0.0;
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		PrOthAmtLess = 0.0;
		LessAdvAmt = 0.0;
		LessAdvNetWt = 0.0;
		EditOPen = false;
		CrDrTot = 0.0;
		if (VchOldData != null)
		{
			VchOldData.Clear();
		}
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		AcGstType = "L";
		PicImage.Image = null;
		PictureBox1.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		((Control)TEXT_RTN_IDTL).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_PR_CLEAR();
		MSG_RTN_IDTL_CLEAR();
		MSG2_CLEAR();
		if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '10'";
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
				MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
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
			RtnIdtl.Clear();
			RtnIdtl.Reset();
			RtnRow = 0;
			int num3 = MSG_RTN_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num3)
			{
				RtnIdtl.Columns.Add(MSG_RTN_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM LBR_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "'";
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
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				nCrWt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_WT"])), "0.000");
				nDrWt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_WT"])), "0.000");
				nCrTouch.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_TOUCH"])), "0.00");
				nDrTouch.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_TOUCH"])), "0.00");
				nCrFine.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_FINE"])), "0.000");
				nDrFine.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_FINE"])), "0.000");
				nCrLbrAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_LBR"])), "0.00");
				CurRatePar = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["RATE_PAR"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(RsData.Rows[0]["IT_TYPE"], (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[1, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_NET_AMT"]), "0.00");
				MSG2_TOTAL[4, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[5, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CARD_AMT"]), "0.00");
				MSG2_TOTAL[6, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["SL_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[7, 4] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SL_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[8, 4] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_NET_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CARD_AMT"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_KASAR_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["PR_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[7, 3] = Strings.Format((object)num3, "0.00");
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_BILL_OS"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["PR_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL4[8, 3] = Strings.Format((object)num4, "0.00");
				MSG2_TOTAL[4, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[4, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[4, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[5, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[5, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
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
				CustOpGold = DC_Main.MsAcGoldOpBal;
				CustClGold = DC_Main.MsAcGoldClBal;
				CustOpSilver = DC_Main.MsAcSilverOpBal;
				CustClSilver = DC_Main.MsAcSilverClBal;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM LBR_ISU_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 56] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["SL_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOT_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_GWT_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_COST"])), "0.00");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 46] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["VCH_SRNO"])), "0");
					mSG[DC_Main.i + 1, 63] = "E";
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_JDT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_KUN_WT"])), "0.000");
					mSG[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_KUN_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_KUN_NET"])), "0.000");
					mSG[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 63] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num5 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num5)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM LBR_ISU_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[29] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
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
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_ACT_WT"])), "0.000");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_ACT_PRC"])), "0.00");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
					dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					dr[18] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
					dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
					dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[28] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM LBR_REC_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsPrDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 57] = Conversions.ToString(RsPrDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 63] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG_PR[DC_Main.i + 1, 2] = "";
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_SIGN"], (object)""));
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 10] = Conversions.ToString(RsPrDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 88] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 74] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["SL_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_OTH_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_TOT_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_GWT_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_COST"])), "0.00");
					mSG_PR[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG_PR[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG_PR[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG_PR[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG_PR[DC_Main.i + 1, 48] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_SRNO"])), "0");
					mSG_PR[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG_PR[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 76] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["APR_ISU"], (object)""));
					mSG_PR[DC_Main.i + 1, 64] = "E";
					mSG_PR[DC_Main.i + 1, 84] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 77] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG_PR[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG_PR[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG_PR[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 81] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["JDT_JDT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["JDT_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["JDT_KUN_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["JDT_KUN_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["JDT_KUN_NET"])), "0.000");
					mSG_PR[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["JDT_WAX_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["KR_WAX_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 89] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
					mSG_PR[DC_Main.i + 1, 90] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG_PR[DC_Main.i + 1, 64] = "E";
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				RtnIdtl.Clear();
				RtnIdtl.Reset();
				RtnRow = 0;
				int num6 = MSG_RTN_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num6)
				{
					RtnIdtl.Columns.Add(MSG_RTN_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					Rtndr = RtnIdtl.NewRow();
					Rtndr[29] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					Rtndr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					Rtndr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					Rtndr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					Rtndr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					Rtndr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					Rtndr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					Rtndr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					Rtndr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					Rtndr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					Rtndr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					Rtndr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					Rtndr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
					Rtndr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					Rtndr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					Rtndr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_ACT_WT"])), "0.000");
					Rtndr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_ACT_PRC"])), "0.00");
					Rtndr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					Rtndr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
					Rtndr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					Rtndr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					Rtndr[18] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					Rtndr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					Rtndr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					Rtndr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
					Rtndr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
					Rtndr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					Rtndr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					Rtndr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					Rtndr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					Rtndr[27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					Rtndr[28] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					RtnIdtl.Rows.Add(Rtndr);
					DC_Main.i++;
				}
				if (MSG.Rows >= 1)
				{
					MsgOldRow = 0;
					MSG.Row = 1;
					MSG_RowColChange(MSG, new EventArgs());
				}
				if (MSG_PR.Rows >= 1)
				{
					RtnOldRow = 0;
					MSG_PR.Row = 1;
					MSG_PR_RowColChange(MSG_PR, new EventArgs());
				}
				EditOPen = false;
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 30]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG2_TOTAL[8, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 30]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG2_TOTAL[8, 3]);
				EntryMode = "E";
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

	private void TR_TAG_SPLIT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_TAG_SPLIT_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			if (Operators.CompareString(tAcCode.Text, "", false) == 0 && Conversion.Val(nCrWt.Text) != Conversion.Val(nDrWt.Text))
			{
				Interaction.MsgBox((object)"Please Insert diff Wt in Received Grid and Try....", (MsgBoxStyle)0, (object)null);
				MSG_PR.Row = MSG_PR.Rows - 1;
				MSG_PR.Col = 1;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
				return;
			}
			if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
				((Control)tEmpCode).Focus();
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
			if (Operators.CompareString(tVchNo.Text, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				return;
			}
			if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)
			{
				int num = MSG_PR.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((Operators.CompareString(MSG_PR[DC_Main.M, 3], "", false) == 0) & (Operators.CompareString(MSG_PR[DC_Main.M, 1], "", false) != 0))
					{
						Interaction.MsgBox((object)"Please Insert Tag Entry Counter Code and Try Because It is Mandatory...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						MSG_PR.Row = DC_Main.M;
						MSG_PR.Col = 3;
						MSG_PR_EnterCell(MSG_PR, new EventArgs());
						((Control)TEXT_PR).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			MSG_TOT_FILL();
			MSG_PR_TOT_FILL();
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			if ((Conversion.Val(MSG_TOT[0, 44]) != 0.0) | (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 30]) != 0.0))
			{
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow = dataTable.NewRow();
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["LC_CODE"] = DC_Main.MLc_code;
				dataRow["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow["VCH_NO"] = tHdVchNo.Text;
				dataRow["BOOK_NAME"] = FormName;
				dataTable.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
				dataTable.Clear();
				DC_Main.RsQry = "SELECT * FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow2 = RsData.NewRow();
				dataRow2["CO_CODE"] = DC_Main.MCo_code;
				dataRow2["LC_CODE"] = DC_Main.MLc_code;
				dataRow2["CO_YEAR"] = DC_Main.MCo_year;
				dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow2["VCH_NO"] = tVchNo.Text;
				dataRow2["AC_CODE"] = tAcCode.Text;
				dataRow2["VCH_DATE"] = mVchDate.Text;
				dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
				dataRow2["AC_CODE"] = tAcCode.Text;
				dataRow2["VCH_TYPE"] = FormBookSname;
				dataRow2["INOUT_TYPE"] = FormBookInOut;
				dataRow2["ENTRY_TYPE"] = "C";
				dataRow2["BOOK_NAME"] = FormMainBook;
				dataRow2["CR_WT"] = Conversion.Val(nCrWt.Text);
				dataRow2["DR_WT"] = Conversion.Val(nDrWt.Text);
				dataRow2["CR_TOUCH"] = Conversion.Val(nCrTouch.Text);
				dataRow2["DR_TOUCH"] = Conversion.Val(nDrTouch.Text);
				dataRow2["CR_FINE"] = Conversion.Val(nCrFine.Text);
				dataRow2["DR_FINE"] = Conversion.Val(nDrFine.Text);
				dataRow2["CR_LBR"] = Conversion.Val(nCrLbrAmt.Text);
				dataRow2["DR_LBR"] = 0;
				dataRow2["RATE_PAR"] = CurRatePar;
				dataRow2["CR_RATE"] = 0;
				dataRow2["DR_RATE"] = 0;
				dataRow2["DR_AMT"] = 0;
				dataRow2["CR_AMT"] = 0;
				dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
				dataRow2["TAX_PRC"] = 0;
				dataRow2["TAX_AMT"] = 0;
				dataRow2["LBR_DISC_PRC"] = 0;
				dataRow2["LBR_DISC_AMT"] = 0;
				dataRow2["LBR_TAX_CODE"] = 0;
				dataRow2["LBR_TAX_PRC"] = 0;
				dataRow2["LBR_TAX_AMT"] = 0;
				dataRow2["TOT_DR_AMT"] = 0;
				dataRow2["ORD_FINE"] = 0;
				dataRow2["ORD_AMT"] = 0;
				dataRow2["SL_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 4]);
				dataRow2["SL_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[4, 4]);
				dataRow2["SL_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[5, 4]);
				dataRow2["SL_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[6, 4]);
				dataRow2["SL_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[7, 4]);
				dataRow2["SL_BILL_OS"] = Conversion.Val(MSG2_TOTAL[8, 4]);
				dataRow2["PR_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
				dataRow2["PR_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
				dataRow2["PR_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
				dataRow2["PR_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
				dataRow2["PR_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
				dataRow2["PR_BILL_OS"] = Conversion.Val(MSG2_TOTAL[8, 3]);
				dataRow2["CARD_AC"] = MSG2_TOTAL[5, 5];
				dataRow2["BANK_AC"] = MSG2_TOTAL[4, 5];
				dataRow2["CHQ_NO"] = MSG2_TOTAL[4, 2];
				dataRow2["EMP_CODE"] = tEmpCode.Text;
				dataRow2["VCH_DESC"] = tVchDesc.Text;
				dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow2["DATA_TRFR"] = "N";
				dataRow2["MAIN_USER"] = MainUser;
				dataRow2["USER_UPDATE"] = "N";
				dataRow2["USER_DELETE"] = "N";
				RsData.Rows.Add(dataRow2);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
				RsData.Clear();
			}
			DC_Main.RsQry = "SELECT * FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow3 = RsDetl.NewRow();
			int num2 = MSG.Rows - 1;
			for (int i = 1; i <= num2; i++)
			{
				AxMSFlexGrid mSG = MSG;
				if ((Operators.CompareString(mSG[i, 2], "", false) != 0) & (Conversion.Val(mSG[i, 44]) + Conversion.Val(mSG[i, 10]) + Conversion.Val(mSG[i, 30]) != 0.0))
				{
					dataRow3["CO_CODE"] = DC_Main.MCo_code;
					dataRow3["LC_CODE"] = DC_Main.MLc_code;
					dataRow3["CO_YEAR"] = DC_Main.MCo_year;
					dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow3["VCH_NO"] = tVchNo.Text;
					dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow3["VCH_DATE"] = mVchDate.Text;
					dataRow3["VCH_TYPE"] = FormBookSname;
					dataRow3["INOUT_TYPE"] = FormBookInOut;
					dataRow3["ENTRY_TYPE"] = "O";
					dataRow3["BOOK_NAME"] = FormMainBook;
					dataRow3["SR_NO"] = Conversion.Val(mSG[i, 0]);
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG[i, 56]);
					dataRow3["IT_CODE"] = mSG[i, 2];
					dataRow3["TAG_NO"] = mSG[i, 1];
					dataRow3["TBL_CODE"] = mSG[i, 3];
					dataRow3["DESIGN_NO"] = mSG[i, 4];
					dataRow3["ITM_SIZE"] = mSG[i, 6];
					dataRow3["HM_ID"] = mSG[i, 7];
					dataRow3["BAG_WT"] = Conversion.Val(mSG[i, 8]);
					dataRow3["ITM_PCS"] = Conversion.Val(mSG[i, 9]);
					dataRow3["ITM_GWT"] = Conversion.Val(mSG[i, 10]);
					dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[i, 11]);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG[i, 12]);
					dataRow3["KR_OTH_WT"] = Conversion.Val(mSG[i, 13]);
					dataRow3["KR_NET_WT"] = Conversion.Val(mSG[i, 14]);
					dataRow3["KR_GHT_PRC"] = Conversion.Val(mSG[i, 15]);
					dataRow3["KR_GHT_WT"] = Conversion.Val(mSG[i, 16]);
					dataRow3["KR_TOUCH"] = Conversion.Val(mSG[i, 17]);
					dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[i, 18]);
					dataRow3["KR_FINE"] = Conversion.Val(mSG[i, 19]);
					dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[i, 21]);
					dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[i, 22]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[i, 23]);
					dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[i, 24]);
					dataRow3["ITM_FINE"] = Conversion.Val(mSG[i, 25]);
					dataRow3["LBR_CODE"] = mSG[i, 20];
					dataRow3["LBR_PRC"] = Conversion.Val(mSG[i, 26]);
					dataRow3["LBR_TYPE"] = mSG[i, 27];
					dataRow3["LBR_RATE"] = Conversion.Val(mSG[i, 28]);
					dataRow3["LBR_AMT"] = Conversion.Val(mSG[i, 29]);
					dataRow3["OTH_AMT"] = Conversion.Val(mSG[i, 30]);
					dataRow3["KR_LBR_RATE"] = Conversion.Val(mSG[i, 31]);
					dataRow3["KR_LBR_AMT"] = Conversion.Val(mSG[i, 32]);
					dataRow3["KR_OTH_AMT"] = Conversion.Val(mSG[i, 33]);
					dataRow3["SL_TYPE"] = mSG[i, 34];
					dataRow3["KR_OTH_RATE"] = Conversion.Val(mSG[i, 35]);
					dataRow3["KR_OTH_FINE"] = Conversion.Val(mSG[i, 36]);
					dataRow3["KR_TOT_FINE"] = Conversion.Val(mSG[i, 37]);
					dataRow3["KR_GWT_TOUCH"] = Conversion.Val(mSG[i, 38]);
					dataRow3["KR_COST"] = Conversion.Val(mSG[i, 41]);
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[i, 39]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[i, 40]);
					dataRow3["TAG_COST"] = Conversion.Val(mSG[i, 42]);
					dataRow3["ITM_MARGIN"] = Conversion.Val(mSG[i, 43]);
					dataRow3["ITM_MRP"] = Conversion.Val(mSG[i, 44]);
					dataRow3["ITM_REMARK"] = mSG[i, 46];
					dataRow3["KR_NAME"] = mSG[i, 47];
					dataRow3["RATE_TYPE"] = mSG[i, 57];
					dataRow3["IT_TYPE"] = mSG[i, 58];
					dataRow3["PR_CODE"] = mSG[i, 60];
					dataRow3["VCH_SRNO"] = Conversion.Val(mSG[i, 61]);
					dataRow3["APR_ISU"] = "N";
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["DATA_TRFR"] = "N";
					dataRow3["DATA_TYPE"] = mSG[i, 71];
					dataRow3["HM_ID2"] = mSG[i, 64];
					dataRow3["HM_ID3"] = mSG[i, 65];
					dataRow3["HM_ID4"] = mSG[i, 66];
					dataRow3["HM_ID_WT"] = Conversion.Val(mSG[i, 67]);
					dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[i, 68]);
					dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[i, 69]);
					dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[i, 70]);
					dataRow3["JDT_JDT_WT"] = Conversion.Val(mSG[i, 48]);
					dataRow3["JDT_GHT_WT"] = Conversion.Val(mSG[i, 49]);
					dataRow3["JDT_KUN_WT"] = Conversion.Val(mSG[i, 50]);
					dataRow3["JDT_KUN_TOUCH"] = Conversion.Val(mSG[i, 51]);
					dataRow3["JDT_KUN_NET"] = Conversion.Val(mSG[i, 52]);
					dataRow3["JDT_WAX_WT"] = Conversion.Val(mSG[i, 53]);
					dataRow3["KR_WAX_WT"] = Conversion.Val(mSG[i, 54]);
					dataRow3["DESIGN_IMG_ID"] = mSG[i, 72];
					dataRow3["MAIN_USER"] = MainUser;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
			}
			DC_Main.RsQry = "SELECT * FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow4 = RsIdtl.NewRow();
			int num3 = DtIdtl.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][25])) != 0.0)
				{
					dataRow4["CO_CODE"] = DC_Main.MCo_code;
					dataRow4["LC_CODE"] = DC_Main.MLc_code;
					dataRow4["CO_YEAR"] = DC_Main.MCo_year;
					dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["VCH_NO"] = tVchNo.Text;
					dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow4["VCH_DATE"] = mVchDate.Text;
					dataRow4["AC_CODE"] = tAcCode.Text;
					dataRow4["VCH_TYPE"] = FormBookSname;
					dataRow4["INOUT_TYPE"] = FormBookInOut;
					dataRow4["ENTRY_TYPE"] = "S";
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][29]));
					dataRow4["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][29]))), 1];
					dataRow4["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][29]))), 61]);
					dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][0]));
					dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][1]);
					dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][3]);
					dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][4]);
					dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][5]);
					dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][6]);
					dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][7]);
					dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][8]);
					dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][9]);
					dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][10]));
					dataRow4["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][11]));
					dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16]));
					dataRow4["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][12]));
					dataRow4["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][13]));
					dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][14]));
					dataRow4["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][15]));
					dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][17]));
					dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][18]);
					dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][19]));
					dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][20]));
					dataRow4["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][21]));
					dataRow4["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][22]));
					dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][23]));
					dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][24]));
					dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][25]));
					dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][26]));
					dataRow4["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][27]));
					dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][28]);
					dataRow4["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow4);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl = null;
			}
			DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "SELECT * FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
			RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow5 = RsPrDetl.NewRow();
			int num4 = MSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num4)
			{
				AxMSFlexGrid mSG_PR = MSG_PR;
				if ((Conversion.Val(MSG_PR[DC_Main.i, 11]) + Conversion.Val(MSG_PR[DC_Main.i, 45]) + Conversion.Val(MSG_PR[DC_Main.i, 31]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
				{
					dataRow5["CO_CODE"] = DC_Main.MCo_code;
					dataRow5["CO_CODE"] = DC_Main.MCo_code;
					dataRow5["LC_CODE"] = DC_Main.MLc_code;
					dataRow5["CO_YEAR"] = DC_Main.MCo_year;
					dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow5["VCH_NO"] = tVchNo.Text;
					dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow5["VCH_DATE"] = mVchDate.Text;
					dataRow5["VCH_TYPE"] = FormBookSname;
					dataRow5["INOUT_TYPE"] = FormBookInOut;
					dataRow5["ENTRY_TYPE"] = "O";
					dataRow5["BOOK_NAME"] = FormMainBook;
					dataRow5["SR_NO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
					dataRow5["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 57]);
					dataRow5["IT_CODE"] = mSG_PR[DC_Main.i, 1];
					if (Operators.CompareString(mSG_PR[DC_Main.i, 2], "", false) == 0)
					{
						dataRow5["TAG_NO"] = "N";
					}
					else
					{
						dataRow5["TAG_NO"] = mSG_PR[DC_Main.i, 2];
					}
					dataRow5["TBL_CODE"] = mSG_PR[DC_Main.i, 3];
					dataRow5["DESIGN_NO"] = mSG_PR[DC_Main.i, 4];
					dataRow5["ITM_SIZE"] = mSG_PR[DC_Main.i, 6];
					dataRow5["ITM_SIGN"] = mSG_PR[DC_Main.i, 8];
					dataRow5["HM_ID"] = mSG_PR[DC_Main.i, 7];
					dataRow5["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
					dataRow5["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
					dataRow5["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 11]);
					dataRow5["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
					dataRow5["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
					dataRow5["KR_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
					dataRow5["KR_NET_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
					dataRow5["KR_GHT_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 16]);
					dataRow5["KR_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
					dataRow5["KR_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
					dataRow5["KR_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
					dataRow5["KR_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 20]);
					dataRow5["ITM_GHT_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 22]);
					dataRow5["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 23]);
					dataRow5["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 24]);
					dataRow5["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 25]);
					dataRow5["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
					dataRow5["LBR_CODE"] = mSG_PR[DC_Main.i, 21];
					dataRow5["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
					dataRow5["LBR_TYPE"] = mSG_PR[DC_Main.i, 28];
					dataRow5["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
					dataRow5["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
					dataRow5["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
					dataRow5["KR_LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
					dataRow5["KR_LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 33]);
					dataRow5["KR_OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
					dataRow5["SL_TYPE"] = mSG_PR[DC_Main.i, 35];
					dataRow5["KR_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 36]);
					dataRow5["KR_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 37]);
					dataRow5["KR_TOT_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 38]);
					dataRow5["KR_GWT_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 39]);
					dataRow5["KR_COST"] = Conversion.Val(mSG_PR[DC_Main.i, 42]);
					dataRow5["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 40]);
					dataRow5["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 41]);
					dataRow5["TAG_COST"] = Conversion.Val(mSG_PR[DC_Main.i, 43]);
					dataRow5["ITM_MARGIN"] = Conversion.Val(mSG_PR[DC_Main.i, 44]);
					dataRow5["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 45]);
					dataRow5["ITM_REMARK"] = mSG_PR[DC_Main.i, 47];
					dataRow5["KR_NAME"] = mSG_PR[DC_Main.i, 48];
					dataRow5["TAG_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 56]);
					dataRow5["RATE_TYPE"] = mSG_PR[DC_Main.i, 58];
					dataRow5["IT_TYPE"] = mSG_PR[DC_Main.i, 59];
					dataRow5["TAG_TYPE"] = mSG_PR[DC_Main.i, 60];
					dataRow5["PR_CODE"] = mSG_PR[DC_Main.i, 61];
					if (Conversion.Val(mSG_PR[DC_Main.i, 62]) == 0.0)
					{
						mSG_PR[DC_Main.i, 62] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm");
						dataRow5["VCH_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 62]);
					}
					else
					{
						dataRow5["VCH_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 62]);
					}
					dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow5["DATA_TRFR"] = "N";
					dataRow5["APR_ISU"] = mSG_PR[DC_Main.i, 76];
					if (Operators.CompareString(mSG_PR[DC_Main.i, 84], "", false) == 0)
					{
						dataRow5["DATA_TYPE"] = "A";
					}
					else
					{
						dataRow5["DATA_TYPE"] = mSG_PR[DC_Main.i, 84];
					}
					dataRow5["HM_ID2"] = mSG_PR[DC_Main.i, 77];
					dataRow5["HM_ID3"] = mSG_PR[DC_Main.i, 78];
					dataRow5["HM_ID4"] = mSG_PR[DC_Main.i, 79];
					dataRow5["HM_ID_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 80]);
					dataRow5["HM_ID2_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 81]);
					dataRow5["HM_ID3_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 82]);
					dataRow5["HM_ID4_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 83]);
					dataRow5["JDT_JDT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 49]);
					dataRow5["JDT_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 50]);
					dataRow5["JDT_KUN_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 51]);
					dataRow5["JDT_KUN_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 52]);
					dataRow5["JDT_KUN_NET"] = Conversion.Val(mSG_PR[DC_Main.i, 53]);
					dataRow5["JDT_WAX_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 54]);
					dataRow5["KR_WAX_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 55]);
					dataRow5["EMP_ISU"] = mSG_PR[DC_Main.i, 89];
					dataRow5["DESIGN_IMG_ID"] = mSG_PR[DC_Main.i, 90];
					dataRow5["MAIN_USER"] = MainUser;
					RsPrDetl.Rows.Add(dataRow5);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsPrDetl);
					RsPrDetl.Clear();
				}
				mSG_PR = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsBarData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow6 = RsBarData.NewRow();
			if ((Conversion.Val(MSG_PR_TOT[0, 45]) != 0.0) | (Conversion.Val(MSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR_TOT[0, 13]) + Conversion.Val(MSG_PR_TOT[0, 31]) != 0.0))
			{
				dataRow6["CO_CODE"] = DC_Main.MCo_code;
				dataRow6["LC_CODE"] = DC_Main.MLc_code;
				dataRow6["CO_YEAR"] = DC_Main.MCo_year;
				dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow6["VCH_NO"] = tVchNo.Text;
				dataRow6["VCH_DATE"] = mVchDate.Text;
				dataRow6["STK_IT_CODE"] = "";
				dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow6["EMP_CODE"] = tEmpCode.Text;
				dataRow6["VCH_DESC"] = tVchDesc.Text;
				dataRow6["DATA_TRFR"] = "N";
				dataRow6["MAIN_USER"] = MainUser;
				RsBarData.Rows.Add(dataRow6);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsBarData);
				RsBarData.Clear();
			}
			DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
			RsBarDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow7 = RsBarDetl.NewRow();
			int num5 = MSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num5)
			{
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				if ((Conversion.Val(MSG_PR[DC_Main.i, 10]) + Conversion.Val(MSG_PR[DC_Main.i, 11]) + Conversion.Val(MSG_PR[DC_Main.i, 45]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 2], "", false) != 0))
				{
					dataRow7["CO_CODE"] = DC_Main.MCo_code;
					dataRow7["CO_CODE"] = DC_Main.MCo_code;
					dataRow7["LC_CODE"] = DC_Main.MLc_code;
					dataRow7["CO_YEAR"] = DC_Main.MCo_year;
					dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow7["VCH_NO"] = tVchNo.Text;
					dataRow7["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow7["VCH_DATE"] = mVchDate.Text;
					dataRow7["STK_DATE"] = mVchDate.Text;
					dataRow7["VCH_TYPE"] = FormBookSname;
					dataRow7["INOUT_TYPE"] = FormBookInOut;
					dataRow7["ENTRY_TYPE"] = "I";
					dataRow7["BOOK_NAME"] = FormMainBook;
					dataRow7["LOT_NO"] = "";
					dataRow7["SR_NO"] = Conversion.Val(mSG_PR2[DC_Main.i, 0]);
					dataRow7["OLD_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 57]);
					dataRow7["IT_CODE"] = mSG_PR2[DC_Main.i, 1];
					if (Operators.CompareString(mSG_PR2[DC_Main.i, 2], "", false) == 0)
					{
						dataRow7["TAG_NO"] = "N";
					}
					else
					{
						dataRow7["TAG_NO"] = mSG_PR2[DC_Main.i, 2];
					}
					dataRow7["TBL_CODE"] = mSG_PR2[DC_Main.i, 3];
					dataRow7["DESIGN_NO"] = mSG_PR2[DC_Main.i, 4];
					dataRow7["ITM_COLOR"] = mSG_PR2[DC_Main.i, 5];
					dataRow7["ITM_SIZE"] = mSG_PR2[DC_Main.i, 6];
					dataRow7["HM_ID"] = mSG_PR2[DC_Main.i, 7];
					dataRow7["BAG_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 9]);
					dataRow7["ITM_PCS"] = Conversion.Val(mSG_PR2[DC_Main.i, 10]);
					dataRow7["ITM_GWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 11]);
					dataRow7["ITM_OTH_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 12]);
					dataRow7["ITM_NWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 13]);
					dataRow7["KR_OTH_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 14]);
					dataRow7["KR_NET_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 15]);
					dataRow7["KR_GHT_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 16]);
					dataRow7["KR_GHT_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 17]);
					dataRow7["KR_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 18]);
					dataRow7["KR_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 19]);
					dataRow7["KR_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 20]);
					dataRow7["ITM_GHT_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 22]);
					dataRow7["ITM_GHT_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 23]);
					dataRow7["ITM_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 24]);
					dataRow7["ITM_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 25]);
					dataRow7["ITM_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 26]);
					dataRow7["LBR_CODE"] = mSG_PR2[DC_Main.i, 21];
					dataRow7["LBR_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 27]);
					dataRow7["LBR_TYPE"] = mSG_PR2[DC_Main.i, 28];
					dataRow7["LBR_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 29]);
					dataRow7["LBR_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 30]);
					dataRow7["OTH_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 31]);
					dataRow7["KR_LBR_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 32]);
					dataRow7["KR_LBR_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 33]);
					dataRow7["KR_OTH_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 34]);
					dataRow7["SL_TYPE"] = mSG_PR2[DC_Main.i, 35];
					dataRow7["KR_OTH_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 36]);
					dataRow7["KR_OTH_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 37]);
					dataRow7["KR_TOT_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 38]);
					dataRow7["KR_GWT_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 39]);
					dataRow7["KR_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 42]);
					dataRow7["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 40]);
					dataRow7["ITM_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 41]);
					dataRow7["TAG_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 43]);
					dataRow7["MAIN_MARGIN_PRC"] = 0;
					dataRow7["MAIN_MRP"] = 0;
					dataRow7["ITM_MARGIN"] = Conversion.Val(mSG_PR2[DC_Main.i, 44]);
					dataRow7["ITM_MRP"] = Conversion.Val(mSG_PR2[DC_Main.i, 45]);
					dataRow7["ITM_REMARK"] = mSG_PR2[DC_Main.i, 47];
					dataRow7["KR_NAME"] = mSG_PR2[DC_Main.i, 48];
					dataRow7["TAG_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 56]);
					dataRow7["RATE_TYPE"] = mSG_PR2[DC_Main.i, 58];
					dataRow7["IT_TYPE"] = mSG_PR2[DC_Main.i, 59];
					dataRow7["TAG_TYPE"] = mSG_PR2[DC_Main.i, 60];
					dataRow7["PR_CODE"] = mSG_PR2[DC_Main.i, 61];
					if (Conversion.Val(mSG_PR2[DC_Main.i, 62]) == 0.0)
					{
						mSG_PR2[DC_Main.i, 62] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG_PR2[mSG_PR2.Row, 57]));
						dataRow7["VCH_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 62]);
					}
					else
					{
						dataRow7["VCH_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 62]);
					}
					if (Operators.CompareString(mSG_PR2[DC_Main.i, 76], "", false) == 0)
					{
						dataRow7["APR_ISU"] = "N";
					}
					else
					{
						dataRow7["APR_ISU"] = mSG_PR2[DC_Main.i, 76];
					}
					dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow7["DATA_TRFR"] = "N";
					if (Operators.CompareString(mSG_PR2[DC_Main.i, 84], "", false) == 0)
					{
						dataRow7["DATA_TYPE"] = "A";
					}
					else
					{
						dataRow7["DATA_TYPE"] = mSG_PR2[DC_Main.i, 84];
					}
					dataRow7["HM_ID2"] = mSG_PR2[DC_Main.i, 77];
					dataRow7["HM_ID3"] = mSG_PR2[DC_Main.i, 78];
					dataRow7["HM_ID4"] = mSG_PR2[DC_Main.i, 79];
					dataRow7["HM_ID_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 80]);
					dataRow7["HM_ID2_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 81]);
					dataRow7["HM_ID3_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 82]);
					dataRow7["HM_ID4_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 83]);
					dataRow7["SF_NO"] = mSG_PR2[DC_Main.i, 86];
					dataRow7["JDT_JDT_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 49]);
					dataRow7["JDT_GHT_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 50]);
					dataRow7["JDT_KUN_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 51]);
					dataRow7["JDT_KUN_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 52]);
					dataRow7["JDT_KUN_NET"] = Conversion.Val(mSG_PR2[DC_Main.i, 53]);
					dataRow7["JDT_WAX_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 54]);
					dataRow7["KR_WAX_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 55]);
					dataRow7["EMP_ISU"] = mSG_PR2[DC_Main.i, 89];
					dataRow7["DESIGN_IMG_ID"] = mSG_PR2[DC_Main.i, 90];
					dataRow7["MAIN_USER"] = MainUser;
					dataRow7["DATA_TRFR"] = "N";
					dataRow7["MAIN_USER"] = MainUser;
					RsBarDetl.Rows.Add(dataRow7);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsBarDetl);
					RsBarDetl.Clear();
				}
				mSG_PR2 = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow8 = RsIdtl.NewRow();
			int num6 = RtnIdtl.Rows.Count - 1;
			int m = default(int);
			for (int k = 0; k <= num6; k++)
			{
				DataTable rtnIdtl = RtnIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][25])) != 0.0)
				{
					int num7 = MSG_PR.Rows - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num7)
					{
						if (Conversion.Val(MSG_PR[DC_Main.M, 57]) == Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][29])))
						{
							m = DC_Main.M;
							break;
						}
						DC_Main.M++;
					}
					dataRow8["CO_CODE"] = DC_Main.MCo_code;
					dataRow8["LC_CODE"] = DC_Main.MLc_code;
					dataRow8["CO_YEAR"] = DC_Main.MCo_year;
					dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow8["VCH_NO"] = tVchNo.Text;
					dataRow8["VCH_DATE"] = mVchDate.Text;
					dataRow8["AC_CODE"] = tAcCode.Text;
					dataRow8["VCH_TYPE"] = FormBookSname;
					dataRow8["INOUT_TYPE"] = FormBookInOut;
					dataRow8["ENTRY_TYPE"] = "S";
					dataRow8["BOOK_NAME"] = FormMainBook;
					dataRow8["SR_NO"] = Conversion.Val(MSG_PR[m, 57]);
					dataRow8["TAG_NO"] = MSG_PR[m, 2];
					dataRow8["VCH_SRNO"] = Conversion.Val(MSG_PR[m, 62]);
					dataRow8["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][0]));
					dataRow8["IT_CODE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][1]);
					dataRow8["DM_CODE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][3]);
					dataRow8["DM_NAME"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][4]);
					dataRow8["DM_COLOR"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][5]);
					dataRow8["DM_SIZE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][6]);
					dataRow8["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][7]);
					dataRow8["DM_REMARK"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][8]);
					dataRow8["DM_SFNO"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][9]);
					dataRow8["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][10]));
					dataRow8["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][11]));
					dataRow8["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][16]));
					dataRow8["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][12]));
					dataRow8["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][13]));
					dataRow8["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][14]));
					dataRow8["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][15]));
					dataRow8["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][17]));
					dataRow8["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][18]);
					dataRow8["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][19]));
					dataRow8["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][20]));
					dataRow8["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][21]));
					dataRow8["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][22]));
					dataRow8["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][23]));
					dataRow8["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][24]));
					dataRow8["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][25]));
					dataRow8["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][26]));
					dataRow8["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][27]));
					dataRow8["IT_TYPE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[k][28]);
					dataRow8["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow8);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				rtnIdtl = null;
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Ledr.Tag_Split_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Rojmel.Tag_Split_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Tag_Split_Stk(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Dm_Tag_Split_Detl(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
			int num8 = MSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num8)
			{
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				if ((Operators.CompareString(mSG_PR3[DC_Main.i, 1], "", false) != 0) & (Operators.CompareString(mSG_PR3[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG_PR3[DC_Main.i, 45]) + (Conversion.Val(mSG_PR3[DC_Main.i, 10]) + Conversion.Val(mSG_PR3[DC_Main.i, 11]) + Conversion.Val(mSG_PR3[DC_Main.i, 30]) + Conversion.Val(mSG_PR3[DC_Main.i, 31])) != 0.0))
				{
					Mobile_image_Save(DC_Main.i, Conversions.ToString(Conversion.Val(mSG_PR3[DC_Main.i, 62])));
				}
				mSG_PR3 = null;
				DC_Main.i++;
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.TableCol();
				string text = "";
				int num9 = RsData.Columns.Count - 2;
				DC_Main.M = 0;
				while (DC_Main.M <= num9)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
					{
						int num10 = DC_Main.RsTblCol.Rows.Count - 1;
						for (int l = 0; l <= num10; l++)
						{
							if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[l]["TBL_COL_NAME"], false))
							{
								text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[l]["COL_NAME"], (object)""));
							}
						}
						if (Operators.CompareString(text, "", false) == 0)
						{
							text = RsData.Columns[DC_Main.M].ColumnName;
						}
						DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','N')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						text = "";
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
			CurPrnVch = tVchNo.Text;
			DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustClAmt = DC_Main.MsAcAmtClBal;
			CustOpGold = DC_Main.MsAcGoldOpBal;
			CustClGold = DC_Main.MsAcGoldClBal;
			CustOpSilver = DC_Main.MsAcSilverOpBal;
			CustClSilver = DC_Main.MsAcSilverClBal;
			CLEAR_DATA();
			BtnPrint_Click(BtnPrint, new EventArgs());
			CurPrnVch = "";
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			DC_Main.MsAcGoldOpBal = 0.0;
			DC_Main.MsAcGoldClBal = 0.0;
			DC_Main.MsAcSilverOpBal = 0.0;
			DC_Main.MsAcSilverClBal = 0.0;
			CustOpAmt = 0.0;
			CustClAmt = 0.0;
			CustOpGold = 0.0;
			CustClGold = 0.0;
			CustOpSilver = 0.0;
			CustClSilver = 0.0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Mobile_image_Save(int ImgRow, string NewVchSrNo)
	{
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		Image val = null;
		checked
		{
			try
			{
				AxMSFlexGrid mSG_PR = MSG_PR;
				string text = mSG_PR[ImgRow, 2] + "_" + NewVchSrNo;
				int num = MSG.Rows - 1;
				for (int i = 1; i <= num; i++)
				{
					if (Operators.CompareString(mSG_PR[ImgRow, 2], MSG[i, 1], false) == 0)
					{
						DC_Main.MsImageNo = MSG[i, 1] + "_" + MSG[i, 61];
						break;
					}
				}
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
				{
					try
					{
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						using WebClient webClient = new WebClient();
						using MemoryStream memoryStream = new MemoryStream(webClient.DownloadData(address));
						val = Image.FromStream((Stream)memoryStream);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val = null;
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + mSG_PR[ImgRow, 1] + "' AND VCH_SRNO= " + Conversions.ToString(Conversion.Val(mSG_PR[ImgRow, 61]))) ?? "";
					DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						string s = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""));
						byte[] buffer = Convert.FromBase64String(s);
						using MemoryStream memoryStream2 = new MemoryStream(buffer);
						val = Image.FromStream((Stream)memoryStream2);
					}
					else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						using FileStream fileStream = new FileStream(DC_Main.MsImagePath, FileMode.Open, FileAccess.Read);
						val = Image.FromStream((Stream)fileStream);
					}
				}
				if (val != null)
				{
					PicImage.Image = (Image)new Bitmap(val);
				}
				if (PicImage.Image != null)
				{
					byte[] inArray;
					using (MemoryStream memoryStream3 = new MemoryStream())
					{
						PicImage.Image.Save((Stream)memoryStream3, ImageFormat.Jpeg);
						inArray = memoryStream3.ToArray();
					}
					string value = Convert.ToBase64String(inArray);
					DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG_PR[DC_Main.i, 2] + "' AND VCH_SRNO = " + NewVchSrNo) ?? "";
					DC_Main.ExeQuteImg(DC_Main.RsQry);
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG_PR[DC_Main.i, 2] + "' AND VCH_SRNO = " + NewVchSrNo) ?? "";
					DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["TAG_NO"] = mSG_PR[DC_Main.i, 2];
					dataRow["VCH_SRNO"] = NewVchSrNo;
					dataRow["IMAGE_TYPE"] = "T";
					dataRow["MOB_IMAGE"] = value;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
				}
				mSG_PR = null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show("Image Error : " + ex2.Message);
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
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			checked
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_SRNO = '" + MSG[DC_Main.M, 61] + "' AND TAG_NO = '" + MSG[DC_Main.M, 1] + "'");
					DC_Main.M++;
				}
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
		}
	}

	private void TR_TAG_SPLIT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 27)
		{
			return;
		}
		checked
		{
			if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = MSG.Rows - 1;
				if (MSG[1] == 0)
				{
					MSG.Col = 2;
				}
				else
				{
					MSG.Col = 1;
				}
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
				MSG_PR.Row = 1;
				MSG_PR.Col = 1;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
			else if (((Control)TEXT_PR).Visible)
			{
				MSG_PR_LeaveCell(MSG, new EventArgs());
				MSG_PR.Row = MSG_PR.Rows - 1;
				MSG_PR.Col = 1;
				((Control)TEXT_PR).Visible = false;
				MSG_PR_TOT_FILL();
				((Control)tAcCode).Focus();
			}
			else if (((Control)TEXT_RTN_IDTL).Visible)
			{
				((Control)TEXT_RTN_IDTL).Visible = false;
				MSG_PR.Col += 1;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Visible = true;
				((Control)TEXT_PR).Focus();
			}
			else if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");
		checked
		{
			int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "INSERT INTO TAG_PRINT_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,IT_CODE,VCH_SRNO)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + CurPrnVch + "'," + Conversions.ToString(DC_Main.i) + ",'00',0)";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.i++;
			}
			if ((Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0) & (Operators.CompareString(EntryMode, "E", false) == 0) & (MSG.Rows > 1))
			{
				DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");
				int num2 = MSG_PR.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					QRCodeGenerator val = new QRCodeGenerator();
					QRCodeData val2 = val.CreateQrCode(MSG_PR[DC_Main.M, 2], (ECCLevel)2, false, false, (EciMode)0, -1);
					QRCode val3 = new QRCode(val2);
					PictureBox2.Image = (Image)(object)val3.GetGraphic(3);
					MemoryStream memoryStream = new MemoryStream();
					PictureBox2.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
					byte[] value = memoryStream.ToArray();
					DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG_PR[DC_Main.M, 2] + "' AND VCH_SRNO = " + MSG_PR[DC_Main.M, 62] + " ";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["SR_NO"] = DC_Main.M;
					dataRow["TAG_NO"] = MSG_PR[DC_Main.M, 2];
					dataRow["VCH_SRNO"] = Conversion.Val(MSG_PR[DC_Main.M, 62]);
					dataRow["TAG_IMAGE"] = value;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					DC_Main.M++;
				}
			}
			DC_Main.ExeQuteDc("INSERT INTO TAG_PRINT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + CurPrnVch + "'");
			DC_Main.RsQry = "SELECT * FROM TAG_PRINT_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			((Form)MyProject.Forms.MS_PRINT).ShowDialog();
			if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) != 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
				Cr.SelectionFormula = "{TAG_PRINT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' ";
				if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
				{
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
				else
				{
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
				DC_Main.MsPrintStatus = false;
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	private void TR_TAG_SPLIT_Activated(object sender, EventArgs e)
	{
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
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.AC_CODE As AcCodeL FROM LBR_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 0.0;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		//IL_0bc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcb: Expected O, but got Unknown
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Expected O, but got Unknown
		//IL_0a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a89: Expected O, but got Unknown
		//IL_0d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d66: Expected O, but got Unknown
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 62] + " : It Name";
		MSG_IDTL_CLEAR();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 1;
		checked
		{
			int num5 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num5; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 56]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29])))
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
					MSG_IDTL[num4, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
					MSG_IDTL[num4, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
					MSG_IDTL[num4, 17] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][17], (object)""));
					MSG_IDTL[num4, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
					MSG_IDTL[num4, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
					MSG_IDTL[num4, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
					MSG_IDTL[num4, 21] = Conversions.ToString(DtIdtl.Rows[i][21]);
					MSG_IDTL[num4, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
					MSG_IDTL[num4, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
					MSG_IDTL[num4, 24] = Conversions.ToString(DtIdtl.Rows[i][24]);
					MSG_IDTL[num4, 25] = Conversions.ToString(DtIdtl.Rows[i][25]);
					MSG_IDTL[num4, 26] = Conversions.ToString(DtIdtl.Rows[i][26]);
					MSG_IDTL[num4, 27] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][27], (object)""));
					MSG_IDTL[num4, 28] = Conversions.ToString(DtIdtl.Rows[i][28]);
					MSG_IDTL[num4, 29] = Conversions.ToString(DtIdtl.Rows[i][29]);
					num += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25]));
					num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26]));
					num3 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][27], (object)""));
					MSG_IDTL.Rows += 1;
					num4++;
				}
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 11] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 12] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - Conversion.Val(MSG[MSG.Row, 11])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 13] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 14] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - Conversion.Val(MSG[MSG.Row, 13])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 30] = Strings.Format((object)num, "0.00");
			}
			CommPassTotal();
			PicImage.Image = null;
			if ((Operators.CompareString(MSG[MSG.Row, 72], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 72] + "' AND IMAGE_TYPE = 'D'";
				DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
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
			}
			else
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 61];
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
				{
					try
					{
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 61]))) ?? "";
						DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
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
					}
				}
				else
				{
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 61]))) ?? "";
					DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
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
			}
			MSG_IDTL[num4, 0] = Conversions.ToString(num4);
			MSG_IDTL[num4, 29] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 56]));
		}
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
				DC_Main.RsQry = "SELECT VCH_NO FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_TAG_SPLIT_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
		}
		if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
		}
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
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.LC_CODE,A.AC_NAME";
				}
				else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
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
					DC_Main.MsGrCode = "10";
					MS_ACCT mS_ACCT = new MS_ACCT();
					((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)mS_ACCT).Show();
					((Control)mS_ACCT).Focus();
				}
				else
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tAcCode).Focus();
				}
				return;
			}
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
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
			DC_Main.MsAcAmtClBal = 0.0;
			if (Conversion.Val(nCrWt.Text) != 0.0 && Conversion.Val(nCrFine.Text) == 0.0)
			{
				nCrFine.Text = nCrWt.Text;
			}
			if (Conversion.Val(nDrWt.Text) != 0.0)
			{
				if (Conversion.Val(nDrFine.Text) == 0.0)
				{
					nDrFine.Text = nDrWt.Text;
				}
				((Control)nCrLbrAmt).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			((Control)tEmpCode).Focus();
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
				((Control)tEmpCode).Focus();
			}
		}
		else
		{
			tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void tVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM LBR_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 9;
		mSG2_TOTAL.Row = 0;
		mSG2_TOTAL.Cols = 6;
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
			mSG2_TOTAL[4] = (int)Math.Round(1500.0 * ColCon);
			mSG2_TOTAL[5] = 7;
			mSG2_TOTAL[5] = 0;
			ColorConverter colorConverter = new ColorConverter();
			mSG2_TOTAL.FillStyle = (FillStyleSettings)1;
			mSG2_TOTAL[8] = 0;
			DC_Main.i = 0;
			do
			{
				mSG2_TOTAL.Row = DC_Main.i;
				mSG2_TOTAL[DC_Main.i] = (int)Math.Round(300.0 * ColCon);
				switch (DC_Main.i)
				{
				case 1:
				case 7:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj9 = mSG2_TOTAL;
						object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
						obj9.CellBackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj11 = mSG2_TOTAL;
						object? obj12 = colorConverter.ConvertFromString("Cornsilk");
						obj11.CellBackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj13 = mSG2_TOTAL;
						object? obj14 = colorConverter.ConvertFromString("255, 224, 192");
						obj13.CellBackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
					}
					break;
				case 2:
				case 3:
				case 4:
				case 6:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj7 = mSG2_TOTAL;
					object? obj8 = colorConverter.ConvertFromString("DarkBlue");
					obj7.CellForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					break;
				}
				case 0:
				case 5:
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
			while (DC_Main.i <= 8);
			mSG2_TOTAL[0, 3] = "Payment    ";
			mSG2_TOTAL[0, 4] = "Received    ";
			mSG2_TOTAL[1, 0] = "Net Amt : ";
			mSG2_TOTAL[2, 0] = "Sale Tax : ";
			mSG2_TOTAL[3, 0] = "Total Amt : ";
			mSG2_TOTAL[4, 0] = "Cheque Amt : ";
			mSG2_TOTAL[5, 0] = "Card Amt : ";
			mSG2_TOTAL[6, 0] = "Cash Amt : ";
			mSG2_TOTAL[7, 0] = "Kasar Amt : ";
			mSG2_TOTAL[8, 0] = "Os Amt : ";
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
			((Control)TEXT_ENTRY_2).Focus();
			switch (MSG2_TOTAL.Col)
			{
			case 1:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 50;
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8))
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
				if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 2))
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
				if ((Operators.CompareString(DC_Main.MsEstmateBankLock, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) != 0))
				{
					if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 12;
				TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				if ((Operators.CompareString(DC_Main.MsEstmateBankLock, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) != 0))
				{
					if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
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
			if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
				break;
			}
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			BILL_TOTAL();
			break;
		case 3:
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			BILL_TOTAL();
			break;
		case 4:
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			BILL_TOTAL();
			break;
		}
		mSG2_TOTAL = null;
	}

	private void TEXT_ENTRY_2_TextChanged(object sender, EventArgs e)
	{
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
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
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
					if (((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 4)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 5)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '19','22','23')  ORDER BY A.AC_NAME";
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
									mSG2_TOTAL[mSG2_TOTAL.Row, 5] = DC_Main.ColValue[1];
									RowChang = true;
								}
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[mSG2_TOTAL.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
							if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 3;
								MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							}
							else
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 4;
								MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							}
							RowChang = true;
						}
						return;
					}
					if (mSG2_TOTAL.Row != 2)
					{
						break;
					}
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
									mSG2_TOTAL[2, 5] = DC_Main.ColValue[2];
									BILL_TOTAL();
								}
								else
								{
									TEXT_ENTRY_2.Text = "TAX FREE";
									mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
									mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
									mSG2_TOTAL[mSG2_TOTAL.Row, 5] = "00";
								}
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 4;
								mSG2_TOTAL.Col = 4;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
							double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 4;
							mSG2_TOTAL.Col = 4;
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
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = "00";
						}
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 4;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 6:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
					case 5:
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
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
						CommPassTotal();
						BILL_TOTAL();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					mSG2_TOTAL.Row += 1;
					mSG2_TOTAL.Col = 1;
					((Control)TEXT_ENTRY_2).Visible = true;
					((Control)TEXT_ENTRY_2).Focus();
					flag = false;
					break;
				case 4:
					switch (mSG2_TOTAL.Row)
					{
					case 6:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
					case 5:
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
							mSG2_TOTAL.Col = 4;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 7:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
						CommPassTotal();
						BILL_TOTAL();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
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
		double num = 0.0;
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		nCrWt.Text = "";
		nDrWt.Text = "";
		if (Conversion.Val(MSG_TOT[0, 12]) > Conversion.Val(MSG_PR_TOT[0, 13]))
		{
			nDrWt.Text = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 12]) - Conversion.Val(MSG_PR_TOT[0, 13])), "0.000");
		}
		if (Conversion.Val(MSG_TOT[0, 12]) < Conversion.Val(MSG_PR_TOT[0, 13]))
		{
			nCrWt.Text = Strings.Format((object)(Conversion.Val(MSG_PR_TOT[0, 13]) - Conversion.Val(MSG_TOT[0, 12])), "0.000");
		}
		if ((Conversion.Val(nCrWt.Text) != 0.0) & (Conversion.Val(nCrTouch.Text) != 0.0))
		{
			nCrFine.Text = Strings.Format((object)(Conversion.Val(nCrWt.Text) * Conversion.Val(nCrTouch.Text) / 100.0), "0.000");
		}
		else
		{
			nCrFine.Text = Strings.Format((object)Conversion.Val(nCrWt.Text), "0.000");
		}
		if ((Conversion.Val(nDrWt.Text) != 0.0) & (Conversion.Val(nDrTouch.Text) != 0.0))
		{
			nDrFine.Text = Strings.Format((object)(Conversion.Val(nDrWt.Text) * Conversion.Val(nDrTouch.Text) / 100.0), "0.000");
		}
		else
		{
			nDrFine.Text = Strings.Format((object)Conversion.Val(nDrWt.Text), "0.000");
		}
		if (CustOpAmt > 0.0)
		{
			CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[8, 4]);
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[8, 3]) - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[8, 4]));
		}
		else
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[8, 4]);
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

	private void tAcName_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcName).SelectionStart = 0;
		((TextBoxBase)tAcName).SelectionLength = Strings.Len(tAcName.Text);
		if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
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
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
		{
			if ((int)e.KeyCode == 13)
			{
				SendKeys.Send("{TAB}");
			}
			return;
		}
		if (MSG[1] == 0)
		{
			MSG.Col = 2;
		}
		else
		{
			MSG.Col = 1;
		}
		MSG.Row = 1;
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
	}

	private void TEXT_ENTRY_2_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
		((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c02: Expected O, but got Unknown
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3d: Expected O, but got Unknown
		if (MSG_PR.Row == 0 || !((RtnOldRow != MSG_PR.Row) & !MsgPrClear))
		{
			return;
		}
		RtnOldRow = MSG_PR.Row;
		lblItem.Text = MSG_PR[MSG_PR.Row, 63] + " : It Name";
		tHmId2.Text = MSG_PR[MSG_PR.Row, 77];
		tHmId3.Text = MSG_PR[MSG_PR.Row, 78];
		tHmId4.Text = MSG_PR[MSG_PR.Row, 79];
		nHmWt.Text = Strings.Format((object)Conversion.Val(MSG_PR[MSG_PR.Row, 80]), "0.000");
		nHmWt2.Text = Strings.Format((object)Conversion.Val(MSG_PR[MSG_PR.Row, 81]), "0.000");
		nHmWt3.Text = Strings.Format((object)Conversion.Val(MSG_PR[MSG_PR.Row, 82]), "0.000");
		nHmWt4.Text = Strings.Format((object)Conversion.Val(MSG_PR[MSG_PR.Row, 83]), "0.000");
		MSG_RTN_IDTL_CLEAR();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = 1;
		checked
		{
			int num6 = RtnIdtl.Rows.Count - 1;
			for (int i = 0; i <= num6; i++)
			{
				int num7 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][29])));
				int num8 = (int)Math.Round(Conversion.Val(MSG_PR[MSG_PR.Row, 57]));
				if (Conversion.Val(MSG_PR[MSG_PR.Row, 57]) == Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][29])))
				{
					MSG_RTN_IDTL[num5, 0] = Conversions.ToString(num5);
					MSG_RTN_IDTL[num5, 1] = Conversions.ToString(RtnIdtl.Rows[i][1]);
					MSG_RTN_IDTL[num5, 2] = Conversions.ToString(RtnIdtl.Rows[i][2]);
					MSG_RTN_IDTL[num5, 3] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][3], (object)""));
					MSG_RTN_IDTL[num5, 4] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][4], (object)""));
					MSG_RTN_IDTL[num5, 5] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][5], (object)""));
					MSG_RTN_IDTL[num5, 6] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][6], (object)""));
					MSG_RTN_IDTL[num5, 7] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][7], (object)""));
					MSG_RTN_IDTL[num5, 8] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][8], (object)""));
					MSG_RTN_IDTL[num5, 9] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][9], (object)""));
					MSG_RTN_IDTL[num5, 10] = Conversions.ToString(RtnIdtl.Rows[i][10]);
					MSG_RTN_IDTL[num5, 11] = Conversions.ToString(0);
					MSG_RTN_IDTL[num5, 16] = Conversions.ToString(RtnIdtl.Rows[i][16]);
					MSG_RTN_IDTL[num5, 12] = Conversions.ToString(RtnIdtl.Rows[i][12]);
					MSG_RTN_IDTL[num5, 13] = Conversions.ToString(RtnIdtl.Rows[i][13]);
					MSG_RTN_IDTL[num5, 14] = Conversions.ToString(RtnIdtl.Rows[i][14]);
					MSG_RTN_IDTL[num5, 15] = Conversions.ToString(RtnIdtl.Rows[i][15]);
					MSG_RTN_IDTL[num5, 17] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][17], (object)""));
					MSG_RTN_IDTL[num5, 18] = Conversions.ToString(RtnIdtl.Rows[i][18]);
					MSG_RTN_IDTL[num5, 19] = Conversions.ToString(RtnIdtl.Rows[i][19]);
					MSG_RTN_IDTL[num5, 20] = Conversions.ToString(RtnIdtl.Rows[i][20]);
					MSG_RTN_IDTL[num5, 21] = Conversions.ToString(RtnIdtl.Rows[i][21]);
					MSG_RTN_IDTL[num5, 22] = Conversions.ToString(RtnIdtl.Rows[i][22]);
					MSG_RTN_IDTL[num5, 23] = Conversions.ToString(RtnIdtl.Rows[i][23]);
					MSG_RTN_IDTL[num5, 24] = Conversions.ToString(RtnIdtl.Rows[i][24]);
					MSG_RTN_IDTL[num5, 25] = Conversions.ToString(RtnIdtl.Rows[i][25]);
					MSG_RTN_IDTL[num5, 26] = Conversions.ToString(RtnIdtl.Rows[i][26]);
					MSG_RTN_IDTL[num5, 27] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][27], (object)""));
					MSG_RTN_IDTL[num5, 28] = Conversions.ToString(RtnIdtl.Rows[i][28]);
					MSG_RTN_IDTL[num5, 29] = Conversions.ToString(RtnIdtl.Rows[i][29]);
					MSG_RTN_IDTL[num5, 30] = Conversions.ToString(RtnIdtl.Rows[i][30]);
					MSG_RTN_IDTL[num5, 31] = Conversions.ToString(RtnIdtl.Rows[i][31]);
					MSG_RTN_IDTL.Rows += 1;
					num5++;
				}
			}
			if (num2 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 12] = Strings.Format((object)num2, "0.000");
				MSG_PR[MSG_PR.Row, 13] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 11]) - Conversion.Val(MSG_PR[MSG_PR.Row, 12])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 14] = Strings.Format((object)num3, "0.000");
				MSG_PR[MSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 11]) - Conversion.Val(MSG_PR[MSG_PR.Row, 14])), "0.000");
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 31] = Strings.Format((object)num, "0.00");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 31] = Strings.Format((object)num, "0.00");
			}
			CommPassTotal_Pr(MSG_PR.Row);
			PictureBox1.Image = null;
			if ((Operators.CompareString(MSG_PR[MSG_PR.Row, 90], "N", false) != 0) & (Operators.CompareString(MSG_PR[MSG_PR.Row, 4], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG_PR[MSG_PR.Row, 90] + "' AND IMAGE_TYPE = 'D'";
				DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
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
					PictureBox1.Image = (Image)objectValue;
				}
			}
			else
			{
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG_PR[MSG_PR.Row, 2] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 62]))) ?? "";
				DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						PicImage.Image = null;
						return;
					}
					object obj2 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
					byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
					object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
					PictureBox1.Image = (Image)objectValue2;
				}
				else
				{
					if (Operators.CompareString(MSG_PR[MSG_PR.Row, 2], "", false) != 0)
					{
						DC_Main.MsImageNo = MSG_PR[MSG_PR.Row, 2] + "_" + MSG_PR[MSG_PR.Row, 62];
						DC_Main.MsImageType = "TagImage";
					}
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PictureBox1.Image = Image.FromFile(DC_Main.MsImagePath);
					}
					else
					{
						PictureBox1.Image = null;
					}
				}
			}
			MSG_RTN_IDTL[num5, 0] = Conversions.ToString(num5);
			MSG_RTN_IDTL[num5, 29] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 57]));
		}
	}

	private void tVchNo_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)tVchNo).ReadOnly = false;
	}

	private void TR_TAG_SPLIT_KeyUp(object sender, KeyEventArgs e)
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
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Invalid comparison between Unknown and I4
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Invalid comparison between Unknown and I4
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Invalid comparison between Unknown and I4
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Invalid comparison between Unknown and I4
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Invalid comparison between Unknown and I4
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_PR", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_PR).SelectionStart = 0;
			((TextBoxBase)TEXT_PR).SelectionLength = Strings.Len(TEXT_PR.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_RTN_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_RTN_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_RTN_IDTL).SelectionLength = Strings.Len(TEXT_RTN_IDTL.Text);
		}
	}

	private void nCrWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrWt.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nCrTouch_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrTouch.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrTouch.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nCrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrFine.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nCrLbrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrLbrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrLbrAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDrWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDrWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDrWt.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDrTouch_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDrTouch.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDrTouch.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDrFine.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void MSG_PR_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG_PR.LeftCol)
		{
			MSG_TOT.LeftCol = MSG_PR.LeftCol;
			MSG_TOT.ScrollTrack = MSG_PR.LeftCol != 0;
		}
		if (MSG.LeftCol != MSG_PR.LeftCol)
		{
			MSG.LeftCol = MSG_PR.LeftCol;
			MSG.ScrollTrack = MSG_PR.LeftCol != 0;
		}
		if (MSG_PR_TOT.LeftCol != MSG_PR.LeftCol)
		{
			MSG_PR_TOT.LeftCol = MSG_PR.LeftCol;
			MSG_PR_TOT.ScrollTrack = MSG_PR.LeftCol != 0;
		}
	}

	private void chkSameTag_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			DC_Main.MsTagVchSrnoUpdate = true;
		}
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void nHmWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nHmWt.Text, "", false) != 0)
			{
				nHmWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				HmDetlFeel();
				MSG_PR.Col = 9;
				MSG_PR.Row = MSG_PR.Row;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
		}
	}

	private void nHmWt2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId2.Text, "", false) != 0) & (Operators.CompareString(nHmWt2.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Insert HmId2 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(nHmWt2.Text, "", false) != 0)
			{
				nHmWt2.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt2.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				HmDetlFeel();
				MSG_PR.Col = 9;
				MSG_PR.Row = MSG_PR.Row;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
		}
	}

	private void nHmWt3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId3.Text, "", false) != 0) & (Operators.CompareString(nHmWt3.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Insert HmId3 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(nHmWt3.Text, "", false) != 0)
			{
				nHmWt3.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt3.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				HmDetlFeel();
				MSG_PR.Col = 9;
				MSG_PR.Row = MSG_PR.Row;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
		}
	}

	private void nHmWt4_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId4.Text, "", false) != 0) & (Operators.CompareString(nHmWt4.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Insert HmId4 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(nHmWt4.Text, "", false) != 0)
			{
				nHmWt4.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt4.Text)), "0.000");
				HmDetlFeel();
				MSG_PR.Col = 9;
				MSG_PR.Row = MSG_PR.Row;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
			else
			{
				HmDetlFeel();
				MSG_PR.Col = 9;
				MSG_PR.Row = MSG_PR.Row;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
		}
	}

	private void HmDetlFeel()
	{
		MSG_PR[MSG_PR.Row, 77] = tHmId2.Text;
		MSG_PR[MSG_PR.Row, 78] = tHmId3.Text;
		MSG_PR[MSG_PR.Row, 79] = tHmId4.Text;
		MSG_PR[MSG_PR.Row, 80] = nHmWt.Text;
		MSG_PR[MSG_PR.Row, 81] = nHmWt2.Text;
		MSG_PR[MSG_PR.Row, 82] = nHmWt3.Text;
		MSG_PR[MSG_PR.Row, 83] = nHmWt4.Text;
	}

	private void tHmId2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId2.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			HmDetlFeel();
			MSG_PR.Col = 9;
			MSG_PR.Row = MSG_PR.Row;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
	}

	private void tHmId3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId3.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			HmDetlFeel();
			MSG_PR.Col = 9;
			MSG_PR.Row = MSG_PR.Row;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
	}

	private void tHmId4_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			DC_Main.MsTagVchSrnoUpdate = true;
		}
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId4.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			HmDetlFeel();
			MSG_PR.Col = 9;
			MSG_PR.Row = MSG_PR.Row;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
	}

	private void btnVchPrint_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'I',AC_CODE,IT_CODE,'',TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,0,RATE_TYPE,IT_TYPE,LESS_TOUCH  FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'R',AC_CODE,IT_CODE,'',TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,0,RATE_TYPE,IT_TYPE,LESS_TOUCH  FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagSplitVch.RPT";
		Cr.SelectionFormula = "{LBR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LBR_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {LBR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LBR_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {LBR_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		Cr[(short)4] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
		Cr[(short)5] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
		Cr[(short)6] = ("OpSilver = " + Strings.Format((object)CustOpSilver, "0.00")) ?? "";
		Cr[(short)7] = ("ClSilver = " + Strings.Format((object)CustClSilver, "0.00")) ?? "";
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

	private void Label15_Click(object sender, EventArgs e)
	{
	}

	private void nHmWt_TextChanged(object sender, EventArgs e)
	{
	}

	private void nHmWt2_TextChanged(object sender, EventArgs e)
	{
	}
}
