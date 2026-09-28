using System;
using System.Collections;
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
public class TR_WH_SALE_RTN : Form
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
	[AccessedThroughProperty("tSlBill")]
	private TextBox _tSlBill;

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
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIsuNo")]
	private SimpleButton _btnIsuNo;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

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

	private string CurRatePar;

	private string BookDataType;

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

	private const int cPrTagNo = 1;

	private const int cPrItCode = 2;

	private const int cPrItName = 3;

	private const int cPrCounter = 4;

	private const int cPrDesign = 5;

	private const int cStyle = 6;

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

	private const int cKrOthWt = 94;

	private const int cKrNetWt = 95;

	private const int cKrGhtPrc = 96;

	private const int cKrGhtWt = 97;

	private const int cKrTouch = 98;

	private const int cKrWestPrc = 99;

	private const int cKrFine = 100;

	private const int cKrLbrRate = 101;

	private const int cKrLbrAmt = 102;

	private const int cKrOthAmt = 103;

	private const int cKrCost = 104;

	private const int cOldVchSrNo = 105;

	private const int c2SrNo = 0;

	private const int c2ItCode = 1;

	private const int c2ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmColor = 5;

	private const int c1DmSize = 6;

	private const int c1DmOrigin = 7;

	private const int c1DmRemark = 8;

	private const int c1DmSfNo = 9;

	private const int c2Pcs = 10;

	private const int c1PcsWt = 11;

	private const int c1KrWt = 12;

	private const int c1KrPrc = 13;

	private const int c2GrWt = 14;

	private const int c2ConPrc = 15;

	private const int c2RateType = 16;

	private const int c2KrRate = 17;

	private const int c2KrAmt = 18;

	private const int c2ItRate = 19;

	private const int c2ItmAmt = 20;

	private const int c2LbrRate = 21;

	private const int c2LbrAmt = 22;

	private const int c2NetAmt = 23;

	private const int c2ConWt = 24;

	private const int c2ItType = 25;

	private const int c2RowSr = 26;

	private const int c2KrConWt = 27;

	private const int c2RowVal = 28;

	private const int c2RowText = 29;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTot2 = 2;

	private const int cChq2 = 3;

	private const int cCard2 = 4;

	private const int cCash2 = 5;

	private const int cKasar2 = 6;

	private const int cOs2 = 7;

	private const int cTax2 = 8;

	private const int cTcs2 = 9;

	private const int cTds2 = 10;

	private const int cHmAmt2 = 11;

	private const int cHmTax2 = 12;

	private const int cRof2 = 13;

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

	internal virtual TextBox tSlBill
	{
		[CompilerGenerated]
		get
		{
			return _tSlBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TSlBill_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tSlBill_KeyDown);
			TextBox val2 = _tSlBill;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tSlBill = value;
			val2 = _tSlBill;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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
	[AccessedThroughProperty("tSlBillYrCd")]
	private virtual TextBox _tSlBillYrCd;

	internal virtual TextBox tSlBillYrCd
	{
		get
		{
			return _tSlBillYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSlBillYrCd = value;
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
			EventHandler eventHandler = BtnIsuNo_Click;
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
	[AccessedThroughProperty("PicImage")]
	private virtual PictureBox _PicImage;

	internal virtual PictureBox PicImage
	{
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PicImage = value;
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

	public TR_WH_SALE_RTN()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_WH_SALE_RTN_Load;
		((Form)this).Deactivate += TR_WH_SALE_RTN_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_WH_SALE_RTN_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_WH_SALE_RTN_KeyDown);
		((Form)this).Activated += TR_WH_SALE_RTN_Activated;
		((Form)this).Closed += TR_WH_SALE_RTN_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_WH_SALE_RTN_KeyUp);
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
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Expected O, but got Unknown
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Expected O, but got Unknown
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Expected O, but got Unknown
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Expected O, but got Unknown
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Expected O, but got Unknown
		//IL_09c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cf: Expected O, but got Unknown
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected O, but got Unknown
		//IL_0ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Expected O, but got Unknown
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c16: Expected O, but got Unknown
		//IL_0d21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2b: Expected O, but got Unknown
		//IL_0d8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d98: Expected O, but got Unknown
		//IL_0f2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe9: Expected O, but got Unknown
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10eb: Expected O, but got Unknown
		//IL_12aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b4: Expected O, but got Unknown
		//IL_138c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1396: Expected O, but got Unknown
		//IL_1432: Unknown result type (might be due to invalid IL or missing references)
		//IL_143c: Expected O, but got Unknown
		//IL_1577: Unknown result type (might be due to invalid IL or missing references)
		//IL_1581: Expected O, but got Unknown
		//IL_15cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d6: Expected O, but got Unknown
		//IL_1653: Unknown result type (might be due to invalid IL or missing references)
		//IL_165d: Expected O, but got Unknown
		//IL_16de: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e8: Expected O, but got Unknown
		//IL_17b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bc: Expected O, but got Unknown
		//IL_1863: Unknown result type (might be due to invalid IL or missing references)
		//IL_186d: Expected O, but got Unknown
		//IL_191d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1927: Expected O, but got Unknown
		//IL_19dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e6: Expected O, but got Unknown
		//IL_1a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a54: Expected O, but got Unknown
		//IL_1ab2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abc: Expected O, but got Unknown
		//IL_1b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b65: Expected O, but got Unknown
		//IL_1be2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bec: Expected O, but got Unknown
		//IL_1c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca4: Expected O, but got Unknown
		//IL_1e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9a: Expected O, but got Unknown
		//IL_1f47: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f51: Expected O, but got Unknown
		//IL_1fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fea: Expected O, but got Unknown
		//IL_2098: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a2: Expected O, but got Unknown
		//IL_2131: Unknown result type (might be due to invalid IL or missing references)
		//IL_213b: Expected O, but got Unknown
		//IL_21e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f3: Expected O, but got Unknown
		//IL_22a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ab: Expected O, but got Unknown
		//IL_233a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2344: Expected O, but got Unknown
		//IL_23d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23dd: Expected O, but got Unknown
		//IL_246b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2475: Expected O, but got Unknown
		//IL_2538: Unknown result type (might be due to invalid IL or missing references)
		//IL_2542: Expected O, but got Unknown
		//IL_2590: Unknown result type (might be due to invalid IL or missing references)
		//IL_259a: Expected O, but got Unknown
		//IL_264e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2658: Expected O, but got Unknown
		//IL_270c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2716: Expected O, but got Unknown
		//IL_27ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d4: Expected O, but got Unknown
		//IL_288b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2895: Expected O, but got Unknown
		//IL_294c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2956: Expected O, but got Unknown
		//IL_2a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a17: Expected O, but got Unknown
		//IL_2a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a8a: Expected O, but got Unknown
		//IL_2b3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b45: Expected O, but got Unknown
		//IL_2bdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be9: Expected O, but got Unknown
		//IL_2c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c5c: Expected O, but got Unknown
		//IL_2d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d17: Expected O, but got Unknown
		//IL_2db6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc0: Expected O, but got Unknown
		//IL_2e6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e77: Expected O, but got Unknown
		//IL_2f28: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f32: Expected O, but got Unknown
		//IL_2fc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fca: Expected O, but got Unknown
		//IL_30f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_30ff: Expected O, but got Unknown
		//IL_319f: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a9: Expected O, but got Unknown
		//IL_31f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_31fd: Expected O, but got Unknown
		//IL_328b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3295: Expected O, but got Unknown
		//IL_3313: Unknown result type (might be due to invalid IL or missing references)
		//IL_331d: Expected O, but got Unknown
		//IL_33a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_33af: Expected O, but got Unknown
		//IL_3480: Unknown result type (might be due to invalid IL or missing references)
		//IL_348a: Expected O, but got Unknown
		//IL_3562: Unknown result type (might be due to invalid IL or missing references)
		//IL_356c: Expected O, but got Unknown
		//IL_3608: Unknown result type (might be due to invalid IL or missing references)
		//IL_3612: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_WH_SALE_RTN));
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
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
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
		PnlPrIdtl = new Panel();
		TEXT_PR_IDTL = new TextBox();
		MSG_PR_IDTL = new AxMSFlexGrid();
		tSlBillYrCd = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		btnIsuNo = new SimpleButton();
		PicImage = new PictureBox();
		PictureBox1 = new PictureBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((Control)PnlPrIdtl).SuspendLayout();
		((ISupportInitialize)MSG_PR_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
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
		lblBook.Text = "Wh Sales Return";
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
		((Control)PnlBotam).TabIndex = 12;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
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
		((Control)tAcCode).TabIndex = 5;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 67);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(347, 23);
		((Control)tAcName).TabIndex = 6;
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
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(8, 421);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(92, 427);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(327, 61);
		((Control)tVchDesc).TabIndex = 11;
		((Control)MSG2_TOTAL).Location = new Point(729, 394);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 166);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(13, 96);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1156, 145);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(913, 470);
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
		((Control)TEXT_PR).TabIndex = 8;
		((Control)TEXT_PR).Visible = false;
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
		((Control)PanelAdd).Location = new Point(312, 97);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 152);
		((Control)PanelAdd).TabIndex = 7;
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
		((Control)MSG_PR_TOT).Location = new Point(15, 242);
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
		((Control)tSlBill).Location = new Point(806, 39);
		((TextBoxBase)tSlBill).MaxLength = 8;
		((Control)tSlBill).Name = "tSlBill";
		((Control)tSlBill).Size = new Size(57, 23);
		((Control)tSlBill).TabIndex = 3;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(737, 40);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(65, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "Wh No";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSlBill_DbCd).BackColor = Color.White;
		((Control)tSlBill_DbCd).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSlBill_DbCd).Location = new Point(867, 39);
		((TextBoxBase)tSlBill_DbCd).MaxLength = 8;
		((Control)tSlBill_DbCd).Name = "tSlBill_DbCd";
		((TextBoxBase)tSlBill_DbCd).ReadOnly = true;
		((Control)tSlBill_DbCd).Size = new Size(37, 23);
		((Control)tSlBill_DbCd).TabIndex = 1216;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(654, 39);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(87, 22);
		((Control)cboItemTyp).TabIndex = 2;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(571, 40);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(74, 20);
		((Control)Label12).TabIndex = 1218;
		Label12.Text = "Item Type";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPartyFine).BackColor = Color.White;
		((Control)nPartyFine).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPartyFine).Location = new Point(654, 395);
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
		((Control)Label14).Location = new Point(584, 397);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(69, 20);
		((Control)Label14).TabIndex = 1220;
		Label14.Text = "Party Fine";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label14).Visible = false;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(737, 68);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(66, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Item Wt";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nitGwt).BackColor = Color.White;
		((Control)nitGwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nitGwt).Location = new Point(806, 68);
		((TextBoxBase)nitGwt).MaxLength = 8;
		((Control)nitGwt).Name = "nitGwt";
		((TextBoxBase)nitGwt).ReadOnly = true;
		((Control)nitGwt).Size = new Size(57, 23);
		((Control)nitGwt).TabIndex = 1222;
		((TextBoxBase)nItNwt).BackColor = Color.White;
		((Control)nItNwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItNwt).Location = new Point(867, 67);
		((TextBoxBase)nItNwt).MaxLength = 8;
		((Control)nItNwt).Name = "nItNwt";
		((TextBoxBase)nItNwt).ReadOnly = true;
		((Control)nItNwt).Size = new Size(69, 23);
		((Control)nItNwt).TabIndex = 1223;
		((Control)PnlPrIdtl).BackColor = SystemColors.ButtonHighlight;
		((Control)PnlPrIdtl).Controls.Add((Control)(object)TEXT_PR_IDTL);
		((Control)PnlPrIdtl).Controls.Add((Control)(object)MSG_PR_IDTL);
		((Control)PnlPrIdtl).Location = new Point(4, 261);
		((Control)PnlPrIdtl).Name = "PnlPrIdtl";
		((Control)PnlPrIdtl).Size = new Size(966, 129);
		((Control)PnlPrIdtl).TabIndex = 9;
		((TextBoxBase)TEXT_PR_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR_IDTL).ForeColor = Color.White;
		((Control)TEXT_PR_IDTL).Location = new Point(338, 55);
		((Control)TEXT_PR_IDTL).Name = "TEXT_PR_IDTL";
		((Control)TEXT_PR_IDTL).Size = new Size(100, 18);
		((Control)TEXT_PR_IDTL).TabIndex = 9;
		((Control)TEXT_PR_IDTL).Visible = false;
		((Control)MSG_PR_IDTL).Location = new Point(8, 4);
		((Control)MSG_PR_IDTL).Name = "MSG_PR_IDTL";
		((AxHost)MSG_PR_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_PR_IDTL.OcxState");
		((Control)MSG_PR_IDTL).Size = new Size(953, 122);
		((Control)MSG_PR_IDTL).TabIndex = 0;
		((TextBoxBase)tSlBillYrCd).BackColor = Color.White;
		((Control)tSlBillYrCd).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSlBillYrCd).Location = new Point(908, 38);
		((TextBoxBase)tSlBillYrCd).MaxLength = 8;
		((Control)tSlBillYrCd).Name = "tSlBillYrCd";
		((TextBoxBase)tSlBillYrCd).ReadOnly = true;
		((Control)tSlBillYrCd).Size = new Size(69, 23);
		((Control)tSlBillYrCd).TabIndex = 1226;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(92, 398);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(70, 23);
		((Control)tEmpCode).TabIndex = 10;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(167, 398);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(252, 23);
		((Control)tEmpName).TabIndex = 1229;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(15, 398);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1228;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
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
		((Control)btnIsuNo).Location = new Point(983, 37);
		((BaseControl)btnIsuNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIsuNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIsuNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIsuNo).Name = "btnIsuNo";
		((Control)btnIsuNo).Size = new Size(30, 23);
		((Control)btnIsuNo).TabIndex = 1230;
		btnIsuNo.Text = "S";
		((BaseControl)btnIsuNo).ToolTip = "Sales Help";
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(983, 265);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(129, 122);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1231;
		PicImage.TabStop = false;
		((Control)PictureBox1).BackColor = Color.Transparent;
		PictureBox1.BorderStyle = (BorderStyle)1;
		PictureBox1.ImeMode = (ImeMode)0;
		((Control)PictureBox1).Location = new Point(1210, 427);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(79, 68);
		PictureBox1.SizeMode = (PictureBoxSizeMode)4;
		PictureBox1.TabIndex = 1237;
		PictureBox1.TabStop = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)btnIsuNo);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)tSlBillYrCd);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)PnlPrIdtl);
		((Control)this).Controls.Add((Control)(object)nItNwt);
		((Control)this).Controls.Add((Control)(object)nitGwt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nPartyFine);
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
		((Control)this).Controls.Add((Control)(object)TEXT_PR);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG_PR);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)PicZoom);
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
		((Control)this).Name = "TR_WH_SALE_RTN";
		((Form)this).Text = "Wh Sales Return";
		((Control)PnlBotam).ResumeLayout(false);
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
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_PR_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		mSG_PR_IDTL.Clear();
		mSG_PR_IDTL.Cols = 30;
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
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG_PR_IDTL[3] = (int)Math.Round(875.0 * ColCon);
				mSG_PR_IDTL[3] = 0;
				mSG_PR_IDTL[0, 3] = "DmCode";
				mSG_PR_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
				mSG_PR_IDTL[4] = 0;
				mSG_PR_IDTL[0, 4] = "DmName";
				mSG_PR_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_PR_IDTL[5] = 0;
				mSG_PR_IDTL[0, 5] = "DmColor";
				mSG_PR_IDTL[6] = (int)Math.Round(900.0 * ColCon);
				mSG_PR_IDTL[6] = 3;
				mSG_PR_IDTL[0, 6] = "DmSize";
				mSG_PR_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[7] = 0;
				mSG_PR_IDTL[0, 7] = "DmOrigin";
				mSG_PR_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[8] = 0;
				mSG_PR_IDTL[0, 8] = "DmRemark";
				mSG_PR_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[9] = 0;
				mSG_PR_IDTL[0, 9] = "DmSfNo";
			}
			else
			{
				mSG_PR_IDTL[3] = 0;
				mSG_PR_IDTL[0, 3] = "DmCode";
				mSG_PR_IDTL[4] = 0;
				mSG_PR_IDTL[0, 4] = "DmName";
				mSG_PR_IDTL[5] = 0;
				mSG_PR_IDTL[0, 5] = "DmColor";
				mSG_PR_IDTL[6] = 0;
				mSG_PR_IDTL[0, 6] = "DmSize";
				mSG_PR_IDTL[7] = 0;
				mSG_PR_IDTL[0, 7] = "DmOrigin";
				mSG_PR_IDTL[8] = 0;
				mSG_PR_IDTL[0, 8] = "Remark";
				mSG_PR_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[9] = 0;
				mSG_PR_IDTL[0, 9] = "DmSfNo";
			}
			mSG_PR_IDTL[10] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[10] = 7;
			mSG_PR_IDTL[0, 10] = "Pcs";
			mSG_PR_IDTL[11] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[11] = 7;
			mSG_PR_IDTL[0, 11] = "PcsWt";
			mSG_PR_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[12] = 7;
			mSG_PR_IDTL[0, 12] = "KrWt";
			mSG_PR_IDTL[13] = (int)Math.Round(800.0 * ColCon);
			mSG_PR_IDTL[13] = 7;
			mSG_PR_IDTL[0, 13] = "KrLs%";
			mSG_PR_IDTL[14] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR_IDTL[14] = 7;
			mSG_PR_IDTL[0, 14] = "Weight";
			mSG_PR_IDTL[15] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[15] = 7;
			mSG_PR_IDTL[0, 15] = "Con%";
			mSG_PR_IDTL[16] = (int)Math.Round(650.0 * ColCon);
			mSG_PR_IDTL[16] = 3;
			mSG_PR_IDTL[0, 16] = "P/W";
			mSG_PR_IDTL[17] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[17] = 7;
			mSG_PR_IDTL[0, 17] = "PRate";
			mSG_PR_IDTL[18] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR_IDTL[18] = 7;
			mSG_PR_IDTL[0, 18] = "PAmt";
			mSG_PR_IDTL[19] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[19] = 7;
			mSG_PR_IDTL[0, 19] = "Rate";
			mSG_PR_IDTL[20] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR_IDTL[20] = 7;
			mSG_PR_IDTL[0, 20] = "ItAmt";
			mSG_PR_IDTL[21] = (int)Math.Round(850.0 * ColCon);
			mSG_PR_IDTL[21] = 7;
			mSG_PR_IDTL[0, 21] = "LbrRate";
			mSG_PR_IDTL[22] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[22] = 7;
			mSG_PR_IDTL[0, 22] = "LbrAmt";
			mSG_PR_IDTL[23] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR_IDTL[23] = 7;
			mSG_PR_IDTL[0, 23] = "NetAmt";
			mSG_PR_IDTL[24] = 0;
			mSG_PR_IDTL[0, 24] = "ConWt";
			mSG_PR_IDTL[25] = 0;
			mSG_PR_IDTL[0, 25] = "ItType";
			mSG_PR_IDTL[26] = 0;
			mSG_PR_IDTL[0, 26] = "RowSrNo";
			mSG_PR_IDTL[27] = 0;
			mSG_PR_IDTL[0, 27] = "KrConWt";
			mSG_PR_IDTL[28] = 0;
			mSG_PR_IDTL[0, 28] = "2RowVal";
			mSG_PR_IDTL[29] = 0;
			mSG_PR_IDTL[0, 29] = "2RowText";
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
		mSG_PR_IDTL[mSG_PR_IDTL.Row, 26] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 80]));
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
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Invalid comparison between Unknown and I4
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Invalid comparison between Unknown and I4
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Invalid comparison between Unknown and I4
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Invalid comparison between Unknown and I4
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][26])) == Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 26])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 0])))
						{
							DtIdtlPr.Rows[i][1] = "";
							DtIdtlPr.Rows[i][2] = "";
							DtIdtlPr.Rows[i][10] = 0;
							DtIdtlPr.Rows[i][11] = 0;
							DtIdtlPr.Rows[i][12] = 0;
							DtIdtlPr.Rows[i][13] = 0;
							DtIdtlPr.Rows[i][14] = 0;
							DtIdtlPr.Rows[i][15] = 0;
							DtIdtlPr.Rows[i][16] = "";
							DtIdtlPr.Rows[i][17] = 0;
							DtIdtlPr.Rows[i][18] = 0;
							DtIdtlPr.Rows[i][19] = 0;
							DtIdtlPr.Rows[i][20] = 0;
							DtIdtlPr.Rows[i][21] = 0;
							DtIdtlPr.Rows[i][22] = 0;
							DtIdtlPr.Rows[i][23] = 0;
							DtIdtlPr.Rows[i][24] = 0;
							DtIdtlPr.Rows[i][25] = 0.0;
							DtIdtlPr.Rows[i][27] = 0;
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
				if (mSG_PR_IDTL.Col < 23)
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
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 25] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR_IDTL).Focus();
							}
							return;
						}
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 19]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 15]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						break;
					case 3:
						if (Operators.CompareString(TEXT_PR_IDTL.Text, "", false) == 0 || mSG_PR_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_PR_IDTL.Text + "'";
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
									TEXT_PR_IDTL.Text = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_PR_IDTL).Focus();
							}
							return;
						}
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_CODE"], (object)""));
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_NAME"], (object)""));
						break;
					case 11:
						if ((Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_PR_IDTL.Text) != 0.0))
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 10]) * Conversion.Val(TEXT_PR_IDTL.Text)), "0.000");
						}
						break;
					case 14:
						if ((Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 10]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 14]) == 0.0))
						{
							if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 23]) == 0.0)
							{
								mSG_PR_IDTL[mSG_PR_IDTL.Row, 23] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 19] = "";
						}
						break;
					case 23:
						if (mSG_PR_IDTL.Row == mSG_PR_IDTL.Rows - 1)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 23] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
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
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 23] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
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
				case 3:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 8;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 50;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 15;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 6:
				case 7:
				case 8:
				case 9:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 20;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 16:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 1;
					TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 6;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0");
					break;
				case 15:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.000");
					break;
				case 13:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
					((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.00");
					break;
				case 11:
				case 12:
				case 14:
				case 24:
				case 27:
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
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 16:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = TEXT_PR_IDTL.Text;
				break;
			case 10:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			case 15:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.000");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			case 13:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
				CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
				break;
			case 11:
			case 12:
			case 14:
			case 24:
			case 27:
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
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 11]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 12] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 10]) * Conversion.Val(mSG_PR_IDTL[XRow, 11])), "0.000");
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 13]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 14] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 13]) / 100.0), "0.000");
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 15]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 27] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 15])), "0.000");
		}
		else
		{
			mSG_PR_IDTL[XRow, 27] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 15]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 24] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 14]) * Conversion.Val(mSG_PR_IDTL[XRow, 15])), "0.000");
		}
		else
		{
			mSG_PR_IDTL[XRow, 24] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_PR_IDTL[XRow, 16], "", false) == 0)
		{
			if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 19]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 19]) * Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 19]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 19]) * Conversion.Val(mSG_PR_IDTL[XRow, 14])), "0.00");
			}
			if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 12])), "0.00");
			}
		}
		else
		{
			if ((Operators.CompareString(mSG_PR_IDTL[XRow, 16], "P", false) == 0) & (Conversion.Val(mSG_PR_IDTL[XRow, 19]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 19]) * Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.00");
			}
			else if (Conversion.Val(mSG_PR_IDTL[XRow, 19]) != 0.0)
			{
				mSG_PR_IDTL[XRow, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 19]) * Conversion.Val(mSG_PR_IDTL[XRow, 14])), "0.00");
			}
			if ((Operators.CompareString(mSG_PR_IDTL[XRow, 16], "P", false) == 0) & (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.00");
			}
			else if (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0)
			{
				mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 12])), "0.00");
			}
		}
		if (Conversion.Val(mSG_PR_IDTL[XRow, 21]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 22] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 21]) * Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.00");
		}
		if (Conversion.Val(mSG_PR_IDTL[XRow, 20]) + Conversion.Val(mSG_PR_IDTL[XRow, 22]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 23] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 20]) + Conversion.Val(mSG_PR_IDTL[XRow, 22])), "0.00");
		}
		checked
		{
			int num5 = mSG_PR_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 24]);
				num4 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 27]);
				num2 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 18]);
				num += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 23]);
				DC_Main.M++;
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 31] = Strings.Format((object)num, "0.00");
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 51] = Strings.Format((object)num, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 103] = Strings.Format((object)num2, "0.00");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 94] = Strings.Format((object)num4, "0.000");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 95] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 12]) - num4), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 13] = Strings.Format((object)num3, "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 12]) - num3), "0.000");
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
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][26])) == Conversion.Val(mSG_PR_IDTL[XRow, 26])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_PR_IDTL[XRow, 0])))
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
						DtIdtlPr.Rows[i][23] = mSG_PR_IDTL[XRow, 23];
						DtIdtlPr.Rows[i][24] = mSG_PR_IDTL[XRow, 24];
						DtIdtlPr.Rows[i][25] = mSG_PR_IDTL[XRow, 25];
						DtIdtlPr.Rows[i][26] = mSG_PR_IDTL[XRow, 26];
						DtIdtlPr.Rows[i][27] = mSG_PR_IDTL[XRow, 27];
						DtIdtlPr.Rows[i][28] = mSG_PR_IDTL[XRow, 28];
						DtIdtlPr.Rows[i][29] = mSG_PR_IDTL[XRow, 29];
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
					drPr[21] = mSG_PR_IDTL[XRow, 21];
					drPr[22] = mSG_PR_IDTL[XRow, 22];
					drPr[23] = mSG_PR_IDTL[XRow, 23];
					drPr[24] = mSG_PR_IDTL[XRow, 24];
					drPr[25] = mSG_PR_IDTL[XRow, 25];
					drPr[26] = mSG_PR_IDTL[XRow, 26];
					drPr[27] = mSG_PR_IDTL[XRow, 27];
					drPr[28] = 0;
					drPr[29] = "";
					DtIdtlPr.Rows.Add(drPr);
				}
			}
			mSG_PR_IDTL = null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		//IL_0a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Expected O, but got Unknown
		//IL_0811: Unknown result type (might be due to invalid IL or missing references)
		//IL_081b: Expected O, but got Unknown
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Expected O, but got Unknown
		//IL_0c32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3c: Expected O, but got Unknown
		if (MSG_PR.Row == 0 || !((MsgOldRowPr != MSG_PR.Row) & !MsgClearPr))
		{
			return;
		}
		MsgOldRowPr = MSG_PR.Row;
		double num = 0.0;
		MSG_PR_IDTL_CLEAR();
		int num2 = 1;
		checked
		{
			int num3 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (Conversion.Val(MSG_PR[MSG_PR.Row, 80]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][26])))
				{
					MSG_PR_IDTL[num2, 0] = Conversions.ToString(num2);
					MSG_PR_IDTL[num2, 1] = Conversions.ToString(DtIdtlPr.Rows[i][1]);
					MSG_PR_IDTL[num2, 2] = Conversions.ToString(DtIdtlPr.Rows[i][2]);
					MSG_PR_IDTL[num2, 3] = Conversions.ToString(DtIdtlPr.Rows[i][3]);
					MSG_PR_IDTL[num2, 4] = Conversions.ToString(DtIdtlPr.Rows[i][4]);
					MSG_PR_IDTL[num2, 5] = Conversions.ToString(DtIdtlPr.Rows[i][5]);
					MSG_PR_IDTL[num2, 6] = Conversions.ToString(DtIdtlPr.Rows[i][6]);
					MSG_PR_IDTL[num2, 7] = Conversions.ToString(DtIdtlPr.Rows[i][7]);
					MSG_PR_IDTL[num2, 8] = Conversions.ToString(DtIdtlPr.Rows[i][8]);
					MSG_PR_IDTL[num2, 9] = Conversions.ToString(DtIdtlPr.Rows[i][9]);
					MSG_PR_IDTL[num2, 10] = Conversions.ToString(DtIdtlPr.Rows[i][10]);
					MSG_PR_IDTL[num2, 11] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][11], (object)""));
					MSG_PR_IDTL[num2, 12] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][12], (object)""));
					MSG_PR_IDTL[num2, 13] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][13], (object)""));
					MSG_PR_IDTL[num2, 14] = Conversions.ToString(DtIdtlPr.Rows[i][14]);
					MSG_PR_IDTL[num2, 15] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][15], (object)""));
					MSG_PR_IDTL[num2, 16] = Conversions.ToString(DtIdtlPr.Rows[i][16]);
					MSG_PR_IDTL[num2, 17] = Conversions.ToString(DtIdtlPr.Rows[i][17]);
					MSG_PR_IDTL[num2, 18] = Conversions.ToString(DtIdtlPr.Rows[i][18]);
					MSG_PR_IDTL[num2, 19] = Conversions.ToString(DtIdtlPr.Rows[i][19]);
					MSG_PR_IDTL[num2, 20] = Conversions.ToString(DtIdtlPr.Rows[i][20]);
					MSG_PR_IDTL[num2, 21] = Conversions.ToString(DtIdtlPr.Rows[i][21]);
					MSG_PR_IDTL[num2, 22] = Conversions.ToString(DtIdtlPr.Rows[i][22]);
					MSG_PR_IDTL[num2, 23] = Conversions.ToString(DtIdtlPr.Rows[i][23]);
					MSG_PR_IDTL[num2, 24] = Conversions.ToString(DtIdtlPr.Rows[i][24]);
					MSG_PR_IDTL[num2, 25] = Conversions.ToString(DtIdtlPr.Rows[i][25]);
					MSG_PR_IDTL[num2, 26] = Conversions.ToString(DtIdtlPr.Rows[i][26]);
					MSG_PR_IDTL[num2, 27] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][27], (object)""));
					MSG_PR_IDTL[num2, 28] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][28], (object)""));
					MSG_PR_IDTL[num2, 29] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][29], (object)""));
					num += Conversion.Val(MSG_PR_IDTL[num2, 18]);
					MSG_PR_IDTL.Rows += 1;
					num2++;
				}
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 103] = Strings.Format((object)Math.Round(num, 0), "0.00");
			}
			PicImage.Image = null;
			if ((Operators.CompareString(MSG_PR[MSG_PR.Row, 86], "N", false) != 0) & (Operators.CompareString(MSG_PR[MSG_PR.Row, 5], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG_PR[MSG_PR.Row, 86] + "' AND IMAGE_TYPE = 'D'";
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
				DC_Main.MsImageNo = MSG_PR[MSG_PR.Row, 1] + "_" + MSG_PR[MSG_PR.Row, 105];
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
				{
					try
					{
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG_PR[MSG_PR.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 105]))) ?? "";
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
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG_PR[MSG_PR.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 105]))) ?? "";
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
			MSG_PR_IDTL[num2, 0] = Conversions.ToString(num2);
			MSG_PR_IDTL[num2, 26] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 80]));
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 106;
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
			mSG_PR[2] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "ItCode";
			mSG_PR[3] = (int)Math.Round(2200.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "ItName";
			mSG_PR[4] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Counter";
			mSG_PR[5] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[5] = 0;
			mSG_PR[0, 5] = "Design";
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				mSG_PR[6] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "Style";
			}
			else
			{
				mSG_PR[6] = 0;
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
			mSG_PR[1] = (int)Math.Round(1150.0 * ColCon);
			mSG_PR[1] = 0;
			mSG_PR[0, 1] = "TagNo";
			mSG_PR[40] = (int)Math.Round(850.0 * ColCon);
			mSG_PR[40] = 3;
			mSG_PR[0, 40] = "TOthWt";
			mSG_PR[41] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[41] = 7;
			mSG_PR[0, 41] = "TgNwt";
			mSG_PR[43] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[43] = 7;
			mSG_PR[0, 43] = "TgTch";
			mSG_PR[44] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[44] = 7;
			mSG_PR[0, 44] = "TgW%";
			mSG_PR[45] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[45] = 7;
			mSG_PR[0, 45] = "TgFine";
			mSG_PR[46] = 0;
			mSG_PR[46] = 7;
			mSG_PR[0, 46] = "TagRate";
			mSG_PR[47] = 0;
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
			mSG_PR[42] = 0;
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
			mSG_PR[57] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[57] = 7;
			mSG_PR[0, 57] = "HmWt";
			mSG_PR[59] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[59] = 7;
			mSG_PR[0, 59] = "HmWt2";
			mSG_PR[61] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[61] = 7;
			mSG_PR[0, 61] = "HmWt3";
			mSG_PR[63] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[63] = 7;
			mSG_PR[0, 63] = "HmWt4";
			mSG_PR[7] = 0;
			mSG_PR[7] = 0;
			mSG_PR[0, 7] = "Color";
			mSG_PR[52] = 0;
			mSG_PR[52] = 7;
			mSG_PR[0, 52] = "TagCost";
			mSG_PR[53] = 0;
			mSG_PR[53] = 7;
			mSG_PR[0, 53] = "Margin%";
			mSG_PR[89] = 0;
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
			mSG_PR[94] = 0;
			mSG_PR[95] = 0;
			mSG_PR[96] = 0;
			mSG_PR[97] = 0;
			mSG_PR[98] = 0;
			mSG_PR[99] = 0;
			mSG_PR[100] = 0;
			mSG_PR[101] = 0;
			mSG_PR[102] = 0;
			mSG_PR[103] = 0;
			mSG_PR[104] = 0;
			mSG_PR[105] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'WH RTN' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
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
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG_PR[mSG_PR.Row, 80] = Conversions.ToString(mSG_PR.Row);
		}
		else
		{
			mSG_PR[mSG_PR.Row, 80] = Conversions.ToString(Conversion.Val(mSG_PR[checked(mSG_PR.Row - 1), 80]) + 1.0);
		}
		mSG_PR[mSG_PR.Row, 66] = BookDataType;
		mSG_PR[mSG_PR.Row, 64] = "N";
		mSG_PR[mSG_PR.Row, 65] = "N";
		mSG_PR[mSG_PR.Row, 86] = "N";
		MSG_PR_IDTL_CLEAR();
		mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Strings.Format((object)Conversion.Val(tVchNo.Text), "0000") + Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 80]), "000");
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Invalid comparison between Unknown and I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Invalid comparison between Unknown and I4
		//IL_28de: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e5: Invalid comparison between Unknown and I4
		//IL_28e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ef: Invalid comparison between Unknown and I4
		//IL_28f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28fa: Invalid comparison between Unknown and I4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Invalid comparison between Unknown and I4
		//IL_1fec: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2466: Unknown result type (might be due to invalid IL or missing references)
		//IL_246c: Invalid comparison between Unknown and I4
		//IL_2716: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
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
				if (mSG_PR.Col < 63)
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
					{
						if (!((Operators.CompareString(TEXT_PR.Text, "", false) == 0) | (Operators.CompareString(TEXT_PR.Text, mSG_PR[mSG_PR.Row, 1], false) != 0)))
						{
							break;
						}
						if (Operators.CompareString(tSlBill.Text, "", false) != 0)
						{
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tSlBillYrCd.Text + "' AND A.CO_BOOK = '" + tSlBill_DbCd.Text + "' AND A.VCH_NO = '" + tSlBill.Text + "' AND A.TAG_NO = '" + TEXT_PR.Text + "' AND A.BOOK_NAME IN ('WH SALES','TOUR SALES') AND A.AC_CODE = '" + tAcCode.Text + "'  ";
						}
						else
						{
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_PR.Text + "' AND A.BOOK_NAME IN ('WH SALES','TOUR SALES') AND A.AC_CODE = '" + tAcCode.Text + "' AND A.TAG_NO = '" + TEXT_PR.Text + "' ORDER BY A.VCH_DATE DESC ";
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(tSlBill.Text, "", false) != 0)
							{
								DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.DESIGN_NO AS DesignNoL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.VCH_NO As IsuNoL,A.CO_YEAR As IsuYearL,A.CO_BOOK As IsuBookL,A.OLD_SRNO As IsuSrNoL  From RATE_CUT_ISU AS A LEFT JOIN  ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME IN ('WH SALES','TOUR SALES') AND A.CO_YEAR = '" + tSlBillYrCd.Text + "' AND A.CO_BOOK = '" + tSlBill_DbCd.Text + "' AND A.VCH_NO = '" + tSlBill.Text + "' AND A.AC_CODE = '" + tAcCode.Text + "'  ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO ";
							}
							else
							{
								DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.DESIGN_NO AS DesignNoL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.VCH_NO As IsuNoL,A.CO_YEAR As IsuYearL,A.CO_BOOK As IsuBookL,A.OLD_SRNO As IsuSrNoL  From RATE_CUT_ISU AS A LEFT JOIN  ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME IN ('WH SALES','TOUR SALES') AND A.AC_CODE = '" + tAcCode.Text + "'  ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO ";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[13];
							DC_Main.ColWidth[0] = 100.0;
							DC_Main.ColWidth[1] = 250.0;
							DC_Main.ColWidth[2] = 80.0;
							DC_Main.ColWidth[3] = 90.0;
							DC_Main.ColWidth[4] = 90.0;
							DC_Main.ColWidth[5] = 90.0;
							DC_Main.ColWidth[6] = 100.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 90.0;
							DC_Main.ColWidth[9] = 100.0;
							DC_Main.ColWidth[10] = 80.0;
							DC_Main.ColWidth[11] = 70.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_PR.Text = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[2];
									mSG_PR[mSG_PR.Row, 5] = DC_Main.ColValue[3];
									mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									((Control)TEXT_PR).Focus();
								}
								else
								{
									mSG_PR[mSG_PR.Row, 1] = "";
									((Control)TEXT_PR).Focus();
								}
							}
							return;
						}
						int num2 = mSG_PR.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num2)
						{
							if ((Operators.CompareString(mSG_PR[DC_Main.X, 1], TEXT_PR.Text, false) == 0) & (mSG_PR.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						string text = "";
						string text2 = "";
						int num3 = 0;
						DC_Main.i = mSG_PR.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG_PR[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG_PR[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG_PR[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG_PR[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_STYLE"], (object)""));
							mSG_PR[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG_PR[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG_PR[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
							mSG_PR[DC_Main.i, 10] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG_PR[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG_PR[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG_PR[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG_PR[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG_PR[DC_Main.i, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG_PR[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG_PR[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG_PR[DC_Main.i, 105] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG_PR[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG_PR[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG_PR[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG_PR[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG_PR[DC_Main.i, 95] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
							mSG_PR[DC_Main.i, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 99] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 100] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
							mSG_PR[DC_Main.i, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])) != 0.0)
							{
								mSG_PR[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							}
							mSG_PR[DC_Main.i, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 82] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[DC_Main.i, 85] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG_PR[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG_PR[DC_Main.i, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG_PR[DC_Main.i, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG_PR[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG_PR[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG_PR[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG_PR[DC_Main.i, 86] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
							text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							num3 = (int)Math.Round(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)"")));
						}
						int num4 = 0;
						int num5 = DtIdtlPr.Rows.Count - 1;
						int num6 = num5;
						for (int i = 0; i <= num6; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtlPr.Rows[num4][26], (object)Conversion.Val(mSG_PR[DC_Main.i, 80]), false))
							{
								DtIdtlPr.Rows[num4].Delete();
								DtIdtlPr.AcceptChanges();
								num4--;
							}
							num4++;
						}
						MSG_PR_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG_PR[mSG_PR.Row, 1] + "' AND A.CO_BOOK = '" + text + "' AND A.VCH_NO = '" + text2 + "' AND A.SR_NO = " + Conversions.ToString(num3) + " ";
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < RsIdtl.Rows.Count)
						{
							dr = DtIdtlPr.NewRow();
							dr[26] = Conversion.Val(MSG_PR[mSG_PR.Row, 80]);
							dr[0] = DC_Main.i + 1;
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
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.000");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[16] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"])), "0.000");
							dr[25] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtlPr.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						MSG_PR_RowColChange(MSG_PR, new EventArgs());
						MSG_PR_TOT_FILL();
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							CommPassTotal_Pr(mSG_PR.Row);
							MsgOldRow = 0;
							MSG_PR_RowColChange(MSG_PR, new EventArgs());
							MsgClear = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							mSG_PR.Col = 1;
							MsgClear = false;
							CommPassAdd_Pr();
							return;
						}
						break;
					}
					case 2:
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
									mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 82] = DC_Main.ColValue[3];
									mSG_PR[mSG_PR.Row, 68] = DC_Main.ColValue[4];
									mSG_PR[mSG_PR.Row, 81] = DC_Main.ColValue[5];
									mSG_PR[mSG_PR.Row, 84] = DC_Main.ColValue[5];
									mSG_PR[mSG_PR.Row, 85] = DC_Main.ColValue[3];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 82] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG_PR[mSG_PR.Row, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
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
					case 56:
					case 63:
						if (mSG_PR.Col == 56 && Operators.CompareString(TEXT_PR.Text, "", false) != 0)
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
			if (Operators.CompareString(MSG_PR[MSG_PR.Row, 2], "", false) != 0)
			{
				if (StkRow != MSG_PR.Row)
				{
					StkRow = MSG_PR.Row;
					DC_Main.RsQry = "Select IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS NetWt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '" + MSG_PR[MSG_PR.Row, 2] + "'  and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' GROUP BY IT_CODE";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						nitGwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GrWt"]), "0.000");
						nItNwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NetWt"]), "0.000");
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
			case 2:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
			case 67:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 56:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
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
		if (!MsgClear && MSG_PR.Row != 0 && MSG_PR[MSG_PR.Col] != 0 && ((Control)TEXT_PR).Visible)
		{
			AxMSFlexGrid mSG_PR = MSG_PR;
			switch (MSG_PR.Col)
			{
			case 1:
			case 6:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 2:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 0:
			case 3:
			case 4:
			case 5:
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
			MSG_PR[Y, 1] = DC_Main.MsNewTagNo;
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
				if (Operators.CompareString(mSG_PR[Y, 1], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 82], mSG_PR[Y, 82], false) == 0) & (Operators.CompareString(mSG_PR[DC_Main.i, 81], mSG_PR[Y, 81], false) == 0) & (Conversion.Val(mSG_PR[DC_Main.i, 83]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 83]) + 1.0)) > Conversion.Val(CurTagNo))
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
				mSG_PR[mSG_PR.Row, 1] = mSG_PR[Y, 82] + mSG_PR[Y, 81] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
			}
			else
			{
				mSG_PR[mSG_PR.Row, 1] = mSG_PR[Y, 82] + mSG_PR[Y, 81] + CurTagNo;
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
			MSG_PR[Y, 1] = MSG_PR[Y, 82] + MSG_PR[Y, 81] + CurRptTagNo;
			TEXT_PR.Text = MSG_PR[Y, 1];
			dataTable.Clear();
			dataTable.Columns.Clear();
			dataTable2.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
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
		double num = 0.0;
		num = ((Operators.CompareString(DC_Main.MsPrAmtType, "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 12]) : ((Operators.CompareString(DC_Main.MsPrAmtType, "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 21]) : (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]))));
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != Conversion.Val(mSG_PR[mSG_PR.Row, 74])) & (num + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 74] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 25]), "0.00");
			switch (mSG_PR[mSG_PR.Row, 69])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 25]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(num * Conversion.Val(mSG_PR[mSG_PR.Row, 25]), 0), "0.00");
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
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num, DC_Main.MsPrRateRof), "0.00");
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
					double num2 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00"));
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
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / num, DC_Main.MsPrRateRof), "0.00");
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
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) + 100.0) * 100.0, 0), "0.00");
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
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0)
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
		double num3 = 0.0;
		num3 = ((Operators.CompareString(DC_Main.MsPrAmtType, "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 12]) : ((Operators.CompareString(DC_Main.MsPrAmtType, "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 21]) : Conversion.Val(mSG_PR[mSG_PR.Row, 41])));
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 46]) != 0.0) & (num + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 41]) != 0.0))
		{
			switch (mSG_PR[mSG_PR.Row, 69])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 46]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(num3 * (Conversion.Val(mSG_PR[mSG_PR.Row, 46]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(num3 * (Conversion.Val(mSG_PR[mSG_PR.Row, 46]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Math.Round(num3 * Conversion.Val(mSG_PR[mSG_PR.Row, 46]), 0), "0.00");
				break;
			}
		}
		mSG_PR[mSG_PR.Row, 52] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 50]) + Conversion.Val(mSG_PR[mSG_PR.Row, 51]) + Conversion.Val(mSG_PR[mSG_PR.Row, 47])), "0.000");
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 53]) != Conversion.Val(mSG_PR[mSG_PR.Row, 89])) & (Conversion.Val(mSG_PR[mSG_PR.Row, 52]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 89] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 53]), "0.00");
			mSG_PR[mSG_PR.Row, 54] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 52]) * (1.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 53]) / 100.0)), "0.00");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 100]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 98] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 43]), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 100]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 99] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 44]), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 100]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 100] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 45]), "0.000");
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
			nPartyFine.Text = Conversions.ToString(PurcAcFine);
			mSG_PR_TOT = null;
		}
	}

	private void TR_WH_SALE_RTN_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_119f: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ae: Expected O, but got Unknown
		//IL_11d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e2: Expected O, but got Unknown
		//IL_1207: Unknown result type (might be due to invalid IL or missing references)
		//IL_120c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1216: Expected O, but got Unknown
		//IL_1255: Unknown result type (might be due to invalid IL or missing references)
		//IL_125a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1264: Expected O, but got Unknown
		//IL_127e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1283: Unknown result type (might be due to invalid IL or missing references)
		//IL_128d: Expected O, but got Unknown
		//IL_12a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b6: Expected O, but got Unknown
		//IL_12d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12df: Expected O, but got Unknown
		//IL_1307: Unknown result type (might be due to invalid IL or missing references)
		//IL_130e: Expected O, but got Unknown
		//IL_13e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f3: Expected O, but got Unknown
		//IL_147b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1480: Unknown result type (might be due to invalid IL or missing references)
		//IL_148a: Expected O, but got Unknown
		//IL_1523: Unknown result type (might be due to invalid IL or missing references)
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_152e: Expected O, but got Unknown
		//IL_15b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c7: Expected O, but got Unknown
		//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fb: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj13 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj14 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL2 = MSG_PR_IDTL;
				object? obj16 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR_IDTL2.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL3 = MSG_PR_IDTL;
				object? obj17 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR_IDTL3.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				Panel pnlPrIdtl = PnlPrIdtl;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)pnlPrIdtl).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj23 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj25 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj26 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj27 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj28 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj29 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL4 = MSG_PR_IDTL;
				object? obj30 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL4.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL5 = MSG_PR_IDTL;
				object? obj31 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR_IDTL5.BackColorBkg = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL6 = MSG_PR_IDTL;
				object? obj32 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR_IDTL6.BackColorFixed = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj33 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj34 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj35 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj35 != null) ? ((Color)obj35) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				Panel pnlPrIdtl2 = PnlPrIdtl;
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)pnlPrIdtl2).BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj38 = lblBook;
				object? obj39 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj38).ForeColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj40 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj41 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj42 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj43 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj44 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj45 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj46 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL7 = MSG_PR_IDTL;
				object? obj47 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL7.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL8 = MSG_PR_IDTL;
				object? obj48 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR_IDTL8.BackColorBkg = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL9 = MSG_PR_IDTL;
				object? obj49 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR_IDTL9.BackColorFixed = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj50 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj51 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj52 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj53 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_PR_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_PR).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
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
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
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
			DC_Main.RsQry = "SELECT DATA_TYPE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.CurBook + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				BookDataType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DATA_TYPE"], (object)""));
				if (Operators.CompareString(BookDataType, "", false) == 0)
				{
					BookDataType = "A";
				}
			}
			TblData = "RATE_CUT_DATA";
			TblDetl = "RATE_CUT_REC";
			TblIdtl = "SL_IDTL";
			((Control)Label14).Visible = true;
			((Control)nPartyFine).Visible = true;
			((Control)Label5).Visible = true;
			((Control)tSlBill).Visible = true;
			((Control)tSlBill_DbCd).Visible = true;
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
		if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
		{
			CurRatePar = "T";
		}
		else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
		{
			CurRatePar = "K";
		}
		else
		{
			CurRatePar = "G";
		}
		PicImage.Image = null;
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
		AcGstType = "L";
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		MSG_PR_CLEAR();
		MSG_PR_IDTL_CLEAR();
		MSG2_CLEAR();
		OldTagItm = "";
		DtIdtlPr.Clear();
		DtIdtlPr.Reset();
		FilRowPr = 0;
		checked
		{
			int num = MSG_PR_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
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
			CommPassAdd_Pr();
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

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
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_NET_AMT"]), "0.00"));
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_TOT_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CARD_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["SL_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[6, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SL_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[7, 3] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[3, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[3, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
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
				CurRatePar = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["RATE_PAR"], (object)""));
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
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 10] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
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
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 84] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 82] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 85] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_PCS"])), "0");
					mSG_PR[DC_Main.i + 1, 91] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 92] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 93] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 105] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OLD_VCH_SRNO"])), "0");
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
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
					mSG_PR[DC_Main.i + 1, 94] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 95] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 99] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 100] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 101] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 102] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 103] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 104] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_COST"])), "0.00");
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
					double num3 = Conversion.Val(mSG_PR[DC_Main.i + 1, 9]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 10]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 12]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 21]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 41]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 45]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 27]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 30]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 31]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 34]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 35]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 57]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 59]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 61]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 63]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 80]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 40]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 41]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 43]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 44]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 51]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 45]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 48]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 49]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 50]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 54]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 46]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 47]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 52]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 53]);
					string text = "";
					text = mSG_PR[DC_Main.i + 1, 2] + mSG_PR[DC_Main.i + 1, 4] + mSG_PR[DC_Main.i + 1, 5] + mSG_PR[DC_Main.i + 1, 8] + mSG_PR[DC_Main.i + 1, 1];
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
					drPr[26] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
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
					drPr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					drPr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					drPr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					drPr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					drPr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					drPr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					drPr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					drPr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					drPr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
					drPr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					drPr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.000");
					drPr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					drPr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					drPr[16] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					drPr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
					drPr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
					drPr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					drPr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					drPr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					drPr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					drPr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					drPr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					drPr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"])), "0.000");
					drPr[25] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					double num7 = 0.0;
					num7 = Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"]));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]));
					string text2 = "";
					text2 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], Operators.AddObject((object)"", RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"])), Operators.AddObject((object)"", RsIdtl.Rows[DC_Main.i]["IT_TYPE"])), (object)""));
					drPr[28] = Strings.Format((object)num7, "0.000");
					drPr[29] = text2;
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				((Control)TEXT_PR_IDTL).Visible = false;
				OldValTot = Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR_TOT[0, 30]);
				NewValTot = Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR_TOT[0, 30]);
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

	private void TR_WH_SALE_RTN_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_WH_SALE_RTN_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_4748: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int m = default(int);
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
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
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
						ProjectData.ClearProjectError();
						num2 = 2;
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
							dataRow2["DR_AMT"] = 0;
							dataRow2["CR_FINE"] = 0;
							dataRow2["CR_AMT"] = 0;
							dataRow2["DR_FINE"] = 0;
							dataRow2["CONV_RATE"] = 0;
							dataRow2["CONV_PRC"] = 0;
							dataRow2["RATE_PAR"] = CurRatePar;
							dataRow2["FINE_RATE"] = 0;
							dataRow2["SL_FINE"] = Conversion.Val(MSG_PR_TOT[0, 33]) + Conversion.Val(nPartyFine.Text);
							dataRow2["PR_FINE"] = 0;
							dataRow2["TOT_FINE_CR"] = 0;
							dataRow2["TOT_FINE_DR"] = Conversion.Val(MSG_PR_TOT[0, 33]) + Conversion.Val(nPartyFine.Text);
							dataRow2["KSR_FINE_CR"] = 0;
							dataRow2["KSR_FINE_DR"] = 0;
							dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
							dataRow2["SILVER_FINE_DR"] = 0;
							dataRow2["SILVER_FINE_CR"] = 0;
							dataRow2["SLV_FINE_CR"] = 0;
							dataRow2["SLV_FINE_DR"] = 0;
							dataRow2["SLV_AMT_CR"] = 0;
							dataRow2["SLV_AMT_DR"] = 0;
							dataRow2["SLV_FINE_RATE"] = 0;
							dataRow2["PR_ITM_AMT"] = 0;
							dataRow2["PR_LBR_AMT"] = 0;
							dataRow2["PR_OTH_AMT"] = 0;
							dataRow2["PR_NET_AMT"] = 0;
							dataRow2["PR_TAX_AMT"] = 0;
							dataRow2["PR_TOT_AMT"] = 0;
							dataRow2["PR_CHQ_AMT"] = 0;
							dataRow2["PR_CARD_AMT"] = 0;
							dataRow2["PR_ADV_AMT"] = 0;
							dataRow2["PR_CASH_AMT"] = 0;
							dataRow2["PR_KASAR_AMT"] = 0;
							dataRow2["PR_BILL_OS"] = 0;
							dataRow2["TAX_PRC"] = 0;
							dataRow2["SL_ITM_AMT"] = Conversion.Val(MSG_PR_TOT[0, 26]);
							dataRow2["SL_LBR_AMT"] = Conversion.Val(MSG_PR_TOT[0, 30]);
							dataRow2["SL_OTH_AMT"] = Conversion.Val(MSG_PR_TOT[0, 31]) - PrOthAmtLess;
							dataRow2["SL_NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
							dataRow2["SL_TAX_AMT"] = 0;
							dataRow2["SL_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
							dataRow2["SL_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
							dataRow2["SL_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
							dataRow2["SL_ADV_AMT"] = 0;
							dataRow2["SL_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
							dataRow2["SL_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
							dataRow2["SL_BILL_OS"] = Conversion.Val(MSG2_TOTAL[7, 3]);
							dataRow2["CARD_AC"] = MSG2_TOTAL[4, 4];
							dataRow2["BANK_AC"] = MSG2_TOTAL[3, 4];
							dataRow2["CHQ_NO"] = MSG2_TOTAL[3, 2];
							dataRow2["ADD1"] = tAdd1.Text;
							dataRow2["ADD2"] = tAdd2.Text;
							dataRow2["ADD3"] = tAdd3.Text;
							dataRow2["CITY"] = tCity.Text;
							dataRow2["MOBILE"] = tMobile.Text;
							dataRow2["CR_DAYS"] = 0;
							dataRow2["INT_DAYS"] = 0;
							dataRow2["INT_PRC_FINE"] = 0;
							dataRow2["INT_FINE"] = 0;
							dataRow2["EMP_CODE"] = tEmpCode.Text;
							dataRow2["VCH_DESC"] = tVchDesc.Text;
							dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
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
							dataRow2["USER_UPDATE"] = "N";
							dataRow2["USER_DELETE"] = "N";
							dataRow2["MOB_ENTRY_SAVE"] = "Y";
							dataRow2["TDS_PRC"] = 0;
							dataRow2["PR_TDS_AMT"] = 0;
							dataRow2["SL_TDS_AMT"] = 0;
							dataRow2["VP_AMT"] = 0;
							dataRow2["VP_INS_AMT"] = 0;
							dataRow2["VP_CHARG_AMT"] = 0;
							dataRow2["VP_ADJ_AMT"] = 0;
							RsData.Rows.Add(dataRow2);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
							RsData.Clear();
						}
						int num3 = MSG_PR.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							AxMSFlexGrid mSG_PR = MSG_PR;
							DC_Main.ExeQuteDc(("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i, 0]))) ?? "");
							DC_Main.RsQry = "SELECT * FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i, 0])) + " ";
							RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow3 = RsDetl.NewRow();
							if ((Conversion.Val(MSG_PR[DC_Main.i, 15]) + Conversion.Val(MSG_PR[DC_Main.i, 38]) + Conversion.Val(MSG_PR[DC_Main.i, 54]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 2], "", false) != 0))
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
								dataRow3["IT_CODE"] = mSG_PR[DC_Main.i, 2];
								dataRow3["ITM_REMARK"] = mSG_PR[DC_Main.i, 3];
								dataRow3["TBL_CODE"] = mSG_PR[DC_Main.i, 4];
								dataRow3["DESIGN_NO"] = mSG_PR[DC_Main.i, 5];
								dataRow3["ITM_STYLE"] = mSG_PR[DC_Main.i, 6];
								dataRow3["ITM_COLOR"] = mSG_PR[DC_Main.i, 7];
								dataRow3["ITM_SIZE"] = mSG_PR[DC_Main.i, 8];
								dataRow3["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
								if (Operators.CompareString(mSG_PR[DC_Main.i, 1], "", false) == 0)
								{
									dataRow3["TAG_NO"] = "N";
								}
								else
								{
									dataRow3["TAG_NO"] = mSG_PR[DC_Main.i, 1];
								}
								dataRow3["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
								dataRow3["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
								dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
								dataRow3["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
								dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
								dataRow3["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
								dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
								dataRow3["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
								dataRow3["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
								dataRow3["LBR_TYPE"] = mSG_PR[DC_Main.i, 28];
								dataRow3["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
								dataRow3["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
								dataRow3["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
								dataRow3["ITM_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
								dataRow3["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 33]);
								dataRow3["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 25]);
								dataRow3["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
								dataRow3["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 35]);
								dataRow3["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 36]);
								dataRow3["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 37]);
								dataRow3["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 38]);
								dataRow3["RATE_TYPE"] = mSG_PR[DC_Main.i, 69];
								dataRow3["IT_TYPE"] = mSG_PR[DC_Main.i, 68];
								dataRow3["DESIGN_IMG_ID"] = mSG_PR[DC_Main.i, 86];
								dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								dataRow3["WITH_STOCK"] = "Y";
								dataRow3["ISU_NO"] = tSlBill.Text;
								dataRow3["ISU_LC_CODE"] = DC_Main.MLc_code;
								dataRow3["ISU_YRCD"] = tSlBillYrCd.Text;
								dataRow3["ISU_DBCD"] = tSlBill_DbCd.Text;
								dataRow3["MAIN_USER"] = MainUser;
								dataRow3["FINE_CUT_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 90]);
								dataRow3["FINE_CUT_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 91]);
								dataRow3["FINE_CUT_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 92]);
								dataRow3["FINE_CUT_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 93]);
								dataRow3["TAG_TYPE"] = mSG_PR[DC_Main.i, 68];
								dataRow3["PR_CODE"] = mSG_PR[DC_Main.i, 82];
								dataRow3["TAG_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 40]);
								dataRow3["TAG_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 41]);
								dataRow3["TAG_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 43]);
								dataRow3["TAG_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 44]);
								dataRow3["TAG_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 45]);
								dataRow3["TAG_LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 48]);
								dataRow3["TAG_LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 49]);
								dataRow3["TAG_LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 50]);
								dataRow3["TAG_OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 51]);
								dataRow3["TAG_COST"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
								dataRow3["TAG_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 54]);
								dataRow3["KR_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
								dataRow3["KR_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
								dataRow3["KR_GHT_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 16]);
								dataRow3["KR_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
								dataRow3["KR_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
								dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
								dataRow3["KR_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
								dataRow3["KR_LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
								dataRow3["KR_LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
								dataRow3["KR_OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
								dataRow3["KR_COST"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
								dataRow3["OLD_VCH_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 105]);
								dataRow3["KR_NAME"] = mSG_PR[DC_Main.i, 56];
								if (Conversion.Val(mSG_PR[DC_Main.i, 67]) == 0.0)
								{
									mSG_PR[DC_Main.i, 67] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Strings.Format((object)Conversion.Val(tVchNo.Text), "0000") + Strings.Format((object)Conversion.Val(mSG_PR[DC_Main.i, 80]), "000");
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
								RsDetl.Rows.Add(dataRow3);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
							}
							mSG_PR = null;
							DC_Main.i++;
						}
						int num4 = 0;
						int num5 = DtIdtlPr.Rows.Count - 1;
						for (int i = 0; i <= num5; i++)
						{
							DC_Main.ExeQuteDc(("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][26]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])))) ?? "");
							DC_Main.RsQry = ("SELECT * FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][26]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])))) ?? "";
							RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow4 = RsIdtl.NewRow();
							DataTable dtIdtlPr = DtIdtlPr;
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][14])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][23])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][18])) != 0.0)
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
								dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][26]));
								dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0]));
								dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][1]);
								dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3]);
								dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][4]);
								dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5]);
								dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6]);
								dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][7]);
								dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][8]);
								dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][9]);
								dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][10]));
								dataRow4["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][11]));
								dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][12]));
								dataRow4["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][13]));
								dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][14]));
								dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][15]));
								dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][16]);
								dataRow4["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][17]));
								dataRow4["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][18]));
								dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19]));
								dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][20]));
								dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][21]));
								dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][22]));
								dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][23]));
								dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][24]));
								dataRow4["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][27]));
								dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][25]);
								dataRow4["MAIN_USER"] = MainUser;
								RsIdtl.Rows.Add(dataRow4);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
								RsIdtl.Clear();
							}
							dtIdtlPr = null;
						}
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
							dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
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
							int num6 = MSG_PR.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num6)
							{
								AxMSFlexGrid mSG_PR2 = MSG_PR;
								if ((Conversion.Val(MSG_PR[DC_Main.i, 10]) + Conversion.Val(MSG_PR[DC_Main.i, 15]) + Conversion.Val(MSG_PR[DC_Main.i, 35]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
								{
									DC_Main.ExeQuteDc(("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR2[DC_Main.i, 0]))) ?? "");
									DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR2[DC_Main.i, 0])) + " ";
									RsBarDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									DC_Main.MsInsertData();
									DataRow dataRow6 = RsBarDetl.NewRow();
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
									dataRow6["IT_CODE"] = mSG_PR2[DC_Main.i, 2];
									if (Operators.CompareString(mSG_PR2[DC_Main.i, 1], "", false) == 0)
									{
										dataRow6["TAG_NO"] = "N";
									}
									else
									{
										dataRow6["TAG_NO"] = mSG_PR2[DC_Main.i, 1];
									}
									dataRow6["TBL_CODE"] = mSG_PR2[DC_Main.i, 4];
									dataRow6["DESIGN_NO"] = mSG_PR2[DC_Main.i, 5];
									dataRow6["ITM_STYLE"] = mSG_PR2[DC_Main.i, 6];
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
									dataRow6["MAIN_MARGIN_PRC"] = 0;
									dataRow6["ITM_MARGIN"] = 0;
									dataRow6["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 46]);
									dataRow6["ITM_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 47]);
									dataRow6["TAG_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 52]);
									dataRow6["ITM_MARGIN"] = Conversion.Val(mSG_PR2[DC_Main.i, 53]);
									dataRow6["ITM_MRP"] = Conversion.Val(mSG_PR2[DC_Main.i, 54]);
									dataRow6["KR_NAME"] = mSG_PR2[DC_Main.i, 56];
									dataRow6["KR_OTH_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 94]);
									dataRow6["KR_NET_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 95]);
									dataRow6["KR_GHT_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 96]);
									dataRow6["KR_GHT_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 97]);
									dataRow6["KR_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 98]);
									dataRow6["KR_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 99]);
									dataRow6["KR_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 100]);
									dataRow6["KR_LBR_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 101]);
									dataRow6["KR_LBR_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 102]);
									dataRow6["KR_OTH_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 103]);
									dataRow6["KR_COST"] = Conversion.Val(mSG_PR2[DC_Main.i, 104]);
									dataRow6["ITM_REMARK"] = "";
									dataRow6["TAG_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 83]);
									dataRow6["RATE_TYPE"] = mSG_PR2[DC_Main.i, 69];
									dataRow6["IT_TYPE"] = mSG_PR2[DC_Main.i, 68];
									dataRow6["TAG_TYPE"] = mSG_PR2[DC_Main.i, 68];
									dataRow6["PR_CODE"] = mSG_PR2[DC_Main.i, 82];
									dataRow6["VCH_SRNO"] = Conversion.Val(mSG_PR2[DC_Main.i, 67]);
									if (Operators.CompareString(mSG_PR2[DC_Main.i, 64], "", false) == 0)
									{
										mSG_PR2[DC_Main.i, 64] = "N";
									}
									dataRow6["APR_ISU"] = mSG_PR2[DC_Main.i, 64];
									dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow6["DATA_TRFR"] = "N";
									if (Operators.CompareString(mSG_PR2[DC_Main.i, 66], "", false) == 0)
									{
										mSG_PR2[DC_Main.i, 66] = "A";
									}
									dataRow6["DATA_TYPE"] = mSG_PR2[DC_Main.i, 66];
									dataRow6["HM_ID"] = mSG_PR2[DC_Main.i, 55];
									dataRow6["HM_ID2"] = mSG_PR2[DC_Main.i, 58];
									dataRow6["HM_ID3"] = mSG_PR2[DC_Main.i, 60];
									dataRow6["HM_ID4"] = mSG_PR2[DC_Main.i, 62];
									dataRow6["HM_ID_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 57]);
									dataRow6["HM_ID2_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 59]);
									dataRow6["HM_ID3_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 61]);
									dataRow6["HM_ID4_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 63]);
									dataRow6["SF_NO"] = "";
									dataRow6["JDT_JDT_WT"] = 0;
									dataRow6["JDT_GHT_WT"] = 0;
									dataRow6["JDT_KUN_WT"] = 0;
									dataRow6["JDT_KUN_TOUCH"] = 0;
									dataRow6["JDT_KUN_NET"] = 0;
									dataRow6["JDT_WAX_WT"] = 0;
									dataRow6["KR_WAX_WT"] = 0;
									if (Operators.CompareString(mSG_PR2[DC_Main.i, 65], "", false) == 0)
									{
										mSG_PR2[DC_Main.i, 65] = "N";
									}
									dataRow6["EMP_ISU"] = mSG_PR2[DC_Main.i, 65];
									dataRow6["MAIN_USER"] = MainUser;
									dataRow6["DATA_TRFR"] = "N";
									dataRow6["MAIN_USER"] = MainUser;
									RsBarDetl.Rows.Add(dataRow6);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsBarDetl);
									RsBarDetl.Clear();
								}
								mSG_PR2 = null;
								DC_Main.i++;
							}
							int num7 = DtIdtlPr.Rows.Count - 1;
							for (int j = 0; j <= num7; j++)
							{
								DC_Main.ExeQuteDc(("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][26]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0])))) ?? "");
								DC_Main.RsQry = ("SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][26]))) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0])))) ?? "";
								RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.MsInsertData();
								DataRow dataRow7 = RsIdtl.NewRow();
								DataTable dtIdtlPr2 = DtIdtlPr;
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][14])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][23])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][18])) != 0.0)
								{
									int num8 = MSG_PR.Rows - 1;
									DC_Main.M = 1;
									while (DC_Main.M <= num8)
									{
										if (Conversion.Val(MSG_PR[DC_Main.M, 80]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][26])))
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
									dataRow7["TAG_NO"] = MSG_PR[m, 1];
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
									dataRow7["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][10]));
									dataRow7["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][11]));
									dataRow7["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][14]));
									dataRow7["KR_ACT_WT"] = 0;
									dataRow7["KR_ACT_PRC"] = 0;
									dataRow7["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][12]));
									dataRow7["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][13]));
									dataRow7["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][15]));
									dataRow7["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][16]);
									dataRow7["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][19]));
									dataRow7["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][20]));
									dataRow7["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][17]));
									dataRow7["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][18]));
									dataRow7["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][21]));
									dataRow7["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][22]));
									dataRow7["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][23]));
									dataRow7["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][24]));
									dataRow7["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][24]));
									dataRow7["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][25]);
									dataRow7["MAIN_USER"] = MainUser;
									RsIdtl.Rows.Add(dataRow7);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
									RsIdtl.Clear();
								}
								dtIdtlPr2 = null;
							}
						}
						int num9 = MSG_PR.Rows - 1;
						for (int k = 1; k <= num9; k++)
						{
							AxMSFlexGrid mSG_PR3 = MSG_PR;
							if ((Conversion.Val(MSG_PR[k, 10]) + Conversion.Val(MSG_PR[k, 15]) + Conversion.Val(MSG_PR[k, 35]) != 0.0) & (Operators.CompareString(MSG_PR[k, 1], "", false) != 0))
							{
								Mobile_image_Save(k);
							}
							mSG_PR3 = null;
						}
						DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Ledr.Wh_Sales_Rtn_Ledr(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Rojmel.Wh_Sales_Rtn_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Stock.Wh_Sale_Rtn_Stk(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Stock.Dm_Purc_Detl(DC_Main.MCo_Book, tVchNo.Text);
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							CLEAR_DATA();
							((Form)this).Close();
							goto end_IL_0001;
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
						goto end_IL_0001;
					}
					case 18256:
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
				try0001_dispatch = 18256;
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
	private void Mobile_image_Save(int ImgRow)
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		AxMSFlexGrid mSG_PR = MSG_PR;
		string text = mSG_PR[ImgRow, 1] + "_" + mSG_PR[ImgRow, 67];
		DC_Main.MsImageNo = mSG_PR[ImgRow, 1] + "_" + mSG_PR[ImgRow, 105];
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
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + mSG_PR[ImgRow, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[ImgRow, 105]))) ?? "";
			RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			if (RsImg.Rows.Count > 0)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
				{
					PicImage.Image = null;
					return;
				}
				object obj = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
				byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
				object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
				PicImage.Image = (Image)objectValue;
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
		}
		if (PicImage.Image != null)
		{
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + mSG_PR[ImgRow, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[ImgRow, 105]))) ?? "";
			DC_Main.Rshlp = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG_PR[ImgRow, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[ImgRow, 67]))) ?? "";
				DC_Main.ExeQuteImg(DC_Main.RsQry);
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG_PR[ImgRow, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[ImgRow, 67]))) ?? "";
				RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow = RsImg.NewRow();
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["LC_CODE"] = DC_Main.MLc_code;
				dataRow["TAG_NO"] = mSG_PR[ImgRow, 1];
				dataRow["VCH_SRNO"] = Conversion.Val(mSG_PR[ImgRow, 67]);
				dataRow["IMAGE_TYPE"] = "T";
				dataRow["MOB_IMAGE"] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MOB_IMAGE"]);
				RsImg.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
				RsImg.Clear();
			}
		}
		mSG_PR = null;
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_WH_SALE_RTN_KeyDown(object sender, KeyEventArgs e)
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
				MSG2_TOTAL.Row = 3;
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
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT,ITM_COLOR,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,IMAGE_ID,ITM_LOT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT,ITM_COLOR,  '','','','',0,0,0,0,'',ITM_LOT  FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		Cr[(short)0] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)1] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		Cr[(short)2] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
		Cr[(short)3] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
		Cr[(short)4] = ("OpSilver = " + Strings.Format((object)CustOpSilver, "0.00")) ?? "";
		Cr[(short)5] = ("ClSilver = " + Strings.Format((object)CustClSilver, "0.00")) ?? "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesRtnBill.RPT";
		Cr.SelectionFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
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

	private void TR_WH_SALE_RTN_Activated(object sender, EventArgs e)
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
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,BILL_NO As RefNoL,A.VCH_DESC As VchDescL,TOT_FINE_DR As FineW,SL_NET_AMT As TotAmtR FROM " + TblData + " AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
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

	private void TR_WH_SALE_RTN_Closed(object sender, EventArgs e)
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
				switch (DC_Main.i)
				{
				case 0:
				case 2:
				case 7:
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
						object? obj4 = colorConverter.ConvertFromString("Cornsilk");
						obj3.CellBackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj5 = mSG2_TOTAL;
						object? obj6 = colorConverter.ConvertFromString("255, 224, 192");
						obj5.CellBackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
					}
					break;
				case 3:
				case 4:
				case 5:
				case 6:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					break;
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
					mSG2_TOTAL[DC_Main.i] = 0;
					break;
				}
				DC_Main.i++;
			}
			while (DC_Main.i <= 13);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[8, 0] = "Tax Amt : ";
			mSG2_TOTAL[9, 0] = "Tcs Amt : ";
			mSG2_TOTAL[10, 0] = "Tds Amt : ";
			mSG2_TOTAL[11, 0] = "Hm Amt : ";
			mSG2_TOTAL[12, 0] = "Hm Tax : ";
			mSG2_TOTAL[13, 0] = "Rof Amt : ";
			mSG2_TOTAL[2, 0] = "Total Amt : ";
			mSG2_TOTAL[3, 0] = "Cheque Amt : ";
			mSG2_TOTAL[4, 0] = "Card Amt : ";
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
			switch (MSG2_TOTAL.Col)
			{
			case 1:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 50;
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 7))
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
				if ((mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 4))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8))
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
					if ((mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 4))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 7))
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
			if ((mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 4))
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
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Unknown result type (might be due to invalid IL or missing references)
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
					if (((mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 4)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 3)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 4)
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
					if (mSG2_TOTAL.Row == 8)
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
										mSG2_TOTAL[8, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
										mSG2_TOTAL[8, 4] = DC_Main.ColValue[2];
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
									mSG2_TOTAL.Row = 9;
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
								mSG2_TOTAL.Row = 9;
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
							mSG2_TOTAL.Row = 9;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 9)
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
										mSG2_TOTAL[9, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										mSG2_TOTAL[9, 4] = DC_Main.ColValue[2];
										OldNetAmt = 0.0;
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										OldNetAmt = 0.0;
										mSG2_TOTAL[9, 1] = "";
										mSG2_TOTAL[9, 2] = "";
										mSG2_TOTAL[9, 3] = "";
										mSG2_TOTAL[9, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 10;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[9, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[9, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 10;
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
							mSG2_TOTAL.Row = 10;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 10)
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
										mSG2_TOTAL[10, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										mSG2_TOTAL[10, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										mSG2_TOTAL[10, 1] = "";
										mSG2_TOTAL[10, 2] = "";
										mSG2_TOTAL[10, 3] = "";
										mSG2_TOTAL[10, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 12;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[13, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[13, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 12;
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
							mSG2_TOTAL.Row = 12;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row != 12)
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
									mSG2_TOTAL[12, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									mSG2_TOTAL[12, 4] = DC_Main.ColValue[2];
									BILL_TOTAL();
								}
								else
								{
									TEXT_ENTRY_2.Text = "";
									mSG2_TOTAL[12, 1] = "";
									mSG2_TOTAL[12, 2] = "";
									mSG2_TOTAL[12, 3] = "";
									mSG2_TOTAL[12, 4] = "";
								}
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 13;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[12, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
							mSG2_TOTAL[12, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 13;
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
						mSG2_TOTAL.Row = 13;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 13:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 2;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 5:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 3:
					case 4:
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
		mSG2_TOTAL[11, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 39]), 0), "0.00");
		if (Conversion.Val(mSG2_TOTAL[12, 2]) != 0.0)
		{
			mSG2_TOTAL[12, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[11, 3]) * Conversion.Val(mSG2_TOTAL[12, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		mSG2_TOTAL[0, 3] = Strings.Format((object)(Math.Round(Conversion.Val(MSG_PR_TOT[0, 38]), 0) - PrOthAmtLess), "0.00");
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_PR_TOT[0, 30]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
		}
		if (OldNetAmt != Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00")))
		{
			OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00"));
			mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[8, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			mSG2_TOTAL[9, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[8, 3])) * Conversion.Val(mSG2_TOTAL[9, 2]) / 100.0, 0), "0.00");
		}
		if (Conversion.Val(mSG2_TOTAL[10, 2]) != 0.0)
		{
			if ((Conversion.Val(mSG2_TOTAL[10, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
			{
				mSG2_TOTAL[10, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[10, 2]) / 100.0, 0), "0.00");
			}
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - (Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[10, 3])) + Conversion.Val(mSG2_TOTAL[13, 3]) + Conversion.Val(mSG2_TOTAL[11, 3]) + Conversion.Val(mSG2_TOTAL[12, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(mSG2_TOTAL[9, 3]), 0), "0.00");
		}
		else
		{
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[13, 3]) + Conversion.Val(mSG2_TOTAL[11, 3]) + Conversion.Val(mSG2_TOTAL[12, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(mSG2_TOTAL[9, 3]), 0), "0.00");
		}
		mSG2_TOTAL[7, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3])), "0.00");
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]), 0), "0.00");
		}
		if (Operators.CompareString(FormMainBook, "WH RTN", false) == 0)
		{
			if (Conversion.Val(nPartyFine.Text) != 0.0)
			{
				CustClAmt = CustOpAmt;
			}
			else if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[7, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[7, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[7, 3]);
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
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[7, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[7, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[7, 3]);
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
			((Control)tEmpCode).Focus();
		}
	}

	private void TR_WH_SALE_RTN_KeyUp(object sender, KeyEventArgs e)
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

	private void BtnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,B.BOOK_NAME As BookL,A.SL_NET_AMT As BillAmtR,A.CO_YEAR As YearL,A.CO_BOOK As CoBookL,A.TOT_FINE_DR As SlFineW,A.AC_CODE AS AcCodeL,A.AC_NAME As AcNameL FROM  RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.MAIN_BOOK IN ('WH SALES','TOUR SALES') AND A.TOT_FINE_DR+A.SL_NET_AMT <> 0  ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[11];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 150.0;
		DC_Main.ColWidth[4] = 110.0;
		DC_Main.ColWidth[5] = 0.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 110.0;
		DC_Main.ColWidth[8] = 0.0;
		DC_Main.ColWidth[9] = 0.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tSlBill.Text = DC_Main.ColValue[0];
				tSlBillYrCd.Text = DC_Main.ColValue[5];
				tSlBill_DbCd.Text = DC_Main.ColValue[6];
				tAcCode.Text = DC_Main.ColValue[8];
				tAcName.Text = DC_Main.ColValue[9];
				((Control)tSlBill).Focus();
			}
			else
			{
				((Control)tSlBill).Focus();
			}
		}
	}

	private void TSlBill_TextChanged(object sender, EventArgs e)
	{
	}

	private void tSlBill_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tSlBill.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tSlBillYrCd.Text + "' AND A.CO_BOOK = '" + tSlBill_DbCd.Text + "' AND A.VCH_NO = '" + tSlBill.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				BtnIsuNo_Click(btnIsuNo, new EventArgs());
				return;
			}
			tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ADD1"], (object)""));
			tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ADD2"], (object)""));
			tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ADD3"], (object)""));
			tCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CITY"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MOBILE"], (object)""));
			((Control)tAcCode).Focus();
		}
		else
		{
			((Control)tAcCode).Focus();
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
}
