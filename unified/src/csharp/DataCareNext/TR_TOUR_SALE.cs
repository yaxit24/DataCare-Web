using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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

namespace DataCareNext;

[DesignerGenerated]
public class TR_TOUR_SALE : Form
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
	[AccessedThroughProperty("nAcDrAmt")]
	private TextBox _nAcDrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcCrFine")]
	private TextBox _nAcCrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcCrAmt")]
	private TextBox _nAcCrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcDrFine")]
	private TextBox _nAcDrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineKsrDr")]
	private TextBox _nFineKsrDr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineKsrCr")]
	private TextBox _nFineKsrCr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineRate")]
	private TextBox _nFineRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDays")]
	private TextBox _nCrDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConvPrc")]
	private TextBox _nConvPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConvRate")]
	private TextBox _nConvRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkSilverCut")]
	private CheckBox _chkSilverCut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSlvrFineRate")]
	private TextBox _nSlvrFineRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSlvrDrAmt")]
	private TextBox _nSlvrDrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSlvrFineDr")]
	private TextBox _nSlvrFineDr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSlvrFineCr")]
	private TextBox _nSlvrFineCr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSlvrCrAmt")]
	private TextBox _nSlvrCrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nWestPrc")]
	private TextBox _nWestPrc;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private string CurRatePar;

	private DataTable VchOldData;

	private bool RowDelete;

	private double SlOthAmtLess;

	private double PrOthAmtLess;

	private double ToDayGlRate;

	private double ToDaySlRate;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private double OldAcCrAmt;

	private double OldAcDrAmt;

	private double OldAcCrFine;

	private double OldAcDrFine;

	private double OldFineRate;

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

	private double OldConRate;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsPrDetl;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private int MsgPrOldRow;

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

	private double SlSilverFine;

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItCode = 2;

	private const int cItName = 3;

	private const int cCounter = 4;

	private const int cDesign = 5;

	private const int cColor = 6;

	private const int cSize = 7;

	private const int cHmId = 8;

	private const int cBagWt = 9;

	private const int cPcs = 10;

	private const int cBagTot = 11;

	private const int cGrWt = 12;

	private const int cOthWt = 13;

	private const int cNetWt = 14;

	private const int cGhtPrc = 15;

	private const int cGhtWt = 16;

	private const int cTouch = 17;

	private const int cWestPrc = 18;

	private const int cLessTch = 19;

	private const int cLessWt = 20;

	private const int cHmFine = 21;

	private const int cFine = 22;

	private const int cNetFine = 23;

	private const int cSilverFine = 24;

	private const int cConvertRate = 25;

	private const int cConvertPrc = 26;

	private const int cItRate = 27;

	private const int cItAmt = 28;

	private const int cLbrPrc = 29;

	private const int cLbrType = 30;

	private const int cLbrRate = 31;

	private const int cLbrAmt = 32;

	private const int cOthAmt = 33;

	private const int cOthRate = 34;

	private const int cOthFine = 35;

	private const int cMrp = 36;

	private const int cNetAmt = 37;

	private const int cTotAmt = 38;

	private const int cTaxPrc = 39;

	private const int cKrName = 40;

	private const int cKrOthWt = 41;

	private const int cKrNetWt = 42;

	private const int cKrGhatPrc = 43;

	private const int cKrGhatWt = 44;

	private const int cKrTouch = 45;

	private const int cKrWestPrc = 46;

	private const int cKrFine = 47;

	private const int cKrLRate = 48;

	private const int cKrLAmt = 59;

	private const int cKrOthAmt = 50;

	private const int cPrCost = 51;

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

	private const int cEntryMod = 62;

	private const int cOldTagType = 63;

	private const int cOldPrCode = 64;

	private const int cOldGrWt = 65;

	private const int cOldNtWt = 66;

	private const int cOldGhatPrc = 67;

	private const int cOldGhatWt = 68;

	private const int cOldTouch = 69;

	private const int cOldWestPrc = 70;

	private const int cOldKrNetWt = 71;

	private const int cOldKrTouch = 72;

	private const int cOldKrWest = 73;

	private const int cOldOthWt = 74;

	private const int cIsuNo = 75;

	private const int cIsuYrCd = 76;

	private const int cIsuDbCd = 77;

	private const int cIsuSrNo = 78;

	private const int cOldItRate = 79;

	private const int cOldLessWt = 80;

	private const int cHmId2 = 81;

	private const int cHmId3 = 82;

	private const int cHmId4 = 83;

	private const int cHmIdWt = 84;

	private const int cHmId2Wt = 85;

	private const int cHmId3Wt = 86;

	private const int cHmId4wt = 87;

	private const int cProfitAmt = 88;

	private const int cProfitFine = 89;

	private const int cDesignImgId = 90;

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

	private const int c1KrWtShow = 12;

	private const int c1KrPrc = 13;

	private const int c1GrWt = 14;

	private const int c1ConPrc = 15;

	private const int c1RateType = 16;

	private const int c1ItRate = 17;

	private const int c1ItmAmt = 18;

	private const int c1LbrRate = 19;

	private const int c1LbrAmt = 20;

	private const int c1NetAmt = 21;

	private const int c1ConWt = 22;

	private const int c1KrWt = 23;

	private const int c1KrConWt = 24;

	private const int c1ItType = 25;

	private const int c1RowSr = 26;

	private const int c1OldGrWt = 27;

	private const int cTitel2 = 0;

	private const int cNetAmt2 = 1;

	private const int cChq2 = 2;

	private const int cCard2 = 3;

	private const int cOrder2 = 4;

	private const int cCash2 = 5;

	private const int cKasar2 = 6;

	private const int cOs2 = 7;

	private const int cTax2 = 8;

	private const int cTot2 = 9;

	private const int cPrSrNo = 0;

	private const int cPrItCode = 1;

	private const int cPrItName = 2;

	private const int cPrCounter = 3;

	private const int cPrDesign = 4;

	private const int cPrBagWt = 5;

	private const int cPrPcs = 6;

	private const int cPrPcsWt = 7;

	private const int cPrGrWt = 8;

	private const int cPrOthWt = 9;

	private const int cPrNetWt = 10;

	private const int cPrGhtWt = 11;

	private const int cPrTouch = 12;

	private const int cPrWestPrc = 13;

	private const int cPrLessTch = 14;

	private const int cPrFine = 15;

	private const int cPrNetFine = 16;

	private const int cPrSilverFine = 17;

	private const int cPrConvRate = 18;

	private const int cPrConvPrc = 19;

	private const int cPrRate = 20;

	private const int cPrItAmt = 21;

	private const int cPrLbrPrc = 22;

	private const int cPrLbrType = 23;

	private const int cPrLbrRate = 24;

	private const int cPrLbrAmt = 25;

	private const int cPrOthAmt = 26;

	private const int cPrOthRate = 27;

	private const int cPrOthFine = 28;

	private const int cPrMrp = 29;

	private const int cPrNetAmt = 30;

	private const int cPrHmFine = 31;

	private const int cPrTotAmt = 32;

	private const int cPrTaxPrc = 33;

	private const int cPrItType = 34;

	private const int cPrRateType = 35;

	private const int cPrOldGwt = 36;

	private const int cPrOldNwt = 37;

	private const int cPrOldTouch = 38;

	private const int cPrOldWest = 39;

	private const int cPrOldRate = 40;

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
			AxMSFlexGrid val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
			}
			_MSG_PR = value;
			val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
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
	[AccessedThroughProperty("nTotFineCr")]
	private virtual TextBox _nTotFineCr;

	internal virtual TextBox nTotFineCr
	{
		get
		{
			return _nTotFineCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotFineCr = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotFineDr")]
	private virtual TextBox _nTotFineDr;

	internal virtual TextBox nTotFineDr
	{
		get
		{
			return _nTotFineDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotFineDr = value;
		}
	}

	internal virtual TextBox nAcDrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nAcDrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcDrAmt_KeyDown);
			TextBox val2 = _nAcDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcDrAmt = value;
			val2 = _nAcDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nAcCrFine
	{
		[CompilerGenerated]
		get
		{
			return _nAcCrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcCrFine_KeyDown);
			TextBox val2 = _nAcCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcCrFine = value;
			val2 = _nAcCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nAcCrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nAcCrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcCrAmt_KeyDown);
			TextBox val2 = _nAcCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcCrAmt = value;
			val2 = _nAcCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nAcDrFine
	{
		[CompilerGenerated]
		get
		{
			return _nAcDrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcDrFine_KeyDown);
			TextBox val2 = _nAcDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcDrFine = value;
			val2 = _nAcDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nFineKsrDr
	{
		[CompilerGenerated]
		get
		{
			return _nFineKsrDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineKsrDr_KeyDown);
			TextBox val2 = _nFineKsrDr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineKsrDr = value;
			val2 = _nFineKsrDr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nFineKsrCr
	{
		[CompilerGenerated]
		get
		{
			return _nFineKsrCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineKsrCr_KeyDown);
			TextBox val2 = _nFineKsrCr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineKsrCr = value;
			val2 = _nFineKsrCr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDiffFine")]
	private virtual TextBox _nDiffFine;

	internal virtual TextBox nDiffFine
	{
		get
		{
			return _nDiffFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nDiffFine = value;
		}
	}

	internal virtual TextBox nFineRate
	{
		[CompilerGenerated]
		get
		{
			return _nFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineRate_KeyDown);
			TextBox val2 = _nFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineRate = value;
			val2 = _nFineRate;
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
	[AccessedThroughProperty("lblRate")]
	private virtual Label _lblRate;

	internal virtual Label lblRate
	{
		get
		{
			return _lblRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRate = value;
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
	[AccessedThroughProperty("lblDiffAmt")]
	private virtual Label _lblDiffAmt;

	internal virtual Label lblDiffAmt
	{
		get
		{
			return _lblDiffAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDiffAmt = value;
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
			EventHandler eventHandler = cboItemTyp_SelectedIndexChanged;
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
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
	[AccessedThroughProperty("LOpGold")]
	private virtual Label _LOpGold;

	internal virtual Label LOpGold
	{
		get
		{
			return _LOpGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpGold = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LOpSilver")]
	private virtual Label _LOpSilver;

	internal virtual Label LOpSilver
	{
		get
		{
			return _LOpSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpSilver = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LClSilver")]
	private virtual Label _LClSilver;

	internal virtual Label LClSilver
	{
		get
		{
			return _LClSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LClSilver = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lClGold")]
	private virtual Label _lClGold;

	internal virtual Label lClGold
	{
		get
		{
			return _lClGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lClGold = value;
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

	internal virtual TextBox nConvPrc
	{
		[CompilerGenerated]
		get
		{
			return _nConvPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nConvPrc_KeyDown);
			TextBox val2 = _nConvPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nConvPrc = value;
			val2 = _nConvPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nConvRate
	{
		[CompilerGenerated]
		get
		{
			return _nConvRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nConvRate_KeyDown);
			TextBox val2 = _nConvRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nConvRate = value;
			val2 = _nConvRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("chkItmImage")]
	private virtual CheckBox _chkItmImage;

	internal virtual CheckBox chkItmImage
	{
		get
		{
			return _chkItmImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkItmImage = value;
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

	internal virtual CheckBox chkSilverCut
	{
		[CompilerGenerated]
		get
		{
			return _chkSilverCut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkSilverCut_Click;
			CheckBox val = _chkSilverCut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkSilverCut = value;
			val = _chkSilverCut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlSilverCut")]
	private virtual Panel _PnlSilverCut;

	internal virtual Panel PnlSilverCut
	{
		get
		{
			return _PnlSilverCut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlSilverCut = value;
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
	[AccessedThroughProperty("nSlvrFinOs")]
	private virtual TextBox _nSlvrFinOs;

	internal virtual TextBox nSlvrFinOs
	{
		get
		{
			return _nSlvrFinOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nSlvrFinOs = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label34")]
	private virtual Label _Label34;

	internal virtual Label Label34
	{
		get
		{
			return _Label34;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label34 = value;
		}
	}

	internal virtual TextBox nSlvrFineRate
	{
		[CompilerGenerated]
		get
		{
			return _nSlvrFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSlvrFineRate_KeyDown);
			TextBox val2 = _nSlvrFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSlvrFineRate = value;
			val2 = _nSlvrFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("Label33")]
	private virtual Label _Label33;

	internal virtual Label Label33
	{
		get
		{
			return _Label33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label33 = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotSilverDr")]
	private virtual TextBox _nTotSilverDr;

	internal virtual TextBox nTotSilverDr
	{
		get
		{
			return _nTotSilverDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotSilverDr = value;
		}
	}

	internal virtual TextBox nSlvrDrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nSlvrDrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSlvrDrAmt_KeyDown);
			TextBox val2 = _nSlvrDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSlvrDrAmt = value;
			val2 = _nSlvrDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nSlvrFineDr
	{
		[CompilerGenerated]
		get
		{
			return _nSlvrFineDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSlvrFineDr_KeyDown);
			TextBox val2 = _nSlvrFineDr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSlvrFineDr = value;
			val2 = _nSlvrFineDr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nSlvrFineCr
	{
		[CompilerGenerated]
		get
		{
			return _nSlvrFineCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSlvrFineCr_KeyDown);
			TextBox val2 = _nSlvrFineCr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSlvrFineCr = value;
			val2 = _nSlvrFineCr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotSilverCr")]
	private virtual TextBox _nTotSilverCr;

	internal virtual TextBox nTotSilverCr
	{
		get
		{
			return _nTotSilverCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotSilverCr = value;
		}
	}

	internal virtual TextBox nSlvrCrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nSlvrCrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSlvrCrAmt_KeyDown);
			TextBox val2 = _nSlvrCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSlvrCrAmt = value;
			val2 = _nSlvrCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nWestPrc
	{
		[CompilerGenerated]
		get
		{
			return _nWestPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nWestPrc_KeyDown);
			EventHandler eventHandler = nWestPrc_TextChanged;
			TextBox val2 = _nWestPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nWestPrc = value;
			val2 = _nWestPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblWestPrc")]
	private virtual Label _lblWestPrc;

	internal virtual Label lblWestPrc
	{
		get
		{
			return _lblWestPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblWestPrc = value;
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
	[AccessedThroughProperty("pnlOthDetl")]
	private virtual Panel _pnlOthDetl;

	internal virtual Panel pnlOthDetl
	{
		get
		{
			return _pnlOthDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlOthDetl = value;
		}
	}

	public TR_TOUR_SALE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_TOUR_SALE_Load;
		((Form)this).Deactivate += TR_TOUR_SALE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_TOUR_SALE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_TOUR_SALE_KeyDown);
		((Form)this).Activated += TR_TOUR_SALE_Activated;
		((Form)this).Closed += TR_TOUR_SALE_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_TOUR_SALE_KeyUp);
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
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Expected O, but got Unknown
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0874: Expected O, but got Unknown
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Expected O, but got Unknown
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bd: Expected O, but got Unknown
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a62: Expected O, but got Unknown
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afb: Expected O, but got Unknown
		//IL_0b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b68: Expected O, but got Unknown
		//IL_0c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1b: Expected O, but got Unknown
		//IL_0c7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c88: Expected O, but got Unknown
		//IL_0d31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3b: Expected O, but got Unknown
		//IL_0e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e62: Expected O, but got Unknown
		//IL_0f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f77: Expected O, but got Unknown
		//IL_0fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe4: Expected O, but got Unknown
		//IL_1176: Unknown result type (might be due to invalid IL or missing references)
		//IL_128d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1297: Expected O, but got Unknown
		//IL_1342: Unknown result type (might be due to invalid IL or missing references)
		//IL_134c: Expected O, but got Unknown
		//IL_1404: Unknown result type (might be due to invalid IL or missing references)
		//IL_140e: Expected O, but got Unknown
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c8: Expected O, but got Unknown
		//IL_15c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ca: Expected O, but got Unknown
		//IL_16ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d8: Expected O, but got Unknown
		//IL_17a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ac: Expected O, but got Unknown
		//IL_1829: Unknown result type (might be due to invalid IL or missing references)
		//IL_1833: Expected O, but got Unknown
		//IL_18f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fe: Expected O, but got Unknown
		//IL_199d: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a7: Expected O, but got Unknown
		//IL_1a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa8: Expected O, but got Unknown
		//IL_1b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b13: Expected O, but got Unknown
		//IL_1c1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c29: Expected O, but got Unknown
		//IL_1d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0b: Expected O, but got Unknown
		//IL_1da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db1: Expected O, but got Unknown
		//IL_1eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef6: Expected O, but got Unknown
		//IL_1f41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4b: Expected O, but got Unknown
		//IL_1fc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd2: Expected O, but got Unknown
		//IL_2053: Unknown result type (might be due to invalid IL or missing references)
		//IL_205d: Expected O, but got Unknown
		//IL_2127: Unknown result type (might be due to invalid IL or missing references)
		//IL_2131: Expected O, but got Unknown
		//IL_21d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e2: Expected O, but got Unknown
		//IL_226c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2276: Expected O, but got Unknown
		//IL_22fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2305: Expected O, but got Unknown
		//IL_23b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c0: Expected O, but got Unknown
		//IL_2474: Unknown result type (might be due to invalid IL or missing references)
		//IL_247e: Expected O, but got Unknown
		//IL_2536: Unknown result type (might be due to invalid IL or missing references)
		//IL_2540: Expected O, but got Unknown
		//IL_25a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b1: Expected O, but got Unknown
		//IL_260c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2616: Expected O, but got Unknown
		//IL_26b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_26bf: Expected O, but got Unknown
		//IL_273d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2747: Expected O, but got Unknown
		//IL_27f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ff: Expected O, but got Unknown
		//IL_29eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f5: Expected O, but got Unknown
		//IL_2aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aac: Expected O, but got Unknown
		//IL_2b3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b45: Expected O, but got Unknown
		//IL_2bf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bfd: Expected O, but got Unknown
		//IL_2c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c96: Expected O, but got Unknown
		//IL_2d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d4e: Expected O, but got Unknown
		//IL_2dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e06: Expected O, but got Unknown
		//IL_2e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e9f: Expected O, but got Unknown
		//IL_2f2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f38: Expected O, but got Unknown
		//IL_2fc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fd0: Expected O, but got Unknown
		//IL_3093: Unknown result type (might be due to invalid IL or missing references)
		//IL_309d: Expected O, but got Unknown
		//IL_30f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3101: Expected O, but got Unknown
		//IL_31c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_31cb: Expected O, but got Unknown
		//IL_327f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3289: Expected O, but got Unknown
		//IL_3312: Unknown result type (might be due to invalid IL or missing references)
		//IL_331c: Expected O, but got Unknown
		//IL_33a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_33b2: Expected O, but got Unknown
		//IL_343b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3445: Expected O, but got Unknown
		//IL_34d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_34db: Expected O, but got Unknown
		//IL_3564: Unknown result type (might be due to invalid IL or missing references)
		//IL_356e: Expected O, but got Unknown
		//IL_35fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3604: Expected O, but got Unknown
		//IL_36b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_36c0: Expected O, but got Unknown
		//IL_3768: Unknown result type (might be due to invalid IL or missing references)
		//IL_3772: Expected O, but got Unknown
		//IL_382a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3834: Expected O, but got Unknown
		//IL_38ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_38f9: Expected O, but got Unknown
		//IL_39ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_39b7: Expected O, but got Unknown
		//IL_3a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a75: Expected O, but got Unknown
		//IL_3b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b30: Expected O, but got Unknown
		//IL_3be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3beb: Expected O, but got Unknown
		//IL_3c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ca6: Expected O, but got Unknown
		//IL_3d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d64: Expected O, but got Unknown
		//IL_3e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1f: Expected O, but got Unknown
		//IL_3ed3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3edd: Expected O, but got Unknown
		//IL_3f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f75: Expected O, but got Unknown
		//IL_4029: Unknown result type (might be due to invalid IL or missing references)
		//IL_4033: Expected O, but got Unknown
		//IL_40f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_40fd: Expected O, but got Unknown
		//IL_4166: Unknown result type (might be due to invalid IL or missing references)
		//IL_4170: Expected O, but got Unknown
		//IL_4221: Unknown result type (might be due to invalid IL or missing references)
		//IL_422b: Expected O, but got Unknown
		//IL_42df: Unknown result type (might be due to invalid IL or missing references)
		//IL_42e9: Expected O, but got Unknown
		//IL_439d: Unknown result type (might be due to invalid IL or missing references)
		//IL_43a7: Expected O, but got Unknown
		//IL_445b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4465: Expected O, but got Unknown
		//IL_451c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4526: Expected O, but got Unknown
		//IL_45dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_45e7: Expected O, but got Unknown
		//IL_469b: Unknown result type (might be due to invalid IL or missing references)
		//IL_46a5: Expected O, but got Unknown
		//IL_4747: Unknown result type (might be due to invalid IL or missing references)
		//IL_4751: Expected O, but got Unknown
		//IL_47f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4803: Expected O, but got Unknown
		//IL_48be: Unknown result type (might be due to invalid IL or missing references)
		//IL_48c8: Expected O, but got Unknown
		//IL_4980: Unknown result type (might be due to invalid IL or missing references)
		//IL_498a: Expected O, but got Unknown
		//IL_4a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a36: Expected O, but got Unknown
		//IL_4ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cf0: Expected O, but got Unknown
		//IL_4d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4da5: Expected O, but got Unknown
		//IL_4e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e61: Expected O, but got Unknown
		//IL_4f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f19: Expected O, but got Unknown
		//IL_4fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_4fc8: Expected O, but got Unknown
		//IL_5079: Unknown result type (might be due to invalid IL or missing references)
		//IL_5083: Expected O, but got Unknown
		//IL_5131: Unknown result type (might be due to invalid IL or missing references)
		//IL_513b: Expected O, but got Unknown
		//IL_51ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_51f6: Expected O, but got Unknown
		//IL_52ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_52b8: Expected O, but got Unknown
		//IL_536c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5376: Expected O, but got Unknown
		//IL_5420: Unknown result type (might be due to invalid IL or missing references)
		//IL_542a: Expected O, but got Unknown
		//IL_54c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_54cd: Expected O, but got Unknown
		//IL_5553: Unknown result type (might be due to invalid IL or missing references)
		//IL_555d: Expected O, but got Unknown
		//IL_55e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_55f0: Expected O, but got Unknown
		//IL_5679: Unknown result type (might be due to invalid IL or missing references)
		//IL_5683: Expected O, but got Unknown
		//IL_5719: Unknown result type (might be due to invalid IL or missing references)
		//IL_5723: Expected O, but got Unknown
		//IL_57ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_57b6: Expected O, but got Unknown
		//IL_5851: Unknown result type (might be due to invalid IL or missing references)
		//IL_585b: Expected O, but got Unknown
		//IL_5916: Unknown result type (might be due to invalid IL or missing references)
		//IL_5920: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_TOUR_SALE));
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
		FlowLayoutPanel1 = new FlowLayoutPanel();
		chkHuIdPrint = new CheckBox();
		chkWapp = new CheckBox();
		nItProfit = new Label();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		chkItmImage = new CheckBox();
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
		MSG_PR_TOT = new AxMSFlexGrid();
		nTotFineCr = new TextBox();
		nTotFineDr = new TextBox();
		nAcDrAmt = new TextBox();
		nAcCrFine = new TextBox();
		nAcCrAmt = new TextBox();
		nAcDrFine = new TextBox();
		nFineKsrDr = new TextBox();
		nFineKsrCr = new TextBox();
		nDiffFine = new TextBox();
		nFineRate = new TextBox();
		Label5 = new Label();
		Label12 = new Label();
		Label14 = new Label();
		Label15 = new Label();
		Label16 = new Label();
		Label17 = new Label();
		Label18 = new Label();
		Label19 = new Label();
		Label20 = new Label();
		lblRate = new Label();
		nCrDays = new TextBox();
		Label22 = new Label();
		lblDiffAmt = new Label();
		cboItemTyp = new ComboBox();
		Label7 = new Label();
		LOpAmt = new Label();
		LOpGold = new Label();
		LOpSilver = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		nConvPrc = new TextBox();
		nConvRate = new TextBox();
		Label21 = new Label();
		Label23 = new Label();
		nBillProfit = new TextBox();
		chkSilverCut = new CheckBox();
		PnlSilverCut = new Panel();
		Label32 = new Label();
		nSlvrFinOs = new TextBox();
		Label34 = new Label();
		nSlvrFineRate = new TextBox();
		Label29 = new Label();
		Label28 = new Label();
		Label27 = new Label();
		Label33 = new Label();
		Label30 = new Label();
		Label31 = new Label();
		nTotSilverDr = new TextBox();
		nSlvrDrAmt = new TextBox();
		nSlvrFineDr = new TextBox();
		nSlvrFineCr = new TextBox();
		nTotSilverCr = new TextBox();
		nSlvrCrAmt = new TextBox();
		nWestPrc = new TextBox();
		lblWestPrc = new Label();
		lblItStock = new Label();
		pnlOthDetl = new Panel();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((Control)PnlSilverCut).SuspendLayout();
		((Control)pnlOthDetl).SuspendLayout();
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
		lblBook.Text = "Tour Sales";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(290, 37);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(216, 38);
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
		((Control)tVchNo).Location = new Point(91, 37);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(461, 37);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(372, 37);
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
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 22;
		((Control)FlowLayoutPanel1).BackColor = Color.Transparent;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkHuIdPrint);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)nItProfit);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkHuIdPrint).BackColor = Color.Transparent;
		((Control)chkHuIdPrint).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHuIdPrint).ForeColor = Color.Black;
		((Control)chkHuIdPrint).Location = new Point(490, 3);
		((Control)chkHuIdPrint).Name = "chkHuIdPrint";
		((Control)chkHuIdPrint).RightToLeft = (RightToLeft)0;
		((Control)chkHuIdPrint).Size = new Size(82, 27);
		((Control)chkHuIdPrint).TabIndex = 4;
		((ButtonBase)chkHuIdPrint).Text = "HuId Prn";
		((ButtonBase)chkHuIdPrint).UseVisualStyleBackColor = false;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(417, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(67, 27);
		((Control)chkWapp).TabIndex = 7;
		((ButtonBase)chkWapp).Text = "Wapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
		((Control)nItProfit).BackColor = Color.Transparent;
		((Control)nItProfit).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)nItProfit).ForeColor = Color.White;
		nItProfit.ImeMode = (ImeMode)0;
		((Control)nItProfit).Location = new Point(6, 0);
		((Control)nItProfit).Name = "nItProfit";
		((Control)nItProfit).Size = new Size(405, 33);
		((Control)nItProfit).TabIndex = 1164;
		nItProfit.Text = "It Profit :";
		nItProfit.TextAlign = (ContentAlignment)16;
		((Control)nItProfit).Visible = false;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(199, 3);
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
		((Control)BtnFirst).Location = new Point(152, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 6;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((ButtonBase)chkItmImage).BackColor = Color.Transparent;
		((Control)chkItmImage).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItmImage).ForeColor = Color.Black;
		((Control)chkItmImage).Location = new Point(1227, 521);
		((Control)chkItmImage).Name = "chkItmImage";
		((Control)chkItmImage).RightToLeft = (RightToLeft)0;
		((Control)chkItmImage).Size = new Size(70, 22);
		((Control)chkItmImage).TabIndex = 30;
		((ButtonBase)chkItmImage).Text = "Itm Img";
		((ButtonBase)chkItmImage).UseVisualStyleBackColor = false;
		((Control)chkItmImage).Visible = false;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(553, 158);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 7;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(863, 69);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(306, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(234, 53);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 0;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(6, 4);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(892, 107);
		((Control)MSG_IDTL).TabIndex = 1;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(375, 482);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(90, 79);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 261);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 94);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1162, 166);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1181, 521);
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
		((Control)BtnF1).Location = new Point(173, 37);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 477);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(290, 66);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 5;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(372, 66);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(360, 23);
		((Control)tAcName).TabIndex = 5;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(212, 67);
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
		((Control)tEmpCode).Location = new Point(795, 38);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((TextBoxBase)tEmpCode).ReadOnly = true;
		((Control)tEmpCode).Size = new Size(62, 23);
		((Control)tEmpCode).TabIndex = 3;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(863, 38);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(208, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(738, 39);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(51, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Emp";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(384, 427);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(73, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(464, 429);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(160, 48);
		((Control)tVchDesc).TabIndex = 21;
		((Control)MSG2_TOTAL).Location = new Point(633, 398);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(541, 161);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(12, 282);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1030, 90);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(942, 450);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 19;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(408, 326);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 9;
		((Control)TEXT_PR).Visible = false;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(28, 67);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(91, 66);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
		((Control)tBillNo).TabIndex = 4;
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
		((Control)PanelAdd).Location = new Point(1181, 94);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 152);
		((Control)PanelAdd).TabIndex = 6;
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
		((Control)MSG_PR_TOT).Location = new Point(16, 375);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(1026, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		((TextBoxBase)nTotFineCr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotFineCr).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nTotFineCr).ForeColor = Color.FromArgb(0, 0, 192);
		((Control)nTotFineCr).Location = new Point(95, 398);
		((TextBoxBase)nTotFineCr).MaxLength = 10;
		((Control)nTotFineCr).Name = "nTotFineCr";
		((TextBoxBase)nTotFineCr).ReadOnly = true;
		((Control)nTotFineCr).Size = new Size(90, 22);
		((Control)nTotFineCr).TabIndex = 1180;
		nTotFineCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nTotFineDr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotFineDr).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nTotFineDr).ForeColor = Color.FromArgb(0, 0, 192);
		((Control)nTotFineDr).Location = new Point(279, 398);
		((TextBoxBase)nTotFineDr).MaxLength = 10;
		((Control)nTotFineDr).Name = "nTotFineDr";
		((TextBoxBase)nTotFineDr).ReadOnly = true;
		((Control)nTotFineDr).Size = new Size(90, 22);
		((Control)nTotFineDr).TabIndex = 1181;
		nTotFineDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcDrAmt).BackColor = Color.White;
		((Control)nAcDrAmt).Font = new Font("Tahoma", 9f);
		((Control)nAcDrAmt).Location = new Point(95, 426);
		((TextBoxBase)nAcDrAmt).MaxLength = 10;
		((Control)nAcDrAmt).Name = "nAcDrAmt";
		((Control)nAcDrAmt).Size = new Size(90, 22);
		((Control)nAcDrAmt).TabIndex = 10;
		nAcDrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcCrFine).BackColor = Color.White;
		((Control)nAcCrFine).Font = new Font("Tahoma", 9f);
		((Control)nAcCrFine).Location = new Point(279, 426);
		((TextBoxBase)nAcCrFine).MaxLength = 10;
		((Control)nAcCrFine).Name = "nAcCrFine";
		((Control)nAcCrFine).Size = new Size(90, 22);
		((Control)nAcCrFine).TabIndex = 11;
		nAcCrFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcCrAmt).BackColor = Color.White;
		((Control)nAcCrAmt).Font = new Font("Tahoma", 9f);
		((Control)nAcCrAmt).Location = new Point(95, 455);
		((TextBoxBase)nAcCrAmt).MaxLength = 10;
		((Control)nAcCrAmt).Name = "nAcCrAmt";
		((Control)nAcCrAmt).Size = new Size(90, 22);
		((Control)nAcCrAmt).TabIndex = 12;
		nAcCrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcDrFine).BackColor = Color.White;
		((Control)nAcDrFine).Font = new Font("Tahoma", 9f);
		((Control)nAcDrFine).Location = new Point(279, 455);
		((TextBoxBase)nAcDrFine).MaxLength = 10;
		((Control)nAcDrFine).Name = "nAcDrFine";
		((Control)nAcDrFine).Size = new Size(90, 22);
		((Control)nAcDrFine).TabIndex = 13;
		nAcDrFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nFineKsrDr).BackColor = Color.Honeydew;
		((Control)nFineKsrDr).Font = new Font("Tahoma", 9f);
		((Control)nFineKsrDr).Location = new Point(95, 483);
		((TextBoxBase)nFineKsrDr).MaxLength = 10;
		((Control)nFineKsrDr).Name = "nFineKsrDr";
		((Control)nFineKsrDr).Size = new Size(90, 22);
		((Control)nFineKsrDr).TabIndex = 14;
		nFineKsrDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nFineKsrCr).BackColor = Color.Honeydew;
		((Control)nFineKsrCr).Font = new Font("Tahoma", 9f);
		((Control)nFineKsrCr).Location = new Point(279, 483);
		((TextBoxBase)nFineKsrCr).MaxLength = 10;
		((Control)nFineKsrCr).Name = "nFineKsrCr";
		((Control)nFineKsrCr).Size = new Size(90, 22);
		((Control)nFineKsrCr).TabIndex = 15;
		nFineKsrCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nDiffFine).BackColor = Color.Lavender;
		((Control)nDiffFine).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nDiffFine).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nDiffFine).Location = new Point(95, 539);
		((TextBoxBase)nDiffFine).MaxLength = 10;
		((Control)nDiffFine).Name = "nDiffFine";
		((TextBoxBase)nDiffFine).ReadOnly = true;
		((Control)nDiffFine).Size = new Size(90, 22);
		((Control)nDiffFine).TabIndex = 1188;
		nDiffFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nFineRate).BackColor = Color.Lavender;
		((Control)nFineRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nFineRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nFineRate).Location = new Point(279, 539);
		((TextBoxBase)nFineRate).MaxLength = 10;
		((Control)nFineRate).Name = "nFineRate";
		((Control)nFineRate).Size = new Size(90, 22);
		((Control)nFineRate).TabIndex = 18;
		nFineRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.FromArgb(192, 0, 0);
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(10, 400);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1190;
		Label5.Text = "Tot Fine Cr";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.FromArgb(192, 0, 0);
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(195, 400);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(79, 20);
		((Control)Label12).TabIndex = 1191;
		Label12.Text = "Tot Fine Dr";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(195, 428);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(79, 20);
		((Control)Label14).TabIndex = 1192;
		Label14.Text = "Ac Fine Cr";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label15).BackColor = Color.Transparent;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(195, 456);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(79, 20);
		((Control)Label15).TabIndex = 1193;
		Label15.Text = "Ac Fine Dr";
		Label15.TextAlign = (ContentAlignment)64;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(10, 428);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(79, 20);
		((Control)Label16).TabIndex = 1194;
		Label16.Text = "Ac Amt Dr";
		Label16.TextAlign = (ContentAlignment)64;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(10, 456);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(79, 20);
		((Control)Label17).TabIndex = 1195;
		Label17.Text = "Ac Amt Cr";
		Label17.TextAlign = (ContentAlignment)64;
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(10, 484);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(79, 20);
		((Control)Label18).TabIndex = 1196;
		Label18.Text = "Ksr Fine Dr";
		Label18.TextAlign = (ContentAlignment)64;
		((Control)Label19).BackColor = Color.Transparent;
		((Control)Label19).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(195, 484);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(79, 20);
		((Control)Label19).TabIndex = 1197;
		Label19.Text = "Ksr Fine Cr";
		Label19.TextAlign = (ContentAlignment)64;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Navy;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(11, 541);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(79, 20);
		((Control)Label20).TabIndex = 1198;
		Label20.Text = "Os Fine";
		Label20.TextAlign = (ContentAlignment)64;
		((Control)lblRate).BackColor = Color.Transparent;
		((Control)lblRate).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRate).ForeColor = Color.Navy;
		lblRate.ImeMode = (ImeMode)0;
		((Control)lblRate).Location = new Point(195, 539);
		((Control)lblRate).Name = "lblRate";
		((Control)lblRate).Size = new Size(79, 20);
		((Control)lblRate).TabIndex = 1199;
		lblRate.Text = "Fine Rate";
		lblRate.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(464, 400);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(44, 23);
		((Control)nCrDays).TabIndex = 20;
		nCrDays.TextAlign = (HorizontalAlignment)2;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(388, 401);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(69, 20);
		((Control)Label22).TabIndex = 1201;
		Label22.Text = "Cr Days";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)lblDiffAmt).BackColor = Color.Transparent;
		((Control)lblDiffAmt).Font = new Font("Arial", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblDiffAmt).ForeColor = Color.Maroon;
		lblDiffAmt.ImeMode = (ImeMode)0;
		((Control)lblDiffAmt).Location = new Point(519, 398);
		((Control)lblDiffAmt).Name = "lblDiffAmt";
		((Control)lblDiffAmt).Size = new Size(109, 20);
		((Control)lblDiffAmt).TabIndex = 1202;
		lblDiffAmt.Text = "Diff Amount";
		lblDiffAmt.TextAlign = (ContentAlignment)64;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(629, 38);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(103, 22);
		((Control)cboItemTyp).TabIndex = 2;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(549, 38);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(74, 20);
		((Control)Label7).TabIndex = 1204;
		Label7.Text = "Item Type";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1051, 291);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(122, 20);
		((Control)LOpAmt).TabIndex = 1205;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(1054, 324);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(119, 20);
		((Control)LOpGold).TabIndex = 1206;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(1054, 356);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(119, 20);
		((Control)LOpSilver).TabIndex = 1207;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(489, 539);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(132, 20);
		((Control)LClSilver).TabIndex = 1210;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(489, 513);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(132, 20);
		((Control)lClGold).TabIndex = 1209;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(486, 487);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(135, 20);
		((Control)LClAmt).TabIndex = 1208;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nConvPrc).BackColor = Color.Beige;
		((Control)nConvPrc).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nConvPrc).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nConvPrc).Location = new Point(95, 511);
		((TextBoxBase)nConvPrc).MaxLength = 10;
		((Control)nConvPrc).Name = "nConvPrc";
		((Control)nConvPrc).Size = new Size(90, 22);
		((Control)nConvPrc).TabIndex = 16;
		nConvPrc.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nConvRate).BackColor = Color.Beige;
		((Control)nConvRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nConvRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nConvRate).Location = new Point(279, 511);
		((TextBoxBase)nConvRate).MaxLength = 10;
		((Control)nConvRate).Name = "nConvRate";
		((Control)nConvRate).Size = new Size(90, 22);
		((Control)nConvRate).TabIndex = 17;
		nConvRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.FromArgb(192, 0, 0);
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(195, 513);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(79, 20);
		((Control)Label21).TabIndex = 1213;
		Label21.Text = "Convrt Rate";
		Label21.TextAlign = (ContentAlignment)64;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.FromArgb(192, 0, 0);
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(10, 513);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(79, 20);
		((Control)Label23).TabIndex = 1214;
		Label23.Text = "Conv %";
		Label23.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nBillProfit).BackColor = Color.White;
		((Control)nBillProfit).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nBillProfit).Location = new Point(1181, 445);
		((TextBoxBase)nBillProfit).MaxLength = 10;
		((Control)nBillProfit).Name = "nBillProfit";
		((Control)nBillProfit).Size = new Size(159, 23);
		((Control)nBillProfit).TabIndex = 1229;
		nBillProfit.TextAlign = (HorizontalAlignment)1;
		((Control)nBillProfit).Visible = false;
		((ButtonBase)chkSilverCut).BackColor = Color.Transparent;
		((Control)chkSilverCut).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkSilverCut).ForeColor = Color.Black;
		((Control)chkSilverCut).Location = new Point(1215, 482);
		((Control)chkSilverCut).Name = "chkSilverCut";
		((Control)chkSilverCut).RightToLeft = (RightToLeft)0;
		((Control)chkSilverCut).Size = new Size(72, 22);
		((Control)chkSilverCut).TabIndex = 19;
		((ButtonBase)chkSilverCut).Text = "Slvr Cut";
		((ButtonBase)chkSilverCut).UseVisualStyleBackColor = false;
		((Control)chkSilverCut).Visible = false;
		((Control)PnlSilverCut).BackColor = Color.SeaShell;
		PnlSilverCut.BorderStyle = (BorderStyle)2;
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label32);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nSlvrFinOs);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label34);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nSlvrFineRate);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label29);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label28);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label27);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label33);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label30);
		((Control)PnlSilverCut).Controls.Add((Control)(object)Label31);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nTotSilverDr);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nSlvrDrAmt);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nSlvrFineDr);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nSlvrFineCr);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nTotSilverCr);
		((Control)PnlSilverCut).Controls.Add((Control)(object)nSlvrCrAmt);
		((Control)PnlSilverCut).Location = new Point(1181, 252);
		((Control)PnlSilverCut).Name = "PnlSilverCut";
		((Control)PnlSilverCut).Size = new Size(389, 169);
		((Control)PnlSilverCut).TabIndex = 1231;
		((Control)PnlSilverCut).Visible = false;
		((Control)Label32).BackColor = Color.Transparent;
		((Control)Label32).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label32).ForeColor = Color.Blue;
		Label32.ImeMode = (ImeMode)0;
		((Control)Label32).Location = new Point(-2, 109);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(79, 20);
		((Control)Label32).TabIndex = 1220;
		Label32.Text = "Sl Os Fine";
		Label32.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nSlvrFinOs).BackColor = Color.Lavender;
		((Control)nSlvrFinOs).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nSlvrFinOs).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nSlvrFinOs).Location = new Point(82, 107);
		((TextBoxBase)nSlvrFinOs).MaxLength = 10;
		((Control)nSlvrFinOs).Name = "nSlvrFinOs";
		((TextBoxBase)nSlvrFinOs).ReadOnly = true;
		((Control)nSlvrFinOs).Size = new Size(90, 22);
		((Control)nSlvrFinOs).TabIndex = 1219;
		nSlvrFinOs.TextAlign = (HorizontalAlignment)1;
		((Control)Label34).BackColor = Color.Transparent;
		((Control)Label34).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label34).ForeColor = Color.Blue;
		Label34.ImeMode = (ImeMode)0;
		((Control)Label34).Location = new Point(178, 109);
		((Control)Label34).Name = "Label34";
		((Control)Label34).Size = new Size(90, 20);
		((Control)Label34).TabIndex = 1218;
		Label34.Text = "Sl Fine Rate";
		Label34.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nSlvrFineRate).BackColor = Color.Lavender;
		((Control)nSlvrFineRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nSlvrFineRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nSlvrFineRate).Location = new Point(273, 107);
		((TextBoxBase)nSlvrFineRate).MaxLength = 10;
		((Control)nSlvrFineRate).Name = "nSlvrFineRate";
		((Control)nSlvrFineRate).Size = new Size(90, 22);
		((Control)nSlvrFineRate).TabIndex = 24;
		nSlvrFineRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label29).BackColor = Color.Transparent;
		((Control)Label29).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label29).ForeColor = Color.Black;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(200, 80);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(67, 20);
		((Control)Label29).TabIndex = 1195;
		Label29.Text = "Sl Fine Dr";
		Label29.TextAlign = (ContentAlignment)64;
		((Control)Label28).BackColor = Color.Transparent;
		((Control)Label28).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label28).ForeColor = Color.Black;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(9, 80);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(67, 20);
		((Control)Label28).TabIndex = 1194;
		Label28.Text = "Sl Amt Cr";
		Label28.TextAlign = (ContentAlignment)64;
		((Control)Label27).BackColor = Color.Transparent;
		((Control)Label27).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label27).ForeColor = Color.Black;
		Label27.ImeMode = (ImeMode)0;
		((Control)Label27).Location = new Point(200, 52);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(67, 20);
		((Control)Label27).TabIndex = 1193;
		Label27.Text = "Sl Fine Cr";
		Label27.TextAlign = (ContentAlignment)64;
		((Control)Label33).BackColor = Color.Transparent;
		((Control)Label33).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label33).ForeColor = Color.FromArgb(192, 0, 0);
		Label33.ImeMode = (ImeMode)0;
		((Control)Label33).Location = new Point(189, 23);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(79, 20);
		((Control)Label33).TabIndex = 1192;
		Label33.Text = "Slvr Fin Dr";
		Label33.TextAlign = (ContentAlignment)64;
		((Control)Label30).BackColor = Color.Transparent;
		((Control)Label30).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label30).ForeColor = Color.FromArgb(192, 0, 0);
		Label30.ImeMode = (ImeMode)0;
		((Control)Label30).Location = new Point(3, 23);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(76, 19);
		((Control)Label30).TabIndex = 1191;
		Label30.Text = "Slvr Fin Cr";
		Label30.TextAlign = (ContentAlignment)64;
		((Control)Label31).BackColor = Color.Transparent;
		((Control)Label31).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label31).ForeColor = Color.Black;
		Label31.ImeMode = (ImeMode)0;
		((Control)Label31).Location = new Point(3, 52);
		((Control)Label31).Name = "Label31";
		((Control)Label31).Size = new Size(73, 20);
		((Control)Label31).TabIndex = 1187;
		Label31.Text = "Sl Amt Dr";
		Label31.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nTotSilverDr).BackColor = Color.Lavender;
		((Control)nTotSilverDr).Font = new Font("Tahoma", 9f);
		((Control)nTotSilverDr).Location = new Point(273, 22);
		((TextBoxBase)nTotSilverDr).MaxLength = 10;
		((Control)nTotSilverDr).Name = "nTotSilverDr";
		((TextBoxBase)nTotSilverDr).ReadOnly = true;
		((Control)nTotSilverDr).Size = new Size(90, 22);
		((Control)nTotSilverDr).TabIndex = 1180;
		nTotSilverDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nSlvrDrAmt).BackColor = Color.White;
		((Control)nSlvrDrAmt).Font = new Font("Tahoma", 9f);
		((Control)nSlvrDrAmt).Location = new Point(82, 49);
		((TextBoxBase)nSlvrDrAmt).MaxLength = 10;
		((Control)nSlvrDrAmt).Name = "nSlvrDrAmt";
		((Control)nSlvrDrAmt).Size = new Size(90, 22);
		((Control)nSlvrDrAmt).TabIndex = 22;
		nSlvrDrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nSlvrFineDr).BackColor = Color.White;
		((Control)nSlvrFineDr).Font = new Font("Tahoma", 9f);
		((Control)nSlvrFineDr).Location = new Point(273, 78);
		((TextBoxBase)nSlvrFineDr).MaxLength = 10;
		((Control)nSlvrFineDr).Name = "nSlvrFineDr";
		((Control)nSlvrFineDr).Size = new Size(90, 22);
		((Control)nSlvrFineDr).TabIndex = 21;
		nSlvrFineDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nSlvrFineCr).BackColor = Color.White;
		((Control)nSlvrFineCr).Font = new Font("Tahoma", 9f);
		((Control)nSlvrFineCr).Location = new Point(273, 50);
		((TextBoxBase)nSlvrFineCr).MaxLength = 10;
		((Control)nSlvrFineCr).Name = "nSlvrFineCr";
		((Control)nSlvrFineCr).Size = new Size(90, 22);
		((Control)nSlvrFineCr).TabIndex = 20;
		nSlvrFineCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nTotSilverCr).BackColor = Color.Lavender;
		((Control)nTotSilverCr).Font = new Font("Tahoma", 9f);
		((Control)nTotSilverCr).Location = new Point(82, 21);
		((TextBoxBase)nTotSilverCr).MaxLength = 10;
		((Control)nTotSilverCr).Name = "nTotSilverCr";
		((TextBoxBase)nTotSilverCr).ReadOnly = true;
		((Control)nTotSilverCr).Size = new Size(90, 22);
		((Control)nTotSilverCr).TabIndex = 1172;
		nTotSilverCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nSlvrCrAmt).BackColor = Color.White;
		((Control)nSlvrCrAmt).Font = new Font("Tahoma", 9f);
		((Control)nSlvrCrAmt).Location = new Point(82, 77);
		((TextBoxBase)nSlvrCrAmt).MaxLength = 10;
		((Control)nSlvrCrAmt).Name = "nSlvrCrAmt";
		((Control)nSlvrCrAmt).Size = new Size(90, 22);
		((Control)nSlvrCrAmt).TabIndex = 23;
		nSlvrCrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nWestPrc).BackColor = Color.White;
		((Control)nWestPrc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nWestPrc).Location = new Point(796, 65);
		((TextBoxBase)nWestPrc).MaxLength = 6;
		((Control)nWestPrc).Name = "nWestPrc";
		((Control)nWestPrc).Size = new Size(61, 23);
		((Control)nWestPrc).TabIndex = 1232;
		nWestPrc.TextAlign = (HorizontalAlignment)2;
		((Control)nWestPrc).Visible = false;
		((Control)lblWestPrc).BackColor = Color.Transparent;
		((Control)lblWestPrc).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblWestPrc).ForeColor = Color.Black;
		lblWestPrc.ImeMode = (ImeMode)0;
		((Control)lblWestPrc).Location = new Point(738, 68);
		((Control)lblWestPrc).Name = "lblWestPrc";
		((Control)lblWestPrc).Size = new Size(52, 20);
		((Control)lblWestPrc).TabIndex = 1233;
		lblWestPrc.Text = "West%";
		lblWestPrc.TextAlign = (ContentAlignment)64;
		((Control)lblWestPrc).Visible = false;
		((Control)lblItStock).BackColor = Color.Transparent;
		((Control)lblItStock).Font = new Font("Tahoma", 9f);
		((Control)lblItStock).ForeColor = Color.Blue;
		lblItStock.ImeMode = (ImeMode)0;
		((Control)lblItStock).Location = new Point(22, 376);
		((Control)lblItStock).Name = "lblItStock";
		((Control)lblItStock).Size = new Size(259, 20);
		((Control)lblItStock).TabIndex = 1234;
		lblItStock.Text = "Itm Stock :";
		lblItStock.TextAlign = (ContentAlignment)16;
		((Control)pnlOthDetl).Controls.Add((Control)(object)TEXT_IDTL);
		((Control)pnlOthDetl).Controls.Add((Control)(object)MSG_IDTL);
		((Control)pnlOthDetl).Location = new Point(5, 277);
		((Control)pnlOthDetl).Name = "pnlOthDetl";
		((Control)pnlOthDetl).Size = new Size(1037, 117);
		((Control)pnlOthDetl).TabIndex = 8;
		((Control)pnlOthDetl).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)pnlOthDetl);
		((Control)this).Controls.Add((Control)(object)PnlSilverCut);
		((Control)this).Controls.Add((Control)(object)lblItStock);
		((Control)this).Controls.Add((Control)(object)nWestPrc);
		((Control)this).Controls.Add((Control)(object)lblWestPrc);
		((Control)this).Controls.Add((Control)(object)chkSilverCut);
		((Control)this).Controls.Add((Control)(object)nBillProfit);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)chkItmImage);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)nConvRate);
		((Control)this).Controls.Add((Control)(object)nConvPrc);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)lblDiffAmt);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)lblRate);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nFineRate);
		((Control)this).Controls.Add((Control)(object)nDiffFine);
		((Control)this).Controls.Add((Control)(object)nFineKsrCr);
		((Control)this).Controls.Add((Control)(object)nFineKsrDr);
		((Control)this).Controls.Add((Control)(object)nAcDrFine);
		((Control)this).Controls.Add((Control)(object)nAcCrAmt);
		((Control)this).Controls.Add((Control)(object)nAcCrFine);
		((Control)this).Controls.Add((Control)(object)nAcDrAmt);
		((Control)this).Controls.Add((Control)(object)nTotFineDr);
		((Control)this).Controls.Add((Control)(object)nTotFineCr);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_PR_TOT);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
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
		((Control)this).Name = "TR_TOUR_SALE";
		((Form)this).Text = "Tour Sales";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_PR).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((Control)PnlSilverCut).ResumeLayout(false);
		((Control)PnlSilverCut).PerformLayout();
		((Control)pnlOthDetl).ResumeLayout(false);
		((Control)pnlOthDetl).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 41;
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
			mSG_PR[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[1] = 0;
			mSG_PR[0, 1] = "ItCode";
			mSG_PR[2] = (int)Math.Round(2300.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "ItName";
			mSG_PR[3] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "Counter";
			mSG_PR[4] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Design";
			mSG_PR[5] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[5] = 7;
			mSG_PR[0, 5] = "BagWt";
			mSG_PR[6] = (int)Math.Round(700.0 * ColCon);
			mSG_PR[6] = 7;
			mSG_PR[0, 6] = "Pcs";
			mSG_PR[7] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[7] = 7;
			mSG_PR[0, 7] = "PsWt";
			mSG_PR[8] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[8] = 7;
			mSG_PR[0, 8] = "GrWt";
			mSG_PR[9] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "OthWt";
			mSG_PR[10] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "NetWt";
			mSG_PR[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "GhtWt";
			mSG_PR[12] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "Touch";
			mSG_PR[13] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[13] = 7;
			mSG_PR[0, 13] = "West%";
			mSG_PR[14] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[14] = 7;
			mSG_PR[0, 14] = "LTouch";
			mSG_PR[15] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "Fine";
			mSG_PR[16] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "NetFine";
			mSG_PR[31] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "HmFine";
			mSG_PR[17] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "SlvFine";
			mSG_PR[18] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[18] = 7;
			mSG_PR[0, 18] = "ConRate";
			mSG_PR[19] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "Con%";
			mSG_PR[20] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[20] = 7;
			mSG_PR[0, 20] = "Rate";
			mSG_PR[21] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[21] = 7;
			mSG_PR[0, 21] = "ItAmt";
			mSG_PR[22] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[22] = 7;
			mSG_PR[0, 22] = "Lbr%";
			mSG_PR[23] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[23] = 3;
			mSG_PR[0, 23] = "Ltype";
			mSG_PR[24] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "LRate";
			mSG_PR[25] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "LAmt";
			mSG_PR[26] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "OthAmt";
			mSG_PR[27] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[27] = 3;
			mSG_PR[0, 27] = "ORate";
			mSG_PR[28] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[28] = 7;
			mSG_PR[0, 28] = "OFine";
			mSG_PR[29] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[29] = 7;
			mSG_PR[0, 29] = "Mrp";
			mSG_PR[32] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[32] = 7;
			mSG_PR[0, 32] = "TotAmt";
			mSG_PR[33] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[33] = 7;
			mSG_PR[0, 33] = "TaxPrc";
			mSG_PR[30] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "NetAmt";
			mSG_PR[34] = 0;
			mSG_PR[35] = 0;
			mSG_PR[36] = 0;
			mSG_PR[37] = 0;
			mSG_PR[38] = 0;
			mSG_PR[39] = 0;
			mSG_PR[40] = 0;
			mSG_PR.Row = 1;
			mSG_PR.Col = 1;
			((Control)TEXT_PR).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG_PR.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'WH_REC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
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
			if (MSG[1] == 0)
			{
				mSG_PR[20] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[20] = 7;
				mSG_PR[0, 20] = "Rate";
				mSG_PR[21] = (int)Math.Round(1400.0 * ColCon);
				mSG_PR[21] = 7;
				mSG_PR[0, 21] = "ItAmt";
				mSG_PR[30] = (int)Math.Round(1400.0 * ColCon);
				mSG_PR[30] = 7;
				mSG_PR[0, 30] = "NetAmt";
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
		mSG_PR[mSG_PR.Row, 23] = DC_Main.MsLbrType;
		mSG_PR = null;
		if (MSG_PR.Row <= 1)
		{
			return;
		}
		DataView dataView = new DataView(DC_Main.RsClDetl);
		if (dataView.Count <= 0)
		{
			return;
		}
		checked
		{
			int num = MSG_PR.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				dataView.RowFilter = "BOOK_NAME = 'WH_REC' AND COL_NEW_NAME = '" + MSG_PR[0, DC_Main.M] + "'";
				if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
				{
					MSG_PR[MSG_PR.Row, DC_Main.M] = MSG_PR[MSG_PR.Row - 1, DC_Main.M];
				}
				DC_Main.M++;
			}
		}
	}

	private void TEXT_PR_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_PR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Invalid comparison between Unknown and I4
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Invalid comparison between Unknown and I4
		//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Invalid comparison between Unknown and I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Invalid comparison between Unknown and I4
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Invalid comparison between Unknown and I4
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_PR.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_PR[mSG_PR.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_PR.Text = "";
					MSG_PR_TOT_FILL();
					BILL_TOTAL();
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + MSG_PR[MSG_PR.Row, 1] + "'";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (mSG_PR.Col == 12)
			{
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 1] + "' ," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ",0,0) ");
				}
				else
				{
					DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "'");
				}
			}
			else if (mSG_PR.Col == 13)
			{
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 1] + "' ," + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 12])) + "," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ",0) ");
				}
				else
				{
					DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_WEST = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' ");
				}
			}
			else if (mSG_PR.Col == 24)
			{
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 1] + "' ,0,0," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ") ");
				}
				else
				{
					DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "'");
				}
			}
			Interaction.MsgBox((object)"Touch Update...", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_PR.Col > 1)
				{
					Msgleft = true;
					mSG_PR.Col = checked(mSG_PR.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR.Col < 30)
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
					MsgPrOldRow = 0;
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_PR.Row < mSG_PR.Rows - 1)
					{
						mSG_PR.Row += 1;
						MsgPrOldRow = 0;
					}
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
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  ORDER BY A.IT_NAME"));
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
									mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 34] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 35] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						ItmStk(MSG_PR.Row, "R");
						if (!((Operators.CompareString(EntryMode, "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
						DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable2.Rows.Count <= 0)
						{
							break;
						}
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
						Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
						double num3 = DC_Main.Fnv(ref Value);
						dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
						if (num2 + num3 != 0.0)
						{
							AxMSFlexGrid obj = mSG_PR;
							int row = mSG_PR.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
							double num4 = DC_Main.Fnv(ref Value);
							dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							obj[row, 12] = Strings.Format((object)num4, "0.00");
							AxMSFlexGrid obj2 = mSG_PR;
							int row2 = mSG_PR.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
							double num5 = DC_Main.Fnv(ref Value);
							dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
							obj2[row2, 13] = Strings.Format((object)num5, "0.00");
							if ((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
							{
								mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13])) / 100.0), "0.000");
							}
						}
						break;
					}
					case 8:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 35], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						break;
					case 30:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
							CommPassTotal_Pr(mSG_PR.Row);
							MsgClearIdtl = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							MsgClearIdtl = false;
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
		checked
		{
			if (mSG_PR.CellWidth >= 0)
			{
				((Control)TEXT_PR).Left = (int)Math.Round((double)((Control)mSG_PR).Left + (double)mSG_PR.CellLeft / 15.0);
				((Control)TEXT_PR).Top = (int)Math.Round((double)((Control)mSG_PR).Top + (double)mSG_PR.CellTop / 15.0);
				((Control)TEXT_PR).Width = (int)Math.Round((double)mSG_PR.CellWidth / 15.0);
				((Control)TEXT_PR).Height = (int)Math.Round((double)mSG_PR.CellHeight / 15.0);
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				MsgPrOldRow = 0;
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
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 23:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_PR).MaxLength = 8;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				break;
			case 12:
			case 13:
			case 14:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 24:
			case 25:
			case 26:
			case 27:
			case 29:
			case 30:
			case 32:
			case 33:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 5:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 17:
			case 28:
			case 31:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 16:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				((TextBoxBase)TEXT_PR).ReadOnly = true;
				break;
			case 15:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				if (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			}
			mSG_PR = null;
			((TextBoxBase)TEXT_PR).SelectAll();
		}
	}

	private void MSG_PR_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_PR.Row != 0 && MSG_PR[MSG_PR.Col] != 0 && ((Control)TEXT_PR).Visible)
		{
			AxMSFlexGrid mSG_PR = MSG_PR;
			switch (MSG_PR.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 23:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 6:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 12:
			case 13:
			case 14:
			case 18:
			case 19:
			case 20:
			case 22:
			case 24:
			case 25:
			case 26:
			case 27:
			case 29:
			case 30:
			case 32:
			case 33:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 21:
				CommPassTotal_Pr(mSG_PR.Row);
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
				break;
			case 5:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 15:
			case 16:
			case 17:
			case 28:
			case 31:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			}
			mSG_PR = null;
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != Conversion.Val(mSG_PR[mSG_PR.Row, 36]))
		{
			mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 8]), "0.000");
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) - Conversion.Val(mSG_PR[mSG_PR.Row, 9])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) - Conversion.Val(mSG_PR[mSG_PR.Row, 9])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != Conversion.Val(mSG_PR[mSG_PR.Row, 37]))
		{
			mSG_PR[mSG_PR.Row, 37] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 10]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 10]), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != Conversion.Val(mSG_PR[mSG_PR.Row, 38]))
		{
			mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14])), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != Conversion.Val(mSG_PR[mSG_PR.Row, 39]))
		{
			mSG_PR[mSG_PR.Row, 39] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 13]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 13]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])) / 100.0), "0.000");
		}
		else
		{
			mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0))
		{
			string text = mSG_PR[mSG_PR.Row, 35];
			if (Operators.CompareString(text, "1", false) != 0)
			{
				if (Operators.CompareString(text, "K", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) * 1000.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 27]), 3), "0.000");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / Conversion.Val(mSG_PR[mSG_PR.Row, 27]), 3), "0.000");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) * 10.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 27]), 3), "0.000");
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 18]) / Conversion.Val(mSG_PR[mSG_PR.Row, 19]) * 100.0, 2), "0.00");
		}
		else if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0)
		{
			mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 18]), "0.00");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 20]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 6]) != 0.0))
		{
			switch (mSG_PR[mSG_PR.Row, 35])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 6]) * Conversion.Val(mSG_PR[mSG_PR.Row, 20]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 20]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 20]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * Conversion.Val(mSG_PR[mSG_PR.Row, 20]), 0), "0.00");
				break;
			}
		}
		if (mSG_PR.Col == 21 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 20]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != Conversion.Val(TEXT_PR.Text)) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 6]) != 0.0)))
		{
			mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			switch (mSG_PR[mSG_PR.Row, 35])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 6]), DC_Main.MsItmRateRof), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * 10.0, DC_Main.MsItmRateRof), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * 1000.0, DC_Main.MsItmRateRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 15]), DC_Main.MsItmRateRof), "0.00");
				break;
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0)
		{
			string text2 = mSG_PR[mSG_PR.Row, 23];
			switch (mSG_PR[mSG_PR.Row, 23])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 6]) * Conversion.Val(mSG_PR[mSG_PR.Row, 24]), 0), "0.00");
				break;
			case "N":
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])) * Conversion.Val(mSG_PR[mSG_PR.Row, 24]), 0), "0.00");
				break;
			case "K":
				if (Operators.CompareString(DC_Main.MsLbrType, "G", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / 1000.0), 0), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / 1000.0), 0), "0.00");
				}
				break;
			default:
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * Conversion.Val(mSG_PR[mSG_PR.Row, 24]), 0), "0.00");
				break;
			}
		}
		mSG_PR[mSG_PR.Row, 32] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) + Conversion.Val(mSG_PR[mSG_PR.Row, 26]) + Conversion.Val(mSG_PR[mSG_PR.Row, 21])), "0.00");
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 33]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 32]), "0.00");
		}
		if (mSG_PR.Col == 33)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 33]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 32]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 33]) + 100.0) * 100.0, 0), "0.00");
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) - Conversion.Val(mSG_PR[mSG_PR.Row, 21]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26]), 0), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0)
				{
					if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 23], "P", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 6]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / Conversion.Val(mSG_PR[mSG_PR.Row, 6])), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 23], "N", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 11]))), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 23], "K", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * 1000.0), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 23], "G", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / Conversion.Val(mSG_PR[mSG_PR.Row, 8])), "0.00");
					}
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 32]), "0.00");
			}
		}
		MSG_PR_TOT_FILL();
		BILL_TOTAL();
		mSG_PR = null;
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
				mSG_PR_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 6]) + Conversion.Val(MSG_PR[DC_Main.M, 6]))), "0");
				mSG_PR_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 5]) + Conversion.Val(MSG_PR[DC_Main.M, 5]))), "0.000");
				mSG_PR_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR[DC_Main.M, 8]))), "0.000");
				mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0.000");
				mSG_PR_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR[DC_Main.M, 10]))), "0.000");
				mSG_PR_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 11]) + Conversion.Val(MSG_PR[DC_Main.M, 11]))), "0.000");
				mSG_PR_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR[DC_Main.M, 15]))), "0.000");
				mSG_PR_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 16]) + Conversion.Val(MSG_PR[DC_Main.M, 16]))), "0.000");
				mSG_PR_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 17]) + Conversion.Val(MSG_PR[DC_Main.M, 17]))), "0.00");
				mSG_PR_TOT[0, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 21]) + Conversion.Val(MSG_PR[DC_Main.M, 21]))), "0.00");
				mSG_PR_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 25]) + Conversion.Val(MSG_PR[DC_Main.M, 25]))), "0.00");
				mSG_PR_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 26]) + Conversion.Val(MSG_PR[DC_Main.M, 26]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 27]) != 0.0)
				{
					PrOthAmtLess += Conversion.Val(MSG_PR[DC_Main.M, 26]);
				}
				mSG_PR_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 28]) + Conversion.Val(MSG_PR[DC_Main.M, 28]))), "0.000");
				mSG_PR_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 29]) + Conversion.Val(MSG_PR[DC_Main.M, 29]))), "0.000");
				mSG_PR_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 32]) + Conversion.Val(MSG_PR[DC_Main.M, 32]))), "0.00");
				mSG_PR_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 30]) + Conversion.Val(MSG_PR[DC_Main.M, 30]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 21]) == 0.0)
				{
					TotCrFine += Conversion.Val(MSG_PR[DC_Main.M, 15]);
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
		mSG_IDTL.Cols = 28;
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
			mSG_IDTL[11] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "PcsWt";
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
			{
				mSG_IDTL[12] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[12] = 7;
				mSG_IDTL[0, 12] = "KrgWt";
				mSG_IDTL[13] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[13] = 7;
				mSG_IDTL[0, 13] = "Krg%";
			}
			else
			{
				mSG_IDTL[12] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[12] = 7;
				mSG_IDTL[0, 12] = "KrgWt";
				mSG_IDTL[13] = (int)Math.Round(800.0 * ColCon);
				mSG_IDTL[13] = 7;
				mSG_IDTL[0, 13] = "Krg%";
			}
			mSG_IDTL[14] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "Weight";
			mSG_IDTL[15] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "Con%";
			mSG_IDTL[16] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[16] = 3;
			mSG_IDTL[0, 16] = "P/W";
			mSG_IDTL[17] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "Rate";
			mSG_IDTL[18] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[18] = 7;
			mSG_IDTL[0, 18] = "ItAmt";
			mSG_IDTL[19] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[19] = 7;
			mSG_IDTL[0, 19] = "LbrRate";
			mSG_IDTL[20] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[20] = 7;
			mSG_IDTL[0, 20] = "LbrAmt";
			mSG_IDTL[21] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[21] = 7;
			mSG_IDTL[0, 21] = "NetAmt";
			mSG_IDTL[22] = 0;
			mSG_IDTL[0, 22] = "ConWt";
			mSG_IDTL[23] = 0;
			mSG_IDTL[0, 23] = "KrWt";
			mSG_IDTL[24] = 0;
			mSG_IDTL[0, 24] = "KrConWt";
			mSG_IDTL[25] = 0;
			mSG_IDTL[0, 25] = "ItType";
			mSG_IDTL[26] = 0;
			mSG_IDTL[0, 26] = "RowSrNo";
			mSG_IDTL[27] = 0;
			mSG_IDTL[0, 27] = "OldGwt";
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
		mSG_IDTL[mSG_IDTL.Row, 26] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 57]));
		mSG_IDTL = null;
	}

	private void TEXT_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Invalid comparison between Unknown and I4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Invalid comparison between Unknown and I4
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Invalid comparison between Unknown and I4
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Invalid comparison between Unknown and I4
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
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
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 26])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
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
					MSG[MSG.Row, 13] = Conversions.ToString(0);
					MSG[MSG.Row, 65] = Conversions.ToString(0);
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
				if (mSG_IDTL.Col < 21)
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
									mSG_IDTL[mSG_IDTL.Row, 25] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 17]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 15]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.00");
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
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 17]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 11:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
						{
							mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
						}
						break;
					case 13:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
						{
							mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) * Conversion.Val(TEXT_IDTL.Text) / 100.0), "0.000");
						}
						break;
					case 21:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
							mSG_IDTL[mSG_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
				case 16:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 13:
				case 15:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 11:
				case 12:
				case 14:
				case 22:
				case 23:
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
			case 16:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 13:
			case 15:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 11:
			case 12:
			case 14:
			case 22:
			case 23:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			}
			mSG_IDTL = null;
		}
	}

	private void CommPassTotal_Idtl(int CRow)
	{
		SlSilverFine = 0.0;
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 11])), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 23]) == 0.0))
		{
			mSG_IDTL[CRow, 23] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
		{
			mSG_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 15])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 22] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
		{
			mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 15])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 24] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 16], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 14]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0))
			{
				mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0))
			{
				mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 16], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 17])))) != 0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0)
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 18]) + Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0)
		{
			mSG_IDTL[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 18]) + Conversion.Val(mSG_IDTL[CRow, 20])), "0.00");
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
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 22]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 24]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 21]);
				if (Operators.CompareString(mSG_IDTL[DC_Main.M, 25], "S", false) == 0)
				{
					if (Conversion.Val(mSG_IDTL[DC_Main.M, 18]) == 0.0)
					{
						SlSilverFine += Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_IDTL[DC_Main.M, 14]), "0.00"));
					}
					else
					{
						MSG[MSG.Row, 24] = "";
					}
				}
				DC_Main.M++;
			}
			if (SlSilverFine != 0.0)
			{
				MSG[MSG.Row, 24] = Strings.Format((object)SlSilverFine, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 13] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 14] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 13])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 41] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 42] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 41])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 33] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 50] = Strings.Format((object)num5, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 14] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - num2), "0.000");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26])) == Conversion.Val(mSG_IDTL[CRow, 26])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][23] = mSG_IDTL[CRow, 23];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
						DtIdtl.Rows[i][21] = mSG_IDTL[CRow, 21];
						DtIdtl.Rows[i][22] = mSG_IDTL[CRow, 22];
						DtIdtl.Rows[i][24] = mSG_IDTL[CRow, 24];
						DtIdtl.Rows[i][25] = mSG_IDTL[CRow, 25];
						DtIdtl.Rows[i][26] = mSG_IDTL[CRow, 26];
						DtIdtl.Rows[i][27] = mSG_IDTL[CRow, 27];
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
					dr[12] = mSG_IDTL[CRow, 12];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[23] = mSG_IDTL[CRow, 23];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[16] = mSG_IDTL[CRow, 16];
					dr[17] = mSG_IDTL[CRow, 17];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[20] = mSG_IDTL[CRow, 20];
					dr[21] = mSG_IDTL[CRow, 21];
					dr[22] = mSG_IDTL[CRow, 22];
					dr[24] = mSG_IDTL[CRow, 24];
					dr[25] = mSG_IDTL[CRow, 25];
					dr[26] = mSG_IDTL[CRow, 26];
					dr[27] = mSG_IDTL[CRow, 27];
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
		mSG.Cols = 91;
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
			mSG[2] = (int)Math.Round(1000.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[3] = (int)Math.Round(2300.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItName";
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Counter";
			mSG[5] = (int)Math.Round(1300.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Design";
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Color";
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "Size";
			mSG[8] = (int)Math.Round(900.0 * ColCon);
			mSG[8] = 0;
			mSG[0, 8] = "HuId";
			mSG[9] = (int)Math.Round(800.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "BagWt";
			mSG[10] = (int)Math.Round(700.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Pcs";
			mSG[11] = (int)Math.Round(900.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "BagTot";
			mSG[12] = (int)Math.Round(1000.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "GrWt";
			mSG[13] = (int)Math.Round(900.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "OthWt";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "NetWt";
			mSG[41] = (int)Math.Round(0.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "KrOthWt";
			mSG[42] = (int)Math.Round(0.0 * ColCon);
			mSG[42] = 7;
			mSG[0, 42] = "KrNwt";
			mSG[43] = (int)Math.Round(0.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "KrGht%";
			mSG[44] = (int)Math.Round(0.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "KrGht";
			mSG[45] = (int)Math.Round(0.0 * ColCon);
			mSG[45] = 7;
			mSG[0, 45] = "KrTouch";
			mSG[46] = (int)Math.Round(0.0 * ColCon);
			mSG[46] = 7;
			mSG[0, 46] = "KrWst%";
			mSG[47] = (int)Math.Round(0.0 * ColCon);
			mSG[47] = 7;
			mSG[0, 47] = "KrFine";
			mSG[15] = (int)Math.Round(750.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "Ght%";
			mSG[16] = (int)Math.Round(850.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "GhtWt";
			mSG[17] = (int)Math.Round(850.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "Touch";
			mSG[18] = (int)Math.Round(850.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "West%";
			mSG[19] = (int)Math.Round(850.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "LTouch";
			mSG[20] = (int)Math.Round(850.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "LessWt";
			mSG[21] = (int)Math.Round(850.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "HmFine";
			mSG[22] = (int)Math.Round(1000.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "Fine";
			mSG[23] = (int)Math.Round(1000.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "NetFine";
			mSG[24] = (int)Math.Round(1000.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "SlvrFine";
			mSG[25] = (int)Math.Round(1000.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "ConRate";
			mSG[26] = (int)Math.Round(900.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "Con%";
			mSG[29] = (int)Math.Round(800.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "Lbr%";
			mSG[30] = (int)Math.Round(800.0 * ColCon);
			mSG[30] = 3;
			mSG[0, 30] = "LType";
			mSG[31] = (int)Math.Round(900.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "LbrRate";
			mSG[32] = (int)Math.Round(950.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "LbrAmt";
			mSG[33] = (int)Math.Round(1000.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "OthAmt";
			mSG[34] = (int)Math.Round(1000.0 * ColCon);
			mSG[34] = 3;
			mSG[0, 34] = "ORate";
			mSG[35] = (int)Math.Round(1000.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "OFine";
			mSG[48] = (int)Math.Round(0.0 * ColCon);
			mSG[48] = 7;
			mSG[0, 48] = "KrLRate";
			mSG[59] = (int)Math.Round(0.0 * ColCon);
			mSG[59] = 7;
			mSG[0, 59] = "KrLAmt";
			mSG[50] = (int)Math.Round(0.0 * ColCon);
			mSG[50] = 7;
			mSG[0, 50] = "KrOthAmt";
			mSG[51] = (int)Math.Round(0.0 * ColCon);
			mSG[51] = 7;
			mSG[0, 51] = "PrCost";
			mSG[27] = (int)Math.Round(1000.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "ItRate";
			mSG[28] = (int)Math.Round(1300.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "ItAmt";
			mSG[53] = (int)Math.Round(0.0 * ColCon);
			mSG[53] = 7;
			mSG[0, 53] = "TagCost";
			mSG[54] = (int)Math.Round(0.0 * ColCon);
			mSG[54] = 7;
			mSG[0, 54] = "Margin";
			mSG[36] = (int)Math.Round(900.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "Mrp";
			mSG[38] = (int)Math.Round(0.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "TotAmt";
			mSG[39] = (int)Math.Round(0.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "Tax%";
			mSG[37] = (int)Math.Round(1300.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "NetAmt";
			mSG[55] = (int)Math.Round(0.0 * ColCon);
			mSG[55] = 3;
			mSG[0, 55] = "Image";
			mSG[40] = (int)Math.Round(0.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "KrCode";
			if (Operators.CompareString(DC_Main.MsMfgType, "B", false) == 0)
			{
				mSG[75] = (int)Math.Round(1000.0 * ColCon);
				mSG[75] = 3;
				mSG[0, 75] = "OrdNo";
			}
			else
			{
				mSG[75] = 0;
			}
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
			mSG[60] = 0;
			mSG[61] = 0;
			mSG[52] = 0;
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
			mSG[78] = 0;
			mSG[76] = 0;
			mSG[77] = 0;
			mSG[79] = 0;
			mSG[80] = 0;
			mSG[81] = 0;
			mSG[82] = 0;
			mSG[83] = 0;
			mSG[84] = 0;
			mSG[85] = 0;
			mSG[86] = 0;
			mSG[87] = 0;
			mSG[88] = 0;
			mSG[89] = 0;
			mSG[90] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'WH_ISU' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			if (MSG[1] == 0)
			{
				mSG[12] = (int)Math.Round(1100.0 * ColCon);
				mSG[12] = 7;
				mSG[0, 12] = "GrWt";
				mSG[27] = (int)Math.Round(1200.0 * ColCon);
				mSG[27] = 7;
				mSG[0, 27] = "ItRate";
				mSG[28] = (int)Math.Round(1400.0 * ColCon);
				mSG[28] = 7;
				mSG[0, 28] = "ItAmt";
				mSG[37] = (int)Math.Round(1400.0 * ColCon);
				mSG[37] = 7;
				mSG[0, 37] = "NetAmt";
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
		if (UpDown)
		{
			return;
		}
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		AxMSFlexGrid mSG_TOT = MSG_TOT;
		checked
		{
			int num = MSG.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG_TOT[0, DC_Main.M] = "";
				DC_Main.M++;
			}
			mSG_TOT[0, 5] = "Total :";
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0");
				mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
				mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
				mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
				mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
				mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
				mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
				mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.000");
				mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.000");
				mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
				mSG_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 28]) + Conversion.Val(MSG[DC_Main.M, 28]))), "0.00");
				mSG_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 32]) + Conversion.Val(MSG[DC_Main.M, 32]))), "0.00");
				mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.00");
				if (Conversion.Val(MSG[DC_Main.M, 34]) != 0.0)
				{
					SlOthAmtLess += Conversion.Val(MSG[DC_Main.M, 33]);
				}
				mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[DC_Main.M, 35]))), "0.000");
				mSG_TOT[0, 53] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 53]) + Conversion.Val(MSG[DC_Main.M, 53]))), "0.00");
				mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[DC_Main.M, 36]))), "0.000");
				mSG_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 38]) + Conversion.Val(MSG[DC_Main.M, 38]))), "0.00");
				mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");
				mSG_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 41]) + Conversion.Val(MSG[DC_Main.M, 41]))), "0.000");
				mSG_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 42]) + Conversion.Val(MSG[DC_Main.M, 42]))), "0.000");
				mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.000");
				mSG_TOT[0, 47] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 47]) + Conversion.Val(MSG[DC_Main.M, 47]))), "0.000");
				mSG_TOT[0, 59] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 59]) + Conversion.Val(MSG[DC_Main.M, 59]))), "0.00");
				mSG_TOT[0, 50] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 50]) + Conversion.Val(MSG[DC_Main.M, 50]))), "0.00");
				mSG_TOT[0, 51] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 51]) + Conversion.Val(MSG[DC_Main.M, 51]))), "0.00");
				if (Conversion.Val(MSG[DC_Main.M, 28]) == 0.0)
				{
					TotDrFine += Conversion.Val(MSG[DC_Main.M, 22]);
				}
				DC_Main.M++;
			}
			mSG_TOT = null;
			NewValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 42]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 32]);
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			mSG.Row = mSG.Rows - 1;
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
			mSG[mSG.Row, 30] = DC_Main.MsLbrType;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 57] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 57] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 57]) + 1.0);
			}
			if (Conversion.Val(nWestPrc.Text) != 0.0)
			{
				mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(nWestPrc.Text), "0.00");
			}
			mSG[mSG.Row, 62] = "A";
			mSG[mSG.Row, 55] = "N";
			mSG[mSG.Row, 90] = "N";
			MSG_IDTL_CLEAR();
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
				MsgOldRow = 0;
				((Control)TEXT_ENTRY).Visible = true;
				((Control)pnlOthDetl).Visible = true;
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
				if ((mSG.Col != 4) & (mSG.Col != 5) & (mSG.Col != 7))
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
			case 40:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 75:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 30:
			case 55:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 10:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 15:
			case 17:
			case 18:
			case 19:
			case 24:
			case 29:
			case 45:
			case 46:
			case 54:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 25:
			case 26:
			case 27:
			case 28:
			case 31:
			case 32:
			case 33:
			case 34:
			case 36:
			case 37:
			case 38:
			case 39:
			case 48:
			case 50:
			case 51:
			case 53:
			case 59:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 9:
			case 11:
			case 12:
			case 13:
			case 14:
			case 16:
			case 20:
			case 21:
			case 35:
			case 41:
			case 42:
			case 43:
			case 44:
			case 47:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 23:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 22:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			}
			mSG = null;
			((TextBoxBase)TEXT_ENTRY).SelectAll();
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
			case 3:
			case 75:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 5:
			case 6:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 4:
			case 7:
			case 8:
			case 30:
			case 40:
			case 55:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 10:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 15:
			case 17:
			case 18:
			case 19:
			case 24:
			case 29:
			case 45:
			case 46:
			case 54:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 25:
			case 26:
			case 27:
			case 28:
			case 31:
			case 32:
			case 33:
			case 34:
			case 36:
			case 37:
			case 38:
			case 39:
			case 48:
			case 50:
			case 51:
			case 53:
			case 59:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 13:
			case 41:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal_Idtl(1);
				CommPassTotal();
				break;
			case 9:
			case 11:
			case 12:
			case 14:
			case 16:
			case 20:
			case 21:
			case 22:
			case 23:
			case 35:
			case 42:
			case 43:
			case 44:
			case 47:
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
		AxMSFlexGrid val = default(AxMSFlexGrid);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				string text;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000c;
				case 8706:
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
							goto IL_0015;
						case 4:
							goto IL_004b;
						case 5:
							goto IL_007e;
						case 6:
							goto IL_00c5;
						case 7:
						case 8:
							goto IL_010e;
						case 9:
							goto IL_0138;
						case 10:
							goto IL_0187;
						case 11:
							goto IL_019e;
						case 12:
							goto IL_01e6;
						case 13:
							goto IL_01fe;
						case 15:
							goto IL_024a;
						case 18:
							goto IL_0297;
						case 14:
						case 16:
						case 17:
						case 19:
						case 20:
						case 21:
							goto IL_02e2;
						case 22:
							goto IL_02f8;
						case 23:
							goto IL_033e;
						case 24:
						case 25:
							goto IL_0374;
						case 26:
							goto IL_03a8;
						case 27:
							goto IL_03dc;
						case 28:
						case 29:
						case 30:
							goto IL_0425;
						case 31:
							goto IL_0471;
						case 32:
							goto IL_0489;
						case 33:
						case 34:
							goto IL_04dd;
						case 35:
							goto IL_0511;
						case 36:
							goto IL_0529;
						case 37:
						case 38:
							goto IL_055f;
						case 39:
							goto IL_05be;
						case 40:
							goto IL_05f2;
						case 41:
							goto IL_0626;
						case 42:
							goto IL_0689;
						case 44:
							goto IL_072f;
						case 43:
						case 45:
						case 46:
						case 47:
							goto IL_078e;
						case 48:
							goto IL_07d9;
						case 49:
							goto IL_0821;
						case 50:
							goto IL_0884;
						case 51:
						case 52:
						case 53:
							goto IL_092a;
						case 54:
							goto IL_0961;
						case 55:
							goto IL_0995;
						case 56:
							goto IL_09f8;
						case 57:
						case 58:
						case 59:
							goto IL_0a9e;
						case 60:
							goto IL_0ad9;
						case 61:
						case 62:
							goto IL_0b4b;
						case 63:
							goto IL_0b78;
						case 64:
							goto IL_0bb3;
						case 66:
							goto IL_0c2a;
						case 65:
						case 67:
						case 68:
						case 69:
							goto IL_0ccf;
						case 70:
							goto IL_0d1f;
						case 72:
							goto IL_0d56;
						case 74:
							goto IL_0db4;
						case 76:
							goto IL_0e0f;
						case 71:
						case 73:
						case 75:
						case 77:
						case 78:
						case 79:
							goto IL_0e62;
						case 80:
							goto IL_0eae;
						case 81:
						case 82:
							goto IL_0ef8;
						case 83:
							goto IL_0f2f;
						case 84:
							goto IL_0f63;
						case 85:
							goto IL_0fc3;
						case 87:
							goto IL_1041;
						case 86:
						case 88:
						case 89:
						case 90:
							goto IL_1078;
						case 91:
							goto IL_10af;
						case 92:
							goto IL_10e3;
						case 93:
							goto IL_1143;
						case 94:
						case 95:
						case 96:
							goto IL_11c1;
						case 97:
							goto IL_11f8;
						case 98:
							goto IL_122c;
						case 99:
							goto IL_128c;
						case 100:
						case 101:
						case 102:
							goto IL_130a;
						case 103:
							goto IL_1345;
						case 104:
						case 105:
							goto IL_138f;
						case 106:
							goto IL_13db;
						case 108:
							goto IL_1437;
						case 109:
							goto IL_1461;
						case 107:
						case 110:
						case 111:
						case 112:
							goto IL_1498;
						case 113:
							goto IL_14e7;
						case 115:
							goto IL_158d;
						case 114:
						case 116:
						case 117:
							goto IL_15d6;
						case 118:
							goto IL_163a;
						case 120:
							goto IL_1683;
						case 122:
							goto IL_16d7;
						case 124:
							goto IL_1735;
						case 126:
							goto IL_1790;
						case 119:
						case 121:
						case 123:
						case 125:
						case 127:
						case 128:
							goto IL_17e1;
						case 129:
						case 130:
							goto IL_181a;
						case 131:
							goto IL_1833;
						case 132:
							goto IL_18ee;
						case 133:
							goto IL_1923;
						case 135:
							goto IL_196f;
						case 137:
							goto IL_19c7;
						case 139:
							goto IL_1a29;
						case 141:
							goto IL_1a88;
						case 134:
						case 136:
						case 138:
						case 140:
						case 142:
						case 143:
							goto IL_1add;
						case 144:
						case 145:
						case 146:
							goto IL_1b18;
						case 147:
							goto IL_1b49;
						case 149:
							goto IL_1b95;
						case 151:
							goto IL_1bec;
						case 153:
							goto IL_1c57;
						case 154:
							goto IL_1c76;
						case 156:
							goto IL_1cd5;
						case 159:
							goto IL_1d48;
						case 148:
						case 150:
						case 152:
						case 155:
						case 157:
						case 158:
						case 160:
						case 161:
						case 162:
							goto IL_1d9e;
						case 163:
							goto IL_1de9;
						case 164:
							goto IL_1e48;
						case 165:
							goto IL_1e78;
						case 166:
							goto IL_1e92;
						case 167:
							goto IL_1eac;
						case 168:
							goto IL_1ee3;
						case 169:
						case 170:
							goto IL_1f1d;
						case 171:
							goto IL_1f1f;
						case 172:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 173:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_1eac:
					num2 = 167;
					val[val.Row, 28] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.00");
					goto IL_1ee3;
					IL_1ee3:
					num2 = 168;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.00");
					goto IL_1f1d;
					IL_1e92:
					num2 = 166;
					val[val.Row, 33] = "";
					goto IL_1eac;
					IL_1f1d:
					val = null;
					goto IL_1f1f;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 65]))
					{
						goto IL_004b;
					}
					goto IL_010e;
					IL_004b:
					num2 = 4;
					val[val.Row, 65] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 41])), "0.000");
					goto IL_010e;
					IL_010e:
					num2 = 8;
					if ((Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0) & (val[9] != 0))
					{
						goto IL_0138;
					}
					goto IL_02e2;
					IL_0138:
					num2 = 9;
					if ((Conversion.Val(val[val.Row, 9]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0187;
					}
					goto IL_0297;
					IL_0187:
					num2 = 10;
					if (val[11] == 0)
					{
						goto IL_019e;
					}
					goto IL_024a;
					IL_019e:
					num2 = 11;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_01e6;
					IL_01e6:
					num2 = 12;
					val[val.Row, 74] = Conversions.ToString(0);
					goto IL_01fe;
					IL_01fe:
					num2 = 13;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_02e2;
					IL_024a:
					num2 = 15;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_02e2;
					IL_0297:
					num2 = 18;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_02e2;
					IL_02e2:
					num2 = 21;
					if (val.Col == 13)
					{
						goto IL_02f8;
					}
					goto IL_0425;
					IL_02f8:
					num2 = 22;
					if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_033e;
					}
					goto IL_0374;
					IL_033e:
					num2 = 23;
					val[val.Row, 14] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_0374;
					IL_0374:
					num2 = 25;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 74]))
					{
						goto IL_03a8;
					}
					goto IL_0425;
					IL_03a8:
					num2 = 26;
					val[val.Row, 74] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_03dc;
					IL_03dc:
					num2 = 27;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(TEXT_ENTRY.Text)), "0.000");
					goto IL_0425;
					IL_0425:
					num2 = 30;
					if ((Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0471;
					}
					goto IL_04dd;
					IL_0471:
					num2 = 31;
					val[val.Row, 66] = Conversions.ToString(0);
					goto IL_0489;
					IL_0489:
					num2 = 32;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 19]) / 100.0), "0.000");
					goto IL_04dd;
					IL_04dd:
					num2 = 34;
					if (Conversion.Val(val[val.Row, 20]) != Conversion.Val(val[val.Row, 80]))
					{
						goto IL_0511;
					}
					goto IL_055f;
					IL_0511:
					num2 = 35;
					val[val.Row, 66] = Conversions.ToString(0);
					goto IL_0529;
					IL_0529:
					num2 = 36;
					val[val.Row, 80] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.000");
					goto IL_055f;
					IL_055f:
					num2 = 38;
					if (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 66]) + Conversion.Val(val[val.Row, 68]))
					{
						goto IL_05be;
					}
					goto IL_078e;
					IL_05be:
					num2 = 39;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
					goto IL_05f2;
					IL_05f2:
					num2 = 40;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.000");
					goto IL_0626;
					IL_0626:
					num2 = 41;
					if ((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0689;
					}
					goto IL_072f;
					IL_0689:
					num2 = 42;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18])) / 100.0 - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_078e;
					IL_072f:
					num2 = 44;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16]) - Conversion.Val(val[val.Row, 20])), "0.000");
					goto IL_078e;
					IL_078e:
					num2 = 47;
					if (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 69]))
					{
						goto IL_07d9;
					}
					goto IL_092a;
					IL_07d9:
					num2 = 48;
					val[val.Row, 69] = Strings.Format((object)(Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_0821;
					IL_0821:
					num2 = 49;
					if ((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_0884;
					}
					goto IL_092a;
					IL_0884:
					num2 = 50;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18])) / 100.0 - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_092a;
					IL_092a:
					num2 = 53;
					if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_0961;
					}
					goto IL_0a9e;
					IL_0961:
					num2 = 54;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0995;
					IL_0995:
					num2 = 55;
					if ((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_09f8;
					}
					goto IL_0a9e;
					IL_09f8:
					num2 = 56;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18])) / 100.0 - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_0a9e;
					IL_0a9e:
					num2 = 59;
					if (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) == 0.0)
					{
						goto IL_0ad9;
					}
					goto IL_0b4b;
					IL_0ad9:
					num2 = 60;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16]) - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_0b4b;
					IL_0b4b:
					num2 = 62;
					if (Conversion.Val(val[val.Row, 21]) != 0.0)
					{
						goto IL_0b78;
					}
					goto IL_0ccf;
					IL_0b78:
					num2 = 63;
					if (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) == 0.0)
					{
						goto IL_0bb3;
					}
					goto IL_0c2a;
					IL_0bb3:
					num2 = 64;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16]) - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_0ccf;
					IL_0c2a:
					num2 = 66;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18])) / 100.0 - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_0ccf;
					IL_0ccf:
					num2 = 69;
					if ((Conversion.Val(val[val.Row, 34]) != 0.0) & (Conversion.Val(val[val.Row, 33]) != 0.0))
					{
						goto IL_0d1f;
					}
					goto IL_0e62;
					IL_0d1f:
					num2 = 70;
					text = val[val.Row, 58];
					if (Operators.CompareString(text, "1", false) == 0)
					{
						goto IL_0d56;
					}
					if (Operators.CompareString(text, "K", false) == 0)
					{
						goto IL_0db4;
					}
					goto IL_0e0f;
					IL_1f1f:
					num2 = 171;
					MSG_TOT_FILL();
					break;
					IL_0e0f:
					num2 = 76;
					val[val.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 33]) / Conversion.Val(val[val.Row, 34]), 3), "0.000");
					goto IL_0e62;
					IL_0db4:
					num2 = 74;
					val[val.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 33]) * 1000.0 / Conversion.Val(val[val.Row, 34]), 3), "0.000");
					goto IL_0e62;
					IL_0d56:
					num2 = 72;
					val[val.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 33]) * 10.0 / Conversion.Val(val[val.Row, 34]), 3), "0.000");
					goto IL_0e62;
					IL_0e62:
					num2 = 79;
					if ((Conversion.Val(val[val.Row, 41]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0eae;
					}
					goto IL_0ef8;
					IL_0eae:
					num2 = 80;
					val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) - Conversion.Val(val[val.Row, 41])), "0.000");
					goto IL_0ef8;
					IL_0ef8:
					num2 = 82;
					if (Conversion.Val(val[val.Row, 42]) != Conversion.Val(val[val.Row, 71]))
					{
						goto IL_0f2f;
					}
					goto IL_1078;
					IL_0f2f:
					num2 = 83;
					val[val.Row, 71] = Strings.Format((object)Conversion.Val(val[val.Row, 42]), "0.000");
					goto IL_0f63;
					IL_0f63:
					num2 = 84;
					if ((Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46]) != 0.0) & (Conversion.Val(val[val.Row, 42]) != 0.0))
					{
						goto IL_0fc3;
					}
					goto IL_1041;
					IL_0fc3:
					num2 = 85;
					val[val.Row, 47] = Strings.Format((object)((Conversion.Val(val[val.Row, 42]) + Conversion.Val(val[val.Row, 44])) * (Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46])) / 100.0), "0.000");
					goto IL_1078;
					IL_1041:
					num2 = 87;
					val[val.Row, 47] = Strings.Format((object)Conversion.Val(val[val.Row, 42]), "0.000");
					goto IL_1078;
					IL_1078:
					num2 = 90;
					if (Conversion.Val(val[val.Row, 45]) != Conversion.Val(val[val.Row, 72]))
					{
						goto IL_10af;
					}
					goto IL_11c1;
					IL_10af:
					num2 = 91;
					val[val.Row, 72] = Strings.Format((object)Conversion.Val(val[val.Row, 45]), "0.00");
					goto IL_10e3;
					IL_10e3:
					num2 = 92;
					if ((Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46]) != 0.0) & (Conversion.Val(val[val.Row, 42]) != 0.0))
					{
						goto IL_1143;
					}
					goto IL_11c1;
					IL_1143:
					num2 = 93;
					val[val.Row, 47] = Strings.Format((object)((Conversion.Val(val[val.Row, 42]) + Conversion.Val(val[val.Row, 44])) * (Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46])) / 100.0), "0.000");
					goto IL_11c1;
					IL_11c1:
					num2 = 96;
					if (Conversion.Val(val[val.Row, 46]) != Conversion.Val(val[val.Row, 73]))
					{
						goto IL_11f8;
					}
					goto IL_130a;
					IL_11f8:
					num2 = 97;
					val[val.Row, 73] = Strings.Format((object)Conversion.Val(val[val.Row, 46]), "0.00");
					goto IL_122c;
					IL_122c:
					num2 = 98;
					if ((Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46]) != 0.0) & (Conversion.Val(val[val.Row, 42]) != 0.0))
					{
						goto IL_128c;
					}
					goto IL_130a;
					IL_128c:
					num2 = 99;
					val[val.Row, 47] = Strings.Format((object)((Conversion.Val(val[val.Row, 42]) + Conversion.Val(val[val.Row, 44])) * (Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46])) / 100.0), "0.000");
					goto IL_130a;
					IL_130a:
					num2 = 102;
					if (Conversion.Val(val[val.Row, 45]) + Conversion.Val(val[val.Row, 46]) == 0.0)
					{
						goto IL_1345;
					}
					goto IL_138f;
					IL_1345:
					num2 = 103;
					val[val.Row, 47] = Strings.Format((object)(Conversion.Val(val[val.Row, 42]) + Conversion.Val(val[val.Row, 44])), "0.000");
					goto IL_138f;
					IL_138f:
					num2 = 105;
					if ((Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 26]) != 0.0))
					{
						goto IL_13db;
					}
					goto IL_1437;
					IL_13db:
					num2 = 106;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 25]) / Conversion.Val(val[val.Row, 26]) * 100.0, 2), "0.00");
					goto IL_1498;
					IL_1437:
					num2 = 108;
					if (Conversion.Val(val[val.Row, 25]) != 0.0)
					{
						goto IL_1461;
					}
					goto IL_1498;
					IL_1461:
					num2 = 109;
					val[val.Row, 27] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_1498;
					IL_1498:
					num2 = 112;
					if ((Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_14e7;
					}
					goto IL_158d;
					IL_14e7:
					num2 = 113;
					val[val.Row, 23] = Strings.Format((object)((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * (Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18])) / 100.0 - Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_15d6;
					IL_158d:
					num2 = 115;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])), "0.000");
					goto IL_15d6;
					IL_15d6:
					num2 = 117;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_163a;
					}
					goto IL_181a;
					IL_163a:
					num2 = 118;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_16d7;
					case "K":
						goto IL_1735;
					default:
						goto IL_1790;
					}
					goto IL_1683;
					IL_1790:
					num2 = 126;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_17e1;
					IL_1735:
					num2 = 124;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * (Conversion.Val(val[val.Row, 27]) / 1000.0), 0), "0.00");
					goto IL_17e1;
					IL_16d7:
					num2 = 122;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * (Conversion.Val(val[val.Row, 27]) / 10.0), 0), "0.00");
					goto IL_17e1;
					IL_1683:
					num2 = 120;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_17e1;
					IL_17e1:
					num2 = 128;
					val[val.Row, 79] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_181a;
					IL_181a:
					num2 = 130;
					if (val.Col == 28)
					{
						goto IL_1833;
					}
					goto IL_1b18;
					IL_1833:
					num2 = 131;
					if (((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 27]) != Conversion.Val(val[val.Row, 79]))) | ((Conversion.Val(val[val.Row, 28]) != Conversion.Val(TEXT_ENTRY.Text)) & (Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 10]) != 0.0)))
					{
						goto IL_18ee;
					}
					goto IL_1b18;
					IL_18ee:
					num2 = 132;
					val[val.Row, 28] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
					goto IL_1923;
					IL_1923:
					num2 = 133;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_19c7;
					case "K":
						goto IL_1a29;
					default:
						goto IL_1a88;
					}
					goto IL_196f;
					IL_1a88:
					num2 = 141;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 22]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1add;
					IL_1a29:
					num2 = 139;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 22]) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1add;
					IL_19c7:
					num2 = 137;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 22]) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1add;
					IL_196f:
					num2 = 135;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 10]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1add;
					IL_1add:
					num2 = 143;
					val[val.Row, 79] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_1b18;
					IL_1b18:
					num2 = 146;
					if (Conversion.Val(val[val.Row, 31]) != 0.0)
					{
						goto IL_1b49;
					}
					goto IL_1d9e;
					IL_1b49:
					num2 = 147;
					switch (val[val.Row, 30])
					{
					case "P":
						break;
					case "N":
						goto IL_1bec;
					case "K":
						goto IL_1c57;
					default:
						goto IL_1d48;
					}
					goto IL_1b95;
					IL_1d48:
					num2 = 159;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 31]), 0), "0.00");
					goto IL_1d9e;
					IL_1c57:
					num2 = 153;
					if (Operators.CompareString(DC_Main.MsLbrType, "G", false) == 0)
					{
						goto IL_1c76;
					}
					goto IL_1cd5;
					IL_1c76:
					num2 = 154;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * (Conversion.Val(val[val.Row, 31]) / 1000.0), 0), "0.00");
					goto IL_1d9e;
					IL_1cd5:
					num2 = 156;
					val[val.Row, 32] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * (Conversion.Val(val[val.Row, 31]) / 1000.0), 0), "0.00");
					goto IL_1d9e;
					IL_1bec:
					num2 = 151;
					val[val.Row, 32] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 16])) * Conversion.Val(val[val.Row, 31]), 0), "0.00");
					goto IL_1d9e;
					IL_1b95:
					num2 = 149;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 31]), 0), "0.00");
					goto IL_1d9e;
					IL_1d9e:
					num2 = 162;
					val[val.Row, 51] = Strings.Format((object)(Conversion.Val(val[val.Row, 59]) + Conversion.Val(val[val.Row, 50])), "0.0");
					goto IL_1de9;
					IL_1de9:
					num2 = 163;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_1e48;
					IL_1e48:
					num2 = 164;
					if (Conversion.Val(val[val.Row, 36]) != 0.0)
					{
						goto IL_1e78;
					}
					goto IL_1f1d;
					IL_1e78:
					num2 = 165;
					val[val.Row, 32] = "";
					goto IL_1e92;
					end_IL_0001_2:
					break;
				}
				num2 = 172;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 8706;
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
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Invalid comparison between Unknown and I4
		//IL_0954: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Invalid comparison between Unknown and I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		//IL_096b: Invalid comparison between Unknown and I4
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Invalid comparison between Unknown and I4
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0980: Invalid comparison between Unknown and I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ec: Invalid comparison between Unknown and I4
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a68: Invalid comparison between Unknown and I4
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af4: Invalid comparison between Unknown and I4
		//IL_0b84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Invalid comparison between Unknown and I4
		//IL_458b: Unknown result type (might be due to invalid IL or missing references)
		//IL_38bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1667: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
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
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				if (Operators.CompareString(EntryMode, "E", false) == 0)
				{
					RowDelete = true;
					if (Operators.CompareString(mSG[mSG.Row, 75], "", false) != 0)
					{
						DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 76] + "' AND CO_BOOK = '" + mSG[mSG.Row, 77] + "' AND VCH_NO = '" + mSG[mSG.Row, 75] + "' AND SR_NO = '" + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 78])) + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "UPDATE A SET A.ISU_NO = '',A.ISU_YRCD = '',A.ISU_DBCD = '',A.ISU_SRNO = 0,A.ISU_AC_CODE = '' FROM APR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 76] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 77] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 75] + "' AND A.OLD_SRNO = '" + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 78])) + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.EMP_ISU = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + mSG[mSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 52])) + " ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 57]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][26])) == Conversion.Val(mSG[mSG.Row, 57]))
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
					MSG_TOT_FILL();
					BILL_TOTAL();
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 112)
			{
				if (mSG.Col == 2)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)" AND IT_TYPE = 'O'")), (object)"  ORDER BY A.IT_NAME"));
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
							mSG[mSG.Row, 3] = DC_Main.ColValue[0];
							mSG[mSG.Row, 61] = DC_Main.ColValue[3];
							mSG[mSG.Row, 59] = DC_Main.ColValue[4];
							mSG[mSG.Row, 60] = DC_Main.ColValue[4];
						}
						((Control)TEXT_ENTRY).Focus();
					}
				}
				else
				{
					mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
					mSG[mSG.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
					mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
					mSG[mSG.Row, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
					mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
					if (Conversion.Val((object)mSG[9]) != 0.0 && ((Operators.CompareString(mSG[mSG.Row, 62], "A", false) == 0) & (mSG.Row == checked(mSG.Rows - 1))))
					{
						AxMSFlexGrid obj = mSG;
						int row = mSG.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_BAG_WT"]);
						double num4 = DC_Main.Fnv(ref Value);
						dataRow["IT_BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 9] = Strings.Format((object)num4, "0.000");
					}
					ItmStk(MSG.Row, "I");
					lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
				}
				return;
			}
			if ((int)keyCode == 46)
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
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 52]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 52]))) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
								{
									DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.DESIGN_NO AS DesignNoL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.VCH_DATE From APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME = 'EMP ISU' AND A.EMP_CODE = '" + tEmpCode.Text + "' AND A.ISU_REC = 'N' ";
								}
								else if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.TAG_NO AS TagNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY C.DESIGN_NO,A.TAG_NO,C.VCH_TIME DESC"));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
								}
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
								if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
								{
									if (Operators.CompareString(DC_Main.ColValue[3], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[3];
										mSG[mSG.Row, 3] = DC_Main.ColValue[1];
										mSG[mSG.Row, 2] = DC_Main.ColValue[2];
										mSG[mSG.Row, 5] = DC_Main.ColValue[0];
										mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
										mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
										mSG[mSG.Row, 52] = DC_Main.ColValue[7];
										((Control)TEXT_ENTRY).Focus();
									}
									else
									{
										mSG[mSG.Row, 52] = "";
										mSG[mSG.Row, 1] = "";
										((Control)TEXT_ENTRY).Focus();
									}
								}
								else if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 3] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[2];
									mSG[mSG.Row, 5] = DC_Main.ColValue[3];
									mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 52] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else if (Operators.CompareString(EntryMode, "A", false) == 0)
								{
									mSG[mSG.Row, 52] = "";
									mSG[mSG.Row, 1] = "";
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
							{
								DC_Main.RsQry = "Select A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.OLD_SRNO,A.TAG_NO,A.VCH_SRNO FROM APR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "' AND BOOK_NAME = 'EMP ISU' AND A.EMP_CODE = '" + tEmpCode.Text + "' AND A.ISU_REC = 'N'";
								DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Tbl.Rows.Count == 0)
								{
									TEXT_ENTRY.Text = "";
									Interaction.MsgBox((object)"This Tag Not In Employee Stock List Please Check...", (MsgBoxStyle)0, (object)null);
									return;
								}
								mSG[mSG.Row, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["VCH_NO"], (object)""));
								mSG[mSG.Row, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_YEAR"], (object)""));
								mSG[mSG.Row, 77] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
								mSG[mSG.Row, 78] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OLD_SRNO"], (object)""));
								mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["VCH_SRNO"], (object)""));
							}
							int num16 = mSG.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num16)
							{
								if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
									return;
								}
								DC_Main.X++;
							}
							if (Operators.CompareString(tEmpCode.Text, "", false) == 0)
							{
								mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							}
							if (DC_Main.Rshlp.Rows.Count > 1)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
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
									mSG[mSG.Row, 3] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[0];
									mSG[mSG.Row, 5] = DC_Main.ColValue[3];
									mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 52] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
							}
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = "), (object)mSG[mSG.Row, 52]), (object)" "));
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.i = mSG.Row;
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
								mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
								mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
								mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
								mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
								mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_COLOR"], (object)""));
								mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
								mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
								mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
								mSG[DC_Main.i, 10] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
								mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								if (Conversion.Val(mSG[DC_Main.i, 12]) != Conversion.Val(mSG[DC_Main.i, 14]))
								{
									mSG[DC_Main.i, 13] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 12]) - Conversion.Val(mSG[DC_Main.i, 14])), "0.000");
								}
								else
								{
									mSG[DC_Main.i, 13] = "";
								}
								mSG[DC_Main.i, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
								mSG[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
								mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
								mSG[DC_Main.i, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
								mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								if (Conversion.Val(nWestPrc.Text) != 0.0)
								{
									mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(nWestPrc.Text), "0.00");
									mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(nWestPrc.Text), "0.00");
									if ((Conversion.Val(mSG[DC_Main.i, 14]) != 0.0) & (Conversion.Val(mSG[DC_Main.i, 18]) != 0.0))
									{
										mSG[DC_Main.i, 22] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 14]) * (Conversion.Val(mSG[DC_Main.i, 17]) + Conversion.Val(mSG[DC_Main.i, 18])) / 100.0), "0.000");
									}
								}
								else
								{
									mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
									mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
									mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
								}
								mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
								mSG[DC_Main.i, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
								mSG[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
								mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
								mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
								mSG[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
								mSG[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
								mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
								mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
								mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
								mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
								mSG[DC_Main.i, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
								mSG[DC_Main.i, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
								mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
								mSG[DC_Main.i, 79] = Conversions.ToString(0);
								mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
								mSG[DC_Main.i, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
								mSG[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
								mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
								mSG[DC_Main.i, 40] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
								mSG[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
								mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
								mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
								mSG[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								mSG[DC_Main.i, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
								mSG[DC_Main.i, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
								mSG[DC_Main.i, 82] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
								mSG[DC_Main.i, 83] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
								mSG[DC_Main.i, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
								mSG[DC_Main.i, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
								mSG[DC_Main.i, 86] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
								mSG[DC_Main.i, 87] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
								mSG[DC_Main.i, 90] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
								lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
								if ((Operators.CompareString(mSG[mSG.Row, 62], "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0) & (Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) == 0))
								{
									DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
									DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable3.Rows.Count > 0)
									{
										DataRow dataRow;
										object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_TOUCH"]);
										double num17 = DC_Main.Fnv(ref Value);
										dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
										Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_WEST"]);
										double num18 = DC_Main.Fnv(ref Value);
										dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
										if (num17 + num18 != 0.0)
										{
											AxMSFlexGrid obj10 = mSG;
											int row10 = mSG.Row;
											Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_TOUCH"]);
											double num19 = DC_Main.Fnv(ref Value);
											dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
											obj10[row10, 17] = Strings.Format((object)num19, "0.00");
											if (Conversion.Val(nWestPrc.Text) == 0.0)
											{
												AxMSFlexGrid obj11 = mSG;
												int row11 = mSG.Row;
												Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_WEST"]);
												double num20 = DC_Main.Fnv(ref Value);
												dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
												obj11[row11, 18] = Strings.Format((object)num20, "0.00");
											}
											if ((Conversion.Val(mSG[mSG.Row, 14]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 17]) != 0.0))
											{
												mSG[mSG.Row, 22] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 14]) * (Conversion.Val(mSG[mSG.Row, 17]) + Conversion.Val(mSG[mSG.Row, 18])) / 100.0), "0.000");
											}
										}
										Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_LBR_RATE"]);
										double num21 = DC_Main.Fnv(ref Value);
										dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
										if ((num21 != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) == 0.0))
										{
											AxMSFlexGrid obj12 = mSG;
											int row12 = mSG.Row;
											Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_LBR_RATE"]);
											double num22 = DC_Main.Fnv(ref Value);
											dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
											obj12[row12, 31] = Strings.Format((object)num22, "0.00");
											mSG[mSG.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["AC_LBR_TYPE"], (object)""));
										}
									}
									else
									{
										DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG[mSG.Row, 2] + "' ";
										dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
										if (dataTable3.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")) != 0.0)
										{
											AxMSFlexGrid obj13 = mSG;
											int row13 = mSG.Row;
											DataRow dataRow;
											object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["IT_TOUCH"]);
											double num23 = DC_Main.Fnv(ref Value);
											dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
											obj13[row13, 17] = Strings.Format((object)num23, "0.00");
											if (Conversion.Val(nWestPrc.Text) == 0.0)
											{
												AxMSFlexGrid obj14 = mSG;
												int row14 = mSG.Row;
												Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["IT_WEST"]);
												double num24 = DC_Main.Fnv(ref Value);
												dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
												obj14[row14, 18] = Strings.Format((object)num24, "0.00");
											}
											if ((Conversion.Val(mSG[mSG.Row, 14]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 17]) != 0.0))
											{
												mSG[mSG.Row, 22] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 14]) * (Conversion.Val(mSG[mSG.Row, 17]) + Conversion.Val(mSG[mSG.Row, 18])) / 100.0), "0.000");
											}
										}
									}
								}
							}
							int num25 = 0;
							int num26 = DtIdtl.Rows.Count - 1;
							int num27 = num26;
							for (int i = 0; i <= num27; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num25][26], (object)Conversion.Val(mSG[DC_Main.i, 57]), false))
								{
									DtIdtl.Rows[num25].Delete();
									DtIdtl.AcceptChanges();
									num25--;
								}
								num25++;
							}
							MSG_IDTL_CLEAR();
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 52] + " ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.i = 0;
							while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
							{
								dr = DtIdtl.NewRow();
								dr[26] = Conversion.Val(MSG[mSG.Row, 57]);
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
								dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
								dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
								dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
								dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
								dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
								dr[16] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
								dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
								dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
								dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
								dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
								dr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
								dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
								dr[24] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
								dr[25] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
								dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
								DtIdtl.Rows.Add(dr);
								DC_Main.i++;
							}
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							CommPassTotal();
							MSG_TOT_FILL();
							if (Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) == 0)
							{
								MsgOldRow = 0;
								BILL_TOTAL();
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
							DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "' ";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) == 0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" AND BULK_SALE <> 'N' ORDER BY A.IT_NAME"));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM (APR_DETL AS C LEFT JOIN ITEM_MAST AS A ON C.CO_CODE = A.CO_CODE AND C.IT_CODE = A.IT_CODE) LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND C.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" AND C.EMP_CODE = '"), (object)tEmpCode.Text), (object)"' AND C.TAG_NO = 'N' AND C.BOOK_NAME IN ('EMP ISU','EMP REC','TOUR SALES') GROUP BY A.IT_NAME,A.IT_CODE,B.GR_NAME,A.PR_CODE,A.IT_TYPE,A.TAG_TYPE HAVING SUM(CASE WHEN C.BOOK_NAME = 'EMP ISU' THEN C.ITM_GWT ELSE -C.ITM_GWT END) > 0 ORDER BY A.IT_NAME"));
								}
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
										mSG[mSG.Row, 3] = DC_Main.ColValue[0];
										mSG[mSG.Row, 61] = DC_Main.ColValue[3];
										mSG[mSG.Row, 59] = DC_Main.ColValue[4];
										mSG[mSG.Row, 60] = DC_Main.ColValue[4];
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
							mSG[mSG.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
							mSG[mSG.Row, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
							if (Conversion.Val((object)mSG[9]) != 0.0 && ((Operators.CompareString(mSG[mSG.Row, 62], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)))
							{
								AxMSFlexGrid obj2 = mSG;
								int row2 = mSG.Row;
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_BAG_WT"]);
								double num5 = DC_Main.Fnv(ref Value);
								dataRow["IT_BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
								obj2[row2, 9] = Strings.Format((object)num5, "0.000");
							}
							ItmStk(MSG.Row, "I");
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) != 0 && Operators.CompareString(mSG[mSG.Row, 1], "", false) == 0 && Operators.CompareString(mSG[mSG.Row, 59], "O", false) != 0)
							{
								DC_Main.RsQry = "SELECT IT_CODE,SUM(CASE WHEN BOOK_NAME = 'EMP ISU' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME IN ('EMP ISU','EMP REC','TOUR SALES') AND EMP_CODE = '" + tEmpCode.Text + "' AND IT_CODE = '" + mSG[mSG.Row, 2] + "' AND TAG_NO = 'N' GROUP BY IT_CODE HAVING SUM(CASE WHEN BOOK_NAME = 'EMP ISU' THEN ITM_GWT ELSE -ITM_GWT END) > 0";
								DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Tbl.Rows.Count <= 0)
								{
									Interaction.MsgBox((object)"You Have No item Stock....Please Tour Isu First...", (MsgBoxStyle)0, (object)null);
									mSG[mSG.Row, 2] = "";
									mSG[mSG.Row, 3] = "";
									TEXT_ENTRY.Text = "";
									return;
								}
								AxMSFlexGrid obj3 = mSG;
								int row3 = mSG.Row;
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["GrWt"]);
								double num6 = DC_Main.Fnv(ref Value);
								dataRow["GrWt"] = RuntimeHelpers.GetObjectValue(Value);
								obj3[row3, 12] = Strings.Format((object)num6, "0.000");
							}
							if ((Operators.CompareString(mSG[mSG.Row, 62], "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0))
							{
								DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
								DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (dataTable2.Rows.Count > 0)
								{
									DataRow dataRow;
									object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
									double num7 = DC_Main.Fnv(ref Value);
									dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
									double num8 = DC_Main.Fnv(ref Value);
									dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
									if (num7 + num8 != 0.0)
									{
										AxMSFlexGrid obj4 = mSG;
										int row4 = mSG.Row;
										Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
										double num9 = DC_Main.Fnv(ref Value);
										dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
										obj4[row4, 17] = Strings.Format((object)num9, "0.00");
										if (Conversion.Val(nWestPrc.Text) == 0.0)
										{
											AxMSFlexGrid obj5 = mSG;
											int row5 = mSG.Row;
											Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
											double num10 = DC_Main.Fnv(ref Value);
											dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
											obj5[row5, 18] = Strings.Format((object)num10, "0.00");
										}
										if ((Conversion.Val(mSG[mSG.Row, 14]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 17]) != 0.0))
										{
											mSG[mSG.Row, 22] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 14]) * (Conversion.Val(mSG[mSG.Row, 17]) + Conversion.Val(mSG[mSG.Row, 18])) / 100.0), "0.000");
										}
									}
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_LBR_RATE"]);
									double num11 = DC_Main.Fnv(ref Value);
									dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
									if ((num11 != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) == 0.0))
									{
										AxMSFlexGrid obj6 = mSG;
										int row6 = mSG.Row;
										Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_LBR_RATE"]);
										double num12 = DC_Main.Fnv(ref Value);
										dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
										obj6[row6, 31] = Strings.Format((object)num12, "0.00");
										mSG[mSG.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[0]["AC_LBR_TYPE"], (object)""));
									}
								}
								else
								{
									DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG[mSG.Row, 2] + "' ";
									dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable2.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["IT_WEST"], (object)"")) != 0.0)
									{
										AxMSFlexGrid obj7 = mSG;
										int row7 = mSG.Row;
										DataRow dataRow;
										object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["IT_TOUCH"]);
										double num13 = DC_Main.Fnv(ref Value);
										dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
										obj7[row7, 17] = Strings.Format((object)num13, "0.00");
										if (Conversion.Val(nWestPrc.Text) == 0.0)
										{
											AxMSFlexGrid obj8 = mSG;
											int row8 = mSG.Row;
											Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["IT_WEST"]);
											double num14 = DC_Main.Fnv(ref Value);
											dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
											obj8[row8, 18] = Strings.Format((object)num14, "0.00");
										}
										if ((Conversion.Val(mSG[mSG.Row, 14]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 17]) != 0.0))
										{
											mSG[mSG.Row, 22] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 14]) * (Conversion.Val(mSG[mSG.Row, 17]) + Conversion.Val(mSG[mSG.Row, 18])) / 100.0), "0.000");
										}
									}
								}
							}
							if (Conversion.Val((object)mSG[31]) != 0.0 && Conversions.ToBoolean(Operators.AndObject((object)(Conversion.Val(mSG[mSG.Row, 31]) == 0.0), Operators.CompareObjectNotEqual(DC_Main.Tbl.Rows[0]["IT_LBR_RATE"], (object)0, false))) && ((Operators.CompareString(mSG[mSG.Row, 62], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)))
							{
								AxMSFlexGrid obj9 = mSG;
								int row9 = mSG.Row;
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
								double num15 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								obj9[row9, 31] = Strings.Format((object)num15, "0.00");
							}
							break;
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
						case 12:
							if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 58], "P", false) != 0))
							{
								((Control)TEXT_ENTRY).Focus();
							}
							else if (MSG[1] == 0)
							{
								mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
								CommPassTotal();
								((Control)TEXT_ENTRY).Visible = false;
								((Control)pnlOthDetl).Visible = true;
								MSG_IDTL.Row = MSG_IDTL.Rows - 1;
								MSG_IDTL.Col = 1;
								MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
								((Control)TEXT_IDTL).Focus();
								((TextBoxBase)TEXT_IDTL).SelectAll();
							}
							else
							{
								mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
								CommPassTotal();
								((Control)TEXT_ENTRY).Visible = false;
								MSG_IDTL.Row = MSG_IDTL.Rows - 1;
								MSG_IDTL.Col = 1;
								MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
								((Control)TEXT_IDTL).Focus();
								((TextBoxBase)TEXT_IDTL).SelectAll();
							}
							return;
						case 37:
							if (mSG.Row == mSG.Rows - 1)
							{
								if (Operators.CompareString(DC_Main.MsTchAutoSave, "Y", false) == 0)
								{
									DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + MSG[MSG.Row, 2] + "'";
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count == 0)
									{
										DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE,AC_LBR_TYPE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG[mSG.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 17])) + "," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 18])) + "," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 31])) + ",'" + mSG[mSG.Row, 30] + "') ");
									}
									else if ((Conversion.Val(mSG[mSG.Row, 17]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 18]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) != 0.0))
									{
										DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 17])) + ", AC_WEST = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 18])) + ",AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 31])) + ", AC_LBR_TYPE = '" + mSG[mSG.Row, 30] + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
									}
									else if ((Conversion.Val(mSG[mSG.Row, 17]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 18]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) == 0.0))
									{
										DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 17])) + ", AC_WEST = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 18])) + ",AC_LBR_RATE = 0, AC_LBR_TYPE = '' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
									}
									else if ((Conversion.Val(mSG[mSG.Row, 17]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 18]) == 0.0))
									{
										DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 17])) + ", AC_WEST = 0,AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 31])) + ", AC_LBR_TYPE = '" + mSG[mSG.Row, 30] + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
									}
								}
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								if (MSG[1] == 0)
								{
									MSG.Col = 2;
								}
								else
								{
									MSG.Col = 1;
								}
								MsgClear = false;
								CommPassAdd();
							}
							else
							{
								mSG.Row += 1;
								if (MSG[1] == 0)
								{
									MSG.Col = 2;
								}
								else
								{
									MSG.Col = 1;
								}
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
		}
		mSG = null;
	}

	private void ItmStk(int Row, string Type)
	{
		if (Operators.CompareString(MSG[Row, 59], "O", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(Type, "R", false) == 0)
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG_PR[Row, 1] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TAG_NO = 'N'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P = ", dataTable.Rows[0]["StkPcs"]), (object)"  G = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			}
			else
			{
				lblItStock.Text = "Itm Stk :";
			}
		}
		else if (Operators.CompareString(MSG[Row, 1], "", false) == 0)
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TAG_NO = 'N'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P = ", dataTable.Rows[0]["StkPcs"]), (object)"  G = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			}
			else
			{
				lblItStock.Text = "Itm Stk :";
			}
		}
		else
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P = ", dataTable.Rows[0]["StkPcs"]), (object)"  G = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			}
			else
			{
				lblItStock.Text = "Itm Stk :";
			}
		}
	}

	private void TR_TOUR_SALE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_1114: Unknown result type (might be due to invalid IL or missing references)
		//IL_1119: Unknown result type (might be due to invalid IL or missing references)
		//IL_1123: Expected O, but got Unknown
		//IL_1148: Unknown result type (might be due to invalid IL or missing references)
		//IL_114d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1157: Expected O, but got Unknown
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1181: Unknown result type (might be due to invalid IL or missing references)
		//IL_118b: Expected O, but got Unknown
		//IL_11b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bf: Expected O, but got Unknown
		//IL_11fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_120d: Expected O, but got Unknown
		//IL_1227: Unknown result type (might be due to invalid IL or missing references)
		//IL_122c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1236: Expected O, but got Unknown
		//IL_1250: Unknown result type (might be due to invalid IL or missing references)
		//IL_1255: Unknown result type (might be due to invalid IL or missing references)
		//IL_125f: Expected O, but got Unknown
		//IL_1279: Unknown result type (might be due to invalid IL or missing references)
		//IL_127e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1288: Expected O, but got Unknown
		//IL_12a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b1: Expected O, but got Unknown
		//IL_12cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12da: Expected O, but got Unknown
		//IL_1302: Unknown result type (might be due to invalid IL or missing references)
		//IL_1309: Expected O, but got Unknown
		//IL_13ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f9: Expected O, but got Unknown
		//IL_1481: Unknown result type (might be due to invalid IL or missing references)
		//IL_1486: Unknown result type (might be due to invalid IL or missing references)
		//IL_1490: Expected O, but got Unknown
		//IL_1529: Unknown result type (might be due to invalid IL or missing references)
		//IL_152e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1534: Expected O, but got Unknown
		//IL_15e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f1: Expected O, but got Unknown
		//IL_1679: Unknown result type (might be due to invalid IL or missing references)
		//IL_167e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1688: Expected O, but got Unknown
		//IL_16ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bc: Expected O, but got Unknown
		//IL_16e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f3: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj21 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj22 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj23 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj25 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj26 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj27 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj29 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj30 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj33 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj34 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj35 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj36 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj37 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj38 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj39 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj40 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj41 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj42 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj43 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj44 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj45 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj46 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
				ComboBox obj47 = cboItemTyp;
				object? obj48 = colorConverter.ConvertFromString("233, 235, 240");
				obj47.BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj49 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj50 = lblBook;
				object? obj51 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj50).ForeColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj52 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj53 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj54 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj55 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj55 != null) ? ((Color)obj55) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj56 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj57 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj58 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj59 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj60 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj61 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj62 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj63 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj64 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj65 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj66 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj67 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj68 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj68 != null) ? ((Color)obj68) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj69 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj69 != null) ? ((Color)obj69) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj70 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj70 != null) ? ((Color)obj70) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj71 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj71 != null) ? ((Color)obj71) : default(Color));
				ComboBox obj72 = cboItemTyp;
				object? obj73 = colorConverter.ConvertFromString("238, 244, 236");
				obj72.BackColor = ((obj73 != null) ? ((Color)obj73) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG_PR.Font.Style);
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG_PR_TOT.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
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
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
						{
							NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)tAdd1).Font.Size * (1.0 + num2));
				Font font3 = ((Control)tAdd1).Font;
				try
				{
					foreach (object control5 in ((Control)PanelAdd).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((Control)chkWapp).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
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
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			if (Operators.CompareString(DC_Main.MsWhBillImg, "Y", false) == 0)
			{
				((Control)chkItmImage).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "B", false) == 0)
			{
				((Control)chkSilverCut).Visible = true;
			}
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
			((Control)lblWestPrc).Visible = true;
			((Control)nWestPrc).Visible = true;
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				((Control)nItProfit).Visible = true;
				((Control)nBillProfit).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0)
			{
				((TextBoxBase)tEmpCode).ReadOnly = false;
			}
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
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
		nConvPrc.Text = "99.50";
		if (Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0)
		{
			tEmpCode.Text = "";
		}
		else
		{
			tEmpCode.Text = "001";
		}
		chkHuIdPrint.Checked = false;
		UsUPdate = "N";
		UsDelete = "N";
		RowDelete = false;
		chkSilverCut.Checked = false;
		((Control)PnlSilverCut).Visible = false;
		((Control)pnlOthDetl).Visible = false;
		nTotSilverCr.Text = "";
		nTotSilverDr.Text = "";
		nSlvrCrAmt.Text = "";
		nSlvrDrAmt.Text = "";
		nSlvrFineRate.Text = "";
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
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		lblItStock.Text = "Itm Stock :";
		((Control)PanelAdd).Visible = false;
		chkWapp.Checked = false;
		OldValTot = 0.0;
		NewValTot = 0.0;
		TotCrFine = 0.0;
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		PrOthAmtLess = 0.0;
		OldConRate = 0.0;
		SlSilverFine = 0.0;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpGold.Text = ": Gold";
		((Control)LOpGold).ForeColor = Color.Black;
		LOpSilver.Text = ": Silvr";
		((Control)LOpSilver).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		lClGold.Text = ": Gold";
		((Control)lClGold).ForeColor = Color.Black;
		LClSilver.Text = ": Silvr";
		((Control)LClSilver).ForeColor = Color.Black;
		AcGstType = "L";
		lblDiffAmt.Text = "Diff Amount";
		if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
		{
			lblRate.Text = "10gm Rate";
			CurRatePar = "T";
		}
		else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
		{
			lblRate.Text = "Kg Rate";
			CurRatePar = "K";
		}
		else
		{
			lblRate.Text = "1gm Rate";
			CurRatePar = "G";
		}
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_PR_CLEAR();
		MSG2_CLEAR();
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsUserEmpCode, "", false) != 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			else
			{
				((TextBoxBase)tEmpCode).ReadOnly = false;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				nAcDrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_AMT"]), "0.00");
				OldAcDrAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_AMT"]), "0.00"));
				nAcCrFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_FINE"]), "0.000");
				OldAcCrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_FINE"]), "0.000"));
				nAcCrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_AMT"]), "0.00");
				OldAcCrAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_AMT"]), "0.00"));
				nAcDrFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_FINE"]), "0.000");
				OldAcDrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_FINE"]), "0.000"));
				nConvRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_RATE"]), "0.00");
				OldConRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_RATE"]), "0.00"));
				nConvPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_PRC"]), "0.00");
				nFineRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["FINE_RATE"]), "0.00");
				OldFineRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["FINE_RATE"]), "0.00"));
				CurRatePar = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["RATE_PAR"], (object)""));
				if (Operators.CompareString(CurRatePar, "T", false) == 0)
				{
					lblRate.Text = "10gm Rate";
				}
				else if (Operators.CompareString(CurRatePar, "K", false) == 0)
				{
					lblRate.Text = "Kg Rate";
				}
				else
				{
					lblRate.Text = "1gm Rate";
				}
				nTotFineCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_FINE_CR"]), "0.000");
				nTotFineDr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_FINE_DR"]), "0.000");
				nFineKsrCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_CR"]), "0.000");
				nFineKsrDr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_DR"]), "0.000");
				TotDrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_FINE"]), "0.000"));
				TotCrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_FINE"]), "0.000"));
				if (Operators.ConditionalCompareObjectEqual(RsData.Rows[0]["IT_TYPE"], (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				nSlvrFineCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SLV_FINE_CR"]), "0.000");
				nSlvrFineDr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SLV_FINE_DR"]), "0.000");
				nSlvrCrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SLV_AMT_CR"]), "0.00");
				nSlvrDrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SLV_AMT_DR"]), "0.00");
				nSlvrFineRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SLV_FINE_RATE"]), "0.00");
				MSG2_TOTAL[1, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_NET_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CARD_AMT"]), "0.00");
				MSG2_TOTAL[4, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_ADV_AMT"]), "0.00");
				MSG2_TOTAL[5, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["SL_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[6, 4] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SL_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[7, 4] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_NET_AMT"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CARD_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_ADV_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_KASAR_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["PR_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[6, 3] = Strings.Format((object)num3, "0.00");
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_BILL_OS"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["PR_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL4[7, 3] = Strings.Format((object)num4, "0.00");
				MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[2, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[2, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[3, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[3, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
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
				if (DC_Main.MsAcGoldOpBal > 0.0)
				{
					LOpGold.Text = Strings.Format((object)DC_Main.MsAcGoldOpBal, "0.000") + " : Cr Gold";
					((Control)LOpGold).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcGoldOpBal < 0.0)
				{
					LOpGold.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcGoldOpBal), "0.000") + " : Dr Gold";
					((Control)LOpGold).ForeColor = Color.Red;
				}
				else
				{
					LOpGold.Text = ": Gold";
				}
				if (DC_Main.MsAcSilverOpBal > 0.0)
				{
					LOpSilver.Text = Strings.Format((object)DC_Main.MsAcSilverOpBal, "0.000") + " : Cr Silvr";
					((Control)LOpSilver).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcSilverOpBal < 0.0)
				{
					LOpSilver.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcSilverOpBal), "0.000") + " : Dr Silvr";
					((Control)LOpSilver).ForeColor = Color.Red;
				}
				else
				{
					LOpSilver.Text = ": Silvr";
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
				if (DC_Main.MsAcGoldClBal > 0.0)
				{
					lClGold.Text = Strings.Format((object)DC_Main.MsAcGoldClBal, "0.000") + " : Cr Gold";
					((Control)lClGold).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcGoldClBal < 0.0)
				{
					lClGold.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcGoldClBal), "0.000") + " : Dr Gold";
					((Control)lClGold).ForeColor = Color.Red;
				}
				else
				{
					lClGold.Text = ": Gold";
				}
				if (DC_Main.MsAcSilverClBal > 0.0)
				{
					LClSilver.Text = Strings.Format((object)DC_Main.MsAcSilverClBal, "0.000") + " : Cr Silvr";
					((Control)LClSilver).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcSilverClBal < 0.0)
				{
					LClSilver.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcSilverClBal), "0.000") + " : Dr Silvr";
					((Control)LClSilver).ForeColor = Color.Red;
				}
				else
				{
					LClSilver.Text = ": Silvr";
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
				TodayFineRate();
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 74] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"]))), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					if ((Conversion.Val(mSG[DC_Main.i + 1, 14]) != 0.0) & (Conversion.Val(mSG[DC_Main.i + 1, 17]) != 0.0))
					{
						mSG[DC_Main.i + 1, 23] = Strings.Format((object)((Conversion.Val(mSG[DC_Main.i + 1, 14]) + Conversion.Val(mSG[DC_Main.i + 1, 16])) * (Conversion.Val(mSG[DC_Main.i + 1, 17]) + Conversion.Val(mSG[DC_Main.i + 1, 18])) / 100.0 - Conversion.Val(mSG[DC_Main.i + 1, 20]) + Conversion.Val(mSG[DC_Main.i + 1, 21])), "0.000");
					}
					else
					{
						mSG[DC_Main.i + 1, 23] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i + 1, 14]) + Conversion.Val(mSG[DC_Main.i + 1, 16])), "0.000");
					}
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.00");
					mSG[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 62] = "E";
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 76] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 77] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num5 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num5, 78] = Conversions.ToString(num6);
					mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 82] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 83] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 86] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 87] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 90] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
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
				int num7 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
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
					dr[26] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
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
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[16] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[24] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[25] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM RATE_CUT_REC AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsPrDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(RsPrDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"]))), "0.00");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					if ((Conversion.Val(mSG_PR[DC_Main.i + 1, 10]) != 0.0) & (Conversion.Val(mSG_PR[DC_Main.i + 1, 12]) != 0.0))
					{
						mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)((Conversion.Val(mSG_PR[DC_Main.i + 1, 10]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 11])) * (Conversion.Val(mSG_PR[DC_Main.i + 1, 12]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 13]) - Conversion.Val(mSG_PR[DC_Main.i + 1, 14])) / 100.0), "0.000");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)(Conversion.Val(mSG_PR[DC_Main.i + 1, 10]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 11])), "0.000");
					}
					mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 23] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				BILL_TOTAL();
				if (Conversion.Val(nSlvrFineRate.Text) != 0.0)
				{
					nSlvrFinOs.Text = Conversions.ToString(Conversion.Val(nTotSilverDr.Text) + Conversion.Val(nSlvrFineDr.Text) - (Conversion.Val(nTotSilverCr.Text) + Conversion.Val(nSlvrFineCr.Text)));
					chkSilverCut.Checked = true;
					((Control)PnlSilverCut).Visible = true;
				}
				OldValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 42]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG2_TOTAL[7, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 42]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG2_TOTAL[7, 3]);
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (RowDelete)
		{
			Interaction.MsgBox((object)"Please Save Voucher Becuse Item Row Is Delete", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void TR_TOUR_SALE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_TOUR_SALE_KeyPress(object sender, KeyPressEventArgs e)
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_4906: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						DC_Main.DefaulterAc(tAcCode.Text);
						if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[7, 4]) + Conversion.Val(nDiffFine.Text) > 0.0))
						{
							Interaction.MsgBox((object)"You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...", (MsgBoxStyle)0, (object)null);
							DC_Main.MsDefaulterAc = "N";
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
							((Control)tEmpCode).Focus();
							goto end_IL_0001;
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM037NEKU", false) == 0 && Operators.CompareString(tBillNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert Ref No Then Try....", (MsgBoxStyle)0, (object)null);
							((Control)tBillNo).Focus();
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if ((Conversion.Val(MSG2_TOTAL[2, 3]) + Conversion.Val(MSG2_TOTAL[2, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[2, 5], "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if ((Conversion.Val(MSG2_TOTAL[3, 3]) + Conversion.Val(MSG2_TOTAL[3, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[3, 5], "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Card Bank Account And Try Because Card Amt <> 0......", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						((Control)BtnSave).Enabled = false;
						if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
						{
							Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
						{
							Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(tAcCode.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert Party and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							((Control)tAcCode).Focus();
							goto end_IL_0001;
						}
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (true)
						{
							if (DC_Main.i <= num3)
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
									else if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
									{
										DC_Main.RsQry = "Select A.TAG_NO,A.VCH_SRNO FROM APR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + MSG[DC_Main.i, 1] + "' AND BOOK_NAME = 'EMP ISU' AND A.EMP_CODE = '" + tEmpCode.Text + "' AND A.ISU_REC = 'N'";
										DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
										if (DC_Main.Tbl.Rows.Count > 0)
										{
											MSG[DC_Main.i, 52] = Conversions.ToString(DC_Main.Tbl.Rows[0]["VCH_SRNO"]);
										}
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
								if ((Operators.CompareString(MSG[DC_Main.i, 2], "", false) == 0) & (Conversion.Val(MSG[DC_Main.i, 12]) + Conversion.Val(MSG[DC_Main.i, 32]) + Conversion.Val(MSG[DC_Main.i, 37]) + Conversion.Val(MSG[DC_Main.i, 36]) != 0.0))
								{
									Interaction.MsgBox((object)("Please Select Item Code In Row " + Conversions.ToString(DC_Main.i) + " and Try......"), (MsgBoxStyle)0, (object)null);
									break;
								}
								DC_Main.i++;
								continue;
							}
							MSG_TOT_FILL();
							MSG_PR_TOT_FILL();
							ProjectData.ClearProjectError();
							num2 = 2;
							if (Operators.CompareString(EntryMode, "A", false) == 0)
							{
								DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
								DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Rshlp.Rows.Count > 0)
								{
									DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
							DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
							DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
							DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
							if ((Conversion.Val(MSG_TOT[0, 36]) != 0.0) | (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG2_TOTAL[1, 3]) + Conversion.Val(MSG2_TOTAL[1, 4]) + Conversion.Val(nTotFineCr.Text) + Conversion.Val(nTotFineDr.Text) != 0.0))
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
								DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
								dataRow2["BILL_NO"] = tBillNo.Text;
								dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
								dataRow2["AC_CODE"] = tAcCode.Text;
								dataRow2["AC_NAME"] = tAcName.Text;
								dataRow2["DR_AMT"] = Conversion.Val(nAcDrAmt.Text);
								dataRow2["CR_FINE"] = Conversion.Val(nAcCrFine.Text);
								dataRow2["CR_AMT"] = Conversion.Val(nAcCrAmt.Text);
								dataRow2["DR_FINE"] = Conversion.Val(nAcDrFine.Text);
								dataRow2["CONV_RATE"] = Conversion.Val(nConvRate.Text);
								dataRow2["CONV_PRC"] = Conversion.Val(nConvPrc.Text);
								dataRow2["RATE_PAR"] = CurRatePar;
								dataRow2["FINE_RATE"] = Conversion.Val(nFineRate.Text);
								dataRow2["SL_FINE"] = TotDrFine + Conversion.Val(MSG_TOT[0, 35]);
								dataRow2["PR_FINE"] = TotCrFine + Conversion.Val(MSG_PR_TOT[0, 28]);
								dataRow2["TOT_FINE_CR"] = Conversion.Val(nTotFineCr.Text);
								dataRow2["TOT_FINE_DR"] = Conversion.Val(nTotFineDr.Text);
								dataRow2["KSR_FINE_CR"] = Conversion.Val(nFineKsrCr.Text);
								dataRow2["KSR_FINE_DR"] = Conversion.Val(nFineKsrDr.Text);
								dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
								dataRow2["SILVER_FINE_DR"] = Conversion.Val(MSG_TOT[0, 24]);
								dataRow2["SILVER_FINE_CR"] = Conversion.Val(MSG_PR_TOT[0, 17]);
								dataRow2["SLV_FINE_CR"] = Conversion.Val(nSlvrFineCr.Text);
								dataRow2["SLV_FINE_DR"] = Conversion.Val(nSlvrFineDr.Text);
								dataRow2["SLV_AMT_CR"] = Conversion.Val(nSlvrCrAmt.Text);
								dataRow2["SLV_AMT_DR"] = Conversion.Val(nSlvrDrAmt.Text);
								dataRow2["SLV_FINE_RATE"] = Conversion.Val(nSlvrFineRate.Text);
								dataRow2["SL_ITM_AMT"] = Conversion.Val(MSG_TOT[0, 28]);
								dataRow2["SL_LBR_AMT"] = Conversion.Val(MSG_TOT[0, 32]);
								dataRow2["SL_OTH_AMT"] = Conversion.Val(MSG_TOT[0, 33]) - SlOthAmtLess;
								dataRow2["SL_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 4]);
								dataRow2["SL_TAX_AMT"] = 0;
								dataRow2["SL_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[1, 4]);
								dataRow2["SL_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[2, 4]);
								dataRow2["SL_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]);
								dataRow2["SL_ADV_AMT"] = Conversion.Val(MSG2_TOTAL[4, 4]);
								dataRow2["SL_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[5, 4]);
								dataRow2["SL_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[6, 4]);
								dataRow2["SL_BILL_OS"] = Conversion.Val(MSG2_TOTAL[7, 4]);
								dataRow2["TAX_PRC"] = 0;
								dataRow2["PR_ITM_AMT"] = Conversion.Val(MSG_PR_TOT[0, 21]);
								dataRow2["PR_LBR_AMT"] = Conversion.Val(MSG_PR_TOT[0, 25]);
								dataRow2["PR_OTH_AMT"] = Conversion.Val(MSG_PR_TOT[0, 26]) - PrOthAmtLess;
								dataRow2["PR_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
								dataRow2["PR_TAX_AMT"] = 0;
								dataRow2["PR_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
								dataRow2["PR_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
								dataRow2["PR_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
								dataRow2["PR_ADV_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
								dataRow2["PR_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
								dataRow2["PR_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
								dataRow2["PR_BILL_OS"] = Conversion.Val(MSG2_TOTAL[7, 3]);
								dataRow2["CARD_AC"] = MSG2_TOTAL[3, 5];
								dataRow2["BANK_AC"] = MSG2_TOTAL[2, 5];
								dataRow2["CHQ_NO"] = MSG2_TOTAL[2, 2];
								dataRow2["ADD1"] = tAdd1.Text;
								dataRow2["ADD2"] = tAdd2.Text;
								dataRow2["ADD3"] = tAdd3.Text;
								dataRow2["CITY"] = tCity.Text;
								dataRow2["MOBILE"] = tMobile.Text;
								dataRow2["CR_DAYS"] = Conversion.Val(nCrDays.Text);
								dataRow2["INT_DAYS"] = 0;
								dataRow2["INT_PRC_FINE"] = 0;
								dataRow2["INT_FINE"] = 0;
								dataRow2["EMP_CODE"] = tEmpCode.Text;
								dataRow2["VCH_DESC"] = tVchDesc.Text;
								dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								dataRow2["DATA_TRFR"] = "N";
								dataRow2["MAIN_USER"] = MainUser;
								dataRow2["USER_UPDATE"] = "N";
								dataRow2["USER_DELETE"] = "N";
								dataRow2["MOB_ENTRY_SAVE"] = "Y";
								RsData.Rows.Add(dataRow2);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
								RsData.Clear();
							}
							DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
							RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow3 = RsDetl.NewRow();
							int num4 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num4)
							{
								AxMSFlexGrid mSG = MSG;
								if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 36]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 12]) + Conversion.Val(mSG[DC_Main.i, 37]) + Conversion.Val(mSG[DC_Main.i, 33]) != 0.0))
								{
									dataRow3["CO_CODE"] = DC_Main.MCo_code;
									dataRow3["LC_CODE"] = DC_Main.MLc_code;
									dataRow3["CO_YEAR"] = DC_Main.MCo_year;
									dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
									dataRow3["VCH_NO"] = tVchNo.Text;
									dataRow3["VCH_DATE"] = mVchDate.Text;
									dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
									dataRow3["AC_CODE"] = tAcCode.Text;
									dataRow3["VCH_TYPE"] = FormBookSname;
									dataRow3["INOUT_TYPE"] = FormBookInOut;
									dataRow3["ENTRY_TYPE"] = "W";
									dataRow3["BOOK_NAME"] = FormMainBook;
									dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
									dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 57]);
									dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
									dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 3];
									if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
									{
										dataRow3["TAG_NO"] = "N";
									}
									else
									{
										dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
									}
									dataRow3["TBL_CODE"] = mSG[DC_Main.i, 4];
									dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 5];
									dataRow3["ITM_COLOR"] = mSG[DC_Main.i, 6];
									dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 7];
									dataRow3["HM_ID"] = mSG[DC_Main.i, 8];
									dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 9]);
									dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 10]);
									dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 12]);
									dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 13]);
									dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 14]);
									dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 16]);
									dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 17]);
									dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 18]);
									dataRow3["LESS_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 19]);
									dataRow3["LESS_WT"] = Conversion.Val(mSG[DC_Main.i, 20]);
									dataRow3["HM_FINE"] = Conversion.Val(mSG[DC_Main.i, 21]);
									dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 22]);
									dataRow3["SILVER_FINE"] = Conversion.Val(mSG[DC_Main.i, 24]);
									dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 29]);
									dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 30];
									dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 31]);
									dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 32]);
									dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 33]);
									dataRow3["ITM_OTH_RATE"] = Conversion.Val(mSG[DC_Main.i, 34]);
									dataRow3["ITM_OTH_FINE"] = Conversion.Val(mSG[DC_Main.i, 35]);
									dataRow3["CONV_RATE"] = Conversion.Val(mSG[DC_Main.i, 25]);
									dataRow3["CONV_PRC"] = Conversion.Val(mSG[DC_Main.i, 26]);
									dataRow3["PRM_AMT"] = 0;
									dataRow3["MCX_RATE"] = 0;
									dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 27]);
									dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 28]);
									dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 36]);
									dataRow3["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 38]);
									dataRow3["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 39]);
									dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 37]);
									dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 42]);
									dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 45]);
									dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 46]);
									dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 47]);
									dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 53]);
									dataRow3["KR_NAME"] = mSG[DC_Main.i, 40];
									dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 58];
									dataRow3["IT_TYPE"] = mSG[DC_Main.i, 59];
									dataRow3["PR_CODE"] = mSG[DC_Main.i, 61];
									dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 52]);
									dataRow3["ISU_NO"] = mSG[DC_Main.i, 75];
									dataRow3["ISU_LC_CODE"] = DC_Main.MLc_code;
									dataRow3["ISU_YRCD"] = mSG[DC_Main.i, 76];
									dataRow3["ISU_DBCD"] = mSG[DC_Main.i, 77];
									dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 78]);
									dataRow3["HM_ID2"] = mSG[DC_Main.i, 81];
									dataRow3["HM_ID3"] = mSG[DC_Main.i, 82];
									dataRow3["HM_ID4"] = mSG[DC_Main.i, 83];
									dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 84]);
									dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 85]);
									dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 86]);
									dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 87]);
									dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow3["MAIN_USER"] = MainUser;
									dataRow3["EMP_CODE"] = tEmpCode.Text;
									dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 90];
									RsDetl.Rows.Add(dataRow3);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
									RsDetl.Clear();
								}
								mSG = null;
								DC_Main.i++;
							}
							if (Operators.CompareString(DC_Main.MsWhBillImg, "Y", false) == 0)
							{
								DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								int num5 = MSG.Rows - 1;
								DC_Main.i = 1;
								while (DC_Main.i <= num5)
								{
									AxMSFlexGrid mSG2 = MSG;
									if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0)
									{
										DC_Main.MsImageNo = mSG2[DC_Main.i, 1] + "_" + mSG2[DC_Main.i, 52];
										DC_Main.MsImageType = "TagImage";
										DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
										if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
										{
											PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
											MemoryStream memoryStream = new MemoryStream();
											PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
											byte[] buffer = memoryStream.GetBuffer();
											DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG2[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 52]))) ?? "";
											DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
											DC_Main.MsInsertData();
											DataRow dataRow4 = dataTable2.NewRow();
											dataRow4["CO_CODE"] = DC_Main.MCo_code;
											dataRow4["LC_CODE"] = DC_Main.MLc_code;
											dataRow4["TAG_NO"] = mSG2[DC_Main.i, 1];
											dataRow4["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 52]);
											dataRow4["TAG_IMAGE"] = buffer;
											dataTable2.Rows.Add(dataRow4);
											((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
											dataTable2.Clear();
										}
									}
									mSG2 = null;
									DC_Main.i++;
								}
							}
							DC_Main.RsQry = "SELECT * FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
							RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow5 = RsIdtl.NewRow();
							int num6 = 0;
							int num7 = DtIdtl.Rows.Count - 1;
							for (int i = 0; i <= num7; i++)
							{
								DataTable dtIdtl = DtIdtl;
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21])) != 0.0)
								{
									int num8 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26])));
									int num9 = MSG.Rows - 1;
									DC_Main.M = 1;
									while (DC_Main.M <= num9)
									{
										if ((double)num8 == Conversion.Val(MSG[DC_Main.M, 57]))
										{
											num6 = (int)Math.Round(Conversion.Val(MSG[DC_Main.M, 0]));
											break;
										}
										DC_Main.M++;
									}
									dataRow5["CO_CODE"] = DC_Main.MCo_code;
									dataRow5["LC_CODE"] = DC_Main.MLc_code;
									dataRow5["CO_YEAR"] = DC_Main.MCo_year;
									dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
									dataRow5["VCH_NO"] = tVchNo.Text;
									dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
									dataRow5["VCH_DATE"] = mVchDate.Text;
									dataRow5["AC_CODE"] = tAcCode.Text;
									dataRow5["VCH_TYPE"] = FormBookSname;
									dataRow5["INOUT_TYPE"] = FormBookInOut;
									dataRow5["ENTRY_TYPE"] = "W";
									dataRow5["BOOK_NAME"] = FormMainBook;
									dataRow5["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26]));
									dataRow5["TAG_NO"] = MSG[num6, 1];
									dataRow5["VCH_SRNO"] = Conversion.Val(MSG[num6, 52]);
									dataRow5["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
									dataRow5["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
									dataRow5["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
									dataRow5["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
									dataRow5["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
									dataRow5["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
									dataRow5["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]);
									dataRow5["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]);
									dataRow5["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]);
									dataRow5["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
									DataRow dataRow6;
									object Value = RuntimeHelpers.GetObjectValue((dataRow6 = DtIdtl.Rows[i])[11]);
									double num10 = DC_Main.Fnv(ref Value);
									dataRow6[11] = RuntimeHelpers.GetObjectValue(Value);
									dataRow5["IT_PCS_WT"] = Conversion.Val((object)num10);
									Value = RuntimeHelpers.GetObjectValue((dataRow6 = DtIdtl.Rows[i])[13]);
									double num11 = DC_Main.Fnv(ref Value);
									dataRow6[13] = RuntimeHelpers.GetObjectValue(Value);
									dataRow5["KR_LESS_PRC"] = Conversion.Val((object)num11);
									dataRow5["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
									dataRow5["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]));
									dataRow5["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
									dataRow5["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]);
									dataRow5["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
									dataRow5["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
									dataRow5["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
									dataRow5["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
									dataRow5["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]));
									dataRow5["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]));
									dataRow5["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25]);
									dataRow5["MAIN_USER"] = MainUser;
									RsIdtl.Rows.Add(dataRow5);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
									RsIdtl.Clear();
								}
								dtIdtl = null;
							}
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) != 0)
							{
								DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
								DC_Main.RsQry = "SELECT * FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
								RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.MsInsertData();
								DataRow dataRow7 = RsDetl.NewRow();
								int num12 = MSG.Rows - 1;
								DC_Main.i = 1;
								while (DC_Main.i <= num12)
								{
									AxMSFlexGrid mSG3 = MSG;
									if ((((Operators.CompareString(mSG3[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG3[DC_Main.i, 36]) != 0.0)) | (Conversion.Val(mSG3[DC_Main.i, 12]) + Conversion.Val(mSG3[DC_Main.i, 37]) + Conversion.Val(mSG3[DC_Main.i, 33]) != 0.0)) && Operators.CompareString(mSG3[DC_Main.i, 1], "", false) == 0)
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
										dataRow7["ENTRY_TYPE"] = "W";
										dataRow7["BOOK_NAME"] = FormMainBook;
										dataRow7["SR_NO"] = Conversion.Val(mSG3[DC_Main.i, 0]);
										dataRow7["OLD_SRNO"] = Conversion.Val(mSG3[DC_Main.i, 57]);
										dataRow7["IT_CODE"] = mSG3[DC_Main.i, 2];
										dataRow7["ITM_REMARK"] = mSG3[DC_Main.i, 3];
										dataRow7["TAG_NO"] = "N";
										dataRow7["TBL_CODE"] = mSG3[DC_Main.i, 4];
										dataRow7["DESIGN_NO"] = mSG3[DC_Main.i, 5];
										dataRow7["ITM_COLOR"] = mSG3[DC_Main.i, 6];
										dataRow7["ITM_SIZE"] = mSG3[DC_Main.i, 7];
										dataRow7["HM_ID"] = mSG3[DC_Main.i, 8];
										dataRow7["BAG_WT"] = Conversion.Val(mSG3[DC_Main.i, 9]);
										dataRow7["ITM_PCS"] = Conversion.Val(mSG3[DC_Main.i, 10]);
										dataRow7["ITM_GWT"] = Conversion.Val(mSG3[DC_Main.i, 12]);
										dataRow7["ITM_OTH_WT"] = Conversion.Val(mSG3[DC_Main.i, 13]);
										dataRow7["ITM_NWT"] = Conversion.Val(mSG3[DC_Main.i, 14]);
										dataRow7["ITM_GHT_WT"] = Conversion.Val(mSG3[DC_Main.i, 16]);
										dataRow7["ITM_TOUCH"] = Conversion.Val(mSG3[DC_Main.i, 17]);
										dataRow7["ITM_WEST_PRC"] = Conversion.Val(mSG3[DC_Main.i, 18]);
										dataRow7["ITM_FINE"] = Conversion.Val(mSG3[DC_Main.i, 22]);
										dataRow7["LBR_PRC"] = Conversion.Val(mSG3[DC_Main.i, 29]);
										dataRow7["LBR_TYPE"] = mSG3[DC_Main.i, 30];
										dataRow7["LBR_RATE"] = Conversion.Val(mSG3[DC_Main.i, 31]);
										dataRow7["LBR_AMT"] = Conversion.Val(mSG3[DC_Main.i, 32]);
										dataRow7["OTH_AMT"] = Conversion.Val(mSG3[DC_Main.i, 33]);
										dataRow7["ITM_RATE"] = Conversion.Val(mSG3[DC_Main.i, 27]);
										dataRow7["ITM_AMT"] = Conversion.Val(mSG3[DC_Main.i, 28]);
										dataRow7["ITM_MRP"] = Conversion.Val(mSG3[DC_Main.i, 36]);
										dataRow7["NET_AMT"] = Conversion.Val(mSG3[DC_Main.i, 37]);
										dataRow7["RATE_TYPE"] = mSG3[DC_Main.i, 58];
										dataRow7["IT_TYPE"] = mSG3[DC_Main.i, 59];
										dataRow7["PR_CODE"] = mSG3[DC_Main.i, 61];
										dataRow7["VCH_SRNO"] = 0;
										dataRow7["ISU_REC"] = "N";
										dataRow7["LBR_TYPE"] = "N";
										dataRow7["HM_ID2"] = mSG3[DC_Main.i, 81];
										dataRow7["HM_ID3"] = mSG3[DC_Main.i, 82];
										dataRow7["HM_ID4"] = mSG3[DC_Main.i, 83];
										dataRow7["HM_ID_WT"] = Conversion.Val(mSG3[DC_Main.i, 84]);
										dataRow7["HM_ID2_WT"] = Conversion.Val(mSG3[DC_Main.i, 85]);
										dataRow7["HM_ID3_WT"] = Conversion.Val(mSG3[DC_Main.i, 86]);
										dataRow7["HM_ID4_WT"] = Conversion.Val(mSG3[DC_Main.i, 87]);
										dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
										dataRow7["MAIN_USER"] = MainUser;
										dataRow7["EMP_CODE"] = tEmpCode.Text;
										dataRow7["DESIGN_IMG_ID"] = mSG3[DC_Main.i, 90];
										RsDetl.Rows.Add(dataRow7);
										((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
										RsDetl.Clear();
									}
									mSG3 = null;
									DC_Main.i++;
								}
							}
							DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
							DC_Main.RsQry = "SELECT * FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
							RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow8 = RsPrDetl.NewRow();
							int num13 = MSG_PR.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num13)
							{
								AxMSFlexGrid mSG_PR = MSG_PR;
								if ((Conversion.Val(MSG_PR[DC_Main.i, 10]) + Conversion.Val(MSG_PR[DC_Main.i, 30]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
								{
									dataRow8["CO_CODE"] = DC_Main.MCo_code;
									dataRow8["LC_CODE"] = DC_Main.MLc_code;
									dataRow8["CO_YEAR"] = DC_Main.MCo_year;
									dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
									dataRow8["VCH_NO"] = tVchNo.Text;
									dataRow8["VCH_DATE"] = mVchDate.Text;
									dataRow8["HD_VCH_NO"] = tHdVchNo.Text;
									dataRow8["AC_CODE"] = tAcCode.Text;
									dataRow8["VCH_TYPE"] = FormBookSname;
									dataRow8["INOUT_TYPE"] = FormBookInOut;
									dataRow8["ENTRY_TYPE"] = "P";
									dataRow8["BOOK_NAME"] = FormMainBook;
									dataRow8["SR_NO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
									dataRow8["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
									dataRow8["IT_CODE"] = mSG_PR[DC_Main.i, 1];
									dataRow8["ITM_REMARK"] = mSG_PR[DC_Main.i, 2];
									dataRow8["TAG_NO"] = "N";
									dataRow8["TBL_CODE"] = mSG_PR[DC_Main.i, 3];
									dataRow8["DESIGN_NO"] = mSG_PR[DC_Main.i, 4];
									dataRow8["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 5]);
									dataRow8["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 6]);
									dataRow8["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 8]);
									dataRow8["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
									dataRow8["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
									dataRow8["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 11]);
									dataRow8["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
									dataRow8["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
									dataRow8["LESS_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
									dataRow8["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
									dataRow8["SILVER_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
									dataRow8["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 22]);
									dataRow8["LBR_TYPE"] = mSG_PR[DC_Main.i, 23];
									dataRow8["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 24]);
									dataRow8["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 25]);
									dataRow8["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
									dataRow8["ITM_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
									dataRow8["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 28]);
									dataRow8["PRM_AMT"] = 0;
									dataRow8["MCX_RATE"] = 0;
									dataRow8["CONV_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
									dataRow8["CONV_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
									dataRow8["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 20]);
									dataRow8["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
									dataRow8["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
									dataRow8["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
									dataRow8["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 33]);
									dataRow8["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
									dataRow8["RATE_TYPE"] = mSG_PR[DC_Main.i, 35];
									dataRow8["IT_TYPE"] = mSG_PR[DC_Main.i, 34];
									dataRow8["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow8["WITH_STOCK"] = "Y";
									dataRow8["MAIN_USER"] = MainUser;
									dataRow8["EMP_CODE"] = tEmpCode.Text;
									RsPrDetl.Rows.Add(dataRow8);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsPrDetl);
									RsPrDetl.Clear();
								}
								mSG_PR = null;
								DC_Main.i++;
							}
							DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'Y'  FROM SL_ORD_DETL,RATE_CUT_ISU AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.VCH_NO = A.ISU_NO AND SL_ORD_DETL.CO_YEAR = A.ISU_YRCD AND SL_ORD_DETL.CO_BOOK = A.ISU_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ISU_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y',APR_DETL.EMP_SALE = 'Y' FROM APR_DETL,RATE_CUT_ISU AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.BOOK_NAME = 'EMP ISU' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.RsQry = "UPDATE A SET A.ISU_NO = B.VCH_NO,A.ISU_YRCD = B.CO_YEAR,A.ISU_DBCD = B.CO_BOOK,A.ISU_SRNO = B.OLD_SRNO,A.ISU_AC_CODE = B.AC_CODE,A.ORNA_REC_DATE = B.VCH_DATE FROM APR_DETL AS A,RATE_CUT_ISU AS B WHERE A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD  AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO AND A.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.BOOK_NAME = 'EMP ISU' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.EMP_ISU = 'N' FROM RATE_CUT_ISU,BAR_DETL AS B WHERE RATE_CUT_ISU.CO_CODE = B.CO_CODE AND RATE_CUT_ISU.LC_CODE = B.LC_CODE AND RATE_CUT_ISU.TAG_NO = B.TAG_NO  AND RATE_CUT_ISU.VCH_SRNO = B.VCH_SRNO AND RATE_CUT_ISU.CO_CODE = '" + DC_Main.MCo_code + "' AND RATE_CUT_ISU.LC_CODE = '" + DC_Main.MLc_code + "' AND RATE_CUT_ISU.CO_YEAR = '" + DC_Main.MCo_year + "' AND RATE_CUT_ISU.CO_BOOK = '" + DC_Main.MCo_Book + "' AND RATE_CUT_ISU.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Ledr.Wh_Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
							DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Rojmel.Wh_Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
							DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Stock.Wh_Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
							DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Stock.Dm_Wh_Tour_Sale_Detl(DC_Main.MCo_Book, tVchNo.Text);
							if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
							{
								DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
								RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.TableCol();
								string text = "";
								int num14 = RsData.Columns.Count - 2;
								DC_Main.M = 0;
								while (DC_Main.M <= num14)
								{
									if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
									{
										int num15 = DC_Main.RsTblCol.Rows.Count - 1;
										for (int j = 0; j <= num15; j++)
										{
											if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[j]["TBL_COL_NAME"], false))
											{
												text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[j]["COL_NAME"], (object)""));
											}
										}
										if (Operators.CompareString(text, "", false) == 0)
										{
											text = RsData.Columns[DC_Main.M].ColumnName;
										}
										DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text + "','" + Strings.Mid(Conversions.ToString(VchOldData.Rows[0][DC_Main.M]), 1, 50) + "','" + Strings.Mid(Conversions.ToString(RsData.Rows[0][DC_Main.M]), 1, 50) + "','N')";
										DC_Main.OpenRecordSetDc(DC_Main.RsQry);
										text = "";
									}
									DC_Main.M++;
								}
								DC_Main.RsTblCol.Clear();
							}
							RowDelete = false;
							if (Operators.CompareString(FormVchNo, "", false) != 0)
							{
								CLEAR_DATA();
								((Form)this).Close();
								break;
							}
							CurPrnVch = tVchNo.Text;
							if (Operators.CompareString(EntryMode, "A", false) == 0)
							{
								DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
								CustOpAmt = DC_Main.MsAcAmtOpBal;
								CustClAmt = DC_Main.MsAcAmtClBal;
								CustOpGold = DC_Main.MsAcGoldOpBal;
								CustClGold = DC_Main.MsAcGoldClBal;
								CustOpSilver = DC_Main.MsAcSilverOpBal;
								CustClSilver = DC_Main.MsAcSilverClBal;
							}
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
							break;
						}
						goto end_IL_0001;
					}
					case 18702:
						num = -1;
						switch (num2)
						{
						case 2:
							((Control)BtnSave).Enabled = true;
							EntryMode = "E";
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 18702;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  SUBSTRING(B.BOOK_NAME,1,20),AC_CODE,AC_NAME,SL_NET_AMT,PR_NET_AMT,IT_TYPE,TOT_FINE_DR,TOT_FINE_CR,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,150) FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'N'  FROM SL_ORD_DETL,RATE_CUT_ISU AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.VCH_NO = A.ISU_NO AND SL_ORD_DETL.CO_YEAR = A.ISU_YRCD AND SL_ORD_DETL.CO_BOOK = A.ISU_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ISU_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N',APR_DETL.EMP_SALE = 'N' FROM APR_DETL,RATE_CUT_ISU AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.BOOK_NAME = 'EMP ISU' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE A SET A.ISU_NO = '',A.ISU_YRCD = '',A.ISU_DBCD = '',A.ISU_SRNO = 0,A.ISU_AC_CODE = '',A.ORNA_REC_DATE = A.VCH_DATE FROM APR_DETL AS A,RATE_CUT_ISU AS B WHERE A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD  AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO AND A.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.BOOK_NAME = 'EMP ISU' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.EMP_ISU = 'Y' FROM RATE_CUT_ISU,BAR_DETL AS B WHERE RATE_CUT_ISU.CO_CODE = B.CO_CODE AND RATE_CUT_ISU.LC_CODE = B.LC_CODE AND RATE_CUT_ISU.TAG_NO = B.TAG_NO  AND RATE_CUT_ISU.VCH_SRNO = B.VCH_SRNO AND RATE_CUT_ISU.CO_CODE = '" + DC_Main.MCo_code + "' AND RATE_CUT_ISU.LC_CODE = '" + DC_Main.MLc_code + "' AND RATE_CUT_ISU.CO_YEAR = '" + DC_Main.MCo_year + "' AND RATE_CUT_ISU.CO_BOOK = '" + DC_Main.MCo_Book + "' AND RATE_CUT_ISU.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APP_TRFR = 'N' FROM RATE_CUT_ISU,BAR_DETL AS B WHERE RATE_CUT_ISU.CO_CODE = B.CO_CODE AND RATE_CUT_ISU.LC_CODE = B.LC_CODE AND RATE_CUT_ISU.TAG_NO = B.TAG_NO  AND RATE_CUT_ISU.VCH_SRNO = B.VCH_SRNO AND RATE_CUT_ISU.CO_CODE = '" + DC_Main.MCo_code + "' AND RATE_CUT_ISU.LC_CODE = '" + DC_Main.MLc_code + "' AND RATE_CUT_ISU.CO_YEAR = '" + DC_Main.MCo_year + "' AND RATE_CUT_ISU.CO_BOOK = '" + DC_Main.MCo_Book + "' AND RATE_CUT_ISU.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_TOUR_SALE_KeyDown(object sender, KeyEventArgs e)
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
				((Control)pnlOthDetl).Visible = false;
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
				MSG_PR.Row = 1;
				MSG_PR.Col = 1;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
			else if (((Control)TEXT_IDTL).Visible)
			{
				((Control)TEXT_IDTL).Visible = false;
				MSG.Col += 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Visible = true;
				((Control)TEXT_ENTRY).Focus();
			}
			else if (((Control)TEXT_PR).Visible)
			{
				MSG_PR_LeaveCell(MSG, new EventArgs());
				MSG_PR.Row = MSG_PR.Rows - 1;
				MSG_PR.Col = 1;
				((Control)TEXT_PR).Visible = false;
				((Control)nAcDrAmt).Focus();
			}
			else if (((Control)TEXT_ENTRY_2).Visible)
			{
				MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
				((Control)TEXT_ENTRY_2).Visible = false;
				((Control)nCrDays).Focus();
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
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
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
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			chkItmImage.Checked = false;
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT,ITM_COLOR,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,OLD_SRNO,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT,ITM_COLOR,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT  FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT,ITM_COLOR,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT,ITM_COLOR,  '','','','',0,0,0,0 FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		string rptName;
		if (chkHuIdPrint.Checked)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhHuidPrint.RPT";
			rptName = "WhHuidPrint";
		}
		else
		{
			DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RateCutBill.RPT";
				rptName = "RateCutBill";
			}
			else if (Operators.CompareString(FormMainBook, "RATE CUT", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RateCutItmBill.RPT";
				rptName = "RateCutItmBill";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesBill.RPT";
				rptName = "WhSalesBill";
			}
		}
		if (chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS001NAVS", false) == 0)
			{
				DC_Main.RptName = "WhSalesBillWapp";
			}
			else
			{
				DC_Main.RptName = rptName;
			}
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.00"));
			DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.00"));
			DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, "0.00"));
			DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, "0.00"));
			DC_Main.MsWappPrintType = "WhSale";
			DC_Main.RptFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {RATE_CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {RATE_CUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {RATE_CUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			return;
		}
		Cr.SelectionFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {RATE_CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {RATE_CUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {RATE_CUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
		if (!chkHuIdPrint.Checked)
		{
			Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
			Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
			Cr[(short)4] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
			Cr[(short)5] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
			Cr[(short)6] = ("OpSilver = " + Strings.Format((object)CustOpSilver, "0.00")) ?? "";
			Cr[(short)7] = ("ClSilver = " + Strings.Format((object)CustClSilver, "0.00")) ?? "";
		}
		checked
		{
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				if (DC_Main.MsPrintOg)
				{
					Cr[(short)1] = "InVoiceType = 'ORIGINAL'";
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
				if (DC_Main.MsPrintDup)
				{
					Cr[(short)1] = "InVoiceType = 'DUPLICATE'";
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
				if (DC_Main.MsPrintTrip)
				{
					Cr[(short)1] = "InVoiceType = 'TRIPLICATE'";
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
			}
			else
			{
				Cr[(short)1] = "InVoiceType = 'ORIGINAL'";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
			DC_Main.MsPrintStatus = false;
			if ((Operators.CompareString(DC_Main.MsWhBillImg, "Y", false) == 0) & chkItmImage.Checked)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesImage.RPT";
				Cr[(short)1] = "InVoiceType = 'ORIGINAL'";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				DC_Main.MsPrintStatus = false;
			}
			chkItmImage.Checked = false;
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (RowDelete)
		{
			Interaction.MsgBox((object)"Please Save Voucher Becuse Item Row Is Delete", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
			return;
		}
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	private void TR_TOUR_SALE_Activated(object sender, EventArgs e)
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
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MCo_Book, "711", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "712", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "713", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "714", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "715", false) == 0))
		{
			DC_Main.ExeQuteDc("UPDATE RATE_CUT_DATA SET SL_FINE = TOT_FINE_DR,MOB_ENTRY_SAVE = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_FINE = 0 AND TOT_FINE_DR <> 0 AND FINE_RATE = 0");
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,format(TOT_FINE_CR,'0.000') AS FineCrW,format(TOT_FINE_DR,'0.000') AS FineDrW,format(PR_NET_AMT,'0.00') AS CrAmtR,format(SL_NET_AMT,'0.00') AS DrAmtR,A.MOB_ENTRY_SAVE As MSaveM FROM RATE_CUT_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,BILL_NO AS RefNoL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,format(TOT_FINE_CR,'0.000') AS FineCrW,format(TOT_FINE_DR,'0.000') AS FineDrW,format(PR_NET_AMT,'0.00') AS CrAmtR,format(SL_NET_AMT,'0.00') AS DrAmtR FROM RATE_CUT_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[11];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 200.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 90.0;
		DC_Main.ColWidth[6] = 80.0;
		DC_Main.ColWidth[7] = 100.0;
		DC_Main.ColWidth[8] = 100.0;
		DC_Main.ColWidth[9] = 80.0;
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
		//IL_0e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e72: Expected O, but got Unknown
		//IL_0be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Expected O, but got Unknown
		//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d30: Expected O, but got Unknown
		//IL_1003: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Expected O, but got Unknown
		if (MsgClear || MSG.Row == 0)
		{
			return;
		}
		checked
		{
			if ((MsgOldRow != MSG.Row) & !MsgClear)
			{
				MsgOldRow = MSG.Row;
				if (Operators.CompareString(MSG[MSG.Row, 83], "", false) != 0)
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 3] + "  Hu2 : " + MSG[MSG.Row, 81] + "  Hu3 : " + MSG[MSG.Row, 82] + "  Hu4 : " + MSG[MSG.Row, 83];
				}
				else if (Operators.CompareString(MSG[MSG.Row, 82], "", false) != 0)
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 3] + "  Hu2 : " + MSG[MSG.Row, 81] + "  Hu3 : " + MSG[MSG.Row, 82];
				}
				else if (Operators.CompareString(MSG[MSG.Row, 81], "", false) != 0)
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 3] + "  Hu2 : " + MSG[MSG.Row, 81];
				}
				else
				{
					lblItem.Text = "Itm : " + MSG[MSG.Row, 3];
				}
				MSG_IDTL_CLEAR();
				int num = 1;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				int num5 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if (Conversion.Val(MSG[MSG.Row, 57]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26])))
					{
						MSG_IDTL[num, 0] = Conversions.ToString(num);
						MSG_IDTL[num, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
						MSG_IDTL[num, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
						MSG_IDTL[num, 3] = Conversions.ToString(DtIdtl.Rows[i][3]);
						MSG_IDTL[num, 4] = Conversions.ToString(DtIdtl.Rows[i][4]);
						MSG_IDTL[num, 5] = Conversions.ToString(DtIdtl.Rows[i][5]);
						MSG_IDTL[num, 6] = Conversions.ToString(DtIdtl.Rows[i][6]);
						MSG_IDTL[num, 7] = Conversions.ToString(DtIdtl.Rows[i][7]);
						MSG_IDTL[num, 8] = Conversions.ToString(DtIdtl.Rows[i][8]);
						MSG_IDTL[num, 9] = Conversions.ToString(DtIdtl.Rows[i][9]);
						MSG_IDTL[num, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
						AxMSFlexGrid mSG_IDTL = MSG_IDTL;
						int num6 = num;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DtIdtl.Rows[i])[11]);
						double num7 = DC_Main.Fnv(ref Value);
						dataRow[11] = RuntimeHelpers.GetObjectValue(Value);
						mSG_IDTL[num6, 11] = Conversions.ToString(num7);
						MSG_IDTL[num, 12] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][12], (object)""));
						MSG_IDTL[num, 13] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][13], (object)""));
						MSG_IDTL[num, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
						MSG_IDTL[num, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
						MSG_IDTL[num, 15] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][15], (object)""));
						MSG_IDTL[num, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
						MSG_IDTL[num, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
						MSG_IDTL[num, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
						MSG_IDTL[num, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
						MSG_IDTL[num, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
						MSG_IDTL[num, 21] = Conversions.ToString(DtIdtl.Rows[i][21]);
						MSG_IDTL[num, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
						MSG_IDTL[num, 24] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][24], (object)""));
						MSG_IDTL[num, 25] = Conversions.ToString(DtIdtl.Rows[i][25]);
						MSG_IDTL[num, 26] = Conversions.ToString(DtIdtl.Rows[i][26]);
						MSG_IDTL[num, 27] = Conversions.ToString(DtIdtl.Rows[i][27]);
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]));
						num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]));
						num4 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][24], (object)""));
						MSG_IDTL.Rows += 1;
						num++;
					}
				}
				if (num3 != 0.0)
				{
					MSG[MSG.Row, 13] = Strings.Format((object)num3, "0.000");
					MSG[MSG.Row, 14] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 13])), "0.000");
				}
				if (num4 != 0.0)
				{
					MSG[MSG.Row, 41] = Strings.Format((object)num4, "0.000");
					MSG[MSG.Row, 42] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 12]) - Conversion.Val(MSG[MSG.Row, 41])), "0.000");
				}
				if (num2 != 0.0)
				{
					MSG[MSG.Row, 33] = Strings.Format((object)num2, "0.00");
				}
				CommPassTotal();
				ItmStk(MSG.Row, "I");
				PicImage.Image = null;
				if ((Operators.CompareString(MSG[MSG.Row, 90], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0))
				{
					DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 90] + "' AND IMAGE_TYPE = 'D'";
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
					DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 52];
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
							DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 52]))) ?? "";
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
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 52]))) ?? "";
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
				MSG_IDTL[num, 0] = Conversions.ToString(num);
				MSG_IDTL[num, 26] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 57]));
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				ItmProfit(MSG.Row);
			}
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
		if (Conversion.Val(mSG[Row, 36]) != 0.0)
		{
			nItProfit.Text = "PrCost = " + Strings.Format((object)Conversion.Val(mSG[Row, 51]), "0.00") + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 38]) - Conversion.Val(mSG[Row, 51])), "0.00");
			mSG[Row, 88] = Conversions.ToString(Conversion.Val(mSG[Row, 38]) - Conversion.Val(mSG[Row, 51]));
		}
		else if ((Conversion.Val(mSG[Row, 47]) != 0.0) & (Operators.CompareString(mSG[Row, 1], "", false) != 0))
		{
			if (Conversion.Val(mSG[Row, 28]) != 0.0)
			{
				num2 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 47]) * num + Conversion.Val(mSG[Row, 50])), "0.00"));
				nItProfit.Text = "Kf = " + mSG[Row, 47] + "  Fr = " + Conversions.ToString(num) + "  Ko = " + Strings.Format((object)mSG[Row, 50], "0.00") + " = " + Conversions.ToString(num2) + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 38]) - num2), "0.00");
				mSG[Row, 88] = Conversions.ToString(Conversion.Val(mSG[Row, 38]) - num2);
			}
			else
			{
				nItProfit.Text = "Ktch = " + Strings.Format((object)(Conversion.Val(mSG[Row, 45]) + Conversion.Val(mSG[Row, 46])), "0.00") + " Kf = " + Strings.Format((object)Conversion.Val(mSG[Row, 47]), "0.000") + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 22]) - Conversion.Val(mSG[Row, 47])), "0.000");
				mSG[Row, 89] = Conversions.ToString(Conversion.Val(mSG[Row, 22]) - Conversion.Val(mSG[Row, 47]));
			}
		}
		else
		{
			double num3 = 0.0;
			DC_Main.RsQry = "SELECT AVG_TOUCH FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[Row, 2] + "' AND AVG_TOUCH <> 0";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				if (Conversion.Val(mSG[Row, 14]) != 0.0)
				{
					num3 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 14]) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AVG_TOUCH"])) / 100.0), "0.000"));
					if (Conversion.Val(mSG[Row, 28]) != 0.0)
					{
						num2 = Conversions.ToDouble(Strings.Format((object)(num3 * num), "0.00"));
						nItProfit.Text = "Kf = " + Conversions.ToString(num3) + "  Fr = " + Conversions.ToString(num) + " = " + Conversions.ToString(num2) + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 38]) - num2), "0.00");
						mSG[Row, 88] = Conversions.ToString(Conversion.Val(mSG[Row, 38]) - num2);
					}
					else
					{
						nItProfit.Text = "ATch = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AVG_TOUCH"]))) + " Kf = " + Strings.Format((object)num3, "0.000") + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 22]) - num3), "0.000");
						mSG[Row, 89] = Conversions.ToString(Conversion.Val(mSG[Row, 22]) - num3);
					}
				}
			}
			else if (Operators.CompareString(mSG[Row, 28], "", false) != 0)
			{
				nItProfit.Text = "Kf = 0.000  / 0.000 Avg Tch Not Found";
				mSG[Row, 89] = Conversions.ToString(0);
			}
			else
			{
				nItProfit.Text = "It Profit";
				mSG[Row, 89] = Conversions.ToString(0);
			}
		}
		mSG = null;
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
				case 351:
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
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 7:
						case 8:
							goto end_IL_0001_3;
						}
						goto default;
					}
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
					IL_000b:
					num2 = 2;
					DC_Main.RsQry = "Select TOP(1) FINE_GL_RATE,FINE_SL_RATE,VCH_DATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND SR_NO = 1";
					goto IL_006f;
					IL_0095:
					num2 = 5;
					ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 10.0), "0.00"));
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 6;
				ToDaySlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 10.0), "0.00"));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 351;
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
				DC_Main.RsQry = "SELECT VCH_NO FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_TOUR_SALE_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
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
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
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
				DC_Main.MsGrCode = "20";
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
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				nCrDays.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CR_DAYS"], (object)"")), "0");
			}
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
			if (DC_Main.MsAcGoldOpBal > 0.0)
			{
				LOpGold.Text = Strings.Format((object)DC_Main.MsAcGoldOpBal, "0.000") + " : Cr Gold";
				((Control)LOpGold).ForeColor = Color.Blue;
			}
			else if (DC_Main.MsAcGoldOpBal < 0.0)
			{
				LOpGold.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcGoldOpBal), "0.000") + " : Dr Gold";
				((Control)LOpGold).ForeColor = Color.Red;
			}
			else
			{
				LOpGold.Text = ": Gold";
			}
			if (DC_Main.MsAcSilverOpBal > 0.0)
			{
				LOpSilver.Text = Strings.Format((object)DC_Main.MsAcSilverOpBal, "0.000") + " : Cr Silvr";
				((Control)LOpSilver).ForeColor = Color.Blue;
			}
			else if (DC_Main.MsAcSilverOpBal < 0.0)
			{
				LOpSilver.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcSilverOpBal), "0.000") + " : Dr Silvr";
				((Control)LOpSilver).ForeColor = Color.Red;
			}
			else
			{
				LOpSilver.Text = ": Silvr";
			}
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustOpGold = DC_Main.MsAcGoldOpBal;
			CustOpSilver = DC_Main.MsAcSilverOpBal;
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcGoldOpBal = 0.0;
			DC_Main.MsAcSilverOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			DC_Main.MsAcGoldClBal = 0.0;
			DC_Main.MsAcSilverClBal = 0.0;
		}
		((Control)pnlOthDetl).Visible = true;
		if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
		{
			((Control)tAcName).Focus();
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
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
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
		mSG2_TOTAL.Rows = 10;
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
			mSG2_TOTAL[9] = 0;
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
			while (DC_Main.i <= 7);
			mSG2_TOTAL[0, 3] = "Payment    ";
			mSG2_TOTAL[0, 4] = "Received    ";
			mSG2_TOTAL[1, 0] = "Net Amt : ";
			mSG2_TOTAL[8, 0] = "Tax Amt : ";
			mSG2_TOTAL[9, 0] = "Total Amt : ";
			mSG2_TOTAL[2, 0] = "Cheque Amt : ";
			mSG2_TOTAL[3, 0] = "Card Amt : ";
			mSG2_TOTAL[4, 0] = "Order Amt : ";
			mSG2_TOTAL[5, 0] = "Cash Amt : ";
			mSG2_TOTAL[6, 0] = "Kasar Amt : ";
			mSG2_TOTAL[7, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 7))
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
				if ((mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 3))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8))
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 7))
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 7))
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
			if ((mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 3))
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
					if (((mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 3)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 2)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 3)
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
					if (mSG2_TOTAL.Row != 8)
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
									mSG2_TOTAL[8, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									mSG2_TOTAL[8, 4] = DC_Main.ColValue[2];
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
								mSG2_TOTAL.Row = 2;
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
							mSG2_TOTAL.Row = 2;
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
						mSG2_TOTAL.Row = 2;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 5:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 2:
					case 3:
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
					case 6:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)nCrDays).Focus();
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
					case 5:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 2:
					case 3:
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
					case 6:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)nCrDays).Focus();
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
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		if ((Conversion.Val(nConvRate.Text) != 0.0) & (Conversion.Val(nConvPrc.Text) != 0.0))
		{
			nFineRate.Text = Strings.Format((object)Math.Round(Conversion.Val(nConvRate.Text) / Conversion.Val(nConvPrc.Text) * 100.0, 2), "0.00");
		}
		else if (Conversion.Val(nConvRate.Text) != 0.0)
		{
			nFineRate.Text = Strings.Format((object)Conversion.Val(nConvRate.Text), "0.00");
		}
		if ((Conversion.Val(nAcDrAmt.Text) != 0.0) & (Conversion.Val(nAcCrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 10.0 / Conversion.Val(nAcCrFine.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 1000.0 / Conversion.Val(nAcCrFine.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nFineRate.Text) == 0.0)
			{
				nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) / Conversion.Val(nAcCrFine.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nAcCrAmt.Text) != 0.0) & (Conversion.Val(nAcDrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 10.0 / Conversion.Val(nAcDrFine.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 1000.0 / Conversion.Val(nAcDrFine.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nFineRate.Text) == 0.0)
			{
				nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) / Conversion.Val(nAcDrFine.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcCrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcDrAmt.Text) == 0.0)
				{
					nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcCrFine.Text) * (Conversion.Val(nFineRate.Text) / 10.0), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcDrAmt.Text) == 0.0)
				{
					nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcCrFine.Text) * (Conversion.Val(nFineRate.Text) / 1000.0), 0), "0.00");
				}
			}
			else if (Conversion.Val(nAcDrAmt.Text) == 0.0)
			{
				nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcCrFine.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcDrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcCrAmt.Text) == 0.0)
				{
					nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcDrFine.Text) * (Conversion.Val(nFineRate.Text) / 10.0), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcCrAmt.Text) == 0.0)
				{
					nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcDrFine.Text) * (Conversion.Val(nFineRate.Text) / 1000.0), 0), "0.00");
				}
			}
			else if (Conversion.Val(nAcCrAmt.Text) == 0.0)
			{
				nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcDrFine.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcDrAmt.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcCrFine.Text) == 0.0)
				{
					nAcCrFine.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 10.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcCrFine.Text) == 0.0)
				{
					nAcCrFine.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 1000.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nAcCrFine.Text) == 0.0)
			{
				nAcCrFine.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) / Conversion.Val(nFineRate.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcCrAmt.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcDrFine.Text) == 0.0)
				{
					nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 10.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcDrFine.Text) == 0.0)
				{
					nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 1000.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nAcDrFine.Text) == 0.0)
			{
				nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) / Conversion.Val(nFineRate.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nSlvrDrAmt.Text) != 0.0) & (Conversion.Val(nSlvrFineCr.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nSlvrFineRate.Text) == 0.0)
				{
					nSlvrFineRate.Text = Strings.Format((object)(Conversion.Val(nSlvrDrAmt.Text) * 10.0 / Conversion.Val(nSlvrFineCr.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nSlvrFineRate.Text) == 0.0)
				{
					nSlvrFineRate.Text = Strings.Format((object)(Conversion.Val(nSlvrDrAmt.Text) * 1000.0 / Conversion.Val(nSlvrFineCr.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nSlvrFineRate.Text) == 0.0)
			{
				nSlvrFineRate.Text = Strings.Format((object)(Conversion.Val(nSlvrDrAmt.Text) / Conversion.Val(nSlvrFineCr.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nSlvrCrAmt.Text) != 0.0) & (Conversion.Val(nSlvrFineDr.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nSlvrFineRate.Text) == 0.0)
				{
					nSlvrFineRate.Text = Strings.Format((object)(Conversion.Val(nSlvrCrAmt.Text) * 10.0 / Conversion.Val(nSlvrFineDr.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nSlvrFineRate.Text) == 0.0)
				{
					nSlvrFineRate.Text = Strings.Format((object)(Conversion.Val(nSlvrCrAmt.Text) * 1000.0 / Conversion.Val(nSlvrFineDr.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nSlvrFineRate.Text) == 0.0)
			{
				nSlvrFineRate.Text = Strings.Format((object)(Conversion.Val(nSlvrCrAmt.Text) / Conversion.Val(nSlvrFineDr.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nSlvrFineRate.Text) != 0.0) & (Conversion.Val(nSlvrFineCr.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nSlvrDrAmt.Text) == 0.0)
				{
					nSlvrDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nSlvrFineCr.Text) * (Conversion.Val(nSlvrFineRate.Text) / 10.0), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nSlvrDrAmt.Text) == 0.0)
				{
					nSlvrDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nSlvrFineCr.Text) * (Conversion.Val(nSlvrFineRate.Text) / 1000.0), 0), "0.00");
				}
			}
			else if (Conversion.Val(nSlvrDrAmt.Text) == 0.0)
			{
				nSlvrDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nSlvrFineCr.Text) * Conversion.Val(nSlvrFineRate.Text), 0), "0.00");
			}
		}
		if ((Conversion.Val(nSlvrFineRate.Text) != 0.0) & (Conversion.Val(nSlvrFineDr.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nSlvrCrAmt.Text) == 0.0)
				{
					nSlvrCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nSlvrFineDr.Text) * (Conversion.Val(nSlvrFineRate.Text) / 10.0), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nSlvrCrAmt.Text) == 0.0)
				{
					nSlvrCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nSlvrFineDr.Text) * (Conversion.Val(nSlvrFineRate.Text) / 1000.0), 0), "0.00");
				}
			}
			else if (Conversion.Val(nSlvrCrAmt.Text) == 0.0)
			{
				nSlvrCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nSlvrFineDr.Text) * Conversion.Val(nSlvrFineRate.Text), 0), "0.00");
			}
		}
		if ((Conversion.Val(nSlvrFineRate.Text) != 0.0) & (Conversion.Val(nAcDrAmt.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nSlvrFineCr.Text) == 0.0)
				{
					nSlvrFineCr.Text = Strings.Format((object)(Conversion.Val(nSlvrDrAmt.Text) * 10.0 / Conversion.Val(nSlvrFineRate.Text)), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nSlvrFineCr.Text) == 0.0)
				{
					nSlvrFineCr.Text = Strings.Format((object)(Conversion.Val(nSlvrDrAmt.Text) * 1000.0 / Conversion.Val(nSlvrFineRate.Text)), "0.00");
				}
			}
			else if (Conversion.Val(nSlvrFineCr.Text) == 0.0)
			{
				nSlvrFineCr.Text = Strings.Format((object)(Conversion.Val(nSlvrDrAmt.Text) / Conversion.Val(nSlvrFineRate.Text)), "0.00");
			}
		}
		if ((Conversion.Val(nSlvrFineRate.Text) != 0.0) & (Conversion.Val(nSlvrCrAmt.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nSlvrDrAmt.Text) == 0.0)
				{
					nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nSlvrCrAmt.Text) * 10.0 / Conversion.Val(nSlvrFineRate.Text)), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nSlvrDrAmt.Text) == 0.0)
				{
					nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nSlvrCrAmt.Text) * 1000.0 / Conversion.Val(nSlvrFineRate.Text)), "0.00");
				}
			}
			else if (Conversion.Val(nSlvrDrAmt.Text) == 0.0)
			{
				nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nSlvrCrAmt.Text) / Conversion.Val(nSlvrFineRate.Text)), "0.00");
			}
		}
		nSlvrFinOs.Text = Conversions.ToString(Conversion.Val(nTotSilverDr.Text) + Conversion.Val(nSlvrFineDr.Text) - (Conversion.Val(nTotSilverCr.Text) + Conversion.Val(nSlvrFineCr.Text)));
		nTotFineDr.Text = Strings.Format((object)(TotDrFine + Conversion.Val(nAcDrFine.Text) + Conversion.Val(nFineKsrDr.Text) + Conversion.Val(MSG_TOT[0, 35])), "0.000");
		nTotFineCr.Text = Strings.Format((object)(TotCrFine + Conversion.Val(nAcCrFine.Text) + Conversion.Val(nFineKsrCr.Text) + Conversion.Val(MSG_PR_TOT[0, 28])), "0.000");
		nDiffFine.Text = Strings.Format((object)(Conversion.Val(nTotFineDr.Text) - Conversion.Val(nTotFineCr.Text)), "0.000");
		double num = 0.0;
		double num2 = 0.0;
		mSG2_TOTAL[1, 4] = Strings.Format((object)Math.Round(Conversion.Val(nAcDrAmt.Text) + num + Conversion.Val(MSG_TOT[0, 37]) - SlOthAmtLess + Math.Round(Conversion.Val(nSlvrDrAmt.Text)), 0), "0.00");
		mSG2_TOTAL[1, 3] = Strings.Format((object)Math.Round(Conversion.Val(nAcCrAmt.Text) + num2 + Conversion.Val(MSG_PR_TOT[0, 30]) - PrOthAmtLess + Math.Round(Conversion.Val(nSlvrCrAmt.Text)), 0), "0.00");
		mSG2_TOTAL[7, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[1, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[6, 3])), "0.00");
		mSG2_TOTAL[7, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[1, 4]) - Conversion.Val(mSG2_TOTAL[5, 4]) - Conversion.Val(mSG2_TOTAL[2, 4]) - Conversion.Val(mSG2_TOTAL[3, 4]) - Conversion.Val(mSG2_TOTAL[6, 4])), "0.00");
		nTotSilverDr.Text = Strings.Format((object)Conversion.Val(MSG_TOT[0, 24]), "0.00");
		nTotSilverCr.Text = Strings.Format((object)Conversion.Val(MSG_PR_TOT[0, 17]), "0.00");
		checked
		{
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				double num3 = 0.0;
				int num4 = MSG.Rows - 1;
				for (int i = 0; i <= num4; i++)
				{
					num3 += Conversion.Val(MSG[i, 89]);
				}
				nBillProfit.Text = Strings.Format((object)num3, "0.000");
			}
			if (Conversion.Val(mSG2_TOTAL[7, 3]) > Conversion.Val(mSG2_TOTAL[7, 4]))
			{
				lblDiffAmt.Text = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[7, 4])), "0.00") + "  Pay";
			}
			else if (Conversion.Val(mSG2_TOTAL[7, 3]) < Conversion.Val(mSG2_TOTAL[7, 4]))
			{
				lblDiffAmt.Text = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[7, 4]) - Conversion.Val(mSG2_TOTAL[7, 3])), "0.00") + "  Rec";
			}
			else
			{
				lblDiffAmt.Text = ".";
			}
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[7, 4]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[7, 3]) - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[7, 4]));
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[7, 4]);
			}
			if (cboItemTyp.SelectedIndex == 0)
			{
				if (CustOpGold > 0.0)
				{
					CustClGold = CustOpGold + Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = Conversion.Val(nTotFineCr.Text) - (Math.Abs(CustOpGold) + Conversion.Val(nTotFineDr.Text));
				}
				else
				{
					CustClGold = Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
				}
			}
			else
			{
				CustClGold = CustOpGold;
			}
			if (cboItemTyp.SelectedIndex == 1)
			{
				if (CustOpSilver > 0.0)
				{
					CustClSilver = CustOpSilver + Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
				}
				else if (CustOpSilver < 0.0)
				{
					CustClSilver = Conversion.Val(nTotFineCr.Text) - (Math.Abs(CustOpSilver) + Conversion.Val(nTotFineDr.Text));
				}
				else
				{
					CustClSilver = Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
				}
			}
			else
			{
				CustClSilver = CustOpSilver;
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
			if (CustClGold > 0.0)
			{
				lClGold.Text = Strings.Format((object)CustClGold, "0.000") + " : Cr Gold";
				((Control)lClGold).ForeColor = Color.Blue;
			}
			else if (CustClGold < 0.0)
			{
				lClGold.Text = Strings.Format((object)Math.Abs(CustClGold), "0.000") + " : Dr Gold";
				((Control)lClGold).ForeColor = Color.Red;
			}
			else
			{
				lClGold.Text = ": Gold";
			}
			if (CustClSilver > 0.0)
			{
				LClSilver.Text = Strings.Format((object)CustClSilver, "0.000") + " : Cr Silvr";
				((Control)LClSilver).ForeColor = Color.Blue;
			}
			else if (CustClSilver < 0.0)
			{
				LClSilver.Text = Strings.Format((object)Math.Abs(CustClSilver), "0.000") + " : Dr Silvr";
				((Control)LClSilver).ForeColor = Color.Red;
			}
			else
			{
				LClSilver.Text = ": Silvr";
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
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
		{
			((Control)PanelAdd).Visible = true;
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
	}

	private void nAcDrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcDrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcDrAmt.Text)), "0.00");
			if ((OldAcDrAmt != 0.0) & (OldAcDrAmt != Conversion.Val(nAcDrAmt.Text)) & (OldAcCrFine != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcDrAmt = Conversion.Val(nAcDrAmt.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nAcCrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcCrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcCrFine.Text)), "0.000");
			if ((OldAcCrFine != 0.0) & (OldAcCrFine != Conversion.Val(nAcCrFine.Text)) & (OldAcDrAmt != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcCrFine = Conversion.Val(nAcCrFine.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nAcCrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcCrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcCrAmt.Text)), "0.00");
			if ((OldAcCrAmt != 0.0) & (OldAcCrAmt != Conversion.Val(nAcCrAmt.Text)) & (OldAcDrFine != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcCrAmt = Conversion.Val(nAcCrAmt.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nAcDrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcDrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcDrFine.Text)), "0.000");
			if ((OldAcDrFine != 0.0) & (OldAcDrFine != Conversion.Val(nAcDrFine.Text)) & (OldAcCrAmt != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcDrFine = Conversion.Val(nAcDrFine.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nFineKsrDr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nFineKsrCr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineKsrCr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrCr.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nFineRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Conversion.Val(nFineRate.Text) != 0.0)
		{
			if (Conversion.Val(nFineRate.Text) != OldFineRate)
			{
				if (OldAcCrAmt == 0.0)
				{
					nAcCrAmt.Text = "";
				}
				if (OldAcDrAmt == 0.0)
				{
					nAcDrAmt.Text = "";
				}
				if (OldAcCrFine == 0.0)
				{
					nAcCrFine.Text = "";
				}
				if (OldAcDrFine == 0.0)
				{
					nAcDrFine.Text = "";
				}
			}
			nFineRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineRate.Text)), "0.00");
			BILL_TOTAL();
			if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
			{
				MSG2_TOTAL.Row = 2;
				MSG2_TOTAL.Col = 3;
			}
			else
			{
				MSG2_TOTAL.Row = 2;
				MSG2_TOTAL.Col = 4;
			}
			MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
			((Control)TEXT_ENTRY_2).Focus();
		}
		else
		{
			if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
			{
				MSG2_TOTAL.Row = 2;
				MSG2_TOTAL.Col = 3;
			}
			else
			{
				MSG2_TOTAL.Row = 2;
				MSG2_TOTAL.Col = 4;
			}
			MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
			((Control)TEXT_ENTRY_2).Focus();
		}
	}

	private void nCrDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrDays.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrDays.Text)), "0");
			((Control)tVchDesc).Focus();
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void TEXT_ENTRY_2_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
		((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
	}

	private void nConvPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nConvPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nConvPrc.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nConvRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (OldConRate != Conversion.Val(nConvRate.Text))
		{
			if ((OldConRate != 0.0) & (Conversion.Val(nConvRate.Text) == 0.0))
			{
				nFineRate.Text = "";
			}
			OldConRate = Conversion.Val(nConvRate.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			if (OldFineRate == 0.0)
			{
				nFineRate.Text = "";
			}
		}
		nConvRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nConvRate.Text)), "0.00");
		BILL_TOTAL();
		SendKeys.Send("{TAB}");
	}

	private void chkSilverCut_Click(object sender, EventArgs e)
	{
		if (chkSilverCut.Checked)
		{
			((Control)PnlSilverCut).Visible = true;
			((Control)nSlvrFineCr).Focus();
		}
		else
		{
			((Control)PnlSilverCut).Visible = false;
		}
	}

	private void nSlvrFineCr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSlvrFineCr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSlvrFineCr.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nSlvrFineDr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSlvrFineDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSlvrFineDr.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nSlvrDrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSlvrDrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSlvrDrAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nSlvrCrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSlvrCrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSlvrCrAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nSlvrFineRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSlvrFineRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSlvrFineRate.Text)), "0.00");
			BILL_TOTAL();
			((Control)nFineRate).Focus();
		}
	}

	private void TR_TOUR_SALE_KeyUp(object sender, KeyEventArgs e)
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
	}

	private void nWestPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112 && Operators.CompareString(EntryMode, "E", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Update All Item Westage Adjust As Per West % ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				checked
				{
					int num = MSG.Rows - 1;
					for (int i = 1; i <= num; i++)
					{
						AxMSFlexGrid mSG = MSG;
						if (Conversion.Val(nWestPrc.Text) != 0.0)
						{
							if (Conversion.Val(mSG[i, 17]) != 0.0)
							{
								if (Conversion.Val(nWestPrc.Text) < 0.0)
								{
									if (Conversion.Val(mSG[i, 18]) > Math.Abs(Conversion.Val(nWestPrc.Text)))
									{
										mSG[i, 18] = Strings.Format((object)(Conversion.Val(mSG[i, 18]) - Math.Abs(Conversion.Val(nWestPrc.Text))), "0.00");
										mSG[i, 70] = Strings.Format((object)Conversion.Val(mSG[i, 18]), "0.00");
										if ((Conversion.Val(mSG[i, 17]) + Conversion.Val(mSG[i, 18]) != 0.0) & (Conversion.Val(mSG[i, 14]) != 0.0))
										{
											mSG[i, 22] = Strings.Format((object)((Conversion.Val(mSG[i, 14]) + Conversion.Val(mSG[i, 16])) * (Conversion.Val(mSG[i, 17]) + Conversion.Val(mSG[i, 18])) / 100.0 - Conversion.Val(mSG[i, 20]) + Conversion.Val(mSG[i, 21])), "0.000");
										}
									}
									else
									{
										Interaction.MsgBox((object)"You Cant Adjust Negative West % Please Change West %...", (MsgBoxStyle)0, (object)null);
									}
								}
								else if (Conversion.Val(nWestPrc.Text) != 0.0)
								{
									mSG[i, 18] = Strings.Format((object)(Conversion.Val(mSG[i, 18]) + Conversion.Val(nWestPrc.Text)), "0.00");
									mSG[i, 70] = Strings.Format((object)Conversion.Val(mSG[i, 18]), "0.00");
									if ((Conversion.Val(mSG[i, 17]) + Conversion.Val(mSG[i, 18]) != 0.0) & (Conversion.Val(mSG[i, 14]) != 0.0))
									{
										mSG[i, 22] = Strings.Format((object)((Conversion.Val(mSG[i, 14]) + Conversion.Val(mSG[i, 16])) * (Conversion.Val(mSG[i, 17]) + Conversion.Val(mSG[i, 18])) / 100.0 - Conversion.Val(mSG[i, 20]) + Conversion.Val(mSG[i, 21])), "0.000");
									}
								}
							}
							if (Conversion.Val(mSG[i, 17]) + Conversion.Val(mSG[i, 18]) == 0.0)
							{
								mSG[i, 22] = Strings.Format((object)(Conversion.Val(mSG[i, 14]) + Conversion.Val(mSG[i, 16]) - Conversion.Val(mSG[i, 20]) + Conversion.Val(mSG[i, 21])), "0.000");
							}
							if ((Conversion.Val(mSG[i, 14]) != 0.0) & (Conversion.Val(mSG[i, 17]) != 0.0))
							{
								mSG[i, 23] = Strings.Format((object)((Conversion.Val(mSG[i, 14]) + Conversion.Val(mSG[i, 16])) * (Conversion.Val(mSG[i, 17]) + Conversion.Val(mSG[i, 18])) / 100.0 - Conversion.Val(mSG[i, 20]) + Conversion.Val(mSG[i, 21])), "0.000");
							}
							else
							{
								mSG[i, 23] = Strings.Format((object)(Conversion.Val(mSG[i, 14]) + Conversion.Val(mSG[i, 16])), "0.000");
							}
						}
						mSG = null;
					}
				}
			}
			MSG_TOT_FILL();
			BILL_TOTAL();
		}
		if ((int)e.KeyCode == 13)
		{
			nWestPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nWestPrc.Text)), "0.00");
			MSG[1, 18] = nWestPrc.Text;
			((Control)tAcCode).Focus();
		}
	}

	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		if (MSG_PR.Row != 0 && MsgPrOldRow != MSG_PR.Row)
		{
			MsgPrOldRow = MSG_PR.Row;
			ItmStk(MSG_PR.Row, "R");
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void cboItemTyp_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void nWestPrc_TextChanged(object sender, EventArgs e)
	{
	}
}
