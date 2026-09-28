using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
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
using DevNet.Models;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_PURC_HM : Form
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
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPartyFine")]
	private TextBox _nPartyFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_PR_IDTL")]
	private AxMSFlexGrid _MSG_PR_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_PR_IDTL")]
	private TextBox _TEXT_PR_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicBill")]
	private PictureBox _PicBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillDel")]
	private SimpleButton _btnBillDel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillSelect")]
	private SimpleButton _btnBillSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnbillCap")]
	private SimpleButton _btnbillCap;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBillImage")]
	private CheckBox _chkBillImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkRateUnFix")]
	private CheckBox _chkRateUnFix;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDays")]
	private TextBox _nCrDays;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string WappMsg;

	private string WappAcName;

	private string WappMobile;

	private string SmsDetail;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearPr;

	private bool MsgClearIdtlPr;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private double PurcAcFine;

	private string CurRptTagNo;

	private int StkRow;

	private double PrOthAmtLess;

	private double OldNetAmt;

	private bool PrHalfPrint;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private string OldTagItm;

	private string TblData;

	private string TblDetl;

	private string TblIdtl;

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

	private DataTable RsBarData;

	private DataTable RsBarDetl;

	private DataTable RsBarIdtl;

	private DataTable RsOldDetl;

	private DataTable RsImg;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private bool MsgIdtlLeft;

	private int FilRowPr;

	private DataTable DtIdtlPr;

	private DataRow drPr;

	private int MsgOldRowPr;

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

	private const int cPrSrNo = 0;

	private const int cPrItCode = 1;

	private const int cPrItName = 2;

	private const int cPrTagNo = 3;

	private const int cPrCounter = 4;

	private const int cPrDesign = 5;

	private const int cPrLotNo = 6;

	private const int cPrColor = 7;

	private const int cPrSize = 8;

	private const int cPrBagWt = 9;

	private const int cPrPcs = 10;

	private const int cPrPcsWt = 11;

	private const int cPrGrWt = 12;

	private const int cPrOthWt = 13;

	private const int cPrLossWt = 14;

	private const int cPrNetWt = 15;

	private const int cPrGhtPrc = 16;

	private const int cPrGhtWt = 17;

	private const int cPrTouch = 18;

	private const int cPrWestPrc = 19;

	private const int cPrLessTch = 20;

	private const int cPrFine = 21;

	private const int cPrSilverFine = 22;

	private const int cPrConvRate = 23;

	private const int cPrConvPrc = 24;

	private const int cPrRate = 25;

	private const int cPrItAmt = 26;

	private const int cPrLbrPrc = 27;

	private const int cPrLbrType = 28;

	private const int cPrLbrRate = 29;

	private const int cPrLbrAmt = 30;

	private const int cPrOthAmt = 31;

	private const int cPrOthRate = 32;

	private const int cPrOthFine = 33;

	private const int cTagCost = 34;

	private const int cPrMrp = 35;

	private const int cPrTotAmt = 36;

	private const int cPrTaxPrc = 37;

	private const int cPrNetAmt = 38;

	private const int cHmAmt = 39;

	private const int cTagOthWt = 40;

	private const int cTagNwt = 41;

	private const int cTagLbrCode = 42;

	private const int cTagTouch = 43;

	private const int cTagWestPrc = 44;

	private const int cTagFine = 45;

	private const int cTagItRate = 46;

	private const int cTagItAmt = 47;

	private const int cTagLbrPrc = 48;

	private const int cTagLRate = 49;

	private const int cTagLAmt = 50;

	private const int cTagOthAmt = 51;

	private const int cTagTotCost = 52;

	private const int cTagMargin = 53;

	private const int cTagMrp = 54;

	private const int cHmId = 55;

	private const int cTagKrName = 56;

	private const int cHmIdWt = 57;

	private const int cHmId2 = 58;

	private const int cHmId2Wt = 59;

	private const int cHmId3 = 60;

	private const int cHmId3Wt = 61;

	private const int cHmId4 = 62;

	private const int cHmId4Wt = 63;

	private const int cAprIsu = 64;

	private const int cEmpIsu = 65;

	private const int cDataType = 66;

	private const int cTagVchSrNo = 67;

	private const int cPrItType = 68;

	private const int cPrRateType = 69;

	private const int cPrOldGwt = 70;

	private const int cPrOldNwt = 71;

	private const int cPrOldTouch = 72;

	private const int cPrOldWest = 73;

	private const int cPrOldRate = 74;

	private const int cPrOldLestch = 75;

	private const int cPrHmFine = 76;

	private const int cPrOldLbrRate = 77;

	private const int cPrcOldLbrAmt = 78;

	private const int cPrOldItAmt = 79;

	private const int cPrOldSrNo = 80;

	private const int cTagType = 81;

	private const int cTagPrCode = 82;

	private const int cTagSrNo = 83;

	private const int cOldTagType = 84;

	private const int cOldTagPrCode = 85;

	private const int cDesignImgId = 86;

	private const int cRowValue = 87;

	private const int cRowText = 88;

	private const int cTagOldMargin = 89;

	private const int cPrCutPcs = 90;

	private const int cPrCutGwt = 91;

	private const int cPrCutNwt = 92;

	private const int cPrCutFine = 93;

	private const int c2SrNo = 0;

	private const int c2ItCode = 1;

	private const int c2ItName = 2;

	private const int c2Pcs = 3;

	private const int c1PcsWt = 4;

	private const int c1KrWt = 5;

	private const int c1KrPrc = 6;

	private const int c2GrWt = 7;

	private const int c2ConPrc = 8;

	private const int c2RateType = 9;

	private const int c2KrRate = 10;

	private const int c2KrAmt = 11;

	private const int c2ItRate = 12;

	private const int c2ItmAmt = 13;

	private const int c2LbrRate = 14;

	private const int c2LbrAmt = 15;

	private const int c2NetAmt = 16;

	private const int c2ConWt = 17;

	private const int c2ItType = 18;

	private const int c2RowSr = 19;

	private const int c2KrConWt = 20;

	private const int c2RowVal = 21;

	private const int c2RowText = 22;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cTcs2 = 3;

	private const int cTds2 = 4;

	private const int cHmAmt2 = 5;

	private const int cHmTax2 = 6;

	private const int cRof2 = 7;

	private const int cTot2 = 8;

	private const int cChq2 = 9;

	private const int cCard2 = 10;

	private const int cCash2 = 11;

	private const int cKasar2 = 12;

	private const int cOs2 = 13;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_IDTL")]
	private virtual TextBox _TEXT_IDTL;

	internal virtual TextBox TEXT_IDTL
	{
		get
		{
			return _TEXT_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TEXT_IDTL = value;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
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
			EventHandler eventHandler = MSG_PR_RowColChange;
			EventHandler eventHandler2 = MSG_PR_ClickEvent;
			EventHandler eventHandler3 = MSG_PR_EnterCell;
			EventHandler eventHandler4 = MSG_PR_LeaveCell;
			EventHandler eventHandler5 = MSG_PR_Scroll;
			AxMSFlexGrid val = _MSG_PR;
			if (val != null)
			{
				val.RowColChange -= eventHandler;
				val.ClickEvent -= eventHandler2;
				val.EnterCell -= eventHandler3;
				val.LeaveCell -= eventHandler4;
				val.Scroll -= eventHandler5;
			}
			_MSG_PR = value;
			val = _MSG_PR;
			if (val != null)
			{
				val.RowColChange += eventHandler;
				val.ClickEvent += eventHandler2;
				val.EnterCell += eventHandler3;
				val.LeaveCell += eventHandler4;
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
			TextBox val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY_2 = value;
			val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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
			EventHandler eventHandler2 = TEXT_PR_DoubleClick;
			TextBox val2 = _TEXT_PR;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler2;
			}
			_TEXT_PR = value;
			val2 = _TEXT_PR;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler2;
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
			EventHandler eventHandler = tBankName_TextChanged;
			TextBox val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tBankName = value;
			val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSlBill")]
	private virtual TextBox _tSlBill;

	internal virtual TextBox tSlBill
	{
		get
		{
			return _tSlBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSlBill = value;
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
	[AccessedThroughProperty("tSlBill_DbCd")]
	private virtual TextBox _tSlBill_DbCd;

	internal virtual TextBox tSlBill_DbCd
	{
		get
		{
			return _tSlBill_DbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSlBill_DbCd = value;
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

	internal virtual TextBox nPartyFine
	{
		[CompilerGenerated]
		get
		{
			return _nPartyFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPartyFine_KeyDown);
			TextBox val2 = _nPartyFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPartyFine = value;
			val2 = _nPartyFine;
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
	[AccessedThroughProperty("nitGwt")]
	private virtual TextBox _nitGwt;

	internal virtual TextBox nitGwt
	{
		get
		{
			return _nitGwt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nitGwt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nItNwt")]
	private virtual TextBox _nItNwt;

	internal virtual TextBox nItNwt
	{
		get
		{
			return _nItNwt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nItNwt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblOldFine")]
	private virtual Label _lblOldFine;

	internal virtual Label lblOldFine
	{
		get
		{
			return _lblOldFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblOldFine = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlPrIdtl")]
	private virtual Panel _PnlPrIdtl;

	internal virtual Panel PnlPrIdtl
	{
		get
		{
			return _PnlPrIdtl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlPrIdtl = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_PR_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_PR_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_PR_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_PR_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_PR_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_PR_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_PR_IDTL = value;
			val = _MSG_PR_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_PR_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_PR_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_PR_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_PR_IDTL_KeyDown);
			TextBox val2 = _TEXT_PR_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_PR_IDTL = value;
			val2 = _TEXT_PR_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlBill")]
	private virtual Panel _pnlBill;

	internal virtual Panel pnlBill
	{
		get
		{
			return _pnlBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlBill = value;
		}
	}

	internal virtual PictureBox PicBill
	{
		[CompilerGenerated]
		get
		{
			return _PicBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicBill_DoubleClick;
			PictureBox val = _PicBill;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicBill = value;
			val = _PicBill;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBillDel
	{
		[CompilerGenerated]
		get
		{
			return _btnBillDel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBillDel_Click;
			SimpleButton val = _btnBillDel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillDel = value;
			val = _btnBillDel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBillSelect
	{
		[CompilerGenerated]
		get
		{
			return _btnBillSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBillSelect_Click;
			SimpleButton val = _btnBillSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillSelect = value;
			val = _btnBillSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnbillCap
	{
		[CompilerGenerated]
		get
		{
			return _btnbillCap;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnbillCap_Click;
			SimpleButton val = _btnbillCap;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnbillCap = value;
			val = _btnbillCap;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkBillImage
	{
		[CompilerGenerated]
		get
		{
			return _chkBillImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkBillImage_CheckedChanged;
			CheckBox val = _chkBillImage;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkBillImage = value;
			val = _chkBillImage;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
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
	[AccessedThroughProperty("chkHalfPrint")]
	private virtual CheckBox _chkHalfPrint;

	internal virtual CheckBox chkHalfPrint
	{
		get
		{
			return _chkHalfPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkHalfPrint = value;
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

	public TR_PURC_HM()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_PURC_HM_Load;
		((Form)this).Deactivate += TR_PURC_HM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_PURC_HM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_PURC_HM_KeyDown);
		((Form)this).Activated += TR_PURC_HM_Activated;
		((Form)this).Closed += TR_PURC_HM_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_PURC_HM_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		DtIdtlPr = new DataTable();
		drPr = DtIdtlPr.NewRow();
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
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Expected O, but got Unknown
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected O, but got Unknown
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected O, but got Unknown
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected O, but got Unknown
		//IL_0935: Unknown result type (might be due to invalid IL or missing references)
		//IL_093f: Expected O, but got Unknown
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ac: Expected O, but got Unknown
		//IL_0a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5f: Expected O, but got Unknown
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Expected O, but got Unknown
		//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7f: Expected O, but got Unknown
		//IL_0c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Expected O, but got Unknown
		//IL_0db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Expected O, but got Unknown
		//IL_0e1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e28: Expected O, but got Unknown
		//IL_0fba: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ca: Expected O, but got Unknown
		//IL_1182: Unknown result type (might be due to invalid IL or missing references)
		//IL_118c: Expected O, but got Unknown
		//IL_1244: Unknown result type (might be due to invalid IL or missing references)
		//IL_124e: Expected O, but got Unknown
		//IL_12fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1305: Expected O, but got Unknown
		//IL_13fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1407: Expected O, but got Unknown
		//IL_1518: Unknown result type (might be due to invalid IL or missing references)
		//IL_1522: Expected O, but got Unknown
		//IL_166f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1679: Expected O, but got Unknown
		//IL_1751: Unknown result type (might be due to invalid IL or missing references)
		//IL_175b: Expected O, but got Unknown
		//IL_17f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1801: Expected O, but got Unknown
		//IL_193c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1946: Expected O, but got Unknown
		//IL_1991: Unknown result type (might be due to invalid IL or missing references)
		//IL_199b: Expected O, but got Unknown
		//IL_1a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a22: Expected O, but got Unknown
		//IL_1aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aad: Expected O, but got Unknown
		//IL_1b77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b81: Expected O, but got Unknown
		//IL_1c28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c32: Expected O, but got Unknown
		//IL_1cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cba: Expected O, but got Unknown
		//IL_1d42: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4c: Expected O, but got Unknown
		//IL_1dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e07: Expected O, but got Unknown
		//IL_1eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec1: Expected O, but got Unknown
		//IL_1f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f80: Expected O, but got Unknown
		//IL_1fe4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fee: Expected O, but got Unknown
		//IL_204c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2056: Expected O, but got Unknown
		//IL_20f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ff: Expected O, but got Unknown
		//IL_2190: Unknown result type (might be due to invalid IL or missing references)
		//IL_219a: Expected O, but got Unknown
		//IL_221c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2226: Expected O, but got Unknown
		//IL_22c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cc: Expected O, but got Unknown
		//IL_237a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2384: Expected O, but got Unknown
		//IL_2570: Unknown result type (might be due to invalid IL or missing references)
		//IL_257a: Expected O, but got Unknown
		//IL_2627: Unknown result type (might be due to invalid IL or missing references)
		//IL_2631: Expected O, but got Unknown
		//IL_26c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ca: Expected O, but got Unknown
		//IL_2778: Unknown result type (might be due to invalid IL or missing references)
		//IL_2782: Expected O, but got Unknown
		//IL_2811: Unknown result type (might be due to invalid IL or missing references)
		//IL_281b: Expected O, but got Unknown
		//IL_28c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d3: Expected O, but got Unknown
		//IL_2981: Unknown result type (might be due to invalid IL or missing references)
		//IL_298b: Expected O, but got Unknown
		//IL_2a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a24: Expected O, but got Unknown
		//IL_2ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2abd: Expected O, but got Unknown
		//IL_2b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b55: Expected O, but got Unknown
		//IL_2c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c22: Expected O, but got Unknown
		//IL_2c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c7a: Expected O, but got Unknown
		//IL_2d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d38: Expected O, but got Unknown
		//IL_2dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_2df6: Expected O, but got Unknown
		//IL_2eaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2eb4: Expected O, but got Unknown
		//IL_2f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f75: Expected O, but got Unknown
		//IL_302c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3036: Expected O, but got Unknown
		//IL_30ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f7: Expected O, but got Unknown
		//IL_3171: Unknown result type (might be due to invalid IL or missing references)
		//IL_317b: Expected O, but got Unknown
		//IL_322c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3236: Expected O, but got Unknown
		//IL_32d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32da: Expected O, but got Unknown
		//IL_3354: Unknown result type (might be due to invalid IL or missing references)
		//IL_335e: Expected O, but got Unknown
		//IL_341c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3426: Expected O, but got Unknown
		//IL_34c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_34cf: Expected O, but got Unknown
		//IL_357c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3586: Expected O, but got Unknown
		//IL_3637: Unknown result type (might be due to invalid IL or missing references)
		//IL_3641: Expected O, but got Unknown
		//IL_36cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d9: Expected O, but got Unknown
		//IL_3767: Unknown result type (might be due to invalid IL or missing references)
		//IL_3771: Expected O, but got Unknown
		//IL_38cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_38d9: Expected O, but got Unknown
		//IL_397a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3984: Expected O, but got Unknown
		//IL_3ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3acd: Expected O, but got Unknown
		//IL_3b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b8b: Expected O, but got Unknown
		//IL_3c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c46: Expected O, but got Unknown
		//IL_3d97: Unknown result type (might be due to invalid IL or missing references)
		//IL_3da1: Expected O, but got Unknown
		//IL_3e61: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e6b: Expected O, but got Unknown
		//IL_3efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f06: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_PURC_HM));
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
		chkBillImage = new CheckBox();
		chkHalfPrint = new CheckBox();
		chkWapp = new CheckBox();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_IDTL = new TextBox();
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
		MSG_PR_TOT = new AxMSFlexGrid();
		LOpSilver = new Label();
		LOpGold = new Label();
		LOpAmt = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		tSlBill = new TextBox();
		Label5 = new Label();
		tSlBill_DbCd = new TextBox();
		cboItemTyp = new ComboBox();
		Label12 = new Label();
		nPartyFine = new TextBox();
		Label14 = new Label();
		Label15 = new Label();
		nitGwt = new TextBox();
		nItNwt = new TextBox();
		lblOldFine = new Label();
		PnlPrIdtl = new Panel();
		TEXT_PR_IDTL = new TextBox();
		MSG_PR_IDTL = new AxMSFlexGrid();
		pnlBill = new Panel();
		btnBillDel = new SimpleButton();
		btnBillSelect = new SimpleButton();
		btnbillCap = new SimpleButton();
		PicBill = new PictureBox();
		chkRateUnFix = new CheckBox();
		nCrDays = new TextBox();
		Label22 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((Control)PnlPrIdtl).SuspendLayout();
		((ISupportInitialize)MSG_PR_IDTL).BeginInit();
		((Control)pnlBill).SuspendLayout();
		((ISupportInitialize)PicBill).BeginInit();
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
		lblBook.Text = "Purchase";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(312, 38);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(229, 39);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 40);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(105, 38);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(483, 38);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(394, 38);
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
		((Control)PnlBotam).TabIndex = 21;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkBillImage);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkHalfPrint);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkBillImage).BackColor = Color.Transparent;
		((Control)chkBillImage).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBillImage).ForeColor = Color.Black;
		((Control)chkBillImage).Location = new Point(474, 3);
		((Control)chkBillImage).Name = "chkBillImage";
		((Control)chkBillImage).RightToLeft = (RightToLeft)0;
		((Control)chkBillImage).Size = new Size(98, 27);
		((Control)chkBillImage).TabIndex = 6;
		((ButtonBase)chkBillImage).Text = "Bill Image";
		((ButtonBase)chkBillImage).UseVisualStyleBackColor = false;
		((Control)chkBillImage).Visible = false;
		((ButtonBase)chkHalfPrint).BackColor = Color.Transparent;
		((Control)chkHalfPrint).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHalfPrint).ForeColor = Color.Black;
		((Control)chkHalfPrint).Location = new Point(357, 3);
		((Control)chkHalfPrint).Name = "chkHalfPrint";
		((Control)chkHalfPrint).RightToLeft = (RightToLeft)0;
		((Control)chkHalfPrint).Size = new Size(111, 27);
		((Control)chkHalfPrint).TabIndex = 7;
		((ButtonBase)chkHalfPrint).Text = "A4 Half Print";
		((ButtonBase)chkHalfPrint).UseVisualStyleBackColor = false;
		((Control)chkHalfPrint).Visible = false;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(232, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(119, 27);
		((Control)chkWapp).TabIndex = 11;
		((ButtonBase)chkWapp).Text = "Whatsapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
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
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(429, 403);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 16;
		((Control)TEXT_IDTL).Visible = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1176, 367);
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
		((Control)BtnF1).Location = new Point(187, 38);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 393);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(312, 67);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 67);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(347, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(230, 66);
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
		((Control)tEmpCode).Location = new Point(92, 436);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(56, 23);
		((Control)tEmpCode).TabIndex = 18;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(152, 436);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(266, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(15, 436);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(8, 489);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(92, 495);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(326, 61);
		((Control)tVchDesc).TabIndex = 20;
		((Control)MSG2_TOTAL).Location = new Point(729, 275);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 284);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(13, 96);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1156, 157);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(924, 407);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 17;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(797, 163);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 6;
		((Control)TEXT_PR).Visible = false;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(92, 464);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(220, 23);
		((Control)tBankName).TabIndex = 19;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(8, 464);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 67);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(105, 67);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
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
		((Control)PanelAdd).Location = new Point(312, 97);
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
		((Control)MSG_PR_TOT).Location = new Point(15, 256);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(1153, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(1020, 74);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(148, 20);
		((Control)LOpSilver).TabIndex = 1210;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(1020, 54);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(148, 20);
		((Control)LOpGold).TabIndex = 1209;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1020, 34);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1208;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(577, 539);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(143, 20);
		((Control)LClSilver).TabIndex = 1213;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(577, 518);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(143, 20);
		((Control)lClGold).TabIndex = 1212;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(577, 497);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(143, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSlBill).BackColor = Color.White;
		((Control)tSlBill).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSlBill).Location = new Point(821, 67);
		((TextBoxBase)tSlBill).MaxLength = 8;
		((Control)tSlBill).Name = "tSlBill";
		((TextBoxBase)tSlBill).ReadOnly = true;
		((Control)tSlBill).Size = new Size(76, 23);
		((Control)tSlBill).TabIndex = 1214;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(750, 68);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(66, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "Sl Bil No";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSlBill_DbCd).BackColor = Color.White;
		((Control)tSlBill_DbCd).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSlBill_DbCd).Location = new Point(903, 67);
		((TextBoxBase)tSlBill_DbCd).MaxLength = 8;
		((Control)tSlBill_DbCd).Name = "tSlBill_DbCd";
		((TextBoxBase)tSlBill_DbCd).ReadOnly = true;
		((Control)tSlBill_DbCd).Size = new Size(76, 23);
		((Control)tSlBill_DbCd).TabIndex = 1216;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(654, 39);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(87, 22);
		((Control)cboItemTyp).TabIndex = 1217;
		((Control)cboItemTyp).Visible = false;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(571, 40);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(74, 20);
		((Control)Label12).TabIndex = 1218;
		Label12.Text = "Item Type";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label12).Visible = false;
		((TextBoxBase)nPartyFine).BackColor = Color.White;
		((Control)nPartyFine).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPartyFine).Location = new Point(648, 436);
		((TextBoxBase)nPartyFine).MaxLength = 50;
		((Control)nPartyFine).Name = "nPartyFine";
		((Control)nPartyFine).Size = new Size(71, 23);
		((Control)nPartyFine).TabIndex = 1219;
		nPartyFine.TextAlign = (HorizontalAlignment)1;
		((Control)nPartyFine).Visible = false;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(578, 438);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(69, 20);
		((Control)Label14).TabIndex = 1220;
		Label14.Text = "Party Fine";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label14).Visible = false;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(750, 40);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(66, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Item Wt";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nitGwt).BackColor = Color.White;
		((Control)nitGwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nitGwt).Location = new Point(821, 40);
		((TextBoxBase)nitGwt).MaxLength = 8;
		((Control)nitGwt).Name = "nitGwt";
		((TextBoxBase)nitGwt).ReadOnly = true;
		((Control)nitGwt).Size = new Size(76, 23);
		((Control)nitGwt).TabIndex = 1222;
		((TextBoxBase)nItNwt).BackColor = Color.White;
		((Control)nItNwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItNwt).Location = new Point(903, 40);
		((TextBoxBase)nItNwt).MaxLength = 8;
		((Control)nItNwt).Name = "nItNwt";
		((TextBoxBase)nItNwt).ReadOnly = true;
		((Control)nItNwt).Size = new Size(76, 23);
		((Control)nItNwt).TabIndex = 1223;
		((Control)lblOldFine).BackColor = Color.Transparent;
		((Control)lblOldFine).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblOldFine).ForeColor = Color.Red;
		lblOldFine.ImeMode = (ImeMode)0;
		((Control)lblOldFine).Location = new Point(600, 475);
		((Control)lblOldFine).Name = "lblOldFine";
		((Control)lblOldFine).Size = new Size(120, 20);
		((Control)lblOldFine).TabIndex = 1225;
		lblOldFine.Text = "Old Itm Fine";
		lblOldFine.TextAlign = (ContentAlignment)64;
		((Control)lblOldFine).Visible = false;
		((Control)PnlPrIdtl).BackColor = SystemColors.ButtonHighlight;
		((Control)PnlPrIdtl).Controls.Add((Control)(object)TEXT_PR_IDTL);
		((Control)PnlPrIdtl).Controls.Add((Control)(object)MSG_PR_IDTL);
		((Control)PnlPrIdtl).Location = new Point(-26, 275);
		((Control)PnlPrIdtl).Name = "PnlPrIdtl";
		((Control)PnlPrIdtl).Size = new Size(751, 153);
		((Control)PnlPrIdtl).TabIndex = 7;
		((TextBoxBase)TEXT_PR_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR_IDTL).ForeColor = Color.White;
		((Control)TEXT_PR_IDTL).Location = new Point(338, 55);
		((Control)TEXT_PR_IDTL).Name = "TEXT_PR_IDTL";
		((Control)TEXT_PR_IDTL).Size = new Size(100, 18);
		((Control)TEXT_PR_IDTL).TabIndex = 9;
		((Control)TEXT_PR_IDTL).Visible = false;
		((Control)MSG_PR_IDTL).Location = new Point(39, 6);
		((Control)MSG_PR_IDTL).Name = "MSG_PR_IDTL";
		((AxHost)MSG_PR_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_PR_IDTL.OcxState");
		((Control)MSG_PR_IDTL).Size = new Size(706, 144);
		((Control)MSG_PR_IDTL).TabIndex = 0;
		((Control)pnlBill).BackColor = Color.FromArgb(255, 224, 192);
		pnlBill.BorderStyle = (BorderStyle)1;
		((Control)pnlBill).Controls.Add((Control)(object)btnBillDel);
		((Control)pnlBill).Controls.Add((Control)(object)btnBillSelect);
		((Control)pnlBill).Controls.Add((Control)(object)btnbillCap);
		((Control)pnlBill).Controls.Add((Control)(object)PicBill);
		((Control)pnlBill).Location = new Point(428, 321);
		((Control)pnlBill).Name = "pnlBill";
		((Control)pnlBill).Size = new Size(213, 242);
		((Control)pnlBill).TabIndex = 1249;
		((Control)pnlBill).Visible = false;
		btnBillDel.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)btnBillDel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnBillDel.ImageOptions.SvgImage");
		((Control)btnBillDel).Location = new Point(145, 198);
		((BaseControl)btnBillDel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnBillDel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBillDel).Name = "btnBillDel";
		((Control)btnBillDel).Size = new Size(43, 32);
		((Control)btnBillDel).TabIndex = 1183;
		((BaseControl)btnBillDel).ToolTip = "Image Delete";
		btnBillSelect.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)btnBillSelect.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnBillSelect.ImageOptions.SvgImage");
		((Control)btnBillSelect).Location = new Point(84, 198);
		((BaseControl)btnBillSelect).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnBillSelect).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBillSelect).Name = "btnBillSelect";
		((Control)btnBillSelect).Size = new Size(43, 32);
		((Control)btnBillSelect).TabIndex = 1182;
		((BaseControl)btnBillSelect).ToolTip = "Image Select";
		btnbillCap.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)btnbillCap.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnbillCap.ImageOptions.SvgImage");
		((Control)btnbillCap).Location = new Point(23, 198);
		((BaseControl)btnbillCap).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnbillCap).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnbillCap).Name = "btnbillCap";
		((Control)btnbillCap).Size = new Size(43, 32);
		((Control)btnbillCap).TabIndex = 1181;
		((BaseControl)btnbillCap).ToolTip = "Image Capture";
		((Control)PicBill).BackColor = SystemColors.ButtonHighlight;
		PicBill.BorderStyle = (BorderStyle)1;
		PicBill.ImeMode = (ImeMode)0;
		((Control)PicBill).Location = new Point(8, 8);
		((Control)PicBill).Name = "PicBill";
		((Control)PicBill).Size = new Size(195, 182);
		PicBill.SizeMode = (PictureBoxSizeMode)4;
		PicBill.TabIndex = 1139;
		PicBill.TabStop = false;
		((ButtonBase)chkRateUnFix).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkRateUnFix).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkRateUnFix).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkRateUnFix).Location = new Point(92, 8);
		((Control)chkRateUnFix).Name = "chkRateUnFix";
		((Control)chkRateUnFix).RightToLeft = (RightToLeft)0;
		((Control)chkRateUnFix).Size = new Size(116, 19);
		((Control)chkRateUnFix).TabIndex = 1250;
		((ButtonBase)chkRateUnFix).Text = "Rate UnFix";
		((ButtonBase)chkRateUnFix).UseVisualStyleBackColor = false;
		((Control)chkRateUnFix).Visible = false;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(380, 464);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(38, 23);
		((Control)nCrDays).TabIndex = 1252;
		nCrDays.TextAlign = (HorizontalAlignment)2;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(325, 465);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(50, 20);
		((Control)Label22).TabIndex = 1253;
		Label22.Text = "CrDys";
		Label22.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)chkRateUnFix);
		((Control)this).Controls.Add((Control)(object)pnlBill);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)PnlPrIdtl);
		((Control)this).Controls.Add((Control)(object)lblOldFine);
		((Control)this).Controls.Add((Control)(object)nItNwt);
		((Control)this).Controls.Add((Control)(object)nitGwt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nPartyFine);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tSlBill_DbCd);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tSlBill);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)MSG_PR_TOT);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
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
		((Control)this).Name = "TR_PURC_HM";
		((Form)this).Text = "Purchase Wiht Hm";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_PR).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((Control)PnlPrIdtl).ResumeLayout(false);
		((Control)PnlPrIdtl).PerformLayout();
		((ISupportInitialize)MSG_PR_IDTL).EndInit();
		((Control)pnlBill).ResumeLayout(false);
		((ISupportInitialize)PicBill).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_PR_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		mSG_PR_IDTL.Clear();
		mSG_PR_IDTL.Cols = 23;
		mSG_PR_IDTL.FixedRows = 1;
		mSG_PR_IDTL.Rows = 2;
		mSG_PR_IDTL.Row = 0;
		mSG_PR_IDTL[0] = 0;
		mSG_PR_IDTL[1] = 0;
		mSG_PR_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_PR_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_PR_IDTL[0] = 3;
			mSG_PR_IDTL[0, 0] = "Sr";
			mSG_PR_IDTL[1] = (int)Math.Round(850.0 * ColCon);
			mSG_PR_IDTL[1] = 0;
			mSG_PR_IDTL[0, 1] = "ItCode";
			mSG_PR_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_PR_IDTL[2] = 0;
			mSG_PR_IDTL[0, 2] = "ItName";
			mSG_PR_IDTL[3] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[3] = 7;
			mSG_PR_IDTL[0, 3] = "Pcs";
			mSG_PR_IDTL[4] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[4] = 7;
			mSG_PR_IDTL[0, 4] = "PcsWt";
			mSG_PR_IDTL[5] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[5] = 7;
			mSG_PR_IDTL[0, 5] = "KrWt";
			mSG_PR_IDTL[6] = (int)Math.Round(800.0 * ColCon);
			mSG_PR_IDTL[6] = 7;
			mSG_PR_IDTL[0, 6] = "KrLs%";
			mSG_PR_IDTL[7] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR_IDTL[7] = 7;
			mSG_PR_IDTL[0, 7] = "Weight";
			mSG_PR_IDTL[8] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[8] = 7;
			mSG_PR_IDTL[0, 8] = "Con%";
			mSG_PR_IDTL[9] = (int)Math.Round(650.0 * ColCon);
			mSG_PR_IDTL[9] = 3;
			mSG_PR_IDTL[0, 9] = "P/W";
			mSG_PR_IDTL[10] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[10] = 7;
			mSG_PR_IDTL[0, 10] = "PRate";
			mSG_PR_IDTL[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR_IDTL[11] = 7;
			mSG_PR_IDTL[0, 11] = "PAmt";
			mSG_PR_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[12] = 7;
			mSG_PR_IDTL[0, 12] = "Rate";
			mSG_PR_IDTL[13] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR_IDTL[13] = 7;
			mSG_PR_IDTL[0, 13] = "ItAmt";
			mSG_PR_IDTL[14] = (int)Math.Round(850.0 * ColCon);
			mSG_PR_IDTL[14] = 7;
			mSG_PR_IDTL[0, 14] = "LbrRate";
			mSG_PR_IDTL[15] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[15] = 7;
			mSG_PR_IDTL[0, 15] = "LbrAmt";
			mSG_PR_IDTL[16] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR_IDTL[16] = 7;
			mSG_PR_IDTL[0, 16] = "NetAmt";
			mSG_PR_IDTL[17] = 0;
			mSG_PR_IDTL[0, 17] = "ConWt";
			mSG_PR_IDTL[18] = 0;
			mSG_PR_IDTL[0, 18] = "ItType";
			mSG_PR_IDTL[19] = 0;
			mSG_PR_IDTL[0, 19] = "RowSrNo";
			mSG_PR_IDTL[20] = 0;
			mSG_PR_IDTL[0, 20] = "KrConWt";
			mSG_PR_IDTL[21] = 0;
			mSG_PR_IDTL[0, 21] = "2RowVal";
			mSG_PR_IDTL[22] = 0;
			mSG_PR_IDTL[0, 22] = "2RowText";
			mSG_PR_IDTL.Row = 1;
			mSG_PR_IDTL.Col = 0;
			((Control)TEXT_PR_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_PR_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_PR_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_PR_IDTL[DC_Main.M] = 0;
						}
						mSG_PR_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_PR_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_PR_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_PR_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Pr_Idtl();
			mSG_PR_IDTL = null;
		}
	}

	private void CommPassAdd_Pr_Idtl()
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		mSG_PR_IDTL[mSG_PR_IDTL.Row, 0] = Conversions.ToString(mSG_PR_IDTL.Row);
		mSG_PR_IDTL[mSG_PR_IDTL.Row, 19] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 80]));
		mSG_PR_IDTL = null;
	}

	private void TEXT_PR_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_PR_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Invalid comparison between Unknown and I4
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Invalid comparison between Unknown and I4
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Invalid comparison between Unknown and I4
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Invalid comparison between Unknown and I4
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = DtIdtlPr.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19])) == Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 19])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 0])))
						{
							DtIdtlPr.Rows[i][1] = "";
							DtIdtlPr.Rows[i][2] = "";
							DtIdtlPr.Rows[i][3] = 0;
							DtIdtlPr.Rows[i][4] = 0;
							DtIdtlPr.Rows[i][5] = 0;
							DtIdtlPr.Rows[i][6] = 0;
							DtIdtlPr.Rows[i][7] = 0;
							DtIdtlPr.Rows[i][8] = 0;
							DtIdtlPr.Rows[i][9] = "";
							DtIdtlPr.Rows[i][10] = 0;
							DtIdtlPr.Rows[i][11] = 0;
							DtIdtlPr.Rows[i][12] = 0;
							DtIdtlPr.Rows[i][13] = 0;
							DtIdtlPr.Rows[i][14] = 0;
							DtIdtlPr.Rows[i][15] = 0;
							DtIdtlPr.Rows[i][16] = 0;
							DtIdtlPr.Rows[i][17] = 0;
							DtIdtlPr.Rows[i][18] = 0.0;
							DtIdtlPr.Rows[i][20] = 0;
							break;
						}
					}
					int num2 = mSG_PR_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_PR_IDTL[mSG_PR_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Pr_Idtl(1);
					TEXT_PR_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....Please Save Voucher.....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_PR_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_PR_IDTL.Col = checked(mSG_PR_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR_IDTL.Col < 16)
				{
					mSG_PR_IDTL.Col = checked(mSG_PR_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_PR_IDTL.Row > 1)
				{
					mSG_PR_IDTL.Row = checked(mSG_PR_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_PR_IDTL.Row < mSG_PR_IDTL.Rows - 1)
					{
						mSG_PR_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_PR_IDTL.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_PR_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_PR_IDTL).Visible = false;
							MSG_PR.Col = 13;
							MSG_PR_EnterCell(MSG_PR, new EventArgs());
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR_IDTL.Text + "'";
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
									TEXT_PR_IDTL.Text = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 18] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR_IDTL).Focus();
							}
							return;
						}
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 12]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 8]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						break;
					case 4:
						if ((Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 3]) != 0.0) & (Conversion.Val(TEXT_PR_IDTL.Text) != 0.0))
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 5] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 3]) * Conversion.Val(TEXT_PR_IDTL.Text)), "0.000");
						}
						break;
					case 7:
						if ((Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 3]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 7]) == 0.0))
						{
							if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 16]) == 0.0)
							{
								mSG_PR_IDTL[mSG_PR_IDTL.Row, 16] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 12] = "";
						}
						break;
					case 16:
						if (mSG_PR_IDTL.Row == mSG_PR_IDTL.Rows - 1)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 16] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
							CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
							MsgClearIdtlPr = true;
							mSG_PR_IDTL.Rows += 1;
							mSG_PR_IDTL.Row += 1;
							MsgClearIdtlPr = false;
							mSG_PR_IDTL.Col = 1;
							CommPassAdd_Pr_Idtl();
						}
						else
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 16] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
							CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
							((Control)TEXT_PR_IDTL).Visible = false;
							mSG_PR_IDTL.Row += 1;
							mSG_PR_IDTL.Col = 1;
							((Control)TEXT_PR_IDTL).Visible = true;
							((Control)TEXT_PR_IDTL).Focus();
						}
						return;
					}
					if (mSG_PR_IDTL.Col < mSG_PR_IDTL.Cols - 1)
					{
						mSG_PR_IDTL.Col += 1;
					}
					((Control)TEXT_PR_IDTL).Visible = true;
					((Control)TEXT_PR_IDTL).Focus();
				}
			}
		}
		mSG_PR_IDTL = null;
	}

	private void MSG_PR_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		checked
		{
			if (mSG_PR_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_PR_IDTL).Left = (int)Math.Round((double)((Control)mSG_PR_IDTL).Left + (double)mSG_PR_IDTL.CellLeft / 15.0);
				((Control)TEXT_PR_IDTL).Top = (int)Math.Round((double)((Control)mSG_PR_IDTL).Top + (double)mSG_PR_IDTL.CellTop / 15.0);
				((Control)TEXT_PR_IDTL).Width = (int)Math.Round((double)mSG_PR_IDTL.CellWidth / 15.0);
				((Control)TEXT_PR_IDTL).Height = (int)Math.Round((double)mSG_PR_IDTL.CellHeight / 15.0);
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				((Control)TEXT_PR_IDTL).Visible = true;
				((Control)TEXT_PR).Visible = false;
				((TextBoxBase)TEXT_PR_IDTL).SelectAll();
				((Control)TEXT_PR_IDTL).Focus();
				mSG_PR_IDTL = null;
			}
		}
	}

	private void MSG_PR_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		checked
		{
			if (mSG_PR_IDTL[mSG_PR_IDTL.Col] == 0)
			{
				TEXT_PR_IDTL.Text = "";
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_PR_IDTL[mSG_PR_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_PR_IDTL.Col > 1)
						{
							mSG_PR_IDTL.Col -= 1;
						}
					}
					else if (mSG_PR_IDTL.Col < mSG_PR_IDTL.Cols - 1)
					{
						mSG_PR_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_PR_IDTL.Row == 0) | (mSG_PR_IDTL.CellWidth <= 0)) && mSG_PR_IDTL[mSG_PR_IDTL.Col] != 0)
			{
				((Control)TEXT_PR_IDTL).Left = (int)Math.Round((double)((Control)mSG_PR_IDTL).Left + (double)mSG_PR_IDTL.CellLeft / 15.0);
				((Control)TEXT_PR_IDTL).Top = (int)Math.Round((double)((Control)mSG_PR_IDTL).Top + (double)mSG_PR_IDTL.CellTop / 15.0);
				((Control)TEXT_PR_IDTL).Width = (int)Math.Round((double)mSG_PR_IDTL.CellWidth / 15.0);
				((Control)TEXT_PR_IDTL).Height = (int)Math.Round((double)mSG_PR_IDTL.CellHeight / 15.0);
				((Control)TEXT_PR_IDTL).Visible = true;
				((TextBoxBase)TEXT_PR_IDTL).ReadOnly = false;
				switch (MSG_PR_IDTL.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 5;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 50;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 9:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 1;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 6;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0");
					break;
				case 8:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.000");
					break;
				case 6:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.00");
					break;
				case 4:
				case 5:
				case 7:
				case 17:
				case 20:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.000");
					break;
				}
				mSG_PR_IDTL = null;
				((TextBoxBase)TEXT_PR_IDTL).SelectAll();
			}
		}
	}

	private void MSG_PR_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtlPr && MSG_PR_IDTL.Row != 0 && MSG_PR_IDTL[MSG_PR_IDTL.Col] != 0 && ((Control)TEXT_PR_IDTL).Visible)
		{
			AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
			switch (MSG_PR_IDTL.Col)
			{
			case 0:
			case 1:
			case 2:
			case 9:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = TEXT_PR_IDTL.Text;
				break;
			case 3:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			case 8:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.000");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			case 6:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			case 4:
			case 5:
			case 7:
			case 17:
			case 20:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.000");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			}
			mSG_PR_IDTL = null;
		}
	}

	private void CommPassTotal_Pr_Idtl(int XRow)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 3]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 4]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 5] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 3]) * Conversion.Val(mSG_PR_IDTL[XRow, 4])), "0.000");
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 6]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 5]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 7] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 5]) * Conversion.Val(mSG_PR_IDTL[XRow, 6]) / 100.0), "0.000");
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 5]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 8]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 5]) * Conversion.Val(mSG_PR_IDTL[XRow, 8])), "0.000");
		}
		else
		{
			mSG_PR_IDTL[XRow, 20] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 7]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 8]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 17] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 7]) * Conversion.Val(mSG_PR_IDTL[XRow, 8])), "0.000");
		}
		else
		{
			mSG_PR_IDTL[XRow, 17] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_PR_IDTL[XRow, 9], "", false) == 0)
		{
			if ((Conversion.Val(mSG_PR_IDTL[XRow, 7]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 3]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 13] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 3])), "0.00");
			}
			else if ((Conversion.Val(mSG_PR_IDTL[XRow, 7]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 13] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 7])), "0.00");
			}
			if ((Conversion.Val(mSG_PR_IDTL[XRow, 7]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 3]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 11] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 10]) * Conversion.Val(mSG_PR_IDTL[XRow, 3])), "0.00");
			}
			else if ((Conversion.Val(mSG_PR_IDTL[XRow, 7]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 11] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 10]) * Conversion.Val(mSG_PR_IDTL[XRow, 5])), "0.00");
			}
		}
		else
		{
			if ((Operators.CompareString(mSG_PR_IDTL[XRow, 9], "P", false) == 0) & (Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 13] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 3])), "0.00");
			}
			else if (Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0)
			{
				mSG_PR_IDTL[XRow, 13] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 7])), "0.00");
			}
			if ((Operators.CompareString(mSG_PR_IDTL[XRow, 9], "P", false) == 0) & (Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 11] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 10]) * Conversion.Val(mSG_PR_IDTL[XRow, 3])), "0.00");
			}
			else if (Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0)
			{
				mSG_PR_IDTL[XRow, 11] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 10]) * Conversion.Val(mSG_PR_IDTL[XRow, 5])), "0.00");
			}
		}
		if (Conversion.Val(mSG_PR_IDTL[XRow, 14]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 15] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 14]) * Conversion.Val(mSG_PR_IDTL[XRow, 3])), "0.00");
		}
		if (Conversion.Val(mSG_PR_IDTL[XRow, 13]) + Conversion.Val(mSG_PR_IDTL[XRow, 15]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 16] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 13]) + Conversion.Val(mSG_PR_IDTL[XRow, 15])), "0.00");
		}
		checked
		{
			int num5 = mSG_PR_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 17]);
				num4 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 20]);
				if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
				{
					num2 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 11]);
					num += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 16]);
				}
				else
				{
					num2 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 16]);
					if (Operators.CompareString(mSG_PR_IDTL[DC_Main.M, 1], "HM", false) == 0)
					{
						if (Conversion.Val(mSG_PR_IDTL[DC_Main.M, 16]) != 0.0)
						{
							MSG_PR[MSG_PR.Row, 39] = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[DC_Main.M, 16]), "0.00");
						}
					}
					else
					{
						num += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 16]);
					}
				}
				DC_Main.M++;
			}
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				if (num2 != 0.0)
				{
					MSG_PR[MSG_PR.Row, 31] = Strings.Format((object)num2, "0.00");
				}
				if (num != 0.0)
				{
					MSG_PR[MSG_PR.Row, 51] = Strings.Format((object)num, "0.00");
				}
			}
			else if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 31] = Strings.Format((object)num, "0.00");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 13] = Strings.Format((object)num4, "0.000");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 12]) - num4), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 40] = Strings.Format((object)num3, "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 41] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 12]) - num3), "0.000");
			}
			if (Operators.CompareString(mSG_PR_IDTL[XRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtlPr.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19])) == Conversion.Val(mSG_PR_IDTL[XRow, 19])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_PR_IDTL[XRow, 0])))
					{
						flag = true;
						DtIdtlPr.Rows[i][0] = mSG_PR_IDTL[XRow, 0];
						DtIdtlPr.Rows[i][1] = mSG_PR_IDTL[XRow, 1];
						DtIdtlPr.Rows[i][2] = mSG_PR_IDTL[XRow, 2];
						DtIdtlPr.Rows[i][3] = mSG_PR_IDTL[XRow, 3];
						DtIdtlPr.Rows[i][4] = mSG_PR_IDTL[XRow, 4];
						DtIdtlPr.Rows[i][5] = mSG_PR_IDTL[XRow, 5];
						DtIdtlPr.Rows[i][6] = mSG_PR_IDTL[XRow, 6];
						DtIdtlPr.Rows[i][7] = mSG_PR_IDTL[XRow, 7];
						DtIdtlPr.Rows[i][8] = mSG_PR_IDTL[XRow, 8];
						DtIdtlPr.Rows[i][9] = mSG_PR_IDTL[XRow, 9];
						DtIdtlPr.Rows[i][10] = mSG_PR_IDTL[XRow, 10];
						DtIdtlPr.Rows[i][11] = mSG_PR_IDTL[XRow, 11];
						DtIdtlPr.Rows[i][12] = mSG_PR_IDTL[XRow, 12];
						DtIdtlPr.Rows[i][13] = mSG_PR_IDTL[XRow, 13];
						DtIdtlPr.Rows[i][14] = mSG_PR_IDTL[XRow, 14];
						DtIdtlPr.Rows[i][15] = mSG_PR_IDTL[XRow, 15];
						DtIdtlPr.Rows[i][16] = mSG_PR_IDTL[XRow, 16];
						DtIdtlPr.Rows[i][17] = mSG_PR_IDTL[XRow, 17];
						DtIdtlPr.Rows[i][18] = mSG_PR_IDTL[XRow, 18];
						DtIdtlPr.Rows[i][19] = mSG_PR_IDTL[XRow, 19];
						DtIdtlPr.Rows[i][20] = mSG_PR_IDTL[XRow, 20];
						DtIdtlPr.Rows[i][21] = mSG_PR_IDTL[XRow, 21];
						DtIdtlPr.Rows[i][22] = mSG_PR_IDTL[XRow, 22];
						break;
					}
				}
				if (!flag)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[0] = mSG_PR_IDTL[XRow, 0];
					drPr[1] = mSG_PR_IDTL[XRow, 1];
					drPr[2] = mSG_PR_IDTL[XRow, 2];
					drPr[3] = mSG_PR_IDTL[XRow, 3];
					drPr[4] = mSG_PR_IDTL[XRow, 4];
					drPr[5] = mSG_PR_IDTL[XRow, 5];
					drPr[6] = mSG_PR_IDTL[XRow, 6];
					drPr[7] = mSG_PR_IDTL[XRow, 7];
					drPr[8] = mSG_PR_IDTL[XRow, 8];
					drPr[9] = mSG_PR_IDTL[XRow, 9];
					drPr[10] = mSG_PR_IDTL[XRow, 10];
					drPr[11] = mSG_PR_IDTL[XRow, 11];
					drPr[12] = mSG_PR_IDTL[XRow, 12];
					drPr[13] = mSG_PR_IDTL[XRow, 13];
					drPr[14] = mSG_PR_IDTL[XRow, 14];
					drPr[15] = mSG_PR_IDTL[XRow, 15];
					drPr[16] = mSG_PR_IDTL[XRow, 16];
					drPr[17] = mSG_PR_IDTL[XRow, 17];
					drPr[18] = mSG_PR_IDTL[XRow, 18];
					drPr[19] = mSG_PR_IDTL[XRow, 19];
					drPr[20] = mSG_PR_IDTL[XRow, 20];
					drPr[21] = 0;
					drPr[22] = "";
					DtIdtlPr.Rows.Add(drPr);
				}
			}
			mSG_PR_IDTL = null;
		}
	}

	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		if (MSG_PR.Row == 0 || !((MsgOldRowPr != MSG_PR.Row) & !MsgClearPr))
		{
			return;
		}
		MsgOldRowPr = MSG_PR.Row;
		MSG_PR_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG_PR[MSG_PR.Row, 80]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19])))
				{
					MSG_PR_IDTL[num, 0] = Conversions.ToString(num);
					MSG_PR_IDTL[num, 1] = Conversions.ToString(DtIdtlPr.Rows[i][1]);
					MSG_PR_IDTL[num, 2] = Conversions.ToString(DtIdtlPr.Rows[i][2]);
					MSG_PR_IDTL[num, 3] = Conversions.ToString(DtIdtlPr.Rows[i][3]);
					MSG_PR_IDTL[num, 4] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][4], (object)""));
					MSG_PR_IDTL[num, 5] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][5], (object)""));
					MSG_PR_IDTL[num, 6] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][6], (object)""));
					MSG_PR_IDTL[num, 7] = Conversions.ToString(DtIdtlPr.Rows[i][7]);
					MSG_PR_IDTL[num, 8] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][8], (object)""));
					MSG_PR_IDTL[num, 9] = Conversions.ToString(DtIdtlPr.Rows[i][9]);
					MSG_PR_IDTL[num, 10] = Conversions.ToString(DtIdtlPr.Rows[i][10]);
					MSG_PR_IDTL[num, 11] = Conversions.ToString(DtIdtlPr.Rows[i][11]);
					MSG_PR_IDTL[num, 12] = Conversions.ToString(DtIdtlPr.Rows[i][12]);
					MSG_PR_IDTL[num, 13] = Conversions.ToString(DtIdtlPr.Rows[i][13]);
					MSG_PR_IDTL[num, 14] = Conversions.ToString(DtIdtlPr.Rows[i][14]);
					MSG_PR_IDTL[num, 15] = Conversions.ToString(DtIdtlPr.Rows[i][15]);
					MSG_PR_IDTL[num, 16] = Conversions.ToString(DtIdtlPr.Rows[i][16]);
					MSG_PR_IDTL[num, 17] = Conversions.ToString(DtIdtlPr.Rows[i][17]);
					MSG_PR_IDTL[num, 18] = Conversions.ToString(DtIdtlPr.Rows[i][18]);
					MSG_PR_IDTL[num, 19] = Conversions.ToString(DtIdtlPr.Rows[i][19]);
					MSG_PR_IDTL[num, 20] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][20], (object)""));
					MSG_PR_IDTL[num, 21] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][21], (object)""));
					MSG_PR_IDTL[num, 22] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][22], (object)""));
					MSG_PR_IDTL.Rows += 1;
					num++;
				}
			}
			MSG_PR_IDTL[num, 0] = Conversions.ToString(num);
			MSG_PR_IDTL[num, 19] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 80]));
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 94;
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
			mSG_PR[4] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Counter";
			mSG_PR[5] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[5] = 0;
			mSG_PR[0, 5] = "Design";
			if (Operators.CompareString(DC_Main.MsPurcLot, "Y", false) == 0)
			{
				if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
				{
					mSG_PR[6] = (int)Math.Round(0.0 * ColCon);
					mSG_PR[6] = 0;
					mSG_PR[0, 6] = "LotNo";
				}
				else
				{
					mSG_PR[6] = (int)Math.Round(1200.0 * ColCon);
					mSG_PR[6] = 0;
					mSG_PR[0, 6] = "LotNo";
				}
			}
			else
			{
				mSG_PR[6] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "LotNo";
			}
			mSG_PR[8] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[8] = 0;
			mSG_PR[0, 8] = "Size";
			mSG_PR[9] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "BagWt";
			mSG_PR[10] = (int)Math.Round(700.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "Pcs";
			mSG_PR[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "PsWt";
			mSG_PR[12] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "GrWt";
			mSG_PR[13] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[13] = 7;
			mSG_PR[0, 13] = "OthWt";
			mSG_PR[15] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "NetWt";
			mSG_PR[16] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "Ght%";
			mSG_PR[17] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "GhtWt";
			mSG_PR[18] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[18] = 3;
			mSG_PR[0, 18] = "Touch";
			mSG_PR[19] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[19] = 3;
			mSG_PR[0, 19] = "West%";
			mSG_PR[21] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[21] = 7;
			mSG_PR[0, 21] = "Fine";
			mSG_PR[76] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[76] = 7;
			mSG_PR[0, 76] = "HmFine";
			mSG_PR[22] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[22] = 7;
			mSG_PR[0, 22] = "SlvFine";
			mSG_PR[23] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[23] = 7;
			mSG_PR[0, 23] = "ConRate";
			mSG_PR[24] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "Con%";
			mSG_PR[25] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "Rate";
			mSG_PR[26] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "ItAmt";
			mSG_PR[39] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[39] = 7;
			mSG_PR[0, 39] = "HmAmt";
			mSG_PR[27] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "Lbr%";
			mSG_PR[28] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[28] = 3;
			mSG_PR[0, 28] = "Ltype";
			mSG_PR[29] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[29] = 7;
			mSG_PR[0, 29] = "LRate";
			mSG_PR[30] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "LAmt";
			mSG_PR[31] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "OthAmt";
			mSG_PR[32] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[32] = 3;
			mSG_PR[0, 32] = "ORate";
			mSG_PR[33] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[33] = 7;
			mSG_PR[0, 33] = "OFine";
			mSG_PR[35] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[35] = 7;
			mSG_PR[0, 35] = "Mrp";
			mSG_PR[20] = 0;
			mSG_PR[14] = 0;
			mSG_PR[36] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[36] = 7;
			mSG_PR[0, 36] = "TotAmt";
			mSG_PR[37] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[37] = 7;
			mSG_PR[0, 37] = "TaxPrc";
			mSG_PR[38] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[38] = 7;
			mSG_PR[0, 38] = "NetAmt";
			mSG_PR[68] = 0;
			mSG_PR[69] = 0;
			mSG_PR[70] = 0;
			mSG_PR[71] = 0;
			mSG_PR[72] = 0;
			mSG_PR[73] = 0;
			mSG_PR[74] = 0;
			mSG_PR[75] = 0;
			mSG_PR[77] = 0;
			mSG_PR[78] = 0;
			mSG_PR[79] = 0;
			mSG_PR[80] = 0;
			mSG_PR[81] = 0;
			mSG_PR[82] = 0;
			mSG_PR[67] = 0;
			mSG_PR[83] = 0;
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				mSG_PR[3] = (int)Math.Round(1300.0 * ColCon);
				mSG_PR[3] = 0;
				mSG_PR[0, 3] = "TagNo";
				mSG_PR[40] = (int)Math.Round(800.0 * ColCon);
				mSG_PR[40] = 3;
				mSG_PR[0, 40] = "TOthWt";
				mSG_PR[41] = (int)Math.Round(750.0 * ColCon);
				mSG_PR[41] = 7;
				mSG_PR[0, 41] = "TgNwt";
				mSG_PR[43] = (int)Math.Round(750.0 * ColCon);
				mSG_PR[43] = 7;
				mSG_PR[0, 43] = "TgTch";
				mSG_PR[44] = (int)Math.Round(750.0 * ColCon);
				mSG_PR[44] = 7;
				mSG_PR[0, 44] = "TgW%";
				mSG_PR[45] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[45] = 7;
				mSG_PR[0, 45] = "TgFine";
				mSG_PR[46] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[46] = 7;
				mSG_PR[0, 46] = "TagRate";
				mSG_PR[47] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[47] = 7;
				mSG_PR[0, 47] = "TagItAmt";
				mSG_PR[48] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[48] = 7;
				mSG_PR[0, 48] = "TgLbr%";
				mSG_PR[49] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[49] = 7;
				mSG_PR[0, 49] = "TgLRat";
				mSG_PR[50] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[50] = 7;
				mSG_PR[0, 50] = "TgLAmt";
				mSG_PR[51] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[51] = 7;
				mSG_PR[0, 51] = "TgOth";
				mSG_PR[34] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[34] = 7;
				mSG_PR[0, 34] = "PrCost";
				mSG_PR[54] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[54] = 7;
				mSG_PR[0, 54] = "TgMrp";
				mSG_PR[56] = (int)Math.Round(1300.0 * ColCon);
				mSG_PR[56] = 3;
				mSG_PR[0, 56] = "KrName";
				mSG_PR[82] = 0;
				mSG_PR[82] = 3;
				mSG_PR[0, 82] = "PrCode";
				mSG_PR[42] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[42] = 3;
				mSG_PR[0, 42] = "LCode";
				mSG_PR[55] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[55] = 3;
				mSG_PR[0, 55] = "HmId";
				mSG_PR[58] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[58] = 3;
				mSG_PR[0, 58] = "HmId2";
				mSG_PR[60] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[60] = 3;
				mSG_PR[0, 60] = "HmId3";
				mSG_PR[62] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[62] = 3;
				mSG_PR[0, 62] = "HmId4";
				mSG_PR[57] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[57] = 7;
				mSG_PR[0, 57] = "HmWt";
				mSG_PR[59] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[59] = 7;
				mSG_PR[0, 59] = "HmWt2";
				mSG_PR[61] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[61] = 7;
				mSG_PR[0, 61] = "HmWt3";
				mSG_PR[63] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[63] = 7;
				mSG_PR[0, 63] = "HmWt4";
				mSG_PR[7] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[7] = 0;
				mSG_PR[0, 7] = "Color";
				mSG_PR[52] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[52] = 7;
				mSG_PR[0, 52] = "TagCost";
				mSG_PR[53] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[53] = 7;
				mSG_PR[0, 53] = "Margin%";
				mSG_PR[89] = 0;
			}
			else
			{
				mSG_PR[3] = 0;
				mSG_PR[40] = 0;
				mSG_PR[41] = 0;
				mSG_PR[43] = 0;
				mSG_PR[44] = 0;
				mSG_PR[45] = 0;
				mSG_PR[46] = 0;
				mSG_PR[47] = 0;
				mSG_PR[48] = 0;
				mSG_PR[49] = 0;
				mSG_PR[50] = 0;
				mSG_PR[51] = 0;
				mSG_PR[34] = 0;
				mSG_PR[54] = 0;
				mSG_PR[56] = 0;
				mSG_PR[82] = 0;
				mSG_PR[42] = 0;
				mSG_PR[55] = 0;
				mSG_PR[58] = 0;
				mSG_PR[60] = 0;
				mSG_PR[62] = 0;
				mSG_PR[57] = 0;
				mSG_PR[59] = 0;
				mSG_PR[61] = 0;
				mSG_PR[63] = 0;
				mSG_PR[7] = 0;
				mSG_PR[63] = 0;
				mSG_PR[63] = 0;
				mSG_PR[52] = 0;
				mSG_PR[53] = 0;
				mSG_PR[89] = 0;
			}
			mSG_PR[64] = 0;
			mSG_PR[65] = 0;
			mSG_PR[66] = 0;
			mSG_PR[85] = 0;
			mSG_PR[84] = 0;
			mSG_PR[86] = 0;
			mSG_PR[87] = 0;
			mSG_PR[88] = 0;
			mSG_PR[90] = 0;
			mSG_PR[91] = 0;
			mSG_PR[92] = 0;
			mSG_PR[93] = 0;
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
					if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
					{
						dataView.RowFilter = " BOOK_NAME = 'TAG PURCHASE' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
					}
					else
					{
						dataView.RowFilter = " BOOK_NAME = 'PURC_AC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
					}
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
		checked
		{
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 80] = Conversions.ToString(mSG_PR.Row);
			}
			else
			{
				mSG_PR[mSG_PR.Row, 80] = Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Rows - 2, 80]) + 1.0);
			}
			mSG_PR[mSG_PR.Row, 66] = "A";
			mSG_PR[mSG_PR.Row, 64] = "N";
			mSG_PR[mSG_PR.Row, 65] = "N";
			mSG_PR[mSG_PR.Row, 86] = "N";
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 10] = Conversions.ToString(1);
				if (mSG_PR.Row > 1)
				{
					TEXT_PR.Text = mSG_PR[mSG_PR.Row - 1, 1];
				}
			}
			MSG_PR_IDTL_CLEAR();
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				if (Operators.CompareString(MsVchSrno, "", false) == 0)
				{
					DC_Main.RsQry = "Select Max(TAG_SRNO) AS SrNo FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(TAG_SRNO) = 6 Having Max(TAG_SRNO) > 0";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						MsVchSrno = "000001";
					}
					else
					{
						MsVchSrno = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SrNo"])) + 1.0), "000000");
					}
				}
				else
				{
					MsVchSrno = Strings.Format((object)(Conversion.Val(MsVchSrno) + 1.0), "000000");
				}
				mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MsVchSrno;
			}
			mSG_PR = null;
		}
	}

	private void LotNoGen(int Y)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		DC_Main.RsQry = "SELECT RIGHT(A.LOT_NO,5) AS TAG_SRNO FROM LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.PR_CODE = '" + mSG_PR[Y, 82] + "' GROUP BY RIGHT(A.LOT_NO,5) ORDER BY RIGHT(A.LOT_NO,5) DESC";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = ((dataTable.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "00000") : "00001");
		checked
		{
			int num = mSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG_PR[Y, 6], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 82], mSG_PR[Y, 82], false) == 0) & (Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) >= Conversion.Val(text))) && Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) + 1.0 > Conversion.Val(text))
				{
					text = Strings.Format((object)(Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) + 1.0), "00000");
				}
				DC_Main.i++;
			}
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG_PR[Y, 6] = mSG_PR[Y, 82] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + text;
			}
			else
			{
				mSG_PR[Y, 6] = mSG_PR[Y, 82] + text;
			}
			TEXT_PR.Text = mSG_PR[Y, 6];
			mSG_PR = null;
			dataTable.Clear();
		}
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Invalid comparison between Unknown and I4
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa5: Invalid comparison between Unknown and I4
		//IL_1b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba1: Invalid comparison between Unknown and I4
		//IL_1ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bab: Invalid comparison between Unknown and I4
		//IL_1baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb6: Invalid comparison between Unknown and I4
		//IL_0b11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b14: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b42: Invalid comparison between Unknown and I4
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b77: Invalid comparison between Unknown and I4
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d92: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b1: Invalid comparison between Unknown and I4
		//IL_180a: Unknown result type (might be due to invalid IL or missing references)
		//IL_118d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1362: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
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
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG_PR.Col == 6)
			{
				LotNoGen(mSG_PR.Row);
				return;
			}
			if (mSG_PR.Col == 56)
			{
				DC_Main.RsQry = "SELECT AC_SHORT FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_SHORT = '" + TEXT_PR.Text + "' AND AC_SHORT <> ''";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
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
							mSG_PR[mSG_PR.Row, 56] = DC_Main.ColValue[1];
						}
						((Control)TEXT_PR).Focus();
					}
					return;
				}
			}
			checked
			{
				if (mSG_PR.Col == 3)
				{
					if (((TextBoxBase)TEXT_PR).ReadOnly)
					{
						return;
					}
					int row = mSG_PR.Row;
					AxMSFlexGrid mSG_PR2 = MSG_PR;
					if (Operators.CompareString(TEXT_PR.Text, "", false) != 0)
					{
						return;
					}
					mSG_PR2[mSG_PR2.Row, 3] = "";
					if ((Operators.CompareString(DC_Main.MCo_Type, "", false) != 0) & (Operators.CompareString(DC_Main.MCo_Type, "P", false) != 0))
					{
						DC_Main.RsQry = "SELECT SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG_PR2[row, 82] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG_PR2[row, 81] + "' GROUP BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) ORDER BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) DESC";
					}
					else
					{
						DC_Main.RsQry = "SELECT TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG_PR2[row, 82] + "'  AND TAG_TYPE = '" + mSG_PR2[row, 81] + "' GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
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
					else if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "00000");
					}
					int num2 = mSG_PR2.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num2)
					{
						if (Operators.CompareString(mSG_PR2[row, 3], "", false) == 0 && ((DC_Main.i != row) & (Operators.CompareString(mSG_PR2[DC_Main.i, 82], mSG_PR2[row, 82], false) == 0) & (Operators.CompareString(mSG_PR2[DC_Main.i, 81], mSG_PR2[row, 81], false) == 0) & (Conversion.Val(mSG_PR2[DC_Main.i, 83]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG_PR2[DC_Main.i, 83]) + 1.0)) > Conversion.Val(CurTagNo))
						{
							if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
							{
								CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR2[DC_Main.i, 83]) + 1.0), "0000");
							}
							else
							{
								CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR2[DC_Main.i, 83]) + 1.0), "00000");
							}
						}
						DC_Main.i++;
					}
					mSG_PR2[mSG_PR2.Row, 83] = CurTagNo;
					if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
					{
						mSG_PR2[mSG_PR2.Row, 3] = mSG_PR2[row, 82] + mSG_PR2[row, 81] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
					}
					else
					{
						mSG_PR2[mSG_PR2.Row, 3] = mSG_PR2[row, 82] + mSG_PR2[row, 81] + CurTagNo;
					}
					mSG_PR2 = null;
					TEXT_PR.Text = mSG_PR[mSG_PR.Row, 3];
					dataTable.Clear();
					return;
				}
				if (mSG_PR.Col == 5)
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
						mSG_PR[mSG_PR.Row, 5] = DC_Main.ColValue[0];
						mSG_PR[mSG_PR.Row, 8] = DC_Main.ColValue[3];
						if (Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (Conversion.Val(DC_Main.ColValue[5]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 43] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.00");
							}
							if (Conversion.Val(DC_Main.ColValue[6]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.00");
							}
							if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 48] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
							}
							if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
							}
						}
						mSG_PR[mSG_PR.Row, 86] = DC_Main.ColValue[9];
						MsgOldRowPr = 0;
						MSG_PR_RowColChange(MSG_PR, new EventArgs());
					}
					((Control)TEXT_PR).Focus();
					return;
				}
				TEXT_PR.Text = "";
				mSG_PR[mSG_PR.Row, 5] = "";
				mSG_PR[mSG_PR.Row, 86] = "N";
			}
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
				checked
				{
					if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
					{
						if (mSG_PR.Col < 63)
						{
							mSG_PR.Col += 1;
						}
					}
					else if (mSG_PR.Col < 38)
					{
						mSG_PR.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG_PR.Row > 1)
				{
					mSG_PR.Row = checked(mSG_PR.Row - 1);
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
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND IT_TYPE = '" + FormItmType + "'"))), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND A.IT_TYPE = '" + FormItmType + "'"))), (object)"  ORDER BY A.IT_NAME"));
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
									mSG_PR[mSG_PR.Row, 82] = DC_Main.ColValue[3];
									mSG_PR[mSG_PR.Row, 68] = DC_Main.ColValue[4];
									mSG_PR[mSG_PR.Row, 81] = DC_Main.ColValue[5];
									mSG_PR[mSG_PR.Row, 84] = "";
									mSG_PR[mSG_PR.Row, 85] = "";
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 82] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG_PR[mSG_PR.Row, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 81], mSG_PR[mSG_PR.Row, 84], false) != 0) | (Operators.CompareString(mSG_PR[mSG_PR.Row, 82], mSG_PR[mSG_PR.Row, 85], false) != 0))
						{
							mSG_PR[mSG_PR.Row, 85] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[mSG_PR.Row, 84] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG_PR[mSG_PR.Row, 3] = "";
							mSG_PR[mSG_PR.Row, 83] = "";
						}
						StkRow = 0;
						break;
					case 4:
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
									mSG_PR[mSG_PR.Row, 4] = DC_Main.ColValue[1];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 42:
					{
						if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) != 0 || Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						string text = mSG_PR[mSG_PR.Row, 42];
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
							mSG_PR[mSG_PR.Row, 49] = "";
							mSG_PR[mSG_PR.Row, 50] = "";
							mSG_PR[mSG_PR.Row, 48] = "";
							mSG_PR[mSG_PR.Row, 44] = "";
							mSG_PR[mSG_PR.Row, 54] = "";
						}
						text2 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG_PR[mSG_PR.Row, 42] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						switch (text2)
						{
						case "01":
							mSG_PR[mSG_PR.Row, 49] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG_PR[mSG_PR.Row, 48] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG_PR[mSG_PR.Row, 50] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "04":
							mSG_PR[mSG_PR.Row, 44] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG_PR[mSG_PR.Row, 28] = "K";
							mSG_PR[mSG_PR.Row, 49] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG_PR[mSG_PR.Row, 54] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal_Pr(mSG_PR.Row);
						break;
					}
					case 7:
						if (!((Operators.CompareString(TEXT_PR.Text, "", false) != 0) & (Operators.CompareString(TEXT_PR.Text, mSG_PR[mSG_PR.Row - 1, 7], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "SELECT ITM_COLOR  From BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND ITM_COLOR = '" + TEXT_PR.Text + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0 && unchecked((int)Interaction.MsgBox((object)"Add New Color ? ", (MsgBoxStyle)292, (object)"Message")) != 6)
						{
							DC_Main.RsQry = "SELECT DISTINCT ITM_COLOR as ColorL From BAR_DETL ORDER BY ITM_COLOR";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[2];
							DC_Main.ColWidth[0] = 350.0;
							DC_Main.HelpSelect = 1;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_PR.Text = DC_Main.ColValue[0];
							}
						}
						break;
					case 12:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 69], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
						((Control)TEXT_PR).Visible = false;
						MSG_PR_IDTL.Row = MSG_PR_IDTL.Rows - 1;
						MSG_PR_IDTL.Col = 1;
						MSG_PR_IDTL_EnterCell(MSG_PR_IDTL, new EventArgs());
						((Control)TEXT_PR_IDTL).Focus();
						((TextBoxBase)TEXT_PR_IDTL).SelectAll();
						return;
					case 39:
						if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) != 0)
						{
							if (mSG_PR.Row == mSG_PR.Rows - 1)
							{
								mSG_PR[mSG_PR.Row, 39] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
								CommPassTotal_Pr(mSG_PR.Row);
								MsgClear = true;
								mSG_PR.Rows += 1;
								mSG_PR.Row += 1;
								MsgClear = false;
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
						break;
					case 56:
					case 63:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							if (mSG_PR.Col == 56)
							{
								mSG_PR[mSG_PR.Row, 56] = TEXT_PR.Text;
							}
							else
							{
								mSG_PR[mSG_PR.Row, 63] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
							}
							CommPassTotal_Pr(mSG_PR.Row);
							MsgClear = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							MsgClear = false;
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
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13))
		{
			if (Operators.CompareString(MSG_PR[MSG_PR.Row, 1], "", false) != 0)
			{
				if (StkRow != MSG_PR.Row)
				{
					StkRow = MSG_PR.Row;
					DC_Main.RsQry = "Select IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS NetWt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '" + MSG_PR[MSG_PR.Row, 1] + "'  and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' GROUP BY IT_CODE";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						nitGwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["GrWt"]), "0.000");
						nItNwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["NetWt"]), "0.000");
					}
					else
					{
						nitGwt.Text = Conversions.ToString(0);
						nItNwt.Text = Conversions.ToString(0);
					}
				}
			}
			else
			{
				nitGwt.Text = Conversions.ToString(0);
				nItNwt.Text = Conversions.ToString(0);
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
			case 67:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				((TextBoxBase)TEXT_PR).ReadOnly = true;
				break;
			case 56:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 6:
			case 7:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 55:
			case 58:
			case 60:
			case 62:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 57:
			case 59:
			case 61:
			case 63:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 42:
				((TextBoxBase)TEXT_PR).MaxLength = 4;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 5:
			case 8:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 28:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 44:
			case 48:
			case 49:
			case 50:
			case 54:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				if (Operators.CompareString(mSG_PR[mSG_PR.Row, 42], "", false) != 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 10:
				((TextBoxBase)TEXT_PR).MaxLength = 8;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				break;
			case 16:
			case 18:
			case 19:
			case 20:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 29:
			case 30:
			case 31:
			case 32:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 46:
			case 47:
			case 52:
			case 53:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 9:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 17:
			case 22:
			case 33:
			case 76:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 34:
			case 43:
			case 51:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 21:
			case 40:
			case 41:
			case 45:
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
		if (MsgClear || MSG_PR.Row == 0 || MSG_PR[MSG_PR.Col] == 0 || !((Control)TEXT_PR).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		switch (MSG_PR.Col)
		{
		case 3:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			break;
		case 1:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0 && ((Operators.CompareString(mSG_PR[mSG_PR.Row, 3], "", false) == 0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0)))
			{
				NewTagNo(mSG_PR.Row);
			}
			break;
		case 0:
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 28:
		case 42:
		case 56:
		case 67:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			break;
		case 55:
		case 58:
		case 60:
		case 62:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			break;
		case 57:
		case 59:
		case 61:
		case 63:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			break;
		case 10:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 34:
		case 43:
		case 44:
		case 48:
		case 49:
		case 50:
		case 51:
		case 54:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 16:
		case 18:
		case 19:
		case 20:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 29:
		case 30:
		case 31:
		case 32:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 46:
		case 47:
		case 52:
		case 53:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 9:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 17:
		case 21:
		case 22:
		case 33:
		case 40:
		case 41:
		case 45:
		case 76:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		}
		mSG_PR = null;
	}

	private void NewTagNo(int Y)
	{
		if (Operators.CompareString(MSG_PR[Y, 82], "", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0)
		{
			DC_Main.NewYearTagGen(MSG_PR[Y, 82], MSG_PR[Y, 81]);
			MSG_PR[Y, 3] = DC_Main.MsNewTagNo;
			return;
		}
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			RepitTagNo(Y);
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		if ((Operators.CompareString(DC_Main.MCo_Type, "", false) != 0) & (Operators.CompareString(DC_Main.MCo_Type, "P", false) != 0))
		{
			DC_Main.RsQry = "SELECT SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG_PR[Y, 82] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG_PR[Y, 81] + "' GROUP BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) ORDER BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) DESC";
		}
		else
		{
			DC_Main.RsQry = "SELECT TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG_PR[Y, 82] + "'  AND TAG_TYPE = '" + mSG_PR[Y, 81] + "' GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
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
				if (Operators.CompareString(mSG_PR[Y, 3], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 82], mSG_PR[Y, 82], false) == 0) & (Operators.CompareString(mSG_PR[DC_Main.i, 81], mSG_PR[Y, 81], false) == 0) & (Conversion.Val(mSG_PR[DC_Main.i, 83]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 83]) + 1.0)) > Conversion.Val(CurTagNo))
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 83]) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 83]) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
			mSG_PR[mSG_PR.Row, 83] = CurTagNo;
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG_PR[mSG_PR.Row, 3] = mSG_PR[Y, 82] + mSG_PR[Y, 81] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
			}
			else
			{
				mSG_PR[mSG_PR.Row, 3] = mSG_PR[Y, 82] + mSG_PR[Y, 81] + CurTagNo;
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
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,4) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG_PR[Y, 82] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG_PR[Y, 81] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "0001";
					int num = 1;
					int num2 = 0;
					double num3 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO ,'',0 FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 81] + "' AND  PR_CODE = '" + MSG_PR[Y, 82] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
					DC_Main.RsQry = "Select A.TAG_NO From MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.TAG_TYPE = '" + MSG_PR[Y, 81] + "' AND  B.PR_CODE = '" + MSG_PR[Y, 82] + "' AND B.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7   GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 68] + "' AND  PR_CODE = '" + MSG_PR[Y, 82] + "' GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,5) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG_PR[Y, 82] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG_PR[Y, 81] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "00001";
					int num = 1;
					int num2 = 0;
					double num3 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO ,'',0 FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 81] + "' AND  PR_CODE = '" + MSG_PR[Y, 82] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
					DC_Main.RsQry = "Select A.TAG_NO From MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.TAG_TYPE = '" + MSG_PR[Y, 81] + "' AND  B.PR_CODE = '" + MSG_PR[Y, 82] + "' AND B.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8   GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 68] + "' AND  PR_CODE = '" + MSG_PR[Y, 82] + "' GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
			MSG_PR[Y, 83] = Conversions.ToString(Conversion.Val(CurRptTagNo));
			MSG_PR[Y, 3] = MSG_PR[Y, 82] + MSG_PR[Y, 81] + CurRptTagNo;
			TEXT_PR.Text = MSG_PR[Y, 3];
			dataTable.Clear();
			dataTable.Columns.Clear();
			dataTable2.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
		int digits = 0;
		int num = 0;
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM035NPDM", false) == 0) | (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0))
		{
			digits = 2;
			num = 2;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != Conversion.Val(mSG_PR[mSG_PR.Row, 70]))
		{
			mSG_PR[mSG_PR.Row, 70] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 12]), "0.000");
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]))), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]))), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]))), "0.000");
		}
		else if (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]))), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 40]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 41] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
		}
		else
		{
			mSG_PR[mSG_PR.Row, 41] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - Conversion.Val(mSG_PR[mSG_PR.Row, 40])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != Conversion.Val(mSG_PR[mSG_PR.Row, 71]))
		{
			mSG_PR[mSG_PR.Row, 71] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
			}
			mSG_PR[mSG_PR.Row, 74] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * Conversion.Val(mSG_PR[mSG_PR.Row, 16]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != Conversion.Val(mSG_PR[mSG_PR.Row, 72]))
		{
			mSG_PR[mSG_PR.Row, 72] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 18]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20])) / 100.0), "0.000");
			}
			mSG_PR[mSG_PR.Row, 74] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != Conversion.Val(mSG_PR[mSG_PR.Row, 73]))
		{
			mSG_PR[mSG_PR.Row, 73] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 19]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20])) / 100.0), "0.000");
			}
			mSG_PR[mSG_PR.Row, 74] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 20]) != Conversion.Val(mSG_PR[mSG_PR.Row, 75]))
		{
			mSG_PR[mSG_PR.Row, 75] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 20]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 32]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0))
		{
			string text = mSG_PR[mSG_PR.Row, 69];
			if (Operators.CompareString(text, "1", false) != 0)
			{
				if (Operators.CompareString(text, "K", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) * 1000.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 3), "0.000");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 3), "0.000");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) * 10.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 32]), 3), "0.000");
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 23]) / Conversion.Val(mSG_PR[mSG_PR.Row, 24]) * 100.0, 2), "0.000");
		}
		else if (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != 0.0)
		{
			mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 23]), "0.00");
		}
		double num2 = 0.0;
		num2 = ((Operators.CompareString(DC_Main.MsPrAmtType, "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 12]) : ((Operators.CompareString(DC_Main.MsPrAmtType, "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 21]) : (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]))));
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != Conversion.Val(mSG_PR[mSG_PR.Row, 74])) & (num2 + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 74] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 25]), "0.00");
			switch (mSG_PR[mSG_PR.Row, 69])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 25]), digits), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(num2 * (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / 10.0), digits), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(num2 * (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / 1000.0), digits), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(num2 * Conversion.Val(mSG_PR[mSG_PR.Row, 25]), digits), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 79] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 26]), "0.00");
		}
		if (mSG_PR.Col == 26 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 25]) == 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0)))
		{
			switch (mSG_PR[mSG_PR.Row, 69])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsPrRateRof), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num2 * 10.0, DC_Main.MsPrRateRof), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num2 * 1000.0, DC_Main.MsPrRateRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num2, DC_Main.MsPrRateRof), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 74] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 25]), "0.00");
		}
		if (Operators.CompareString(DC_Main.MsOldPurcTchGen, "Y", false) == 0 && ((Operators.CompareString(DC_Main.MCo_Book, "037", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "038", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "043", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "044", false) == 0)) && mSG_PR.Col == 26 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != 0.0)))
		{
			mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(TEXT_PR.Text) * Conversion.Val(mSG_PR[mSG_PR.Row, 21]) / Conversion.Val(mSG_PR[mSG_PR.Row, 79]))), "0.000");
			mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 21]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.00");
			mSG_PR[mSG_PR.Row, 79] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			mSG_PR[mSG_PR.Row, 72] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 18]), "0.00");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 29]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 77]) != Conversion.Val(mSG_PR[mSG_PR.Row, 29])))
		{
			switch (mSG_PR[mSG_PR.Row, 28])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 77] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
		}
		else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 30]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
		{
			switch (mSG_PR[mSG_PR.Row, 28])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 15]), DC_Main.MsLbrRof), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), DC_Main.MsLbrRof), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * 1000.0, DC_Main.MsLbrRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), DC_Main.MsLbrRof), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 77] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
		}
		if (mSG_PR.Col == 36)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 30]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)(Conversion.Val(TEXT_PR.Text) - Conversion.Val(mSG_PR[mSG_PR.Row, 31]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 30]) < 0.0)
				{
					mSG_PR[mSG_PR.Row, 30] = "";
				}
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 30]) != Conversion.Val(mSG_PR[mSG_PR.Row, 78]) && ((Conversion.Val(mSG_PR[mSG_PR.Row, 30]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) != 0.0)))
				{
					switch (mSG_PR[mSG_PR.Row, 28])
					{
					case "P":
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
						break;
					case "N":
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 15]), DC_Main.MsLbrRof), "0.00");
						}
						else
						{
							mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), DC_Main.MsLbrRof), "0.00");
						}
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * 1000.0, DC_Main.MsLbrRof), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), DC_Main.MsLbrRof), "0.00");
						break;
					}
					double num3 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00"));
					mSG_PR[mSG_PR.Row, 77] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
					mSG_PR[mSG_PR.Row, 78] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 30]), "0.00");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) - Conversion.Val(mSG_PR[mSG_PR.Row, 31])), "0.00");
				if ((Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
				{
					switch (mSG_PR[mSG_PR.Row, 69])
					{
					case "P":
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsPrRateRof), "0.00");
						break;
					case "1":
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / num2 * 10.0, DC_Main.MsPrRateRof), "0.00");
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / num2 * 1000.0, DC_Main.MsPrRateRof), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / num2, DC_Main.MsPrRateRof), "0.00");
						break;
					}
					mSG_PR[mSG_PR.Row, 74] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 25]), "0.00");
				}
			}
		}
		mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) + Conversion.Val(mSG_PR[mSG_PR.Row, 31]) + Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.00");
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
		}
		if (mSG_PR.Col == 37)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) + 100.0) * 100.0, digits), "0.00");
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26]) - Conversion.Val(mSG_PR[mSG_PR.Row, 31]), 0), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 30]) != 0.0)
				{
					if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 28], "P", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10])), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 28], "N", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
					{
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 15])), "0.00");
						}
						else
						{
							mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]))), "0.00");
						}
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 28], "K", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * 1000.0), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 28], "G", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12])), "0.00");
					}
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
			}
		}
		if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 49]) == 0.0)
				{
					mSG_PR[mSG_PR.Row, 46] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 25]), "0.00");
				}
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 49]) == 0.0)
				{
					mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
				}
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 50]) == 0.0)
				{
					mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 30]), "0.00");
				}
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 51]) == 0.0)
				{
					mSG_PR[mSG_PR.Row, 51] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 31]), "0.00");
				}
			}
			else if (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 30] = "";
				mSG_PR[mSG_PR.Row, 26] = "";
				mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 34]), "0.00");
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 34]), "0.00");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 43]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 43] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 18]), "0.00");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 44]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 19]), "0.00");
			}
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 43]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 41]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 45] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 41]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 43]) + Conversion.Val(mSG_PR[mSG_PR.Row, 44])) / 100.0), "0.000");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 45]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 45] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.000");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 45]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 45] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.000");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 49]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 50]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 30]), "0.00");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 49]) != 0.0)
			{
				switch (mSG_PR[mSG_PR.Row, 28])
				{
				case "P":
					mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 49]), 0), "0.00");
					break;
				case "N":
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 41]) * Conversion.Val(mSG_PR[mSG_PR.Row, 49]), 0), "0.00");
					}
					else
					{
						mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 41]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * Conversion.Val(mSG_PR[mSG_PR.Row, 49]), 0), "0.00");
					}
					break;
				case "K":
					mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 41]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 49]) / 1000.0), 0), "0.00");
					break;
				default:
					mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * Conversion.Val(mSG_PR[mSG_PR.Row, 49]), 0), "0.00");
					break;
				}
			}
			else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 50]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
			{
				switch (mSG_PR[mSG_PR.Row, 28])
				{
				case "P":
					mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
					break;
				case "N":
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) / Conversion.Val(mSG_PR[mSG_PR.Row, 41]), DC_Main.MsLbrRof), "0.00");
					}
					else
					{
						mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 41]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), DC_Main.MsLbrRof), "0.00");
					}
					break;
				case "K":
					mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) / Conversion.Val(mSG_PR[mSG_PR.Row, 41]) * 1000.0, DC_Main.MsLbrRof), "0.00");
					break;
				default:
					mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), DC_Main.MsLbrRof), "0.00");
					break;
				}
			}
			double num4 = 0.0;
			num4 = ((Operators.CompareString(DC_Main.MsPrAmtType, "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 12]) : ((Operators.CompareString(DC_Main.MsPrAmtType, "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 21]) : Conversion.Val(mSG_PR[mSG_PR.Row, 41])));
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 46]) != 0.0) & (num2 + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 41]) != 0.0))
			{
				switch (mSG_PR[mSG_PR.Row, 69])
				{
				case "P":
					mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 46]), 0), "0.00");
					break;
				case "1":
					mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(num4 * (Conversion.Val(mSG_PR[mSG_PR.Row, 46]) / 10.0), 0), "0.00");
					break;
				case "K":
					mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(num4 * (Conversion.Val(mSG_PR[mSG_PR.Row, 46]) / 1000.0), 0), "0.00");
					break;
				default:
					mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(num4 * Conversion.Val(mSG_PR[mSG_PR.Row, 46]), 0), "0.00");
					break;
				}
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 50]) + Conversion.Val(mSG_PR[mSG_PR.Row, 51]) + Conversion.Val(mSG_PR[mSG_PR.Row, 47]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 52] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) + Conversion.Val(mSG_PR[mSG_PR.Row, 31]) + Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 52] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) + Conversion.Val(mSG_PR[mSG_PR.Row, 51]) + Conversion.Val(mSG_PR[mSG_PR.Row, 47])), "0.000");
			}
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 53]) != Conversion.Val(mSG_PR[mSG_PR.Row, 89])) & (Conversion.Val(mSG_PR[mSG_PR.Row, 52]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 89] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 53]), "0.00");
				mSG_PR[mSG_PR.Row, 54] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 52]) * (1.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 53]) / 100.0)), "0.00");
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
		PurcAcFine = 0.0;
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
			mSG_PR_TOT[0, 5] = "Total :";
			int num2 = MSG_PR.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_PR_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR[DC_Main.M, 10]))), "0");
				mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0.000");
				mSG_PR_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR[DC_Main.M, 12]))), "0.000");
				mSG_PR_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 13]) + Conversion.Val(MSG_PR[DC_Main.M, 13]))), "0.000");
				mSG_PR_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 14]) + Conversion.Val(MSG_PR[DC_Main.M, 14]))), "0.000");
				mSG_PR_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR[DC_Main.M, 15]))), "0.000");
				mSG_PR_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 17]) + Conversion.Val(MSG_PR[DC_Main.M, 17]))), "0.000");
				mSG_PR_TOT[0, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 21]) + Conversion.Val(MSG_PR[DC_Main.M, 21]))), "0.000");
				mSG_PR_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 26]) + Conversion.Val(MSG_PR[DC_Main.M, 26]))), "0.00");
				mSG_PR_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 30]) + Conversion.Val(MSG_PR[DC_Main.M, 30]))), "0.00");
				mSG_PR_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR[DC_Main.M, 31]))), "0.00");
				mSG_PR_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 35]) + Conversion.Val(MSG_PR[DC_Main.M, 35]))), "0.000");
				mSG_PR_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 36]) + Conversion.Val(MSG_PR[DC_Main.M, 36]))), "0.00");
				mSG_PR_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 38]) + Conversion.Val(MSG_PR[DC_Main.M, 38]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 32]) != 0.0)
				{
					PrOthAmtLess += Conversion.Val(MSG_PR[DC_Main.M, 31]);
				}
				mSG_PR_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 33]) + Conversion.Val(MSG_PR[DC_Main.M, 33]))), "0.000");
				mSG_PR_TOT[0, 39] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 39]) + Conversion.Val(MSG_PR[DC_Main.M, 39]))), "0.000");
				if (Conversion.Val(MSG_PR[DC_Main.M, 26]) == 0.0)
				{
					PurcAcFine += Conversion.Val(MSG_PR[DC_Main.M, 21]);
				}
				DC_Main.M++;
			}
			lblOldFine.Text = "Old Fine : " + Strings.Format((object)Conversion.Val(mSG_PR_TOT[0, 21]), "0.000");
			mSG_PR_TOT = null;
		}
	}

	private void TR_PURC_HM_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_11fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1209: Expected O, but got Unknown
		//IL_122e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1233: Unknown result type (might be due to invalid IL or missing references)
		//IL_123d: Expected O, but got Unknown
		//IL_1262: Unknown result type (might be due to invalid IL or missing references)
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Expected O, but got Unknown
		//IL_1296: Unknown result type (might be due to invalid IL or missing references)
		//IL_129b: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a5: Expected O, but got Unknown
		//IL_12e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f3: Expected O, but got Unknown
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1312: Unknown result type (might be due to invalid IL or missing references)
		//IL_131c: Expected O, but got Unknown
		//IL_1336: Unknown result type (might be due to invalid IL or missing references)
		//IL_133b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1345: Expected O, but got Unknown
		//IL_135f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1364: Unknown result type (might be due to invalid IL or missing references)
		//IL_136e: Expected O, but got Unknown
		//IL_1396: Unknown result type (might be due to invalid IL or missing references)
		//IL_139d: Expected O, but got Unknown
		//IL_1473: Unknown result type (might be due to invalid IL or missing references)
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_1482: Expected O, but got Unknown
		//IL_150a: Unknown result type (might be due to invalid IL or missing references)
		//IL_150f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1519: Expected O, but got Unknown
		//IL_15b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Expected O, but got Unknown
		//IL_164a: Unknown result type (might be due to invalid IL or missing references)
		//IL_164f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1655: Expected O, but got Unknown
		//IL_16dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ec: Expected O, but got Unknown
		//IL_1711: Unknown result type (might be due to invalid IL or missing references)
		//IL_1716: Unknown result type (might be due to invalid IL or missing references)
		//IL_1720: Expected O, but got Unknown
		//IL_174d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1757: Expected O, but got Unknown
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
			foreach (object control4 in ((Control)PnlPrIdtl).Controls)
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
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((Control)PnlPrIdtl).BackColor = Color.Silver;
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
				CheckBox obj9 = chkRateUnFix;
				object? obj10 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj9).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj11 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj12 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj13 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj14 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj15 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj16 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
				object? obj17 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL2 = MSG_PR_IDTL;
				object? obj18 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR_IDTL2.BackColorBkg = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL3 = MSG_PR_IDTL;
				object? obj19 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR_IDTL3.BackColorFixed = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj20 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj21 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj22 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj23 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				Panel pnlPrIdtl = PnlPrIdtl;
				object? obj24 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)pnlPrIdtl).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				((ButtonBase)chkRateUnFix).BackColor = Color.LightSlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj26 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj27 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj29 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj31 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL4 = MSG_PR_IDTL;
				object? obj32 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL5 = MSG_PR_IDTL;
				object? obj33 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR_IDTL5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL6 = MSG_PR_IDTL;
				object? obj34 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR_IDTL6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj35 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj36 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj37 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj37 != null) ? ((Color)obj37) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj38 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				Panel pnlPrIdtl2 = PnlPrIdtl;
				object? obj39 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)pnlPrIdtl2).BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				((ButtonBase)chkRateUnFix).BackColor = Color.Cornsilk;
				Label obj40 = lblBook;
				object? obj41 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj40).ForeColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj42 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj43 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj44 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj45 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj46 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj47 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj48 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL7 = MSG_PR_IDTL;
				object? obj49 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL7.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL8 = MSG_PR_IDTL;
				object? obj50 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR_IDTL8.BackColorBkg = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL9 = MSG_PR_IDTL;
				object? obj51 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR_IDTL9.BackColorFixed = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj52 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj53 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj54 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj55 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_PR_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_PR).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_PR_IDTL).Font = new Font(((Control)TEXT_PR_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_PR_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG_PR.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG_PR.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG_PR.Font.Style);
				MSG_PR_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_PR_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue4, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkBillImage", false))
						{
							NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				Font font3 = ((Control)tAdd1).Font;
				try
				{
					foreach (object control7 in ((Control)PanelAdd).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
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
				((Control)chkBillImage).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
				if (DC_Main.ScreenHight > 1.0)
				{
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
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				TblData = "PR_DATA";
				TblDetl = "PR_DETL";
				TblIdtl = "PR_IDTL";
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					((Control)chkBillImage).Visible = true;
				}
				((Control)Label14).Visible = true;
				((Control)nPartyFine).Visible = true;
				((Control)Label5).Visible = false;
				((Control)tSlBill).Visible = false;
				((Control)tSlBill_DbCd).Visible = false;
			}
			else
			{
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					((Control)chkRateUnFix).Visible = true;
					((Control)chkHalfPrint).Visible = true;
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					((Control)chkBillImage).Visible = true;
				}
				TblData = "PR_DATA";
				TblDetl = "PR_DETL";
				TblIdtl = "PR_IDTL";
			}
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
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
			DC_Main.RsQry = "SELECT A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.OLD_SRNO,A.TAG_NO,A.IT_CODE,B.PR_CODE,B.IT_TYPE,B.TAG_TYPE,A.VCH_SRNO FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.VCH_SRNO = 0 OR A.PR_CODE = '' OR A.IT_TYPE = ''";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Tbl.Rows.Count)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"], (object)""), (object)0, false))
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET VCH_SRNO = " + Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), 6, 4)), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]), (object)",PR_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["PR_CODE"]), (object)"',IT_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_TYPE"]), (object)"',TAG_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_TYPE"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"' AND VCH_SRNO = 0")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_IDTL SET VCH_SRNO = " + Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), 6, 4)), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_SRNO = 0")));
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET TAG_SRNO = RIGHT(TAG_NO,4) WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET TAG_SRNO = RIGHT(TAG_NO,5) WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
					}
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BAR_DETL SET PR_CODE = '", DC_Main.Tbl.Rows[DC_Main.M]["PR_CODE"]), (object)"',IT_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_TYPE"]), (object)"',TAG_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_TYPE"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"' ")));
				}
				DC_Main.M++;
			}
			DC_Main.Tbl.Rows.Clear();
			DC_Main.Tbl.Columns.Clear();
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
		DataTrfr = "N";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		((Control)PanelAdd).Visible = false;
		UsUPdate = "N";
		UsDelete = "N";
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
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		OldValTot = 0.0;
		NewValTot = 0.0;
		PrOthAmtLess = 0.0;
		OldNetAmt = 0.0;
		StkRow = 0;
		chkRateUnFix.Checked = false;
		chkHalfPrint.Checked = false;
		if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
		{
			tAcCode.Text = "00045";
		}
		else if (Operators.CompareString(FormMainBook, "PURCHASE", false) == 0)
		{
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ004NPKJ", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0))
			{
				tAcCode.Text = "00050";
				tAcName.Text = "CASH PURCHASE A/C";
			}
			string mCo_Book = DC_Main.MCo_Book;
			if (Operators.CompareString(mCo_Book, "037", false) == 0 || Operators.CompareString(mCo_Book, "038", false) == 0)
			{
				tAcCode.Text = "00050";
				tAcName.Text = "CASH PURCHASE A/C";
			}
		}
		AcGstType = "L";
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		PicBill.Image = null;
		chkBillImage.Checked = false;
		((Control)pnlBill).Visible = false;
		DC_Main.MsBillImgPath = "";
		DC_Main.MsImagePath = "";
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		MSG_PR_CLEAR();
		MSG_PR_IDTL_CLEAR();
		MSG2_CLEAR();
		OldTagItm = "";
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + DC_Main.MsTaxCode + "'";
				DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsTax.Rows.Count > 0)
				{
					TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL[6, 2] = Strings.Format((object)num, "0.00");
					MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
		}
		else if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '11'";
				DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsTax.Rows.Count > 0)
				{
					TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL2[2, 2] = Strings.Format((object)num2, "0.00");
					MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
			else if ((Operators.CompareString(FormBook, "043", false) != 0) & (Operators.CompareString(FormBook, "044", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '10'";
				DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsTax.Rows.Count > 0)
				{
					TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL3[2, 2] = Strings.Format((object)num3, "0.00");
					MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
		{
		}
		DtIdtlPr.Clear();
		DtIdtlPr.Reset();
		FilRowPr = 0;
		checked
		{
			int num4 = MSG_PR_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num4)
			{
				DtIdtlPr.Columns.Add(MSG_PR_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				nPartyFine.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["PARTY_FINE"], (object)"")), "0.000");
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00"));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TDS_CODE"], (object)""));
				MSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_PRC"]), "0.000");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]), "0.00");
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_AMT"]), "0.00");
				MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HM_TAX_CODE"], (object)""));
				MSG2_TOTAL[6, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_TAX_PRC"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_TAX_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
				if (Conversion.Val(MSG2_TOTAL[4, 3]) != 0.0)
				{
					MSG2_TOTAL[8, 3] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]))), "0.00");
				}
				else
				{
					MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				}
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[10, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[11, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[12, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[13, 3] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[9, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[9, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[9, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[9, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[10, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[10, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[10, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[6, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
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
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				WappMobile = tMobile.Text;
				WappAcName = tAcName.Text;
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
				DataTrfr = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DATA_TRFR"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					DataTrfr = "Y";
				}
				if (Operators.CompareString(UsUPdate, "Y", false) == 0)
				{
					((BaseStyleControl)BtnSave).ForeColor = Color.Green;
				}
				if (Operators.CompareString(UsDelete, "Y", false) == 0)
				{
					((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
				}
				tSlBill.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_NO"], (object)""));
				tSlBill_DbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_DBCD"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RATE_UNFIX"], (object)""), (object)"Y", false))
				{
					chkRateUnFix.Checked = true;
				}
				else
				{
					chkRateUnFix.Checked = false;
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
				MSG_PR_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM " + TblDetl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""), (object)"", false))
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 10] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LOSS_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_SRNO"])), "0");
					if (Operators.CompareString(TblDetl, "PR_DETL", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
						mSG_PR[DC_Main.i + 1, 84] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
						mSG_PR[DC_Main.i + 1, 82] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG_PR[DC_Main.i + 1, 85] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG_PR[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_PCS"])), "0");
					mSG_PR[DC_Main.i + 1, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 93] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_FINE"])), "0.000");
					if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
						mSG_PR[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_OTH_WT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_NWT"])), "0.000");
						if (Conversion.Val(mSG_PR[DC_Main.i + 1, 41]) == 0.0)
						{
							mSG_PR[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						}
						mSG_PR[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_FINE"])), "0.00");
						mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_LBR_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_LBR_RATE"])), "0.00");
						mSG_PR[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_LBR_AMT"])), "0.00");
						mSG_PR[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_OTH_AMT"])), "0.00");
						mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
						mSG_PR[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_MRP"])), "0.00");
						mSG_PR[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
						mSG_PR[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["VCH_SRNO"])), "0");
						mSG_PR[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_IT_RATE"])), "0.00");
						mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_IT_AMT"])), "0.00");
						mSG_PR[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_TOT_COST"])), "0.00");
						mSG_PR[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_MARGIN_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 89] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_MARGIN_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["APR_ISU"], (object)""));
						mSG_PR[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
						mSG_PR[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
						mSG_PR[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
						mSG_PR[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
						mSG_PR[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
						mSG_PR[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
						mSG_PR[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 86] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
						mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
						mSG_PR[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_SRNO"])), "0");
					}
					double num3 = Conversion.Val(mSG_PR[DC_Main.i + 1, 9]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 10]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 12]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 21]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 41]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 45]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 27]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 30]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 31]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 34]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 35]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 57]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 59]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 61]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 63]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 80]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 40]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 41]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 43]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 44]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 51]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 45]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 48]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 49]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 50]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 54]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 46]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 47]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 52]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 53]);
					string text = "";
					text = mSG_PR[DC_Main.i + 1, 1] + mSG_PR[DC_Main.i + 1, 4] + mSG_PR[DC_Main.i + 1, 5] + mSG_PR[DC_Main.i + 1, 8] + mSG_PR[DC_Main.i + 1, 3];
					text = text + mSG_PR[DC_Main.i + 1, 55] + mSG_PR[DC_Main.i + 1, 58] + mSG_PR[DC_Main.i + 1, 62] + mSG_PR[DC_Main.i + 1, 62] + mSG_PR[DC_Main.i + 1, 86] + mSG_PR[DC_Main.i + 1, 56];
					mSG_PR[DC_Main.i + 1, 87] = Strings.Format((object)num3, "0.000");
					mSG_PR[DC_Main.i + 1, 88] = text;
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				MSG_PR_IDTL_CLEAR();
				DtIdtlPr.Clear();
				DtIdtlPr.Reset();
				FilRowPr = 0;
				int num4 = MSG_PR_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num4)
				{
					DtIdtlPr.Columns.Add(MSG_PR_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM " + TblIdtl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				int num5 = 0;
				int num6 = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[19] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					if (Operators.ConditionalCompareObjectNotEqual((object)num5, RsIdtl.Rows[DC_Main.i]["SR_NO"], false))
					{
						num5 = Conversions.ToInteger(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
						num6 = 1;
						drPr[0] = num6;
					}
					else
					{
						num6++;
						drPr[0] = num6;
					}
					drPr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					drPr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					drPr[3] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					drPr[4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
					drPr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					drPr[6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.000");
					drPr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					drPr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					drPr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					drPr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
					drPr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
					drPr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					drPr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					drPr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					drPr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					drPr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					drPr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					drPr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"])), "0.000");
					drPr[18] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					double num7 = 0.0;
					num7 = Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"]));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]));
					string text2 = "";
					text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], Operators.AddObject((object)"", RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"])), Operators.AddObject((object)"", RsIdtl.Rows[DC_Main.i]["IT_TYPE"])), (object)""));
					drPr[21] = Strings.Format((object)num7, "0.000");
					drPr[22] = text2;
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				((Control)TEXT_PR_IDTL).Visible = false;
				OldValTot = Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR_TOT[0, 30]);
				NewValTot = Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR_TOT[0, 30]);
				string text3 = "DhranImage";
				string text4 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
				DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text3 + "\\" + text4 + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
				{
					PicBill.Image = Image.FromFile(DC_Main.MsBillImgPath);
				}
				OldTagItm = "";
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

	private void TR_PURC_HM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_PURC_HM_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_5645: Unknown result type (might be due to invalid IL or missing references)
		//IL_564b: Invalid comparison between Unknown and I4
		//IL_56f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_56fd: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
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
		if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0 && ((Conversion.Val(nPartyFine.Text) == 0.0) & (Conversion.Val(MSG_PR_TOT[0, 26]) == 0.0)))
		{
			Interaction.MsgBox((object)"Please Insert Party fine Value or item Amount Valeu and try....", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if ((Conversion.Val(MSG_PR_TOT[0, 35]) != 0.0) | (Conversion.Val(MSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 38]) != 0.0))
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
			DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
			dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				dataRow2["PARTY_FINE"] = Conversion.Val(nPartyFine.Text);
			}
			else
			{
				dataRow2["PARTY_FINE"] = PurcAcFine + Conversion.Val(MSG_PR_TOT[0, 33]);
			}
			dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
			dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
			dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
			dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 4];
			dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
			dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			dataRow2["TCS_CODE"] = MSG2_TOTAL[3, 4];
			dataRow2["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
			dataRow2["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["TDS_CODE"] = MSG2_TOTAL[4, 4];
			dataRow2["TDS_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
			dataRow2["TDS_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["HM_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["HM_TAX_CODE"] = MSG2_TOTAL[6, 4];
			dataRow2["HM_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[6, 2]);
			dataRow2["HM_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
			dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
			dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]) + Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["LBR_AMT"] = Conversion.Val(MSG_PR_TOT[0, 30]);
			dataRow2["OTH_AMT"] = Conversion.Val(MSG_PR_TOT[0, 31]) - PrOthAmtLess;
			dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
			dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
			dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[11, 3]);
			dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[12, 3]);
			dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[13, 3]);
			dataRow2["CARD_AC"] = MSG2_TOTAL[10, 4];
			dataRow2["BANK_AC"] = MSG2_TOTAL[9, 4];
			dataRow2["CHQ_NO"] = MSG2_TOTAL[9, 2];
			dataRow2["BANK_NAME"] = tBankName.Text;
			dataRow2["ADD1"] = tAdd1.Text;
			dataRow2["ADD2"] = tAdd2.Text;
			dataRow2["ADD3"] = tAdd3.Text;
			dataRow2["CITY"] = tCity.Text;
			dataRow2["MOBILE"] = tMobile.Text;
			dataRow2["AC_GST_TYPE"] = AcGstType;
			if (Conversion.Val(MSG2_TOTAL[2, 3]) != 0.0)
			{
				if (Operators.CompareString(AcGstType, "I", false) == 0)
				{
					dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);
					dataRow2["SGST_TAX"] = 0;
					dataRow2["CGST_TAX"] = 0;
				}
				else
				{
					dataRow2["IGST_TAX"] = 0;
					dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
					dataRow2["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
				}
			}
			else
			{
				dataRow2["IGST_TAX"] = 0;
				dataRow2["SGST_TAX"] = 0;
				dataRow2["CGST_TAX"] = 0;
			}
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["CR_DAYS"] = Conversion.Val(nCrDays.Text);
			dataRow2["SL_BILL_NO"] = tSlBill.Text;
			dataRow2["SL_BILL_LC"] = DC_Main.MLc_code;
			dataRow2["SL_BILL_YRCD"] = DC_Main.MCo_year;
			dataRow2["SL_BILL_DBCD"] = tSlBill_DbCd.Text;
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			if (chkRateUnFix.Checked)
			{
				dataRow2["RATE_UNFIX"] = "Y";
			}
			else
			{
				dataRow2["RATE_UNFIX"] = "N";
			}
			dataRow2["DATA_TRFR"] = "N";
			if (Operators.CompareString(DataTrfr, "Y", false) == 0)
			{
				dataRow2["RE_TRFR"] = "Y";
			}
			else
			{
				dataRow2["RE_TRFR"] = "N";
			}
			dataRow2["MAIN_USER"] = MainUser;
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		checked
		{
			int num = MSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				AxMSFlexGrid mSG_PR = MSG_PR;
				double num2 = 0.0;
				num2 = Conversion.Val(mSG_PR[DC_Main.i, 9]) + Conversion.Val(mSG_PR[DC_Main.i, 10]) + Conversion.Val(mSG_PR[DC_Main.i, 12]) + Conversion.Val(mSG_PR[DC_Main.i, 21]) + Conversion.Val(mSG_PR[DC_Main.i, 41]) + Conversion.Val(mSG_PR[DC_Main.i, 45]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 27]) + Conversion.Val(mSG_PR[DC_Main.i, 30]) + Conversion.Val(mSG_PR[DC_Main.i, 31]) + Conversion.Val(mSG_PR[DC_Main.i, 34]) + Conversion.Val(mSG_PR[DC_Main.i, 35]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 57]) + Conversion.Val(mSG_PR[DC_Main.i, 59]) + Conversion.Val(mSG_PR[DC_Main.i, 61]) + Conversion.Val(mSG_PR[DC_Main.i, 63]) + Conversion.Val(mSG_PR[DC_Main.i, 80]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 40]) + Conversion.Val(mSG_PR[DC_Main.i, 41]) + Conversion.Val(mSG_PR[DC_Main.i, 43]) + Conversion.Val(mSG_PR[DC_Main.i, 44]) + Conversion.Val(mSG_PR[DC_Main.i, 51]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 45]) + Conversion.Val(mSG_PR[DC_Main.i, 48]) + Conversion.Val(mSG_PR[DC_Main.i, 49]) + Conversion.Val(mSG_PR[DC_Main.i, 50]) + Conversion.Val(mSG_PR[DC_Main.i, 54]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 46]) + Conversion.Val(mSG_PR[DC_Main.i, 47]) + Conversion.Val(mSG_PR[DC_Main.i, 52]) + Conversion.Val(mSG_PR[DC_Main.i, 53]);
				string text = "";
				text = mSG_PR[DC_Main.i, 1] + mSG_PR[DC_Main.i, 4] + mSG_PR[DC_Main.i, 5] + mSG_PR[DC_Main.i, 8] + mSG_PR[DC_Main.i, 3];
				text = text + mSG_PR[DC_Main.i, 55] + mSG_PR[DC_Main.i, 58] + mSG_PR[DC_Main.i, 62] + mSG_PR[DC_Main.i, 62] + mSG_PR[DC_Main.i, 86] + mSG_PR[DC_Main.i, 56];
				if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG_PR[DC_Main.i, 87]), "0.000"), Strings.Format((object)num2, "0.000"), false) != 0) | (Operators.CompareString(mSG_PR[DC_Main.i, 88], text, false) != 0))
				{
					DC_Main.ExeQuteDc(("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i, 0]))) ?? "");
					DC_Main.RsQry = "SELECT * FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i, 0])) + " ";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow3 = RsDetl.NewRow();
					if ((Conversion.Val(MSG_PR[DC_Main.i, 15]) + Conversion.Val(MSG_PR[DC_Main.i, 38]) + Conversion.Val(MSG_PR[DC_Main.i, 54]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
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
						dataRow3["ENTRY_TYPE"] = "P";
						dataRow3["BOOK_NAME"] = FormMainBook;
						dataRow3["SR_NO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 80]);
						dataRow3["IT_CODE"] = mSG_PR[DC_Main.i, 1];
						dataRow3["IT_DESC"] = mSG_PR[DC_Main.i, 2];
						dataRow3["TAG_NO"] = "N";
						dataRow3["TBL_CODE"] = mSG_PR[DC_Main.i, 4];
						dataRow3["DESIGN_NO"] = mSG_PR[DC_Main.i, 5];
						dataRow3["LOT_NO"] = mSG_PR[DC_Main.i, 6];
						dataRow3["ITM_COLOR"] = mSG_PR[DC_Main.i, 7];
						dataRow3["ITM_SIZE"] = mSG_PR[DC_Main.i, 8];
						dataRow3["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
						dataRow3["ITM_LOSS_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
						dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 16]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
						dataRow3["ITM_LESS_TCH"] = Conversion.Val(mSG_PR[DC_Main.i, 20]);
						dataRow3["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
						dataRow3["SILVER_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 22]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
						dataRow3["LBR_TYPE"] = mSG_PR[DC_Main.i, 28];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
						dataRow3["ITM_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
						dataRow3["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 33]);
						dataRow3["CONV_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 23]);
						dataRow3["CONV_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 24]);
						dataRow3["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 25]);
						dataRow3["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 35]);
						dataRow3["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 36]);
						dataRow3["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 37]);
						dataRow3["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 38]);
						dataRow3["HM_ID_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 39]);
						dataRow3["RATE_TYPE"] = mSG_PR[DC_Main.i, 69];
						dataRow3["IT_TYPE"] = mSG_PR[DC_Main.i, 68];
						dataRow3["DESIGN_IMG_ID"] = mSG_PR[DC_Main.i, 86];
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow3["WITH_STOCK"] = "Y";
						dataRow3["SL_BILL_NO"] = tSlBill.Text;
						dataRow3["SL_BILL_LC"] = DC_Main.MLc_code;
						dataRow3["SL_BILL_YRCD"] = DC_Main.MCo_year;
						dataRow3["SL_BILL_DBCD"] = tSlBill_DbCd.Text;
						dataRow3["MAIN_USER"] = MainUser;
						dataRow3["URD_RATE_TYPE"] = "F";
						dataRow3["FINE_CUT_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 90]);
						dataRow3["FINE_CUT_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 91]);
						dataRow3["FINE_CUT_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 92]);
						dataRow3["FINE_CUT_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 93]);
						if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
						{
							dataRow3["WITH_STOCK"] = "N";
							dataRow3["TAG_TYPE"] = mSG_PR[DC_Main.i, 81];
							dataRow3["PR_CODE"] = mSG_PR[DC_Main.i, 82];
							dataRow3["TAG_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 83]);
							dataRow3["TAG_NO"] = mSG_PR[DC_Main.i, 3];
							dataRow3["TAG_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 40]);
							dataRow3["TAG_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 41]);
							dataRow3["TAG_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 43]);
							dataRow3["TAG_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 44]);
							dataRow3["TAG_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 45]);
							dataRow3["TAG_IT_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 46]);
							dataRow3["TAG_IT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 47]);
							dataRow3["TAG_LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 48]);
							dataRow3["TAG_LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 49]);
							dataRow3["TAG_LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 50]);
							dataRow3["TAG_OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 51]);
							dataRow3["TAG_COST"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
							dataRow3["TAG_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 54]);
							dataRow3["KR_NAME"] = mSG_PR[DC_Main.i, 56];
							if (Conversion.Val(mSG_PR[DC_Main.i, 67]) == 0.0)
							{
								mSG_PR[DC_Main.i, 67] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + "7" + DC_Main.MLc_code + Strings.Format((object)Conversion.Val(mSG_PR[DC_Main.i, 80]), "000000");
							}
							dataRow3["VCH_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 67]);
							dataRow3["LBR_CODE"] = mSG_PR[DC_Main.i, 42];
							dataRow3["APR_ISU"] = mSG_PR[DC_Main.i, 64];
							dataRow3["EMP_ISU"] = mSG_PR[DC_Main.i, 65];
							dataRow3["DATA_TYPE"] = mSG_PR[DC_Main.i, 66];
							dataRow3["HM_ID"] = mSG_PR[DC_Main.i, 55];
							dataRow3["HM_ID2"] = mSG_PR[DC_Main.i, 58];
							dataRow3["HM_ID3"] = mSG_PR[DC_Main.i, 60];
							dataRow3["HM_ID4"] = mSG_PR[DC_Main.i, 62];
							dataRow3["HM_ID_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 57]);
							dataRow3["HM_ID2_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 59]);
							dataRow3["HM_ID3_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 61]);
							dataRow3["HM_ID4_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 63]);
							dataRow3["TAG_TOT_COST"] = Conversion.Val(mSG_PR[DC_Main.i, 52]);
							dataRow3["TAG_MARGIN_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 53]);
						}
						else if (Operators.CompareString(TblDetl, "PR_DETL", false) == 0)
						{
							dataRow3["TAG_TYPE"] = mSG_PR[DC_Main.i, 81];
							dataRow3["PR_CODE"] = mSG_PR[DC_Main.i, 82];
							dataRow3["TAG_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 83]);
							dataRow3["TAG_NO"] = "";
							dataRow3["TAG_OTH_WT"] = 0;
							dataRow3["TAG_NWT"] = 0;
							dataRow3["TAG_TOUCH"] = 0;
							dataRow3["TAG_WEST_PRC"] = 0;
							dataRow3["TAG_FINE"] = 0;
							dataRow3["TAG_LBR_PRC"] = 0;
							dataRow3["TAG_LBR_RATE"] = 0;
							dataRow3["TAG_LBR_AMT"] = 0;
							dataRow3["TAG_OTH_AMT"] = 0;
							dataRow3["TAG_COST"] = 0;
							dataRow3["TAG_MRP"] = 0;
							dataRow3["KR_NAME"] = "";
							dataRow3["VCH_SRNO"] = 0;
							dataRow3["LBR_CODE"] = "";
							dataRow3["TAG_IT_RATE"] = 0;
							dataRow3["TAG_IT_AMT"] = 0;
							dataRow3["TAG_TOT_COST"] = 0;
							dataRow3["TAG_MARGIN_PRC"] = 0;
						}
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
				}
				mSG_PR = null;
				DC_Main.i++;
			}
			int num3 = 0;
			int num4 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				double num5 = 0.0;
				num5 = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][11])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][13]));
				num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][15])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][17])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][20])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0]));
				string text2 = "";
				text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DtIdtlPr.Rows[i][1], Operators.AddObject((object)"", DtIdtlPr.Rows[i][9])), Operators.AddObject((object)"", DtIdtlPr.Rows[i][18])), (object)""));
				int num6 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])));
				if (Conversions.ToBoolean(Operators.OrObject((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][21])) != num5), Operators.CompareObjectNotEqual(DtIdtlPr.Rows[i][22], (object)text2, false))))
				{
					DC_Main.ExeQuteDc(("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])))) ?? "");
					DC_Main.RsQry = ("SELECT * FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])))) ?? "";
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow4 = RsIdtl.NewRow();
					DataTable dtIdtlPr = DtIdtlPr;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][11])) != 0.0)
					{
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow4["VCH_NO"] = tVchNo.Text;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						dataRow4["VCH_TYPE"] = FormBookSname;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						dataRow4["ENTRY_TYPE"] = "P";
						dataRow4["BOOK_NAME"] = FormMainBook;
						dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19]));
						dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0]));
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][1]);
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3]));
						dataRow4["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][4]));
						dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5]));
						dataRow4["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6]));
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][7]));
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][8]));
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][9]);
						dataRow4["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][10]));
						dataRow4["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][11]));
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][12]));
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][13]));
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][14]));
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][15]));
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][16]));
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][17]));
						dataRow4["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][20]));
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][18]);
						dataRow4["MAIN_USER"] = MainUser;
						RsIdtl.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtlPr = null;
				}
			}
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsBarData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow5 = RsBarData.NewRow();
				if ((Conversion.Val(MSG_PR_TOT[0, 35]) != 0.0) | (Conversion.Val(MSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR_TOT[0, 31]) != 0.0))
				{
					dataRow5["CO_CODE"] = DC_Main.MCo_code;
					dataRow5["LC_CODE"] = DC_Main.MLc_code;
					dataRow5["CO_YEAR"] = DC_Main.MCo_year;
					dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow5["VCH_NO"] = tVchNo.Text;
					dataRow5["VCH_DATE"] = mVchDate.Text;
					dataRow5["STK_IT_CODE"] = "";
					dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow5["EMP_CODE"] = tEmpCode.Text;
					dataRow5["VCH_DESC"] = tVchDesc.Text;
					dataRow5["DATA_TRFR"] = "N";
					dataRow5["MAIN_USER"] = MainUser;
					RsBarData.Rows.Add(dataRow5);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsBarData);
					RsBarData.Clear();
				}
				int num7 = MSG_PR.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num7)
				{
					AxMSFlexGrid mSG_PR2 = MSG_PR;
					double num8 = 0.0;
					num8 = Conversion.Val(mSG_PR2[DC_Main.i, 9]) + Conversion.Val(mSG_PR2[DC_Main.i, 10]) + Conversion.Val(mSG_PR2[DC_Main.i, 12]) + Conversion.Val(mSG_PR2[DC_Main.i, 21]) + Conversion.Val(mSG_PR2[DC_Main.i, 41]) + Conversion.Val(mSG_PR2[DC_Main.i, 45]);
					num8 += Conversion.Val(mSG_PR2[DC_Main.i, 27]) + Conversion.Val(mSG_PR2[DC_Main.i, 30]) + Conversion.Val(mSG_PR2[DC_Main.i, 31]) + Conversion.Val(mSG_PR2[DC_Main.i, 34]) + Conversion.Val(mSG_PR2[DC_Main.i, 35]);
					num8 += Conversion.Val(mSG_PR2[DC_Main.i, 57]) + Conversion.Val(mSG_PR2[DC_Main.i, 59]) + Conversion.Val(mSG_PR2[DC_Main.i, 61]) + Conversion.Val(mSG_PR2[DC_Main.i, 63]) + Conversion.Val(mSG_PR2[DC_Main.i, 80]);
					num8 += Conversion.Val(mSG_PR2[DC_Main.i, 40]) + Conversion.Val(mSG_PR2[DC_Main.i, 41]) + Conversion.Val(mSG_PR2[DC_Main.i, 43]) + Conversion.Val(mSG_PR2[DC_Main.i, 44]) + Conversion.Val(mSG_PR2[DC_Main.i, 51]);
					num8 += Conversion.Val(mSG_PR2[DC_Main.i, 45]) + Conversion.Val(mSG_PR2[DC_Main.i, 48]) + Conversion.Val(mSG_PR2[DC_Main.i, 49]) + Conversion.Val(mSG_PR2[DC_Main.i, 50]) + Conversion.Val(mSG_PR2[DC_Main.i, 54]);
					num8 += Conversion.Val(mSG_PR2[DC_Main.i, 46]) + Conversion.Val(mSG_PR2[DC_Main.i, 47]) + Conversion.Val(mSG_PR2[DC_Main.i, 52]) + Conversion.Val(mSG_PR2[DC_Main.i, 53]);
					string text3 = "";
					text3 = mSG_PR2[DC_Main.i, 1] + mSG_PR2[DC_Main.i, 4] + mSG_PR2[DC_Main.i, 5] + mSG_PR2[DC_Main.i, 8] + mSG_PR2[DC_Main.i, 3];
					text3 = text3 + mSG_PR2[DC_Main.i, 55] + mSG_PR2[DC_Main.i, 58] + mSG_PR2[DC_Main.i, 62] + mSG_PR2[DC_Main.i, 62] + mSG_PR2[DC_Main.i, 86] + mSG_PR2[DC_Main.i, 56];
					if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG_PR2[DC_Main.i, 87]), "0.000"), Strings.Format((object)num8, "0.000"), false) != 0) | (Operators.CompareString(mSG_PR2[DC_Main.i, 88], text3, false) != 0))
					{
						DC_Main.ExeQuteDc(("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR2[DC_Main.i, 0]))) ?? "");
						DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR2[DC_Main.i, 0])) + " ";
						RsBarDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow6 = RsBarDetl.NewRow();
						if ((Conversion.Val(MSG_PR[DC_Main.i, 10]) + Conversion.Val(MSG_PR[DC_Main.i, 15]) + Conversion.Val(MSG_PR[DC_Main.i, 35]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 3], "", false) != 0))
						{
							dataRow6["CO_CODE"] = DC_Main.MCo_code;
							dataRow6["CO_CODE"] = DC_Main.MCo_code;
							dataRow6["LC_CODE"] = DC_Main.MLc_code;
							dataRow6["CO_YEAR"] = DC_Main.MCo_year;
							dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow6["VCH_NO"] = tVchNo.Text;
							dataRow6["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow6["VCH_DATE"] = mVchDate.Text;
							dataRow6["STK_DATE"] = mVchDate.Text;
							dataRow6["VCH_TYPE"] = FormBookSname;
							dataRow6["INOUT_TYPE"] = FormBookInOut;
							dataRow6["ENTRY_TYPE"] = "I";
							dataRow6["BOOK_NAME"] = FormMainBook;
							dataRow6["LOT_NO"] = "";
							dataRow6["SR_NO"] = Conversion.Val(mSG_PR2[DC_Main.i, 0]);
							dataRow6["OLD_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 80]);
							dataRow6["IT_CODE"] = mSG_PR2[DC_Main.i, 1];
							if (Operators.CompareString(mSG_PR2[DC_Main.i, 3], "", false) == 0)
							{
								dataRow6["TAG_NO"] = "N";
							}
							else
							{
								dataRow6["TAG_NO"] = mSG_PR2[DC_Main.i, 3];
							}
							dataRow6["TBL_CODE"] = mSG_PR2[DC_Main.i, 4];
							dataRow6["DESIGN_NO"] = mSG_PR2[DC_Main.i, 5];
							dataRow6["ITM_COLOR"] = mSG_PR2[DC_Main.i, 7];
							dataRow6["ITM_SIZE"] = mSG_PR2[DC_Main.i, 8];
							dataRow6["BAG_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 9]);
							dataRow6["ITM_PCS"] = Conversion.Val(mSG_PR2[DC_Main.i, 10]);
							dataRow6["ITM_GWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 12]);
							dataRow6["ITM_OTH_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 40]);
							if (Conversion.Val(mSG_PR2[DC_Main.i, 41]) == 0.0)
							{
								dataRow6["ITM_NWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 15]);
							}
							else
							{
								dataRow6["ITM_NWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 41]);
							}
							dataRow6["KR_OTH_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 13]);
							dataRow6["KR_NET_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 15]);
							dataRow6["KR_GHT_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 16]);
							dataRow6["KR_GHT_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 17]);
							dataRow6["KR_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 18]);
							dataRow6["KR_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 19]);
							dataRow6["KR_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 21]);
							dataRow6["ITM_GHT_PRC"] = 0;
							dataRow6["ITM_GHT_WT"] = 0;
							dataRow6["ITM_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 43]);
							dataRow6["ITM_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 44]);
							dataRow6["ITM_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 45]);
							dataRow6["LBR_CODE"] = mSG_PR2[DC_Main.i, 42];
							dataRow6["LBR_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 48]);
							dataRow6["LBR_TYPE"] = mSG_PR2[DC_Main.i, 28];
							dataRow6["LBR_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 49]);
							dataRow6["LBR_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 50]);
							dataRow6["OTH_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 51]);
							dataRow6["KR_LBR_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 29]);
							dataRow6["KR_LBR_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 30]);
							dataRow6["KR_OTH_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 31]);
							dataRow6["KR_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 34]);
							dataRow6["MAIN_MARGIN_PRC"] = 0;
							dataRow6["ITM_MARGIN"] = 0;
							dataRow6["ITM_MRP"] = Conversion.Val(mSG_PR2[DC_Main.i, 54]);
							dataRow6["ITM_REMARK"] = "";
							dataRow6["KR_NAME"] = mSG_PR2[DC_Main.i, 56];
							dataRow6["TAG_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 83]);
							dataRow6["RATE_TYPE"] = mSG_PR2[DC_Main.i, 69];
							dataRow6["IT_TYPE"] = mSG_PR2[DC_Main.i, 68];
							dataRow6["TAG_TYPE"] = mSG_PR2[DC_Main.i, 81];
							dataRow6["PR_CODE"] = mSG_PR2[DC_Main.i, 82];
							dataRow6["VCH_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 67]);
							if (Operators.CompareString(mSG_PR2[DC_Main.i, 64], "", false) == 0)
							{
								dataRow6["APR_ISU"] = "N";
							}
							else
							{
								dataRow6["APR_ISU"] = mSG_PR2[DC_Main.i, 64];
							}
							dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow6["DATA_TRFR"] = "N";
							if (Operators.CompareString(mSG_PR2[DC_Main.i, 66], "", false) == 0)
							{
								dataRow6["DATA_TYPE"] = "A";
							}
							else
							{
								dataRow6["DATA_TYPE"] = mSG_PR2[DC_Main.i, 66];
							}
							dataRow6["HM_ID"] = mSG_PR2[DC_Main.i, 55];
							dataRow6["HM_ID2"] = mSG_PR2[DC_Main.i, 58];
							dataRow6["HM_ID3"] = mSG_PR2[DC_Main.i, 60];
							dataRow6["HM_ID4"] = mSG_PR2[DC_Main.i, 62];
							dataRow6["HM_ID_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 57]);
							dataRow6["HM_ID2_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 59]);
							dataRow6["HM_ID3_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 61]);
							dataRow6["HM_ID4_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 63]);
							if (Conversion.Val(mSG_PR2[DC_Main.i, 47]) != 0.0)
							{
								dataRow6["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 46]);
								dataRow6["ITM_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 47]);
								dataRow6["TAG_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 52]);
								dataRow6["ITM_MARGIN"] = Conversion.Val(mSG_PR2[DC_Main.i, 53]);
							}
							else
							{
								dataRow6["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 25]);
								dataRow6["ITM_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 26]);
								dataRow6["TAG_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 34]);
								dataRow6["ITM_MARGIN"] = 0;
							}
							dataRow6["SF_NO"] = "";
							dataRow6["JDT_JDT_WT"] = 0;
							dataRow6["JDT_GHT_WT"] = 0;
							dataRow6["JDT_KUN_WT"] = 0;
							dataRow6["JDT_KUN_TOUCH"] = 0;
							dataRow6["JDT_KUN_NET"] = 0;
							dataRow6["JDT_WAX_WT"] = 0;
							dataRow6["KR_WAX_WT"] = 0;
							dataRow6["EMP_ISU"] = mSG_PR2[DC_Main.i, 65];
							dataRow6["MAIN_USER"] = MainUser;
							dataRow6["DATA_TRFR"] = "N";
							dataRow6["MAIN_USER"] = MainUser;
							RsBarDetl.Rows.Add(dataRow6);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsBarDetl);
							RsBarDetl.Clear();
							DC_Main.RsQry = "DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_SRNO = '" + Strings.Mid(mSG_PR2[DC_Main.i, 67], 7, 6) + "' AND TAG_NO = '" + mSG_PR2[DC_Main.i, 3] + "'";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Mid(mSG_PR2[DC_Main.i, 67], 7, 6) + "','" + mSG_PR2[DC_Main.i, 67] + "','" + mSG_PR2[DC_Main.i, 3] + "','" + mSG_PR2[DC_Main.i, 1] + "')";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
					}
					mSG_PR2 = null;
					DC_Main.i++;
				}
				int num9 = DtIdtlPr.Rows.Count - 1;
				int m = default(int);
				for (int j = 0; j <= num9; j++)
				{
					double num10 = 0.0;
					num10 = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][5])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][11])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][13]));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][15])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][17])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][20])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0]));
					string text4 = "";
					text4 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DtIdtlPr.Rows[j][1], Operators.AddObject((object)"", DtIdtlPr.Rows[j][9])), Operators.AddObject((object)"", DtIdtlPr.Rows[j][18])), (object)""));
					if (!Conversions.ToBoolean(Operators.OrObject((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][21])) != num10), Operators.CompareObjectNotEqual(DtIdtlPr.Rows[j][22], (object)text4, false))))
					{
						continue;
					}
					DC_Main.ExeQuteDc(("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][19]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0])))) ?? "");
					DC_Main.RsQry = ("SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][19]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0])))) ?? "";
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow7 = RsIdtl.NewRow();
					DataTable dtIdtlPr2 = DtIdtlPr;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][11])) != 0.0)
					{
						int num11 = MSG_PR.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num11)
						{
							if (Conversion.Val(MSG_PR[DC_Main.M, 80]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][19])))
							{
								m = DC_Main.M;
								break;
							}
							DC_Main.M++;
						}
						dataRow7["CO_CODE"] = DC_Main.MCo_code;
						dataRow7["LC_CODE"] = DC_Main.MLc_code;
						dataRow7["CO_YEAR"] = DC_Main.MCo_year;
						dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow7["VCH_NO"] = tVchNo.Text;
						dataRow7["VCH_DATE"] = mVchDate.Text;
						dataRow7["AC_CODE"] = tAcCode.Text;
						dataRow7["VCH_TYPE"] = FormBookSname;
						dataRow7["INOUT_TYPE"] = FormBookInOut;
						dataRow7["ENTRY_TYPE"] = "S";
						dataRow7["BOOK_NAME"] = FormMainBook;
						dataRow7["SR_NO"] = Conversion.Val(MSG_PR[m, 80]);
						dataRow7["TAG_NO"] = MSG_PR[m, 3];
						dataRow7["VCH_SRNO"] = Conversion.Val(MSG_PR[m, 67]);
						dataRow7["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0]));
						dataRow7["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][1]);
						dataRow7["DM_CODE"] = "";
						dataRow7["DM_NAME"] = "";
						dataRow7["DM_COLOR"] = "";
						dataRow7["DM_SIZE"] = "";
						dataRow7["DM_ORIGIN"] = "";
						dataRow7["DM_REMARK"] = "";
						dataRow7["DM_SFNO"] = "";
						dataRow7["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][3]));
						dataRow7["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][4]));
						dataRow7["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][7]));
						dataRow7["KR_ACT_WT"] = 0;
						dataRow7["KR_ACT_PRC"] = 0;
						dataRow7["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][5]));
						dataRow7["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][6]));
						dataRow7["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][8]));
						dataRow7["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][9]);
						dataRow7["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][12]));
						dataRow7["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][13]));
						dataRow7["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][10]));
						dataRow7["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][11]));
						dataRow7["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][14]));
						dataRow7["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][15]));
						dataRow7["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][16]));
						dataRow7["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][17]));
						dataRow7["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][17]));
						dataRow7["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][18]);
						dataRow7["MAIN_USER"] = MainUser;
						RsIdtl.Rows.Add(dataRow7);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtlPr2 = null;
				}
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Ledr.Purc_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Rojmel.Purc_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Tax.Purc_GST(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Purc_Stk(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Dm_Purc_Detl(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.PrKr_Lot(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
		}
		if (DC_Main.MsOldPurcSl)
		{
			if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
			{
				DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[8, 3]);
			}
			else
			{
				DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[13, 3]);
			}
			DC_Main.MsOldPurcWt = Conversion.Val(MSG_PR_TOT[0, 15]);
			((Control)BtnSave).Enabled = true;
			if ((int)Interaction.MsgBox((object)"Old Silver Purchase Print... ?", (MsgBoxStyle)260, (object)null) == 7)
			{
				((Form)this).Close();
				return;
			}
		}
		else if (DC_Main.MsOldPurc)
		{
			if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
			{
				DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[8, 3]);
			}
			else
			{
				DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[13, 3]);
			}
			DC_Main.MsOldPurcWt = Conversion.Val(MSG_PR_TOT[0, 15]);
			((Control)BtnSave).Enabled = true;
			if ((int)Interaction.MsgBox((object)"Old Gold Purchase Print... ?", (MsgBoxStyle)260, (object)null) == 7)
			{
				((Form)this).Close();
				return;
			}
		}
		if (Operators.CompareString(DC_Main.MsOsBillSms, "Y", false) == 0)
		{
			WappMsg = "Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[8, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[13, 3])) + " " + SmsDetail;
		}
		else
		{
			WappMsg = SmsDetail;
		}
		WappAcName = tAcName.Text;
		WappMobile = tMobile.Text;
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK282NAST", false) == 0)
		{
			WappMsg = "Dear Customer \r\nAttached is your receipt from \r\n\r\nAl Tariq Jewellers.\r\n\r\n Your trust means a lot to us.\r\n If you’re happy with our service,\r\n\r\nplease support us with a quick Google review:\r\n\r\n https://g.page/r/CcfEOEe5meCzEAE/review";
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(WappMsg, "", false) != 0) & (Operators.CompareString(DC_Main.MsCustSms, "Y", false) == 0))
			{
				WappReport();
				Thread.Sleep(3000);
			}
			Application.DoEvents();
		}
		if (Operators.CompareString(FormVchNo, "", false) != 0)
		{
			CLEAR_DATA();
			((Form)this).Close();
			return;
		}
		CurPrnVch = tVchNo.Text;
		if (chkHalfPrint.Checked)
		{
			PrHalfPrint = true;
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
		DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
		CustOpAmt = DC_Main.MsAcAmtOpBal;
		CustClAmt = DC_Main.MsAcAmtClBal;
		CustOpGold = DC_Main.MsAcGoldOpBal;
		CustClGold = DC_Main.MsAcGoldClBal;
		CustOpSilver = DC_Main.MsAcSilverOpBal;
		CustClSilver = DC_Main.MsAcSilverClBal;
		CLEAR_DATA();
		BtnPrint_Click(BtnPrint, new EventArgs());
		if (DC_Main.MsOldPurc | DC_Main.MsOldPurcSl)
		{
			Thread.Sleep(3000);
			Application.DoEvents();
		}
		PrHalfPrint = false;
		CurPrnVch = "";
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		DC_Main.MsAcAmtOpBal = 0.0;
		DC_Main.MsAcAmtClBal = 0.0;
		DC_Main.MsAcGoldOpBal = 0.0;
		DC_Main.MsAcGoldClBal = 0.0;
		DC_Main.MsAcSilverOpBal = 0.0;
		DC_Main.MsAcSilverClBal = 0.0;
		if (DC_Main.MsOldPurc | DC_Main.MsOldPurcSl)
		{
			((Form)this).Close();
		}
	}

	private async void WappReport()
	{
		if ((Strings.Len(WappMobile) > 5) & (Operators.CompareString(WappMsg, "", false) != 0))
		{
			try
			{
				if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) != 0)
				{
					MessageRequest val = new MessageRequest();
					val.Phone = DC_Main.MsCountryId + WappMobile;
					val.Message = WappMsg;
					val.AttachmentPath = "";
					MessageRequest request = val;
					object objectValue = RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
					MessageBox.Show(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Description", new object[0], (string[])null, (Type[])null, (bool[])null))));
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,CASH_AMT+CARD_AMT+CHQ_AMT,TOT_AMT,IT_TYPE,0,PARTY_FINE,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM " + TblData + " AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,SR_NO,A.VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,A.VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,A.NET_AMT,A.IT_TYPE,0,ITM_FINE,A.HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE FROM (PR_DATA AS C LEFT JOIN PR_DETL AS A ON C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE AND C.CO_YEAR = A.CO_YEAR AND C.CO_BOOK = A.CO_BOOK AND C.VCH_NO = A.VCH_NO)  LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			if (Operators.CompareString(FormMainBook, "TAG PURCHASE", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			}
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_PURC_HM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (((Control)TEXT_PR).Visible)
			{
				MSG_PR_LeaveCell(MSG_PR, new EventArgs());
				MSG_PR.Row = checked(MSG_PR.Rows - 1);
				MSG_PR.Col = 0;
				((Control)TEXT_PR).Visible = false;
				((Control)TEXT_PR_IDTL).Visible = false;
				MSG_PR_TOT_FILL();
				MSG2_TOTAL.Row = 1;
				MSG2_TOTAL.Col = 3;
				MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
				((Control)TEXT_ENTRY_2).Focus();
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

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			chkWapp.Checked = false;
			return;
		}
		string text = "";
		if ((Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0) | chkWapp.Checked)
		{
			DC_Main.MsCustMail = "";
			DC_Main.MsCustWappNo = "";
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM " + TblData + " AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
			}
			text = ((Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0) ? ((Operators.CompareString(FormBookType, "T", false) != 0) ? "KrRecVch" : "KrRecVchGst") : ((Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0) ? "OldItmSaleVch" : ((Operators.CompareString(FormBookType, "T", false) != 0) ? "PurcBillA4" : ((!PrHalfPrint) ? "PurcBillA4Gst" : "PurcBillHalfGst"))));
			DC_Main.MsWappPrintType = "WithFine";
			DC_Main.RptName = text;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			if (Operators.CompareString(FormBookType, "T", false) != 0)
			{
				DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.000"));
				DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.000"));
				DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
				DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			}
			DC_Main.RptFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				if (DC_Main.MsPrintDup)
				{
					DC_Main.MsPrintType = "InVoiceTipe";
					DC_Main.MaPirntCopy = "'CUSTOMER COPY'";
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
				if (DC_Main.MsPrintOg)
				{
					DC_Main.MsPrintType = "InVoiceTipe";
					DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
			}
			else
			{
				if (DC_Main.MsPrintDup)
				{
					DC_Main.MsPrintType = "InVoiceTipe";
					DC_Main.MaPirntCopy = "'CUSTOMER COPY'";
					Module_Save.ShowReportPreview();
				}
				if (DC_Main.MsPrintOg)
				{
					DC_Main.MsPrintType = "InVoiceTipe";
					DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
					Module_Save.ShowReportPreview();
				}
			}
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)0] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)1] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		if (Operators.CompareString(FormBookType, "T", false) != 0)
		{
			Cr[(short)2] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
			Cr[(short)3] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
			Cr[(short)4] = ("OpSilver = " + Strings.Format((object)CustOpSilver, "0.00")) ?? "";
			Cr[(short)5] = ("ClSilver = " + Strings.Format((object)CustClSilver, "0.00")) ?? "";
		}
		if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
		{
			if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRecVchGst.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRecVch.RPT";
			}
		}
		else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OldItmSaleVch.RPT";
		}
		else if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			if (PrHalfPrint)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBillHalfGst.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBillA4Gst.RPT";
			}
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBillA4.RPT";
		}
		Cr.SelectionFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					Cr[(short)1] = "InVoiceType = 'ACCOUNT COPY'";
				}
				else
				{
					Cr[(short)1] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";
				}
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					Cr[(short)1] = "InVoiceType = 'PARTY COPY'";
				}
				else
				{
					Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				}
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
		chkWapp.Checked = false;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_PURC_HM_Activated(object sender, EventArgs e)
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
			((Control)TEXT_PR).Visible = false;
			((Control)mVchDate).Focus();
			return;
		}
		if (DC_Main.MsOldPurc | DC_Main.MsOldPurcSl)
		{
			tAcCode.Text = DC_Main.MsSlAcCode;
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				tAcCode.Text = "00050";
			}
			tAcName.Text = DC_Main.CustUrdName;
			tSlBill.Text = DC_Main.MsSlBill;
			tSlBill_DbCd.Text = DC_Main.MsSlDbCd;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsBillImgPath, "", false) != 0))
		{
			PicBill.Image = Image.FromFile(DC_Main.MsBillImgPath);
		}
		else
		{
			PicBill.Image = null;
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,BILL_NO As RefNoL,A.VCH_DESC As VchDescL,PARTY_FINE As FineW,TOT_AMT As TotAmtR FROM " + TblData + " AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 90.0;
		DC_Main.ColWidth[4] = 250.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
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
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mVchDate;
		DC_Main.SetDate(ref MsDate);
		mVchDate = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				((Control)cboItemTyp).Focus();
			}
			else
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
				DC_Main.RsQry = "SELECT VCH_NO FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void PicZoom_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = null;
		((Control)PicZoom).Dock = (DockStyle)0;
		((Control)PicZoom).Visible = false;
	}

	private void TR_PURC_HM_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
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

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
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
				if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
				{
					DC_Main.MsGrCode = "10";
				}
				else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
				{
					DC_Main.MsGrCode = "10";
				}
				else
				{
					DC_Main.MsGrCode = "05";
				}
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
		if (Operators.CompareString(tAcCode.Text, "00050", false) != 0)
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
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
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			((Control)tAcName).Focus();
			return;
		}
		MSG_PR.Col = 1;
		MSG_PR.Row = 1;
		MSG_PR_EnterCell(MSG_PR, new EventArgs());
		((Control)TEXT_PR).Focus();
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
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				((Control)nPartyFine).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void tVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM " + TblData + " WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 14;
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
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0 && ((DC_Main.i == 4) | (DC_Main.i == 3)))
				{
					mSG2_TOTAL[DC_Main.i] = 0;
				}
				switch (DC_Main.i)
				{
				case 0:
				case 8:
				case 13:
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
				case 2:
				case 5:
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
			while (DC_Main.i <= 13);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Tcs Amt : ";
			mSG2_TOTAL[4, 0] = "Tds Amt : ";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				mSG2_TOTAL[5, 0] = "Lbr Amt : ";
				mSG2_TOTAL[6, 0] = "Lbr Tax : ";
			}
			else
			{
				mSG2_TOTAL[5, 0] = "Hm Amt : ";
				mSG2_TOTAL[6, 0] = "Hm Tax : ";
			}
			mSG2_TOTAL[7, 0] = "Rof Amt : ";
			mSG2_TOTAL[8, 0] = "Total Amt : ";
			mSG2_TOTAL[9, 0] = "Cheque Amt : ";
			mSG2_TOTAL[10, 0] = "Card Amt : ";
			mSG2_TOTAL[11, 0] = "Cash Amt : ";
			mSG2_TOTAL[12, 0] = "Kasar Amt : ";
			mSG2_TOTAL[13, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 13))
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
				if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 13) | (mSG2_TOTAL.Row == 2))
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
					if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 13))
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
			if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
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
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f19: Unknown result type (might be due to invalid IL or missing references)
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
					if (((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 9)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 10)
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
										OldNetAmt = 0.0;
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
										mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
										OldNetAmt = 0.0;
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
									{
										mSG2_TOTAL.Row = 3;
									}
									else
									{
										mSG2_TOTAL.Row = 6;
									}
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
								double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
								{
									mSG2_TOTAL.Row = 3;
								}
								else
								{
									mSG2_TOTAL.Row = 6;
								}
								mSG2_TOTAL.Col = 1;
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
							if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
							{
								mSG2_TOTAL.Row = 3;
							}
							else
							{
								mSG2_TOTAL.Row = 6;
							}
							mSG2_TOTAL.Col = 1;
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
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '20' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
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
										mSG2_TOTAL[3, 4] = DC_Main.ColValue[2];
										OldNetAmt = 0.0;
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										OldNetAmt = 0.0;
										mSG2_TOTAL[3, 1] = "";
										mSG2_TOTAL[3, 2] = "";
										mSG2_TOTAL[3, 3] = "";
										mSG2_TOTAL[3, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 4;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 4;
								mSG2_TOTAL.Col = 1;
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
							mSG2_TOTAL.Row = 4;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 4)
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE NOT IN ('01','02','10','11','12','13','14','20') AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
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
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[7, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 6;
								mSG2_TOTAL.Col = 1;
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
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row != 6)
					{
						break;
					}
					if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
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
									mSG2_TOTAL[6, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									mSG2_TOTAL[6, 4] = DC_Main.ColValue[2];
									BILL_TOTAL();
								}
								else
								{
									TEXT_ENTRY_2.Text = "";
									mSG2_TOTAL[6, 1] = "";
									mSG2_TOTAL[6, 2] = "";
									mSG2_TOTAL[6, 3] = "";
									mSG2_TOTAL[6, 4] = "";
								}
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 7;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[6, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
							mSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 7;
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
						mSG2_TOTAL.Row = 7;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 7:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 2;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 11:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 9:
					case 10:
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
					case 12:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)tEmpCode).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
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
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 30]), DC_Main.MsTotAmtRof), "0.00");
			if (Conversion.Val(mSG2_TOTAL[6, 2]) != 0.0)
			{
				mSG2_TOTAL[6, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) * Conversion.Val(mSG2_TOTAL[6, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
		}
		else
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 39]), 0), "0.00");
			if (Conversion.Val(mSG2_TOTAL[6, 2]) != 0.0)
			{
				mSG2_TOTAL[6, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) * Conversion.Val(mSG2_TOTAL[6, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 38]) - Conversion.Val(MSG_PR_TOT[0, 30]) - PrOthAmtLess, DC_Main.MsTotAmtRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)(Math.Round(Conversion.Val(MSG_PR_TOT[0, 38]), 0) - PrOthAmtLess), "0.00");
		}
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_PR_TOT[0, 30]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
		}
		if (OldNetAmt != Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00")))
		{
			OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00"));
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
		}
		if (Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0)
		{
			if ((Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
			{
				mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
			}
			mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - (Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[4, 3])) + Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[6, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]), 0), "0.00");
		}
		else
		{
			mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[6, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]), 0), "0.00");
		}
		mSG2_TOTAL[13, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[12, 3])), "0.00");
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			mSG2_TOTAL[11, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]), 0), "0.00");
		}
		if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
		{
			if (Conversion.Val(nPartyFine.Text) != 0.0)
			{
				CustClAmt = CustOpAmt;
			}
			else if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[13, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[13, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[13, 3]);
			}
			if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "G", false) == 0)
			{
				if (CustOpGold > 0.0)
				{
					CustClGold = CustOpGold + Conversion.Val(nPartyFine.Text);
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = Conversion.Val(nPartyFine.Text) - Math.Abs(CustOpGold);
				}
				else
				{
					CustClGold = Conversion.Val(nPartyFine.Text);
				}
			}
			else
			{
				CustClGold = CustOpGold;
			}
			if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "S", false) == 0)
			{
				if (CustOpSilver > 0.0)
				{
					CustClSilver = CustOpSilver + Conversion.Val(nPartyFine.Text);
				}
				else if (CustOpGold < 0.0)
				{
					CustClSilver = Conversion.Val(nPartyFine.Text) - Math.Abs(CustOpSilver);
				}
				else
				{
					CustClSilver = Conversion.Val(nPartyFine.Text);
				}
			}
			else
			{
				CustClSilver = CustOpSilver;
			}
		}
		else
		{
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[13, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[13, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[13, 3]);
			}
			if (Operators.CompareString(FormItmType, "G", false) == 0)
			{
				if (CustOpGold > 0.0)
				{
					CustClGold = CustOpGold + PurcAcFine;
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = PurcAcFine - Math.Abs(CustOpGold);
				}
				else
				{
					CustClGold = PurcAcFine;
				}
			}
			else
			{
				CustClGold = CustOpGold;
			}
			if (Operators.CompareString(FormItmType, "S", false) == 0)
			{
				if (CustOpSilver > 0.0)
				{
					CustClSilver = CustOpSilver + PurcAcFine;
				}
				else if (CustOpGold < 0.0)
				{
					CustClSilver = PurcAcFine - Math.Abs(CustOpSilver);
				}
				else
				{
					CustClSilver = PurcAcFine;
				}
			}
			else
			{
				CustClSilver = CustOpSilver;
			}
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
			((Control)nCrDays).Focus();
		}
	}

	private void tAcName_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcName).SelectionStart = 0;
		((TextBoxBase)tAcName).SelectionLength = Strings.Len(tAcName.Text);
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
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
		}
		else
		{
			MSG_PR.Col = 1;
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
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
			MSG_PR.Col = 1;
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
	}

	private void MSG_PR_Scroll(object sender, EventArgs e)
	{
		if (MSG_PR_TOT.LeftCol != MSG_PR.LeftCol)
		{
			MSG_PR_TOT.LeftCol = MSG_PR.LeftCol;
			MSG_PR_TOT.ScrollTrack = MSG_PR.LeftCol != 0;
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tAcCode).Focus();
		}
	}

	private void nPartyFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPartyFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPartyFine.Text)), "0.000");
			BILL_TOTAL();
			((Control)tBankName).Focus();
		}
	}

	private void chkBillImage_CheckedChanged(object sender, EventArgs e)
	{
		if (((Control)pnlBill).Visible)
		{
			((Control)pnlBill).Visible = false;
		}
		else
		{
			((Control)pnlBill).Visible = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void btnBillSelect_Click(object sender, EventArgs e)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					((FileDialog)DlgOpen).Filter = "JPEG (*.jpg)|*.jpg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					string text = "DhranImage";
					string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
					DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
					{
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
						{
							PicBill.Image.Dispose();
							PicBill.Image = null;
							FileSystem.Kill(DC_Main.MsBillImgPath);
						}
						PicBill.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
						PicBill.Image.Save(DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg");
					}
					goto end_IL_0001;
				}
				case 420:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 420;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void btnBillDel_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num2 = 2;
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
					{
						string text = "DhranImage";
						string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
						DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
						{
							PicBill.Image.Dispose();
							PicBill.Image = null;
							FileSystem.Kill(DC_Main.MsBillImgPath);
						}
					}
					goto end_IL_0001;
				case 295:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 295;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void btnbillCap_Click(object sender, EventArgs e)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					string text = "DhranImage";
					string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
					DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
					{
						PicBill.Image.Dispose();
						PicBill.Image = null;
						FileSystem.Kill(DC_Main.MsBillImgPath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				}
				case 294:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)"Please Check Len Connection...You Cant Save Image...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 294;
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

	private void PicBill_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicBill.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void TR_PURC_HM_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_PR", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_PR).SelectionStart = 0;
			((TextBoxBase)TEXT_PR).SelectionLength = Strings.Len(TEXT_PR.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_PR_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_PR_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_PR_IDTL).SelectionLength = Strings.Len(TEXT_PR_IDTL.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void TEXT_PR_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_PR).ReadOnly = false;
	}

	private void chkRateUnFix_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tVchNo).Focus();
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

	private void tBankName_TextChanged(object sender, EventArgs e)
	{
	}
}
