using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
public class TR_PR_SL_UAE : Form
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
	[AccessedThroughProperty("cboRateFixType")]
	private ComboBox _cboRateFixType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgD")]
	private SimpleButton _BtnImgD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgS")]
	private SimpleButton _BtnImgS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgC")]
	private SimpleButton _BtnImgC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOzRate")]
	private TextBox _nOzRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOzConv")]
	private TextBox _nOzConv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFxRate")]
	private TextBox _nFxRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFxCode")]
	private TextBox _tFxCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMtlRate")]
	private TextBox _nMtlRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnConsiNo")]
	private SimpleButton _btnConsiNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConsiNo")]
	private TextBox _tConsiNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSet")]
	private SimpleButton _btnTagSet;

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

	private string RateFixType;

	private string OldAcCode;

	private string AcGstType;

	private double PurcAcFine;

	private string CurRptTagNo;

	private int StkRow;

	private double PrOthAmtLess;

	private double OldNetAmt;

	private bool PrHalfPrint;

	private string FormPrintFile;

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

	private const int cPrLotNo = 6;

	private const int cPrPcs = 7;

	private const int cPrGrWt = 8;

	private const int cPrOthWt = 9;

	private const int cPrNetWt = 10;

	private const int cPrGhtPrc = 11;

	private const int cPrGhtWt = 12;

	private const int cPrTouch = 13;

	private const int cPrWestPrc = 14;

	private const int cPrLessTch = 15;

	private const int cPrFine = 16;

	private const int cMcxRate = 17;

	private const int cPremium = 18;

	private const int cPremDisc = 19;

	private const int cPrRatWith = 20;

	private const int cPrRate = 21;

	private const int cPrItAmt = 22;

	private const int cPrDiscAmt = 23;

	private const int cPrLbrPrc = 24;

	private const int cPrLbrType = 25;

	private const int cPrLbrRate = 26;

	private const int cPrLbrAmt = 27;

	private const int cPrOthAmt = 28;

	private const int cPrOthRate = 29;

	private const int cPrOthFine = 30;

	private const int cTagCost = 31;

	private const int cPrMrp = 32;

	private const int cPrTotAmt = 33;

	private const int cPrTaxPrc = 34;

	private const int cPrNetAmt = 35;

	private const int cConsiNo = 36;

	private const int cConsiYrCd = 37;

	private const int cConsiDbCd = 38;

	private const int cConsiSrNo = 39;

	private const int cPrColor = 40;

	private const int cPrSize = 41;

	private const int cPrBagWt = 42;

	private const int cPrPcsWt = 43;

	private const int cPrLossWt = 44;

	private const int cPrSilverFine = 45;

	private const int cPrConvRate = 46;

	private const int cPrConvPrc = 47;

	private const int cHmAmt = 48;

	private const int cPrTagSrNo = 49;

	private const int cAprIsu = 50;

	private const int cEmpIsu = 51;

	private const int cDataType = 52;

	private const int cPrItType = 53;

	private const int cPrRateType = 54;

	private const int cPrOldGwt = 55;

	private const int cPrOldNwt = 56;

	private const int cPrOldTouch = 57;

	private const int cPrOldWest = 58;

	private const int cPrOldRate = 59;

	private const int cPrOldLestch = 60;

	private const int cPrHmFine = 61;

	private const int cPrOldLbrRate = 62;

	private const int cPrcOldLbrAmt = 63;

	private const int cPrOldItAmt = 64;

	private const int cPrOldSrNo = 65;

	private const int cTagType = 66;

	private const int cTagPrCode = 67;

	private const int cTagSrNo = 68;

	private const int cOldTagType = 69;

	private const int cOldTagPrCode = 70;

	private const int cDesignImgId = 71;

	private const int cRowValue = 72;

	private const int cRowText = 73;

	private const int cTagOldMargin = 74;

	private const int cPrCutPcs = 75;

	private const int cPrCutGwt = 76;

	private const int cPrCutNwt = 77;

	private const int cPrCutFine = 78;

	private const int cPrVchSrNo = 79;

	private const int cPrOldItCode = 80;

	private const int cPrOldPcs = 81;

	private const int c2SrNo = 0;

	private const int c2ItCode = 1;

	private const int c2ItName = 2;

	private const int c2Pcs = 3;

	private const int c2PcsWt = 4;

	private const int c2KrWt = 5;

	private const int c2KrLsPrc = 6;

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

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cOthAmt2 = 3;

	private const int cOthTax2 = 4;

	private const int cHmAmt2 = 5;

	private const int cHmTax2 = 6;

	private const int cRof2 = 7;

	private const int cTot2 = 8;

	private const int cChq2 = 9;

	private const int cCard2 = 10;

	private const int cCash2 = 11;

	private const int cKasar2 = 12;

	private const int cOs2 = 13;

	private const int cTcs2 = 14;

	private const int cTds2 = 15;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mVchDate_KeyDown);
			MaskInputRejectedEventHandler val2 = new MaskInputRejectedEventHandler(mVchDate_MaskInputRejected);
			MaskedTextBox val3 = _mVchDate;
			if (val3 != null)
			{
				((Control)val3).GotFocus -= eventHandler;
				((Control)val3).KeyDown -= val;
				val3.MaskInputRejected -= val2;
			}
			_mVchDate = value;
			val3 = _mVchDate;
			if (val3 != null)
			{
				((Control)val3).GotFocus += eventHandler;
				((Control)val3).KeyDown += val;
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

	internal virtual ComboBox cboRateFixType
	{
		[CompilerGenerated]
		get
		{
			return _cboRateFixType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboRateFixType_KeyDown);
			ComboBox val2 = _cboRateFixType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboRateFixType = value;
			val2 = _cboRateFixType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual SimpleButton BtnImgD
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgD_Click;
			SimpleButton val = _BtnImgD;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgD = value;
			val = _BtnImgD;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgS
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgS_Click;
			SimpleButton val = _BtnImgS;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgS = value;
			val = _BtnImgS;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgC
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgC_Click;
			SimpleButton val = _BtnImgC;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgC = value;
			val = _BtnImgC;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox nOzRate
	{
		[CompilerGenerated]
		get
		{
			return _nOzRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOzRate_KeyDown);
			TextBox val2 = _nOzRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nOzRate = value;
			val2 = _nOzRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nOzConv
	{
		[CompilerGenerated]
		get
		{
			return _nOzConv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nOzConv_KeyDown);
			TextBox val2 = _nOzConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nOzConv = value;
			val2 = _nOzConv;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblOzConv")]
	private virtual Label _lblOzConv;

	internal virtual Label lblOzConv
	{
		get
		{
			return _lblOzConv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblOzConv = value;
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

	internal virtual TextBox nFxRate
	{
		[CompilerGenerated]
		get
		{
			return _nFxRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFxRate_KeyDown);
			TextBox val2 = _nFxRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFxRate = value;
			val2 = _nFxRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tFxCode
	{
		[CompilerGenerated]
		get
		{
			return _tFxCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tFxCode_KeyDown);
			TextBox val2 = _tFxCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tFxCode = value;
			val2 = _tFxCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nMtlRate
	{
		[CompilerGenerated]
		get
		{
			return _nMtlRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMtlRate_KeyDown);
			TextBox val2 = _nMtlRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMtlRate = value;
			val2 = _nMtlRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("nItPcs")]
	private virtual TextBox _nItPcs;

	internal virtual TextBox nItPcs
	{
		get
		{
			return _nItPcs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nItPcs = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConsiYrCd")]
	private virtual TextBox _tConsiYrCd;

	internal virtual TextBox tConsiYrCd
	{
		get
		{
			return _tConsiYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tConsiYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConsiDbCd")]
	private virtual TextBox _tConsiDbCd;

	internal virtual TextBox tConsiDbCd
	{
		get
		{
			return _tConsiDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tConsiDbCd = value;
		}
	}

	internal virtual SimpleButton btnConsiNo
	{
		[CompilerGenerated]
		get
		{
			return _btnConsiNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnConsiNo_Click;
			SimpleButton val = _btnConsiNo;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnConsiNo = value;
			val = _btnConsiNo;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblConsiNo")]
	private virtual Label _lblConsiNo;

	internal virtual Label lblConsiNo
	{
		get
		{
			return _lblConsiNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblConsiNo = value;
		}
	}

	internal virtual TextBox tConsiNo
	{
		[CompilerGenerated]
		get
		{
			return _tConsiNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tConsiNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tConsiNo_KeyDown);
			TextBox val2 = _tConsiNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tConsiNo = value;
			val2 = _tConsiNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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

	public TR_PR_SL_UAE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((Form)this).Load += TR_PR_SL_UAE_Load;
		((Form)this).Deactivate += TR_PR_SL_UAE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_PR_SL_UAE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_PR_SL_UAE_KeyDown);
		((Form)this).Activated += TR_PR_SL_UAE_Activated;
		((Form)this).Closed += TR_PR_SL_UAE_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_PR_SL_UAE_KeyUp);
		((Control)this).Invalidated += new InvalidateEventHandler(TR_PR_SL_UAE_Invalidated);
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
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Expected O, but got Unknown
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Expected O, but got Unknown
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Expected O, but got Unknown
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected O, but got Unknown
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Expected O, but got Unknown
		//IL_0950: Unknown result type (might be due to invalid IL or missing references)
		//IL_095a: Expected O, but got Unknown
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f3: Expected O, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Expected O, but got Unknown
		//IL_0b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Expected O, but got Unknown
		//IL_0b76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Expected O, but got Unknown
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c33: Expected O, but got Unknown
		//IL_0d50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5a: Expected O, but got Unknown
		//IL_0e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6f: Expected O, but got Unknown
		//IL_0ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edc: Expected O, but got Unknown
		//IL_106e: Unknown result type (might be due to invalid IL or missing references)
		//IL_115d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1167: Expected O, but got Unknown
		//IL_1215: Unknown result type (might be due to invalid IL or missing references)
		//IL_121f: Expected O, but got Unknown
		//IL_12cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d5: Expected O, but got Unknown
		//IL_13cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d7: Expected O, but got Unknown
		//IL_1596: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a0: Expected O, but got Unknown
		//IL_1678: Unknown result type (might be due to invalid IL or missing references)
		//IL_1682: Expected O, but got Unknown
		//IL_171e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1728: Expected O, but got Unknown
		//IL_1863: Unknown result type (might be due to invalid IL or missing references)
		//IL_186d: Expected O, but got Unknown
		//IL_18b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c2: Expected O, but got Unknown
		//IL_193d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1947: Expected O, but got Unknown
		//IL_19c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d3: Expected O, but got Unknown
		//IL_1a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa4: Expected O, but got Unknown
		//IL_1b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b55: Expected O, but got Unknown
		//IL_1bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bdd: Expected O, but got Unknown
		//IL_1c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6f: Expected O, but got Unknown
		//IL_1d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2a: Expected O, but got Unknown
		//IL_1dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de4: Expected O, but got Unknown
		//IL_1e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea3: Expected O, but got Unknown
		//IL_1f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f11: Expected O, but got Unknown
		//IL_1f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f79: Expected O, but got Unknown
		//IL_2018: Unknown result type (might be due to invalid IL or missing references)
		//IL_2022: Expected O, but got Unknown
		//IL_20b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20be: Expected O, but got Unknown
		//IL_2140: Unknown result type (might be due to invalid IL or missing references)
		//IL_214a: Expected O, but got Unknown
		//IL_21e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21f0: Expected O, but got Unknown
		//IL_229e: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a8: Expected O, but got Unknown
		//IL_2495: Unknown result type (might be due to invalid IL or missing references)
		//IL_249f: Expected O, but got Unknown
		//IL_254c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2556: Expected O, but got Unknown
		//IL_25e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ef: Expected O, but got Unknown
		//IL_269d: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a7: Expected O, but got Unknown
		//IL_2736: Unknown result type (might be due to invalid IL or missing references)
		//IL_2740: Expected O, but got Unknown
		//IL_27ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f8: Expected O, but got Unknown
		//IL_28a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b0: Expected O, but got Unknown
		//IL_293f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2949: Expected O, but got Unknown
		//IL_29d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e2: Expected O, but got Unknown
		//IL_2a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a7a: Expected O, but got Unknown
		//IL_2b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b47: Expected O, but got Unknown
		//IL_2b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b9f: Expected O, but got Unknown
		//IL_2c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c5d: Expected O, but got Unknown
		//IL_2d11: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d1b: Expected O, but got Unknown
		//IL_2dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dd9: Expected O, but got Unknown
		//IL_2e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e9a: Expected O, but got Unknown
		//IL_2f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f5b: Expected O, but got Unknown
		//IL_301e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3028: Expected O, but got Unknown
		//IL_3091: Unknown result type (might be due to invalid IL or missing references)
		//IL_309b: Expected O, but got Unknown
		//IL_314c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3156: Expected O, but got Unknown
		//IL_31f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_31ff: Expected O, but got Unknown
		//IL_32ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_32b6: Expected O, but got Unknown
		//IL_336a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3374: Expected O, but got Unknown
		//IL_3405: Unknown result type (might be due to invalid IL or missing references)
		//IL_340f: Expected O, but got Unknown
		//IL_34ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b7: Expected O, but got Unknown
		//IL_355f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3569: Expected O, but got Unknown
		//IL_36a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ac: Expected O, but got Unknown
		//IL_3760: Unknown result type (might be due to invalid IL or missing references)
		//IL_376a: Expected O, but got Unknown
		//IL_381b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3825: Expected O, but got Unknown
		//IL_3984: Unknown result type (might be due to invalid IL or missing references)
		//IL_398e: Expected O, but got Unknown
		//IL_39f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a01: Expected O, but got Unknown
		//IL_3ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ac0: Expected O, but got Unknown
		//IL_3b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b7b: Expected O, but got Unknown
		//IL_3c2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c36: Expected O, but got Unknown
		//IL_3d69: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d73: Expected O, but got Unknown
		//IL_3e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e2e: Expected O, but got Unknown
		//IL_3eb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ec2: Expected O, but got Unknown
		//IL_3f38: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f42: Expected O, but got Unknown
		//IL_3fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fe9: Expected O, but got Unknown
		//IL_4086: Unknown result type (might be due to invalid IL or missing references)
		//IL_4090: Expected O, but got Unknown
		//IL_4141: Unknown result type (might be due to invalid IL or missing references)
		//IL_414b: Expected O, but got Unknown
		//IL_41d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_41df: Expected O, but got Unknown
		//IL_4269: Unknown result type (might be due to invalid IL or missing references)
		//IL_4273: Expected O, but got Unknown
		//IL_42ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_42f7: Expected O, but got Unknown
		//IL_43a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b2: Expected O, but got Unknown
		//IL_4440: Unknown result type (might be due to invalid IL or missing references)
		//IL_444a: Expected O, but got Unknown
		//IL_44e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_44ec: Expected O, but got Unknown
		//IL_45a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_45b1: Expected O, but got Unknown
		//IL_4689: Unknown result type (might be due to invalid IL or missing references)
		//IL_4693: Expected O, but got Unknown
		//IL_472f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4739: Expected O, but got Unknown
		//IL_4847: Unknown result type (might be due to invalid IL or missing references)
		//IL_4851: Expected O, but got Unknown
		//IL_490c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4916: Expected O, but got Unknown
		//IL_499d: Unknown result type (might be due to invalid IL or missing references)
		//IL_49a7: Expected O, but got Unknown
		//IL_4a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a85: Expected O, but got Unknown
		//IL_4b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b64: Expected O, but got Unknown
		//IL_4c00: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c0a: Expected O, but got Unknown
		//IL_4d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d66: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_PR_SL_UAE));
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
		chkHalfPrint = new CheckBox();
		chkBillImage = new CheckBox();
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
		cboItemTyp = new ComboBox();
		Label12 = new Label();
		nPartyFine = new TextBox();
		Label14 = new Label();
		Label15 = new Label();
		nitGwt = new TextBox();
		nItNwt = new TextBox();
		TEXT_PR_IDTL = new TextBox();
		MSG_PR_IDTL = new AxMSFlexGrid();
		pnlBill = new Panel();
		btnBillDel = new SimpleButton();
		btnBillSelect = new SimpleButton();
		btnbillCap = new SimpleButton();
		PicBill = new PictureBox();
		cboRateFixType = new ComboBox();
		Label16 = new Label();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgC = new SimpleButton();
		PicImage = new PictureBox();
		Label5 = new Label();
		nOzRate = new TextBox();
		nOzConv = new TextBox();
		lblOzConv = new Label();
		Label18 = new Label();
		Label19 = new Label();
		nFxRate = new TextBox();
		tFxCode = new TextBox();
		nMtlRate = new TextBox();
		Label17 = new Label();
		nItPcs = new TextBox();
		tConsiYrCd = new TextBox();
		tConsiDbCd = new TextBox();
		btnConsiNo = new SimpleButton();
		lblConsiNo = new Label();
		tConsiNo = new TextBox();
		Label20 = new Label();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((ISupportInitialize)MSG_PR_IDTL).BeginInit();
		((Control)pnlBill).SuspendLayout();
		((ISupportInitialize)PicBill).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
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
		lblBDate.TextAlign = (ContentAlignment)64;
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
		((Control)mDay).Location = new Point(482, 38);
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
		((Control)PnlBotam).TabIndex = 18;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkHalfPrint);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkBillImage);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkHalfPrint).BackColor = Color.Transparent;
		((Control)chkHalfPrint).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHalfPrint).ForeColor = Color.Black;
		((Control)chkHalfPrint).Location = new Point(437, 3);
		((Control)chkHalfPrint).Name = "chkHalfPrint";
		((Control)chkHalfPrint).RightToLeft = (RightToLeft)0;
		((Control)chkHalfPrint).Size = new Size(135, 27);
		((Control)chkHalfPrint).TabIndex = 7;
		((ButtonBase)chkHalfPrint).Text = "Print With Image";
		((ButtonBase)chkHalfPrint).UseVisualStyleBackColor = false;
		((ButtonBase)chkBillImage).BackColor = Color.Transparent;
		((Control)chkBillImage).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBillImage).ForeColor = Color.Black;
		((Control)chkBillImage).Location = new Point(333, 3);
		((Control)chkBillImage).Name = "chkBillImage";
		((Control)chkBillImage).RightToLeft = (RightToLeft)0;
		((Control)chkBillImage).Size = new Size(98, 27);
		((Control)chkBillImage).TabIndex = 6;
		((ButtonBase)chkBillImage).Text = "Bill Image";
		((ButtonBase)chkBillImage).UseVisualStyleBackColor = false;
		((Control)chkBillImage).Visible = false;
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
		((Control)tAcCode).Location = new Point(105, 96);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 9;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(187, 96);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(378, 23);
		((Control)tAcName).TabIndex = 10;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(23, 93);
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
		((Control)tEmpCode).TabIndex = 15;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(152, 436);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
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
		((Control)tVchDesc).Size = new Size(276, 61);
		((Control)tVchDesc).TabIndex = 17;
		((Control)MSG2_TOTAL).Location = new Point(729, 279);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 281);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(13, 124);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1156, 136);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(924, 407);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 14;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(683, 176);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 12;
		((Control)TEXT_PR).Visible = false;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(92, 464);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(276, 23);
		((Control)tBankName).TabIndex = 16;
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
		((Control)PanelAdd).Location = new Point(187, 124);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 152);
		((Control)PanelAdd).TabIndex = 11;
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
		((Control)MSG_PR_TOT).Location = new Point(15, 261);
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
		((Control)LClSilver).Location = new Point(583, 539);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(137, 20);
		((Control)LClSilver).TabIndex = 1213;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(580, 518);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(140, 20);
		((Control)lClGold).TabIndex = 1212;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(580, 495);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(140, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(311, 67);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(78, 22);
		((Control)cboItemTyp).TabIndex = 5;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(222, 67);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(78, 20);
		((Control)Label12).TabIndex = 1218;
		Label12.Text = "Itm Type";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPartyFine).BackColor = Color.White;
		((Control)nPartyFine).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPartyFine).Location = new Point(648, 465);
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
		((Control)Label14).Location = new Point(572, 467);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(69, 20);
		((Control)Label14).TabIndex = 1220;
		Label14.Text = "Party Fine";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label14).Visible = false;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(440, 285);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(66, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Item Wt";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nitGwt).BackColor = Color.White;
		((Control)nitGwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nitGwt).Location = new Point(568, 284);
		((TextBoxBase)nitGwt).MaxLength = 8;
		((Control)nitGwt).Name = "nitGwt";
		((TextBoxBase)nitGwt).ReadOnly = true;
		((Control)nitGwt).Size = new Size(71, 23);
		((Control)nitGwt).TabIndex = 1222;
		((TextBoxBase)nItNwt).BackColor = Color.White;
		((Control)nItNwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItNwt).Location = new Point(644, 284);
		((TextBoxBase)nItNwt).MaxLength = 8;
		((Control)nItNwt).Name = "nItNwt";
		((TextBoxBase)nItNwt).ReadOnly = true;
		((Control)nItNwt).Size = new Size(74, 23);
		((Control)nItNwt).TabIndex = 1223;
		((TextBoxBase)TEXT_PR_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR_IDTL).ForeColor = Color.White;
		((Control)TEXT_PR_IDTL).Location = new Point(359, 357);
		((Control)TEXT_PR_IDTL).Name = "TEXT_PR_IDTL";
		((Control)TEXT_PR_IDTL).Size = new Size(100, 18);
		((Control)TEXT_PR_IDTL).TabIndex = 13;
		((Control)TEXT_PR_IDTL).Visible = false;
		((Control)MSG_PR_IDTL).Location = new Point(13, 314);
		((Control)MSG_PR_IDTL).Name = "MSG_PR_IDTL";
		((AxHost)MSG_PR_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_PR_IDTL.OcxState");
		((Control)MSG_PR_IDTL).Size = new Size(706, 114);
		((Control)MSG_PR_IDTL).TabIndex = 0;
		((Control)pnlBill).BackColor = Color.FromArgb(255, 224, 192);
		pnlBill.BorderStyle = (BorderStyle)1;
		((Control)pnlBill).Controls.Add((Control)(object)btnBillDel);
		((Control)pnlBill).Controls.Add((Control)(object)btnBillSelect);
		((Control)pnlBill).Controls.Add((Control)(object)btnbillCap);
		((Control)pnlBill).Controls.Add((Control)(object)PicBill);
		((Control)pnlBill).Location = new Point(1176, 317);
		((Control)pnlBill).Name = "pnlBill";
		((Control)pnlBill).Size = new Size(213, 242);
		((Control)pnlBill).TabIndex = 22;
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
		((Control)cboRateFixType).AccessibleDescription = "";
		cboRateFixType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboRateFixType).Font = new Font("Tahoma", 9f);
		((ListControl)cboRateFixType).FormattingEnabled = true;
		((Control)cboRateFixType).Location = new Point(482, 67);
		((Control)cboRateFixType).Name = "cboRateFixType";
		((Control)cboRateFixType).Size = new Size(83, 22);
		((Control)cboRateFixType).TabIndex = 6;
		((Control)Label16).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(379, 68);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(100, 20);
		((Control)Label16).TabIndex = 1252;
		Label16.Text = "Rate Fix Typ";
		Label16.TextAlign = (ContentAlignment)64;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(513, 526);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 28);
		((Control)BtnImgD).TabIndex = 21;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(513, 494);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 28);
		((Control)BtnImgS).TabIndex = 20;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(513, 461);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 28);
		((Control)BtnImgC).TabIndex = 19;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(375, 436);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(130, 120);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1253;
		PicImage.TabStop = false;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(579, 41);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(92, 20);
		((Control)Label5).TabIndex = 1257;
		Label5.Text = "Oz Usd Rate";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nOzRate).BackColor = Color.White;
		((Control)nOzRate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nOzRate).Location = new Point(677, 38);
		((TextBoxBase)nOzRate).MaxLength = 8;
		((Control)nOzRate).Name = "nOzRate";
		((Control)nOzRate).Size = new Size(71, 23);
		((Control)nOzRate).TabIndex = 2;
		nOzRate.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nOzConv).BackColor = Color.White;
		((Control)nOzConv).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nOzConv).Location = new Point(677, 67);
		((TextBoxBase)nOzConv).MaxLength = 8;
		((Control)nOzConv).Name = "nOzConv";
		((Control)nOzConv).Size = new Size(71, 23);
		((Control)nOzConv).TabIndex = 7;
		nOzConv.TextAlign = (HorizontalAlignment)1;
		((Control)lblOzConv).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblOzConv).ForeColor = Color.Black;
		lblOzConv.ImeMode = (ImeMode)0;
		((Control)lblOzConv).Location = new Point(579, 69);
		((Control)lblOzConv).Name = "lblOzConv";
		((Control)lblOzConv).Size = new Size(91, 20);
		((Control)lblOzConv).TabIndex = 1259;
		lblOzConv.Text = "Oz Conv";
		lblOzConv.TextAlign = (ContentAlignment)64;
		((Control)Label18).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(739, 68);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(96, 20);
		((Control)Label18).TabIndex = 1261;
		Label18.Text = "Forex Code";
		Label18.TextAlign = (ContentAlignment)64;
		((Control)Label19).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(736, 41);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(99, 20);
		((Control)Label19).TabIndex = 1262;
		Label19.Text = "Forex Rate";
		Label19.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nFxRate).BackColor = Color.White;
		((Control)nFxRate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nFxRate).Location = new Point(841, 38);
		((TextBoxBase)nFxRate).MaxLength = 8;
		((Control)nFxRate).Name = "nFxRate";
		((Control)nFxRate).Size = new Size(71, 23);
		((Control)nFxRate).TabIndex = 3;
		nFxRate.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tFxCode).BackColor = Color.White;
		((Control)tFxCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFxCode).Location = new Point(841, 67);
		((TextBoxBase)tFxCode).MaxLength = 8;
		((Control)tFxCode).Name = "tFxCode";
		((Control)tFxCode).Size = new Size(71, 23);
		((Control)tFxCode).TabIndex = 8;
		tFxCode.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)nMtlRate).BackColor = Color.White;
		((Control)nMtlRate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nMtlRate).Location = new Point(677, 95);
		((TextBoxBase)nMtlRate).MaxLength = 8;
		((Control)nMtlRate).Name = "nMtlRate";
		((Control)nMtlRate).Size = new Size(71, 23);
		((Control)nMtlRate).TabIndex = 1266;
		nMtlRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(579, 96);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(91, 20);
		((Control)Label17).TabIndex = 1265;
		Label17.Text = "1 Gm Rate";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nItPcs).BackColor = Color.White;
		((Control)nItPcs).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItPcs).Location = new Point(513, 285);
		((TextBoxBase)nItPcs).MaxLength = 8;
		((Control)nItPcs).Name = "nItPcs";
		((TextBoxBase)nItPcs).ReadOnly = true;
		((Control)nItPcs).Size = new Size(50, 23);
		((Control)nItPcs).TabIndex = 1267;
		((TextBoxBase)tConsiYrCd).BackColor = Color.White;
		((Control)tConsiYrCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tConsiYrCd).Location = new Point(923, 97);
		((TextBoxBase)tConsiYrCd).MaxLength = 8;
		((Control)tConsiYrCd).Name = "tConsiYrCd";
		((TextBoxBase)tConsiYrCd).ReadOnly = true;
		((Control)tConsiYrCd).Size = new Size(76, 22);
		((Control)tConsiYrCd).TabIndex = 1272;
		((Control)tConsiYrCd).Visible = false;
		((TextBoxBase)tConsiDbCd).BackColor = Color.White;
		((Control)tConsiDbCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tConsiDbCd).Location = new Point(1005, 97);
		((TextBoxBase)tConsiDbCd).MaxLength = 8;
		((Control)tConsiDbCd).Name = "tConsiDbCd";
		((TextBoxBase)tConsiDbCd).ReadOnly = true;
		((Control)tConsiDbCd).Size = new Size(76, 22);
		((Control)tConsiDbCd).TabIndex = 1271;
		((Control)tConsiDbCd).Visible = false;
		((BaseStyleControl)btnConsiNo).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnConsiNo).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnConsiNo).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnConsiNo).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnConsiNo).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnConsiNo).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnConsiNo).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnConsiNo).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnConsiNo).Appearance.Options.UseForeColor = true;
		((BaseButton)btnConsiNo).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnConsiNo).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnConsiNo).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnConsiNo).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnConsiNo).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnConsiNo).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnConsiNo).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnConsiNo).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnConsiNo).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnConsiNo).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnConsiNo).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnConsiNo).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnConsiNo).AppearancePressed.Options.UseFont = true;
		((Control)btnConsiNo).Location = new Point(1087, 96);
		((BaseControl)btnConsiNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnConsiNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnConsiNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnConsiNo).Name = "btnConsiNo";
		((Control)btnConsiNo).Size = new Size(35, 23);
		((Control)btnConsiNo).TabIndex = 1270;
		btnConsiNo.Text = "F1";
		((BaseControl)btnConsiNo).ToolTip = "Voucher Help";
		((Control)btnConsiNo).Visible = false;
		((Control)lblConsiNo).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblConsiNo).ForeColor = Color.Black;
		lblConsiNo.ImeMode = (ImeMode)0;
		((Control)lblConsiNo).Location = new Point(764, 97);
		((Control)lblConsiNo).Name = "lblConsiNo";
		((Control)lblConsiNo).Size = new Size(71, 20);
		((Control)lblConsiNo).TabIndex = 1269;
		lblConsiNo.Text = "Consi No";
		lblConsiNo.TextAlign = (ContentAlignment)64;
		((Control)lblConsiNo).Visible = false;
		((TextBoxBase)tConsiNo).BackColor = Color.White;
		((Control)tConsiNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tConsiNo).Location = new Point(841, 97);
		((TextBoxBase)tConsiNo).MaxLength = 8;
		((Control)tConsiNo).Name = "tConsiNo";
		((TextBoxBase)tConsiNo).ReadOnly = true;
		((Control)tConsiNo).Size = new Size(76, 22);
		((Control)tConsiNo).TabIndex = 1268;
		((Control)tConsiNo).Visible = false;
		((Control)Label20).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label20).ForeColor = Color.Black;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(512, 436);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(39, 20);
		((Control)Label20).TabIndex = 1275;
		Label20.Text = "Print";
		Label20.TextAlign = (ContentAlignment)64;
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
		((Control)btnTagSet).Location = new Point(682, 434);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(36, 24);
		((Control)btnTagSet).TabIndex = 1274;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		cboPrintfile.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(555, 434);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(123, 24);
		((Control)cboPrintfile).TabIndex = 1273;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)tConsiYrCd);
		((Control)this).Controls.Add((Control)(object)tConsiDbCd);
		((Control)this).Controls.Add((Control)(object)btnConsiNo);
		((Control)this).Controls.Add((Control)(object)lblConsiNo);
		((Control)this).Controls.Add((Control)(object)tConsiNo);
		((Control)this).Controls.Add((Control)(object)nItPcs);
		((Control)this).Controls.Add((Control)(object)nMtlRate);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)nFxRate);
		((Control)this).Controls.Add((Control)(object)nOzRate);
		((Control)this).Controls.Add((Control)(object)tFxCode);
		((Control)this).Controls.Add((Control)(object)nOzConv);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)lblOzConv);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)TEXT_PR_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_PR_IDTL);
		((Control)this).Controls.Add((Control)(object)mDay);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)cboRateFixType);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)pnlBill);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)nItNwt);
		((Control)this).Controls.Add((Control)(object)nitGwt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nPartyFine);
		((Control)this).Controls.Add((Control)(object)Label12);
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
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_PR_SL_UAE";
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
		((ISupportInitialize)MSG_PR_IDTL).EndInit();
		((Control)pnlBill).ResumeLayout(false);
		((ISupportInitialize)PicBill).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_PR_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		mSG_PR_IDTL.Clear();
		mSG_PR_IDTL.Cols = 21;
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
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				mSG_PR_IDTL[5] = 0;
				mSG_PR_IDTL[5] = 7;
				mSG_PR_IDTL[0, 5] = "KrWt";
				mSG_PR_IDTL[6] = 0;
				mSG_PR_IDTL[6] = 7;
				mSG_PR_IDTL[0, 6] = "KrLs%";
			}
			else
			{
				mSG_PR_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_PR_IDTL[5] = 7;
				mSG_PR_IDTL[0, 5] = "KrWt";
				mSG_PR_IDTL[6] = (int)Math.Round(800.0 * ColCon);
				mSG_PR_IDTL[6] = 7;
				mSG_PR_IDTL[0, 6] = "KrLs%";
			}
			mSG_PR_IDTL[7] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR_IDTL[7] = 7;
			mSG_PR_IDTL[0, 7] = "Weight";
			mSG_PR_IDTL[8] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[8] = 7;
			mSG_PR_IDTL[0, 8] = "Con%";
			mSG_PR_IDTL[9] = (int)Math.Round(650.0 * ColCon);
			mSG_PR_IDTL[9] = 3;
			mSG_PR_IDTL[0, 9] = "P/W";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				mSG_PR_IDTL[10] = 0;
				mSG_PR_IDTL[10] = 7;
				mSG_PR_IDTL[0, 10] = "PRate";
				mSG_PR_IDTL[11] = 0;
				mSG_PR_IDTL[11] = 7;
				mSG_PR_IDTL[0, 11] = "PAmt";
				mSG_PR_IDTL[12] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR_IDTL[12] = 7;
				mSG_PR_IDTL[0, 12] = "Rate";
				mSG_PR_IDTL[13] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR_IDTL[13] = 7;
				mSG_PR_IDTL[0, 13] = "ItAmt";
			}
			else
			{
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
			}
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
		mSG_PR_IDTL[mSG_PR_IDTL.Row, 19] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 65]));
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
							MSG_PR.Col = 9;
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
				case 5:
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
				case 6:
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
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 5]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 6]) != 0.0))
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
					num += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 16]);
				}
				DC_Main.M++;
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 28] = Strings.Format((object)num, "0.00");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 9] = Strings.Format((object)num3, "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 8]) - num3), "0.000");
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
					DtIdtlPr.Rows.Add(drPr);
				}
			}
			mSG_PR_IDTL = null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		if (MsgClear || MSG_PR.Row == 0 || !((MsgOldRowPr != MSG_PR.Row) & !MsgClearPr))
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
				if (Conversion.Val(MSG_PR[MSG_PR.Row, 65]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19])))
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
					MSG_PR_IDTL.Rows += 1;
					num++;
				}
			}
			DC_Main.MsImageType = "DhranImage";
			DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + "_" + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 65]));
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				Image image;
				using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
				{
					image = Image.FromStream(stream);
				}
				PicImage.Image = image;
			}
			else
			{
				PicImage.Image = null;
			}
			MSG_PR_IDTL[num, 0] = Conversions.ToString(num);
			MSG_PR_IDTL[num, 19] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 65]));
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 82;
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
			if ((Operators.CompareString(FormMainBook, "B2B SALES", false) == 0) | (Operators.CompareString(FormMainBook, "CON PUR", false) == 0))
			{
				mSG_PR[1] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[1] = 0;
				mSG_PR[0, 1] = "TagNo";
			}
			else
			{
				mSG_PR[1] = 0;
				mSG_PR[1] = 0;
				mSG_PR[0, 1] = "TagNo";
			}
			mSG_PR[2] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "ItCode";
			mSG_PR[3] = (int)Math.Round(2300.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "ItName";
			mSG_PR[4] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Counter";
			mSG_PR[5] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[5] = 0;
			mSG_PR[0, 5] = "Design";
			if (Operators.CompareString(DC_Main.MsPurcLot, "Y", false) == 0)
			{
				mSG_PR[6] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "LotNo";
			}
			else
			{
				mSG_PR[6] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "LotNo";
			}
			mSG_PR[41] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[41] = 0;
			mSG_PR[0, 41] = "Size";
			mSG_PR[42] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[42] = 7;
			mSG_PR[0, 42] = "BagWt";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
			{
				mSG_PR[7] = (int)Math.Round(900.0 * ColCon);
				mSG_PR[7] = 7;
				mSG_PR[0, 7] = "Pcs";
			}
			else
			{
				mSG_PR[7] = (int)Math.Round(700.0 * ColCon);
				mSG_PR[7] = 7;
				mSG_PR[0, 7] = "Pcs";
			}
			mSG_PR[43] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[43] = 7;
			mSG_PR[0, 43] = "PsWt";
			mSG_PR[8] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[8] = 7;
			mSG_PR[0, 8] = "GrWt";
			mSG_PR[9] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "OthWt";
			mSG_PR[10] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "NetWt";
			mSG_PR[11] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "Ght%";
			mSG_PR[12] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "GhtWt";
			mSG_PR[13] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[13] = 3;
			mSG_PR[0, 13] = "Touch";
			mSG_PR[14] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[14] = 3;
			mSG_PR[0, 14] = "West%";
			mSG_PR[16] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "Fine";
			mSG_PR[17] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "McxRate";
			mSG_PR[18] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[18] = 7;
			mSG_PR[0, 18] = "Premium";
			mSG_PR[19] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "PrmDisc";
			mSG_PR[20] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[20] = 3;
			mSG_PR[0, 20] = "RatWith";
			mSG_PR[46] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[46] = 7;
			mSG_PR[0, 46] = "ConRate";
			mSG_PR[47] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[47] = 7;
			mSG_PR[0, 47] = "Con%";
			mSG_PR[21] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[21] = 7;
			mSG_PR[0, 21] = "Rate";
			mSG_PR[22] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[22] = 7;
			mSG_PR[0, 22] = "ItAmt";
			mSG_PR[23] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[23] = 7;
			mSG_PR[0, 23] = "ItDscont";
			mSG_PR[61] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[61] = 7;
			mSG_PR[0, 61] = "HmFine";
			mSG_PR[45] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[45] = 7;
			mSG_PR[0, 45] = "SlvFine";
			mSG_PR[48] = 0;
			mSG_PR[48] = 7;
			mSG_PR[0, 48] = "HmAmt";
			mSG_PR[24] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "Lbr%";
			mSG_PR[25] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[25] = 3;
			mSG_PR[0, 25] = "Ltype";
			mSG_PR[26] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "LRate";
			mSG_PR[27] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "LAmt";
			mSG_PR[28] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[28] = 7;
			mSG_PR[0, 28] = "OthAmt";
			mSG_PR[29] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[29] = 3;
			mSG_PR[0, 29] = "ORate";
			mSG_PR[30] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "OFine";
			mSG_PR[32] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[32] = 7;
			mSG_PR[0, 32] = "Mrp";
			mSG_PR[15] = 0;
			mSG_PR[44] = 0;
			mSG_PR[31] = 0;
			mSG_PR[33] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[33] = 7;
			mSG_PR[0, 33] = "TotAmt";
			mSG_PR[34] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[34] = 7;
			mSG_PR[0, 34] = "TaxPrc";
			mSG_PR[35] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[35] = 7;
			mSG_PR[0, 35] = "NetAmt";
			mSG_PR[53] = 0;
			mSG_PR[54] = 0;
			mSG_PR[55] = 0;
			mSG_PR[56] = 0;
			mSG_PR[57] = 0;
			mSG_PR[58] = 0;
			mSG_PR[59] = 0;
			mSG_PR[60] = 0;
			mSG_PR[62] = 0;
			mSG_PR[63] = 0;
			mSG_PR[64] = 0;
			mSG_PR[65] = 0;
			mSG_PR[66] = 0;
			mSG_PR[67] = 0;
			mSG_PR[49] = 0;
			mSG_PR[68] = 0;
			mSG_PR[40] = 0;
			mSG_PR[74] = 0;
			mSG_PR[50] = 0;
			mSG_PR[51] = 0;
			mSG_PR[52] = 0;
			mSG_PR[70] = 0;
			mSG_PR[69] = 0;
			mSG_PR[71] = 0;
			mSG_PR[72] = 0;
			mSG_PR[73] = 0;
			mSG_PR[75] = 0;
			mSG_PR[76] = 0;
			mSG_PR[77] = 0;
			mSG_PR[78] = 0;
			mSG_PR[79] = 0;
			mSG_PR[80] = 0;
			mSG_PR[81] = 0;
			if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
			{
				mSG_PR[36] = (int)Math.Round(800.0 * ColCon);
				mSG_PR[36] = 3;
				mSG_PR[0, 36] = "ConNo";
				mSG_PR[37] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[37] = 3;
				mSG_PR[0, 37] = "ConYear";
				mSG_PR[38] = (int)Math.Round(800.0 * ColCon);
				mSG_PR[38] = 3;
				mSG_PR[0, 38] = "ConBk";
				mSG_PR[39] = (int)Math.Round(700.0 * ColCon);
				mSG_PR[39] = 3;
				mSG_PR[0, 39] = "ConSr";
			}
			else
			{
				mSG_PR[36] = 0;
				mSG_PR[37] = 0;
				mSG_PR[38] = 0;
				mSG_PR[39] = 0;
			}
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
					dataView.RowFilter = " BOOK_NAME = 'B2B PURC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
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
		checked
		{
			mSG_PR.Row = mSG_PR.Rows - 1;
			mSG_PR[mSG_PR.Row, 0] = Conversions.ToString(mSG_PR.Row);
			mSG_PR[mSG_PR.Row, 25] = DC_Main.MsLbrType;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 65] = Conversions.ToString(mSG_PR.Row);
			}
			else
			{
				mSG_PR[mSG_PR.Row, 65] = Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Rows - 2, 65]) + 1.0);
			}
			mSG_PR[mSG_PR.Row, 52] = "A";
			mSG_PR[mSG_PR.Row, 50] = "N";
			mSG_PR[mSG_PR.Row, 51] = "N";
			mSG_PR[mSG_PR.Row, 71] = "N";
			if (Operators.CompareString(FormMainBook, "B2B SALES", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 20] = DC_Main.MsSlAmtType;
			}
			else
			{
				mSG_PR[mSG_PR.Row, 20] = DC_Main.MsPrAmtType;
			}
			MSG_PR_IDTL_CLEAR();
			if (mSG_PR.Row > 1)
			{
				DataView dataView = new DataView(DC_Main.RsClDetl);
				if (dataView.Count > 0)
				{
					int num = mSG_PR.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						dataView.RowFilter = "BOOK_NAME = 'B2B PURC' AND COL_NEW_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							mSG_PR[mSG_PR.Row, DC_Main.M] = mSG_PR[mSG_PR.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG_PR = null;
		}
	}

	private void LotNoGen(int Y)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		DC_Main.RsQry = "SELECT RIGHT(A.LOT_NO,5) AS TAG_SRNO FROM LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.PR_CODE = '" + mSG_PR[Y, 67] + "' GROUP BY RIGHT(A.LOT_NO,5) ORDER BY RIGHT(A.LOT_NO,5) DESC";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = ((dataTable.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "00000") : "00001");
		checked
		{
			int num = mSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG_PR[Y, 6], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 67], mSG_PR[Y, 67], false) == 0) & (Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) >= Conversion.Val(text))) && Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) + 1.0 > Conversion.Val(text))
				{
					text = Strings.Format((object)(Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) + 1.0), "00000");
				}
				DC_Main.i++;
			}
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG_PR[Y, 6] = mSG_PR[Y, 67] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + text;
			}
			else
			{
				mSG_PR[Y, 6] = mSG_PR[Y, 67] + text;
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
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Invalid comparison between Unknown and I4
		//IL_2fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fb4: Invalid comparison between Unknown and I4
		//IL_2fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fbe: Invalid comparison between Unknown and I4
		//IL_2fc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fc9: Invalid comparison between Unknown and I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Invalid comparison between Unknown and I4
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Invalid comparison between Unknown and I4
		//IL_2609: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3b: Unknown result type (might be due to invalid IL or missing references)
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
		}
		else
		{
			if ((int)keyCode == 37)
			{
				checked
				{
					if ((Operators.CompareString(FormMainBook, "B2B SALES", false) == 0) | (Operators.CompareString(FormMainBook, "CON PUR", false) == 0))
					{
						if (mSG_PR.Col > 1)
						{
							Msgleft = true;
							mSG_PR.Col -= 1;
						}
					}
					else if (mSG_PR.Col > 2)
					{
						Msgleft = true;
						mSG_PR.Col -= 1;
					}
					return;
				}
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR.Col < 35)
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
						if (Operators.CompareString(FormBookInOut, "O", false) != 0)
						{
							break;
						}
						if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 79]) == 0.0))
						{
							mSG_PR[mSG_PR.Row, 1] = "";
						}
						if (!((Operators.CompareString(TEXT_PR.Text, "", false) != 0) & (Operators.CompareString(TEXT_PR.Text, mSG_PR[mSG_PR.Row, 1], false) != 0)))
						{
							break;
						}
						mSG_PR[mSG_PR.Row, 79] = Conversions.ToString(0);
						if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_PR.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG_PR[mSG_PR.Row, 79]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 79]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_PR.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG_PR[mSG_PR.Row, 79]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 79]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
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
									TEXT_PR.Text = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 5] = DC_Main.ColValue[0];
								}
								else
								{
									TEXT_PR.Text = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 5] = DC_Main.ColValue[1];
								}
								mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[2];
								mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[3];
								mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG_PR[mSG_PR.Row, 79] = DC_Main.ColValue[7];
								((Control)TEXT_PR).Focus();
							}
							else
							{
								mSG_PR[mSG_PR.Row, 79] = "";
								mSG_PR[mSG_PR.Row, 1] = "";
								((Control)TEXT_PR).Focus();
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
						mSG_PR[mSG_PR.Row, 79] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
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
								TEXT_PR.Text = DC_Main.ColValue[0];
								mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[1];
								mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[0];
								mSG_PR[mSG_PR.Row, 5] = DC_Main.ColValue[3];
								mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG_PR[mSG_PR.Row, 79] = DC_Main.ColValue[7];
								((Control)TEXT_PR).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE,B.RATE_TYPE As RateType,B.DISC_PRC As LbrDisc,B.MRP_DISC_PRC As MrpDisc,B.TAX_FREE_ITEM FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG_PR[mSG_PR.Row, 79]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG_PR.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG_PR[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG_PR[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG_PR[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG_PR[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG_PR[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG_PR[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG_PR[DC_Main.i, 7] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG_PR[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG_PR[DC_Main.i, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG_PR[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG_PR[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG_PR[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							if ((Conversion.Val(mSG_PR[DC_Main.i, 8]) != Conversion.Val(mSG_PR[DC_Main.i, 10])) & (Conversion.Val(mSG_PR[DC_Main.i, 9]) == 0.0))
							{
								mSG_PR[DC_Main.i, 9] = Strings.Format((object)(Conversion.Val(mSG_PR[DC_Main.i, 8]) - Conversion.Val(mSG_PR[DC_Main.i, 10])), "0.000");
							}
							mSG_PR[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG_PR[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG_PR[mSG_PR.Row, 2] + "' ";
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							object Value;
							if (dataTable.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["IT_WEST"], (object)"")) != 0.0)
							{
								if (Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["IT_TOUCH"], (object)"")) != 0.0)
								{
									AxMSFlexGrid obj = mSG_PR;
									int row = mSG_PR.Row;
									DataRow dataRow;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["IT_TOUCH"]);
									double num3 = DC_Main.Fnv(ref Value);
									dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									obj[row, 13] = Strings.Format((object)num3, "0.00");
								}
								if (Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["IT_WEST"], (object)"")) != 0.0)
								{
									mSG_PR[mSG_PR.Row, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["IT_WEST"], (object)"")), "0.00");
								}
								if ((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0))
								{
									mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14])) / 100.0), "0.000");
								}
							}
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
							{
								mSG_PR[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							}
							mSG_PR[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RateType"], (object)""));
							if (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) == 0.0 && Conversion.Val(mSG_PR[mSG_PR.Row, 32]) == 0.0)
							{
								if (Conversions.ToDouble(nMtlRate.Text) != 0.0)
								{
									NetWiseRate(mSG_PR.Row);
								}
								else if (Operators.CompareString(mSG_PR[mSG_PR.Row, 20], "F", false) != 0)
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
									DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									double num4 = default(double);
									if (dataTable2.Rows.Count > 0)
									{
										num4 = Conversions.ToDouble(dataTable2.Rows[0]["GR_RATE"]);
									}
									else if (DC_Main.RtView != null)
									{
										DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
										if (DC_Main.RtView.Count > 0)
										{
											num4 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
										}
									}
									if (num4 > 0.0)
									{
										mSG_PR[mSG_PR.Row, 59] = Conversions.ToString(0);
										if (Operators.CompareString(mSG_PR[DC_Main.i, 54], "G", false) == 0)
										{
											mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(num4 / 10.0, 2), "0.00");
										}
										else if (Operators.CompareString(mSG_PR[DC_Main.i, 54], "K", false) == 0)
										{
											mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(num4 * 10.0, 0), "0.00");
										}
										else if (Operators.CompareString(mSG_PR[DC_Main.i, 54], "1", false) == 0)
										{
											mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(num4, 0), "0.00");
										}
									}
									else
									{
										mSG_PR[mSG_PR.Row, 21] = "";
									}
								}
							}
							mSG_PR[DC_Main.i, 59] = Conversions.ToString(0);
							mSG_PR[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_AMT"], (object)"")), "0.00");
							mSG_PR[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_PRC"], (object)"")), "0.00");
							if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"", false))
							{
								mSG_PR[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							}
							mSG_PR[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_RATE"], (object)"")), "0.00");
							mSG_PR[DC_Main.i, 62] = Conversions.ToString(0);
							mSG_PR[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_AMT"], (object)"")), "0.00");
							mSG_PR[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OTH_AMT"], (object)"")), "0.00");
							mSG_PR[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							if (((Operators.CompareString(DC_Main.MsMrpTaxReverc, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) == 0)) && Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) != 0.0)
							{
								mSG_PR[DC_Main.i, 34] = "3.00";
							}
							AxMSFlexGrid obj2 = mSG_PR;
							int i = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"");
							obj2[i, 49] = Strings.Format((object)DC_Main.Fnv(ref Value), "0");
							mSG_PR[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 79] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							MsgOldRow = 0;
						}
						int num5 = 0;
						int num6 = DtIdtlPr.Rows.Count - 1;
						int num7 = num6;
						for (int j = 0; j <= num7; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtlPr.Rows[num5][19], (object)Conversion.Val(mSG_PR[DC_Main.i, 65]), false))
							{
								DtIdtlPr.Rows[num5].Delete();
								DtIdtlPr.AcceptChanges();
								num5--;
							}
							num5++;
						}
						MSG_PR_IDTL_CLEAR();
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG_PR[mSG_PR.Row, 1]), (object)"' AND A.VCH_SRNO = "), (object)mSG_PR[mSG_PR.Row, 79]), (object)" "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtlPr.NewRow();
							double num8 = Conversion.Val(MSG_PR[MSG_PR.Row, 65]);
							dr[19] = Conversion.Val(MSG_PR[MSG_PR.Row, 65]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[10] = 0;
							dr[11] = 0;
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[18] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtlPr.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal_Pr(MSG_PR.Row);
						MSG_PR_RowColChange(MSG_PR, new EventArgs());
						MSG_PR_TOT_FILL();
						if (Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) != 0)
						{
							break;
						}
						CommPassTotal_Pr(MSG_PR.Row);
						MsgOldRow = 0;
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							MsgClear = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							if (Operators.CompareString(FormMainBook, "B2B SALES", false) == 0)
							{
								MSG_PR.Col = 1;
							}
							else
							{
								MSG_PR.Col = 2;
							}
							MsgClear = false;
							CommPassAdd_Pr();
							return;
						}
						break;
					}
					case 2:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "' "), Interaction.IIf(Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "A", false) == 0, (object)"", (object)("AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "A", false) == 0, (object)"", (object)("AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  ORDER BY A.IT_NAME"));
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
									mSG_PR[mSG_PR.Row, 67] = DC_Main.ColValue[3];
									mSG_PR[mSG_PR.Row, 53] = DC_Main.ColValue[4];
									mSG_PR[mSG_PR.Row, 66] = DC_Main.ColValue[5];
									mSG_PR[mSG_PR.Row, 69] = "";
									mSG_PR[mSG_PR.Row, 70] = "";
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG_PR[mSG_PR.Row, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 66], mSG_PR[mSG_PR.Row, 69], false) != 0) | (Operators.CompareString(mSG_PR[mSG_PR.Row, 67], mSG_PR[mSG_PR.Row, 70], false) != 0))
						{
							mSG_PR[mSG_PR.Row, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[mSG_PR.Row, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG_PR[mSG_PR.Row, 68] = "";
						}
						if (Operators.CompareString(mSG_PR[mSG_PR.Row, 20], "F", false) != 0 && Conversions.ToDouble(nMtlRate.Text) != 0.0)
						{
							NetWiseRate(mSG_PR.Row);
						}
						if (Operators.CompareString(mSG_PR[mSG_PR.Row, 80], mSG_PR[mSG_PR.Row, 2], false) != 0)
						{
							mSG_PR[mSG_PR.Row, 80] = mSG_PR[mSG_PR.Row, 2];
							DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG_PR[mSG_PR.Row, 2] + "' ";
							DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")) != 0.0)
							{
								if (Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_TOUCH"], (object)"")) != 0.0)
								{
									AxMSFlexGrid obj3 = mSG_PR;
									int row2 = mSG_PR.Row;
									DataRow dataRow;
									object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["IT_TOUCH"]);
									double num9 = DC_Main.Fnv(ref Value);
									dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									obj3[row2, 13] = Strings.Format((object)num9, "0.00");
								}
								if (Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")) != 0.0)
								{
									mSG_PR[mSG_PR.Row, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")), "0.00");
								}
								if (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) > 0.0)
								{
									CommPassTotal_Pr(mSG_PR.Row);
								}
							}
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
					case 8:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 54], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
						((Control)TEXT_PR).Visible = false;
						MSG_PR_IDTL.Row = MSG_PR_IDTL.Rows - 1;
						MSG_PR_IDTL.Col = 1;
						MSG_PR_IDTL_EnterCell(MSG_PR_IDTL, new EventArgs());
						((Control)TEXT_PR_IDTL).Focus();
						((TextBoxBase)TEXT_PR_IDTL).SelectAll();
						return;
					case 20:
						if (Conversion.Val(nMtlRate.Text) != 0.0)
						{
							mSG_PR[mSG_PR.Row, 20] = TEXT_PR.Text;
							NetWiseRate(mSG_PR.Row);
						}
						break;
					case 35:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							mSG_PR[mSG_PR.Row, 48] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
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
					DC_Main.RsQry = "Select IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) As Pcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS NetWt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '" + MSG_PR[MSG_PR.Row, 2] + "'  and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' GROUP BY IT_CODE";
					DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable4.Rows.Count > 0)
					{
						nItPcs.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[0]["Pcs"]), "0");
						nitGwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[0]["GrWt"]), "0.000");
						nItNwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[0]["NetWt"]), "0.000");
					}
					else
					{
						nItPcs.Text = Conversions.ToString(0);
						nitGwt.Text = Conversions.ToString(0);
						nItNwt.Text = Conversions.ToString(0);
					}
				}
			}
			else
			{
				nItPcs.Text = Conversions.ToString(0);
				nitGwt.Text = Conversions.ToString(0);
				nItNwt.Text = Conversions.ToString(0);
			}
		}
		mSG_PR = null;
	}

	private void NetWiseRate(int RateRow)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG_PR = MSG_PR;
		double value;
		if (Operators.CompareString(mSG_PR[RateRow, 20], "F", false) != 0)
		{
			DC_Main.RsQry = "SELECT B.GR_TOUCH FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + mSG_PR[RateRow, 2] + "' AND B.GR_TOUCH <> 0";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				value = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["GR_TOUCH"], (object)"")) * Conversion.Val(nMtlRate.Text) / 100.0), "0.00"));
			}
			else
			{
				Interaction.MsgBox((object)"Please Update Gr Rate Touch In  Group Mast... Then Net Wise Rate Is Show.... ", (MsgBoxStyle)0, (object)null);
				value = Conversions.ToDouble(nMtlRate.Text);
			}
		}
		else
		{
			value = Conversions.ToDouble(nMtlRate.Text);
		}
		mSG_PR[RateRow, 21] = Strings.Format((object)Math.Round(value, 2), "0.00");
		CommPassTotal_Pr(mSG_PR.Row);
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
				if (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 3:
			case 49:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 6:
			case 40:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 36:
			case 37:
			case 38:
			case 39:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				((TextBoxBase)TEXT_PR).ReadOnly = true;
				break;
			case 1:
			case 5:
			case 41:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 20:
			case 25:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 7:
				((TextBoxBase)TEXT_PR).MaxLength = 8;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				if (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 13:
			case 14:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 11:
			case 15:
			case 21:
			case 22:
			case 23:
			case 24:
			case 26:
			case 27:
			case 28:
			case 29:
			case 32:
			case 33:
			case 34:
			case 35:
			case 46:
			case 47:
			case 48:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 8:
			case 9:
			case 10:
			case 12:
			case 30:
			case 42:
			case 43:
			case 44:
			case 45:
			case 61:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 17:
			case 18:
			case 19:
			case 31:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 16:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				if ((Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0))
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
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 2:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 0:
			case 3:
			case 4:
			case 5:
			case 6:
			case 20:
			case 25:
			case 40:
			case 41:
			case 49:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 36:
			case 37:
			case 38:
			case 39:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 7:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 17:
			case 18:
			case 19:
			case 31:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 11:
			case 13:
			case 14:
			case 15:
			case 21:
			case 22:
			case 23:
			case 24:
			case 26:
			case 27:
			case 28:
			case 29:
			case 32:
			case 33:
			case 34:
			case 35:
			case 46:
			case 47:
			case 48:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 8:
			case 9:
			case 10:
			case 12:
			case 16:
			case 30:
			case 42:
			case 43:
			case 44:
			case 45:
			case 61:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			}
			mSG_PR = null;
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
		int digits = 0;
		int digits2 = 0;
		if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
		{
			digits = 2;
			digits2 = 2;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != Conversion.Val(mSG_PR[mSG_PR.Row, 81]))
		{
			mSG_PR[mSG_PR.Row, 81] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 7]), "0");
			mSG_PR[mSG_PR.Row, 59] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != Conversion.Val(mSG_PR[mSG_PR.Row, 55]))
		{
			mSG_PR[mSG_PR.Row, 55] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 8]), "0.000");
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 9]) + Conversion.Val(mSG_PR[mSG_PR.Row, 44]))), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 44]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 9]) + Conversion.Val(mSG_PR[mSG_PR.Row, 44]))), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 9]) + Conversion.Val(mSG_PR[mSG_PR.Row, 44]))), "0.000");
		}
		else if (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 9]) + Conversion.Val(mSG_PR[mSG_PR.Row, 44]))), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != Conversion.Val(mSG_PR[mSG_PR.Row, 56]))
		{
			mSG_PR[mSG_PR.Row, 56] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 10]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) - Conversion.Val(mSG_PR[mSG_PR.Row, 15])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 10]), "0.000");
			}
			mSG_PR[mSG_PR.Row, 59] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 11]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != Conversion.Val(mSG_PR[mSG_PR.Row, 57]))
		{
			mSG_PR[mSG_PR.Row, 57] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 13]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) - Conversion.Val(mSG_PR[mSG_PR.Row, 15])) / 100.0), "0.000");
			}
			mSG_PR[mSG_PR.Row, 59] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != Conversion.Val(mSG_PR[mSG_PR.Row, 58]))
		{
			mSG_PR[mSG_PR.Row, 58] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 14]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) - Conversion.Val(mSG_PR[mSG_PR.Row, 15])) / 100.0), "0.000");
			}
			mSG_PR[mSG_PR.Row, 59] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != Conversion.Val(mSG_PR[mSG_PR.Row, 60]))
		{
			mSG_PR[mSG_PR.Row, 60] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) - Conversion.Val(mSG_PR[mSG_PR.Row, 15])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 29]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 28]) != 0.0))
		{
			string text = mSG_PR[mSG_PR.Row, 54];
			if (Operators.CompareString(text, "1", false) != 0)
			{
				if (Operators.CompareString(text, "K", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 28]) * 1000.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 3), "0.000");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 28]) / Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 3), "0.000");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 28]) * 10.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 3), "0.000");
			}
		}
		if (mSG_PR[17] > 0)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 17]) + Conversion.Val(mSG_PR[mSG_PR.Row, 18]) - Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 2), "0.00");
			}
			else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 46]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 47]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 46]) / Conversion.Val(mSG_PR[mSG_PR.Row, 47]) * 100.0, 2), "0.000");
			}
			else if (Conversion.Val(mSG_PR[mSG_PR.Row, 46]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 46]), "0.00");
			}
		}
		double num = 0.0;
		if (mSG_PR[20] <= 0)
		{
			string text2 = ((Operators.CompareString(FormMainBook, "B2B SALES", false) != 0) ? DC_Main.MsPrAmtType : DC_Main.MsSlAmtType);
			num = ((Operators.CompareString(text2, "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 8]) : ((Operators.CompareString(text2, "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 16]) : (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12]))));
		}
		else
		{
			num = ((Operators.CompareString(mSG_PR[mSG_PR.Row, 20], "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 8]) : ((Operators.CompareString(mSG_PR[mSG_PR.Row, 20], "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 16]) : (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12]))));
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != Conversion.Val(mSG_PR[mSG_PR.Row, 59])) & (num + Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 59] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.00");
			switch (mSG_PR[mSG_PR.Row, 54])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 7]) * Conversion.Val(mSG_PR[mSG_PR.Row, 21]), digits), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) / 10.0), digits), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) / 1000.0), digits), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)Math.Round(num * Conversion.Val(mSG_PR[mSG_PR.Row, 21]), digits), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 64] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 22]), "0.00");
		}
		if (mSG_PR.Col == 22 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) == 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) + Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != 0.0)))
		{
			switch (mSG_PR[mSG_PR.Row, 54])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 7]), DC_Main.MsPrRateRof), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num, DC_Main.MsPrRateRof), "0.00");
				break;
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 21]) - Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 2), "0.00");
			}
			mSG_PR[mSG_PR.Row, 59] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.00");
		}
		if (Operators.CompareString(DC_Main.MsOldPurcTchGen, "Y", false) == 0 && ((Operators.CompareString(DC_Main.MCo_Book, "037", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "038", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "043", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "044", false) == 0)) && mSG_PR.Col == 22 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) != 0.0)))
		{
			mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(TEXT_PR.Text) * Conversion.Val(mSG_PR[mSG_PR.Row, 16]) / Conversion.Val(mSG_PR[mSG_PR.Row, 64]))), "0.000");
			mSG_PR[mSG_PR.Row, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 16]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 10]))), "0.00");
			mSG_PR[mSG_PR.Row, 64] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			mSG_PR[mSG_PR.Row, 57] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 13]), "0.00");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 62]) != Conversion.Val(mSG_PR[mSG_PR.Row, 26])))
		{
			switch (mSG_PR[mSG_PR.Row, 25])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 7]) * Conversion.Val(mSG_PR[mSG_PR.Row, 26]), digits2), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 26]), digits2), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * Conversion.Val(mSG_PR[mSG_PR.Row, 26]), digits2), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 26]) / 1000.0), digits2), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * Conversion.Val(mSG_PR[mSG_PR.Row, 26]), digits2), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 62] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 26]), "0.00");
		}
		else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
		{
			switch (mSG_PR[mSG_PR.Row, 25])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 7]), DC_Main.MsLbrRof), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])), DC_Main.MsLbrRof), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * 1000.0, DC_Main.MsLbrRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 8]), DC_Main.MsLbrRof), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 62] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 26]), "0.00");
		}
		if (mSG_PR.Col == 33)
		{
			if (mSG_PR[23] > 0)
			{
				mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(TEXT_PR.Text)), "0.00");
			}
			else if (Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)(Conversion.Val(TEXT_PR.Text) - Conversion.Val(mSG_PR[mSG_PR.Row, 28]) - Conversion.Val(mSG_PR[mSG_PR.Row, 22])), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 27]) < 0.0)
				{
					mSG_PR[mSG_PR.Row, 27] = "";
				}
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != Conversion.Val(mSG_PR[mSG_PR.Row, 63]) && ((Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0)))
				{
					switch (mSG_PR[mSG_PR.Row, 25])
					{
					case "P":
						mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 7]), DC_Main.MsLbrRof), "0.00");
						break;
					case "N":
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
						}
						else
						{
							mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])), DC_Main.MsLbrRof), "0.00");
						}
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12])) * 1000.0, DC_Main.MsLbrRof), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 8]), DC_Main.MsLbrRof), "0.00");
						break;
					}
					double num2 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 26]), "0.00"));
					mSG_PR[mSG_PR.Row, 62] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 26]), "0.00");
					mSG_PR[mSG_PR.Row, 63] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 27]), "0.00");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 33]) - Conversion.Val(mSG_PR[mSG_PR.Row, 28])), "0.00");
				if ((Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) + Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != 0.0))
				{
					switch (mSG_PR[mSG_PR.Row, 54])
					{
					case "P":
						mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 22]) / Conversion.Val(mSG_PR[mSG_PR.Row, 7]), DC_Main.MsPrRateRof), "0.00");
						break;
					case "1":
						mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 22]) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 22]) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 22]) / num, DC_Main.MsPrRateRof), "0.00");
						break;
					}
					mSG_PR[mSG_PR.Row, 59] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.00");
				}
			}
		}
		mSG_PR[mSG_PR.Row, 33] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) + Conversion.Val(mSG_PR[mSG_PR.Row, 28]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 23])), "0.00");
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 33]), "0.00");
		}
		if (mSG_PR.Col == 34)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 33]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) + 100.0) * 100.0, 0), "0.00");
				mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) - Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 28]), 0), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0)
				{
					if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 25], "P", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 7])), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 25], "N", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
					{
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10])), "0.00");
						}
						else
						{
							mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 12]))), "0.00");
						}
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 25], "K", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * 1000.0), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 25], "G", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 8])), "0.00");
					}
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 33]), "0.00");
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
				mSG_PR_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 7]) + Conversion.Val(MSG_PR[DC_Main.M, 7]))), "0");
				mSG_PR_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 42]) + Conversion.Val(MSG_PR[DC_Main.M, 42]))), "0.000");
				mSG_PR_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR[DC_Main.M, 8]))), "0.000");
				mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0.000");
				mSG_PR_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 44]) + Conversion.Val(MSG_PR[DC_Main.M, 44]))), "0.000");
				mSG_PR_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR[DC_Main.M, 10]))), "0.000");
				mSG_PR_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR[DC_Main.M, 12]))), "0.000");
				mSG_PR_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 16]) + Conversion.Val(MSG_PR[DC_Main.M, 16]))), "0.000");
				mSG_PR_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 22]) + Conversion.Val(MSG_PR[DC_Main.M, 22]))), "0.00");
				mSG_PR_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 27]) + Conversion.Val(MSG_PR[DC_Main.M, 27]))), "0.00");
				mSG_PR_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 28]) + Conversion.Val(MSG_PR[DC_Main.M, 28]))), "0.00");
				mSG_PR_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 32]) + Conversion.Val(MSG_PR[DC_Main.M, 32]))), "0.000");
				mSG_PR_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 33]) + Conversion.Val(MSG_PR[DC_Main.M, 33]))), "0.00");
				mSG_PR_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 35]) + Conversion.Val(MSG_PR[DC_Main.M, 35]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 29]) != 0.0)
				{
					PrOthAmtLess += Conversion.Val(MSG_PR[DC_Main.M, 28]);
				}
				mSG_PR_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 30]) + Conversion.Val(MSG_PR[DC_Main.M, 30]))), "0.000");
				mSG_PR_TOT[0, 48] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 48]) + Conversion.Val(MSG_PR[DC_Main.M, 48]))), "0.000");
				if (Conversion.Val(MSG_PR[DC_Main.M, 22]) == 0.0)
				{
					PurcAcFine += Conversion.Val(MSG_PR[DC_Main.M, 16]);
				}
				DC_Main.M++;
			}
			mSG_PR_TOT = null;
		}
	}

	private void TR_PR_SL_UAE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb7: Expected O, but got Unknown
		//IL_0fdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0feb: Expected O, but got Unknown
		//IL_1010: Unknown result type (might be due to invalid IL or missing references)
		//IL_1015: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f: Expected O, but got Unknown
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_106d: Expected O, but got Unknown
		//IL_1087: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1096: Expected O, but got Unknown
		//IL_10b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bf: Expected O, but got Unknown
		//IL_10d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10de: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e8: Expected O, but got Unknown
		//IL_1110: Unknown result type (might be due to invalid IL or missing references)
		//IL_1117: Expected O, but got Unknown
		//IL_11ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fc: Expected O, but got Unknown
		//IL_1284: Unknown result type (might be due to invalid IL or missing references)
		//IL_1289: Unknown result type (might be due to invalid IL or missing references)
		//IL_1293: Expected O, but got Unknown
		//IL_132c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1331: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Expected O, but got Unknown
		//IL_13c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cf: Expected O, but got Unknown
		//IL_1457: Unknown result type (might be due to invalid IL or missing references)
		//IL_145c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1466: Expected O, but got Unknown
		//IL_148b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1490: Unknown result type (might be due to invalid IL or missing references)
		//IL_149a: Expected O, but got Unknown
		//IL_14c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d1: Expected O, but got Unknown
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
				ComboBox obj9 = cboRateFixType;
				object? obj10 = colorConverter.ConvertFromString("MistyRose");
				obj9.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
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
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				cboRateFixType.BackColor = Color.LightSlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj24 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj25 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj26 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj27 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj28 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj29 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL4 = MSG_PR_IDTL;
				object? obj31 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL4.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL5 = MSG_PR_IDTL;
				object? obj32 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR_IDTL5.BackColorBkg = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL6 = MSG_PR_IDTL;
				object? obj33 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR_IDTL6.BackColorFixed = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj34 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj35 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj36 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				cboRateFixType.BackColor = Color.Cornsilk;
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
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
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
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue3, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkBillImage", false))
						{
							NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					foreach (object control6 in ((Control)PanelAdd).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
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
			if (Operators.CompareString(FormMainBook, "B2B SALES", false) == 0)
			{
				TblData = "SL_DATA";
				TblDetl = "SL_DETL";
				TblIdtl = "SL_IDTL";
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					((Control)chkBillImage).Visible = true;
					((Control)pnlBill).Left = ((Control)tEmpName).Left;
				}
				((Control)Label14).Visible = true;
				((Control)nPartyFine).Visible = true;
			}
			else if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
			{
				TblData = "PR_DATA";
				TblDetl = "PR_DETL";
				TblIdtl = "PR_IDTL";
				((Control)lblConsiNo).Visible = true;
				((Control)tConsiNo).Visible = true;
				((Control)tConsiYrCd).Visible = true;
				((Control)tConsiDbCd).Visible = true;
				((Control)btnConsiNo).Visible = true;
			}
			else
			{
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					((Control)chkBillImage).Visible = true;
					((Control)pnlBill).Left = ((Control)tEmpName).Left;
				}
				TblData = "PR_DATA";
				TblDetl = "PR_DETL";
				TblIdtl = "PR_IDTL";
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
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
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"All");
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
			{
				cboItemTyp.SelectedIndex = 2;
			}
			else if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 0;
			}
			else
			{
				cboItemTyp.SelectedIndex = 1;
			}
			cboRateFixType.Items.Add((object)"Standard");
			cboRateFixType.Items.Add((object)"Hedging");
			cboRateFixType.SelectedIndex = 0;
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
		chkHalfPrint.Checked = false;
		if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
		{
			tAcCode.Text = "00045";
		}
		else if (Operators.CompareString(FormMainBook, "PURCHASE", false) != 0)
		{
		}
		AcGstType = "L";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
		{
			cboItemTyp.SelectedIndex = 2;
		}
		else if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		cboRateFixType.SelectedIndex = 0;
		nOzConv.Text = Strings.Format((object)DC_Main.MsSlPrOzConv, "0.0000");
		nFxRate.Text = Strings.Format((object)DC_Main.MsFxRate, "0.000");
		tFxCode.Text = DC_Main.MsFxCode;
		PicBill.Image = null;
		chkBillImage.Checked = false;
		((Control)pnlBill).Visible = false;
		DC_Main.MsBillImgPath = "";
		DC_Main.MsImagePath = "";
		((Control)TEXT_PR_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		MSG_PR_CLEAR();
		MSG_PR_IDTL_CLEAR();
		MSG2_CLEAR();
		OldTagItm = "";
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
		cboPrintfile.Text = FormPrintFile;
		DtIdtlPr.Clear();
		DtIdtlPr.Reset();
		FilRowPr = 0;
		checked
		{
			int num2 = MSG_PR_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
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
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"A", false))
				{
					cboItemTyp.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
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
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OTH_AMT"]), "0.00");
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["OTH_TAX_CODE"], (object)""));
				MSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OTH_TAX_PRC"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OTH_TAX_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_AMT"]), "0.00");
				MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HM_TAX_CODE"], (object)""));
				MSG2_TOTAL[6, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_TAX_PRC"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_TAX_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
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
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
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
				tFxCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FX_CODE"], (object)""));
				nOzRate.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["OZ_RATE"], (object)"")), "0.000");
				nOzConv.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["OZ_CONV"], (object)"")), "0.000");
				nFxRate.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["FX_RATE"], (object)"")), "0.000");
				nMtlRate.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["MTL_RATE"], (object)"")), "0.00");
				if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
				{
					tConsiNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_NO"], (object)""));
					tConsiYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_YRCD"], (object)""));
					tConsiDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_DBCD"], (object)""));
				}
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RATE_UNFIX"], (object)""), (object)"Y", false))
				{
					cboRateFixType.SelectedIndex = 1;
				}
				else
				{
					cboRateFixType.SelectedIndex = 0;
				}
				RateFixType = Conversions.ToString(cboRateFixType.SelectedIndex);
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
					mSG_PR[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG_PR[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 81] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LOSS_WT"])), "0.000");
					}
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.000");
					}
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
						mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
						mSG_PR[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
						mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_AMT"])), "0.00");
					}
					mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["MCX_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["PRM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["PRM_DISC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["RATE_WITH"], (object)""));
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 67] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["VCH_SRNO"])), "0.00");
					if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
						mSG_PR[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
						mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_SRNO"])), "0");
						mSG_PR[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_PCS"])), "0");
						mSG_PR[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_GWT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_NWT"])), "0.000");
						mSG_PR[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_FINE"])), "0.000");
						mSG_PR[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["APR_ISU"], (object)""));
						mSG_PR[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
						mSG_PR[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
					}
					double num3 = Conversion.Val(mSG_PR[DC_Main.i + 1, 42]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 7]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 8]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 16]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 24]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 27]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 28]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 31]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 32]);
					num3 += Conversion.Val(mSG_PR[DC_Main.i + 1, 65]) + Conversion.Val(mSG_PR[DC_Main.i, 21]) + Conversion.Val(mSG_PR[DC_Main.i, 22]);
					string text = "";
					text = mSG_PR[DC_Main.i + 1, 2] + mSG_PR[DC_Main.i + 1, 4] + mSG_PR[DC_Main.i + 1, 5] + mSG_PR[DC_Main.i + 1, 41] + mSG_PR[DC_Main.i + 1, 1];
					text = text + mSG_PR[DC_Main.i + 1, 71] + tAcCode.Text + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy");
					mSG_PR[DC_Main.i + 1, 72] = Strings.Format((object)num3, "0.000");
					mSG_PR[DC_Main.i + 1, 73] = text;
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
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				((Control)TEXT_PR_IDTL).Visible = false;
				OldValTot = Conversion.Val(MSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR_TOT[0, 28]) + Conversion.Val(MSG_PR_TOT[0, 27]);
				NewValTot = Conversion.Val(MSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR_TOT[0, 28]) + Conversion.Val(MSG_PR_TOT[0, 27]);
				DC_Main.MsImageType = "DhranImage";
				DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + "_" + Conversions.ToString(Conversion.Val(MSG_PR[1, 65]));
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					Image image;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					PicImage.Image = image;
				}
				else
				{
					PicImage.Image = null;
				}
				string text2 = "DhranImage";
				string text3 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
				DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text2 + "\\" + text3 + ".jpg";
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

	private void TR_PR_SL_UAE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_PR_SL_UAE_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_338b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3391: Invalid comparison between Unknown and I4
		//IL_343d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3443: Invalid comparison between Unknown and I4
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
		if ((Operators.CompareString(EntryMode, "E", false) == 0) & (Operators.CompareString(FormMainBook, "CON PUR", false) == 0))
		{
			DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT - B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT - B.ITM_NWT FROM APR_DETL,PR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.CONSI_YRCD  AND APR_DETL.CO_BOOK = B.CONSI_DBCD AND APR_DETL.VCH_NO = B.CONSI_NO AND APR_DETL.OLD_SRNO = B.CONSI_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		DC_Main.ExeQuteDc("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if ((Conversion.Val(MSG_PR_TOT[0, 32]) != 0.0) | (Conversion.Val(MSG_PR_TOT[0, 7]) + Conversion.Val(MSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR_TOT[0, 35]) != 0.0))
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
			dataRow2["PARTY_FINE"] = PurcAcFine + Conversion.Val(MSG_PR_TOT[0, 30]);
			dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
			dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
			dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
			dataRow2["TAX_CODE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(MSG2_TOTAL[2, 4], "", false) == 0, (object)"00", (object)MSG2_TOTAL[2, 4]));
			dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
			dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			dataRow2["TCS_CODE"] = "";
			dataRow2["TCS_PRC"] = 0;
			dataRow2["TCS_AMT"] = 0;
			dataRow2["TDS_CODE"] = "";
			dataRow2["TDS_PRC"] = 0;
			dataRow2["TDS_AMT"] = 0;
			dataRow2["OTH_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["OTH_TAX_CODE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(MSG2_TOTAL[4, 4], "", false) == 0, (object)"00", (object)MSG2_TOTAL[4, 4]));
			dataRow2["OTH_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
			dataRow2["OTH_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["HM_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["HM_TAX_CODE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Conversion.Val(MSG2_TOTAL[6, 4]) == 0.0, (object)"00", (object)MSG2_TOTAL[6, 4]));
			dataRow2["HM_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[6, 2]);
			dataRow2["HM_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
			dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
			dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
			dataRow2["LBR_AMT"] = Conversion.Val(MSG_PR_TOT[0, 27]);
			dataRow2["OTH_AMT"] = Conversion.Val(MSG_PR_TOT[0, 28]) - PrOthAmtLess;
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
			dataRow2["IGST_TAX"] = 0;
			dataRow2["SGST_TAX"] = 0;
			dataRow2["CGST_TAX"] = 0;
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
			{
				dataRow2["SL_BILL_NO"] = "";
				dataRow2["SL_BILL_LC"] = "";
				dataRow2["SL_BILL_YRCD"] = "";
				dataRow2["SL_BILL_DBCD"] = "";
			}
			else if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
			{
				dataRow2["SL_BILL_NO"] = tConsiNo.Text;
				dataRow2["SL_BILL_LC"] = DC_Main.MLc_code;
				dataRow2["SL_BILL_YRCD"] = tConsiYrCd.Text;
				dataRow2["SL_BILL_DBCD"] = tConsiDbCd.Text;
			}
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			if (cboRateFixType.SelectedIndex == 1)
			{
				dataRow2["RATE_UNFIX"] = "Y";
			}
			else
			{
				dataRow2["RATE_UNFIX"] = "N";
			}
			dataRow2["OZ_RATE"] = Conversion.Val(nOzRate.Text);
			dataRow2["OZ_CONV"] = Conversion.Val(nOzConv.Text);
			dataRow2["FX_RATE"] = Conversion.Val(nFxRate.Text);
			dataRow2["FX_CODE"] = tFxCode.Text;
			dataRow2["MTL_RATE"] = Conversion.Val(nMtlRate.Text);
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
				num2 = Conversion.Val(mSG_PR[DC_Main.i, 42]) + Conversion.Val(mSG_PR[DC_Main.i, 7]) + Conversion.Val(mSG_PR[DC_Main.i, 8]) + Conversion.Val(mSG_PR[DC_Main.i, 16]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 24]) + Conversion.Val(mSG_PR[DC_Main.i, 27]) + Conversion.Val(mSG_PR[DC_Main.i, 28]) + Conversion.Val(mSG_PR[DC_Main.i, 31]) + Conversion.Val(mSG_PR[DC_Main.i, 32]);
				num2 += Conversion.Val(mSG_PR[DC_Main.i, 65]) + Conversion.Val(mSG_PR[DC_Main.i, 21]) + Conversion.Val(mSG_PR[DC_Main.i, 22]);
				string text = "";
				text = mSG_PR[DC_Main.i, 2] + mSG_PR[DC_Main.i, 4] + mSG_PR[DC_Main.i, 5] + mSG_PR[DC_Main.i, 41] + mSG_PR[DC_Main.i, 1];
				text = text + mSG_PR[DC_Main.i, 71] + tAcCode.Text + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy");
				if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG_PR[DC_Main.i, 72]), "0.000"), Strings.Format((object)num2, "0.000"), false) != 0) | (Operators.CompareString(mSG_PR[DC_Main.i, 73], text, false) != 0))
				{
					DC_Main.ExeQuteDc(("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i, 0]))) ?? "");
					DC_Main.RsQry = "SELECT * FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i, 0])) + " ";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow3 = RsDetl.NewRow();
					if ((Conversion.Val(MSG_PR[DC_Main.i, 10]) + Conversion.Val(MSG_PR[DC_Main.i, 35]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 2], "", false) != 0))
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
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 65]);
						dataRow3["IT_CODE"] = mSG_PR[DC_Main.i, 2];
						if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
						{
							dataRow3["IT_DESC"] = mSG_PR[DC_Main.i, 3];
						}
						if (Operators.CompareString(mSG_PR[DC_Main.i, 1], "", false) == 0)
						{
							dataRow3["TAG_NO"] = "N";
						}
						else
						{
							dataRow3["TAG_NO"] = mSG_PR[DC_Main.i, 1];
						}
						dataRow3["TBL_CODE"] = mSG_PR[DC_Main.i, 4];
						dataRow3["DESIGN_NO"] = mSG_PR[DC_Main.i, 5];
						dataRow3["LOT_NO"] = mSG_PR[DC_Main.i, 6];
						dataRow3["ITM_COLOR"] = mSG_PR[DC_Main.i, 40];
						dataRow3["ITM_SIZE"] = mSG_PR[DC_Main.i, 41];
						dataRow3["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 42]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 7]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 8]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
						if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
						{
							dataRow3["ITM_LOSS_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 44]);
						}
						dataRow3["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
						dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 11]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
						if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
						{
							dataRow3["ITM_LESS_TCH"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
							dataRow3["SILVER_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 45]);
							dataRow3["ITM_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
							dataRow3["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
							dataRow3["CONV_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 46]);
							dataRow3["CONV_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 47]);
							dataRow3["HM_ID_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 48]);
						}
						dataRow3["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 16]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 24]);
						dataRow3["LBR_TYPE"] = mSG_PR[DC_Main.i, 25];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 28]);
						dataRow3["MCX_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
						dataRow3["PRM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
						dataRow3["PRM_DISC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
						dataRow3["RATE_WITH"] = mSG_PR[DC_Main.i, 20];
						dataRow3["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
						dataRow3["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 22]);
						dataRow3["DISC_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 23]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
						dataRow3["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 33]);
						dataRow3["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
						dataRow3["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 35]);
						dataRow3["VCH_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 79]);
						dataRow3["RATE_TYPE"] = mSG_PR[DC_Main.i, 54];
						dataRow3["IT_TYPE"] = mSG_PR[DC_Main.i, 53];
						dataRow3["DESIGN_IMG_ID"] = mSG_PR[DC_Main.i, 71];
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
						{
							dataRow3["CONSI_NO"] = mSG_PR[DC_Main.i, 36];
							dataRow3["CONSI_YRCD"] = mSG_PR[DC_Main.i, 37];
							dataRow3["CONSI_DBCD"] = mSG_PR[DC_Main.i, 38];
							dataRow3["CONSI_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 39]);
						}
						if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
						{
							dataRow3["CONSI_NO"] = "";
							dataRow3["CONSI_YRCD"] = "";
							dataRow3["CONSI_DBCD"] = "";
							dataRow3["CONSI_SRNO"] = 0;
							dataRow3["WITH_STOCK"] = "Y";
							dataRow3["SL_BILL_NO"] = "";
							dataRow3["SL_BILL_LC"] = "";
							dataRow3["SL_BILL_YRCD"] = "";
							dataRow3["SL_BILL_DBCD"] = "";
							dataRow3["MAIN_USER"] = MainUser;
							dataRow3["URD_RATE_TYPE"] = "F";
							dataRow3["FINE_CUT_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 75]);
							dataRow3["FINE_CUT_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 76]);
							dataRow3["FINE_CUT_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 77]);
							dataRow3["FINE_CUT_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 78]);
							dataRow3["TAG_TYPE"] = mSG_PR[DC_Main.i, 66];
							dataRow3["PR_CODE"] = mSG_PR[DC_Main.i, 67];
							dataRow3["TAG_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 68]);
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
			DC_Main.ExeQuteDc("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "SELECT * FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow4 = RsIdtl.NewRow();
			int num4 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
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
					dataRow4["IT_PCS_WT"] = Conversion.Val(Operators.ConcatenateObject(DtIdtlPr.Rows[i][4], (object)""));
					dataRow4["KR_WT"] = Conversion.Val(Operators.ConcatenateObject(DtIdtlPr.Rows[i][5], (object)""));
					dataRow4["KR_LESS_PRC"] = Conversion.Val(Operators.ConcatenateObject(DtIdtlPr.Rows[i][6], (object)""));
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
			if (chkHalfPrint.Checked)
			{
				DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				int num5 = MSG_PR.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num5)
				{
					AxMSFlexGrid mSG_PR2 = MSG_PR;
					DC_Main.MsImageType = "DhranImage";
					DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + "_" + Conversions.ToString(Conversion.Val(MSG_PR[DC_Main.i, 65]));
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
						MemoryStream memoryStream = new MemoryStream();
						PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
						byte[] buffer = memoryStream.GetBuffer();
						DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + DC_Main.MCo_Book + "' AND TAG_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG_PR2[DC_Main.i, 65]))) ?? "";
						DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow5 = dataTable2.NewRow();
						dataRow5["CO_CODE"] = DC_Main.MCo_code;
						dataRow5["LC_CODE"] = DC_Main.MLc_code;
						dataRow5["SCHM_CODE"] = DC_Main.MCo_Book;
						dataRow5["MEMB_CODE"] = "";
						dataRow5["TAG_NO"] = tVchNo.Text;
						dataRow5["SR_NO"] = Conversion.Val(mSG_PR2[DC_Main.i, 65]);
						dataRow5["DESIGN"] = tAcCode.Text;
						dataRow5["VCH_SRNO"] = 0;
						dataRow5["TAG_IMAGE"] = buffer;
						dataTable2.Rows.Add(dataRow5);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
						dataTable2.Clear();
					}
					mSG_PR2 = null;
					DC_Main.i++;
				}
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE A SET  A.ZERO_RATED_AMT = B.ZeroRated FROM " + TblData + " AS A  INNER JOIN(Select B.CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SUM(ITM_AMT) As ZeroRated   FROM " + TblDetl + " AS B,ITEM_MAST AS C WHERE B.CO_CODE = C.CO_CODE And B.IT_CODE =  C.IT_CODE And C.TAX_FREE_ITEM = 'Y'  GROUP BY B.CO_CODE, B.LC_CODE, B.CO_YEAR, B.CO_BOOK, B.VCH_NO) As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE  And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT + B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT + B.ITM_NWT FROM APR_DETL,PR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.CONSI_YRCD  AND APR_DETL.CO_BOOK = B.CONSI_DBCD AND APR_DETL.VCH_NO = B.CONSI_NO AND APR_DETL.OLD_SRNO = B.CONSI_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.CON_ISU_REC = 'Y' FROM APR_DETL,PR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.CONSI_YRCD  AND APR_DETL.CO_BOOK = B.CONSI_DBCD AND APR_DETL.VCH_NO = B.CONSI_NO AND APR_DETL.OLD_SRNO = B.CONSI_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if ((Operators.CompareString(FormMainBook, "B2B PURC", false) == 0) | (Operators.CompareString(FormMainBook, "CON PUR", false) == 0))
			{
				Ac_Ledr.B2B_Purc_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Rojmel.Purc_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Tax.Purc_GST(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Purc_Stk(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Dm_Purc_Detl(DC_Main.MCo_Book, tVchNo.Text);
			}
			else
			{
				Ac_Ledr.B2B_Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Rojmel.Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Tax.Sales_GST(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Dm_Sale_Detl(DC_Main.MCo_Book, tVchNo.Text);
			}
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
			DC_Main.RsQry = "DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.PrKr_Lot(DC_Main.MCo_Book, tVchNo.Text);
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
			DC_Main.MsOldPurcWt = Conversion.Val(MSG_PR_TOT[0, 10]);
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
			DC_Main.MsOldPurcWt = Conversion.Val(MSG_PR_TOT[0, 10]);
			((Control)BtnSave).Enabled = true;
			if ((int)Interaction.MsgBox((object)"Old Gold Purchase Print... ?", (MsgBoxStyle)260, (object)null) == 7)
			{
				((Form)this).Close();
				return;
			}
		}
		if (Operators.CompareString(FormVchNo, "", false) != 0)
		{
			CLEAR_DATA();
			((Form)this).Close();
			return;
		}
		CurPrnVch = tVchNo.Text;
		RateFixType = Conversions.ToString(cboRateFixType.SelectedIndex);
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
		PrHalfPrint = false;
		CurPrnVch = "";
		RateFixType = "";
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
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
			if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT - B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT - B.ITM_NWT FROM APR_DETL,PR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.CONSI_YRCD  AND APR_DETL.CO_BOOK = B.CONSI_DBCD AND APR_DETL.VCH_NO = B.CONSI_NO AND APR_DETL.OLD_SRNO = B.CONSI_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.CON_ISU_REC = 'N' FROM APR_DETL,PR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.CONSI_YRCD  AND APR_DETL.CO_BOOK = B.CONSI_DBCD AND APR_DETL.VCH_NO = B.CONSI_NO AND APR_DETL.OLD_SRNO = B.CONSI_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
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

	private void TR_PR_SL_UAE_KeyDown(object sender, KeyEventArgs e)
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
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Invalid comparison between Unknown and I4
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Invalid comparison between Unknown and I4
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		string text = "";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
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
			text = ((Operators.CompareString(FormMainBook, "B2B PURC", false) != 0) ? cboPrintfile.Text : cboPrintfile.Text);
			DC_Main.MsWappPrintType = "AmtBal";
			DC_Main.RptName = text;
			DC_Main.RptFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			if (Conversions.ToDouble(RateFixType) != 1.0 || (int)Interaction.MsgBox((object)"Fixing Voucher Print...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				return;
			}
			text = ((Operators.CompareString(FormMainBook, "B2B PURC", false) != 0) ? "SalesToPurcFixingVch" : "PurcToSalesFixingVch");
			DC_Main.MsWappPrintType = "AmtBal";
			DC_Main.RptName = text;
			DC_Main.RptFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				if (DC_Main.MsPrintDup)
				{
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'CUSTOMER COPY'";
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
				if (DC_Main.MsPrintOg)
				{
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
			}
			else
			{
				if (DC_Main.MsPrintDup)
				{
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'CUSTOMER COPY'";
					Module_Save.ShowReportPreview();
				}
				if (DC_Main.MsPrintOg)
				{
					DC_Main.MsPrintType = "InVoiceType";
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
		if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
		}
		Cr.SelectionFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				Cr[(short)1] = "InVoiceType = 'ACCOUNT COPY'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				Cr[(short)1] = "InVoiceType = 'CUSTOMER COPY'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintTrip)
			{
				Cr[(short)1] = "InVoiceType = 'TRIPLICATE COPY'";
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
		if (Conversions.ToDouble(RateFixType) != 1.0 || (int)Interaction.MsgBox((object)"Fixing Voucher Print...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		if (Operators.CompareString(FormMainBook, "B2B PURC", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcToSalesFixingVch.RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesToPurcFixingVch.RPT";
		}
		Cr.SelectionFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				Cr[(short)1] = "InVoiceType = 'ACCOUNT COPY'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				Cr[(short)1] = "InVoiceType = 'CUSTOMER COPY'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintTrip)
			{
				Cr[(short)1] = "InVoiceType = 'TRIPLICATE COPY'";
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
	private void TR_PR_SL_UAE_Activated(object sender, EventArgs e)
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
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			PicImage.Image = null;
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

	private void TR_PR_SL_UAE_Closed(object sender, EventArgs e)
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
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
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
				if (Operators.CompareString(FormMainBook, "B2B SALES", false) == 0)
				{
					DC_Main.MsGrCode = "20";
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
		if ((Operators.CompareString(FormMainBook, "B2B SALES", false) == 0) | (Operators.CompareString(FormMainBook, "CON PUR", false) == 0))
		{
			MSG_PR.Col = 1;
		}
		else
		{
			MSG_PR.Col = 2;
		}
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
				case 4:
				case 6:
				case 9:
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
			mSG2_TOTAL[3, 0] = "Oth Amt : ";
			mSG2_TOTAL[4, 0] = "Oth Tax : ";
			mSG2_TOTAL[5, 0] = "Lbr Amt : ";
			mSG2_TOTAL[6, 0] = "Lbr Tax : ";
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
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f22: Unknown result type (might be due to invalid IL or missing references)
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
					if ((mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 4))
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
										mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
										mSG2_TOTAL[mSG2_TOTAL.Row, 4] = DC_Main.ColValue[2];
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
									if (mSG2_TOTAL.Row == 2)
									{
										mSG2_TOTAL.Row = 4;
									}
									else
									{
										mSG2_TOTAL.Row = 5;
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
								if (mSG2_TOTAL.Row == 2)
								{
									mSG2_TOTAL.Row = 4;
								}
								else
								{
									mSG2_TOTAL.Row = 5;
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
							if (mSG2_TOTAL.Row == 2)
							{
								mSG2_TOTAL.Row = 4;
							}
							else
							{
								mSG2_TOTAL.Row = 5;
							}
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 14)
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
										mSG2_TOTAL[14, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										mSG2_TOTAL[14, 4] = DC_Main.ColValue[2];
										OldNetAmt = 0.0;
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										OldNetAmt = 0.0;
										mSG2_TOTAL[14, 1] = "";
										mSG2_TOTAL[14, 2] = "";
										mSG2_TOTAL[14, 3] = "";
										mSG2_TOTAL[14, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 15;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[14, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[14, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 15;
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
							mSG2_TOTAL.Row = 15;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 15)
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
										mSG2_TOTAL[15, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										mSG2_TOTAL[15, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										mSG2_TOTAL[15, 1] = "";
										mSG2_TOTAL[15, 2] = "";
										mSG2_TOTAL[15, 3] = "";
										mSG2_TOTAL[15, 4] = "";
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
					case 1:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 1;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
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
		mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 27]), DC_Main.MsTotAmtRof), "0.00");
		if (Conversion.Val(mSG2_TOTAL[6, 2]) != 0.0)
		{
			mSG2_TOTAL[6, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[5, 3]) * Conversion.Val(mSG2_TOTAL[6, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 28]), DC_Main.MsTotAmtRof), "0.00");
		if ((Conversion.Val(mSG2_TOTAL[3, 3]) != 0.0) & (Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0))
		{
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[3, 3]) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[4, 3] = "";
		}
		mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 35]) - Conversion.Val(MSG_PR_TOT[0, 28]) - Conversion.Val(MSG_PR_TOT[0, 27]) - PrOthAmtLess, DC_Main.MsTotAmtRof), "0.00");
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_PR_TOT[0, 27]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
		}
		if (OldNetAmt != Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00")))
		{
			OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00"));
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[6, 3]), DC_Main.MsTotAmtRof), "0.00");
		mSG2_TOTAL[13, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[12, 3])), "0.00");
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			mSG2_TOTAL[11, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]), DC_Main.MsTotAmtRof), "0.00");
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
			((Control)cboRateFixType).Focus();
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
					((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
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
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.MsImageNo = "";
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
				case 304:
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
				try0001_dispatch = 304;
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

	private void TR_PR_SL_UAE_KeyUp(object sender, KeyEventArgs e)
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

	private void cboRateFixType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)tAcCode).Focus();
		}
	}

	private void TR_PR_SL_UAE_Invalidated(object sender, InvalidateEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.MsBillImgPath = "";
					DC_Main.MsImageType = "DhranImage";
					DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + "_" + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 65]));
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image.Dispose();
						PicImage.Image = null;
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				case 372:
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
				try0001_dispatch = 372;
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
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
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
					((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
					{
						DC_Main.MsImageType = "DhranImage";
						DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + "_" + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 65]));
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
							FileSystem.Kill(DC_Main.MsImagePath);
						}
						PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
						PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
					}
					goto end_IL_0001;
				case 494:
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
				try0001_dispatch = 494;
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
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
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
						DC_Main.MsImageType = "DhranImage";
						DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + "_" + Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 65]));
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
							FileSystem.Kill(DC_Main.MsImagePath);
						}
					}
					goto end_IL_0001;
				case 361:
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
				try0001_dispatch = 361;
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

	private void nOzRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nOzRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nOzRate.Text)), "0.000");
			OzCalcution();
			SendKeys.Send("{tab}");
		}
	}

	private void nFxRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFxRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFxRate.Text)), "0.000");
			OzCalcution();
			SendKeys.Send("{tab}");
		}
	}

	private void nOzConv_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nOzConv.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nOzConv.Text)), "0.0000");
			OzCalcution();
			SendKeys.Send("{tab}");
		}
	}

	private void tFxCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nMtlRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nMtlRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nMtlRate.Text)), "0.00");
			((Control)tAcCode).Focus();
		}
	}

	private void OzCalcution()
	{
		nMtlRate.Text = Strings.Format((object)(Conversion.Val(nOzRate.Text) * Conversion.Val(nFxRate.Text) / Conversion.Val(nOzConv.Text)), "0.00");
		if (MSG_PR[17] > 0 && ((Operators.CompareString(EntryMode, "A", false) == 0) & (Conversion.Val(nMtlRate.Text) != 0.0)))
		{
			MSG_PR[1, 17] = Strings.Format((object)Conversion.Val(nMtlRate.Text), "0.00");
		}
		if ((Operators.CompareString(MSG_PR[MSG_PR.Row, 20], "F", false) == 0) & (Conversion.Val(nMtlRate.Text) != 0.0))
		{
			MSG_PR[MSG_PR.Row, 21] = Strings.Format((object)Conversion.Val(nMtlRate.Text), "0.00");
		}
	}

	private void btnConsiNo_Click(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.AC_NAME As PartyNameL,SUM(A.ITM_NWT) As ItmNwtW,SUM(A.ADJ_NWT) As AdjWtW,SUM(A.ITM_NWT-A.ADJ_NWT) As BalWtW,A.CO_YEAR As YearL,A.CO_BOOK As BookL FROM (APR_DETL AS A   LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND D.MAIN_BOOK = 'CON REC'  GROUP BY A.VCH_NO,A.VCH_DATE,C.AC_NAME,A.CO_YEAR,A.CO_BOOK HAVING SUM(A.ITM_NWT-A.ADJ_NWT) > 0 ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 110.0;
		DC_Main.ColWidth[7] = 90.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tConsiNo.Text = DC_Main.ColValue[0];
				tConsiYrCd.Text = DC_Main.ColValue[6];
				tConsiDbCd.Text = DC_Main.ColValue[7];
				((Control)tConsiNo).Focus();
			}
			else
			{
				((Control)tConsiNo).Focus();
			}
		}
	}

	private void tConsiNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tConsiNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tConsiYrCd.Text + "' AND CO_BOOK = '" + tConsiDbCd.Text + "' AND VCH_NO = '" + tConsiNo.Text + "' AND CON_ISU_REC = 'N' ";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsDetl.Rows.Count == 0)
		{
			btnConsiNo_Click(btnConsiNo, new EventArgs());
			return;
		}
		tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["AC_CODE"], (object)""));
		DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.RsAc.Rows.Count > 0)
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
		}
		if ((int)Interaction.MsgBox((object)"Yes Then Consignment All Item Import In This Voucher...?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.i = 0;
			DC_Main.R = 1;
			AxMSFlexGrid mSG_PR = MSG_PR;
			checked
			{
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG_PR[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 81] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 11] = Conversions.ToString(0);
					mSG_PR[DC_Main.i + 1, 12] = Conversions.ToString(0);
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = DC_Main.MsPrAmtType;
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 34] = Conversions.ToString(0);
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 67] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["VCH_SRNO"])), "0.00");
					mSG_PR[DC_Main.i + 1, 52] = "A";
					mSG_PR[DC_Main.i + 1, 36] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 37] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["CO_YEAR"], (object)""));
					mSG_PR[DC_Main.i + 1, 38] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["CO_BOOK"], (object)""));
					mSG_PR[DC_Main.i + 1, 39] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
					mSG_PR[DC_Main.i + 1, 72] = Conversions.ToString(0);
					mSG_PR[DC_Main.i + 1, 73] = "";
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
				int num = MSG_PR_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DtIdtlPr.Columns.Add(MSG_PR_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tConsiYrCd.Text + "' AND  A.CO_BOOK = '" + tConsiDbCd.Text + "' AND A.VCH_NO = '" + tConsiNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				int num2 = 0;
				int num3 = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[19] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					if (Operators.ConditionalCompareObjectNotEqual((object)num2, RsIdtl.Rows[DC_Main.i]["SR_NO"], false))
					{
						num2 = Conversions.ToInteger(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
						num3 = 1;
						drPr[0] = num3;
					}
					else
					{
						num3++;
						drPr[0] = num3;
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
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			((Control)tAcCode).Focus();
		}
	}

	private void btnTagSet_Click(object sender, EventArgs e)
	{
	}

	private void mVchDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
	{
	}
}
